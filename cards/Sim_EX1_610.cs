// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_610.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_610.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_610.
    /// </summary>
    class Sim_EX1_610 : SimTemplate
    {
        // explosivetrap
        // todo secret

        // geheimnis:/ wenn euer held angegriffen wird, erleiden alle feinde $2 schaden.
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
            int dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }
    }
}