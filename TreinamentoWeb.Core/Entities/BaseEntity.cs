using System;

namespace TreinamentoWeb.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            //ID = Guid.NewGuid();
        }

        protected BaseEntity(bool active) : this()
        {
            Active = active;
        }

        //public Guid ID { get; private set; }
        public bool Active { get; set; }

        public void Activate()
        {
            Active = true;
        }
    }
}
