using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebMvc.Data;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class UserService
    {
        private readonly WebMvcContext _context;

        public UserService(WebMvcContext context)
        {
            _context = context;
        }

        public void Insert(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User Login(string email, string pwd)
        {
            return _context.User.FirstOrDefault(obj => obj.Email == email && obj.Password == pwd);
        }
    }
}
