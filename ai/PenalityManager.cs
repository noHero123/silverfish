namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public class PenalityManager
    {
        //todo acolyteofpain
        //todo better aoe-penality

        ComboBreaker cb;

        public Dictionary<CardDB.cardIDEnum, int> TargetAbilitysDatabase = new Dictionary<CardDB.cardIDEnum, int>();
        Dictionary<CardDB.cardName, int> HealTargetDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealHeroDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealAllDatabase = new Dictionary<CardDB.cardName, int>();


        Dictionary<CardDB.cardName, int> DamageAllDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageHeroDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageRandomDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageAllEnemysDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> enrageDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> silenceDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> heroAttackBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> attackBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> healthBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> tauntBuffDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> lethalHelpers = new Dictionary<CardDB.cardName, int>();


        Dictionary<CardDB.cardName, int> backToHandDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> cardDiscardDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyOwnDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> buffingMinionsDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> buffing1TurnDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> heroDamagingAoeDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> randomEffects = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> silenceTargets = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> priorityDatabase = new Dictionary<CardDB.cardName, int>();

        public Dictionary<CardDB.cardName, int> DamageTargetDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> DamageTargetSpecialDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> cardDrawBattleCryDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> priorityTargets = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> specialMinions = new Dictionary<CardDB.cardName, int>(); //minions with cardtext, but no battlecry

        private Dictionary<CardDB.cardName, int> discoverMinions = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> strongInspireEffectMinions = new Dictionary<CardDB.cardName, int>();


        private static PenalityManager instance;

        public static PenalityManager Instance
        {
            get
            {
                return instance ?? (instance = new PenalityManager());
            }
        }

        private PenalityManager()
        {
            setupHealDatabase();
            setupEnrageDatabase();
            setupDamageDatabase();
            setupPriorityList();
            setupsilenceDatabase();
            setupAttackBuff();
            setupHealthBuff();

            setupDiscover();
            setupCardDrawBattlecry();

            setupDiscardCards();
            setupDestroyOwnCards();
            setupSpecialMins();
            setupEnemyTargetPriority();
            setupHeroDamagingAOE();
            setupBuffingMinions();
            setupRandomCards();
            setupLethalHelpMinions();
            setupSilenceTargets();
            setupTargetAbilitys();
            setupStrongInspireMinions();
            
        }

        public void setCombos()
        {
            this.cb = ComboBreaker.Instance;
        }

        public int getAttackWithMininonPenality(Minion m, Playfield p, Minion target, bool lethal)
        {
            int pen = 0;
            pen = getAttackSecretPenality(m, p, target);
            if (!lethal && target.entitiyID == p.enemyHero.entitiyID && m.destroyOnOwnTurnEnd) pen += 50;
            if (!lethal && m.name == CardDB.cardName.bloodimp) pen += 50;
            if (m.name == CardDB.cardName.leeroyjenkins)
            {
                if (!target.own)
                {
                    if (target.name == CardDB.cardName.whelp) return 500;
                }

            }

            if (!lethal && target.isHero && !target.own && m.tempAttack >= 3
                && p.playactions.Find(a => a.actionType == actionEnum.playcard && a.card.card.name == CardDB.cardName.rockbiterweapon && a.target.entitiyID == m.entitiyID) != null)
            {
                pen += 50;
            }

            if (!m.silenced && (m.name == CardDB.cardName.acolyteofpain || ((m.name == CardDB.cardName.loothoarder || m.name == CardDB.cardName.bloodmagethalnos) && !target.isHero && target.Angr >= m.Hp)))
            {
                pen += p.playactions.Count;  // penalize not utilizing the card draw as early as possible
            }

            return pen;
        }


        int enfacehp = -142;
        
        public int getAttackWithHeroPenality(Minion target, Playfield p, bool leathal)
        {
            if (enfacehp == -142) enfacehp = Settings.Instance.enfacehp;
            int retval = 0;

            if (!leathal && p.ownWeaponName == CardDB.cardName.swordofjustice)
            {
                return 28;
            }

            if (!leathal && target.entitiyID == p.enemyHero.entitiyID)
            {
                if (p.ownWeaponAttack >= 1 && p.enemyHero.Hp >= enfacehp)
                {
                    if (p.ownWeaponName == CardDB.cardName.lightsjustice && p.ownWeaponDurability >= 3) return 0;
                    if (!(p.ownHeroName == HeroEnum.thief && p.ownWeaponAttack == 1)) return 50 + p.ownWeaponAttack;
                }

                if (p.ownHero.tempAttack > 0 && p.playactions.Find(a => a.actionType == actionEnum.playcard && a.card.card.name == CardDB.cardName.rockbiterweapon && a.target.entitiyID == p.ownHero.entitiyID) != null)
                {
                    return 50;
                }

            }

            if (p.ownWeaponDurability == 1 && p.ownWeaponName == CardDB.cardName.eaglehornbow)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.arcaneshot || hc.card.name == CardDB.cardName.killcommand) return -p.ownWeaponAttack - 1;
                }
                if (p.ownSecretsIDList.Count >= 1) return 20;

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.Secret) return 20;
                }
            }

            //no penality, but a bonus, if he has weapon on hand!
            if (target.isHero && !target.own && p.ownWeaponName == CardDB.cardName.gorehowl && p.ownWeaponAttack >= 3)
            {
                return 10;
            }
            if (p.ownWeaponDurability >= 1)
            {
                bool hasweapon = false;
                foreach (Handmanager.Handcard c in p.owncards)
                {
                    if (c.card.type == CardDB.cardtype.WEAPON) hasweapon = true;
                }
                if (p.ownWeaponAttack == 1 && p.ownHeroName == HeroEnum.thief) hasweapon = true;
                if (hasweapon) retval = -p.ownWeaponAttack - 1; // so he doesnt "lose" the weapon in evaluation :D
            }
            if (p.ownWeaponAttack == 1 && p.ownHeroName == HeroEnum.thief) retval += -1;
            return retval;
        }

        public int getPlayCardPenality(Handmanager.Handcard hcard, Minion target, Playfield p, int choice, bool lethal)
        {
            int retval = 0;
            CardDB.Card card = hcard.card;
            CardDB.cardName name = card.name;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(hcard, target, p, choice, lethal);
            int tbuff = getTauntBuffPenality(hcard, target, p, choice);
            if (name == CardDB.cardName.markofthewild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
            {
                retval = 0;
            }
            else
            {
                retval += abuff + tbuff;
            }
            retval += getHPBuffPenality(card, target, p, choice);
            retval += getSilencePenality(name, target, p, choice, lethal);
            retval += getDamagePenality(name, target, p, choice, lethal);
            retval += getHealPenality(name, target, p, choice, lethal);
            //if(retval < 500) 
            retval += getCardDrawPenality(name, target, p, choice, lethal);
            retval += getCardDrawofEffectMinions(card, p);
            retval += getCardDiscardPenality(name, p);
            retval += getDestroyOwnPenality(name, target, p, lethal);

            retval += getDestroyPenality(name, target, p, lethal);
            retval += getbackToHandPenality(name, target, p, lethal);
            retval += getSpecialCardComboPenalitys(hcard, target, p, lethal, choice);
            //if (lethal) Console.WriteLine(retval+ " " + name);
            retval += getRandomPenaltiy(card, p, target);
            if (!lethal)
            {
                retval += cb.getPenalityForDestroyingCombo(card, p);
                retval += cb.getPlayValue(card.cardIDenum);
                retval += getPlayInspirePenalty(hcard, p);
                retval += getPlayMobPenalty(hcard, target, p, lethal);
                if (card.name == p.ownHeroAblility.card.name) retval += getHeroPowerPenality(hcard, target, p);
            }

            retval += playSecretPenality(card, p);
            retval += getPlayCardSecretPenality(card, p);

            retval += (int)card.pen_card.getPlayPenalty(p, hcard, target, choice, lethal);
            //Helpfunctions.Instance.ErrorLog("retval " + retval);
            return retval;
        }

        private int getAttackBuffPenality(Handmanager.Handcard playhc, Minion target, Playfield p, int choice, bool lethal)
        {
            CardDB.Card card = playhc.card;
            CardDB.cardName name = card.name;
            if (name == CardDB.cardName.darkwispers && choice != 1) return 0;

            if (!lethal && (card.name == CardDB.cardName.bolster))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.taunt) targets++;
                }
                if (targets < 2)
                {
                    return 10;
                }
            }

            if (!lethal && (card.name == CardDB.cardName.savageroar || card.name == CardDB.cardName.bloodlust))
            {
                int pen = 0;
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }

                if ((p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) && card.name == CardDB.cardName.savageroar) targets++;

                if (targets <= 3)
                {
                    pen += 20;
                }
                return pen + (5 - p.enemyMinions.Count) * 10;
            }

            if (!this.attackBuffDatabase.ContainsKey(name)) return 0;
            if (target == null)
            {
                //if ((p.ownMaxMana <= 2 && (p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.hunter)))
                //    return 10;
                if (card.type == CardDB.cardtype.MOB)
                {
                    if (card.name == CardDB.cardName.metaltoothleaper && p.ownMinions.Find(mech => mech.handcard.card.race == TAG_RACE.MECHANICAL) != null) return 0;
                    return 4 * attackBuffDatabase[name];
                }

                return 60;
            }

            if (!target.isHero && !target.own)
            {
                if (card.type == CardDB.cardtype.MOB && p.ownMinions.Count == 0) return 0;
                //allow it if you have biggamehunter
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter && target.Angr <= 6 && p.mana >= (hc.getManaCost(p) + playhc.getManaCost(p))) return 5;
                    if (hc.card.name == CardDB.cardName.shadowworddeath && target.Angr <= 4 && p.mana >= (hc.getManaCost(p) + playhc.getManaCost(p))) return 5;
                }
                if (card.name == CardDB.cardName.crueltaskmaster || card.name == CardDB.cardName.innerrage)
                {
                    Minion m = target;

                    if (m.Hp == 1)
                    {
                        return 0;
                    }

                    if (!m.wounded && (m.Angr >= 4 || m.Hp >= 5))
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute && p.mana >= (hc.getManaCost(p) + playhc.getManaCost(p))) return 0;
                        }
                    }

                    return 30;
                }
                else
                {
                    return 500;
                }
            }

            if (!target.isHero && target.own)
            {
                Minion m = target;
                bool hasownready = false;

                //vs mage or hunter we need board presence at early game? so we skip the minion ready-check.
                // for everyone else, we penalize buffing minions when they are not ready

                if (p.ownMaxMana > 2 || (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.hunter))
                {
                    if (card.name == CardDB.cardName.clockworkknight || card.name == CardDB.cardName.screwjankclunker)
                    {
                        // hasownready can only apply to mechs
                        hasownready = p.ownMinions.Find(mnn => mnn.handcard.card.race == TAG_RACE.MECHANICAL && mnn.Ready) != null;
                    }
                    else
                    {
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.Ready)
                            {
                                hasownready = true;
                                break;
                            }
                        }
                    }
                }

                if (!m.Ready && !m.taunt && hasownready)
                {
                    if (this.buffing1TurnDatabase.ContainsKey(name)) return 50;

                    return 5 * attackBuffDatabase[name];
                }
                if (m.Hp == 1 && !m.divineshild && !this.buffing1TurnDatabase.ContainsKey(name))
                {
                    if (this.healthBuffDatabase.ContainsKey(name)) return 0;  // m.Hp no longer == 1
                    if (card.type == CardDB.cardtype.MOB) return 2 * attackBuffDatabase[name] + 1;  // only 1pt worse than playing vanilla minion with same stats and no atk buff

                    return 10;
                }
                if (card.name == CardDB.cardName.blessingofmight) return 6;
            }

            if (target.own && name == CardDB.cardName.rockbiterweapon)
            {
                return 10;
            }

            return 0;
        }

        private int getHPBuffPenality(CardDB.Card card, Minion target, Playfield p, int choice)
        {
            CardDB.cardName name = card.name;
            if (name == CardDB.cardName.darkwispers && choice != 1) return 0;
            int pen = 0;
            //buff enemy?
            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
             if (target == null)
            {
                // penalize for lost buff
                if (card.type == CardDB.cardtype.MOB) return healthBuffDatabase[name];
            }

            if (target!=null && !target.own && !this.tauntBuffDatabase.ContainsKey(name))
            {
                return 500;
            }

            return 0;
        }


        private int getTauntBuffPenality(Handmanager.Handcard hcard, Minion target, Playfield p, int choice)
        {
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(hcard.card.name)) return 0;
            if (hcard.card.name == CardDB.cardName.markofnature && choice != 2) return 0;
            if (hcard.card.name == CardDB.cardName.darkwispers && choice != 1) return 0;
            if (target == null) return 20;
            if (!target.isHero && !target.own)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.theblackknight && (p.mana >= hcard.getManaCost(p) + hc.getManaCost(p))) return 0;
                }

                // allow taunting if target is priority and others have taunt
                bool enemyhasTaunts = false;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt)
                    {
                        enemyhasTaunts = true;
                        break;
                    }
                }
                if (enemyhasTaunts && this.priorityDatabase.ContainsKey(target.name) && !target.silenced && !target.taunt)
                {
                    return 0;
                }

                pen = 500;
            }

            return pen;
        }

        private int getSilencePenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            int pen = 0;
            if (name == CardDB.cardName.keeperofthegrove && choice != 2) return 0; // look at damage penality in this case

            if (target == null)
            {
                if (name == CardDB.cardName.ironbeakowl || name == CardDB.cardName.spellbreaker)
                {

                    return 40;
                }
                return 0;
            }

            if (target.own)
            {

                

                if (this.silenceDatabase.ContainsKey(name))
                {
                    if ((!target.silenced && (target.name == CardDB.cardName.wrathguard || target.name == CardDB.cardName.darnassusaspirant || target.name == CardDB.cardName.icehowl || target.name == CardDB.cardName.venturecomercenary)))
                    {
                        return 0;
                    }

                    // no pen if own is enrage
                    if ((!target.silenced && (target.name == CardDB.cardName.darnassusaspirant || target.name == CardDB.cardName.ancientwatcher || target.name == CardDB.cardName.ragnarosthefirelord || target.name == CardDB.cardName.mogortheogre || target.name == CardDB.cardName.animagolem)) || target.Angr < target.handcard.card.Attack || target.maxHp < target.handcard.card.Health || (target.frozen && !target.playedThisTurn && target.numAttacksThisTurn == 0))
                    {
                        return 0;
                    }


                    pen += 500;
                }
                
            }



            if (!target.own)
            {
                if (this.silenceDatabase.ContainsKey(name))
                {
                    // no pen if own is enrage
                    Minion m = target;//

                    if (!m.silenced && (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord))
                    {
                        return 500;
                    }

                    if ((!target.silenced && (target.name == CardDB.cardName.wrathguard || target.name == CardDB.cardName.darnassusaspirant || target.name == CardDB.cardName.icehowl)))
                    {
                        return 100;
                    }

                    if (lethal)
                    {
                        //during lethal we only silence taunt, or if its a mob (owl/spellbreaker) + we can give him charge
                        if (m.taunt || (name == CardDB.cardName.ironbeakowl && (p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) || (name == CardDB.cardName.spellbreaker && p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) return 0; // || p.ownMinions.Find(x => x.name == CardDB.cardName.warsongcommander) != null

                        return 500;
                    }

                    if (m.handcard.card.name == CardDB.cardName.dancingswords && !m.silenced)
                    {
                        return 50;
                    }

                    if (m.handcard.card.name == CardDB.cardName.venturecomercenary && !m.silenced && (m.Angr <= m.handcard.card.Attack && m.maxHp <= m.handcard.card.Health))
                    {
                        return 30;
                    }

                    if (m.handcard.card.name == CardDB.cardName.quartermaster && (p.enemyHeroAblility.card.cardIDenum != CardDB.cardIDEnum.AT_132_PALADIN && p.enemyHeroAblility.card.cardIDenum != CardDB.cardIDEnum.CS2_101))
                    {
                        return 30;
                    }

                    if (priorityDatabase.ContainsKey(m.name) && !m.silenced)
                    {
                        return 0;
                    }

                    if (this.silenceTargets.ContainsKey(m.name) && !m.silenced)
                    {
                        return 0;
                    }

                    if (m.handcard.card.deathrattle && !m.silenced)
                    {
                        return 0;
                    }

                    //silence nothing
                    //todo add "new" enchantments (good or bad ones)
                    if (m.Angr <= m.handcard.card.Attack && m.maxHp <= m.handcard.card.Health && !m.taunt && !m.windfury && !m.divineshild && !m.poisonous && !this.specialMinions.ContainsKey(name))
                    {
                        if (name == CardDB.cardName.keeperofthegrove) return 500;
                        return 30;
                    }



                    return 5;
                }
            }

            return pen;

        }

        private int getDamagePenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            int pen = 0;

            if (name == CardDB.cardName.shieldslam && p.ownHero.armor == 0) return 500;
            if (name == CardDB.cardName.savagery && p.ownHero.Angr == 0) return 500;
            if (name == CardDB.cardName.keeperofthegrove && choice != 1) return 0; // look at silence penality
            if (name == CardDB.cardName.livingroots && choice != 1) return 0; // look at silence penality

            if (this.DamageAllDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealAllDatabase.ContainsKey(name))) // aoe penality
            {

                if (p.enemyMinions.Count == 0) return 300;

                foreach (Minion m in p.enemyMinions)
                {
                    if ((m.Angr >= 4 || m.Hp >= 5) && !m.wounded)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute) return 0;
                        }
                    }
                }

                if (name == CardDB.cardName.demonwrath)
                {
                    int ownmins = 0;
                    int enemymins = 0;

                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.handcard.card.race != TAG_RACE.DEMON) ownmins++;
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.handcard.card.race != TAG_RACE.DEMON) enemymins++;
                    }

                    if (enemymins <= 1 || enemymins + 1 <= ownmins || ownmins >= 3)
                    {
                        return 30;
                    }
                }

                if (p.enemyMinions.Count <= 1 || p.enemyMinions.Count + 1 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                {
                    return 30;
                }
            }

            if (this.DamageAllEnemysDatabase.ContainsKey(name)) // aoe penality
            {
                if (p.enemyMinions.Count == 0) return 300;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((m.Angr >= 4 || m.Hp >= 5) && !m.wounded)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute) return 0;
                        }
                    }
                }

                if (name == CardDB.cardName.holynova)
                {
                    int targets = p.enemyMinions.Count;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.wounded) targets++;
                    }
                    if (targets <= 2)
                    {
                        return 20;
                    }

                }
                if (name == CardDB.cardName.darkironskulker)
                {
                    int targets = 0;
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (!m.wounded) targets++;
                    }
                    if (targets <= 2)
                    {
                        return 20;
                    }

                }
                if (p.enemyMinions.Count <= 2)
                {
                    return 20 * (3 - p.enemyMinions.Count);
                }
            }

            if (target == null) return 0;

            if (target.own && target.isHero)
            {
                if (DamageTargetDatabase.ContainsKey(name) || DamageTargetSpecialDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealTargetDatabase.ContainsKey(name)))
                {
                    pen = 500;
                }
            }

            if (!lethal && !target.own && target.isHero)
            {
                if (name == CardDB.cardName.baneofdoom)
                {
                    pen = 500;
                }
                if (name == CardDB.cardName.lavashock && p.owedRecall == 0 && p.currentRecall==0)
                {
                    pen = 30;
                }
            }

            if (target.own && !target.isHero)
            {
                if (DamageTargetDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealTargetDatabase.ContainsKey(name)))
                {
                    // no pen if own is enrage
                    Minion m = target;

                    //standard ones :D (mostly carddraw
                    if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready)
                    {
                        return 5;
                    }

                    // no pen if we have battlerage for example
                    int dmg = this.DamageTargetDatabase.ContainsKey(name) ? this.DamageTargetDatabase[name] : this.HealTargetDatabase[name];

                    if (m.name == CardDB.cardName.madscientist && p.ownHeroName == HeroEnum.hunter) return 500;
                    if (m.name == CardDB.cardName.sylvanaswindrunner) return 0;
                    if (m.handcard.card.deathrattle) return 60;
                    if (m.Hp > dmg)
                    {
                        if (m.name == CardDB.cardName.acolyteofpain && p.owncards.Count <= 3) return 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.battlerage) return pen;
                            if (hc.card.name == CardDB.cardName.rampage) return pen;
                        }
                    }


                    pen = 500;
                }

                //special cards
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    int dmg = DamageTargetSpecialDatabase[name];
                    Minion m = target;
                    if ((name == CardDB.cardName.crueltaskmaster || name == CardDB.cardName.innerrage) && m.Hp >= 2) return 0;
                    if ((name == CardDB.cardName.demonfire || name == CardDB.cardName.demonheart) && (TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0;
                    if (name == CardDB.cardName.earthshock && m.Hp >= 2)
                    {
                        if ((!m.silenced && (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord)) || m.Angr < m.handcard.card.Attack || m.maxHp < m.handcard.card.Health || (m.frozen && !m.playedThisTurn && m.numAttacksThisTurn == 0))
                            return 0;
                        if (priorityDatabase.ContainsKey(m.name) && !m.silenced)
                        {
                            return 500;
                        }
                    }
                    if (name == CardDB.cardName.earthshock)//dont silence other own minions
                    {
                        return 500;
                    }
                    if (name == CardDB.cardName.lavashock)//dont do this on own minions (you can do it on enemy hero
                    {
                        return 500;
                    }
                    // no pen if own is enrage
                    if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready)
                    {
                        return pen;
                    }

                    // no pen if we have battlerage for example

                    if (m.Hp > dmg)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.battlerage) return pen;
                            if (hc.card.name == CardDB.cardName.rampage) return pen;
                        }
                    }

                    pen = 500;
                }
            }
            if (!target.own && !target.isHero)
            {
                if (DamageTargetSpecialDatabase.ContainsKey(name) || DamageTargetDatabase.ContainsKey(name))
                {
                    Minion m = target;
                    if (name == CardDB.cardName.soulfire && m.maxHp <= 2) pen = 10;

                    if (name == CardDB.cardName.baneofdoom && m.Hp >= 3) pen = 10;

                    if (name == CardDB.cardName.shieldslam && (m.Hp <= 4 || m.Angr <= 4)) pen = 20;

                    if (name == CardDB.cardName.lavashock && p.owedRecall == 0 && p.currentRecall == 0)
                    {
                        pen = 15;
                    }
                }
            }

            return pen;
        }

        private int getHealPenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            ///Todo healpenality for aoe heal
            ///todo auchenai soulpriest
            if (p.anzOwnAuchenaiSoulpriest >= 1) return 0;
            if (name == CardDB.cardName.ancientoflore && choice != 2) return 0;
            int pen = 0;
            int heal = 0;
            /*if (HealHeroDatabase.ContainsKey(name))
            {
                heal = HealHeroDatabase[name];
                if (target == 200) pen = 500; // dont heal enemy
                if ((target == 100 || target == -1) && p.ownHeroHp + heal > 30) pen = p.ownHeroHp + heal - 30;
            }*/

            if (name == CardDB.cardName.treeoflife)
            {
                int mheal = 0;
                int wounded = 0;
                //int eheal = 0;
                if (p.ownHero.wounded) wounded++;
                foreach (Minion mi in p.ownMinions)
                {
                    mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                    if (mi.wounded) wounded++;
                }
                //Console.WriteLine(mheal + " circle");
                if (mheal == 0) return 500;
                if (mheal <= 7 && wounded <= 2) return 20;
            }

            if (name == CardDB.cardName.circleofhealing)
            {
                int mheal = 0;
                int wounded = 0;
                //int eheal = 0;
                foreach (Minion mi in p.ownMinions)
                {
                    mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                    if (mi.wounded) wounded++;
                }
                //Console.WriteLine(mheal + " circle");
                if (mheal == 0) return 500;
                if (mheal <= 7 && wounded <= 2) return 20;
            }

            if (HealTargetDatabase.ContainsKey(name) || HealHeroDatabase.ContainsKey(name))
             {
                
                if (HealHeroDatabase.ContainsKey(name))
                {
                    target = p.ownHero;
                    heal = HealHeroDatabase[name];
                }
                else
                {
                    if (target == null) return 10;
                    //Helpfunctions.Instance.ErrorLog("pencheck for " + name + " " + target.entitiyID + " " + target.isHero  + " " + target.own);
                    heal = HealTargetDatabase[name];
                }
                if (target.isHero && !target.own) return 510; // dont heal enemy
                //Helpfunctions.Instance.ErrorLog("pencheck for " + name + " " + target.entitiyID + " " + target.isHero + " " + target.own);
                if ((target.isHero && target.own) && p.ownHero.Hp == 30) return 150;
                if ((target.isHero && target.own) && p.ownHero.Hp + heal > 30) pen = p.ownHero.Hp + heal - 30;
                Minion m = new Minion();

                if (!target.isHero && target.own)
                {
                    m = target;
                    int wasted = 0;
                    if (m.Hp == m.maxHp) return 500;
                    if (m.Hp + heal - 1 > m.maxHp) wasted = m.Hp + heal - m.maxHp;
                    pen = wasted;

                    if (m.taunt && wasted <= 2 && m.Hp < m.maxHp) pen -= 5; // if we heal a taunt, its good :D

                    if (m.Hp + heal <= m.maxHp) pen = -1;
                }

                if (!target.isHero && !target.own)
                {
                    m = target;
                    if (m.Hp == m.maxHp) return 500;
                    // no penality if we heal enrage enemy
                    if (enrageDatabase.ContainsKey(m.name))
                    {
                        return pen;
                    }
                    // no penality if we have heal-trigger :D
                    int i = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.name == CardDB.cardName.northshirecleric) i++;
                        if (mnn.name == CardDB.cardName.lightwarden) i++;
                    }
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.name == CardDB.cardName.northshirecleric) i--;
                        if (mnn.name == CardDB.cardName.lightwarden) i--;
                    }
                    if (i >= 1) return pen;

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.cardName.slam && m.Hp < 2) return pen;
                        if (hc.card.name == CardDB.cardName.backstab) return pen;
                    }

                    pen = 500;
                }


            }

            return pen;
        }

        private int getCardDrawPenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            // penality if carddraw is late or you have enough cards
            int pen = 0;
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.cardName.ancientoflore && choice != 1) return 0;
            if (name == CardDB.cardName.wrath && choice != 2) return 0;
            if (name == CardDB.cardName.nourish && choice != 2) return 0;
            if (name == CardDB.cardName.grovetender && choice != 2) return 0;

            int carddraw = cardDrawBattleCryDatabase[name];
            if (name == CardDB.cardName.harrisonjones)
            {
                carddraw = p.enemyWeaponDurability;
                if (carddraw == 0 && (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.warlock && p.enemyHeroName != HeroEnum.priest)) return 5;
            }
            if (name == CardDB.cardName.divinefavor)
            {
                carddraw = p.enemyAnzCards - (p.owncards.Count);
                if (carddraw <= 0) return 500;
            }

            if (name == CardDB.cardName.battlerage)
            {
                carddraw = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.wounded) carddraw++;
                }
                if (carddraw == 0) return 500;
            }

            if (name == CardDB.cardName.slam)
            {
                Minion m = target;
                carddraw = 0;
                if (m != null && m.Hp >= 3) carddraw = 1;
                if (carddraw == 0) return 4;
            }

            if (name == CardDB.cardName.mortalcoil)
            {
                Minion m = target;
                carddraw = 0;
                if (m != null && m.Hp == 1) carddraw = 1;
                if (carddraw == 0) return 15;
            }

            if (name == CardDB.cardName.tinkertowntechnician)
            {
                carddraw = (p.ownMinions.Find(m => m.handcard.card.race == TAG_RACE.MECHANICAL) != null ? 1 : 0);
                if (carddraw == 0) return 2;
            }

            if (name == CardDB.cardName.lifetap || name == CardDB.cardName.soultap)
            {
                if (lethal) return 500; //RR no benefit for lethal check
                int minmana = 10;
                bool cardOnLimit = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.manacost <= minmana)
                    {
                        minmana = hc.manacost;
                    }
                    //if (hc.getManaCost(p) == p.ownMaxMana)
                    int manac = hc.getManaCost(p);
                    if (manac > p.ownMaxMana - 2 && manac <= p.ownMaxMana)
                    {
                        cardOnLimit = true;
                    }

                }

                if (Ai.Instance.botBase is BehaviorRush && p.ownMaxMana <= 3 && cardOnLimit) return 6; //RR penalization for drawing the 3 first turns if we have a card in hand that we won't be able to play in Rush


                if (p.owncards.Count + p.cardsPlayedThisTurn <= 5 && minmana > p.ownMaxMana) return 0;
                if (p.owncards.Count + p.cardsPlayedThisTurn > 5) return 25;
                return Math.Max(-carddraw + 2 * p.optionsPlayedThisTurn + p.ownMaxMana - p.mana, 0);
            }

            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10);
            if (p.owncards.Count + p.cardsPlayedThisTurn > 5) return (5 * carddraw) + 1;

            return -carddraw + 2 * p.optionsPlayedThisTurn + p.ownMaxMana - p.mana;
            /*pen = -carddraw + p.ownMaxMana - p.mana;
            return pen;*/
        }

        private int getCardDrawofEffectMinions(CardDB.Card card, Playfield p)
        {
            int pen = 0;
            int carddraw = 0;
            if (card.type == CardDB.cardtype.SPELL)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.gadgetzanauctioneer) carddraw++;
                }
            }

            if (card.type == CardDB.cardtype.MOB && (TAG_RACE)card.race == TAG_RACE.PET)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.starvingbuzzard) carddraw++;
                }
            }

            if (carddraw == 0) return 0;

            if (p.owncards.Count >= 5) return 0;
            pen = -carddraw + p.ownMaxMana - p.mana + p.optionsPlayedThisTurn;

            return pen;
        }

        private int getRandomPenaltiy(CardDB.Card card, Playfield p, Minion target)
        {
            int pen = 0;
            if (p.turnCounter >= 1)
            {
                return 0;
            }

            bool first = true;
            bool hasgadget = false;
            bool hasstarving = false;
            bool hasknife = false;
            bool hasflamewaker = false;
            bool hasmech = false;
            bool hadkn = false;

            

            foreach (Minion mnn in p.ownMinions)
            {

                if (mnn.handcard.card.race == TAG_RACE.MECHANICAL) hasmech = true;

                if (mnn.silenced) continue;


                if (mnn.name == CardDB.cardName.gadgetzanauctioneer)
                {
                    hasgadget = true;
                }

                if (mnn.name == CardDB.cardName.starvingbuzzard)
                {
                    hasstarving = true;
                }

                if (mnn.name == CardDB.cardName.knifejuggler)
                {
                    hasknife = true;
                }

                if (mnn.name == CardDB.cardName.flamewaker)
                {
                    hasflamewaker = true;
                }
            }

            foreach (Action a in p.playactions) // penalty for "killing" combos (like had knifejuggler, traded him in last enemy-minion and then played a minion)
            {
                if (a.actionType == actionEnum.attackWithMinion)
                {
                    if (a.own.silenced)
                        continue;
                    if (a.own.name == CardDB.cardName.gadgetzanauctioneer)
                    {
                        if (!hasgadget && card.type == CardDB.cardtype.SPELL && p.owncards.Count <= 5) pen += 10;
                    }

                    if (a.own.name == CardDB.cardName.starvingbuzzard)
                    {
                        if (!hasstarving && card.race == TAG_RACE.PET) pen += 10; 
                    }

                    if (a.own.name == CardDB.cardName.knifejuggler)
                    {
                        if (!hasknife && card.type == CardDB.cardtype.MOB) pen += 10; 
                    }

                    if (a.own.name == CardDB.cardName.flamewaker)
                    {
                        if (!hasflamewaker && card.type == CardDB.cardtype.SPELL) pen += 10; 
                    }
                }

            }

            // Don't penalize for cases that don't actually have random outcomes
            // TODO: Add Lightning Storm + Elemental Destruction if all enemies hp < the minimum damage?

            if (!this.randomEffects.ContainsKey(card.name) 
                && !this.cardDrawBattleCryDatabase.ContainsKey(card.name)
                && !(hasknife && card.type == CardDB.cardtype.MOB && p.enemyMinions.Count > 0) 
                && !(hasgadget && card.type == CardDB.cardtype.SPELL)
                && !(hasflamewaker && card.type == CardDB.cardtype.SPELL && p.enemyMinions.Count > 0)
                && !(hasstarving && (TAG_RACE)card.race == TAG_RACE.PET))
             {
                 return pen;
             }


            if (card.name == CardDB.cardName.brawl || ((card.name == CardDB.cardName.bouncingblade && p.enemyMinions.Count + p.ownMinions.Count == 1)
                || ( (card.name == CardDB.cardName.goblinblastmage || card.name == CardDB.cardName.tinkertowntechnician) && !hasmech)
                || (card.name == CardDB.cardName.coghammer && p.ownMinions.Count == 1)))
             {
                 return pen;
             }

            // Don't penalize for cases that don't actually have random outcomes
            // TODO: Add Lightning Storm + Elemental Destruction if all enemies hp < the minimum damage?

            if (p.enemyMinions.Count == 2 && (card.name == CardDB.cardName.cleave
                || card.name == CardDB.cardName.multishot
                || card.name == CardDB.cardName.forkedlightning
                || card.name == CardDB.cardName.darkbargain))
             {
                 return pen;
             }

            if (p.enemyMinions.Count == 1 && (card.name == CardDB.cardName.deadlyshot
                || card.name == CardDB.cardName.flamecannon
                || card.name == CardDB.cardName.bomblobber))
             {
                 return pen;
             }

            if (p.enemyMinions.Count == 0 && (card.name == CardDB.cardName.arcanemissiles 
                || card.name == CardDB.cardName.avengingwrath 
                || card.name == CardDB.cardName.goblinblastmage
                || card.name == CardDB.cardName.flamejuggler))
             {
                 return pen;
             }

            int cards = 0;
            cards = this.randomEffects.ContainsKey(card.name) ? this.randomEffects[card.name] : (this.cardDrawBattleCryDatabase.ContainsKey(card.name) ? this.cardDrawBattleCryDatabase[card.name] : 0);

            int mobsafterKnife = 0;
            foreach (Action a in p.playactions) // penalize for any non-random actions taken before playing this random one
            {
                if (first == false) break;
                if (a.actionType == actionEnum.attackWithHero)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.useHeroPower && (p.ownHeroName != HeroEnum.shaman && p.ownHeroName != HeroEnum.warlock))
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.attackWithMinion)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.playcard)
                {


                    if (this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name))
                    {
                        continue;
                    }

                    if (this.randomEffects.ContainsKey(a.card.card.name))
                    {
                        continue;
                    }

                    // no penalty for spells or other cards that obtain bonuses from playing spells
                    if ((hasgadget || hasflamewaker) && (a.card.card.type == CardDB.cardtype.SPELL
                        || a.card.card.name == CardDB.cardName.gadgetzanauctioneer || a.card.card.name == CardDB.cardName.flamewaker
                        || a.card.card.name == CardDB.cardName.manawyrm || a.card.card.name == CardDB.cardName.manaaddict
                        || a.card.card.name == CardDB.cardName.questingadventurer || a.card.card.name == CardDB.cardName.wildpyromancer
                        || a.card.card.name == CardDB.cardName.violetteacher || a.card.card.name == CardDB.cardName.archmageantonidas))
                     {
                         continue;
                     }

                    if (hasstarving && a.card.card.race == TAG_RACE.PET)
                    {
                        continue;
                    }


                    if (hasknife && (a.card.card.type == CardDB.cardtype.MOB || a.card.card.name == CardDB.cardName.swordofjustice || a.card.card.name == CardDB.cardName.mirrorentity)) //and others
                     {
                        if (card.name == CardDB.cardName.knifejuggler && mobsafterKnife >= 1)
                        {
                            first = false;   // penalize playing 2nd knife juggler after other mobs
                        }
                        else
                        {
                            if (a.card.card.type == CardDB.cardtype.MOB && a.card.card.name != CardDB.cardName.knifejuggler) mobsafterKnife++;
                            continue;
                        }
                     }

                    first = false;
                }
            }

            if (first == false)
            {
                pen += cards + p.playactions.Count + 1;
            }

            return pen;
        }

        private int getCardDiscardPenality(CardDB.cardName name, Playfield p)
        {
            if (p.owncards.Count <= 1) return 0;
            if (p.ownMaxMana <= 3) return 0;
            int pen = 0;
            if (this.cardDiscardDatabase.ContainsKey(name))
            {
                int newmana = p.mana - cardDiscardDatabase[name];
                bool canplayanothercard = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (this.cardDiscardDatabase.ContainsKey(hc.card.name)) continue;
                    if (hc.card.getManaCost(p, hc.manacost) <= newmana)
                    {
                        canplayanothercard = true;
                    }
                }
                if (canplayanothercard) pen += 20;

            }

            return pen;
        }

        private int getDestroyOwnPenality(CardDB.cardName name, Minion target, Playfield p, bool lethal)
        {
            if (!this.destroyOwnDatabase.ContainsKey(name)) return 0;
            int pen = 0;
            if ((name == CardDB.cardName.brawl || name == CardDB.cardName.deathwing || name == CardDB.cardName.twistingnether) && p.mobsplayedThisTurn >= 1) return 500;

            if (name == CardDB.cardName.brawl || name == CardDB.cardName.twistingnether)
            {
                if (name == CardDB.cardName.brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
                int highminion = 0;
                int veryhighminion = 0;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr >= 5 || m.Hp >= 5) highminion++;
                    if (m.Angr >= 8 || m.Hp >= 8) veryhighminion++;
                }

                if (highminion >= 2 || veryhighminion >= 1)
                {
                    return 0;
                }

                if (p.enemyMinions.Count <= 2 || p.enemyMinions.Count + 2 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                {
                    return 30;
                }
            }
            if (target == null) return 0;
            if (target.own && !target.isHero)
            {
                // dont destroy owns ;_; (except mins with deathrattle effects)

                Minion m = target;
                if (m.handcard.card.deathrattle) return 10;
                if (lethal && name == CardDB.cardName.sacrificialpact)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && mm.handcard.card.name == CardDB.cardName.lightwarden) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
                else
                {

                    return 500;
                }
            }

            return pen;
        }

        private int getDestroyPenality(CardDB.cardName name, Minion target, Playfield p, bool lethal)
        {
            if (!this.destroyDatabase.ContainsKey(name) || lethal) return 0;
            int pen = 0;
            if (target == null) return 0;
            if (target.own && !target.isHero)
            {
                // dont destroy owns ;_; (except mins with deathrattle effects)
                Minion m = target;
                if (!m.handcard.card.deathrattle)
                {
                    pen = 500;
                }
            }

            if (!target.own && !target.isHero)
            {

                // destroy others
                Minion m = target;

                /*if (m.allreadyAttacked)//doesnt make sence :D
                {
                    return 50;
                }*/

                if (name == CardDB.cardName.shadowwordpain)
                {
                    if (this.specialMinions.ContainsKey(m.name) || m.Angr == 3 || m.Hp >= 4)
                    {
                        return 0;
                    }

                    if (m.Angr == 2) return 5;

                    return 10;
                }

                

                if (m.Angr >= 4 || m.Hp >= 5)
                {
                    pen = 0; // so we dont destroy cheap ones :D
                }
                else
                {
                    pen = 30;
                }

                if ( m.name == CardDB.cardName.doomsayer )
                {
                    pen = 0;
                }

                if (name == CardDB.cardName.mindcontrol && (m.name == CardDB.cardName.direwolfalpha || m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.flametonguetotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

            }

            return pen;
        }

        private int getPlayInspirePenalty(Handmanager.Handcard playhc, Playfield p)
        {
            // Penalize for playing Inspire minions without Inspire effect

            CardDB.Card card = playhc.card;           
            CardDB.cardName name = card.name;

            if (!this.strongInspireEffectMinions.ContainsKey(name)) return 0;

            // check already used hero power
            if (p.playactions.Find(a => a.actionType == actionEnum.useHeroPower) != null)
                return 1 + (5 * strongInspireEffectMinions[name]);

            int ownplaycost = playhc.getManaCost(p);
            int heropowercost = p.ownHeroAblility.card.getManaCost(p, 2);

            // check not enough mana to gain Inspire buff
            if (p.mana < ownplaycost + heropowercost) return 2 * strongInspireEffectMinions[name];

            return 0;
        }

        private int getbackToHandPenality(CardDB.cardName name, Minion target, Playfield p, bool lethal)
        {
            if (!this.backToHandDatabase.ContainsKey(name) || lethal) return 0;
            int pen = 0;

            if (name == CardDB.cardName.vanish)
            {
                //dont vanish if we have minons on board wich are ready
                bool haveready = false;
                foreach (Minion mins in p.ownMinions)
                {
                    if (mins.Ready) haveready = true;
                }
                if (haveready) pen += 10;
            }

            if (target == null) return 0;

            if (target.own && !target.isHero)
            {
                if (p.turnCounter >= 1 && !target.handcard.card.Charge) return 500;
                // dont destroy owns ;_; (except mins with deathrattle effects, with battlecry, or to heal)
                Minion m = target;
                pen = 500;
                
                if (m.handcard.card.deathrattle || m.handcard.card.battlecry || m.handcard.card.Charge || ((m.maxHp - m.Hp) >= 4))
                {
                    pen = 0;
                }
                if (m.handcard.card.deathrattle || m.handcard.card.battlecry || m.handcard.card.Charge || ((m.maxHp - m.Hp )>=4))
                {
                    pen = 0;
                }
                if (m.shadowmadnessed)
                {
                    pen = -20;
                }

                if (m.Ready) pen += 10;
            }
            if (!target.own && !target.isHero)
            {
                
                Minion m = target;

                if (m.allreadyAttacked || m.shadowmadnessed) //dont sap shadow madness
                {
                    return 50;
                }

                if (m.name == CardDB.cardName.theblackknight)
                {
                    return 50;
                }

                if (m.Angr >= 5 || m.Hp >= 5)
                {
                    pen = 0; // so we dont destroy cheap ones :D
                }
                else
                {
                    pen = 30;
                }

                if (this.cardDrawBattleCryDatabase.ContainsKey(m.name)) pen += 10 * this.cardDrawBattleCryDatabase[m.name];

            }

            return pen;
        }

        private int getHeroPowerPenality(Handmanager.Handcard hcard, Minion target, Playfield p)
        {
            CardDB.Card card = hcard.card;
            CardDB.cardName name = card.name;

            // penalize playing hero power after spell dmg cards
            if (name == CardDB.cardName.totemiccall || name == CardDB.cardName.totemicslam)  // shaman
            {
                if (p.ownMinions.Find(m => m.name == CardDB.cardName.wrathofairtotem) != null) return 0;  // already have spelldmg totem, so no penalty

                return p.playactions.FindAll(a => a.actionType == actionEnum.playcard && a.card.card.type == CardDB.cardtype.SPELL
                    && (DamageTargetSpecialDatabase.ContainsKey(a.card.card.name) || DamageTargetDatabase.ContainsKey(a.card.card.name)
                        || a.card.card.name == CardDB.cardName.lightningstorm || a.card.card.name == CardDB.cardName.elementaldestruction)).Count;
            }

            return 0;
        }

        private int getPlayMobPenalty(Handmanager.Handcard card, Minion target, Playfield p, bool lethal)
        {
            if (card.card.type != CardDB.cardtype.MOB) return 0;
            int retval = 0;

            if (p.ownMinions.Find(m => m.name == CardDB.cardName.muklaschampion && !m.silenced) != null && p.playactions.Find(a => a.actionType == actionEnum.useHeroPower) != null)
            {
                // penalize playing minions after mukla's +1/+1 buff
                retval += 5;
            }

            int buffs =0;
            foreach (Action a in p.playactions)
            {
                if (a.card == null || a.actionType != actionEnum.playcard) continue;

                if (a.card.card.name == CardDB.cardName.everyfinisawesome) buffs++;
                if (a.card.card.name == CardDB.cardName.savageroar) buffs++;
                if (a.card.card.name == CardDB.cardName.bloodlust) buffs++;
                if (a.card.card.name == CardDB.cardName.souloftheforest) buffs++;
                if (a.card.card.name == CardDB.cardName.powerofthewild) buffs++;
                if (a.card.card.name == CardDB.cardName.cenarius) buffs++;
                if (a.card.card.name == CardDB.cardName.metaltoothleaper) buffs++;
                if (a.card.card.name == CardDB.cardName.enhanceomechano) buffs++;
                if (card.card.tank && a.card.card.name == CardDB.cardName.bolster) buffs++;

            }

            if (buffs >=1)
            {
                retval += 5*buffs;
            }

            return retval;
        }

        private int getSpecialCardComboPenalitys(Handmanager.Handcard playedhcard, Minion target, Playfield p, bool lethal, int choice)
        {
            CardDB.Card card = playedhcard.card;
            CardDB.cardName name = card.name;

            if (lethal && card.type == CardDB.cardtype.MOB)
            {
                if (this.lethalHelpers.ContainsKey(name))
                {
                    return 0;
                }

                if (this.DamageTargetDatabase.ContainsKey(name) || this.DamageAllDatabase.ContainsKey(name) )
                {
                    return 0;
                }

                if (this.buffingMinionsDatabase.ContainsKey(name))
                {
                    if (name == CardDB.cardName.timberwolf || name == CardDB.cardName.houndmaster)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && (TAG_RACE)mm.handcard.card.race == TAG_RACE.PET) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }

                    if (name == CardDB.cardName.warsongcommander)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.charge>=1) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }

                    if (name == CardDB.cardName.southseacaptain)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && (TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }
                    if (name == CardDB.cardName.murlocwarleader || name == CardDB.cardName.grimscaleoracle || name == CardDB.cardName.coldlightseer)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && (TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }

                    if (name == CardDB.cardName.warhorsetrainer)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready &&  mm.name == CardDB.cardName.silverhandrecruit) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }

                    if (name == CardDB.cardName.malganis)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && mm.handcard.card.race == TAG_RACE.DEMON) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }
                }
                else
                {
                    if (name == CardDB.cardName.theblackknight)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.enemyMinions)
                        {
                            if (mm.taunt) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }
                    else
                    {
                        if ((this.HealTargetDatabase.ContainsKey(name) || this.HealHeroDatabase.ContainsKey(name) || this.HealAllDatabase.ContainsKey(name)))
                        {
                            int beasts = 0;
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.Ready && mm.handcard.card.name == CardDB.cardName.lightwarden) beasts++;
                            }
                            if (beasts == 0) return 500;
                        }
                        else
                        {
                            //ignore that minion if it does not have charge, or we can give him charge ---> warsong was deleted ;_;
                            if (!(name == CardDB.cardName.nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || ((TAG_RACE)card.race == TAG_RACE.PET && p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null) || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null))
                            {
                                return 500;
                            }
                        }
                    }
                }
            }

            //lethal end########################################################

            //bonus for early thread
            if (p.ownMaxMana == 1 )
            {
                //if (card.name == CardDB.cardName.nerubianegg) return -10;
                if (card.name == CardDB.cardName.lepergnome) return -10;
                if (card.name == CardDB.cardName.faeriedragon) return -20;
                if (card.name == CardDB.cardName.shrinkmeister) return 0;
                if (card.Attack >= 3 && card.Health >= 2) return -20;
                if (card.name == CardDB.cardName.wildgrowth) return -150;
                
            }

            if (p.ownMaxMana == 2)
            {
                if (card.name == CardDB.cardName.nerubianegg) return -15;
            }

            /*if (card.name == CardDB.cardName.flamewaker && p.turnCounter == 0)
            {
                int number =0;
                foreach (Action a in p.playactions)
                {
                    if (a.card!=null && a.card.card.type == CardDB.cardtype.SPELL) number++;
                }
                return number * 10;
            }*/



            //if (card.name == CardDB.cardName.unstableportal && p.owncards.Count <= 9) return -15;

            if (card.name == CardDB.cardName.daggermastery)
            {
                if (p.ownWeaponAttack >= 2 || p.ownWeaponDurability >= 2) return 5;
            }

            if (card.name == CardDB.cardName.upgrade)
            {
                if (p.ownWeaponDurability == 0)
                {
                    return 16;
                }
            }

            if (card.name == CardDB.cardName.baronrivendare)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.deathlord || mnn.name == CardDB.cardName.zombiechow || mnn.name == CardDB.cardName.dancingswords) return 30;
                }
            }

            //rule for coin on early game
            if (p.ownMaxMana < 3 && card.name == CardDB.cardName.thecoin)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB && hc.canplayCard(p)) return 5;
                }

            }

            // spare parts need a base penalty so the bot does not waste them
            // TODO: move this a better location, and break reversing switch into atk buff and hp buff components
            if (name == CardDB.cardName.finickycloakfield || name == CardDB.cardName.emergencycoolant || name == CardDB.cardName.reversingswitch)
                return 20;

            if (name == CardDB.cardName.flare) 
            {
                if (p.enemyHeroName != HeroEnum.hunter && p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.pala) return 0;
                //it is a hunter/mage or pala:
                if (p.enemySecretCount == 0) return 50;
                if (p.enemySecretCount >= 1 && p.playactions.Count == 0)  return -10;
            }

            //some effects, which are bad :D
            int pen = 0;
            if (name == CardDB.cardName.houndmaster)
            {
                if (target == null) return 50;
            }

            if ((card.name == CardDB.cardName.biggamehunter) && (target == null || target.own))
            {
                return 40;
            }
            if (name == CardDB.cardName.aldorpeacekeeper && target == null)
            {
                return  30;
            }

            if (name == CardDB.cardName.sylvanaswindrunner && p.enemyMinions.Count == 0)
            {
                return 50;
            }

            if (name == CardDB.cardName.cabalshadowpriest && target == null)
            {
                return 40;
            }

            if (name == CardDB.cardName.emergencycoolant && target != null && target.own)//dont freeze own minions
            {
                return  500;
            }

            if (name == CardDB.cardName.shatteredsuncleric && target == null) { pen = 10; }
            if (name == CardDB.cardName.argentprotector)
            {
                if (target == null) { return 20; }
                else
                {
                    if (!target.own) { return 500; }
                    if (target.divineshild) { return 15; }
                    if (!target.Ready && !target.handcard.card.isSpecialMinion) { return 10; }
                    if (!target.Ready && !target.handcard.card.isSpecialMinion && target.Angr <= 2 && target.Hp <= 2) { return 15; }
                }

            }

            if (name == CardDB.cardName.facelessmanipulator)
            {
                if (target == null)
                {
                    return 50;
                }
                if (target.Angr >= 5 || target.handcard.card.cost >= 5 || (target.handcard.card.rarity == 5 && target.handcard.card.cost >= 3))
                {
                    return 0;
                }
                return 49;
            }

            if (name == CardDB.cardName.ancientofwar)
            {
                if (p.enemyMinions.Count > 0 && choice == 1) return 200;
                if (p.enemyMinions.Count == 0 && choice == 2) return 50;
            }

            if (name == CardDB.cardName.druidoftheflame)
            {

                if (p.enemyMinions.Count > 0 && choice == 2) return 40;
                if (p.enemyMinions.Count == 0 && choice == 1) return 40;

            }

            if (name == CardDB.cardName.gangup && target!=null)
            {
                if(target.handcard.card.isToken) return 20;
                if (target.handcard.card.isSpecialMinion) return -20;
                
                
            }

            if (name == CardDB.cardName.theblackknight)
            {
                if (target == null)
                {
                    return 50;
                }

                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt && (target.Angr >= 3 || target.Hp >= 3)) return 0;
                }
                return 20;
            }

            //------------------------------------------------------------------------------------------------------
            Minion m = target;

            if (card.name == CardDB.cardName.reincarnate)
            {
                if (m.own)
                {
                    if (m.handcard.card.deathrattle || m.ancestralspirit >= 1 || m.souloftheforest >= 1 || m.enemyBlessingOfWisdom >= 1 || m.explorersHat >=1) return 0;
                    if (m.handcard.card.Charge && ((m.numAttacksThisTurn == 1 && !m.windfury) || (m.numAttacksThisTurn == 2 && m.windfury))) return 0;
                    if (m.wounded || m.Angr < m.handcard.card.Attack || (m.silenced && PenalityManager.instance.specialMinions.ContainsKey(m.name))) return 0;


                    bool hasOnMinionDiesMinion = false;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.name == CardDB.cardName.scavenginghyena && m.handcard.card.race == TAG_RACE.PET) hasOnMinionDiesMinion = true;
                        if (mnn.name == CardDB.cardName.flesheatingghoul || mnn.name == CardDB.cardName.cultmaster) hasOnMinionDiesMinion = true;
                    }
                    if (hasOnMinionDiesMinion) return 0;

                    return 500;
                }
                else
                {
                    if (m.name == CardDB.cardName.nerubianegg && m.Angr <= 4 && !m.taunt) return 500;
                    if (m.taunt && !m.handcard.card.tank) return 0;
                    if (m.enemyBlessingOfWisdom >= 1) return 0;
                    if (m.Angr > m.handcard.card.Attack || m.Hp > m.handcard.card.Health) return 0;
                    if (m.name == CardDB.cardName.abomination || m.name == CardDB.cardName.zombiechow || m.name == CardDB.cardName.unstableghoul || m.name == CardDB.cardName.dancingswords) return 0;
                    return 500;

                }

            }


            if (name == CardDB.cardName.madbomber || name == CardDB.cardName.madderbomber)
            {
                //penalize for any own minions with health equal to potential attack amount
                //to lessen risk of losing your own minion
                int maxAtk = 3;
                if (name == CardDB.cardName.madderbomber) maxAtk = 6;
                if (maxAtk >= p.ownHero.Hp && maxAtk < p.enemyHero.Hp) return 500;//we could be killed, but not enemy >_< .. otherwise YOLO
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Hp <= maxAtk)
                    {
                        if (mnn.Ready) pen += 20; 
                    }
                }

                /*
                int numTargets = 2 + p.ownMinions.Count + p.enemyMinions.Count;
                int numOwnTargets = 1 + p.ownMinions.Count;
                int numEnemyTargets = numTargets-numOwnTargets;
                double dmgpertarget = ((double)maxAtk)/((double)numTargets);
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Hp <= dmgpertarget)
                    {
                        pen += 10;
                    }
                }
                */
            }



            if (name == CardDB.cardName.mechwarper)
            {
                List<Handmanager.Handcard> mechCards = p.owncards.FindAll(hc => hc != playedhcard && hc.card.race == TAG_RACE.MECHANICAL);
                mechCards.Sort((a, b) => a.getManaCost(p).CompareTo(b.getManaCost(p)));  // increasing mana cost

                int maxMechsNextTurnWithoutWarper = 0, maxMechsNextTurnWithWarper = 0;
                int manaNextTurnWithoutWarper = p.ownMaxMana + 1, manaNextTurnWithWarper = p.ownMaxMana + 1;

                for (int i = 0; i < mechCards.Count; i++)
                {
                    int cost = mechCards[i].getManaCost(p);
                    if (manaNextTurnWithoutWarper > cost)
                    {
                        maxMechsNextTurnWithoutWarper++;
                        manaNextTurnWithoutWarper -= cost;
                    }
                    if (manaNextTurnWithWarper > (cost - 1))
                    {
                        maxMechsNextTurnWithWarper++;
                        manaNextTurnWithWarper -= (cost - 1);
                    }
                }

                return -3*(maxMechsNextTurnWithWarper - maxMechsNextTurnWithoutWarper);  // +1 mana in savings per additional mech
            }

            if (name == CardDB.cardName.goblinblastmage)
            {
                bool mechOnField = false;

                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.handcard.card.race == TAG_RACE.MECHANICAL)
                    {
                        mechOnField = true;
                        break;
                    }
                }

                if (!mechOnField)  // penalize if we can play a mech this turn
                {
                    int lowestCostMechInHand = 1000;
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.race == TAG_RACE.MECHANICAL && hc.getManaCost(p) < lowestCostMechInHand) lowestCostMechInHand = hc.getManaCost(p);
                    }

                    if (p.mana >= (playedhcard.getManaCost(p) + lowestCostMechInHand)) return 50;
                    if (p.mana >= lowestCostMechInHand) return 20;

                    return 0;
                }
                else  // penalize for randomness of battlecry
                {
                    bool hasNerubianEgg = false;
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.handcard.card.name == CardDB.cardName.nerubianegg && !m.silenced && m.Hp <= 2)
                        {
                            hasNerubianEgg = true;
                            break;
                        }
                    }

                    // less minions = less randomness to penalize, but more minions = less chance to kill egg, so egg penalty is constant
                    return (hasNerubianEgg ? 10 : p.enemyMinions.Count);
                }
            }


            if (card.name == CardDB.cardName.knifejuggler && (p.mobsplayedThisTurn > 1 || ((p.ownHeroName == HeroEnum.shaman || p.ownHeroName == HeroEnum.pala) && p.ownAbilityReady == false)))
             {
                 return 20;
             }

            if (card.name == CardDB.cardName.flametonguetotem && p.ownMinions.Count == 0)
            {
                return 100;
            }

            if (card.name == CardDB.cardName.stampedingkodo)
            {
                bool found = false;
                foreach (Minion mi in p.enemyMinions)
                {
                    if (mi.Angr <= 2) found = true;
                }
                if (!found) return 20;
            }

            if (name == CardDB.cardName.windfury)
            {
                if (!m.own) return 500;
                if (m.own && !m.Ready) return 500;
            }

            if ((name == CardDB.cardName.wildgrowth || name == CardDB.cardName.nourish) && p.ownMaxMana == 9 && !(p.ownHeroName == HeroEnum.thief && p.cardsPlayedThisTurn == 0))
            {
                return 500;
            }

            if (name == CardDB.cardName.ancestralspirit)
            {
                if (!target.own && !target.isHero)
                {
                    if (m.name == CardDB.cardName.deathlord || m.name == CardDB.cardName.zombiechow || m.name == CardDB.cardName.dancingswords) return 0;
                    return 500;
                }
                if (target.own && !target.isHero)
                {
                    if (this.specialMinions.ContainsKey(m.name)) return -5;
                    return 0;
                }

            }

            if (name == CardDB.cardName.sylvanaswindrunner)
            {
                if (p.enemyMinions.Count == 0)
                {
                    return 10;
                }
            }

            if (name == CardDB.cardName.betrayal && !target.own && !target.isHero)
            {
                if (m.Angr == 0) return 30;
                if (p.enemyMinions.Count == 1) return 30;
            }




            if (name == CardDB.cardName.bite)
            {
                if ((p.ownHero.numAttacksThisTurn == 0 || (p.ownHero.windfury && p.ownHero.numAttacksThisTurn == 1)) && !p.ownHero.frozen)
                {
                    return 0;
                }
                else
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.deadlypoison)
            {
                return -p.ownWeaponDurability * 2;
            }

            if (name == CardDB.cardName.shadydealer)
            {
                bool haspirate = false;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.handcard.card.race == TAG_RACE.PIRATE)
                    {
                        haspirate = true;
                        break;
                    }
                }
                if (haspirate) return 0;
                else return 10;

            }

            if (name == CardDB.cardName.coldblood)
            {
                if (lethal) return 0;
                return 25;
            }

            if (name == CardDB.cardName.bloodmagethalnos)
            {
                return 10;
            }

            if (name == CardDB.cardName.frostbolt)
            {
                if (!target.own && !target.isHero)
                {
                    if (m.handcard.card.cost <= 2)
                        return 15;
                }
                return 8;
            }

            if (!lethal && choice == 1 && name == CardDB.cardName.druidoftheclaw)
            {
                return 20;
            }


            if (name == CardDB.cardName.poweroverwhelming)
            {
                if (target.own && !target.isHero && !m.Ready)
                {
                    if (target.name == CardDB.cardName.voidcaller) return 50;
                    if (target.name == CardDB.cardName.sylvanaswindrunner) return 100;
                    return 500;
                }
            }

            if (name == CardDB.cardName.frothingberserker)
            {
                if (p.cardsPlayedThisTurn >= 1) return  5;
            }

            if (name == CardDB.cardName.handofprotection)
            {
                if (m.Hp == 1) return 15;
            }

            if (lethal)
            {
                if (name == CardDB.cardName.corruption)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && (mm.handcard.card.name == CardDB.cardName.questingadventurer || mm.handcard.card.name == CardDB.cardName.archmageantonidas || mm.handcard.card.name == CardDB.cardName.manaaddict || mm.handcard.card.name == CardDB.cardName.manawyrm || mm.handcard.card.name == CardDB.cardName.wildpyromancer)) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
            }

            if (name == CardDB.cardName.divinespirit)
            {
                if (lethal)
                {
                    if (!target.own && !target.isHero)
                    {
                        if (!m.taunt)
                        {
                            return 500;
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && (m.Hp >= 4 || (p.owncards.Find(x => x.card.name == CardDB.cardName.divinespirit) != null && m.Hp >= 2)))
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                }
                else
                {
                    if (!target.own && !target.isHero)
                    {

                        // combo for killing with innerfire and biggamehunter
                        if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && m.Hp >= 4)
                        {
                            return 0;
                        }
                        return 500;
                    }

                }

                if (target.own && !target.isHero)
                {

                    if (m.Hp >= 4)
                    {
                        return 0;
                    }
                    return 15;
                }

            }




            if ((name == CardDB.cardName.polymorph || name == CardDB.cardName.hex))
            {



                if (target.own && !target.isHero)
                {
                    return 500;
                }

                if (!target.own && !target.isHero)
                {
                    int hexpen = 10;  // base penalty so we don't waste the spell on small minions
                    if (target.allreadyAttacked) hexpen += 30;
                    Minion frog = target;
                    if (!frog.silenced && this.priorityTargets.ContainsKey(frog.name) && this.priorityTargets[frog.name] >= 5) return hexpen;
                    if (frog.Angr >= 4 && frog.Hp >= 4) return 0;  // no base penalty because minion is not small
                    if (frog.Angr >= 4 && !frog.silenced && this.silenceTargets.ContainsKey(frog.name)) return hexpen+5;
                    return hexpen+30;

                }

            }


            if ((name == CardDB.cardName.defenderofargus || name == CardDB.cardName.sunfuryprotector) && p.ownMinions.Count == 1)
            {
                return 40;
            }
            if ((name == CardDB.cardName.defenderofargus || name == CardDB.cardName.sunfuryprotector) && p.ownMinions.Count == 0)
            {
                return 50;
            }

            if (name == CardDB.cardName.unleashthehounds)
            {
                if (p.enemyMinions.Count <= 1)
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.equality) // aoe penality
            {
                int hpdestroyed = 0;
                foreach (Minion mini in p.enemyMinions)
                {
                    hpdestroyed += (mini.Hp - 1);
                }

                if (p.enemyMinions.Count <= 2 || hpdestroyed <= 4)
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.bloodsailraider && p.ownWeaponDurability == 0)
            {
                //if you have bloodsailraider and no weapon equiped, but own a weapon:
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.WEAPON) return 10;
                }
            }



            if (name == CardDB.cardName.innerfire)
            {
                if (m.name == CardDB.cardName.lightspawn) return 500;
            }

            if (name == CardDB.cardName.huntersmark)
            {
                if (target.own && !target.isHero) return 500; // dont use on own minions
                if (!target.own && !target.isHero && (target.Hp <= 4) && target.Angr <= 4) // only use on strong minions
                {
                    return 20;
                }
            }


            if ((name == CardDB.cardName.aldorpeacekeeper || name == CardDB.cardName.humility))
            {
                if (target != null)
                {
                    if (target.own) pen = 500; // dont use on own minions
                    if (!target.own && target.Angr <= 3) // only use on strong minions
                    {
                        return 30;
                    }
                    if (m.name == CardDB.cardName.lightspawn) pen = 500;
                }
                else
                {
                    return 50;
                }
            }



            if (name == CardDB.cardName.defiasringleader && p.cardsPlayedThisTurn == 0)
            { pen = 10; }
            if (name == CardDB.cardName.bloodknight)
            {
                int shilds = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.divineshild)
                    {
                        shilds++;
                    }
                }
                foreach (Minion min in p.enemyMinions)
                {
                    if (min.divineshild)
                    {
                        shilds++;
                    }
                }
                if (shilds == 0)
                {
                    return 10;
                }
            }
            if (name == CardDB.cardName.direwolfalpha)
            {
                int ready = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.Ready)
                    { ready++; }
                }
                if (ready == 0)
                { return 5; }
            }
            if (name == CardDB.cardName.abusivesergeant)
            {
                int ready = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.Ready)
                    { ready++; }
                }
                if (ready == 0)
                {
                    return 5;
                }
            }

            if (p.turnCounter >= 1 && name == CardDB.cardName.reversingswitch && target.Angr == target.Hp) return 500;

            

            return pen;
        }

        private int playSecretPenality(CardDB.Card card, Playfield p)
        {
            //penality if we play secret and have playable kirintormage
            int pen = 0;
            if (card.Secret)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.kirintormage && p.mana >= hc.getManaCost(p))
                    {
                        pen = 500;
                    }
                }
            }

            return pen;
        }

        //not used-----------------------------------------------------------------------
        ///secret strategys pala
        /// -Attack lowest enemy. If you can’t, use noncombat means to kill it. 
        /// -attack with something able to withstand 2 damage. 
        /// -Then play something that had low health to begin with to dodge Repentance. 
        /// 
        ///secret strategys hunter
        /// - kill enemys with your minions with 2 or less heal.
        ///  - Use the smallest minion available for the first attack 
        ///  - Then smack them in the face with whatever’s left. 
        ///  - If nothing triggered until then, it’s a Snipe, so throw something in front of it that won’t die or is expendable.
        /// 
        ///secret strategys mage
        /// - Play a small minion to trigger Mirror Entity.
        /// Then attack the mage directly with the smallest minion on your side. 
        /// If nothing triggered by that point, it’s either Spellbender or Counterspell, so hold your spells until you can (and have to!) deal with either. 

        private int getPlayCardSecretPenality(CardDB.Card c, Playfield p)
        {
            int pen = 0;
            if (p.enemySecretCount == 0)
            {
                return 0;
            }


            bool hasHighHealthMinion = false;

            if (c.name == CardDB.cardName.flare || c.name == CardDB.cardName.kezanmystic)
            {
                if (p.playactions.Count >= 1) return 100;
                return 0;
            }
            else
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.flare && hc.canplayCard(p)) return 100 * p.enemySecretCount;
                    if (hc.card.name == CardDB.cardName.kezanmystic && hc.canplayCard(p)) return 50;

                    if (hc.card.type == CardDB.cardtype.MOB && hc.card.Health > 4 && hc.canplayCard(p)) hasHighHealthMinion = true;
                }
            }

            int attackedbefore = 0;
            int canattack = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1)
                {
                    attackedbefore++;
                }
                if (mnn.Ready && mnn.Angr > 0 && !mnn.frozen)
                {
                    canattack++;
                }
            }

            // only penalize for playing cards if we have better options
            if (p.enemyHeroName == HeroEnum.hunter)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    if (attackedbefore == 0 && canattack > 0) pen += 10;
                    if (c.Health <= 4 && hasHighHealthMinion) pen += 10;
                    if (c.Health <= 4 && c.deathrattle && c.name != CardDB.cardName.darnassusaspirant && c.name != CardDB.cardName.dancingswords) pen -= 5;
                }
            }

            if (p.enemyHeroName == HeroEnum.mage)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.tank,
                        name = c.name
                    };

                    // play first the small minion:
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0)
                        || (p.mobsplayedThisTurn == 0 && attackedbefore >= 1))
                    {
                        pen += 10;
                    }
                }

                // should not penalize playing spells unless 1) we know we have other options, and 2) we know it's a high value spell
                //if (c.type == CardDB.cardtype.SPELL && p.cardsPlayedThisTurn == p.mobsplayedThisTurn)
                //{
                //    pen += 10;
                //}
            }

            if (p.enemyHeroName == HeroEnum.pala)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.tank,
                        name = c.name
                    };
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0) || (attackedbefore == 0 && canattack > 0))
                    {
                        pen += 10;
                    }
                }
            }

            return pen;
        }

        private int getAttackSecretPenality(Minion m, Playfield p, Minion target)
        {
            if (p.enemySecretCount == 0)
            {
                return 0;
            }

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.name == CardDB.cardName.flare && hc.canplayCard(p)) return 100 * p.enemySecretCount;
                if (hc.card.name == CardDB.cardName.kezanmystic && hc.canplayCard(p)) return 50;
            }

            int pen = 0;

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1) attackedbefore++;
            }

            if (p.enemyHeroName == HeroEnum.hunter)
            {
                bool islow = isOwnLowest(m, p);
                if (attackedbefore == 0 && islow) pen -= 20;
                if (attackedbefore == 0 && !islow) pen += 10;

                if (target.isHero && !target.own && p.enemyMinions.Count >= 1)
                {
                    //penality if we doestn attacked before
                    if (hasMinionsWithLowHeal(p)) pen += 10; //penality if we doestn attacked minions before
                }
            }

            if (p.enemyHeroName == HeroEnum.mage)
            {
                if (p.mobsplayedThisTurn == 0) pen += 10;

                bool islow = isOwnLowest(m, p);

                if (target.isHero && !target.own && !islow)
                {
                    pen += 10;
                }
                if (target.isHero && !target.own && islow && p.mobsplayedThisTurn >= 1)
                {
                    pen -= 20;
                }

            }

            if (p.enemyHeroName == HeroEnum.pala)
            {

                bool islow = isOwnLowest(m, p);

                if (!target.own && !target.isHero && attackedbefore == 0)
                {
                    bool isEnemLow = isEnemyLowest(target, p);
                    if (!isEnemLow || m.Hp <= 2) pen += 5;
                    if (isEnemLow) pen -= 5;  // encourage attacking weakest enemy
                    if (m.Hp > 2) pen -= 5;
                }

                if (target.isHero && !target.own && !islow)
                {
                    pen += 5;
                }

                if (target.isHero && !target.own && p.enemyMinions.Count >= 1 && attackedbefore == 0)
                {
                    pen += 5;
                }

            }


            return pen;
        }






        private int getValueOfMinion(Minion m)
        {
            int ret = 0;
            ret += 2 * m.Angr + m.Hp;
            if (m.taunt) ret += 2;
            if (this.priorityDatabase.ContainsKey(m.name)) ret += 20 + priorityDatabase[m.name];
            return ret;
        }

        private bool isOwnLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            int val = getValueOfMinion(mnn);
            foreach (Minion m in p.ownMinions)
            {
                if (!m.Ready) continue;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool isOwnLowestInHand(Minion mnn, Playfield p)
        {
            bool ret = true;
            Minion m = new Minion();
            int val = getValueOfMinion(mnn);
            foreach (Handmanager.Handcard card in p.owncards)
            {
                if (card.card.type != CardDB.cardtype.MOB) continue;
                CardDB.Card c = card.card;
                m.Hp = c.Health;
                m.maxHp = c.Health;
                m.Angr = c.Attack;
                m.taunt = c.tank;
                m.name = c.name;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private int getValueOfEnemyMinion(Minion m)
        {
            int ret = 0;
            ret += m.Hp;
            if (m.taunt) ret -= 2;
            return ret;
        }

        private bool isEnemyLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            List<Minion> litt = p.getAttackTargets(true);
            int val = getValueOfEnemyMinion(mnn);
            foreach (Minion m in p.enemyMinions)
            {
                if (litt.Find(x => x.entitiyID == m.entitiyID) == null) continue;
                if (getValueOfEnemyMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool hasMinionsWithLowHeal(Playfield p)
        {
            bool ret = false;
            foreach (Minion m in p.ownMinions)
            {
                if (m.Hp <= 2 && ((m.Ready && m.Angr > 0 && !m.frozen) || this.priorityDatabase.ContainsKey(m.name))) ret = true;
            }
            return ret;
        }

        private void setupEnrageDatabase()
        {
            enrageDatabase.Add(CardDB.cardName.amaniberserker, 0);
            enrageDatabase.Add(CardDB.cardName.angrychicken, 0);
            enrageDatabase.Add(CardDB.cardName.grommashhellscream, 0);
            enrageDatabase.Add(CardDB.cardName.ragingworgen, 0);
            enrageDatabase.Add(CardDB.cardName.spitefulsmith, 0);
            enrageDatabase.Add(CardDB.cardName.taurenwarrior, 0);
            enrageDatabase.Add(CardDB.cardName.warbot, 0);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(CardDB.cardName.holynova, 2);//to all own minions
            HealAllDatabase.Add(CardDB.cardName.circleofhealing, 4);//allminions
            HealAllDatabase.Add(CardDB.cardName.darkscalehealer, 2);//all friends
            HealAllDatabase.Add(CardDB.cardName.treeoflife, 3);//all friends

            HealHeroDatabase.Add(CardDB.cardName.drainlife, 2);//tohero
            HealHeroDatabase.Add(CardDB.cardName.guardianofkings, 6);//tohero
            HealHeroDatabase.Add(CardDB.cardName.holyfire, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.priestessofelune, 4);//tohero
            HealHeroDatabase.Add(CardDB.cardName.sacrificialpact, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.siphonsoul, 3); //tohero
            HealHeroDatabase.Add(CardDB.cardName.sealoflight, 4); //tohero
            HealHeroDatabase.Add(CardDB.cardName.antiquehealbot, 8); //tohero

            HealTargetDatabase.Add(CardDB.cardName.lightofthenaaru, 3);
            HealTargetDatabase.Add(CardDB.cardName.ancestralhealing, 3);
            HealTargetDatabase.Add(CardDB.cardName.ancientsecrets, 5);
            HealTargetDatabase.Add(CardDB.cardName.holylight, 6);
            HealTargetDatabase.Add(CardDB.cardName.earthenringfarseer, 3);
            HealTargetDatabase.Add(CardDB.cardName.healingtouch, 8);
            HealTargetDatabase.Add(CardDB.cardName.layonhands, 8);
            HealTargetDatabase.Add(CardDB.cardName.lesserheal, 2);
            HealTargetDatabase.Add(CardDB.cardName.voodoodoctor, 2);
            HealTargetDatabase.Add(CardDB.cardName.willofmukla, 8);
            HealTargetDatabase.Add(CardDB.cardName.ancientoflore, 5);
            //HealTargetDatabase.Add(CardDB.cardName.divinespirit, 2);

            HealTargetDatabase.Add(CardDB.cardName.refreshmentvendor, 4);
            HealTargetDatabase.Add(CardDB.cardName.flashheal, 5);
            HealTargetDatabase.Add(CardDB.cardName.heal, 4);
            HealTargetDatabase.Add(CardDB.cardName.healingwave, 7);

        }

        private void setupDamageDatabase()
        {

            DamageHeroDatabase.Add(CardDB.cardName.headcrack, 2);
            DamageHeroDatabase.Add(CardDB.cardName.shadowbomber, 2);
            DamageHeroDatabase.Add(CardDB.cardName.ballistashot, 3);

            DamageAllDatabase.Add(CardDB.cardName.demonwrath, 2);
            DamageAllDatabase.Add(CardDB.cardName.revenge, 1);

            DamageAllDatabase.Add(CardDB.cardName.abomination, 2);
            DamageAllDatabase.Add(CardDB.cardName.dreadinfernal, 1);
            DamageAllDatabase.Add(CardDB.cardName.hellfire, 3);
            DamageAllDatabase.Add(CardDB.cardName.whirlwind, 1);
            DamageAllDatabase.Add(CardDB.cardName.yseraawakens, 5);
            DamageAllDatabase.Add(CardDB.cardName.lightbomb, 5);

            DamageAllDatabase.Add(CardDB.cardName.elementaldestruction, 4);

            DamageAllEnemysDatabase.Add(CardDB.cardName.arcaneexplosion, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.shadowflame, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.consecration, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.fanofknives, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.flamestrike, 4);
            DamageAllEnemysDatabase.Add(CardDB.cardName.holynova, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.lightningstorm, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.stomp, 1);
            
            DamageAllEnemysDatabase.Add(CardDB.cardName.swipe, 4);//1 to others
            DamageAllEnemysDatabase.Add(CardDB.cardName.bladeflurry, 1);


            DamageAllEnemysDatabase.Add(CardDB.cardName.madbomber, 1);
            DamageRandomDatabase.Add(CardDB.cardName.goblinblastmage, 1);
            DamageRandomDatabase.Add(CardDB.cardName.flamecannon, 4);
            DamageRandomDatabase.Add(CardDB.cardName.arcanemissiles, 1);
            DamageRandomDatabase.Add(CardDB.cardName.avengingwrath, 1);
            DamageRandomDatabase.Add(CardDB.cardName.cleave, 2);
            DamageRandomDatabase.Add(CardDB.cardName.forkedlightning, 2);
            DamageRandomDatabase.Add(CardDB.cardName.multishot, 3);

            DamageRandomDatabase.Add(CardDB.cardName.flamejuggler, 1);

            DamageTargetSpecialDatabase.Add(CardDB.cardName.crueltaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.cardName.innerrage, 1); // gives 2 attack


            DamageTargetSpecialDatabase.Add(CardDB.cardName.lavashock, 2); //erases overload

            DamageTargetSpecialDatabase.Add(CardDB.cardName.demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(CardDB.cardName.demonheart, 5);
            DamageTargetSpecialDatabase.Add(CardDB.cardName.earthshock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(CardDB.cardName.hammerofwrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.holywrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shieldslam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(CardDB.cardName.slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(CardDB.cardName.soulfire, 4);//delete a card


            DamageTargetDatabase.Add(CardDB.cardName.keeperofthegrove, 2); // or silence
            DamageTargetDatabase.Add(CardDB.cardName.wrath, 3);//or 1 + card

            DamageTargetDatabase.Add(CardDB.cardName.quickshot, 3);//brmcard
            DamageTargetDatabase.Add(CardDB.cardName.dragonsbreath, 4);//brmcard

            DamageTargetDatabase.Add(CardDB.cardName.steadyshot, 2);//or 1 + card
            DamageTargetDatabase.Add(CardDB.cardName.coneofcold, 1);
            DamageTargetDatabase.Add(CardDB.cardName.arcaneshot, 2);
            DamageTargetDatabase.Add(CardDB.cardName.backstab, 2);
            DamageTargetDatabase.Add(CardDB.cardName.baneofdoom, 2);
            DamageTargetDatabase.Add(CardDB.cardName.barreltoss, 2);
            DamageTargetDatabase.Add(CardDB.cardName.blizzard, 2);
            DamageTargetDatabase.Add(CardDB.cardName.drainlife, 2);
            DamageTargetDatabase.Add(CardDB.cardName.elvenarcher, 1);
            DamageTargetDatabase.Add(CardDB.cardName.eviscerate, 3);
            DamageTargetDatabase.Add(CardDB.cardName.explosiveshot, 5);
            DamageTargetDatabase.Add(CardDB.cardName.fireelemental, 3);
            DamageTargetDatabase.Add(CardDB.cardName.fireball, 6);
            DamageTargetDatabase.Add(CardDB.cardName.fireblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.frostshock, 1);
            DamageTargetDatabase.Add(CardDB.cardName.frostbolt, 1);
            DamageTargetDatabase.Add(CardDB.cardName.hoggersmash, 4);
            DamageTargetDatabase.Add(CardDB.cardName.holyfire, 5);
            DamageTargetDatabase.Add(CardDB.cardName.holysmite, 2);
            DamageTargetDatabase.Add(CardDB.cardName.icelance, 4);//only if iced
            DamageTargetDatabase.Add(CardDB.cardName.ironforgerifleman, 1);
            DamageTargetDatabase.Add(CardDB.cardName.killcommand, 3);//or 5
            DamageTargetDatabase.Add(CardDB.cardName.lavaburst, 5);
            DamageTargetDatabase.Add(CardDB.cardName.lightningbolt, 2);
            DamageTargetDatabase.Add(CardDB.cardName.mindshatter, 3);
            DamageTargetDatabase.Add(CardDB.cardName.mindspike, 2);
            DamageTargetDatabase.Add(CardDB.cardName.moonfire, 1);
            DamageTargetDatabase.Add(CardDB.cardName.mortalcoil, 1);
            DamageTargetDatabase.Add(CardDB.cardName.mortalstrike, 4);
            DamageTargetDatabase.Add(CardDB.cardName.perditionsblade, 1);
            DamageTargetDatabase.Add(CardDB.cardName.pyroblast, 10);
            DamageTargetDatabase.Add(CardDB.cardName.shadowbolt, 4);
            DamageTargetDatabase.Add(CardDB.cardName.shotgunblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.si7agent, 2);
            DamageTargetDatabase.Add(CardDB.cardName.starfall, 5);
            DamageTargetDatabase.Add(CardDB.cardName.starfire, 5);//draw a card, but its to strong
            DamageTargetDatabase.Add(CardDB.cardName.stormpikecommando, 5);

            DamageTargetDatabase.Add(CardDB.cardName.darkbomb, 3);
            DamageTargetDatabase.Add(CardDB.cardName.crackle, 3);
            DamageTargetDatabase.Add(CardDB.cardName.implosion, 2);
            DamageTargetDatabase.Add(CardDB.cardName.cobrashot, 3);
            DamageTargetDatabase.Add(CardDB.cardName.blackwingcorruptor, 3);

            DamageTargetDatabase.Add(CardDB.cardName.northseakraken, 4);
            DamageTargetDatabase.Add(CardDB.cardName.livingroots, 2);//choice 1
            DamageTargetDatabase.Add(CardDB.cardName.powershot, 2);
            DamageTargetDatabase.Add(CardDB.cardName.flamelance, 5);// i know its 8 :D
            DamageTargetDatabase.Add(CardDB.cardName.arcaneblast, 2);

            DamageTargetDatabase.Add(CardDB.cardName.undercityvaliant, 1);//combo
            DamageTargetDatabase.Add(CardDB.cardName.bash, 3);//combo
            DamageTargetDatabase.Add(CardDB.cardName.fireblastrank2, 3);//combo

            //LOE
            DamageAllDatabase.Add(CardDB.cardName.excavatedevil, 3);

            DamageTargetDatabase.Add(CardDB.cardName.forgottentorch, 3);
            DamageTargetDatabase.Add(CardDB.cardName.roaringtorch, 6);


        }

        private void setupsilenceDatabase()
        {
            this.silenceDatabase.Add(CardDB.cardName.dispel, 1);
            this.silenceDatabase.Add(CardDB.cardName.earthshock, 1);
            this.silenceDatabase.Add(CardDB.cardName.massdispel, 1);
            this.silenceDatabase.Add(CardDB.cardName.silence, 1);
            this.silenceDatabase.Add(CardDB.cardName.keeperofthegrove, 1);
            this.silenceDatabase.Add(CardDB.cardName.ironbeakowl, 1);
            this.silenceDatabase.Add(CardDB.cardName.spellbreaker, 1);
            this.silenceDatabase.Add(CardDB.cardName.lightschampion, 1);
        }

        private void setupPriorityList()
        {
            this.priorityDatabase.Add(CardDB.cardName.prophetvelen, 5);
            this.priorityDatabase.Add(CardDB.cardName.archmageantonidas, 5);
            this.priorityDatabase.Add(CardDB.cardName.flametonguetotem, 6);
            this.priorityDatabase.Add(CardDB.cardName.raidleader, 5);
            this.priorityDatabase.Add(CardDB.cardName.grimscaleoracle, 5);
            this.priorityDatabase.Add(CardDB.cardName.direwolfalpha, 6);
            this.priorityDatabase.Add(CardDB.cardName.murlocwarleader, 5);
            this.priorityDatabase.Add(CardDB.cardName.southseacaptain, 5);
            this.priorityDatabase.Add(CardDB.cardName.stormwindchampion, 5);
            this.priorityDatabase.Add(CardDB.cardName.timberwolf, 5);
            this.priorityDatabase.Add(CardDB.cardName.leokk, 5);
            this.priorityDatabase.Add(CardDB.cardName.northshirecleric, 5);
            this.priorityDatabase.Add(CardDB.cardName.sorcerersapprentice, 3);
            this.priorityDatabase.Add(CardDB.cardName.summoningportal, 5);
            this.priorityDatabase.Add(CardDB.cardName.pintsizedsummoner, 3);
            this.priorityDatabase.Add(CardDB.cardName.scavenginghyena, 5);
            this.priorityDatabase.Add(CardDB.cardName.manatidetotem, 5);
            this.priorityDatabase.Add(CardDB.cardName.emperorthaurissan, 5);
            this.priorityDatabase.Add(CardDB.cardName.wilfredfizzlebang, 5);
            this.priorityDatabase.Add(CardDB.cardName.confessorpaletress, 5);
            this.priorityDatabase.Add(CardDB.cardName.acidmaw, 5);
            this.priorityDatabase.Add(CardDB.cardName.aviana, 5);

            this.priorityDatabase.Add(CardDB.cardName.brannbronzebeard, 5);
        }

        private void setupAttackBuff()
        {
            heroAttackBuffDatabase.Add(CardDB.cardName.bite, 4);
            heroAttackBuffDatabase.Add(CardDB.cardName.claw, 2);
            heroAttackBuffDatabase.Add(CardDB.cardName.heroicstrike, 2);

            this.attackBuffDatabase.Add(CardDB.cardName.abusivesergeant, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.bananas, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.bestialwrath, 2); // NEVER ON enemy MINION
            this.attackBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            this.attackBuffDatabase.Add(CardDB.cardName.blessingofmight, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.coldblood, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.crueltaskmaster, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.darkirondwarf, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.innerrage, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.markofnature, 4);//choice1 
            this.attackBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.nightmare, 5); //destroy minion on next turn
            this.attackBuffDatabase.Add(CardDB.cardName.rampage, 3);//only damaged minion 
            this.attackBuffDatabase.Add(CardDB.cardName.uproot, 5);
            this.attackBuffDatabase.Add(CardDB.cardName.velenschosen, 2);

            this.attackBuffDatabase.Add(CardDB.cardName.rockbiterweapon, 3);

            this.attackBuffDatabase.Add(CardDB.cardName.darkwispers, 5);//choice 1
            this.attackBuffDatabase.Add(CardDB.cardName.whirlingblades, 1);

            this.attackBuffDatabase.Add(CardDB.cardName.metaltoothleaper, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.screwjankclunker, 2);

            this.attackBuffDatabase.Add(CardDB.cardName.lancecarrier, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.clockworkknight, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.demonfuse, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.sealofchampions, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.bolster, 2);

            this.attackBuffDatabase.Add(CardDB.cardName.explorershat, 1);


        }

        private void setupHealthBuff()
        {

            //this.healthBuffDatabase.Add(CardDB.cardName.ancientofwar, 5);//choice2 is only buffing himself!
            this.healthBuffDatabase.Add(CardDB.cardName.bananas, 1);
            this.healthBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            this.healthBuffDatabase.Add(CardDB.cardName.markofnature, 4);//choice2
            this.healthBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            this.healthBuffDatabase.Add(CardDB.cardName.nightmare, 5);
            this.healthBuffDatabase.Add(CardDB.cardName.powerwordshield, 2);
            this.healthBuffDatabase.Add(CardDB.cardName.rampage, 3);
            this.healthBuffDatabase.Add(CardDB.cardName.velenschosen, 4);
            this.healthBuffDatabase.Add(CardDB.cardName.darkwispers, 5);//choice1
            this.healthBuffDatabase.Add(CardDB.cardName.upgradedrepairbot, 4);
            this.healthBuffDatabase.Add(CardDB.cardName.screwjankclunker, 2);
            this.healthBuffDatabase.Add(CardDB.cardName.armorplating, 1);
            //this.healthBuffDatabase.Add(CardDB.cardName.rooted, 5);

            this.tauntBuffDatabase.Add(CardDB.cardName.markofnature, 1);
            this.tauntBuffDatabase.Add(CardDB.cardName.markofthewild, 1);
            this.tauntBuffDatabase.Add(CardDB.cardName.darkwispers, 1);
            this.tauntBuffDatabase.Add(CardDB.cardName.rustyhorn, 1);

            //this.tauntBuffDatabase.Add(CardDB.cardName.rooted, 1);

            this.healthBuffDatabase.Add(CardDB.cardName.clockworkknight, 1);
            this.healthBuffDatabase.Add(CardDB.cardName.wildwalker, 3);
            this.healthBuffDatabase.Add(CardDB.cardName.demonfuse, 3);
            this.healthBuffDatabase.Add(CardDB.cardName.bolster, 2);

            this.healthBuffDatabase.Add(CardDB.cardName.explorershat, 1);

            this.tauntBuffDatabase.Add(CardDB.cardName.sparringpartner, 1);

        }

        private void setupCardDrawBattlecry()
        {

            cardDrawBattleCryDatabase.Add(CardDB.cardName.solemnvigil, 2);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientoflore, 2);// choice =1
            cardDrawBattleCryDatabase.Add(CardDB.cardName.nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.grovetender, 1); //choice = 2

            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientteachings, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.flare, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.excessmana, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.starfire, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.azuredrake, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.coldlightoracle, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gnomishinventor, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.harrisonjones, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.noviceengineer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.arcaneintellect, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.hammerofwrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.holywrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.layonhands, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.massdispel, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.powerwordshield, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.fanofknives, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shiv, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.sprint, 4);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.farsight, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lifetap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.commandingshout, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shieldblock, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.slam, 1); //if survives
            cardDrawBattleCryDatabase.Add(CardDB.cardName.mortalcoil, 1);//only if kills
            cardDrawBattleCryDatabase.Add(CardDB.cardName.battlerage, 1);//only if wounded own minions
            cardDrawBattleCryDatabase.Add(CardDB.cardName.divinefavor, 1);//only if enemy has more cards than you

            cardDrawBattleCryDatabase.Add(CardDB.cardName.neptulon, 4);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gnomishexperimenter, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.unstableportal, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.callpet, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.grandcrusader, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.nexuschampionsaraad, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.spellslinger, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.burgle, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancestralknowledge, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.varianwrynn, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ambush, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.soultap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lockandload, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kingselekk, 1);  // only if we win joust

            cardDrawBattleCryDatabase.Add(CardDB.cardName.tinkertowntechnician, 1); // if we have a mech
            cardDrawBattleCryDatabase.Add(CardDB.cardName.toshley, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.maptothegoldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.goldenmonkey, 1); //no carddraw, but new cards



            //add discover minions
            foreach (CardDB.cardName discoverCard in this.discoverMinions.Keys)
            {
                cardDrawBattleCryDatabase.Add(discoverCard, 1);
            }
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(CardDB.cardName.doomguard, 5);
            cardDiscardDatabase.Add(CardDB.cardName.soulfire, 0);
            cardDiscardDatabase.Add(CardDB.cardName.succubus, 2);
            cardDiscardDatabase.Add(CardDB.cardName.darkbargain, 2);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(CardDB.cardName.brawl, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.deathwing, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.twistingnether, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.naturalize, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowworddeath, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowwordpain, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.siphonsoul, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.biggamehunter, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.hungrycrab, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.sacrificialpact, 0);//not own mins

            this.destroyDatabase.Add(CardDB.cardName.assassinate, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.corruption, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.execute, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.naturalize, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.siphonsoul, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.mindcontrol, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.theblackknight, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.sabotage, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.crush, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.hemetnesingwary, 0);//not own mins

            this.destroyDatabase.Add(CardDB.cardName.mulch, 0);


            this.backToHandDatabase.Add(CardDB.cardName.sap, 0);
            this.backToHandDatabase.Add(CardDB.cardName.timerewinder, 0);
            this.backToHandDatabase.Add(CardDB.cardName.ancientbrewmaster, 0);
            this.backToHandDatabase.Add(CardDB.cardName.dream, 0);
            this.backToHandDatabase.Add(CardDB.cardName.shadowstep, 0);
            this.backToHandDatabase.Add(CardDB.cardName.youthfulbrewmaster, 0);
            this.backToHandDatabase.Add(CardDB.cardName.kidnapper, 0);
            this.backToHandDatabase.Add(CardDB.cardName.recycle, 0);
            this.backToHandDatabase.Add(CardDB.cardName.vanish, 0);

        }


        private void setupHeroDamagingAOE()
        {
            this.heroDamagingAoeDatabase.Add(CardDB.cardName.unknown, 0);
        }

        private void setupSpecialMins()
        {

            //== everything with an effect (other than battlecry and normal stuff like taunt, charge, divshield)
            //also deathrattles?
            this.specialMinions.Add(CardDB.cardName.amaniberserker, 0);
            this.specialMinions.Add(CardDB.cardName.angrychicken, 0);
            this.specialMinions.Add(CardDB.cardName.abomination, 0);
            this.specialMinions.Add(CardDB.cardName.acolyteofpain, 0);
            this.specialMinions.Add(CardDB.cardName.alarmobot, 0);
            this.specialMinions.Add(CardDB.cardName.archmage, 0);
            this.specialMinions.Add(CardDB.cardName.archmageantonidas, 0);
            this.specialMinions.Add(CardDB.cardName.armorsmith, 0);
            this.specialMinions.Add(CardDB.cardName.auchenaisoulpriest, 0);
            this.specialMinions.Add(CardDB.cardName.azuredrake, 0);
            this.specialMinions.Add(CardDB.cardName.barongeddon, 0);
            this.specialMinions.Add(CardDB.cardName.bloodimp, 0);
            this.specialMinions.Add(CardDB.cardName.bloodmagethalnos, 0);
            this.specialMinions.Add(CardDB.cardName.cairnebloodhoof, 0);
            this.specialMinions.Add(CardDB.cardName.cultmaster, 0);
            this.specialMinions.Add(CardDB.cardName.dalaranmage, 0);
            this.specialMinions.Add(CardDB.cardName.demolisher, 0);
            this.specialMinions.Add(CardDB.cardName.direwolfalpha, 0);
            this.specialMinions.Add(CardDB.cardName.doomsayer, 0);
            this.specialMinions.Add(CardDB.cardName.emperorcobra, 0);
            this.specialMinions.Add(CardDB.cardName.etherealarcanist, 0);
            this.specialMinions.Add(CardDB.cardName.flametonguetotem, 0);
            this.specialMinions.Add(CardDB.cardName.flesheatingghoul, 0);
            this.specialMinions.Add(CardDB.cardName.gadgetzanauctioneer, 0);
            this.specialMinions.Add(CardDB.cardName.grimscaleoracle, 0);
            this.specialMinions.Add(CardDB.cardName.grommashhellscream, 0);
            this.specialMinions.Add(CardDB.cardName.gruul, 0);
            this.specialMinions.Add(CardDB.cardName.gurubashiberserker, 0);
            this.specialMinions.Add(CardDB.cardName.harvestgolem, 0);
            this.specialMinions.Add(CardDB.cardName.hogger, 0);
            this.specialMinions.Add(CardDB.cardName.illidanstormrage, 0);
            this.specialMinions.Add(CardDB.cardName.impmaster, 0);
            this.specialMinions.Add(CardDB.cardName.knifejuggler, 0);
            this.specialMinions.Add(CardDB.cardName.koboldgeomancer, 0);
            this.specialMinions.Add(CardDB.cardName.lepergnome, 0);
            this.specialMinions.Add(CardDB.cardName.lightspawn, 0);
            this.specialMinions.Add(CardDB.cardName.lightwarden, 0);
            this.specialMinions.Add(CardDB.cardName.lightwell, 0);
            this.specialMinions.Add(CardDB.cardName.loothoarder, 0);
            this.specialMinions.Add(CardDB.cardName.lorewalkercho, 0);
            this.specialMinions.Add(CardDB.cardName.malygos, 0);
            this.specialMinions.Add(CardDB.cardName.manaaddict, 0);
            this.specialMinions.Add(CardDB.cardName.manatidetotem, 0);
            this.specialMinions.Add(CardDB.cardName.manawraith, 0);
            this.specialMinions.Add(CardDB.cardName.manawyrm, 0);
            this.specialMinions.Add(CardDB.cardName.masterswordsmith, 0);
            this.specialMinions.Add(CardDB.cardName.murloctidecaller, 0);
            this.specialMinions.Add(CardDB.cardName.murlocwarleader, 0);
            this.specialMinions.Add(CardDB.cardName.natpagle, 0);
            this.specialMinions.Add(CardDB.cardName.northshirecleric, 0);
            this.specialMinions.Add(CardDB.cardName.ogremagi, 0);
            this.specialMinions.Add(CardDB.cardName.oldmurkeye, 0);
            this.specialMinions.Add(CardDB.cardName.patientassassin, 0);
            this.specialMinions.Add(CardDB.cardName.pintsizedsummoner, 0);
            this.specialMinions.Add(CardDB.cardName.prophetvelen, 0);
            this.specialMinions.Add(CardDB.cardName.questingadventurer, 0);
            this.specialMinions.Add(CardDB.cardName.ragingworgen, 0);
            this.specialMinions.Add(CardDB.cardName.raidleader, 0);
            this.specialMinions.Add(CardDB.cardName.savannahhighmane, 0);
            this.specialMinions.Add(CardDB.cardName.scavenginghyena, 0);
            this.specialMinions.Add(CardDB.cardName.secretkeeper, 0);
            this.specialMinions.Add(CardDB.cardName.sorcerersapprentice, 0);
            this.specialMinions.Add(CardDB.cardName.southseacaptain, 0);
            this.specialMinions.Add(CardDB.cardName.spitefulsmith, 0);
            this.specialMinions.Add(CardDB.cardName.starvingbuzzard, 0);
            this.specialMinions.Add(CardDB.cardName.stormwindchampion, 0);
            this.specialMinions.Add(CardDB.cardName.summoningportal, 0);
            this.specialMinions.Add(CardDB.cardName.sylvanaswindrunner, 0);
            this.specialMinions.Add(CardDB.cardName.taurenwarrior, 0);
            this.specialMinions.Add(CardDB.cardName.thebeast, 0);
            this.specialMinions.Add(CardDB.cardName.timberwolf, 0);
            this.specialMinions.Add(CardDB.cardName.tirionfordring, 0);
            this.specialMinions.Add(CardDB.cardName.tundrarhino, 0);
            this.specialMinions.Add(CardDB.cardName.unboundelemental, 0);
            //this.specialMinions.Add(CardDB.cardName.venturecomercenary, 0);
            this.specialMinions.Add(CardDB.cardName.violetteacher, 0);
            this.specialMinions.Add(CardDB.cardName.warsongcommander, 0);
            this.specialMinions.Add(CardDB.cardName.waterelemental, 0);

            // naxx cards
            this.specialMinions.Add(CardDB.cardName.baronrivendare, 0);
            this.specialMinions.Add(CardDB.cardName.undertaker, 0);
            this.specialMinions.Add(CardDB.cardName.dancingswords, 0);
            this.specialMinions.Add(CardDB.cardName.darkcultist, 0);
            this.specialMinions.Add(CardDB.cardName.deathlord, 0);
            this.specialMinions.Add(CardDB.cardName.feugen, 0);
            this.specialMinions.Add(CardDB.cardName.stalagg, 0);
            this.specialMinions.Add(CardDB.cardName.hauntedcreeper, 0);
            this.specialMinions.Add(CardDB.cardName.kelthuzad, 0);
            this.specialMinions.Add(CardDB.cardName.madscientist, 0);
            this.specialMinions.Add(CardDB.cardName.maexxna, 0);
            this.specialMinions.Add(CardDB.cardName.nerubarweblord, 0);
            this.specialMinions.Add(CardDB.cardName.shadeofnaxxramas, 0);
            this.specialMinions.Add(CardDB.cardName.unstableghoul, 0);
            this.specialMinions.Add(CardDB.cardName.voidcaller, 0);
            this.specialMinions.Add(CardDB.cardName.anubarambusher, 0);
            this.specialMinions.Add(CardDB.cardName.webspinner, 0);

            this.specialMinions.Add(CardDB.cardName.emperorthaurissan, 0);
            this.specialMinions.Add(CardDB.cardName.majordomoexecutus, 0);
            this.specialMinions.Add(CardDB.cardName.chromaggus, 0);
            this.specialMinions.Add(CardDB.cardName.flamewaker, 0);
            this.specialMinions.Add(CardDB.cardName.impgangboss, 0);
            this.specialMinions.Add(CardDB.cardName.axeflinger, 0);
            this.specialMinions.Add(CardDB.cardName.grimpatron, 0);
            this.specialMinions.Add(CardDB.cardName.dragonkinsorcerer, 0);
            this.specialMinions.Add(CardDB.cardName.dragonegg, 0);

            //GVG
            this.specialMinions.Add(CardDB.cardName.snowchugger, 0);
            this.specialMinions.Add(CardDB.cardName.mechwarper, 0);
            this.specialMinions.Add(CardDB.cardName.cogmaster, 0);
            this.specialMinions.Add(CardDB.cardName.mistressofpain, 0);
            this.specialMinions.Add(CardDB.cardName.felcannon, 0);
            this.specialMinions.Add(CardDB.cardName.malganis, 0);
            this.specialMinions.Add(CardDB.cardName.ironsensei, 0);
            this.specialMinions.Add(CardDB.cardName.tradeprincegallywix, 0);
            this.specialMinions.Add(CardDB.cardName.mechbearcat, 0);
            this.specialMinions.Add(CardDB.cardName.vitalitytotem, 0);
            this.specialMinions.Add(CardDB.cardName.siltfinspiritwalker, 0);
            this.specialMinions.Add(CardDB.cardName.gahzrilla, 0);
            this.specialMinions.Add(CardDB.cardName.warbot, 0);
            this.specialMinions.Add(CardDB.cardName.cobaltguardian, 0);
            this.specialMinions.Add(CardDB.cardName.stonesplintertrogg, 0);
            this.specialMinions.Add(CardDB.cardName.burlyrockjawtrogg, 0);
            this.specialMinions.Add(CardDB.cardName.shadowboxer, 0);
            this.specialMinions.Add(CardDB.cardName.shipscannon, 0);
            this.specialMinions.Add(CardDB.cardName.steamwheedlesniper, 0);
            this.specialMinions.Add(CardDB.cardName.jeeves, 0);
            this.specialMinions.Add(CardDB.cardName.goblinsapper, 0);
            this.specialMinions.Add(CardDB.cardName.floatingwatcher, 0);
            this.specialMinions.Add(CardDB.cardName.micromachine, 0);
            this.specialMinions.Add(CardDB.cardName.hobgoblin, 0);
            this.specialMinions.Add(CardDB.cardName.junkbot, 0);
            this.specialMinions.Add(CardDB.cardName.mimironshead, 0);
            this.specialMinions.Add(CardDB.cardName.mogortheogre, 0);
            this.specialMinions.Add(CardDB.cardName.foereaper4000, 0);
            this.specialMinions.Add(CardDB.cardName.mekgineerthermaplugg, 0);
            this.specialMinions.Add(CardDB.cardName.gazlowe, 0);
            this.specialMinions.Add(CardDB.cardName.troggzortheearthinator, 0);
            this.specialMinions.Add(CardDB.cardName.clockworkgnome, 0);
            this.specialMinions.Add(CardDB.cardName.explosivesheep, 0);
            this.specialMinions.Add(CardDB.cardName.mechanicalyeti, 0);
            this.specialMinions.Add(CardDB.cardName.pilotedshredder, 0);
            this.specialMinions.Add(CardDB.cardName.pilotedskygolem, 0);
            this.specialMinions.Add(CardDB.cardName.malorne, 0);
            this.specialMinions.Add(CardDB.cardName.sneedsoldshredder, 0);
            this.specialMinions.Add(CardDB.cardName.toshley, 0);

            //TGT
            this.specialMinions.Add(CardDB.cardName.lowlysquire, 0);
            this.specialMinions.Add(CardDB.cardName.boneguardlieutenant, 0);
            this.specialMinions.Add(CardDB.cardName.dragonhawkrider, 0);
            this.specialMinions.Add(CardDB.cardName.silverhandregent, 0);
            this.specialMinions.Add(CardDB.cardName.maidenofthelake, 0);
            this.specialMinions.Add(CardDB.cardName.tournamentmedic, 0);
            this.specialMinions.Add(CardDB.cardName.kvaldirraider, 0);
            this.specialMinions.Add(CardDB.cardName.muklaschampion, 0);
            this.specialMinions.Add(CardDB.cardName.garrisoncommander, 0);
            this.specialMinions.Add(CardDB.cardName.crowdfavorite, 0);
            this.specialMinions.Add(CardDB.cardName.recruiter, 0);
            this.specialMinions.Add(CardDB.cardName.kodorider, 0);
            this.specialMinions.Add(CardDB.cardName.eydisdarkbane, 0);
            this.specialMinions.Add(CardDB.cardName.fjolalightbane, 0);
            this.specialMinions.Add(CardDB.cardName.nexuschampionsaraad, 0);
            this.specialMinions.Add(CardDB.cardName.bolframshield, 0);

            this.specialMinions.Add(CardDB.cardName.savagecombatant, 0);
            this.specialMinions.Add(CardDB.cardName.knightofthewild, 0);
            this.specialMinions.Add(CardDB.cardName.aviana, 0);
            this.specialMinions.Add(CardDB.cardName.bravearcher, 0);
            this.specialMinions.Add(CardDB.cardName.dreadscale, 0);
            this.specialMinions.Add(CardDB.cardName.acidmaw, 0);
            this.specialMinions.Add(CardDB.cardName.dalaranaspirant, 0);
            this.specialMinions.Add(CardDB.cardName.fallenhero, 0);
            this.specialMinions.Add(CardDB.cardName.coldarradrake, 0);
            this.specialMinions.Add(CardDB.cardName.warhorsetrainer, 0);
            this.specialMinions.Add(CardDB.cardName.murlocknight, 0);
            this.specialMinions.Add(CardDB.cardName.holychampion, 0);
            this.specialMinions.Add(CardDB.cardName.spawnofshadows, 0);
            this.specialMinions.Add(CardDB.cardName.shadowfiend, 0);
            this.specialMinions.Add(CardDB.cardName.confessorpaletress, 0);
            this.specialMinions.Add(CardDB.cardName.buccaneer, 0);
            this.specialMinions.Add(CardDB.cardName.cutpurse, 0);
            this.specialMinions.Add(CardDB.cardName.thunderbluffvaliant, 0);
            this.specialMinions.Add(CardDB.cardName.wrathguard, 0);
            this.specialMinions.Add(CardDB.cardName.tinyknightofevil, 0);
            this.specialMinions.Add(CardDB.cardName.voidcrusher, 0);
            this.specialMinions.Add(CardDB.cardName.wilfredfizzlebang, 0);
            this.specialMinions.Add(CardDB.cardName.orgrimmaraspirant, 0);
            this.specialMinions.Add(CardDB.cardName.magnatauralpha, 0);

            //LOE (week 1 and 2 :D)
            this.specialMinions.Add(CardDB.cardName.obsidiandestroyer, 0);
            this.specialMinions.Add(CardDB.cardName.djinniofzephyrs, 0);
            this.specialMinions.Add(CardDB.cardName.summoningstone, 0);
            this.specialMinions.Add(CardDB.cardName.rumblingelemental, 0);
            this.specialMinions.Add(CardDB.cardName.tunneltrogg, 0);
            this.specialMinions.Add(CardDB.cardName.brannbronzebeard, 0);



        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.captaingreenskin, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.cenarius, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.coldlightseer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.crueltaskmaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.darkirondwarf, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.defenderofargus, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.direwolfalpha, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.flametonguetotem, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.grimscaleoracle, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.houndmaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.leokk, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.murlocwarleader, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.raidleader, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.shatteredsuncleric, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.southseacaptain, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.spitefulsmith, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.stormwindchampion, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.templeenforcer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.timberwolf, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.malganis, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.warsongcommander, 0);

            buffing1TurnDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.darkirondwarf, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.rockbiterweapon, 0);

            buffingMinionsDatabase.Add(CardDB.cardName.metaltoothleaper, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.quartermaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.screwjankclunker, 0);

            buffingMinionsDatabase.Add(CardDB.cardName.lancecarrier, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.clockworkknight, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.wildwalker, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.warhorsetrainer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.thunderbluffvaliant, 0);


        }

        private void setupEnemyTargetPriority()
        {
            //priorityTargets.Add(CardDB.cardName.angrychicken, 1);  // minion canot be enraged until hp is buffed, so generally not a priority
            priorityTargets.Add(CardDB.cardName.lightwarden, 4);
            priorityTargets.Add(CardDB.cardName.secretkeeper, 3);
            priorityTargets.Add(CardDB.cardName.youngdragonhawk, 4);
            priorityTargets.Add(CardDB.cardName.bloodmagethalnos, 3);
            priorityTargets.Add(CardDB.cardName.direwolfalpha, 4);
            priorityTargets.Add(CardDB.cardName.doomsayer, 10);
            priorityTargets.Add(CardDB.cardName.knifejuggler, 4);
            priorityTargets.Add(CardDB.cardName.koboldgeomancer, 3);
            priorityTargets.Add(CardDB.cardName.manaaddict, 4);
            priorityTargets.Add(CardDB.cardName.masterswordsmith, 2);
            priorityTargets.Add(CardDB.cardName.natpagle, 10);
            priorityTargets.Add(CardDB.cardName.murloctidehunter, 4);
            priorityTargets.Add(CardDB.cardName.pintsizedsummoner, 10);
            priorityTargets.Add(CardDB.cardName.wildpyromancer, 4);
            priorityTargets.Add(CardDB.cardName.alarmobot, 10);
            priorityTargets.Add(CardDB.cardName.acolyteofpain, 10);
            priorityTargets.Add(CardDB.cardName.demolisher, 4);
            priorityTargets.Add(CardDB.cardName.flesheatingghoul, 5);
            priorityTargets.Add(CardDB.cardName.impmaster, 3);
            priorityTargets.Add(CardDB.cardName.questingadventurer, 6);
            priorityTargets.Add(CardDB.cardName.raidleader, 6);
            priorityTargets.Add(CardDB.cardName.thrallmarfarseer, 10);
            priorityTargets.Add(CardDB.cardName.cultmaster, 10);
            //priorityTargets.Add(CardDB.cardName.leeroyjenkins, 10);  // charge already used when on the field, no need for additional penalty
            priorityTargets.Add(CardDB.cardName.violetteacher, 6);
            priorityTargets.Add(CardDB.cardName.gadgetzanauctioneer, 10);
            priorityTargets.Add(CardDB.cardName.hogger, 10);
            priorityTargets.Add(CardDB.cardName.illidanstormrage, 10);
            priorityTargets.Add(CardDB.cardName.barongeddon, 10);
            priorityTargets.Add(CardDB.cardName.stormwindchampion, 10);
            priorityTargets.Add(CardDB.cardName.gurubashiberserker, 10);

            //warrior cards
            priorityTargets.Add(CardDB.cardName.frothingberserker, 10);
            priorityTargets.Add(CardDB.cardName.warsongcommander, 10);

            //warlock cards
            priorityTargets.Add(CardDB.cardName.summoningportal, 10);

            //shaman cards
            priorityTargets.Add(CardDB.cardName.dustdevil, 10);
            priorityTargets.Add(CardDB.cardName.wrathofairtotem, 2);
            priorityTargets.Add(CardDB.cardName.flametonguetotem, 10);
            priorityTargets.Add(CardDB.cardName.manatidetotem, 10);
            priorityTargets.Add(CardDB.cardName.unboundelemental, 5);

            //rogue cards

            //priest cards
            priorityTargets.Add(CardDB.cardName.northshirecleric, 10);
            priorityTargets.Add(CardDB.cardName.lightwell, 10);
            priorityTargets.Add(CardDB.cardName.auchenaisoulpriest, 5);
            priorityTargets.Add(CardDB.cardName.prophetvelen, 10);

            //paladin cards

            //mage cards
            priorityTargets.Add(CardDB.cardName.manawyrm, 4);
            priorityTargets.Add(CardDB.cardName.sorcerersapprentice, 10);
            priorityTargets.Add(CardDB.cardName.etherealarcanist, 6);
            priorityTargets.Add(CardDB.cardName.archmageantonidas, 10);

            //hunter cards
            priorityTargets.Add(CardDB.cardName.timberwolf, 4);
            priorityTargets.Add(CardDB.cardName.scavenginghyena, 10);
            priorityTargets.Add(CardDB.cardName.starvingbuzzard, 10);
            priorityTargets.Add(CardDB.cardName.leokk, 10);
            priorityTargets.Add(CardDB.cardName.tundrarhino, 10);

            //naxx cards
            priorityTargets.Add(CardDB.cardName.baronrivendare, 5);
            priorityTargets.Add(CardDB.cardName.kelthuzad, 10);
            priorityTargets.Add(CardDB.cardName.nerubarweblord, 10);
            priorityTargets.Add(CardDB.cardName.shadeofnaxxramas, 10);
            priorityTargets.Add(CardDB.cardName.undertaker, 4);



            //GVG
            this.priorityTargets.Add(CardDB.cardName.ironsensei, 6);
            this.priorityTargets.Add(CardDB.cardName.mechwarper, 4);
            this.priorityTargets.Add(CardDB.cardName.malganis, 10);
            this.priorityTargets.Add(CardDB.cardName.vitalitytotem, 4);
            this.priorityTargets.Add(CardDB.cardName.gahzrilla, 10);
            this.priorityTargets.Add(CardDB.cardName.steamwheedlesniper, 5);
            this.priorityTargets.Add(CardDB.cardName.floatingwatcher, 6);
            this.priorityTargets.Add(CardDB.cardName.micromachine, 4);
            this.priorityTargets.Add(CardDB.cardName.hobgoblin, 5);
            this.priorityTargets.Add(CardDB.cardName.mogortheogre, 10);
            this.priorityTargets.Add(CardDB.cardName.foereaper4000, 10);
            this.priorityTargets.Add(CardDB.cardName.troggzortheearthinator, 10);
            
            //BRM
            this.priorityTargets.Add(CardDB.cardName.flamewaker, 5);
            this.priorityTargets.Add(CardDB.cardName.impgangboss, 5);
            this.priorityTargets.Add(CardDB.cardName.grimpatron, 10);
            this.priorityTargets.Add(CardDB.cardName.dragonkinsorcerer, 4);
            this.priorityTargets.Add(CardDB.cardName.emperorthaurissan, 10);
            this.priorityTargets.Add(CardDB.cardName.chromaggus, 10);

            //TGT
            this.priorityTargets.Add(CardDB.cardName.muklaschampion, 10);
            this.priorityTargets.Add(CardDB.cardName.kodorider, 5);
            this.priorityTargets.Add(CardDB.cardName.eydisdarkbane, 5);
            this.priorityTargets.Add(CardDB.cardName.nexuschampionsaraad, 5);
            this.priorityTargets.Add(CardDB.cardName.savagecombatant, 5);
            this.priorityTargets.Add(CardDB.cardName.aviana, 10);
            this.priorityTargets.Add(CardDB.cardName.acidmaw, 5);

            this.priorityTargets.Add(CardDB.cardName.coldarradrake, 5);
            this.priorityTargets.Add(CardDB.cardName.warhorsetrainer, 5);
            this.priorityTargets.Add(CardDB.cardName.murlocknight, 10);
            this.priorityTargets.Add(CardDB.cardName.holychampion, 5);
            this.priorityTargets.Add(CardDB.cardName.wilfredfizzlebang, 10);

            //LOE

            this.priorityTargets.Add(CardDB.cardName.brannbronzebeard, 10);
            this.priorityTargets.Add(CardDB.cardName.obsidiandestroyer, 10);
            this.priorityTargets.Add(CardDB.cardName.summoningstone, 10);
            this.priorityTargets.Add(CardDB.cardName.djinniofzephyrs, 5);
            this.priorityTargets.Add(CardDB.cardName.rumblingelemental, 5);
            this.priorityTargets.Add(CardDB.cardName.animatedarmor, 5);


        }

        private void setupLethalHelpMinions()
        {
            lethalHelpers.Add(CardDB.cardName.auchenaisoulpriest, 0);
            //spellpower minions
            lethalHelpers.Add(CardDB.cardName.archmage, 0);
            lethalHelpers.Add(CardDB.cardName.dalaranmage, 0);
            lethalHelpers.Add(CardDB.cardName.koboldgeomancer, 0);
            lethalHelpers.Add(CardDB.cardName.ogremagi, 0);
            lethalHelpers.Add(CardDB.cardName.ancientmage, 0);
            lethalHelpers.Add(CardDB.cardName.azuredrake, 0);
            lethalHelpers.Add(CardDB.cardName.bloodmagethalnos, 0);
            lethalHelpers.Add(CardDB.cardName.malygos, 0);
            lethalHelpers.Add(CardDB.cardName.velenschosen, 0);
            lethalHelpers.Add(CardDB.cardName.sootspewer, 0);
            lethalHelpers.Add(CardDB.cardName.minimage, 0);

            lethalHelpers.Add(CardDB.cardName.varianwrynn, 0);
            lethalHelpers.Add(CardDB.cardName.bravearcher, 0);
            lethalHelpers.Add(CardDB.cardName.acidmaw, 0);
            lethalHelpers.Add(CardDB.cardName.coldarradrake, 0);
            lethalHelpers.Add(CardDB.cardName.polymorphboar, 0);
            //

        }

        private void setupSilenceTargets()
        {
            this.silenceTargets.Add(CardDB.cardName.abomination, 0);
            this.silenceTargets.Add(CardDB.cardName.acolyteofpain, 0);
            this.silenceTargets.Add(CardDB.cardName.archmageantonidas, 0);
            this.silenceTargets.Add(CardDB.cardName.armorsmith, 0);
            this.silenceTargets.Add(CardDB.cardName.auchenaisoulpriest, 0);
            this.silenceTargets.Add(CardDB.cardName.barongeddon, 0);
            //this.silenceTargets.Add(CardDB.cardName.bloodimp, 0);
            this.silenceTargets.Add(CardDB.cardName.cairnebloodhoof, 0);
            this.silenceTargets.Add(CardDB.cardName.cultmaster, 0);
            this.silenceTargets.Add(CardDB.cardName.direwolfalpha, 0);
            this.silenceTargets.Add(CardDB.cardName.doomsayer, 0);
            this.silenceTargets.Add(CardDB.cardName.emperorcobra, 0);
            this.silenceTargets.Add(CardDB.cardName.etherealarcanist, 0);
            this.silenceTargets.Add(CardDB.cardName.flametonguetotem, 0);
            this.silenceTargets.Add(CardDB.cardName.gadgetzanauctioneer, 10);
            this.silenceTargets.Add(CardDB.cardName.grommashhellscream, 0);

            this.silenceTargets.Add(CardDB.cardName.gruul, 0);
            this.silenceTargets.Add(CardDB.cardName.gurubashiberserker, 0);
            this.silenceTargets.Add(CardDB.cardName.hogger, 0);

            this.silenceTargets.Add(CardDB.cardName.illidanstormrage, 0);
            this.silenceTargets.Add(CardDB.cardName.impmaster, 0);

            this.silenceTargets.Add(CardDB.cardName.knifejuggler, 0);
            this.silenceTargets.Add(CardDB.cardName.lightspawn, 0);
            this.silenceTargets.Add(CardDB.cardName.lightwarden, 0);
            this.silenceTargets.Add(CardDB.cardName.lightwell, 0);
            this.silenceTargets.Add(CardDB.cardName.lorewalkercho, 0);

            this.silenceTargets.Add(CardDB.cardName.malygos, 0);

            this.silenceTargets.Add(CardDB.cardName.manatidetotem, 0);
            this.silenceTargets.Add(CardDB.cardName.manawraith, 0);
            this.silenceTargets.Add(CardDB.cardName.manawyrm, 0);
            this.silenceTargets.Add(CardDB.cardName.masterswordsmith, 0);

            this.silenceTargets.Add(CardDB.cardName.murloctidecaller, 0);
            this.silenceTargets.Add(CardDB.cardName.murlocwarleader, 0);
            this.silenceTargets.Add(CardDB.cardName.natpagle, 0);
            this.silenceTargets.Add(CardDB.cardName.northshirecleric, 0);

            this.silenceTargets.Add(CardDB.cardName.oldmurkeye, 0);
            this.silenceTargets.Add(CardDB.cardName.prophetvelen, 0);
            this.silenceTargets.Add(CardDB.cardName.questingadventurer, 0);
            this.silenceTargets.Add(CardDB.cardName.raidleader, 0);

            this.silenceTargets.Add(CardDB.cardName.savannahhighmane, 0);
            this.silenceTargets.Add(CardDB.cardName.scavenginghyena, 0);
            this.silenceTargets.Add(CardDB.cardName.sorcerersapprentice, 0);
            this.silenceTargets.Add(CardDB.cardName.southseacaptain, 0);
            this.silenceTargets.Add(CardDB.cardName.spitefulsmith, 0);
            this.silenceTargets.Add(CardDB.cardName.starvingbuzzard, 0);
            this.silenceTargets.Add(CardDB.cardName.stormwindchampion, 0);
            this.silenceTargets.Add(CardDB.cardName.summoningportal, 0);
            this.silenceTargets.Add(CardDB.cardName.sylvanaswindrunner, 0);
            this.silenceTargets.Add(CardDB.cardName.timberwolf, 0);
            this.silenceTargets.Add(CardDB.cardName.tirionfordring, 0);
            this.silenceTargets.Add(CardDB.cardName.tundrarhino, 0);
            //this.specialMinions.Add(CardDB.cardName.unboundelemental, 0);
            //this.specialMinions.Add(CardDB.cardName.venturecomercenary, 0);
            this.silenceTargets.Add(CardDB.cardName.violetteacher, 0);
            this.silenceTargets.Add(CardDB.cardName.warsongcommander, 0);
            //this.specialMinions.Add(CardDB.cardName.waterelemental, 0);

            // naxx cards
            this.silenceTargets.Add(CardDB.cardName.baronrivendare, 0);
            this.silenceTargets.Add(CardDB.cardName.undertaker, 0);
            this.silenceTargets.Add(CardDB.cardName.darkcultist, 0);
            this.silenceTargets.Add(CardDB.cardName.feugen, 0);
            this.silenceTargets.Add(CardDB.cardName.stalagg, 0);
            this.silenceTargets.Add(CardDB.cardName.hauntedcreeper, 0);
            this.silenceTargets.Add(CardDB.cardName.kelthuzad, 10);
            this.silenceTargets.Add(CardDB.cardName.madscientist, 0);
            this.silenceTargets.Add(CardDB.cardName.maexxna, 0);
            this.silenceTargets.Add(CardDB.cardName.nerubarweblord, 0);
            this.silenceTargets.Add(CardDB.cardName.shadeofnaxxramas, 0);

            this.silenceTargets.Add(CardDB.cardName.webspinner, 0);
            this.silenceTargets.Add(CardDB.cardName.ironsensei, 0);
            this.silenceTargets.Add(CardDB.cardName.vitalitytotem, 0);


            this.silenceTargets.Add(CardDB.cardName.malganis, 0);
            this.silenceTargets.Add(CardDB.cardName.malorne, 0);
            this.silenceTargets.Add(CardDB.cardName.gahzrilla, 0);
            this.silenceTargets.Add(CardDB.cardName.bolvarfordragon, 0);
            this.silenceTargets.Add(CardDB.cardName.mogortheogre, 0);
            this.silenceTargets.Add(CardDB.cardName.stonesplintertrogg, 0);
            this.silenceTargets.Add(CardDB.cardName.burlyrockjawtrogg, 0);
            this.silenceTargets.Add(CardDB.cardName.shadowboxer, 0);
            this.silenceTargets.Add(CardDB.cardName.explosivesheep, 0);
            this.silenceTargets.Add(CardDB.cardName.animagolem, 0);
            this.silenceTargets.Add(CardDB.cardName.siegeengine, 0);
            this.silenceTargets.Add(CardDB.cardName.steamwheedlesniper, 0);
            this.silenceTargets.Add(CardDB.cardName.floatingwatcher, 0);
            this.silenceTargets.Add(CardDB.cardName.micromachine, 0);
            this.silenceTargets.Add(CardDB.cardName.hobgoblin, 0);
            this.silenceTargets.Add(CardDB.cardName.pilotedskygolem, 0);
            this.silenceTargets.Add(CardDB.cardName.junkbot, 0);
            this.silenceTargets.Add(CardDB.cardName.v07tr0n, 0);
            this.silenceTargets.Add(CardDB.cardName.foereaper4000, 0);
            this.silenceTargets.Add(CardDB.cardName.sneedsoldshredder, 0);
            this.silenceTargets.Add(CardDB.cardName.mekgineerthermaplugg, 0);
            this.silenceTargets.Add(CardDB.cardName.troggzortheearthinator, 0);

            this.silenceTargets.Add(CardDB.cardName.flamewaker, 0);
            this.silenceTargets.Add(CardDB.cardName.impgangboss, 0);
            this.silenceTargets.Add(CardDB.cardName.grimpatron, 0);
            this.silenceTargets.Add(CardDB.cardName.dragonkinsorcerer, 0);
            this.silenceTargets.Add(CardDB.cardName.majordomoexecutus, 0);
            this.silenceTargets.Add(CardDB.cardName.emperorthaurissan, 0);
            this.silenceTargets.Add(CardDB.cardName.chromaggus, 0);

            this.silenceTargets.Add(CardDB.cardName.quartermaster, 0);

            //TGT

            this.silenceTargets.Add(CardDB.cardName.silverhandregent, 0);
            this.silenceTargets.Add(CardDB.cardName.muklaschampion, 0);
            this.silenceTargets.Add(CardDB.cardName.maidenofthelake, 0);
            this.silenceTargets.Add(CardDB.cardName.crowdfavorite, 0);
            this.silenceTargets.Add(CardDB.cardName.kodorider, 0);
            this.silenceTargets.Add(CardDB.cardName.eydisdarkbane, 0);
            this.silenceTargets.Add(CardDB.cardName.fjolalightbane, 0);
            this.silenceTargets.Add(CardDB.cardName.nexuschampionsaraad, 0);
            this.silenceTargets.Add(CardDB.cardName.theskeletonknight, 0);
            this.silenceTargets.Add(CardDB.cardName.chillmaw, 0);

            this.silenceTargets.Add(CardDB.cardName.savagecombatant, 0);
            this.silenceTargets.Add(CardDB.cardName.aviana, 0);
            this.silenceTargets.Add(CardDB.cardName.dreadscale, 0);
            this.silenceTargets.Add(CardDB.cardName.acidmaw, 0);

            this.silenceTargets.Add(CardDB.cardName.coldarradrake, 0);
            this.silenceTargets.Add(CardDB.cardName.rhonin, 0);

            this.silenceTargets.Add(CardDB.cardName.warhorsetrainer, 0);
            this.silenceTargets.Add(CardDB.cardName.murlocknight, 0);

            this.silenceTargets.Add(CardDB.cardName.holychampion, 0);
            this.silenceTargets.Add(CardDB.cardName.confessorpaletress, 0);

            this.silenceTargets.Add(CardDB.cardName.thunderbluffvaliant, 0);

            this.silenceTargets.Add(CardDB.cardName.voidcrusher, 0);

            this.silenceTargets.Add(CardDB.cardName.wilfredfizzlebang, 0);

            this.silenceTargets.Add(CardDB.cardName.magnatauralpha, 0);

            this.silenceTargets.Add(CardDB.cardName.anubarak, 0);

            //LOE



        }

        private void setupRandomCards()
        {
            this.randomEffects.Add(CardDB.cardName.deadlyshot, 1);
            this.randomEffects.Add(CardDB.cardName.multishot, 1);

            this.randomEffects.Add(CardDB.cardName.animalcompanion, 1);
            this.randomEffects.Add(CardDB.cardName.arcanemissiles, 3);
            this.randomEffects.Add(CardDB.cardName.goblinblastmage, 1);
            this.randomEffects.Add(CardDB.cardName.avengingwrath, 8);

            this.randomEffects.Add(CardDB.cardName.flamecannon, 4);

            //this.randomEffects.Add(CardDB.cardName.baneofdoom, 1);
            this.randomEffects.Add(CardDB.cardName.brawl, 1);
            this.randomEffects.Add(CardDB.cardName.captainsparrot, 1);
            this.randomEffects.Add(CardDB.cardName.cleave, 1);
            this.randomEffects.Add(CardDB.cardName.forkedlightning, 1);
            this.randomEffects.Add(CardDB.cardName.gelbinmekkatorque, 1);
            this.randomEffects.Add(CardDB.cardName.iammurloc, 3);
            this.randomEffects.Add(CardDB.cardName.lightningstorm, 1);
            this.randomEffects.Add(CardDB.cardName.madbomber, 3);
            this.randomEffects.Add(CardDB.cardName.mindgames, 1);
            this.randomEffects.Add(CardDB.cardName.mindcontroltech, 1);
            this.randomEffects.Add(CardDB.cardName.mindvision, 1);
            this.randomEffects.Add(CardDB.cardName.powerofthehorde, 1);
            this.randomEffects.Add(CardDB.cardName.sensedemons, 2);
            this.randomEffects.Add(CardDB.cardName.tinkmasteroverspark, 1);
            this.randomEffects.Add(CardDB.cardName.totemiccall, 1);
            this.randomEffects.Add(CardDB.cardName.elitetaurenchieftain, 1);
            this.randomEffects.Add(CardDB.cardName.lifetap, 1);

            this.randomEffects.Add(CardDB.cardName.unstableportal, 1);
            this.randomEffects.Add(CardDB.cardName.crackle, 1);
            this.randomEffects.Add(CardDB.cardName.bouncingblade, 3);
            this.randomEffects.Add(CardDB.cardName.coghammer, 1);
            this.randomEffects.Add(CardDB.cardName.madderbomber, 6);
            this.randomEffects.Add(CardDB.cardName.bomblobber, 1);
            this.randomEffects.Add(CardDB.cardName.enhanceomechano, 1);

            this.randomEffects.Add(CardDB.cardName.nefarian, 2);
            this.randomEffects.Add(CardDB.cardName.dieinsect, 2);
            this.randomEffects.Add(CardDB.cardName.resurrect, 2);
            this.randomEffects.Add(CardDB.cardName.fireguarddestroyer, 2);

            //TGT
            //50% minions
            this.randomEffects.Add(CardDB.cardName.mogorschampion, 1);

            this.randomEffects.Add(CardDB.cardName.gadgetzanjouster, 1);
            this.randomEffects.Add(CardDB.cardName.armoredwarhorse, 1);
            this.randomEffects.Add(CardDB.cardName.masterjouster, 1);
            this.randomEffects.Add(CardDB.cardName.tuskarrjouster, 1);
            this.randomEffects.Add(CardDB.cardName.tuskarrtotemic, 1);
            this.randomEffects.Add(CardDB.cardName.healingwave, 1);
            this.randomEffects.Add(CardDB.cardName.elementaldestruction, 1);
            this.randomEffects.Add(CardDB.cardName.darkbargain, 2);
            this.randomEffects.Add(CardDB.cardName.varianwrynn, 3);

            this.randomEffects.Add(CardDB.cardName.lockandload, 10);
            this.randomEffects.Add(CardDB.cardName.flamejuggler, 1);
            this.randomEffects.Add(CardDB.cardName.grandcrusader, 1);
            this.randomEffects.Add(CardDB.cardName.spellslinger, 1);

        }

        private void setupTargetAbilitys()
        {
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS1h_001, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.DS1h_292, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.EX1_625t, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.EX1_625t2, 1);
            //this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034_H1, 1);
            //this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034_H1_AT_132, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_050t, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_132_HUNTER, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_132_MAGE, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_132_PRIEST, 1);
        }

        private void setupDiscover()
        {
            this.discoverMinions.Add(CardDB.cardName.tracking, 1);
            this.discoverMinions.Add(CardDB.cardName.jeweledscarab, 1);
            this.discoverMinions.Add(CardDB.cardName.ancientshade, 1);
            this.discoverMinions.Add(CardDB.cardName.darkpeddler, 1);
            this.discoverMinions.Add(CardDB.cardName.tombspider, 1);
            this.discoverMinions.Add(CardDB.cardName.gorillabota3, 1);  // only if you have a mech
            this.discoverMinions.Add(CardDB.cardName.etherealconjurer, 1);
            this.discoverMinions.Add(CardDB.cardName.museumcurator, 1);
            this.discoverMinions.Add(CardDB.cardName.ravenidol, 1);
            this.discoverMinions.Add(CardDB.cardName.archthiefrafaam, 1);


        }


        private void setupStrongInspireMinions()
        {
            

            strongInspireEffectMinions.Add(CardDB.cardName.boneguardlieutenant, 0);
            strongInspireEffectMinions.Add(CardDB.cardName.confessorpaletress, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.dalaranaspirant, 1);
            strongInspireEffectMinions.Add(CardDB.cardName.kodorider, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.kvaldirraider, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.lowlysquire, 0);
            strongInspireEffectMinions.Add(CardDB.cardName.muklaschampion, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.murlocknight, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.nexuschampionsaraad, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.recruiter, 3);
            strongInspireEffectMinions.Add(CardDB.cardName.thunderbluffvaliant, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.tournamentmedic, 1);
            strongInspireEffectMinions.Add(CardDB.cardName.savagecombatant, 4);
            strongInspireEffectMinions.Add(CardDB.cardName.silverhandregent, 3);
        }


    }

}