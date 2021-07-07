using System;

namespace BS2.Foundation.Domain.Auditing
{
    public abstract class CreationAuditedEntity<TKey> : Entity<TKey>, IHasCreationTime, IMayHaveCreator
    {
        public virtual DateTime CreatedOn { get; protected set; }

        public virtual Guid? CreatedBy { get; protected set; }
    }
}