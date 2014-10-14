// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_048.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_048.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_048.
    /// </summary>
    internal class Sim_EX1_048 : SimTemplate
    {
        // spellbreaker

        // kampfschrei:/ bringt einen diener zum schweigen/.
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
                p.minionGetSilenced(target);
            }
        }

        #endregion
    }
}