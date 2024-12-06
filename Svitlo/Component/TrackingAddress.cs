using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.Component
{
    public class TrackingAddress
    {
        public string Name;
        private ObjResidence followingObject;
        private CancellationTokenSource cts;
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
            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    //запрос на даные и их оброботака
                }
            }, cancellationToken);
        }
        public void StopFollowing()
        {
            cts.Cancel();
        }

    }
}
