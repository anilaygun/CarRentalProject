using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntities, TContext> : IEntityRepository<TEntities>
        where TEntities : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntities entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntities entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntities entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public TEntities Get(Expression<Func<TEntities, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntities>().SingleOrDefault(filter);
            }
        }

        public List<TEntities> GetAll(Expression<Func<TEntities, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {

                return filter == null
                 ? context.Set<TEntities>().ToList()
                 : context.Set<TEntities>().Where(filter).ToList();

            }
        }
    }
}
