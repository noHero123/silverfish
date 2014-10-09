// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_301.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_301.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_301.
    /// </summary>
    internal class Sim_EX1_301 : SimTemplate
    {
        // felguard

        // spott/. kampfschrei:/ zerstört einen eurer manakristalle.
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
                p.ownMaxMana--;
            }
            else
            {
                p.enemyMaxMana--;
            }
        }

        #endregion
    }
}