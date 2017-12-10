using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using Client.Properties;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace Client
{
    public partial class ConForm : Form
    {
        private string _dataSource;
        public static string ConString { get; private set; }

        private DataConnectionDialog _dcd;
        public ConForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConString = GetConnectionString();
            textBox1.Text = ConString;

            SaveConString(ConString);

            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private string GetConnectionString()
        {
            string conString = null;
            DataConnectionDialog dcd = new DataConnectionDialog();
            _dcd = dcd;
            DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
            dcs.LoadConfiguration(dcd);

            if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
            {
                conString = dcd.ConnectionString;
            }

            dcs.SaveConfiguration(dcd);

            return conString;
        }

        private void SaveConString(string conString)
        {
            string confName = "TimetableContext";

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder(conString);

            EntityConnectionStringBuilder entitySb  = new EntityConnectionStringBuilder();
            entitySb.Metadata = "res://*/DbTimetable.csdl|res://*/DbTimetable.ssdl|res://*/DbTimetable.msl";
            entitySb.Provider = _dcd.SelectedDataProvider.Name;
            entitySb.ProviderConnectionString = conStringBuilder.ConnectionString;

            ConnectionStringSettings cs = new ConnectionStringSettings(confName, entitySb.ConnectionString);

            ConnectionStringsSection csSection = config.ConnectionStrings;
            csSection.ConnectionStrings[confName].ConnectionString = cs.ConnectionString;
            //csSection.ConnectionStrings.Remove(cs.Name);
            //csSection.ConnectionStrings.Add(cs);

            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
