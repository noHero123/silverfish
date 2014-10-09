// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_181.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_181.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_181.
    /// </summary>
    class Sim_CS2_181 : SimTemplate
    {
        // Injured Blademaster

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

            p.minionGetDamageOrHeal(own, 4);
        }

    }
}
