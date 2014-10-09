// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_341.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_341.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_341.
    /// </summary>
    internal class Sim_EX1_341 : SimTemplate
    {
        // lightwell

        // <deDE>Stellt zu Beginn Eures Zuges bei einem verletzten befreundeten Charakter 3 Leben wieder her.</deDE>
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
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                int heal = turnStartOfOwner ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
                List<Minion> temp = turnStartOfOwner ? p.ownMinions : p.enemyMinions;
                if (temp.Count >= 1)
                {
                    bool healed = false;
                    foreach (Minion mins in temp)
                    {
                        if (mins.wounded)
                        {
                            p.minionGetDamageOrHeal(mins, -heal);
                            healed = true;
                            break;
                        }
                    }

                    if (!healed)
                    {
                        if (turnStartOfOwner)
                        {
                            p.minionGetDamageOrHeal(p.ownHero, -heal);
                        }
                        else
                        {
                            p.minionGetDamageOrHeal(p.enemyHero, -heal);
                        }
                    }
                }
                else
                {
                    if (turnStartOfOwner)
                    {
                        p.minionGetDamageOrHeal(p.ownHero, -heal);
                    }
                    else
                    {
                        p.minionGetDamageOrHeal(p.enemyHero, -heal);
                    }
                }
            }
        }

        #endregion
    }
}