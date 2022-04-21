using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RoeeAmzaleg_HWS_Events
{
    public class Program
    {
        static void Main(string[] args)
        {
            SpaceQuestGameManager gm = new(2, 15, 30, 5);
            GameViewer gameViewer = new GameViewer();

            gm.GoodSpaceShipHpChanged += gameViewer.GoodSpaceShipHpChangedEventHandler;
            gm.GoodSpaceShipLocationChanged += gameViewer.GoodSpaceShipLocationChangedEventHandler;
            gm.GoodSpaceShipDestroyed += gameViewer.GoodSpaceShipDestroyedEventHandler;
            gm.BadShipExploded += gameViewer.BadShipExplodedEventHandler;
            gm.LevelUpReached += gameViewer.LevelUpReachedEventHandler;
            gm.GoodSpaceShipLocationChanged += (sender, eventArgs) => Thread.Sleep(2000);
            gm.LevelUpReached += (sender, eventArgs) => Thread.Sleep(2000);
            gm.GoodSpaceShipHpChanged += (sender, eventArgs) => Thread.Sleep(2000);
            gm.GoodSpaceShipDestroyed += (sender, eventArgs) => Thread.Sleep(2000);
            gm.BadShipExploded += (sender, eventArgs) => Thread.Sleep(2000);
            TimeMethod(gm);


            static void TimeMethod(SpaceQuestGameManager gm)
            {
                Random randomChoise = new Random();
                Random randomDemage = new Random();
                Random randomMove = new Random();
                Random randomExtraHp = new Random();

                while (gm.goodSpaceShipHitPoint > 0)
                    switch (randomChoise.Next(0, 4))
                    {
                        case 0:
                            gm.MoveSpaceShip(randomMove.Next(0, 1000), randomMove.Next(0, 1000));
                            break;
                        case 1:
                            gm.GoodSpaceShipGotDemaged(randomDemage.Next(0, 30));
                            break;
                        case 2:
                            gm.GoodSpaceShipGotExtraHp(randomExtraHp.Next(0, 50));
                            break;
                        case 3:
                            gm.EnemyShipsDestroyed(randomDemage.Next(0, 4));
                            break;
                        default:
                            break;
                    }
            }           
        }
    }

}