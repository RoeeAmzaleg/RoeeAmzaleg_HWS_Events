namespace RoeeAmzaleg_HWS_Events
{
    public class LevelEventArgs
    {
        public int CurrentLevel { get; set; }

        public LevelEventArgs(int currentLevel)
        {
            CurrentLevel=currentLevel;
        }
    }
}