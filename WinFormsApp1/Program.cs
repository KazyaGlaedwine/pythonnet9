using Python.Runtime;
using System.Drawing.Imaging;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            RunScript("mypythonscript");
            Application.Run(new Form1());
        }
        static void RunScript(string scriptName)
        {
            Runtime.PythonDLL = @"C:\Users\user\AppData\Local\Programs\Python\Python311\python311.dll";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                var pythonScript = Py.Import(scriptName);
                var result = pythonScript.InvokeMethod("say_hello");
            }
        }
    }
}