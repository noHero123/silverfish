// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_031.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_031.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_031.
    /// </summary>
    class Sim_NEW1_031 : SimTemplate
	{
	    // animalcompanion

// ruft einen zufälligen wildtierbegleiter herbei.
        /// <summary>
        /// The c 2.
        /// </summary>
        CardDB.Card c2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_032);// misha

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
            int placeoffather = ownplay?  p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.c2, placeoffather, ownplay);
		}

	}
}