// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_594.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_594.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_594.
    /// </summary>
    internal class Sim_EX1_594 : SimTemplate
    {
        // vaporize
        // todo secret

        // geheimnis:/ wenn ein diener euren helden angreift, wird er vernichtet.
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
            p.minionGetDestroyed(target);
        }

        #endregion
    }
}