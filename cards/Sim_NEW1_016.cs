// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_016.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_016.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_016.
    /// </summary>
    internal class Sim_NEW1_016 : SimTemplate
    {
        // captainsparrot

        // kampfschrei:/ fügt eurer hand einen zufälligen piraten aus eurem deck hinzu.
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
            p.drawACard(CardDB.cardName.unknown, true, true);
        }

        #endregion
    }
}