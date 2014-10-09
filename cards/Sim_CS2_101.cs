// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_101.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_101.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_101.
    /// </summary>
    class Sim_CS2_101 : SimTemplate
    {
        // reinforce

        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t); // silverhandrecruit

        // heldenfähigkeit/\nruft einen rekruten der silbernen hand (1/1) herbei.
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
        }
    }
}