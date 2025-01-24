using zxcforum.core.controls.buttons;
using zxcforum.core.interfaces;
using zxcforum.core.models.database;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using zxcforum.core.models;
using zxcforum.core.enums;

namespace zxcforum.core.controls
{
    public partial class AdminDefaultManagerPage<T> : UserControl where T: Table, ITable, new()
    {
        public void InitAll()
        {
            InitSelectPanel();
            InitButtons();
            InitSelectedPanel();
        }
        public void InitSelectedPanel()
        {
            SelectedPanel = new Panel();
            SelectedPanel.Size = new Size(771, 805);
            SelectedPanel.BackColor = ColorManagment.DefaultPanelColor;
            SelectedPanel.Location = new Point(900, 49);
            this.Controls.Add(SelectedPanel);
        }
        public void InitSelectPanel()
        {
            SelectPanel = new Panel();
            SelectPanel.Size = new Size(771, 805);
            SelectPanel.BackColor = ColorManagment.DefaultPanelColor;
            SelectPanel.Location = new Point(49, 49);
            this.Controls.Add(SelectPanel);

            OptionsPanel = new Panel();
            OptionsPanel.Size = new Size(771, 734);
            OptionsPanel.AutoScroll = true;
            OptionsPanel.BackColor = ColorManagment.DefaultPanelColor;
            SelectPanel.Controls.Add(OptionsPanel);

            AddPanel = new Panel();
            AddPanel.Size = new Size(771, 71);
            AddPanel.Location = new Point(0, OptionsPanel.Height);
            AddPanel.BackColor = ColorManagment.DarkerDefaultPanelColor;
            SelectPanel.Controls.Add(AddPanel);

            AddButton = new Button();
            AddButton.Size = new Size(47, 47);
            AddButton.BackgroundImage = DefaultImages.GetDefaultImage("plus-hexagon.png");
            AddButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddButton.BackColor = ColorManagment.InvisibleBackGround;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.Location = new Point(AddPanel.Width / 2 - AddButton.Width / 2, AddPanel.Height / 2 - AddButton.Height / 2);
            AddButton.Click += AddButton_clicked;
            AddPanel.Controls.Add(AddButton);

        }
        public void InitButtons()
        {
            Console.WriteLine($"init button");
            List<T> records = DBHandler.GetTableData<T>();
            int currentY = this.StartOptionPositionY;
            foreach(T record in records)
            {
                Console.WriteLine($"Table: {record.tableName}");
                foreach(string key in record.GetKeys())
                {
                    Console.WriteLine($"key: {key}, value: {record[key]}");
                }
                OptionButton<T> button = new OptionButton<T>(record, FieldName, OptionSize);
                button.Location = new Point(SelectPanel.Width / 2 - button.Width / 2, currentY);
                OptionsPanel.Controls.Add(button);
                button.AddClickMethod(Selected);
                Buttons.Add(button);
                currentY += button.Height + GapBetweenButtons;
            }
        }

        public void OnSelectSubmitted<V>(AdvancedOption<V> control, bool isItForAddPanel = false) where V : Table, ITable, new()
        {
            if(control.SelectControl.SelectedOption != null && !isItForAddPanel) DBHandler.UpdateRecord(SelectedButton.Record, control.Field, control.SelectControl.SelectedOption.Option.Value, new List<WhereField>() { new WhereField("id", control.CurrentRecord["id"]) });

        }
        private void ClearSelectedPanel()
        {
            foreach(Control control in SelectedPanel.Controls)
            {
                control.Dispose();
            }
            this.SelectedPanel.Controls.Clear();
        }
        private void GenerateSelect(string field, string tableName, out dynamic select, bool changeAvailable = true, bool isItForAddPanel = false)
        {
            List<SelectOption> options = new List<SelectOption>();
            Type type = TablesManagment.GetRecordType(tableName);
            var method = typeof(DBHandler).GetMethod("GetTableData");
            
            var genericMethod = method.MakeGenericMethod(type);
            object result = genericMethod.Invoke(null, null);

            if(result is IEnumerable<Table> tableList)
            {
                foreach (Table tableInstance in tableList)
                {
                    options.Add(new SelectOption(tableInstance["id"], tableInstance.OutValue));
                }
            }
            var advancedOptionType = typeof(AdvancedOption<>).MakeGenericType(type);
            select = Activator.CreateInstance(advancedOptionType, enums.AdvancedOptionType.Select, 0, field, null, null, null, null, options, changeAvailable, isItForAddPanel);
            var advMethod = advancedOptionType.GetMethod("AddMethodOnSubmitted");
            var actionType = typeof(Action<,>).MakeGenericType(advancedOptionType, typeof(bool));
            var action = Delegate.CreateDelegate(actionType, this, typeof(AdminDefaultManagerPage<T>).GetMethod(nameof(OnSelectSubmitted)).MakeGenericMethod(type));

            object advResult = advMethod.Invoke(select, new object[] { action, isItForAddPanel });
            
        }
        
