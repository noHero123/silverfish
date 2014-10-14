// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_002.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_002.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_002.
    /// </summary>
    internal class Sim_EX1_002 : SimTemplate
    {
        // theblackknight

        // kampfschrei:/ vernichtet einen feindlichen diener mit spott/.
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
                p.minionGetDestroyed(target);
            }
        }

        #endregion
    }
}