using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_004 : SimTemplate //Goblin Blastmage
    {

        //    Battlecry: If you have a Mech, deal 4 damage randomly split among all enemies.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            // conservative/realistic
            bool ownplay = own.own;
            List<Minion> temp1 = (ownplay) ? p.ownMinions : p.enemyMinions;
            bool haveAMech = false;
            foreach (Minion m in temp1)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                {
                    haveAMech = true;
                    break;
                }
            }
            if (!haveAMech) return;

            if (p.isServer)
            {
                int timesS = 4;
                for (int iS = 0; iS < timesS; iS++)
                {
                    Minion poortarget = p.getRandomMinionFromSide_SERVER(!ownplay, true);
                    if (poortarget != null) p.minionGetDamageOrHeal(poortarget, 1);
                }
                return;
            }

            List<Minion> targets = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            int times = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            if (ownplay)
            {
                targets.Add(p.enemyHero);
                targets.Sort((a, b) => -a.Hp.CompareTo(b.Hp));  // most hp -> least
            }
            else
            {
                targets.Add(p.ownHero);
                targets.Sort((a, b) => a.Hp.CompareTo(b.Hp));  // least hp -> most
            }

            // Distribute the damage evenly among the targets
            int i = 0;
            while (i < times)
            {
                int loc = i % targets.Count;
                p.minionGetDamageOrHeal(targets[loc], 1);
                i++;
            }
        }

    }

}