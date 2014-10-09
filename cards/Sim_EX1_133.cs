// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_133.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_133.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_133.
    /// </summary>
    class Sim_EX1_133 : SimTemplate
    {
        // pertitions blade
        /// <summary>
        /// The w.
        /// </summary>
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_133);

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
            int dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (p.cardsPlayedThisTurn >= 1) dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            p.equipWeapon(this.w, ownplay);
        }

    }

    
}
