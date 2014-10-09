// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_355.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_355.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_355.
    /// </summary>
    internal class Sim_EX1_355 : SimTemplate
    {
        // blessedchampion

        // verdoppelt den angriff eines dieners.
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
            p.minionGetBuffed(target, target.Angr, 0);
        }

        #endregion
    }
}