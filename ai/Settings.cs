// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="">
//   
// </copyright>
// <summary>
//   The settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The settings.
    /// </summary>
    internal class Settings
    {
        #region Static Fields

        /// <summary>
        ///     The instance.
        /// </summary>
        private static Settings instance;

        #endregion

        #region Fields

        /// <summary>
        ///     The enemy second turn max wide.
        /// </summary>
        public int enemySecondTurnMaxWide = 20;

        /// <summary>
        ///     The enemy turn max wide.
        /// </summary>
        public int enemyTurnMaxWide = 20;

        /// <summary>
        ///     The logfile.
        /// </summary>
        public string logfile = "Logg.txt";

        /// <summary>
        ///     The logpath.
        /// </summary>
        public string logpath = string.Empty;

        /// <summary>
        ///     The next turn deep.
        /// </summary>
        public int nextTurnDeep = 6;

        /// <summary>
        ///     The next turn max wide.
        /// </summary>
        public int nextTurnMaxWide = 20;

        /// <summary>
        ///     The next turn total boards.
        /// </summary>
        public int nextTurnTotalBoards = 50;

        /// <summary>
        ///     The number of threads.
        /// </summary>
        public int numberOfThreads = 32;

        /// <summary>
        ///     The path.
        /// </summary>
        public string path = string.Empty;

        /// <summary>
        ///     The playaroundprob.
        /// </summary>
        public int playaroundprob = 50;

        /// <summary>
        ///     The playaroundprob 2.
        /// </summary>
        public int playaroundprob2 = 80;

        /// <summary>
        ///     The playarround.
        /// </summary>
        public bool playarround = false;

        /// <summary>
        ///     The second turn amount.
        /// </summary>
        public int secondTurnAmount = 256;

        /// <summary>
        ///     The sim enemy second turn.
        /// </summary>
        public bool simEnemySecondTurn = true;

        /// <summary>
        ///     The simulate enemys turn.
        /// </summary>
        public bool simulateEnemysTurn = true;

        /// <summary>
        ///     The use secrets play arround.
        /// </summary>
        public bool useSecretsPlayArround = false;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Verhindert, dass eine Standardinstanz der <see cref="Settings"/> Klasse erstellt wird. 
        ///     Prevents a default instance of the <see cref="Settings"/> class from being created.
        /// </summary>
        private Settings()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }

                return instance;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The set file path.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void setFilePath(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// The set logg file.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void setLoggFile(string path)
        {
            this.logfile = path;
        }

        /// <summary>
        /// The set logg path.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void setLoggPath(string path)
        {
            this.logpath = path;
        }

        #endregion
    }
}