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

namespace _04062019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillCatigories();


        }
        private void Btn_Click(string name)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            con.Open();
            string query = "INSERT INTO FACULTE([Name]) VALUES(@name)";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@name", name);
          

            int rowAffercted= command.ExecuteNonQuery();

            con.Close();

            FillCatigories();


        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Btn_Click(TxtName.Text);
        }


        private void FillCatigories()

        {
            DvgCatigoreis.Rows.Clear();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
            con.Open();

            string query = "SELECT * FROM  FACULTE  ORDER BY id ASC ";

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                //MessageBox.Show(reader.GetString(1));

                DvgCatigoreis.Rows.Add(reader.GetInt32(0), reader.GetString(1));
            }

            con.Close();
        }
    }
}
