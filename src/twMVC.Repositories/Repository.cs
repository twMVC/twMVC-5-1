using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace twMVC.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : AbstractRepository<T> where T : class { }
}
