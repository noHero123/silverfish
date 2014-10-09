// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hrtprozis.cs" company="">
//   
// </copyright>
// <summary>
//   The hero enum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The hero enum.
    /// </summary>
    public enum HeroEnum
    {
        /// <summary>
        /// The none.
        /// </summary>
        None, 

        /// <summary>
        /// The druid.
        /// </summary>
        druid, 

        /// <summary>
        /// The hogger.
        /// </summary>
        hogger, 

        /// <summary>
        /// The hunter.
        /// </summary>
        hunter, 

        /// <summary>
        /// The priest.
        /// </summary>
        priest, 

        /// <summary>
        /// The warlock.
        /// </summary>
        warlock, 

        /// <summary>
        /// The thief.
        /// </summary>
        thief, 

        /// <summary>
        /// The pala.
        /// </summary>
        pala, 

        /// <summary>
        /// The warrior.
        /// </summary>
        warrior, 

        /// <summary>
        /// The shaman.
        /// </summary>
        shaman, 

        /// <summary>
        /// The mage.
        /// </summary>
        mage, 

        /// <summary>
        /// The lordjaraxxus.
        /// </summary>
        lordjaraxxus
    }

    /// <summary>
    /// The hrtprozis.
    /// </summary>
    public class Hrtprozis
    {
        /// <summary>
        /// The attack face hp.
        /// </summary>
        public int attackFaceHp = 15;

        /// <summary>
        /// The own hero fatigue.
        /// </summary>
        public int ownHeroFatigue = 0;

        /// <summary>
        /// The own deck size.
        /// </summary>
        public int ownDeckSize = 30;

        /// <summary>
        /// The enemy deck size.
        /// </summary>
        public int enemyDeckSize = 30;

        /// <summary>
        /// The enemy hero fatigue.
        /// </summary>
        public int enemyHeroFatigue = 0;

        /// <summary>
        /// The own hero entity.
        /// </summary>
        public int ownHeroEntity = -1;

        /// <summary>
        /// The enemy hero entitiy.
        /// </summary>
        public int enemyHeroEntitiy = -1;

        /// <summary>
        /// The roundstart.
        /// </summary>
        public DateTime roundstart = DateTime.Now;

        /// <summary>
        /// The current mana.
        /// </summary>
        public int currentMana = 0;

        /// <summary>
        /// The hero hp.
        /// </summary>
        public int heroHp = 30;

        /// <summary>
        /// The enemy hp.
        /// </summary>
        public int enemyHp = 30;

        /// <summary>
        /// The hero atk.
        /// </summary>
        public int heroAtk = 0;

        /// <summary>
        /// The enemy atk.
        /// </summary>
        public int enemyAtk = 0;

        /// <summary>
        /// The hero defence.
        /// </summary>
        public int heroDefence = 0;

        /// <summary>
        /// The enemy defence.
        /// </summary>
        public int enemyDefence = 0;

        /// <summary>
        /// The ownheroisread.
        /// </summary>
        public bool ownheroisread = false;

        /// <summary>
        /// The own hero num attacks this turn.
        /// </summary>
        public int ownHeroNumAttacksThisTurn = 0;

        /// <summary>
        /// The own hero windfury.
        /// </summary>
        public bool ownHeroWindfury = false;

        /// <summary>
        /// The herofrozen.
        /// </summary>
        public bool herofrozen = false;

        /// <summary>
        /// The enemyfrozen.
        /// </summary>
        public bool enemyfrozen = false;

        /// <summary>
        /// The own secret list.
        /// </summary>
        public List<CardDB.cardIDEnum> ownSecretList = new List<CardDB.cardIDEnum>();

        /// <summary>
        /// The enemy secret count.
        /// </summary>
        public int enemySecretCount = 0;

        /// <summary>
        /// The heroname.
        /// </summary>
        public HeroEnum heroname = HeroEnum.druid;

        /// <summary>
        /// The enemy heroname.
        /// </summary>
        public HeroEnum enemyHeroname = HeroEnum.druid;

        /// <summary>
        /// The hero ability.
        /// </summary>
        public CardDB.Card heroAbility;

        /// <summary>
        /// The own abilityis ready.
        /// </summary>
        public bool ownAbilityisReady = false;

        /// <summary>
        /// The enemy ability.
        /// </summary>
        public CardDB.Card enemyAbility;

        /// <summary>
        /// The num options played this turn.
        /// </summary>
        public int numOptionsPlayedThisTurn = 0;

        /// <summary>
        /// The num minions played this turn.
        /// </summary>
        public int numMinionsPlayedThisTurn = 0;

        /// <summary>
        /// The cards played this turn.
        /// </summary>
        public int cardsPlayedThisTurn = 0;

        /// <summary>
        /// The ueberladung.
        /// </summary>
        public int ueberladung = 0;

        /// <summary>
        /// The own max mana.
        /// </summary>
        public int ownMaxMana = 0;

        /// <summary>
        /// The enemy max mana.
        /// </summary>
        public int enemyMaxMana = 0;

        /// <summary>
        /// The enemy weapon durability.
        /// </summary>
        public int enemyWeaponDurability = 0;

        /// <summary>
        /// The enemy weapon attack.
        /// </summary>
        public int enemyWeaponAttack = 0;

        /// <summary>
        /// The enemy hero weapon.
        /// </summary>
        public CardDB.cardName enemyHeroWeapon = CardDB.cardName.unknown;

        /// <summary>
        /// The hero weapon durability.
        /// </summary>
        public int heroWeaponDurability = 0;

        /// <summary>
        /// The hero weapon attack.
        /// </summary>
        public int heroWeaponAttack = 0;

        /// <summary>
        /// The own hero weapon.
        /// </summary>
        public CardDB.cardName ownHeroWeapon = CardDB.cardName.unknown;

        /// <summary>
        /// The hero immune to damage while attacking.
        /// </summary>
        public bool heroImmuneToDamageWhileAttacking = false;

        /// <summary>
        /// The hero immune.
        /// </summary>
        public bool heroImmune = false;

        /// <summary>
        /// The enemy hero immune.
        /// </summary>
        public bool enemyHeroImmune = false;

        /// <summary>
        /// The own minions.
        /// </summary>
        public List<Minion> ownMinions = new List<Minion>();

        /// <summary>
        /// The enemy minions.
        /// </summary>
        public List<Minion> enemyMinions = new List<Minion>();

        /// <summary>
        /// The own hero.
        /// </summary>
        public Minion ownHero = new Minion();

        /// <summary>
        /// The enemy hero.
        /// </summary>
        public Minion enemyHero = new Minion();

        /// <summary>
        /// The help.
        /// </summary>
        private Helpfunctions help = Helpfunctions.Instance;

        // Imagecomparer icom = Imagecomparer.Instance;
        // HrtNumbers hrtnumbers = HrtNumbers.Instance;
        /// <summary>
        /// The cdb.
        /// </summary>
        private CardDB cdb = CardDB.Instance;

        /// <summary>
        /// The own player controller.
        /// </summary>
        private int ownPlayerController = 0;

        /// <summary>
        /// The instance.
        /// </summary>
        private static Hrtprozis instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Hrtprozis Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Hrtprozis();
                }

                return instance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Hrtprozis"/> class from being created.
        /// </summary>
        private Hrtprozis()
        {
        }

        /// <summary>
        /// The set attack face hp.
        /// </summary>
        /// <param name="hp">
        /// The hp.
        /// </param>
        public void setAttackFaceHP(int hp)
        {
            this.attackFaceHp = hp;
        }

        /// <summary>
        /// The clear all.
        /// </summary>
        public void clearAll()
        {
            this.ownHeroEntity = -1;
            this.enemyHeroEntitiy = -1;
            this.currentMana = 0;
            this.heroHp = 30;
            this.enemyHp = 30;
            this.heroAtk = 0;
            this.enemyAtk = 0;
            this.heroDefence = 0;
            this.enemyDefence = 0;
            this.ownheroisread = false;
            this.ownAbilityisReady = false;
            this.ownHeroNumAttacksThisTurn = 0;
            this.ownHeroWindfury = false;
            this.ownSecretList.Clear();
            this.enemySecretCount = 0;
            this.heroname = HeroEnum.druid;
            this.enemyHeroname = HeroEnum.druid;
            this.heroAbility = new CardDB.Card();
            this.enemyAbility = new CardDB.Card();
            this.herofrozen = false;
            this.enemyfrozen = false;
            this.numMinionsPlayedThisTurn = 0;
            this.cardsPlayedThisTurn = 0;
            this.ueberladung = 0;
            this.ownMaxMana = 0;
            this.enemyMaxMana = 0;
            this.enemyWeaponDurability = 0;
            this.enemyWeaponAttack = 0;
            this.heroWeaponDurability = 0;
            this.heroWeaponAttack = 0;
            this.heroImmuneToDamageWhileAttacking = false;
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            this.heroImmune = false;
            this.enemyHeroImmune = false;
            this.ownHeroWeapon = CardDB.cardName.unknown;
            this.enemyHeroWeapon = CardDB.cardName.unknown;
        }

        /// <summary>
        /// The set own player.
        /// </summary>
        /// <param name="player">
        /// The player.
        /// </param>
        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }

        /// <summary>
        /// The get own controller.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int getOwnController()
        {
            return this.ownPlayerController;
        }

        /// <summary>
        /// The hero i dto name.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string heroIDtoName(string s)
        {
            string retval = "druid";

            if (s == "XXX_040")
            {
                retval = "hogger";
            }

            if (s == "HERO_05")
            {
                retval = "hunter";
            }

            if (s == "HERO_09")
            {
                retval = "priest";
            }

            if (s == "HERO_06")
            {
                retval = "druid";
            }

            if (s == "HERO_07")
            {
                retval = "warlock";
            }

            if (s == "HERO_03")
            {
                retval = "thief";
            }

            if (s == "HERO_04")
            {
                retval = "pala";
            }

            if (s == "HERO_01")
            {
                retval = "warrior";
            }

            if (s == "HERO_02")
            {
                retval = "shaman";
            }

            if (s == "HERO_08")
            {
                retval = "mage";
            }

            if (s == "EX1_323h")
            {
                retval = "lordjaraxxus";
            }

            return retval;
        }

        /// <summary>
        /// The hero nameto enum.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="HeroEnum"/>.
        /// </returns>
        public HeroEnum heroNametoEnum(string s)
        {
            if (s == "hogger")
            {
                return HeroEnum.hogger;
            }

            if (s == "hunter")
            {
                return HeroEnum.hunter;
            }

            if (s == "priest")
            {
                return HeroEnum.priest;
            }

            if (s == "druid")
            {
                return HeroEnum.druid;
            }

            if (s == "warlock")
            {
                return HeroEnum.warlock;
            }

            if (s == "thief")
            {
                return HeroEnum.thief;
            }

            if (s == "pala")
            {
                return HeroEnum.pala;
            }

            if (s == "warrior")
            {
                return HeroEnum.warrior;
            }

            if (s == "shaman")
            {
                return HeroEnum.shaman;
            }

            if (s == "mage")
            {
                return HeroEnum.mage;
            }

            if (s == "lordjaraxxus")
            {
                return HeroEnum.lordjaraxxus;
            }

            return HeroEnum.None;
        }

        /// <summary>
        /// The update minions.
        /// </summary>
        /// <param name="om">
        /// The om.
        /// </param>
        /// <param name="em">
        /// The em.
        /// </param>
        public void updateMinions(List<Minion> om, List<Minion> em)
        {
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            foreach (var item in om)
            {
                this.ownMinions.Add(new Minion(item));
            }

            // this.ownMinions.AddRange(om);
            foreach (var item in em)
            {
                this.enemyMinions.Add(new Minion(item));
            }

            // this.enemyMinions.AddRange(em);

            // sort them 
            this.updatePositions();
        }

        /// <summary>
        /// The update secret stuff.
        /// </summary>
        /// <param name="ownsecs">
        /// The ownsecs.
        /// </param>
        /// <param name="numEnemSec">
        /// The num enem sec.
        /// </param>
        public void updateSecretStuff(List<string> ownsecs, int numEnemSec)
        {
            this.ownSecretList.Clear();
            foreach (string s in ownsecs)
            {
                this.ownSecretList.Add(CardDB.Instance.cardIdstringToEnum(s));
            }

            this.enemySecretCount = numEnemSec;
        }

        /// <summary>
        /// The update player.
        /// </summary>
        /// <param name="maxmana">
        /// The maxmana.
        /// </param>
        /// <param name="currentmana">
        /// The currentmana.
        /// </param>
        /// <param name="cardsplayedthisturn">
        /// The cardsplayedthisturn.
        /// </param>
        /// <param name="numMinionsplayed">
        /// The num minionsplayed.
        /// </param>
        /// <param name="optionsPlayedThisTurn">
        /// The options played this turn.
        /// </param>
        /// <param name="recall">
        /// The recall.
        /// </param>
        /// <param name="heroentity">
        /// The heroentity.
        /// </param>
        /// <param name="enemyentity">
        /// The enemyentity.
        /// </param>
        public void updatePlayer(
            int maxmana, 
            int currentmana, 
            int cardsplayedthisturn, 
            int numMinionsplayed, 
            int optionsPlayedThisTurn, 
            int recall, 
            int heroentity, 
            int enemyentity)
        {
            this.currentMana = currentmana;
            this.ownMaxMana = maxmana;
            this.cardsPlayedThisTurn = cardsplayedthisturn;
            this.numMinionsPlayedThisTurn = numMinionsplayed;
            this.ueberladung = recall;
            this.ownHeroEntity = heroentity;
            this.enemyHeroEntitiy = enemyentity;
            this.numOptionsPlayedThisTurn = optionsPlayedThisTurn;
        }

        /// <summary>
        /// The update own hero.
        /// </summary>
        /// <param name="weapon">
        /// The weapon.
        /// </param>
        /// <param name="watt">
        /// The watt.
        /// </param>
        /// <param name="wdur">
        /// The wdur.
        /// </param>
        /// <param name="heron">
        /// The heron.
        /// </param>
        /// <param name="hab">
        /// The hab.
        /// </param>
        /// <param name="habrdy">
        /// The habrdy.
        /// </param>
        /// <param name="Hero">
        /// The hero.
        /// </param>
        public void updateOwnHero(
            string weapon, 
            int watt, 
            int wdur, 
            string heron, 
            CardDB.Card hab, 
            bool habrdy, 
            Minion Hero)
        {
            this.ownHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.heroWeaponAttack = watt;
            this.heroWeaponDurability = wdur;

            this.heroname = this.heroNametoEnum(heron);

            this.heroAbility = hab;
            this.ownAbilityisReady = habrdy;

            this.ownHero = new Minion(Hero);
            this.ownHero.updateReadyness();
        }

        /// <summary>
        /// The update enemy hero.
        /// </summary>
        /// <param name="weapon">
        /// The weapon.
        /// </param>
        /// <param name="weaponAttack">
        /// The weapon attack.
        /// </param>
        /// <param name="weaponDurability">
        /// The weapon durability.
        /// </param>
        /// <param name="heron">
        /// The heron.
        /// </param>
        /// <param name="enemMaxMana">
        /// The enem max mana.
        /// </param>
        /// <param name="eab">
        /// The eab.
        /// </param>
        /// <param name="enemyHero">
        /// The enemy hero.
        /// </param>
        public void updateEnemyHero(
            string weapon, 
            int weaponAttack, 
            int weaponDurability, 
            string heron, 
            int enemMaxMana, 
            CardDB.Card eab, 
            Minion enemyHero)
        {
            this.enemyHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.enemyWeaponAttack = weaponAttack;
            this.enemyWeaponDurability = weaponDurability;

            this.enemyMaxMana = enemMaxMana;

            this.enemyHeroname = this.heroNametoEnum(heron);

            this.enemyAbility = eab;

            this.enemyHero = new Minion(enemyHero);
        }

        /// <summary>
        /// The update fatigue stats.
        /// </summary>
        /// <param name="ods">
        /// The ods.
        /// </param>
        /// <param name="ohf">
        /// The ohf.
        /// </param>
        /// <param name="eds">
        /// The eds.
        /// </param>
        /// <param name="ehf">
        /// The ehf.
        /// </param>
        public void updateFatigueStats(int ods, int ohf, int eds, int ehf)
        {
            this.ownDeckSize = ods;
            this.ownHeroFatigue = ohf;
            this.enemyDeckSize = eds;
            this.enemyHeroFatigue = ehf;
        }

        /// <summary>
        /// The update positions.
        /// </summary>
        public void updatePositions()
        {
            this.ownMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            this.enemyMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            int i = 0;
            foreach (Minion m in this.ownMinions)
            {
                i++;
                m.zonepos = i;
            }

            i = 0;
            foreach (Minion m in this.enemyMinions)
            {
                i++;
                m.zonepos = i;
            }

            /*List<Minion> temp = new List<Minion>();
            temp.AddRange(ownMinions);
            this.ownMinions.Clear();
            this.ownMinions.AddRange(temp.OrderBy(x => x.zonepos).ToList());
            temp.Clear();
            temp.AddRange(enemyMinions);
            this.enemyMinions.Clear();
            this.enemyMinions.AddRange(temp.OrderBy(x => x.zonepos).ToList());*/
        }

        /// <summary>
        /// The create new minion.
        /// </summary>
        /// <param name="hc">
        /// The hc.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Minion"/>.
        /// </returns>
        private Minion createNewMinion(Handmanager.Handcard hc, int id)
        {
            Minion m = new Minion();
            m.handcard = new Handmanager.Handcard(hc);
            m.zonepos = id + 1;
            m.entitiyID = hc.entity;
            m.Angr = hc.card.Attack;
            m.Hp = hc.card.Health;
            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;

            if (hc.card.windfury)
            {
                m.windfury = true;
            }

            if (hc.card.tank)
            {
                m.taunt = true;
            }

            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = 1;
            }

            if (hc.card.Shield)
            {
                m.divineshild = true;
            }

            if (hc.card.poisionous)
            {
                m.poisonous = true;
            }

            if (hc.card.Stealth)
            {
                m.stealth = true;
            }

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }

            return m;
        }

        /// <summary>
        /// The print hero.
        /// </summary>
        /// <param name="writetobuffer">
        /// The writetobuffer.
        /// </param>
        public void printHero(bool writetobuffer = false)
        {
            this.help.logg("player:");
            this.help.logg(
                this.numMinionsPlayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.ueberladung + " "
                + this.ownPlayerController);

            this.help.logg("ownhero:");
            this.help.logg(
                this.heroname + " " + this.ownHero.Hp + " " + this.ownHero.maxHp + " " + this.ownHero.armor + " "
                + this.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + this.ownHero.entitiyID + " "
                + this.ownHero.Ready + " " + this.ownHero.numAttacksThisTurn + " " + this.ownHero.frozen + " "
                + this.ownHero.Angr + " " + this.ownHero.tempAttack);
            this.help.logg(
                "weapon: " + this.heroWeaponAttack + " " + this.heroWeaponDurability + " " + this.ownHeroWeapon);
            this.help.logg("ability: " + this.ownAbilityisReady + " " + this.heroAbility.cardIDenum);
            string secs = string.Empty;
            foreach (CardDB.cardIDEnum sec in this.ownSecretList)
            {
                secs += sec + " ";
            }

            this.help.logg("osecrets: " + secs);
            this.help.logg("enemyhero:");
            this.help.logg(
                this.enemyHeroname + " " + this.enemyHero.Hp + " " + this.enemyHero.maxHp + " " + this.enemyHero.armor
                + " " + this.enemyHero.frozen + " " + this.enemyHero.immune + " " + this.enemyHero.entitiyID);
            this.help.logg(
                "weapon: " + this.enemyWeaponAttack + " " + this.enemyWeaponDurability + " " + this.enemyHeroWeapon);
            this.help.logg("ability: " + "true" + " " + this.enemyAbility.cardIDenum);
            this.help.logg(
                "fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " "
                + this.enemyHeroFatigue);

            if (writetobuffer)
            {
                this.help.writeToBuffer("player:");
                this.help.writeToBuffer(
                    this.numMinionsPlayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.ueberladung + " "
                    + this.ownPlayerController);

                this.help.writeToBuffer("ownhero:");
                this.help.writeToBuffer(
                    this.heroname + " " + this.ownHero.Hp + " " + this.ownHero.maxHp + " " + this.ownHero.armor + " "
                    + this.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + this.ownHero.entitiyID + " "
                    + this.ownHero.Ready + " " + this.ownHero.numAttacksThisTurn + " " + this.ownHero.frozen + " "
                    + this.ownHero.Angr + " " + this.ownHero.tempAttack);
                this.help.writeToBuffer(
                    "weapon: " + this.heroWeaponAttack + " " + this.heroWeaponDurability + " " + this.ownHeroWeapon);
                this.help.writeToBuffer("ability: " + this.ownAbilityisReady + " " + this.heroAbility.cardIDenum);
                secs = string.Empty;
                foreach (CardDB.cardIDEnum sec in this.ownSecretList)
                {
                    secs += sec + " ";
                }

                this.help.writeToBuffer("osecrets: " + secs);
                this.help.writeToBuffer("enemyhero:");
                this.help.writeToBuffer(
                    this.enemyHeroname + " " + this.enemyHero.Hp + " " + this.enemyHero.maxHp + " "
                    + this.enemyHero.armor + " " + this.enemyHero.frozen + " " + this.enemyHero.immune + " "
                    + this.enemyHero.entitiyID);
                this.help.writeToBuffer(
                    "weapon: " + this.enemyWeaponAttack + " " + this.enemyWeaponDurability + " " + this.enemyHeroWeapon);
                this.help.writeToBuffer("ability: " + "true" + " " + this.enemyAbility.cardIDenum);
                this.help.writeToBuffer(
                    "fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " "
                    + this.enemyHeroFatigue);
            }
        }

        /// <summary>
        /// The print own minions.
        /// </summary>
        /// <param name="writetobuffer">
        /// The writetobuffer.
        /// </param>
        public void printOwnMinions(bool writetobuffer = false)
        {
            this.help.logg("OwnMinions:");
            if (writetobuffer)
            {
                this.help.writeToBuffer("OwnMinions:");
            }

            foreach (Minion m in this.ownMinions)
            {
                string mini = m.name + " " + m.handcard.card.cardIDenum + " zp:" + m.zonepos + " e:" + m.entitiyID
                              + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready + " natt:"
                              + m.numAttacksThisTurn;
                if (m.exhausted)
                {
                    mini += " ex";
                }

                if (m.taunt)
                {
                    mini += " tnt";
                }

                if (m.frozen)
                {
                    mini += " frz";
                }

                if (m.silenced)
                {
                    mini += " silenced";
                }

                if (m.divineshild)
                {
                    mini += " divshield";
                }

                if (m.playedThisTurn)
                {
                    mini += " ptt";
                }

                if (m.windfury)
                {
                    mini += " wndfr";
                }

                if (m.stealth)
                {
                    mini += " stlth";
                }

                if (m.poisonous)
                {
                    mini += " poi";
                }

                if (m.immune)
                {
                    mini += " imm";
                }

                if (m.concedal)
                {
                    mini += " cncdl";
                }

                if (m.destroyOnOwnTurnStart)
                {
                    mini += " dstrOwnTrnStrt";
                }

                if (m.destroyOnOwnTurnEnd)
                {
                    mini += " dstrOwnTrnnd";
                }

                if (m.destroyOnEnemyTurnStart)
                {
                    mini += " dstrEnmTrnStrt";
                }

                if (m.destroyOnEnemyTurnEnd)
                {
                    mini += " dstrEnmTrnnd";
                }

                if (m.shadowmadnessed)
                {
                    mini += " shdwmdnssd";
                }

                if (m.cantLowerHPbelowONE)
                {
                    mini += " cantLowerHpBelowOne";
                }

                if (m.charge >= 1)
                {
                    mini += " chrg(" + m.charge + ")";
                }

                if (m.AdjacentAngr >= 1)
                {
                    mini += " adjaattk(" + m.AdjacentAngr + ")";
                }

                if (m.tempAttack >= 1)
                {
                    mini += " tmpattck(" + m.tempAttack + ")";
                }

                if (m.spellpower >= 1)
                {
                    mini += " spllpwr(" + m.spellpower + ")";
                }

                if (m.ancestralspirit >= 1)
                {
                    mini += " ancstrl(" + m.ancestralspirit + ")";
                }

                if (m.ownBlessingOfWisdom >= 1)
                {
                    mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
                }

                if (m.enemyBlessingOfWisdom >= 1)
                {
                    mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
                }

                if (m.souloftheforest >= 1)
                {
                    mini += " souloffrst(" + m.souloftheforest + ")";
                }

                this.help.logg(mini);
                if (writetobuffer)
                {
                    this.help.writeToBuffer(mini);
                }
            }
        }

        /// <summary>
        /// The print enemy minions.
        /// </summary>
        /// <param name="writetobuffer">
        /// The writetobuffer.
        /// </param>
        public void printEnemyMinions(bool writetobuffer = false)
        {
            this.help.logg("EnemyMinions:");
            if (writetobuffer)
            {
                this.help.writeToBuffer("EnemyMinions:");
            }

            foreach (Minion m in this.enemyMinions)
            {
                string mini = m.name + " " + m.handcard.card.cardIDenum + " zp:" + m.zonepos + " e:" + m.entitiyID
                              + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready;
                    
                    // +" natt:" + m.numAttacksThisTurn;
                if (m.exhausted)
                {
                    mini += " ex";
                }

                if (m.taunt)
                {
                    mini += " tnt";
                }

                if (m.frozen)
                {
                    mini += " frz";
                }

                if (m.silenced)
                {
                    mini += " silenced";
                }

                if (m.divineshild)
                {
                    mini += " divshield";
                }

                if (m.playedThisTurn)
                {
                    mini += " ptt";
                }

                if (m.windfury)
                {
                    mini += " wndfr";
                }

                if (m.stealth)
                {
                    mini += " stlth";
                }

                if (m.poisonous)
                {
                    mini += " poi";
                }

                if (m.immune)
                {
                    mini += " imm";
                }

                if (m.concedal)
                {
                    mini += " cncdl";
                }

                if (m.destroyOnOwnTurnStart)
                {
                    mini += " dstrOwnTrnStrt";
                }

                if (m.destroyOnOwnTurnEnd)
                {
                    mini += " dstrOwnTrnnd";
                }

                if (m.destroyOnEnemyTurnStart)
                {
                    mini += " dstrEnmTrnStrt";
                }

                if (m.destroyOnEnemyTurnEnd)
                {
                    mini += " dstrEnmTrnnd";
                }

                if (m.shadowmadnessed)
                {
                    mini += " shdwmdnssd";
                }

                if (m.cantLowerHPbelowONE)
                {
                    mini += " cantLowerHpBelowOne";
                }

                if (m.charge >= 1)
                {
                    mini += " chrg(" + m.charge + ")";
                }

                if (m.AdjacentAngr >= 1)
                {
                    mini += " adjaattk(" + m.AdjacentAngr + ")";
                }

                if (m.tempAttack >= 1)
                {
                    mini += " tmpattck(" + m.tempAttack + ")";
                }

                if (m.spellpower >= 1)
                {
                    mini += " spllpwr(" + m.spellpower + ")";
                }

                if (m.ancestralspirit >= 1)
                {
                    mini += " ancstrl(" + m.ancestralspirit + ")";
                }

                if (m.ownBlessingOfWisdom >= 1)
                {
                    mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
                }

                if (m.enemyBlessingOfWisdom >= 1)
                {
                    mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
                }

                if (m.souloftheforest >= 1)
                {
                    mini += " souloffrst(" + m.souloftheforest + ")";
                }

                this.help.logg(mini);
                if (writetobuffer)
                {
                    this.help.writeToBuffer(mini);
                }
            }
        }
    }
}
