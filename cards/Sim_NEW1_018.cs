// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_018.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_018.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_018.
    /// </summary>
    class Sim_NEW1_018 : SimTemplate
    {
        // bloodsail raider
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
             own.Angr += p.ownWeaponAttack;
        }

    }
}
