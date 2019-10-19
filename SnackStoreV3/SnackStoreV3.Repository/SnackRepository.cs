﻿using System;
using System.Collections.Generic;
using System.Text;
using SnackStoreV3.Domain.Models;
using SnackStoreV3.Domain.Interfaces;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SnackStoreV3.Models;

namespace SnackStoreV3.Repository
{

    public class SnackRepository : MainStoreRepository<SnackModel>, ISnackRepository
    {
        StoreDbContext _context;
        public SnackRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SnackModel>> GetAllProducts()
        {
            return await FindAll().OrderBy(a => a.snackName).ToListAsync();
        }

        public async Task<IEnumerable<SnackModel>> GetAllProductsChunk(PaginationDTO pagination)
        {
            IQueryable<SnackModel> query;
            var property = TypeDescriptor.GetProperties(typeof(SnackModel)).Find(pagination.SortBy, true);
            if (pagination.Order == "Desc")            
                query = FindAll().OrderByDescending(a => property.GetValue(a));            
            else            
                query = FindAll().OrderBy(a => property.GetValue(a));            
            return await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

    }
}
