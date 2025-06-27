namespace TaskManagerGUI
{
    partial class Main_frame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lb_tasks = new ListBox();
            tb_task = new TextBox();
            remove_task = new Button();
            update_task = new Button();
            add_task = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuBar;
            label1.Location = new Point(147, 38);
            label1.Name = "label1";
            label1.Size = new Size(178, 32);
            label1.TabIndex = 0;
            label1.Text = "Task Manager";
            // 
            // lb_tasks
            // 
            lb_tasks.BackColor = Color.White;
            lb_tasks.BorderStyle = BorderStyle.None;
            lb_tasks.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_tasks.FormattingEnabled = true;
            lb_tasks.ItemHeight = 21;
            lb_tasks.Location = new Point(40, 102);
            lb_tasks.Name = "lb_tasks";
            lb_tasks.Size = new Size(350, 231);
            lb_tasks.TabIndex = 1;
            // 
            // tb_task
            // 
            tb_task.BorderStyle = BorderStyle.FixedSingle;
            tb_task.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_task.Location = new Point(40, 359);
            tb_task.Name = "tb_task";
            tb_task.Size = new Size(350, 29);
            tb_task.TabIndex = 3;
            // 
            // remove_task
            // 
            remove_task.BackColor = Color.FromArgb(0, 0, 255, 128);
            remove_task.FlatStyle = FlatStyle.Flat;
            remove_task.ForeColor = Color.White;
            remove_task.Location = new Point(286, 418);
            remove_task.Name = "remove_task";
            remove_task.Size = new Size(104, 29);
            remove_task.TabIndex = 9;
            remove_task.Text = "Remove Task";
            remove_task.UseVisualStyleBackColor = false;
            remove_task.Click += remove_task_Click;
            // 
            // update_task
            // 
            update_task.BackColor = Color.FromArgb(0, 0, 255, 128);
            update_task.FlatStyle = FlatStyle.Flat;
            update_task.ForeColor = Color.White;
            update_task.Location = new Point(163, 418);
            update_task.Name = "update_task";
            update_task.Size = new Size(104, 29);
            update_task.TabIndex = 10;
            update_task.Text = "Update Task";
            update_task.UseVisualStyleBackColor = false;
            update_task.Click += update_task_Click;
            // 
            // add_task
            // 
            add_task.BackColor = Color.FromArgb(0, 0, 255, 128);
            add_task.FlatStyle = FlatStyle.Flat;
            add_task.ForeColor = Color.White;
            add_task.Location = new Point(40, 418);
            add_task.Name = "add_task";
            add_task.Size = new Size(104, 29);
            add_task.TabIndex = 11;
            add_task.Text = "Add Task";
            add_task.UseVisualStyleBackColor = false;
            add_task.Click += add_task_Click;
            // 
            // Main_frame
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(446, 510);
            Controls.Add(add_task);
            Controls.Add(update_task);
            Controls.Add(remove_task);
            Controls.Add(tb_task);
            Controls.Add(lb_tasks);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Main_frame";
            Text = "Task Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lb_tasks;
        private TextBox tb_task;
        private Button remove_task;
        private Button update_task;
        private Button add_task;
    }
}
