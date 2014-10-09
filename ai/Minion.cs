// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Minion.cs" company="">
//   
// </copyright>
// <summary>
//   The mini ench.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The mini ench.
    /// </summary>
    public class miniEnch
    {
        /// <summary>
        /// The cardid.
        /// </summary>
        public CardDB.cardIDEnum CARDID = CardDB.cardIDEnum.None;

        /// <summary>
        /// The creator.
        /// </summary>
        public int creator = 0; // the minion

        /// <summary>
        /// The controller of creator.
        /// </summary>
        public int controllerOfCreator = 0; // own or enemys buff?

        /// <summary>
        /// Initializes a new instance of the <see cref="miniEnch"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="crtr">
        /// The crtr.
        /// </param>
        /// <param name="controler">
        /// The controler.
        /// </param>
        public miniEnch(CardDB.cardIDEnum id, int crtr, int controler)
        {
            this.CARDID = id;
            this.creator = crtr;
            this.controllerOfCreator = controler;
        }

    }

    /// <summary>
    /// The minion.
    /// </summary>
    public class Minion
    {
        // dont silence----------------------------
        /// <summary>
        /// The anz got dmg.
        /// </summary>
        public int anzGotDmg = 0;

        /// <summary>
        /// The is hero.
        /// </summary>
        public bool isHero = false;

        /// <summary>
        /// The own.
        /// </summary>
        public bool own;

        /// <summary>
        /// The name.
        /// </summary>
        public CardDB.cardName name = CardDB.cardName.unknown;

        /// <summary>
        /// The handcard.
        /// </summary>
        public Handmanager.Handcard handcard;

        /// <summary>
        /// The entitiy id.
        /// </summary>
        public int entitiyID = -1;

        // public int id = -1;//delete this
        /// <summary>
        /// The zonepos.
        /// </summary>
        public int zonepos = 0;

        /// <summary>
        /// The played this turn.
        /// </summary>
        public bool playedThisTurn = false;

        /// <summary>
        /// The num attacks this turn.
        /// </summary>
        public int numAttacksThisTurn = 0;

        /// <summary>
        /// The immune while attacking.
        /// </summary>
        public bool immuneWhileAttacking = false;

        // ---------------------------------------
        /// <summary>
        /// The shadowmadnessed.
        /// </summary>
        public bool shadowmadnessed = false; // ´can be silenced :D

        /// <summary>
        /// The ancestralspirit.
        /// </summary>
        public int ancestralspirit = 0;

        /// <summary>
        /// The destroy on own turn start.
        /// </summary>
        public bool destroyOnOwnTurnStart = false; // depends on own!

        /// <summary>
        /// The destroy on enemy turn start.
        /// </summary>
        public bool destroyOnEnemyTurnStart = false; // depends on own!

        /// <summary>
        /// The destroy on own turn end.
        /// </summary>
        public bool destroyOnOwnTurnEnd = false; // depends on own!

        /// <summary>
        /// The destroy on enemy turn end.
        /// </summary>
        public bool destroyOnEnemyTurnEnd = false; // depends on own!

        /// <summary>
        /// The concedal.
        /// </summary>
        public bool concedal = false;

        /// <summary>
        /// The souloftheforest.
        /// </summary>
        public int souloftheforest = 0;

        /// <summary>
        /// The own blessing of wisdom.
        /// </summary>
        public int ownBlessingOfWisdom = 0;

        /// <summary>
        /// The enemy blessing of wisdom.
        /// </summary>
        public int enemyBlessingOfWisdom = 0;

        /// <summary>
        /// The spellpower.
        /// </summary>
        public int spellpower = 0;

        /// <summary>
        /// The hp.
        /// </summary>
        public int Hp = 0;

        /// <summary>
        /// The max hp.
        /// </summary>
        public int maxHp = 0;

        /// <summary>
        /// The armor.
        /// </summary>
        public int armor = 0;

        /// <summary>
        /// The angr.
        /// </summary>
        public int Angr = 0;

        /// <summary>
        /// The adjacent angr.
        /// </summary>
        public int AdjacentAngr = 0;

        /// <summary>
        /// The temp attack.
        /// </summary>
        public int tempAttack = 0;

        /// <summary>
        /// The ready.
        /// </summary>
        public bool Ready = false;

        /// <summary>
        /// The taunt.
        /// </summary>
        public bool taunt = false;

        /// <summary>
        /// The wounded.
        /// </summary>
        public bool wounded = false; // hp red?

        /// <summary>
        /// The divineshild.
        /// </summary>
        public bool divineshild = false;

        /// <summary>
        /// The windfury.
        /// </summary>
        public bool windfury = false;

        /// <summary>
        /// The frozen.
        /// </summary>
        public bool frozen = false;

        /// <summary>
        /// The stealth.
        /// </summary>
        public bool stealth = false;

        /// <summary>
        /// The immune.
        /// </summary>
        public bool immune = false;

        /// <summary>
        /// The exhausted.
        /// </summary>
        public bool exhausted = false;

        /// <summary>
        /// The charge.
        /// </summary>
        public int charge = 0;

        /// <summary>
        /// The poisonous.
        /// </summary>
        public bool poisonous = false;

        /// <summary>
        /// The cant lower h pbelow one.
        /// </summary>
        public bool cantLowerHPbelowONE = false;

        /// <summary>
        /// The silenced.
        /// </summary>
        public bool silenced = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Minion"/> class.
        /// </summary>
        public Minion()
        {
            this.handcard = new Handmanager.Handcard();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Minion"/> class.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public Minion(Minion m)
        {
            // dont silence----------------------------
            this.anzGotDmg = m.anzGotDmg;
            this.isHero = m.isHero;
            this.own = m.own;

            this.name = m.name;
            this.handcard = m.handcard; // new?
            this.entitiyID = m.entitiyID;
            this.zonepos = m.zonepos;

            this.playedThisTurn = m.playedThisTurn;
            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.immuneWhileAttacking = m.immuneWhileAttacking;

            // ---------------------------------------
            this.shadowmadnessed = m.shadowmadnessed;

            this.ancestralspirit = m.ancestralspirit;
            this.destroyOnOwnTurnStart = m.destroyOnOwnTurnStart; // depends on own!
            this.destroyOnEnemyTurnStart = m.destroyOnEnemyTurnStart; // depends on own!
            this.destroyOnOwnTurnEnd = m.destroyOnOwnTurnEnd; // depends on own!
            this.destroyOnEnemyTurnEnd = m.destroyOnEnemyTurnEnd; // depends on own!

            this.concedal = m.concedal;
            this.souloftheforest = m.souloftheforest;

            this.ownBlessingOfWisdom = m.ownBlessingOfWisdom;
            this.enemyBlessingOfWisdom = m.enemyBlessingOfWisdom;
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
        }

        /// <summary>
        /// The set minion tominion.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public void setMinionTominion(Minion m)
        {
            // dont silence----------------------------
            this.anzGotDmg = m.anzGotDmg;
            this.isHero = m.isHero;
            this.own = m.own;

            this.name = m.name;
            this.handcard = m.handcard; // new?
            this.entitiyID = m.entitiyID;
            this.zonepos = m.zonepos;

            this.playedThisTurn = m.playedThisTurn;
            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.immuneWhileAttacking = m.immuneWhileAttacking;

            // ---------------------------------------
            this.shadowmadnessed = m.shadowmadnessed;

            this.ancestralspirit = m.ancestralspirit;
            this.destroyOnOwnTurnStart = m.destroyOnOwnTurnStart; // depends on own!
            this.destroyOnEnemyTurnStart = m.destroyOnEnemyTurnStart; // depends on own!
            this.destroyOnOwnTurnEnd = m.destroyOnOwnTurnEnd; // depends on own!
            this.destroyOnEnemyTurnEnd = m.destroyOnEnemyTurnEnd; // depends on own!

            this.concedal = m.concedal;
            this.souloftheforest = m.souloftheforest;

            this.ownBlessingOfWisdom = m.ownBlessingOfWisdom;
            this.enemyBlessingOfWisdom = m.enemyBlessingOfWisdom;
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
        }

        /// <summary>
        /// The get real attack.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int getRealAttack()
        {
            return this.Angr;
        }

        /// <summary>
        /// The get damage or heal.
        /// </summary>
        /// <param name="dmg">
        /// The dmg.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="isMinionAttack">
        /// The is minion attack.
        /// </param>
        /// <param name="dontCalcLostDmg">
        /// The dont calc lost dmg.
        /// </param>
        public void getDamageOrHeal(int dmg, Playfield p, bool isMinionAttack, bool dontCalcLostDmg)
        {
            if (this.Hp <= 0)
            {
                return;
            }

            if (this.immune && dmg > 0)
            {
                return;
            }

            if (this.isHero)
            {
                if (dmg < 0 || this.armor <= 0)
                {
                    // if (dmg < 0) return;

                    // heal
                    int copy = this.Hp;

                    this.Hp = Math.Min(30, this.Hp - dmg);
                    if (copy < this.Hp)
                    {
                        p.tempTrigger.charsGotHealed++;
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
                            this.Hp += rest;
                            p.secretTrigger_HeroGotDmg(this.own, rest);
                        }

                        this.armor = Math.Max(0, this.armor - dmg);
                    }
                }

                if (this.cantLowerHPbelowONE && this.Hp <= 0)
                {
                    this.Hp = 1;
                }

                return;
            }

            // its a Minion--------------------------------------------------------------
            int damage = dmg;
            int heal = 0;
            if (dmg < 0)
            {
                heal = -dmg;
            }

            bool woundedbefore = this.wounded;
            if (heal < 0)
            {
                // heal was shifted in damage
                damage = -1 * heal;
                heal = 0;
            }

            if (damage >= 1 && this.divineshild)
            {
                this.divineshild = false;
                if (!this.own && !dontCalcLostDmg)
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

            if (this.cantLowerHPbelowONE && damage >= 1 && damage >= this.Hp)
            {
                damage = this.Hp - 1;
            }

            if (!this.own && !dontCalcLostDmg && this.Hp < damage)
            {
                if (isMinionAttack)
                {
                    p.lostDamage += damage - this.Hp;
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
                if (this.own && !dontCalcLostDmg && heal <= 999 && this.Hp + heal > this.maxHp)
                {
                    p.lostHeal += this.Hp + heal - this.maxHp;
                }

                this.Hp = this.Hp + Math.Min(heal, this.maxHp - this.Hp);
            }

            if (this.Hp > hpcopy)
            {
                // minionWasHealed
                p.tempTrigger.minionsGotHealed++;
                p.tempTrigger.charsGotHealed++;
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

        /// <summary>
        /// The minion died.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        public void minionDied(Playfield p)
        {
            if (this.name == CardDB.cardName.stalagg)
            {
                p.stalaggDead = true;
            }
            else
            {
                if (this.name == CardDB.cardName.feugen)
                {
                    p.feugenDead = true;
                }
            }

            if (this.handcard.card.race == 14)
            {
                p.tempTrigger.murlocDied++;
            }

            if (this.own)
            {
                p.tempTrigger.ownMinionsDied++;
                if (this.handcard.card.race == 20)
                {
                    p.tempTrigger.ownBeastDied++;
                }
            }
            else
            {
                p.tempTrigger.enemyMinionsDied++;
                if (this.handcard.card.race == 20)
                {
                    p.tempTrigger.enemyBeastDied++;
                }
            }

            if (p.diedMinions != null)
            {
                GraveYardItem gyi = new GraveYardItem(this.handcard.card.cardIDenum, this.entitiyID, this.own);
                p.diedMinions.Add(gyi);
            }
        }

        /// <summary>
        /// The update readyness.
        /// </summary>
        public void updateReadyness()
        {
            this.Ready = false;

            // default test (minion must be unfrozen!)
            if (this.isHero)
            {
                if (!this.frozen && ((this.charge >= 1 && this.playedThisTurn) || !this.playedThisTurn)
                    && (this.numAttacksThisTurn == 0 || (this.numAttacksThisTurn == 1 && this.windfury)))
                {
                    this.Ready = true;
                }

                return;
            }

            if (!this.silenced
                && (this.name == CardDB.cardName.ragnarosthefirelord || this.name == CardDB.cardName.ancientwatcher))
            {
                return;
            }

            if (!this.frozen
                && ((this.charge >= 1 && this.playedThisTurn) || !this.playedThisTurn || this.shadowmadnessed)
                && (this.numAttacksThisTurn == 0 || (this.numAttacksThisTurn == 1 && this.windfury)))
            {
                this.Ready = true;
            }
        }

        /// <summary>
        /// The become silence.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        public void becomeSilence(Playfield p)
        {
            p.minionGetOrEraseAllAreaBuffs(this, false);

            // buffs
            this.ancestralspirit = 0;
            this.destroyOnOwnTurnStart = false;
            this.destroyOnEnemyTurnStart = false;
            this.destroyOnOwnTurnEnd = false;
            this.destroyOnEnemyTurnEnd = false;
            this.concedal = false;
            this.souloftheforest = 0;
            this.ownBlessingOfWisdom = 0;
            this.enemyBlessingOfWisdom = 0;

            this.charge = 0;
            this.taunt = false;
            this.divineshild = false;
            this.windfury = false;
            this.frozen = false;
            this.stealth = false;
            this.immune = false;
            this.poisonous = false;
            this.cantLowerHPbelowONE = false;

            if (this.own)
            {
                p.spellpower -= this.spellpower;
            }
            else
            {
                p.enemyspellpower -= this.spellpower;
            }

            this.spellpower = 0;

            // delete enrage (if minion is silenced the first time)
            if (this.wounded && this.handcard.card.Enrage && !this.silenced)
            {
                this.handcard.card.sim_card.onEnrageStop(p, this);
            }

            // reset attack
            this.Angr = this.handcard.card.Attack;
            this.tempAttack = 0; // we dont toutch the adjacent buffs!

            // reset hp and heal it
            if (this.maxHp < this.handcard.card.Health)
            {
                // minion has lower maxHp as his card -> heal his hp
                this.Hp += this.handcard.card.Health - this.maxHp; // heal minion
            }

            this.maxHp = this.handcard.card.Health;
            if (this.Hp > this.maxHp)
            {
                this.Hp = this.maxHp;
            }

            if (!this.silenced)
            {
                // minion WAS not silenced, deactivate his aura
                this.handcard.card.sim_card.onAuraEnds(p, this);
            }

            this.silenced = true;
            this.updateReadyness();
            p.minionGetOrEraseAllAreaBuffs(this, true);
            if (this.own)
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
                p.minionGetControlled(this, !this.own, false);
            }
        }

        /// <summary>
        /// The load enchantments.
        /// </summary>
        /// <param name="enchants">
        /// The enchants.
        /// </param>
        /// <param name="ownPlayerControler">
        /// The own player controler.
        /// </param>
        public void loadEnchantments(List<miniEnch> enchants, int ownPlayerControler)
        {
            foreach (miniEnch me in enchants)
            {
                // deathrattles reborns and destoyings----------------------------------------------
                if (me.CARDID == CardDB.cardIDEnum.CS2_038e)
                {
                    // ancestral spirit
                    this.ancestralspirit++;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_584e)
                {
                    // ancient mage
                    this.spellpower++;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_158e)
                {
                    // soul of the forest
                    this.souloftheforest++;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_128e)
                {
                    // conceal
                    this.concedal = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_063e)
                {
                    // corruption
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.destroyOnOwnTurnStart = true;
                    }
                    else
                    {
                        this.destroyOnEnemyTurnStart = true;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_363e || me.CARDID == CardDB.cardIDEnum.EX1_363e2)
                {
                    // corruption
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.ownBlessingOfWisdom++;
                    }
                    else
                    {
                        this.enemyBlessingOfWisdom++;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.DREAM_05e)
                {
                    // nightmare
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.destroyOnOwnTurnStart = true;
                    }
                    else
                    {
                        this.destroyOnEnemyTurnStart = true;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_316e)
                {
                    // overwhelmingpower
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.destroyOnOwnTurnEnd = true;
                    }
                    else
                    {
                        this.destroyOnEnemyTurnEnd = true;
                    }
                }

                if (me.CARDID == CardDB.cardIDEnum.NEW1_036e)
                {
                    // commanding shout
                    this.cantLowerHPbelowONE = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.NEW1_036e2)
                {
                    // commanding shout
                    this.cantLowerHPbelowONE = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_334e)
                {
                    // Dark Command
                    this.shadowmadnessed = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.FP1_030e)
                {
                    // Necrotic Aura
                    // todo Eure Zauber kosten in diesem Zug (5) mehr.
                }

                if (me.CARDID == CardDB.cardIDEnum.NEW1_029t)
                {
                    // death to millhouse!
                    // todo spells cost (0) this turn!
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_612o)
                {
                    // Power of the Kirin Tor
                    // todo Your next Secret costs (0).
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_084e)
                {
                    // warsongcommander
                    this.charge++;
                }

                if (me.CARDID == CardDB.cardIDEnum.DS1_178e)
                {
                    // rhino
                    this.charge++;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_103e2)
                {
                    // sturmangriff    +2 angriff und ansturm/.
                    this.charge++;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_103e)
                {
                    // sturmangriff    +2 angriff und ansturm/.
                    this.charge++;
                }

                // ancientbuffs-------------------------------------------------
                if (me.CARDID == CardDB.cardIDEnum.EX1_565o)
                {
                    // flametongue
                    this.AdjacentAngr += 2;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_162o)
                {
                    // dire wolf alpha
                    this.AdjacentAngr += 1;
                }

                // tempbuffs-------------------------------------------------
                if (me.CARDID == CardDB.cardIDEnum.CS2_105e)
                {
                    // heldenhafter stoss
                    this.tempAttack += 4;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_570e)
                {
                    // bite
                    this.tempAttack += 4;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_083e)
                {
                    // sharpened
                    this.tempAttack += 1;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_046e)
                {
                    // tempered
                    this.tempAttack += 2;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_188o)
                {
                    // inspiring
                    this.tempAttack += 2;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_045e)
                {
                    // rockbiter
                    this.tempAttack += 3;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_046e)
                {
                    // bloodlust
                    this.tempAttack += 3;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_011o)
                {
                    // Savage Roar
                    this.tempAttack += 2;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_017o)
                {
                    // Claws
                    this.tempAttack += 1;
                }

                if (me.CARDID == CardDB.cardIDEnum.EX1_549o)
                {
                    // bestial wrath
                    this.tempAttack += 2;
                    this.immune = true;
                }

                if (me.CARDID == CardDB.cardIDEnum.CS2_005o)
                {
                    // Claw
                    this.tempAttack += 2;
                }
            }
        }
    }
}
