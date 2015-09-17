using System.Text;
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
        [TestCase(100, 2, 1, 10000)]
        [TestCase(1000, 2, 1, 10000)]
        [TestCase(10000000, 17, 1, 10000)]
        public void MathExpectedTest(int m, int a, int r, int count)
        {
            var itemsCount = 0;
            double summ = 0;
            LehmerGenerator.M = m;
            LehmerGenerator.A = a;
            LehmerGenerator.R = r;

            for (int i = 0; i < count; i++)
            {
                itemsCount++;
                summ += LehmerGenerator.Next();
            }
            Assert.Greater(itemsCount, 0);  
            Assert.AreEqual(0.5, summ / itemsCount, 0.05);
        }

        [Test]
        [TestCase(131071, 59656, 1)]
        [TestCase(59656, 596, 1)]
        public void PeriodTest(int m, int a, int r)
        {
            LehmerGenerator.M = m;
            LehmerGenerator.A = a;
            LehmerGenerator.R = r;

            Assert.Greater(LehmerGenerator.GetShift(), 5000);
            Assert.Greater(LehmerGenerator.GetPeriod(), 5000);
            Assert.Greater(LehmerGenerator.GetShift(), 50000);
            Assert.Greater(LehmerGenerator.GetPeriod(), 50000);
        }
    }
}
