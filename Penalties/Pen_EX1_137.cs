using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_137 : PenTemplate //headcrack
	{

//    fügt dem feindlichen helden $2 schaden zu. combo:/ lasst die karte in eurem nächsten zug wieder auf eure hand zurückkehren.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}