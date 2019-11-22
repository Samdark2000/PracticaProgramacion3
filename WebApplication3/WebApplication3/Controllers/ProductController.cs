using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Import(HttpPostedFileBase excelfile)
        {

            if (excelfile == null ||  excelfile.ContentLength == 0)

            {
                ViewBag.Error = "Please select a excel file<br>";
                return View("Index");

            }
            else
            { 

              if(excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))

                {
                    string path = Server.MapPath("~/Content/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                        excelfile.SaveAs(path);
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<Product> listProducts = new List<Product>();
                    for(int row = 3; row <range.Rows.Count; row++)
                    {
                        Product p = new Product();
                        p.id = ((Excel.Range)range.Cells[row, 1]).Text;
                        p.evento = ((Excel.Range)range.Cells[row, 2]).Text;
                        p.fecha = ((Excel.Range)range.Cells[row, 3]).Text;
                        p.hora = ((Excel.Range)range.Cells[row, 4]).Text;
                        listProducts.Add(p);
                    }
                    ViewBag.ListProducts = listProducts;
                    return View("Success");
                }
              
            else
            {
                    ViewBag.Error = "Please select a excel file";
                    return View("Index");
            }


            }
        }
    }
}
