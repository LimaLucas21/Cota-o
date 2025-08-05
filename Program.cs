using Cotacao.Interacoes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Threading.Tasks;

namespace Cotacao
{
    internal class Program : InteracaoBCB
    {
        static void Main(string[] args)
        {
            string XE = "https://www.xe.com/";
            DateTime data = DateTime.Now;
            bool loop = true;


            while (loop)
            {
                Console.Clear();
                Console.WriteLine("-------Cotação do Real-------\n" +
                "----- Dia: " + data.ToShortDateString() + " ------\n\n");
                Console.WriteLine("Digite o número correspondente:\n1 - Banco Central do Brasil\n2 - Fechar a aplicação");

                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        InteracaoBCB BCB = new InteracaoBCB();
                        Console.Clear();
                        Console.WriteLine("-------Cotação do Real-------\n" +
                        "----- Dia: " + data.ToShortDateString() + " ------\n\n");
                        Console.WriteLine("Cotação Dolar: " + BCB.Dolar);
                        Console.WriteLine("Cotação Euro: " + BCB.Euro + "\n\n");

                        Console.WriteLine("Escolha uma opção:\n" +
                        "1 - Gerar o PDF dessa cotação?\n" +
                        "2 - Fechar a aplicação");
                        escolha = Convert.ToInt32(Console.ReadLine());
                        switch (escolha)
                        {
                            case 1:
                                Console.Clear();
                                new Cotacao.PDF.GerarPdfBcb(BCB.Dolar, BCB.Euro, DateTime.Now.ToString());
                                Console.WriteLine("PDF baixado com sucesso na pasta Downloads da sua aplicação.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Digite um email para o envio do documento:");
                                string Enderecoemail = Console.ReadLine();
                                Console.WriteLine("Agora digite seu nome:");
                                string Destinatario = Console.ReadLine();
                                Email(Enderecoemail, Destinatario);

                                break;
                            case 2:
                                loop = false;
                                break;
                        }
                        Console.Clear();
                        break;

                    case 2:
                        loop = false;
                        break;

                }
                if (loop)
                {
                    Console.Clear();
                    Console.WriteLine("-------Cotação do Real-------\n" +
                    "----- Dia: " + data.ToShortDateString() + " ------\n\n");
                    Console.WriteLine("Escolha uma opção:\n" +
                    "1 - Voltar ao menu inicial?\n" +
                    "2 - Fechar a aplicação");
                    escolha = Convert.ToInt32(Console.ReadLine());
                    switch (escolha)
                    {
                        case 1:
                            Console.Clear();

                            break;
                        case 2:
                            loop = false;
                            break;
                    }
                }
            }

            Console.ReadKey();
        }

        static async void Email(string emailDestinatario, string destinatario)
        {
            var emailService = new EmailService(
                smtpHost: "smtp.gmail.com",
                smtpPort: 587,
                username: "cotacaoteste224@gmail.com",
                password: "tkpg puqe frff pwya"
            );

            bool enviado = await emailService.SendEmailAsync(
                to: emailDestinatario,
                subject: destinatario,
                body: "<p>Segue documento em pdf das cotações solicitadas.</p>"
            );
        }
        //cotacaoteste224@gmail.com
        //testeteste@123

    }
    public class EmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _username;
        private readonly string _password;
    
        public EmailService(string smtpHost, int smtpPort, string username, string password)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _username = username;
            _password = password;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            try
            {
                using (var client = new SmtpClient(_smtpHost, _smtpPort))
                {
                    client.Credentials = new NetworkCredential(_username, _password);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(_username, "Cotação do Dólar e Euro.");
                    mailMessage.To.Add(to);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = isHtml;
                    mailMessage.Attachments.Add(new Attachment(Caminho.CaminhoPDF));
                    await client.SendMailAsync(mailMessage);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                return false;
            }
        }
    }

}
