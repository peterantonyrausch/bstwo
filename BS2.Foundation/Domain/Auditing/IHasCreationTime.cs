using System;

namespace BS2.Foundation.Domain.Auditing
{
    public interface IHasCreationTime
    {
        DateTime CreatedOn { get; }
    }
}