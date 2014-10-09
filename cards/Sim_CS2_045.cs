// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_045.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_045.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_045.
    /// </summary>
    class Sim_CS2_045 : SimTemplate
	{
	    // rockbiterweapon

// verleiht einem befreundeten charakter +3 angriff in diesem zug.

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
            p.minionGetTempBuff(target, 3, 0);
		}

	}
}