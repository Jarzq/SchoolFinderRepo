using OfficeOpenXml;
using SchoolFinder.models;

namespace SchoolFinder.Helpers
{
    public static class ExcelHelper
    {
        public static List<JednostkaSzkolna> ReadExcelFile(string filePath)
        {
            var jednostkiSzkolne = new List<JednostkaSzkolna>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 4; row <= worksheet.Dimension.End.Row; row++)
                {
                    var jednostkaSzkolna = new JednostkaSzkolna
                    {
                        Dzielnica = worksheet.Cells[row, 1].Value.ToString(),
                        NazwaSzkoly = worksheet.Cells[row, 2].Value.ToString(),
                        SymbolOddzialu = worksheet.Cells[row, 3].Value.ToString(),
                        NazwaOddzialu = worksheet.Cells[row, 4].Value.ToString(),
                    };

                    double minimalnePunkty;
                    double maksymalnePunkty;

                    if (worksheet.Cells[row, 5].Value != null && double.TryParse(worksheet.Cells[row, 5].Value.ToString(), out minimalnePunkty))
                        jednostkaSzkolna.MinimalnePunkty = minimalnePunkty;

                    if (worksheet.Cells[row, 6].Value != null && double.TryParse(worksheet.Cells[row, 6].Value.ToString(), out maksymalnePunkty))
                        jednostkaSzkolna.MaksymalnePunkty = maksymalnePunkty;


                    jednostkiSzkolne.Add(jednostkaSzkolna);
                }
            }

            return jednostkiSzkolne;
        }
    }
}