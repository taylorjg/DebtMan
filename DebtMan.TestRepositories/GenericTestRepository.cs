using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DebtMan.DomainModel.Repositories;

namespace DebtMan.TestRepositories
{
    internal class GenericTestRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        private readonly Type _entityType = typeof(TEntity);
        private readonly Type _primaryKeyType = typeof(TId);
        private readonly IList<TEntity> _entities;

        public GenericTestRepository(IEnumerable<TEntity> items)
        {
            _entities = new List<TEntity>(items);
        }

        public TEntity FindById(TId id)
        {
            return _entities.FirstOrDefault(entity => GetPrimaryKey(entity).Equals(id));
        }

        public TEntity FindByIdAndLock(TId id)
        {
            return FindById(id);
        }

        public TEntity[] FindAll()
        {
            return _entities.OrderBy(GetPrimaryKey).ToArray();
        }

        public TEntity MakePersistent(TEntity entity)
        {
            var idOfExistingEntity = GetPrimaryKey(entity);

            if (idOfExistingEntity.Equals(default(TId))) {
                GeneratePrimaryKey(entity);
                _entities.Add(entity);
            }
            else {
                var existingEntity = FindById(idOfExistingEntity);

                if (existingEntity == null)
                    throw new InvalidOperationException(string.Format("Expected an entity with an id of {0} to exist in the repository.", idOfExistingEntity));

                _entities.Remove(existingEntity);
                _entities.Add(entity);
            }

            return entity;
        }

        public void MakeTransient(TEntity entity)
        {
            var idOfExistingEntity = GetPrimaryKey(entity);

            if (idOfExistingEntity.Equals(default(TId)))
            {
                throw new InvalidOperationException("Attempt to call MakeTransient on an entity with a default id.");
            }

            var existingEntity = FindById(idOfExistingEntity);

            if (existingEntity == null)
                throw new InvalidOperationException(string.Format("Expected an entity with an id of {0} to exist in the repository.", idOfExistingEntity));

            _entities.Remove(existingEntity);
        }

        private TId GetPrimaryKey(TEntity entity)
        {
            var id = default(TId);

            var fieldInfo = _entityType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo != null) {
                var fieldValue = fieldInfo.GetValue(entity);
                if (fieldValue.GetType() == _primaryKeyType) {
                    id = (TId)fieldValue;
                }
            }

            return id;
        }

        private void SetPrimaryKey(TEntity entity, object id)
        {
            var fieldInfo = _entityType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo != null) {
                fieldInfo.SetValue(entity, id);
            }
        }

        private void GeneratePrimaryKey(TEntity entity)
        {
            if (_primaryKeyType == typeof(Guid)) {
                SetPrimaryKey(entity, Guid.NewGuid());
                return;
            }

            if (_primaryKeyType == typeof(int)) {
                var random = new Random();
                for (; ; ) {
                    object id = random.Next();
                    if (FindById((TId) id) != null) continue;
                    SetPrimaryKey(entity, id);
                    return;
                }
            }

            throw new NotSupportedException(string.Format("Don't know how to generate a new primary key of type {0}.", _primaryKeyType.FullName));
        }
    }
}
