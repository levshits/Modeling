using System;
using Modeling.Common;

namespace Modeling.Logic
{
    public class SipmsonGenerator: IRandomNumberGenerator
{
    public string Name => "Simpson generator";
    public Guid Id => GeneratorsConstants.SIMPSON_GENERATOR;
    private Random _random = new Random();
    private double? _a;
    private double? _b;
    public int A { get; set; }
    public int B { get; set; }

    public double Next()
    {
        if (!_a.HasValue)
        {
            _a = A;
            _b = B;
        }
        return _a.Value/2 + (_b.Value/2 - _a.Value/2)*_random.NextDouble() + _a.Value / 2 + (_b.Value / 2 - _a.Value / 2) * _random.NextDouble();
    }

    public void Reset()
    {
        _a = null;
        _b = null;
    }
}

}