namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public enum HeroEnum
    {
        None,
        druid,
        hogger,
        hunter,
        priest,
        warlock,
        thief,
        pala,
        warrior,
        shaman,
        mage,
        lordjaraxxus
    }

    public class Hrtprozis
    {


        public int attackFaceHp = 15;
        public int ownHeroFatigue = 0;
        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int enemyHeroFatigue = 0;

        public int ownHeroEntity = -1;
        public int enemyHeroEntitiy = -1;
        public DateTime roundstart = DateTime.Now;
        public int currentMana = 0;

        public int heroHp = 30, enemyHp = 30;
        public int heroAtk = 0, enemyAtk = 0;
        public int heroDefence = 0, enemyDefence = 0;
        public bool ownheroisread = false;
        public int ownHeroNumAttacksThisTurn = 0;
        public bool ownHeroWindfury = false;
        public bool herofrozen = false;
        public bool enemyfrozen = false;

        public List<CardDB.cardIDEnum> ownSecretList = new List<CardDB.cardIDEnum>();
        public int enemySecretCount = 0;



        public HeroEnum heroname = HeroEnum.druid, enemyHeroname = HeroEnum.druid;
        public CardDB.Card heroAbility;
        public bool ownAbilityisReady = false;
        public CardDB.Card enemyAbility;
        public int numOptionsPlayedThisTurn = 0;
        public int numMinionsPlayedThisTurn = 0;

        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0;

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int enemyWeaponDurability = 0;
        public int enemyWeaponAttack = 0;
        public CardDB.cardName enemyHeroWeapon = CardDB.cardName.unknown;

        public int heroWeaponDurability = 0;
        public int heroWeaponAttack = 0;
        public CardDB.cardName ownHeroWeapon = CardDB.cardName.unknown;

        public bool heroImmuneToDamageWhileAttacking = false;
        public bool heroImmune = false;
        public bool enemyHeroImmune = false;


        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public Minion ownHero = new Minion();
        public Minion enemyHero = new Minion();

        Helpfunctions help = Helpfunctions.Instance;
        //Imagecomparer icom = Imagecomparer.Instance;
        //HrtNumbers hrtnumbers = HrtNumbers.Instance;
        CardDB cdb = CardDB.Instance;

        private int ownPlayerController = 0;

        private static Hrtprozis instance;

        public static Hrtprozis Instance
        {
            get
            {
                return instance ?? (instance = new Hrtprozis());
            }
        }



        private Hrtprozis()
        {
        }

        public void setAttackFaceHP(int hp)
        {
            this.attackFaceHp = hp;
        }

        public void clearAll()
        {
            ownHeroEntity = -1;
            enemyHeroEntitiy = -1;
            currentMana = 0;
            heroHp = 30;
            enemyHp = 30;
            heroAtk = 0;
            enemyAtk = 0;
            heroDefence = 0; enemyDefence = 0;
            ownheroisread = false;
            ownAbilityisReady = false;
            ownHeroNumAttacksThisTurn = 0;
            ownHeroWindfury = false;
            ownSecretList.Clear();
            enemySecretCount = 0;
            heroname = HeroEnum.druid;
            enemyHeroname = HeroEnum.druid;
            heroAbility = new CardDB.Card();
            enemyAbility = new CardDB.Card();
            herofrozen = false;
            enemyfrozen = false;
            numMinionsPlayedThisTurn = 0;
            cardsPlayedThisTurn = 0;
            ueberladung = 0;
            ownMaxMana = 0;
            enemyMaxMana = 0;
            enemyWeaponDurability = 0;
            enemyWeaponAttack = 0;
            heroWeaponDurability = 0;
            heroWeaponAttack = 0;
            heroImmuneToDamageWhileAttacking = false;
            ownMinions.Clear();
            enemyMinions.Clear();
            heroImmune = false;
            enemyHeroImmune = false;
            this.ownHeroWeapon = CardDB.cardName.unknown;
            this.enemyHeroWeapon = CardDB.cardName.unknown;
        }


        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }

        public int getOwnController()
        {
            return this.ownPlayerController;
        }

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


        public void updateMinions(List<Minion> om, List<Minion> em)
        {
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            foreach (var item in om)
            {
                this.ownMinions.Add(new Minion(item));
            }
            //this.ownMinions.AddRange(om);
            foreach (var item in em)
            {
                this.enemyMinions.Add(new Minion(item));
            }
            //this.enemyMinions.AddRange(em);

            //sort them 
            updatePositions();
        }

        public void updateSecretStuff(List<string> ownsecs, int numEnemSec)
        {
            this.ownSecretList.Clear();
            foreach (string s in ownsecs)
            {
                this.ownSecretList.Add(CardDB.Instance.cardIdstringToEnum(s));
            }
            this.enemySecretCount = numEnemSec;
        }

        public void updatePlayer(int maxmana, int currentmana, int cardsplayedthisturn, int numMinionsplayed, int optionsPlayedThisTurn, int recall, int heroentity, int enemyentity)
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

        public void updateOwnHero(string weapon, int watt, int wdur, string heron, CardDB.Card hab, bool habrdy, Minion Hero)
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

        public void updateEnemyHero(string weapon, int weaponAttack, int weaponDurability, string heron, int enemMaxMana, CardDB.Card eab, Minion enemyHero)
        {
            this.enemyHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.enemyWeaponAttack = weaponAttack;
            this.enemyWeaponDurability = weaponDurability;

            this.enemyMaxMana = enemMaxMana;

            this.enemyHeroname = this.heroNametoEnum(heron);

            this.enemyAbility = eab;

            this.enemyHero = new Minion(enemyHero);

        }

        public void updateFatigueStats(int ods, int ohf, int eds, int ehf)
        {
            this.ownDeckSize = ods;
            this.ownHeroFatigue = ohf;
            this.enemyDeckSize = eds;
            this.enemyHeroFatigue = ehf;
        }

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

        private Minion createNewMinion(Handmanager.Handcard hc, int id)
        {
            Minion m = new Minion
            {
                handcard = new Handmanager.Handcard(hc),
                zonepos = id + 1,
                entitiyID = hc.entity,
                Angr = hc.card.Attack,
                Hp = hc.card.Health,
                maxHp = hc.card.Health,
                name = hc.card.name,
                playedThisTurn = true,
                numAttacksThisTurn = 0
            };


            if (hc.card.windfury) m.windfury = true;
            if (hc.card.tank) m.taunt = true;
            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = 1;
            }
            if (hc.card.Shield) m.divineshild = true;
            if (hc.card.poisionous) m.poisonous = true;

            if (hc.card.Stealth) m.stealth = true;

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            return m;
        }


        public void printHero(bool writetobuffer = false)
        {
            help.logg("player:");
            help.logg(this.numMinionsPlayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.ueberladung + " " + this.ownPlayerController);

            help.logg("ownhero:");
            help.logg(this.heroname + " " + this.ownHero.Hp + " " + this.ownHero.maxHp + " " + this.ownHero.armor + " " + this.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + this.ownHero.entitiyID + " " + this.ownHero.Ready + " " + this.ownHero.numAttacksThisTurn + " " + this.ownHero.frozen + " " + this.ownHero.Angr + " " + this.ownHero.tempAttack);
            help.logg("weapon: " + heroWeaponAttack + " " + heroWeaponDurability + " " + ownHeroWeapon);
            help.logg("ability: " + this.ownAbilityisReady + " " + this.heroAbility.cardIDenum);
            string secs = "";
            foreach (CardDB.cardIDEnum sec in this.ownSecretList)
            {
                secs += sec + " ";
            }
            help.logg("osecrets: " + secs);
            help.logg("enemyhero:");
            help.logg(this.enemyHeroname + " " + this.enemyHero.Hp + " " + this.enemyHero.maxHp + " " + this.enemyHero.armor + " " + this.enemyHero.frozen + " " + this.enemyHero.immune + " " + this.enemyHero.entitiyID);
            help.logg("weapon: " + this.enemyWeaponAttack + " " + this.enemyWeaponDurability + " " + this.enemyHeroWeapon);
            help.logg("ability: " + "true" + " " + this.enemyAbility.cardIDenum);
            help.logg("fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " " + this.enemyHeroFatigue);

            if (writetobuffer)
            {
                help.writeToBuffer("player:");
                help.writeToBuffer(this.numMinionsPlayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.ueberladung + " " + this.ownPlayerController);

                help.writeToBuffer("ownhero:");
                help.writeToBuffer(this.heroname + " " + this.ownHero.Hp + " " + this.ownHero.maxHp + " " + this.ownHero.armor + " " + this.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + this.ownHero.entitiyID + " " + this.ownHero.Ready + " " + this.ownHero.numAttacksThisTurn + " " + this.ownHero.frozen + " " + this.ownHero.Angr + " " + this.ownHero.tempAttack);
                help.writeToBuffer("weapon: " + heroWeaponAttack + " " + heroWeaponDurability + " " + ownHeroWeapon);
                help.writeToBuffer("ability: " + this.ownAbilityisReady + " " + this.heroAbility.cardIDenum);
                secs = "";
                foreach (CardDB.cardIDEnum sec in this.ownSecretList)
                {
                    secs += sec + " ";
                }
                help.writeToBuffer("osecrets: " + secs);
                help.writeToBuffer("enemyhero:");
                help.writeToBuffer(this.enemyHeroname + " " + this.enemyHero.Hp + " " + this.enemyHero.maxHp + " " + this.enemyHero.armor + " " + this.enemyHero.frozen + " " + this.enemyHero.immune + " " + this.enemyHero.entitiyID);
                help.writeToBuffer("weapon: " + this.enemyWeaponAttack + " " + this.enemyWeaponDurability + " " + this.enemyHeroWeapon);
                help.writeToBuffer("ability: " + "true" + " " + this.enemyAbility.cardIDenum);
                help.writeToBuffer("fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " " + this.enemyHeroFatigue);
            }
        }


        public void printOwnMinions(bool writetobuffer = false)
        {
            help.logg("OwnMinions:");
            if (writetobuffer) help.writeToBuffer("OwnMinions:");
            foreach (Minion m in this.ownMinions)
            {
                string mini = m.name + " " + m.handcard.card.cardIDenum + " zp:" + m.zonepos + " e:" + m.entitiyID + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready + " natt:" + m.numAttacksThisTurn;
                if (m.exhausted) mini += " ex";
                if (m.taunt) mini += " tnt";
                if (m.frozen) mini += " frz";
                if (m.silenced) mini += " silenced";
                if (m.divineshild) mini += " divshield";
                if (m.playedThisTurn) mini += " ptt";
                if (m.windfury) mini += " wndfr";
                if (m.stealth) mini += " stlth";
                if (m.poisonous) mini += " poi";
                if (m.immune) mini += " imm";
                if (m.concedal) mini += " cncdl";
                if (m.destroyOnOwnTurnStart) mini += " dstrOwnTrnStrt";
                if (m.destroyOnOwnTurnEnd) mini += " dstrOwnTrnnd";
                if (m.destroyOnEnemyTurnStart) mini += " dstrEnmTrnStrt";
                if (m.destroyOnEnemyTurnEnd) mini += " dstrEnmTrnnd";
                if (m.shadowmadnessed) mini += " shdwmdnssd";
                if (m.cantLowerHPbelowONE) mini += " cantLowerHpBelowOne";
                if (m.cantBeTargetedBySpellsOrHeroPowers) mini += " canttarget";

                if (m.charge >= 1) mini += " chrg(" + m.charge + ")";
                if (m.AdjacentAngr >= 1) mini += " adjaattk(" + m.AdjacentAngr + ")";
                if (m.tempAttack >= 1) mini += " tmpattck(" + m.tempAttack + ")";
                if (m.spellpower >= 1) mini += " spllpwr(" + m.spellpower + ")";

                if (m.ancestralspirit >= 1) mini += " ancstrl(" + m.ancestralspirit + ")";
                if (m.ownBlessingOfWisdom >= 1) mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
                if (m.enemyBlessingOfWisdom >= 1) mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
                if (m.souloftheforest >= 1) mini += " souloffrst(" + m.souloftheforest + ")";




                help.logg(mini);
                if (writetobuffer) help.writeToBuffer(mini);
            }

        }

        public void printEnemyMinions(bool writetobuffer = false)
        {
            help.logg("EnemyMinions:");
            if (writetobuffer) help.writeToBuffer("EnemyMinions:");
            foreach (Minion m in this.enemyMinions)
            {
                string mini = m.name + " " + m.handcard.card.cardIDenum + " zp:" + m.zonepos + " e:" + m.entitiyID + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready;// +" natt:" + m.numAttacksThisTurn;
                if (m.exhausted) mini += " ex";
                if (m.taunt) mini += " tnt";
                if (m.frozen) mini += " frz";
                if (m.silenced) mini += " silenced";
                if (m.divineshild) mini += " divshield";
                if (m.playedThisTurn) mini += " ptt";
                if (m.windfury) mini += " wndfr";
                if (m.stealth) mini += " stlth";
                if (m.poisonous) mini += " poi";
                if (m.immune) mini += " imm";
                if (m.concedal) mini += " cncdl";
                if (m.destroyOnOwnTurnStart) mini += " dstrOwnTrnStrt";
                if (m.destroyOnOwnTurnEnd) mini += " dstrOwnTrnnd";
                if (m.destroyOnEnemyTurnStart) mini += " dstrEnmTrnStrt";
                if (m.destroyOnEnemyTurnEnd) mini += " dstrEnmTrnnd";
                if (m.shadowmadnessed) mini += " shdwmdnssd";
                if (m.cantLowerHPbelowONE) mini += " cantLowerHpBelowOne";
                if (m.cantBeTargetedBySpellsOrHeroPowers) mini += " canttarget";

                if (m.charge >= 1) mini += " chrg(" + m.charge + ")";
                if (m.AdjacentAngr >= 1) mini += " adjaattk(" + m.AdjacentAngr + ")";
                if (m.tempAttack >= 1) mini += " tmpattck(" + m.tempAttack + ")";
                if (m.spellpower >= 1) mini += " spllpwr(" + m.spellpower + ")";

                if (m.ancestralspirit >= 1) mini += " ancstrl(" + m.ancestralspirit + ")";
                if (m.ownBlessingOfWisdom >= 1) mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
                if (m.enemyBlessingOfWisdom >= 1) mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
                if (m.souloftheforest >= 1) mini += " souloffrst(" + m.souloftheforest + ")";

                help.logg(mini);
                if (writetobuffer) help.writeToBuffer(mini);
            }

        }


    }

}