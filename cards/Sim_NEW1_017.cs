// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_017.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_017.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_017.
    /// </summary>
    class Sim_NEW1_017 : SimTemplate
    {
        // Hungry Crab
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
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, 2, 2);
            }
        } 
    }
}
