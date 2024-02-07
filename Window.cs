using System.Diagnostics;

namespace WildOmissionServerConfigurator
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            // TODO create server administrators ini file

            // Launch server executable with correct launch options
            String LaunchString = String.Format("WildOmissionServer.exe -log -SteamServerName={0} -Port={1}", ServerNameTextBox.Text, PortTextBox.Text);
            Process.Start(LaunchString);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
