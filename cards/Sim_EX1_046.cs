// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_046.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_046.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_046.
    /// </summary>
    class Sim_EX1_046 : SimTemplate
    {
        // Dark Iron Dwarf
        // +2 tempattack
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
            if (target != null) p.minionGetTempBuff(target, 2, 0);
        }
    }
}
