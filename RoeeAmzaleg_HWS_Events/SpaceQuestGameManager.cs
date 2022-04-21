using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoeeAmzaleg_HWS_Events
{
    internal class SpaceQuestGameManager
    {
        private const int maxPoints = 50;

        public int goodSpaceShipHitPoint;
        public int shipXLocation;
        public int shipYLocation;
        public int numberOfBadShips;
        public int currentLevel;

        public event EventHandler<PointEventArgs> GoodSpaceShipHpChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipExplodedEventArgs> BadShipExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;

        public SpaceQuestGameManager(int goodSpaceShipHitPoint , int shipXLocation , int shipYLocation , int numberOfBadShips )
        {
            this.goodSpaceShipHitPoint=goodSpaceShipHitPoint;
            this.shipXLocation=shipXLocation;
            this.shipYLocation=shipYLocation;
            this.numberOfBadShips=numberOfBadShips;
        }

        public void MoveSpaceShip(int newX, int newY)
        {
            shipXLocation =newX;
            shipYLocation =newY;
            OnGoodSpaceShipLocationChanged(newX, newY);
        }
        public void GoodSpaceShipGotDemaged(int damage)
        {
            goodSpaceShipHitPoint -= damage;
            if (goodSpaceShipHitPoint <= 0)
            {
                OnGoodSpaceShipExploded();
                return;
            }
            else
            {
                Console.WriteLine($"Your spaceship was hit : -{damage}. ");
                OnGoodSpaceShipHpChanged(damage);
            }
        }
        public void GoodSpaceShipGotExtraHp(int extra)
        {
            goodSpaceShipHitPoint += extra;
            Console.WriteLine($"You got extra: {extra} Hp. ");
            OnGoodSpaceShipHpChanged(extra);
        }
        public void EnemyShipsDestroyed(int numberOfBadShipsDestroyd)
        {
            numberOfBadShips -= numberOfBadShipsDestroyd;
            if (numberOfBadShips <= 0)
            {
                OnBadShipExploded(numberOfBadShipsDestroyd);
                ++currentLevel;
                OnLevelUpReached();
            }
            else
                OnBadShipExploded(numberOfBadShipsDestroyd);
        }

        //
        private void OnGoodSpaceShipHpChanged(int hp)
        {
            GoodSpaceShipHpChanged?.Invoke(this, new PointEventArgs(hp));
        }
        private void OnGoodSpaceShipLocationChanged(int x, int y)
        {
            GoodSpaceShipLocationChanged?.Invoke(this, new LocationEventArgs(x, y));
        }
        private void OnGoodSpaceShipDamaged(int hp)
        {
            GoodSpaceShipHpChanged?.Invoke(this, new PointEventArgs(hp));
        }
        private void OnGoodSpaceShipExploded()
        {
            GoodSpaceShipDestroyed?.Invoke(this, new LocationEventArgs(shipXLocation, shipYLocation));
        }
        private void OnBadShipExploded(int badShipsExploded)
        {
            BadShipExploded?.Invoke(this, new BadShipExplodedEventArgs(numberOfBadShips, badShipsExploded));
        }
        private void OnLevelUpReached()
        {
            LevelUpReached?.Invoke(this, new LevelEventArgs(currentLevel));
            GoodSpaceShipHpChanged?.Invoke(this, new PointEventArgs(maxPoints));
        }

    }
}
