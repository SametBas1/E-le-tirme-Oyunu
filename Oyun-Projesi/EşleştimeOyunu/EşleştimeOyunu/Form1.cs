using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EşleştimeOyunu

{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "!", ",", "b", "k", "v", "y", "z", "M", "N", "a",
            "!", ",", "b", "k", "v", "y", "z", "M", "N", "a"
        };
        Random rnd = new Random();
        Button first, second;
        Timer t = new Timer();
        Timer t2 = new Timer();
        int skor = 0;
        public Form1()
        {
            InitializeComponent();
            t.Tick += T_Tick;
            t.Interval = 3000;
            t2.Tick += T2_Tick;
            t2.Interval = 1000;
            Göster();
            t.Start();
        }

        private void skorarttır()
        {
            skor += 10; 
            label1.Text = "Skor: " + skor.ToString();
            label1.Refresh();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.ForeColor = btn.BackColor;
            }
        }

        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void Buton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || btn.ForeColor == Color.Black) return;

            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                return;
            }

            second = btn;
            second.ForeColor = Color.Black;

            if (first.Text == second.Text)
            {
                skorarttır();
                first = null;
                second = null;
            }
            else
            {
                t2.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Click += Buton_Click;
            }
        }

        void Göster()
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                int randomIndex = rnd.Next(icons.Count);
                btn.Text = icons[randomIndex];
                btn.ForeColor = Color.Black;
                icons.RemoveAt(randomIndex);
            }
        }       
    }
}
