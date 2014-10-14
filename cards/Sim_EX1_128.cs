// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_128.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_128.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_128.
    /// </summary>
    internal class Sim_EX1_128 : SimTemplate
    {
        // conceal

        // verleiht euren dienern bis zu eurem nächsten zug verstohlenheit/.
        #region Public Methods and Operators

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
            if (ownplay)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.concedal = true;
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.concedal = true;
                    }
                }
            }
        }

        #endregion
    }
}