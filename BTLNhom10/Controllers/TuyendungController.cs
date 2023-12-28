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
    public class TuyendungController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public TuyendungController(ApplicationDbcontext context){
            _context=context;
        }
         private ExcelProcess _excelPro = new ExcelProcess();
        public async Task<IActionResult> Index(int? page, int? PageSize )
        {
            ViewBag.PageSize = new List<SelectListItem>()
            {
                
                new SelectListItem() { Value="5",Text= "5"},
                new SelectListItem() { Value="10",Text= "10"},
                new SelectListItem() { Value="15",Text= "15"},
                new SelectListItem() { Value="25",Text= "25"},
                new SelectListItem() { Value="50",Text= "50"},
                
        
            };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model = _context.Tuyendung.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Tuyendung == null)
            {
                return NotFound();
            }

            var tuyendung = await _context.Tuyendung
                .FirstOrDefaultAsync(m => m.MaQL == id);
            if (tuyendung == null)
            {
                return NotFound();
            }

            return View(tuyendung);
        }

        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("MaQL, PhongBan, DoTuoi, NamKN, TrinhDo, NgoaiHinh, NgoaiNgu, PhongVan, YeuCau ")] Tuyendung tuyendung){
            if(ModelState.IsValid){
                _context.Add(tuyendung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tuyendung);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.Tuyendung == null)
            {
                return NotFound();
            }
            var tuyendung = await _context.Tuyendung.FindAsync(id);
            if (tuyendung == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("MaQL, PhongBan, DoTuoi, NamKN, TrinhDo, NgoaiHinh, NgoaiNgu, PhongVan, YeuCau")] Tuyendung tuyendung){
            if (id !=tuyendung.MaQL){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(tuyendung);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!TuyendungExists(tuyendung.MaQL)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool TuyendungExists(string id)
        {
            return (_context.Tuyendung?.Any(e=>e.MaQL==id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Delete(String id)
        {
            if(id==null || _context.Tuyendung == null){
                return NotFound();
            }
            var tuyendung = await _context.Tuyendung.FirstOrDefaultAsync(m => m.MaQL == id);
            if (tuyendung ==  null){
                return NotFound();
            }
            return View(tuyendung);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(String id){
            if(_context.Tuyendung==null){
                return Problem ("Entity set 'ApplicationDbcontext.Tuyendung' is null." );
            }
            var tuyendung = await _context.Tuyendung.FindAsync(id);
            if (tuyendung !=null)
            {
                _context.Tuyendung.Remove(tuyendung);
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
                                    var td = new Tuyendung();
                                    td.MaQL = dt.Rows[i][0].ToString();
                                    td.PhongBan = dt.Rows[i][1].ToString();
                                    td.DoTuoi = dt.Rows[i][2].ToString();
                                    td.NamKN = dt.Rows[i][3].ToString();
                                    td.TrinhDo = dt.Rows[i][4].ToString();
                                    td.NgoaiHinh = dt.Rows[i][5].ToString();
                                    td.NgoaiNgu = dt.Rows[i][6].ToString();
                                    td.PhongVan = dt.Rows[i][7].ToString();
                                     td.YeuCau = dt.Rows[i][8].ToString();
                                    _context.Add(td);
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
            var fileName = "TuyendungList.xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                excelWorksheet.Cells["A1"].Value = "MaQL";
                excelWorksheet.Cells["B1"].Value = "PhongBan";
                excelWorksheet.Cells["C1"].Value = "DoTuoi";
                excelWorksheet.Cells["D1"].Value = "NamKN";
                excelWorksheet.Cells["E1"].Value = "TrinhDo";
                excelWorksheet.Cells["F1"].Value = "NgoaiHinh";
                excelWorksheet.Cells["G1"].Value = "NgoaiNgu";
                excelWorksheet.Cells["H1"].Value = "PhongVan";
                excelWorksheet.Cells["I1"].Value = "YeuCau";
                var tdList = _context.Tuyendung.ToList();
                excelWorksheet.Cells["A2"].LoadFromCollection(tdList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
            }
        }  
    }

}