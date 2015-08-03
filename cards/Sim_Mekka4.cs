using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_Mekka4 : SimTemplate //poultryizer
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka4t);
                                
//    verwandelt zu beginn eures zuges einen zufälligen diener in ein huhn (1/1).

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (p.isServer)
                {
                    Minion choosen = p.getRandomCharExcept_SERVER(null, false);
                    if (choosen != null) p.minionTransform(choosen, c);
                    return;
                }

                Minion tm = null;
                int ges = 1000;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }
                if (ges <= 999)
                {
                    p.minionTransform(tm, c);
                }
            }
        }

      

	}
}