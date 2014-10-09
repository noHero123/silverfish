// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_116.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_116.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_116.
    /// </summary>
    class Sim_EX1_116 : SimTemplate
    {
        // leeroyjenkins
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_116t); // whelp

        // ansturm/. kampfschrei:/ ruft zwei welplinge (1/1) für euren gegner herbei.
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
            int pos = own.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.kid, pos, !own.own);
            p.callKid(this.kid, pos, !own.own);
        }
    }
}