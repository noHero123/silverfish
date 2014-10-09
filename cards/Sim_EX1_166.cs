// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_166.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_166.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_166.
    /// </summary>
    internal class Sim_EX1_166 : SimTemplate
    {
        // keeperofthegrove

        // wählt aus:/ verursacht 2 schaden; oder bringt einen diener zum schweigen/.
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
            if (choice == 1)
            {
                p.minionGetDamageOrHeal(target, 2);
            }

            if (choice == 2)
            {
                p.minionGetSilenced(target);
            }
        }

        #endregion
    }
}