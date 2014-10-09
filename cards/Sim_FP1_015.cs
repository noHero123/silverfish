// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_015.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_015.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_015.
    /// </summary>
    class Sim_FP1_015 : SimTemplate
    {
        // feugen

        // todesröcheln:/ ruft thaddius herbei, wenn stalagg in diesem duell bereits gestorben ist.
        /// <summary>
        /// The thaddius.
        /// </summary>
        private CardDB.Card thaddius = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_014t);

        // todesröcheln:/ ruft thaddius herbei, wenn feugen in diesem duell bereits gestorben ist.

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
            if (p.stalaggDead)
            {
                p.callKid(this.thaddius, m.zonepos - 1, m.own);
            }
        }
    }
}