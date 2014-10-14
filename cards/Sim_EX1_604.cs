// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_604.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_604.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_604.
    /// </summary>
    internal class Sim_EX1_604 : SimTemplate
    {
        // frothingberserker

        // erhält jedes mal +1 angriff, wenn ein diener schaden erleidet.
        #region Public Methods and Operators

        /// <summary>
        /// The on minion got dmg trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="ownDmgdmin">
        /// The own dmgdmin.
        /// </param>
        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdmin)
        {
            p.minionGetBuffed(triggerEffectMinion, 1, 0);
        }

        #endregion
    }
}