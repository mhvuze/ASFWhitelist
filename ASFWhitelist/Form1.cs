using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ASFWhitelist
{
    public partial class Form1 : Form
    {
        const string APP_LIST_FILE = "applist.txt";
        bool sortAscending = false;
        List<string> blacklist = new List<string>();

        public Form1()
        {
            InitializeComponent();
            populateGameList();
        }

        // Populate listViewGames with all apps in applist.txt
        private void populateGameList()
        {
            string[] gameList = System.IO.File.ReadAllLines(APP_LIST_FILE);
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
            StreamWriter writer = new StreamWriter("blacklist.txt", false);

            foreach (ListViewItem item in listViewGames.Items)
            {
                if (!item.Checked) blacklist.Add(item.SubItems[1].Text);
            }

            foreach (string app in blacklist)
            {
                writer.WriteLine("    " + app + ",");
            }

            blacklist.Clear();
            writer.Close();
            labelStatus.Text = "Blacklist saved.";
        }
    }
}
