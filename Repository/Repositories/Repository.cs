﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomWorld.Models;

namespace RoomWorld.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly DatabaseContext databaseContext;
        private readonly DbSet<T> entities;

        public Repository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            entities = databaseContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return  entities.AsQueryable();
        }

        public Task<T> GetByIdAsunc(int id)
        {
            return entities.FindAsync(id);
        }

        public async Task InsertAsunc(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsunc(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsunc(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsunc()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}