using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_003 : SimTemplate//Mind Vision
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            if (p.isServer)
            {
                List<Handmanager.Handcard> cardss = (ownplay) ? p.EnemyCards : p.owncards;
                if (cardss.Count >= 1)
                {
                    int random = p.getRandomNumber_SERVER(0, cardss.Count - 1);
                    p.drawACard(cardss[random].card.cardIDenum, ownplay, true);
                }
                return;
            }

            int anz = (ownplay) ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 1)
            {
                p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            }
        }

    }
}
