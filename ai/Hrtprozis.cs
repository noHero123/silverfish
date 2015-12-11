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
        lordjaraxxus,
        ragnarosthefirelord
    }

    public class Hrtprozis
    {

        public int enemyCursedCardsinHand = 0;
        public int ownFenciCoaches=0;
        public int ownSaboteur=0;
        public int enemySaboteur=0;

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

        public int heroPowerUsesThisTurn = 0;
        public int ownHeroPowerUsesThisGame = 0;
        public int enemyHeroPowerUsesThisGame = 0;
        public int lockAndLoads = 0;

        public int numberMinionsDiedThisTurn = 0;
        

        public int cardsPlayedThisTurn = 0;
        public int owedRecall = 0;
        public int ownCurrentRecall = 0;
        public int enemyRecall;

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

        public int ownDragonConsort = 0;
        public int enemyDragonConsort = 0;
        public int ownLoatheb = 0;
        public int enemyLoatheb = 0;
        public int ownMillhouse=0;
        public int enemyMillhouse = 0;
        public int ownKirinTorEffect = 0;
        public int ownPreparation = 0;

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
            owedRecall = 0;
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
            numberMinionsDiedThisTurn = 0;
            ownCurrentRecall = 0;
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
            if (s == "HERO_05" || s == "HERO_05a")
            {
                retval = "hunter";
            }
            if (s == "HERO_09" || s == "HERO_09a")
            {
                retval = "priest";
            }
            if (s == "HERO_06" || s == "HERO_06a")
            {
                retval = "druid";
            }
            if (s == "HERO_07" || s == "HERO_07a")
            {
                retval = "warlock";
            }
            if (s == "HERO_03" || s == "HERO_03a")
            {
                retval = "thief";
            }
            if (s == "HERO_04" || s == "HERO_04a")
            {
                retval = "pala";
            }
            if (s == "HERO_01" || s == "HERO_01a")
            {
                retval = "warrior";
            }
            if (s == "HERO_02" || s == "HERO_02a")
            {
                retval = "shaman";
            }
            if (s == "HERO_08" || s == "HERO_08a")
            {
                retval = "mage";
            }
            if (s == "BRM_027h")
            {
                retval = "ragnarosthefirelord";
            }
            if (s == "EX1_323h")
            {
                retval = "lordjaraxxus";
            }

            return retval;
        }


        public static string heroEnumtoName(HeroEnum s)
        {

            if (s ==HeroEnum.hogger )
            {
                return "hogger";
            }
            if (s == HeroEnum.hunter)
            {
                return "hunter";
            }
            if (s == HeroEnum.priest)
            {
                return "priest";
            }
            if (s == HeroEnum.druid)
            {
                return "druid";
            }
            if (s == HeroEnum.warlock)
            {
                return "warlock";
            }
            if (s == HeroEnum.thief)
            {
                return "thief";
            }
            if (s == HeroEnum.pala)
            {
                return "pala";
            }
            if (s == HeroEnum.warrior)
            {
                return "warrior";
            }
            if (s == HeroEnum.shaman)
            {
                return "shaman";
            }
            if (s == HeroEnum.mage)
            {
                return "mage";
            }
            if (s == HeroEnum.lordjaraxxus)
            {
                return "lordjaraxxus";
            }
            if (s == HeroEnum.ragnarosthefirelord)
            {
                return "ragnarosthefirelord";
            }

            return "druid";
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
            if (s == "ragnarosthefirelord")
            {
                return HeroEnum.ragnarosthefirelord;
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

        public void updatePlayer(int maxmana, int currentmana, int cardsplayedthisturn, int numMinionsplayed, int optionsPlayedThisTurn, int recall, int heroentity, int enemyentity, int numMinsDied, int currentRecall, int enemRecall, int hrpwrUsesThisTurn, int locknload)
        {
            this.currentMana = currentmana;
            this.ownMaxMana = maxmana;
            this.cardsPlayedThisTurn = cardsplayedthisturn;
            this.numMinionsPlayedThisTurn = numMinionsplayed;
            
            this.ownHeroEntity = heroentity;
            this.enemyHeroEntitiy = enemyentity;
            this.numOptionsPlayedThisTurn = optionsPlayedThisTurn;

            this.numberMinionsDiedThisTurn = numMinsDied;
            this.ownCurrentRecall= currentRecall;
            this.owedRecall = recall;
            this.enemyRecall = enemRecall;

            this.heroPowerUsesThisTurn = hrpwrUsesThisTurn;
            this.lockAndLoads = locknload;
            
        }

        public void setPlayereffects(int ownDragonConsorts, int enemyDragonConsorts, int ownLoathebs, int enemyLoathebs, int ownMillhouses, int enemyMillhouses, int ownKirin, int ownPrep, int ownSabo, int enemySabo, int ownFenciCoachess, int enemycurses)
        {
            this.ownDragonConsort = ownDragonConsorts;
            this.enemyDragonConsort = enemyDragonConsorts;

            this.ownLoatheb = ownLoathebs;
            this.enemyLoatheb = enemyLoathebs;

            this.ownMillhouse = ownMillhouses;
            this.enemyMillhouse = enemyMillhouses;

            this.ownKirinTorEffect = ownKirin;

            this.ownPreparation = ownPrep;

            this.ownSaboteur = ownSabo;
            this.enemySaboteur = enemySabo;

            this.ownFenciCoaches = ownFenciCoachess;

            this.enemyCursedCardsinHand = enemycurses;
        }

        public void updateOwnHero(string weapon, int watt, int wdur, string heron, CardDB.Card hab, bool habrdy, Minion Hero, int heroPowerUsesThisGame)
        {
            this.ownHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.heroWeaponAttack = watt;
            this.heroWeaponDurability = wdur;

            this.heroname = this.heroNametoEnum(heron);

            this.heroAbility = hab;
            this.ownAbilityisReady = habrdy;

            this.ownHero = new Minion(Hero);
            this.ownHero.updateReadyness();

            this.ownHeroPowerUsesThisGame = heroPowerUsesThisGame;
        }

        public void updateEnemyHero(string weapon, int weaponAttack, int weaponDurability, string heron, int enemMaxMana, CardDB.Card eab, Minion enemyHero, int heroPowerUsesThisGame)
        {
            this.enemyHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.enemyWeaponAttack = weaponAttack;
            this.enemyWeaponDurability = weaponDurability;

            this.enemyMaxMana = enemMaxMana;

            this.enemyHeroname = this.heroNametoEnum(heron);

            this.enemyAbility = eab;

            this.enemyHero = new Minion(enemyHero);

            this.enemyHeroPowerUsesThisGame = heroPowerUsesThisGame;

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

        //these functions are not longer updated (moved to playfield.getCompleteBoardForSimulating)
        public void printHero(bool writetobuffer = false)
        {
           
        }

        public void printOwnMinions(bool writetobuffer = false)
        {
            
        }

        public void printEnemyMinions(bool writetobuffer = false)
        {
            
        }


    }

}