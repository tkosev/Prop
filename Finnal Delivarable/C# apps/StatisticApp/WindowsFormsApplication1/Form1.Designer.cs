namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ChartMoney = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartMaleFemale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelMoney = new System.Windows.Forms.Label();
            this.labelInEvent = new System.Windows.Forms.Label();
            this.chartVisits = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonGetStatistics = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelRFID = new System.Windows.Forms.Label();
            this.labelMaleFemale = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMaleFemale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVisits)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(218, 342);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 495);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Client";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(0, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 118);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "First Client Extra Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelMaleFemale);
            this.groupBox3.Controls.Add(this.ChartMoney);
            this.groupBox3.Controls.Add(this.ChartMaleFemale);
            this.groupBox3.Controls.Add(this.labelMoney);
            this.groupBox3.Controls.Add(this.labelInEvent);
            this.groupBox3.Controls.Add(this.chartVisits);
            this.groupBox3.Location = new System.Drawing.Point(254, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 495);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Statistics";
            // 
            // ChartMoney
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartMoney.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartMoney.Legends.Add(legend1);
            this.ChartMoney.Location = new System.Drawing.Point(12, 267);
            this.ChartMoney.Name = "ChartMoney";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Money In Accounts";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Money Spent";
            this.ChartMoney.Series.Add(series1);
            this.ChartMoney.Series.Add(series2);
            this.ChartMoney.Size = new System.Drawing.Size(543, 222);
            this.ChartMoney.TabIndex = 2;
            this.ChartMoney.Text = "Money";
            // 
            // ChartMaleFemale
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartMaleFemale.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.ChartMaleFemale.Legends.Add(legend2);
            this.ChartMaleFemale.Location = new System.Drawing.Point(292, 41);
            this.ChartMaleFemale.Name = "ChartMaleFemale";
            this.ChartMaleFemale.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Male/Female";
            this.ChartMaleFemale.Series.Add(series3);
            this.ChartMaleFemale.Size = new System.Drawing.Size(260, 199);
            this.ChartMaleFemale.TabIndex = 4;
            this.ChartMaleFemale.Text = "Malse Female Ratio";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Location = new System.Drawing.Point(9, 251);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(0, 13);
            this.labelMoney.TabIndex = 3;
            // 
            // labelInEvent
            // 
            this.labelInEvent.AutoSize = true;
            this.labelInEvent.Location = new System.Drawing.Point(9, 17);
            this.labelInEvent.Name = "labelInEvent";
            this.labelInEvent.Size = new System.Drawing.Size(0, 13);
            this.labelInEvent.TabIndex = 1;
            // 
            // chartVisits
            // 
            chartArea3.Name = "ChartArea1";
            this.chartVisits.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartVisits.Legends.Add(legend3);
            this.chartVisits.Location = new System.Drawing.Point(9, 41);
            this.chartVisits.Name = "chartVisits";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "visits";
            this.chartVisits.Series.Add(series4);
            this.chartVisits.Size = new System.Drawing.Size(260, 199);
            this.chartVisits.TabIndex = 0;
            this.chartVisits.Text = "Visits";
            // 
            // buttonGetStatistics
            // 
            this.buttonGetStatistics.Location = new System.Drawing.Point(563, 514);
            this.buttonGetStatistics.Name = "buttonGetStatistics";
            this.buttonGetStatistics.Size = new System.Drawing.Size(243, 36);
            this.buttonGetStatistics.TabIndex = 5;
            this.buttonGetStatistics.Text = "Get Statistics";
            this.buttonGetStatistics.UseVisualStyleBackColor = true;
            this.buttonGetStatistics.Click += new System.EventHandler(this.buttonGetStatistics_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 45);
            this.button1.TabIndex = 6;
            this.button1.Text = "Assign RFID to First Client From the List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelRFID
            // 
            this.labelRFID.AutoSize = true;
            this.labelRFID.Location = new System.Drawing.Point(263, 514);
            this.labelRFID.Name = "labelRFID";
            this.labelRFID.Size = new System.Drawing.Size(0, 13);
            this.labelRFID.TabIndex = 5;
            // 
            // labelMaleFemale
            // 
            this.labelMaleFemale.AutoSize = true;
            this.labelMaleFemale.Location = new System.Drawing.Point(289, 17);
            this.labelMaleFemale.Name = "labelMaleFemale";
            this.labelMaleFemale.Size = new System.Drawing.Size(0, 13);
            this.labelMaleFemale.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 562);
            this.Controls.Add(this.labelRFID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGetStatistics);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMaleFemale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVisits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonGetStatistics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVisits;
        private System.Windows.Forms.Label labelInEvent;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartMoney;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRFID;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartMaleFemale;
        private System.Windows.Forms.Label labelMaleFemale;
    }
}

