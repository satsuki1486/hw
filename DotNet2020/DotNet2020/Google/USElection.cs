using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.Google
{
    public static class USElection
    {
        /**
         * Input:
        - num_states：int
        - delegates: int[]
        - votes_president_A: int[]
        - votes_president_B: int[]
        - votes_Undecided: int[]

        output: the minimum number of people vote A will lead A win, output -1 if not valid (int)

        example:

        input1:
        num_states = 3
        [delegate, vote_A, vote_B, undecided)
        state 1: 5 0 0 20
        state 2: 4 0 0 19
        state 3: 2 0 0 10

        output1:
        16

        Input 2:
        3
        7 100 200 200
        8 100 300 200
        9 100 400 200
        Output 2: -1
        */
        public static int Solution(int numOfStates, int[] delegates, int[] votesPresidentA, int[]
            votesPresidentB, int[] votesUndecided)
        {
            // <# of delegets, min votes A to win>
            var minVotes = new Dictionary<int, int>();
            for (var i = 0; i < numOfStates; i++)
            {
                var totalVotes = votesPresidentA[i] + votesPresidentB[i] + votesUndecided[i];
                var minVotesNeeded = (totalVotes / 2 + 1) - votesPresidentA[i];
                if (minVotesNeeded <= votesUndecided[i])
                    minVotes[delegates[i]] = minVotesNeeded;
            }

            var result = int.MaxValue;
            var cost = minVotes.Values.ToArray();
            var gain = minVotes.Keys.ToArray();
            var sum = gain.Sum();
            var dp = new int[sum + 1];
            for (var i = 0; i < gain.Length; i++) {
                for (var j = sum; j >= gain[i]; i--)
                {
                    dp[j] = dp[j - cost[i]] + gain[i];
                    if (j > sum / 2)
                        result = Math.Min(result, j);
                }
            }

            return result == int.MaxValue ? -1 : result;
        }

    }
}
