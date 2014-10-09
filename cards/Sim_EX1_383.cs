// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_383.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_383.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_383.
    /// </summary>
    class Sim_EX1_383 : SimTemplate
    {
        // tirionfordring
        /// <summary>
        /// The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_383t);

        // gottesschild/. spott/. todesröcheln:/ legt einen aschenbringer (5/3) an.

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
            p.equipWeapon(this.card, m.own);
        }
    }
}