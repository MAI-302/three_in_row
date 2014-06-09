using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 2 - «Базовый синий»,
    public class Blue : Cell
    {
        public Blue()
        {
            ImgSource = Properties.Resources.blue;
        }

        public override void CreateElement()
        {
            ImgSource = Properties.Resources.blue;
        }

        public override void SelectElement()
        {
            ImgSource = Properties.Resources.blue_1;
        }
    }

}
