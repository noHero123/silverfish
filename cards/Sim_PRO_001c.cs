// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_PRO_001c.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ pr o_001 c.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ pr o_001 c.
    /// </summary>
    class Sim_PRO_001c : SimTemplate
    {
        // powerofthehorde
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_390);

        // beschwört einen zufälligen krieger der horde.

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
    }
}