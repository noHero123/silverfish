using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_087 : SimTemplate //Steamwheedle Sniper
    {

        //  Your Hero Power can target minions. 

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own) 
            {
                if(p.ownHeroName == HeroEnum.hunter)   p.weHaveSteamwheedleSniper = true;
            }
            else
            {
                if (p.enemyHeroName == HeroEnum.hunter) p.enemyHaveSteamwheedleSniper = true;
            }
        }

        public override void  onAuraEnds(Playfield p, Minion m)
        {
            if (m.own && p.ownHeroName == HeroEnum.hunter)
            {
                bool hasss = false;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (!mnn.silenced && m.name == CardDB.cardName.steamwheedlesniper)
                    {
                        hasss = true;
                    }
                }
                p.weHaveSteamwheedleSniper = hasss;
               
            }
            if (!m.own && p.enemyHeroName == HeroEnum.hunter)
            {
                bool hasss = false;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (!mnn.silenced && m.name == CardDB.cardName.steamwheedlesniper)
                    {
                        hasss = true;
                    }
                }
                p.enemyHaveSteamwheedleSniper = hasss;
            }
        }


    }

}