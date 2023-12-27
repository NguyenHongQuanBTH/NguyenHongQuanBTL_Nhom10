using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNhom10.Models;

[Table("Banquanlys")]
public class Banquanly
{
    [Key]
    [Required(ErrorMessage ="ID không được bỏ trống")]
    [Display(Name = "Mã nhân viên")]
    public string MaNV { get; set; }
    
    [Required(ErrorMessage ="Họ và tên không được bỏ trống")]
    [Display(Name = "Họ và tên")]
    public string TenNV { get; set; }
    
    [Required(ErrorMessage ="Quê quán không được bỏ trống")]
    [Display(Name = "Quê quán")]
    public string QueQuan { get; set; }
    
    [Required(ErrorMessage ="Tuổi không được bỏ trống")]
    [Display(Name = "Tuổi")]
     public int Tuoi { get; set; }
    
     [Required(ErrorMessage ="Giới tính không được bỏ trống")]
    [Display(Name = "Giới tính")]
     public string GioiTinh { get; set; }
    
     [Required(ErrorMessage ="Năm kinh nghiệm không được bỏ trống")]
    [Display(Name = "Năm kinh nghiệm")]
     public string NamKN { get; set; }
    
     [Required(ErrorMessage ="Chức vụ không được bỏ trống")]
    [Display(Name = "Chức vụ")]
      public string ChucVu { get; set; }

}