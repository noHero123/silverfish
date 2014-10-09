// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_029.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_029.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_029.
    /// </summary>
    internal class Sim_NEW1_029 : SimTemplate
    {
        // millhousemanastorm

        // kampfschrei:/ im nächsten zug kosten zauber für euren gegner (0) mana.
        // todo implement the nomanacosts for the enemyturn
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
            if (own.own)
            {
                p.weHavePlayedMillhouseManastorm = true;
            }
        }

        #endregion
    }
}