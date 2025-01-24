using zxcforum.core.models.database;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.core.controls
{
    public partial class MovieCard
    {
        private void InitAll()
        {
            InitLines();
            InitHeaderText();
            InitRunTime();
            InitButtonMore();
            InitGenre();
            InitPoster();
        }
        private void InitHeaderText()
        {
            Header = new Label();
            Header.Font = utils.DefaultFonts.GetFont(38);
            Header.Size = new Size(385, 64);
            Header.BackColor = ColorManagment.InvisibleBackGround;
            Header.Location = new Point(309, 11);
            Header.ForeColor = ColorManagment.MovieCardHeader;
            Header.Text = FilmTable["nimetus"];
            this.Controls.Add(Header);
        }
        private void InitRunTime()
        {
            RunTimeLabel = new Label();
            RunTimeLabel.Font = utils.DefaultFonts.GetFont(18);
            RunTimeLabel.ForeColor = ColorManagment.MovieCardOption;
            RunTimeLabel.Text = "Kestvus";
            RunTimeLabel.Location = new Point(309, 171);
            RunTimeLabel.Size = new Size(93, 25);
            RunTimeLabel.BackColor = ColorManagment.InvisibleBackGround;

            RunTime = new Label();
            RunTime.Font = utils.DefaultFonts.GetFont(24);
            RunTime.ForeColor = ColorManagment.MovieCardOptionValue;
            RunTime.Text = FilmTable["kestvus"];
            RunTime.Location = new Point(309, 194);
            RunTime.Size = new Size(289, 40);
            RunTime.BackColor = ColorManagment.InvisibleBackGround;
            this.Controls.Add(RunTimeLabel);
            this.Controls.Add(RunTime);
        }
        private void InitButtonMore()
        {
            ButtonMore = new Button();
            ButtonMore.Font = utils.DefaultFonts.GetFont(26);
            ButtonMore.Text = "Rohkem";
            ButtonMore.BackColor = ColorManagment.InputColors;
            ButtonMore.Size = new Size(186, 67);
            ButtonMore.Location = new Point(576, 316);
            ButtonMore.ForeColor = Color.White;
            ButtonMore.FlatStyle = FlatStyle.Flat;
            ButtonMore.FlatAppearance.BorderSize = 0;
            ButtonMore.Click += buttonMore_clicked;
            this.Controls.Add(ButtonMore);
                                    
        }
        private void InitGenre()
        {
            List<Filmizanres> filmid = DBHandler.GetTableData<Filmizanres>();
            List<string> zanrid = new List<string>();
            foreach(Filmizanres film in filmid)
            {
                if (film["film"] == FilmTable["id"])
                {
                    zanrid.Add(DBHandler.GetSingleResponse($"SELECT zanr FROM zanr WHERE id = {film["zanr"]}", "zanr"));
                }
            }

            GenreLabel = new Label();
            GenreLabel.Font = utils.DefaultFonts.GetFont(18);
            GenreLabel.ForeColor = ColorManagment.MovieCardOption;
            GenreLabel.Text = "Zanrid";
            GenreLabel.Location = new Point(309, 101);
            GenreLabel.Size = new Size(500, 25);
            GenreLabel.BackColor = ColorManagment.InvisibleBackGround;

            Genre = new Label();
            Genre.Font = utils.DefaultFonts.GetFont(24);
            Genre.ForeColor = ColorManagment.MovieCardOptionValue;
            Genre.Text = String.Join(", ", zanrid.ToArray());
            Genre.Location = new Point(309, 126);
            Genre.Size = new Size(500, 35);
            Genre.BackColor = ColorManagment.InvisibleBackGround;
            this.Controls.Add(GenreLabel);
            this.Controls.Add(Genre);
        }
        private void InitPoster()
        {
            Poster = new PictureBox();
            Poster.Size = new Size(271, 406);
            Poster.SizeMode = PictureBoxSizeMode.Zoom;
            Poster.Image = DefaultImages.GetPoster(FilmTable);
            this.Controls.Add(Poster);
        }
        private void InitLines()
        {
            int lineNumber = 0;
            foreach(List<int> size in LinesWidth)
            {
                lineNumber++;
                Label line = new Label();
                line.BackColor = ColorManagment.MovieCardBorder;
                line.Size = new Size(size[0], size[1]);
                if(lineNumber == 2) line.Location = new Point(787 - LineThickness, 0);
                else if(lineNumber == 3) line.Location = new Point(0, 406 - LineThickness);
                else if(lineNumber == 5) line.Location = new Point(271,0);
                else line.Location = new Point(0,0);
                this.Controls.Add(line);
            }
        }
    }
}
