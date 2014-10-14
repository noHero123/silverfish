// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DREAM_05.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ drea m_05.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ drea m_05.
    /// </summary>
    internal class Sim_DREAM_05 : SimTemplate
    {
        // Nightmare
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
            p.minionGetBuffed(target, 4, 4);
            if (ownplay)
            {
                target.destroyOnOwnTurnStart = true;
            }
            else
            {
                target.destroyOnEnemyTurnStart = true;
            }
        }

        #endregion
    }
}