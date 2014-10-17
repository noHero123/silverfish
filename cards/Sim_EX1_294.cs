using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_294 : SimTemplate //mirrorentity
    {
        //todo secret
        //    geheimnis:/ wenn euer gegner einen diener ausspielt, beschwört ihr eine kopie desselben herbei.

        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {

            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(target.handcard.card, posi, ownplay);
            if (ownplay)
            {
                if (p.ownMinions.Count >= 1 && p.ownMinions[p.ownMinions.Count - 1].name == target.handcard.card.name)
                {
                    int e = p.ownMinions[p.ownMinions.Count - 1].entitiyID;
                    p.ownMinions[p.ownMinions.Count - 1].setMinionTominion(target);
                    p.ownMinions[p.ownMinions.Count - 1].entitiyID = e;
                    p.ownMinions[p.ownMinions.Count - 1].own = true;
                }
            }
            else
            {
                if (p.enemyMinions.Count >= 1 && p.enemyMinions[p.enemyMinions.Count - 1].name == target.handcard.card.name)
                {
                    int e = p.enemyMinions[p.enemyMinions.Count - 1].entitiyID;
                    p.enemyMinions[p.enemyMinions.Count - 1].setMinionTominion(target);
                    p.enemyMinions[p.enemyMinions.Count - 1].entitiyID = e;
                    p.enemyMinions[p.enemyMinions.Count - 1].own = false;
                }
            }
        }

    }

}