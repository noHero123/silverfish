// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_283.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_283.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_283.
    /// </summary>
    class Sim_EX1_283 : SimTemplate
	{
	    // frostelemental

// kampfschrei:/ friert/ einen charakter ein.
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
            target.frozen = true;
		}


	}
}