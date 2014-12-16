using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_059 : SimTemplate //Coghammer
    {

        //   Battlecry: Give a random friendly minion Divine Shield and Taunt;.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            Minion m = p.searchRandomMinion(temp, Playfield.searchmode.searchLowestHP);
            m.divineshild = true;
            m.taunt = true;
        }

    }

}