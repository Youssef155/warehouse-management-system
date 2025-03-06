using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.Repositories;



public class Repository<T> : IRepository<T> where T : class
{
    private readonly WMSDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(WMSDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public T GetById(int id) => _dbSet.Find(id);

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).ToList();

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        Save();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        Save();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        Save();
    }

    public void Save() => _context.SaveChanges();
}

