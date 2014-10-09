// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_398.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_398.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_398.
    /// </summary>
    class Sim_EX1_398 : SimTemplate
    {
        // Arathi Weaponsmith
        /// <summary>
        /// The wcard.
        /// </summary>
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_398t);// battleaxe

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
            p.equipWeapon(this.wcard, own.own);

        }

    }
}
