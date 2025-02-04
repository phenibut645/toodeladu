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
namespace zxcforum.forms.main.pages
{
    public partial class Shop : PageUserControl
    {

        public Shop(): base()
        {
        }

        public override void InitAll()
        {
            base.InitAll();
            List<Toode> products = DBHandler.GetTableData<Toode>();
            List<ToodeCard> cards = new List<ToodeCard>() { };
            foreach(Toode product in products)
            {
                ToodeCard productCard = new ToodeCard(product);
                cards.Add(productCard);
                
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
        }
    }
}
