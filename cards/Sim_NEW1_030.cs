// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_030.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_030.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_030.
    /// </summary>
    internal class Sim_NEW1_030 : SimTemplate
    {
        // deathwing

        // kampfschrei:/ vernichtet alle anderen diener und werft eure hand ab.
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
            p.allMinionsGetDestroyed();
            if (own.own)
            {
                p.owncards.Clear();
            }
            else
            {
                p.enemycarddraw = 0;
                p.enemyAnzCards = 0;
            }
        }

        #endregion
    }
}