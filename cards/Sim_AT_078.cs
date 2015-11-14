using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_078 : SimTemplate //Enter the Coliseum
    {

        //   Destroy all minions except each player's highest Attack minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if(p.isServer)
            {
                //TODO
                // if same attackvalue -> a random one survives
                int maxat2 = -1;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Angr > maxat2)
                    {
                        maxat2 = m.Angr;
                    }
                }

                List<Minion> maxattackmins = new List<Minion>();
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Angr == maxat2)
                    {
                        maxattackmins.Add(m);
                    }
                }

                Minion survive = p.getRandomMinionOfThatList(maxattackmins);

                foreach (Minion m in p.ownMinions)
                {
                    if (m.entitiyID != survive.entitiyID)
                    {
                        p.minionGetDestroyed(m);
                    }
                }

                //enemy ones

                maxat2 = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr > maxat2)
                    {
                        maxat2 = m.Angr;
                    }
                }

                maxattackmins.Clear();
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr == maxat2)
                    {
                        maxattackmins.Add(m);
                    }
                }

                survive = p.getRandomMinionOfThatList(maxattackmins);

                foreach (Minion m in p.enemyMinions)
                {
                    if (m.entitiyID != survive.entitiyID)
                    {
                        p.minionGetDestroyed(m);
                    }
                }

                return;
            }
            int maxid = 0;
            int maxat = -1;
            foreach (Minion m in p.ownMinions)
            {
                if (m.Angr > maxat)
                {
                    maxat = m.Angr;
                    maxid = m.entitiyID;
                }
            }

            foreach (Minion m in p.ownMinions)
            {
                if (m.entitiyID!=maxid)
                {
                    p.minionGetDestroyed(m);
                }
            }

            maxid = 0;
            maxat = -1;
            foreach (Minion m in p.enemyMinions)
            {
                if (m.Angr > maxat)
                {
                    maxat = m.Angr;
                    maxid = m.entitiyID;
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                if (m.entitiyID != maxid)
                {
                    p.minionGetDestroyed(m);
                }
            }
        }


    }

}