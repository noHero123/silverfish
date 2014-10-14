// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_049.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_049.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_049.
    /// </summary>
    internal class Sim_CS2_049 : SimTemplate
    {
        // totemiccall

        // heldenfähigkeit/\nbeschwört ein zufälliges totem.

        // heldenfähigkeit/\nruft einen rekruten der silbernen hand (1/1) herbei.
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
            int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, posi, ownplay);
        }

        #endregion
    }
}