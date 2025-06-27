namespace TaskManagerGUI
{
    public partial class Main_frame : Form
    {
        public Main_frame()
        {
            InitializeComponent();
            GetTasks();
        }

        static taskManager_BusinessLogic.BusinessLogic_Process taskProcess = new taskManager_BusinessLogic.BusinessLogic_Process();
        public void GetTasks()
        {
            lb_tasks.Items.Clear();

            var tasks = taskProcess.GetAllTasks();
            int i = 1;
            foreach (var task in tasks)
            {
                lb_tasks.Items.Add($"{i}.{task.TaskName} - {task.Status}");
                i++;
            }
        }
        private void add_task_Click(object sender, EventArgs e)
        {
            string taskName = tb_task.Text.Trim();
            if (string.IsNullOrEmpty(taskName))
            {
                MessageBox.Show("Please enter a task name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            taskProcess.SaveTask(taskName);
            GetTasks();
            tb_task.Clear();
        }

        private void update_task_Click(object sender, EventArgs e)
        {
            int selectedIndex = lb_tasks.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Please select a task to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            taskProcess.UpdateTask(selectedIndex);
            GetTasks();

        }

        private void remove_task_Click(object sender, EventArgs e)
        {
            int selectedIndex = lb_tasks.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Please select a task to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            taskProcess.RemoveTask(selectedIndex);
            GetTasks();
        }

    }
}
