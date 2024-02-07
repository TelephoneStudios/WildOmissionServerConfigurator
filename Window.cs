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
            ReadServerInfoConfig();
            ReadAdministratorConfig();

            //string[] AdminIdConfig = File.ReadAllLines("WildOmission/Saved/Config/WindowsServer/ServerAdministrators.ini");
            //for ( int i = 0; i < AdminIdConfig.Length; i++ )
            //{
            //    if (!AdminIdConfig[i].StartsWith("Administrators="))
            //    {
            //        continue;
            //    }

            //    if (AdminIDTextBox.Text == "")
            //    {
            //        AdminIDTextBox.Text = AdminIdConfig[i].Remove(0, 15);
            //    }
            //    else
            //    {
            //        string newId = AdminIdConfig[i].Remove(0, 15).Insert(0, ", ");
            //        AdminIDTextBox.Text.Insert(AdminIDTextBox.TextLength, newId);
            //    }
            //}
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            WriteServerInfoConfig();
            WriteAdministratorConfig();

            // Launch server executable with correct launch options
            String LaunchArgumentsString = String.Format("-log -SteamServerName=\"{0}\" -Port={1}", ServerNameTextBox.Text, PortTextBox.Text);
            Process.Start("WildOmissionServer.exe", LaunchArgumentsString);

            Close();
        }

        private void ReadAdministratorConfig()
        {
            // I absolutely hate the way this looks :(
            FileStream fs = File.Open("WildOmission/Saved/Config/WindowsServer/ServerAdministrators.ini", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            String line;
            try
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith("Administrators="))
                    {
                        continue;
                    }

                    if (AdminIDTextBox.Text.Length == 0)
                    {
                        AdminIDTextBox.Text = line.Remove(0, 15);
                    }
                    else
                    {
                        string newId = line.Remove(0, 15).Insert(0, ", ");
                        AdminIDTextBox.Text = AdminIDTextBox.Text.Insert(AdminIDTextBox.TextLength, newId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { fs.Close(); }
        }

        private void WriteAdministratorConfig()
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
        }

        private void ReadServerInfoConfig()
        {
            // I absolutely hate the way this looks :(
            FileStream fs = File.Open("WildOmission/Saved/Config/WindowsServer/ServerInfo.ini", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            String line;
            try
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string serverNameKey = "ServerName=";
                    string serverPortKey = "ServerPort=";
                    if (line.StartsWith(serverNameKey))
                    {
                        ServerNameTextBox.Text = line.Remove(0, serverNameKey.Length);
                    }
                    else if(line.StartsWith(serverPortKey))
                    {
                        PortTextBox.Text = line.Remove(0, serverPortKey.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { fs.Close(); }
        }

        private void WriteServerInfoConfig()
        {
            // Attempt to write the server info config
            string[] serverInfoLines = { String.Format("ServerName={0}", ServerNameTextBox.Text), String.Format("ServerPort={0}", PortTextBox.Text) };

            // Write to that file
            Directory.CreateDirectory("WildOmission/Saved/Config/WindowsServer/");
            File.WriteAllLines("WildOmission/Saved/Config/WindowsServer/ServerInfo.ini", serverInfoLines);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
