// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_564.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_564.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_564.
    /// </summary>
    internal class Sim_EX1_564 : SimTemplate
    {
        // facelessmanipulator

        // kampfschrei:/ wählt einen diener aus, um gesichtsloser manipulator in eine kopie desselben zu verwandeln.
        #region Public Methods and Operators

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                // p.copyMinion(own, target);
                own.setMinionTominion(target);
                own.handcard.card.sim_card.onAuraStarts(p, own);
            }
        }

        #endregion
    }
}