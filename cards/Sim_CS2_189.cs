// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_189.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_189.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_189.
    /// </summary>
    internal class Sim_CS2_189 : SimTemplate
    {
        // elvenarcher

        // kampfschrei:/ verursacht 1 schaden.
        #region Public Methods and Operators

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int dmg = 1;
            p.minionGetDamageOrHeal(target, dmg);
        }

        #endregion
    }
}