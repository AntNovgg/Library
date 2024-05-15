using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Seeds
{
    public abstract class Entity
    {
        private Guid _id;
        public virtual Guid Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }

}
