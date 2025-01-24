using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using zxcforum.core.utils;
using zxcforum.core.models;
using zxcforum.core.models.database;
using zxcforum.core.interfaces;
using zxcforum.core.enums;
using zxcforum.core.controls.buttons;

namespace zxcforum.core.controls
{
    public partial class AdvancedOption<T>: UserControl, IAdvanced where T: Table, ITable, new()
    {
        private Panel FieldPanel { get; set; }
        private Panel ValuePanel { get; set; }
        private Panel ButtonPanel { get; set; }
        private Label FieldLabel { get; set; } = new Label();
        private Label ValueLabel { get; set; } = new Label();
        private TextBox ValueTextBox { get; set; } = null;
        public SelectControl SelectControl { get; set; } = null;
        private Button Button { get; set; }
        public List<int> OptionSize { get; set;} = new List<int>() { 681, 48 };
        public List<int> FieldSize { get; set; } = new List<int>() { 191, 48};
        public List<int> ValueSize { get; set; } = new List<int>() { 442, 48};
        public List<int> ButtonSize { get; set; } = new List<int>() { 48, 48 };
        public Action<AdvancedOption<T>, bool> OnSubmit { get; set; } = null;
        bool IsItForAddPanel { get; set; } = false;

        private bool _inChanging;
        public bool InChanging
        {
            get
            {
                return _inChanging;
            }
            private set
            {
                if(_inChanging != value) _inChanging = value;
                StatusChanged();
            }
        }
        public int RecordId { get; set; }

