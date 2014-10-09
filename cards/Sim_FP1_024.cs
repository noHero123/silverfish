// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_024.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_024.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_024.
    /// </summary>
    internal class Sim_FP1_024 : SimTemplate
    {
        // unstableghoul

        // spott/. todesröcheln:/ fügt allen dienern 1 schaden zu.
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
            p.allMinionsGetDamage(1);
        }

        #endregion
    }
}