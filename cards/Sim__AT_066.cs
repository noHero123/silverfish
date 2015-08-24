using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_066 : SimTemplate //Dalaran Aspirant
    {

        //insprire: gain Spell Damage +1

        public override void onInspire(Playfield p, Minion m)
        {
            
            if (m.own && p.ownWeaponDurability>=1)
            {
                p.ownWeaponAttack++;
            }
            if (!m.own && p.enemyWeaponDurability >= 1)
            {
                p.enemyWeaponAttack++;
            }
        }



    }

}