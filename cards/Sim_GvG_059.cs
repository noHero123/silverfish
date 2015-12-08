using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_059 : SimTemplate //Coghammer
    {

        //   Battlecry: Give a random friendly minion Divine Shield and Taunt;.
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_059);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            if (temp.Count <= 0) return;

            if (p.isServer)
            {
                Minion choosen = p.getRandomMinionFromSide_SERVER(ownplay, false);
                if (choosen != null)
                {
                    choosen.divineshild = true;
                    choosen.taunt = true;
                }
                return;
            }

            Minion m = p.searchRandomMinion(temp, (ownplay ? Playfield.searchmode.searchLowestAttack : Playfield.searchmode.searchHighestAttack));
            m.divineshild = true;
            m.taunt = true;
        }


    }

}