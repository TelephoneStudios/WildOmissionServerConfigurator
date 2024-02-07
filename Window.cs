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
            string[] AdminIDs = AdminIDTextBox.Text.Split(", ");
            string[] AdministratorConfigLines = new string[AdminIDs.Length + 1];
            for (int i = 0; i < AdministratorConfigLines.Length; i++)
            {
                if (i == 0)
                {
                    AdministratorConfigLines[i] = "[/Script/DedicatedServer.ServerAdministrators]";
                    continue;
                }

                AdministratorConfigLines[i] = AdminIDs[i - 1].Insert(0, "Administrators=");
            }

            // Write to that file
            Directory.CreateDirectory("WildOmission/Saved/Config/WindowsServer/");
            File.WriteAllLines("WildOmission/Saved/Config/WindowsServer/ServerAdministrators.ini", AdministratorConfigLines);

            // Launch server executable with correct launch options
            String LaunchArgumentsString = String.Format("-log -SteamServerName=\"{0}\" -Port={1}", ServerNameTextBox.Text, PortTextBox.Text);
            Process.Start("WildOmissionServer.exe", LaunchArgumentsString);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
