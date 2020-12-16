using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Google
{
    public static class ComputerCoreAndTasks
    {
        /*
         * Given two arrays a,b with positive integers
            the item i in a represents a server which hasa[i] cores.
            the item iin b represents a tasks that needs b[i] cores in order to be execute.
            single server can run multiple tasks but single task can only be execte in single server.

            return true if servers can run the tasks and false otherwise.

            examples:

            a = [2,4] b = [1,1,4]
            1,1->2
            4-> 4
            result = true
            a = [1,3] b = [2,2]
            result = false
            a = [8,10] b = [2,3,3,3,7]
            2,3,3->8
            3,7 -> 10
            result = true
         */
        public static bool CanExecute(int[] cores, int[] tasks, int t)
        {
            if (t == tasks.Length)
                return true;
            for (var i = 0; i < cores.Length; i++)
            {
                if (cores[i] >= tasks[t])
                    cores[i] -= tasks[t];
                if (CanExecute(cores, tasks, t + 1))
                    return true;
                // backtrack
                cores[i] += tasks[t];
            }

            return false;
        }
    }
}
