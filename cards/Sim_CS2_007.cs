// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_007.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_007.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_007.
    /// </summary>
    internal class Sim_CS2_007 : SimTemplate
    {
        // healingtouch

        // stellt #8 leben wieder her.
        #region Public Methods and Operators

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = ownplay ? p.getSpellHeal(8) : p.getEnemySpellHeal(8);
            p.minionGetDamageOrHeal(target, -heal);
        }

        #endregion
    }
}