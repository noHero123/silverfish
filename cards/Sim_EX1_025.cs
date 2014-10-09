// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_025.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_025.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_025.
    /// </summary>
    class Sim_EX1_025 : SimTemplate
    {
        // dragonling mechanic
        /// <summary>
        /// The kid.
        /// </summary>
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_025t);// mechanicaldragonling

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
