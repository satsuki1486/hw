using System;
using System.Collections.Generic;
using System.Text;
using ConcurrentPriorityQueue;
using PriorityQueueCollection;

namespace DotNet2020.Wayfair
{
    public static class MeetingScheduler
    {
        /*
         * We are writing a tool to help users manage their calendars.
         * Given an unordered list of times of day when people are busy,
         * write a function that tells us the intervals during the day when ALL of them are available.
         * Each time is expressed as an integer using 24-hour notation, such as 1200 (12:00), 1530 (15:30), or 800 (8:00).
         * Example input:
         * p1_meetings = [
           (1230, 1300),
           ( 845, 900),
           (1300, 1500),
           ]
           
           p2_meetings = [
           ( 0, 844),
           ( 930, 1200),
           (1515, 1546),	
           (1600, 2400),
           ]
           
           p3_meetings = [
           ( 845, 915),
           (1515, 1545),
           (1235, 1245),
           ]
           
           p4_meetings = [
           ( 1, 5),
           (844, 900),
           (1515, 1600)
           ]
           
           schedules1 = [p1_meetings, p2_meetings, p3_meetings]
           schedules2 = [p1_meetings, p3_meetings]
           schedules3 = [p2_meetings, p4_meetings]
           
           Expected output:
           
           findAvailableTimes(schedules1)
           => [  844,  845 ],
           [  915,  930 ],
           [ 1200, 1230 ],
           [ 1500, 1515 ],
           [ 1546, 1600 ]
           
           findAvailableTimes(schedules2)
           => [    0,  845 ],
           [  915, 1230 ],
           [ 1500, 1515 ],
           [ 1545, 2400 ]
           
           findAvailableTimes(schedules3)
           [  900,  930 ],
           [ 1200, 1515 ]
           
           n = number of meetings
           s = number of schedules
         */
        /*
         *     public static ArrayList<ArrayList<Integer>> findSchedules(List<int[][]> schedules) {
                    ArrayList<ArrayList<Integer>> result = new ArrayList<ArrayList<Integer>>();
                    PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a, b) -> a[1] - b[1]);
                    List<int[]> flat = schedules.stream().flatMap(Arrays::stream).collect(Collectors.toList());
                    Collections.sort(flat, (o1, o2) -> o1[0] - o2[0]);
                    int[] first = flat.get(0);
                    pq.offer(first);
                    if (first[0] > 0) {
                        ArrayList<Integer> curr = new ArrayList<Integer>();
                        curr.add(0);
                        curr.add(first[0]);
                        result.add(curr);
                    }
                    for (int[] meeting: flat) {
                        int[] top = pq.poll();
                        if (top[1] < meeting[0]) {
                            ArrayList<Integer> curr1 = new ArrayList<Integer>();
                            curr1.add(top[1]);
                            curr1.add(meeting[0]);
                            result.add(curr1);                
                        } else {
                            int[] newMeeting = {top[0], Math.max(top[1], meeting[1])};
                            pq.offer(newMeeting);
                        }
                    }
                    int[] last = pq.poll();
                    if (last[1] < 2359) {
                        ArrayList<Integer> curr2 = new ArrayList<Integer>();
                        curr2.add(last[1]);
                        curr2.add(2359);
                        result.add(curr2);
                    }        
                    return result;
                }
         */
    }
}
