// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_024.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_024.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_024.
    /// </summary>
    class Sim_CS2_024 : SimTemplate
    {
        // Frostbolt

        /// <summary>
        /// The on card play.
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
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            target.frozen = true;
            p.minionGetDamageOrHeal(target, dmg);

        }

    }
}
