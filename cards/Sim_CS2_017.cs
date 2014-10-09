// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_017.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_017.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_017.
    /// </summary>
    class Sim_CS2_017 : SimTemplate
	{
	    // shapeshift

// heldenfähigkeit/\n+1 angriff in diesem zug.\n+1 rüstung.

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
                p.minionGetTempBuff(p.ownHero, 1, 0);
                p.ownHero.armor += 1;
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 1, 0);
                p.enemyHero.armor += 1;
            }
        }

	}
}