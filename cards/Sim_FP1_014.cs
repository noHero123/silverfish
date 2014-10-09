// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_014.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_014.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_014.
    /// </summary>
    internal class Sim_FP1_014 : SimTemplate
    {
        // stalagg
        #region Fields

        /// <summary>
        ///     The thaddius.
        /// </summary>
        private CardDB.Card thaddius = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_014t);

        #endregion

        // todesröcheln:/ ruft thaddius herbei, wenn feugen in diesem duell bereits gestorben ist.
        #region Public Methods and Operators

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
            if (p.feugenDead)
            {
                p.callKid(this.thaddius, m.zonepos - 1, m.own);
            }
        }

        #endregion
    }
}