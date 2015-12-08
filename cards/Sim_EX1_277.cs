using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_277 : SimTemplate //arcanemissiles
    {

        //    verursacht $3 schaden, der zufällig auf feindliche charaktere verteilt wird.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            if (p.isServer)
            {
                int timesS = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
                for (int iS = 0; iS < timesS; iS++)
                {
                    Minion poortarget = p.getRandomMinionFromSide_SERVER(!ownplay, true);
                    if (poortarget != null) p.minionGetDamageOrHeal(poortarget, 1);
                }
                return;
            }


            List<Minion> targets = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            int times = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

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

        public  void onCardPlayold(Playfield p, bool ownplay, Minion target, int choice)
        {

            if (p.isServer)
            {
                int timesS = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
                for (int iS = 0; iS < timesS; iS++)
                {
                    Minion poortarget = p.getRandomMinionFromSide_SERVER(!ownplay, true);
                    if (poortarget != null) p.minionGetDamageOrHeal(poortarget, 1);
                }
                return;
            }


            // optimistic
            int i = 0;
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            int times = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            if ((ownplay && p.enemyHero.Hp <= times) || (!ownplay && p.ownHero.Hp <= times))
            {
                if (ownplay) p.minionGetDamageOrHeal(p.enemyHero, p.enemyHero.Hp - 1);
                else p.minionGetDamageOrHeal(p.ownHero, p.ownHero.Hp - 1);
            }
            else
            {
                while (i < times)
                {
                    if (temp.Count >= 1)
                    {
                        //search Minion with lowest hp
                        Minion enemy = temp[0];
                        int minhp = 10000;
                        bool found = false;
                        foreach (Minion m in temp)
                        {
                            if (m.name == CardDB.cardName.nerubianegg && enemy.Hp >= 2) continue; //dont attack nerubianegg!

                            if (m.Hp >= 2 && minhp > m.Hp)
                            {
                                enemy = m;
                                minhp = m.Hp;
                                found = true;
                            }
                        }

                        if (found)
                        {
                            p.minionGetDamageOrHeal(enemy, 1);
                        }
                        else
                        {
                            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, 1);
                        }

                    }
                    else
                    {
                        p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, 1);
                    }

                    i++;
                }
            }
        }

    }

}