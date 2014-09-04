using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра
{
    // 4 - «Бомба»,
    public class Bomb : Cell
    {
        public Bomb()
        {
            ImgSource = Properties.Resources.bomb;
        }
        /// <summary>
        /// Создает изображение элемента игрового поля
        /// </summary>
        public override void CreateElement()
        {}

        /// <summary>
        /// Выделяет изображение элемента игрового поля
        /// </summary>
        public  override void SelectElement()
        {}
        
        public override bool Activation(int posX, int posY, Board myBoard)
        {
            int rand = 0;
            int lb = posX - 1, rb = posX + 1, tb = posY - 1, bb = posY + 1; // запоминаем координаты границ вокруг ячейки

            if (posX == 0) lb = posX; // корректируем границ, чтобы избежать выхода за границы поля
            if (posX == myBoard.Columns - 1) rb = posX;
            if (posY == 0) tb = posY;
            if (posY == myBoard.Rows - 1) bb = posY;

            for (int i = tb; i <= bb; i++) // проходим по всем ячейкам вокруг ячейки
                for (int j = lb; j <= rb; j++)
                {
                    myBoard.Score++; // увелииваем счетчик очков на 1
                    myBoard.Matrix[i, j] = myBoard.RandElement(ref rand); // заменяем на новый
                }
            return true;
        }
    }
}
