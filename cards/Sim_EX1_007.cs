using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_007 : SimTemplate//Acolyte of Pain
    {
        //  <deDE>Zieht jedes Mal eine Karte, wenn dieser Diener Schaden erleidet.</deDE>
        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdMinion)
        {
            if (triggerEffectMinion.anzGotDmg >= 1)
            {
                for (int i = 0; i < triggerEffectMinion.anzGotDmg; i++)
                {
                    p.drawACard(CardDB.cardIDEnum.None, triggerEffectMinion.own);
                }
                triggerEffectMinion.anzGotDmg = 0;
            }
        }
    }
}
