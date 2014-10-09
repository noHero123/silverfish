// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_238.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_238.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_238.
    /// </summary>
    class Sim_EX1_238 : SimTemplate
	{
	    // lightningbolt

// verursacht $3 schaden. überladung:/ (1)

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
            int dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay) p.ueberladung++;
		}

	}
}