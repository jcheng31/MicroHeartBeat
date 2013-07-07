using System;
using System.Threading;
using Microsoft.SPOT;

namespace MicroHeartBeat
{
    public delegate void HeartBeatEventHandler(object sender, EventArgs e);
    
    public class HeartBeat
    {
        private Timer _timer;
        private int _period;

        public event HeartBeatEventHandler OnHeartBeat;

        public HeartBeat(int period)
        {
            _period = period;
        }

        private void TimerCallback(object state)
        {
            if (OnHeartBeat != null)
            {
                OnHeartBeat(this, new EventArgs());
            }
        }

        public void Start()
        {
            Start(0);
        }

        public void Start(int delay)
        {
            if (_timer != null) return;

            _timer = new Timer(TimerCallback, null, delay, _period);
        }

        public void Stop()
        {
            if (_timer == null) return;

            _timer.Dispose();
            _timer = null;
        }

        public bool Toggle()
        {
            return Toggle(0);
        }

        public bool Toggle(int delay)
        {
            bool started;
            if (_timer == null)
            {
                Start(delay);
                started = true;
            }
            else
            {
                Stop();
                started = false;
            }
            return started;
        }

        public void Reset()
        {
            Reset(0);
        }

        public void Reset(int delay)
        {
            Stop();
            Start(delay);
        }

        public void ChangePeriod(int newPeriod)
        {
            _period = newPeriod;

            if (_timer != null)
            {
                Reset();
            }
        }
    }
}
