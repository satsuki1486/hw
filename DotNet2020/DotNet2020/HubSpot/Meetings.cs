using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DotNet2020.HubSpot
{
    public class Meetings
    {
        /*
         * For each country  get available time slots for two day meeting , build result json and post it to another end point.  
            给你一个 HTTP End Point, make http get call will have json like , merge all time slot (two day) together
            {"partners":[
            {"firstName":"Jana","lastName":"Carnall","email":"jcarnall@hubspotpartners.com","country":"United States","availableDates":["2017-05-29","2017-05-31","2017-06-03","2017-06-04","2017-06-05","2017-06-06"]},
            {"firstName":"Allegra","lastName":"Bitton","email":"abitton@hubspotpartners.com","country":"United States","availableDates":["2017-05-27","2017-05-31","2017-06-02","2017-06-03","2017-06-04","2017-06-05","2017-06-06","2017-06-19"]} ... }
         */
        public static Response HandleInput(string input)
        {
            var requestRoot = JsonConvert.DeserializeObject<Request>(input);
            var countryMap = requestRoot.Partners.GroupBy(e => e.Country).ToDictionary(key => key.Key, value => value.ToList());
            // 2 days
            const int interval = 1;
            var result = new List<Country>();
            foreach (var country in countryMap)
            {
                var datesCount = new Dictionary<DateTime, SortedSet<string>>();
                foreach (var p in country.Value)
                {
                    foreach (var date in p.AvailableDates)
                    {
                        if (!datesCount.ContainsKey(date))
                            datesCount[date] = new SortedSet<string>();
                        datesCount[date].Add(p.Email);
                    }
                }

                var daysByCount = datesCount.OrderByDescending(d => d.Value.Count).Select(d => d.Key).ToList();
                var bestDate = daysByCount[0];
                var attendeeCount = 0;
                for (var i = 0; i < daysByCount.Count - 1; i++)
                {
                    if ((daysByCount[i + 1] - daysByCount[i]).Days != interval) continue;
                    bestDate = daysByCount[i];
                    attendeeCount = datesCount[bestDate].Count;
                    break;
                }
                result.Add(new Country
                {
                    attendeeCount = attendeeCount,
                    attendees = datesCount[bestDate],
                    name = country.Key,
                    startDate = bestDate.Date.ToString("yyyy-MM-dd")
                });
            }
            return new Response
            {
                countries = result
            };
        }
    }

    public class Request
    {
        public Partner[] Partners { get; set; }
    }

    public class Partner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public SortedSet<DateTime> AvailableDates { get; set; }
    }

    public class Response
    {
        public List<Country> countries { get; set; }
    }

    public class Country
    {
        public int attendeeCount { get; set; }
        public SortedSet<string> attendees { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
    }
}
