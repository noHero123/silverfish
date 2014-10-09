// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_258.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_258.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_258.
    /// </summary>
    class Sim_EX1_258 : SimTemplate
    {
        // Unbound Elemental
        // <deDE>ErhÃ¤lt jedes Mal +1/+1, wenn Ihr eine Karte mit &lt;b&gt;Ãœberladung&lt;/b&gt; ausspielt.</deDE>
        /// <summary>
        /// The on card is going to be played.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="wasOwnCard">
        /// The was own card.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && c.Recall)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }

    }
}
