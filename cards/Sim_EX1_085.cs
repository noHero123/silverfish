// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_085.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_085.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_085.
    /// </summary>
    class Sim_EX1_085 : SimTemplate
    {
        // mindcontroltech
        // todo list

        // kampfschrei:/ falls euer gegner mind. 4 diener hat, übernehmt zufällig die kontrolle über einen davon.
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
            if (own.own)
            {
                if (p.enemyMinions.Count >= 4)
                {
                    List<Minion> temp = new List<Minion>(p.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr)); // we take the weekest
                    Minion targett;
                    targett = temp[0];
                    if (targett.taunt && temp.Count >= 2 && !temp[1].taunt)
                    {
                        targett = temp[1];
                    }

                    p.minionGetControlled(targett, true, false);
                }
            }
            else
            {
                if (p.ownMinions.Count >= 4)
                {
                    List<Minion> temp = new List<Minion>(p.ownMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr)); // we take the weekest
                    Minion targett;
                    targett = temp[0];
                    if (targett.taunt && temp.Count >= 2 && !temp[1].taunt)
                    {
                        targett = temp[1];
                    }

                    p.minionGetControlled(targett, false, false);
                }
            }
        }
    }
}