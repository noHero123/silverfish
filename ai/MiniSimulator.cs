// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiniSimulator.cs" company="">
//   
// </copyright>
// <summary>
//   The mini simulator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    ///     The mini simulator.
    /// </summary>
    public class MiniSimulator
    {
        // #####################################################################################################################
        #region Fields

        /// <summary>
        ///     The bestboard.
        /// </summary>
        public Playfield bestboard = new Playfield();

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
        ///     The calculated.
        /// </summary>
        private int calculated;

        /// <summary>
        ///     The dirty two turn sim.
        /// </summary>
        private int dirtyTwoTurnSim = 256;

        /// <summary>
        ///     The dont recalc.
        /// </summary>
        private bool dontRecalc = true;

        /// <summary>
        ///     The maxdeep.
        /// </summary>
        private int maxdeep = 6;

        /// <summary>
        ///     The maxwide.
        /// </summary>
        private int maxwide = 10;

        /// <summary>
        ///     The movegen.
        /// </summary>
        private Movegenerator movegen = Movegenerator.Instance;

        /// <summary>
        ///     The pen.
        /// </summary>
        private PenalityManager pen = PenalityManager.Instance;

        /// <summary>
        ///     The playaround.
        /// </summary>
        private bool playaround;

        /// <summary>
        ///     The playaroundprob.
        /// </summary>
        private int playaroundprob = 50;

        /// <summary>
        ///     The playaroundprob 2.
        /// </summary>
        private int playaroundprob2 = 80;

        /// <summary>
        ///     The posmoves.
        /// </summary>
        private List<Playfield> posmoves = new List<Playfield>(7000);

        /// <summary>
        ///     The print normalstuff.
        /// </summary>
        private bool printNormalstuff;

        /// <summary>
        ///     The simulate second turn.
        /// </summary>
        private bool simulateSecondTurn = false;

        /// <summary>
        ///     The threadresults.
        /// </summary>
        private List<List<Playfield>> threadresults = new List<List<Playfield>>(64);

        /// <summary>
        ///     The totalboards.
        /// </summary>
        private int totalboards = 50;

        /// <summary>
        ///     The twoturnfields.
        /// </summary>
        private List<Playfield> twoturnfields = new List<Playfield>(500);

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
        /// Initialisiert eine neue Instanz der <see cref="MiniSimulator"/> Klasse. 
        ///     Initializes a new instance of the <see cref="MiniSimulator"/> class.
        /// </summary>
        public MiniSimulator()
        {
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="MiniSimulator"/> Klasse. 
        /// Initializes a new instance of the <see cref="MiniSimulator"/> class.
        /// </summary>
        /// <param name="deep">
        /// The deep.
        /// </param>
        /// <param name="wide">
        /// The wide.
        /// </param>
        /// <param name="ttlboards">
        /// The ttlboards.
        /// </param>
        public MiniSimulator(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The cut attack targets.
        /// </summary>
        /// <param name="oldlist">
        /// The oldlist.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<targett> cutAttackTargets(List<targett> oldlist, Playfield p, bool own)
        {
            List<targett> retvalues = new List<targett>();
            List<Minion> addedmins = new List<Minion>(8);

            bool priomins = false;
            List<targett> retvaluesPrio = new List<targett>();
            foreach (targett t in oldlist)
            {
                if ((own && t.target == 200) || (!own && t.target == 100))
                {
                    retvalues.Add(t);
                    continue;
                }

                if ((own && t.target >= 10 && t.target <= 19) || (!own && t.target >= 0 && t.target <= 9))
                {
                    Minion m = null;
                    if (own)
                    {
                        m = p.enemyMinions[t.target - 10];
                    }

                    if (!own)
                    {
                        m = p.ownMinions[t.target];
                    }

                    /*if (penman.priorityDatabase.ContainsKey(m.name))
                    {
                        //retvalues.Add(t);
                        retvaluesPrio.Add(t);
                        priomins = true;
                        //help.logg(m.name + " is added to targetlist");
                        continue;
                    }*/
                    bool goingtoadd = true;
                    List<Minion> temp = new List<Minion>(addedmins);
                    bool isSpecial = m.handcard.card.isSpecialMinion;
                    foreach (Minion mnn in temp)
                    {
                        // special minions are allowed to attack in silended and unsilenced state!
                        // help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));
                        bool otherisSpecial = mnn.handcard.card.isSpecialMinion;

                        if ((!isSpecial || (isSpecial && m.silenced))
                            && (!otherisSpecial || (otherisSpecial && mnn.silenced)))
                        {
                            // both are not special, if they are the same, dont add
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild
                                && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous)
                            {
                                goingtoadd = false;
                            }

                            continue;
                        }

                        if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced)
                        {
                            // same are special
                            if (m.name != mnn.name)
                            {
                                // different name -> take it
                                continue;
                            }

                            // same name -> test whether they are equal
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild
                                && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous)
                            {
                                goingtoadd = false;
                            }
                        }
                    }

                    if (goingtoadd)
                    {
                        addedmins.Add(m);
                        retvalues.Add(t);

                        // help.logg(m.name + " " + m.id +" is added to targetlist");
                    }
                    else
                    {
                        // help.logg(m.name + " is not needed to attack");
                    }
                }
            }

            // help.logg("end targetcutting");
            if (priomins)
            {
                return retvaluesPrio;
            }

            return retvalues;
        }

        /// <summary>
        ///     The cuttingposibilities.
        /// </summary>
        public void cuttingposibilities()
        {
            // take the x best values
            int takenumber = this.maxwide;
            List<Playfield> temp = new List<Playfield>();
            this.posmoves.Sort(
                (a, b) => -this.botBase.getPlayfieldValue(a).CompareTo(this.botBase.getPlayfieldValue(b)));
                
                // want to keep the best
            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(this.posmoves.Count, this.maxwide);

                Playfield p = null;
                Playfield pp = null;

                // foreach (Playfield p in posmoves)
                for (i = 0; i < max; i++)
                {
                    p = this.posmoves[i];
                    int hash = p.GetHashCode();
                    p.hashcode = hash;
                    bool found = false;

                    // foreach (Playfield pp in temp)
                    for (int j = 0; j < temp.Count; j++)
                    {
                        pp = temp[j];
                        if (pp.hashcode == p.hashcode)
                        {
                            if (pp.isEqualf(p))
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        temp.Add(p);
                    }

                    // i++;
                    // if (i >= this.maxwide) break;
                }
            }
            else
            {
                temp.AddRange(this.posmoves);
            }

            this.posmoves.Clear();
            this.posmoves.AddRange(temp.GetRange(0, Math.Min(takenumber, temp.Count)));

            // twoturnfields!
            if (this.dirtyTwoTurnSim == 0)
            {
                return;
            }

            temp.Clear();
            temp.AddRange(this.twoturnfields);
            temp.AddRange(this.posmoves.GetRange(0, Math.Min(this.dirtyTwoTurnSim, this.posmoves.Count)));
            temp.Sort((a, b) => -this.botBase.getPlayfieldValue(a).CompareTo(this.botBase.getPlayfieldValue(b)));
            this.twoturnfields.Clear();

            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(temp.Count, this.dirtyTwoTurnSim);

                Playfield p = null;
                Playfield pp = null;

                // foreach (Playfield p in posmoves)
                for (i = 0; i < max; i++)
                {
                    p = temp[i];
                    int hash = p.GetHashCode();
                    p.hashcode = hash;
                    bool found = false;

                    // foreach (Playfield pp in temp)
                    for (int j = 0; j < this.twoturnfields.Count; j++)
                    {
                        pp = this.twoturnfields[j];
                        if (pp.hashcode == p.hashcode)
                        {
                            if (pp.isEqualf(p))
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        this.twoturnfields.Add(p);
                    }

                    // i++;
                    // if (i >= this.maxwide) break;
                }
            }

            // this.twoturnfields.AddRange(temp.GetRange(0, Math.Min(this.dirtyTwoTurnSim, temp.Count)));

            // Helpfunctions.Instance.ErrorLog(this.twoturnfields.Count + "");

            // posmoves.Clear();
            // posmoves.AddRange(Helpfunctions.TakeList(temp, takenumber));
        }

        /// <summary>
        ///     The do dirty two turnsim.
        /// </summary>
        public void doDirtyTwoTurnsim()
        {
            // return;
            if (this.dirtyTwoTurnSim == 0)
            {
                return;
            }

            this.posmoves.Clear();
            int thread = 0;

            // DateTime started = DateTime.Now;
            if (Settings.Instance.numberOfThreads == 1)
            {
                foreach (Playfield p in this.twoturnfields)
                {
                    if (p.guessingHeroHP >= 1)
                    {
                        p.value = int.MinValue;

                        // simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                        p.prepareNextTurn(p.isOwnTurn);
                        Ai.Instance.enemyTurnSim[thread].simulateEnemysTurn(
                            p, 
                            true, 
                            this.playaround, 
                            false, 
                            this.playaroundprob, 
                            this.playaroundprob2);
                    }

                    // Ai.Instance.enemyTurnSim.simulateEnemysTurn(p, true, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                    this.posmoves.Add(p);
                }
            }
            else
            {
                // multithreading!
                List<Thread> tasks = new List<Thread>(Settings.Instance.numberOfThreads);
                for (int kl = 0; kl < Settings.Instance.numberOfThreads; kl++)
                {
                    if (this.threadresults.Count > kl)
                    {
                        this.threadresults[kl].Clear();
                        continue;
                    }

                    this.threadresults.Add(new List<Playfield>());
                }

                int k = 0;
                for (k = 0; k < Settings.Instance.numberOfThreads; k++)
                {
                    // System.Threading.Thread threadl = new System.Threading.Thread(() => this.Workthread(test, botBase, isLethalCheck, playfieldsTasklist[k], threadnumbers[k]));
                    Thread threadl = new Thread(this.dirtyWorkthread);

                    // System.Threading.Tasks.Task tsk = new System.Threading.Tasks.Task(this.Workthread, (object)new threadobject(test, botBase, isLethalCheck, playfieldsTasklist[k], threadnumbers[k]));
                    int i = k;
                    threadl.Start(i);

                    tasks.Add(threadl);
                }

                Thread.Sleep(1);

                for (int j = 0; j < Settings.Instance.numberOfThreads; j++)
                {
                    tasks[j].Join();
                    this.posmoves.AddRange(this.threadresults[j]);
                }
            }

            // Helpfunctions.Instance.ErrorLog("time needed for parallel: " + (DateTime.Now - started).TotalSeconds);
        }

        /// <summary>
        /// The doallmoves.
        /// </summary>
        /// <param name="playf">
        /// The playf.
        /// </param>
        /// <param name="isLethalCheck">
        /// The is lethal check.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        public float doallmoves(Playfield playf, bool isLethalCheck)
        {
            // Helpfunctions.Instance.logg("NXTTRN" + playf.mana);
            if (this.botBase == null)
            {
                this.botBase = Ai.Instance.botBase;
            }

            bool test = false;
            this.posmoves.Clear();
            this.twoturnfields.Clear();
            this.addToPosmoves(playf);
            bool havedonesomething = true;
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;

            // Helpfunctions.Instance.logg("NXTTRN" + playf.mana + " " + posmoves.Count);
            this.calculated = 0;
            while (havedonesomething)
            {
                if (this.printNormalstuff)
                {
                    Helpfunctions.Instance.logg("ailoop");
                }

                GC.Collect();
                temp.Clear();
                temp.AddRange(this.posmoves);
                havedonesomething = false;
                Playfield bestold = null;
                float bestoldval = -20000000;
                foreach (Playfield p in temp)
                {
                    if (p.complete || p.ownHero.Hp <= 0)
                    {
                        continue;
                    }

                    // gernerate actions and play them!
                    List<Action> actions = this.movegen.getMoveList(
                        p, 
                        isLethalCheck, 
                        this.usePenalityManager, 
                        this.useCutingTargets);
                    foreach (Action a in actions)
                    {
                        // if (deep == 0 && a.actionType == actionEnum.playcard) Helpfunctions.Instance.ErrorLog("play " + a.card.card.name);
                        havedonesomething = true;
                        Playfield pf = new Playfield(p);
                        pf.doAction(a);
                        this.addToPosmoves(pf);
                    }

                    // end the turn of the current board (only if its not a lethalcheck)
                    if (isLethalCheck)
                    {
                        p.complete = true;
                    }
                    else
                    {
                        // end turn of enemy
                        p.endTurn(
                            this.simulateSecondTurn, 
                            this.playaround, 
                            false, 
                            this.playaroundprob, 
                            this.playaroundprob2);

                        // simulate the enemys response
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false);
                    }

                    // sort stupid stuff ouf
                    if (this.botBase.getPlayfieldValue(p) > bestoldval)
                    {
                        bestoldval = this.botBase.getPlayfieldValue(p);
                        bestold = p;
                    }

                    if (!test)
                    {
                        this.posmoves.Remove(p);
                    }

                    if (this.calculated > this.totalboards)
                    {
                        break;
                    }
                }

                if (!test && bestoldval >= -10000 && bestold != null)
                {
                    this.posmoves.Add(bestold);
                }

                // Helpfunctions.Instance.loggonoff(true);
                if (this.printNormalstuff)
                {
                    int donec = 0;
                    foreach (Playfield p in this.posmoves)
                    {
                        if (p.complete)
                        {
                            donec++;
                        }
                    }

                    Helpfunctions.Instance.logg("deep " + deep + " len " + this.posmoves.Count + " dones " + donec);
                }

                if (!test)
                {
                    this.cuttingposibilities();
                }

                if (this.printNormalstuff)
                {
                    Helpfunctions.Instance.logg("cut to len " + this.posmoves.Count);
                }

                // Helpfunctions.Instance.loggonoff(false);
                deep++;

                if (this.calculated > this.totalboards)
                {
                    break;
                }

                if (deep >= this.maxdeep)
                {
                    break; // remove this?
                }
            }

            foreach (Playfield p in this.posmoves)
            {
                // temp
                if (!p.complete)
                {
                    if (isLethalCheck)
                    {
                        p.complete = true;
                    }
                    else
                    {
                        p.endTurn(
                            this.simulateSecondTurn, 
                            this.playaround, 
                            false, 
                            this.playaroundprob, 
                            this.playaroundprob2);
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false);
                    }
                }
            }

            // search the best play...........................................................

            // do dirtytwoturnsim first :D
            if (!isLethalCheck)
            {
                this.doDirtyTwoTurnsim();
            }

            if (!isLethalCheck)
            {
                this.dirtyTwoTurnSim /= 2;
            }

            // Helpfunctions.Instance.logg("find best ");
            if (this.posmoves.Count >= 1)
            {
                float bestval = int.MinValue;
                int bestanzactions = 1000;
                Playfield bestplay = this.posmoves[0]; // temp[0]
                foreach (Playfield p in this.posmoves)
                {
                    // temp
                    float val = this.botBase.getPlayfieldValue(p);
                    if (bestval <= val)
                    {
                        if (bestval == val && bestanzactions < p.playactions.Count)
                        {
                            continue;
                        }

                        bestplay = p;
                        bestval = val;
                        bestanzactions = p.playactions.Count;
                    }
                }

                this.bestmove = bestplay.getNextAction();
                this.bestmoveValue = bestval;
                this.bestboard = new Playfield(bestplay);

                // Helpfunctions.Instance.logg("return");
                return bestval;
            }

            // Helpfunctions.Instance.logg("return");
            this.bestmove = null;
            this.bestmoveValue = -100000;
            this.bestboard = playf;
            return -10000;
        }

        /// <summary>
        ///     The print posmoves.
        /// </summary>
        public void printPosmoves()
        {
            int i = 0;
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
                i++;
                if (i >= 200)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// The set play around.
        /// </summary>
        /// <param name="spa">
        /// The spa.
        /// </param>
        /// <param name="pprob">
        /// The pprob.
        /// </param>
        /// <param name="pprob2">
        /// The pprob 2.
        /// </param>
        public void setPlayAround(bool spa, int pprob, int pprob2)
        {
            this.playaround = spa;
            this.playaroundprob = pprob;
            this.playaroundprob2 = pprob2;
        }

        /// <summary>
        /// The set printingstuff.
        /// </summary>
        /// <param name="sp">
        /// The sp.
        /// </param>
        public void setPrintingstuff(bool sp)
        {
            this.printNormalstuff = sp;
        }

        /// <summary>
        /// The set second turn simu.
        /// </summary>
        /// <param name="sts">
        /// The sts.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        public void setSecondTurnSimu(bool sts, int amount)
        {
            // this.simulateSecondTurn = sts;
            this.dirtyTwoTurnSim = amount;
        }

        /// <summary>
        /// The update params.
        /// </summary>
        /// <param name="deep">
        /// The deep.
        /// </param>
        /// <param name="wide">
        /// The wide.
        /// </param>
        /// <param name="ttlboards">
        /// The ttlboards.
        /// </param>
        public void updateParams(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add to posmoves.
        /// </summary>
        /// <param name="pf">
        /// The pf.
        /// </param>
        private void addToPosmoves(Playfield pf)
        {
            if (pf.ownHero.Hp <= 0)
            {
                return;
            }

            /*foreach (Playfield p in this.posmoves)
            {
                if (pf.isEqual(p, false)) return;
            }*/
            this.posmoves.Add(pf);

            // posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best
            // if (posmoves.Count > this.maxwide) posmoves.RemoveAt(this.maxwide);
            if (this.totalboards >= 1)
            {
                this.calculated++;
            }
        }

        // workthread for dirtyTwoTurnsim
        /// <summary>
        /// The dirty workthread.
        /// </summary>
        /// <param name="to">
        /// The to.
        /// </param>
        private void dirtyWorkthread(object to)
        {
            int threadnumber = (int)to;

            // Helpfunctions.Instance.ErrorLog("Hi, i'm no " + threadnumber);
            for (int i = 0; i < this.twoturnfields.Count; i++)
            {
                if (i % Settings.Instance.numberOfThreads == threadnumber)
                {
                    // if(threadnumber ==0)Helpfunctions.Instance.ErrorLog("no " + threadnumber + " calculates " + i);
                    Playfield p = this.twoturnfields[i];
                    if (p.guessingHeroHP >= 1)
                    {
                        p.value = int.MinValue;

                        // simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                        p.prepareNextTurn(p.isOwnTurn);
                        Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(
                            p, 
                            true, 
                            this.playaround, 
                            false, 
                            this.playaroundprob, 
                            this.playaroundprob2);
                    }

                    // Ai.Instance.enemyTurnSim.simulateEnemysTurn(p, true, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                    this.threadresults[threadnumber].Add(p);
                }
            }
        }

        /// <summary>
        /// The start enemy turn sim.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="simulateTwoTurns">
        /// The simulate two turns.
        /// </param>
        /// <param name="print">
        /// The print.
        /// </param>
        private void startEnemyTurnSim(Playfield p, bool simulateTwoTurns, bool print)
        {
            if (p.guessingHeroHP >= 1)
            {
                // simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                p.prepareNextTurn(p.isOwnTurn);

                Ai.Instance.enemyTurnSim[0].simulateEnemysTurn(
                    p, 
                    simulateTwoTurns, 
                    this.playaround, 
                    print, 
                    this.playaroundprob, 
                    this.playaroundprob2);
            }

            p.complete = true;
        }

        #endregion
    }
}