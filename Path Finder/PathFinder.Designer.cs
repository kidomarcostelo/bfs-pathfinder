namespace Path_Finder
{
    partial class PathFinder
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
            this.Table = new System.Windows.Forms.PictureBox();
            this.groupBoxDraw = new System.Windows.Forms.GroupBox();
            this.rClear = new System.Windows.Forms.RadioButton();
            this.rDrawDest = new System.Windows.Forms.RadioButton();
            this.rDrawStart = new System.Windows.Forms.RadioButton();
            this.rDrawWall = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.lbStepsNum = new System.Windows.Forms.Label();
            this.lbSteps = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.groupBoxDraw.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.BackColor = System.Drawing.Color.White;
            this.Table.Location = new System.Drawing.Point(12, 37);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(601, 451);
            this.Table.TabIndex = 1;
            this.Table.TabStop = false;
            this.Table.Paint += new System.Windows.Forms.PaintEventHandler(this.Table_Paint);
            this.Table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Table_MouseClick);
            this.Table.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Table_MouseMove);
            // 
            // groupBoxDraw
            // 
            this.groupBoxDraw.Controls.Add(this.rClear);
            this.groupBoxDraw.Controls.Add(this.rDrawDest);
            this.groupBoxDraw.Controls.Add(this.rDrawStart);
            this.groupBoxDraw.Controls.Add(this.rDrawWall);
            this.groupBoxDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDraw.Location = new System.Drawing.Point(654, 37);
            this.groupBoxDraw.Name = "groupBoxDraw";
            this.groupBoxDraw.Size = new System.Drawing.Size(132, 128);
            this.groupBoxDraw.TabIndex = 2;
            this.groupBoxDraw.TabStop = false;
            this.groupBoxDraw.Text = "Draw";
            // 
            // rClear
            // 
            this.rClear.AutoSize = true;
            this.rClear.Location = new System.Drawing.Point(16, 98);
            this.rClear.Name = "rClear";
            this.rClear.Size = new System.Drawing.Size(57, 20);
            this.rClear.TabIndex = 3;
            this.rClear.Text = "Clear";
            this.rClear.UseVisualStyleBackColor = true;
            this.rClear.CheckedChanged += new System.EventHandler(this.rClear_CheckedChanged);
            // 
            // rDrawDest
            // 
            this.rDrawDest.AutoSize = true;
            this.rDrawDest.Location = new System.Drawing.Point(16, 72);
            this.rDrawDest.Name = "rDrawDest";
            this.rDrawDest.Size = new System.Drawing.Size(87, 20);
            this.rDrawDest.TabIndex = 2;
            this.rDrawDest.Text = "Draw Dest";
            this.rDrawDest.UseVisualStyleBackColor = true;
            this.rDrawDest.CheckedChanged += new System.EventHandler(this.rDrawDest_CheckedChanged);
            // 
            // rDrawStart
            // 
            this.rDrawStart.AutoSize = true;
            this.rDrawStart.Location = new System.Drawing.Point(16, 46);
            this.rDrawStart.Name = "rDrawStart";
            this.rDrawStart.Size = new System.Drawing.Size(86, 20);
            this.rDrawStart.TabIndex = 1;
            this.rDrawStart.Text = "Draw Start";
            this.rDrawStart.UseVisualStyleBackColor = true;
            this.rDrawStart.CheckedChanged += new System.EventHandler(this.rDrawStart_CheckedChanged);
            // 
            // rDrawWall
            // 
            this.rDrawWall.AutoSize = true;
            this.rDrawWall.Location = new System.Drawing.Point(16, 20);
            this.rDrawWall.Name = "rDrawWall";
            this.rDrawWall.Size = new System.Drawing.Size(52, 20);
            this.rDrawWall.TabIndex = 0;
            this.rDrawWall.Text = "Wall";
            this.rDrawWall.UseVisualStyleBackColor = true;
            this.rDrawWall.CheckedChanged += new System.EventHandler(this.rDrawWall_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bread First Search Path Finder";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(654, 250);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(132, 38);
            this.btnClear.TabIndex = 8;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(654, 199);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(132, 38);
            this.btnFind.TabIndex = 7;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lbStepsNum
            // 
            this.lbStepsNum.BackColor = System.Drawing.SystemColors.Window;
            this.lbStepsNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStepsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStepsNum.Location = new System.Drawing.Point(659, 332);
            this.lbStepsNum.Name = "lbStepsNum";
            this.lbStepsNum.Size = new System.Drawing.Size(47, 25);
            this.lbStepsNum.TabIndex = 13;
            this.lbStepsNum.Text = "0";
            this.lbStepsNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSteps
            // 
            this.lbSteps.AutoSize = true;
            this.lbSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteps.Location = new System.Drawing.Point(656, 307);
            this.lbSteps.Name = "lbSteps";
            this.lbSteps.Size = new System.Drawing.Size(45, 16);
            this.lbSteps.TabIndex = 12;
            this.lbSteps.Text = "Steps:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PathFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 509);
            this.Controls.Add(this.lbStepsNum);
            this.Controls.Add(this.lbSteps);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxDraw);
            this.Controls.Add(this.Table);
            this.Name = "PathFinder";
            this.Text = "Path Finder";
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.groupBoxDraw.ResumeLayout(false);
            this.groupBoxDraw.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Table;
        private System.Windows.Forms.GroupBox groupBoxDraw;
        private System.Windows.Forms.RadioButton rClear;
        private System.Windows.Forms.RadioButton rDrawDest;
        private System.Windows.Forms.RadioButton rDrawStart;
        private System.Windows.Forms.RadioButton rDrawWall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lbStepsNum;
        private System.Windows.Forms.Label lbSteps;
        private System.Windows.Forms.Timer timer1;
    }
}

