// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_196.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_196.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_196.
    /// </summary>
    class Sim_CS2_196 : SimTemplate
    {
        // razorfenhunter
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_boar); // boar

        // kampfschrei:/ ruft einen eber (1/1) herbei.
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