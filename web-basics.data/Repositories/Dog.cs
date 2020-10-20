using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data.Repositories
{
    public class Dog
    {
        WebBasicsDBContext context;

        public Dog(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Dog> Get()
        {
            var dogs = context.Dogs.ToList();
            return dogs;
        }
        public Entities.Dog Get(int id)
        {
            Entities.Dog dog = context.Dogs.FirstOrDefault(x => x.Id == id);
            return dog;
        }
        public void Post(Entities.Dog dog)
        {
             context.Dogs.Add(dog);
             context.SaveChanges();
        }
        public void Put(Entities.Dog dog)
        {
            context.Update(dog);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Entities.Dog dog = context.Dogs.FirstOrDefault(x => x.Id == id);
            if (dog != null)
            {
                context.Dogs.Remove(dog);
                context.SaveChanges();
            }

        }
    }
}
