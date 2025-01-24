using zxcforum.core.controls.buttons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.core.controls
{
    public partial class AdminDefaultManagerPage<T> : UserControl
    {
        public Panel SelectPanel { get; set; }
        public Panel OptionsPanel { get; set; }
        public Panel AddPanel { get; set; }
        public Panel DownOptionsPanel { get; set; }
        public Button DownSelectedPanelButton { get; set; }
        public Button AddButton { get; set; }
        public Panel SelectedInputsPanel { get; set; }
        public List<OptionButton<T>> Buttons = new List<OptionButton<T>>();
        public string FieldName { get; set; }
        public int OptionSize { get; set; }
        public int StartOptionPositionY = 49;
        public int GapBetweenButtons = 20;

        public List<int> size = new List<int> { 681, 48 };
        public List<int> fieldSize = new List<int> { 191, 48 };
        public List<int> valueSize = new List<int> { 442, 48 };
        public List<int> buttonSize = new List<int> { 48, 48 };

        public Panel SelectedPanel { get; set; }
        public OptionButton<T> SelectedButton { get; set; }
    }
}
