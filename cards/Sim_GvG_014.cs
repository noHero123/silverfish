using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_014 : SimTemplate //Vol'jin
    {
        //todo: what happens if the target is damaged?
       //Battlecry: Swap Health with another minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            int volMHp = own.maxHp;
            int tarMHp = target.Hp;


            target.maxHp = volMHp;
            if (tarMHp < volMHp)//minion has lower maxHp as his card -> heal his hp
            {
                target.Hp += volMHp - tarMHp; //heal minion
            }
            if (target.Hp > target.maxHp) 
            {
                target.Hp = target.maxHp;
            }

            own.maxHp = tarMHp;
            own.Hp = tarMHp;

        }

    }

}