using System;

//Af Rasmus
// Et Timer script der sender en event når timmeren er færdig

namespace Misc
{
    public class Timer
    {
        public float TimerLengh { get; private set; }
        public float TimeLeft { get; private set; }

        public event Action timerDone;

        public Timer (float time)
        {
            TimerLengh = time;
            TimeLeft = time;
        }

        //timeren ticker ikke selv men skal tikkes far et andet script
        public void Tick(float deltaTime)
        {
            if (TimeLeft == 0) return;

            TimeLeft -= deltaTime;

            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                timerDone?.Invoke();
            }
        }

        public void Restart()
        {
            TimeLeft = TimerLengh;
        }
        public void Restart(float newTime)
        {
            TimeLeft = newTime;
            TimerLengh = newTime;
        }
    }
}
