using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace key
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int X = 228, MAX_X = 456;
		int Y = 235, MAX_Y = 470;
		string Event = "";
		int speed = 2;
		int food_x, food_y;
		int score = 0;
		bool gameOverEvent = true;
		Label[] segment = new Label[0];
		
		
		
		public void SetCircle(Label e) {
			var path = new System.Drawing.Drawing2D.GraphicsPath();
			path.AddEllipse(0, 0, e.Width, e.Height);			
			e.Region = new Region(path);
		}
		
		public void changePos(Label e, int x, int y) {
			e.Location = new Point(x, y);
		}
		
		public void foodPos(Label food, int x, int y) {
			Random rnd = new Random();
			flag: food_x = rnd.Next(MAX_X);
			food_y = rnd.Next(MAX_Y);
			if ((food_x < X+15 && food_x > X-15) && (food_y < Y+15 && food_y > Y-15)) goto flag;
			if ((food_x < x+15 && food_x > x-15) && (food_y < y+15 && food_y > y-15)) goto flag;
			food.Location = new Point(food_x, food_y);
		}
		
		
		public Label createLabel() {
			Label l = new Label();
			l.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			l.Margin = new System.Windows.Forms.Padding(0);
			l.Size = new System.Drawing.Size(20, 20);
			l.Text = "tail";
			l.AutoSize = false;
			this.Controls.Add(l);
			return l;
		}
		
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			Random rnd = new Random();
			
			flag: food_x = rnd.Next(MAX_X);
			food_y = rnd.Next(MAX_Y);
			if ((food_x < X+15 && food_x > X-15) && (food_y < Y+15 && food_y > Y-15)) goto flag;
			
			// circle label
			SetCircle(food);
			changePos(food, food_x, food_y);
			SetCircle(head);
			changePos(head, X, Y);
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
		     if (e.KeyCode == Keys.Enter)
		     {
		     	MessageBox.Show(segment.Length.ToString());
		     }
		     
		     else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
		     {
		     	if (Event != "up") Event = "down";
		     }
		     
		     else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
		     {
		     	if (Event != "down") Event = "up";
		     }
		     
		     else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
		     {
		     	if (Event != "right") Event = "left";
		     }
		     
		     else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
		     {
		     	if (Event != "left") Event = "right";
		     }
		}
		
		void HeadClick(object sender, EventArgs e)
		{
			
		}
		
		void Move_Tick(object sender, EventArgs e)
		{
			if ((0 <= X && X < MAX_X) && (0 <= Y && Y < MAX_Y)) {
				if (Event == "up") {
					Y -= speed;
				}
				else if (Event == "down") {
					Y += speed;
				}
				else if (Event == "right") {
					X += speed;
				}
				else if (Event == "left") {
					X -= speed;
				}
				
				
				for (int i = segment.Length-1; i > 0; i--) {
					changePos(segment[i], segment[i-1].Location.X, segment[i-1].Location.Y);
				}
				if (segment.Length > 0) changePos(segment[0], head.Location.X, head.Location.Y);
				
				head.Location = new Point(X, Y);
				
				int dis = 8;
				if ((X < food_x+dis && X > food_x-dis) && (Y < food_y+dis && Y > food_y-dis)) {
					foodPos(food, food_x, food_y);
					
					Label l = createLabel();
					SetCircle(l);
					segment = segment.Concat(new Label[] {l}).ToArray();
						
					score++;
				}
			}
			else {
				if (gameOverEvent) {
					gameOverEvent = false;
					MessageBox.Show("Your score: " + score.ToString());
				}				
			}
			
			
		}
	}
}
