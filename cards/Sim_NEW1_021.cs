// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_021.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_021.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_021.
    /// </summary>
    internal class Sim_NEW1_021 : SimTemplate
    {
        // doomsayer

        // vernichtet zu beginn eures zuges alle diener.
        #region Public Methods and Operators

        /// <summary>
        /// The on turn start trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnStartOfOwner">
        /// The turn start of owner.
        /// </param>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                p.allMinionsGetDestroyed();
            }
        }

        #endregion
    }
}