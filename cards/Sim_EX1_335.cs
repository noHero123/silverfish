// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_335.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_335.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_335.
    /// </summary>
    class Sim_EX1_335 : SimTemplate
	{
	    // lightspawn

// der angriff dieses dieners entspricht immer seinem leben.
        // todo dont buff this!
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
            own.Angr = own.Hp;
		}

	}
}