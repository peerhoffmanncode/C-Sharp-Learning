using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

internal static class PDFFileHandler
{
    public static List<string> ReadWords(string Path)
    {
        List<string> foundText = new List<string>();
        using (PdfDocument document = PdfDocument.Open($@"{Path}"))
        {
            foreach (Page page in document.GetPages())
            {
                string pageText = page.Text;
                foundText.Add(pageText);
            }
        }
        return foundText;
    }

    public static List<Hyperlink> ReadHyperlinks(string Path)
    {
        using (PdfDocument document = PdfDocument.Open($@"{Path}"))
        {
            foreach (Page page in document.GetPages())
            {
                return (List<Hyperlink>)page.GetHyperlinks();                
            }
        }
        return null;
    }
}
