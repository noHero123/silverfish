// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_173.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_173.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_173.
    /// </summary>
    class Sim_EX1_173 : SimTemplate
	{
	    // starfire

// verursacht $5 schaden. zieht eine karte.

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
            int dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);

            // this.owncarddraw++;
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }
	}
}