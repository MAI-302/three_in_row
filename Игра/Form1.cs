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
        public Game newGame; // Объект - Игра

        int Rows = 10, Columns = 8;
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
            newGame = new Game(Columns, Rows); // создаем новую игру
           
            newGame.Initialization(); // запускаем игровой процесс
        


            do // доводим игровое поле до состояния готовности путем обнуления очков на игровом поле
            {
                newGame.newBoard.Score = 0;
                newGame.newBoard.Scoring();
            } while (newGame.newBoard.Score != 0);

            this.ClientSize = new System.Drawing.Size(newGame.Width, newGame.Height); // корректируем размеры формы
        }

        /// <summary>
        ///  Отрисовка формы
        /// </summary>
        /// <param name="e">Событие - рисование</param>
        /// <param name="sender">Объект обращения</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.StripScore.Text = "Score: _" + Convert.ToString(newGame.newBoard.Score); // Выводит кол-во очков в поле Score
            newGame.newBoard.Draw(e); // Рисует игровое поле - обращение к методу Draw из класса Board
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
                if ((e.X < newGame.Width) && (e.Y < newGame.Height)) // защита от кликов вне игрового поля
                {
                    posX = (int)(e.X / 36); // находит номер ячейки матрицы
                    posY = (int)(e.Y /36 );

                    if (flag = newGame.newBoard.FirstClick(posX, posY)) // проверяем характер первого клика - True - ожидание 2 клика, False - была активация
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
                if ((e.X < newGame.Width) && (e.Y < newGame.Height)) // защита от клика вне границ игрового поля
                {
                    posX = (int)(e.X / 36); // получает номер столбца и строки ячейки, по которой кликнули
                    posY = (int)(e.Y / 36);

                    newGame.newBoard.SecondClick(FposX, FposY, posX, posY);

                    this.Refresh(); // обновляем форму
                }
                flag = false; // снимаем флаг (False - не было первого клика)
            }
        }
    }
}
