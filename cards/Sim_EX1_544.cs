// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_544.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_544.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_544.
    /// </summary>
    class Sim_EX1_544 : SimTemplate
    {
        // flare

        // alle diener verlieren verstohlenheit/. zerstört alle feindlichen geheimnisse/. zieht eine karte.

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
            foreach (Minion m in p.ownMinions)
            {
                m.stealth = false;
            }

            foreach (Minion m in p.enemyMinions)
            {
                m.stealth = false;
            }

            if (ownplay)
            {
                p.enemySecretCount = 0;
                p.enemySecretList.Clear();
            }
            else
            {
                p.ownSecretsIDList.Clear();
            }

            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

    }

}