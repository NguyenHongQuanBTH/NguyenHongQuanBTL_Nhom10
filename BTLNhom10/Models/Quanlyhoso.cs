using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNhom10.Models;

[Table("Quanlyhosos")]
public class Quanlyhoso
{
    [Key]
     [Required(ErrorMessage ="ID không được bỏ trống")]
    [Display(Name = "Mã nhân viên")]
    public string MaNV { get; set; }

     [Required(ErrorMessage ="Họ và tên không được bỏ trống")]
    [Display(Name = "Họ và tên")]
    public string TenNV { get; set; }

     [Required(ErrorMessage ="Email không được bỏ trống")]
    [Display(Name = "Email")]
    public string Email { get; set; }

     [Required(ErrorMessage ="Số điện thoại không được bỏ trống")]
    [Display(Name = "Số điện thoại")]
     public string SoDienThoai { get; set; }

      [Required(ErrorMessage ="Số tài khoản không được bỏ trống")]
    [Display(Name = "Số tài khoản")]
     public int SoTaiKhoan { get; set; }

      [Required(ErrorMessage ="Phòng ban không được bỏ trống")]
    [Display(Name = "Phòng ban")]
     public string PhongBan { get; set; }

      
}