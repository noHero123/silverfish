// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_038.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_038.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_038.
    /// </summary>
    class Sim_CS2_038 : SimTemplate
	{
	    // ancestralspirit

// verleiht einem diener „todesröcheln:/ ruft diesen diener erneut herbei.“
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
            target.ancestralspirit++;
		}

	}
}