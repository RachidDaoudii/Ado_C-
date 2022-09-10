using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EFF2014
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-71BCM1U\SQLEXPRESS;Initial Catalog=EFF2014;Integrated Security=True");
        SqlDataAdapter daStagiaire;
        SqlDataAdapter da;
        DataSet dataSet = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cmb
            SqlCommand cmd = new SqlCommand("Select * from Filiere", cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            comboBox1.DataSource = tb;
            comboBox1.DisplayMember = "nomFiliere";
            comboBox1.ValueMember = "idFiliere";
            rd.Close();
            cn.Close();

            datagrid();

            da = new SqlDataAdapter("select * from Filiere", cn);
            da.Fill(dataSet, "Filiere");


            daStagiaire = new SqlDataAdapter("select * from stagiaire", cn);
            new SqlCommandBuilder(daStagiaire);
            daStagiaire.Fill(dataSet, "Reclamation");
        }
        public void datagrid()
        {
            
            SqlCommand cmd = new SqlCommand("select S.idstagiaire,S.nom,S.prenom,F.nomFiliere,S.TotalAbsence from Stagiaire S,Filiere F where S.idFiliere=F.idFiliere", cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tb;
            rd.Close();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Stagiaire values(@id,@nom,@prenom,@idf)", cn);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nom", textBox3.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@idf", comboBox1.SelectedValue);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            datagrid();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update stagiaire set nom=@nom,prenom=@prenom,idFiliere=@idf where idstagiaire=@id", cn);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nom", textBox3.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@idf", comboBox1.SelectedValue);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            datagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from stagiaire where idstagiaire=@id", cn);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            datagrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataSet.Tables["Filiere"].WriteXml(@"C:\Users\dell\Desktop\rachid.xml");
            //dataSet.WriteXml(@"C:\Users\dell\Desktop\rachid.xml");
            MessageBox.Show("Expoter");
        }
    }
}
