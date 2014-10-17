namespace HREngine.Bots
{

    public abstract class Behavior
    {
        public virtual float getPlayfieldValue(Playfield p)
        {
            return 0;
        }

        public virtual int getEnemyMinionValue(Minion m, Playfield p)
        {
            return 0;
        }

    }

}