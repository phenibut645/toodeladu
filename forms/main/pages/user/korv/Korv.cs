using zxcforum.core.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.models.database;
using zxcforum.core.utils;
using zxcforum.core.controls.toode_card;
using zxcforum.core.context;
namespace zxcforum.forms.main.pages
{
    public partial class Korv : PageUserControl
    {
        public int StartCardX { get; set; } = 52;
        public int StartCardY { get; set; } = 52;
        public int BetweenCardsGapX { get; set; } = 42;
        public int BetweenCardsGapY { get; set; } = 42;
        public Button SubmitButton { get; set; }
        public Button Cancel { get; set; }
        public Korv(): base()
        {
        }

        public override void InitAll()
        {
            base.InitAll();
            if(FormAppContext.Korv.Count == 0) return;
            SubmitButton = new Button();
            SubmitButton.Text = "Esitada";
            SubmitButton.BackColor = ColorManagment.InputColors;
            SubmitButton.ForeColor = Color.White;
            SubmitButton.Font = DefaultFonts.GetKanitFont(15);
            SubmitButton.ClientSize = new Size(100, 80);
            SubmitButton.Click += SubmitButton_Click;
            Cancel = new Button();
            Cancel.Text = "Tellimuse tühistamine";
            Cancel.BackColor = ColorManagment.InputColors;
            Cancel.ForeColor = Color.White;
            Cancel.Font = DefaultFonts.GetKanitFont(15);
            Cancel.ClientSize = new Size(100, 80);
            Cancel.Click += Cancel_Click;
            this.Controls.Add(Cancel);

            this.Controls.Add(SubmitButton);
            int lopphind = 0;
            List<ToodeCard> cards = new List<ToodeCard>() { };
            
            foreach(KeyValuePair<Toode, int> entry in FormAppContext.Korv)
            {
                ToodeCard productCard = new ToodeCard(entry.Key, buttons:false, kogus: entry.Value);
                cards.Add(productCard);
                lopphind += entry.Value;
            }
            int y = StartCardY;
            int x = StartCardX;
            int count = 0;
           
            foreach(ToodeCard card in cards)
            {
                if (count == 4)
                {
                    count = 0;
                    y += BetweenCardsGapY + card.Height;
                    x = StartCardX;
                }
                this.Controls.Add(card);
                card.Location = new Point(x, y);
                x += BetweenCardsGapX + card.ClientSize.Width;
                count += 1;
            }
            Label Hind = new Label();
            
            Hind.Text = $"Lõpphind: {lopphind}";
            Hind.ForeColor = Color.White;
            Hind.Font = DefaultFonts.GetKanitFont(15);
            Hind.AutoSize = true;
            this.Controls.Add(Hind);
            Hind.Location = new Point(StartCardX + 30 + SubmitButton.Width, y + 50 + cards[0].Height);
            SubmitButton.Location = new Point(StartCardX, y + 50 + cards[0].Height);
            Cancel.Location = new Point(StartCardX + 60 + SubmitButton.Width + Hind.Width, y + 50 + cards[0].Height);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            foreach(KeyValuePair<Toode, int> entry in FormAppContext.Korv)
            {
                int kogemus = int.Parse(DBHandler.GetSingleResponse($"SELECT kogus FROM taidis WHERE ladu = 1 and toode = {entry.Key["id"]}", "kogus"));
                DBHandler.MakeQuery($"UPDATE taidis SET kogus = {kogemus + entry.Value} WHERE ladu = 1 and toode = {entry.Key["id"]}");
            }
            FormAppContext.Korv.Clear();
            FormAppContext.MainForm.RefreshForm();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            TicketsHandler.CreateTicketPdf();
            FormAppContext.Korv.Clear();
            FormAppContext.MainForm.RefreshForm();
        }
    }
}
