using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using twMVC.Common;
using twMVC.Interface;
using twMVC.Repositories.EF;

namespace twMVC.Interface
{
    public class RandomEmployeeNameService : IRandomEmployeeNameService
    {
        public IRepository<Employees> Rep { get; set; }

        public Employees GetEmployee()
        {
            var itemCount = Rep.GetAll().Count();
            Random r = new Random();
            var index = r.Next(1, itemCount);
            return Rep.GetAll()
                        .OrderBy(a => a.EmployeeID)
                        .Skip(index - 1)
                        .Take(1)
                        .First();
        }
    }
}
