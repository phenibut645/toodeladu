using zxcforum.core.interfaces;
using zxcforum.core.models;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.core.controls.buttons
{
    public class SelectOptionButton: Button
    {
        public SelectOption Option { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    this.BackColor = ColorTranslator.FromHtml("#303689");

                }
                else
                {
                    this.BackColor = ColorTranslator.FromHtml("#464A7A");
                }
            }
        }
        public Action<SelectOptionButton> OnSelect { get; private set; }
        public SelectOptionButton(SelectOption option)
        {
            Option = option;
            this.Text = Option.ExternalText;
            this.Click += clicked;
        }
        private void clicked(object sender, EventArgs e)
        {
            OnSelect(this);
        }
        public void AddClickMethod(Action<SelectOptionButton> func)
        {
            OnSelect = func;
        }
    }
}
