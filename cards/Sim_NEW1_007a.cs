// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_007a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_007 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_007 a.
    /// </summary>
    class Sim_NEW1_007a : SimTemplate
    {
        // starfall choice left

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
            int dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }

    }
}