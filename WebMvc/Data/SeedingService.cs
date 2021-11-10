using System;
using System.Linq;
using WebMvc.Models;
using WebMvc.Models.Enums;

namespace WebMvc.Data
{
    public class SeedingService
    {
        private WebMvcContext _context;

        public SeedingService(WebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() || 
                _context.SalesRecords.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");

            Seller s1 = new Seller(1, "Boob", "bob@gmail.com", new DateTime(1998, 4, 24), 1000.0, d1);
            Seller s2 = new Seller(2, "Boob2", "bob2@gmail.com", new DateTime(1999, 4, 24), 2000.0, d2);
            Seller s3 = new Seller(3, "Boob3", "bob3@gmail.com", new DateTime(2000, 4, 24), 3000.0, d3);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 25), 12000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 25), 13000.0, SaleStatus.Billed, s3);

            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1, s2, s3);
            _context.SalesRecords.AddRange(r1, r2, r3);

            _context.SaveChanges();
        }
    }
}
