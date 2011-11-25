using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DebtMan.DomainModel.Repositories;

namespace DebtMan.TestRepositories
{
    internal class GenericTestRepository<T, ID> : IGenericRepository<T, ID>
    {
        private IList<T> entities;

        public GenericTestRepository(IEnumerable<T> items)
        {
            this.entities = new List<T>(items);
        }

        public T FindById(ID id)
        {
            T result = default(T);

            Type entityType = typeof(T);
            Type primaryKeyType = typeof(ID);

            FieldInfo fieldInfo = entityType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo != null) {

                foreach (T entity in this.entities) {

                    object fieldValue = fieldInfo.GetValue(entity);
                    if (fieldValue.GetType() == primaryKeyType) {
                        if (fieldValue.Equals(id)) {
                            result = entity;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public T FindByIdAndLock(ID id)
        {
            return FindById(id);
        }

        public T[] FindAll()
        {
            return this.entities.ToArray();
        }

        public T MakePersistent(T entity)
        {
            Type entityType = typeof(T);
            Type primaryKeyType = typeof(ID);

            FieldInfo fieldInfo = entityType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo != null) {
                object fieldValue = fieldInfo.GetValue(entity);
                if (fieldValue.GetType() == primaryKeyType) {
                    if (fieldValue.Equals(default(ID))) {
                        object id = GeneratePrimaryKey();
                        fieldInfo.SetValue(entity, id);
                    }
                }
            }

            // TODO: Uses entity.Equals() ? Which is effectively reference equals unless entity overrides it ?
            if (!this.entities.Contains(entity))
                this.entities.Add(entity);

            return entity;
        }

        public void MakeTransient(T entity)
        {
            // TODO: Uses entity.Equals() ? Which is effectively reference equals unless entity overrides it ?
            this.entities.Remove(entity);
        }

        private object GeneratePrimaryKey()
        {
            object id = default(ID);

            if (typeof(ID) == typeof(Guid)) {
                id = Guid.NewGuid();
            }
            else {
                if (typeof(ID) == typeof(int)) {
                    Random random = new Random();
                    for (; ; ) {
                        id = random.Next();
                        if (FindById((ID)id) == null)
                            break;
                    }
                }
            }

            return id;
        }
    }
}
