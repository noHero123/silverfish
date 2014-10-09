// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_Mekka2.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ mekka 2.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ mekka 2.
    /// </summary>
    internal class Sim_Mekka2 : SimTemplate
    {
        // repairbot

        // stellt am ende eures zuges bei einem verletzten charakter 6 leben wieder her.
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
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                Minion tm = null;
                int hl = triggerEffectMinion.own ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);
                int heal = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.maxHp - m.Hp > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.Hp;
                    }
                }

                foreach (Minion m in p.enemyMinions)
                {
                    if (m.maxHp - m.Hp > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.Hp;
                    }
                }

                if (heal >= 1)
                {
                    p.minionGetDamageOrHeal(tm, -hl);
                }
                else
                {
                    if (p.ownHero.Hp < 30)
                    {
                        p.minionGetDamageOrHeal(p.ownHero, -hl);
                    }
                    else
                    {
                        p.minionGetDamageOrHeal(p.enemyHero, -hl);
                    }
                }
            }
        }

        #endregion
    }
}