using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PDFApp
{
    public class PDF
    {
        private Thread thread;

        public void Create(List<double> xList, List<double> yList, List<string> textList, int firstCount, int lastCount, double grapValue1, double grapValue2)
        {
            if (thread != null && thread.IsAlive)
                return;
            thread = new Thread(() => ThreadProcess(xList, yList, textList, firstCount, lastCount, grapValue1, grapValue2));
            thread.Start();
        }

        private void ThreadProcess(List<double> xList, List<double> yList, List<string> textList, int firstCount, int lastCount, double grapValue1, double grapValue2)
        {
            CloseAdobeReader();
            Print(xList, yList, textList, firstCount, lastCount, grapValue1, grapValue2);
        }

        private void CloseAdobeReader()
        {
            foreach (Process clsProcess in Process.GetProcesses().Where(clsProcess => clsProcess.ProcessName.StartsWith("AcroRd32")))
                clsProcess.Kill();
        }

        private void Print(List<double> xList, List<double> yList, List<string> textList, int firstCount, int lastCount, double grapValue1, double grapValue2)
        {
            string pdfName = Name();
            FileStream printFileStream = new FileStream(pdfName, FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Document printDocument = new iTextSharp.text.Document();

            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(printDocument, printFileStream);
            printDocument.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            printDocument.Open();

            iTextSharp.text.Image pageBackgroundImg1 = PDFBackgroundImage(Properties.Resources.PDF1, 810, 646, 15, -20);
            printDocument.SetMargins(0f, 0f, 0f, 0f);
            printDocument.NewPage();
            printDocument.Add(pageBackgroundImg1);

            float[] dateWidthsPDF = { 690f, 110f };
            iTextSharp.text.pdf.PdfPTable dateTable = CreateTable(2, 39f, true, dateWidthsPDF, printDocument, 0, 9f);
            var dateFont = Font(0, 0, 0, "Calibri", 11);
            dateTable.AddCell("");
            dateTable.AddCell(new iTextSharp.text.Paragraph("Date : " + DateTime.Now.ToString("dd.MM.yyyy") + "\n" + "Time : " + DateTime.Now.ToString("HH:mm:ss"), dateFont));
            printDocument.Add(dateTable);
  
            float[] headerWidthsPDF = { 435f, 333f };
            iTextSharp.text.pdf.PdfPTable headerTable = CreateTable(2, 37f, true, headerWidthsPDF, printDocument, 0, 0);
            var headerFont = Font(0, 0, 0, "Calibri", 11);

            iTextSharp.text.pdf.PdfPCell nameCell = CreatePDFCell(0, -5);
            iTextSharp.text.Paragraph nameParagraph = new iTextSharp.text.Paragraph("Name : ", headerFont)
            {
                Alignment = iTextSharp.text.Element.ALIGN_RIGHT
            };
            nameCell.AddElement(nameParagraph);
            iTextSharp.text.pdf.PdfPCell noCell = CreatePDFCell(0, -30);
            iTextSharp.text.Paragraph noParagraph = new iTextSharp.text.Paragraph("No : ", headerFont)
            {
                Alignment = iTextSharp.text.Element.ALIGN_RIGHT
            };
            noCell.AddElement(noParagraph);
            iTextSharp.text.pdf.PdfPCell dateCell = CreatePDFCell(0, -54);
            iTextSharp.text.Paragraph dateParagraph = new iTextSharp.text.Paragraph("Date : ", headerFont)
            {
                Alignment = iTextSharp.text.Element.ALIGN_RIGHT
            };
            dateCell.AddElement(dateParagraph);

            headerTable.AddCell("");
            headerTable.AddCell(nameCell);
            headerTable.AddCell("");
            headerTable.AddCell(noCell);
            headerTable.AddCell("");
            headerTable.AddCell(dateCell);
            printDocument.Add(headerTable);

            float[] widthsPDF1 = { 110f, 720f };
            iTextSharp.text.pdf.PdfPTable pageTable1 = CreateTable(2, 141f, true, widthsPDF1, printDocument, 0, 0);
            List<double> tmpXList = new List<double>();
            List<double> tmpYList = new List<double>();
            for (int i = firstCount; i <= lastCount; i++)
            {
                tmpXList.Add(xList[i]);
                tmpYList.Add(yList[i]);
            }
            pageTable1.AddCell("");
            iTextSharp.text.Image image1 = CreateChart(tmpXList, tmpYList, 5, 3, 1010, 135, Color.White, 1, Color.Green, Color.White, "0.00", "Microsoft Sans Serif", 
                                           8, "X", "Y", 1, 1, Color.LightGray, 0, grapValue1);
            pageTable1.AddCell(image1);
            pageTable1.AddCell("");
            iTextSharp.text.Image image2 = CreateChart(tmpXList, tmpYList, 5, 3, 1010, 135, Color.White, 1, Color.Green, Color.White, "0.00", "Microsoft Sans Serif", 
                                                         8, "X", "Y", 1, 1, Color.LightGray, 0, grapValue1);
            pageTable1.AddCell(image2);
            pageTable1.AddCell("");
            iTextSharp.text.Image image3 = CreateChart(tmpXList, tmpYList, 5, 3, 1010, 135, Color.White, 1, Color.Green, Color.White, "0.00", "Microsoft Sans Serif", 
                                                           8, "X", "Y", 1, 1, Color.LightGray, 0, grapValue1);
            pageTable1.AddCell(image3);
            printDocument.Add(pageTable1);

            float[] widthsPDF2 = { 400f, 380f };
            iTextSharp.text.pdf.PdfPTable pageTable2 = CreateTable(2, 0, true, widthsPDF2, printDocument, 0, 0);
            var textFont = Font(0, 0, 0, "Calibri", 11);
            iTextSharp.text.pdf.PdfPCell textCell = CreatePDFCell(0, -19);
            iTextSharp.text.Paragraph textParagraph = new iTextSharp.text.Paragraph("Text1" + " - " + "Text2", textFont)
            {
                Alignment = iTextSharp.text.Element.ALIGN_CENTER
            };
            textCell.AddElement(textParagraph);
            pageTable2.AddCell("");
            pageTable2.AddCell(textCell);
            printDocument.Add(pageTable2);

            iTextSharp.text.Image pageBackgroundImg2 = PDFBackgroundImage(Properties.Resources.PDF2, 810, 646, 15, -20);
            printDocument.SetMargins(0f, 0f, 0f, 0f);
            printDocument.NewPage();
            printDocument.Add(pageBackgroundImg2);
            printDocument.Add(dateTable);
            printDocument.Add(headerTable);

            float[] widthsPDF3 = { 110f, 720f };
            iTextSharp.text.pdf.PdfPTable pageTable3 = CreateTable(2, 141f, true, widthsPDF3, printDocument, 0, 0);
            pageTable3.AddCell("");
            iTextSharp.text.Image image4 = CreateChart(tmpXList, tmpYList, 5, 3, 1010, 135, Color.White, 1, Color.Green, Color.White, "0.00", "Microsoft Sans Serif", 
                                           8, "X", "Y", 1, 1, Color.LightGray, 0, grapValue2);
            pageTable3.AddCell(image4);
            pageTable3.AddCell("");
            iTextSharp.text.Image image5 = CreateChart(tmpXList, tmpYList, 5, 3, 1010, 135, Color.White, 1, Color.Green, Color.White, "0.00", "Microsoft Sans Serif", 
                                           8, "X", "Y", 1, 1, Color.LightGray, 0, grapValue2);
            pageTable3.AddCell(image5);
            pageTable3.AddCell("");
            iTextSharp.text.Image image6 = CreateChart(tmpXList, tmpYList, 5, 3, 1010, 135, Color.White, 1, Color.Green, Color.White, "0.00", "Microsoft Sans Serif", 
                                           8, "X", "Y", 1, 1, Color.LightGray, 0, grapValue2);
            pageTable3.AddCell(image6);
            printDocument.Add(pageTable3);
            printDocument.Add(pageTable2);

            iTextSharp.text.Image pageBackgroundImg3 = PDFBackgroundImage(Properties.Resources.PDF3, 810, 646, 15, -20);
            printDocument.SetMargins(0f, 0f, 0f, 0f);
            printDocument.NewPage();
            printDocument.Add(pageBackgroundImg3);
            printDocument.Add(dateTable);
            printDocument.Add(headerTable);

            float[] widthsPDF4 = { 55f, 845f };
            iTextSharp.text.pdf.PdfPTable notesTable = CreateTable(2, 18f, true, widthsPDF4, printDocument, 0, 0);
            for (int i = 0; i < textList.Count; i++)
            {
                notesTable.AddCell("");
                notesTable.AddCell(textList[i]);
            }
            printDocument.Add(notesTable);

            printDocument.Close();
            printFileStream.Close();
            Process.Start(pdfName);
        }

        private string Name()
        {
            string name = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture) + ".pdf";

            return name;
        }

        private iTextSharp.text.Image PDFBackgroundImage(Image image, float widthScaleToFit, float heightScaleToFit, float xAbsolutePosition, float yAbsolutePosition)
        {
            iTextSharp.text.Image pageBackgroundImage = iTextSharp.text.Image.GetInstance(image, ImageFormat.Png);
            pageBackgroundImage.Alignment = iTextSharp.text.Image.UNDERLYING;
            pageBackgroundImage.ScaleToFit(widthScaleToFit, heightScaleToFit);
            pageBackgroundImage.SetAbsolutePosition(xAbsolutePosition, yAbsolutePosition);

            return pageBackgroundImage;
        }

        private iTextSharp.text.pdf.PdfPTable CreateTable(int cellCount, float fixedHeight, bool lockedWidthState, float[] widthsPDF, iTextSharp.text.Document printDocument, int defaultCellBorder, float defaultCellPaddingTop)
        {
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(cellCount);
            table.DefaultCell.FixedHeight = fixedHeight;
            table.LockedWidth = lockedWidthState;
            float[] tmpWidthsPDF = widthsPDF;
            table.SetWidthPercentage(tmpWidthsPDF, printDocument.PageSize);
            table.DefaultCell.Border = defaultCellBorder;
            table.DefaultCell.PaddingTop = defaultCellPaddingTop;

            return table;
        }

        private iTextSharp.text.Font Font(int red, int green, int blue, string fontName, float fontSize)
        {
            var fontColour = new iTextSharp.text.BaseColor(red, green, blue);
            iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(fontName, fontSize, fontColour);

            return font;
        }

        private iTextSharp.text.pdf.PdfPCell CreatePDFCell(int border, float paddingTop)
        {
            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell
            {
                HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_RIGHT,
                Border = border,
                PaddingTop = paddingTop
            };

            return cell;
        }

        private iTextSharp.text.Image CreateChart(List<double> xList, List<double> yList, double xAxisGridCount, double yAxisGridCount, int chartWidth, int chartHeight, Color chartBackColor, int seriesBorderWidth, Color seriesColor, Color chartAreaColor, 
                                                  string chartAreaLabelStyleFormat, string chartAreaLabelStyleFont, float chartAreaLabelStyleFontSize, string xChartAreaTitle, string yChartAreaTitle, int xChartAreaMajorGridLineWidth, 
                                                  int yChartAreaMajorGridLineWidth, Color chartAreaAxisColor, double yMinAxis, double yMaxAxis)
        {
            Chart chart = new Chart()
            {
                Width = chartWidth,
                Height = chartHeight,
                BackColor = chartBackColor
            };

            Series series = new Series("Series")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = seriesBorderWidth,
                Color = seriesColor
            };

            ChartArea chartArea = new ChartArea()
            {
                BackColor = chartAreaColor
            };

            chartArea.AxisX.LabelStyle.Format = chartAreaLabelStyleFormat;
            chartArea.AxisX.LabelStyle.Font = new Font(chartAreaLabelStyleFont, chartAreaLabelStyleFontSize);
            chartArea.AxisX.Title = xChartAreaTitle;
            chartArea.AxisX.TitleFont = new Font(chartAreaLabelStyleFont, chartAreaLabelStyleFontSize);
            chartArea.AxisX.Minimum = xList[0];
            chartArea.AxisX.Maximum = xList[xList.Count - 1];
            chartArea.AxisX.Interval = (xList[xList.Count - 1] - xList[0]) / xAxisGridCount;
            chartArea.AxisX.MajorGrid.LineWidth = xChartAreaMajorGridLineWidth;
            chartArea.AxisX.MajorGrid.LineColor = chartAreaAxisColor;
            chartArea.AxisX.MajorTickMark.LineColor = chartAreaAxisColor;
            chartArea.AxisX.MinorGrid.LineColor = chartAreaAxisColor;
            chartArea.AxisX.MinorTickMark.LineColor = chartAreaAxisColor;

            chartArea.AxisY.LabelStyle.Format = chartAreaLabelStyleFormat;
            chartArea.AxisY.LabelStyle.Font = new Font(chartAreaLabelStyleFont, chartAreaLabelStyleFontSize);
            chartArea.AxisY.Title = yChartAreaTitle;
            chartArea.AxisY.TitleFont = new Font(chartAreaLabelStyleFont, chartAreaLabelStyleFontSize);
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = yMaxAxis;
            chartArea.AxisY.Minimum = yMinAxis;
            chartArea.AxisY.Interval = (yMaxAxis - yMinAxis) / yAxisGridCount;
            chartArea.AxisY.MajorGrid.LineWidth = yChartAreaMajorGridLineWidth;
            chartArea.AxisY.MajorGrid.LineColor = chartAreaAxisColor;
            chartArea.AxisY.MajorTickMark.LineColor = chartAreaAxisColor;
            chartArea.AxisY.MinorGrid.LineColor = chartAreaAxisColor;
            chartArea.AxisY.MinorTickMark.LineColor = chartAreaAxisColor;

            chart.ChartAreas.Add(chartArea);
            chart.Series.Add(series);

            for (int i = 0; i < xList.Count; i++)
                chart.Series[0].Points.AddXY(xList[i], yList[i]);

            var chartImage = new MemoryStream();
            chart.SaveImage(chartImage, ChartImageFormat.Png);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartImage.GetBuffer());

            return image;
        }
    }
}
