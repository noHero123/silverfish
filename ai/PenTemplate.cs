namespace HREngine.Bots
{
   
    public class PenTemplate
    {

        private int enemyMinionAttackFactor = 2;

        private int enemyMinionBaseValue = 10;

        private int enemyMinionHPFactor = 2;


        //penalty if attacker-minion is attacking the target-minion
        public virtual float getAttackPenalty(Playfield p, Minion attacker, Minion target, bool isLethal)
        {
            return 0;
        }

        //penalty if card is attacking the target-minion
        public virtual float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            return 0;
        }

        //could be used for Behaviour-class to get the value of the minion on your side
        public virtual float getValueOfOwnMinion(Minion m)
        {
            return this.enemyMinionBaseValue + 5 * m.Angr + 5 * m.Hp;
        }

        //could be used for Behaviour-class to get the value of the minion as opponent
        public virtual float getValueOfEnemyMinion(Minion m)
        {
            return this.enemyMinionBaseValue + this.enemyMinionAttackFactor * m.Angr + this.enemyMinionHPFactor * m.Hp;
        }

        //could be used for Behaviour-class to get the value of that card in your hand
        public virtual float getValueOfCardInHand(Handmanager.Handcard hc)
        {
            return 5;
        }


    }
}