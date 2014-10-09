// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_316.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_316.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_316.
    /// </summary>
    internal class Sim_EX1_316 : SimTemplate
    {
        // poweroverwhelming

        // verleiht einem befreundeten diener bis zum ende des zuges +4/+4. dann stirbt er. auf schreckliche art und weise.
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
                target.destroyOnOwnTurnEnd = true;
            }
            else
            {
                target.destroyOnEnemyTurnEnd = true;
            }
        }

        #endregion
    }
}