﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.models;
using zxcforum.core.models.database;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using zxcforum.core.context;


namespace zxcforum.core.utils
{
    public static class TicketsHandler
    {
        public static void CreateTicketPdf()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Tšekk";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
        
            int startX = 50;
            int startY = 50;
            int imageWidth = 100;
            int imageHeight = 100;
            int textOffsetX = 120;
            int textLineHeight = 20;
            int spacing = 150;
            int lopphind = 0;
            foreach(KeyValuePair<Toode, int> entry in FormAppContext.Korv)
            {
                string imagePath = Path.Combine(DefaultPaths.ProductsPath ,entry.Key["pilt"]);
                if (File.Exists(imagePath)) 
                {
                    XImage image = XImage.FromFile(imagePath);
                    gfx.DrawImage(image, startX, startY, imageWidth, imageHeight);
                }
                gfx.DrawString($"Toode: {entry.Key["nimetus"]}", new XFont("Arial", 12), XBrushes.Black, new XPoint(startX + textOffsetX, startY + 20));
                gfx.DrawString($"Kogus: {entry.Value}", new XFont("Arial", 12), XBrushes.Black, new XPoint(startX + textOffsetX, startY + 40));
                gfx.DrawString($"Hind: {int.Parse(entry.Key["hind"]) * entry.Value }", new XFont("Arial", 12), XBrushes.Black, new XPoint(startX + textOffsetX, startY + 60));
                lopphind += int.Parse(entry.Key["hind"]) * entry.Value ;
                startY += spacing;
            }

            gfx.DrawString($"Lõpphind: {lopphind}", new XFont("Arial", 12), XBrushes.Black, new XPoint(startX + textOffsetX, startY + 60));

            string outputPath = "tsekk.pdf";
            document.Save(Path.Combine(DefaultPaths.PdfFilesPath, outputPath));
        }
    }
}