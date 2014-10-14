// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_132.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_132.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_132.
    /// </summary>
    internal class Sim_EX1_132 : SimTemplate
    {
        // eyeforaneye
        // todo secret

        // geheimnis:/ wenn euer held schaden erleidet, wird dem feindlichen helden ebenso viel schaden zugefügt.
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
            int dmg = ownplay ? p.getSpellDamageDamage(number) : p.getEnemySpellDamageDamage(number);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
        }

        #endregion
    }
}