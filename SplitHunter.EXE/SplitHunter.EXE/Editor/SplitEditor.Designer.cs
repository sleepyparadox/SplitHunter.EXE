namespace SplitHunter.EXE.Editor
{
    partial class SplitEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadSplitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.EditText = new System.Windows.Forms.TextBox();
            this.EditLabel = new System.Windows.Forms.Label();
            this.RightClickContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddSplitContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBeforeContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAfterContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSplitContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.RightClickContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSplitsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(417, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadSplitsToolStripMenuItem
            // 
            this.loadSplitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.loadSplitsToolStripMenuItem.Name = "loadSplitsToolStripMenuItem";
            this.loadSplitsToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.loadSplitsToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.emptyToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.runToolStripMenuItem.Text = "SpeedRun";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.CloneExisting);
            // 
            // emptyToolStripMenuItem
            // 
            this.emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            this.emptyToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.emptyToolStripMenuItem.Text = "Empty";
            this.emptyToolStripMenuItem.Click += new System.EventHandler(this.NewEmpty);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsClicked);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleTimerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // simpleTimerToolStripMenuItem
            // 
            this.simpleTimerToolStripMenuItem.Name = "simpleTimerToolStripMenuItem";
            this.simpleTimerToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.simpleTimerToolStripMenuItem.Text = "Simple Timer";
            this.simpleTimerToolStripMenuItem.Click += new System.EventHandler(this.simpleTimerToolStripMenuItem_Click);
            // 
            // TreeView
            // 
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.Location = new System.Drawing.Point(0, 28);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(417, 432);
            this.TreeView.TabIndex = 1;
            // 
            // EditText
            // 
            this.EditText.Location = new System.Drawing.Point(161, 209);
            this.EditText.Name = "EditText";
            this.EditText.Size = new System.Drawing.Size(244, 22);
            this.EditText.TabIndex = 2;
            this.EditText.Text = "Jack Gets Punched";
            // 
            // EditLabel
            // 
            this.EditLabel.AutoSize = true;
            this.EditLabel.Location = new System.Drawing.Point(92, 212);
            this.EditLabel.Name = "EditLabel";
            this.EditLabel.Size = new System.Drawing.Size(63, 17);
            this.EditLabel.TabIndex = 3;
            this.EditLabel.Text = "Current: ";
            this.EditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RightCLickContext
            // 
            this.RightClickContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClickContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSplitContextItem,
            this.DeleteSplitContextItem});
            this.RightClickContext.Name = "RightCLickContext";
            this.RightClickContext.Size = new System.Drawing.Size(163, 56);
            // 
            // AddSplitContextItem
            // 
            this.AddSplitContextItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBeforeContextItem,
            this.AddAfterContextItem});
            this.AddSplitContextItem.Name = "AddSplitContextItem";
            this.AddSplitContextItem.Size = new System.Drawing.Size(162, 26);
            this.AddSplitContextItem.Text = "Add Split";
            // 
            // AddBeforeContextItem
            // 
            this.AddBeforeContextItem.Name = "AddBeforeContextItem";
            this.AddBeforeContextItem.Size = new System.Drawing.Size(181, 26);
            this.AddBeforeContextItem.Text = "Before";
            this.AddBeforeContextItem.Click += new System.EventHandler(this.AddSplitBeforeSelection);
            // 
            // AddAfterContextItem
            // 
            this.AddAfterContextItem.Name = "AddAfterContextItem";
            this.AddAfterContextItem.Size = new System.Drawing.Size(181, 26);
            this.AddAfterContextItem.Text = "After";
            this.AddAfterContextItem.Click += new System.EventHandler(this.AddSplitAfterSelection);
            // 
            // DeleteSplitContextItem
            // 
            this.DeleteSplitContextItem.Name = "DeleteSplitContextItem";
            this.DeleteSplitContextItem.Size = new System.Drawing.Size(162, 26);
            this.DeleteSplitContextItem.Text = "Delete Split";
            this.DeleteSplitContextItem.Click += new System.EventHandler(this.DeleteSplit);
            // 
            // SplitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 460);
            this.Controls.Add(this.EditLabel);
            this.Controls.Add(this.EditText);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SplitEditor";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RightClickContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadSplitsToolStripMenuItem;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.TextBox EditText;
        private System.Windows.Forms.Label EditLabel;
        private System.Windows.Forms.ToolStripMenuItem simpleTimerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip RightClickContext;
        private System.Windows.Forms.ToolStripMenuItem AddSplitContextItem;
        private System.Windows.Forms.ToolStripMenuItem AddBeforeContextItem;
        private System.Windows.Forms.ToolStripMenuItem AddAfterContextItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSplitContextItem;
    }
}

