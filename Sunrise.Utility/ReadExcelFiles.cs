using OfficeOpenXml;
using Sunrise.Models;

namespace Sunrise.DataAccess.Data
{
    public class ReadExcelFiles
    {
        public const int Control_Quiz1 = 10;

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

        public static List<Student> AddStudentsFromMatex(string filePath)
        {
            // Initialize EPPlus (non-commercial use)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var students = new List<Student>();
            // Read the Excel file
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets[0]; // Access the first worksheet

                // Get the total rows and columns
                int rows = worksheet.Dimension.Rows;
                int columns = worksheet.Dimension.Columns;

                // Read the data row by row

                for (int row = 2; row <= rows; row++) // Start from row 2 to skip headers
                {
                    var student = new Student
                    {
                        StudentNameAR = worksheet.Cells[row, 1].Text.Trim(),
                        StudentNameEN = worksheet.Cells[row, 2].Text.Trim(),
                        MatexParentID = TryParseInt(worksheet.Cells[row, 3].Text),
                        MatexStudentID = TryParseInt(worksheet.Cells[row, 4].Text),
                        ParentPhone1 = worksheet.Cells[row, 6].Text.Trim(),
                        ParentPhones2 = worksheet.Cells[row, 7].Text.Trim(),
                        CurrentClassID = TryParseInt(worksheet.Cells[row, 8].Text),
                        CreatedBy ="FileReader",
                        DateCreated=DateTime.Now
                        
                    };

                    students.Add(student);
                }

            }
            return students;
        }
        private static int TryParseInt(string text)
        {
            return int.TryParse(text.Trim(), out int result) ? (int)result : 0;
        }

    }
    //public class StudentTest
    //{
    //    public string Serial { get; set; }
    //    public string Name { get; set; }
    //    public string ParentNumber { get; set; }
    //    public string StudentNumber { get; set; }
    //    public string Nationality { get; set; }
    //    public string ParentPhone { get; set; }
    //    public string MotherPhone { get; set; }
    //    public string Section { get; set; }
    //    public string Grade { get; set; }
    //    public string EnrollmentDate { get; set; }
    //    public string Class { get; set; }
    //    public string IDNumber { get; set; }
    //    public string Transport1 { get; set; }
    //    public string Transport2 { get; set; }
    //    public string FirstYear { get; set; }
    //        public override string ToString()
    //        {
    //            return $"{Serial},{Name}, {ParentNumber}, " +
    //                   $"{StudentNumber},{Nationality},{ParentPhone}, " +
    //                   $"{MotherPhone},{Section},{Grade}, " +
    //                   $" {EnrollmentDate},  {Class},{IDNumber}, " +
    //                   $"{Transport1}, {Transport2}, {FirstYear}";
    //        }

    //    }

}
