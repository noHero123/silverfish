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
            if (p.isServer)
            {
                Minion choosen = p.getRandomMinionFromSide_SERVER(!m.own, false);
                if (choosen != null) p.minionGetControlled(choosen, m.own, false);
                return;
            }

                List<Minion> tmp = (m.own) ? p.enemyMinions : p.ownMinions;
                if (tmp.Count >= 1)
                {
                    Minion target = null;
                    int value = 10000;
                    bool found = false;

                    //search smallest minion:
                    if (m.own)
                    {
                        foreach (Minion mnn in tmp)
                        {
                            if (mnn.Hp < value && mnn.Hp >= 1)
                            {
                                target = mnn;
                                value = target.Hp;
                                found = true;
                            }
                        }
                    }
                    else
                    {
                        //steal a minion with has not attacked or has taunt
                        value = -1000;
                        foreach (Minion mnn in tmp)
                        {
                            int special = (m.Ready) ? 10 : 0;
                            special += (m.taunt) ? 5 : 0;
                            special += mnn.Hp;
                            if (special > value)
                            {
                                
                                target = mnn;
                                value = special;
                                found = true;
                            }
                        }
                    }
                    if (found) p.minionGetControlled(target, m.own, false);
                }

            
        }

	}
}