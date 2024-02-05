using FoodDataLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FoodDBContext? _dbContext;
        private readonly ILogger<GenericRepository<T>>? _logger;

        public GenericRepository(FoodDBContext? dbContext, ILogger<GenericRepository<T>>? logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Create(T entity)
        {
            try
            {
                _logger?.LogInformation($"Adding entity {entity.GetType} ");
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                _logger?.LogInformation($"Entity {entity.GetType} Created");

            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error:{ex.Message}");
            
            }
        }

        public async Task<string> Delete(Guid Id)
        {
            try
            {
                _logger?.LogInformation("Deleting Item");
                var t = await _dbContext.Set<T>().FindAsync(Id);
                if (t == null)
                {
                    throw new Exception("Item not find");
                }
                _dbContext.Set<T>().Remove(t);
                await _dbContext.SaveChangesAsync();
                _logger?.LogInformation("Item Deleted");
                return "Item deleted";

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error:{ex.Message}");
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                _logger?.LogInformation("Get all item");
                var list = await _dbContext.Set<T>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error:{ex.Message}");
                throw;
            }
        }

        public async Task<T> GetSingle(Guid Id)
        {
            try
            {
                _logger?.LogInformation("Finding item");
                var t = await _dbContext.Set<T>().FindAsync(Id);
                if (t == null)
                {
                    throw new Exception("Item not found");
                }
                _logger?.LogInformation("Item found");
                return t;

            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error:{ex.Message}");
                throw;
            }
        }

        public async Task Update(Guid Id, T entity)
        {
            try
            {
                var existingEntity = await _dbContext.Set<T>().FindAsync(Id);
                if (existingEntity == null)
                {
                    _logger?.LogInformation("Item not found");
                    throw new Exception("Item not found");
                }
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
                _dbContext.Update(existingEntity);
                await _dbContext.SaveChangesAsync();

                _logger?.LogInformation("Item Updated");
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
