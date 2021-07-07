using System;

namespace BS2.Foundation.Domain.Auditing
{
    public interface IMayHaveCreator
    {
        Guid? CreatedBy { get; }
    }
}