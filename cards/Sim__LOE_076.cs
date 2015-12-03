using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_076 : SimTemplate //Sir Finley Mrrgglton
	{
        //Battlecry: Discover a new basic Hero Power.

        //difficult to simmulate... we assume to draw steady shot (yolo), expect if we already have it
        CardDB.Card hp = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DS1h_292);//hunter
        CardDB.Card hp2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_034);//mage

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                //TODO
                if (own.own)
                {
                    if (p.ownHeroAblility.card.name != CardDB.cardName.steadyshot)
                    {
                        p.ownHeroAblility = new Handmanager.Handcard(hp);
                        p.ownAbilityReady = true;
                    }
                    else
                    {
                        p.ownHeroAblility = new Handmanager.Handcard(hp2);
                        p.ownAbilityReady = true;
                    }
                }
                else
                {
                    if (p.enemyHeroAblility.card.name != CardDB.cardName.steadyshot)
                    {
                        p.enemyHeroAblility = new Handmanager.Handcard(hp);
                        p.enemyAbilityReady = true;
                    }
                    else
                    {
                        p.enemyHeroAblility = new Handmanager.Handcard(hp2);
                        p.enemyAbilityReady = true;
                    }

                }

                if (own.own == p.isOwnTurn) p.heroPowerActivationsThisTurn = 0;
                return;
            }

            if (own.own)
            {
                if(p.ownHeroAblility.card.name != CardDB.cardName.steadyshot)
                {
                    p.ownHeroAblility = new Handmanager.Handcard(hp);
                    p.ownAbilityReady = true;
                }
                else
                {
                    p.ownHeroAblility = new Handmanager.Handcard(hp2);
                    p.ownAbilityReady = true;
                }
            }
            else
            {
                if(p.enemyHeroAblility.card.name != CardDB.cardName.steadyshot)
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(hp);
                    p.enemyAbilityReady = true;
                }
                else
                {
                    p.enemyHeroAblility = new Handmanager.Handcard(hp2);
                    p.enemyAbilityReady = true;
                }

            }

            if (own.own == p.isOwnTurn) p.heroPowerActivationsThisTurn = 0;
        }

	}

}
