using System;
using System.Threading;
using System.Windows.Forms;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace HomepageGalleryGenerator
{
    static class HomepageGalleryGenerator
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(HomepageGalleryGenerator));

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            Application.Run(new MainForm());
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            logger.Error("Critical unhandled application Exception", threadExceptionEventArgs.Exception);   
        }
    }
}
