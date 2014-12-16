namespace HREngine.Bots
{
    internal class Settings
    {

        public void setSettings()
        {
            // play with these settings###################################
            this.enfacehp = 15;  // hp of enemy when your hero is allowed to attack the enemy face with his weapon
            this.maxwide = 3000;   // numer of boards which are taken to the next deep-lvl
            this.twotsamount = 0;          // number of boards where the next turn is simulated
            this.simEnemySecondTurn = true; // if he simulates the next players-turn, he also simulates the enemys respons

            this.playarround = false;  //play around some enemys aoe-spells?
            //these two probs are >= 0 and <= 100
            this.playaroundprob = 50;    //probability where the enemy plays the aoe-spell, but your minions will not die through it
            this.playaroundprob2 = 80;   // probability where the enemy plays the aoe-spell, and your minions can die!

            this.enemyTurnMaxWide = 40; // bords calculated in enemys-first-turn in first AI step (lower than enemySecondTurnMaxWide)
            this.enemyTurnMaxWideSecondTime = 200; // bords calculated in enemys-first-turn BUT in the second AI step (higher than enemyTurnMaxWide)
            this.enemySecondTurnMaxWide = 20; // number of enemy-board calculated in enemys second TURN

            this.nextTurnDeep = 6; //maximum combo-deep in your second turn (dont change this!)
            this.nextTurnMaxWide = 20; //maximum boards calculated in one second-turn-"combo-step"
            this.nextTurnTotalBoards = 200;//maximum boards calculated in second turn simulation

            this.useSecretsPlayArround = false; // playing arround enemys secrets

            this.alpha = 50; // weight of the second turn in calculation (0<= alpha <= 100)

            this.simulatePlacement = false;  // set this true, and ai will simulate all placements, whether you have a alpha/flametongue/argus
            //use this only with useExternalProcess = true !!!!

            this.useExternalProcess = false; // use silver.exe for calculations a lot faster than turning it off (true = recomended)
            this.passiveWaiting = false; // process will wait passive for silver.exe to finish

            //###########################################################

            this.setWeights(alpha);

            Mulligan.Instance.setAutoConcede(Settings.Instance.concede);
            Helpfunctions.Instance.ErrorLog("set enemy-face-hp to: " + this.enfacehp);
            ComboBreaker.Instance.attackFaceHP = this.enfacehp;
            Ai.Instance.setMaxWide(this.maxwide);
            Helpfunctions.Instance.ErrorLog("set maxwide to: " + this.maxwide);

            Ai.Instance.setTwoTurnSimulation(false, this.twotsamount);
            Helpfunctions.Instance.ErrorLog("calculate the second turn of the " + this.twotsamount + " best boards");
            if (this.twotsamount >= 1)
            {
                if (this.simEnemySecondTurn) Helpfunctions.Instance.ErrorLog("simulates the enemy turn on your second turn");
            }
            if (this.useSecretsPlayArround)
            {
                Helpfunctions.Instance.ErrorLog("playing arround secrets is " + this.useSecretsPlayArround);
            }
            if (this.playarround)
            {
                Ai.Instance.setPlayAround();
                Helpfunctions.Instance.ErrorLog("activated playaround AOE Spells");
            }
            if (this.writeToSingleFile) Helpfunctions.Instance.ErrorLog("write log to single file");


        }


        private Settings()
        {
            this.writeToSingleFile = false;
        }


        public int maxwide = 3000;
        public int twotsamount = 0;

        public bool useExternalProcess = false;
        public bool passiveWaiting = false;

        public int alpha = 50;
        public float firstweight = 0.5f;
        public float secondweight = 0.5f;

        public int numberOfThreads = 32;
        public bool useSecretsPlayArround = false;

        public bool simulatePlacement = true;

        public bool simulateEnemysTurn = true;
        public int enemyTurnMaxWide = 20;
        public int enemyTurnMaxWideSecondTime = 200;

        public int secondTurnAmount = 256;
        public bool simEnemySecondTurn = true;
        public int enemySecondTurnMaxWide = 20;

        public int nextTurnDeep = 6;
        public int nextTurnMaxWide = 20;
        public int nextTurnTotalBoards = 50;

        public bool playarround = false;
        public int playaroundprob = 50;
        public int playaroundprob2 = 80;

        public int enfacehp = 15;

        public string path = "";
        public string logpath = "";
        public string logfile = "Logg.txt";

        public bool concede = false;
        public bool enemyConcede = false;
        public bool writeToSingleFile = false;

        public bool learnmode = true;
        public bool printlearnmode = true;

        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                return instance ?? (instance = new Settings());
            }
        }

        public void setWeights(int alpha)
        {
            float a = ((float)alpha) / 100f;
            this.firstweight = 1f - a;
            this.secondweight = a;
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