// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_073.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_073.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_073.
    /// </summary>
    internal class Sim_CS2_073 : SimTemplate
    {
        // coldblood

        // verleiht einem diener +2 angriff. combo:/ stattdessen +4 angriff.
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
            int ag = (p.cardsPlayedThisTurn >= 1 || !ownplay) ? 4 : 2;
                
                // we suggest, whether enemy is playing this, it is combo
            p.minionGetBuffed(target, ag, 0);
        }

        #endregion
    }
}