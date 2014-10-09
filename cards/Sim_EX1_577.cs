// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_577.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_577.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_577.
    /// </summary>
    class Sim_EX1_577 : SimTemplate
	{
	    // thebeast

// todesröcheln:/ ruft finkle einhorn (3/3) für euren gegner herbei.
        /// <summary>
        /// The c.
        /// </summary>
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_finkle);// finkleeinhorn

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

            int place = m.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.c, place, !m.own);
        }

	}
}