using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Cotacao.PDF
{
    public class GerarPdfBcb
    {
        public GerarPdfBcb(string cotacaoDolar,string cotacaoEuro, string dataCotacao) 
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string pastaDownloads = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "downloads");
            Directory.CreateDirectory(pastaDownloads); 

            string caminho = Path.Combine(pastaDownloads, "Cotacao.pdf");

            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }

            iTextSharp.text.Document pdf = new iTextSharp.text.Document();
            PdfWriter.GetInstance(pdf, new FileStream(caminho, FileMode.Create));
            pdf.Open();

            var titulo = new Paragraph("Cotação do Real", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            pdf.Add(titulo);

            pdf.Add(new Paragraph("\n")); 

            pdf.Add(new Paragraph($"Data da cotação: {dataCotacao}"));
            pdf.Add(new Paragraph($"Valor do Dólar: R$ {cotacaoDolar}"));
            pdf.Add(new Paragraph($"Valor do Euro: R$ {cotacaoEuro}"));

            pdf.Close();
        }
    }
}
