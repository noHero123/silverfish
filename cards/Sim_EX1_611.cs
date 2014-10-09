// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_611.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_611.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_611.
    /// </summary>
    internal class Sim_EX1_611 : SimTemplate
    {
        // freezingtrap
        // todo secret

        // geheimnis:/ wenn ein feindlicher diener angreift, lasst ihn auf die hand seines besitzers zurückkehren. zusätzlich kostet er (2) mehr.
        #region Public Methods and Operators

        /// <summary>
        /// The on secret play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            p.minionReturnToHand(target, !ownplay, 2);

            target.Hp = -100;
        }

        #endregion
    }
}