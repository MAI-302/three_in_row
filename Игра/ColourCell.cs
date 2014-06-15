using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Игра
{
 public abstract class ColourCell:Cell
    {
        
           new public  Image ImgSource; // Хранит изображение объекта

            public ColourCell() { }

            /// <summary>
            /// Создает изображение элемента игрового поля
            /// </summary>
            public override void CreateElement() {}

            /// <summary>
            /// Выделяет изображение элемента игрового поля
            /// </summary>
            public override  void SelectElement() {}
            /// <summary>
            /// Активация
            /// </summary>
           

    }
}
