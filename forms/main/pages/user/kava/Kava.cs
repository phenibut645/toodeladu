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
namespace zxcforum.forms.main.pages
{
    public partial class Kava : PageUserControl
    {
        public Kava(): base()
        {
        }

        public override void InitAll()
        {
            base.InitAll();

            MainPanel = new Panel();
            this.Controls.Add(MainPanel);
            MainPanel.AutoScroll = true;
            MainPanel.Dock = DockStyle.Fill;

            List<Film> filmid = DBHandler.GetTableData<Film>();
            int index = 0;
            int currentX = StartCardX;
            int currentY = StartCardY;
            foreach(Film film in filmid)
            {
                index++;
                MovieCard movieCard = new MovieCard(film);
                MovieCards.Add(movieCard);
               
                movieCard.Location = new Point(currentX , currentY);
                MainPanel.Controls.Add(movieCard);

                currentX = StartCardX + movieCard.Width + BetweenCardsGapX;

                if(index % 2 == 0)
                {
                    currentY += 406 + BetweenCardsGapY;
                    currentX = StartCardX;
                }
            }
        }
    }
}
