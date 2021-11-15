using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMvc.Data;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class SalesRecordService
    {
        private readonly WebMvcContext _context;

        public SalesRecordService(WebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller) // join
                .Include(x => x.Seller.Department) // join
                .OrderByDescending(x => x.Date) //order
                .ToListAsync();
        }
    }
}
