using zxcforum.core.enums;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.presets;
using zxcforum.core.models;
using zxcforum.forms.main.pages;
using zxcforum.core.context;
namespace zxcforum.core.controls
{
    public class HeaderButton: UserControl
    {
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

        public PictureBox Icon { get; set; } = null;
        public Label Name { get; set; } = new Label();
        public Label IconLine { get; set; }
        public PageUserControl Page { get; set; } = null;
        public HeaderButtonType Type { get; set; }
        public List<Rolls> RolesRequired { get; set; }
        public PageDataTemplate PageDataTemplate { get; set; }
        public bool Temp { get; set; }
        public MouseEventHandler func { get; set; }
        public HeaderButton(PageUserControl page, HeaderButtonType type,  List<Rolls> rollsRequired, PageDataTemplate pageDataTemplate = null, string text = null, bool isActive = false, Image image = null) 
        {
            RolesRequired = rollsRequired;
            PageDataTemplate = pageDataTemplate;
            InitUserControl();
            Type = type;
            Page = page;
            
            if(type == HeaderButtonType.Default && text != null)
            {
                InitLabel();
                Name.Text = text;
            }
            if(image != null)
            {
                InitIcon();
                Icon.Image = image;
            }
            SetButton();
            IsActive = isActive;
        }
        public HeaderButton(PageDataTemplate pageDataTemplate, bool isActive = false)
        {
            InitUserControl();
            RolesRequired = pageDataTemplate.Role;
            PageDataTemplate = pageDataTemplate;
            Type = pageDataTemplate.Type;
            Page = pageDataTemplate.Page;
            if(Type == HeaderButtonType.Default && PageDataTemplate.ButtonName != null)
            {
                InitLabel();
                Name.Text = PageDataTemplate.ButtonName;
            }
            if(PageDataTemplate.Icon != null)
            {
                InitIcon();
                Icon.Image = PageDataTemplate.Icon;
            }
            SetButton();
            IsActive = isActive;

        }
        public void AddMethodOnClick(MouseEventHandler method)
        {
            this.MouseDown += button_Click;
            foreach(Control control in this.Controls)
            {
                control.MouseDown += button_Click;
            }
            func = method;

        }
        public void button_Click(object sender, MouseEventArgs e)
        {
            func.Invoke(this, e);
        }

        public void Delete()
        {
            if(this.Page != null)
            {
                this.Page.Clear();
            }
            this.Dispose();
        }

        public void SetButton()
        {
            if(Type == HeaderButtonType.Default && Icon != null)
            {
                InitIconLine();
                Console.WriteLine("ICON ISN'T NULL, BITHES");
                this.Size = new Size(DefaultScales.DefaultHeaderButtonWidth, DefaultScales.DefaultHeaderButtonHeight);

                Icon.Location = new Point(DefaultScales.HeaderButtonIconSpace / 2 - Icon.Width / 2, this.Height / 2 - Icon.Height / 2);
                IconLine.Location = new Point(DefaultScales.HeaderButtonIconSpace - IconLine.Width, 0);

                Name.Location = new Point(((Width - DefaultScales.HeaderButtonIconSpace) / 2 - Name.Width / 2) + DefaultScales.HeaderButtonIconSpace, Height / 2 - (int)Math.Round((double)( Name.Height / 2 ) * 1));
            }
            else if(Type == HeaderButtonType.More)
            {
                InitIcon();
                this.Size = new Size(DefaultScales.MoreHeaderButtonWidth, DefaultScales.MoreHeaderButtonHeight);
                this.Icon.Image = DefaultImages.GetMoreIcon();
                Icon.Location = new Point(Width / 2 - Icon.Width / 2, Height / 2 - Icon.Height / 2);
            }
            else if(Type == HeaderButtonType.Profile)
            {
                InitIcon();
                
                this.Size = new Size(DefaultScales.MoreHeaderButtonWidth, DefaultScales.MoreHeaderButtonHeight);
                Icon.Size = new Size(50, 50);
                Icon.Location = new Point(Width / 2 - Icon.Width / 2, Height / 2 - Icon.Height / 2);
                
                if (FormAppContext.CurrentUser != null) Icon.Image = DefaultImages.GetAvatar(FormAppContext.CurrentUser);
                else Icon.Image = DefaultImages.GetDefaultImage("profile.png");
                Page = new Profile();
            }
        }
        public void InitUserControl()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.BackColor = ColorManagment.ActiveButton;
        }
        public void InitLabel()
        {
            Name = new Label();
            Name.Font = DefaultFonts.GetFont(24);
            Name.BackColor = ColorManagment.InvisibleBackGround;
            Name.ForeColor = Color.White;
            Name.AutoSize = true;
            this.Controls.Add(Name);
        }
        public void InitIcon()
        {

            Icon = new PictureBox();
            Icon.Size = new Size(25, 25);
            Icon.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(Icon);
        }
        public void InitIconLine()
        {
            IconLine = new Label();
            IconLine.Size = new Size(DefaultScales.HeaderButtonLineThickness, Height);
            IconLine.BackColor = Color.White;
            this.Controls.Add(IconLine);
        }
        private void ChangeActiveStatus()
        {
            if (IsActive)
            {
                this.BackColor = ColorManagment.ActiveButton;
                Name.ForeColor = Color.White;
            }
            else
            {
                Console.WriteLine($"Switch off the {this.Name.Text} button");
                this.BackColor = ColorManagment.UnActiveButton;
                Name.ForeColor = ColorManagment.UnActiveButtonFontColor;
            }
        }
         public void ChangeActiveStatusAuto()
        {
            IsActive = !IsActive;
        }
    }
}
