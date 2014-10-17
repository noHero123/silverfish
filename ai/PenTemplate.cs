namespace HREngine.Bots
{
   
    internal class PenTemplate
    {

        private int enemyMinionAttackFactor = 2;

        private int enemyMinionBaseValue = 10;

        private int enemyMinionHPFactor = 2;



        public virtual int getAttackPenalty(Playfield p, Minion target, bool isLethal)
        {
            return 0;
        }

        public virtual int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }

        public int getValueOfMinion(int Angr, int HP, bool isTaunt = false)
        {
            return this.enemyMinionBaseValue + this.enemyMinionAttackFactor * Angr + this.enemyMinionHPFactor * HP;
        }


    }
}