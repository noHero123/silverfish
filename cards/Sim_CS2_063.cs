using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_063 : SimTemplate //corruption
	{

//    wählt einen feindlichen diener aus. vernichtet ihn zu beginn eures zuges.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            //if ownplay == true -> destroyOnOwnturnstart =true   else  destroyonenemyturnstart
            target.destroyOnOwnTurnStart = target.destroyOnOwnTurnStart || ownplay;
            target.destroyOnEnemyTurnStart = target.destroyOnEnemyTurnStart || !ownplay;
            
		}

	}
}