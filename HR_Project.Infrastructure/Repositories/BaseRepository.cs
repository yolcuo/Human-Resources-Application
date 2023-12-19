using HR_Project.Domain.Entities.Abstract;
using HR_Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
	{
		//DIP ile context sınıfı buraya dahil edilecek!!
		private readonly HR_Context _context;
		protected DbSet<T> _table;
		public BaseRepository(HR_Context context)
		{
			_context = context;
			_table = context.Set<T>(); //_table alanına, _context içindeki ilgili tür(T) için DbSet'i atıyoruz.
		}
		public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
		{
			var result = await _table.FirstOrDefaultAsync(predicate);
			return result;
		}

		public async Task<int> UpdateAsync(T entity)
		{
			_context.Entry<T>(entity).State = EntityState.Modified;
			return await _context.SaveChangesAsync();
		}


        //Ömerin sonradan ekledikleri:


        public async Task<T> GetByIdAsync(int id)
		{
			return await _table.FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
		{
			var result=await _table.Where(predicate).ToListAsync();
			return result;
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await GetByIdAsync(id);
			if (entity != null)
			{
				//_table.Remove(entity);
				_context.Entry<T>(entity).State = EntityState.Modified;
				entity.DeleteDate = DateTime.Now;
				entity.IsActive = false;

				await _context.SaveChangesAsync();
			}
		}

		public async Task<T> GetByCodeAsync(string code)
		{
			return await _table.FindAsync(code);
		}

        public async Task AddAsync(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.IsActive = true;
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable();

            // Include işlemleri
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            var result = await query.Where(predicate).ToListAsync();
            return result;
        }

        public async Task RemoveFromTableAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }


    }
}
