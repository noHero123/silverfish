// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PenTemplate.cs" company="">
//   
// </copyright>
// <summary>
//   The pen template.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The pen template.
    /// </summary>
    internal class PenTemplate
    {
        #region Fields

        /// <summary>
        ///     The enemy minion attack factor.
        /// </summary>
        private int enemyMinionAttackFactor = 2;

        /// <summary>
        ///     The enemy minion base value.
        /// </summary>
        private int enemyMinionBaseValue = 10;

        /// <summary>
        ///     The enemy minion hp factor.
        /// </summary>
        private int enemyMinionHPFactor = 2;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get attack penalty.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="isLethal">
        /// The is lethal.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public virtual int getAttackPenalty(Playfield p, Minion target, bool isLethal)
        {
            return 0;
        }

        /// <summary>
        /// The get play penalty.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        /// <param name="isLethal">
        /// The is lethal.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public virtual int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }

        /// <summary>
        /// The get value of minion.
        /// </summary>
        /// <param name="Angr">
        /// The angr.
        /// </param>
        /// <param name="HP">
        /// The hp.
        /// </param>
        /// <param name="isTaunt">
        /// The is taunt.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int getValueOfMinion(int Angr, int HP, bool isTaunt = false)
        {
            return this.enemyMinionBaseValue + this.enemyMinionAttackFactor * Angr + this.enemyMinionHPFactor * HP;
        }

        #endregion
    }
}