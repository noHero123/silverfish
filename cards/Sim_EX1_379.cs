// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_379.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_379.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_379.
    /// </summary>
    class Sim_EX1_379 : SimTemplate
    {
        // repentance

        // geheimnis:/ wenn euer gegner einen diener ausspielt, wird dessen leben auf 1 verringert.

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
            target.Hp = 1;
            target.maxHp = 1;
            target.wounded = false;
        }
    }
}