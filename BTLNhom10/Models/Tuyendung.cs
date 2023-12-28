using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNhom10.Models;

[Table("Tuyendungs")]
public class Tuyendung
{
    [Key]
    [Required(ErrorMessage ="ID không được bỏ trống")]
    [Display(Name = "Mã quản lý")]
    public string MaQL { get; set; }

    [Required(ErrorMessage ="Phòng ban không được bỏ trống")]
    [Display(Name = "Phòng ban")]
    public string PhongBan { get; set; }


     [Required(ErrorMessage ="Độ tuổi không được bỏ trống")]
     [Display(Name = "Độ tuổi")]
    public string DoTuoi { get; set; }
     
     [Required(ErrorMessage ="kinh nghiệm không được bỏ trống")]
     [Display(Name = "Kinh nghiệm")]
    public string NamKN { get; set; }
    
    [Required(ErrorMessage ="Trình độ không được bỏ trống")]
     [Display(Name = "Trình độ")]
    public string TrinhDo { get; set; }
    
    [Required(ErrorMessage ="Ngoại hình không được bỏ trống")]
     [Display(Name = "Ngoại hình")]
    public string NgoaiHinh { get; set; }
    
    [Required(ErrorMessage ="Ngoại ngữ không được bỏ trống")]
     [Display(Name = "Ngoại ngữ")]
     public string NgoaiNgu { get; set; }

  
     [Display(Name = "Phỏng vấn")]
     public string PhongVan { get; set; }


     [Display(Name = "Yêu cầu")]
    public string YeuCau { get; set; }
     
     
}