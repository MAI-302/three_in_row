using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 5 - «Радужный квадрат», 
    public class Rainbow : Cell
    {
        public Rainbow()
        {
            ImgSource = Properties.Resources.rainbow;
        }
        /// <summary>
        /// Создает изображение элемента игрового поля
        /// </summary>
        public override void DeselectElement()
        { }

        /// <summary>
        /// Выделяет изображение элемента игрового поля
        /// </summary>
        public override void SelectElement()
        { }
    }

}
