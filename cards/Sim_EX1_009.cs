// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_009.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_009.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_009.
    /// </summary>
    class Sim_EX1_009 : SimTemplate
	{
	    // angrychicken

// wutanfall:/ +5 angriff.
        /// <summary>
        /// The on enrage start.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onEnrageStart(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, 5, 0);
        }

        /// <summary>
        /// The on enrage stop.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void  onEnrageStop(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, -5, 0);
        }

	}
}