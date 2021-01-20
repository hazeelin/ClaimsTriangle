using ClaimsTriangle;
using NUnit.Framework;

namespace ClaimsTriangleUnitTests
{
    [TestFixture]
    public class ProcessTriangleTests
    {
        [Test]
        [TestCase("1990, 4", "Comp, 0, 0, 0, 0, 0, 0, 0, 110, 280, 200", "Non-Comp, 45.2, 110, 110, 147, 50, 125, 150, 55, 140, 100")]
        public void ProcessTriangle_WhenCalled_ReturnsAList(string line1, string line2, string line3)
        {
            string fileIn = @"data.csv";
            var linesInOutputFile = new ProcessTriangle(new LoadCsv(fileIn), ",").Process();

            Assert.That(linesInOutputFile[0].Equals(line1));
            Assert.That(linesInOutputFile[1].Equals(line2));
            Assert.That(linesInOutputFile[2].Equals(line3));
        }
    }
}