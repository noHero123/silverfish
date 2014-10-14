// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_007.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_007.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_007.
    /// </summary>
    internal class Sim_EX1_007 : SimTemplate
    {
        // Acolyte of Pain
        // <deDE>Zieht jedes Mal eine Karte, wenn dieser Diener Schaden erleidet.</deDE>
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
        /// <param name="ownDmgdMinion">
        /// The own dmgd minion.
        /// </param>
        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdMinion)
        {
            if (triggerEffectMinion.anzGotDmg >= 1)
            {
                for (int i = 0; i < triggerEffectMinion.anzGotDmg; i++)
                {
                    p.drawACard(CardDB.cardName.unknown, triggerEffectMinion.own);
                }

                triggerEffectMinion.anzGotDmg = 0;
            }
        }

        #endregion
    }
}