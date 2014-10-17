using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_544 : SimTemplate //flare
    {

        //    alle diener verlieren verstohlenheit/. zerstört alle feindlichen geheimnisse/. zieht eine karte.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                m.stealth = false;
            }
            foreach (Minion m in p.enemyMinions)
            {
                m.stealth = false;
            }
            if (ownplay)
            {
                p.enemySecretCount = 0;
                p.enemySecretList.Clear();
            }
            else
            {
                p.ownSecretsIDList.Clear();
            }
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

    }

}