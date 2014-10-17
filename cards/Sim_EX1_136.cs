using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_136 : SimTemplate //redemption
    {
        //todo secret
        //    geheimnis:/ wenn einer eurer diener stirbt, wird er mit 1 leben wiederbelebt.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            CardDB.Card kid = CardDB.Instance.getCardDataFromID(ownplay ? p.revivingOwnMinion : p.revivingEnemyMinion);

            p.callKid(kid, posi, ownplay);
            if (ownplay)
            {
                if (p.ownMinions.Count >= 1)
                {
                    if (p.ownMinions[p.ownMinions.Count - 1].handcard.card.cardIDenum == kid.cardIDenum)
                    {
                        p.ownMinions[p.ownMinions.Count - 1].Hp = 1;
                        p.ownMinions[p.ownMinions.Count - 1].wounded = false;
                        if (p.ownMinions[p.ownMinions.Count - 1].Hp < p.ownMinions[p.ownMinions.Count - 1].maxHp)
                        {
                            p.ownMinions[p.ownMinions.Count - 1].wounded = true;
                        }
                    }
                }
            }
            else
            {
                if (p.enemyMinions.Count >= 1)
                {
                    if (p.enemyMinions[p.enemyMinions.Count - 1].handcard.card.cardIDenum == kid.cardIDenum)
                    {
                        p.enemyMinions[p.enemyMinions.Count - 1].Hp = 1;
                        p.enemyMinions[p.enemyMinions.Count - 1].wounded = false;
                        if (p.enemyMinions[p.enemyMinions.Count - 1].Hp < p.enemyMinions[p.enemyMinions.Count - 1].maxHp)
                        {
                            p.enemyMinions[p.enemyMinions.Count - 1].wounded = true;
                        }
                    }
                }
            }

        }

    }
}