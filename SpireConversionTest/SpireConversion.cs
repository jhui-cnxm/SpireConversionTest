using Spire.Pdf;

namespace SpireConversionTest
{
    public class SpireConversion
    {
        public SpireConversion()
        {
            Spire.Doc.License.LicenseProvider.SetLicenseKey("sample_license_key");
            Spire.Pdf.License.LicenseProvider.SetLicenseKey("sample_license_key");
        }

        public PdfDocument ExecuteWorkflow()
        {
            string extension = "doc";
            byte[] docData = File.ReadAllBytes($"..\\..\\..\\..\\document.{extension}");

            // Load DOC document
            Spire.Doc.FileFormat format = Spire.Doc.FileFormat.Auto;
            var document = new Spire.Doc.Document();
            using (var inStream = new MemoryStream(docData))
            {
                document.LoadFromStream(inStream, format);
            }

            // Extract PDF byte data
            byte[] pdfData;
            using (var outStream = new MemoryStream())
            {
                document.SaveToStream(outStream, Spire.Doc.FileFormat.PDF);
                outStream.Position = 0;
                pdfData = outStream.ToArray();
            }

            // Create PDF document from byte data
            var pdfDocument = new PdfDocument();
            pdfDocument.LoadFromBytes(pdfData);
            return pdfDocument;
        }
    }
}
