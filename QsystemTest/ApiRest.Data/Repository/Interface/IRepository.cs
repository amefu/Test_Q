﻿using ApiRest.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRest.Data.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
