// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_294.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_294.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_294.
    /// </summary>
    internal class Sim_EX1_294 : SimTemplate
    {
        // mirrorentity
        // todo secret
        // geheimnis:/ wenn euer gegner einen diener ausspielt, beschwört ihr eine kopie desselben herbei.
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
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(target.handcard.card, posi, ownplay);
            if (ownplay)
            {
                if (p.ownMinions.Count >= 1 && p.ownMinions[p.ownMinions.Count - 1].name == target.handcard.card.name)
                {
                    int e = p.ownMinions[p.ownMinions.Count - 1].entitiyID;
                    p.ownMinions[p.ownMinions.Count - 1].setMinionTominion(target);
                    p.ownMinions[p.ownMinions.Count - 1].entitiyID = e;
                    p.ownMinions[p.ownMinions.Count - 1].own = true;
                }
            }
            else
            {
                if (p.enemyMinions.Count >= 1
                    && p.enemyMinions[p.enemyMinions.Count - 1].name == target.handcard.card.name)
                {
                    int e = p.enemyMinions[p.enemyMinions.Count - 1].entitiyID;
                    p.enemyMinions[p.enemyMinions.Count - 1].setMinionTominion(target);
                    p.enemyMinions[p.enemyMinions.Count - 1].entitiyID = e;
                    p.enemyMinions[p.enemyMinions.Count - 1].own = false;
                }
            }
        }

        #endregion
    }
}