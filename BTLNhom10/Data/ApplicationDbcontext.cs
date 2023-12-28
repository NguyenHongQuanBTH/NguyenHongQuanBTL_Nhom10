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
        public  DbSet <Luong> Luong { get; set; }
        public  DbSet <Chamcong> Chamcong { get; set; }
        public  DbSet <Quanlyhoso> Quanlyhoso { get; set; }
        public  DbSet <Tuyendung> Tuyendung { get; set; }
    }
}

//NguyenHongQuan-1921050489