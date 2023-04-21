using DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DBHelper db;
        public GenericRepository(DBHelper _db)
        {
            db = _db;
        }
        public void Delete(int id)
        {
           
            db.Set<T>().Remove(GetByID(id));
        }
        public void DeleteAll()
        {
            db.Set<T>().RemoveRange(GetAll());
        }
        public IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }
        public T GetByID(int id)
        {
            return db.Set<T>().Find(id);
        }
        public T GetByName(string name)
        {
            return db.Set<T>().Find(name);
        }
        public T GetLastID()
        {
            return db.Set<T>().Max();
        }
        public T Insert(T entity)
        {
            db.Set<T>().Add(entity);
            return entity;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public T Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //db.Set<T>().Update(entity);
            return entity;
        }
    }
}
