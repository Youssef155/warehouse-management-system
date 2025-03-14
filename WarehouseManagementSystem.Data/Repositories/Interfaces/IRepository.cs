﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WarehouseManagementSystem.Data.Repositories.Interfaces;


public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
