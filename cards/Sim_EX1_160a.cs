// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_160a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_160 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_160 a.
    /// </summary>
    class Sim_EX1_160a : SimTemplate
    {
        // summonapanther
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160t); // panther

        // ruft einen panther (3/2) herbei.

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
            int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, posi, true);
        }
    }
}