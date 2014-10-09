// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_021.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_021.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_021.
    /// </summary>
    class Sim_FP1_021 : SimTemplate
    {
        // Death's Bite
        /// <summary>
        /// The w.
        /// </summary>
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_021);

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
            p.equipWeapon(this.w, ownplay);
        }

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
        }

    }
}
