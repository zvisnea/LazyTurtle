using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LazyTurtle
{
	public partial class PassedPoints : Form
	{
		public PassedPoints(int count, string points)
		{
			InitializeComponent();
			pointsTXT.Text = points;
			cntLBL.Text = count.FormatNumber();
			pointsTXT.DeselectAll();
			pointsTXT.ScrollToCaret();
		}

		private void PassedPoints_Load(object sender, EventArgs e)
		{
			pointsTXT.DeselectAll();
			pointsTXT.ScrollToCaret();
			pointsTXT.Select(pointsTXT.TextLength, 0);
		}
	}
}
