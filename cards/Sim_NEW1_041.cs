using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_041 : SimTemplate//Stampeding Kodo
    {
        //todo list
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                List<Minion> temp22 = (own.own) ? p.enemyMinions : p.ownMinions;
                List<Minion> temp23 = new List<Minion>();
                foreach (Minion enemy in temp22)
                {
                    if (enemy.Angr <= 2)
                    {
                        temp23.Add(enemy);
                    }
                }
                Minion choosen = p.getRandomMinionOfThatList(temp23);
                if (choosen != null) p.minionGetDestroyed(choosen);
                return;
            }
            List<Minion> temp2 = (own.own) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//destroys the weakest
            foreach (Minion enemy in temp2)
            {
                if (enemy.Angr <= 2)
                {
                    p.minionGetDestroyed(enemy);
                    break;
                }
            }

        }


    }
}
