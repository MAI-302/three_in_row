using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 0 - «Базовый», 
    public class Basic : Cell
    {
        public Basic(int op)
        {
            ObjectType = op;
            switch (ObjectType)
            {
                case 0: ImgSource = Properties.Resources.yellow; break;
                case 1: ImgSource = Properties.Resources.red; break;
                case 2: ImgSource = Properties.Resources.blue; break;
                case 3: ImgSource = Properties.Resources.green; break;
            }
        }

        public override void CreateElement()
        {
            switch (ObjectType)
            {
                case 0: ImgSource = Properties.Resources.yellow; break;
                case 1: ImgSource = Properties.Resources.red; break;
                case 2: ImgSource = Properties.Resources.blue; break;
                case 3: ImgSource = Properties.Resources.green; break;
            }
        }

        public override void SelectElement()
        {
            switch (ObjectType)
            {
                case 0: ImgSource = Properties.Resources.yellow_1; break;
                case 1: ImgSource = Properties.Resources.red_1; break;
                case 2: ImgSource = Properties.Resources.blue_1; break;
                case 3: ImgSource = Properties.Resources.green_1; break;
            }
        }
    }
}
