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

namespace EEF2019
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-71BCM1U\SQLEXPRESS;Initial Catalog=EFF2019;Integrated Security=True");
        DataSet dataSet = new DataSet();
        SqlDataAdapter da_Association;
        private void Form2_Load(object sender, EventArgs e)
        {
            da_Association = new SqlDataAdapter("select * from Association", cnx);
            new SqlCommandBuilder(da_Association);
            da_Association.Fill(dataSet, "Association");
            //remplirComBoxAssociation
            cmbAssociation.DataSource = null;
            cmbAssociation.DataSource = dataSet.Tables["Association"];
            cmbAssociation.ValueMember = "Id_Ville";
            //remplirDataGridViewAssociation
            DataGridView();
        }
        private void DataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow dataRow in dataSet.Tables["Association"].Rows)
            {
                dataGridView1.Rows.Add(dataRow["Id_Ass"],dataRow["Nom_Ass"],
                dataRow["RaisonSocail"], dataRow["Adresse"], dataRow["Telephone"], dataRow["Id_Ville"].ToString());
            }
        }
        //Existence
        private bool Exist()
        {
            foreach (DataRow dataRow in dataSet.Tables["Association"].Rows)
            {
                if (textBox1.Text == dataRow["Id_Ass"].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Exist())
            {
                foreach (DataRow dataRow in dataSet.Tables["Association"].Rows)
                {
                    if (textBox1.Text == dataRow["Id_Ass"].ToString())
                    {
                        textBox2.Text = dataRow["Nom_Ass"].ToString();
                        textBox3.Text = dataRow["RaisonSocail"].ToString();
                        textBox4.Text = dataRow["Adresse"].ToString();
                        textBox5.Text = dataRow["Telephone"].ToString();
                        cmbAssociation.SelectedValue = dataRow["Id_Ville"].ToString();
                    }

                }
            }
            else
            {
                MessageBox.Show("Association N'existe Pas");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Exist())
            {
                MessageBox.Show("Association N'existe Pas");
                
            }
            else
            {
                DataRow dataRow = dataSet.Tables["Association"].NewRow();
                dataRow["Id_Ass"] = textBox1.Text;
                dataRow["Nom_Ass"] = textBox2.Text;
                dataRow["RaisonSocail"] = textBox3.Text;
                dataRow["Adresse"] = textBox4.Text;
                dataRow["Telephone"] = textBox5.Text;
                dataRow["Id_Ville"] = cmbAssociation.SelectedValue;
                dataSet.Tables["Association"].Rows.Add(dataRow);
                da_Association.Update(dataSet, "Association");
                DataGridView();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Exist())
            {
                foreach (DataRow dataRow in dataSet.Tables["Association"].Rows)
                {
                    if (textBox1.Text == dataRow["Id_Ass"].ToString())
                    {
                        dataRow["Nom_Ass"] = textBox2.Text;
                        dataRow["RaisonSocail"] = textBox3.Text;
                        dataRow["Adresse"] = textBox4.Text;
                        dataRow["Telephone"] = textBox5.Text;
                        dataRow["Id_Ville"] = cmbAssociation.SelectedValue;
                        da_Association.Update(dataSet, "Association");
                        DataGridView();
                        break;
                    }

                }
            }
            else
            {
                MessageBox.Show("Association N'existe Pas");
            }
        }
    }
}
