// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_362.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_362.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_362.
    /// </summary>
    internal class Sim_EX1_362 : SimTemplate
    {
        // argentprotector

        // kampfschrei:/ verleiht einem befreundeten diener gottesschild/.
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
                target.divineshild = true;
            }
        }

        #endregion
    }
}