using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int x = 0;
        int y = 0;
        bool order = true;
        int board_size;
        int[,] board_state;
        int check;
        int diagonal;
        int game_lenght = 0;
        bool winner_decided = false;
        public Form1()
        {
            InitializeComponent();

        }
        void AddBtn()
        {
            Button btn = new Button();
            btn.BackColor = Color.White;
            btn.Location = new Point(x, y);
            btn.Height = 100;
            btn.Width = 100;
            btn.Click += Btn_Click;
            x += btn.Width;
            this.Controls.Add(btn);

        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            if (sender is Button)
            {
                Button b = sender as Button;
                if (b.Text == "X" || b.Text=="O")
                {
                    label1.Text = "Занято";
                    return;
                }
                else if (order) 
                {
                    b.Text = "X";
                    board_state[(this.Controls.GetChildIndex(b) - 2) % board_size, (this.Controls.GetChildIndex(b) - 2) / board_size] = 1;
                }
                else
                {
                    b.Text = "O";
                    board_state[(this.Controls.GetChildIndex(b) - 2) % board_size, (this.Controls.GetChildIndex(b) - 2) / board_size] = 2;
                }
                for (int i = 0; i < board_size; i++)
                {
                    check = 0;
                    for (int j = 0; j < board_size; j++)
                    {
                        if (board_state[i, j] == 1)
                        {
                            check++;
                        }
                    }
                    if (check == board_size && !winner_decided)
                    {
                        Win("Крестики победили");
                    }
                }
                
                for (int i = 0; i < board_size; i++)
                {
                    check = 0;
                    for (int j = 0; j < board_size; j++)
                    {
                        if (board_state[j, i] == 1)
                        {
                            check++;
                        }
                    }
                    if (check == board_size && !winner_decided)
                    {
                        Win("Крестики победили");
                    }
                }

                diagonal = 0;
                check = 0;
                for (int i = 0; i < board_size; i++)
                {
                    if (board_state[i, diagonal] == 1)
                    {
                        check++;
                    }
                    diagonal++;
                }
                if (check == board_size && !winner_decided)
                {
                    Win("Крестики победили");
                }

                check = 0;
                diagonal = 0;
                for (int i = board_size-1; i >= 0; i--)
                {
                    if (board_state[i, diagonal] == 1)
                    {
                        check++;
                    }
                    diagonal++;
                }
                if (check == board_size && !winner_decided)
                {
                    Win("Крестики победили");
                }

                for (int i = 0; i < board_size; i++)
                {
                    check = 0;
                    for (int j = 0; j < board_size; j++)
                    {
                        if (board_state[i, j] == 2)
                        {
                            check++;
                        }
                    }
                    if (check == board_size && !winner_decided)
                    {
                        Win("Нолики победили");
                    }
                }

                for (int i = 0; i < board_size; i++)
                {
                    check = 0;
                    for (int j = 0; j < board_size; j++)
                    {
                        if (board_state[j, i] == 2)
                        {
                            check++;
                        }
                    }
                    if (check == board_size && !winner_decided)
                    {
                        Win("Нолики победили");
                    }
                }

                check = 0;
                diagonal = 0;
                for (int i = 0; i < board_size; i++)
                {
                    if (board_state[i, diagonal] == 2)
                    {
                        check++;
                    }
                    diagonal++;
                }
                if (check == board_size && !winner_decided)
                {
                    Win("Нолики победили");
                }

                check = 0;
                diagonal = 0;
                for (int i = board_size-1; i >= 0; i--)
                {
                    if (board_state[i, diagonal] == 2)
                    {
                        check++;
                    }
                    diagonal++;
                }
                if (check == board_size && !winner_decided)
                {
                    Win("Нолики победили");
                }

                game_lenght++;

                if (game_lenght == board_size*board_size && !winner_decided)
                {
                    Win("Ничья");
                }

                order = !order;
            }
        }

        private void Win(string winner)
        {
            label1.Visible = true;
            winner_decided = true;
            label1.Text = $"{winner}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            board_size = int.Parse(comboBox1.Text);
            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    AddBtn();
                }
                x = 0;
                y += 100;
            }
            board_state = new int[board_size, board_size];
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}