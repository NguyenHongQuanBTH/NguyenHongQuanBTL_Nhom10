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
    public class LuongController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public LuongController(ApplicationDbcontext context){
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
            var model = _context.Luong.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Luong == null)
            {
                return NotFound();
            }

            var luong = await _context.Luong
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (luong == null)
            {
                return NotFound();
            }

            return View(luong);
        }

        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("MaNV, TenNV, LuongCoBan, PhuCap, HeSoLuong, LuongChuyenCan")] Luong luong){
            if(ModelState.IsValid){
                _context.Add(luong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(luong);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.Luong == null)
            {
                return NotFound();
            }
            var luong = await _context.Luong.FindAsync(id);
            if (luong == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("MaNV, TenNV, LuongCoBan, PhuCap, HeSoLuong, LuongChuyenCan")] Luong luong){
            if (id !=luong.MaNV){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(luong);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!LuongExists(luong.MaNV)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool LuongExists(string id)
        {
            return (_context.Luong?.Any(e=>e.MaNV==id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Delete(String id)
        {
            if(id==null || _context.Luong == null){
                return NotFound();
            }
            var luong = await _context.Luong.FirstOrDefaultAsync(m => m.MaNV == id);
            if (luong ==  null){
                return NotFound();
            }
            return View(luong);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(String id){
            if(_context.Luong==null){
                return Problem ("Entity set 'ApplicationDbcontext.Luong' is null." );
            }
            var luong = await _context.Luong.FindAsync(id);
            if (luong !=null)
            {
                _context.Luong.Remove(luong);
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
                                    var lg = new Luong();
                                    lg.MaNV = dt.Rows[i][0].ToString();
                                    lg.TenNV = dt.Rows[i][1].ToString();
                                    lg.LuongCoBan = Convert.ToInt32(dt.Rows[i][2].ToString());
                                    lg.PhuCap = Convert.ToInt32(dt.Rows[i][3].ToString());
                                    lg.HeSoLuong = Convert.ToInt32(dt.Rows[i][4].ToString());
                                    lg.LuongChuyenCan = Convert.ToInt32(dt.Rows[i][5].ToString());
                                    
                                    _context.Add(lg);
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
            var fileName = "LuongList.xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                excelWorksheet.Cells["A1"].Value = "MaNV";
                excelWorksheet.Cells["B1"].Value = "TenNV";
                excelWorksheet.Cells["C1"].Value = "LuongCoBan";
                excelWorksheet.Cells["D1"].Value = "PhuCap";
                excelWorksheet.Cells["E1"].Value = "HeSoLuong";
                excelWorksheet.Cells["F1"].Value = "LuongChuyenCan";
               
                var lgList = _context.Luong.ToList();
                excelWorksheet.Cells["A2"].LoadFromCollection(lgList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
            }
        }  
    }

}