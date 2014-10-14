// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_572.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_572.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_572.
    /// </summary>
    internal class Sim_EX1_572 : SimTemplate
    {
        // ysera

        // zieht am ende eures zuges eine traumkarte.
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
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardDB.cardName.yseraawakens, turnEndOfOwner, true);
            }
        }

        #endregion
    }
}