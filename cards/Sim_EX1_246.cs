// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_246.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_246.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_246.
    /// </summary>
    class Sim_EX1_246 : SimTemplate
    {
        // hex
        /// <summary>
        /// The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.hexfrog);

        // verwandelt einen diener in einen frosch (0/1) mit spott/.

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
            p.minionTransform(target, this.card);
        }
    }
}