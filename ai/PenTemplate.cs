using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class PenTemplate
    {
        int enemyMinionBaseValue = 10;
        int enemyMinionAttackFactor = 2;
        int enemyMinionHPFactor = 2;

        public virtual int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }

        public virtual int getAttackPenalty(Playfield p, Minion target, bool isLethal)
        {
            return 0;
        }

        public int getValueOfMinion(int Angr, int HP, bool isTaunt = false)
        {
            return this.enemyMinionBaseValue + this.enemyMinionAttackFactor * Angr + this.enemyMinionHPFactor * HP;
        }
    }
}
