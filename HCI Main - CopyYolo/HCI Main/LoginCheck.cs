using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HCI_Main
{
    public class LoginCheck
    {
        public Dictionary<string, string> userCredentials = new Dictionary<string, string>();

        public bool CheckCredentials(string username, string password)
        {
            if (userCredentials.ContainsKey(username))
            {                
                return userCredentials[username] == password;
            }

            return false;
        }

        public void LoadCredentials()
        {            
            if (File.Exists("credentials.txt"))
            {
                string[] lines = File.ReadAllLines("credentials.txt");

                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string username = parts[0];
                        string password = parts[1];
                        userCredentials[username] = password;
                    }
                }
            }
        }

        public void SaveCredentials(string username, string password)
        {
            if (userCredentials.ContainsKey(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            else
            {
                userCredentials.Add(username, password);

                using (StreamWriter writer = new StreamWriter("credentials.txt", true))
                {
                    foreach (var kvp in userCredentials)
                    {
                        writer.WriteLine($"{kvp.Key},{kvp.Value}");
                    }
                }
            }                             
        }

        public void SaveCredentials2()
        {
            using (StreamWriter writer = new StreamWriter("credentials.txt"))
            {
                foreach (var kvp in userCredentials)
                {
                    writer.WriteLine($"{kvp.Key},{kvp.Value}");
                }
            }
        }

        public void ChangeUsername(string oldUsername, string newUsername)
        {            
            if (!userCredentials.ContainsKey(oldUsername))
            {
                MessageBox.Show("Username does not exist. Unable to modify username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string password = userCredentials[oldUsername];
            
            if (oldUsername == newUsername)
            {
                MessageBox.Show("Username remains the same. No changes made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (userCredentials.ContainsKey(newUsername))
            {
                MessageBox.Show("New username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            userCredentials.Remove(oldUsername);
            userCredentials[newUsername] = password;
            
            SaveCredentials2();

            MessageBox.Show("Username modified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ChangePassword(string username, string newPassword)
        {            
            if (userCredentials.ContainsKey(username))
            {                
                userCredentials[username] = newPassword;
                
                SaveCredentials2();

                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Username does not exist. Unable to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
