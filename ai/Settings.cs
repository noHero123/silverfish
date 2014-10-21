namespace HREngine.Bots
{
    internal class Settings
    {
        public float firstweight = 0.5f;
        public float secondweight = 0.5f;

        public int numberOfThreads = 32;
        public bool useSecretsPlayArround = false;

        public bool simulatePlacement = true;

        public bool simulateEnemysTurn = true;
        public int enemyTurnMaxWide = 20;

        public int secondTurnAmount = 256;
        public bool simEnemySecondTurn = true;
        public int enemySecondTurnMaxWide = 20;

        public int nextTurnDeep = 6;
        public int nextTurnMaxWide = 20;
        public int nextTurnTotalBoards = 50;

        public bool playarround = false;
        public int playaroundprob = 50;
        public int playaroundprob2 = 80;

        public string path = "";
        public string logpath = "";
        public string logfile = "Logg.txt";
        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                return instance ?? (instance = new Settings());
            }
        }


        private Settings()
        {
        }

        public void setWeights(int a)
        {
            float alpha = ((float)a) / 100f;
            this.firstweight = 1f - alpha;
            this.secondweight = alpha;
            Helpfunctions.Instance.ErrorLog("current alpha is " + this.secondweight);
        }

        public void setFilePath(string path)
        {
            this.path = path;
        }
        public void setLoggPath(string path)
        {
            this.logpath = path;
        }

        public void setLoggFile(string path)
        {
            this.logfile = path;
        }
    }

}