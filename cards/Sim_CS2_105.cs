// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_105.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_105.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_105.
    /// </summary>
    class Sim_CS2_105 : SimTemplate
	{
	    // heroicstrike

// verleiht eurem helden +4 angriff in diesem zug.
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
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 4, 0);
            }

		}

	}
}