using BTLNhom10.Data;
using BTLNhom10.Models;
using BTLNhom10.Models.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using X.PagedList;

namespace BTLNhom10.Controllers{
    public class QuanlyhosoController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public QuanlyhosoController(ApplicationDbcontext context){
            _context=context;
        }
         private ExcelProcess _excelPro = new ExcelProcess();
        public async Task<IActionResult> Index(int? page, int? PageSize )
        {
            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Value="3",Text= "3"},
                new SelectListItem() { Value="5",Text= "5"},
                new SelectListItem() { Value="10",Text= "10"},
                new SelectListItem() { Value="15",Text= "15"},
                new SelectListItem() { Value="25",Text= "25"},
                new SelectListItem() { Value="50",Text= "50"},
                
        
            };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model = _context.Quanlyhoso.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlyhoso == null)
            {
                return NotFound();
            }

            var quanlyhoso = await _context.Quanlyhoso
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (quanlyhoso == null)
            {
                return NotFound();
            }

            return View(quanlyhoso);
        }

        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("MaNV, TenNV, SinhNgay, NgayLamViec, Email, SoDienThoai, SoTaiKhoan, PhongBan")] Quanlyhoso quanlyhoso){
            if(ModelState.IsValid){
                _context.Add(quanlyhoso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanlyhoso);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.Quanlyhoso == null)
            {
                return NotFound();
            }
            var quanlyhoso = await _context.Quanlyhoso.FindAsync(id);
            if (quanlyhoso == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("MaNV, TenNV, SinhNgay, NgayLamViec, Email, SoDienThoai, SoTaiKhoan, PhongBan")] Quanlyhoso quanlyhoso){
            if (id !=quanlyhoso.MaNV){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(quanlyhoso);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!QuanlyhosoExists(quanlyhoso.MaNV)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool QuanlyhosoExists(string id)
        {
            return (_context.Quanlyhoso?.Any(e=>e.MaNV==id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Delete(String id)
        {
            if(id==null || _context.Quanlyhoso == null){
                return NotFound();
            }
            var quanlyhoso = await _context.Quanlyhoso.FirstOrDefaultAsync(m => m.MaNV == id);
            if (quanlyhoso ==  null){
                return NotFound();
            }
            return View(quanlyhoso);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(String id){
            if(_context.Quanlyhoso==null){
                return Problem ("Entity set 'ApplicationDbcontext.Quanlyhoso' is null." );
            }
            var quanlyhoso = await _context.Quanlyhoso.FindAsync(id);
            if (quanlyhoso !=null)
            {
                _context.Quanlyhoso.Remove(quanlyhoso);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file!=null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError("", "Please choose excel file to upload!");
                    }
                    else
                    {
                        //rename file when upload to server
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", "File" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond + fileExtension);
                        var fileLocation = new FileInfo(filePath).ToString();
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                for(int i = 0; i < dt.Rows.Count; i++)
                                {
                                    var ql = new Quanlyhoso();
                                    ql.MaNV = dt.Rows[i][0].ToString();
                                    ql.TenNV = dt.Rows[i][1].ToString();
                                    ql.SinhNgay = dt.Rows[i][2].ToString();
                                    ql.NgayLamViec = dt.Rows[i][3].ToString();
                                    ql.Email = dt.Rows[i][4].ToString();
                                    ql.SoDienThoai = dt.Rows[i][5].ToString();
                                    ql.SoTaiKhoan = Convert.ToInt32(dt.Rows[i][6].ToString());
                                    ql.PhongBan = dt.Rows[i][7].ToString();
                                    
                                    _context.Add(ql);
                                }
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
                }
            
            return View();
        }  
         public IActionResult Download()
        {
            var fileName = "QuanlyhosoList.xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                excelWorksheet.Cells["A1"].Value = "MaNV";
                excelWorksheet.Cells["B1"].Value = "TenNV";
                excelWorksheet.Cells["C1"].Value = "Email";
                excelWorksheet.Cells["D1"].Value = "SoDienThoai";
                excelWorksheet.Cells["E1"].Value = "SoTaiKhoan";
                excelWorksheet.Cells["F1"].Value = "PhongBan";
               
                var qlList = _context.Quanlyhoso.ToList();
                excelWorksheet.Cells["A2"].LoadFromCollection(qlList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
            }
        }  
    }

}