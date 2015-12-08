using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_022 : SimTemplate //Tinker's Sharpsword Oil
    {

        //    Give your weapon +3 Attack. Combo: Give a random friendly minion +3 Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.isServer)
            {
                if (ownplay)
                {
                    if (p.ownWeaponDurability >= 1)
                    {
                        p.ownWeaponAttack += 3;
                        p.minionGetBuffed(p.ownHero, 3, 0);
                    }
                    
                }
                else
                {
                    if (p.enemyWeaponDurability >= 1)
                    {
                        p.enemyWeaponAttack += 3;
                        p.minionGetBuffed(p.enemyHero, 3, 0);
                    }
                    
                }

                if (p.cardsPlayedThisTurn >= 1 )
                {
                    Minion choosen = p.getRandomMinionFromSide_SERVER(ownplay, false);
                    if (choosen != null) p.minionGetBuffed(choosen, 3, 0); 
                }
                
                return;
            }

            if (ownplay)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.ownWeaponAttack += 3;
                    p.minionGetBuffed(p.ownHero, 3, 0);
                }
                if (p.cardsPlayedThisTurn >= 1 && p.ownMinions.Count >= 1)
                {
                    p.minionGetBuffed(p.searchRandomMinion(p.ownMinions, Playfield.searchmode.searchLowestHP), 3, 0);
                }
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponAttack += 3;
                    p.minionGetBuffed(p.enemyHero, 3, 0);
                }
                if (p.cardsPlayedThisTurn >= 1 && p.enemyMinions.Count >= 1)
                {
                    p.minionGetBuffed(p.searchRandomMinion(p.enemyMinions, Playfield.searchmode.searchHighestHP), 3, 0);
                }
            }
        }


    }

}