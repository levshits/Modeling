using NUnit.Framework;
using Spring.Context.Support;
using Spring.Testing.NUnit;


namespace Modeling.Logic.Test
{
    [TestFixture]
    public class LehmerGeneratorTest: TestFixtureBase
    {
        public LehmerRandomNumberGenerator LehmerGenerator { get; set; }

        [TearDown]
        public void TearDownTest()
        {
            LehmerGenerator.Reset();
        }

        [Test]
        public void LehmerGeneratorSpringTest()
        {
            Assert.IsNotNull(LehmerGenerator);
        }

        [Test]
        [TestCase(100, 2, 1)]
        [TestCase(1000, 2, 1)]
        [TestCase(10000000, 17, 1)]
        public void MathExpectedTest(int m, int a, int r)
        {
            var itemsCount = 0;
            double summ = 0;
            LehmerGenerator.IsStopOnCycleDetectionEnabled = true;
            LehmerGenerator.M = m;
            LehmerGenerator.A = a;
            LehmerGenerator.R = r;
            
            while (LehmerGenerator.MoveNext())
            {
                itemsCount++;
                summ += (double)LehmerGenerator.Current;
                if (itemsCount%1000 == 0)
                {
                    Assert.AreEqual(0.5, summ / itemsCount, 0.05);
                }
            }
            Assert.Greater(itemsCount, 0);  
            Assert.AreEqual(0.5, summ / itemsCount, 0.05);
        }
    }
}
