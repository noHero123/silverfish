// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DS1_188.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ d s 1_188.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ d s 1_188.
    /// </summary>
    class Sim_DS1_188 : SimTemplate
    {
        // gladiatorslongbow
        /// <summary>
        /// The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DS1_188);

        // euer held ist immun/, während er angreift.
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
            p.equipWeapon(this.c, ownplay);
        }
    }
}