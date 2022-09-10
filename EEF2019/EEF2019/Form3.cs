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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-71BCM1U\SQLEXPRESS;Initial Catalog=EFF2019;Integrated Security=True");
        DataSet dataSet = new DataSet();
        SqlDataAdapter da_Association;
        SqlDataAdapter da_Stage;
        SqlDataAdapter da_Dinscription;
        DataView dataView = new DataView();
        private void Form3_Load(object sender, EventArgs e)
        {
            da_Association = new SqlDataAdapter("select * from Association", cnx);
            da_Association.Fill(dataSet, "Association");

            da_Stage = new SqlDataAdapter("select * from Stage", cnx);
            da_Stage.Fill(dataSet, "Stage");

            da_Dinscription = new SqlDataAdapter("select * from Demande_Inscription", cnx);
            da_Dinscription.Fill(dataSet, "Demande_Inscription");

            //remplirComBoxAssociation
            comboBox1.DataSource = null;
            comboBox1.DataSource = dataSet.Tables["Association"];
            comboBox1.DisplayMember = "Nom_Ass";
            comboBox1.ValueMember = "Id_Ass";
            //DatagridviewStage
            dataView = dataSet.Tables["Stage"].DefaultView;
            dataGridView1.DataSource = dataView;
            //DatagridviewInscription
            /*dataView = dataSet.Tables["Demande_Inscription"].DefaultView;
            dataGridView2.DataSource = dataView;*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dataView.RowFilter = "Id_Ass =" + comboBox1.SelectedValue;
            }
            else if (radioButton1.Checked)
            {
                dataView.RowFilter = "Date_Debut ='" + Convert.ToDateTime(textBox2.Text)+" 'and Date_Fin ='" + Convert.ToDateTime(textBox1.Text)+"'";
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                SqlCommand cmd = new SqlCommand("select d.Id_Inscription,d.Date_Demande,d.Id_Vlt,v.Nom_Vlt,v.Prenom_Vlt,d.Etat from Demande_Inscription d, Volontaire v where v.Id_Vlt=d.Id_Vlt AND d.Id_Stage="+ dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), cnx);
                DataTable db = new DataTable();
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                db.Load(dr);
                cnx.Close();
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = db;
            }
        }
    }
}
