using System;

namespace YOS.Pages.Inputs
{
    public class BallEventArgs : EventArgs
    {
        public int Trajectory { get; private set;  }
        public int Distance { get; private set; }
        public BallEventArgs(int Trajectory, int Distance)
        {
            this.Trajectory = Trajectory;
            this.Distance = Distance;
        }
    }
}