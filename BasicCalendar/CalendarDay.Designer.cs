namespace BasicCalendar
{
    partial class CalendarDay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDayLabel = new System.Windows.Forms.Panel();
            this.lblDayNumber = new System.Windows.Forms.Label();
            this.pnlDayContents = new System.Windows.Forms.Panel();
            this.pnlDayLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDayLabel
            // 
            this.pnlDayLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlDayLabel.Controls.Add(this.lblDayNumber);
            this.pnlDayLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDayLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlDayLabel.Name = "pnlDayLabel";
            this.pnlDayLabel.Size = new System.Drawing.Size(150, 18);
            this.pnlDayLabel.TabIndex = 0;
            // 
            // lblDayNumber
            // 
            this.lblDayNumber.AutoSize = true;
            this.lblDayNumber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayNumber.ForeColor = System.Drawing.Color.White;
            this.lblDayNumber.Location = new System.Drawing.Point(3, 2);
            this.lblDayNumber.Name = "lblDayNumber";
            this.lblDayNumber.Size = new System.Drawing.Size(52, 13);
            this.lblDayNumber.TabIndex = 0;
            this.lblDayNumber.Text = "AUG 1ST";
            // 
            // pnlDayContents
            // 
            this.pnlDayContents.AutoScroll = true;
            this.pnlDayContents.BackColor = System.Drawing.Color.White;
            this.pnlDayContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDayContents.Location = new System.Drawing.Point(0, 18);
            this.pnlDayContents.Name = "pnlDayContents";
            this.pnlDayContents.Size = new System.Drawing.Size(150, 132);
            this.pnlDayContents.TabIndex = 1;
            // 
            // CalendarDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDayContents);
            this.Controls.Add(this.pnlDayLabel);
            this.Name = "CalendarDay";
            this.pnlDayLabel.ResumeLayout(false);
            this.pnlDayLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDayLabel;
        private System.Windows.Forms.Label lblDayNumber;
        private System.Windows.Forms.Panel pnlDayContents;
    }
}
