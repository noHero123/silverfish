// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_570.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_570.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_570.
    /// </summary>
    class Sim_EX1_570 : SimTemplate
	{
	    // bite

// verleiht eurem helden +4 angriff in diesem zug und 4 rüstung.

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
                p.minionGetTempBuff(p.ownHero, 4, 0);
                p.ownHero.armor += 4;
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 4, 0);
                p.enemyHero.armor += 4;

            }
		}

	}
}