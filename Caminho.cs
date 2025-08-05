using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotacao
{
    public static class Caminho
    {
            public static readonly string PastaDownloads = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "downloads");
            public static readonly string CaminhoPDF = Path.Combine(PastaDownloads, "Cotacao.pdf");
    }
}
