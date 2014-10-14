// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_005.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_005.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_005.
    /// </summary>
    internal class Sim_CS2_005 : SimTemplate
    {
        // claw

        // verleiht eurem helden +2 angriff in diesem zug und 2 rüstung.
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
                p.ownHero.armor += 2;
                p.minionGetTempBuff(p.ownHero, 2, 0);
            }
            else
            {
                p.enemyHero.armor += 2;
                p.minionGetTempBuff(p.enemyHero, 2, 0);
            }
        }

        #endregion
    }
}