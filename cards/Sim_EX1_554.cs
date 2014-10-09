// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_554.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_554.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_554.
    /// </summary>
    class Sim_EX1_554 : SimTemplate
    {
        // snaketrap
        // todo secret

        // geheimnis:/ wenn einer eurer diener angegriffen wird, ruft ihr drei schlangen (1/1) herbei.
        /// <summary>
        /// The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t); // snake

        /// <summary>
        /// The on secret play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            if (ownplay)
            {
                int posi = p.ownMinions.Count;
                p.callKid(this.kid, posi, true);
                p.callKid(this.kid, posi, true);
                p.callKid(this.kid, posi, true);
            }
            else
            {
                int posi = p.enemyMinions.Count;
                p.callKid(this.kid, posi, false);
                p.callKid(this.kid, posi, false);
                p.callKid(this.kid, posi, false);
            }
        }
    }
}