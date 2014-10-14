// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_155.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_155.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_155.
    /// </summary>
    internal class Sim_EX1_155 : SimTemplate
    {
        // markofnature

        // wählt aus:/ verleiht einem diener +4 angriff; oder +4 leben und spott/.
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
            if (choice == 1)
            {
                p.minionGetBuffed(target, 4, 0);
            }

            if (choice == 2)
            {
                p.minionGetBuffed(target, 0, 4);
                target.taunt = true;
            }
        }

        #endregion
    }
}