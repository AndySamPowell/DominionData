using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DominionData.AccountsWinApp
{
	public partial class Accounts : Form
	{
		public Accounts()
		{
			InitializeComponent();
		}

		private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CustomerList customerList = new CustomerList();
			customerList.MdiParent = this;
			customerList.Show();
		}

		private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Invoice invoice = new Invoice();
			invoice.MdiParent = this;
			invoice.Show();
		}

		private void creditNoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreditNote creditNote = new CreditNote();
			creditNote.MdiParent = this;
			creditNote.Show();
		}

		private void debtorToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
