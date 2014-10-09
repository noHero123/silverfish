// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_151.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_151.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_151.
    /// </summary>
    class Sim_CS2_151 : SimTemplate
    {
        // silverhandknight
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_152); // squire

        // kampfschrei:/ ruft einen knappen (2/2) herbei.
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
            p.callKid(this.kid, own.zonepos, own.own, true);
        }
    }
}