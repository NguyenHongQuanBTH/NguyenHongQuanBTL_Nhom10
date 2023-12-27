using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNhom10.Models;

[Table("Banquanlys")]
public class Banquanly
{
    [Key]
    public string MaNV { get; set; }
    public string TenNV { get; set; }
    public string QueQuan { get; set; }
     public int Tuoi { get; set; }
     public string GioiTinh { get; set; }
     public string NamKN { get; set; }
      public string ChucVu { get; set; }

}