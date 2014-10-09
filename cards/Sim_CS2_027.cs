// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_027.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_027.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_027.
    /// </summary>
    class Sim_CS2_027 : SimTemplate
    {
        // mirrorimage
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_mirror);

        // ruft zwei diener (0/2) mit spott/ herbei.
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
            p.callKid(this.kid, posi, ownplay);
        }
    }
}