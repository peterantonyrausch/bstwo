using System;

namespace BS2.Foundation.Domain.Auditing
{
    public class AuditedEntity<TKey> : CreationAuditedEntity<TKey>
    {
        public virtual DateTime ModifiedOn { get; protected set; }

        public virtual Guid? ModifiedBy { get; protected set; }
    }
}