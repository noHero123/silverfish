// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_024.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_024.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_024.
    /// </summary>
    class Sim_NEW1_024 : SimTemplate
    {
        // captaingreenskin

        // kampfschrei:/ verleiht eurer waffe +1/+1.
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
            if (own.own)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.ownWeaponDurability++;
                    p.ownWeaponAttack++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponDurability++;
                    p.enemyWeaponAttack++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
            }
        }
    }
}