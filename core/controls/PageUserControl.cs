
using zxcforum.core.presets;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.core.controls
{
    public partial class PageUserControl : UserControl
    {
        public bool IsInited { get; set;} = false;
        public List<List<int>> RandomImagesCoordinates = new List<List<int>>()
        { 
            new List<int>(){170, 170, 40},
            new List<int>(){116, 768, 35},
            new List<int>(){3, 556, 30},
            new List<int>(){1514, 115, 38},
            new List<int>(){1375, 633, 42},
            new List<int>(){547, 139, 29}
        };
        public PageUserControl()
        {
            this.Size = new Size(DefaultScales.PageWidth, DefaultScales.PageHeight);
            this.Location = new Point(0, 77); 
        }
        public void SetRandomImages()
        {
            List<Image> images = DefaultImages.GetRandomBackgroundImages(RandomImagesCoordinates.Count);
            int index = -1;
            foreach(Image image in images)
            {
                index++;
                Label pb = new Label();
                pb.Size = new Size(RandomImagesCoordinates[index][2], RandomImagesCoordinates[index][2]);
                pb.Location = new Point(RandomImagesCoordinates[index][0], RandomImagesCoordinates[index][1]);
                pb.BackgroundImage = image;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(pb);
            }
        }
        public virtual void Clear()
        {
            Console.WriteLine("Clearing...");
            foreach(Control control in this.Controls)
            {
                control.Dispose();
            }
            this.Controls.Clear();
            IsInited = false;
        }

        public virtual void InitAll()
        {
            Console.WriteLine("Initing...");
            if (IsInited) throw new Exception("This Page is already inited");
            IsInited = true;
        }
    }
}
