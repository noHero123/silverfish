// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_009.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_009.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_009.
    /// </summary>
    class Sim_FP1_009 : SimTemplate
    {
        // deathlord
        /// <summary>
        /// The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_017); // nerubian

        // spott. todesröcheln:/ euer gegner legt einen diener aus seinem deck auf das schlachtfeld.
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
            int place = m.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.c, place, !m.own);
        }
    }
}