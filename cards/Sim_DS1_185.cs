// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DS1_185.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ d s 1_185.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ d s 1_185.
    /// </summary>
    class Sim_DS1_185 : SimTemplate
	{
	    // arcaneshot

// verursacht $2 schaden.
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
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}