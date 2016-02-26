using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton
{
    public class Series : System.Windows.Forms.DataVisualization.Charting.Series
    {
        /// <summary>
        /// Creates a new series to hold data points.
        /// </summary>
        public Series() : base("PrimarySeries")
        {
            this.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            this.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            this.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.PointMode = false;
        }

        /// <summary>
        /// Gets whether point mode is enabled.
        /// </summary>
        public bool PointMode
        {
            get;
            private set;
        }

        /// <summary>
        /// Stylizes the series to plot points without sizes (faster plotting).
        /// </summary>
        public void PointMode_ON()
        {
            this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            this.PointMode = true;
        }

        /// <summary>
        /// Stylizes the series to plot points with sizes (default).
        /// </summary>
        public void PointMode_OFF()
        {
            this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            this.PointMode = false;
        }
    }
}