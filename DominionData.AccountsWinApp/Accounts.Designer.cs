namespace DominionData.AccountsWinApp
{
	partial class Accounts
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.creditNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debtorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrationToolStripMenuItem,
            this.processToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(840, 28);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// administrationToolStripMenuItem
			// 
			this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerListToolStripMenuItem});
			this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
			this.administrationToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
			this.administrationToolStripMenuItem.Text = "Administration";
			// 
			// customerListToolStripMenuItem
			// 
			this.customerListToolStripMenuItem.Name = "customerListToolStripMenuItem";
			this.customerListToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
			this.customerListToolStripMenuItem.Text = "Customer List";
			this.customerListToolStripMenuItem.Click += new System.EventHandler(this.customerListToolStripMenuItem_Click);
			// 
			// processToolStripMenuItem
			// 
			this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoiceToolStripMenuItem,
            this.creditNoteToolStripMenuItem,
            this.debtorToolStripMenuItem});
			this.processToolStripMenuItem.Name = "processToolStripMenuItem";
			this.processToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
			this.processToolStripMenuItem.Text = "Process";
			// 
			// invoiceToolStripMenuItem
			// 
			this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
			this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.invoiceToolStripMenuItem.Text = "Invoice";
			this.invoiceToolStripMenuItem.Click += new System.EventHandler(this.invoiceToolStripMenuItem_Click);
			// 
			// creditNotreToolStripMenuItem
			// 
			this.creditNoteToolStripMenuItem.Name = "creditNotreToolStripMenuItem";
			this.creditNoteToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.creditNoteToolStripMenuItem.Text = "Credit Note";
			this.creditNoteToolStripMenuItem.Click += new System.EventHandler(this.creditNoteToolStripMenuItem_Click);
			// 
			// debtorToolStripMenuItem
			// 
			this.debtorToolStripMenuItem.Name = "debtorToolStripMenuItem";
			this.debtorToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.debtorToolStripMenuItem.Text = "Debtor History";
			this.debtorToolStripMenuItem.Click += new System.EventHandler(this.debtorToolStripMenuItem_Click);
			// 
			// DominionData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(840, 539);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "DominionData";
			this.Text = "DominionData - Accounts";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customerListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem creditNoteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem debtorToolStripMenuItem;
	}
}

