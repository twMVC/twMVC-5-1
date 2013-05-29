using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Entity;

namespace twMVC.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// context
        /// </summary>
        ObjectContext Context { get; }
        /// <summary>
        /// save change
        /// </summary>
        void Save();
        /// <summary>
        /// 連線字串
        /// </summary>
        string ConnectionString { get; set; }
    }
}