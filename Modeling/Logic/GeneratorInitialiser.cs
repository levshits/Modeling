using System;
using Modeling.Common;
using Modeling.Model;

namespace Modeling.Logic
{
    public static class GeneratorInitialiser
    {
        public static void Init(this LehmerRandomNumberGenerator generator, InitialParametersBase parameters)
        {
            var model = (InitialParametersModel) parameters;
            generator.M = model.M;
            generator.A = model.A;
            generator.R = model.InitialValue;
        }

        public static void Init(this NormalDistributionGenerator generator, InitialParametersBase parameters)
        {
            var model = (NormalDistributionParameters)parameters;
            generator.A = model.A;
            generator.B = model.B;
        }

        public static void Init(this GaussGenerator generator, InitialParametersBase parameters)
        {
            var model = (GausGeneratorParameters)parameters;
            generator.Mx = model.Mx;
            generator.SigmaX = model.SigmaX;
            generator.N = model.N;
        }

        public static void Init(this ExpGenerator generator, InitialParametersBase parameters)
        {
            var model = (ExpGeneratorParameters)parameters;
            generator.Lambda = model.Lambda;
        }

        public static void Init(this GammaGenerator generator, InitialParametersBase parameters)
        {
            var model = (GammaGeneratorParameters)parameters;
            generator.Lambda = model.Lambda;
            generator.N = model.N;
        }

        public static void Init(this TriangleGenerator generator, InitialParametersBase parameters)
        {
            var model = (TriangleGeneratorParameters)parameters;
            generator.A = model.A;
            generator.B = model.B;
        }

        public static void Init(this SipmsonGenerator generator, InitialParametersBase parameters)
        {
            var model = (SimpsonGeneratorParameters)parameters;
            generator.A = model.A;
            generator.B = model.B;
        }

        public static void Init(this IRandomNumberGenerator generator, InitialParametersBase parameters)
        {
            if (generator is LehmerRandomNumberGenerator)
            {
                ((LehmerRandomNumberGenerator)generator).Init(parameters);
            }
            else if(generator is NormalDistributionGenerator)
            {
                ((NormalDistributionGenerator)generator).Init(parameters);
            }
            else if (generator is GaussGenerator)
            {
                ((GaussGenerator)generator).Init(parameters);
            }
            else if (generator is ExpGenerator)
            {
                ((ExpGenerator)generator).Init(parameters);
            }
            else if (generator is GammaGenerator)
            {
                ((GammaGenerator)generator).Init(parameters);
            }
            else if (generator is TriangleGenerator)
            {
                ((TriangleGenerator)generator).Init(parameters);
            }
            else if (generator is SipmsonGenerator)
            {
                ((SipmsonGenerator)generator).Init(parameters);
            }
        }
    }
}