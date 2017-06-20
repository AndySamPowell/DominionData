using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominionData.DataAndBase;

namespace DominionData.AccountsWinApp
{
	public partial class CustomerList : Form
	{
		string TabPage;
		int rowIndex;
		public CustomerList()
		{
			InitializeComponent();
		
			var cu = new DominionData.DataAndBase.CustomerList();
			var query = cu.GetAll();
			dataGridView1.DataSource = query;
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			//save
			var firstNameEdit = this.txtFirstNameEdit.Text;
			var lasttNameEdit = this.txtLastNameEdit.Text;

			var customer = new CustomerModel()
			{
			
				FirstName = firstNameEdit,
				LastName = lasttNameEdit,

			};



		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			//search
		}
				

		private void tabControl1_Selected(object sender, TabControlEventArgs e)
		{
		   this.TabPage = e.TabPage.ToString();

		}



		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		    var clickedItem = e.ClickedItem;

			var customerId = dataGridView1[0, this.rowIndex].Value;

			Goto(customerId, clickedItem);


		}

		private void Goto(object customerId, ToolStripItem clickedItem)
		{

			var invoice = new Invoice(customerId);
			
			invoice.Show();
		}

		private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.rowIndex = e.RowIndex;

		}
	}
}
