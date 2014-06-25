using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Игра
{
    /// <summary>
    /// Класс Cell - ячейка
    /// </summary>
    abstract public class Cell
    {
        public Image ImgSource; // Хранит изображение объекта

        public Cell() { }

        /// <summary>
        /// Создает изображение элемента игрового поля
        /// </summary>
        public abstract void DeselectElement();


        /// <summary>
        /// Выделяет изображение элемента игрового поля
        /// </summary>
        public abstract void SelectElement();


        /// <summary>
        /// Активация
        /// </summary>
        public virtual bool Activation(int posX, int posY, Board myBoard) { return false; }
    }
}

