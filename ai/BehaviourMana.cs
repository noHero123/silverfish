namespace HREngine.Bots
{
    using System;

    public class BehaviorMana : Behavior
    {
        PenalityManager penman = PenalityManager.Instance;

        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000) return p.value;
            int retval = 0;

            retval += p.ownHero.Hp + p.ownHero.armor;
            retval -= (p.enemyHero.Hp + p.enemyHero.armor);

            foreach (Minion m in p.ownMinions)
            {
                retval += this.getEnemyMinionValue(m, p);
            }

            foreach (Minion m in p.enemyMinions)
            {
                retval -= this.getEnemyMinionValue(m, p);
            }

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                int r = Math.Max(hc.getManaCost(p), 1);
                if (hc.card.name == CardDB.cardName.unknown) r = 4;
                retval += r;
            }

            retval -= p.enemySecretCount;
            retval -= p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;
            if (p.enemyHero.Hp <= 0) retval = 10000;
            if (p.enemyHero.Hp >= 1 && p.ownHero.Hp <= 0)
            {
                retval += p.owncarddraw * 500;
                retval -= 1000;
            }
            if (p.ownHero.Hp <= 0) retval = -10000;

            p.value = retval;
            return retval;
        }

        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            int retval = 0;
            retval += m.handcard.card.cost;
            if (m.handcard.card.name == CardDB.cardName.unknown) retval = 4;
            return retval;
        }


    }

}