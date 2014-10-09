// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_037.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_037.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ ne w 1_037.
    /// </summary>
    internal class Sim_NEW1_037 : SimTemplate
    {
        // masterswordsmith

        // verleiht am ende eures zuges einem anderen zufälligen befreundeten diener +1 angriff.
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
                List<Minion> temp2 = new List<Minion>(p.ownMinions);
                temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr)); // buff the weakest
                foreach (Minion mins in temp2)
                {
                    if (triggerEffectMinion.zonepos == mins.zonepos)
                    {
                        continue;
                    }

                    p.minionGetBuffed(mins, 1, 0);
                    break;
                }
            }
        }

        #endregion
    }
}