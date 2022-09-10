using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFF2021CASA
{
    class ObjetsAdo
    {
        public SqlConnection cn; 
        public SqlDataAdapter dapp;
        public SqlDataReader dr;
        public SqlDataAdapter dalocat;
        public SqlDataAdapter daloc;
        public SqlCommandBuilder commandBuilder;
        public SqlCommand cmd;
        public DataTable tb;
        public DataSet data;
        public DataRow row;

        public ObjetsAdo()
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-71BCM1U\SQLEXPRESS;Initial Catalog=EFF2021CASA;Integrated Security=True");
            cmd = new SqlCommand();
            dapp = new SqlDataAdapter();
            dalocat = new SqlDataAdapter();
            daloc = new SqlDataAdapter();
            data = new DataSet();
            commandBuilder = new SqlCommandBuilder();
        }
        public void connecter()
        {
            cn.Open();
        }
        public void déconnecter()
        {
            cn.Close();
        }
    }
    
}
