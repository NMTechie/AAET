using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using CAAAETCommon.DataTransferObjects;




namespace CAAAETMQPullService.ServiceLogic
{
    public class MQPullNDBSave : IMQPullNDBSave
    {
        private readonly Timer _timer;
        public MQPullNDBSave(ServiceParams param)
        {
            _timer = new Timer();
            _timer.AutoReset = true;
            _timer.Interval = param.Interval;
            _timer.Elapsed += PullMessageAndSave;
        }        	    
        public void StartService()
        {
            _timer.Start();
        }
        public void StopService()
        {
            _timer.Stop();
            _timer.Close();
            _timer.Dispose();            
        }
        private void PullMessageAndSave(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime.ToUniversalTime());
        }
    }
}
