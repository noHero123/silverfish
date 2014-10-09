// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_074.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_074.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_074.
    /// </summary>
    internal class Sim_CS2_074 : SimTemplate
    {
        // deadlypoison

        // eure waffe erhält +2 angriff.
        #region Public Methods and Operators

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
            if (ownplay)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.ownWeaponAttack += 2;
                    p.ownHero.Angr += 2;
                }
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.enemyWeaponAttack += 2;
                    p.enemyHero.Angr += 2;
                }
            }
        }

        #endregion
    }
}