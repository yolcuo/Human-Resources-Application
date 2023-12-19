using HR_Project.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Repositories
{
    public interface IBaseRepository<T>where T : IBaseEntity//IBaseEntity sınıfının implemente edildiği tüm sınıflarda bunu kullan
    {

        //Güncelleme:
        Task<int>UpdateAsync(T entity);

        //Detay:
        //istenilen tekil bir personel kaydı bulmak için
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        //Ömerin sonradan ekledikleri:
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByCodeAsync(string code);//para birimini getirmek için
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task DeleteAsync(int id);
        Task RemoveFromTableAsync(int id);

    }
}
