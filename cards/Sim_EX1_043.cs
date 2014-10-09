// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_043.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_043.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_043.
    /// </summary>
    internal class Sim_EX1_043 : SimTemplate
    {
        // twilightdrake

        // kampfschrei:/ erhält +1 leben für jede karte auf eurer hand.
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
            p.minionGetBuffed(own, 0, own.own ? p.owncards.Count : p.enemyAnzCards);
        }

        #endregion
    }
}