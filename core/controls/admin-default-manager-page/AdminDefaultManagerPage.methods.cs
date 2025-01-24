using zxcforum.core.controls.buttons;
using zxcforum.core.interfaces;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.core.controls
{
    public partial class AdminDefaultManagerPage<T> : UserControl where T: Table, ITable, new()
    {
        public void Selected(OptionButton<T> button)
        {
            if(SelectedButton != null) SelectedButton.IsActive = false;
            SelectedButton = button;
            SelectedButton.IsActive = true;

            InitAdvancedOptions(type: enums.PanelType.Choice);
        }
        public void ReDraw()
        {
            
            if (SelectedButton != null) SelectedButton.IsActive = false;
            SelectedButton = null;
            if (SelectedInputsPanel != null)SelectedInputsPanel.Dispose();
            InitRightPanel();
            SelectPanel.Dispose();
            InitSelectPanel();
            InitButtons();

        }
    }
}
