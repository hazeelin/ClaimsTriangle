using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ClaimsTriangle
{
    public class LoadCsv : ILoadCsv
    {
        private readonly string _file;

        public virtual List<Triangle> GetData()
        {
            try
            {
                using (var reader = new StreamReader(_file))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var triangles = new List<Triangle>();
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var triangle = new Triangle
                        {
                            Product = csv[0],
                            OriginYear = csv[1],
                            DevelopmentYear = csv[2],
                            IncrementalValue = Convert.ToDecimal(csv[3])
                        };
                        triangles.Add(triangle);
                    }
                    return triangles;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public LoadCsv(string file)
        {
            _file = file;
        }
    }
}
