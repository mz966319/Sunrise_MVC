using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Sunrise.Models;
using Sunrise.DataAccess;
using Sunrise.Models.ViewModels;
using Sunrise.DataAccess.Repository.IRepository;


namespace Sunrise.Utility
{

    public class SemesterReportPDF : IDocument
    {
        private readonly IUnitOfWork _unitOfWork;
        private SortedDictionary<int, SortedDictionary<int, List<Student>>> _studentsMap;
        private List<CurrentControl> _currentControls;
        private int _totalStudents;
        public SemesterReportPDF(List<Student> students, List<CurrentControl> currentControls, IUnitOfWork unitOfWork)
        {
            // Set the license type
            QuestPDF.Settings.License = LicenseType.Community;
            _unitOfWork = unitOfWork;
            _totalStudents = students.Count;
            _currentControls = currentControls;
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
                    row.RelativeItem((float)0.7).AlignCenter().Text(text =>
                    {
                        text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C").Bold());
                        text.Span("Sunrise International School\n");
                        text.Span("Under the Supervision of the Ministry of Education\n");
                        text.Span("Licence No: 520-2432");
                    });
                    row.RelativeItem((float)0.3);
                    row.ConstantItem(90).Column(column =>
                    {
                        column.Item().AlignCenter().Height(60).Image("wwwroot/images/logo.png", ImageScaling.FitArea);
                        column.Item().AlignCenter().PaddingTop(3).Text("Semester Report").FontSize(11).Bold().AlignCenter();
                    });
                    row.RelativeItem((float)0.4);
                    row.RelativeItem((float)0.6).AlignCenter().Text(text =>
                    {
                        text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C").Bold());
                        text.Span("مدارس شروق الشمس العالمية\n");
                        text.Span("تحت إشراف وزارة التربية والتعليم\n");
                        text.Span("التعليم الأجنبي\n");
                        text.Span("الترخيص: ٢٤٣٢-٥٢٠");
                    });
                });




                // Content section
                page.Content().PaddingVertical(0, Unit.Centimetre).Column(column =>
                {
                    // Define cell styles
                    QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    { return container.Border((float)0.6).BorderColor("#000000").Padding(3); }
                    int processedStudents = 0;
                    foreach (var gradeEntry in _studentsMap)
                    {
                        int gradeID = gradeEntry.Key;
                        var classMap = gradeEntry.Value;

                        foreach (var classEntry in classMap)
                        {
                            int classID = classEntry.Key;
                            var studentList = classEntry.Value;
                            for (int i = 0; i < studentList.Count; i++)
                            {
                                List<CurrentControl> studentControl = new List<CurrentControl>();
                                studentControl.AddRange(_currentControls.Where(c => c.StudentID == studentList[i].StudentID));
                                if (studentControl.Count > 0)
                                {
                                    column.Item().PaddingTop(10).PaddingLeft(40).PaddingRight(40).Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(30);
                                            columns.RelativeColumn(30);


                                        });
                                        table.Cell().Element(CellStyle).Element(cell => cell.AlignCenter()).Text(text =>
                                        {
                                            text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C"));
                                            text.Span("Year: ").Bold();
                                            text.Span(studentControl[0].YearSemester.Year.YearEN);
                                        });
                                        table.Cell().Element(CellStyle).Element(cell => cell.AlignCenter()).Text(text =>
                                        {
                                            text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C"));
                                            text.Span("Semester: ").Bold();
                                            text.Span(studentControl[0].YearSemester.SemesterNameEN);
                                        });



                                    });

                                    column.Item().PaddingLeft(30).PaddingRight(30).Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(30);
                                            columns.RelativeColumn(20);


                                        });         
                                        table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(text =>
                                        {
                                            text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C"));
                                            text.Span("Student Name: ").Bold();
                                            text.Span(studentList[i].StudentNameEN);
                                        });
                                        table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(text =>
                                        {
                                            text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C"));
                                            text.Span("Seat Number").Bold();
                                            //text.Span(studentList[i].SeatNumber);
                                        });
                                        table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(text =>
                                        {
                                            text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C"));
                                            text.Span("Grade: ").Bold();
                                            text.Span(_unitOfWork.GradeClass.Get(u=> u.GradeClassID== studentControl[0].ClassID,includeProperties:"Grade").Grade.GradeName);
                                        });
                                        table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(text =>
                                        {
                                            text.DefaultTextStyle(x => x.FontSize(12).FontColor("#2A2B2C"));
                                            text.Span("Class: ").Bold();
                                            text.Span(_unitOfWork.GradeClass.Get(u => u.GradeClassID == studentControl[0].ClassID).ClassName);
                                        });



                                    });
                                    column.Item().Padding(5).Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(30);
                                            columns.RelativeColumn(9);
                                            columns.RelativeColumn(12);
                                            columns.RelativeColumn(10);
                                            columns.RelativeColumn(10);
                                            columns.RelativeColumn(10);
                                            columns.RelativeColumn(10);
                                            columns.RelativeColumn(10);
                                            columns.RelativeColumn(10);
                                            columns.RelativeColumn(7);

                                        });

                                        table.Header(header =>
                                        {
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tSubject Name").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tMax").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tHomework").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\t Project").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tClass Work").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tQuizes").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tSemester Test").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tTotal").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\t%").FontSize(9).Bold();
                                            header.Cell().Background("#F0F0F0").Element(cell => cell.AlignLeft()).Padding(3).Text("\tLetter Grade").FontSize(9).Bold();
                                        });

                                        // Add sample data to the table
                                        for (int i = 0; i < studentControl.Count; i++)
                                        {
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(studentControl[i].Subject.SubjectNameEN).FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("100").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(studentControl[i].HomeWork).FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(studentControl[i].Project).FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(studentControl[i].ClassWork).FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("??").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(studentControl[i].ExamMark).FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("???").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("???").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("???").FontSize(12);
                                        }
                                        List<Subject> staticSubjects =_unitOfWork.Subject.GetList(u=> u.StaticFlag).ToList();
                                        for (int i = 0; i < staticSubjects.Count; i++)
                                        {
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text(staticSubjects[i].SubjectNameEN).FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("100").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("15").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("10").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("15").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("20").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("40").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("100").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("100.0%").FontSize(12);
                                            table.Cell().Element(CellStyle).Element(cell => cell.AlignLeft()).Text("A").FontSize(12);
                                            
                                        }



                                        //static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container) => container.PaddingVertical(5);
                                    });
                                    processedStudents++;

                                    // Add a page break if not the last class
                                    if (processedStudents < _totalStudents)
                                    {
                                        column.Item().PageBreak();
                                    }
                                }
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

