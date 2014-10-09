// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_Mekka4.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ mekka 4.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ mekka 4.
    /// </summary>
    internal class Sim_Mekka4 : SimTemplate
    {
        // poultryizer
        #region Fields

        /// <summary>
        ///     The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka4t);

        #endregion

        // verwandelt zu beginn eures zuges einen zufälligen diener in ein huhn (1/1).
        #region Public Methods and Operators

        /// <summary>
        /// The on turn start trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnStartOfOwner">
        /// The turn start of owner.
        /// </param>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                Minion tm = null;
                int ges = 1000;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }

                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }

                if (ges <= 999)
                {
                    p.minionTransform(tm, this.c);
                }
            }
        }

        #endregion
    }
}