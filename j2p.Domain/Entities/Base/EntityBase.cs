using System;

namespace j2p.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}
