using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNhom10.Models;

[Table("Luongs")]
public class Luong
{
    [Key]
    [Required(ErrorMessage ="ID không được bỏ trống")]
    [Display(Name = "Mã nhân viên")]
    public string MaNV { get; set; }

    [Required(ErrorMessage ="Họ và tên không được bỏ trống")]
    [Display(Name = "Họ và tên")]
    public string TenNV { get; set; }

    [Required(ErrorMessage ="Lương không được bỏ trống")]
    [Display(Name = "Lương cơ bản")]
    public int LuongCoBan { get; set; }

    [Required(ErrorMessage ="Phụ cấp không được bỏ trống")]
    [Display(Name = "Phụ cấp")]
    public int PhuCap { get; set; }

    [Required(ErrorMessage ="Hệ số lương không được bỏ trống")]
    [Display(Name = "Hệ số lương")]
    public int HeSoLuong { get; set; }

    
    [Display(Name = "Lương chuyên cần")]
     public int LuongChuyenCan { get; set; }
    

}