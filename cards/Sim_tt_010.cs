using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_tt_010 : SimTemplate //spellbender
    {
        //todo secret
        //    geheimnis:/ wenn ein feind einen zauber auf einen diener wirkt, ruft ihr einen diener (1/3) als neues ziel herbei.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.tt_010a);

        public override void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
            if (ownplay)
            {
                int posi = p.ownMinions.Count;
                p.callKid(kid, posi, true);
                if (p.ownMinions.Count >= 1)
                {
                    if (p.ownMinions[p.ownMinions.Count - 1].name == CardDB.cardName.spellbender)
                    {
                        number = p.ownMinions[p.ownMinions.Count - 1].entitiyID;
                    }
                }
            }
            else
            {
                int posi = p.enemyMinions.Count;
                p.callKid(kid, posi, false);

                if (p.enemyMinions.Count >= 1)
                {
                    if (p.enemyMinions[p.enemyMinions.Count - 1].name == CardDB.cardName.spellbender)
                    {
                        number = p.enemyMinions[p.enemyMinions.Count - 1].entitiyID;
                    }
                }
            }

        }

    }

}