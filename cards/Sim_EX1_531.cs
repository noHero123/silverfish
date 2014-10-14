// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_531.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_531.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_531.
    /// </summary>
    internal class Sim_EX1_531 : SimTemplate
    {
        // scavenginghyena

        // erhält jedes mal +2/+1, wenn ein befreundetes wildtier stirbt.
        #region Public Methods and Operators

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
            if (triggerEffectMinion.own == diedMinion.own && (TAG_RACE)diedMinion.handcard.card.race == TAG_RACE.PET)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 1);
            }
        }

        #endregion
    }
}