using Microsoft.EntityFrameworkCore;
using BTLNhom10.Models;
namespace BTLNhom10.Data 
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options) : base(options)
        {}
        public  DbSet <Nhanvien> Nhanvien { get; set; }
         public  DbSet <Banquanly> Banquanly { get; set; }
        
    }
}