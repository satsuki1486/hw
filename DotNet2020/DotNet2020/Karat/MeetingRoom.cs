using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.Karat
{
    public class MeetingRoom
    {
        /*
         * 第一题：类似meeting rooms，输入是一个int[][] meetings, int start, int end, 每个数都是时间，13：00 =》 1300， 9：30 =》 18930，
         * 看新的meeting 能不能安排到meetings
            ex: {[1300, 1500], [930, 1200],[830, 845]}, 新的meeting[820, 830], return true; [1450, 1500] return false;
         */
        public static bool canSchedule(int[][] meetings, int start, int end)
            => meetings.All(m => (start < m[0] || start >= m[1]) && (end <= m[0] || end > m[1]) && (start >= m[0] || end <= m[1]));

        /*
        Follow up:
        We are writing a tool to help users manage their calendars. 
        Given an unordered list of times of day when people are busy, 
        write a function that tells us the intervals during the day when ALL of them are available.

        Sample input:

        p1_meetings = [
          {"start": 1230, "end": 1300},
          {"start":  845, "end":  900},
          {"start": 1300, "end": 1500},
        ]
        p2_meetings = [
          {"start":  930, "end": 1200},
          {"start": 1600, "end": 2359},
        ]
        p3_meetings = [
          {"start":  845, "end":  915},
          {"start": 1515, "end": 1545},
        ]
        schedules = [p1_meetings, p2_meetings, p3_meetings]

        Expected output:

        find_available_time(schedules)
        => [    0,  845 ],
            [  915,  930 ],
            [ 1200, 1230 ],
            [ 1500, 1515 ],
            [ 1545, 1600 ]
        */
    }
}
