using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_117 : SimTemplate //Master of Ceremonies
    {

        //Battlecry: If you have a minion with Spell Damage, gain +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            bool hasdragon = false;
            foreach (Minion m in (own.own) ? p.ownMinions : p.enemyMinions)
            {
                if (m.spellpower >= 1) hasdragon = true;
            }
            if (hasdragon)
            {
                p.minionGetBuffed(own, 2, 2);
            }

        }

       

    }
}