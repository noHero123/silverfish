// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_057.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_057.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_057.
    /// </summary>
    internal class Sim_EX1_057 : SimTemplate
    {
        // ancientbrewmaster

        // kampfschrei:/ lasst einen befreundeten diener vom schlachtfeld auf eure hand zurückkehren.
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
                p.minionReturnToHand(target, target.own, 0);
            }
        }

        #endregion
    }
}