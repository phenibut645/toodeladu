using zxcforum.core.context;
using zxcforum.core.controls;
using zxcforum.core.presets;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.forms.main.pages
{
    public partial class More: PageUserControl
    {
        public int StartY = 60;
        public int GapBetweenButton = 35;
        public More() : base()
        {

        }
        public override void InitAll()
        {
            base.InitAll();
            List<HeaderButton> buttons = DefaultPageTemplates.GetButtons(FormAppContext.Role, true);
            HeaderHandler.PushButtons(buttons);

            int y = StartY;
            List<HeaderButton> notDefaultButtonIndexes = new List<HeaderButton>();
            foreach(HeaderButton button in buttons)
            {
                if(button.Type == core.enums.HeaderButtonType.Default)
                {
                    button.Location = new Point(this.Width / 2 - button.Width / 2, y );
                    y += GapBetweenButton + button.Height;
                    this.Controls.Add(button);
                }
                else notDefaultButtonIndexes.Add(button);
            }
            foreach(HeaderButton button in notDefaultButtonIndexes)
            {
                buttons.Remove(button);
            }
        }
        public override void Clear()
        {
            base.Clear();
            HeaderHandler.ClearTempButtons();
        }

    }
}
