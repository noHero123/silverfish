// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_345.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_345.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_345.
    /// </summary>
    class Sim_EX1_345 : SimTemplate
	{
	    // mindgames

// legt eine kopie eines zufälligen dieners aus dem deck eures gegners auf das schlachtfeld.

        /// <summary>
        /// The copymin.
        /// </summary>
        CardDB.Card copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_182); // we take a icewindjety :D

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
            p.callKid(this.copymin, p.ownMinions.Count, true);
		}

	}
}