// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_412.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_412.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_412.
    /// </summary>
    internal class Sim_EX1_412 : SimTemplate
    {
        // ragingworgen

        // wutanfall:/ windzorn/ und +1 angriff
        #region Public Methods and Operators

        /// <summary>
        /// The on enrage start.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr++;
            p.minionGetWindfurry(m);
        }

        /// <summary>
        /// The on enrage stop.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr--;
            m.windfury = false;
            if (m.numAttacksThisTurn == 1)
            {
                m.Ready = false;
            }
        }

        #endregion
    }
}