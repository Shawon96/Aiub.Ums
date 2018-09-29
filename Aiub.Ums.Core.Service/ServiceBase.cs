using System;
using Aiub.Ums.Core.Service.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Aiub.Ums.Core.Service
{
    public abstract class ServiceBase<T> : IService<T> where T : class
    {
        private readonly DbContext _context;
        protected DbContext Context => this._context;

        protected ServiceBase(DbContext context)
        {
            this._context = context;
        }

        public bool Add(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Edit(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove<TKey>(TKey id)
        {
            try
            {
                T entity = _context.Set<T>().Find(id);
                _context.Entry(entity).State = EntityState.Deleted; 
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T GetById<TKey>(TKey id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
