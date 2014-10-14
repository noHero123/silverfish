// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_038.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_038.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_038.
    /// </summary>
    internal class Sim_NEW1_038 : SimTemplate
    {
        // Gruul
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
            p.minionGetBuffed(triggerEffectMinion, 1, 1);
        }

        #endregion
    }
}