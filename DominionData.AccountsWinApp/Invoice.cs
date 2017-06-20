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
	public partial class Invoice: Form
	{
		public Invoice()
		{
			InitializeComponent();

			
		}

		public Invoice(object i)
		{
			int j = (int)i;

			InitializeComponent();


		}

		private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
			if (dataGridView1.CurrentCell.ColumnIndex == 2) //Desired Column
			{
				TextBox tb = e.Control as TextBox;
				if (tb != null)
				{
					tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
				}
			}
		}

		private void Column1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar)
				&& !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{

		}
	}
}                                                                                                                                                                                                                                                                                                                                                                                              