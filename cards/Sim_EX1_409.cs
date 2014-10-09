// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_409.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_409.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_409.
    /// </summary>
    class Sim_EX1_409 : SimTemplate
    {
        // upgrade
        /// <summary>
        /// The wcard.
        /// </summary>
        private CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_409t); // heavyaxe

        // wenn ihr eine waffe habt, erhält sie +1/+1. legt anderenfalls eine waffe (1/3) an.
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
            if (ownplay)
            {
                if (p.ownWeaponName != CardDB.cardName.unknown)
                {
                    p.ownWeaponAttack++;
                    p.ownWeaponDurability++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
                else
                {
                    p.equipWeapon(this.wcard, true);
                }
            }
            else
            {
                if (p.enemyWeaponName != CardDB.cardName.unknown)
                {
                    p.enemyWeaponAttack++;
                    p.enemyWeaponDurability++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
                else
                {
                    p.equipWeapon(this.wcard, false);
                }
            }
        }
    }
}