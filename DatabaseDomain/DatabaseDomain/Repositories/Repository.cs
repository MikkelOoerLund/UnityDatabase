using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class Repository<TEntity> : IDisposable where TEntity : class
    {
        private DbContext _database;
        private DbSet<TEntity> _entities;

        public Repository(DbContext database)
        {
            _database = database;
            _entities = database.Set<TEntity>();
        }


        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public void Update()
        {
            _database.SaveChanges();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        protected DbSet<TEntity> Entities => _entities;
    }
}
