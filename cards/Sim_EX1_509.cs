// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_509.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_509.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_509.
    /// </summary>
    internal class Sim_EX1_509 : SimTemplate
    {
        // murloctidecaller

        // erhält jedes mal +1 angriff, wenn ein murloc herbeigerufen wird.
        #region Public Methods and Operators

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
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.MURLOC)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }

        #endregion
    }
}