using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Linq;
using HtmlAgilityPack;

namespace ASFWhitelist
{
    public partial class Form1 : Form
    {
        const string APP_LIST_FILE = "applist.txt";
        string ASF_CONFIG = "";
        bool sortAscending = false;
        List<string> current_apps = new List<string>();
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
                current_apps.Add(game.Split('\t')[0]);
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

        // Save blacklist to ASF config
        private void buttonSaveList_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(ASF_CONFIG, false);
            int count = 1;

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
                if (count < blacklist.Count)
                {
                    writer.WriteLine("    " + app + ",");
                }
                else
                {
                    writer.WriteLine("    " + app);
                }
                
                count++;
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
                ASF_CONFIG = openFileDialogConfig.FileName;
                string[] temp = File.ReadAllLines(ASF_CONFIG);

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
                for (int i = 0; i < temp.Length + 1 - lineBlacklistEnd; i++)
                {
                    new_config_end.Add(temp[lineBlacklistEnd - 1 + i]);
                }

                labelStatus.Text = "Base ASF config loaded.";
                buttonSaveList.Enabled = true;
            }
        }

        // Update applist
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("applist.txt", true);
            int count = 0;

            var apiJson = new StreamReader(
                WebRequest.Create(
                "http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=YOURWEBAPIKEY&steamid=YOURSTEAMID&l=english&json")
                .GetResponse().GetResponseStream()).ReadToEnd();
            var gamesList = JObject.Parse(apiJson)["response"]["games"].Children().Select(current => current.SelectToken("appid").ToString()).ToList();

            foreach (string appid in gamesList)
            {
                if (!current_apps.Contains(appid))
                {
                    string name = gameName(appid);

                    ListViewItem l1 = listViewGames.Items.Add("");
                    l1.SubItems.Add(appid);
                    l1.SubItems.Add(name);
                    writer.WriteLine(appid + "\t" + name);
                    current_apps.Add(appid);

                    count++;
                }
            }

            labelStatus.Text = count + " new apps found.";
            writer.Close();
        }

        // Fetch game name
        public static string gameName(string appid)
        {
            string game_name = "";
            var url = "http://store.steampowered.com/app/" + appid;
            try
            {
                game_name = new HtmlWeb().Load(url)
                    .DocumentNode
                    .SelectSingleNode("/html/body/div[1]/div[7]/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[3]")
                    .InnerText;
            }
            catch
            {
                try
                {
                    // SteamDB doesn't like this and may ban your IP, use with caution and respect
                    var url2 = "https://steamdb.info/app/" + appid;
                    game_name = new HtmlWeb().Load(url2)
                        .DocumentNode
                        .SelectSingleNode("/html/body/div[1]/div[2]/div/div/div[2]/div[1]/table/tbody/tr[3]/td[2]")
                        .InnerText;
                }
                catch
                {
                    game_name = "Name not available";
                }
            }
            return game_name;
        }
    }
}
