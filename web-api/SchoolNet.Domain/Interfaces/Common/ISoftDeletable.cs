using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Domain.Interfaces.Common
{
    public interface ISoftDeletable
    {
        public bool isDeleted { get; }
        public void SoftDelete();
    }
}
