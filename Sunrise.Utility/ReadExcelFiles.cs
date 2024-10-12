using OfficeOpenXml;
using Sunrise.Models;

namespace Sunrise.DataAccess.Data
{
    public class ReadExcelFiles
    {
        public ReadExcelFiles() { }

        public List<Country> ReadExcelFile(string filePath)
        {
            var dataList = new List<Country>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Get the first worksheet
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Assuming the first row is header
                {
                    var data = new Country
                    {
                        CountryID = int.Parse(worksheet.Cells[row, 1].Text),
                        CountryNameEN = worksheet.Cells[row, 2].Text,
                        CountryNameAR = worksheet.Cells[row, 1].Text,
                        //NationalityEN = worksheet.Cells[row, 1].Text,
                        //NationalityARMale = worksheet.Cells[row, 1].Text,
                        //NationalityARFemale = worksheet.Cells[row, 1].Text

                    };
                    dataList.Add(data);
                }
            }

            return dataList;
        }

    }
    
}
