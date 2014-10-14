// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_317.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_317.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_317.
    /// </summary>
    internal class Sim_EX1_317 : SimTemplate
    {
        // sensedemons

        // fügt eurer hand zwei zufällige dämonen aus eurem deck hinzu.
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
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

        #endregion
    }
}