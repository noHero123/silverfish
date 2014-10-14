// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_561.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_561.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_561.
    /// </summary>
    internal class Sim_EX1_561 : SimTemplate
    {
        // alexstrasza

        // kampfschrei:/ setzt das verbleibende leben eines helden auf 15.
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
            target.Hp = 15;
        }

        #endregion
    }
}