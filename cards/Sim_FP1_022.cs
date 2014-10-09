// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_022.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_022.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_022.
    /// </summary>
    class Sim_FP1_022 : SimTemplate
    {
        // voidcaller
        /// <summary>
        /// The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_301); // felguard

        // todesröcheln:/ legt einen zufälligen dämon aus eurer hand auf das schlachtfeld.

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>();
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON)
                    {
                        temp.Add(hc);
                    }
                }

                temp.Sort((x, y) => x.card.Attack.CompareTo(y.card.Attack));

                foreach (Handmanager.Handcard mnn in temp)
                {
                    p.callKid(mnn.card, p.ownMinions.Count, true);
                    p.removeCard(mnn);
                    break;
                }
            }
            else
            {
                if (p.enemyAnzCards >= 1)
                {
                    p.callKid(this.c, p.enemyMinions.Count, false);
                }
            }
        }
    }
}