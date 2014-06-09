using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Игра
    {
        /// <summary>
        ///  Класс Game - запускает игру
        /// </summary>
        public class Game
        {
            // параметр - Игровое поле
            public Board newBoard;

            /// <summary>
            ///  Запускает игровой процесс
            /// </summary>
            public void Initialization()
            {
                newBoard = new Board(); // создаем новое игровое поле (объект класса Board)

                newBoard.SizeN = 10; // размеры игрового поля кол-во строк
                newBoard.SizeM = 8; // кол-во столбцов

                newBoard.Generate(); // генерируем случайную матрицу элементов игрового поля
            }
        }

    }


