﻿using System.Collections.Generic;
using WebMvc.Data;
using WebMvc.Models;
using Microsoft.EntityFrameworkCore;
using WebMvc.Services.Exceptions;
using System.Threading.Tasks;

namespace WebMvc.Services
{
    public class SellerService
    {
        private readonly WebMvcContext _context;

        public SellerService(WebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Impossivel deletar o vendedor, ela/ele tem vendas");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            if (! await _context.Seller.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
