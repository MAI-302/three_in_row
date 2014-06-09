using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 1 - «Базовый красный»,
    public class Red : Cell
    {
        public Red()
        {
            ImgSource = Properties.Resources.red;
        }

        public override void CreateElement()
        {
            ImgSource = Properties.Resources.red;
        }

        public override void SelectElement()
        {
            ImgSource = Properties.Resources.red_1;
        }
    }
}
