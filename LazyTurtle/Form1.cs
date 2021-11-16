using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LazyTurtle
{
	public partial class Form1 : Form
	{
		Direction turtleDirect = Direction.Up; // turtle starting direction
		Point currPoint = new Point(59, 53); // this just has to match the turtle's starting point in the designer. It's auto-generated
		Point turtPoint = new Point(0, 0); // turtle starting point
		string map = ""; // the map string
		public List<Point> coordList = new List<Point>(); // control based coordinates
		public List<Point> turtleCoords = new List<Point>(); // turtle based coordinates
		public List<Point> crossPoints = new List<Point>(); // points that have been crossed more than once
		Dictionary<Point, Point> coordTrans = new Dictionary<Point,Point>(); // a way to convert turtle coordinates to turtle coordinates (buggy?)
		int i = 0; // our incrementer for turtle instructions

		enum Direction
		{
			Up,
			Down,
			Left,
			Right
		}

		protected override CreateParams CreateParams // This helps winforms render faster
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | 0x2000000;
				return cp;
			}
		}

		void Reset()
		{
			Application.Restart(); // too many variables to reset, this is easier
		}

		public Form1()
		{
			InitializeComponent();

			var loc = grid.GetCellPosition(turtle);
			currPoint = new Point(loc.Column, loc.Row); // get control coordinates set in designer

			coordList.Add(new Point(currPoint.X, currPoint.Y)); // add starting control point
			turtleCoords.Add(new Point(0, 0)); // add turtle starting point
			turtle.BackColor = Color.CornflowerBlue; // shes swimming!
			grid.CellPaint += Grid_CellPaint; // our method to colorize the grid
			turtle.Focus(); // this will always keep the turtle in view

		}

		private void Grid_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			Point p = new Point(e.Column, e.Row); // the cell we're working on
			int cnt = 0;
			bool colored = false;

			if (coordTrans.ContainsKey(p)) // this should translate control point to turtle point, but may not work fully due to designer bugs?
			{
				p = coordTrans[p];
				cnt = crossPoints.Where(s => s == p).Count(); // get the number of times this turtle point has been recorded
			}

			if (cnt > 11) // higher colors will overwrite lower colors.
			{
				e.Graphics.FillRectangle(Brushes.Magenta, e.CellBounds);
				colored = true;
			}
			else if (cnt > 10) 
			{
				e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds);
				colored = true;
			}
			else if (cnt > 9) 
			{
				e.Graphics.FillRectangle(Brushes.DarkOrange, e.CellBounds);
				colored = true;
			}
			else if (cnt > 8) 
			{
				e.Graphics.FillRectangle(Brushes.Crimson, e.CellBounds);
				colored = true;
			}
			else if (cnt > 7)
			{
				e.Graphics.FillRectangle(Brushes.Maroon, e.CellBounds);
				colored = true;
			}
			else if (cnt > 6)
			{
				e.Graphics.FillRectangle(Brushes.MediumOrchid, e.CellBounds);
				colored = true;
			}
			else if (cnt > 5)
			{
				e.Graphics.FillRectangle(Brushes.MediumOrchid, e.CellBounds);
				colored = true;
			}
			else if (cnt > 4)
			{
				e.Graphics.FillRectangle(Brushes.MediumSlateBlue, e.CellBounds);
				colored = true;
			}
			else if (cnt > 3)
			{
				e.Graphics.FillRectangle(Brushes.RoyalBlue, e.CellBounds);
				colored = true;
			}
			else if (cnt > 2)
			{
				e.Graphics.FillRectangle(Brushes.Teal, e.CellBounds);
				colored = true;
			}
			else if (cnt > 1)
			{
				e.Graphics.FillRectangle(Brushes.LightSeaGreen, e.CellBounds);
				colored = true;
			}
			else if (cnt > 0)
			{
				e.Graphics.FillRectangle(Brushes.Turquoise, e.CellBounds);
				colored = true;
			}

			if (colored) // if its been multi-colored we stop here
				return;

			foreach (Point c in coordList) // otherwise we use default path color
				if (e.Column == c.X && e.Row == c.Y)
					e.Graphics.FillRectangle(Brushes.PaleTurquoise, e.CellBounds);

		}

		private void aboutBTN_Click(object sender, EventArgs e)
		{
			About a = new About();
			a.Show();
		}

		void RightTurn()
		{
			Image img = turtle.Image;
			img.RotateFlip(RotateFlipType.Rotate90FlipNone);
			turtle.Image = img;
			Direction old = turtleDirect; // track old direction so we know new direction in 1 move
			switch (old)
			{
				case Direction.Up:
					turtleDirect = Direction.Right;
					break;
				case Direction.Right:
					turtleDirect = Direction.Down;
					break;
				case Direction.Left:
					turtleDirect = Direction.Up;
					break;
				case Direction.Down:
					turtleDirect = Direction.Left;
					break;
			}
			
		}

		void LeftTurn()
		{
			Image img = turtle.Image;
			img.RotateFlip(RotateFlipType.Rotate270FlipNone); // flipping wasn't working so I used this
			turtle.Image = img;
			Direction old = turtleDirect;
			switch (old)
			{
				case Direction.Up:
					turtleDirect = Direction.Left;
					break;
				case Direction.Right:
					turtleDirect = Direction.Up;
					break;
				case Direction.Left:
					turtleDirect = Direction.Down;
					break;
				case Direction.Down:
					turtleDirect = Direction.Right;
					break;
			}
		}

	

		void MoveForward()
		{
			grid.SuspendLayout(); // prevents grid flicker
			switch (turtleDirect) // move forward one space in direction turtle is facing
			{
				case Direction.Up:
					grid.Controls.Remove(turtle);
					grid.Controls.Add(turtle, currPoint.X, currPoint.Y - 1); // it seems our control is vertically backwards
					currPoint = new Point(currPoint.X, currPoint.Y - 1); // currPoint is supposed to match the control
					break;
				case Direction.Right:
					grid.Controls.Remove(turtle);
					grid.Controls.Add(turtle, currPoint.X + 1, currPoint.Y); // seems straightforward
					currPoint = new Point(currPoint.X + 1, currPoint.Y);
					break;
				case Direction.Left:
					grid.Controls.Remove(turtle);
					grid.Controls.Add(turtle, currPoint.X - 1, currPoint.Y); // same
					currPoint = new Point(currPoint.X - 1, currPoint.Y);
					break;
				case Direction.Down:
					grid.Controls.Remove(turtle);
					grid.Controls.Add(turtle, currPoint.X, currPoint.Y + 1); // backwards again
					currPoint = new Point(currPoint.X, currPoint.Y + 1);
					break;
			}

			coordList.Add(currPoint); // list of all control coordinates turtle has been



			Point last = turtleCoords.Last(); // now we track our turtle coordinates seperately to add to list
		
			switch (turtleDirect)
			{
				case Direction.Up:
					turtPoint = new Point(turtPoint.X, turtPoint.Y + 1); // not inverted
					break;
				case Direction.Right:
					turtPoint = new Point(turtPoint.X + 1, turtPoint.Y);
					break;
				case Direction.Left:
					turtPoint = new Point(turtPoint.X - 1, turtPoint.Y);
					break;
				case Direction.Down:
					turtPoint = new Point(turtPoint.X, turtPoint.Y - 1);
					break;
			}

			if (!coordTrans.ContainsKey(currPoint)) // our dictionary for control -> turtle coordinate lookups
				coordTrans.Add(currPoint, turtPoint);

			turtleCoords.Add(turtPoint); // keep a seperate turtle coordinate list

			if (turtleCoords.Where(s => s == turtPoint).Count() > 1) // if the turtle has passed its own coordinates twice, we add it to the list
			{
				crossPoints.Add(turtPoint);
				crossnumLBL.Text = crossPoints.Count.FormatNumber(); // this is the form control that displays overlaps in realtime and you can click it to get the values.
			}
			
			coordTXT.Text = "(" + turtPoint.X + ", " + turtPoint.Y + ")"; // nice to see realtime coordinates
			grid.ResumeLayout(); // grid only flickers on movement
		}


		private void loadmapBTN_Click(object sender, EventArgs e)
		{
			if (loadmapBTN.Checked) // Track loading with the checkbox, reset if its already loaded
				Reset();
			else
			{
				if (ofd.ShowDialog() == DialogResult.OK) // We load our map here. No error checking so hopefully its a good map.
				{
					loadmapBTN.Checked = true;
					maploadedTXT.Text = ofd.SafeFileName;
					beginBTN.Enabled = true;
					map = File.ReadAllText(ofd.FileName); // easiest way to do it

					// Give the user time to examine things, maybe select speed which can still be changed while running
					if (MessageBox.Show("Would you like to start your journey now? Or you can start from the File Menu.", "Map Loaded", MessageBoxButtons.YesNo) == DialogResult.Yes)
						beginBTN_Click(null, null);
				}
				else // If the map load was not sucessful
				{
					loadmapBTN.Checked = false;
					beginBTN.Enabled = false;
					maploadedTXT.Text = "No Map Loaded";
					map = "";
				}
			}
		}

		
		private void beginBTN_Click(object sender, EventArgs e) // The main loop
		{
			beginBTN.Enabled = false;
			foreach (char c in map)
			{
				i++;
				if (c == 'L')
				{
					LeftTurn();
					if (!lazFast.Checked) // Our speed feature in action
					{
						if (lazSlow.Checked)
							Thread.Sleep(140);
						else if (lazMed.Checked)
							Thread.Sleep(20);
						Application.DoEvents();
					}
				}
				else if (c == 'R')
				{
					RightTurn();
					if (!lazFast.Checked)
					{
						if (lazSlow.Checked)
							Thread.Sleep(140);
						else if (lazMed.Checked)
							Thread.Sleep(20);
						Application.DoEvents();
					}
				}
				else if (c == 'F')
				{
					MoveForward();
					if (!lazFast.Checked)
					{
						if (lazSlow.Checked)
							Thread.Sleep(140);
						else if (lazMed.Checked)
							Thread.Sleep(20);
						Application.DoEvents();
					}
					turtle.Focus();
				}

				// All stats updated in realtime
				
				pctLBL.Text = i + "/" + map.Length.ToString() + "   " + Math.Round(((i / (decimal)map.Length) * 100),2) + "%";
				progBar2.Value = (int)Math.Round(((int)i / (decimal)map.Length) * 100, 0);
				Application.DoEvents();
				Application.DoEvents();
			}

			
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			turtle.Select(); // make sure its visible when the form is shown
		}

		private void showPointsBTN_Click(object sender, EventArgs e) // Show the overlapping points in a separate window
		{
			string points = crossPoints.Select(s => "(" + s.X + ", " + s.Y + ")").ToArray().Delimit(" ");
			PassedPoints pp = new PassedPoints(crossPoints.Count, points);
			pp.ShowDialog();
		}

		private void lazSlow_Click(object sender, EventArgs e) // We use one handler for all the speed changes.
		{
			var item = sender as ToolStripMenuItem;
			if (item == lazSlow && lazSlow.Checked)
				return;
			else
			{
				lazSlow.Checked = true;
				lazFast.Checked = false;
				lazMed.Checked = false;
			}
			if (item == lazFast)
			{
				lazFast.Checked = true;
				lazSlow.Checked = false;
				lazMed.Checked = false;
			}
			else if (item == lazMed)
			{
				lazMed.Checked = true;
				lazSlow.Checked = false;
				lazFast.Checked = false;
			}
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Reset(); // Run it again!
		}
	}
}
