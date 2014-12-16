using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_008 : SimTemplate //spectralknight
	{

//    kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
	}
}