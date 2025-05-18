// using QuestPDF;
// using QuestPDF.Companion;
// using QuestPDF.Fluent;
// using QuestPDF.Helpers;
// using QuestPDF.Infrastructure;
// using QuestPDF.Previewer;
// using ScottPlot;
// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Data;
// using System.Data.SqlClient;
// using System.Diagnostics;
// using System.Drawing;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Windows.Forms;
// using Colors = QuestPDF.Helpers.Colors;

// private Dictionary<string, int> getGenreRentals()
// {
//     Dictionary<string, int> genreRentals = new Dictionary<string, int>();
//     SqlConnection connection = new SqlConnection("Data Source=SHARNOUBI_HP\\SQLEXPRESS;Initial Catalog=MovieRentalDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
//     connection.Open();

//     string query =
//         "SELECT GenreName, " +
//         " COUNT(*) AS RentalCount " +
//         "FROM  Rents " +
//         "JOIN  [Movie Tape] ON [Movie Tape].TapeID = Rents.TapeID " +
//         "JOIN   Genres  ON Genres.GenreID = [Movie Tape].GenreID " +
//         "GROUP  BY GenreName;";
//     SqlCommand getGenresRentals = new SqlCommand(query, connection);
//     using (SqlDataReader reader = getGenresRentals.ExecuteReader())
//     {
//         while (reader.Read())
//         {
//             string genre = reader["GenreName"].ToString();
//             int count = Convert.ToInt32(reader["RentalCount"]);
//             genreRentals[genre] = count;
//         }
//     }
//     return genreRentals;
// }

// private Dictionary<string, int> getGenreProfit()
// {
//     Dictionary<string, int> genreRentals = new Dictionary<string, int>();
//     SqlConnection connection = new SqlConnection("Data Source=SHARNOUBI_HP\\SQLEXPRESS;Initial Catalog=MovieRentalDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
//     connection.Open();

//     string query =
//         "SELECT GenreName, " +
//         " SUM(TotalCharge) AS Profit " +
//         "FROM  Rents " +
//         "JOIN  [Movie Tape] ON [Movie Tape].TapeID = Rents.TapeID " +
//         "JOIN   Genres  ON Genres.GenreID = [Movie Tape].GenreID " +
//         "GROUP  BY GenreName;";
//     SqlCommand getGenresRentals = new SqlCommand(query, connection);
//     using (SqlDataReader reader = getGenresRentals.ExecuteReader())
//     {
//         while (reader.Read())
//         {
//             string genre = reader["GenreName"].ToString();
//             int profit = Convert.ToInt32(reader["Profit"]);
//             genreRentals[genre] = profit;
//         }
//     }
//     return genreRentals;
// }

// private string GenerateBarChart(Dictionary<string, int> stats, QuestPDF.Infrastructure.Size size)
// {
//     ScottPlot.Plot plot = new ScottPlot.Plot();

//     var bars = stats.Select((item, index) => new Bar
//     {
//         Position = index + 1,
//         Value = item.Value,
//     }).ToArray();

//     var barPlot = plot.Add.Bars(bars);

//     foreach (var bar in bars)
//     {
//         bar.FillColor = new ScottPlot.Color(Colors.Grey.Medium.Hex);

//         bar.Size = 0.75;
//     }

//     plot.Add.Bars(bars);

//     var ticks = stats.Select((item, index) =>
//             new Tick(index + 1, item.Key)).ToArray();

//     plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
//     plot.Axes.Bottom.MajorTickStyle.Length = 0;
//     plot.Axes.Bottom.TickLabelStyle.FontName = "Rockwell";
//     plot.Axes.Bottom.TickLabelStyle.FontSize = 16;
//     plot.Axes.Bottom.TickLabelStyle.OffsetY = 8;
//     plot.Grid.XAxisStyle.IsVisible = false;

//     plot.Axes.Margins(bottom: 0, top: 0.25f);

//     return plot.GetSvgXml((int)size.Width, (int)size.Height);

// }

// private string generatePieChart(Dictionary<string, int> stats, QuestPDF.Infrastructure.Size size)
// {
//     ScottPlot.Plot plot = new ScottPlot.Plot();
//     Dictionary<string, int> genreRentals = getGenreRentals();

//     ScottPlot.Color[] sliceColors = new ScottPlot.Color[]
//     {
//         new ScottPlot.Color(Colors.Red.Lighten3.Hex),
//         new ScottPlot.Color(Colors.Yellow.Lighten3.Hex),
//         new ScottPlot.Color(Colors.LightBlue.Lighten3.Hex),
//         new ScottPlot.Color(Colors.LightGreen.Lighten3.Hex),
//         new ScottPlot.Color(Colors.Indigo.Lighten3.Hex),
//         new ScottPlot.Color(Colors.DeepPurple.Lighten3.Hex),
//         new ScottPlot.Color(Colors.BlueGrey.Lighten4.Hex),
//         new ScottPlot.Color(Colors.Cyan.Lighten4.Hex),
//     };

//     int index = 0;
//     var slicesList = new List<PieSlice>();
//     foreach (var record in genreRentals)
//     {
//         slicesList.Add(new PieSlice
//         {
//             Value = record.Value,
//             Label = record.Key,
//             FillColor = sliceColors[index % 8],
//         });
//         index++;
//     }

//     var slices = slicesList.ToArray();

//     var pie = plot.Add.Pie(slices);
//     //pie.DonutFraction = 0.5;
//     pie.SliceLabelDistance = 1.2;
//     pie.LineColor = ScottPlot.Colors.White;
//     //pie.LineWidth = 3;

//     foreach (var pieSlice in pie.Slices)
//     {
//         pieSlice.LabelStyle.FontName = "Rockwell";
//         pieSlice.LabelStyle.FontSize = 12;
//     }

//     plot.Axes.Frameless();
//     plot.HideGrid();

//     return plot.GetSvgXml((int)size.Width, (int)size.Height); ;
// }


// private void button1_Click(object sender, EventArgs e)
// {
//     QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

//     Document.Create(container =>
//     {
//         container.Page(page =>
//         {
//             page.Size(PageSizes.A4);
//             page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);


//             page.Content().Column(column =>
//              {
//                  column.Spacing(10);

//                  column.Item().Text("1] Rentals per Genre").AlignLeft().Bold().FontFamily("RockWell").FontSize(24);

//                  column.Item().AspectRatio(1).Svg(size =>
//                  {
//                      Dictionary<string, int> genreRentals = getGenreRentals();
//                      return GenerateBarChart(genreRentals, size);
//                  });
//                  column.Item().PageBreak();

//                  column.Item().Text("2] Profit per Genre").AlignLeft().Bold().FontFamily("Rockwell").FontSize(24);


//                  column.Item().AspectRatio(1).Svg(size =>
//                  {
//                      Dictionary<string, int> genreProfit = getGenreProfit();
//                      return GenerateBarChart(genreProfit, size);
//                  });

//              });

//             page.Footer().AlignCenter()
//             .Text(x =>
//             {
//                 x.Span("Page ").FontFamily("Rockwell");
//                 x.CurrentPageNumber();
//             });
//         });
//     }
//     ).GeneratePdfAndShow();
// }
