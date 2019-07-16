using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class ListLineToObjList
    {
        public static Cube ListLineToObjListMap(List<SampleInputLine> inputlineList)
        {

            Cube cube = new Cube();
            cube.Details = new List<string>();

            string testCaseString = inputlineList.Where(x => x.InputLine.Length == 1).ToList().FirstOrDefault().InputLine;
            cube.TestCase =  Convert.ToInt32(testCaseString);

            var listQuery = inputlineList.Where(x => x.InputLine.Contains("QUERY") || x.InputLine.Contains("UPDATE")).ToList();
            foreach( var query in listQuery)
            {
                cube.Details.Add(query.InputLine);
            }

            cube.Querys = inputlineList.Where(x => x.InputLine.Length == 3).ToList().FirstOrDefault().InputLine;
        

            return cube;
        }
    }
}
