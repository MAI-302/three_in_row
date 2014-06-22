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

            private readonly int width;
            private readonly int height;
            public int Width
            {
                get
                {
                    return width;
                }
            }
            public int Height
            {
                get
                {
                    return height;
                }
            }

            /// <summary>
            ///  Конструктор класса
            /// </summary>
            public Game(int Columns, int Rows)
            {
                newBoard = new Board(Columns, Rows);

                width = 296;
                height = 392;
            }

            /// <summary>
            ///  Запускает игровой процесс
            /// </summary>
            public void Initialization()
            {
                newBoard.Generate(); // генерируем случайную матрицу элементов игрового поля
            }
        }

    }


