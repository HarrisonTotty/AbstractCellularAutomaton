using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace CellularAutomaton
{
    public class Grid : Chart
    {
        /// <summary>
        /// The private (actual) boolean describing if we are in high defintion rendering mode.
        /// </summary>
        private bool HighDefinition_Field = true;

        ///// <summary>
        ///// The private int for XIndex
        ///// </summary>
        //public int XIndex_Field = 0;

        ///// <summary>
        ///// The private int for YIndex
        ///// </summary>
        //private int YIndex_Field = 1;

        ///// <summary>
        ///// The private int for YIndex
        ///// </summary>
        //private int ZIndex_Field = 2;

        /// <summary>
        /// The previously clicked location used for drag-pan
        /// </summary>
        private int[] DragPanPreviousClickLocation_Field;

        ///// <summary>
        ///// Represents the index of a position vector to pull the x-axis value from (default: 0)
        ///// </summary>
        //public int XIndex
        //{
        //    get
        //    {
        //        return this.XIndex_Field;
        //    }
        //    set
        //    {
        //        this.XIndex_Field = value;
        //    }
        //}

        ///// <summary>
        ///// Represents the index of a position vector to pull the y-axis value from (default: 1)
        ///// </summary>
        //public int YIndex
        //{
        //    get
        //    {
        //        return this.YIndex_Field;
        //    }
        //    set
        //    {
        //        this.YIndex_Field = value;
        //    }
        //}

        ///// <summary>
        ///// Represents the index of a position vector to pull the z-axis value from (default: 2)
        ///// </summary>
        //public int ZIndex
        //{
        //    get
        //    {
        //        return this.ZIndex_Field;
        //    }
        //    set
        //    {
        //        this.ZIndex_Field = value;
        //    }
        //}

        public static Color[] StateColors = new Color[] { Color.Black, Color.Purple, Color.Violet, Color.Blue, SystemColors.Desktop, Color.LightBlue, Color.Cyan, Color.Green, Color.GreenYellow, Color.Yellow, Color.Orange, Color.OrangeRed, Color.Red, Color.DarkRed };

        /// <summary>
        /// If set to true, the grid will pan (or rotate around the origin if in 3D mode) when the user clicks and drags the mouse.
        /// </summary>
        public bool DragPan
        {
            get;
            set;
        }

        /// <summary>
        /// If set to true, the grid will zoom in and out when the mouse wheel is scrolled.
        /// </summary>
        public bool MouseWheelZoom
        {
            get;
            set;
        }

        /// <summary>
        /// Whether we are in the middle of a panning operation.
        /// </summary>
        private bool Panning;

        ///// <summary>
        ///// Represents a vector for the position of the camera in world coordinates
        ///// </summary>
        //public double[] CameraPosition
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// Represents the current dirction of the camera in degrees.
        ///// </summary>
        //public double[] CameraOrientation
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Creates a new chart with the default settings.
        /// </summary>
        public Grid()
        {
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Palette = ChartColorPalette.None;
            this.PaletteCustomColors = StateColors;
            this.HighDefinition = false;
            this.ClearChartComponents();

            //Intialize the grid
            Reinitialize();

            //Handle some events
            this.MouseWheel += VisualizationGrid_MouseWheel;
            this.PreviewKeyDown += VisualizationGrid_PreviewKeyDown;
            this.MouseDown += VisualizationGrid_MouseDown;
            this.MouseUp += VisualizationGrid_MouseUp;
            this.MouseMove += VisualizationGrid_MouseMove;
        }

        /// <summary>
        /// Reinitializes the grid to its default settings.
        /// </summary>
        public void Reinitialize()
        {
            //SETUP PREMADE SETTINGS
            this.Name = "Grid";
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.ClearChartComponents();
            this.Titles.Add(new Title("Generation 0"));
            base.Series.Add(new Series());
            this.ChartAreas.Add(new ChartArea());
            this.Series[0].ChartArea = this.ChartArea.Name;

            //Add additional series
            for (int i = 0; i < StateColors.Length; i++)
            {
                base.Series.Add(new Series() { Color = StateColors[i], ChartArea = this.ChartArea.Name });
            }

            //SETUP CUSTOM SETTINGS
            //this.XIndex = 0;
            //this.YIndex = 1;
            //this.ZIndex = 2;
            this.DragPan = true;
            this.Panning = false;
            this.GridSize = 100;
            this.MouseWheelZoom = true;
            this.Origin = new double[] { 0, 0 };
            //this.CameraPosition = new double[] { 0, 0, -100 };
            //this.CameraOrientation = new double[3];
            //this.FOV = 90;
            //this.Point3DCameraToOrigin();
        }

        ///// <summary>
        ///// The GenerationTimer of view of the camera in degrees (default: 90).
        ///// Can be a value between 0 and 180.
        ///// </summary>
        //public double FOV
        //{
        //    get;
        //    set;
        //}

        private double[] Origin_Field = { 0, 0 };

        /// <summary>
        /// A vector representing the relative origin (center) of the visualization grid.
        /// DO NOT MANUALLY SET THIS VALUE (use SetOrigin).
        /// </summary>
        public double[] Origin
        {
            get
            {
                return this.Origin_Field;
            }
            set
            {
                //Set the new origin
                this.Origin_Field = value;
                //Adjust the maximum and minimum values around the new origin
                this.ChartArea.AxisX.Maximum = value[0] + this.GridSize / 2;
                this.ChartArea.AxisX.Minimum = value[0] - this.GridSize / 2;
                this.ChartArea.AxisY.Maximum = value[1] + this.GridSize / 2;
                this.ChartArea.AxisY.Minimum = value[1] - this.GridSize / 2;
            }
        }

        private double GridSize_Field = 100;

        /// <summary>
        /// Represents the size of this grid.
        /// </summary>
        public double GridSize
        {
            get
            {
                return this.GridSize_Field;
            }
            set
            {
                this.ChartArea.AxisX.Maximum = this.Origin[0] + System.Math.Abs(value / 2);
                this.ChartArea.AxisX.Minimum = this.Origin[0] - System.Math.Abs(value / 2);
                this.ChartArea.AxisX.MajorGrid.Interval = (this.ChartArea.AxisX.Maximum - this.ChartArea.AxisX.Minimum) / 20;
                this.ChartArea.AxisY.Maximum = this.Origin[1] + System.Math.Abs(value / 2);
                this.ChartArea.AxisY.Minimum = this.Origin[1] - System.Math.Abs(value / 2);
                this.ChartArea.AxisY.MajorGrid.Interval = (this.ChartArea.AxisY.Maximum - this.ChartArea.AxisY.Minimum) / 20;
                this.GridSize_Field = System.Math.Abs(value);
            }
        }

        ///// <summary>
        ///// Points the 3D camera toward the relative origin from its current position.
        ///// </summary>
        //public void Point3DCameraToOrigin()
        //{
        //    //The unit vector that points from our camera to the origin is found by subtracting their position vectors and grabbing the direction
        //    this.CameraOrientation = Orientation3DFromDirection(VectorDirection(VectorSubtract(this.Origin,this.CameraPosition)));
        //}

        ///// <summary>
        ///// Obtains an orientation from a particular unit vector direction (disreguards roll).
        ///// </summary>
        ///// <param name="DirectionUnitVector">The 3D unit vector corresponding to a direction</param>
        //public static double[] Orientation3DFromDirection(double[] DirectionUnitVector)
        //{
        //    if (DirectionUnitVector.Length != 3) throw new Exception("Unit vector must be 3-dimensional!");

        //    double[] ReturnOrientation = new double[3];

        //    //ACCORDING TO https://stackoverflow.com/questions/1568568/how-to-convert-euler-angles-to-directional-vector
        //    // x = cos(yaw)*cos(pitch)
        //    // y = sin(yaw)*cos(pitch)
        //    // z = sin(pitch)
        //    //NOTE THAT System.Math USES RADIANS INSTEAD OF DEGREES!!

        //    //pitch = sin^-1(z)
        //    double pitch = System.Math.Asin(DirectionUnitVector[1]);
        //    ReturnOrientation[0] = RadiansToDegrees(pitch);

        //    //yaw = cos^-1(x / cos(pitch)) and yaw = sin^-1(y / cos(pitch))
        //    double yaw = System.Math.Asin(DirectionUnitVector[0] / System.Math.Cos(pitch));
        //    if (DirectionUnitVector[0] > 0 && DirectionUnitVector[2] > 0)
        //    {
        //        ReturnOrientation[1] = RadiansToDegrees(-yaw); //I have no idea why I used a negative yaw...just worked?
        //    }
        //    else if (DirectionUnitVector[0] < 0 && DirectionUnitVector[2] < 0)
        //    {
        //        ReturnOrientation[1] = 180 - RadiansToDegrees(-yaw);
        //    }
        //    else if (DirectionUnitVector[0] >= 0 && DirectionUnitVector[2] <= 0)
        //    {
        //        ReturnOrientation[1] = 180 - RadiansToDegrees(-yaw);
        //    }
        //    else if (DirectionUnitVector[0] <= 0 && DirectionUnitVector[2] >= 0)
        //    {
        //        ReturnOrientation[1] = RadiansToDegrees(-yaw);
        //    }

        //    return ReturnOrientation;
        //}

        ///// <summary>
        ///// Converts an angle in radians to an angle in degrees.
        ///// </summary>
        ///// <param name="Radians">The angle in radians</param>
        //public static double RadiansToDegrees(double Radians)
        //{
        //    return (Radians * (180.0 / System.Math.PI));
        //}

        ///// <summary>
        ///// Calculates the 2D coordinates (B) of a set of translated coordinates (D) given an effective viewer's position (E) using:
        ///// Bx = ((Ez / Dz) * Dx) - Ex
        ///// By = ((Ez / Dz) * Dy) - Ey
        ///// 
        ///// returns null if the object is behind the camera
        ///// </summary>
        ///// <param name="TranslatedCoordinates">The translated coorinates after performing the matrix calculation</param>
        ///// <param name="EffectiveViewerPosition">The effective position of the viewer from the projection plane calculated from the FOV</param>
        //private static double[] TranslatedCoordinatesTo2D(double[] TranslatedCoordinates, double[] EffectiveViewerPosition)
        //{
        //    if (TranslatedCoordinates[2] < 0) return null;

        //    double[] Position2D = new double[]
        //    {
        //        ((EffectiveViewerPosition[2] / TranslatedCoordinates[2]) * TranslatedCoordinates[0]) - EffectiveViewerPosition[0],
        //        ((EffectiveViewerPosition[2] / TranslatedCoordinates[2]) * TranslatedCoordinates[1]) - EffectiveViewerPosition[1],
        //    };

        //    return Position2D;
        //}


        ///// <summary>
        ///// Scales a radius based on the current perspective (converts a 3D radius into a 2D radius).
        ///// Assumes the distance between the particles is > 0.
        ///// </summary>
        ///// <param name="Radius">The radius (size) of the particle to scale</param>
        //public double ScaleRadiusToPerspective(double[] TranslatedPosition3D, double Radius)
        //{
        //    if (TranslatedPosition3D == null) return 0;

        //    //We want to convert the radius into a ratio to a 1x1 grid.
        //    double Distance = TranslatedPosition3D[2];
        //    if (Distance <= 0) return 0;

        //    //Since Cot(45) = 1, if the FOV is 90 degrees, we can skip the Cot function
        //    double Cot;
        //    if (this.FOV == 90)
        //    {
        //        Cot = 1;
        //    }
        //    else
        //    {
        //        Cot = (1.0 / System.Math.Tan(this.FOV / 2.0));
        //    }


        //    double ScaledRadius = Radius * (Cot / Distance);

        //    //If the Scaled radius is > 1, then we will set it to 1
        //    if (ScaledRadius > 1) return 1;

        //    return ScaledRadius;
        //}


        ///// <summary>
        ///// Calculates the effective viewer position from a FOV using the fact that:
        ///// FOV = 2 * tan^-1(1 / Ez)    OR    1 / (tan(FOV / 2)) = Ez
        ///// Assuming 2D varient of the grid is suppressed to size 1
        ///// </summary>
        ///// <param name="FOV">The angle of the FOV in degrees (which will be converted to radians)</param>
        //private static double[] GetEffectiveViewerPositionFromFOV(double FOV)
        //{
        //    //NOTE: IN MY COORDINATE SYSTEM, Z MAY BE Y AND VICE VERSA!!!
        //    double[] ReturnVector = new double[3];

        //    double BottomPart = System.Math.Tan(DegreesToRadians(FOV) / 2.0);

        //    if (BottomPart == 0) return null;

        //    ReturnVector[2] = (1.0 / BottomPart);

        //    return ReturnVector;
        //}

        ///// <summary>
        ///// Obtains the translated coordinates (D) from a 3D position vector (A), camera position (C), and orentation (T).
        ///// </summary>
        ///// <param name="Position3D">The origional 3D position of the object in world coordinates</param>
        ///// <param name="CameraPosition">The position of the camera</param>
        ///// <param name="CameraOrientation">The orientation of the camera</param>
        //private static double[] PerfromMatrixTranslation(double[] Position3D, double[] CameraPosition, double[] CameraOrientation)
        //{
        //    //Calculate Angles
        //    double Sinx = System.Math.Sin(DegreesToRadians(-CameraOrientation[0]));
        //    double Siny = System.Math.Sin(DegreesToRadians(-CameraOrientation[1]));
        //    double Sinz = System.Math.Sin(DegreesToRadians(-CameraOrientation[2]));
        //    double Cosx = System.Math.Cos(DegreesToRadians(-CameraOrientation[0]));
        //    double Cosy = System.Math.Cos(DegreesToRadians(-CameraOrientation[1]));
        //    double Cosz = System.Math.Cos(DegreesToRadians(-CameraOrientation[2]));

        //    //Calculate the components of (A - C)
        //    double X = Position3D[0] - CameraPosition[0];
        //    double Y = Position3D[1] - CameraPosition[1];
        //    double Z = Position3D[2] - CameraPosition[2];

        //    //Translate the coordinates
        //    double[] Translated = new double[3];

        //    //Dx = (Cosy * ((Sinz * Y) + (Cosz * X))) - (Siny * Z)
        //    Translated[0] = (Cosy * ((Sinz * Y) + (Cosz * X))) - (Siny * Z);

        //    //Dy = (Sinx * ((Cosy * Z) + (Siny * ((Sinz * Y) + (Cosz * X))))) + (Cosx * ((Cosz * Y) - (Sinz * X)))
        //    double FirstPart = (Cosy * Z) + (Siny * ((Sinz * Y) + (Cosz * X)));
        //    double SecondPart = (Cosz * Y) - (Sinz * X);
        //    Translated[1] = (Sinx * FirstPart) + (Cosx * SecondPart);

        //    //Dz = (Cosx * ((Cosy * Z) + (Siny * ((Sinz * Y) + (Cosz * X))))) - (Sinx * ((Cosz * Y) - (Sinz * X)))
        //    Translated[2] = (Cosx * FirstPart) - (Sinx * SecondPart);

        //    return Translated;
        //}

        ///// <summary>
        ///// Converts an angle in degrees to an angle in radians.
        ///// </summary>
        ///// <param name="Degrees">The angle in degrees</param>
        //public static double DegreesToRadians(double Degrees)
        //{
        //    return (Degrees * (System.Math.PI / 180.0));
        //}

        /// <summary>
        /// Gets or sets the series used by this visualization grid.
        /// </summary>
        public new Series[] Series
        {
            get
            {
                if (base.Series != null && base.Series.Count > 0) return base.Series.Cast<Series>().ToArray();
                else return null;
            }
        }

        /// <summary>
        /// Gets or sets the primary chart area used by this visualization grid.
        /// </summary>
        public ChartArea ChartArea
        {
            get
            {
                if (base.ChartAreas != null && base.ChartAreas.Count > 0) return base.ChartAreas[0] as ChartArea;
                else return null;
            }

            set
            {
                if (base.ChartAreas != null && base.ChartAreas.Count > 0) base.ChartAreas[0] = value;
                else base.ChartAreas.Add(value);
            }
        }

        /// <summary>
        /// Paused that handles the mouse moving across the visualization grid
        /// </summary>
        void VisualizationGrid_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If we are panning:
            if (this.DragPan && this.Panning)
            {
                try
                {
                    //Find the coordinates of the new location
                    int[] NewClickLocation = new int[2] { e.Location.X, e.Location.Y };

                    //Calculate the change in location
                    int ClickChangeX = NewClickLocation[0] - DragPanPreviousClickLocation_Field[0];
                    int ClickChangeY = NewClickLocation[1] - DragPanPreviousClickLocation_Field[1];
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Event that handles the mouse button being released on the visualization grid
        /// </summary>
        void VisualizationGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.DragPan && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Panning = false;
            }
        }

        /// <summary>
        /// Event that handles the mouse button being pressed down the visualization grid
        /// </summary>
        void VisualizationGrid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.DragPan && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Panning = true;
                DragPanPreviousClickLocation_Field = new int[2] { e.Location.X, e.Location.Y };
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

            }
        }

        ///// <summary>
        ///// Handles button presses for when the chart is in 3D mode
        ///// </summary>
        //private void Handle3DButtonPress(System.Windows.Forms.Keys KeyPress)
        //{
        //    //switch (KeyPress)
        //    //{
        //    //    //Toggle point mode
        //    //    case System.Windows.Forms.Keys.P:
        //    //        if (this.Series.PointMode)
        //    //        {
        //    //            this.Series.PointMode_OFF();
        //    //        }
        //    //        else
        //    //        {
        //    //            this.Series.PointMode_ON();
        //    //        }
        //    //        break;

        //    //    //Rotate the camera
        //    //    case System.Windows.Forms.Keys.Right:
        //    //        RotateCameraAroundOrigin(10, false);
        //    //        break;
        //    //    case System.Windows.Forms.Keys.Left:
        //    //        RotateCameraAroundOrigin(-10, false);
        //    //        break;
        //    //    case System.Windows.Forms.Keys.Up:
        //    //        RotateCameraAroundOrigin(10, true);
        //    //        break;
        //    //    case System.Windows.Forms.Keys.Down:
        //    //        RotateCameraAroundOrigin(-10, true);
        //    //        break;

        //    //    //Zoom camera if needed
        //    //    case System.Windows.Forms.Keys.Oemplus:
        //    //        CameraZoomToOrigin(-10);
        //    //        break;
        //    //    case System.Windows.Forms.Keys.OemMinus:
        //    //        CameraZoomToOrigin(10);
        //    //        break;
        //    //}
        //}

        ///// <summary>
        ///// Rotates the 3D camera about the origin given a particular angle and direction
        ///// </summary>
        ///// <param name="Angle">The angle to rotate</param>
        ///// <param name="IsVertical">Whether the rotation is vertical or not</param>
        //public void RotateCameraAroundOrigin(double Angle, bool IsVertical)
        //{
        //    // Via https://stackoverflow.com/questions/3162643/proper-trigonometry-for-rotating-a-point-around-the-origin
        //    // xnew = xcos(angle) - ysin(angle)
        //    // ynew = xsin(angle) + ycos(angle)

        //    if (Angle == 0) return;
        //    double cosangle = System.Math.Cos(DegreesToRadians(Angle));
        //    double sinangle = System.Math.Sin(DegreesToRadians(Angle));

        //    //If we are moving vertically
        //    if (IsVertical)
        //    {
        //        int xindex = 2;
        //        int yindex = 1;

        //        double xnew = (this.CameraPosition[xindex] * cosangle) - (this.CameraPosition[yindex] * sinangle);
        //        double ynew = (this.CameraPosition[xindex] * sinangle) + (this.CameraPosition[yindex] * cosangle);

        //        this.CameraPosition[xindex] = xnew;
        //        this.CameraPosition[yindex] = ynew;
        //    }
        //    else //Otherwise, if we are moving horizontally
        //    {
        //        int xindex = 2;
        //        int yindex = 0;

        //        double xnew = (this.CameraPosition[xindex] * cosangle) - (this.CameraPosition[yindex] * sinangle);
        //        double ynew = (this.CameraPosition[xindex] * sinangle) + (this.CameraPosition[yindex] * cosangle);

        //        this.CameraPosition[xindex] = xnew;
        //        this.CameraPosition[yindex] = ynew;
        //    }

        //    //Now point the camera to the origin
        //    Point3DCameraToOrigin();
        //}

        ///// <summary>
        ///// "Zooms in" the camera toward the origin by physically moving it closer.
        ///// </summary>
        ///// <param name="MoveDistance">The change in percent distance to move (positive for farther away, negative for closer)</param>
        //public void CameraZoomToOrigin(double MoveDistance)
        //{
        //    //Create a new "distance magnitude" that the camera will be at.
        //    this.CameraPosition = SetVectorMagnitude(this.CameraPosition, VectorMagnitude(this.CameraPosition) + (VectorMagnitude(this.CameraPosition) * (MoveDistance / 100)));
        //}

        /// <summary>
        /// Handles various key presses.
        /// </summary>
        public void VisualizationGrid_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            //this.Handle3DButtonPress(e.KeyData);
            switch (e.KeyData)
            {
                //Toggle the grid
                case System.Windows.Forms.Keys.G:
                    this.ChartArea.ToggleGrid();
                    break;

                //Toggle the axes
                case System.Windows.Forms.Keys.A:
                    this.ChartArea.ToggleAxis();
                    break;

                //Toggle point mode
                case System.Windows.Forms.Keys.P:
                    if (this.Series[0].PointMode)
                    {
                        this.Series.AsParallel().ForAll(x => x.PointMode_OFF());
                    }
                    else
                    {
                        this.Series.AsParallel().ForAll(x => x.PointMode_ON());
                    }
                    break;

                //ZOOM IN
                case System.Windows.Forms.Keys.Oemplus:
                    this.GridSize = (this.GridSize - (this.GridSize * 0.1));
                    break;

                //ZOOM OUT
                case System.Windows.Forms.Keys.OemMinus:
                    this.GridSize = (this.GridSize + (this.GridSize * 0.1));
                    break;

                //MOVE LEFT
                case System.Windows.Forms.Keys.Left:
                    double[] NewOrgL = (double[])this.Origin.Clone();
                    NewOrgL[0] -= ((this.GridSize / 2) * 0.1);
                    this.Origin = NewOrgL;
                    break;

                //MOVE RIGHT
                case System.Windows.Forms.Keys.Right:
                    double[] NewOrgR = (double[])this.Origin.Clone();
                    NewOrgR[0] += ((this.GridSize / 2) * 0.1);
                    this.Origin = NewOrgR;
                    break;

                //MOVE UP
                case System.Windows.Forms.Keys.Up:
                    double[] NewOrgU = (double[])this.Origin.Clone();
                    NewOrgU[1] += ((this.GridSize / 2) * 0.1);
                    this.Origin = NewOrgU;
                    break;

                //MOVE DOWN
                case System.Windows.Forms.Keys.Down:
                    double[] NewOrgD = (double[])this.Origin.Clone();
                    NewOrgD[1] -= ((this.GridSize / 2) * 0.1);
                    this.Origin = NewOrgD;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Handles zooming of the grid via mouse wheel when enabled.
        /// </summary>
        void VisualizationGrid_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If zooming is enabled:
            if (this.MouseWheelZoom)
            {
                double ZoomPercent = System.Math.Abs(e.Delta) * 0.001;
                
                //If the wheel was moved forward:
                if (e.Delta > 0)
                {
                    //ZOOM IN
                    this.GridSize = (this.GridSize - (this.GridSize * ZoomPercent));

                }
                else //Otherwise if the wheel was moved backward:
                {
                    //ZOOM OUT
                    this.GridSize = (this.GridSize + (this.GridSize * ZoomPercent));
                }
            }
        }

        ///// <summary>
        ///// Sets the origin of the grid to a particular value.
        ///// </summary>
        ///// <param name="Origin">The vector corresponding to the new origin of the visualization grid</param>
        //public void SetOrigin(double[] Origin)
        //{
        //    ////Determine the vector the camera was from the old origin
        //    //double[] Vec = VectorSubtract(this.CameraPosition, this.Origin);
        //    ////Set the new origin
        //    //this.Origin = Origin;
        //    ////Change the camera's position to be the "Vec.Magnitude" units from the new origin in direction "Vec.Direction"
        //    //this.CameraPosition = VectorAdd(this.Origin, Vec);
        //    ////Point the camera to the new origin
        //    //this.Point3DCameraToOrigin();
        //}

        ///// <summary>
        ///// Projects a 3D position into the current 2D scene (Gets the equivelant 2D coordinates of a 3D position).
        ///// Returns null if the position cannot be converted (object was behind camera, etc).
        ///// Also returns the scaled radius as an additional term in the vector.
        ///// </summary>
        //public double[] ProjectTo2D(double[] Position3D, double Radius)
        //{
        //    //Determine if the particle has the appropriate capacity
        //    if (Position3D.Length < 3) return null;

        //    //Single out the components that will represent X, Y, and Z in our projection
        //    double[] Vec3 = new double[3];
        //    try
        //    {
        //        Vec3[0] = Position3D[this.XIndex];
        //        Vec3[1] = Position3D[this.YIndex];
        //        Vec3[2] = Position3D[this.ZIndex];
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    //Determine the distance from the camera to the particle and return null if they are at the same position
        //    double[] DistanceToParticle = VectorSubtract(Vec3, this.CameraPosition);
        //    if (VectorMagnitude(DistanceToParticle) == 0) return null;

        //    //Transform the coordinates using the rotational matrix
        //    double[] Translated = PerfromMatrixTranslation(Vec3, this.CameraPosition, this.CameraOrientation);
        //    if (Translated == null) return null;

        //    //Obtain the effective viewer position from the FOV
        //    double[] EffectiveViewerPos = GetEffectiveViewerPositionFromFOV(this.FOV);
        //    if (EffectiveViewerPos == null) return null;

        //    //Project the translated coordinates into 2D
        //    double[] Position2D = TranslatedCoordinatesTo2D(Translated, EffectiveViewerPos);
        //    if (Position2D == null) return null;

        //    //Scale the Radius
        //    double[] ReturnVec = new double[3];
        //    double NewRadius = ScaleRadiusToPerspective(Translated, Radius);
        //    ReturnVec[0] = Position2D[0];
        //    ReturnVec[1] = Position2D[1];
        //    ReturnVec[2] = NewRadius;

        //    //Return the 2D coordinates + Radius
        //    return ReturnVec;
        //}

        /// <summary>
        /// Gets/sets whether this chart is in high definition.
        /// </summary>
        public bool HighDefinition
        {
            get
            {
                return this.HighDefinition_Field;
            }
            set
            {
                if (value == true)
                {
                    this.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                    this.AntiAliasing = AntiAliasingStyles.All;
                }
                else
                {
                    this.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
                    this.AntiAliasing = AntiAliasingStyles.None;
                }
                this.HighDefinition_Field = value;
            }
        }

        /// <summary>
        /// Clears the chart of all series, annotations, titles, legends, and chart areas.
        /// </summary>
        public void ClearChartComponents()
        {
            base.Series.Clear();
            this.Annotations.Clear();
            base.Titles.Clear();
            base.ChartAreas.Clear();
            base.Legends.Clear();
        }

        /// <summary>
        /// Converts a particular particle's radius to the specified marker size at the current scale.
        /// </summary>
        /// <param name="ParticleRadius">The radius (size) of the particle to convert</param>
        public int RadiusToMarkerSize_2D(double ParticleRadius)
        {
            //Modified function from Jack of Stack Overflow
            double innerScaleX = this.ChartAreas[0].AxisX.Maximum - this.ChartAreas[0].AxisX.Minimum;
            double innerScaleY = this.ChartAreas[0].AxisY.Maximum - this.ChartAreas[0].AxisY.Minimum;
            double innerScaleAvg = (innerScaleX + innerScaleY) / 2;
            float innerPctX = this.ChartAreas[0].InnerPlotPosition.Width / 100;
            float innerPctY = this.ChartAreas[0].InnerPlotPosition.Height / 100;
            float innerPixelsX = this.Width * innerPctX;
            float innerPixelsY = this.Height * innerPctY;
            float innerPixelsAvg = (innerPixelsX + innerPixelsY) / 2;
            return (int)System.Math.Round((ParticleRadius * 2) / innerScaleAvg * innerPixelsAvg);
        }

        ///// <summary>
        ///// Plots all of the cells of a single automaton.
        ///// </summary>
        ///// <param name="Automaton">The automaton to plot</param>
        //public void PlotAutomaton3D(Automaton Automaton)
        //{
        //    ////Clear the top list of particles
        //    //this.Series.Points.Clear();

        //    ////Store all of the DataPoints
        //    //List<DataPoint> PointList = new List<DataPoint>();

        //    ////If we are in point mode:
        //    //if (this.Series.PointMode)
        //    //{
        //    //    //For each particle:
        //    //    Parallel.ForEach(Automaton.Grid, C =>
        //    //    {
        //    //        //We don't care about cells with state 0
        //    //        if (C.State != 0)
        //    //        {

        //    //            //We don't care about size
        //    //            double[] PerspectivePosition = ProjectTo2D(Automaton[C].Select(x => (double)x - (Automaton.Size/ 2)).ToArray(), 0.2);
        //    //            if (PerspectivePosition == null) return;

        //    //            DataPoint newpoint = new DataPoint(PerspectivePosition[0], PerspectivePosition[1], this.Series.MarkerSize);
        //    //            lock (PointList)
        //    //            {
        //    //                PointList.Add(newpoint);
        //    //            }
        //    //        }
        //    //    });
        //    //}
        //    //else //Otherwise if we aren't in point mode:
        //    //{
        //    //    //For each particle:
        //    //    Parallel.ForEach(Automaton.Grid, C =>
        //    //    {
        //    //        //We don't care about cells with state 0
        //    //        if (C.State != 0)
        //    //        {
        //    //            //Obtain the 2D projected coordinates
        //    //            double[] Results = ProjectTo2D(Automaton[C].Select(x => (double)x - (Automaton.Size / 2)).ToArray(), 0.2);
        //    //            if (Results == null) return;
        //    //            double[] PerspectivePosition = new double[2];
        //    //            PerspectivePosition[0] = Results[0];
        //    //            PerspectivePosition[1] = Results[1];

        //    //            //Obtain the size of the particle
        //    //            double PerspectiveRadius = Results[2];
        //    //            if (PerspectiveRadius <= 0) return;

        //    //            //Continue plotting the new perspective particle as if it were 2D
        //    //            int EffectiveRadius = RadiusToMarkerSize_2D(PerspectiveRadius);
        //    //            if (EffectiveRadius <= 0) return;
        //    //            DataPoint newpoint = new DataPoint(PerspectivePosition[0], PerspectivePosition[1], EffectiveRadius);
        //    //            lock (PointList)
        //    //            {
        //    //                PointList.Add(newpoint);
        //    //            }
        //    //        }
        //    //    });

        //    //}

        //    //foreach (DataPoint x in PointList)
        //    //{
        //    //    this.Series.Points.Add(x);
        //    //}
        //}



        /// <summary>
        /// Gets/sets the primary (first) title of this chart.
        /// </summary>
        public Title Title
        {
            get
            {
                if (this.Titles != null && this.Titles.Count > 0) return this.Titles[0];
                else return null;
            }

            set
            {
                if (this.Titles != null && this.Titles.Count > 0) this.Titles[0] = value;
                else this.Titles.Add(value);
            }
        }

        public static double VectorMagnitude(double[] Vector)
        {
            double Summation = 0;
            for (int i = 0; i < Vector.Length; i++)
            {
                Summation += Vector[i] * Vector[i];
            }
            return System.Math.Sqrt(Summation);
        }

        public static double[] SetVectorMagnitude(double[] Vector, double Magnitude)
        {
            double[] NewV = new double[Vector.Length];
            double[] MyDirection = VectorDirection(Vector);
            for (int i = 0; i < Vector.Length; i++)
            {
                NewV[i] = MyDirection[i] * Magnitude;
            }
            return NewV;
        }

        public static double[] VectorDirection(double[] Vector)
        {
            double[] DirectionVector = new double[Vector.Length];

            //Get the magnitude
            double Summation = 0;
            for (int i = 0; i < Vector.Length; i++)
            {
                Summation += Vector[i] * Vector[i];
            }
            double MyMag = System.Math.Sqrt(Summation);

            //Get the direction
            for (int i = 0; i < Vector.Length; i++)
            {
                DirectionVector[i] = Vector[i] / MyMag;
            }
            return DirectionVector;
        }


        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        /// <param name="Vector1">The first vector to add</param>
        /// <param name="Vector2">The second vector to add</param>
        public static double[] VectorAdd(double[] Vector1, double[] Vector2)
        {
            if (Vector1.Length != Vector2.Length) throw new Exception("Vectors do not have the same number of dimensions");
            double[] ReturnVector = new double[Vector1.Length];
            for (int i = 0; i < Vector1.Length; i++)
            {
                ReturnVector[i] = Vector1[i] + Vector2[i];
            }
            return ReturnVector;
        }


        /// <summary>
        /// Subracts two vectors from each other (Vector1 - Vector2).
        /// </summary>
        /// <param name="Vector1">The first vector to subtract</param>
        /// <param name="Vector2">The second vector to subtract</param>
        public static double[] VectorSubtract(double[] Vector1, double[] Vector2)
        {
            if (Vector1.Length != Vector2.Length) throw new Exception("Vectors do not have the same number of dimensions");
            double[] ReturnVector = new double[Vector1.Length];
            for (int i = 0; i < Vector1.Length; i++)
            {
                ReturnVector[i] = Vector1[i] - Vector2[i];
            }
            return ReturnVector;
        }

        /// <summary>
        /// Plots the grid of a particular automaton
        /// </summary>
        public void PlotAutomaton(Automaton Automaton)
        {
            //Clear the top list of particles
            this.Series.ToList().ForEach(x => x.Points.Clear());

            //Create a list of points, sorted by series
            List<List<DataPoint>> Points = new List<List<DataPoint>>(this.Series.Length);
            for (int i = 0; i < Points.Capacity; i++)
            {
                Points.Add(new List<DataPoint>());
            }

            //If we are in point mode:
            if (this.Series[0].PointMode)
            {
                //For each particle:
                Parallel.ForEach(Automaton.Grid, C =>
                {
                    //We don't care about cells with state 0
                    if (C.State != 0)
                    {
                        //We don't care about size
                        double[] Position = Automaton[C].Select(x => (double)x).ToArray();

                        DataPoint newpoint = new DataPoint(Position[0], Position[1], this.Series[0].MarkerSize);

                        lock (Points)
                        {
                            if (C.State < Points.Capacity)
                            {
                                Points[C.State - 1].Add(newpoint);
                            }
                            else
                            {
                                Points[Points.Capacity - 1].Add(newpoint);
                            }
                        }
                    }
                });
            }
            else //Otherwise if we aren't in point mode:
            {
                //For each particle:
                Parallel.ForEach(Automaton.Grid, C =>
                {
                    //We don't care about cells with state 0
                    if (C.State != 0)
                    {
                        //We DO care about size
                        double[] Position = Automaton[C].Select(x => (double)x).ToArray();
                        int MarkerSize = RadiusToMarkerSize_2D(0.5);

                        DataPoint newpoint = new DataPoint(Position[0], Position[1], MarkerSize);

                        lock (Points)
                        {
                            if (C.State < Points.Capacity)
                            {
                                Points[C.State - 1].Add(newpoint);
                            }
                            else
                            {
                                Points[Points.Capacity - 1].Add(newpoint);
                            }
                        }
                    }
                });
            }

            //Add the points
            for (int i = 0; i < Points.Capacity; i++)
            {
                Points[i].TrimExcess();
                for (int j = 0; j < Points[i].Count; j++)
                {
                    base.Series[i].Points.Add(Points[i][j]);
                }
            }

            ////Colorize the grid
            //for (int i = 0; i < this.Series.Length; i++)
            //{
            //    if (i < StateColors.Length) this.Series[i].Color = StateColors[i];
            //    else this.Series[i].Color = StateColors[StateColors.Length - 1];
            //}
        }

        /// <summary>
        /// Determines if a 2D position is within the plotted region (is within the current plot grid).
        /// </summary>
        /// <param name="PositionVector">The position of the particle to check</param>
        public bool IsPositionInView_2D(double[] PositionVector)
        {
            double X = PositionVector[0];
            double Y = PositionVector[1];

            if (X < this.ChartArea.AxisX.Minimum || X > this.ChartArea.AxisX.Maximum) return false;
            if (Y < this.ChartArea.AxisY.Minimum || Y > this.ChartArea.AxisY.Maximum) return false;

            return true;
        }

        /// <summary>
        /// Plots a buffered automaton
        /// </summary>
        /// <param name="B"></param>
        public void PlotBuffered(BufferedAutomaton B, int Generation)
        {
            //Clear the top list of particles
            this.Series.ToList().ForEach(x => x.Points.Clear());

            //Get the grid for this generation
            Cell[][] G = B[Generation];

            //Store all of the DataPoints
            List<DataPoint> PointList = new List<DataPoint>();

            //If we are in point mode:
            if (this.Series[0].PointMode)
            {
                //For each row:
                Parallel.For(0, G.Length, R =>
                {
                    for (int C = 0; C < G[R].Length; C++)
                    {
                        //We don't care about cells with state 0
                        if (G[R][C].State != 0)
                        {
                            DataPoint newpoint = new DataPoint(R, C, this.Series[0].MarkerSize);
                            lock (PointList)
                            {
                                PointList.Add(newpoint);
                            }
                        }
                    }
                });
            }
            else //Otherwise if we aren't in point mode:
            {
                int MarkerSize = RadiusToMarkerSize_2D(0.5);
                //For each row:
                Parallel.For(0, G.Length, R =>
                {
                    for (int C = 0; C < G[R].Length; C++)
                    {
                        //We don't care about cells with state 0
                        if (G[R][C].State != 0)
                        {
                            DataPoint newpoint;
                            //if (G[R][C].State - 1 <= StateColors.Length)
                            //{
                            //    newpoint = new DataPoint(R, C, MarkerSize, StateColors[G[R][C].State - 1]);
                            //}
                            //else
                            //{
                            //    newpoint = new DataPoint(R, C, MarkerSize);
                            //}
                            newpoint = new DataPoint(R, C, MarkerSize);
                            lock (PointList)
                            {
                                PointList.Add(newpoint);
                            }
                        }
                    }
                });

            }

            foreach (DataPoint x in PointList)
            {
                this.Series[0].Points.Add(x);
            }
        }
    }
}
