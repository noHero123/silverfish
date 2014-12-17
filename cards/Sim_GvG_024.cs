using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_024 : SimTemplate //Cogmaster's Wrench
    {

        //    Has +2 Attack while you have a Mech.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_024);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            bool hasmech = false;
            foreach (Minion m in temp)
            {
                //if we have allready a mechanical, we are buffed
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmech=true;
            }
            if (hasmech)
            {
                if (ownplay)
                {
                    p.ownWeaponAttack += 2;
                    p.minionGetBuffed(p.ownHero, 2, 0);
                }
                else
                {
                    p.enemyWeaponAttack += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                }
            }


        }

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.MECHANICAL)
            {
                List<Minion> temp = (triggerEffectMinion.own) ? p.ownMinions : p.enemyMinions;

                foreach (Minion m in temp)
                {
                    //if we have allready a mechanical, we are buffed
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) return; 
                }

                //we had no mechanical, but now!
                if (triggerEffectMinion.own)
                {
                    p.ownWeaponAttack += 2;
                    p.minionGetBuffed(p.ownHero, 2, 0);
                }
                else
                {
                    p.enemyWeaponAttack += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                }
            }
        }


        //on minon died is handled in playfield


    }

}