        public string Field
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
                FieldLabel.Text = _fieldName;
            }
        }
        
        public string CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                Console.WriteLine($"izatakix tipov kak ja net smisla ot aborta {(ValueTextBox != null ? ( ValueTextBox.Text != null ? ValueTextBox.Text : "null") : "full null")}");
                _currentValue = value;
                ValueLabel.Text = _currentValue;
            }
        }

        public T CurrentRecord { get; set; }
        public AdvancedOptionType Type { get; set; }

        private string _fieldName;
        private string _currentValue;

        public AdvancedOption(AdvancedOptionType type, int recordId, string fieldName, List<int> size = null , List<int> fieldSize = null, List<int> valueSize = null, List<int> buttonSize = null, List<SelectOption> options = null, bool changeAvailable = true, bool isItForAddPanel = false)
        {
            if(size != null) OptionSize = size;
            if(fieldSize != null) FieldSize = fieldSize;
            if(valueSize != null) ValueSize = valueSize;
            if(buttonSize != null) ButtonSize = buttonSize;
            Type = type;
            IsItForAddPanel = isItForAddPanel;
            this.Size = new Size(OptionSize[0], OptionSize[1]);
            if(!isItForAddPanel) RecordId = recordId;
            Field = fieldName;
            if(!isItForAddPanel) CurrentRecord = DBHandler.GetRecord<T>(new List<WhereField>() { new WhereField("id", RecordId.ToString()) });
            if(!isItForAddPanel) CurrentValue = CurrentRecord[fieldName];
            else CurrentValue = "";
   
            InitAll();
            if(type == AdvancedOptionType.Select)
            {
                SelectControl = new SelectControl(ValueSize, options);
                InitSelect();
            }
            else if(type == AdvancedOptionType.TextBox)
            {
                InitTextBox();
            }
 
            InChanging = false;
        }
        public void AddMethodOnSubmitted(Action<AdvancedOption<T>, bool> func, bool isItForAddPanel = false)
        {
            this.OnSubmit = func;
            this.IsItForAddPanel = isItForAddPanel;
        }
        private void Submitted()
        {
            if(OnSubmit != null) OnSubmit(this, IsItForAddPanel);
            else
            {
                Console.WriteLine("submitted");
                if(!IsItForAddPanel) DBHandler.UpdateRecord(this.CurrentRecord, this.Field, this.CurrentValue, new List<WhereField>() { new WhereField("id", this.CurrentRecord["id"].ToString())});
                Console.WriteLine("submitted");
            }
        }
        private void clicked(object sender, EventArgs e)
        {
            Console.WriteLine("clicked");
            if (InChanging)
            {
                if(Type == AdvancedOptionType.TextBox)
                {
                    ValueTextBox.Hide();
                    CurrentValue = ValueTextBox.Text;
                    ValueLabel.Show();
                }
                else if(Type == AdvancedOptionType.Select)
                {
                    SelectControl.Hide();
                    SelectControl.HideDownBar();

                    CurrentValue = SelectControl.SelectedOption.Option.Value;
                    ValueLabel.Show();
                    
                }
                Submitted();
            }
            else
            {
                if(Type == AdvancedOptionType.TextBox)
                {
                    Console.WriteLine($"Showing {ValueTextBox.Location.X} {ValueTextBox.Location.Y}");
                    ValueTextBox.Show();
                    ValueTextBox.Text = ValueLabel.Text;
                    ValueLabel.Hide();
                }
                else if(Type == AdvancedOptionType.Select)
                {
                    SelectControl.Show();
                    ValueLabel.Hide();
                }
            }
            InChanging = !InChanging;
            //DBHandler.UpdateRecord<T>(CurrentRecord, FieldName, )
        }
        public void StatusChanged()
        {
            if (InChanging)
            {
                Button.BackgroundImage = DefaultImages.GetDefaultImage("check.png");

            }
            else
            {
                Button.BackgroundImage = DefaultImages.GetDefaultImage("edit.png");
            }
        }
        public void InitAll()
        {
            InitField();
            InitValue();
            InitButton();
        }
        public void InitField()
        {
            FieldPanel = new Panel();
            FieldPanel.BackColor = ColorManagment.IconBackgroundPurple;
            FieldPanel.ClientSize = new Size(FieldSize[0], FieldSize[1]);
            this.Controls.Add(FieldPanel);

            FieldLabel = new Label();
            FieldLabel.BackColor = ColorManagment.InvisibleBackGround;
            FieldLabel.Font = DefaultFonts.GetFont(22);
            FieldLabel.ForeColor = ColorManagment.LightOptionsText;
            FieldLabel.Text = Field;
            FieldLabel.Size = new Size(FieldPanel.Width, FieldSize[1]);
            FieldLabel.TextAlign = ContentAlignment.MiddleLeft;
            FieldLabel.Location = new Point(0, 0);
            this.FieldPanel.Controls.Add(FieldLabel);
        }
        public void InitValue()
        {
            ValuePanel = new Panel();
            ValuePanel.BackColor = ColorManagment.OptionValueBackground;
            ValuePanel.Size = new Size(ValueSize[0], ValueSize[1]);
            ValuePanel.Location = new Point(FieldSize[0], 0);
            this.Controls.Add(ValuePanel);

            ValueLabel.Font = DefaultFonts.GetKanitFont(19);
            ValueLabel.BackColor = ColorManagment.InvisibleBackGround;
            ValueLabel.ForeColor = Color.White; //X
            ValueLabel.Size = new Size(ValuePanel.Width, ValuePanel.Height);
            ValuePanel.Controls.Add(ValueLabel);
            ValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            ValueLabel.Location = new Point(0, 0);
        }
        public void InitTextBox()
        {
            ValueTextBox = new TextBox();
            ValueTextBox.AutoSize =false;
            ValueTextBox.BackColor = ColorManagment.InputColors;
            ValueTextBox.Font = DefaultFonts.GetFont(22);
            ValueTextBox.ForeColor = Color.White;
            ValueTextBox.ClientSize = new Size( ValuePanel.Width, ValuePanel.Height);
            ValueTextBox.Location = new Point(0, 0);
            ValueTextBox.Text = ValueLabel.Text;
            ValueTextBox.BorderStyle = BorderStyle.None;
            ValueTextBox.TextAlign = HorizontalAlignment.Center;
            ValueTextBox.Hide();
            ValuePanel.Controls.Add(ValueTextBox);
        }
        public void ItemSelected(SelectControl button)
        {
            CurrentValue = button.SelectedOption.Option.ExternalText;
        }
        public void InitSelect()
        {
            SelectControl.Location = new Point(0, 0);
            SelectControl.Hide();
            ValuePanel.Controls.Add(SelectControl);
            SelectControl.AddOnShowOrHideMethod(ShowOrHide);
            SelectControl.AddClickMethod(ItemSelected);
        }
        public void ShowOrHide(int value, bool show)
        {
            if (show)
            {
                this.Size = new Size(OptionSize[0], OptionSize[1] + value);
                ValuePanel.Size = new Size(ValueSize[0], OptionSize[1] + value);
                Console.WriteLine("RESIZE");
            }
            else
            {
                this.Size = new Size(OptionSize[0], OptionSize[1]);
            }
            
        }
        public void InitButton()
        {
            ButtonPanel = new Panel();
            ButtonPanel.Size = new Size(ButtonSize[0], ButtonSize[1]);
            ButtonPanel.BackColor = ColorManagment.IconBackgroundPurple;
            ButtonPanel.Location = new Point(FieldSize[0] + ValueSize[0], 0);

            this.Controls.Add(ButtonPanel);

            Button = new Button();
            Button.Size = new Size(ButtonSize[0] - 20, ButtonSize[0] - 20);
            Button.BackgroundImageLayout = ImageLayout.Zoom;
            Button.FlatStyle = FlatStyle.Flat;
            Button.BackColor = ColorManagment.InvisibleBackGround;
            Button.FlatAppearance.BorderSize = 0;
            Button.Click += clicked;
            this.Click += clicked;
            
            Button.FlatAppearance.MouseDownBackColor = ColorManagment.InvisibleBackGround;
            Button.FlatAppearance.MouseOverBackColor = ColorManagment.InvisibleBackGround;
            this.ButtonPanel.Controls.Add(Button);
            this.Button.Location = new Point(ButtonPanel.Width / 2 - Button.Width / 2, ButtonPanel.Height / 2 - Button.Height / 2);
        }
    }
}
