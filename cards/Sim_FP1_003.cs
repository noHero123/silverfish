// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_003.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_003.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_003.
    /// </summary>
    class Sim_FP1_003 : SimTemplate
	{
	    // echoingooze

// kampfschrei:/ beschwört am ende des zuges eine exakte kopie dieses dieners.
        /// <summary>
        /// The on turn ends trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnEndOfOwner">
        /// The turn end of owner.
        /// </param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.playedThisTurn && triggerEffectMinion.own == turnEndOfOwner)
            {
                p.callKid(triggerEffectMinion.handcard.card, triggerEffectMinion.zonepos, turnEndOfOwner);
                List<Minion> temp = turnEndOfOwner ? p.ownMinions : p.enemyMinions;
                foreach (Minion mnn in temp)
                {
                    if (mnn.name == CardDB.cardName.echoingooze && triggerEffectMinion.entitiyID != mnn.entitiyID)
                    {
                        mnn.setMinionTominion(triggerEffectMinion);
                        break;
                    }
                }
            }
        }

	}
}