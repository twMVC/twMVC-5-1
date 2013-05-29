using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Entity;
using twMVC.Interface;
using twMVC.Repositories.EF;

namespace twMVC.Repositories
{
    public partial class EFUnitOfWork : IUnitOfWork
    {
        public ObjectContext Context
        {
            get
            {
                return new NorthwindEntities();
            }
        }
        public void Save()
        {
            Context.SaveChanges();
        }

        public string ConnectionString
        {
            get { return Context.Connection.ConnectionString; }
            set { Context.Connection.ConnectionString = value; }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}