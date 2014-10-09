// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_573.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_573.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_573.
    /// </summary>
    internal class Sim_EX1_573 : SimTemplate
    {
        // cenarius
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573t); // special treant

        #endregion

        // wählt aus:/ verleiht euren anderen dienern +2/+2; oder ruft zwei treants (2/2) mit spott/ herbei.
        #region Public Methods and Operators

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
            if (choice == 1)
            {
                List<Minion> temp = own.own ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    p.minionGetBuffed(m, 2, 2);
                }
            }

            if (choice == 2)
            {
                int pos = own.own ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kid, pos, own.own, true);
                p.callKid(this.kid, pos, own.own, true);
            }
        }

        #endregion
    }
}