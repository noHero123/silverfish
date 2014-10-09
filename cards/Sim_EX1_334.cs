// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_334.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_334.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_334.
    /// </summary>
    class Sim_EX1_334 : SimTemplate
	{
	    // shadowmadness

// übernehmt bis zum ende des zuges die kontrolle über einen feindlichen diener mit max. 3 angriff.
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
            target.shadowmadnessed = true;
            p.minionGetControlled(target, ownplay, true);
		}

	}
}