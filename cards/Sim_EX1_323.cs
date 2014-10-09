// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_323.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_323.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_323.
    /// </summary>
    internal class Sim_EX1_323 : SimTemplate
    {
        // lordjaraxxus
        #region Fields

        /// <summary>
        ///     The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk33);

        /// <summary>
        ///     The weapon.
        /// </summary>
        private CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_323w);

        #endregion

        // kampfschrei:/ vernichtet euren helden und ersetzt ihn durch lord jaraxxus.
        #region Public Methods and Operators

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
                p.ownHeroAblility.card = this.card;
                p.ownHeroName = HeroEnum.lordjaraxxus;
                p.ownHero.Hp = own.Hp;
                p.ownHero.maxHp = own.maxHp;

                p.equipWeapon(this.weapon, own.own);
            }
            else
            {
                p.enemyHeroAblility.card = this.card;
                p.enemyHeroName = HeroEnum.lordjaraxxus;
                p.enemyHero.Hp = own.Hp;
                p.enemyHero.maxHp = own.maxHp;

                p.equipWeapon(this.weapon, own.own);
            }
        }

        #endregion
    }
}