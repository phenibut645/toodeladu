using zxcforum.core.interfaces;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using zxcforum.core.utils;
namespace zxcforum.core.controls.buttons
{
    public partial class OptionButton<T>: UserControl where T: Table, ITable
    {
        public Panel IconFrame { get; set; }
        public PictureBox Icon { get; set; }
        public Panel OptionNameBackground { get; set; }
        public Label OptionNameValue { get; set; }
        public T Record { get; set; }
        private bool _isActive = false;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                ChangeActiveStatus();
            }
        }
        public Action<OptionButton<T>> funcMethod { get; set;} = null;
        public int OptionWidth { get; set; }
        public int OptionHeight { get; set; }
        public int IconFrameSize { get; set; } = 61;
        public string FieldName { get; set; }

        public OptionButton(T record, string fieldName, int sizeX)
        {
            OptionWidth = sizeX + IconFrameSize;
            FieldName = fieldName;
            OptionHeight = 61;
            this.ClientSize = new Size(OptionWidth + IconFrameSize, OptionHeight);
            Record = record;
            InitAll();
            IsActive = false;
        }

        public void AddClickMethod(Action<OptionButton<T>> func)
        {
            funcMethod = func;
            foreach(Control control in this.Controls)
            {
                control.Click += clicked;
            }
            this.Click += clicked;
        }
        private void clicked(object sender, EventArgs e)
        {
            if(funcMethod != null)
            {
                funcMethod(this);
            }
        }
        private void ChangeActiveStatus()
        {
            if (IsActive)
            {
                Icon.Image = DefaultImages.GetDefaultImage("eye.png");
            }
            else
            {
                Icon.Image = DefaultImages.GetDefaultImage("edit.png");
            }
        }
        public void InitAll()
        {
            InitIcon();
            InitOptionName();
        }
        public void InitIcon()
        {
            IconFrame = new Panel();
            IconFrame.Size = new Size(61, 61);
            IconFrame.BackColor = ColorManagment.IconBackgroundPurple;
            this.Controls.Add(IconFrame);
            Icon = new PictureBox();
            Icon.Size = new Size(32, 32);
            Icon.BackColor = ColorManagment.InvisibleBackGround;
            Icon.SizeMode = PictureBoxSizeMode.Zoom;
            Icon.Location = new Point(IconFrame.Width / 2 - Icon.Size.Width / 2, IconFrame.Height / 2 - Icon.Height /2);
            IconFrame.Controls.Add(Icon);
        }
        public void InitOptionName()
        {
            OptionNameBackground = new Panel();
            OptionNameBackground.BackColor = ColorManagment.OptionField;
            OptionNameBackground.Size = new Size(OptionWidth - IconFrameSize, OptionHeight);
            OptionNameBackground.Location = new Point(IconFrameSize, 0);
            this.Controls.Add(OptionNameBackground);

            OptionNameValue = new Label();
            Console.WriteLine(Record[FieldName]);
            OptionNameValue.Text = Record[FieldName];
            OptionNameValue.Font = DefaultFonts.GetFont(23);
            OptionNameValue.ForeColor = ColorManagment.LightOptionsText;
            OptionNameValue.BackColor = ColorManagment.InvisibleBackGround;
            OptionNameValue.AutoSize = true;
            OptionNameValue.Location = new Point(20, 10);
            OptionNameBackground.Controls.Add(OptionNameValue);
        }
    }
}
