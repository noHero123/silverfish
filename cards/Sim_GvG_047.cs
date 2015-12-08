using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_047 : SimTemplate //Sabotage
    {

        //   Destroy a random enemy minion. Combo: And your opponent's weapon.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if(p.isServer)
            {
                Minion choosen = p.getRandomMinionFromSide_SERVER(!ownplay, false);
                if (choosen != null) p.minionGetDestroyed(choosen);
                if (p.cardsPlayedThisTurn >= 1) p.lowerWeaponDurability(1000, !ownplay);
                return;
            }

            List<Minion> temp = (ownplay)? p.enemyMinions : p.ownMinions;
            if (temp.Count >= 1)
            {
                p.minionGetDestroyed(p.searchRandomMinion(temp, (ownplay ? Playfield.searchmode.searchLowestAttack : Playfield.searchmode.searchHighestAttack)));
                
            }
            if (p.cardsPlayedThisTurn >= 1) p.lowerWeaponDurability(1000, !ownplay);
        }


    }

}