using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ASFWhitelist
{
    public partial class Form1 : Form
    {
        const string APP_LIST_FILE = "applist.txt";
        bool sortAscending = false;
        List<string> blacklist = new List<string>();
        List<string> new_config_start = new List<string>();
        List<string> new_config_end = new List<string>();

        public Form1()
        {
            InitializeComponent();
            populateGameList();
        }

        // Populate listViewGames with all apps in applist.txt
        private void populateGameList()
        {
            string[] gameList = File.ReadAllLines(APP_LIST_FILE);
            foreach (string game in gameList)
            {
                ListViewItem l1 = listViewGames.Items.Add("");
                l1.SubItems.Add(game.Split('\t')[0]);
                l1.SubItems.Add(game.Split('\t')[1]);
            }
        }

        // Search for app name when textBoxSearch content is changed
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ListViewItem foundItem = listViewGames.FindItemWithText(textBoxSearch.Text);
            if (foundItem != null)
            {
                listViewGames.TopItem = foundItem;
            }
        }

        // Sort apps ascending/descending when column header is clicked
        private void listViewGames_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!sortAscending)
            {
                sortAscending = true;
            }
            else
            {
                sortAscending = false;
            }
            this.listViewGames.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
        }

        // Save blacklist to ASF config *wip*
        private void buttonSaveList_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("ASF.json", false);

            // Write start from original config
            foreach (string str in new_config_start)
            {
                writer.WriteLine(str);
            }

            // Write blacklist based on listViewGames
            foreach (ListViewItem item in listViewGames.Items)
            {
                if (!item.Checked) blacklist.Add(item.SubItems[1].Text);
            }

            foreach (string app in blacklist)
            {
                writer.WriteLine("    " + app + ",");
            }

            // Write end from original config
            foreach (string str in new_config_end)
            {
                writer.WriteLine(str);
            }

            blacklist.Clear();
            writer.Close();
            labelStatus.Text = "New ASF config saved.";
        }

        // Load ASF main config (includes app blacklist)
        private void buttonOpenASFconfig_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogConfig.ShowDialog();
            if (result == DialogResult.OK)
            {
                int lineBlacklist = 1;
                int lineBlacklistEnd = 1;
                string file = openFileDialogConfig.FileName;
                string[] temp = File.ReadAllLines(file);

                // Save everything before blacklist block to new_config_start
                foreach (string str in temp)
                {
                    if (!str.Contains("Blacklist"))
                    {
                        new_config_start.Add(str);
                        lineBlacklist++;
                    }
                    else
                    {
                        new_config_start.Add(str);
                        break;
                    }
                }

                // Find end of blacklist block
                foreach (string str in temp)
                {
                    if (!str.Contains("  ],"))
                    {
                        lineBlacklistEnd++;
                    }
                    else
                    {
                        break;
                    }
                }

                // Save everything after blacklist block to new_config_end
                int add = 0;
                for (int i = 0; i < temp.Length - lineBlacklistEnd; i++)
                {
                    new_config_end.Add(temp[lineBlacklistEnd - 1 + i]);
                }

                Console.WriteLine(lineBlacklist);
                Console.WriteLine(lineBlacklistEnd);

                labelStatus.Text = "Base ASF config loaded.";
                buttonSaveList.Enabled = true;
            }
        }
    }
}
