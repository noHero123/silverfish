// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_371.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_371.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_371.
    /// </summary>
    class Sim_EX1_371 : SimTemplate
	{
	    // handofprotection

// verleiht einem diener gottesschild/.

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
            target.divineshild = true;
		}

	}
}