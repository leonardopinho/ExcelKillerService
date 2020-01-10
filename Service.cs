using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

namespace ClearExcelService
{
    public partial class Service : ServiceBase
    {
        private Thread mainThread;
        private LogTxt log = new LogTxt();
        private System.Timers.Timer timer;

        public Service()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            log.Logger("OnStart");
            mainThread = new Thread(Execute);
            mainThread.Start();
        }

        private void Execute(object args)
        {
            timer = new System.Timers.Timer();

            timer.Interval = 900000;

            timer.Elapsed += new System.Timers.ElapsedEventHandler(loop);

            timer.AutoReset = true;

            ExecutarProcessamento();
        }

        private void ExecutarProcessamento()
        {
            timer.Stop();

            var processList = Process.GetProcessesByName("excel");

            log.Logger(string.Format("Length: {0}", processList.Count()));

            if (processList.Count() > 0)
            {
                foreach (var process in processList)
                {
                    try
                    {
                        if (processList != null)
                        {
                            var startDate = processList[0].StartTime;
                            var endDate = DateTime.Now;
                            var diff = endDate.Subtract(startDate);

                            log.Logger(string.Format("Process started at: {0} | End Hour: {1} | Length: {2} | overdue: {3}", startDate, endDate, processList.Count(), (diff.Hours >= 12)));

                            if (diff.Hours >= 12)
                            {
                                process.Kill();
                                log.Logger("Status: successfully killed");
                            }

                            log.Logger("End of process cleanup");

                        }
                    }
                    catch (Exception) {
                        log.Logger("Status: error to kill");
                    }

                }

            }

            timer.Start();
        }

        private void loop(object sender, System.Timers.ElapsedEventArgs e)
        {
            ExecutarProcessamento();
        }

        protected override void OnStop()
        {
            if (mainThread.IsAlive)
            {
                mainThread.Abort();
            }

            timer.Stop();
            timer = null;
        }
    }
}
