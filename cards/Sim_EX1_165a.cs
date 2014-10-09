// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_165a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_165 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_165 a.
    /// </summary>
    class Sim_EX1_165a : SimTemplate
	{
	    // catform

// ansturm/
        /// <summary>
        /// The cat.
        /// </summary>
        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t1);

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionTransform(own, this.cat);
            
        }

	}
}