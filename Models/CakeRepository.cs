using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public class CakeRepository : ICakeRepository
    {
        private readonly AppDbContext context;
        public CakeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Cake Create(Cake cake)
        {
            context.Cakes.Add(cake);
            context.SaveChanges();
            return cake;
        }

        public Cake Edit(Cake cake)
        {
            var editCake = context.Cakes.Attach(cake);
            editCake.State = EntityState.Modified;
            context.SaveChanges();
            return cake;

        }

        public IEnumerable<Cake> Get()
        {
            return context.Cakes;
        }

        public Cake Get(int id)
        {
            return context.Cakes.Find(id);
        }

        public bool Remove(int id)
        {
            var cake = Get(id);
            if (cake != null)
            {
                cake.IsDeleted = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
