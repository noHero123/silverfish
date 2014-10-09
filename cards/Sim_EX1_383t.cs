// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_383t.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_383 t.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_383 t.
    /// </summary>
    class Sim_EX1_383t : SimTemplate
	{
	    // ashbringer

        /// <summary>
        /// The wcard.
        /// </summary>
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_383t);

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
            p.equipWeapon(this.wcard, ownplay);
        }

	}
}