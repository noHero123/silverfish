// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_221.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_221.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_221.
    /// </summary>
    class Sim_CS2_221 : SimTemplate
	{
	    // spitefulsmith

// wutanfall:/ eure waffe hat +2 angriff.
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
            if (m.own)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.minionGetBuffed(p.ownHero, 2, 0);
                    p.ownWeaponAttack += 2;
                }
            }
            else 
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponAttack += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                }
            }
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
        public override void onEnrageStop(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.minionGetBuffed(p.ownHero, -2, 0);
                    p.ownWeaponAttack -= 2;
                }
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponAttack -= 2;
                    p.minionGetBuffed(p.enemyHero, -2, 0);
                }
            }
        }

	}

}