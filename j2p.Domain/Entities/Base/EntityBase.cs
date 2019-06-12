using System;
using prmToolkit.NotificationPattern;

namespace j2p.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}
