using System.Globalization;
using UglyToad.PdfPig.Content;

internal class Utils
{
    readonly static Dictionary<string, CultureInfo> _MappingCultures2Format = new Dictionary<string, CultureInfo>
    {
        [".fr"] = new CultureInfo("fr-FR"),
        [".com"] = new CultureInfo("en-US"),
        [".jp"] = new CultureInfo("ja-JP"),
    };
    public static List<BookingsModel> ExtractFilms(List<string> pdfTexts, List<Hyperlink> Hyperlinks)
    {
        List<BookingsModel> data = new();

        // get valid hyperlink for cuture detection
        string hyperlink = Hyperlinks[0].Text;

        // Define remove strings
        string removeString1 = "tickets:";
        string removeString2 = "Visit";

        // itterate over all Textes
        foreach (string pdfText in pdfTexts)
        {
            // define header and endings to clean string 
            string _cleanedPdfText = pdfText.Trim();
            int headerIndex = pdfText.IndexOf(removeString1) + removeString1.Length;
            int endingIndex = pdfText.IndexOf(removeString2) - headerIndex;
            _cleanedPdfText = _cleanedPdfText.Substring(headerIndex, _cleanedPdfText.Length - headerIndex);
            _cleanedPdfText = _cleanedPdfText.Substring(0, endingIndex);

            // read all relevant parts of the pdf text
            string[] parts = _cleanedPdfText.Split(new string[] { "Title:", "Date:", "Time:" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i += 3)
            {
                // get title and date&time
                var title = parts[i];
                var inputDateTime = $"{parts[i + 1]} {parts[i + 2]}";
                data.Add(new BookingsModel(title, GetDateTimeByHyperlink(inputDateTime, hyperlink)));
            }
        }
        return data;
    }
    internal static DateTime GetDateTimeByHyperlink(string inputDateTime, string hyperlink)
    {
        foreach (var culture in _MappingCultures2Format)
        {
            if (hyperlink.Contains(culture.Key))
            {
                CultureInfo.CurrentCulture = _MappingCultures2Format[culture.Key];
                return DateTime.Parse(inputDateTime);
            }
        }
        throw new Exception("No valid date type found!");
    }
}