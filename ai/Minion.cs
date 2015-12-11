namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public class miniEnch
    {
        public CardDB.cardIDEnum CARDID = CardDB.cardIDEnum.None;
        public int creator = 0; // the minion
        public int controllerOfCreator = 0; // own or enemys buff?

        public miniEnch(CardDB.cardIDEnum id, int crtr, int controler)
        {
            this.CARDID = id;
            this.creator = crtr;
            this.controllerOfCreator = controler;
        }

    }

    public class Minion
    {
        //dont silence----------------------------
        public int anzGotDmg = 0;
        public int gotDmgRaw = 0;
        public bool isHero = false;
        public bool own;

        public CardDB.cardName name = CardDB.cardName.unknown;
        public Handmanager.Handcard handcard;
        public int entitiyID = -1;
        //public int id = -1;//delete this
        public int zonepos = 0;

        public bool playedThisTurn = false;
        public int numAttacksThisTurn = 0;
        public bool immuneWhileAttacking = false;

        public bool allreadyAttacked = false;

        //---------------------------------------
        public bool shadowmadnessed = false;//´can be silenced :D
        public bool canAttackNormal = false;

        public int ancestralspirit = 0;
        public bool destroyOnOwnTurnStart = false; // depends on own!
        public bool destroyOnEnemyTurnStart = false; // depends on own!
        public bool destroyOnOwnTurnEnd = false; // depends on own!
        public bool destroyOnEnemyTurnEnd = false; // depends on own!

        public bool concedal = false;
        public int souloftheforest = 0;

        public int explorersHat = 0;
        public int ownBlessingOfWisdom = 0;
        public int enemyBlessingOfWisdom = 0;
        public int ownPowerWordGlory = 0;
        public int enemyPowerWordGlory = 0;
        public int spellpower = 0;

        public bool cantBeTargetedBySpellsOrHeroPowers = false;

        public int Hp = 0;
        public int maxHp = 0;
        public int armor = 0;

        public int Angr = 0;
        public int AdjacentAngr = 0;
        public int tempAttack = 0;

        public bool Ready = false;

        public bool taunt = false;
        public bool wounded = false;//hp red?

        public bool divineshild = false;
        public bool windfury = false;
        public bool frozen = false;
        public bool stealth = false;
        public bool immune = false;
        public bool exhausted = false;

        public int charge = 0;
        public bool poisonous = false;
        public bool cantLowerHPbelowONE = false;

        public bool silenced = false;

        public List<int> deathrattles = new List<int>();//we might have to use this for unearthed raptor

        public Minion()
        {
            this.handcard = new Handmanager.Handcard();
        }

        public Minion(Minion m)
        {
            //dont silence----------------------------
            this.anzGotDmg = m.anzGotDmg;
            this.gotDmgRaw = m.gotDmgRaw;
            this.isHero = m.isHero;
            this.own = m.own;
            this.canAttackNormal = m.canAttackNormal;
            this.name = m.name;
            this.handcard = m.handcard;//new?
            this.entitiyID = m.entitiyID;
            this.zonepos = m.zonepos;

            this.allreadyAttacked = m.allreadyAttacked;


            this.playedThisTurn = m.playedThisTurn;
            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.immuneWhileAttacking = m.immuneWhileAttacking;
            this.cantBeTargetedBySpellsOrHeroPowers = m.cantBeTargetedBySpellsOrHeroPowers;
            //---------------------------------------
            this.shadowmadnessed = m.shadowmadnessed;

            this.ancestralspirit = m.ancestralspirit;
            this.destroyOnOwnTurnStart = m.destroyOnOwnTurnStart; // depends on own!
            this.destroyOnEnemyTurnStart = m.destroyOnEnemyTurnStart; // depends on own!
            this.destroyOnOwnTurnEnd = m.destroyOnOwnTurnEnd; // depends on own!
            this.destroyOnEnemyTurnEnd = m.destroyOnEnemyTurnEnd; // depends on own!

            this.concedal = m.concedal;
            this.souloftheforest = m.souloftheforest;

            this.explorersHat = m.explorersHat;

            this.ownBlessingOfWisdom = m.ownBlessingOfWisdom;
            this.enemyBlessingOfWisdom = m.enemyBlessingOfWisdom;
            this.ownPowerWordGlory = m.ownPowerWordGlory;
            this.enemyPowerWordGlory = m.enemyPowerWordGlory;
            this.spellpower = m.spellpower;

            this.Hp = m.Hp;
            this.maxHp = m.maxHp;
            this.armor = m.armor;

            this.Angr = m.Angr;
            this.AdjacentAngr = m.AdjacentAngr;
            this.tempAttack = m.tempAttack;

            this.Ready = m.Ready;

            this.taunt = m.taunt;
            this.wounded = m.wounded;

            this.divineshild = m.divineshild;
            this.windfury = m.windfury;
            this.frozen = m.frozen;
            this.stealth = m.stealth;
            this.immune = m.immune;
            this.exhausted = m.exhausted;

            this.charge = m.charge;
            this.poisonous = m.poisonous;
            this.cantLowerHPbelowONE = m.cantLowerHPbelowONE;

            this.silenced = m.silenced;
            if (m.deathrattles != null)
            {
                this.deathrattles = new List<int>();
                foreach (int dr in m.deathrattles)
                {
                    this.deathrattles.Add(dr);  
                }
            }
        }

        public void setMinionTominion(Minion m)
        {
            //dont silence----------------------------
            this.anzGotDmg = m.anzGotDmg;
            this.gotDmgRaw = m.gotDmgRaw;
            this.isHero = m.isHero;
            this.own = m.own;
            this.canAttackNormal = m.canAttackNormal;
            this.name = m.name;
            this.handcard = m.handcard;//new?
            //this.entitiyID = m.entitiyID;
            this.zonepos = m.zonepos;


            this.allreadyAttacked = m.allreadyAttacked;

            this.playedThisTurn = m.playedThisTurn;
            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.immuneWhileAttacking = m.immuneWhileAttacking;

            //---------------------------------------
            this.shadowmadnessed = m.shadowmadnessed;

            this.ancestralspirit = m.ancestralspirit;
            this.destroyOnOwnTurnStart = m.destroyOnOwnTurnStart; // depends on own!
            this.destroyOnEnemyTurnStart = m.destroyOnEnemyTurnStart; // depends on own!
            this.destroyOnOwnTurnEnd = m.destroyOnOwnTurnEnd; // depends on own!
            this.destroyOnEnemyTurnEnd = m.destroyOnEnemyTurnEnd; // depends on own!
            this.cantBeTargetedBySpellsOrHeroPowers = m.cantBeTargetedBySpellsOrHeroPowers;
            this.concedal = m.concedal;
            this.souloftheforest = m.souloftheforest;

            this.explorersHat = m.explorersHat;

            this.ownBlessingOfWisdom = m.ownBlessingOfWisdom;
            this.enemyBlessingOfWisdom = m.enemyBlessingOfWisdom;
            this.ownPowerWordGlory = m.ownPowerWordGlory;
            this.enemyPowerWordGlory = m.enemyPowerWordGlory;
            this.spellpower = m.spellpower;

            this.Hp = m.Hp;
            this.maxHp = m.maxHp;
            this.armor = m.armor;

            this.Angr = m.Angr;
            this.AdjacentAngr = m.AdjacentAngr;
            this.tempAttack = m.tempAttack;

            this.Ready = m.Ready;

            this.taunt = m.taunt;
            this.wounded = m.wounded;

            this.divineshild = m.divineshild;
            this.windfury = m.windfury;
            this.frozen = m.frozen;
            this.stealth = m.stealth;
            this.immune = m.immune;
            this.exhausted = m.exhausted;

            this.charge = m.charge;
            this.poisonous = m.poisonous;
            this.cantLowerHPbelowONE = m.cantLowerHPbelowONE;

            this.silenced = m.silenced;

            if (m.deathrattles != null)
            {
                this.deathrattles = new List<int>();
                foreach (int dr in m.deathrattles)
                {
                    this.deathrattles.Add(dr);
                }
            }
        }

        public int getRealAttack()
        {
            return this.Angr;
        }

        public void getDamageOrHeal(int dmgg, Playfield p, bool isMinionAttack, bool dontCalcLostDmg)
        {
            int dmg = dmgg;
            if (this.Hp <= 0) return;

            if (this.immune && dmg > 0) return;

            if (this.isHero)
            {
                //dmg reduction from animated armor
                if (this.own && dmg > 1)
                {
                    if (p.ownWeaponDurability >=1 && p.ownWeaponName == CardDB.cardName.cursedblade)
                    {
                        dmg = dmg*2;
                    }

                    if (p.anzOwnAnimatedArmor >= 1)
                    {
                        dmg = 1;
                    }
                }
                else
                {
                    if (p.enemyWeaponDurability >=1 && p.enemyWeaponName == CardDB.cardName.cursedblade)
                    {
                        dmg = dmg * 2;
                    }

                    if (p.anzEnemyAnimatedArmor >= 1)
                    {
                        dmg = 1;
                    }
                }

                int copy = this.Hp;
                if (dmg < 0 || this.armor <= 0)
                {
                    //if (dmg < 0) return;

                    //heal
                    bool BolfRamshield = false;
                    if (dmg > 0)
                    {

                        foreach (Minion m in (this.own) ? p.ownMinions : p.enemyMinions)
                        {
                            if (m.name == CardDB.cardName.bolframshield)
                            {
                                BolfRamshield = true;
                                m.getDamageOrHeal(dmg, p, isMinionAttack, dontCalcLostDmg);
                            }
                        }
                    }

                    if (!BolfRamshield)
                    {
                        this.Hp = Math.Min(30, this.Hp - dmg);
                    }
                    if (copy < this.Hp)
                    {
                        p.tempTrigger.charsGotHealed++;
                        if (this.own)
                        {
                            p.tempTrigger.owncharsGotHealed++;
                        }
                    }
                    if (copy - this.Hp >= 1)
                    {
                        p.secretTrigger_HeroGotDmg(this.own, copy - this.Hp);
                    }
                }
                else
                {
                    if (this.armor > 0 && dmg > 0)
                    {

                        int rest = this.armor - dmg;
                        if (rest < 0)
                        {
                            bool BolfRamshield = false;
                            foreach (Minion m in (this.own) ? p.ownMinions : p.enemyMinions)
                            {
                                if (m.name == CardDB.cardName.bolframshield)
                                {
                                    BolfRamshield = true;
                                    m.getDamageOrHeal(-rest, p, isMinionAttack, dontCalcLostDmg);
                                }
                            }
                            if (!BolfRamshield)
                            {
                                this.Hp += rest;
                                p.secretTrigger_HeroGotDmg(this.own, rest);
                            }
                        }
                        this.armor = Math.Max(0, this.armor - dmg);

                    }
                }
                if (this.cantLowerHPbelowONE && this.Hp <= 0) this.Hp = 1;


                if (this.Hp < copy)
                {
                    if (this.own)
                    {
                        p.tempTrigger.ownHeroGotDmg++;
                    }
                    else
                    {
                        p.tempTrigger.enemyHeroGotDmg++;
                    }
                    this.anzGotDmg++;
                    this.gotDmgRaw += dmg;
                }
                return;
            }

            //its a Minion--------------------------------------------------------------


            int damage = dmg;
            int heal = 0;
            if (dmg < 0) heal = -dmg;

            bool woundedbefore = this.wounded;
            if (heal < 0) // heal was shifted in damage
            {
                damage = -1 * heal;
                heal = 0;
            }

            if (damage >= 1) this.allreadyAttacked = true;

            if (damage >= 1 && this.divineshild)
            {
                this.divineshild = false;
                if (!own && !dontCalcLostDmg && p.turnCounter == 0)
                {
                    if (isMinionAttack)
                    {
                        p.lostDamage += damage - 1;
                    }
                    else
                    {
                        p.lostDamage += (damage - 1) * (damage - 1);
                    }
                }
                return;
            }

            if (this.cantLowerHPbelowONE && damage >= 1 && damage >= this.Hp) damage = this.Hp - 1;

            if (!own && !dontCalcLostDmg && this.Hp < damage && p.turnCounter == 0)
            {
                if (isMinionAttack)
                {
                    p.lostDamage += (damage - this.Hp);
                }
                else
                {
                    p.lostDamage += (damage - this.Hp) * (damage - this.Hp);
                }
            }

            int hpcopy = this.Hp;

            if (damage >= 1)
            {
                this.Hp = this.Hp - damage;
            }

            if (heal >= 1)
            {
                if (own && !dontCalcLostDmg && heal <= 999 && this.Hp + heal > this.maxHp) p.lostHeal += this.Hp + heal - this.maxHp;

                this.Hp = this.Hp + Math.Min(heal, this.maxHp - this.Hp);
            }



            if (this.Hp > hpcopy)
            {
                //minionWasHealed
                p.tempTrigger.minionsGotHealed++;
                p.tempTrigger.charsGotHealed++;
                if (this.own)
                {
                    p.tempTrigger.ownMinionsGotHealed++;
                    p.tempTrigger.owncharsGotHealed++;
                }
            }

            if (this.Hp < hpcopy)
            {
                if (this.own)
                {
                    p.tempTrigger.ownMinionsGotDmg++;
                }
                else
                {
                    p.tempTrigger.enemyMinionsGotDmg++;
                }

                this.anzGotDmg++;
                this.gotDmgRaw += dmg;
            }

            if (this.maxHp == this.Hp)
            {
                this.wounded = false;
            }
            else
            {
                this.wounded = true;
            }



            if (this.name == CardDB.cardName.lightspawn && !this.silenced)
            {
                this.Angr = this.Hp;
            }

            if (woundedbefore && !this.wounded)
            {
                this.handcard.card.sim_card.onEnrageStop(p, this);
            }

            if (!woundedbefore && this.wounded)
            {
                this.handcard.card.sim_card.onEnrageStart(p, this);
            }

            if (this.Hp <= 0)
            {
                this.minionDied(p);
            }



        }

        public void minionDied(Playfield p)
        {
            if (this.name == CardDB.cardName.stalagg)
            {
                p.stalaggDead = true;
            }
            else
            {
                if (this.name == CardDB.cardName.feugen) p.feugenDead = true;
            }



            if (own)
            {

                p.tempTrigger.ownMinionsDied++;
                if (this.handcard.card.race == TAG_RACE.PET)
                {
                    p.tempTrigger.ownBeastDied++;
                }
                if (this.handcard.card.race == TAG_RACE.MECHANICAL)
                {
                    p.tempTrigger.ownMechanicDied++;
                }
                if (this.handcard.card.race == TAG_RACE.MURLOC)
                {
                    p.tempTrigger.ownMurlocDied++;
                }
            }
            else
            {
                p.tempTrigger.enemyMinionsDied++;
                if (this.handcard.card.race == TAG_RACE.PET)
                {
                    p.tempTrigger.enemyBeastDied++;
                }
                if (this.handcard.card.race == TAG_RACE.MECHANICAL)
                {
                    p.tempTrigger.enemyMechanicDied++;
                }
                if (this.handcard.card.race == TAG_RACE.MURLOC)
                {
                    p.tempTrigger.enemyMurlocDied++;
                }
            }

            if (p.diedMinions != null)
            {
                GraveYardItem gyi = new GraveYardItem(this.handcard.card.cardIDenum, this.entitiyID, this.own);
                p.diedMinions.Add(gyi);
            }
            p.anzMinionsDiedThisTurn++;
        }

        public void updateReadyness()
        {
            Ready = false;
            //default test (minion must be unfrozen!)
            if (isHero)
            {
                if (!frozen && ((charge >= 1 && playedThisTurn) || !playedThisTurn) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury))) Ready = true;
                return;
            }

            if (!silenced && (name == CardDB.cardName.ragnarosthefirelord || name == CardDB.cardName.ancientwatcher || (name == CardDB.cardName.argentwatchman && !this.canAttackNormal) || (name == CardDB.cardName.eeriestatue && !this.canAttackNormal))) return;

            if (!frozen && ((charge >= 1 && playedThisTurn) || !playedThisTurn || shadowmadnessed) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury) || (!silenced && this.name == CardDB.cardName.v07tr0n && numAttacksThisTurn <= 3))) Ready = true;

        }

        public void updateReadyness(Playfield p)
        {
            Ready = false;
            //default test (minion must be unfrozen!)
            if (isHero)
            {
                if (!frozen && ((charge >= 1 && playedThisTurn) || !playedThisTurn) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury))) Ready = true;
                return;
            }

            if (!silenced && (name == CardDB.cardName.ragnarosthefirelord || name == CardDB.cardName.ancientwatcher || (name == CardDB.cardName.argentwatchman && !this.canAttackNormal))) return;

            if (!silenced && (name == CardDB.cardName.eeriestatue))
            {
                int numberminionOnBoard = 0;
                //we loop throug every minion, because we have to test hp>=1 (we trigger this in on minion died -> died minion isnt removed)
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Hp >= 1) numberminionOnBoard++;
                }

                if (numberminionOnBoard > 1) return;

                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Hp >= 1) numberminionOnBoard++;
                }

                if (numberminionOnBoard > 1) return;
            }

            if (!frozen && ((charge >= 1 && playedThisTurn) || !playedThisTurn || shadowmadnessed) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury) || (!silenced && this.name == CardDB.cardName.v07tr0n && numAttacksThisTurn <= 3))) Ready = true;

        }

        public void endAura(Playfield p)
        {
            if(!this.silenced) this.handcard.card.sim_card.onAuraEnds(p, this);

            if (this.own)
            {
                p.spellpower -= this.spellpower;
            }
            else
            {
                p.enemyspellpower -= this.spellpower;
            }
            this.spellpower = 0;
        }

        public void becomeSilence(Playfield p)
        {
            p.minionGetOrEraseAllAreaBuffs(this, false);
            //buffs
            ancestralspirit = 0;
            destroyOnOwnTurnStart = false;
            destroyOnEnemyTurnStart = false;
            destroyOnOwnTurnEnd = false;
            destroyOnEnemyTurnEnd = false;
            concedal = false;
            souloftheforest = 0;
            ownBlessingOfWisdom = 0;
            enemyBlessingOfWisdom = 0;
            ownPowerWordGlory = 0;
            enemyPowerWordGlory = 0;

            explorersHat = 0;

            cantBeTargetedBySpellsOrHeroPowers = false;

            charge = 0;
            taunt = false;
            divineshild = false;
            windfury = false;
            frozen = false;
            stealth = false;
            immune = false;
            poisonous = false;
            cantLowerHPbelowONE = false;
            if(this.deathrattles!=null) this.deathrattles.Clear();

            if (own) p.spellpower -= spellpower;
            else p.enemyspellpower -= spellpower;

            spellpower = 0;

            //delete enrage (if minion is silenced the first time)
            if (wounded && handcard.card.Enrage && !silenced)
            {
                handcard.card.sim_card.onEnrageStop(p, this);
            }

            //reset attack
            Angr = handcard.card.Attack;
            tempAttack = 0;//we dont toutch the adjacent buffs!


            //reset hp and heal it
            if (maxHp < handcard.card.Health)//minion has lower maxHp as his card -> heal his hp
            {
                Hp += handcard.card.Health - maxHp; //heal minion
            }
            maxHp = handcard.card.Health;
            if (Hp > maxHp) Hp = maxHp;

            if (!silenced)//minion WAS not silenced, deactivate his aura
            {
                handcard.card.sim_card.onAuraEnds(p, this);
            }

            silenced = true;
            this.updateReadyness();
            p.minionGetOrEraseAllAreaBuffs(this, true);
            if (own)
            {
                p.tempTrigger.ownMinionsChanged = true;
            }
            else
            {
                p.tempTrigger.enemyMininsChanged = true;
            }
            if (this.shadowmadnessed)
            {
                this.shadowmadnessed = false;
                p.minionGetControlled(this, !own, false);
            }
        }

        public bool hasDeathrattle()
        {
            if (this.deathrattles == null || this.deathrattles.Count == 0) return false;
            return true;
        }

        public void loadEnchantments(List<miniEnch> enchants, int ownPlayerControler)
        {
            bool correctSpellPower = false;
            int spellpowerbuffs = 0;
            foreach (miniEnch me in enchants)
            {

                if (me.CARDID == CardDB.cardIDEnum.LOE_105e) //explorersHat
                {
                    this.explorersHat++;
                }


                if (me.CARDID == CardDB.cardIDEnum.AT_132_DRUIDe) //Claws better
                {
                    this.tempAttack += 2;
                }

                if (me.CARDID == CardDB.cardIDEnum.AT_013e) //power word: glory
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.ownPowerWordGlory++;
                    }
                    else
                    {
                        this.enemyPowerWordGlory++;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.AT_109e)
                {
                    this.canAttackNormal = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.AT_039e) //Claw
                {
                    this.tempAttack += 2;
                }
                // deathrattles reborns and destoyings----------------------------------------------


                if (me.CARDID == CardDB.cardIDEnum.CS2_038e) //ancestral spirit
                {
                    this.ancestralspirit++;
                }

                //spellpower is now readed in m.spellpower = entity.getTag(SPELLPOWER)!
                if (me.CARDID == CardDB.cardIDEnum.EX1_584e) //ancient mage
                {
                    //this.spellpower++;
                    correctSpellPower = true;
                    spellpowerbuffs++;
                }
                if (me.CARDID == CardDB.cardIDEnum.GVG_010b) //Velen's Chosen (+2+4, +spellpower)
                {
                    //this.spellpower++;
                    correctSpellPower = true;
                    spellpowerbuffs++;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_158e) //soul of the forest
                {
                    this.souloftheforest++;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_128e) //conceal
                {
                    this.concedal = true;
                }
                if (me.CARDID == CardDB.cardIDEnum.PART_004e) //conceal
                {
                    this.concedal = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_063e) //corruption
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.destroyOnOwnTurnStart = true;
                    }
                    else
                    {
                        this.destroyOnEnemyTurnStart = true;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_363e || me.CARDID == CardDB.cardIDEnum.EX1_363e2) //corruption
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.ownBlessingOfWisdom++;
                    }
                    else
                    {
                        this.enemyBlessingOfWisdom++;
                    }
                }



                if (me.CARDID == CardDB.cardIDEnum.DREAM_05e) //nightmare
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.destroyOnOwnTurnStart = true;
                    }
                    else
                    {
                        this.destroyOnEnemyTurnStart = true;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_316e) //overwhelmingpower
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.destroyOnOwnTurnEnd = true;
                    }
                    else
                    {
                        this.destroyOnEnemyTurnEnd = true;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.NEW1_036e) //commanding shout
                {
                    this.cantLowerHPbelowONE = true;
                }
                if (me.CARDID == CardDB.cardIDEnum.NEW1_036e2) //commanding shout
                {
                    this.cantLowerHPbelowONE = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_334e) //Dark Command
                {
                    this.shadowmadnessed = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.FP1_030e) //Necrotic Aura
                {
                    //todo Eure Zauber kosten in diesem Zug (5) mehr.
                }

                if (me.CARDID == CardDB.cardIDEnum.NEW1_029t) //death to millhouse!
                {
                    // todo spells cost (0) this turn!
                }
                if (me.CARDID == CardDB.cardIDEnum.EX1_612o) //Power of the Kirin Tor
                {
                    // todo Your next Secret costs (0).
                }

                /*if (me.CARDID == CardDB.cardIDEnum.EX1_084e) //warsongcommander
                {
                    this.charge++;
                }*/

                if (me.CARDID == CardDB.cardIDEnum.DS1_178e) //rhino
                {
                    this.charge++;
                }
                if (me.CARDID == CardDB.cardIDEnum.CS2_103e2)// sturmangriff    +2 angriff und ansturm/.
                {
                    this.charge++;
                }

                if (me.CARDID == CardDB.cardIDEnum.AT_071e)// sturmangriff    +1 angriff und ansturm/.
                {
                    this.charge++;
                }

                //ancientbuffs-------------------------------------------------
                if (me.CARDID == CardDB.cardIDEnum.EX1_565o) //flametongue
                {
                    this.AdjacentAngr += 2;
                }
                if (me.CARDID == CardDB.cardIDEnum.EX1_162o) //dire wolf alpha
                {
                    this.AdjacentAngr += 1;
                }
                //tempbuffs-------------------------------------------------

                if (me.CARDID == CardDB.cardIDEnum.CS2_105e) //heldenhafter stoss
                {
                    this.tempAttack += 4;
                }
                if (me.CARDID == CardDB.cardIDEnum.EX1_570e) //bite
                {
                    this.tempAttack += 4;
                }
                if (me.CARDID == CardDB.cardIDEnum.CS2_083e) //sharpened
                {
                    this.tempAttack += 1;
                }
                if (me.CARDID == CardDB.cardIDEnum.EX1_046e) //tempered
                {
                    this.tempAttack += 2;
                }
                if (me.CARDID == CardDB.cardIDEnum.CS2_188o) //inspiring
                {
                    this.tempAttack += 2;
                }
                if (me.CARDID == CardDB.cardIDEnum.CS2_045e) //rockbiter
                {
                    this.tempAttack += 3;
                }
                if (me.CARDID == CardDB.cardIDEnum.CS2_046e) //bloodlust
                {
                    this.tempAttack += 3;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_011o) //Savage Roar
                {
                    this.tempAttack += 2;
                }
                if (me.CARDID == CardDB.cardIDEnum.CS2_017o) //Claws
                {
                    this.tempAttack += 1;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_549o) //bestial wrath
                {
                    this.tempAttack += 2;
                    this.immune = true;
                }
                if (me.CARDID == CardDB.cardIDEnum.CS2_005o) //Claw
                {
                    this.tempAttack += 2;
                }



                if (me.CARDID == CardDB.cardIDEnum.GVG_011a) //Shrink Ray
                {
                    this.tempAttack -= 2; //todo might not be correct
                }
                if (me.CARDID == CardDB.cardIDEnum.GVG_057a) //Seal of Light
                {
                    this.tempAttack += 2;
                }
            }

            if (correctSpellPower)
            {
                //TODO add the mission spellpower of that new insprire minion, but we need the (correct)spellpower of the player for that
                this.spellpower = 0;
                if (spellpowerbuffs >= 1)
                {
                    this.spellpower += spellpowerbuffs; //one is counted!
                }
                if (!this.silenced)
                {
                    this.spellpower += this.handcard.card.spellpowervalue;
                }
            }

        }

    }

}