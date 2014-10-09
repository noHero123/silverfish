// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_020.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_020.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_020.
    /// </summary>
    class Sim_NEW1_020 : SimTemplate
	{
	    // wildpyromancer

// fügt allen dienern 1 schaden zu, nachdem ihr einen zauber gewirkt habt.
        // we do this manually (because there are only 2 minions which have this trigger)
        /*public override void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                p.allMinionsGetDamage(1);
            }
        }
        */
	}
}