// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_030.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_030.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_030.
    /// </summary>
    internal class Sim_FP1_030 : SimTemplate
    {
        // loatheb

        // kampfschrei:/ im nächsten zug kosten zauber für euren gegner (5) mehr.
        #region Public Methods and Operators

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
            p.loatheb = true;
        }

        #endregion
    }
}