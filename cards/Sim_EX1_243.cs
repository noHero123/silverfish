// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_243.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_243.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_243.
    /// </summary>
    internal class Sim_EX1_243 : SimTemplate
    {
        // dustdevil

        // windzorn/, überladung:/ (2)
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
            if (own.own)
            {
                p.ueberladung += 2;
            }
        }

        #endregion
    }
}