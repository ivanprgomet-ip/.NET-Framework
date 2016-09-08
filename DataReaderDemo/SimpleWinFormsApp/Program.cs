using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWinFormsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new MainWindow("ivansform",200,300));
        }
    }
    class MainWindow : Form 
    {
        private MenuStrip mnuMainMenu = new MenuStrip();
        private ToolStripMenuItem mnuFile = new ToolStripMenuItem();
        private ToolStripMenuItem mnuFileExit = new ToolStripMenuItem();

        public MainWindow(string title, int height, int width)
        {
            //method to create the menu system
            BuildMenuSystem();
        }

        private void BuildMenuSystem()
        {
            //add the file menu to the main menu
            mnuFile.Text = "&File";
            mnuMainMenu.Items.Add(mnuFile);

            //add exit menu to the file menu
            mnuFileExit.Text = "E&xit";
            mnuFile.DropDownItems.Add(mnuFileExit);
            mnuFileExit.Click +=(o,s)=>Application.Exit();

            //finally set the menu for this form
            Controls.Add(this.mnuMainMenu);
            MainMenuStrip = this.mnuMainMenu;

        }
    }
}
