// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_104.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_104.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_104.
    /// </summary>
    internal class Sim_CS2_104 : SimTemplate
    {
        // rampage

        // verleiht einem verletzten diener +3/+3.
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
            p.minionGetBuffed(target, 3, 3);
        }

        #endregion
    }
}