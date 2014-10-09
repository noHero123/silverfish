// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_274.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_274.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_274.
    /// </summary>
    internal class Sim_EX1_274 : SimTemplate
    {
        // etherealarcanist

        // erhält +2/+2, wenn ihr am ende eures zuges über ein aktives geheimnis/ verfügt.
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
                int b = turnEndOfOwner ? p.ownSecretsIDList.Count : p.enemySecretCount;
                if (b >= 1)
                {
                    p.minionGetBuffed(triggerEffectMinion, 2, 2);
                }
            }
        }

        #endregion
    }
}