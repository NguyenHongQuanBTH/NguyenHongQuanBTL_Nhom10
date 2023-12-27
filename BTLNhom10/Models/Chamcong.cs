using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNhom10.Models;

[Table("Chamcongs")]
public class Chamcong
{
    [Key]
    [Required(ErrorMessage ="ID không được bỏ trống")]
    [Display(Name = "Mã nhân viên")]
    public string MaNV { get; set; }
     
     [Required(ErrorMessage ="Họ Và Tên không được bỏ trống")]
     [Display(Name = "Họ và tên")]
    public string TenNV { get; set; }
    
    [Required(ErrorMessage ="Ngày nghỉ không được bỏ trống")]
     [Display(Name = "Ngày nghỉ phép")]
    public int NgayNghiPhep { get; set; }
    
    [Required(ErrorMessage ="Số ngày công không được bỏ trống")]
     [Display(Name = "Số ngày công")]
    public int SoNgayCong { get; set; }
    
    [Required(ErrorMessage ="Số giờ công không được bỏ trống")]
     [Display(Name = "Số giờ công")]
     public int SoGioCong { get; set; }
     
}