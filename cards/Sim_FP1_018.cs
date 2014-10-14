// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_018.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_018.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_018.
    /// </summary>
    internal class Sim_FP1_018 : SimTemplate
    {
        // duplicate
        // todo secret

        // geheimnis:/ wenn ein befreundeter diener stirbt, erhaltet ihr 2 kopien dieses dieners auf eure hand.
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
        /// <param name="number">
        /// The number.
        /// </param>
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            if (ownplay)
            {
                p.drawACard(p.revivingOwnMinion, ownplay, true);
                p.drawACard(p.revivingOwnMinion, ownplay, true);
            }
            else
            {
                p.drawACard(p.revivingEnemyMinion, ownplay, true);
                p.drawACard(p.revivingEnemyMinion, ownplay, true);
            }
        }

        #endregion
    }
}