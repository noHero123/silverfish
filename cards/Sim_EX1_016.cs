using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_016 : SimTemplate //sylvanaswindrunner
	{
        //todo make it better
//    todesröcheln:/ übernehmt die kontrolle über einen zufälligen feindlichen diener.
        public override void onDeathrattle(Playfield p, Minion m)
        {
                List<Minion> tmp = (m.own) ? p.enemyMinions : p.ownMinions;
                if (tmp.Count >= 1)
                {
                    Minion target = null;
                    int value = 10000;
                    bool found = false;

                    //search smallest minion:
                    foreach (Minion mnn in tmp)
                    {
                        if (mnn.Hp < value && mnn.Hp >= 1)
                        {
                            target = mnn;
                            value = target.Hp;
                            found = true;
                        }
                    }
                    if (found) p.minionGetControlled(target, m.own, false);
                }

            
        }

	}
}