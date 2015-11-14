using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_011 : SimTemplate //Reno Jackson
    {

        //Battlecry: If your deck contains no more than 1 of any card, fully heal your hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                //TODO
                return;
            }

            if (own.own)
            {
                if (Probabilitymaker.Instance.hasDeck)
                {
                    //TODO heal hero based on current deck
                }
                else
                {
                    if (p.ownDeckSize <= 15)
                    {
                        p.minionGetDamageOrHeal(p.ownHero, -15, true);
                    }
                    if (p.ownDeckSize <= 10)
                    {
                        p.minionGetDamageOrHeal(p.ownHero, -5, true);//because he is also healed with 15hp :D
                    }
                    if (p.ownDeckSize <= 5)
                    {
                        p.minionGetDamageOrHeal(p.ownHero, -30, true);//fully heal
                    }
                }
            }
            else
            {
                if (p.enemyDeckSize <= 15)
                {
                    p.minionGetDamageOrHeal(p.enemyHero, -15, true);
                }
                if (p.enemyDeckSize <= 10)
                {
                    p.minionGetDamageOrHeal(p.enemyHero, -5, true);//because he is also healed with 15hp :D
                }
                if (p.enemyDeckSize <= 5)
                {
                    p.minionGetDamageOrHeal(p.enemyHero, -30, true);//fully heal
                }
            }
        }

       

    }
}