using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_004 : SimTemplate //vanish
	{

//    lasst alle diener auf die hand ihrer besitzer zurückkehren.
        //todo clear playfield
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.anzOwnRaidleader = 0;
            p.anzEnemyRaidleader = 0;
            p.anzOwnStormwindChamps = 0;
            p.anzEnemyStormwindChamps = 0;
            p.anzOwnTundrarhino = 0;
            p.anzEnemyTundrarhino = 0;
            p.anzOwnTimberWolfs = 0;
            p.anzEnemyTimberWolfs = 0;
            p.anzMurlocWarleader = 0;
            p.anzGrimscaleOracle = 0;
            p.anzOwnAuchenaiSoulpriest = 0;
            p.anzEnemyAuchenaiSoulpriest = 0;
            p.anzOwnsorcerersapprentice = 0;
            p.anzOwnsorcerersapprenticeStarted = 0;
            p.anzEnemysorcerersapprentice = 0;
            p.anzEnemysorcerersapprenticeStarted = 0;
            p.anzOwnSouthseacaptain = 0;
            p.anzEnemySouthseacaptain = 0;
            p.doublepriest = 0;
            p.enemydoublepriest = 0;
            p.ownBaronRivendare = 0;
            p.enemyBaronRivendare = 0;

            p.spellpower = 0;
            p.enemyspellpower = 0;



            p.winzigebeschwoererin = 0;
            p.managespenst = 0;
            p.soeldnerDerVenture = 0;
            p.beschwoerungsportal = 0;
            p.nerubarweblord = 0;

            foreach (Minion m in p.ownMinions)
            {
                p.drawACard(m.name, true, true);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.drawACard(m.name, false, true);
            }
            p.ownMinions.Clear();
            p.enemyMinions.Clear();

        }

	}
}