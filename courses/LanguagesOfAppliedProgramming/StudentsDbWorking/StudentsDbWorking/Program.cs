using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace StudentsDbWorking
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var dbContext = new StudentsContext("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=StudentsDb");
            Application.Run(new MainForm(dbContext));
        }
    }
}
