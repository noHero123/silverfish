// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_091.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_091.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_091.
    /// </summary>
    internal class Sim_EX1_091 : SimTemplate
    {
        // cabalshadowpriest

        // kampfschrei:/ übernehmt die kontrolle über einen feindlichen diener mit max. 2 angriff.
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
            if (target != null)
            {
                p.minionGetControlled(target, own.own, false);
            }
        }

        #endregion
    }
}