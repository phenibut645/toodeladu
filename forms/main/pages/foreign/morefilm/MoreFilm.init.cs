using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using zxcforum.core.models.database;
using zxcforum.core.context;
using zxcforum.forms.main.pages.foreign;
namespace zxcforum.forms.main.pages
{
    public partial class MoreFilm
    {
        public override void InitAll()
        {
            base.InitAll();
            //InitLines();
            InitPoster();
            InitHeaderText();
            InitRunTime();
            InitGenre();
            InitOstaButton();
            InitKirjeldus();
        }
        private void InitOstaButton()
        {
            this.OstaPiletButton = new Button();
            OstaPiletButton = new Button();
            OstaPiletButton.Font = DefaultFonts.GetFont(23);
            OstaPiletButton.Text = "Osta pilet";
            OstaPiletButton.BackColor = ColorManagment.InputColors;
            OstaPiletButton.Size = new Size(240, 44);
            OstaPiletButton.Location = new Point(67 , 765);
            OstaPiletButton.ForeColor = Color.White;
            OstaPiletButton.FlatStyle = FlatStyle.Flat;
            OstaPiletButton.FlatAppearance.BorderSize = 0;
            OstaPiletButton.Click += OstaPiletButton_Click;
            this.Controls.Add(OstaPiletButton);
        }

        private void OstaPiletButton_Click(object sender, EventArgs e)
        {
            if (FormAppContext.CurrentUser == null)
            {
                Login form = new Login();
                form.Show();
                return;
            }
            HeaderHandler.ChangeToForeignPage(new Booking(this.Film));
        }

        private void InitPoster()
        {
            Poster = new PictureBox();
            Poster.Image = DefaultImages.GetPoster(Film);
            Poster.Size = new Size(435, 651);
            Poster.SizeMode = PictureBoxSizeMode.Zoom;
            Poster.Location = new Point(1078, 125);
            this.Controls.Add(Poster);
        }
        private void InitHeaderText()
        {
            FilmName = new Label();
            FilmName.Font = DefaultFonts.GetFont(38);
            FilmName.AutoSize = true;
            FilmName.BackColor = ColorManagment.InvisibleBackGround;
            FilmName.Location = new Point(67, 97);
            FilmName.ForeColor = Color.White;
            FilmName.Text = Film["nimetus"];
            this.Controls.Add(FilmName);
        }
        private void InitKirjeldus()
        {
            KirjeldusLabel = new Label();
            KirjeldusLabel.Font = DefaultFonts.GetFont(18);
            KirjeldusLabel.ForeColor = ColorManagment.MovieCardOption;
            KirjeldusLabel.Text = "Kirjeldus";
            KirjeldusLabel.AutoSize = true;
            KirjeldusLabel.Location = new Point(67, 357);
            KirjeldusLabel.BackColor = ColorManagment.InvisibleBackGround;
            this.Controls.Add(KirjeldusLabel);

            KirjeldusLabelValue = new Label();
            KirjeldusLabelValue.Font = DefaultFonts.GetKanitFont(15);
            KirjeldusLabelValue.ForeColor = Color.White;
            KirjeldusLabelValue.Text = Film["kirjeldus"];
            KirjeldusLabelValue.MaximumSize = new Size(704, 0);
            KirjeldusLabelValue.AutoSize = true;
            KirjeldusLabelValue.Location = new Point(67, 397);
            KirjeldusLabelValue.BackColor = ColorManagment.InvisibleBackGround;
            this.Controls.Add(KirjeldusLabelValue);

        }
        private void InitRunTime()
        {
            RunTimeLabel = new Label();
            RunTimeLabel.Font = DefaultFonts.GetFont(18);
            RunTimeLabel.ForeColor = ColorManagment.MovieCardOption;
            RunTimeLabel.Text = "Kestvus";
            RunTimeLabel.AutoSize = true;
            RunTimeLabel.Location = new Point(67, 282);
            RunTimeLabel.BackColor = ColorManagment.InvisibleBackGround;

            RunTimeLabelValue = new Label();
            RunTimeLabelValue.Font = DefaultFonts.GetKanitFont(20);
            RunTimeLabelValue.ForeColor = ColorManagment.MovieCardOptionValue;
            RunTimeLabelValue.Text = Film["kestvus"];
            RunTimeLabelValue.AutoSize = true;
            RunTimeLabelValue.Location = new Point(67, 305);
            
            RunTimeLabelValue.BackColor = ColorManagment.InvisibleBackGround;
            this.Controls.Add(RunTimeLabel);
            this.Controls.Add(RunTimeLabelValue);
        }
        private void InitGenre()
        {
            List<Filmizanres> filmid = DBHandler.GetTableData<Filmizanres>();
            List<string> zanrid = new List<string>();
            foreach(Filmizanres film in filmid)
            {
                if (film["film"] == Film["id"])
                {
                    zanrid.Add(DBHandler.GetSingleResponse($"SELECT zanr FROM zanr WHERE id = {film["zanr"]}", "zanr"));
                }
            }

            GenreLabel = new Label();
            GenreLabel.Font = DefaultFonts.GetFont(18);
            GenreLabel.ForeColor = ColorManagment.MovieCardOption;
            GenreLabel.Text = "Zanrid";
            GenreLabel.Location = new Point(67, 203);
            GenreLabel.Size = new Size(500, 25);
            GenreLabel.BackColor = ColorManagment.InvisibleBackGround;

            GenreLabelValue = new Label();
            GenreLabelValue.Font = DefaultFonts.GetKanitFont(20);
            GenreLabelValue.ForeColor = ColorManagment.MovieCardOptionValue;
            GenreLabelValue.Text = String.Join(", ", zanrid.ToArray());
            GenreLabelValue.AutoSize = true;
            GenreLabelValue.Location = new Point(67, 228);
            
            GenreLabelValue.BackColor = ColorManagment.InvisibleBackGround;
            this.Controls.Add(GenreLabel);
            this.Controls.Add(GenreLabelValue);
        }
        //private void InitLines()
        //{
        //    int lineNumber = 0;
        //    foreach(List<int> size in LinesWidth)
        //    {
        //        lineNumber++;
        //        Label line = new Label();
        //        line.BackColor = ColorManagment.MovieCardBorder;
        //        line.Size = new Size(size[0], size[1]);
        //        if(lineNumber == 2) line.Location = new Point(863 - LineThickness, 0);
        //        else if(lineNumber == 3) line.Location = new Point(0, 952 - LineThickness);
        //        else if(lineNumber == 5) line.Location = new Point(271,0);
        //        else if(lineNumber == 6) line.Location = new Point(0,406);
        //        else line.Location = new Point(0,0);
        //        this.Controls.Add(line);
        //    }
        //}
    }
}
