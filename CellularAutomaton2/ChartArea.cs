using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton
{
    public class ChartArea : System.Windows.Forms.DataVisualization.Charting.ChartArea
    {
        /// <summary>
        /// Creates a new chart area pre-formatted to support 2D rendering.
        /// </summary>
        public ChartArea() : base("PrimaryChartArea")
        {
            this.AxisX.IsLogarithmic = false;
            this.AxisY.IsLogarithmic = false;
            this.AxisX.IsStartedFromZero = false;
            this.AxisY.IsStartedFromZero = false;
            this.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.AxisX.Title = "";
            this.AxisY.Title = "";
            this.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            this.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            this.AxisX.LabelStyle.Enabled = false;
            this.AxisY.LabelStyle.Enabled = false;
            this.AxisX.IsMarginVisible = false;
            this.AxisY.IsMarginVisible = false;
            this.AxisX.MajorGrid.Enabled = true;
            this.AxisX.MinorGrid.Enabled = false;
            this.AxisX.MajorTickMark.Enabled = false;
            this.AxisX.MinorTickMark.Enabled = false;
            this.AxisY.MajorGrid.Enabled = true;
            this.AxisY.MinorGrid.Enabled = false;
            this.AxisX.MajorGrid.Interval = 10;
            this.AxisY.MajorGrid.Interval = 10;
            this.AxisY.MajorTickMark.Enabled = false;
            this.AxisY.MinorTickMark.Enabled = false;
            this.AxisX.Maximum = 100;
            this.AxisX.Minimum = -100;
            this.AxisY.Maximum = 100;
            this.AxisY.Minimum = -100;
        }

        /// <summary>
        /// Toggles the grid lines on and off.
        /// </summary>
        public void ToggleGrid()
        {
            this.AxisX.MajorGrid.Enabled = !this.AxisX.MajorGrid.Enabled;
            this.AxisY.MajorGrid.Enabled = !this.AxisY.MajorGrid.Enabled;
            //this.AxisX.MajorTickMark.Enabled = !this.AxisX.MajorTickMark.Enabled;
            //this.AxisY.MajorTickMark.Enabled = !this.AxisY.MajorTickMark.Enabled;
        }

        /// <summary>
        /// Toggles the axes on and off
        /// </summary>
        public void ToggleAxis()
        {
            this.AxisX.LabelStyle.Enabled = !this.AxisX.LabelStyle.Enabled;
            this.AxisY.LabelStyle.Enabled = !this.AxisY.LabelStyle.Enabled;


            if (this.AxisX.Enabled == System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False)
            {
                this.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            }
            else
            {
                this.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            }

            if (this.AxisY.Enabled == System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False)
            {
                this.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            }
            else
            {
                this.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            }
        }
    }
}