// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_295.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_295.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_295.
    /// </summary>
    internal class Sim_EX1_295 : SimTemplate
    {
        // iceblock
        // todo secret

        // geheimnis:/ wenn euer held tödlichen schaden erleidet, wird dieser verhindert und der held wird immun/ in diesem zug.
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
            target.Hp += number;
            target.immune = true;
        }

        #endregion
    }
}