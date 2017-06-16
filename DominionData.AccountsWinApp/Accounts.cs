using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominionData.Base.Interfaces;
using DominionData.Base.Implementations;
namespace DominionData.AccountsWinApp
{
	public partial class Accounts : Form
	{
		ICustomerList CustomerList = new DominionData.Base.Implementations.CustomerList();

		public Accounts()
		{
			InitializeComponent();
		}

		private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CustomerList customerList = new CustomerList();
			customerList.ShowDialog();

		}

		private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Invoice invoice = new Invoice();
			invoice.Show();
		}

		private void creditNoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreditNote creditNote = new CreditNote();
			creditNote.Show();
		}

		private void debtorToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
