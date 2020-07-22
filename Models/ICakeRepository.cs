using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public interface ICakeRepository
    {
        IEnumerable<Cake> Get();
        Cake Get(int id);
        Cake Create(Cake cake);
        Cake Edit(Cake cake);
        bool Remove(int id);
    }
}
