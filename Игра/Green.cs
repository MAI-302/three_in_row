using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 3 - «Базовый зеленый»,
    public class Green : Cell
    {
        public Green()
        {
            ImgSource = Properties.Resources.green;
        }

        public override void CreateElement()
        {
            ImgSource = Properties.Resources.green;
        }

        public override void SelectElement()
        {
            ImgSource = Properties.Resources.green_1;
        }
    }
}
