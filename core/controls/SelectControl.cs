using zxcforum.core.controls.buttons;
using zxcforum.core.interfaces;
using zxcforum.core.models;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using zxcforum.core.utils;
using System.Diagnostics;

namespace zxcforum.core.controls
{
    public partial class SelectControl: UserControl
    {
        public List<int> FieldSize { get; set;}
        public List<SelectOptionButton> OptionsButtons { get; set; } = new List<SelectOptionButton>();
        private Panel FieldPanel { get; set;}
        private Label FieldValueLabel { get; set; }
        private PictureBox MoreIcon { get; set; }
        private Panel DownBarPanel { get; set;} = new Panel();
        public int DownBarSizeY { get; set; }
        public int GapBetweenOptions { get; set; }
        public int GapBetweenIconAndFiled { get; set; } = 10;
        public Action<SelectControl> OnSelect { get; set; }
        public Action<int, bool> OnShowOrHide { get; set;}

        private SelectOptionButton _selectedOption;
        public SelectOptionButton SelectedOption
        {
            get
            {

                return _selectedOption;
            }
            set
            {
                if(_selectedOption != null)
                {
                    _selectedOption.IsSelected = false;
                }
                value.IsSelected = true;
                _selectedOption = value;
            }
        }
        public bool IsDownBarShowed { get; private set; }
        public SelectControl(List<int> size, List<SelectOption> options, int downBarSizeY = 100, int gapBetweenOptions = 7)
        {
            GapBetweenOptions = gapBetweenOptions;
            FieldSize = size;
            this.Size = new Size(FieldSize[0], FieldSize[1]);
            DownBarSizeY = downBarSizeY;
            InitAll();
            GenerateButtons(options);
        }
        public void AddClickMethod(Action<SelectControl> func)
        {
            OnSelect = func;
        }
        public void AddOnShowOrHideMethod(Action<int, bool> func)
        {
            OnShowOrHide = func;
        }

        public void ShowDownBar()
        {
            IsDownBarShowed = true;
            
            this.Size = new Size(FieldSize[0], FieldSize[1] + DownBarPanel.Height);
            DownBarPanel.Show();
            
        }
        public void HideDownBar()
        {
            IsDownBarShowed = false;
            this.Size = new Size(FieldSize[0], FieldSize[1]);
            DownBarPanel.Hide();
        }
        private void FieldClicked(object sender, EventArgs e)
        {
            
            if (IsDownBarShowed)
            {
                OnShowOrHide(this.DownBarPanel.Height, false);
                HideDownBar();
                Console.WriteLine("HIDE");
            }
            else
            {
                OnShowOrHide(this.DownBarPanel.Height, true);
                ShowDownBar();
                Console.WriteLine("SHOW");
            }
            
        }
        public void InitAll()
        {
            InitField();
            InitDownBar();
        }
        private void InitDownBar()
        {
            DownBarPanel.Size = new Size(FieldSize[0], DownBarSizeY);
            DownBarPanel.BackColor = ColorTranslator.FromHtml("#333550");
            DownBarPanel.AutoScroll = true;
            DownBarPanel.Location = new Point(0, FieldSize[1]);
            this.Controls.Add(DownBarPanel);
            DownBarPanel.Hide();
        }

        private void InitField()
        {
            FieldPanel = new Panel();
            FieldPanel.BackColor = ColorTranslator.FromHtml("#333550");
            FieldPanel.Size = new Size(FieldSize[0], FieldSize[1]);
            this.Controls.Add(FieldPanel);

            MoreIcon = new PictureBox();
            MoreIcon.Image = DefaultImages.GetDefaultImage("menu-burger.png");
            MoreIcon.Size = new Size(24, 24);
            MoreIcon.SizeMode = PictureBoxSizeMode.Zoom;
            MoreIcon.BackColor = ColorManagment.InvisibleBackGround;

            FieldValueLabel = new Label();
            FieldValueLabel.Font = DefaultFonts.GetKanitFont(22);
            FieldValueLabel.ForeColor = Color.White;
            FieldValueLabel.BackColor = ColorManagment.InvisibleBackGround;
            FieldValueLabel.Text = "Vali";
            FieldValueLabel.AutoSize = true;


            FieldPanel.Controls.Add(FieldValueLabel);
            FieldPanel.Controls.Add(MoreIcon);

            FieldPanel.Click += FieldClicked;
            MoreIcon.Click += FieldClicked;
            FieldValueLabel.Click += FieldClicked;
            RefreshField();
        }
        private void RefreshField()
        {
            FieldValueLabel.Location = new Point(FieldPanel.Width / 2 - FieldValueLabel.Width / 2 - GapBetweenIconAndFiled - MoreIcon.Width, FieldPanel.Height / 2- FieldValueLabel.Height / 2);
            MoreIcon.Location = new Point(FieldPanel.Width / 2 - MoreIcon.Width / 2 + FieldValueLabel.Width / 2 + GapBetweenIconAndFiled, FieldPanel.Height / 2 - FieldValueLabel.Height / 2);
        }

        private void AddOnItemSelectedMethod(Action<SelectOptionButton> func)
        {

        }

        private void ItemSelected(SelectOptionButton button)
        {
            SelectedOption = button;
            FieldValueLabel.Text = button.Option.ExternalText;
            Console.WriteLine("SELECTED");
            FieldClicked(null, null);

            if(OnSelect != null)
            {
                OnSelect(this);
            }
        }

        private void GenerateButtons(List<SelectOption> options)
        {
            int currentY = 0;
            foreach (SelectOption option in options)
            {
                Console.WriteLine(option.ExternalText);
                SelectOptionButton button = new SelectOptionButton(option);
                button.Size = new Size(FieldSize[0], 37);
                button.Font = DefaultFonts.GetKanitFont(17);
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                
                button.AddClickMethod(ItemSelected);

                OptionsButtons.Add(button);
                DownBarPanel.Controls.Add(button);
                button.Location = new Point(0, currentY);

                currentY += button.Height + GapBetweenOptions;
            }
        }

    }
}
