// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_549.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_549.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_549.
    /// </summary>
    class Sim_EX1_549 : SimTemplate
	{
	    // bestialwrath

// verleiht einem wildtier +2 angriff und immunität/ in diesem zug.
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
            p.minionGetTempBuff(target, 2, 0);
            target.immune = true;
		}

	}
}