using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_037 : SimTemplate //Living Roots
    {

        //   Choose One - Deal $2 damage; or Summon two 1/1 Saplings..
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_037t);//sapp
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1)
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                if(target!=null) p.minionGetDamageOrHeal(target, dmg);
            }
            if (choice == 2)
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos, ownplay);
            }
        }

    }


}