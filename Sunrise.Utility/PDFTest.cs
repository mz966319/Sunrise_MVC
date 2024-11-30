using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Elements;
using QuestPDF.Elements.Text;
using System.IO;
using QuestPDF.Infrastructure;
using Sunrise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Sunrise.Utility
{

    public class PDFTest : IDocument
    {
        public byte[] CreateBarChart()
        {
            int width = 300;
            int height = 200;

            int leftMargin = 50;
            int rightMargin = 20;
            int topMargin = 20;
            int bottomMargin = 90; // Increased to accommodate rotated labels
            int chartWidth = width - leftMargin - rightMargin;
            int chartHeight = height - topMargin - bottomMargin;

            using (Bitmap bitmap = new Bitmap(width, height))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Set background color
                graphics.Clear(System.Drawing.Color.White);

                // Create data
                int[] values = { 100, 20, 30, 40, 100 };
                string[] labels = { "Category A", "Category B", "Category C", "Category D", "Category E" };
                Brush barBrush = Brushes.DimGray;

                // Determine scaling
                int maxValue = 100;
                double scaleY = (double)chartHeight / maxValue;

                // Define bar parameters
                int barSpacing = 10;
                int barWidth = (chartWidth - barSpacing * (values.Length - 1)) / values.Length;

                // Draw grid lines every 20 units
                Pen gridPen = new Pen(System.Drawing.Color.LightGray);
                for (int y = 0; y <= maxValue; y += 20)
                {
                    int yPos = topMargin + (int)(chartHeight - y * scaleY);
                    graphics.DrawLine(gridPen, leftMargin, yPos, width - rightMargin, yPos);
                }

                // Draw axes
                Pen axisPen = new Pen(System.Drawing.Color.Black);
                graphics.DrawLine(axisPen, leftMargin, topMargin, leftMargin, height - bottomMargin); // Y-axis
                graphics.DrawLine(axisPen, leftMargin, height - bottomMargin, width - rightMargin, height - bottomMargin); // X-axis

                // Label y-axis
                for (int y = 0; y <= maxValue; y += 20)
                {
                    int yPos = topMargin + (int)(chartHeight - y * scaleY);
                    // Draw tick mark
                    graphics.DrawLine(axisPen, leftMargin - 5, yPos, leftMargin, yPos);
                    // Draw label
                    string yLabel = y.ToString();
                    SizeF yLabelSize = graphics.MeasureString(yLabel, new Font("Arial", 10));
                    graphics.DrawString(yLabel, new Font("Arial", 10), Brushes.Black, leftMargin - yLabelSize.Width - 8, yPos - yLabelSize.Height / 2);
                }

                // Draw bars and rotated labels
                for (int i = 0; i < values.Length; i++)
                {
                    int barHeight = (int)(values[i] * scaleY);
                    int x = leftMargin + i * (barWidth + barSpacing);
                    int y = topMargin + (chartHeight - barHeight);
                    graphics.FillRectangle(barBrush, x, y, barWidth, barHeight);

                    // Draw rotated label centered under the bar
                    string label = labels[i];
                    Font labelFont = new Font("Arial", 10);
                    SizeF labelSize = graphics.MeasureString(label, labelFont);

                    // Save the current state of the graphics
                    graphics.TranslateTransform(x + barWidth / 2, height - bottomMargin + 5 + labelSize.Width);
                    graphics.RotateTransform(-90); // Rotate text 90 degrees counterclockwise

                    // Draw the label
                    graphics.DrawString(label, labelFont, Brushes.Black, 0, -labelSize.Height / 2);

                    // Restore the graphics state
                    graphics.ResetTransform();
                }

                // Return the image as a byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
        public PDFTest()
        {
            // Set the license type to avoid exceptions
            QuestPDF.Settings.License = LicenseType.Community;
        }
        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(20).FontFamily("Aptos").DirectionFromRightToLeft());

                    // Add the header with text and logo
                    page.Header()
                        .Row(row =>
                        {
                            row.RelativeColumn().Text("نموذج تقرير", TextStyle.Default.Size(24).Bold());
                            row.ConstantColumn(100).Image("wwwroot/images/logo.png", ImageScaling.FitArea);
                            row.RelativeColumn().AlignRight().Text("تقرير تحكم مدرسي", TextStyle.Default.Size(24).Bold());
                        });
                   
                    // Content section
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(20);

                            // Paragraph with Arabic Text
                            column.Item().Text("مرحبا بكم في نظام إدارة المدارس الدولية")
                                  .FontSize(20)
                                  .FontFamily("Arial");

                            // Create a simple table to add data
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("المادة").FontSize(16);
                                    header.Cell().Element(CellStyle).Text("الدرجة").FontSize(16);
                                    header.Cell().Element(CellStyle).Text("الحالة").FontSize(16);

                                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container) => container.DefaultTextStyle(x => x.Bold());
                                });

                                // Add sample data to the table
                                for (int i = 0; i < 5; i++)
                                {
                                    table.Cell().Element(CellStyle).Text($"المادة {i + 1}");
                                    table.Cell().Element(CellStyle).Text($"{10 + i * 5}");
                                    table.Cell().Element(CellStyle).Text(i % 2 == 0 ? "ناجح" : "راسب");
                                }

                                static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container) => container.PaddingVertical(5);
                            });
                            //column.Spacing(20);

                            // Add the bar chart image to the PDF
                            column.Item().ScaleHorizontal(5).ScaleVertical(5).Image(CreateBarChart(), ImageScaling.FitWidth);
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text("© جميع الحقوق محفوظة - نظام المدارس الدولية")
                        .FontSize(12);
                });
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

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

