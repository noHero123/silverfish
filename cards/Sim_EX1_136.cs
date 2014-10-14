// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_136.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_136.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_136.
    /// </summary>
    internal class Sim_EX1_136 : SimTemplate
    {
        // redemption
        // todo secret
        // geheimnis:/ wenn einer eurer diener stirbt, wird er mit 1 leben wiederbelebt.
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
        /// <param name="number">
        /// The number.
        /// </param>
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            CardDB.Card kid = CardDB.Instance.getCardDataFromID(ownplay ? p.revivingOwnMinion : p.revivingEnemyMinion);

            p.callKid(kid, posi, ownplay);
            if (ownplay)
            {
                if (p.ownMinions.Count >= 1)
                {
                    if (p.ownMinions[p.ownMinions.Count - 1].handcard.card.cardIDenum == kid.cardIDenum)
                    {
                        p.ownMinions[p.ownMinions.Count - 1].Hp = 1;
                        p.ownMinions[p.ownMinions.Count - 1].wounded = false;
                        if (p.ownMinions[p.ownMinions.Count - 1].Hp < p.ownMinions[p.ownMinions.Count - 1].maxHp)
                        {
                            p.ownMinions[p.ownMinions.Count - 1].wounded = true;
                        }
                    }
                }
            }
            else
            {
                if (p.enemyMinions.Count >= 1)
                {
                    if (p.enemyMinions[p.enemyMinions.Count - 1].handcard.card.cardIDenum == kid.cardIDenum)
                    {
                        p.enemyMinions[p.enemyMinions.Count - 1].Hp = 1;
                        p.enemyMinions[p.enemyMinions.Count - 1].wounded = false;
                        if (p.enemyMinions[p.enemyMinions.Count - 1].Hp < p.enemyMinions[p.enemyMinions.Count - 1].maxHp)
                        {
                            p.enemyMinions[p.enemyMinions.Count - 1].wounded = true;
                        }
                    }
                }
            }
        }

        #endregion
    }
}