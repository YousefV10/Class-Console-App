using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Manager<T> where T : BaseEntity
    {
        private List<T> _entities;

        public Manager()
        {
            _entities = new List<T>();
        }

        public void Add(T entity)
        {
            if (_entities.Any(e => e.Id == entity.Id))
            {
                Console.WriteLine($"XƏBƏRDARLIQ: Id {entity.Id} olan obyekt artıq mövcuddur. Əlavə edilmədi.");
            }
            else
            {
                _entities.Add(entity);
                Console.WriteLine($" UĞUR: Id {entity.Id} olan obyekt əlavə edildi.");
            }
        }

        public void Remove(int id)
        {
            T entityToRemove = _entities.FirstOrDefault(e => e.Id == id);

            if (entityToRemove != null)
            {
                _entities.Remove(entityToRemove);
                Console.WriteLine($" UĞUR: Id {id} olan obyekt silindi.");
            }
            else
            {
                Console.WriteLine($" XƏBƏRDARLIQ: Id {id} ilə uyğun obyekt tapılmadı. Silinmədi.");
            }
        }

        public void Update(T entity)
        {
            T existingEntity = _entities.FirstOrDefault(e => e.Id == entity.Id);

            if (existingEntity != null)
            {
                int index = _entities.IndexOf(existingEntity);
                _entities[index] = entity;
                Console.WriteLine($" UĞUR: Id {entity.Id} olan obyekt yeniləndi.");
            }
            else
            {
                Console.WriteLine($"⚠ XƏBƏRDARLIQ: Id {entity.Id} ilə uyğun obyekt tapılmadı. Yenilənmədi.");
            }
        }

        public T GetById(int id)
        {
            T entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                Console.WriteLine($" XƏBƏRDARLIQ: Id {id} ilə uyğun obyekt tapılmadı.");
            }
            return entity;
        }

        public List<T> GetAll()
        {
            return _entities;
        }
    }
}
