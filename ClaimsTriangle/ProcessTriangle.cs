using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClaimsTriangle
{
    public class ProcessTriangle
    {
        private readonly ILoadCsv _loadCsv;
        private readonly string _fileOut;
        private readonly string _delimiter;


        public virtual List<String> Process()
        {
            try
            {
                var triangles = _loadCsv.GetData();
                int minYear = Convert.ToInt32(triangles.Min(t => t.OriginYear));
                int maxYear = Convert.ToInt32(triangles.Max(t => t.DevelopmentYear));
                int devYearCount = maxYear - minYear;

                var products = from t in triangles
                               group t by t.Product into p
                               select p;
                StringBuilder sb = new StringBuilder("");
                List<string> outputLines = new List<string>();

                int count = triangles.Count();
                int yearRange = devYearCount + 1;
                if (count > 0)
                {
                    outputLines.Add(minYear + _delimiter + " " + yearRange);



                    foreach (var product in products)
                    {
                        sb = sb.Clear();
                        sb.Append(product.Key);
                        for (int row = 0; row <= devYearCount; row++)
                        {
                            int originYear = minYear + row;
                            int devYear = minYear + row;
                            decimal accumTotal = 0;
                            while (devYear <= maxYear)
                            {
                                IEnumerable<decimal> claimedYearsForProduct = triangles.Where(t => t.Product == product.Key
                                                                && t.OriginYear.Trim() == originYear.ToString()
                                                                && t.DevelopmentYear.Trim() == devYear.ToString())
                                                                .Select(t => t.IncrementalValue);
                                accumTotal += claimedYearsForProduct.FirstOrDefault();
                                sb.Append(_delimiter + " " + accumTotal.ToString("G29"));
                                devYear++;
                            }
                        }
                        outputLines.Add(sb.ToString());
                    }
                    return outputLines;
                }

                throw new Exception("No data found in the file provided");

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void WriteOutputFile(List<string> linesForOutput)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_fileOut))
                {
                    foreach (var line in linesForOutput)
                    {
                        sw.WriteLine(line);
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public ProcessTriangle(ILoadCsv loadCsv, string fileOut, string delimiter)
        {
            _loadCsv = loadCsv;
            _fileOut = fileOut;
            _delimiter = delimiter;
            WriteOutputFile(Process());
        }

        public ProcessTriangle(ILoadCsv loadCsv, string delimiter)
        {
            _loadCsv = loadCsv;
            _delimiter = delimiter;
        }
    }
}
