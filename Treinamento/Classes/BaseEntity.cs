using System;

namespace Treinamento.Classes
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            ID = Guid.NewGuid();
        }

        protected BaseEntity(bool active) : this()
        {
            Active = active;
        }

        public Guid ID { get; private set; }
        protected bool Active { get; set; }

        public void Activate()
        {
            Active = true;
        }
    }
}
