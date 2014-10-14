// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_tt_004.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_tt_004.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_tt_004.
    /// </summary>
    internal class Sim_tt_004 : SimTemplate
    {
        // flesheatingghoul

        // erhält jedes mal +1 angriff, wenn ein diener stirbt.
        #region Public Methods and Operators

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
            p.minionGetBuffed(triggerEffectMinion, 1, 0);
        }

        #endregion
    }
}