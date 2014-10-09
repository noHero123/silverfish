// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_tk9.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_tk 9.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_tk 9.
    /// </summary>
    internal class Sim_EX1_tk9 : SimTemplate
    {
        // treant

        // ansturm/. vernichtet diesen diener am ende des zuges.
        #region Public Methods and Operators

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
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.minionGetDestroyed(triggerEffectMinion);
            }
        }

        #endregion
    }
}