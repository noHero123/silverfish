namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public class MiniSimulatorNextTurn
    {
        //#####################################################################################################################
        //public int maxdeep = 6;
        //public int maxwide = 10;
        //public int totalboards = 50;

        public int thread = 0;

        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;

        public bool doEnemySecondTurn = false;

        List<Playfield> posmoves = new List<Playfield>(7000);

        public Action bestmove = null;
        public float bestmoveValue = 0;
        public Playfield bestboard = new Playfield();

        public Behavior botBase = null;
        private int calculated = 0;

        private bool simulateSecondTurn = false;

        Movegenerator movegen = Movegenerator.Instance;


        public MiniSimulatorNextTurn()
        {
        }



        private void addToPosmoves(Playfield pf, int totalboards)
        {
            if (pf.ownHero.Hp <= 0) return;
            /*foreach (Playfield p in this.posmoves)
            {
                if (pf.isEqual(p, false)) return;
            }*/
            this.posmoves.Add(pf);
            //posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best
            //if (posmoves.Count > this.maxwide) posmoves.RemoveAt(this.maxwide);
            if (totalboards >= 1)
            {
                this.calculated++;
            }
        }

        private void startEnemyTurnSim(Playfield p, bool simulateTwoTurns, bool print, bool playaround, int playaroundprob, int playaroundprob2)
        {
            if (p.ownHero.Hp >= 1 && p.enemyHero.Hp>=1)
            {
                //simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                p.prepareNextTurn(p.isOwnTurn);
                //Helpfunctions.Instance.ErrorLog("tc " + p.turnCounter);
                Ai.Instance.enemySecondTurnSim[this.thread].simulateEnemysTurn(p, simulateTwoTurns, playaround, print, playaroundprob, playaroundprob2);
                /*
                if (p.turnCounter >= 2)
                    Ai.Instance.enemySecondTurnSim.simulateEnemysTurn(p, simulateTwoTurns, playaround, print, playaroundprob, playaroundprob2);
                else
                    Ai.Instance.enemyTurnSim.simulateEnemysTurn(p, simulateTwoTurns, playaround, print, playaroundprob, playaroundprob2);
                */
            }
            p.complete = true;
        }

        public float doallmoves(Playfield playf, bool isLethalCheck, bool print = false)
        {

            //todo only one time!
            this.doEnemySecondTurn = Settings.Instance.simEnemySecondTurn;
            int totalboards = Settings.Instance.nextTurnTotalBoards;
            int maxwide = Settings.Instance.nextTurnMaxWide;
            int maxdeep = Settings.Instance.nextTurnDeep;
            bool playaround = Settings.Instance.playarround;
            int playaroundprob = Settings.Instance.playaroundprob;
            int playaroundprob2 = Settings.Instance.playaroundprob2;


            //Helpfunctions.Instance.logg("NXTTRN" + playf.mana);
            if (botBase == null) botBase = Ai.Instance.botBase;
            bool test = false;
            this.posmoves.Clear();
            this.addToPosmoves(playf, totalboards);
            bool havedonesomething = true;
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            //Helpfunctions.Instance.logg("NXTTRN" + playf.mana + " " + posmoves.Count);
            this.calculated = 0;
            while (havedonesomething)
            {
                //if (this.printNormalstuff) Helpfunctions.Instance.logg("ailoop");
                //GC.Collect();
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

                    List<Action> actions = movegen.getMoveList(p, isLethalCheck, usePenalityManager, useCutingTargets);
                    foreach (Action a in actions)
                    {
                        havedonesomething = true;
                        Playfield pf = new Playfield(p);
                        pf.doAction(a);
                        addToPosmoves(pf, totalboards);
                    }


                    if (isLethalCheck)
                    {
                        p.complete = true;
                    }
                    else
                    {
                        p.sEnemTurn = this.doEnemySecondTurn;
                        p.endTurn(this.simulateSecondTurn, playaround, false, playaroundprob, playaroundprob2);
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false, playaround, playaroundprob, playaroundprob2);
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

                    if (this.calculated > totalboards) break;
                }

                if (!test && bestoldval >= -10000 && bestold != null)
                {
                    this.posmoves.Add(bestold);
                }

                //Helpfunctions.Instance.loggonoff(true);
                /*if (this.printNormalstuff)
                {
                    int donec = 0;
                    foreach (Playfield p in posmoves)
                    {
                        if (p.complete) donec++;
                    }
                    Helpfunctions.Instance.logg("deep " + deep + " len " + this.posmoves.Count + " dones " + donec);
                }*/

                if (!test)
                {
                    cuttingposibilities(maxwide);
                }

                //if (this.printNormalstuff) Helpfunctions.Instance.logg("cut to len " + this.posmoves.Count);
                //Helpfunctions.Instance.loggonoff(false);
                deep++;

                if (this.calculated > totalboards) break;
                if (deep >= maxdeep) break;//remove this?
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
                        p.sEnemTurn = this.doEnemySecondTurn;
                        p.endTurn(this.simulateSecondTurn, playaround, false, playaroundprob, playaroundprob2);
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false, playaround, playaroundprob, playaroundprob2);
                    }
                }
            }
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
                        if (bestval == val && bestanzactions < p.playactions.Count) continue;
                        bestplay = p;
                        bestval = val;
                        bestanzactions = p.playactions.Count;
                    }

                }
                this.bestboard = new Playfield(bestplay);

                if (print)
                {
                    Helpfunctions.Instance.ErrorLog("best board after your second turn (value included enemy second turn)----------");
                    bestplay.printBoard();
                    bestplay.value = int.MinValue;
                    bestplay.sEnemTurn = this.doEnemySecondTurn;
                    Ai.Instance.enemySecondTurnSim[this.thread].simulateEnemysTurn(bestplay, false, playaround, false, playaroundprob, playaroundprob2);
                    //Ai.Instance.enemySecondTurnSim.simulateEnemysTurn(bestplay, false, false, true, 100, 100); //dont play arround in enemys second turn

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

        public void cuttingposibilities(int maxwide)
        {
            // take the x best values
            List<Playfield> temp = new List<Playfield>();
            posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best

            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(posmoves.Count, maxwide);

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
            posmoves.AddRange(temp.GetRange(0, Math.Min(maxwide, temp.Count)));
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
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
            }
        }

    }


}