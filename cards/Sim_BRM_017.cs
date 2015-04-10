using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_017 : SimTemplate //Resurrect
    {


        //    Summon a random friendly minion that died this game.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS1_042);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay && Probabilitymaker.Instance.ownGraveYardCommonAttack>=1)
            {
                int posi = p.ownMinions.Count;
                if (Probabilitymaker.Instance.ownGraveYardCommonTaunt == 1)
                {

                    
                    p.callKid(kid, posi, true);
                    Minion m = p.ownMinions[p.ownMinions.Count-1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.ownGraveYardCommonAttack - 1, Probabilitymaker.Instance.ownGraveYardCommonHP - 1);
                }
                else
                {
                    // create minion without taunt
                    p.callKid(kid, posi, true);
                    Minion m = p.ownMinions[p.ownMinions.Count - 1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.ownGraveYardCommonAttack - 1, Probabilitymaker.Instance.ownGraveYardCommonHP - 1);
                    m.taunt = false;
                }
            }


            if (!ownplay && Probabilitymaker.Instance.enemyGraveYardCommonAttack >= 1)
            {
                int posi = p.enemyMinions.Count;
                if (Probabilitymaker.Instance.enemyGraveYardCommonTaunt == 1)
                {


                    p.callKid(kid, posi, false);
                    Minion m = p.enemyMinions[p.enemyMinions.Count - 1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.enemyGraveYardCommonAttack - 1, Probabilitymaker.Instance.enemyGraveYardCommonHP - 1);
                }
                else
                {
                    // create minion without taunt
                    p.callKid(kid, posi, false);
                    Minion m = p.enemyMinions[p.enemyMinions.Count - 1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.enemyGraveYardCommonAttack - 1, Probabilitymaker.Instance.enemyGraveYardCommonHP - 1);
                    m.taunt = false;
                }
            }
        }

    }
}