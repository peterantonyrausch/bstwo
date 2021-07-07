using System;

namespace BS2.Foundation.Domain.Auditing
{
    //TODO: segregação de interface igual o CreationAuditedEntity
    public class FullAuditedEntity<TKey> : AuditedEntity<TKey>
    {
        public virtual bool IsDeleted { get; set; }

        public virtual Guid? DeletedBy { get; set; }

        public virtual DateTime? DeletedOn { get; set; }
    }
}