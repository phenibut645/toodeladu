using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using zxcforum.core.context;
using zxcforum.core.models;
using zxcforum.core.models.database;
using zxcforum.core.utils;

namespace zxcforum.core.controls.toode_card
{
    public partial class ToodeCard : UserControl
    {
        public PictureBox Image { get; set; }
        public Label ProductName { get; set; }
        public Label Cost { get; set; }
        public Button BuyButton { get; set; }
        public NumericUpDown AmountChoose { get; set; }
        public SelectControl Select { get; set; }
        public Label Amount { get; set; }
        public Toode Toode { get; set; }
        public ToodeCard(Toode toode, bool buttons = true, int kogus = 0)
        {
            this.Toode = toode;
            this.ClientSize = new Size(350, buttons ? 350 : 250);
            this.Image = new PictureBox();
            this.Image.Image = DefaultImages.GetProductImage(toode["pilt"]);
            this.Image.SizeMode = PictureBoxSizeMode.Zoom;
            this.Image.ClientSize = new Size(150, buttons ? 350 : 250);
            this.Controls.Add(Image);
            this.Image.Location = new Point(0,0);

            this.ProductName = new Label();
            this.ProductName.AutoSize = true;
            this.ProductName.Text = toode["nimetus"];
            this.ProductName.Font = DefaultFonts.GetKanitFont(16);
 
            this.Controls.Add(ProductName);
            this.ProductName.Location = new Point(Image.Width + 20, 20);
            
            this.Cost = new Label();
            this.ProductName.AutoSize = true;
            this.Cost.Text = $"Hind: {toode["hind"]}";
            this.Cost.Font = DefaultFonts.GetKanitFont(14);
            this.BackColor = ColorManagment.DefaultPanelColor;

            this.Controls.Add(Cost);
            this.Cost.ForeColor = Color.White;
            this.ProductName.ForeColor = Color.White;
            this.Cost.Location = new Point(Image.Width + 20, 40 + ProductName.Height);
            if (buttons) { 
            this.BuyButton = new Button();
            this.BuyButton.Text = "Lisa ostukorvi";
            this.BuyButton.ForeColor = Color.White;
            this.BuyButton.BackColor = ColorManagment.InputColors;
            this.BuyButton.Font = DefaultFonts.GetKanitFont(13);
            this.BuyButton.ClientSize = new Size(80, 50);
            this.Controls.Add(BuyButton);
            this.BuyButton.Location = new Point(Image.Width + 20,  80 + Cost.Height + ProductName.Height);
            BuyButton.Click += BuyButton_Click;

            Select = new SelectControl(new List<int>() { 150, 60 }, DBHandler.GetWarehouses(int.Parse(this.Toode["id"])), fontSize:18, buttonFontSize: 15);
            this.Controls.Add(Select);
            Select.Location = new Point(Image.Width + 20, 100 + Cost.Height + ProductName.Height + BuyButton.ClientSize.Height);
            AmountChoose = new NumericUpDown();
            AmountChoose.ClientSize = new Size(200, 100);
            AmountChoose.Font = DefaultFonts.GetKanitFont(15);
            AmountChoose.AutoSize = true;
            this.Controls.Add(AmountChoose);
            this.AmountChoose.Location = new Point(Image.Width + 20, 120 + Cost.Height + ProductName.Height + BuyButton.ClientSize.Height + Select.Height);
            }
            else
            {
                Amount = new Label();
                Amount.Text = $"Kogus: {kogus}";
                Amount.Font = DefaultFonts.GetKanitFont(15);
                Amount.AutoSize = true;
                Amount.ForeColor = Color.White;
                this.Controls.Add(Amount);
                Amount.Location = new Point(Image.Width + 20, 60 + ProductName.Height + Cost.Height);
            }
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            if(FormAppContext.CurrentUser == null)
            {
                Login log = new Login();
                log.Show();
                return;
            }
            if(Select.SelectedOption == null)
            {
                MessageBox.Show("Vali ladu");
                return;
            }
            int kogus = int.Parse(DBHandler.GetSingleResponse($"SELECT kogus FROM taidis WHERE ladu = {Select.SelectedOption.Option.Value}", "kogus"));
            if(AmountChoose.Value > kogus)
            {
                MessageBox.Show($"Kogus valiti suurem kui laos. Kogus valiti suurem kui laos. Maksimaalne kogus {Select.SelectedOption.Option.ExternalText}-laos võrdub {kogus.ToString()}-ga");
                AmountChoose.Value = kogus;
                return;
            }
            Console.WriteLine($"toode: {this.Toode["nimetus"]}");
            Console.WriteLine($"kogus: {(int)AmountChoose.Value}");


            FormAppContext.AddProductToKorv(this.Toode, (int)AmountChoose.Value);
            int currentAmount = kogus - (int)AmountChoose.Value;
            DBHandler.MakeQuery($"UPDATE taidis SET kogus = {currentAmount} WHERE ladu = {Select.SelectedOption.Option.Value}");
            MessageBox.Show($"Teie ostukorvi lisati toode \"{this.Toode["nimetus"]}\", kogus \"{kogus.ToString()}\" {Select.SelectedOption.Option.ExternalText}-laost");
        }
    }
}
