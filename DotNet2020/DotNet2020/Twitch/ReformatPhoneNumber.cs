using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Twitch
{
    public class ReformatPhoneNumber
    {
        /*
         * Give a tel number reformat it from "123456789" to "123-456-789", the last 2 grp can be only 2 digits
         */
        public string Format(string number)
        {
            return $"{number.Substring(0, 3)}-{number.Substring(3, (number.Length - 3) / 2)}-{number.Substring(3 + (number.Length - 3) / 2)}";
        }
    }
}
