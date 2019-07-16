using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Application.Helpers
{
    public class CubeSummationHelper
    {

        public static List<long> CubeSummation(Cube inputLine)
        {
            List<long> sumList = new List<long>();
            sumList = CubeSummationOperation(inputLine);
            return sumList;
        }

        private static List<long> CubeSummationOperation(Cube inputLine)
        {
            int tests = inputLine.TestCase;

            int queries = 0;
            string dimAndQueries = null;
            string details = null;

            List<long> sumList = new List<long>();

            Dictionary<string, int> input = new Dictionary<string, int>();
            string key = null;
            int val = 0;

            int[] values;
            string[] rawKeys;
            int key0 = 0;
            int key1 = 0;
            int key2 = 0;

            long sum = 0;

            for (int test = 0; test < tests; test++)
            {
                input.Clear();
                foreach (var detail in inputLine.Details)
                {
                    dimAndQueries = inputLine.Querys;

                    queries = int.Parse(dimAndQueries.Split(' ')[1]);

                    for (int query = 0; query < queries; query++)
                    {
                        details = detail;

                        if (details.StartsWith("UPDATE"))
                        {
                            values = details.Replace("UPDATE ", "").Split(' ').Select(s => int.Parse(s)).ToArray();
                            key = values[0] + "-" + values[1] + "-" + values[2];
                            val = values[3];

                            if (!input.ContainsKey(key) && val != 0)
                            {
                                input.Add(key, val);
                            }
                            else
                            {
                                if (val == 0)
                                {
                                    input.Remove(key);
                                }
                                else
                                {
                                    input[key] = val;
                                }
                            }

                            continue;
                        }

                        sum = 0;
                        values = details.Replace("QUERY ", "").Split(' ').Select(s => int.Parse(s)).ToArray();

                        foreach (string rawKey in input.Keys)
                        {
                            rawKeys = rawKey.Split('-');
                            key0 = int.Parse(rawKeys[0]);
                            key1 = int.Parse(rawKeys[1]);
                            key2 = int.Parse(rawKeys[2]);

                            if (values[0] <= key0 && key0 <= values[3] && values[1] <= key1 && key1 <= values[4] && values[2] <= key2 && key2 <= values[5])
                            {
                                sum += input[rawKey];
                             
                            }
                           
                        }
                       
                    }
                    sumList.Add(sum);
                }
            }
            return sumList;
        }
    }
}
