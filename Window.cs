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
            // TODO at some point have implement recall admin ability
        //    File.Create("WildOmission/Saved/Config/WindowsServer/ServerAdministrators.ini");

        //    string[] AdminIdConfig = File.ReadAllLines("WildOmission/Saved/Config/WindowsServer/ServerAdministrators.ini");
        //    for (int i = 1; i < AdminIdConfig.Length; i++)
        //    {
        //        AdminIdConfig[i] = AdminIdConfig[i].Remove(0, 15);
        //    }
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            // Create ServerAdministrators.ini file
            string[] AdministratorConfigLines = ["[/Script/DedicatedServer.ServerAdministrators]"];

            string[] AdminIDs = AdminIDTextBox.Text.Split(", ");
            for (int i = 0; i<AdminIDs.Length; i++)
            {
                AdminIDs[i].Insert(0, "Administrators=");
                AdministratorConfigLines.Append(AdminIDs[i]);            
            }

            Directory.CreateDirectory("WildOmission/Saved/Config/WindowsServer/");
            File.WriteAllLines("WildOmission/Saved/Config/WindowsServer/ServerAdministrators.ini", AdministratorConfigLines);

            // Launch server executable with correct launch options
            String LaunchString = String.Format("WildOmissionServer.exe -log -SteamServerName=\"{0}\" -Port={1}", ServerNameTextBox.Text, PortTextBox.Text);
            Process.Start(LaunchString);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
