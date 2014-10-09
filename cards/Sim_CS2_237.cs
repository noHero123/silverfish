// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_237.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_237.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_237.
    /// </summary>
    class Sim_CS2_237 : SimTemplate
	{
	    // starvingbuzzard

// zieht jedes mal eine karte, wenn ihr ein wildtier herbeiruft.
        /// <summary>
        /// The on minion is summoned.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="summonedMinion">
        /// The summoned minion.
        /// </param>
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && (TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PET)
            {
                p.drawACard(CardDB.cardName.unknown, triggerEffectMinion.own);
            }
        }

	}
}