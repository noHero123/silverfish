namespace HREngine.Bots
{
    using System.Collections.Generic;

    public class Movegenerator
    {
        PenalityManager pen = PenalityManager.Instance;

        private static Movegenerator instance;

        public static Movegenerator Instance
        {
            get
            {
                return instance ?? (instance = new Movegenerator());
            }
        }

        private Movegenerator()
        {
        }


        public List<Action> doAllChoices(Playfield p, Handmanager.Handcard hcc, bool lethalcheck, bool usePenalityManager, int tracing = 0)
        {
            int tracking = tracing;
            List<Action> returnlist = new List<Action>();
            Handmanager.Handcard hc = hcc;
            if (hc.card.type == CardDB.cardtype.MOB && p.ownMinions.Count >= 7) return returnlist;

            int max = 3;
            if (hc.card.cardIDenum == CardDB.cardIDEnum.AT_132_SHAMAN) max = 5;
            if (hc.isChoiceTemp) max = Handmanager.Instance.getNumberChoices() + 1;
            
            for (int j = 1; j < max; j++)
            {
                int i = j;
                CardDB.Card c = hc.card;
                int basemana = hc.manacost;
                if (c.cardIDenum == CardDB.cardIDEnum.AT_132_SHAMAN)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANa);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANb);
                    }
                    if (i == 3)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANc);
                    }
                    if (i == 4)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_SHAMANd);
                    }
                }

                if (c.name == CardDB.cardName.darkwispers)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_041a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_041b);
                    }
                }

                if (c.name == CardDB.cardName.keeperofthegrove)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166b);
                    }
                }

                if (c.name == CardDB.cardName.starfall)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_007b);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_007a);
                    }
                }

                if (c.name == CardDB.cardName.ancientoflore)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_008a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_008b);
                    }
                }

                if (c.name == CardDB.cardName.powerofthewild)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160b);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160a);
                    }
                }
                if (c.name == CardDB.cardName.ancientofwar)
                {

                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_178b);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_178a);
                    }
                }
                if (c.name == CardDB.cardName.druidoftheclaw)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t1);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t2);
                    }
                }
                if (c.name == CardDB.cardName.druidoftheflame)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t2);
                    }
                }
                //cenarius dont need
                if (c.name == CardDB.cardName.keeperofthegrove)//keeper of the grove
                {

                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_166b);
                    }
                }
                if (c.name == CardDB.cardName.markofnature)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_155a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_155b);
                    }
                }
                if (c.name == CardDB.cardName.nourish)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_164a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_164b);
                    }
                }
                if (c.name == CardDB.cardName.wrath)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_154a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_154b);
                    }
                }
                if (c.name == CardDB.cardName.livingroots)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_037a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_037b);
                    }
                }
                if (c.name == CardDB.cardName.druidofthesaber)
                {
                    if (i == 1)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042b);
                    }
                }

                if (hcc.isChoiceTemp)
                {
                    i = 0;//its not a druid-choice
                    tracking = j;
                    hc = Handmanager.Instance.getCardChoice(tracking - 1);
                    c = hc.card;
                    //the tracking/discover card is a druid-choice-card himself :D
                    if (c.choice)
                    {
                        //Helpfunctions.Instance.ErrorLog("choice tracking " + c.name);
                        Handmanager.Handcard hccc = Handmanager.Instance.getCardChoice(tracking - 1);
                        returnlist.AddRange(doAllChoices( p, hccc, lethalcheck, usePenalityManager, tracking));
                        continue;
                    }
                    
                    basemana = c.cost;
                }

                if (c.canplayCard(p, basemana))
                {

                    int bestplace = p.getBestPlace(c, lethalcheck);
                    List<Minion> trgts = c.getTargetsForCard(p);
                    int cardplayPenality = 0;
                    if (trgts.Count == 0)
                    {


                        if (usePenalityManager)
                        {
                            cardplayPenality = pen.getPlayCardPenality(hc, null, p, i, lethalcheck);
                            if (cardplayPenality <= 499)
                            {
                                //help.logg(hc.card.name + " is played");
                                //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, i, bestplace, cardplayPenality);
                                // i is the choice
                                Action a = new Action(actionEnum.playcard, hc, null, bestplace, null, cardplayPenality, i , tracking);
                                //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, 0, bestplace, cardplayPenality);
                                returnlist.Add(a);
                            }
                        }
                        else
                        {
                            //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, i, bestplace, cardplayPenality);

                            Action a = new Action(actionEnum.playcard, hc, null, bestplace, null, cardplayPenality, i , tracking);
                            returnlist.Add(a);
                        }

                    }
                    else
                    {
                        foreach (Minion trgt in trgts)
                        {

                            if (usePenalityManager)
                            {
                                cardplayPenality = pen.getPlayCardPenality(hc, trgt, p, i, lethalcheck);

                                if (cardplayPenality <= 499)
                                {
                                    //help.logg(hc.card.name + " is played");
                                    //pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, i, bestplace, cardplayPenality);

                                    Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, i , tracking); //i is the choice
                                    returnlist.Add(a);
                                }
                            }
                            else
                            {
                                //pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, i, bestplace, cardplayPenality);

                                Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, i , tracking); //i is the choice
                                returnlist.Add(a);
                            }

                        }
                    }

                }

            }


            return returnlist;
        }

        public List<Action> getMoveList(Playfield p, bool isLethalCheck, bool usePenalityManager, bool useCutingTargets)
        {
            //generates only own moves

            List<Action> ret = new List<Action>();

            if (p.complete || p.ownHero.Hp <= 0)
            {
                return ret;
            }

            //play cards:

            List<CardDB.cardName> playedcards = new List<CardDB.cardName>();

            bool superplacement = false;
            bool useplacement = Settings.Instance.simulatePlacement && p.turnCounter == 0 && p.ownMinions.Count >= 2;
            foreach (Minion hc in p.ownMinions)
            {
                //if direwolf or flametongue is on our side, we do calculate correct placement (if activated)
                if (hc.handcard.card.name == CardDB.cardName.direwolfalpha || hc.handcard.card.name == CardDB.cardName.flametonguetotem )
                {
                    superplacement = true;
                    break;
                }

            }

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                CardDB.Card c = hc.card;
                //help.logg("try play crd" + c.name + " " + c.getManaCost(p) + " " + c.canplayCard(p));
                if (playedcards.Contains(c.name)) continue; // dont play the same card in one loop
                playedcards.Add(c.name);

                if (c.choice || hc.isChoiceTemp)
                {
                    ret.AddRange(this.doAllChoices(p, hc, isLethalCheck, usePenalityManager));
                }
                else
                {
                    int bestplace = p.getBestPlace(c, isLethalCheck);
                    if (hc.canplayCard(p))
                    {
                        List<Minion> trgts = c.getTargetsForCard(p);

                        if (isLethalCheck && trgts.Count >= 1 && (c.damagesTarget || c.damagesTargetWithSpecial))// only target enemy hero during Lethal check!
                        {
                            if (trgts.Count >= 1 && trgts[0].isHero && !trgts[0].own) // first minion is enemy hero (or he is not in list)
                            {
                                trgts.Clear();
                                trgts.Add(p.enemyHero);
                            }
                            else
                            {
                                // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                                if (trgts.Count >= 1)
                                {
                                    Minion trg = trgts[0];
                                    trgts.Clear();
                                    trgts.Add(trg);
                                }
                            }
                        }


                        int cardplayPenality = 0;

                        if (trgts.Count == 0)
                        {


                            if (usePenalityManager)
                            {
                                cardplayPenality = pen.getPlayCardPenality(hc, null, p, 0, isLethalCheck);
                                if (cardplayPenality <= 499)
                                {

                                    if (useplacement && ((hc.card.name == CardDB.cardName.direwolfalpha || hc.card.name == CardDB.cardName.flametonguetotem || hc.card.name == CardDB.cardName.defenderofargus || hc.card.name == CardDB.cardName.voidterror) || (superplacement && hc.card.type == CardDB.cardtype.MOB)))
                                    {
                                        int adding = 1;
                                        int subbing = 0;
                                        if (hc.card.name == CardDB.cardName.direwolfalpha || hc.card.name == CardDB.cardName.flametonguetotem)//|| hc.card.name == CardDB.cardName.defenderofargus)
                                        {
                                            adding = 2;
                                            subbing = 1;
                                        }
                                        //Helpfunctions.Instance.ErrorLog(adding + " " + subbing + " " + p.ownMinions.Count);
                                        for (int placer = 0; placer < p.ownMinions.Count - subbing; placer++)
                                        {
                                            Action a = new Action(actionEnum.playcard, hc, null, placer + adding, null, cardplayPenality, 0);
                                            //Helpfunctions.Instance.ErrorLog("place " +hc.card.name + " on pos " + (placer+adding) + " mincount " + p.ownMinions.Count);
                                            //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, 0, bestplace, cardplayPenality);
                                            ret.Add(a);
                                        }
                                    }
                                    else
                                    {
                                        Action a = new Action(actionEnum.playcard, hc, null, bestplace, null, cardplayPenality, 0);
                                        //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, 0, bestplace, cardplayPenality);
                                        ret.Add(a);
                                    }
                                }
                            }
                            else
                            {
                                Action a = new Action(actionEnum.playcard, hc, null, bestplace, null, cardplayPenality, 0);
                                //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, 0, bestplace, cardplayPenality);
                                ret.Add(a);
                            }


                        }
                        else
                        {

                            foreach (Minion trgt in trgts)
                            {


                                if (usePenalityManager)
                                {
                                    cardplayPenality = pen.getPlayCardPenality(hc, trgt, p, 0, isLethalCheck);
                                    if (cardplayPenality <= 499)
                                    {
                                        //pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                                        Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, 0);
                                        ret.Add(a);

                                    }
                                }
                                else
                                {

                                    //pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, 0, bestplace, cardplayPenality);
                                    Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, 0);
                                    ret.Add(a);
                                }

                            }

                        }


                    }
                }
            }

            // attack with minions ###############################################################################################################

            List<Minion> playedMinions = new List<Minion>(8);
            bool attackordermatters = this.didAttackOrderMatters(p);
            foreach (Minion m in p.ownMinions)
            {

                if (m.Ready && m.Angr >= 1 && !m.frozen)
                {
                    //BEGIN:cut (double/similar) attacking minions out#####################################
                    // DONT LET SIMMILAR MINIONS ATTACK IN ONE TURN (example 3 unlesh the hounds-hounds doesnt need to simulated hole)
                    if (attackordermatters)
                    {
                        List<Minion> tempoo = new List<Minion>(playedMinions);
                        bool dontattacked = true;
                        bool isSpecial = m.handcard.card.isSpecialMinion;
                        foreach (Minion mnn in tempoo)
                        {
                            // special minions are allowed to attack in silended and unsilenced state!
                            //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                            bool otherisSpecial = mnn.handcard.card.isSpecialMinion;

                            if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                            {
                                if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                continue;
                            }

                            if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                            {
                                if (m.name != mnn.name) // different name -> take it
                                {
                                    continue;
                                }
                                // same name -> test whether they are equal
                                if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                continue;
                            }

                        }


                        if (dontattacked)
                        {
                            playedMinions.Add(m);
                        }
                        else
                        {
                            //help.logg(m.name + " doesnt need to attack!");
                            continue;
                        }
                    }
                    //END: cut (double/similar) attacking minions out#####################################

                    //help.logg(m.name + " is going to attack!");
                    List<Minion> trgts = p.getAttackTargets(true);
                    

                    if (isLethalCheck)// only target enemy hero during Lethal check!
                    {
                        if (trgts.Count >= 1 && trgts[0].isHero) // first minion is always hero if existent
                        {
                            trgts.Clear();
                            trgts.Add(p.enemyHero);
                        }
                        else
                        {
                            // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                            if (trgts.Count >= 1)
                            {
                                Minion trg = trgts[0];
                                trgts.Clear();
                                trgts.Add(trg);
                            }
                        }
                    }
                    else
                    {
                        if (useCutingTargets) trgts = this.cutAttackTargets(trgts, p, true);
                    }

                    foreach (Minion trgt in trgts)
                    {
                        if (!m.silenced && m.name == CardDB.cardName.icehowl && trgt.isHero)
                        {
                            continue; //this minion cant attack heros!
                        }

                        int attackPenality = 0;

                        if (usePenalityManager)
                        {
                            attackPenality = pen.getAttackWithMininonPenality(m, p, trgt, isLethalCheck);
                            if (attackPenality <= 499)
                            {
                                //pf.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);

                                Action a = new Action(actionEnum.attackWithMinion, null, m, 0, trgt, attackPenality, 0);
                                ret.Add(a);
                            }
                        }
                        else
                        {
                            //pf.attackWithMinion(m, trgt.target, trgt.targetEntity, attackPenality);
                            Action a = new Action(actionEnum.attackWithMinion, null, m, 0, trgt, attackPenality, 0);
                            ret.Add(a);

                        }


                    }
                    if ((!m.stealth || isLethalCheck) && p.enemySecretCount == 0 && trgts.Count == 1 && trgts[0].isHero)//only enemy hero is available als attack
                    {
                        break;
                    }

                    if (!attackordermatters && !m.stealth) break;
                }

            }


            // attack with hero
            if (p.ownHero.Ready && p.ownHero.Angr >= 1)
            {
                List<Minion> trgts = p.getAttackTargets(true);

                if (isLethalCheck)// only target enemy hero during Lethal check!
                {
                    if (trgts.Count >= 1 && trgts[0].isHero && !trgts[0].own)
                    {
                        trgts.Clear();
                        trgts.Add(p.enemyHero);
                    }
                    else
                    {
                        // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                        if (trgts.Count >= 1)
                        {
                            Minion trg = trgts[0];
                            trgts.Clear();
                            trgts.Add(trg);
                        }
                    }
                }
                else
                {
                    if (useCutingTargets) trgts = this.cutAttackTargets(trgts, p, true);
                }

                foreach (Minion trgt in trgts)
                {
                    int heroAttackPen = 0;
                    if (usePenalityManager)
                    {
                        heroAttackPen = pen.getAttackWithHeroPenality(trgt, p, isLethalCheck);
                    }
                    //pf.attackWithWeapon(trgt.target, trgt.targetEntity, heroAttackPen);
                    Action a = new Action(actionEnum.attackWithHero, null, p.ownHero, 0, trgt, heroAttackPen, 0);
                    ret.Add(a);

                }
            }

            // use ability
            /// TODO check if ready after manaup
            if (p.ownAbilityReady && p.ownHeroAblility.card.canplayCard(p, 2))
            {
                int abilityPenality = 0;
                // if we have mage or priest, we have to target something####################################################

                if (pen.TargetAbilitysDatabase.ContainsKey(p.ownHeroAblility.card.cardIDenum))
                {
                    List<Minion> trgts = p.ownHeroAblility.card.getTargetsForCard(p);
                    if (isLethalCheck && (p.ownHeroName == HeroEnum.mage || (p.ownHeroName == HeroEnum.priest && (p.ownHeroAblility.card.name != CardDB.cardName.lesserheal || (p.ownHeroAblility.card.name == CardDB.cardName.lesserheal && p.anzOwnAuchenaiSoulpriest >= 1)))))// only target enemy hero during Lethal check!
                    {
                        if (trgts.Count >= 1 && trgts[0].entitiyID == p.enemyHero.entitiyID)
                        {
                            trgts.Clear();
                            trgts.Add(p.enemyHero);
                        }
                        else
                        {
                            // no enemy hero -> enemy have taunts ->kill the taunts from left to right
                            if (trgts.Count >= 1)
                            {
                                Minion trg = trgts[0];
                                trgts.Clear();
                                trgts.Add(trg);
                            }
                        }
                    }

                    foreach (Minion trgt in trgts)
                    {



                        if (usePenalityManager)
                        {
                            abilityPenality = pen.getPlayCardPenality(p.ownHeroAblility, trgt, p, 0, isLethalCheck);
                            if (abilityPenality <= 499)
                            {
                                //pf.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                                Action a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, 0, trgt, abilityPenality, 0);
                                ret.Add(a);
                            }
                        }
                        else
                        {
                            //pf.activateAbility(p.ownHeroAblility, trgt.target, trgt.targetEntity, abilityPenality);
                            Action a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, 0, trgt, abilityPenality, 0);
                            ret.Add(a);
                        }

                    }
                }
                else
                {
                    // the other classes dont have to target####################################################
                    //Playfield pf = new Playfield(p);

                    if (usePenalityManager)
                    {
                        abilityPenality = pen.getPlayCardPenality(p.ownHeroAblility, null, p, 0, isLethalCheck);
                        if (abilityPenality <= 499)
                        {
                            //havedonesomething = true;
                            //pf.activateAbility(p.ownHeroAblility, -1, -1, abilityPenality);
                            Action a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, 0, null, abilityPenality, 0);
                            ret.Add(a);
                        }
                    }
                    else
                    {
                        //havedonesomething = true;
                        //pf.activateAbility(p.ownHeroAblility, -1, -1, abilityPenality);
                        Action a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, 0, null, abilityPenality, 0);
                        ret.Add(a);
                    }

                }

            }



            return ret;
        }

        //turndeep = progress of current players turn
        public List<Action> getEnemyMoveList(Playfield p, bool isLethalCheck, bool usePenalityManager, bool useCutingTargets, int turndeep)
        {
            //generates only own moves

            List<Action> ret = new List<Action>();

            if (p.complete || p.ownHero.Hp <= 0)
            {
                return ret;
            }

            //is not called, because of trundeep is allways >0 (in enemys turn) 
            //currently all enemy heropower use is handled in enemyTurnSimulator
            //if he can use ability use it on his turnstart or never!###########################################################################################
            if (turndeep == 0 && p.enemyAbilityReady && p.mana >= 2 && p.enemyHeroAblility.card.canplayCard(p, 0) && p.ownSaboteur==0)
            {
                int abilityPenality = 0;

                // if we have mage or priest, we have to target something####################################################
                if (pen.TargetAbilitysDatabase.ContainsKey(p.enemyHeroAblility.card.cardIDenum))
                {
                    List<Minion> trgts = p.enemyHeroAblility.card.getTargetsForCardEnemy(p);
                    foreach (Minion trgt in trgts)
                    {
                        if (trgt.isHero) continue;//dont target hero
                        Action a = new Action(actionEnum.useHeroPower, null, null, 0, trgt, abilityPenality, 0);
                        ret.Add(a);
                    }
                }
                else
                {
                    // the other classes dont have to target####################################################
                    Action a = new Action(actionEnum.useHeroPower, null, null, 0, null, abilityPenality, 0);
                    ret.Add(a);
                }
                return ret;
            }


            // attack with minions ###############################################################################################################

            List<Minion> playedMinions = new List<Minion>(8);
            bool attackordermatters = this.didAttackOrderMatters(p);

            foreach (Minion m in p.enemyMinions)
            {

                if (m.Ready && m.Angr >= 1 && !m.frozen)
                {
                    //BEGIN:cut (double/similar) attacking minions out#####################################
                    // DONT LET SIMMILAR MINIONS ATTACK IN ONE TURN (example 3 unlesh the hounds-hounds doesnt need to simulated hole)
                    if (attackordermatters)
                    {
                        List<Minion> tempoo = new List<Minion>(playedMinions);
                        bool dontattacked = true;
                        bool isSpecial = m.handcard.card.isSpecialMinion;
                        foreach (Minion mnn in tempoo)
                        {
                            // special minions are allowed to attack in silended and unsilenced state!
                            //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                            bool otherisSpecial = mnn.handcard.card.isSpecialMinion;

                            if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                            {
                                if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                continue;
                            }

                            if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                            {
                                if (m.name != mnn.name) // different name -> take it
                                {
                                    continue;
                                }
                                // same name -> test whether they are equal
                                if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                continue;
                            }

                        }

                        if (dontattacked)
                        {
                            playedMinions.Add(m);
                        }
                        else
                        {
                            //help.logg(m.name + " doesnt need to attack!");
                            continue;
                        }
                    }
                    //END: cut (double/similar) attacking minions out#####################################

                    //help.logg(m.name + " is going to attack!");
                    List<Minion> trgts = p.getAttackTargets(false);

                    if (useCutingTargets) trgts = this.cutAttackTargets(trgts, p, false);

                    foreach (Minion trgt in trgts)
                    {
                        if (!m.silenced && m.name == CardDB.cardName.icehowl && trgt.isHero)
                        {
                            continue; //this minion cant attack heros!
                        }

                        Action a = new Action(actionEnum.attackWithMinion, null, m, 0, trgt, this.pen.getAttackWithMininonPenality(m, p, trgt, false), 0);
                        ret.Add(a);
                    }


                    if ((!m.stealth) && trgts.Count == 1 && trgts[0].isHero)//only enemy hero is available als attack
                    {
                        break;
                    }
                    if (!attackordermatters) break;
                }


            }


            // attack with hero
            if (p.enemyHero.Ready && p.enemyHero.Angr >= 1)
            {
                List<Minion> trgts = p.getAttackTargets(false);

                if (useCutingTargets) trgts = this.cutAttackTargets(trgts, p, false);

                foreach (Minion trgt in trgts)
                {
                    //pf.attackWithWeapon(trgt.target, trgt.targetEntity, heroAttackPen);
                    Action a = new Action(actionEnum.attackWithHero, null, p.enemyHero, 0, trgt, 0, 0);
                    ret.Add(a);
                }
            }



            return ret;
        }

        public List<Minion> cutAttackTargets(List<Minion> oldlist, Playfield p, bool own)
        {
            //sorts out attack targets (minion + hero attack)
            oldlist.Sort((a, b) => -(a.Hp.CompareTo(b.Hp)));
            List<Minion> retvalues = new List<Minion>(oldlist.Count);
            List<Minion> addedmins = new List<Minion>(oldlist.Count);

            foreach (Minion m in oldlist)
            {
                if (m.isHero)
                {
                    retvalues.Add(m);
                    continue;
                }
                if (true)
                {

                    bool goingtoadd = true;
                    bool isSpecial = m.handcard.card.isSpecialMinion;
                    foreach (Minion mnn in addedmins)
                    {
                        // special minions are allowed to attack in silended and unsilenced state!
                        //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = mnn.handcard.card.isSpecialMinion;

                        if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                        {
                            if (mnn.Angr == m.Angr && mnn.Hp <= m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && m.handcard.card.isToken == mnn.handcard.card.isToken) goingtoadd = false;
                            continue;
                        }

                        if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                        {
                            if (m.name != mnn.name) // different name -> take it
                            {
                                continue;
                            }
                            // same name -> test whether they are equal
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && m.handcard.card.isToken == mnn.handcard.card.isToken) goingtoadd = false;
                            continue;
                        }

                    }

                    if (goingtoadd)
                    {
                        addedmins.Add(m);
                        retvalues.Add(m);
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

            return retvalues;
        }

        public bool didAttackOrderMatters(Playfield p)
        {
            //return true;
            if (p.isOwnTurn)
            {
                if (p.enemySecretCount >= 1) return true;
                if (p.enemyHero.immune) return true;

            }
            else
            {
                if (p.ownHero.immune) return true;
            }
            List<Minion> enemym = (p.isOwnTurn) ? p.enemyMinions : p.ownMinions;
            List<Minion> ownm = (p.isOwnTurn) ? p.ownMinions : p.enemyMinions;

            int strongestAttack = 0;
            foreach (Minion m in enemym)
            {
                if (m.Angr > strongestAttack) strongestAttack = m.Angr;
                if (m.taunt) return true;
                if (m.name == CardDB.cardName.dancingswords || m.name == CardDB.cardName.deathlord) return true;
                if (m.name == CardDB.cardName.flametonguetotem || m.name == CardDB.cardName.direwolfalpha) return true;
            }

            int haspets = 0;
            bool hashyena = false;
            bool hasJuggler = false;
            bool spawnminions = false;
            foreach (Minion m in ownm)
            {
                if (m.name == CardDB.cardName.cultmaster) return true;
                if (m.name == CardDB.cardName.knifejuggler) hasJuggler = true;
                if (m.Ready && m.Angr >= 1)
                {
                    if (m.AdjacentAngr >= 1) return true;//wolphalfa or flametongue is in play
                    if (m.name == CardDB.cardName.northshirecleric) return true;
                    if (m.name == CardDB.cardName.armorsmith) return true;
                    if (m.name == CardDB.cardName.loothoarder) return true;
                    //if (m.name == CardDB.cardName.madscientist) return true; // dont change the tactic
                    if (m.name == CardDB.cardName.sylvanaswindrunner) return true;
                    if (m.name == CardDB.cardName.darkcultist) return true;
                    if (m.ownBlessingOfWisdom >= 1) return true;
                    if (m.name == CardDB.cardName.acolyteofpain) return true;
                    if (m.name == CardDB.cardName.frothingberserker) return true;
                    if (m.name == CardDB.cardName.flesheatingghoul) return true;
                    if (m.name == CardDB.cardName.bloodmagethalnos) return true;
                    if (m.name == CardDB.cardName.webspinner) return true;
                    if (m.name == CardDB.cardName.tirionfordring) return true;
                    if (m.name == CardDB.cardName.baronrivendare) return true;


                    //if (m.name == CardDB.cardName.manawraith) return true;
                    //buffing minions (attack with them last)
                    if (m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.stormwindchampion || m.name == CardDB.cardName.timberwolf || m.name == CardDB.cardName.southseacaptain || m.name == CardDB.cardName.murlocwarleader || m.name == CardDB.cardName.grimscaleoracle || m.name == CardDB.cardName.leokk) return true;


                    if (m.name == CardDB.cardName.scavenginghyena) hashyena = true;
                    if (m.handcard.card.race == TAG_RACE.PET) haspets++;
                    if (m.name == CardDB.cardName.harvestgolem || m.name == CardDB.cardName.hauntedcreeper || m.souloftheforest >= 1 || m.ancestralspirit >= 1 || m.name == CardDB.cardName.nerubianegg || m.name == CardDB.cardName.savannahhighmane || m.name == CardDB.cardName.sludgebelcher || m.name == CardDB.cardName.cairnebloodhoof || m.name == CardDB.cardName.feugen || m.name == CardDB.cardName.stalagg || m.name == CardDB.cardName.thebeast) spawnminions = true;

                }
            }

            if (haspets >= 1 && hashyena) return true;
            if (hasJuggler && spawnminions) return true;




            return false;
        }
    }

}