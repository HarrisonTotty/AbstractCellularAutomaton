using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CellularAutomaton
{
    public class DataPoint : System.Windows.Forms.DataVisualization.Charting.DataPoint
    {
        /// <summary>
        /// Creates a new data point at the specified position with a pre-calculated marker size with default style and theme.
        /// </summary>
        /// <param name="EffectiveX">The x-coordinate of the point cast in 2D coordinates</param>
        /// <param name="EffectiveY">The y-coordinate of the point cast in 2D coordinates</param>
        /// <param name="EffectiveMarkerSize">The pre-calculated effective marker size in pixels</param>
        /// <param name="Color">The color of the marker to draw</param>
        public DataPoint(double EffectiveX, double EffectiveY, int EffectiveMarkerSize, Color Color) : base(EffectiveX, EffectiveY)
        {
            this.MarkerBorderColor = Color.Black;
            this.MarkerBorderWidth = 0;
            this.MarkerSize = EffectiveMarkerSize;
            this.MarkerColor = Color;
            this.Color = Color;
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
        }

        /// <summary>
        /// Creates a new data point at the specified position with a pre-calculated marker size with default style and theme.
        /// </summary>
        /// <param name="EffectiveX">The x-coordinate of the point cast in 2D coordinates</param>
        /// <param name="EffectiveY">The y-coordinate of the point cast in 2D coordinates</param>
        /// <param name="EffectiveMarkerSize">The pre-calculated effective marker size in pixels</param>
        /// <param name="Color">The color of the marker to draw</param>
        public DataPoint(double EffectiveX, double EffectiveY, int EffectiveMarkerSize) : base(EffectiveX, EffectiveY)
        {
            this.MarkerBorderColor = Color.Black;
            this.MarkerBorderWidth = 0;
            this.MarkerSize = EffectiveMarkerSize;
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
        }
    }
}