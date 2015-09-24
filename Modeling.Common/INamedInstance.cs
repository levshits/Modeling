using System;

namespace Modeling.Common
{
    public interface INamedInstance
    {
        string Name { get;} 
        Guid Id { get; }
    }
}