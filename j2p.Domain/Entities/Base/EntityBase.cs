using System;
using System.Text;

namespace j2p.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        protected readonly StringBuilder _errors;

        public virtual Guid Id { get; set; }

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            _errors = new StringBuilder();
        }

        public virtual void Validate()
        {
            
        }

        public void ChangeId(Guid id)
        {
            this.Id = id;
        }
    }
}
