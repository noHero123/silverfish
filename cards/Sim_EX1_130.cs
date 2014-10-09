// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_130.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_130.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_130.
    /// </summary>
    internal class Sim_EX1_130 : SimTemplate
    {
        // noblesacrifice
        // todo secret
        // geheimnis:/ wenn ein feind angreift, ruft ihr einen verteidiger (2/1) als neues ziel herbei.
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_130a);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The on secret play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="attacker">
        /// The attacker.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public override void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
            if (ownplay)
            {
                int posi = p.ownMinions.Count;
                p.callKid(this.kid, posi, true);
                if (p.ownMinions.Count >= 1)
                {
                    if (p.ownMinions[p.ownMinions.Count - 1].name == CardDB.cardName.defender)
                    {
                        number = p.ownMinions[p.ownMinions.Count - 1].entitiyID;
                    }
                }
            }
            else
            {
                int posi = p.enemyMinions.Count;
                p.callKid(this.kid, posi, false);

                if (p.enemyMinions.Count >= 1)
                {
                    if (p.enemyMinions[p.enemyMinions.Count - 1].name == CardDB.cardName.defender)
                    {
                        number = p.enemyMinions[p.enemyMinions.Count - 1].entitiyID;
                    }
                }
            }
        }

        #endregion
    }
}