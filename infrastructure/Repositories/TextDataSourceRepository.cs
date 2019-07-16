using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Repositories
{
    public class TextDataSourceRepository : ITextDataSourceRepository
    {
        public List<SampleInputLine> GetListInputLine(string routeArchive)
        {
            var listSampleInputLine = new List<SampleInputLine>();

            var dataSourceTxt = new StreamReader(routeArchive);

            while (!dataSourceTxt.EndOfStream)
            {
                listSampleInputLine.Add(new SampleInputLine()
                {
                    InputLine = dataSourceTxt.ReadLine()
                });
            }

            return listSampleInputLine;
        }
    }
}
