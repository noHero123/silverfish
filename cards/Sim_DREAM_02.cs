using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DREAM_02 : SimTemplate //yseraawakens
	{

//    fügt allen charakteren mit ausnahme von ysera $5 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            foreach (Minion m in p.ownMinions)
            {
                if (m.name != CardDB.cardName.ysera) p.minionGetDamageOrHeal(m, dmg);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.name != CardDB.cardName.ysera) p.minionGetDamageOrHeal(m, dmg);
            }
            p.minionGetDamageOrHeal(p.ownHero, dmg);
            p.minionGetDamageOrHeal(p.enemyHero, dmg);

		}

	}
}