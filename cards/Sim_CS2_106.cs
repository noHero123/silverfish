// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_106.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_106.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_106.
    /// </summary>
    class Sim_CS2_106 : SimTemplate
	{
	    // fierywaraxe
        /// <summary>
        /// The card.
        /// </summary>
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_106);

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
            p.equipWeapon(this.card, ownplay);
		}

	}
}