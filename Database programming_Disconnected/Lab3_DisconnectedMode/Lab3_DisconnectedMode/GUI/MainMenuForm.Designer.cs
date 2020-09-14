namespace Lab3_DisconnectedMode.GUI
{
    partial class MainMenuForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseRegistrationFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formsToolStripMenuItem
            // 
            this.formsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentFormToolStripMenuItem,
            this.courseFormToolStripMenuItem,
            this.courseRegistrationFormToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.formsToolStripMenuItem.Name = "formsToolStripMenuItem";
            this.formsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.formsToolStripMenuItem.Text = "Forms";
            // 
            // studentFormToolStripMenuItem
            // 
            this.studentFormToolStripMenuItem.Name = "studentFormToolStripMenuItem";
            this.studentFormToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.studentFormToolStripMenuItem.Text = "Student Form";
            // 
            // courseFormToolStripMenuItem
            // 
            this.courseFormToolStripMenuItem.Name = "courseFormToolStripMenuItem";
            this.courseFormToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.courseFormToolStripMenuItem.Text = "Course Form";
            // 
            // courseRegistrationFormToolStripMenuItem
            // 
            this.courseRegistrationFormToolStripMenuItem.Name = "courseRegistrationFormToolStripMenuItem";
            this.courseRegistrationFormToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.courseRegistrationFormToolStripMenuItem.Text = "Course Registration Form";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 409);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseRegistrationFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}