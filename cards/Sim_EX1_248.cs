// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_248.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_248.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_248.
    /// </summary>
    class Sim_EX1_248 : SimTemplate
    {
        // feralspirit
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk11); // spiritwolf

        // ruft zwei geisterwölfe (2/3) mit spott/ herbei. überladung:/ (2)

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

            p.callKid(this.kid, posi, ownplay);
            p.callKid(this.kid, posi, ownplay);
            if (ownplay)
            {
                p.ueberladung += 2;
            }
        }
    }
}