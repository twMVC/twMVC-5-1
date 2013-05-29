using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Entity;
using twMVC.Interface;

namespace twMVC.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new EFUnitOfWork();
            }
        }

        public string EntityName
        {
            get
            {
                return typeof(T).Name;
            }
        }

        public virtual ObjectQuery<T> GetAll()
        {
            return UnitOfWork.Context.CreateQuery<T>(string.Concat("[", EntityName, "]"));
        }

        public virtual void Create(T entity)
        {
            UnitOfWork.Context.AddObject(EntityName, entity);
        }

        public virtual void Delete(T entity)
        {
            UnitOfWork.Context.DeleteObject(entity);
        }

        public virtual void Save()
        {
            UnitOfWork.Save();
        }
    }
}