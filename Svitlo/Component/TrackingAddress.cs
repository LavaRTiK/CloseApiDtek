using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Svitlo.Component
{
    public class TrackingAddress
    {
        public string Name;
        private string currentData;
        private ObjResidence followingObject;
        private DataLoderAPI dataLoderAPI;
        private CancellationTokenSource cts;
        private static System.Timers.Timer aTimer;
        private CancellationToken cancellationToken;
        public TrackingAddress(ObjResidence obj)
        {
            this.followingObject = obj;
            this.cts = new CancellationTokenSource();
            this.cancellationToken = cts.Token;
            this.Name = obj.Name;
        }
        public void StartFollowing()
        {

            SetTimerUpdate();
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {

                }
                aTimer.Stop();
                aTimer.Dispose();
                //тут стопаем все таймеры

            }, cancellationToken);
        }
        public void StopFollowing()
        {
            cts.Cancel();
        }
        private async void UpdateData(Object source, ElapsedEventArgs e)
        {
            var temp = await dataLoderAPI.RequestDisconnectDataAsync(followingObject.City, followingObject.IdCity, followingObject.Street, followingObject.IdStreet, followingObject.House, followingObject.IdHouse);
            if (temp != null)
            {
                currentData = temp[2].ToString();
            }
            else
            {
                return;
            }
        }
        private  void SetTimerUpdate()
        {
            aTimer = new System.Timers.Timer(300000);
            aTimer.Elapsed +=  UpdateData;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

    }
}
