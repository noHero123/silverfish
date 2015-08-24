using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_002 : SimTemplate // effigy
    {

        //    if minion dies, summon another one with same manacost


        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {

            //TODO SERVER

            //we just revive it
            int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            CardDB.Card kid = CardDB.Instance.getCardDataFromID(ownplay ? p.revivingOwnMinion : p.revivingEnemyMinion);
            p.callKid(kid, posi, ownplay);
        }

       


    }

}