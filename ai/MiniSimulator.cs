namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class MiniSimulator
    {
        //#####################################################################################################################
        private int maxdeep = 6;
        private int maxwide = 10;
        private int totalboards = 50;
        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;


        private bool printNormalstuff = false;

        public int boardindexToSimulate = 0;
        List<Playfield> posmoves = new List<Playfield>(7000);
        List<Playfield> twoturnfields = new List<Playfield>(500);

        List<List<Playfield>> threadresults = new List<List<Playfield>>(64);
        private int dirtyTwoTurnSim = 256;

        public Action bestmove = null;
        public float bestmoveValue = 0;
        public Playfield bestboard = new Playfield();

        public Behavior botBase = null;
        private int calculated = 0;

        private bool simulateSecondTurn = false;
        private bool playaround = false;
        private int playaroundprob = 50;
        private int playaroundprob2 = 80;

        Movegenerator movegen = Movegenerator.Instance;

        PenalityManager pen = PenalityManager.Instance;

        public MiniSimulator()
        {
        }
        public MiniSimulator(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void updateParams(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void setPrintingstuff(bool sp)
        {
            this.printNormalstuff = sp;
        }

        public void setSecondTurnSimu(bool sts, int amount)
        {
            //this.simulateSecondTurn = sts;
            this.dirtyTwoTurnSim = amount;
        }

        public void setPlayAround(bool spa, int pprob, int pprob2)
        {
            this.playaround = spa;
            this.playaroundprob = pprob;
            this.playaroundprob2 = pprob2;
        }

        private void addToPosmoves(Playfield pf)
        {
            if (pf.ownHero.Hp <= 0) return;
            /*foreach (Playfield p in this.posmoves)
            {
                if (pf.isEqual(p, false)) return;
            }*/
            this.posmoves.Add(pf);

            //posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best
            //if (posmoves.Count > this.maxwide) posmoves.RemoveAt(this.maxwide);
            if (this.totalboards >= 1)
            {
                this.calculated++;
            }
        }

        private void startEnemyTurnSim(Playfield p, bool simulateTwoTurns, bool print)
        {
            if (p.ownHero.Hp >= 1 && p.enemyHero.Hp >= 1)
            {
                //simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                p.prepareNextTurn(p.isOwnTurn);

                Ai.Instance.enemyTurnSim[0].simulateEnemysTurn(p, simulateTwoTurns, playaround, print, playaroundprob, playaroundprob2);

            }
            p.complete = true;
        }

        public float doallmoves(Playfield playf, bool isLethalCheck)
        {
            //Helpfunctions.Instance.logg("NXTTRN" + playf.mana);
            if (botBase == null) botBase = Ai.Instance.botBase;
            bool test = false;
            this.posmoves.Clear();
            this.twoturnfields.Clear();
            this.addToPosmoves(playf);
            bool havedonesomething = true;
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            //Helpfunctions.Instance.logg("NXTTRN" + playf.mana + " " + posmoves.Count);
            this.calculated = 0;
            while (havedonesomething)
            {
                if (this.printNormalstuff) Helpfunctions.Instance.logg("ailoop");
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

                    //gernerate actions and play them!
                    List<Action> actions = movegen.getMoveList(p, isLethalCheck, usePenalityManager, useCutingTargets);
                    foreach (Action a in actions)
                    {
                        //if (deep == 0 && a.actionType == actionEnum.attackWithMinion) Helpfunctions.Instance.ErrorLog("play " + a.own.entitiyID + " -> " + a.target.entitiyID);
                        havedonesomething = true;
                        Playfield pf = new Playfield(p);
                        pf.doAction(a);
                        /*if (deep == 1)
                        {
                            Helpfunctions.Instance.ErrorLog("do action...");
                            a.print(false);
                            pf.printBoard();
                        }*/
                        addToPosmoves(pf);
                    }

                    // end the turn of the current board (only if its not a lethalcheck)
                    if (isLethalCheck)
                    {
                        p.complete = true;
                    }
                    else
                    {
                        //end turn of enemy
                        p.endTurn(this.simulateSecondTurn, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                        //simulate the enemys response
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false);
                    }

                    //sort stupid stuff ouf

                    if (botBase.getPlayfieldValue(p) > bestoldval)
                    {
                        bestoldval = botBase.getPlayfieldValue(p);
                        bestold = p;
                    }
                    if (!test)
                    {
                        posmoves.Remove(p);
                    }

                    if (this.calculated > this.totalboards) break;
                }

                if (!test && bestoldval >= -10000 && bestold != null)
                {
                    this.posmoves.Add(bestold);
                }

                //Helpfunctions.Instance.loggonoff(true);
                if (this.printNormalstuff)
                {
                    int donec = 0;
                    foreach (Playfield p in posmoves)
                    {
                        if (p.complete) donec++;
                    }
                    Helpfunctions.Instance.logg("deep " + deep + " len " + this.posmoves.Count + " dones " + donec);
                }

                if (!test)
                {
                    cuttingposibilities();
                }

                if (this.printNormalstuff)
                {
                    Helpfunctions.Instance.logg("cut to len " + this.posmoves.Count);
                }
                //Helpfunctions.Instance.loggonoff(false);
                deep++;

                if (this.calculated > this.totalboards) break;
                if (deep >= this.maxdeep) break;//remove this?
            }

            foreach (Playfield p in posmoves)//temp
            {
                if (!p.complete)
                {
                    if (isLethalCheck)
                    {
                        p.complete = true;
                    }
                    else
                    {
                        p.endTurn(this.simulateSecondTurn, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false);
                    }
                }
            }

            // search the best play...........................................................

            //do dirtytwoturnsim first :D
            if (!isLethalCheck) doDirtyTwoTurnsim();

            if (!isLethalCheck) this.dirtyTwoTurnSim /= 2;

            // Helpfunctions.Instance.logg("find best ");
            if (posmoves.Count >= 1)
            {
                float bestval = int.MinValue;
                int bestanzactions = 1000;
                Playfield bestplay = posmoves[0];//temp[0]
                foreach (Playfield p in posmoves)//temp
                {
                    float val = botBase.getPlayfieldValue(p);
                    if (bestval <= val)
                    {
                        if (bestval == val && bestanzactions <= p.playactions.Count) continue;
                        bestplay = p;
                        bestval = val;
                        bestanzactions = p.playactions.Count;
                    }

                }
                this.bestmove = bestplay.getNextAction();
                this.bestmoveValue = bestval;
                this.bestboard = new Playfield(bestplay);
                //Helpfunctions.Instance.logg("return");
                return bestval;
            }
            //Helpfunctions.Instance.logg("return");
            this.bestmove = null;
            this.bestmoveValue = -100000;
            this.bestboard = playf;
            return -10000;
        }

        public void doDirtyTwoTurnsim()
        {
            //return;
            if (this.dirtyTwoTurnSim == 0) return;
            this.posmoves.Clear();
            int thread = 0;
            //DateTime started = DateTime.Now;

            //set maxwide of enemyturnsimulator's to second step (this value is higher than the maxwide in first step) 
            foreach (EnemyTurnSimulator ets in Ai.Instance.enemyTurnSim)
            {
                ets.setMaxwideSecondStep(true);
            }

            if (Settings.Instance.numberOfThreads == 1)
            {
                foreach (Playfield p in this.twoturnfields)
                {

                    if (p.ownHero.Hp >= 1 && p.enemyHero.Hp >= 1)
                    {
                        p.value = int.MinValue;
                        //simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                        p.prepareNextTurn(p.isOwnTurn);
                        p.turnCounter = 1;//correcting turncoutner: because we performed turncounter++ in the firstloop, but we perform first enemy turn also in this loop
                        Ai.Instance.enemyTurnSim[thread].simulateEnemysTurn(p, true, playaround, false, this.playaroundprob, this.playaroundprob2);
                    }
                    else
                    {
                        //p.value = -10000;
                    }
                    //Ai.Instance.enemyTurnSim.simulateEnemysTurn(p, true, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                    this.posmoves.Add(p);
                }
            }
            else
            {
                //multithreading!

                List<System.Threading.Thread> tasks = new List<System.Threading.Thread>(Settings.Instance.numberOfThreads);
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
                    //System.Threading.Thread threadl = new System.Threading.Thread(() => this.Workthread(test, botBase, isLethalCheck, playfieldsTasklist[k], threadnumbers[k]));
                    System.Threading.Thread threadl = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(this.dirtyWorkthread));
                    //System.Threading.Tasks.Task tsk = new System.Threading.Tasks.Task(this.Workthread, (object)new threadobject(test, botBase, isLethalCheck, playfieldsTasklist[k], threadnumbers[k]));
                    int i = k;
                    threadl.Start((object)i);

                    tasks.Add(threadl);

                }

                System.Threading.Thread.Sleep(1);

                for (int j = 0; j < Settings.Instance.numberOfThreads; j++)
                {
                    tasks[j].Join();
                    posmoves.AddRange(this.threadresults[j]);
                }


            }

            //just for debugging
            posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best

            //Helpfunctions.Instance.ErrorLog("time needed for parallel: " + (DateTime.Now - started).TotalSeconds);
        }

        //workthread for dirtyTwoTurnsim
        private void dirtyWorkthread(object to)
        {
            int threadnumber = (int)to;
            //Helpfunctions.Instance.ErrorLog("Hi, i'm no " + threadnumber);
            for (int i = 0; i < this.twoturnfields.Count; i++)
            {
                if (i % Settings.Instance.numberOfThreads == threadnumber)
                {
                    //if(threadnumber ==0)Helpfunctions.Instance.ErrorLog("no " + threadnumber + " calculates " + i);
                    Playfield p = this.twoturnfields[i];
                    if (p.ownHero.Hp >= 1 && p.enemyHero.Hp>=1)
                    {
                        p.value = int.MinValue;
                        //simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                        p.prepareNextTurn(p.isOwnTurn);
                        p.turnCounter = 1;//correcting turncoutner: because we performed turncounter++ in the firstloop, but we perform first enemy turn also in this loop
                        Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, true, playaround, false, this.playaroundprob, this.playaroundprob2);
                    }
                    else
                    {
                        //p.value = -10000;
                    }
                    //Ai.Instance.enemyTurnSim.simulateEnemysTurn(p, true, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                    

                    this.threadresults[threadnumber].Add(p);

                }
            }

        }



        public void cuttingposibilities()
        {
            // take the x best values
            int takenumber = this.maxwide;
            List<Playfield> temp = new List<Playfield>();
            posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best

            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(posmoves.Count, this.maxwide);

                Playfield p = null;
                Playfield pp = null;
                //foreach (Playfield p in posmoves)
                for (i = 0; i < max; i++)
                {
                    p = posmoves[i];
                    int hash = p.GetHashCode();
                    p.hashcode = hash;
                    bool found = false;
                    //foreach (Playfield pp in temp)
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
                    if (!found) temp.Add(p);
                    //i++;
                    //if (i >= this.maxwide) break;

                }


            }
            else
            {
                temp.AddRange(posmoves);
            }
            posmoves.Clear();
            posmoves.AddRange(temp.GetRange(0, Math.Min(takenumber, temp.Count)));

            //twoturnfields!
            if (this.dirtyTwoTurnSim == 0) return;
            temp.Clear();
            temp.AddRange(this.twoturnfields);
            temp.AddRange(posmoves.GetRange(0, Math.Min(this.dirtyTwoTurnSim, posmoves.Count)));
            temp.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));
            this.twoturnfields.Clear();

            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(temp.Count, this.dirtyTwoTurnSim);

                Playfield p = null;
                Playfield pp = null;
                //foreach (Playfield p in posmoves)
                for (i = 0; i < max; i++)
                {
                    p = temp[i];
                    int hash = p.GetHashCode();
                    p.hashcode = hash;
                    bool found = false;
                    //foreach (Playfield pp in temp)
                    for (int j = 0; j < twoturnfields.Count; j++)
                    {
                        pp = twoturnfields[j];
                        if (pp.hashcode == p.hashcode)
                        {
                            if (pp.isEqualf(p))
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found) twoturnfields.Add(p);
                    //i++;
                    //if (i >= this.maxwide) break;

                }


            }






            //this.twoturnfields.AddRange(temp.GetRange(0, Math.Min(this.dirtyTwoTurnSim, temp.Count)));

            //Helpfunctions.Instance.ErrorLog(this.twoturnfields.Count + "");

            //posmoves.Clear();
            //posmoves.AddRange(Helpfunctions.TakeList(temp, takenumber));

        }

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
                    if (own) m = p.enemyMinions[t.target - 10];
                    if (!own) m = p.ownMinions[t.target];
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
                        //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = mnn.handcard.card.isSpecialMinion;

                        if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                        {
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) goingtoadd = false;
                            continue;
                        }

                        if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                        {
                            if (m.name != mnn.name) // different name -> take it
                            {
                                continue;
                            }
                            // same name -> test whether they are equal
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) goingtoadd = false;
                            continue;
                        }

                    }

                    if (goingtoadd)
                    {
                        addedmins.Add(m);
                        retvalues.Add(t);
                        //help.logg(m.name + " " + m.id +" is added to targetlist");
                    }
                    else
                    {
                        //help.logg(m.name + " is not needed to attack");
                        continue;
                    }

                }
            }
            //help.logg("end targetcutting");
            if (priomins) return retvaluesPrio;

            return retvalues;
        }

        public void printPosmoves()
        {
            int i = 0;
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard(i);
                i++;
                if (i >= 200) break;
            }
        }

        public Playfield getBoard(int i)
        {
            if (i >= 0 && i < this.posmoves.Count)
            {
                boardindexToSimulate = i;
                return this.posmoves[i];
            }
            boardindexToSimulate = 0;
            return this.bestboard;
        }

    }

}