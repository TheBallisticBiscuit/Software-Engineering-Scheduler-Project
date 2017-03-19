using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            database courselist = new database();
            searchQuery courseSearch = new searchQuery(courselist.getCourses(), courselist.getLineCount());
            searchResults results = new searchResults(courselist.getCourses());
            TestClass t = new TestClass();
            t.test();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            t.SearchTest();
            
        }
    }
}
