// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_028.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_028.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_028.
    /// </summary>
    internal class Sim_FP1_028 : SimTemplate
    {
        // undertaker

        // erhält jedes mal +1/+1, wenn ihr einen diener mit todesröcheln/ herbeiruft.
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
            if (triggerEffectMinion.own == summonedMinion.own)
            {
                if (summonedMinion.handcard.card.deathrattle)
                {
                    p.minionGetBuffed(triggerEffectMinion, 1, 1);
                }
            }
        }

        #endregion
    }
}