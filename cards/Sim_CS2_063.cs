// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_063.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_063.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_063.
    /// </summary>
    class Sim_CS2_063 : SimTemplate
	{
	    // corruption

// wählt einen feindlichen diener aus. vernichtet ihn zu beginn eures zuges.

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
            // if ownplay == true -> destroyOnOwnturnstart =true   else  destroyonenemyturnstart
            target.destroyOnOwnTurnStart = target.destroyOnOwnTurnStart || ownplay;
            target.destroyOnEnemyTurnStart = target.destroyOnEnemyTurnStart || !ownplay;
            
		}

	}
}