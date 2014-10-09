// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_Mekka3.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ mekka 3.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ mekka 3.
    /// </summary>
    class Sim_Mekka3 : SimTemplate
	{
	    // emboldener3000

// verleiht am ende eures zuges einem zufälligen diener +1/+1.

        /// <summary>
        /// The on turn ends trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnEndOfOwner">
        /// The turn end of owner.
        /// </param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                Minion tm = null;
                int ges = 1000;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }

                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }

                if (ges <= 999)
                {
                    p.minionGetBuffed(tm, 1, 1);
                }
            }
        }

	}
}