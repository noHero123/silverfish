using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_002 : SimTemplate //Flamewaker
    {


        //    After you cast a spell, deal 2 damage randomly split among all enemies.

        public override void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (p.isServer)
                {
                    int timesS = 2;
                    for (int iS = 0; iS < timesS; iS++)
                    {
                        Minion poortarget = p.getRandomMinionFromSide_SERVER(!wasOwnCard, true);
                        if (poortarget != null) p.minionGetDamageOrHeal(poortarget, 1);
                    }
                    return;
                }

                List<Minion> targets = (triggerEffectMinion.own) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);

                if (triggerEffectMinion.own)
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
                while (i < 2)
                {
                    int loc = i % targets.Count;
                    p.minionGetDamageOrHeal(targets[loc], 1);
                    i++;
                }

                triggerEffectMinion.stealth = false;
            }
        }

        public void onCardWasPlayedold(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (p.isServer)
                {
                    int timesS = 2;
                    for (int iS = 0; iS < timesS; iS++)
                    {
                        Minion poortarget = p.getRandomMinionFromSide_SERVER(!wasOwnCard, true);
                        if (poortarget != null) p.minionGetDamageOrHeal(poortarget, 1);
                    }
                    return;
                }

                List<Minion> temp = (triggerEffectMinion.own) ? p.enemyMinions : p.ownMinions;
                for (int i = 0; i < 2; i++)
                {
                    if (temp.Count >= 1)
                    {
                        //search Minion with lowest hp
                        Minion enemy = temp[0];
                        int minhp = 10000;
                        bool found = false;
                        foreach (Minion m in temp)
                        {
                            if (m.name == CardDB.cardName.nerubianegg && m.Hp >= 2) continue; //dont attack nerubianegg!
                            if (m.handcard.card.isToken && m.Hp == 1) continue;
                            if (m.name == CardDB.cardName.defender) continue;
                            if (m.name == CardDB.cardName.spellbender) continue;
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
                            p.minionGetDamageOrHeal(triggerEffectMinion.own ? p.enemyHero : p.ownHero, 1);
                        }

                    }
                    else
                    {
                        p.minionGetDamageOrHeal(triggerEffectMinion.own ? p.enemyHero : p.ownHero, 1);
                    }
                }

                triggerEffectMinion.stealth = false;
            }
        }

    }
}