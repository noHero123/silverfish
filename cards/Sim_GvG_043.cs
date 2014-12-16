using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_043 : SimTemplate //Glaivezooka
    {

        //   Battlecry: Give a random friendly minion +1 Attack.
        

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            p.minionGetBuffed(p.searchRandomMinion(temp, Playfield.searchmode.searchLowestAttack), 1, 0);

        }

    }

}