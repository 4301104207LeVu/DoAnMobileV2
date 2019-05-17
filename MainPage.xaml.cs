using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;
using System.Diagnostics;

namespace DoAnMobile
{
    public partial class MainPage : TabbedPage
    {
        Stopwatch stopwatch;
        public MainPage()
        {
            stopwatch = new Stopwatch();
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                            lbldate.Text = "Time: " + DateTime.Now.ToString("hh:mm:ss tt") + "\n Date: " + DateTime.Now.ToString("dd/MM/yyyy")
                    );
                return true;
            });
        }

        int stt = 0;
        private void TapTime(object sender, EventArgs e)
        {
            var time = TimerTap.Text;
            kqTapTime.Text = "ID:" + stt.ToString() + " - " + time + "\n" + kqTapTime.Text;
            stt++;
        }

        private void ResetTime(object sender, EventArgs e)
        {
            kqTapTime.Text = "";
            TimerTap.Text = "00:00:00.000000";
            stt = 0;
            BtnStartTap.IsVisible = true;
            BtnPauseTap.IsVisible = false;
            BtnResumeTap.IsVisible = false;
            stopwatch.Stop();
            stopwatch.Reset();
        }
        private void startTap(object sender, EventArgs e)
        {
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                TimerTap.Text = stopwatch.Elapsed.ToString();
                return true;
            });
            BtnStartTap.IsVisible = false;
            BtnPauseTap.IsVisible = true;
        }

        private void ResumeTap(object sender, EventArgs e)
        {
            stopwatch.Start();
            BtnResumeTap.IsVisible = false;
            BtnStartTap.IsVisible = false;
            BtnPauseTap.IsVisible = true;
        }

        private void pauseTap(object sender, EventArgs e)
        {
            BtnPauseTap.IsVisible = false;
            BtnResumeTap.IsVisible = true;
            stopwatch.Stop();
        }
        int currentState = 1;
        string myope;
        double fnum, snum;
        private void Clear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            currentState = 1;
            snum = 0;
            fnum = 0;
        }

        private void CanBacHai(object sender, EventArgs e)
        {
            if (currentState == -1 || currentState == 1)
            {
                var result = Math.Sqrt(fnum);
                resultText.Text = result.ToString();
                fnum = result;
                currentState = 1;
            }
        }

        private void PhanTram(object sender, EventArgs e)
        {
            if (currentState == 1 || currentState == -1)
            {
                var result = fnum / 100;
                resultText.Text = result.ToString();
                fnum = result;
                currentState = -1;
            }
        }

        private void Operator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string press = button.Text;
            myope = press;
        }

        private void SelectNum(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string press = button.Text;
            if (resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0) currentState *= -1;
            }
            resultText.Text += press;
            double number;
            if (double.TryParse(resultText.Text, out number))
            {
                resultText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    fnum = number;
                }
                else
                {
                    snum = number;
                }
            }
        }

        private void DoubleOpe(object sender, EventArgs e)
        {
            if (currentState == -1 || currentState == 1)
            {
                var result = fnum * fnum;
                resultText.Text = result.ToString();
                fnum = result;
                currentState = -1;
            }
        }
        private void CDs(object sender, EventArgs e)
        {

        }

        private void CDe(object sender, EventArgs e)
        {

        }

        private void OnCaculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = OperatorHelper.caculate(fnum, snum, myope);
                this.resultText.Text = result.ToString();
                fnum = result;
                currentState = -1;
            }
        }
    }
}

