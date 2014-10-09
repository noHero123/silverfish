// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_031.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_031.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_031.
    /// </summary>
    class Sim_CS2_031 : SimTemplate
	{
	    // icelance

// friert/ einen charakter ein. wenn er bereits eingefroren/ ist, werden ihm stattdessen $4 schaden zugefügt.
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
            int dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            
            if (target.frozen)
            {
                p.minionGetDamageOrHeal(target, dmg);
            }
            else
            {
                target.frozen = true;
            }

            
		}

	}
}