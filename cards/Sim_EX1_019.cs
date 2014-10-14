// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_019.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_019.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_019.
    /// </summary>
    internal class Sim_EX1_019 : SimTemplate
    {
        // shatteredsuncleric

        // kampfschrei:/ verleiht einem befreundeten diener +1/+1.
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
                p.minionGetBuffed(target, 1, 1);
            }
        }

        #endregion
    }
}