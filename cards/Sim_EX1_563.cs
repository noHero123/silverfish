// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_563.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_563.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_563.
    /// </summary>
    internal class Sim_EX1_563 : SimTemplate
    {
        // malygos

        // zauberschaden +5/
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
                p.spellpower -= 5;
            }
            else
            {
                p.enemyspellpower -= 5;
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
                p.spellpower += 5;
            }
            else
            {
                p.enemyspellpower += 5;
            }
        }

        #endregion
    }
}