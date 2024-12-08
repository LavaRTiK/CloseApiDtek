using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Svitlo.Component
{
    public class TrackingAddress
    {
        public string Name;
        private string currentData;
        private ObjResidence followingObject;
        private DataLoderAPI dataLoderAPI;
        private CancellationTokenSource cts;
        private System.Timers.Timer aTimer;
        private CancellationToken cancellationToken;
        private ListDictionary currentDicssonect;
        NotifyIcon notifyIcon;
        public TrackingAddress(ObjResidence obj)
        {
            this.followingObject = obj;
            this.cts = new CancellationTokenSource();
            this.cancellationToken = cts.Token;
            this.Name = obj.Name;
            currentDicssonect = new ListDictionary();
            notifyIcon = new NotifyIcon();
            notifyIcon.Text = $"Svitlo ({followingObject.Name})";
            notifyIcon.Icon = new Icon("molnia.ico");
            notifyIcon.Visible = true;
            dataLoderAPI = new DataLoderAPI();
        }
        public void StartFollowing()
        {
            Task.Run(async ()  =>
            {
                SetTimerUpdate();
                while (!cancellationToken.IsCancellationRequested)
                {
                    TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
                    TimeOnly time = new TimeOnly(22, 00);
                    TimeOnly testOne = new TimeOnly(1, 00);
                    TimeOnly testTwo = new TimeOnly(0, 15);
                    TimeOnly testThree = new TimeOnly(0, 5);

                    for (int i = 0; i < currentDicssonect.Count; i++) 
                    {
                        if(currentDicssonect[currentTime.AddHours(1)] == "+" || currentDicssonect[currentTime.AddHours(1)] == "+-")
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Відключення світла через годину", ToolTipIcon.Info);
                        }
                        else if(currentDicssonect[currentTime.AddMinutes(15)] == "+" || currentDicssonect[currentTime.AddMinutes(15)] == "+-")
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Відключення світла через 15 хвилин", ToolTipIcon.Info);
                        }
                        else if (currentDicssonect[currentTime.AddMinutes(5)] == "+" || currentDicssonect[currentTime.AddMinutes(5)] == "+-")
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Відключення світла через 5 хвилин", ToolTipIcon.Info);
                        }
                    }
                    await Task.Delay(1000);
                    
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
                if(currentData != temp[2].data.ToString())
                {
                    currentData = temp[2].data.ToString();
                    ParsingHTMLDoccument();
                    notifyIcon.ShowBalloonTip(2000,$"Svitlo ({followingObject.Name})","Данні оновлено",ToolTipIcon.Info);
                }
            }
            else
            {
                return;
            }
        }
        private void ParsingHTMLDoccument()
        {
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(currentData);
            var tableNode = htmlDocument.DocumentNode.SelectNodes("//div[@class='disconnection-detailed-table-cell cell  no_disconnection current_day' or @class='disconnection-detailed-table-cell cell  has_disconnection confirm_1 current_day' or @class='disconnection-detailed-table-cell cell  has_disconnection confirm_0 current_day']");
            TimeOnly time = new TimeOnly(00, 00);
            for (int i = 0; i < tableNode.Count; i++)
            {
                if (tableNode[i].Attributes[0].Value == "disconnection-detailed-table-cell cell  no_disconnection current_day")
                {
                    currentDicssonect.Add(time.ToString("HH:mm"), "-");
                }
                else if (tableNode[i].Attributes[0].Value == "disconnection-detailed-table-cell cell  has_disconnection confirm_1 current_day")
                {
                    currentDicssonect.Add(time.ToString("HH:mm"), "+");
                }
                else
                {
                    currentDicssonect.Add(time.ToString("HH:mm"), "+-");
                }
                time = time.AddHours(1);
            }
        }
        private  void SetTimerUpdate()
        {
            aTimer = new System.Timers.Timer(300000);
            aTimer.Elapsed +=  UpdateData;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            UpdateData(this, null);
        }

    }
}
