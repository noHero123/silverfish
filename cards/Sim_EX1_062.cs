// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_062.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_062.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_062.
    /// </summary>
    internal class Sim_EX1_062 : SimTemplate
    {
        // oldmurkeye

        // ansturm/. hat +1 angriff für jeden anderen murloc auf dem schlachtfeld.
        #region Public Methods and Operators

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                if (m.handcard.card.race == 14)
                {
                    p.minionGetBuffed(own, 1, 0);
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                if (m.handcard.card.race == 14)
                {
                    p.minionGetBuffed(own, 1, 0);
                }
            }
        }

        /// <summary>
        /// The on minion died trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="diedMinion">
        /// The died minion.
        /// </param>
        public override void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            if (diedMinion.handcard.card.race == 14)
            {
                p.minionGetBuffed(triggerEffectMinion, -1, 0);
            }
        }

        /// <summary>
        /// The on minion is summoned.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="summonedMinion">
        /// The summoned minion.
        /// </param>
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (summonedMinion.handcard.card.race == 14)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }

        #endregion
    }
}