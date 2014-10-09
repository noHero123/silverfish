// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_160.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_160.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_160.
    /// </summary>
    class Sim_EX1_160 : SimTemplate
	{
	    // powerofthewild

// wählt aus:/ verleiht euren dienern +1/+1; oder ruft einen panther (3/2) herbei.
        /// <summary>
        /// The kid.
        /// </summary>
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160t);// panther

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1)
            {
                List<Minion> temp = ownplay ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    p.minionGetBuffed(m, 1, 1);
                }
            }

            if (choice == 2)
            {
                int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kid, posi, true);
                
            }
		}

	}
}