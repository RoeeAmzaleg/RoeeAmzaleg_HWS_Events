namespace RoeeAmzaleg_HWS_Events
{
    public class LocationEventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }

        public LocationEventArgs(int x, int y)
        {
            this.X=x;
            this.Y=y;
        }
    }
}