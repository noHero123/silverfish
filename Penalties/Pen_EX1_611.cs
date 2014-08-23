using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_611 : PenTemplate //freezingtrap
	{

//    geheimnis:/ wenn ein feindlicher diener angreift, lasst ihn auf die hand seines besitzers zurückkehren. zusätzlich kostet er (2) mehr.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}