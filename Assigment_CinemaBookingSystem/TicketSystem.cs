using System.Globalization;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using UglyToad.PdfPig.Content;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static UglyToad.PdfPig.Core.PdfSubpath;

internal static class TicketSystem
{

    const string outputFile = "aggregatedTickets.txt";
    public static void run(string BasePath, IFileHandler fileHandler)
    {
        // get all files in base folder
        string[] allTicketPDFs = FileUtils.FindAllFiles(BasePath, "*.pdf");

        List<BookingsModel> allBookings = new();

        foreach (string ticketPDF in allTicketPDFs)
        {
            List<string> ReadText = PDFFileHandler.ReadWords(ticketPDF);
            List<Hyperlink> ReadHyperlinks = PDFFileHandler.ReadHyperlinks(ticketPDF);
            allBookings.AddRange(Utils.ExtractFilms(ReadText, ReadHyperlinks));
        }

        List<string> data = new();
        foreach (var Booking in allBookings)
        {
            data.Add($"{Booking.Title,-30} | {Booking.getInvaruant()}");
        }
        fileHandler.Write(outputFile, data);
        Console.WriteLine($"Result saved to {outputFile}");
    }
}
