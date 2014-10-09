// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_009.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_009.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_009.
    /// </summary>
    class Sim_CS2_009 : SimTemplate
    {
        // Mark of the Wild

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
            target.taunt = true;
            p.minionGetBuffed(target, 2, 2);
        }

    }
}
