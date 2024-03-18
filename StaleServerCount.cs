﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank
{
    internal class StaleServerCount
    {
        internal static void Run()
        {
            #region Sample Input 0
            //int n = 6, m = 4;
            //List<List<int>> log_data = [[3, 2],
            //    [4, 3],
            //    [2, 6],
            //    [6, 3]];
            //List<int> query = [3, 2, 6];
            //int X = 2; 
            #endregion

            #region Sample Input 1
            //int n = 6, m = 4;
            //List<List<int>> log_data = [[3, 2],
            //    [4, 3],
            //    [2, 6],
            //    [6, 3]];
            //List<int> query = [1,2,3,4,5,6];
            //int X = 1;
            #endregion

            #region Sample Input 2
            int n = 4, m = 4;
            List<List<int>> log_data = [[1,3],
                [2, 6],
                [1,5],
                [3,4]
                ];
            List<int> query = [10,6];
            int X = 5;
            #endregion


            var result = new List<int>();
            var hashMap = new HashSet<int>();

            foreach(var item in query)
            {
                int start = item - X;
                int end = item;
                hashMap.Clear();
                //var loggedServers = log_data.Where( x => x[1] >= start && x[1] <= end).Distinct(y => y[0]);
                foreach(var log in log_data)
                {
                    if(log[1] >= start && log[1] <= end)
                    {
                        if (!hashMap.Contains(log[0]))
                            hashMap.Add(log[0]);
                    }
                }
                result.Add(n-hashMap.Count);
            }

            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
