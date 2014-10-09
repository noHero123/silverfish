// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_178.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_178.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_178.
    /// </summary>
    class Sim_EX1_178 : SimTemplate
    {
        // ancientofwar

        // wählt aus:/ +5 angriff; oder +5 leben und spott/.
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
            if (choice == 2)
            {
                p.minionGetBuffed(own, 5, 0);
            }

            if (choice == 1)
            {
                p.minionGetBuffed(own, 0, 5);
                own.taunt = true;
            }
        }


    }

}