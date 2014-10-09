// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_084.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_084.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_084.
    /// </summary>
    internal class Sim_EX1_084 : SimTemplate
    {
        // warsongcommander

        // jedes mal, wenn ihr einen diener mit max. 3 angriff herbeiruft, erhält dieser ansturm/.
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
            if (triggerEffectMinion.own == summonedMinion.own && summonedMinion.handcard.card.Attack <= 3)
            {
                p.minionGetCharge(summonedMinion);
            }
        }

        #endregion
    }
}