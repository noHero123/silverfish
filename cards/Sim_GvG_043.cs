using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_043 : SimTemplate //Glaivezooka
    {

        //   Battlecry: Give a random friendly minion +1 Attack.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_043);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            if (temp.Count <= 0) return;
            p.minionGetBuffed(p.searchRandomMinion(temp, (ownplay ? Playfield.searchmode.searchLowestHP : Playfield.searchmode.searchHighestHP)), 1, 0);

        }

    }

}