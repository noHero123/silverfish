// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_013.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_013.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_013.
    /// </summary>
    class Sim_CS2_013 : SimTemplate
	{
	    // wildgrowth

// erhaltet einen leeren manakristall.
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
            if (ownplay)
            {
                if (p.ownMaxMana < 10)
                {
                    p.ownMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, true, true);
                }

            }
            else
            {
                if (p.enemyMaxMana < 10)
                {
                    p.enemyMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, false, true);
                }
            }
		}

	}
}