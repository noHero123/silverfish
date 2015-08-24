using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_054 : SimTemplate //The Mistcaller
    {

        //Battlecry: Give all minions in your hand and deck +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                if (own.own)
                {
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            hc.addattack++;
                            hc.addHp++;
                        }
                    }

                    foreach (Handmanager.Handcard hc in p.myDeck)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            hc.addattack++;
                            hc.addHp++;
                        }
                    }
                }
                else
                {
                    foreach (Handmanager.Handcard hc in p.EnemyCards)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            hc.addattack++;
                            hc.addHp++;
                        }
                    }

                    foreach (Handmanager.Handcard hc in p.enemyDeck)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            hc.addattack++;
                            hc.addHp++;
                        }
                    }
                }
                return;
            }

            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB)
                    {
                        hc.addattack++;
                        hc.addHp++;
                    }
                }
            }

        }

       

    }
}