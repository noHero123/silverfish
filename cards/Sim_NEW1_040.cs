// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_040.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_040.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_040.
    /// </summary>
    class Sim_NEW1_040 : SimTemplate
    {
        // hogger
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_040t); // gnoll

        // ruft am ende eures zuges einen gnoll (2/2) mit spott/ herbei.

        /// <summary>
        /// The on turn ends trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnEndOfOwner">
        /// The turn end of owner.
        /// </param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int posi = triggerEffectMinion.zonepos;

                p.callKid(this.kid, posi, triggerEffectMinion.own);
            }
        }
    }
}