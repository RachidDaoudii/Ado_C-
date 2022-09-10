using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFF2021CASA
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ObjetsAdo Ob = new ObjetsAdo();
        private void Form1_Load(object sender, EventArgs e)
        {
            Ob.dapp = new SqlDataAdapter("select * from appartement", Ob.cn);
            Ob.dapp.Fill(Ob.data, "appartement");
            new SqlCommandBuilder(Ob.dapp);
            //combobox
            comboBox1.Items.Add("Studio");
            comboBox1.Items.Add("F1");
            comboBox1.Items.Add("F2");
            comboBox1.Items.Add("F3");
            comboBox1.Items.Add("F4");
            comboBox1.Items.Add("F5+");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox1.Text != "" && textBox1.Text != "" && comboBox1.SelectedIndex !=-1)
            {
                if (!exist())
                {
                    Ob.row = Ob.data.Tables["appartement"].NewRow();
                    Ob.row[0] = int.Parse(textBox1.Text);
                    Ob.row[1] = textBox3.Text;
                    Ob.row[2] = comboBox1.SelectedItem.ToString();
                    Ob.row[3] = int.Parse(textBox4.Text);

                    Ob.data.Tables["appartement"].Rows.Add(Ob.row);
                    Ob.dapp.Update(Ob.data, "appartement");
                }
                else
                {
                    MessageBox.Show("Appartement Déja existe");
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir les champs");
            }
            
        }
        public bool exist()
        {
            foreach (DataRow row in Ob.data.Tables["appartement"].Rows)
            {
                if (row[0].ToString() == textBox1.Text)
                    return true;
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (exist())
            {
                foreach (DataRow row in Ob.data.Tables["appartement"].Rows)
                {
                    if (row[0].ToString() == textBox1.Text)
                    {
                        row[1] = textBox3.Text;
                        row[2] = comboBox1.SelectedItem.ToString();
                        row[3] = int.Parse(textBox4.Text);
                        Ob.dapp.Update(Ob.data, "appartement");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Appartement N'existe pas");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (exist())
            {
                foreach (DataRow row in Ob.data.Tables["appartement"].Rows)
                {
                    if (row[0].ToString() == textBox1.Text)
                    {
                        row.Delete();
                        Ob.dapp.Update(Ob.data, "appartement");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Appartement N'existe pas");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
                string message = "Voulez-vous quitter";
                string caption = "Fermer Application";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
        }
    }
}
