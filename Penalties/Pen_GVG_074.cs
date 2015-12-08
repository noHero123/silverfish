using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_GVG_074 : PenTemplate //kezanmystic
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{

            if (p.enemyHeroName == HeroEnum.hunter || p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.pala)
            {
                return 50;
            }

			return 0;
		}
	}
}
