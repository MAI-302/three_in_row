using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игра
{
    public partial class Form1 : Form
    {
        //public Game newGame; // Объект - Игра
        public Board newBoard;
        int Rows = 10, Columns = 8, 
            Cell_Width = Properties.Resources.blue.Width, 
            Cell_Height = Properties.Resources.blue.Height;
        public bool flag = false; // Флаг состояния кликов (False - не было первого клика, True - был первый клик)
        int posX = 0, posY = 0;
        int FposX = 0, FposY = 0; // Координаты клика

        /// <summary>
        ///  Конструктор - инициализация формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Метод при загрузке формы
        /// </summary>
        /// <param name="e">Аргументы события</param>
        /// <param name="sender">Объект обращения</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            newBoard = new Board(Columns, Rows, Columns * Cell_Width, Rows * Cell_Height + this.statusStrip1.Height); // создаем новую игру
            newBoard.Generate();

            do // доводим игровое поле до состояния готовности путем обнуления очков на игровом поле
            {
                newBoard.Score = 0;
                newBoard.Scoring();
            } while (newBoard.Score != 0);

            this.ClientSize = new System.Drawing.Size(newBoard.Width, newBoard.Height); // корректируем размеры формы
        }

        /// <summary>
        ///  Отрисовка формы
        /// </summary>
        /// <param name="e">Событие - рисование</param>
        /// <param name="sender">Объект обращения</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.StripScore.Text = "Score: _" + Convert.ToString(newBoard.Score); // Выводит кол-во очков в поле Score
            newBoard.Draw(e); // Рисует игровое поле - обращение к методу Draw из класса Board
        }

        /// <summary>
        ///  Обработка клика мыши
        /// </summary>
        /// <param name="e">Событие - клик мыши</param>
        /// <param name="sender">Объект обращения</param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!flag) // проверяем состояние флага
            {
                if ((e.X < newBoard.Width) && (e.Y < newBoard.Height)) // защита от кликов вне игрового поля
                {
                    posX = (int)(e.X / Cell_Width); // находит номер ячейки матрицы
                    posY = (int)(e.Y / Cell_Height);

                    if (flag = newBoard.FirstClick(posX, posY)) // проверяем характер первого клика - True - ожидание 2 клика, False - была активация
                    {
                        FposX = posX; // сохраняем коодинаты первого клика
                        FposY = posY;
                        this.Score2.Text = "Ждем клик" + Convert.ToString(FposX) + Convert.ToString(FposY); // выводим в поле Score2 текст
                        this.Refresh(); // обновляем форму
                    }
                    else
                    {
                        this.Score2.Text = "Активация!"; // выводим в поле Score2 текст
                        this.Refresh(); // обновляем форму
                    }
                }
            }
            else // если находимся в состоянии ожидании второго клика (flag = True)
            {
                this.Score2.Text = "Второй клик"; // выводим в поле Score2 текст
                if ((e.X < newBoard.Width) && (e.Y < newBoard.Height)) // защита от клика вне границ игрового поля
                {
                    posX = (int)(e.X / Cell_Width); // получает номер столбца и строки ячейки, по которой кликнули
                    posY = (int)(e.Y / Cell_Height);

                    newBoard.SecondClick(FposX, FposY, posX, posY);

                    this.Refresh(); // обновляем форму
                }
                flag = false; // снимаем флаг (False - не было первого клика)
            }
        }
    }
}
