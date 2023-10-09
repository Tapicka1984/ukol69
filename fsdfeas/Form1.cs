using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fsdfeas
{
    public partial class Form1 : Form
    {
        ListBox listBox1 = new ListBox();
        public Form1()
        {
            InitializeComponent();
            listBox1.Location = new System.Drawing.Point(12, 12);
            listBox1.Name = "ListBox1";
            listBox1.Size = new System.Drawing.Size(245, 200);

            this.Controls.Add(listBox1);
        }

        Form2 form2;
        Button newButton = new Button();

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count == 10)
            {

            }
            else
            {
                form2 = new Form2();
                form2.ValueEntered += (value) =>
                {
                    listBox1.Items.Add(value);
                };
                form2.Show();
            }
        }
    }

    public partial class Form2 : Form
    {
        Button newButton = new Button();
        Button newButton2 = new Button();
        TextBox textboxicek = new TextBox();

        public event Action<string> ValueEntered;

        public Form2()
        {
            newButton.Text = "uloz!";
            newButton.Location = new System.Drawing.Point(50, 20);
            newButton.Size = new System.Drawing.Size(60, 40);
            newButton.BackColor = System.Drawing.Color.FromArgb(250, 115, 105);
            newButton.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            newButton.Click += newButton_Click;
            Controls.Add(newButton);

            newButton2.Text = "zrus!";
            newButton2.Location = new System.Drawing.Point(180, 40);
            newButton2.Size = new System.Drawing.Size(60, 40);
            newButton2.BackColor = System.Drawing.Color.FromArgb(250, 115, 105);
            newButton2.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            newButton2.Click += newButton_Click2;
            Controls.Add(newButton2);

            textboxicek.KeyDown += textboxicek_KeyDown; // Přidáme obsluhu KeyDown
            Controls.Add(textboxicek);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (ValueEntered != null)
            {
                ValueEntered(textboxicek.Text);
            }
        }

        private void newButton_Click2(object sender, EventArgs e)
        {
            // Obsluha pro tlačítko "zrus!"
        }

        private void textboxicek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValueEntered != null)
                {
                    ValueEntered(textboxicek.Text);
                }
                this.Close();
            }
        }
    }
}
