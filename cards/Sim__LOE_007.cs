using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_007 : SimTemplate //curse of rafaam
    {

        //give your opponent a cursed! card. while they hold it, they take 2 damage on their turn.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            if (ownplay)
            {
                if (p.enemyAnzCards < 10)
                {
                    p.anzEnemyCursed++;
                    p.drawACard(CardDB.cardIDEnum.LOE_007t, false, true);
                }
            }
            else
            {
                if (p.owncards.Count < 10)
                {
                    p.drawACard(CardDB.cardIDEnum.LOE_007t,true, true);
                }
            }
        }


       

    }
}