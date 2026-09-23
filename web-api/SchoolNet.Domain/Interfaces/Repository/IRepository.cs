using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IRepository<TEnitity>:IReadRepository<TEnitity>,IWriteRepository<TEnitity> where TEnitity: AbstractEntity
    {

    }
}
