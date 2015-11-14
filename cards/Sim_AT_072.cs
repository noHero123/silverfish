using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_072 : SimTemplate //Varian Wrynn
    {

        //Battlecry: Draw 3 cards. Put any minions you drew directly into the battlefield.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_099t);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                for (int i = 0; i < 3; i++)
                {
                    int anzbefore = (own.own) ? p.owncards.Count : p.EnemyCards.Count;
                    p.drawACard(CardDB.cardIDEnum.None, own.own);
                    int anzafter = (own.own) ? p.owncards.Count : p.EnemyCards.Count;
                    // its a mob and we have place on board: summon it!
                    if (anzbefore <= 9 && anzafter >= 1)
                    {
                        Handmanager.Handcard hc = (own.own) ? p.owncards[anzafter - 1] : p.EnemyCards[anzafter - 1];
                        int anzmobs = (own.own)? p.ownMinions.Count : p.enemyMinions.Count; //this includes the battlecry minion :D
                        if (hc.card.type == CardDB.cardtype.MOB && anzmobs < 7)
                        {
                            int posi = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
                            p.callKid(hc.card, posi, own.own, true);
                            if (own.own)
                            {
                                p.owncards.RemoveAt(anzafter - 1);
                            }
                            else
                            {
                                p.enemyMinions.RemoveAt(anzafter - 1);
                            }
                        }
                    }
                }
                return;
            }
            p.drawACard(CardDB.cardIDEnum.None, own.own);
            p.drawACard(CardDB.cardIDEnum.None, own.own);
            p.drawACard(CardDB.cardIDEnum.None, own.own);
            int posi2 = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, posi2, own.own, true);

        }

       

    }
}