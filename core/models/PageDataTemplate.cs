using zxcforum.core.controls;
using zxcforum.core.enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models
{
    public class PageDataTemplate
    {
        public string ButtonName { get; set; }
        public PageUserControl Page { get; set; }
        public List<Rolls> Role { get; set; }
        public HeaderButtonType Type { get; set; }
        public Image Icon { get; set; }
        public PageDataTemplate(PageUserControl page, List<Rolls> roles, HeaderButtonType type, string buttonName = null, Image icon = null)
        {
            ButtonName = buttonName;
            Page = page;
            Role = roles;
            Type = type;
            Icon = icon;
        }
    }
}
