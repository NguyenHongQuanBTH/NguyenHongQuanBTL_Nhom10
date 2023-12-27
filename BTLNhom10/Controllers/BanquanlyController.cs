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
    public class BanquanlyController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public BanquanlyController(ApplicationDbcontext context){
            _context = context;
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
            var model = _context.Banquanly.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Banquanly == null)
            {
                return NotFound();
            }

            var banquanly = await _context.Banquanly
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (banquanly == null)
            {
                return NotFound();
            }

            return View(banquanly);
        }

        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("MaNV, TenNV, QueQuan, Tuoi, GioiTinh, NamKN, ChucVu")] Banquanly banquanly){
            if(ModelState.IsValid){
                _context.Add(banquanly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banquanly);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.Banquanly == null)
            {
                return NotFound();
            }
            var banquanly = await _context.Banquanly.FindAsync(id);
            if (banquanly == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("MaNV, TenNV, QueQuan, Tuoi, GioiTinh, NamKN, ChucVu")] Banquanly banquanly){
            if (id !=banquanly.MaNV){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(banquanly);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!BanquanlyExists(banquanly.MaNV)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool BanquanlyExists(string id)
        {
            return (_context.Banquanly?.Any(e=>e.MaNV==id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Delete(String id)
        {
            if(id==null || _context.Banquanly == null){
                return NotFound();
            }
            var banquanly = await _context.Banquanly.FirstOrDefaultAsync(m => m.MaNV == id);
            if (banquanly ==  null){
                return NotFound();
            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(String id){
            if(_context.Banquanly==null){
                return Problem ("Entity set 'ApplicationDbcontext.Banquanly' is null." );
            }
            var banquanly = await _context.Banquanly.FindAsync(id);
            if (banquanly !=null)
            {
                _context.Banquanly.Remove(banquanly);
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
                                    var bql = new Banquanly();
                                    bql.MaNV = dt.Rows[i][0].ToString();
                                    bql.TenNV = dt.Rows[i][1].ToString();
                                    bql.QueQuan = dt.Rows[i][2].ToString();
                                    bql.Tuoi = Convert.ToInt32(dt.Rows[i][3].ToString());
                                    bql.GioiTinh = dt.Rows[i][4].ToString();
                                    bql.NamKN = dt.Rows[i][5].ToString();
                                    bql.ChucVu = dt.Rows[i][6].ToString();
                                    _context.Add(bql);
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
            var fileName = "BanquanlyList.xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                excelWorksheet.Cells["A1"].Value = "MaNV";
                excelWorksheet.Cells["B1"].Value = "TenNV";
                excelWorksheet.Cells["C1"].Value = "QueQuan";
                excelWorksheet.Cells["D1"].Value = "Tuoi";
                excelWorksheet.Cells["E1"].Value = "GioiTinh";
                excelWorksheet.Cells["F1"].Value = "NamKN";
                excelWorksheet.Cells["G1"].Value = "ChucVu";
                var bqlList = _context.Banquanly.ToList();
                excelWorksheet.Cells["A2"].LoadFromCollection(bqlList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
            }
        }  
    }

}