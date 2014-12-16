using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DREAM_01 : SimTemplate //laughingsister
	{

//    kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
	}
}