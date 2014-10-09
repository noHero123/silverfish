// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_320.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_320.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_320.
    /// </summary>
    class Sim_EX1_320 : SimTemplate
	{
	    // baneofdoom

// fügt einem charakter $2 schaden zu. beschwört einen zufälligen dämon, wenn der schaden tödlich ist.
        /// <summary>
        /// The kid.
        /// </summary>
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_059);// bloodimp

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

            bool summondemon = false;

            if (!target.isHero && dmg >= target.Hp && !target.divineshild && !target.immune)
            {
                summondemon = true;
            }

            p.minionGetDamageOrHeal(target, dmg);

            if (summondemon)
            {
                int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                
                p.callKid(this.kid, posi, ownplay);
            }

		}

	}
}