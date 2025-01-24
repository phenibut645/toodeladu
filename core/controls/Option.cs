using zxcforum.core.enums;
using zxcforum.core.models.database;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.context;
using zxcforum.core.interfaces;
namespace zxcforum.core.controls
{
    public partial class Option<T> : UserControl where T: Table, ITable, new()
    {
        public OptionType Type { get; set; }
        public Label OptionName { get; set; }
        public Label OptionValue { get; set; }
        public TextBox OptionValueTextBox { get; set; }
        public ChangeButton Button { get; set; }
        public int OptHeight { get; set;}
        public int OptWidth { get; set;}
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public T Record { get; set; }
        public Option(T record, string field, OptionType type, string optionName, int height = 48, int width = 160)
        {
            this.Type = type;
            OptHeight = height;
            OptWidth = width;
            Record = record;
            FieldName = field;

            OptionName = new Label();
            OptionName.Text = optionName;
            OptionName.BackColor = ColorManagment.OptionField;
            OptionName.ForeColor = ColorManagment.MovieCardHeader;
            OptionName.Font = utils.DefaultFonts.GetFont(22);
            OptionName.Size = new Size(width, height);
            OptionName.Location = new Point(0, 0);
            OptionName.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(OptionName);
            Console.WriteLine("first field");

            OptionValue = new Label();
            if(field == "roll")
            {
                Console.WriteLine($"role = {RolesManagment.GetRole(int.Parse(record[field])).ToString()}");
                OptionValue.Text = RolesManagment.GetRole(int.Parse(record[field])).ToString();
            }
            else OptionValue.Text = record[field];
            
            OptionValue.BackColor = ColorManagment.OptionValueField;
            OptionValue.ForeColor = Color.White;
            OptionValue.Font = utils.DefaultFonts.GetFont(22);
            OptionValue.Size = new Size(width, height);
            OptionValue.ForeColor = Color.White;
            OptionValue.Location = new Point(OptionName.Width, 0);
            OptionValue.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(OptionValue);
            Console.WriteLine($"{OptionName.Width}, 0");

            Button = new ChangeButton(type);
            Button.AddClick(changeButton_click);
            Button.Location = new Point(OptionValue.Width + OptionName.Width, 0);
            this.Controls.Add(Button);

            this.Size = new Size(OptionName.Size.Width + OptionValue.Size.Width + Button.Width, height);
            
        }
        public void changeButton_click(object sender, EventArgs e)
        {
            if (Button.Available)
            {
                if (!Button.InChange)
                {
                    Button.InChange = true;
                    InitTextBox();
                }
                else
                {
                    Button.InChange = false;
                    if(Type == OptionType.Number && !double.TryParse(OptionValueTextBox.Text, out _))
                    {
                        MessageBox.Show($"The {OptionName.Text} textbox must contain only a number.", "Error");
                        return;
                    }
                    OptionValue.Text = OptionValueTextBox.Text;
                    Changed();
                    T record = DBHandler.GetRecord<T>(new List<models.WhereField>() { new models.WhereField("id", Record["id"].ToString())});
                    DBHandler.UpdateRecord(Record, FieldName, OptionValueTextBox.Text, new List<models.WhereField>() { new models.WhereField("id", Record["id"].ToString()) });
                }
            }
        }
        public void Changed()
        {
            OptionValueTextBox.Hide();
            OptionValue.Show();
        }
        public void InitTextBox()
        {
            OptionValueTextBox = new TextBox();
            OptionValueTextBox.AutoSize =false;
            OptionValueTextBox.BackColor = ColorManagment.InputColors;
            OptionValueTextBox.Font = DefaultFonts.GetFont(22);
            OptionValueTextBox.ForeColor = Color.White;
            OptionValueTextBox.ClientSize = new Size(OptWidth, OptHeight);
            OptionValueTextBox.Location = new Point(OptionValue.Location.X, OptionValue.Location.Y);
            OptionValueTextBox.Text = OptionValue.Text;
            OptionValueTextBox.MaximumSize = new Size(OptWidth, OptHeight);
            OptionValueTextBox.BorderStyle = BorderStyle.None;
   
            OptionValueTextBox.TextAlign = HorizontalAlignment.Center;

            OptionValue.Hide();
            this.Controls.Add(OptionValueTextBox);
        }
    }
}
