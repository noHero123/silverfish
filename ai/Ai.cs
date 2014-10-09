// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ai.cs" company="">
//   
// </copyright>
// <summary>
//   The ai.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The ai.
    /// </summary>
    public class Ai
    {
        #region Static Fields

        /// <summary>
        ///     The instance.
        /// </summary>
        private static Ai instance;

        #endregion

        #region Fields

        /// <summary>
        ///     The best actions.
        /// </summary>
        public List<Action> bestActions = new List<Action>();

        /// <summary>
        ///     The bestmove.
        /// </summary>
        public Action bestmove = null;

        /// <summary>
        ///     The bestmove value.
        /// </summary>
        public float bestmoveValue = 0;

        /// <summary>
        ///     The bot base.
        /// </summary>
        public Behavior botBase = null;

        /// <summary>
        ///     The current calculated board.
        /// </summary>
        public string currentCalculatedBoard = "1";

        /// <summary>
        ///     The enemy second turn sim.
        /// </summary>
        public List<EnemyTurnSimulator> enemySecondTurnSim = new List<EnemyTurnSimulator>();

        /// <summary>
        ///     The enemy turn sim.
        /// </summary>
        public List<EnemyTurnSimulator> enemyTurnSim = new List<EnemyTurnSimulator>();

        /// <summary>
        ///     The lethal missing.
        /// </summary>
        public int lethalMissing = 30; // RR

        /// <summary>
        ///     The main turn simulator.
        /// </summary>
        public MiniSimulator mainTurnSimulator;

        /// <summary>
        ///     The maxwide.
        /// </summary>
        public int maxwide = 3000;

        /// <summary>
        ///     The next move guess.
        /// </summary>
        public Playfield nextMoveGuess = new Playfield();

        /// <summary>
        ///     The next turn simulator.
        /// </summary>
        public List<MiniSimulatorNextTurn> nextTurnSimulator = new List<MiniSimulatorNextTurn>();

        /// <summary>
        ///     The playaround.
        /// </summary>
        public bool playaround = false;

        /// <summary>
        ///     The playaroundprob 2.
        /// </summary>
        public int playaroundprob2 = 80;

        /// <summary>
        ///     The secondturnsim.
        /// </summary>
        public bool secondturnsim = false;

        /// <summary>
        ///     The dont recalc.
        /// </summary>
        private bool dontRecalc = true;

        /// <summary>
        ///     The help.
        /// </summary>
        private Helpfunctions help = Helpfunctions.Instance;

        /// <summary>
        ///     The hm.
        /// </summary>
        private Handmanager hm = Handmanager.Instance;

        /// <summary>
        ///     The hp.
        /// </summary>
        private Hrtprozis hp = Hrtprozis.Instance;

        /// <summary>
        ///     The maxdeep.
        /// </summary>
        private int maxdeep = 12;

        /// <summary>
        ///     The penman.
        /// </summary>
        private PenalityManager penman = PenalityManager.Instance;

        /// <summary>
        ///     The posmoves.
        /// </summary>
        private List<Playfield> posmoves = new List<Playfield>(7000);

        /// <summary>
        ///     The use comparison.
        /// </summary>
        private bool useComparison = true;

        /// <summary>
        ///     The use cuting targets.
        /// </summary>
        private bool useCutingTargets = true;

        /// <summary>
        ///     The use lethal check.
        /// </summary>
        private bool useLethalCheck = true;

        /// <summary>
        ///     The use penality manager.
        /// </summary>
        private bool usePenalityManager = true;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Verhindert, dass eine Standardinstanz der <see cref="Ai"/> Klasse erstellt wird. 
        ///     Prevents a default instance of the <see cref="Ai"/> class from being created.
        /// </summary>
        private Ai()
        {
            this.nextMoveGuess = new Playfield { mana = -100 };

            this.mainTurnSimulator = new MiniSimulator(this.maxdeep, this.maxwide, 0); // 0 for unlimited
            this.mainTurnSimulator.setPrintingstuff(true);

            /*this.nextTurnSimulator = new MiniSimulatorNextTurn();
            this.enemyTurnSim = new EnemyTurnSimulator();
            this.enemySecondTurnSim = new EnemyTurnSimulator();*/
            for (int i = 0; i < Settings.Instance.numberOfThreads; i++)
            {
                this.nextTurnSimulator.Add(new MiniSimulatorNextTurn());
                this.enemyTurnSim.Add(new EnemyTurnSimulator());
                this.enemySecondTurnSim.Add(new EnemyTurnSimulator());

                this.nextTurnSimulator[i].thread = i;
                this.enemyTurnSim[i].thread = i;
                this.enemySecondTurnSim[i].thread = i;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        public static Ai Instance
        {
            get
            {
                return instance ?? (instance = new Ai());
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The auto tester.
        /// </summary>
        /// <param name="printstuff">
        /// The printstuff.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public void autoTester(bool printstuff, string data = "")
        {
            this.help.logg("simulating board ");

            BoardTester bt = new BoardTester(data);
            if (!bt.datareaded)
            {
                return;
            }

            this.hp.printHero();
            this.hp.printOwnMinions();
            this.hp.printEnemyMinions();
            this.hm.printcards();

            // calculate the stuff
            this.posmoves.Clear();
            this.posmoves.Add(new Playfield());
            this.posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
            }

            this.help.logg("ownminionscount " + this.posmoves[0].ownMinions.Count);
            this.help.logg("owncardscount " + this.posmoves[0].owncards.Count);

            foreach (Handmanager.Handcard item in this.posmoves[0].owncards)
            {
                this.help.logg(
                    "card " + item.card.name + " is playable :" + item.canplayCard(this.posmoves[0]) + " cost/mana: "
                    + item.manacost + "/" + this.posmoves[0].mana);
            }

            this.help.logg(
                "ability " + this.posmoves[0].ownHeroAblility.card.name + " is playable :"
                + this.posmoves[0].ownHeroAblility.card.canplayCard(this.posmoves[0], 2) + " cost/mana: "
                + this.posmoves[0].ownHeroAblility.card.getManaCost(this.posmoves[0], 2) + "/" + this.posmoves[0].mana);

            // lethalcheck + normal
            DateTime strt = DateTime.Now;
            this.doallmoves(false, true);
            this.help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
            double timeneeded = 0;
            if (this.bestmoveValue < 10000)
            {
                this.posmoves.Clear();
                this.posmoves.Add(new Playfield());
                this.posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;
                strt = DateTime.Now;
                this.doallmoves(false, false);
                timeneeded = (DateTime.Now - strt).TotalSeconds;
                this.help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
            }

            if (printstuff)
            {
                this.mainTurnSimulator.printPosmoves();
                this.simmulateWholeTurn();
                this.help.logg("calculated " + timeneeded);
            }
        }

        /// <summary>
        ///     The do next calced move.
        /// </summary>
        public void doNextCalcedMove()
        {
            this.help.logg("noRecalcNeeded!!!-----------------------------------");

            // this.bestboard.printActions();
            this.bestmove = null;
            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }

            if (this.nextMoveGuess == null)
            {
                this.nextMoveGuess = new Playfield();
            }

            // this.nextMoveGuess.printBoardDebug();
            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn)
            {
                // save the guessed move, so we doesnt need to recalc!
                // this.nextMoveGuess = new Playfield();
                Helpfunctions.Instance.logg("nmgsim-");
                try
                {
                    this.nextMoveGuess.doAction(this.bestmove);
                    this.bestmove = this.nextMoveGuess.playactions[this.nextMoveGuess.playactions.Count - 1];
                }
                catch (Exception ex)
                {
                    Helpfunctions.Instance.logg("Message ---");
                    Helpfunctions.Instance.logg("Message ---" + ex.Message);
                    Helpfunctions.Instance.logg("Source ---" + ex.Source);
                    Helpfunctions.Instance.logg("StackTrace ---" + ex.StackTrace);
                    Helpfunctions.Instance.logg("TargetSite ---\n{0}" + ex.TargetSite);
                }

                Helpfunctions.Instance.logg("nmgsime-");
            }
            else
            {
                // Helpfunctions.Instance.logg("nd trn");
                this.nextMoveGuess.mana = -100;
            }
        }

        /// <summary>
        /// The dosomethingclever.
        /// </summary>
        /// <param name="bbase">
        /// The bbase.
        /// </param>
        public void dosomethingclever(Behavior bbase)
        {
            // return;
            // turncheck
            // help.moveMouse(950,750);
            // help.Screenshot();
            this.botBase = bbase;
            this.hp.updatePositions();

            this.posmoves.Clear();
            this.posmoves.Add(new Playfield());
            this.posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;

            /* foreach (var item in this.posmoves[0].owncards)
             {
                 help.logg("card " + item.handcard.card.name + " is playable :" + item.handcard.card.canplayCard(posmoves[0]) + " cost/mana: " + item.handcard.card.cost + "/" + posmoves[0].mana);
             }
             */
            // help.logg("is hero ready?" + posmoves[0].ownHeroReady);
            this.help.loggonoff(false);

            // do we need to recalc?
            this.help.logg("recalc-check###########");
            if (this.dontRecalc && this.posmoves[0].isEqual(this.nextMoveGuess, true))
            {
                this.doNextCalcedMove();
            }
            else
            {
                this.help.logg("Leathal-check###########");
                this.bestmoveValue = -1000000;
                DateTime strt = DateTime.Now;
                if (this.useLethalCheck)
                {
                    strt = DateTime.Now;
                    this.doallmoves(false, true);
                    this.help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
                }

                if (this.bestmoveValue < 10000)
                {
                    this.posmoves.Clear();
                    this.posmoves.Add(new Playfield());
                    this.posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;
                    this.help.logg("no lethal, do something random######");
                    strt = DateTime.Now;
                    this.doallmoves(false, false);
                    this.help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
                }
            }

            // help.logging(true);
        }

        /// <summary>
        /// The set best moves.
        /// </summary>
        /// <param name="alist">
        /// The alist.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void setBestMoves(List<Action> alist, float value)
        {
            this.help.logg("set best action-----------------------------------");
            this.bestActions.Clear();
            this.bestmove = null;

            foreach (Action a in alist)
            {
                this.help.logg("-a-");
                this.bestActions.Add(new Action(a));
                this.bestActions[this.bestActions.Count - 1].print();
            }

            // this.bestActions.Add(new Action(actionEnum.endturn, null, null, 0, null, 0, 0));
            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }

            this.nextMoveGuess = new Playfield();

            // only debug:
            // this.nextMoveGuess.printBoardDebug();
            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn)
            {
                // save the guessed move, so we doesnt need to recalc!
                Helpfunctions.Instance.logg("nmgsim-");
                try
                {
                    this.nextMoveGuess.doAction(this.bestmove);
                    this.bestmove = this.nextMoveGuess.playactions[this.nextMoveGuess.playactions.Count - 1];
                }
                catch (Exception ex)
                {
                    Helpfunctions.Instance.logg("Message ---");
                    Helpfunctions.Instance.logg("Message ---" + ex.Message);
                    Helpfunctions.Instance.logg("Source ---" + ex.Source);
                    Helpfunctions.Instance.logg("StackTrace ---" + ex.StackTrace);
                    Helpfunctions.Instance.logg("TargetSite ---\n{0}" + ex.TargetSite);
                }

                Helpfunctions.Instance.logg("nmgsime-");
            }
            else
            {
                this.nextMoveGuess.mana = -100;
            }
        }

        /// <summary>
        /// The set max wide.
        /// </summary>
        /// <param name="mw">
        /// The mw.
        /// </param>
        public void setMaxWide(int mw)
        {
            this.maxwide = mw;
            if (this.maxwide <= 100)
            {
                this.maxwide = 100;
            }

            this.mainTurnSimulator.updateParams(this.maxdeep, this.maxwide, 0);
        }

        /// <summary>
        ///     The set play around.
        /// </summary>
        public void setPlayAround()
        {
            this.mainTurnSimulator.setPlayAround(
                Settings.Instance.playarround, 
                Settings.Instance.playaroundprob, 
                Settings.Instance.playaroundprob2);
        }

        /// <summary>
        /// The set two turn simulation.
        /// </summary>
        /// <param name="stts">
        /// The stts.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        public void setTwoTurnSimulation(bool stts, int amount)
        {
            this.mainTurnSimulator.setSecondTurnSimu(stts, amount);
            this.secondturnsim = stts;
            Settings.Instance.secondTurnAmount = amount;
        }

        /// <summary>
        ///     The simmulate whole turn.
        /// </summary>
        public void simmulateWholeTurn()
        {
            this.help.ErrorLog(
                "########################################################################################################");
            this.help.ErrorLog("simulate best board");
            this.help.ErrorLog(
                "########################################################################################################");

            // this.bestboard.printActions();
            Playfield tempbestboard = new Playfield();

            tempbestboard.printBoard();

            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn)
            {
                // save the guessed move, so we doesnt need to recalc!
                this.bestmove.print();

                tempbestboard.doAction(this.bestmove);
            }
            else
            {
                tempbestboard.mana = -100;
            }

            this.help.logg("-------------");
            tempbestboard.printBoard();

            foreach (Action bestmovee in this.bestActions)
            {
                this.help.logg("stepp");

                if (bestmovee != null && this.bestmove.actionType != actionEnum.endturn)
                {
                    // save the guessed move, so we doesnt need to recalc!
                    bestmovee.print();

                    tempbestboard.doAction(bestmovee);
                }
                else
                {
                    tempbestboard.mana = -100;
                }

                this.help.logg("-------------");
                tempbestboard.printBoard();
            }

            // help.logg("AFTER ENEMY TURN:" );
            tempbestboard.sEnemTurn = true;
            tempbestboard.endTurn(
                false, 
                this.playaround, 
                false, 
                Settings.Instance.playaroundprob, 
                Settings.Instance.playaroundprob2);
            this.help.logg("ENEMY TURN:-----------------------------");
            tempbestboard.value = int.MinValue;
            tempbestboard.prepareNextTurn(tempbestboard.isOwnTurn);
            Instance.enemyTurnSim[0].simulateEnemysTurn(
                tempbestboard, 
                true, 
                this.playaround, 
                true, 
                Settings.Instance.playaroundprob, 
                Settings.Instance.playaroundprob2);
        }

        /// <summary>
        ///     The simmulate whole turnand print.
        /// </summary>
        public void simmulateWholeTurnandPrint()
        {
            this.help.ErrorLog("###################################");
            this.help.ErrorLog("what would silverfish do?---------");
            this.help.ErrorLog("###################################");
            if (this.bestmoveValue >= 10000)
            {
                this.help.ErrorLog("DETECTED LETHAL ###################################");
            }

            // this.bestboard.printActions();
            Playfield tempbestboard = new Playfield();

            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn)
            {
                // save the guessed move, so we doesnt need to recalc!
                tempbestboard.doAction(this.bestmove);
                tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);

                if (this.bestActions.Count == 0)
                {
                    this.help.ErrorLog("end turn");
                }
            }
            else
            {
                tempbestboard.mana = -100;
                this.help.ErrorLog("end turn");
            }

            foreach (Action bestmovee in this.bestActions)
            {
                if (bestmovee != null && this.bestmove.actionType != actionEnum.endturn)
                {
                    // save the guessed move, so we doesnt need to recalc!
                    // bestmovee.print();
                    tempbestboard.doAction(bestmovee);
                    tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);
                }
                else
                {
                    tempbestboard.mana = -100;
                    this.help.ErrorLog("end turn");
                }
            }
        }

        /// <summary>
        /// The update entitiy.
        /// </summary>
        /// <param name="old">
        /// The old.
        /// </param>
        /// <param name="newone">
        /// The newone.
        /// </param>
        public void updateEntitiy(int old, int newone)
        {
            Helpfunctions.Instance.logg("entityupdate! " + old + " to " + newone);
            if (this.nextMoveGuess != null)
            {
                foreach (Minion m in this.nextMoveGuess.ownMinions)
                {
                    if (m.entitiyID == old)
                    {
                        m.entitiyID = newone;
                    }
                }

                foreach (Minion m in this.nextMoveGuess.enemyMinions)
                {
                    if (m.entitiyID == old)
                    {
                        m.entitiyID = newone;
                    }
                }
            }

            foreach (Action a in this.bestActions)
            {
                if (a.own != null && a.own.entitiyID == old)
                {
                    a.own.entitiyID = newone;
                }

                if (a.target != null && a.target.entitiyID == old)
                {
                    a.target.entitiyID = newone;
                }

                if (a.card != null && a.card.entity == old)
                {
                    a.card.entity = newone;
                }
            }
        }

        /// <summary>
        ///     The update two turn sim.
        /// </summary>
        public void updateTwoTurnSim()
        {
            this.mainTurnSimulator.setSecondTurnSimu(
                Settings.Instance.simulateEnemysTurn, 
                Settings.Instance.secondTurnAmount);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The doallmoves.
        /// </summary>
        /// <param name="test">
        /// The test.
        /// </param>
        /// <param name="isLethalCheck">
        /// The is lethal check.
        /// </param>
        private void doallmoves(bool test, bool isLethalCheck)
        {
            this.mainTurnSimulator.doallmoves(this.posmoves[0], isLethalCheck);

            Playfield bestplay = this.mainTurnSimulator.bestboard;
            float bestval = this.mainTurnSimulator.bestmoveValue;

            this.help.loggonoff(true);
            this.help.logg("-------------------------------------");
            this.help.logg("value of best board " + bestval);

            if (isLethalCheck)
            {
                this.lethalMissing = bestplay.enemyHero.armor + bestplay.enemyHero.Hp; // RR
                this.help.logg("missing dmg to lethal " + this.lethalMissing);
            }
            else
            {
                this.lethalMissing = 130;
            }

            this.bestActions.Clear();
            this.bestmove = null;
            foreach (Action a in bestplay.playactions)
            {
                this.bestActions.Add(new Action(a));
                a.print();
            }

            // this.bestActions.Add(new Action(actionEnum.endturn, null, null, 0, null, 0, 0));
            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }

            this.bestmoveValue = bestval;

            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn)
            {
                // save the guessed move, so we doesnt need to recalc!
                this.nextMoveGuess = new Playfield();

                this.nextMoveGuess.doAction(this.bestmove);
            }
            else
            {
                this.nextMoveGuess.mana = -100;
            }
        }

        #endregion
    }
}