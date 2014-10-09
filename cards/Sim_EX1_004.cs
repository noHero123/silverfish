// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_004.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_004.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_004.
    /// </summary>
    class Sim_EX1_004 : SimTemplate
	{
	    // youngpriestess

// verleiht am ende eures zuges einem anderen zufälligen befreundeten diener +1 leben.
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
            List<Minion> temp2 = new List<Minion>(turnEndOfOwner ? p.ownMinions : p.enemyMinions);
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));// buff the weakest
            foreach (Minion mins in temp2)
            {
                if (triggerEffectMinion.entitiyID == mins.entitiyID) continue;
                p.minionGetBuffed(mins, 0, 1);
                break;
            }
        }

	}
}