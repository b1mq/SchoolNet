using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Domain.Entities.BaseEntitie
{
    public abstract class AbstractEntity:Entity
    {
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;
        public void UpdateTimeStamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
