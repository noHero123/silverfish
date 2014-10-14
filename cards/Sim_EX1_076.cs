// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_076.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_076.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_076.
    /// </summary>
    internal class Sim_EX1_076 : SimTemplate
    {
        // pintsizedsummoner

        // todo enemy stuff

        // der erste diener, den ihr in einem zug ausspielt, kostet (1) weniger.
        #region Public Methods and Operators

        /// <summary>
        /// The on aura ends.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.winzigebeschwoererin--;
            }
        }

        /// <summary>
        /// The on aura starts.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.winzigebeschwoererin++;
            }
        }

        #endregion
    }
}