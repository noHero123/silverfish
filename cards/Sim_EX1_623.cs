// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_623.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_623.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_623.
    /// </summary>
    internal class Sim_EX1_623 : SimTemplate
    {
        // templeenforcer

        // kampfschrei:/ verleiht einem befreundeten diener +3 leben.
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
                p.minionGetBuffed(target, 0, 3);
            }
        }

        #endregion
    }
}