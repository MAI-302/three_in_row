using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 6 - «Молния»
    public class Zip : Cell
    {
        public Zip()
        {
            ImgSource = Properties.Resources.zip;
        }
        /// <summary>
        /// Создает изображение элемента игрового поля
        /// </summary>
        public  override void CreateElement() { }

        /// <summary>
        /// Выделяет изображение элемента игрового поля
        /// </summary>
        public  override void SelectElement() { }

        public override bool Activation(int posX, int posY, Board myBoard)
        {
            myBoard.Generate(); // генерируем новое игровое поле
            return true;
        }
    }
}
