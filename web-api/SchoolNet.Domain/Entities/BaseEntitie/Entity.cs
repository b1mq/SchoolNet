using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Domain.Entities.BaseEntitie
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
