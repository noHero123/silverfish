// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_087.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_087.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_087.
    /// </summary>
    class Sim_CS2_087 : SimTemplate
    {
        // Blessing of Might
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
            p.minionGetBuffed(target, 3, 0);
        }

    }
}
