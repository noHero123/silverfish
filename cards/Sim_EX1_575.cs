// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_575.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_575.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_575.
    /// </summary>
    internal class Sim_EX1_575 : SimTemplate
    {
        // manatidetotem

        // zieht am ende eures zuges eine karte.
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
                p.drawACard(CardDB.cardName.unknown, turnEndOfOwner);
            }
        }

        #endregion
    }
}