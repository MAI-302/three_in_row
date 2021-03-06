﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игра
{
    /// <summary>
    ///  Класс Board - создает игровое поле
    /// </summary>
    public class Board
    {
        private readonly int Count_Columns; // Кол-во столбцов игрового поля
        private readonly int Count_Rows; // Кол-во строк игрового поля
        private readonly int Cell_Height;
        private readonly int Cell_Width;
        public int Columns
        {
            get
            {
                return Count_Columns;
            }
        }
        public int Rows
        {
            get
            {
                return Count_Rows;
            }
        }
        public int Width
        {
            get
            {
                return Cell_Width * Columns;
            }
        }
        public int Height
        {
            get
            {
                return Cell_Height * Rows;
            }
        }

        public Cell[,] Matrix; // Матрица объектов класса Cell
        public int Score; // Количество набранных очков

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Columns"></param>
        /// <param name="Rows"></param>
        public Board(int Rows, int Columns, int Width, int Height)
        {
            this.Count_Rows = Rows;
            this.Count_Columns = Columns;
            this.Cell_Width = Width;
            this.Cell_Height = Height;
        }

        /// <summary>
        ///  Генерирует элементы игрового поля
        /// </summary>
        public void Generate()
        {
            int rand = 0;
            Matrix = new Cell[Rows, Columns]; // создает матрицу размером SizeN x SizeM из объектов класса Cell
            for (int i = 0; i < Rows; i++) // заполняем матрицу объектами класса Cell
                for (int j = 0; j < Columns; j++)
                {
                    Matrix[i, j] = RandElement(); // ячейке матрицы присваиваем случайный объект класса Cell
                }
        }

        /// <summary>
        ///  Рисует игровое поле
        /// </summary>
        /// <param name="e">Событие - рисование</param>
        public void Draw(PaintEventArgs e)
        {
            for (int i = 0; i < this.Rows; i++) // рисуем на форме объекты матрицы 
                for (int j = 0; j < this.Columns; j++)
                    e.Graphics.DrawImage(this.Matrix[i, j].ImgSource, j * Cell_Width, i * Cell_Height); // рисуем на форме рисунок элемента
        }

        /// <summary>
        /// Подсчитывает количество набранных очков
        /// </summary>
        public void Scoring()
        {
            int k = 1; // счетчик доп. ячеек
            int rand = 0;

            int StScore = Score; // запоминает текущее кол-во очков

            for (int i = 0; i < Rows; i++) // подсчет очков по горизонтали
            {
                for (int j = 1; j < Columns - 1; j++) // от первого до предпоследнего, т.к. у них нет соседа слева (справа)
                {
                    // проверяет соседей справа и слева от текущ. ячейки на одинаковость (или на радужный квадрат)
                    if (((Matrix[i, j - 1].ObjectType == Matrix[i, j].ObjectType) || (Matrix[i, j - 1] is Rainbow))
                        && ((Matrix[i, j + 1].ObjectType == Matrix[i, j].ObjectType) || (Matrix[i, j + 1] is Rainbow)))
                    {
                        k = 1;
                        // проверяем ещё соседей справа
                        while ((j + 1 + k < Columns) && ((Matrix[i, j + 1 + k].ObjectType == Matrix[i, j].ObjectType) || (Matrix[i, j + 1 + k] is Rainbow)))
                            k++;

                        Matrix[i, j - 1] = RandElement(); // заменяем найденные одинаковые ячейки (соседей)
                        Matrix[i, j] = RandElement();
                        Matrix[i, j + 1] = RandElement();
                        rand += 3;

                        if (k != 1) // если были найдены доп. соседи справа
                        {
                            for (int l = 1; l < k; l++)
                                Matrix[i, j + 1 + l] = RandElement(); // меняем доп. соседи на новые
                        }

                        Score++; // увеличиваем счетчик очков на 1
                    }
                }
            }

            if (Score == StScore)
            {
                for (int i = 1; i < Rows - 1; i++) // подсчет очков по вертикали
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        // проверяет соседей сверху и снизу от текущ. ячейки на одинаковость (или на радужный квадрат)
                        if (((Matrix[i - 1, j].ObjectType == Matrix[i, j].ObjectType) || (Matrix[i - 1, j] is Rainbow))
                            && ((Matrix[i + 1, j].ObjectType == Matrix[i, j].ObjectType) || (Matrix[i + 1, j] is Rainbow)))
                        {
                            // проверяем ещё соседей снизу
                            k = 1;
                            while ((i + 1 + k < Rows) && ((Matrix[i + 1 + k, j].ObjectType == Matrix[i, j].ObjectType) || (Matrix[i + 1 + k, j] is Rainbow)))
                                k++;

                            Matrix[i - 1, j] = RandElement();  // заменяем найденные одинаковые ячейки (соседей)
                            Matrix[i, j] = RandElement();
                            Matrix[i + 1, j] = RandElement();

                            if (k != 1) // если были найдены доп. соседи снизу
                            {
                                for (int l = 1; l < k; l++)
                                    Matrix[i + 1 + l, j] = RandElement(); // меняем доп. соседи на новые
                            }

                            Score++; // увеличиваем счетчик очков на 1
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Анализирует клик по первому элементу игрового поля (квадратику)
        /// </summary>
        /// <param name="e">Событие - клик мыши</param>
        /// <returns>True - не было активации, False - была активация</returns> 
        public bool FirstClick(int posX, int posY)
        {
            int StScore; // запоминает текущее кол-во очков
            if (!Matrix[posY, posX].Activation(posX, posY, this)) // проверка на возможность активации при однократном клике
            {
                Matrix[posY, posX].SelectElement(); // выделяем данную ячейку (затемняем)
                return true;
            }
            else
            {
                do // подсчитываем очки после активации 
                {
                    StScore = Score;
                    Scoring();
                } while (StScore != Score); // до тех пор, пока не останется неподсчитанных очков
            }
            return false;
        }

        /// <summary>
        ///   Анализирует клик по второму элементу игрового поля (квадратику)
        /// </summary>
        /// <param name="FposX">Номер столбца ячейки из первого клика</param>
        /// <param name="FposY">Номер строки ячейки из первого клика</param>
        /// <param name="e">Событие - клик мыши</param>
        public void SecondClick(int FposX, int FposY, int posX, int posY)
        {
            // проверяет корректность второго клика
            if ((Matrix[posY, posX] is Basic)
                &&
                (((Math.Abs(posX - FposX) == 1) && (Math.Abs(posY - FposY) == 0)) || ((Math.Abs(posY - FposY) == 1) && (Math.Abs(posX - FposX) == 0))))
            {
                Chain(FposX, FposY, posX, posY); // проверяем возможность образования цепочки в реультате перемены мест 
            }
            Matrix[FposY, FposX].CreateElement(); // снимаем выделение с ячейки из первого клика
        }

        /// <summary>
        ///Уничтожает цепочки из 3 и более элементов одинаковых по цвету (в том числе Радужного квадрата) по столбцам или строкам игрового поля
        /// </summary>
        /// <param name="FposX">Номер столбца ячейки из первого клика</param>
        /// <param name="FposY">Номер строки ячейки из первого клика</param>
        /// <param name="SposX">Номер столбца ячейки из второго клика</param>
        /// <param name="SposY">Номер строки ячейки из второго клика</param>
        public void Chain(int FposX, int FposY, int SposX, int SposY)
        {
            int ChScore = Score; // запоминаем кол-во очков на текущий момент
            Swap(FposX, FposY, SposX, SposY); // меняем местами 2 ячейки с координатами из вх. аргументов
            Scoring(); // считаем кол-во очков на игровом поле
            if (Score == ChScore) // если кол-во очков не изменилось
            {
                Swap(SposX, SposY, FposX, FposY); // меняем 2 ячейки местами обратно
                Matrix[FposY, FposX].CreateElement(); // снимаем выделение с первой ячейки
            }
            else // если кол-во очков изменилось, сохраняем перемену мест
            {
                Matrix[SposY, SposX].CreateElement(); // снимаем выделение со второй ячейки
                do // производим подсчет очков до тех пор, пока не подсчитаем все
                {
                    ChScore = Score;
                    Scoring();
                } while (ChScore != Score);
            }
        }

        /// <summary>
        /// Перестановка местами двух элементов игрового поля
        /// </summary>
        /// <param name="FposX">Номер столбца ячейки из первого клика</param>
        /// <param name="FposY">Номер строки ячейки из первого клика</param>
        /// <param name="posX">Номер столбца ячейки из второго клика</param>
        /// <param name="posY">Номер строки ячейки из второго клика</param>
        public void Swap(int FposX, int FposY, int posX, int posY)
        {
            Cell SwCell = Matrix[FposY, FposX]; // сохраняем в буфер первую ячейку
            Matrix[FposY, FposX] = Matrix[posY, posX]; // меняем первую ячейку на вторую
            Matrix[posY, posX] = SwCell; // меняем вторую ячейку на первую (из буфера)
        }

        /// <summary>
        /// Генерирует случайный элемент игрового поля
        /// </summary>
        /// <param name="prand">Увеличивает счетчик итераций генератора случайных чисел на значение prand</param>
        /// <returns>Сгенерированный объект класса Cell (ячейку)</returns>
        public Cell RandElement()
        {
            Random rnd = new Random();// Инициализируем генератор случайных чисел

            Random rnd1 = new Random();
            int CellTypecode = rnd.Next(4);
            double rand = rnd1.NextDouble();
            if (rand < 0.6)
            {
                return new Basic(CellTypecode);
            }
            else if (rand < 0.7)
            {
                return new Bomb();
            }
            else if (rand < 0.8)
            {
                return new Rainbow();
            }
            else
            {
                return new Zip();
            }
        }
    }
}
