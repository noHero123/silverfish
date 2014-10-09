// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_349.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_349.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_349.
    /// </summary>
    internal class Sim_EX1_349 : SimTemplate
    {
        // divinefavor

        // zieht so viele karten, bis ihr genauso viele karten auf eurer hand habt wie euer gegner.
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
            int diff = ownplay ? p.enemyAnzCards - p.owncards.Count : p.owncards.Count - p.enemyAnzCards;
            if (diff >= 1)
            {
                for (int i = 0; i < diff; i++)
                {
                    // this.owncarddraw++;
                    p.drawACard(CardDB.cardName.unknown, ownplay);
                }
            }
        }

        #endregion
    }
}