// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_609.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_609.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_609.
    /// </summary>
    internal class Sim_EX1_609 : SimTemplate
    {
        // snipe
        // todo secret

        // geheimnis:/ wenn euer gegner einen diener ausspielt, werden diesem $4 schaden zugefügt.
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
            int dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            p.minionGetDamageOrHeal(target, dmg);
        }

        #endregion
    }
}