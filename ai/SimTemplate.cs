namespace HREngine.Bots
{

    public class SimTemplate
    {

        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            return;
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            return;
        }



        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            return;
        }

        public virtual void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            return;
        }

        public virtual void onAuraStarts(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onAuraEnds(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onInspire(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onEnrageStart(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onEnrageStop(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfMinionGotHealed)
        {
            return;
        }

        public virtual void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            return;
        }


        public virtual void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            return;
        }

        public virtual void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            return;
        }

        public virtual void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdMinion)
        {
            return;
        }

        public virtual void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            return;
        }

        public virtual void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onDeathrattle(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            return;
        }

        public virtual void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }


        public virtual void onCardWasDiscarded(Playfield p, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        public virtual void onCardIsDiscarded(Playfield p, CardDB.Card card, bool own)
        {
            return;
        }




    }

}