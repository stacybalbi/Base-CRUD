using Base_CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_CRUD.Servicios
{
    public interface IBaseCrudService<TEntity> where TEntity : Base
    {
        List<TEntity> Get();
        IQueryable<TEntity> Query();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
    }
    public class BaseCrudServices<TEntity> : IBaseCrudService<TEntity> where TEntity : Base
    {

        protected List<TEntity> Database;

        private int IdCounter; 

        public BaseCrudServices()
        {
            Database = new List<TEntity>();
            IdCounter = 1;
        }

        public List<TEntity> Get()
        {
            return Query().ToList();
        }

        public IQueryable<TEntity> Query()
        {
            return Database.AsQueryable().Where(x=> !x.Deleted);
        }
        public TEntity GetById(int id)
        {
            return Query().FirstOrDefault(entity => entity.ID == id);
        }

        public TEntity Create(TEntity entity)
        {
            entity.ID = IdCounter;
            Database.Add(entity);
            IdCounter++;
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            var existingEntity = GetById(entity.ID);
            if (existingEntity == null)
            {
                throw new Exception($"{nameof(TEntity)} con id {entity.ID} no existe");
            }
            existingEntity = entity;
            return  existingEntity;
        }

       

        public TEntity Delete(int id)
        {
            var existingEntity = GetById(id);
            if (existingEntity == null)
            {
                throw new Exception($"{nameof(TEntity)} con id {id} no existe");
            }
            existingEntity.Deleted = true;
            return existingEntity;
        }
    }
}
