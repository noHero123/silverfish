using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HREngine.Bots
{
    public class Movegenerator
    {
        PenalityManager pen = PenalityManager.Instance;

        private static Movegenerator instance;

        public static Movegenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Movegenerator();
                }
                return instance;
            }
        }

        private Movegenerator()
        {
        }


        public List<Action> doAllChoices(Playfield p, Handmanager.Handcard hc, bool lethalcheck, bool usePenalityManager)
        {
            List<Action> returnlist = new List<Action>();

            if (hc.card.type == CardDB.cardtype.MOB && p.ownMinions.Count>=7) return returnlist;

            for (int i = 1; i < 3; i++)
            {
                CardDB.Card c = hc.card;
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
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_178a);
                    }
                    if (i == 2)
                    {
                        c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_178b);
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

                if (c.canplayCard(p, hc.manacost))
                {

                    int bestplace = p.getBestPlace(c, lethalcheck);
                    List<Minion> trgts = c.getTargetsForCard(p);
                    int cardplayPenality = 0;
                    if (trgts.Count == 0)
                    {


                        if (usePenalityManager)
                        {
                            cardplayPenality = pen.getPlayCardPenality(hc.card, null, p, i, lethalcheck);
                            if (cardplayPenality <= 499)
                            {
                                //help.logg(hc.card.name + " is played");
                                //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, i, bestplace, cardplayPenality);
                                // i is the choice
                                Action a = new Action(actionEnum.playcard, hc, null, bestplace, null, cardplayPenality, i);
                                //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, 0, bestplace, cardplayPenality);
                                returnlist.Add(a);
                            }
                        }
                        else
                        {
                            //pf.playCard(hc, hc.position - 1, hc.entity, -1, -1, i, bestplace, cardplayPenality);

                            Action a = new Action(actionEnum.playcard, hc, null, bestplace, null, cardplayPenality, i);
                            returnlist.Add(a);
                        }

                    }
                    else
                    {
                        foreach (Minion trgt in trgts)
                        {

                            if (usePenalityManager)
                            {
                                cardplayPenality = pen.getPlayCardPenality(hc.card, trgt, p, 0, lethalcheck);

                                if (cardplayPenality <= 499)
                                {
                                    //help.logg(hc.card.name + " is played");
                                    //pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, i, bestplace, cardplayPenality);

                                    Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, i); //i is the choice
                                    returnlist.Add(a);
                                }
                            }
                            else
                            {
                                //pf.playCard(hc, hc.position - 1, hc.entity, trgt.target, trgt.targetEntity, i, bestplace, cardplayPenality);

                                Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, i); //i is the choice
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

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                CardDB.Card c = hc.card;
                //help.logg("try play crd" + c.name + " " + c.getManaCost(p) + " " + c.canplayCard(p));
                if (playedcards.Contains(c.name)) continue; // dont play the same card in one loop
                playedcards.Add(c.name);

                if (c.choice)
                {
                    ret.AddRange(this.doAllChoices(p, hc, isLethalCheck, usePenalityManager));
                }
                else
                {
                    int bestplace = p.getBestPlace(c, isLethalCheck);
                    if (hc.canplayCard(p))
                    {
                        List<Minion> trgts = c.getTargetsForCard(p);

                        if (isLethalCheck && trgts.Count >=1 && (pen.DamageTargetDatabase.ContainsKey(c.name) || pen.DamageTargetSpecialDatabase.ContainsKey(c.name)))// only target enemy hero during Lethal check!
                        {
                            if (trgts.Count>=1 && trgts[0].isHero && !trgts[0].own) // first minion is enemy hero (or he is not in list)
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
                                cardplayPenality = pen.getPlayCardPenality(c, null, p, 0, isLethalCheck);
                                if (cardplayPenality <= 499)
                                {
                                    Action a = new Action(actionEnum.playcard, hc, null, bestplace, null, cardplayPenality, 0);
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
                        else
                        {

                            foreach (Minion trgt in trgts)
                            {


                                if (usePenalityManager)
                                {
                                    cardplayPenality = pen.getPlayCardPenality(c, trgt, p, 0, isLethalCheck);
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

            foreach (Minion m in p.ownMinions)
            {

                if (m.Ready && m.Angr >= 1 && !m.frozen)
                {
                    //BEGIN:cut (double/similar) attacking minions out#####################################
                    // DONT LET SIMMILAR MINIONS ATTACK IN ONE TURN (example 3 unlesh the hounds-hounds doesnt need to simulated hole)
                    List<Minion> tempoo = new List<Minion>(playedMinions);
                    bool dontattacked = true;
                    bool isSpecial = pen.specialMinions.ContainsKey(m.name);
                    foreach (Minion mnn in tempoo)
                    {
                        // special minions are allowed to attack in silended and unsilenced state!
                        //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = pen.specialMinions.ContainsKey(mnn.name);

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
                }

            }


            // attack with hero
            if (p.ownHero.Ready && p.ownHero.Angr>=1)
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
            if (p.ownAbilityReady && p.mana >= 2 && p.ownHeroAblility.card.canplayCard(p, 2))
            {
                int abilityPenality = 0;
                // if we have mage or priest, we have to target something####################################################
               if (p.ownHeroAblility.card.cardIDenum == CardDB.cardIDEnum.CS2_034 || p.ownHeroAblility.card.cardIDenum == CardDB.cardIDEnum.CS1h_001 || p.ownHeroAblility.card.cardIDenum == CardDB.cardIDEnum.EX1_625t || p.ownHeroAblility.card.cardIDenum == CardDB.cardIDEnum.EX1_625t2)
               {

                    List<Minion> trgts = p.ownHeroAblility.card.getTargetsForCard(p);

                    if (isLethalCheck && (p.ownHeroName == HeroEnum.mage || (p.ownHeroName == HeroEnum.priest && (p.ownHeroAblility.card.name != CardDB.cardName.lesserheal || (p.ownHeroAblility.card.name == CardDB.cardName.lesserheal && p.anzOwnAuchenaiSoulpriest >= 1)))))// only target enemy hero during Lethal check!
                    {
                        if (trgts.Count >=1 && trgts[0].entitiyID == p.enemyHero.entitiyID)
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
                            abilityPenality = pen.getPlayCardPenality(p.ownHeroAblility.card, trgt, p, 0, isLethalCheck);
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
                        abilityPenality = pen.getPlayCardPenality(p.ownHeroAblility.card, null, p, 0, isLethalCheck);
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


            //if he can use ability use it on his turnstart or never!###########################################################################################
            if (turndeep == 0 && p.enemyAbilityReady && p.mana >= 2 && p.enemyHeroAblility.card.canplayCard(p, 0) && !p.loatheb)
            {
                int abilityPenality = 0;

                // if we have mage or priest, we have to target something####################################################
                if (p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.priest)
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

            foreach (Minion m in p.enemyMinions)
            {

                if (m.Ready && m.Angr >= 1 && !m.frozen)
                {
                    //BEGIN:cut (double/similar) attacking minions out#####################################
                    // DONT LET SIMMILAR MINIONS ATTACK IN ONE TURN (example 3 unlesh the hounds-hounds doesnt need to simulated hole)
                    List<Minion> tempoo = new List<Minion>(playedMinions);
                    bool dontattacked = true;
                    bool isSpecial = pen.specialMinions.ContainsKey(m.name);
                    foreach (Minion mnn in tempoo)
                    {
                        // special minions are allowed to attack in silended and unsilenced state!
                        //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = pen.specialMinions.ContainsKey(mnn.name);

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
                    //END: cut (double/similar) attacking minions out#####################################

                    //help.logg(m.name + " is going to attack!");
                    List<Minion> trgts = p.getAttackTargets(false);

                    if (useCutingTargets) trgts = this.cutAttackTargets(trgts, p, false);

                    foreach (Minion trgt in trgts)
                    {
                        Action a = new Action(actionEnum.attackWithMinion, null, m, 0, trgt, 0, 0);
                        ret.Add(a);
                    }

                    if ((!m.stealth) && trgts.Count == 1 && trgts[0].isHero)//only enemy hero is available als attack
                    {
                        break;
                    }
                }

            }


            // attack with hero
            if (p.enemyHero.Ready && p.enemyHero.Angr >=1)
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
                    bool isSpecial = pen.specialMinions.ContainsKey(m.name);
                    foreach (Minion mnn in addedmins)
                    {
                        // special minions are allowed to attack in silended and unsilenced state!
                        //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = pen.specialMinions.ContainsKey(mnn.name);

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

    }

}
