// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DS1_070.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ d s 1_070.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ d s 1_070.
    /// </summary>
    class Sim_DS1_070 : SimTemplate
	{
	    // houndmaster

// kampfschrei:/ verleiht einem befreundeten wildtier +2/+2 und spott/.
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
            if (target != null)
            {
                p.minionGetBuffed(target, 2, 2);
                target.taunt = true;
            }
		}


	}
}