// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_289.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_289.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_289.
    /// </summary>
    class Sim_EX1_289 : SimTemplate
    {
        // icebarrier

        // todo secret

        // geheimnis:/ wenn euer held angegriffen wird, erhält er 8 rüstung.
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
            target.armor += 8;
        }
    }
}