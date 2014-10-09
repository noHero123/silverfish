// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_597.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_597.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_597.
    /// </summary>
    internal class Sim_EX1_597 : SimTemplate
    {
        // impmaster

        // fügt am ende eures zuges diesem diener 1 schaden zu und beschwört einen wichtel (1/1).
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_598); // imp

        #endregion

        #region Public Methods and Operators

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
                if (triggerEffectMinion.Hp == 1)
                {
                    posi--;
                }

                p.minionGetDamageOrHeal(triggerEffectMinion, 1);
                p.callKid(this.kid, posi, triggerEffectMinion.own);
                triggerEffectMinion.stealth = false;
            }
        }

        #endregion
    }
}