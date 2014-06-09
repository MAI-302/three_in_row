using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 0 - «Базовый желтый», 
    public class Yellow : Cell
    {
        public Yellow()
        {
            ImgSource = Properties.Resources.yellow;
        }

        public override void CreateElement()
        {
            ImgSource = Properties.Resources.yellow;
        }

        public override void SelectElement()
        {
            ImgSource = Properties.Resources.yellow_1;
        }
    }
}
