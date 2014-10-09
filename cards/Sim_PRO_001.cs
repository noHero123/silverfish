// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_PRO_001.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ pr o_001.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ pr o_001.
    /// </summary>
    internal class Sim_PRO_001 : SimTemplate
    {
        // elitetaurenchieftain

        // kampfschrei:/ verleiht beiden spielern die macht des rock! (durch eine powerakkordkarte)
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
            p.drawACard(CardDB.cardName.roguesdoit, true, true);
            p.drawACard(CardDB.cardName.roguesdoit, false, true);
        }

        #endregion
    }
}