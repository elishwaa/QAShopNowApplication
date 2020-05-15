using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;

namespace MyShopApplication.Data
{
    public class ExcelData
    {
        public excel.Range xRange;
        public ExcelData()
        {

        }
        public void LoadExcelSheet()
        {
            excel.Application xApplication = new excel.Application();
            excel.Workbook xWorkBook = xApplication.Workbooks.Open(@"C:\Users\Administrator\Desktop\data.xlsx");
            excel._Worksheet xWorkSheet = xWorkBook.Sheets[1];
            xRange = xWorkSheet.UsedRange;
        }
    }
}