        public void InitAddRecordPanel()
        {
            ClearSelectedPanel();
            InitDownOptionPanel();
            InitDownSelectedButton(isItForAddPanel: true);
            T table = new T();
            List<string> fields = table.GetKeys();
            int currentY = this.StartOptionPositionY;
            foreach(string field in fields)
            {
                if(field == "id") continue;
                List<string> response = DBHandler.CheckForForeign<T>(field);
                dynamic advancedOption;
                if(response.Count != 0) GenerateSelect(field, response[0], out advancedOption, changeAvailable:false, isItForAddPanel: true);
                else advancedOption = new AdvancedOption<T>(enums.AdvancedOptionType.TextBox, 0, field, changeAvailable: false, isItForAddPanel: true);

                advancedOption.Location = new Point(SelectedPanel.Width / 2 - advancedOption.Width / 2, currentY);
                this.SelectedPanel.Controls.Add(advancedOption);
                currentY += advancedOption.Height + this.GapBetweenButtons;
            }
        }
        public void InitRightPanel(bool isItForAddPanel = false)
        {
            SelectedInputsPanel = new Panel();
            SelectedInputsPanel.Size = new Size(771, 734);
            SelectedInputsPanel.AutoScroll = true;
            SelectedInputsPanel.BackColor = ColorManagment.DefaultPanelColor;
            SelectedPanel.Controls.Add(SelectedInputsPanel);

            InitDownOptionPanel();
            InitDownSelectedButton(isItForAddPanel);
            

        }
        public void InitDownOptionPanel()
        {
            DownOptionsPanel = new Panel();
            DownOptionsPanel.Size = new Size(771, 71);
            DownOptionsPanel.Location = new Point(0, OptionsPanel.Height);
            DownOptionsPanel.BackColor = ColorManagment.DarkerDefaultPanelColor;
            SelectedPanel.Controls.Add(DownOptionsPanel);

        }
        public void InitDownSelectedButton(bool isItForAddPanel = false)
        {
            DownSelectedPanelButton = new Button();
            DownSelectedPanelButton.Size = new Size(47, 47);
            DownSelectedPanelButton.BackgroundImage = DefaultImages.GetDefaultImage(!isItForAddPanel ? "trash.png" : "plus-hexagon.png");
            DownSelectedPanelButton.BackgroundImageLayout = ImageLayout.Zoom;
            DownSelectedPanelButton.BackColor = ColorManagment.InvisibleBackGround;
            DownSelectedPanelButton.FlatStyle = FlatStyle.Flat;
            DownSelectedPanelButton.FlatAppearance.BorderSize = 0;
            DownSelectedPanelButton.Location = new Point(DownOptionsPanel.Width / 2 - DownSelectedPanelButton.Width / 2, DownOptionsPanel.Height / 2 - DownSelectedPanelButton.Height / 2);
            if(isItForAddPanel) DownSelectedPanelButton.Click += AddRecord_clicked;
            DownOptionsPanel.Controls.Add(DownSelectedPanelButton);
        }
        public void DeleteButton_clicked(object sender, EventArgs e)
        {
            DBHandler.DeleteRecord<T>(int.Parse(SelectedButton.Record["id"]));
            ReDraw();
        }
        public void AddButton_clicked(object sender, EventArgs e)
        {
            if(SelectedButton != null) SelectedButton.IsActive = false;
            ClearSelectedPanel();
            
            InitAddRecordPanel();
        }
        public void AddRecord_clicked(object sender, EventArgs e)
        {
            T record = new T();
            foreach(Control control in SelectedPanel.Controls)
            {
                if(control is IAdvanced adv)
                {
                    if(adv.CurrentValue != "" && adv.CurrentValue != null) record[adv.Field] = adv.CurrentValue;
                    else
                    {
                        MessageBox.Show("Error", "There is empty boxes");
                        return;
                    }
                }
            }

            DBHandler.AddRecord<T>(record);
            ReDraw();
        }
        public void GenerateField(string fieldName)
        {
            Panel FieldInput = new Panel();
        }
        public void InitAdvancedOptions(PanelType type)
        {
            ClearSelectedPanel();
            InitRightPanel();
            List<string> fields;
            DownSelectedPanelButton.Image =  DefaultImages.GetDefaultImage(type == PanelType.Add ? "check.png" : "trash.png");
            fields = type == PanelType.Add ? new T().GetKeys() : SelectedButton.Record.GetKeys();
            if(type == PanelType.Add) DownSelectedPanelButton.Click += AddButton_clicked;
            else DownSelectedPanelButton.Click += DeleteButton_clicked;
            
            int currentY = this.StartOptionPositionY;
            foreach(string field in fields)
            {
                if(field == "id") continue;
                List<string> response = DBHandler.CheckForForeign<T>(field);
                dynamic advancedOption;
                if(response.Count != 0) GenerateSelect(field, response[0], out advancedOption);
                else advancedOption = new AdvancedOption<T>(enums.AdvancedOptionType.TextBox, int.Parse(SelectedButton.Record["id"]), field, changeAvailable:type == PanelType.Add);
                SelectedInputsPanel.Controls.Add(advancedOption);
                advancedOption.Location = new Point(SelectedPanel.Width / 2 - advancedOption.Width / 2, currentY);
                currentY += advancedOption.Height + this.GapBetweenButtons;
            }
            
        }
    }
}
