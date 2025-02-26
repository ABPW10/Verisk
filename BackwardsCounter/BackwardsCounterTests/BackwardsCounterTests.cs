using static BackwardsCounter;

namespace Tests
{
    [TestClass()]
    public class BackwardsCounterTests
    {
        [TestMethod()]
        public void MainTest()
        {
            List<string[]> invalidInputs = new List<string[]>{
                new string[] {"1","1" },
                new string[] { "5","25" },
                new string[] { "25","7" },
                new string[] { "25","xyz" },
                new string[] { "-25","5" },
            };
            List<string[]> divisionByZero = new List<string[]>{
                new string[] {"25","0"},
            };
            List<string[]> outOfRange = new List<string[]>{
                new string[] {"1010","10"},
            };
            List<string[]> validInputs = new List<string[]>{
                new string[] {"25","5"},
                new string[] {"7","7"},
            };

            foreach (var inputNumbers in invalidInputs)
            {
                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                Main(inputNumbers);
                Assert.AreEqual<string>("Invalid input", sw.ToString().ReplaceLineEndings(""));
                sw.Close();
            }

            foreach (var inputNumbers in divisionByZero)
            {
                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                Main(inputNumbers);
                Assert.AreEqual<string>("Division by zero error", sw.ToString().ReplaceLineEndings(""));
                sw.Close();
            }

            foreach (var inputNumbers in outOfRange)
            {
                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                Main(inputNumbers);
                Assert.AreEqual<string>("Out of range", sw.ToString().ReplaceLineEndings(""));
                sw.Close();
            }

            foreach (var inputNumbers in validInputs)
            {
                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                Main(inputNumbers);
                Assert.IsTrue(sw.ToString().ReplaceLineEndings("").EndsWith(inputNumbers[1]));
                sw.Close();
            }
        }
    }
}