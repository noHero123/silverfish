// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_005.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_005.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_005.
    /// </summary>
    internal class Sim_FP1_005 : SimTemplate
    {
        // shadeofnaxxramas

        // verstohlenheit/. erhält zu beginn eures zuges +1/+1.
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
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }

        #endregion
    }
}