using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_090 : SimTemplate //Madder Bomber
    {

        //   Battlecry: Deal 6 damage randomly split between all other characters.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (p.isServer)
            {
                int timesS = 6;
                for (int iS = 0; iS < timesS; iS++)
                {
                    Minion poortarget = p.getRandomCharExcept_SERVER(own, true);
                    if (poortarget != null) p.minionGetDamageOrHeal(poortarget, 1);
                }
                return;
            }

            int anz = 6;
            for (int i = 0; i < anz; i++)
            {
                if (p.ownHero.Hp <= anz)
                {
                    p.minionGetDamageOrHeal(p.ownHero, 1);
                    continue;
                }
                List<Minion> temp = new List<Minion>(p.enemyMinions);
                if (temp.Count == 0)
                {
                    temp.AddRange(p.ownMinions);
                }
                temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//destroys the weakest

                foreach (Minion m in temp)
                {
                    p.minionGetDamageOrHeal(m, 1);
                    break;
                }
                p.minionGetDamageOrHeal(p.enemyHero, 1);
            }
        }


    }

}