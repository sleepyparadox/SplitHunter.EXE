namespace SplitHunter.EXE.Tools
{
    partial class SimpleTimer
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
            this.ElapsedText = new System.Windows.Forms.Label();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.SplitNameText = new System.Windows.Forms.Label();
            this.CurrentTimeText = new System.Windows.Forms.Label();
            this.BestTimeText = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.ForwardButton = new System.Windows.Forms.Button();
            this.SplitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElapsedText
            // 
            this.ElapsedText.Location = new System.Drawing.Point(12, 9);
            this.ElapsedText.Name = "ElapsedText";
            this.ElapsedText.Size = new System.Drawing.Size(204, 17);
            this.ElapsedText.TabIndex = 0;
            this.ElapsedText.Text = "00:00:01";
            this.ElapsedText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartStopButton
            // 
            this.StartStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartStopButton.Location = new System.Drawing.Point(39, 29);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(150, 23);
            this.StartStopButton.TabIndex = 1;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.ToggleRecording);
            // 
            // SplitNameText
            // 
            this.SplitNameText.Location = new System.Drawing.Point(12, 55);
            this.SplitNameText.Name = "SplitNameText";
            this.SplitNameText.Size = new System.Drawing.Size(204, 17);
            this.SplitNameText.TabIndex = 2;
            this.SplitNameText.Text = "\"Split Name\"";
            this.SplitNameText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentTimeText
            // 
            this.CurrentTimeText.Location = new System.Drawing.Point(78, 72);
            this.CurrentTimeText.Name = "CurrentTimeText";
            this.CurrentTimeText.Size = new System.Drawing.Size(138, 17);
            this.CurrentTimeText.TabIndex = 3;
            this.CurrentTimeText.Text = "00:15:34";
            this.CurrentTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BestTimeText
            // 
            this.BestTimeText.Location = new System.Drawing.Point(78, 89);
            this.BestTimeText.Name = "BestTimeText";
            this.BestTimeText.Size = new System.Drawing.Size(138, 17);
            this.BestTimeText.TabIndex = 4;
            this.BestTimeText.Text = "00:15:34";
            this.BestTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 109);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(21, 23);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "<";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.SelectPreviousSplit);
            // 
            // ForwardButton
            // 
            this.ForwardButton.Location = new System.Drawing.Point(195, 109);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(21, 23);
            this.ForwardButton.TabIndex = 6;
            this.ForwardButton.Text = ">";
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.SelectNextSplit);
            // 
            // SplitButton
            // 
            this.SplitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplitButton.Location = new System.Drawing.Point(39, 109);
            this.SplitButton.Name = "SplitButton";
            this.SplitButton.Size = new System.Drawing.Size(150, 23);
            this.SplitButton.TabIndex = 7;
            this.SplitButton.Text = "Split";
            this.SplitButton.UseVisualStyleBackColor = true;
            this.SplitButton.Click += new System.EventHandler(this.SplitNow);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Best:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 30);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // SimpleTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 145);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SplitButton);
            this.Controls.Add(this.ForwardButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.BestTimeText);
            this.Controls.Add(this.CurrentTimeText);
            this.Controls.Add(this.SplitNameText);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.ElapsedText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleTimer";
            this.Text = "SimpleTimer";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ElapsedText;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Label SplitNameText;
        private System.Windows.Forms.Label CurrentTimeText;
        private System.Windows.Forms.Label BestTimeText;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button SplitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
    }
}