// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_366.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_366.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_366.
    /// </summary>
    class Sim_EX1_366 : SimTemplate
    {
        // swordofjustice
        /// <summary>
        /// The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_366);

        // jedes mal, wenn ihr einen diener herbeiruft, erhält dieser +1/+1 und diese waffe verliert 1 haltbarkeit.

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
            p.equipWeapon(this.card, ownplay);
        }

        /// <summary>
        /// The on minion is summoned.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="summonedMinion">
        /// The summoned minion.
        /// </param>
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own)
            {
                p.minionGetBuffed(summonedMinion, 1, 1);
                p.lowerWeaponDurability(1, triggerEffectMinion.own);
            }
        }
    }
}