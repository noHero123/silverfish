// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_053.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_053.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_053.
    /// </summary>
    class Sim_CS2_053 : SimTemplate
    {
        // far sight

        // todo: bonus for it?
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
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

    }
}
