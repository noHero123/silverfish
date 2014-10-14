// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_226.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_226.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_226.
    /// </summary>
    internal class Sim_CS2_226 : SimTemplate
    {
        // frostwolfwarlord

        // kampfschrei:/ erhält +1/+1 für jeden anderen befreundeten diener auf dem schlachtfeld.
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
            int buff = own.own ? p.ownMinions.Count : p.enemyMinions.Count;
            p.minionGetBuffed(own, buff, buff);
        }

        #endregion
    }
}