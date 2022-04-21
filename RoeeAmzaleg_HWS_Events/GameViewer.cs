using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoeeAmzaleg_HWS_Events
{
    internal class GameViewer
    {
        public void GoodSpaceShipHpChangedEventHandler(object sender, PointEventArgs pointEventArgs)
        {
            Console.WriteLine("\n******************* HP change ********************");

            Console.WriteLine($"Your have: {pointEventArgs.Point} HP.");
            if (pointEventArgs.Point >= 50)
            {
                Console.WriteLine("You have full HP !");
            }
        }
        public void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventArgs locationEventArgs)
        {
            Console.WriteLine("\n******************* Location change ********************");

            Console.WriteLine($"New location = X: {locationEventArgs.X}. Y: {locationEventArgs.Y}.");
        }
        public void GoodSpaceShipDestroyedEventHandler(object sender, LocationEventArgs locationEventArgs)
        {
            Console.WriteLine("\n******************* Good spaceship destroyed ********************");

            Console.WriteLine($"Good Spaceship was destroyed at Location = X: {locationEventArgs.X}. Y: {locationEventArgs.Y}");
            Console.WriteLine("GAME OVER !!!");
        }
        public void BadShipExplodedEventHandler(object sender, BadShipExplodedEventArgs badShipExplodedEventArgs)
        {
            Console.WriteLine("\n******************* Bad spaceships was destroyed ********************");

            Console.WriteLine($"{badShipExplodedEventArgs.ShipsExploded} Bad spaceships was destroyed.");
            Console.WriteLine($"Enemy Spaceships left: {badShipExplodedEventArgs.CurrentEnemyShipsNumber}");
        }
        public void LevelUpReachedEventHandler(object sender, LevelEventArgs levelEventArgs)
        {
            Console.WriteLine("\n******************* LEVEL UP ********************");

            Console.WriteLine($" Your level is: {levelEventArgs.CurrentLevel}");
        }
    }
}
