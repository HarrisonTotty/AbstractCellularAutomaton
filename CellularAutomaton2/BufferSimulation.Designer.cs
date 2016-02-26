namespace CellularAutomaton
{
    partial class BufferSimulation
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
            this.components = new System.ComponentModel.Container();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.Status = new System.Windows.Forms.TextBox();
            this.GenLabel = new System.Windows.Forms.Label();
            this.GenCount = new System.Windows.Forms.NumericUpDown();
            this.Buffer = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GenCount)).BeginInit();
            this.SuspendLayout();
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(12, 68);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(609, 23);
            this.PB.TabIndex = 0;
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.White;
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Status.Location = new System.Drawing.Point(12, 49);
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Size = new System.Drawing.Size(609, 13);
            this.Status.TabIndex = 1;
            this.Status.TabStop = false;
            this.Status.Text = "Ready...";
            // 
            // GenLabel
            // 
            this.GenLabel.AutoSize = true;
            this.GenLabel.Location = new System.Drawing.Point(12, 9);
            this.GenLabel.Name = "GenLabel";
            this.GenLabel.Size = new System.Drawing.Size(122, 13);
            this.GenLabel.TabIndex = 2;
            this.GenLabel.Text = "Number of Generations: ";
            // 
            // GenCount
            // 
            this.GenCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GenCount.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.GenCount.Location = new System.Drawing.Point(140, 7);
            this.GenCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.GenCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GenCount.Name = "GenCount";
            this.GenCount.Size = new System.Drawing.Size(120, 20);
            this.GenCount.TabIndex = 3;
            this.GenCount.TabStop = false;
            this.GenCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Buffer
            // 
            this.Buffer.Location = new System.Drawing.Point(266, 7);
            this.Buffer.Name = "Buffer";
            this.Buffer.Size = new System.Drawing.Size(115, 20);
            this.Buffer.TabIndex = 4;
            this.Buffer.Text = "START BUFFER";
            this.Buffer.UseVisualStyleBackColor = true;
            this.Buffer.Click += new System.EventHandler(this.Buffer_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 1;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // BufferSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 103);
            this.Controls.Add(this.Buffer);
            this.Controls.Add(this.GenCount);
            this.Controls.Add(this.GenLabel);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.PB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BufferSimulation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buffer Simulation";
            this.Load += new System.EventHandler(this.BufferSimulation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GenCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label GenLabel;
        private System.Windows.Forms.NumericUpDown GenCount;
        private System.Windows.Forms.Button Buffer;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}