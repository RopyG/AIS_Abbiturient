using AIS.ProjectForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS
{
    public partial class DBForm : System.Windows.Forms.Form
    {
        DBConnector dbc = new DBConnector();
        public DBForm()
        {
            InitializeComponent();
            dbc.Connect(this);
            //abbiturientDataSet1.Get
        }

        

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.abbiturientsBindingSource.EndEdit();
            //this.
            this.tableAdapterManager.UpdateAll(this.abbiturientDataSet1);

        }
        private void DBForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abbiturientDataSet1.Accounts". При необходимости она может быть перемещена или удалена.
            //this.accountsTableAdapter.Fill(this.abbiturientDataSet1.Accounts);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abbiturientDataSet1.Clients". При необходимости она может быть перемещена или удалена.
            
            this.clientsTableAdapter.Fill(this.abbiturientDataSet1.Clients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abbiturientDataSet1.Clients". При необходимости она может быть перемещена или удалена.
            //this.clientsTableAdapter1.Fill(this.abbiturientDataSet1.Clients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Clients". При необходимости она может быть перемещена или удалена.
            //this.clientsTableAdapter.Fill(this.abbiturientDataSet1.Clients);
            //dataGridView1.DataSource = abbiturientsBindingSource.DataSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SelectSortForm().ShowDialog();
        }
    }
}

//ADDButton
/*dbc.InsertAbbiturient(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);*/

//SaveButton
/*          this.Validate();
            this.abbiturientsBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.abbiturientDataSet1);*/

//UpdateButton
/*dataGridView1.Update();*/
