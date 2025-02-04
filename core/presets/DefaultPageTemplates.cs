using zxcforum.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.forms.main.pages;
using zxcforum.core.enums;
using zxcforum.core.controls;
using zxcforum.core.utils;
using zxcforum.core.context;
namespace zxcforum.core.presets
{
    public static class DefaultPageTemplates
    {
        public static List<PageDataTemplate> Templates { get; set; } = new List<PageDataTemplate>()
        { 
            new PageDataTemplate(new Shop(), new List<Rolls>(){Rolls.User, Rolls.Guest, Rolls.Admin }, HeaderButtonType.Default, buttonName: "Shop", icon:DefaultImages.GetHomeIcon()),
            new PageDataTemplate(new Kasutajad(), new List<Rolls>(){Rolls.Admin}, HeaderButtonType.Default, buttonName:"Kasutajad", icon:DefaultImages.GetUsersIcon()),
            new PageDataTemplate(new TaidisPage(), new List<Rolls>(){Rolls.Admin}, HeaderButtonType.Default, buttonName:"Taidis", icon:DefaultImages.GetSessionIcon()),
            new PageDataTemplate(new ToodePage(), new List<Rolls>(){Rolls.Admin}, HeaderButtonType.Default, buttonName:"Toode", icon:DefaultImages.GetTicketsIcon()),
            new PageDataTemplate(new Korv(), new List<Rolls>(){Rolls.User, Rolls.Admin}, HeaderButtonType.Default, buttonName:"Korv", icon:DefaultImages.GetTicketsIcon()),
            new PageDataTemplate(new LaduPage(), new List<Rolls>() { Rolls.Admin }, HeaderButtonType.Default, buttonName:"Laod", icon:DefaultImages.GetGenreIcon()),
            new PageDataTemplate(new More(), new List<Rolls>() { Rolls.Admin, Rolls.User, Rolls.Guest }, HeaderButtonType.More),
            new PageDataTemplate(new Profile(), new List<Rolls>() { Rolls.Admin, Rolls.User }, HeaderButtonType.Profile)

        };

        public static PageDataTemplate ProfileTemplate
        {
            get
            {
                foreach(PageDataTemplate pdt in Templates) if(pdt.Type == HeaderButtonType.Profile) return pdt;
                return null;
            }
        }
        public static PageDataTemplate MoreTemplate
        {
            get
            {
                foreach(PageDataTemplate pdt in Templates) if(pdt.Type == HeaderButtonType.More) return pdt;
                return null;
            }
        }
        public static HeaderButton GetButton(PageDataTemplate pdt)
        {
            Console.WriteLine($"GetButton, {pdt.Page}");
            return new HeaderButton(pdt);
        }
        public static List<PageDataTemplate> GetTemplates(Rolls role)
        {
            List<PageDataTemplate> returnList = new List<PageDataTemplate>();
            foreach(PageDataTemplate template in Templates) if(template.Role.Contains(role)) returnList.Add(template);
            return returnList;
        }
        public static List<HeaderButton> GetButtons(Rolls role, bool temp = false)
        {
            List<HeaderButton> returnList = new List<HeaderButton>();
            foreach(PageDataTemplate template in Templates)
            {
                if(template.Role.Contains(role) && template.Type == HeaderButtonType.Default)
                {
                    HeaderButton button = GetButton(template);
                    if(temp) button.Temp = true;
                    returnList.Add(button);
                }
            }
            return returnList;
        }
    }
}
