using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
    }
}
