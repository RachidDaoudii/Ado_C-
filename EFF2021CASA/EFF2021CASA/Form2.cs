using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFF2021CASA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ObjetsAdo Ob = new ObjetsAdo();
        private void Form2_Load(object sender, EventArgs e)
        {
            Ob.dapp = new SqlDataAdapter("select * from appartement", Ob.cn);
            Ob.dapp.Fill(Ob.data, "appartement");
            //combobox
            comboBox1.Items.Add("Studio");
            comboBox1.Items.Add("F1");
            comboBox1.Items.Add("F2");
            comboBox1.Items.Add("F3");
            comboBox1.Items.Add("F4");
            comboBox1.Items.Add("F5+");
            comboBox1.SelectedIndex = 0;
            //datagridview
            foreach(DataRow row in Ob.data.Tables["appartement"].Rows)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow row in Ob.data.Tables["appartement"].Rows)
            {
                if(row[2].ToString()==comboBox1.SelectedItem.ToString())
                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[3]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlWriter xmlWriter = XmlWriter.Create(@"C:\Users\dell\Desktop\appartements.xml");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("appartements");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    xmlWriter.WriteStartElement("appartement");
                    xmlWriter.WriteAttributeString("id", row.Cells[0].Value.ToString());
                    xmlWriter.WriteStartElement("adress");
                    xmlWriter.WriteString(row.Cells[1].Value.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("type");
                    xmlWriter.WriteString(row.Cells[2].Value.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("prix");
                    xmlWriter.WriteString(row.Cells[3].Value.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            MessageBox.Show("Xml enregistré");
        }
    }
}
