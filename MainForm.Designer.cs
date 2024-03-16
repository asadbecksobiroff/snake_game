namespace key
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.food = new System.Windows.Forms.Label();
			this.head = new System.Windows.Forms.Label();
			this.Move = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// food
			// 
			this.food.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.food.Location = new System.Drawing.Point(55, 45);
			this.food.Name = "food";
			this.food.Size = new System.Drawing.Size(20, 20);
			this.food.TabIndex = 0;
			// 
			// head
			// 
			this.head.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.head.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.head.Location = new System.Drawing.Point(300, 300);
			this.head.Margin = new System.Windows.Forms.Padding(0);
			this.head.Name = "head";
			this.head.Size = new System.Drawing.Size(25, 25);
			this.head.TabIndex = 1;
			this.head.Text = "head";
			this.head.Click += new System.EventHandler(this.HeadClick);
			// 
			// Move
			// 
			this.Move.Enabled = true;
			this.Move.Interval = 1;
			this.Move.Tick += new System.EventHandler(this.Move_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 603);
			this.Controls.Add(this.food);
			this.Controls.Add(this.head);
			this.Name = "MainForm";
			this.Text = "key";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label food;
		private System.Windows.Forms.Timer Move;
		private System.Windows.Forms.Label head;
	}
}
