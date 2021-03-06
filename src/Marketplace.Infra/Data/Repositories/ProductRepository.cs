﻿using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
using System;
using System.Threading.Tasks;

namespace Marketplace.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketplaceContext _context;

        public ProductRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public void Create(Product product) =>
            _context.Products.Add(product);
         
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);

            return product;
        }

        public async Task<Product> GetByIdAsync(Guid idProduct)
        {
            var product = await _context.Products.FindAsync(idProduct);

            return product;
        }
    }
}
