namespace Ucpf.Grammar.Analyzer
{
	partial class MainWindow
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
			if (disposing && (components != null)) {
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
			this.tvGrammar = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// tvGrammar
			// 
			this.tvGrammar.Location = new System.Drawing.Point(8, 8);
			this.tvGrammar.Name = "tvGrammar";
			this.tvGrammar.Size = new System.Drawing.Size(216, 256);
			this.tvGrammar.TabIndex = 1;
			this.tvGrammar.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvGrammar_BeforeExpand);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(566, 352);
			this.Controls.Add(this.tvGrammar);
			this.Name = "MainWindow";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.GrammarAnalyzer_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tvGrammar;

	}
}

