using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Sunrise.Models;


namespace Sunrise.Utility
{

    public class StudentsPDF : IDocument
    {
        private List<Student> _students;
        private SortedDictionary<int, SortedDictionary<int, List<Student>>> _studentsMap;
        public StudentsPDF(List<Student> students)
        {
            // Set the license type
            QuestPDF.Settings.License = LicenseType.Community;
            _students = students ?? new List<Student>();

            _studentsMap = new();
            foreach (var student in students)
            {
                // Check if the grade exists in the outer map
                if (!_studentsMap.ContainsKey(student.CurrentClass.GradeID))
                {
                    // If not, add it with a new inner map
                    _studentsMap[student.CurrentClass.GradeID] = new SortedDictionary<int, List<Student>>();
                }

                // Check if the class exists in the inner map
                var classMap = _studentsMap[student.CurrentClass.GradeID];
                if (!classMap.ContainsKey(student.CurrentClassID))
                {
                    // If not, add it with a new student list
                    classMap[student.CurrentClassID] = new List<Student>();
                }

                // Add the student to the list
                classMap[student.CurrentClassID].Add(student);
            }


            



        }


        public void Compose(IDocumentContainer container)
        {
            string currentDate = DateTime.Now.ToString("HH:mm:ss - MMMM dd, yyyy");

            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(5, Unit.Millimetre);
                page.DefaultTextStyle(x => x.FontSize(14).FontFamily("Arial").DirectionFromRightToLeft());

                // Add the header with text and logo
                page.Header().Row(row =>
                {
                    row.RelativeColumn().Padding(5).Text("\nSunrise International Schools", TextStyle.Default.Size(14).ExtraBold());
                    row.ConstantColumn(60).Image("wwwroot/images/logo.png", ImageScaling.FitArea);
                    row.RelativeColumn().AlignRight().Text("\nمدارس شروق الشمس العالمية", TextStyle.Default.Size(18).ExtraBold());
                });


                

                // Content section
                page.Content().PaddingVertical(0, Unit.Centimetre).Column(column =>
                {
                // Define cell styles
                    QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                        {return container.Border(1).BorderColor("#F0F0F0").Padding(3);}
                    int totalClasses = _studentsMap.Values.Sum(classMap => classMap.Count);
                    int processedClasses = 0;
                    foreach (var gradeEntry in _studentsMap)
                    {
                        int gradeID = gradeEntry.Key;
                        var classMap = gradeEntry.Value;

                        foreach (var classEntry in classMap)
                        {
                            int classID = classEntry.Key;
                            var studentList = classEntry.Value;

                            column.Item().Padding(5).PaddingBottom(2).Text(text =>
                            {
                                text.DefaultTextStyle(x => x.FontSize(14).FontColor("#2A2B2C"));
                                text.Span("Grade: ").SemiBold();
                                text.Span(studentList[0].CurrentClass.Grade.GradeName.ToString());
                                text.Span("\t\t Class: ").SemiBold();
                                text.Span(studentList[0].CurrentClass.ClassName.ToString());
                            });

                            // Create a simple table to add data
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(30);
                                    columns.RelativeColumn(27);
                                    columns.RelativeColumn(5);

                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background("#F0F0F0").Element(CellStyle).Background("#F0F0F0")
                                        .Element(cell => cell.AlignCenter().AlignMiddle()).Text("SN").Bold();
                                    header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tStudent Name").Bold();
                                    header.Cell().Background("#F0F0F0").Element(cell => cell.AlignRight()).Padding(3).Text("اسم الطالب\t").Bold();
                                    header.Cell().Background("#F0F0F0").Element(CellStyle).Element(cell => cell.AlignCenter().AlignMiddle()).Text("Bus").FontSize(9).Bold();

                                    //static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container) => container.DefaultTextStyle(x => x.Bold());
                                });

                                // Add sample data to the table
                                for (int i = 0; i < studentList.Count; i++)
                                {
                                    table.Cell().Element(CellStyle).Element(cell => cell.AlignCenter()).Text(i + 1).FontSize(12);
                                    table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(studentList[i].StudentNameEN).FontSize(12);
                                    table.Cell().Element(CellStyle).Element(cell => cell.AlignRight()).Text(studentList[i].StudentNameAR).FontSize(12);
                                    table.Cell().Element(CellStyle).Element(cell => cell.AlignCenter()).Text(studentList[i].Bus != null ? studentList[i].Bus.BusNumber : "").Bold();
                                }


                                //static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container) => container.PaddingVertical(5);
                            });
                            processedClasses++;

                            // Add a page break if not the last class
                            if (processedClasses < totalClasses)
                            {
                                column.Item().PageBreak();
                            }
                        }
                    }

                });


                //Footer
                page.Footer().Padding(10).BorderTop(1).BorderColor("#D3D3D3").Row(row =>
                {
                    // Left-aligned date
                    row.RelativeItem().AlignLeft().Text(currentDate).FontSize(10).FontColor("#808080");

                    // Right-aligned page numbers
                    row.RelativeItem().AlignRight().Text(text =>
                    {
                        text.DefaultTextStyle(x => x.FontSize(10).FontColor("#808080"));
                        text.Span("Page ").SemiBold();
                        text.CurrentPageNumber().SemiBold();
                        text.Span(" of ").SemiBold();
                        text.TotalPages().SemiBold();
                    });
                });
        });
        }

        //public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public byte[] GeneratePdf()
        {
            using (var stream = new MemoryStream())
            {
                Document.Create(document => Compose(document)).GeneratePdf(stream);
                return stream.ToArray();
            }
        }

    }
}

