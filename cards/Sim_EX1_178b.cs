// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_178b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_178 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_178 b.
    /// </summary>
    internal class Sim_EX1_178b : SimTemplate
    {
        // uproot

        // +5 angriff.
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
            p.minionGetBuffed(own, 5, 0);
        }

        #endregion
    }
}