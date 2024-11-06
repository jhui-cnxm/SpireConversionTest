using FluentAssertions;
using Xunit;

namespace SpireConversionTest
{
    public class SpireConversionTests
    {
        private SpireConversion spireConversion = new SpireConversion();

        [Fact]
        public void SpireConversionTest()
        {
            var pdfDoc1 = spireConversion.ExecuteWorkflow();
            var pdfDoc2 = spireConversion.ExecuteWorkflow();

            // compare objects
            //pdfDoc1.Should().BeEquivalentTo(pdfDoc2);     // Test fails here

            // compare streams
            var stream1 = pdfDoc1.SaveToStream(Spire.Pdf.FileFormat.SVG);
            string streamTxt1 = "";
            foreach (var stream in stream1)
            {
                StreamReader reader = new StreamReader(stream);
                streamTxt1 += reader.ReadToEnd();
            }

            var stream2 = pdfDoc2.SaveToStream(Spire.Pdf.FileFormat.SVG);
            string streamTxt2 = "";
            foreach (var stream in stream2)
            {
                StreamReader reader = new StreamReader(stream);
                streamTxt2 += reader.ReadToEnd();
            }

            streamTxt1.Should().Be(streamTxt2);         // Test fails here
        }
    }
}
