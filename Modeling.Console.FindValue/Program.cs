using Modeling.Logic;

namespace Modeling.Console.FindValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = 1000000000;

            for (var i = 57315; i < m; i = 2*i + 1)
            {
                for (var j = 2; j < i; j = j*2 + 1)
                {
                    LehmerGenerator.Reset();
                    LehmerGenerator.M = i;
                    LehmerGenerator.A = j;
                    LehmerGenerator.R = 1;
                    if (LehmerGenerator.GetShift() > 50000)
                    {
                        System.Console.WriteLine(
                            $"Period {LehmerGenerator.GetPeriod()} Shift {LehmerGenerator.GetShift()} m {i} a {j} r {1}");
                    }
                }
            }
            System.Console.WriteLine("finished");
            System.Console.ReadLine();
        }

        public static LehmerRandomNumberGenerator LehmerGenerator = new LehmerRandomNumberGenerator();
    }
}
