using Svitlo.ObjectModels;
using System;
using System.CodeDom.Compiler;
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
            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Почав слідкувати за відключенням", ToolTipIcon.Warning);
            Task.Run(async ()  =>
            {
                SetTimerUpdate();
                while (!cancellationToken.IsCancellationRequested)
                {
                    TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
                    if (currentDicssonect[currentTime.AddHours(1).ToString()] == "+" || currentDicssonect[currentTime.AddHours(1).ToString()] == "+-")
                    {
                        if (currentDicssonect[currentTime.AddHours(1).ToString()] == "+")
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Відключення світла через годину", ToolTipIcon.Info);
                        }
                        else
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Можливе відключення світла через годину", ToolTipIcon.Info);
                        }
                    }
                    else if (currentDicssonect[currentTime.AddMinutes(15).ToString()] == "+" || currentDicssonect[currentTime.AddMinutes(15).ToString()] == "+-")
                    {
                        if (currentDicssonect[currentTime.AddMinutes(15).ToString()] == "+")
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Відключення світла через 15 хвилин", ToolTipIcon.Info);
                        }
                        else
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Можливе відключення світла через 15 хвилин", ToolTipIcon.Info);
                        }
                    }
                    else if (currentDicssonect[currentTime.AddMinutes(5).ToString()] == "+" || currentDicssonect[currentTime.AddMinutes(5).ToString()] == "+-")
                    {
                        if (currentDicssonect[currentTime.AddMinutes(5).ToString()] == "+")
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Відключення світла через 5 хвилин", ToolTipIcon.Info);
                        }
                        else
                        {
                            notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Можливе відключення світла через 5 хвилин", ToolTipIcon.Info);
                        }
                    }
                    //MessageBox.Show("Update");
                    //test if
                    try
                    {
                        await Task.Delay(60000, cancellationToken);
                    }
                    catch(TaskCanceledException)
                    {
#if DEBUG
                        //MessageBox.Show(Name + "закінчився");
#endif
                    }
                }
                aTimer.Stop();
                aTimer.Dispose();
                notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Зкінчив слідкувати за адерсую", ToolTipIcon.Warning);
                await Task.Delay(1000);
                notifyIcon.Dispose();
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
                    //currentData = temp[2].data.ToString();
                    ParsingHTMLDoccument(temp[2].data.ToString());
                }
            }
            else
            {
                return;
            }
        }
        private void ParsingHTMLDoccument(string obj)
        {
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(obj);
            var tableNode = htmlDocument.DocumentNode.SelectNodes("//div[@class='disconnection-detailed-table-cell cell  no_disconnection current_day' or @class='disconnection-detailed-table-cell cell  has_disconnection confirm_1 current_day' or @class='disconnection-detailed-table-cell cell  has_disconnection confirm_0 current_day']");
            TimeOnly time = new TimeOnly(00, 00);
            ListDictionary temp = new ListDictionary();
            //currentDicssonect.Clear() ;
            for (int i = 0; i < tableNode.Count; i++)
            {
                if (tableNode[i].Attributes[0].Value == "disconnection-detailed-table-cell cell  no_disconnection current_day")
                {
                    temp.Add(time.ToString("HH:mm"), "-");
                }
                else if (tableNode[i].Attributes[0].Value == "disconnection-detailed-table-cell cell  has_disconnection confirm_1 current_day")
                {
                    temp.Add(time.ToString("HH:mm"), "+");
                }
                else
                {
                    temp.Add(time.ToString("HH:mm"), "+-");
                }
                time = time.AddHours(1);
            }
            if (currentDicssonect.Count == 0)
            {
                currentDicssonect = temp;
                notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Данні оновлено", ToolTipIcon.Info);
            }
            else
            {
                if (СomparisonDissconectAddress(temp))
                {
                    return;
                }
                else
                {
                    currentDicssonect = temp;
                    notifyIcon.ShowBalloonTip(2000, $"Svitlo ({followingObject.Name})", "Данні оновлено", ToolTipIcon.Info);
                }
            }
        }
        private bool СomparisonDissconectAddress(ListDictionary temp)
        {
            foreach (var key in currentDicssonect.Keys)
            {
                if (!temp[key].Equals(currentDicssonect[key]))
                {
                    return false;
                }
            }
            return true;
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
