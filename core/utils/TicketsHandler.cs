using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.models;
using zxcforum.core.models.database;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using PdfSharp.UniversalAccessibility.Drawing;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace zxcforum.core.utils
{
    public static class TicketsHandler
    {
        public static string CreateTicketPdf(Film movie, User user, string koht, string row)
        {
            string imagePath = "asdddd.png";

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 14, XFontStyleEx.Regular);
            XPen redPen = new XPen(XColors.Red, 2);

            double imageBoxX = 50, imageBoxY = 50, imageBoxWidth = 100, imageBoxHeight = 100;
            gfx.DrawRectangle(redPen, imageBoxX, imageBoxY, imageBoxWidth, imageBoxHeight);

            gfx.DrawString($"Tere, {user.name}!", font, XBrushes.Red, new XPoint(imageBoxX + 10, imageBoxY + imageBoxHeight + 20));

            double largeBoxX = 50, largeBoxY = 200, largeBoxWidth = 150, largeBoxHeight = 300;
            gfx.DrawRectangle(redPen, largeBoxX, largeBoxY, largeBoxWidth, largeBoxHeight);

            double textStartX = largeBoxX + largeBoxWidth + 20, textStartY = largeBoxY + 20;

            gfx.DrawString(movie["nimetus"], font, XBrushes.Red, new XPoint(textStartX, textStartY));
            gfx.DrawString($"Koht: {koht}", font, XBrushes.Red, new XPoint(textStartX, textStartY + 30));
            gfx.DrawString($"Rida: {row}", font, XBrushes.Red, new XPoint(textStartX, textStartY + 60));

            if (File.Exists(imagePath))
            {
                XImage image = XImage.FromFile(Path.Combine(DefaultPaths.PostersPath, movie["poster"]));
                gfx.DrawImage(image, imageBoxX + 1, imageBoxY + 1, imageBoxWidth - 2, imageBoxHeight - 2);
            }
            string filename = Path.Combine(DefaultPaths.PdfFilesPath, $"{user.name}_{user.id}_{movie["nimi"]}_{DateTime.Now.Ticks}.pdf");
            document.Save(filename);
            return filename;
        }
        public static void SendEmail(Film movie, User user, string koht, string row, string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                string path = CreateTicketPdf(movie, user, koht, row);
                mail.From = new MailAddress("tarikpikarik@gmail.com");
                mail.To.Add(email);
                mail.Subject = $"{movie["name"]} pilet";
                mail.Body = "Sinu pilet on siin";
                mail.IsBodyHtml = true;

                if (File.Exists(path))
                {
                    mail.Attachments.Add(new Attachment(path));
                }

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("tarikpikarik@gmail.com", "xrpy mrnl xujh ijhi");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
