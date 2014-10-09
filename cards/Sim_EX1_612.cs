// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_612.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_612.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_612.
    /// </summary>
    class Sim_EX1_612 : SimTemplate
	{
	    // kirintormage

// kampfschrei:/ das nächste geheimnis/, das ihr in diesem zug ausspielt, kostet (0).

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.playedmagierinderkirintor = true;
		}


	}
}