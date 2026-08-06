using System;
using System.Windows.Forms;

namespace June2026.BookLendingSystem.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the Windows Forms application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain());
        }
    }
}