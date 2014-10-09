// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_595.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_595.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_595.
    /// </summary>
    class Sim_EX1_595 : SimTemplate
	{
	    // cultmaster

// zieht jedes mal eine karte, wenn einer eurer anderen diener stirbt.

        /// <summary>
        /// The on minion died trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="diedMinion">
        /// The died minion.
        /// </param>
        public override void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            if (triggerEffectMinion.own == diedMinion.own)
            {
                p.drawACard(CardDB.cardName.unknown, triggerEffectMinion.own);
            }
        }

	}
}