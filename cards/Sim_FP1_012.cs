// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_012.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_012.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_012.
    /// </summary>
    class Sim_FP1_012 : SimTemplate
    {
        // sludgebelcher
        /// <summary>
        /// The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_012t);

        // spott.\ntodesröcheln:/ ruft einen schleim (1/2) mit spott/ herbei.
        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.c, m.zonepos - 1, m.own);
        }
    }
}