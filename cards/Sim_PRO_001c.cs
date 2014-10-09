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
    ///     The sim_ pr o_001 c.
    /// </summary>
    internal class Sim_PRO_001c : SimTemplate
    {
        // powerofthehorde
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_390);

        #endregion

        // beschwört einen zufälligen krieger der horde.
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