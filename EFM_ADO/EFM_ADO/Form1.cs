using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFM_ADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-71BCM1U\SQLEXPRESS;Initial Catalog=EmployeService;Integrated Security=True");
        SqlDataReader dr;
        SqlDataAdapter daEmp;
        SqlDataAdapter daSer;
        DataSet data =new DataSet();
        BindingSource bs = new BindingSource();
        DataContext dataContext = new DataContext(@"Data Source=DESKTOP-71BCM1U\SQLEXPRESS;Initial Catalog=EmployeService;Integrated Security=True");
        private Table<Employe> employes;
        private Table<Service> services;
        private void Form1_Load(object sender, EventArgs e)
        {
            //cmb
            services = dataContext.GetTable<Service>();
            var req = (from ser in services select ser).ToList();
            comboBox1.DataSource = req;
            comboBox1.DisplayMember = "NomService";
            comboBox1.ValueMember = "IdService";
            gridview();

            //cmb2
            services = dataContext.GetTable<Service>();
            var re = (from ser in services select ser).ToList();
            comboBox2.DataSource = re;
            comboBox2.DisplayMember = "NomService";
            comboBox2.ValueMember = "IdService";


        }
        public void gridview()
        {
            employes = dataContext.GetTable<Employe>();
            var req = from emp in employes select emp;
            dataGridView1.Rows.Clear();
            foreach(var e in req)
            {
                dataGridView1.Rows.Add(e.Id, e.Nom, e.Prenom, e.DateNaissance, e.IdService);
            }
        }
        public bool Exist()
        {
            employes = dataContext.GetTable<Employe>();
            var req = from emp in employes where emp.Id == int.Parse(txtid.Text) select emp;
            if (req.Count() > 0)
                return true;
            return false;

        }

        private void btnChercher_Click(object sender, EventArgs e)
        {
            if (Exist())
            {
                employes = dataContext.GetTable<Employe>();
                var req = from emp in employes where emp.Id == int.Parse(txtid.Text) select emp;
                foreach(var em in req)
                {
                    txtnom.Text = em.Nom;
                    txtprenom.Text = em.Prenom;
                    txtdateN.Text = DateTime.Parse(em.DateNaissance.ToString()).ToShortDateString();
                    comboBox1.SelectedValue = em.IdService;
                }
            }
            else
            {
                MessageBox.Show("Employe N'existe Pas");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cn.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            employes = dataContext.GetTable<Employe>();
            Employe emp = new Employe { 
                Id = int.Parse(txtid.Text),
                Nom=txtnom.Text,
                Prenom=txtprenom.Text,
                DateNaissance=DateTime.Parse(txtdateN.Text),
                IdService=int.Parse(comboBox1.SelectedValue.ToString())
            };
            employes.InsertOnSubmit(emp);
            dataContext.SubmitChanges();
            gridview();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            employes = dataContext.GetTable<Employe>();
            var req = from em in employes where em.Id == int.Parse(txtid.Text) select em;
            foreach(var em in req)
            {
                em.Nom = txtnom.Text;
                em.Prenom = txtprenom.Text;
                em.DateNaissance = DateTime.Parse(txtdateN.Text);
                em.IdService = int.Parse(comboBox1.SelectedValue.ToString());
            }
            dataContext.SubmitChanges();
            gridview();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            employes = dataContext.GetTable<Employe>();
            var req = from em in employes where em.Id == int.Parse(txtid.Text) select em;
            foreach (var em in req)
            {
                employes.DeleteAllOnSubmit(req);
                dataContext.SubmitChanges();
            }
            gridview();
        }


        private void Afficher_Click(object sender, EventArgs e)
        {
            employes = dataContext.GetTable<Employe>();
            var req = from emp in employes where emp.IdService == int.Parse(comboBox2.SelectedValue.ToString()) select emp;
            dataGridView1.Rows.Clear();
            foreach(var em in req)
            {
                dataGridView1.Rows.Add(em.Id, em.Nom, em.Prenom,DateTime.Parse(em.DateNaissance.ToString()), em.IdService);
            }
        }
    }
}
