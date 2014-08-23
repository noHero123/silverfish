// the ai :D
//please ask/write me if you use this in your project

using System;
using System.Collections.Generic;
using System.Text;



//TODO:

//test wichtelmeisterin, befehlsruf

//tueftlermeisteroberfunks
//verrückter bomber ( 3 damage to random chars)
//nozdormu (for computing time :D)
//faehrtenlesen
// lehrensucher cho
//scharmuetzel kills all :D




namespace HREngine.Bots
{

    public class Action
    {
        public bool cardplay = false;
        public bool heroattack = false;
        public bool useability = false;
        public bool minionplay = false;
        public CardDB.Card card;
        public int cardEntitiy = -1;
        public int owntarget = -1; //= target where card/minion is placed
        public int ownEntitiy = -1;
        public int enemytarget = -1; // target where red arrow is placed
        public int enemyEntitiy = -1;
        public int druidchoice = 0; // 1 left card, 2 right card
        public int numEnemysBeforePlayed = 0;

        public void print()
        {
            Helpfunctions help = Helpfunctions.Instance;
            help.logg("current Action: ");
                if (this.cardplay)
                {
                    help.logg("play " + this.card.name);
                    if (this.druidchoice >= 1) help.logg("choose choise " + this.druidchoice);
                    help.logg("with position " + this.cardEntitiy);
                    if (this.owntarget >= 0)
                    {
                        help.logg("on position " + this.ownEntitiy);
                    }
                    if (this.enemytarget >= 0)
                    {
                        help.logg("and target to " + this.enemytarget + " " + this.enemyEntitiy);
                    }
                }
                if (this.minionplay)
                {
                    help.logg("attacker: " + this.owntarget + " enemy: " + this.enemytarget);
                    help.logg("targetplace " + this.enemyEntitiy);
                }
                if (this.heroattack)
                {
                    help.logg("attack with hero, enemy: " + this.enemytarget);
                    help.logg("targetplace " + this.enemyEntitiy);
                }
                if (this.useability)
                {
                    help.logg("useability ");
                    if (this.enemytarget >= 0)
                    {
                        help.logg("on enemy: " + this.enemytarget + "targetplace " + this.enemyEntitiy);
                    }
                }
                help.logg("");
        }

    }


    public class Playfield
    {
        public bool logging = false;

        public int evaluatePenality = 0;
        public int ownController = 0;

        public int ownHeroEntity = -1;
        public int enemyHeroEntity = -1;

        public int value = Int32.MinValue;
        public int guessingHeroDamage = 0;

        public int mana = 0;
        public int enemyHeroHp = 30;
        public string ownHeroName = "";
        public string enemyHeroName = "";
        public bool ownHeroReady = false;
        public int ownHeroNumAttackThisTurn = 0;
        public bool ownHeroWindfury = false;

        public List<string> ownSecretsIDList = new List<string>();
        public int enemySecretCount = 0;

        public int ownHeroHp = 30;
        public int ownheroAngr = 0;
        public bool ownHeroFrozen = false;
        public bool enemyHeroFrozen = false;
        public bool heroImmuneWhileAttacking = false;
        public int ownWeaponDurability = 0;
        public int ownWeaponAttack = 0;
        public string ownWeaponName = "";
        
        public int enemyWeaponAttack = 0;
        public int enemyWeaponDurability = 0;
        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public List<Handmanager.Handcard> owncards = new List<Handmanager.Handcard>();
        public List<Action> playactions = new List<Action>();
        public bool complete = false;
        public int owncarddraw = 0;
        public int ownHeroDefence = 0;
        public int enemycarddraw = 0;
        public int enemyAnzCards = 0;
        public int enemyHeroDefence = 0;
        public bool ownAbilityReady = false;
        public int doublepriest = 0;
        public int spellpower = 0;
        public bool auchenaiseelenpriesterin = false;

        public bool playedmagierinderkirintor = false;
        public bool playedPreparation = false;

        public int winzigebeschwoererin = 0;
        public int startedWithWinzigebeschwoererin = 0;
        public int zauberlehrling = 0;
        public int startedWithZauberlehrling = 0;
        public int managespenst = 0;
        public int startedWithManagespenst = 0;
        public int soeldnerDerVenture = 0;
        public int startedWithsoeldnerDerVenture = 0;
        public int beschwoerungsportal = 0;
        public int startedWithbeschwoerungsportal = 0;

        public int ownWeaponAttackStarted = 0;
        public int ownMobsCountStarted = 0;
        public int ownCardsCountStarted = 0;
        public int ownHeroHpStarted = 30;

        public int mobsplayedThisTurn = 0;
        public int startedWithMobsPlayedThisTurn = 0;

        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0; //=recall

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int lostDamage = 0;
        public int lostHealth = 0; 
        public int lostWeaponDamage = 0;

        public CardDB.Card ownHeroAblility;

        Helpfunctions help = Helpfunctions.Instance;

        private void addMinionsReal(List<Minion> source, List<Minion> trgt)
        {
            foreach (Minion m in source)
            {
                Minion mc = new Minion(m);
                trgt.Add(mc);
            }

        }

        private void addCardsReal(List<Handmanager.Handcard> source)
        {

            foreach (Handmanager.Handcard m in source)
            {
                Handmanager.Handcard mc = new Handmanager.Handcard();
                mc.card = new CardDB.Card(m.card);
                mc.position = m.position;
                mc.entity = m.entity;
                this.owncards.Add(mc);
            }

        }

        public Playfield()
        {
            this.ownController = Hrtprozis.Instance.getOwnController();
            this.ownHeroEntity = Hrtprozis.Instance.ownHeroEntity;
            this.enemyHeroEntity = Hrtprozis.Instance.enemyHeroEntitiy;
            this.mana = Hrtprozis.Instance.currentMana;
            this.ownMaxMana = Hrtprozis.Instance.ownMaxMana;
            this.enemyMaxMana = Hrtprozis.Instance.enemyMaxMana;
            this.evaluatePenality = 0;
            this.ownSecretsIDList = Hrtprozis.Instance.ownSecretList;
            this.enemySecretCount = Hrtprozis.Instance.enemySecretCount;

            addMinionsReal(Hrtprozis.Instance.ownMinions, ownMinions);
            addMinionsReal(Hrtprozis.Instance.enemyMinions, enemyMinions);
            addCardsReal(Handmanager.Instance.handCards);
            this.enemyHeroHp = Hrtprozis.Instance.enemyHp;
            this.ownHeroName = Hrtprozis.Instance.heroname;
            this.enemyHeroName = Hrtprozis.Instance.enemyHeroname;
            this.ownHeroHp = Hrtprozis.Instance.heroHp;
            this.complete = false;
            this.ownHeroReady = Hrtprozis.Instance.ownheroisread;
            this.ownHeroWindfury = Hrtprozis.Instance.ownHeroWindfury;
            this.ownHeroNumAttackThisTurn = Hrtprozis.Instance.ownHeroNumAttacksThisTurn;

            this.ownHeroFrozen = Hrtprozis.Instance.herofrozen;
            this.enemyHeroFrozen = Hrtprozis.Instance.enemyfrozen;
            this.ownheroAngr = Hrtprozis.Instance.heroAtk;
            this.heroImmuneWhileAttacking = Hrtprozis.Instance.heroImmuneToDamageWhileAttacking;
            this.ownWeaponDurability = Hrtprozis.Instance.heroWeaponDurability;
            this.ownWeaponAttack = Hrtprozis.Instance.heroWeaponAttack;
            this.ownWeaponName = Hrtprozis.Instance.ownHeroWeapon;
            this.owncarddraw = 0;
            this.ownHeroDefence = 0;
            this.enemyHeroDefence = 0;
            this.enemyWeaponAttack = 0;//dont know jet
            this.enemyWeaponDurability = Hrtprozis.Instance.enemyWeaponDurability;
            this.enemycarddraw = 0;
            this.enemyAnzCards = Handmanager.Instance.enemyAnzCards;
            this.ownAbilityReady = Hrtprozis.Instance.ownAbilityisReady;
            this.ownHeroAblility = Hrtprozis.Instance.heroAbility;
            this.doublepriest = 0;
            this.spellpower = 0;
            value = -1000000;
            this.mobsplayedThisTurn = Hrtprozis.Instance.numMinionsPlayedThisTurn;
            this.startedWithMobsPlayedThisTurn = Hrtprozis.Instance.numMinionsPlayedThisTurn;// only change mobsplayedthisturm
            this.cardsPlayedThisTurn = Hrtprozis.Instance.cardsPlayedThisTurn;
            this.ueberladung = Hrtprozis.Instance.ueberladung;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = this.ownHeroHp;
            this.ownWeaponAttackStarted = this.ownWeaponAttack;
            this.ownCardsCountStarted = this.owncards.Count;
            this.ownMobsCountStarted = this.ownMinions.Count;


            this.playedmagierinderkirintor = false;
            this.playedPreparation = false;

            this.zauberlehrling = 0;
            this.winzigebeschwoererin = 0;
            this.managespenst = 0;
            this.soeldnerDerVenture = 0;
            this.beschwoerungsportal = 0;

            this.startedWithbeschwoerungsportal = 0;
            this.startedWithManagespenst = 0;
            this.startedWithWinzigebeschwoererin = 0;
            this.startedWithZauberlehrling = 0;
            this.startedWithsoeldnerDerVenture = 0;

            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced) continue;

                if (m.name == "prophetvelen") this.doublepriest++;
                spellpower = spellpower + m.card.spellpowervalue;
                if (m.name == "auchenaiseelenpriesterin") this.auchenaiseelenpriesterin = true;

                if (m.name == "winzigebeschwoererin")
                {
                    this.winzigebeschwoererin++;
                    this.startedWithWinzigebeschwoererin++;
                }
                if (m.name == "zauberlehrling")
                {
                    this.zauberlehrling++;
                    this.startedWithZauberlehrling++;
                }
                if (m.name == "managespenst")
                {
                    this.managespenst++;
                    this.startedWithManagespenst++;
                }
                if (m.name == "soeldnerderventureco")
                {
                    this.soeldnerDerVenture++;
                    this.startedWithsoeldnerDerVenture++;
                }
                if (m.name == "beschwoerungsportal")
                {
                    this.beschwoerungsportal++;
                    this.startedWithbeschwoerungsportal++;
                }

                foreach (Enchantment e in m.enchantments)// only at first init needed, after that its copied
                {
                    if (e.CARDID == "NEW1_036e" || e.CARDID == "NEW1_036e2") m.cantLowerHPbelowONE = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced) continue;
                if (m.name == "managespenst")
                {
                    this.managespenst++;
                    this.startedWithManagespenst++;
                }
            }


        }

        public Playfield(Playfield p)
        {
            this.ownController = p.ownController;
            this.ownHeroEntity = p.ownHeroEntity;
            this.enemyHeroEntity = p.enemyHeroEntity;

            this.evaluatePenality = p.evaluatePenality;

            foreach(string s in p.ownSecretsIDList)
            { this.ownSecretsIDList.Add(s); }
            this.enemySecretCount = p.enemySecretCount;
            this.mana = p.mana;
            this.ownMaxMana = p.ownMaxMana;
            this.enemyMaxMana = p.enemyMaxMana;
            addMinionsReal(p.ownMinions, ownMinions);
            addMinionsReal(p.enemyMinions, enemyMinions);
            addCardsReal(p.owncards);
            this.enemyHeroHp = p.enemyHeroHp;
            this.ownHeroName = p.ownHeroName;
            this.enemyHeroName = p.enemyHeroName;
            this.ownHeroHp = p.ownHeroHp;
            this.playactions.AddRange(p.playactions);
            this.complete = false;
            this.ownHeroReady = p.ownHeroReady;
            this.ownHeroNumAttackThisTurn = p.ownHeroNumAttackThisTurn;
            this.ownHeroWindfury = p.ownHeroWindfury;

            this.ownheroAngr = p.ownheroAngr;
            this.ownHeroFrozen = p.ownHeroFrozen;
            this.enemyHeroFrozen = p.enemyHeroFrozen;
            this.heroImmuneWhileAttacking = p.heroImmuneWhileAttacking;
            this.owncarddraw = p.owncarddraw;
            this.ownHeroDefence = p.ownHeroDefence;
            this.enemyWeaponAttack = p.enemyWeaponAttack;
            this.enemycarddraw = p.enemycarddraw;
            this.enemyAnzCards = p.enemyAnzCards;
            this.enemyHeroDefence = p.enemyHeroDefence;
            this.ownWeaponDurability = p.ownWeaponDurability;
            this.ownWeaponAttack = p.ownWeaponAttack;
            this.ownWeaponName = p.ownWeaponName;

            this.lostDamage = p.lostDamage;
            this.lostWeaponDamage = p.lostWeaponDamage;
            this.lostHealth = p.lostHealth;

            this.ownAbilityReady = p.ownAbilityReady;
            this.ownHeroAblility = p.ownHeroAblility;
            this.doublepriest = 0;
            this.spellpower = 0;
            value = -1000000;
            this.mobsplayedThisTurn = p.mobsplayedThisTurn;
            this.startedWithMobsPlayedThisTurn = p.startedWithMobsPlayedThisTurn;
            this.cardsPlayedThisTurn = p.cardsPlayedThisTurn;
            this.ueberladung = p.ueberladung;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = p.ownHeroHpStarted;
            this.ownWeaponAttackStarted = p.ownWeaponAttackStarted;
            this.ownCardsCountStarted = p.ownCardsCountStarted;
            this.ownMobsCountStarted = p.ownMobsCountStarted;

            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            this.playedmagierinderkirintor = p.playedmagierinderkirintor;

            this.startedWithZauberlehrling = p.startedWithZauberlehrling;
            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            this.startedWithManagespenst = p.startedWithManagespenst;
            this.startedWithsoeldnerDerVenture = p.startedWithsoeldnerDerVenture;
            this.startedWithbeschwoerungsportal = p.startedWithbeschwoerungsportal;

            this.zauberlehrling = 0;
            this.winzigebeschwoererin = 0;
            this.managespenst = 0;
            this.soeldnerDerVenture = 0;
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced) continue;
                if (m.name == "prophetvelen") this.doublepriest++;
                spellpower = spellpower + m.card.spellpowervalue;
                if (m.name == "auchenaiseelenpriesterin") this.auchenaiseelenpriesterin = true;

                if (m.name == "winzigebeschwoererin") this.winzigebeschwoererin++;
                if (m.name == "zauberlehrling") this.zauberlehrling++;
                if (m.name == "managespenst") this.managespenst++;
                if (m.name == "soeldnerderventureco") this.soeldnerDerVenture++;
                if (m.name == "beschwoerungsportal") this.beschwoerungsportal++;


            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced) continue;
                if (m.name == "managespenst") this.managespenst++;
            }

        }

        public int getValuee()
        {
            //if (value >= -200000) return value;
            int retval = 0;
            retval += owncards.Count * 1;
            
            retval += ownMinions.Count * 10;
            retval -= enemyMinions.Count * 10;

            retval += ownHeroHp + ownHeroDefence;
            retval += -enemyHeroHp - enemyHeroDefence;

            retval += ownheroAngr;// +ownWeaponDurability;
            retval -= enemyWeaponDurability;

            retval += owncarddraw * 5;
            retval -= enemycarddraw * 5;

            retval += this.ownMaxMana;

            if (enemyMinions.Count >= 0)
            {
                int anz = enemyMinions.Count;
                int owntaunt = ownMinions.FindAll(x => x.taunt == true).Count;
                int froggs = ownMinions.FindAll(x => x.name == "frosch").Count;
                owntaunt -= froggs;
                if (owntaunt == 0) retval -= 10 * anz;
                retval += owntaunt * 10 - 11 * anz;
            }

            foreach (Minion m in this.ownMinions)
            {
                retval += m.Hp * 1;
                retval += m.Angr * 2;
                if (m.Angr >= m.maxHp + 1)
                {
                    //is a tanky minion
                    retval += m.Hp;
                }
                if (m.windfury) retval += m.Angr;
            }

            foreach (Minion m in this.enemyMinions)
            {

                retval -= m.Hp;
                retval -= m.Angr*2;
                if (m.Angr >= m.maxHp + 1)
                {
                    //is a tanky minion
                    retval -= m.Hp;
                }

                if (m.windfury) retval -= m.Angr;
                if (m.taunt) retval -= 5;
                if (m.name == "schlachtzugsleiter") retval -= 5;
                if (m.name == "grimmschuppenorakel") retval -= 5;
                if (m.name == "terrorwolfalpha") retval -= 2;
                if (m.name == "murlocanfuehrer") retval -= 5;
                if (m.name == "suedmeerkapitaen") retval -= 5;
                if (m.name == "championvonsturmwind") retval -= 10;
                if (m.name == "waldwolf") retval -= 5;
                if (m.name == "leokk") retval -= 5;
                if (m.name == "klerikerinvonnordhain") retval -= 5;
                if (m.name == "zauberlehrling") retval -= 3;
                if (m.name == "winzigebeschwoererin") retval -= 3;
            }

            retval -= lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= lostWeaponDamage;
            if (ownMinions.Count == 0) retval -= 20;
            if (enemyMinions.Count == 0) retval += 20;
            if (enemyHeroHp <= 0) retval = 10000;
            if (ownHeroHp <= 0) retval = -10000;

            this.value = retval;
            return retval;
        }

        public List<targett> getAttackTargets()
        {
            List<targett> trgts = new List<targett>();
            List<targett> trgts2 = new List<targett>();
            trgts2.Add(new targett(200, this.enemyHeroEntity));
            bool hastanks = false;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.stealth) continue; // cant target stealth

                if (m.taunt)
                {
                    hastanks = true;
                    trgts.Add(new targett(m.id + 10, m.entitiyID));
                }
                else
                {
                    trgts2.Add(new targett(m.id + 10, m.entitiyID));
                }
            }
            if (hastanks) return trgts;

            return trgts2;


        }

        public int getBestPlace(CardDB.Card card)
        {
            if (card.type != CardDB.cardtype.MOB) return 0;
            if (this.ownMinions.Count <= 1) return 0;

            int[] places = new int[this.ownMinions.Count];
            int i = 0;
            int tempval = 0;
            if (card.name == "sonnenzornbeschuetzerin" || card.name == "verteidigervonargus") // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (!m.taunt)
                    {
                        tempval -= m.Hp;
                    }
                    else
                    {
                        tempval = 30;
                    }

                    if (m.name == "flammenzungentotem") tempval += 50;
                    if (m.name == "schlachtzugsleiter") tempval += 30;
                    if (m.name == "grimmschuppenorakel") tempval += 30;
                    if (m.name == "terrorwolfalpha") tempval += 50;
                    if (m.name == "murlocanfuehrer") tempval += 30;
                    if (m.name == "suedmeerkapitaen") tempval += 30;
                    if (m.name == "championvonsturmwind") tempval += 30;
                    if (m.name == "waldwolf") tempval += 30;
                    if (m.name == "leokk") tempval += 30;
                    if (m.name == "klerikerinvonnordhain") tempval += 30;
                    if (m.name == "zauberlehrling") tempval += 20;
                    if (m.name == "winzigebeschwoererin") tempval += 10;
                    if (m.name == "beschwoerungsportal") tempval += 20;
                    if (m.name == "aasfressendehyaene") tempval += 20;

                    places[i] = tempval;

                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if(bestval > prev + next) 
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl;
            }
            // normal placement
            int cardvalue = card.Attack * 2 + card.Health;
            if (card.tank)
            {
                cardvalue += 5;
                cardvalue += card.Health;
            }

            if (card.name == "flammenzungentotem") cardvalue += 50;
            if (card.name == "schlachtzugsleiter") cardvalue += 10;
            if (card.name == "grimmschuppenorakel") cardvalue += 10;
            if (card.name == "terrorwolfalpha") cardvalue += 50;
            if (card.name == "murlocanfuehrer") cardvalue += 10;
            if (card.name == "suedmeerkapitaen") cardvalue += 10;
            if (card.name == "championvonsturmwind") cardvalue += 10;
            if (card.name == "waldwolf") cardvalue += 10;
            if (card.name == "leokk") cardvalue += 10;
            if (card.name == "cardvalue") cardvalue += 10;
            if (card.name == "zauberlehrling") cardvalue += 10;
            if (card.name == "winzigebeschwoererin") cardvalue += 10;
            if (card.name == "beschwoerungsportal") cardvalue += 10;
            if (card.name == "aasfressendehyaene") cardvalue += 10;


            i = 0;
            foreach(Minion m in this.ownMinions)
            {
                places[i] = 0;
                tempval = m.Angr * 2 + m.maxHp;
                if (m.taunt)
                {
                    tempval += 6;
                    tempval += m.maxHp;
                }

                if (m.name == "flammenzungentotem") tempval += 50;
                if (m.name == "schlachtzugsleiter") tempval += 10;
                if (m.name == "grimmschuppenorakel") tempval += 10;
                if (m.name == "terrorwolfalpha") tempval += 50;
                if (m.name == "murlocanfuehrer") tempval += 10;
                if (m.name == "suedmeerkapitaen") tempval += 10;
                if (m.name == "championvonsturmwind") tempval += 10;
                if (m.name == "waldwolf") tempval += 10;
                if (m.name == "leokk") tempval += 10;
                if (m.name == "klerikerinvonnordhain") tempval += 10;
                if (m.name == "zauberlehrling") tempval += 10;
                if (m.name == "winzigebeschwoererin") tempval += 10;
                if (m.name == "beschwoerungsportal") tempval += 10;
                if (m.name == "aasfressendehyaene") tempval += 10;

                places[i] = tempval;

                i++;
            }

            //bigminion if >=10
            int bestplace = 0;
            int bestvale = 0;
            tempval=0;
            i=0;
            for (int j = 0; j <= this.ownMinions.Count; j++ )
            {
                int prev = cardvalue;
                int next = cardvalue;
                if (i >= 1) prev = places[i - 1];
                if (i < this.ownMinions.Count) next = places[i];


                if (cardvalue >= prev && cardvalue >= next)
                {
                    tempval = 2 * cardvalue - prev - next;
                    if (tempval > bestvale)
                    {
                        bestplace = i;
                        bestvale = tempval;
                    }
                }
                if (cardvalue <= prev && cardvalue <= next)
                {
                    tempval = -2 * cardvalue + prev + next;
                    if (tempval > bestvale)
                    {
                        bestplace = i ;
                        bestvale = tempval;
                    }
                }

                i++;
            }

            return bestplace;
        }

        public int getBestPlacePrint(CardDB.Card card)
        {
            if (card.type != CardDB.cardtype.MOB) return 0;
            if (this.ownMinions.Count <= 1) return 0;

            int[] places = new int[this.ownMinions.Count];
            int i = 0;
            int tempval = 0;
            if (card.name == "sonnenzornbeschuetzerin" || card.name == "verteidigervonargus") // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (!m.taunt)
                    {
                        tempval -= m.Hp;
                    }
                    else
                    {
                        tempval = 30;
                    }

                    if (m.name == "flammenzungentotem") tempval += 50;
                    if (m.name == "schlachtzugsleiter") tempval += 30;
                    if (m.name == "grimmschuppenorakel") tempval += 30;
                    if (m.name == "terrorwolfalpha") tempval += 50;
                    if (m.name == "murlocanfuehrer") tempval += 30;
                    if (m.name == "suedmeerkapitaen") tempval += 30;
                    if (m.name == "championvonsturmwind") tempval += 30;
                    if (m.name == "waldwolf") tempval += 30;
                    if (m.name == "leokk") tempval += 30;
                    if (m.name == "klerikerinvonnordhain") tempval += 30;
                    if (m.name == "zauberlehrling") tempval += 20;
                    if (m.name == "winzigebeschwoererin") tempval += 10;
                    if (m.name == "beschwoerungsportal") tempval += 20;
                    if (m.name == "aasfressendehyaene") tempval += 20;

                    places[i] = tempval;

                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    help.logg(places[i]+"");
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i ;
                    }
                    i++;
                }
                return bestpl;
            }

            // normal placement
            int cardvalue = card.Attack * 2 + card.Health;
            if (card.tank)
            {
                cardvalue += 5;
                cardvalue += card.Health;
            }

            if (card.name == "flammenzungentotem") tempval += 50;
            if (card.name == "schlachtzugsleiter") cardvalue += 10;
            if (card.name == "grimmschuppenorakel") cardvalue += 10;
            if (card.name == "terrorwolfalpha") cardvalue += 50;
            if (card.name == "murlocanfuehrer") cardvalue += 10;
            if (card.name == "suedmeerkapitaen") cardvalue += 10;
            if (card.name == "championvonsturmwind") cardvalue += 10;
            if (card.name == "waldwolf") cardvalue += 10;
            if (card.name == "leokk") cardvalue += 10;
            if (card.name == "cardvalue") cardvalue += 10;
            if (card.name == "zauberlehrling") cardvalue += 10;
            if (card.name == "winzigebeschwoererin") cardvalue += 10;
            if (card.name == "beschwoerungsportal") cardvalue += 10;
            if (card.name == "aasfressendehyaene") cardvalue += 10;


            i = 0;
            foreach (Minion m in this.ownMinions)
            {
                places[i] = 0;
                tempval = m.Angr * 2 + m.maxHp;
                if (m.taunt)
                {
                    tempval += 6;
                    tempval += m.maxHp;
                }

                if (m.name == "flammenzungentotem") tempval += 50;
                if (m.name == "schlachtzugsleiter") tempval += 10;
                if (m.name == "grimmschuppenorakel") tempval += 10;
                if (m.name == "terrorwolfalpha") tempval += 50;
                if (m.name == "murlocanfuehrer") tempval += 10;
                if (m.name == "suedmeerkapitaen") tempval += 10;
                if (m.name == "championvonsturmwind") tempval += 10;
                if (m.name == "waldwolf") tempval += 10;
                if (m.name == "leokk") tempval += 10;
                if (m.name == "klerikerinvonnordhain") tempval += 10;
                if (m.name == "zauberlehrling") tempval += 10;
                if (m.name == "winzigebeschwoererin") tempval += 10;
                if (m.name == "beschwoerungsportal") tempval += 10;
                if (m.name == "aasfressendehyaene") tempval += 10;

                places[i] = tempval;
                help.logg(places[i] + "");

                i++;
            }

            //bigminion if >=10
            int bestplace = 0;
            int bestvale = 0;
            tempval = 0;
            i = 0;
            help.logg(cardvalue + " (own)");
            i = 0;
            for (int j = 0; j <= this.ownMinions.Count; j++)
            {
                int prev = cardvalue;
                int next = cardvalue;
                if (i >= 1) prev = places[i - 1];
                if (i < this.ownMinions.Count)
                {
                    next = places[i];
                }


                if (cardvalue >= prev && cardvalue >= next)
                {
                    tempval = 2 * cardvalue - prev - next;
                    if (tempval > bestvale)
                    {
                        bestplace = i ;
                        bestvale = tempval;
                    }
                }
                if (cardvalue <= prev && cardvalue <= next)
                {
                    tempval = -2 * cardvalue + prev + next;
                    if (tempval > bestvale)
                    {
                        bestplace = i;
                        bestvale = tempval;
                    }
                }

                i++;
            }
            help.logg(bestplace + " (best)");
            return bestplace;
        }


        public void endTurn()
        {
            this.complete = true;
            endTurnBuffs(true);//end own buffs 
            endTurnEffect(true);//own turn ends
            startTurnEffect(false);//enemy turn begins
            guessHeroDamage();
            simulateTraps();
            
        }


        private void guessHeroDamage()
        {
            int ghd = 0;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.frozen) continue;
                ghd += m.Angr;
                if (m.windfury) ghd += m.Angr;
            }

            if (this.enemyHeroName == "druid") ghd++;
            if (this.enemyHeroName == "mage") ghd++;
            if (this.enemyHeroName == "thief") ghd++;
            if (this.enemyHeroName == "hunter") ghd += 2;
            ghd += enemyWeaponAttack;

            foreach (Minion m in this.ownMinions)
            {
                if (m.frozen) continue;
                if (m.taunt) ghd -= m.Hp;
                if (m.taunt && m.divineshild) ghd -= 1;
            }

            this.guessingHeroDamage = Math.Max(0, ghd);
        }

        private void simulateTraps()
        {
            // DONT KILL ENEMY HERO (cause its only guessing)
            foreach (string secretID in this.ownSecretsIDList)
            {
                //hunter secrets############
                if (secretID == "EX1_554") //snaketrap
                {

                    //call 3 snakes (if possible)
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardData("schlange");
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                }
                if (secretID == "EX1_609") //snipe
                {
                    //kill weakest minion of enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDamagedOrHealed(m, 4, 0, false);
                }
                if (secretID == "EX1_610") //explosive trap
                {
                    //take 2 damage to each enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    foreach (Minion m in temp)
                    {
                        minionGetDamagedOrHealed(m, 2, 0, false);
                    }
                    attackEnemyHeroWithoutKill(2);
                }
                if (secretID == "EX1_611") //freezing trap
                {
                    //return weakest enemy minion to hand
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionReturnToHand(m, false);
                }
                if (secretID == "EX1_533") // missdirection
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    this.guessingHeroDamage = Math.Max(0, this.guessingHeroDamage -= Math.Max(m.Angr,1));
                    this.ownHeroDefence += this.enemyMinions.Count;// the more the enemy minions has on board, the more the posibility to destroy something other :D
                }

                //mage secrets############
                if (secretID == "EX1_287") //counterspell
                {
                    // what should we do?
                    this.ownHeroDefence += 5;
                }

                if (secretID == "EX1_289") //ice barrier
                {
                    this.ownHeroDefence += 8;
                }

                if (secretID == "EX1_295") //ice barrier
                {
                    //set the guessed Damage to zero
                    this.guessingHeroDamage = 0;
                }

                if (secretID == "EX1_294") //mirror entity
                {
                    //summon snake ( a weak minion)
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardData("schlange");
                    callKid(kid, posi, true);
                }
                if (secretID == "tt_010") //spellbender
                {
                    //whut???
                    // add 2 to your defence (most attack-buffs give +2, lots of damage spells too)
                    this.ownHeroDefence += 2;
                }
                if (secretID == "EX1_594") // vaporize
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    this.guessingHeroDamage = Math.Max(0, this.guessingHeroDamage -= Math.Max(m.Angr, 1));
                    minionGetDestroyed(m, false);
                }
                //pala secrets############
                if (secretID == "EX1_132") // eye for an eye
                {
                    // enemy takes one damage
                    attackEnemyHeroWithoutKill(1);
                }
                if (secretID == "EX1_130") // noble sacrifice
                {
                    //lower guessed hero damage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    this.guessingHeroDamage = Math.Max(0, this.guessingHeroDamage -= Math.Max(m.Angr, 1));
                }

                if (secretID == "EX1_136") // redemption
                {
                    // we give our weakest minion a divine shield :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    foreach (Minion m in temp)
                    {
                        if (m.divineshild) continue;
                        m.divineshild = true;
                        break;
                    }
                }

                if (secretID == "EX1_379") // repentance
                {
                    // set his current lowest hp minion to x/1
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Hp = 1;
                    m.maxHp = 1;
                }
            }

            
        }

        private void endTurnBuffs(bool own)
        {

            List<Minion> temp = new List<Minion>();

            if (own)
            {
                temp.AddRange(this.ownMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
            }
            // end buffs
            foreach (Minion m in temp)
            {
                m.cantLowerHPbelowONE = false;
                m.immune = false;
                List<Enchantment> tempench = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in tempench)
                {
                    if (e.CARDID == "EX1_316e")//ueberwaeltigende macht
                    {
                        minionGetDestroyed(m, own);
                    }

                    if (e.CARDID == "CS2_046e")//kampfrausch
                    {
                        debuff(m, e);
                    }

                    if (e.CARDID == "CS2_045e")// waffe felsbeiser
                    {
                        debuff(m, e);
                    }

                    if (e.CARDID == "EX1_046e")// dunkeleisenzwerg
                    {
                        debuff(m, e);
                    }
                    if (e.CARDID == "CS2_188o")// ruchloserunteroffizier
                    {
                        debuff(m, e);
                    }
                    if (e.CARDID == "EX1_055o")//  manasuechtige
                    {
                        debuff(m, e);
                    }
                    if (e.CARDID == "EX1_549o")//zorn des wildtiers
                    {
                        debuff(m, e);
                    }
                    if (e.CARDID == "EX1_334e")// dunkler wahnsin (control minion till end of turn)
                    {
                        //"uncontrol minion"
                        minionGetControlled(m, false, true);
                    }

                }
            }


        }


        private void endTurnEffect(bool own)
        {

            List<Minion> temp = new List<Minion>();
            List<Minion> ownmins = new List<Minion>();
            List<Minion> enemymins = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                ownmins.AddRange(this.ownMinions);
                enemymins.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                ownmins.AddRange(this.enemyMinions);
                enemymins.AddRange(this.ownMinions);
            }

     

            foreach (Minion m in temp)
            {
                if (m.silenced) continue;

                if (m.name == "barongeddon") // all other chards get dmg get 2 dmg
                {
                    List<Minion> temp2 = new List<Minion>(this.ownMinions);
                    foreach (Minion mm in temp2)
                    {
                        if (mm.entitiyID != m.entitiyID)
                        {
                            minionGetDamagedOrHealed(mm, 2, 0, true);
                        }
                    }
                    temp2.Clear();
                    temp2.AddRange(this.enemyMinions);
                    foreach (Minion mm in temp2)
                    {
                        if (mm.entitiyID != m.entitiyID)
                        {
                            minionGetDamagedOrHealed(mm, 2, 0, false);
                        }
                    }
                    attackOrHealHero(2, true);
                    attackOrHealHero(2, false);

                }

                if (m.name == "blutwichtel" || m.name == "jungepriesterin") // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//buff the weakest
                    foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                    {
                        minionGetBuffed(mins, 0, 1, own);
                    }
                }

                if (m.name == "meisterschwertschmied") // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));//buff the weakest
                    foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                    {
                        minionGetBuffed(mins, 1, 0, own);
                    }
                }

                if (m.name == "kraftverstaerker3000") // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                    temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));//buff the strongest enemy
                    foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                    {
                        minionGetBuffed(mins, 1, 0, false);//buff alyways enemy :D
                    }
                }

                if (m.name == "gruul") // gain +1/+1
                {
                    minionGetBuffed(m, 1, 1, own);
                }

                if (m.name == "astralerarkanist") // gain +2/+2
                {
                    if (own && this.ownSecretsIDList.Count>=1)
                    {
                        minionGetBuffed(m, 2, 2, own);
                    }
                    if (!own && this.enemySecretCount >= 1)
                    {
                        minionGetBuffed(m, 2, 2, own);
                    }
                }
                

                if (m.name == "manafluttotem") // draw card
                {
                    if (own)
                    {
                        this.owncarddraw++;
                        this.drawACard("");
                    }
                    else
                    {
                        this.enemycarddraw++;
                    }
                }

                if (m.name == "heiltotem") // heal
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    foreach (Minion mins in temp2)
                    {
                        minionGetDamagedOrHealed(mins, 0, 1, own);
                    }
                }

                if (m.name == "hogger") // summon
                {
                    int posi = m.id;
                    CardDB.Card kid = CardDB.Instance.getCardData("gnoll");
                    callKid(kid, posi, own);
                }

                if (m.name == "wichtelmeisterin") // damage itself and summon 
                {
                    int posi = m.id;
                    if (m.Hp == 1) posi--;
                    minionGetDamagedOrHealed(m, 1, 0, own);

                    CardDB.Card kid = CardDB.Instance.getCardData("wichtel");
                    callKid(kid, posi, own);
                }

                if (m.name == "natpagle") // draw card
                {
                    if (own)
                    {
                        this.owncarddraw++;
                        this.drawACard("");
                    }
                    else
                    {
                        this.enemycarddraw++;
                    }
                }

                if (m.name == "ragnarosderfeuerfuerst") // summon
                {
                    if (this.enemyMinions.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(enemymins);
                        temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the stronges
                        foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                        {
                            minionGetDamagedOrHealed(mins, 8, 0, !own);
                        }
                    }
                    else
                    {
                        attackOrHealHero(8, !own);
                    }
                }


                if (m.name == "reparaturbot") // heal damaged char
                {

                    attackOrHealHero(-6, false);
                }
                if (m.card.CardID == "EX1_tk9") //treant which is destroyed
                {
                    minionGetDestroyed(m, own);
                }

                if (m.name == "ysera") // draw card
                {
                    if (own)
                    {
                        this.owncarddraw++;
                        this.drawACard("yseraerwacht");
                    }
                    else
                    {
                        this.enemycarddraw++;
                    }
                }
            }

        }

        private void startTurnEffect(bool own)
        {
            List<Minion> temp = new List<Minion>();
            List<Minion> ownmins = new List<Minion>();
            List<Minion> enemymins = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                ownmins.AddRange(this.ownMinions);
                enemymins.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                ownmins.AddRange(this.enemyMinions);
                enemymins.AddRange(this.ownMinions);
            }

            bool untergang=false;
            foreach (Minion m in temp)
            {
                if (m.silenced) continue;
                if (m.name == "verwuester") // deal 2 dmg
                {
                    List<Minion> temp2 = new List<Minion>(enemymins);
                    foreach (Minion mins in temp2)
                    {
                        minionGetDamagedOrHealed(mins, 2, 0, !own);
                    }
                }

                if (m.name == "untergangsverkuender") // destroy
                {
                    untergang = true;
                }

                if (m.name == "zielsuchendeshuhn") // ok
                {
                    minionGetDestroyed(m, own);
                    if (own)
                    {
                        this.owncarddraw += 3;
                        this.drawACard("");
                        this.drawACard("");
                        this.drawACard("");
                    }
                    else
                    {
                        this.enemycarddraw += 3 ;
                    }
                }

                if (m.name == "lichtbrunnen") // heal
                {
                    if (ownmins.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(ownmins);
                        bool healed = false;
                        foreach (Minion mins in temp2)
                        {
                            if (mins.wounded)
                            {
                                minionGetDamagedOrHealed(mins, 0, 3, own);
                                healed = true;
                                break;
                            }
                        }

                        if (!healed) attackOrHealHero(-3, own);
                    }
                    else 
                    {
                        attackOrHealHero(-3, own);
                    }
                }

                if (m.name == "gefluegelisierer") // 
                {
                    if (this.ownMinions.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the stronges
                        foreach (Minion mins in temp2)
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID("Mekka4t");
                            minionTransform(mins, c, true);
                            break;
                        }
                    }
                    else
                    {
                        List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                        temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//damage the lowest
                        foreach (Minion mins in temp2)
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID("Mekka4t");
                            minionTransform(mins, c, false);
                            break;
                        }
                    }
                }
                

            }


            foreach (Minion m in enemymins) // search for corruption in other minions
            {
                List<Enchantment> elist = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in elist)
                {

                    if (e.CARDID == "CS2_063e")//corruption
                    {
                        if (own && e.controllerOfCreator == this.ownController) // own turn + we owner of curruption
                        {
                            minionGetDestroyed(m, false);
                        }
                        if (!own && e.controllerOfCreator != this.ownController)
                        {
                            minionGetDestroyed(m, true);
                        }
                    }
                }
            }

            if (untergang)
            {
                foreach (Minion mins in ownmins)
                {
                    minionGetDestroyed(mins, own);
                    
                }
                foreach (Minion mins in enemymins)
                {
                    minionGetDestroyed(mins, !own);
                }
            }

        }

        private int getSpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.spellpower;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        private int getSpellHeal(int heal)
        {
            int retval = heal;
            retval += this.spellpower;
            if (this.auchenaiseelenpriesterin) retval *= -1;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        private void attackEnemyHeroWithoutKill(int dmg)
        {
            int oldHp = this.enemyHeroHp;
            if (this.enemyHeroDefence <= 0)
            {
                this.enemyHeroHp = Math.Min(30, this.enemyHeroHp - dmg);
            }
            else
            {
                if (this.enemyHeroDefence > 0)
                {

                    int rest = enemyHeroDefence - dmg;
                    if (rest < 0)
                    {
                        this.enemyHeroHp += rest;
                    }
                    ownHeroDefence = Math.Max(0, enemyHeroDefence - dmg);

                }
            }

            if (oldHp >= 1 && this.enemyHeroHp == 0) this.enemyHeroHp = 1;
        }

        private void attackOrHealHero(int dmg, bool own) // negative damage is heal
        {
            if (own)
            {
                if (dmg < 0 || this.ownHeroDefence <= 0)
                {
                    //heal
                    int copy = this.ownHeroHp;
                    this.ownHeroHp = Math.Min(30, this.ownHeroHp - dmg);
                    if (copy < this.ownHeroHp)
                    {
                        triggerAHeroGetHealed(own);
                    }
                }
                else
                {
                    if (this.ownHeroDefence > 0)
                    {

                        int rest = ownHeroDefence - dmg;
                        if (rest < 0)
                        {
                            this.ownHeroHp += rest;
                        }
                        ownHeroDefence = Math.Max(0, ownHeroDefence - dmg);

                    }
                }


            }
            else
            {
                if (dmg < 0 || this.enemyHeroDefence <= 0)
                {
                    int copy = this.enemyHeroHp;
                    this.enemyHeroHp = Math.Min(30, this.enemyHeroHp - dmg);
                    if (copy < this.enemyHeroHp)
                    {
                        triggerAHeroGetHealed(own);
                    }
                }
                else
                {
                    if (this.enemyHeroDefence > 0)
                    {

                        int rest = enemyHeroDefence - dmg;
                        if (rest < 0)
                        {
                            this.enemyHeroHp += rest;
                        }
                        ownHeroDefence = Math.Max(0, enemyHeroDefence - dmg);

                    }
                }

            }

        }

        private void debuff(Minion m, Enchantment e)
        {
            int anz = m.enchantments.RemoveAll(x => x.creator == e.creator && x.CARDID == e.CARDID);
            if (anz >= 1)
            {
                for (int i = 0; i < anz; i++)
                {

                    if (e.charge && !m.card.Charge && m.enchantments.FindAll(x => x.charge == true).Count == 0)
                    {
                        m.charge = false;
                    }
                    if (e.taunt && !m.card.tank && m.enchantments.FindAll(x => x.taunt == true).Count == 0)
                    {
                        m.taunt = false;
                    }
                    if (e.divineshild && m.enchantments.FindAll(x => x.divineshild == true).Count == 0)
                    {
                        m.divineshild = false;
                    }
                    if (e.windfury && !m.card.windfury && m.enchantments.FindAll(x => x.windfury == true).Count == 0)
                    {
                        m.divineshild = false;
                    }
                    if (e.imune && m.enchantments.FindAll(x => x.imune == true).Count == 0)
                    {
                        m.immune = false;
                    }
                    minionGetBuffed(m, -e.angrbuff, -e.hpbuff, true);
                }
            }
        }

        private void deleteEffectOf(string CardID, int creator)
        {
            // deletes the effect of the cardID with creator from all minions 
            Enchantment e = CardDB.getEnchantmentFromCardID(CardID);
            e.creator = creator;
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion m in temp)
            {
                debuff(m, e);
            }
            temp.Clear();
            temp.AddRange(this.enemyMinions);
            foreach (Minion m in temp)
            {
                debuff(m, e);
            }
        }

        private void deleteEffectOfWithExceptions(string CardID, int creator, List<int> exeptions)
        {
            // deletes the effect of the cardID with creator from all minions 
            Enchantment e = CardDB.getEnchantmentFromCardID(CardID);
            e.creator = creator;
            foreach (Minion m in this.ownMinions)
            {
                if (!exeptions.Contains(m.id))
                {
                    debuff(m, e);
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (!exeptions.Contains(m.id))
                {
                    debuff(m, e);
                }
            }
        }

        private void addEffectToMinionNoDoubles(Minion m, Enchantment e, bool own)
        {
            foreach (Enchantment es in m.enchantments)
            {
                if ( es.CARDID == e.CARDID && es.creator == e.creator) return;
            }
            m.enchantments.Add(e);
            if (e.angrbuff >= 1 || e.hpbuff >= 1)
            {
                minionGetBuffed(m, e.angrbuff, e.hpbuff, own);
            }
            if (e.charge) minionGetCharge(m);
            if (e.divineshild) m.divineshild = true;
            if (e.taunt) m.taunt = true;
            if (e.windfury) minionGetWindfurry(m);
            if (e.imune) m.immune = true;
        }

        private void adjacentBuffer(Minion m, string enchantment, int before, int after, bool own)
        {
            List<Minion> lm = new List<Minion>();
            if (own)
            {
                lm.AddRange(this.ownMinions);
            }
            else
            {
                lm.AddRange(this.enemyMinions);
            }
            List<int> exeptions = new List<int>();
            exeptions.Add(before);
            exeptions.Add(after);
            deleteEffectOfWithExceptions(enchantment, m.entitiyID, exeptions);
            Enchantment e = CardDB.getEnchantmentFromCardID(enchantment);
            e.creator = m.entitiyID;
            e.controllerOfCreator = this.ownController;
            if (before >= 0)
            {
                Minion bef = lm[before];
                addEffectToMinionNoDoubles(bef, e, own);
            }
            if (after < lm.Count)
            {
                Minion bef = lm[after];
                addEffectToMinionNoDoubles(bef, e, own);
            }
        }

        private void adjacentBuffUpdate(bool own)
        {
            //int before = -1;
            //int after = 1;
            List<Minion> lm = new List<Minion>();
            if (own)
            {
                lm.AddRange(this.ownMinions);
            }
            else
            {
                lm.AddRange(this.enemyMinions);
            }
            foreach (Minion m in lm)
            {
                /*if (m.name == "terrorwolfalpha")
                {
                    string enchantment = "EX1_162o";
                    adjacentBuffer(m, enchantment, before, after, own);
                }
                if (m.name == "flammenzungentotem")
                {
                    string enchantment = "EX1_565o";
                    adjacentBuffer(m, enchantment, before, after, own);
                }
                before++;
                after++;*/

                getNewEffects(m, own, m.id, false);


            }

        }

        private void endEffectsDueToDeath(Minion m, bool own)
        { // minion which grants effect died
            if (m.name == "schlachtzugsleiter") // if he dies, lower attack of all minions of his side
            {
                deleteEffectOf("CS2_122e", m.entitiyID);
            }

            if (m.name == "grimmschuppenorakel")
            {
                deleteEffectOf("EX1_508o", m.entitiyID);
            }

            if (m.name == "terrorwolfalpha")
            {
                deleteEffectOf("EX1_162o", m.entitiyID);
            }
            if (m.name == "murlocanfuehrer")
            {
                deleteEffectOf("EX1_507e", m.entitiyID);
            }
            if (m.name == "suedmeerkapitaen")
            {
                deleteEffectOf("NEW1_027e", m.entitiyID);
            }
            if (m.name == "championvonsturmwind")
            {
                deleteEffectOf("CS2_222o", m.entitiyID);
            }
            if (m.name == "waldwolf")
            {
                deleteEffectOf("DS1_175o", m.entitiyID);
            }
            if (m.name == "leokk")
            {
                deleteEffectOf("NEW1_033o", m.entitiyID);
            }

            //lowering truebaugederalte

            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.name == "truebaugederalte" && m.card.race == 14)
                {
                    minionGetBuffed(mnn, -1, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.name == "truebaugederalte" && m.card.race == 14)
                {
                    minionGetBuffed(mnn, -1, 0, false);
                }
            }

            //no deathrattle, but lowering the weapon
            if (m.name == "hasserfuellteschmiedin" && m.wounded)// remove weapon changes form hasserfuelleschmiedin
            {
                if (own && this.ownWeaponDurability >= 1)
                {
                    this.ownWeaponAttack -= 2;
                    this.ownheroAngr -= 2;
                }
                if (!own && this.enemyWeaponDurability >= 1) this.enemyWeaponAttack -= 2;
            }
        }

        private void getNewEffects(Minion m, bool own, int placeOfNewMob, bool isSummon)
        {
            bool havekriegshymnenanfuehrerin = false;
            List<Minion> temp = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
            }
            int ownanz = temp.Count;

            if (own && isSummon && this.ownWeaponName == "schwertdergerechtigkeit")
            {
                minionGetBuffed(m, 1, 1, own);
                this.lowerWeaponDurability(1, true);
            }

            foreach (Minion ownm in temp)
            {
                if (ownm.silenced) continue; // silenced minions dont buff

                if (isSummon && ownm.name == "kriegshymnenanfuehrerin")
                {
                    havekriegshymnenanfuehrerin = true;
                }

                if (ownm.name == "schlachtzugsleiter")
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_122e");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);

                }
                if (ownm.name == "leokk")
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("NEW1_033o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);

                }
                if (ownm.name == "championvonsturmwind")
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_222o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.name == "grimmschuppenorakel" && m.card.race == 14)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_508o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.name == "murlocanfuehrer" && m.card.race == 14)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_507e");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.name == "suedmeerkapitaen" && m.card.race == 23)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("NEW1_027e");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.name == "terrorwolfalpha")
                {
                    if (ownm.id == placeOfNewMob + 1 || ownm.id == placeOfNewMob - 1)
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_162o");
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = this.ownController;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                }
                if (ownm.name == "flammenzungentotem")
                {
                    if (ownm.id == placeOfNewMob + 1 || ownm.id == placeOfNewMob - 1)
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_565o");
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = this.ownController;
                        addEffectToMinionNoDoubles(m, e, own);
                    }

                }

                if (ownm.name == "waldwolf" && (TAG_RACE)m.card.race == TAG_RACE.PET)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("DS1_175o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }

                if (isSummon && ownm.name == "tundranashorn" && (TAG_RACE)m.card.race == TAG_RACE.PET)
                {
                    minionGetCharge(m);
                }

                

            }
            // minions that gave ALL minions buffs
            temp.Clear();
            if (own)
            {
                temp.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.ownMinions);
            }

            foreach (Minion ownm in temp) // the enemy grimmschuppenorakel!
            {
                if (ownm.silenced) continue; // silenced minions dont buff

                if (ownm.name == "grimmschuppenorakel" && m.card.race == 14)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_508o");
                    e.creator = ownm.entitiyID;
                    addEffectToMinionNoDoubles(m, e, own);
                }

            }

            if (isSummon && havekriegshymnenanfuehrerin && m.Angr <= 3)
            {
                minionGetCharge(m);
            }

        }

        private void deathrattle(Minion m, bool own)
        {

            if (!m.silenced)
            {

                //real deathrattles
                if (m.card.CardID == "EX1_534")//m.name == "savannenhochmaehne"
                {
                    CardDB.Card c = CardDB.Instance.getCardData("hyaene");
                    callKid(c, m.id - 1, own);
                    callKid(c, m.id - 1, own);
                }

                if (m.name == "erntegolem")
                {
                    CardDB.Card c = CardDB.Instance.getCardData("beschaedigtergolem");
                    callKid(c, m.id - 1, own);

                }

                if (m.name == "cairnebluthuf")
                {
                    CardDB.Card c = CardDB.Instance.getCardData("bainebluthuf");
                    callKid(c, m.id - 1, own);
                    //penaltity for summon this thing :D (so we dont kill it only to have a new minion)
                    this.evaluatePenality += 5;


                }

                if (m.name == "diebestie")
                {
                    CardDB.Card c = CardDB.Instance.getCardData("finkleeinhorn");
                    callKid(c, m.id - 1, own);

                }

                if (m.name == "lepragnom")
                {
                    attackOrHealHero(2, !own);
                }

                if (m.name == "beutehamsterer")
                {
                    if (own)
                    {
                        this.owncarddraw++;
                        drawACard("unknown");
                    }
                    else
                    {
                        this.enemycarddraw++;
                    }
                }




                if (m.name == "blutmagierthalnos")
                {
                    if (own)
                    {
                        this.owncarddraw++;
                        drawACard("unknown");
                    }
                    else
                    {
                        this.enemycarddraw++;
                    }
                }

                if (m.name == "monstrositaet")
                {
                    if (logging) help.logg("deathrattle monstrositaet:");
                    attackOrHealHero(2, false);
                    attackOrHealHero(2, true);
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 2, 0, true);
                    }
                    temp.Clear();
                    temp.AddRange(this.enemyMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 2, 0, false);
                    }

                }


                if (m.name == "tirionfordring")
                {
                    if (own)
                    {
                        CardDB.Card c = CardDB.Instance.getCardData("aschenbringer");
                        this.equipWeapon(c);
                    }
                    else
                    {
                        this.enemyWeaponAttack = 5;
                        this.enemyWeaponDurability = 3;
                    }
                }

                if (m.name == "sylvanaswindlaeufer")
                {
                    List<Minion> temp = new List<Minion>();
                    if (own)
                    {
                        List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                        temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                        temp.AddRange(Helpfunctions.TakeList(temp2, Math.Min(2, this.enemyMinions.Count)));
                    }
                    else
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                        temp.AddRange(temp2);
                    }
                    if (temp.Count >= 1)
                    {
                        if (own)
                        {
                            Minion target = new Minion();
                            target = temp[0];
                            if (target.taunt && !temp[1].taunt) target = temp[1];
                            minionGetControlled(target, true, false);
                        }
                        else
                        {
                            Minion target = new Minion();

                            target = temp[0];
                            foreach (Minion mnn in temp)
                            {
                                if (mnn.Ready)
                                {
                                    target = mnn;
                                    break;
                                }
                            }
                            minionGetControlled(target, false, false);
                        }
                    }
                }

            }

            //deathrattle enchantments // these can be triggered after an silence (if they are casted after the silence)
            bool geistderahnen = false;
            foreach (Enchantment e in m.enchantments)
            {
                if (e.CARDID == "CS2_038e" && !geistderahnen)
                {
                    //revive minion due to "geist der ahnen"
                    CardDB.Card kid = m.card;
                    int pos = this.ownMinions.Count - 1;
                    if (!own) pos = this.enemyMinions.Count - 1;
                    callKid(kid, pos, own);
                    geistderahnen = true;
                }
                //Seele des Waldes
                if (e.CARDID == "EX1_158e")
                {
                    //revive minion due to "geist der ahnen"
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_158t");//Treant
                    int pos = this.ownMinions.Count - 1;
                    if (!own) pos = this.enemyMinions.Count - 1;
                    callKid(kid, pos, own);
                }
            }


        }

        private void triggerAMinionDied(Minion m, bool own)
        {
            List<Minion> temp = new List<Minion>();
            List<Minion> temp2 = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                temp2.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                temp2.AddRange(this.ownMinions);
            }

            foreach (Minion mnn in temp)
            {
                if (mnn.silenced) continue;

                if (mnn.name == "aasfressendehyaene" && m.card.race == 20)
                {
                    mnn.Angr += 2; mnn.Hp += 1;
                }
                if (mnn.name == "fleischfressenderghul")
                {
                    mnn.Angr += 1;
                }
                if (mnn.name == "kultmeisterin")
                {
                    if (own)
                    {
                        this.owncarddraw++;
                        drawACard("unknown");
                    }
                    else
                    {
                        this.enemycarddraw++;
                    }
                }
            }

            foreach (Minion mnn in temp2)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "fleischfressenderghul")
                {
                    mnn.Angr += 1;
                }
            }

        }

        private void minionGetDestroyed(Minion m, bool own)
        {

            if (own)
            {
                removeMinionFromList(m, this.ownMinions, true);

            }
            else
            {
                removeMinionFromList(m, this.enemyMinions, false);
            }

        }

        private void minionReturnToHand(Minion m, bool own)
        {

            if (own)
            {
                removeMinionFromListNoDeath(m, this.ownMinions, true);
                drawACard(m.card.name);
            }
            else
            {
                removeMinionFromListNoDeath(m, this.enemyMinions, false);
            }

        }

        private void minionTransform(Minion m, CardDB.Card c, bool own)
        {

            Minion tranform = createNewMinion(c, m.id, own);
            Minion temp = new Minion();
            temp.setMinionTominion(m);
            m.setMinionTominion(tranform);
            m.entitiyID = -2;
            this.endEffectsDueToDeath(temp, own);
            adjacentBuffUpdate(own);
            if (logging) help.logg("minion got sheep" + m.name + " " + m.Angr);
        }


        private void minionGetSilenced(Minion m, bool own)
        {
            //TODO
            
            m.taunt = false;
            m.stealth = false;
            m.charge = false;
            
            m.divineshild = false;
            m.poisonous = false;

            //delete enrage (if minion is silenced the first time)
            if (m.wounded && m.card.Enrage && !m.silenced)
            {
                deleteWutanfall(m, own);
            }

            //delete enrage (if minion is silenced the first time)

            if (m.frozen && m.numAttacksThisTurn == 0 && !(m.name == "uralterwaechter" || m.name == "ragnarosderfeuerfuerst") && !m.playedThisTurn)
            {
                m.Ready = true;
            }


            m.frozen = false;

            if (!m.silenced && (m.name == "uralterwaechter" || m.name == "ragnarosderfeuerfuerst") && !m.playedThisTurn && m.numAttacksThisTurn==0)
            {
                m.Ready = true;
            }

            endEffectsDueToDeath(m, own);//the minion doesnt die, but its effect is ending

            m.enchantments.Clear();

            m.Angr = m.card.Attack;
            if (m.maxHp < m.card.Health)//minion has lower maxHp as his card -> heal his hp
            {
                m.Hp += m.card.Health - m.maxHp; //heal minion

            }
            m.maxHp = m.card.Health;
            if (m.Hp > m.maxHp) m.Hp = m.maxHp;

            getNewEffects(m, own, m.id, false);// minion get effects of others 

            m.silenced = true;
        }

        private void minionGetControlled(Minion m, bool newOwner, bool canAttack)
        {
            List<Minion> newOwnerList = new List<Minion>();

            if (newOwner) { newOwnerList = new List<Minion>(this.ownMinions); }
            else { newOwnerList.AddRange(this.enemyMinions); }

            if (newOwnerList.Count >= 7) return;

            if (newOwner)
            {
                removeMinionFromListNoDeath(m, this.enemyMinions, !newOwner);
                m.Ready = false;

                this.getNewEffects(m, newOwner, newOwnerList.Count, false);

                addMiniontoList(m, this.ownMinions, newOwnerList.Count, newOwner);
                if (m.charge || canAttack)
                {
                    m.charge = false;
                    minionGetCharge(m);
                }

            }
            else
            {
                removeMinionFromListNoDeath(m, this.ownMinions, !newOwner);
                //m.Ready=false;
                addMiniontoList(m, this.enemyMinions, newOwnerList.Count, newOwner);
                //if (m.charge) minionGetCharge(m);
            }

        }


        private void minionGetWindfurry(Minion m)
        {
            if (m.windfury) return;
            m.windfury = true;
            if (!m.playedThisTurn && m.numAttacksThisTurn <= 1)
            {
                m.Ready = true;
            }
            if (!m.charge && m.numAttacksThisTurn <= 1)
            {
                m.Ready = true;
            }
        }

        private void minionGetCharge(Minion m)
        {
            if (m.charge) return;
            m.charge = true;
            if (m.playedThisTurn && (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
            {
                m.Ready = true;
            }
        }

        private void minionGetReady(Minion m) // minion get ready due to attack-buff
        {
            if (!m.silenced && (m.name == "uralterwaechter" || m.name == "ragnarosderfeuerfuerst")) return;

            if (!m.playedThisTurn && (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
            {
                m.Ready = true;
            }
        }

        private void minionGetBuffed(Minion m, int attackbuff, int hpbuff, bool own)
        {
            if (m.Angr == 0 && attackbuff >= 1) minionGetReady(m);

            m.Angr = Math.Max(0, m.Angr + attackbuff);
            
            if (hpbuff >= 1)
            {
                m.Hp = m.Hp + hpbuff;
                m.maxHp = m.maxHp + hpbuff;
            }
            else
            {
                //debuffing hp, lower only maxhp (unless maxhp < hp)
                m.maxHp = m.maxHp + hpbuff;
                if (m.maxHp < m.Hp)
                {
                    m.Hp = m.maxHp;
                }
            }


            if (m.maxHp == m.Hp)
            {
                m.wounded = false;
            }
            else
            {
                m.wounded = true;
            }

            if (m.name == "lichtbrut" && !m.silenced)
            {
                m.Angr = m.Hp;
            }

            if (m.Hp <= 0)
            {
                if (own)
                {
                    this.removeMinionFromList(m, this.ownMinions, true);
                    if (logging) help.logg("own " + m.name + " died");
                }
                else
                {
                    this.removeMinionFromList(m, this.enemyMinions, false);
                    if (logging) help.logg("enemy " + m.name + " died");
                }
            }
        }


        private void deleteWutanfall(Minion m, bool own)
        {
            if (m.name == "wuetendeshuhn")
            {
                minionGetBuffed(m, -5, 0, own);
            }
            if (m.name == "amaniberserker")
            {
                minionGetBuffed(m, -3, 0, own);
            }
            if (m.name == "taurenkrieger")
            {
                minionGetBuffed(m, -3, 0, own);
            }
            if (m.name == "grommashhoellschrei")
            {
                minionGetBuffed(m, -6, 0, own);
            }
            if (m.name == "tobenderworgen")
            {
                minionGetBuffed(m, -1, 0, own);
                minionGetWindfurry(m);
            }
            if (m.name == "hasserfuellteschmiedin")
            {
                if (own && this.ownWeaponDurability >= 1)
                {
                    this.ownWeaponAttack -= 2;
                    this.ownheroAngr -= 2;
                }
                if (!own && this.enemyWeaponDurability >= 1) this.enemyWeaponAttack -= 2;
            }
        }

        private void wutanfall(Minion m, bool woundedBefore, bool own) // = enrange effects
        {
            if (!m.card.Enrage) return; // if minion has no enrange, do nothing
            if (woundedBefore == m.wounded || m.silenced) return; // if he was wounded, and still is (or was unwounded) do nothing

            if (m.wounded && m.Hp >= 1) //is wounded, wasnt wounded before, grant wutanfall
            {
                if (m.name == "wuetendeshuhn")
                {
                    minionGetBuffed(m, 5, 0, own);
                }
                if (m.name == "amaniberserker")
                {
                    minionGetBuffed(m, 3, 0, own);
                }
                if (m.name == "taurenkrieger")
                {
                    minionGetBuffed(m, 3, 0, own);
                }
                if (m.name == "grommashhoellschrei")
                {
                    minionGetBuffed(m, 6, 0, own);
                }
                if (m.name == "tobenderworgen")
                {
                    minionGetBuffed(m, 1, 0, own);
                    minionGetWindfurry(m);
                }
                if (m.name == "hasserfuellteschmiedin")
                {
                    if (own && this.ownWeaponDurability >= 1)
                    {
                        this.ownWeaponAttack += 2;
                        this.ownheroAngr += 2;
                    }
                    if (!own && this.enemyWeaponDurability >= 1) this.enemyWeaponAttack += 2;
                }

            }

            if (!m.wounded) // reverse buffs
            {
                deleteWutanfall(m, own);
            }
        }

        private void triggerAHeroGetHealed(bool own)
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "lichtwaechterin")
                {
                    minionGetBuffed(mnn, 2, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "lichtwaechterin")
                {
                    minionGetBuffed(mnn, 2, 0, false);
                }
            }
        }

        private void triggerAMinionGetHealed(Minion m, bool own)
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "klerikerinvonnordhain")
                {
                    this.owncarddraw++;
                    drawACard("unknown");
                }
                if (mnn.name == "lichtwaechterin")
                {
                    minionGetBuffed(mnn, 2, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "klerikerinvonnordhain")
                {
                    this.enemycarddraw++;
                }
                if (mnn.name == "lichtwaechterin")
                {
                    minionGetBuffed(mnn, 2, 0, false);
                }
            }

        }

        private void triggerAMinionGetDamage(Minion m, bool own)
        {
            //minion take dmg
            if (m.name == "akolythdesschmerzes" && !m.silenced)
            {
                if (own)
                {
                    this.owncarddraw++;
                    drawACard("unknown");
                }
                else
                {
                    this.enemycarddraw++;
                }
            }
            if (m.name == "gurubashiberserker" && !m.silenced)
            {
                minionGetBuffed(m, 3, 0, own);
            }
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "wuetenderberserker")
                {
                    mnn.Angr++;
                }
                if (own)
                {
                    if (mnn.name == "ruestungsschmiedin")
                    {
                        this.ownHeroDefence++;
                    }
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "wuetenderberserker")
                {
                    mnn.Angr++;
                }
                if (!own)
                {
                    if (mnn.name == "ruestungsschmiedin")
                    {
                        this.enemyHeroDefence++;
                    }
                }
            }
        }

        private void minionGetDamagedOrHealed(Minion m, int damages, int heals, bool own)
        {
            minionGetDamagedOrHealed(m, damages, heals, own, false);
        }

        private void minionGetDamagedOrHealed(Minion m, int damages, int heals, bool own, bool dontCalcLostDmg)
        {
            int damage = damages;
            int heal = heals;

            bool woundedbefore = m.wounded;
            if (heal < 0) // heal was shifted in damage
            {
                damage = -1 * heal;
                heal = 0;
            }

            if (damage >= 1 && m.divineshild)
            {
                m.divineshild = false;
                if (!own && !dontCalcLostDmg) this.lostDamage += damage;
                return;
            }

            if (m.cantLowerHPbelowONE && damage >= 1 && damage >= m.Hp) damage = m.Hp - 1;

            if (!own && !dontCalcLostDmg && m.Hp < damage) lostDamage += damage - m.Hp;


            m.Hp = m.Hp - damage;

            int hpcopy = m.Hp;
            if (heal >= 1)
            {
                m.Hp = m.Hp + Math.Min(heal, m.maxHp - m.Hp);
            }



            if (heal >= 1)
            {
                triggerAMinionGetHealed(m, own);
                //minionWasHealed
            }

            if (damage >= 1)
            {
                triggerAMinionGetDamage(m, own);
            }

            if (m.maxHp == m.Hp)
            {
                m.wounded = false;
            }
            else
            {
                m.wounded = true;
            }

            this.wutanfall(m, woundedbefore, own);

            if (m.name == "lichtbrut" && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            if (m.Hp <= 0)
            {
                if (own)
                {
                    this.removeMinionFromList(m, this.ownMinions, true);
                    if (logging) help.logg("own " + m.name + " died");
                }
                else
                {
                    this.removeMinionFromList(m, this.enemyMinions, false);
                    if (logging) help.logg("enemy " + m.name + " died");
                }
            }
        }

        private void copyMinion(Minion target, Minion source)
        {
            target.name = source.name;
            target.Angr = source.Angr;
            target.card = CardDB.Instance.getCardDataFromID(source.card.CardID);
            target.charge = source.charge;
            target.divineshild = source.divineshild;
            target.exhausted = source.exhausted;
            target.frozen = source.frozen;
            target.Hp = source.Hp;
            target.immune = source.immune;
            target.maxHp = source.maxHp;
            target.playedThisTurn = source.playedThisTurn;
            target.poisonous = source.poisonous;
            target.silenced = source.silenced;
            target.stealth = source.stealth;
            target.taunt = source.taunt;
            target.windfury = source.windfury;
            target.wounded = source.wounded;
            target.Ready = false;
            if (target.charge) target.Ready = true;
            foreach (Enchantment e in source.enchantments)
            {
                Enchantment ne = CardDB.getEnchantmentFromCardID(e.CARDID);
                target.enchantments.Add(ne);
            }
        }

        private void removeMinionFromListNoDeath(Minion m, List<Minion> l, bool own)
        {
            l.Remove(m);
            int i = 0;
            foreach (Minion mnn in l)
            {
                mnn.id = i;
                mnn.zonepos = i + 1;
                i++;
            }
            this.endEffectsDueToDeath(m, own);
            adjacentBuffUpdate(own);
        }

        private void removeMinionFromList(Minion m, List<Minion> l, bool own)
        {
            l.Remove(m);
            int i = 0;
            foreach (Minion mnn in l)
            {
                mnn.id = i;
                mnn.zonepos = i + 1;
                i++;
            }

            this.endEffectsDueToDeath(m, own);
            this.deathrattle(m, own);
            this.triggerAMinionDied(m, own);
            adjacentBuffUpdate(own);

        }

        private void attack(int attacker, int target, bool dontcount)
        {
            Minion m = new Minion();
            bool attackOwn = true;
            if (attacker < 10)
            {
                m = this.ownMinions[attacker];
                attackOwn = true;
            }
            if (attacker >= 10 && attacker < 20)
            {
                m = this.enemyMinions[attacker - 10];
                attackOwn = false;
            }

            if (!dontcount)
            {
                m.numAttacksThisTurn++;
                if (m.windfury && m.numAttacksThisTurn == 2)
                {
                    m.Ready = false;
                }
                if (!m.windfury)
                {
                    m.Ready = false;
                }
            }

            if (logging) help.logg(".attck with" + m.name + " A " + m.Angr + " H " + m.Hp);
            
            if (target == 200)//target is hero
            {
                attackOrHealHero(m.Angr, false);
                return;
            }

            bool enemyOwn = false;
            Minion enemy = new Minion();
            if (target < 10)
            {
                enemy = this.ownMinions[target];
                enemyOwn = true;
            }

            if (target >= 10 && target < 20)
            {
                enemy = this.enemyMinions[target - 10];
                enemyOwn = false;
            }




            int ownAttack = m.Angr;
            int enemyAttack = enemy.Angr;
            // defender take damage
            if (m.card.poisionous)
            {
                minionGetDestroyed(enemy, enemyOwn);
            }
            else
            {
                int oldHP = enemy.Hp;
                minionGetDamagedOrHealed(enemy, ownAttack, 0, enemyOwn);
                if (oldHP > enemy.Hp && m.name == "wasserelementar") enemy.frozen = true;
            }


            //attacker take damage
            if (!m.immune)
            {
                if (enemy.card.poisionous)
                {
                    minionGetDestroyed(m, attackOwn);
                }
                else
                {
                    int oldHP = m.Hp;
                    minionGetDamagedOrHealed(m, enemyAttack, 0, attackOwn);
                    if (oldHP > m.Hp && enemy.name == "wasserelementar") m.frozen = true;
                }
            }
        }

        public void attackWithMinion(Minion ownMinion, int target, int targetEntity)
        {

            Action a = new Action();
            a.minionplay = true;
            a.owntarget = ownMinion.id;
            a.ownEntitiy = ownMinion.entitiyID;
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            this.playactions.Add(a);
            if (logging) help.logg("attck with" + ownMinion.name + " " + ownMinion.id + " trgt " + target + " A " + ownMinion.Angr + " H " + ownMinion.Hp);


            attack(ownMinion.id, target, false);

            //draw a card if the minion has enchantment from: Segen der weisheit 
            int segenderweisheitAnz = 0;
            foreach (Enchantment e in ownMinion.enchantments)
            {
                if (e.CARDID == "EX1_363e2" && e.controllerOfCreator == this.ownController)
                {
                    segenderweisheitAnz++;
                }
            }
            this.owncarddraw += segenderweisheitAnz;
            for (int i = 0; i < segenderweisheitAnz; i++)
            {
                drawACard("");
            }


        }

        private void addMiniontoList(Minion m, List<Minion> l, int pos, bool own)
        {
            List<Minion> newmins = new List<Minion>(l);
            l.Clear();

            int i = 0;
            foreach (Minion mnn in newmins)
            {

                if (pos == i)
                {
                    m.id = i;
                    m.zonepos = i + 1;
                    l.Add(m);
                    i++;
                }
                mnn.id = i;
                mnn.zonepos = i + 1;
                l.Add(mnn);
                i++;
            }
            // maybe he is last mob
            if (pos == i)
            {
                m.id = i;
                m.zonepos = i + 1;
                l.Add(m);
                i++;
            }
            adjacentBuffUpdate(own);
            triggerPlayedAMinion(m.card, own);

        }

        private Minion createNewMinion(CardDB.Card c, int placeOfNewMob, bool own)
        {
            Minion m = new Minion();
            m.card = c;
            m.entitiyID = c.entityID;
            m.Posix = 0;
            m.Posiy = 0;
            m.Angr = c.Attack;
            m.Hp = c.Health;
            m.maxHp = c.Health;
            m.name = c.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.id = placeOfNewMob;
            m.zonepos = placeOfNewMob + 1;


            if (c.windfury) m.windfury = true;
            if (c.tank) m.taunt = true;
            if (c.Charge)
            {
                m.Ready = true;
                m.charge = true;
            }

            if (c.poisionous) m.poisonous = true;

            if (c.Stealth) m.stealth = true;

            if (m.name == "lichtbrut" && !m.silenced)
            {
                m.Angr = m.Hp;
            }

            this.getNewEffects(m, own, placeOfNewMob, true);

            return m;
        }

        private void doBattleCryWithTargeting(Minion c, int target, int choice)
        {

            //target is the target AFTER spawning mobs
            int attackbuff = 0;
            int hpbuff = 0;
            int heal = 0;
            int damage = 0;
            bool spott = false;
            bool divineshild = false;
            bool windfury = false;
            bool silence = false;
            bool destroy = false;
            bool frozen = false;
            bool stealth = false;
            bool backtohand = false;

            bool own = true;

            if (target >= 10 && target < 20)
            {
                own = false;
            }
            Minion m = new Minion();
            if (target < 10)
            {
                m = this.ownMinions[target];
            }
            if (target >= 10 && target < 20)
            {
                m = this.enemyMinions[target - 10];
            }


            if (c.name == "urtumderlehren")
            {
                if (choice == 2)
                {
                    heal = 5;
                }
            }


            if (c.name == "hueterdeshains")
            {
                if (choice == 1)
                {
                    damage = 2;
                }

                if (choice == 2)
                {
                    silence = true;
                }
            }

            if (c.name == "verrueckteralchemist")
            {
                if (target < 10)
                {
                    bool woundedbef = m.wounded;
                    int temp = m.Angr;
                    m.Angr = m.Hp;
                    m.Hp = temp;
                    m.maxHp = temp;
                    m.wounded = false;
                    wutanfall(m, woundedbef, true);
                    if (m.Hp <= 0) minionGetDestroyed(m, true);
                }

                if (target >= 10 && target < 20)
                {
                    bool woundedbef = m.wounded;
                    int temp = m.Angr;
                    m.Angr = m.Hp;
                    m.Hp = temp;
                    m.maxHp = temp;
                    m.wounded = false;
                    wutanfall(m, woundedbef, false);
                    if (m.Hp <= 0) minionGetDestroyed(m, false);
                }

            }

            if (c.name == "si7-agent" && this.cardsPlayedThisTurn >= 1)
            {
                damage = 2;
            }
            if (c.name == "entfuehrer" && this.cardsPlayedThisTurn >= 1)
            {
                backtohand = true;
            }
            if (c.name == "meisterindertarnung")
            {
                stealth = true;
            }

            if (c.name == "kabaleschattenpriesterin")
            {
                minionGetControlled(m, true, false);
            }


            if (c.name == "eisenschnabeleule" || c.name == "zauberbrecher") //eisenschnabeleule, zauberbrecher
            {
                silence = true;
            }

            if (c.name == "blutelfenklerikerin")
            {
                attackbuff = 1;
                hpbuff = 1;
            }

            if (c.name == "uralterbraumeister")
            {
                backtohand = true;
            }
            if (c.name == "jungerbraumeister")
            {
                backtohand = true;
            }

            if (c.name == "dunkeleisenzwerg")
            {
                //attackbuff = 2;
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_046e");
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }

            if (c.name == "hungrigekrabbe")
            {
                destroy = true;
                /*Enchantment e = CardDB.getEnchantmentFromCardID("NEW1_017e");
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(c, e, true);//buff own hungrige krabbe*/
                minionGetBuffed(c, 2, 2, true);
            }

            if (c.name == "ruchloserunteroffizier")
            {
                Enchantment e = CardDB.getEnchantmentFromCardID("CS2_188o");
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }
            if (c.name == "fieserzuchtmeister")
            {
                attackbuff = 2;
                damage = 1;
            }

            if (c.name == "frostelementar")
            {
                frozen = true;
            }

            if (c.name == "elfenbogenschuetzin")
            {
                damage = 1;
            }
            if (c.name == "voodoodoktor")
            {
                heal = 2;
            }
            if (c.name == "vollstreckerdestempels")
            {
                hpbuff = 3;
            }
            if (c.name == "schuetzevoneisenschmiede")
            {
                damage = 1;
            }
            if (c.name == "sturmlanzenkommando")
            {
                damage = 2;
            }
            if (c.name == "hundemeister")
            {
                attackbuff = 2;
                hpbuff = 2;
                spott = true;
            }

            if (c.name == "friedensbewahrer")
            {
                attackbuff = 1 - m.Angr;
            }

            if (c.name == "derschwarzeritter")
            {
                destroy = true;
            }

            if (c.name == "argentumbeschuetzer")
            {
                divineshild = true; // Grants NO buff
            }

            if (c.name == "windsprecher")
            {
                windfury = true;
            }
            if (c.name == "feuerelementar")
            {
                damage = 3;
            }
            if (c.name == "seherdesirdenenrings")
            {
                heal = 3;
            }
            if (c.name == "grosswildjaeger")
            {
                destroy = true;
            }

            if (c.name == "alexstrasza")
            {
                if (target == 100)
                {
                    this.ownHeroHp = 15;

                }
                if (target == 200)
                {
                    this.enemyHeroHp = 15;
                }
            }

            if (c.name == "gesichtslosermanipulator")
            {//todo, test this :D

                copyMinion(c, m);
            }

            //make effect on target
            //ownminion
            if (target < 10)
            {
                if (attackbuff != 0 || hpbuff != 0)
                {
                    minionGetBuffed(m, attackbuff, hpbuff, true);
                }
                if (damage != 0 || heal != 0)
                {
                    minionGetDamagedOrHealed(m, damage, heal, true);
                }
                if (spott) m.taunt = true;
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, true);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, true);
                if (silence) minionGetSilenced(m, true);

            }
            //enemyminion
            if (target >= 10 && target < 20)
            {
                if (attackbuff != 0 || hpbuff != 0)
                {
                    minionGetBuffed(m, attackbuff, hpbuff, false);
                }
                if (damage != 0 || heal != 0)
                {
                    minionGetDamagedOrHealed(m, damage, heal, false);
                }
                if (spott) m.taunt = true;
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, false);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, false);
                if (silence) minionGetSilenced(m, false);
            }
            if (target == 100)
            {
                if (frozen) this.ownHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, true);
                if (heal >= 1) attackOrHealHero(-heal, true);
            }
            if (target == 200)
            {
                if (frozen) this.enemyHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, false);
                if (heal >= 1) attackOrHealHero(-heal, false);
            }

        }

        private void doBattleCryWithoutTargeting(Minion c, int position, bool own, int choice)
        {
            //only nontargetable battlecrys!

            //druid choices

            //urtum des krieges:
            if (c.name == "urtumdeskrieges")
            {
                if (choice == 1)
                {
                    minionGetBuffed(c, 5, 0, true);
                }
                if (choice == 2)
                {
                    minionGetBuffed(c, 0, 5, true);
                    c.taunt = true;
                }
            }

            if (c.name == "urtumderlehren")
            {
                if (choice == 1)
                {
                    this.owncarddraw += 2;
                    this.drawACard("");
                    this.drawACard("");
                }

            }

            if (c.name == "druidederklaue")
            {
                if (choice == 1)
                {
                    minionGetCharge(c);
                }
                if (choice == 2)
                {
                    minionGetBuffed(c, 0, 2, true);
                    c.taunt = true;
                }
            }

            if (c.name == "cenarius")
            {
                if (choice == 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        minionGetBuffed(m, 2, 2, true);
                    }
                }
                //choice 2 = spawn 2 kids
            }

            //normal ones

            if (c.name == "gedankenkontrolleur")
            {
                if (this.enemyMinions.Count >= 4)
                {
                    List<Minion> temp = new List<Minion>();

                    List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                    temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));//we take the weekest

                    temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                    Minion target = new Minion();
                    target = temp[0];
                    if (target.taunt && !temp[1].taunt) target = temp[1];
                    minionGetControlled(target, true, false);

                }
            }

            if (c.name == "teufelswache")
            {
                this.ownMaxMana--;
            }
            if (c.name == "arkangolem")
            {
                this.enemyMaxMana++;
            }

            if (c.name == "edwinvancleef" && this.cardsPlayedThisTurn >= 1)
            {
                minionGetBuffed(c, this.cardsPlayedThisTurn * 2, this.cardsPlayedThisTurn * 2, own);
            }

            if (c.name == "verdammniswache")
            {
                this.owncarddraw -= Math.Min(2, this.owncards.Count);
                this.owncards.RemoveRange(0, Math.Min(2, this.owncards.Count));
            }

            if (c.name == "sukkubus")
            {
                this.owncarddraw -= Math.Min(1, this.owncards.Count);
                this.owncards.RemoveRange(0, Math.Min(1, this.owncards.Count));
            }

            if (c.name == "lordjaraxxus")
            {
                this.ownHeroAblility = CardDB.Instance.getCardDataFromID("EX1_tk33");
                this.ownHeroName = "lordjaraxxus";
                this.ownHeroHp = c.Hp;
            }

            if (c.name == "flammenwichtel")
            {
                attackOrHealHero(3, own);
            }
            if (c.name == "grubenlord")
            {
                attackOrHealHero(5, own);
            }

            if (c.name == "schreckenderleere")
            {
                List<Minion> temp = new List<Minion>();
                if (own)
                {
                    temp.AddRange(this.ownMinions);
                }
                else
                {
                    temp.AddRange(this.enemyMinions);
                }

                int angr = 0;
                int hp = 0;
                foreach (Minion m in temp)
                {
                    if (m.id == position + 1 || m.id == position - 1)
                    {
                        angr += m.Angr;
                        hp += m.Hp;
                    }
                }
                foreach (Minion m in temp)
                {
                    if (m.id == position + 1 || m.id == position - 1)
                    {
                        minionGetDestroyed(m, own);
                    }
                }
                minionGetBuffed(c, angr, hp, own);

            }

            if (c.name == "frostwolfkriegsfuerst")
            {
                minionGetBuffed(c, this.ownMinions.Count, this.ownMinions.Count, own);
            }
            if (c.name == "blutsegelraeuberin")
            {
                c.Angr += this.ownWeaponAttack;
            }

            if (c.name == "suedmeerdeckmatrose" && this.ownWeaponDurability >= 1)
            {
                minionGetCharge(c);
            }



            if (c.name == "blutritter")
            {
                int shilds = 0;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.divineshild)
                    {
                        m.divineshild = false;
                        shilds++;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.divineshild)
                    {
                        m.divineshild = false;
                        shilds++;
                    }
                }
                minionGetBuffed(c, 3 * shilds, 3 * shilds, own);

            }

            if (c.name == "koenigmukla")
            {
                this.enemycarddraw += 2;
            }

            if (c.name == "tiefenlichtorakel")
            {
                this.enemycarddraw += 2;
                this.owncarddraw += 2;
                drawACard("unknown");
                drawACard("unknown");
            }

            if (c.name == "arathiwaffenschmiedin")
            {
                CardDB.Card wcard = CardDB.Instance.getCardData("streitaxt");
                this.equipWeapon(wcard);
                

            }
            if (c.name == "blutsegelkorsar")
            {
                this.lowerWeaponDurability(1, false);
            }

            if (c.name == "saeurehaltigerschlamm")
            {
                this.lowerWeaponDurability(1000, false);
            }
            if (c.name == "ingenieurslehrling")
            {
                this.owncarddraw++;
                drawACard("unknown");
            }
            if (c.name == "gnomischeerfinderin")
            {
                this.owncarddraw++;
                drawACard("unknown");
            }

            if (c.name == "dunkelschuppenheilerin")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {

                    minionGetDamagedOrHealed(m, 0, 2, true);

                }
                attackOrHealHero(-2, true);
            }
            if (c.name == "nachtklinge")
            {
                attackOrHealHero(3, !own);
            }

            if (c.name == "zwielichtdrache")
            {
                minionGetBuffed(c, 0, this.owncards.Count, true);
            }

            if (c.name == "azurblauerdrache")
            {
                this.owncarddraw++;
                drawACard("unknown");
            }

            if (c.name == "harrisonjones")
            {
                this.enemyWeaponAttack = 0;
                this.owncarddraw += enemyWeaponDurability;
                for (int i = 0; i < enemyWeaponDurability; i++)
                {
                    drawACard("unknown");
                }
                this.enemyWeaponDurability = 0;
            }

            if (c.name == "waechterderkoenige")
            {
                attackOrHealHero(-6, true);
            }

            if (c.name == "kapitaengruenhaut")
            {
                if (this.ownWeaponName != "")
                {
                    this.ownheroAngr += 1;
                    this.ownWeaponAttack++;
                    this.ownWeaponDurability++;
                }
            }

            if (c.name == "priesteringvonelune")
            {
                attackOrHealHero(-4, true);
            }
            if (c.name == "verletzterklingenmeister")
            {
                minionGetDamagedOrHealed(c, 4, 0, true);
            }

            if (c.name == "schreckenshoellenbestie")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    minionGetDamagedOrHealed(m, 1, 0, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion m in temp)
                {
                    minionGetDamagedOrHealed(m, 1, 0, false);
                }
                attackOrHealHero(1, false);
                attackOrHealHero(1, true);
            }

            if (c.name == "tundranashorn")
            {
                minionGetCharge(c);
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.card.race == TAG_RACE.PET)
                    {
                        minionGetCharge(m);
                    }
                }
            }

            if (c.name == "panischerkodo")
            {
                List<Minion> temp = new List<Minion>();
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//destroys the weakest
                temp.AddRange(temp2);
                foreach (Minion enemy in temp)
                {
                    if (enemy.Angr <= 2)
                    {
                        minionGetDestroyed(enemy, false);
                        break;
                    }
                }
            }

            if (c.name == "sonnenzornbeschuetzerin")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position + 1)
                    {
                        m.taunt = true;
                    }
                }
            }

            if (c.name == "uraltermagier")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position + 1)
                    {
                        m.card.spellpowervalue++;
                    }
                }
            }

            if (c.name == "verteidigervonargus")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position + 1)
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_093e");
                        e.creator = c.entitiyID;
                        e.controllerOfCreator = this.ownController;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                }
            }

            if (c.name == "tiefenlichtseher")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.card.race == TAG_RACE.MURLOC)
                    {
                        minionGetBuffed(m, 0, 2, true);
                    }
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.card.race == TAG_RACE.MURLOC)
                    {
                        minionGetBuffed(m, 0, 2, false);
                    }
                }
            }

            if (c.name == "todesschwinge")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }
                this.owncards.Clear();

            }

            if (c.name == "papageideskapitaens")
            {
                this.owncarddraw++;
                this.drawACard("");

            }



        }

        private int spawnKids(CardDB.Card c, int position, bool own, int choice)
        {
            int kids = 0;
            if (c.name == "murlocgezeitenjaeger")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("mulocspaeher");
                callKid(kid, position, own);

            }
            if (c.name == "jaegerderklingenhauer")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("eber");
                callKid(kid, position, own);

            }
            if (c.name == "drachlingmechanikerin")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("mechanischerdrachling");
                callKid(kid, position, own);

            }
            if (c.name == "leeroyjenkins")
            {
                kids = 2;
                CardDB.Card kid = CardDB.Instance.getCardData("welpling");
                int pos = this.ownMinions.Count - 1;
                if (own) pos = this.enemyMinions.Count - 1;
                callKid(kid, pos, !own);
                callKid(kid, pos, !own);

            }

            if (c.name == "cenarius" && choice == 2)
            {
                kids = 2;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_573t"); //special treant
                int pos = this.ownMinions.Count - 1;
                if (!own) pos = this.enemyMinions.Count - 1;
                callKid(kid, pos, own);
                callKid(kid, pos, own);

            }
            if (c.name == "ritterdersilbernenhand")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("knappe");
                callKid(kid, position, own);

            }
            if (c.name == "gelbinmekkadrill")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("zielsuchendeshuhn");
                callKid(kid, position, own);

            }

            if (c.name == "raedelsfuehrerderdefias" && this.cardsPlayedThisTurn >= 1) //needs combo for spawn
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("banditderdefias");
                callKid(kid, position, own);

            }
            if (c.name == "onyxia")
            {
                kids = 7 - this.ownMinions.Count;
                CardDB.Card kid = CardDB.Instance.getCardData("Welpling");
                for (int i = 0; i < kids; i++)
                {
                    callKid(kid, position, own);
                }


            }
            return kids;
        }

        private void callKid(CardDB.Card c, int placeoffather, bool own)
        {
            if (own && this.ownMinions.Count >= 7) return;
            if (!own && this.enemyMinions.Count >= 7) return;
            int mobplace = placeoffather + 1;
            /*if (own && this.ownMinions.Count >= 1)
            {
                retval.X = ownMinions[mobplace - 1].Posix + 85;
                retval.Y = ownMinions[mobplace - 1].Posiy;
            }
            if (!own && this.enemyMinions.Count >= 1)
            {
                retval.X = enemyMinions[mobplace - 1].Posix + 85;
                retval.Y = enemyMinions[mobplace - 1].Posiy;
            }*/

            Minion m = createNewMinion(c, mobplace, own);

            if (own)
            {
                addMiniontoList(m, this.ownMinions, mobplace, own);// additional minions span next to it!
            }
            else
            {
                addMiniontoList(m, this.enemyMinions, mobplace, own);// additional minions span next to it!
            }

        }

        private Action placeAmobSomewhere(CardDB.Card c, int cardpos, int target, int choice, int placepos)
        {

            Action a = new Action();
            a.cardplay = true;
            a.card = c;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;

            //we place him on the right!
            int mobplace = placepos;


            //create the minion out of the card + effects from other minions, which higher his hp/angr
            Minion m = createNewMinion(c, mobplace, true);




            //make the battlecry (where you dont need a target)
            doBattleCryWithoutTargeting(m, mobplace, true, choice);

            if (target >= 0)
            {
                doBattleCryWithTargeting(m, target, choice);

            }


            //maybe he spawns another minion
            addMiniontoList(m, this.ownMinions, mobplace, true);
            if (logging) help.logg("add " + m.card.name);


            // additional minions span next to it!
            int spawnkids = spawnKids(c, mobplace, true, choice); //  if a mob targets something, it doesnt spawn minions!?

            if (target >= 0)
            {
                // the OWNtargets right of the placed mobs are going up :D
                if (target < 10 && target > mobplace + spawnkids) target++;
            }


            a.enemytarget = target;
            a.owntarget = mobplace + 1; //1==before the 1.minion on board , 2 ==before the 2. minion o board (from left)
            return a;
        }

        private void lowerWeaponDurability(int value, bool own)
        {
            if (own)
            {
                this.ownWeaponDurability -= value;
                if (this.ownWeaponDurability <= 0)
                {
                    this.ownheroAngr -= this.ownWeaponAttack;
                    this.ownWeaponDurability = 0;
                    this.ownWeaponAttack = 0;
                    this.ownWeaponName = "";
                }
            }
            else
            {
                this.enemyWeaponDurability -= value;
                if (this.enemyWeaponDurability <= 0)
                {
                    this.enemyWeaponDurability = 0;
                    this.enemyWeaponAttack = 0;
                }
            }
        }


        private void equipWeapon(CardDB.Card c)
        {
            if (this.ownWeaponDurability >= 1) this.lostWeaponDamage += this.ownWeaponDurability * this.ownWeaponAttack;
            this.ownheroAngr = c.Attack;
            this.ownWeaponAttack = c.Attack;
            this.ownWeaponDurability = c.Durability;
            if (c.name == "schicksalshammer")
            {
                this.ownHeroWindfury = true;
            }
            else
            {
                this.ownHeroWindfury = false;
            }
            if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen) 
            {
                this.ownHeroReady = true;
            }
            if (c.name == "langbogendesgladiators")
            {
                this.heroImmuneWhileAttacking = true;
            }
            else
            {
                this.heroImmuneWhileAttacking = false;
            }

            foreach (Minion m in this.ownMinions)
            {
                if (m.name == "suedmeerdeckmatrose")
                {
                    minionGetCharge(m);
                }
            }

        }

        private void playCardWithTarget(CardDB.Card c, int target, int choice)
        {
            //play card with target
            int attackbuff = 0;
            int hpbuff = 0;
            int heal = 0;
            int damage = 0;
            bool spott = false;
            bool divineshild = false;
            bool windfury = false;
            bool silence = false;
            bool destroy = false;
            bool frozen = false;
            bool stealth = false;
            bool backtohand = false;
            bool charge = false;
            bool setHPtoONE = false;
            bool immune = false;
            int adjacentDamage = 0;
            bool sheep = false;
            bool frogg = false;
            //special
            bool geistderahnen = false;
            bool ueberwaeltigendemacht = false;

            bool own = true;

            if (target >= 10 && target < 20)
            {
                own = false;
            }
            Minion m = new Minion();
            if (target < 10)
            {
                m = this.ownMinions[target];
            }
            if (target >= 10 && target < 20)
            {
                m = this.enemyMinions[target - 10];
            }


            //warrior###########################################################################

            if (c.name == "hinrichten")
            {
                destroy = true;
            }

            if (c.name == "innerewut")
            {
                damage = 1;
                attackbuff = 2;
            }

            if (c.name == "zerschmettern")
            {
                damage = 2;
                if (m.Hp >= 3)
                {
                    this.owncarddraw++;
                    this.drawACard("");
                }
            }

            if (c.name == "toedlicherstoss")
            {
                damage = 4;
                if (ownHeroHp <= 12) damage = 6;
            }

            if (c.name == "schildschlag")
            {
                damage = this.ownHeroDefence;
            }

            if (c.name == "sturmangriff")
            {
                charge = true;
                attackbuff = 2;
            }

            if (c.name == "toben")
            {
                attackbuff = 3;
                hpbuff = 3;
            }

            //hunter#################################################################################

            if (c.name == "maldesjaegers")
            {
                setHPtoONE = true;
            }
            if (c.name == "arkanerschuss")
            {
                damage = 2;
            }
            if (c.name == "fass")
            {
                damage = 3;
                foreach (Minion mnn in this.ownMinions)
                {
                    if ((TAG_RACE)mnn.card.race == TAG_RACE.PET)
                    {
                        damage = 5;
                    }
                }
            }
            if (c.name == "zorndeswildtiers")
            {

                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_549o");
                e.creator = c.entityID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }

            if (c.name == "explosivschuss")
            {
                damage = 5;
                adjacentDamage = 1;
            }

            //mage###############################################################################

            if (c.name == "eislanze")
            {
                if (m.frozen)
                { damage = 4; }
                else { frozen = true; }
            }

            if (c.name == "kaeltekegel")
            {
                damage = 1;
                adjacentDamage = 1;
                frozen = true;
            }
            if (c.name == "feuerball")
            {
                damage = 6;
            }
            if (c.name == "verwandlung")
            {
                sheep = true;
            }

            if (c.name == "pyroschlag")
            {
                damage = 10;
            }

            if (c.name == "frostblitz")
            {
                damage = 3;
                frozen = true;
            }

            //pala######################################################################

            if (c.name == "demut")
            {
                m.Angr = 1;
            }
            if (c.name == "handdesschutzes")
            {
                divineshild = true;
            }
            if (c.name == "segendermacht")
            {
                attackbuff = 3;
            }
            if (c.name == "heiligeslicht")
            {
                heal = 6;
            }

            if (c.name == "hammerdeszorns")
            {
                damage = 3;
                this.owncarddraw++;
                drawACard("");
            }

            if (c.name == "segenderkoenige")
            {
                attackbuff = 4;
                hpbuff = 4;
            }

            if (c.name == "segenderweisheit")
            {
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_363e2");
                e.creator = c.entityID;
                e.controllerOfCreator = this.ownController;
                m.enchantments.Add(e);
            }

            if (c.name == "gesegneterchampion")
            {
                m.Angr *= 2;
            }
            if (c.name == "heiligerzorn")
            {
                damage = 2;
                this.owncarddraw++;
                drawACard("");
            }
            if (c.name == "handauflegung")
            {
                for (int i = 0; i < 3; i++)
                {
                    this.owncarddraw++;
                    this.drawACard("");
                }
                heal = 8;
            }

            //priest ##########################################

            if (c.name == "dunklerwahnsinn")
            {

                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_334e");
                e.creator = c.entityID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
                this.minionGetControlled(m, true, true);
            }

            if (c.name == "gedankenkontrolle")
            {
                this.minionGetControlled(m, true, false);
            }

            if (c.name == "heiligepein")
            {
                damage = 2;
            }
            if (c.name == "machtwortschild")
            {
                hpbuff = 2;
                this.owncarddraw++;
                this.drawACard("");
            }
            if (c.name == "stille")
            {
                silence = true;
            }
            if (c.name == "goettlicherwiller")
            {
                hpbuff = m.Hp;
            }
            if (c.name == "inneresfeuer")
            {
                m.Angr = m.Hp;
            }
            if (c.name == "heiligesfeuer")
            {
                damage = 5;
                int ownheal = getSpellHeal(5);
                attackOrHealHero(-ownheal, true);
            }
            if (c.name == "schattenwortschmerz")
            {
                destroy = true;
            }
            if (c.name == "schattenworttod")
            {
                destroy = true;
            }
            //rogue ##########################################
            if (c.name == "schattenschritt")
            {
                backtohand = true;
                m.card.cost = Math.Max(0, m.card.cost -= 2);
            }
            if (c.name == "kopfnuss")
            {
                backtohand = true;
            }
            if (c.name == "tueckischeklinge")
            {
                damage = 1;
                this.owncarddraw++;
                this.drawACard("");
            }
            if (c.name == "kaltbluetigkeit")
            {
                attackbuff = 2;
                if (this.cardsPlayedThisTurn >= 1) attackbuff = 4;
            }
            if (c.name == "verhuellen")
            {
                stealth = true;
            }
            if (c.name == "ausweiden")
            {
                damage = 2;
                if (this.cardsPlayedThisTurn >= 1) damage = 4;
            }
            if (c.name == "verrat")
            {
                //attack right neightbor
                if (target >= 10 && target < 20 && target < this.enemyMinions.Count + 10 - 1)
                {
                    attack(target, target + 1, true);
                }
                if (target < 10 && target < this.ownMinions.Count - 1)
                {
                    attack(target, target + 1, true);
                }

                //attack left neightbor
                if (target >= 11 || (target < 10 && target >= 1))
                {
                    attack(target, target - 1, true);
                }

            }

            if (c.name == "klingedesverderbens")
            {
                damage = 1;
                if (this.cardsPlayedThisTurn >= 1) damage = 2;
            }

            if (c.name == "meucheln")
            {
                damage = 2;
            }

            if (c.name == "attentat")
            {
                destroy = true;
            }
            //shaman ##########################################
            if (c.name == "blitzschlag")
            {
                damage = 3;
            }
            if (c.name == "frostschock")
            {
                frozen = true;
                damage = 1;
            }
            if (c.name == "waffedesfelsbeissers")
            {
                if (target <= 20)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_045e");
                    e.creator = c.entityID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                else
                {
                    if (target == 100)
                    {
                        this.ownheroAngr += 3;
                        if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                        {
                            this.ownHeroReady = true;
                        }
                    }
                }
            }
            if (c.name == "windzorn")
            {
                windfury = true;
            }
            if (c.name == "verhexung")
            {
                frogg = true;
            }
            if (c.name == "erdschock")
            {
                silence = true;
                damage = 1;
            }
            if (c.name == "geistderahnen")
            {
                geistderahnen = true;
            }
            if (c.name == "lavaeruption")
            {
                damage = 5;
            }

            if (c.name == "heilungderahnen")
            {
                heal = 1000;
                spott = true;
            }

            //hexenmeister ##########################################

            if (c.name == "opferpakt")
            {
                destroy = true;
                this.attackOrHealHero(getSpellHeal(5), true); // heal own hero
            }

            if (c.name == "seelenfeuer")
            {
                damage = 4;
                this.owncarddraw--;
                this.owncards.RemoveRange(0, Math.Min(1, this.owncards.Count));

            }
            if (c.name == "ueberwaeltigendemacht")
            {
                //only to own mininos
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_316e");
                e.creator = c.entityID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, true);
            }
            if (c.name == "verderbnis")
            {
                //only to enemy mininos
                Enchantment e = CardDB.getEnchantmentFromCardID("CS2_063e");
                e.creator = c.entityID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, false);
            }
            if (c.name == "weltlicheaengste")
            {
                damage = 1;
                if (getSpellDamageDamage(1) >= m.Hp && !m.divineshild && !m.immune)
                {
                    this.owncarddraw++;
                    this.drawACard("");
                }
            }
            if (c.name == "blutsauger")
            {
                damage = 2;
                attackOrHealHero(2, true);
            }
            if (c.name == "schattenblitz")
            {
                damage = 4;
            }
            if (c.name == "schattenflamme")
            {
                int damage1 = getSpellDamageDamage(m.Angr);
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDamagedOrHealed(mnn, damage1, 0, false);
                }
                //destroy own mininon
                destroy = true;
            }

            if (c.name == "daemonenfeuer")
            {
                if (m.card.race == 15 && own)
                {
                    attackbuff = 2;
                    hpbuff = 2;
                }
                else
                {
                    damage = 2;
                }
            }
            if (c.name == "omenderverdammnis")
            {
                damage = 2;
                if (getSpellDamageDamage(2) >= m.Hp && !m.divineshild && !m.immune)
                {
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardData("blutwichtel");
                    callKid(kid, posi, true);
                }
            }

            if (c.name == "seeleentziehen")
            {
                destroy = true;
                attackOrHealHero(3, true);

            }


            //druid #######################################################################

            if (c.name == "mondfeuer" && c.CardID == "CS2_008")// nicht zu verwechseln mit cenarius choice nummer 1
            {
                damage = 1;
            }

            if (c.name == "malderwildnis")
            {
                spott = true;
                attackbuff = 2;
                hpbuff = 2;
            }

            if (c.name == "heilendeberuehrung")
            {
                heal = 8;
            }

            if (c.name == "sternenfeuer")
            {
                damage = 5;
                this.owncarddraw++;
                this.drawACard("");
            }

            if (c.name == "kreislaufdernatur")
            {
                destroy = true;
                this.enemycarddraw += 2;
            }

            if (c.name == "unbaendigkeit")
            {
                damage = this.ownheroAngr;
            }

            if (c.name == "prankenhieb")
            {
                damage = 4;
                // all others get 1 spelldamage
                int damage1 = getSpellDamageDamage(1);
                if (target != 200)
                {
                    attackOrHealHero(damage1, false);
                }
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    if (mnn.id + 10 != target)
                    {
                        minionGetDamagedOrHealed(m, damage1, 0, false);
                    }
                }
            }

            //druid choices##################################################################################
            if (c.name == "zorn")
            {
                if (choice == 1)
                {
                    damage = 3;
                }
                if (choice == 2)
                {
                    damage = 1;
                    this.owncarddraw++;
                    this.drawACard("");
                }
            }

            if (c.name == "maldernatur")
            {
                if (choice == 1)
                {
                    attackbuff = 4;
                }
                if (choice == 2)
                {
                    spott = true;
                    hpbuff = 4;
                }
            }

            if (c.name == "sternenregen")
            {
                if (choice == 1)
                {
                    damage = 5;
                }

            }


            //special cards#########################################################################################

            if (c.name == "alptraum")
            {
                //only to own mininos
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_316e");
                e.creator = c.entityID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, true);
            }

            if (c.name == "traum")
            {
                backtohand = true;
            }

            if (c.name == "banane")
            {
                attackbuff = 1;
                hpbuff = 1;
            }

            if (c.name == "fasswurf")
            {
                damage = 2;
            }

            if (c.CardID == "PRO_001b")// i am murloc
            {
                damage = 4;
                this.owncarddraw++;
                this.drawACard("");

            } if (c.name == "derwillemuklas")
            {
                heal = 6 ;
            }

            //make effect on target
            //ownminion

            if (damage >= 1) damage = getSpellDamageDamage(damage);
            if (adjacentDamage >= 1) adjacentDamage = getSpellDamageDamage(adjacentDamage);
            if (heal >= 1 && heal < 1000) heal = getSpellHeal(heal);

            if (target < 10)
            {
                if (silence) minionGetSilenced(m, true);
                minionGetBuffed(m, attackbuff, hpbuff, true);
                minionGetDamagedOrHealed(m, damage, heal, true);
                if (spott) m.taunt = true;
                if (charge) minionGetCharge(m);
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, true);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, true);
                if (immune) m.immune = true;
                if (adjacentDamage >= 1)
                {
                    foreach (Minion mnn in this.ownMinions)
                    {
                        if (mnn.id == target + 1 || mnn.id == target - 1)
                        {
                            minionGetDamagedOrHealed(m, adjacentDamage, 0, own);
                            if (frozen) mnn.frozen = true;
                        }
                    }
                }
                if (sheep) minionTransform(m, CardDB.Instance.getCardDataFromID("CS2_tk1"), own);
                if (frogg) minionTransform(m, CardDB.Instance.getCardDataFromID("hexfrog"), own);
                if (setHPtoONE)
                {
                    m.Hp = 1; m.maxHp = 1;
                }

                if (geistderahnen)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_038e");
                    e.creator = c.entityID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, true);
                }


            }
            //enemyminion
            if (target >= 10 && target < 20)
            {
                if (silence) minionGetSilenced(m, false);
                minionGetBuffed(m, attackbuff, hpbuff, false);
                minionGetDamagedOrHealed(m, damage, heal, false);
                if (spott) m.taunt = true;
                if (charge) minionGetCharge(m);
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, false);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, false);
                if (immune) m.immune = true;
                if (adjacentDamage >= 1)
                {
                    foreach (Minion mnn in this.enemyMinions)
                    {
                        if (mnn.id + 10 == target + 1 || mnn.id + 10 == target - 1)
                        {
                            minionGetDamagedOrHealed(m, adjacentDamage, 0, own);
                            if (frozen) mnn.frozen = true;
                        }
                    }
                }
                if (sheep) minionTransform(m, CardDB.Instance.getCardDataFromID("CS2_tk1"), own);
                if (frogg) minionTransform(m, CardDB.Instance.getCardDataFromID("hexfrog"), own);
                if (setHPtoONE)
                {
                    m.Hp = 1; m.maxHp = 1;
                }
                if (geistderahnen)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_038e");
                    e.creator = c.entityID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, false);
                }

            }
            if (target == 100)
            {
                if (frozen) this.ownHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, true);
                if (heal >= 1) attackOrHealHero(-heal, true);
            }
            if (target == 200)
            {
                if (frozen) this.enemyHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, false);
                if (heal >= 1) attackOrHealHero(-heal, false);
            }

        }

        private void playCardWithoutTarget(CardDB.Card c, int choice)
        {

            //todo faehrtenlesen!

            //play card without target
            if (c.name == "diemuenze")
            {
                this.mana++;

            }
            //hunter#########################################################################
            if (c.name == "mehrfachschuss" && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(3);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the strongest
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }
            if (c.name == "tierbegleiter")
            {
                CardDB.Card c2 = CardDB.Instance.getCardData("misha");
                int placeoffather = this.ownMinions.Count - 1;
                callKid(c2, placeoffather, true);
            }

            if (c.name == "leuchtfeuer")
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.stealth = false;
                }
                foreach (Minion m in this.enemyMinions)
                {
                    m.stealth = false;
                }
                this.owncarddraw++;
                this.drawACard("");
                this.enemySecretCount = 0;
            }

            if (c.name == "lasstdiehundelos")
            {
                int anz = this.enemyMinions.Count;
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("jagdhund");
                for (int i = 0; i < anz; i++)
                {
                    callKid(kid, posi, true);
                }
            }

            if (c.name == "toedlicherschuss" && this.enemyMinions.Count >= 1)
            {
                List<Minion> temp = new List<Minion>();
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 1));
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }

            }

            //warrior#########################################################################
            if (c.name == "befehlsruf")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e1 = CardDB.getEnchantmentFromCardID("NEW1_036e");
                e1.creator = c.entityID;
                e1.controllerOfCreator = this.ownController;
                Enchantment e2 = CardDB.getEnchantmentFromCardID("NEW1_036e2");
                e2.creator = c.entityID;
                e2.controllerOfCreator = this.ownController;
                foreach (Minion mnn in temp)
                {//cantLowerHPbelowONE
                    addEffectToMinionNoDoubles(mnn, e1, true);
                    addEffectToMinionNoDoubles(mnn, e2, true);
                    mnn.cantLowerHPbelowONE = true;
                }

            }

            if (c.name == "kampfeswut")
            {
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.wounded)
                    {
                        this.owncarddraw++;
                        this.drawACard("");
                    }
                }

            }

            if (c.name == "scharmuetzel")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn,false);
                }

            }


            if (c.name == "spalten" && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(2);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

            if (c.name == "aufwertung" )
            {
                if (this.ownWeaponName != "")
                {
                    this.ownWeaponAttack++;
                    this.ownheroAngr++;
                    this.ownWeaponDurability++;
                }
                else
                {
                    CardDB.Card wcard = CardDB.Instance.getCardData("schwereaxt");
                    this.equipWeapon(wcard);
                }

            }



            if (c.name == "wirbelwind")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                temp.Clear();
                temp = new List<Minion>(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true);
                }
            }

            if (c.name == "heldenhafterstoss")
            {
                this.ownheroAngr = this.ownheroAngr + 4;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen) 
                {
                    this.ownHeroReady = true;
                }
            }

            if (c.name == "schildblock")
            {
                this.ownHeroDefence = this.ownHeroDefence + 5;
                this.owncarddraw++;
                drawACard("unknown");
            }



            //mage#########################################################################################

            if (c.name == "blizzard")
            {
                int damage = getSpellDamageDamage(2);
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }

                this.lostDamage += Math.Max(0, damage - maxHp); 

            }

            if (c.name == "arkanegeschosse")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                int damage = 1;
                int ammount = getSpellDamageDamage(3);
                int i = 0;
                int hp = 0;
                foreach (Minion enemy in temp)
                {
                    if (enemy.Hp >= 2)
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                        i++;
                        hp += enemy.Hp;
                        if (i == ammount) break;
                    }
                    
                }
                if (i < ammount) attackOrHealHero(ammount - i, false);

            }
            if (c.name == "arkaneintelligenz")
            {
                this.owncarddraw++;
                this.drawACard("");
                this.drawACard("");
            }

            if (c.name == "spiegelbild")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("spiegelbildminion");
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == "arkaneexplosion")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
            }
            if (c.name == "frostnova")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                }

            }
            if (c.name == "flammenstoss")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(4);
                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }
                this.lostDamage += Math.Max(0, damage - maxHp); 

            }

            //pala#################################################################
            if (c.name == "weihe")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

                attackOrHealHero(damage, false);
            }

            if (c.name == "gleichheit")
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.Hp = 1;
                    m.maxHp = 1;
                }
                foreach (Minion m in this.enemyMinions)
                {
                    m.Hp = 1;
                    m.maxHp = 1;
                }

            }
            if (c.name == "goettlichegunst")
            {
                int enemcardsanz = this.enemyAnzCards + this.enemycarddraw;
                int diff = enemcardsanz - this.owncards.Count;
                if (diff >= 1)
                {
                    for (int i = 0; i < diff; i++)
                    {
                        this.owncarddraw++;
                        this.drawACard("");
                    }
                }
            }

            if (c.name == "zornigevergeltung")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = 1;
                int i = 0;
                if (temp.Count >= 1)
                {
                    foreach (Minion enemy in temp)
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                        i++;
                        if (i == 8) break;
                    }
                }
                else
                {
                    damage = getSpellDamageDamage(8);
                    attackOrHealHero(damage, false);
                }

            }


            //priest ####################################################
            if (c.name == "kreisderheilung")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int heal = getSpellHeal(4);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, true);
                }

            }
            if (c.name == "gedankenraub")
            {
                this.owncarddraw++;
                this.drawACard("enemycard");
                this.owncarddraw++;
                this.drawACard("enemycard");
            }
            if (c.name == "gedankensicht")
            {
                if (this.enemyAnzCards >= 1)
                {
                    this.owncarddraw++;
                    this.drawACard("enemycard");
                }
            }

            if (c.name == "schattengestalt")
            {
                if (this.ownHeroAblility.CardID == "CS1h_001") // lesser heal becomes mind spike
                {
                    this.ownHeroAblility = CardDB.Instance.getCardDataFromID("EX1_625t");
                }
                else
                {
                    this.ownHeroAblility = CardDB.Instance.getCardDataFromID("EX1_625t2");  // mindspike becomes mind shatter
                }
            }

            if (c.name == "gedankenspiele")
            {
                CardDB.Card copymin = CardDB.Instance.getCardDataFromID("CS2_152"); //we draw a knappe :D (worst case)
                callKid(copymin, this.ownMinions.Count - 1, true);
            }

            if (c.name == "massenbannung")
            {
                foreach (Minion m in this.enemyMinions)
                {
                    minionGetSilenced(m, false);
                }
            }
            if (c.name == "gedankenschlag")
            {
                int damage = getSpellDamageDamage(5);
                attackOrHealHero(damage, false);
            }

            if (c.name == "kreisderheilung")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                int heal = getSpellHeal(2);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, false);
                }
                attackOrHealHero(-heal, true);
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true);
                }
                attackOrHealHero(damage, true);

            }
            //rogue #################################################
            if (c.name == "vorbereitung")
            {
                this.playedPreparation = true;
            }
            if (c.name == "klingenwirbel")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = this.ownWeaponAttack;
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                attackOrHealHero(damage, false);

                //destroy own weapon
                this.lowerWeaponDurability(1000, true);
            }
            if (c.name == "schaedelbruch")
            {
                int damage = getSpellDamageDamage(2);
                attackOrHealHero(damage, false);
                if (this.cardsPlayedThisTurn >= 1) this.owncarddraw++; // DONT DRAW A CARD WITH (drawAcard()) because we get this NEXT turn 
            }
            if (c.name == "finstererstoss")
            {
                int damage = getSpellDamageDamage(3);
                attackOrHealHero(damage, false);
            }
            if (c.name == "toedlichesgift")
            {
                if (this.ownWeaponName != "")
                {
                    this.ownWeaponAttack += 2;
                    this.ownheroAngr += 2;
                }
            }
            if (c.name == "dolchfaecher")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
            }

            if (c.name == "sprinten")
            {
                for (int i = 0; i < 4; i++)
                {
                    this.owncarddraw++;
                    this.drawACard("");
                }

            }

            if (c.name == "verschwinden")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int heal = getSpellHeal(4);
                foreach (Minion enemy in temp)
                {
                    minionReturnToHand(enemy, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionReturnToHand(enemy, true);
                }

            }

            //shaman #################################################
            if (c.name == "gabelblitzschlag" && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(2);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

            if (c.name == "fernsicht")
            {
                this.owncarddraw++;
                this.drawACard("");

            }

            if (c.name == "gewittersturm")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);

                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }
                this.lostDamage += Math.Max(0, damage - maxHp); 

            }
            if (c.name == "wildgeist")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("geisterwolf");
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == "machtdertotems")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.card.race == 21) // if minion is a totem, buff it
                    {
                        minionGetBuffed(m, 0, 2, true);
                    }
                }

            }

            if (c.name == "kampfrausch")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_046e");
                    e.creator = this.ownController;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, true);
                }
            }


            //hexenmeister #################################################
            if (c.name == "daemonenwahrnehmen")
            {
                this.owncarddraw += 2;
                this.drawACard("");
                this.drawACard("");


            }
            if (c.name == "wirbelndernether")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, true);
                }

            }

            if (c.name == "hoellenfeuer")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(3);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                attackOrHealHero(damage, true);
                attackOrHealHero(damage, false);

            }


            //druid #################################################
            if (c.name == "seeledeswaldes")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_158e");
                e.creator = c.entityID;
                e.controllerOfCreator = this.ownController;
                foreach (Minion enemy in temp)
                {
                    addEffectToMinionNoDoubles(enemy, e, true);
                }
            }

            if (c.name == "anregen")
            {
                this.mana = Math.Min(this.mana + 2  ,10);

            }

            if (c.name == "biss")
            {
                this.ownheroAngr += 4;
                this.ownHeroDefence += 4;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }

            }

            if (c.name == "klaue")
            {
                this.ownheroAngr += 2;
                this.ownHeroDefence += 2;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }

            }

            if (c.name == "naturgewalt")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_tk9");//Treant
                callKid(kid, posi, true);
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == "machtderwildnis")// macht der wildnis with summoning
            {
                if (choice == 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        minionGetBuffed(m, 1, 1, true);
                    }
                }
                if (choice == 2)
                {
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_160t");//panther
                    callKid(kid, posi, true);
                }
            }

            if (c.name == "sternenregen")
            {
                if (choice == 2)
                {
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    int damage = getSpellDamageDamage(2);
                    foreach (Minion enemy in temp)
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }

            }

            if (c.name == "pflege")
            {
                if (choice == 1)
                {
                    if (this.ownMaxMana == 10)
                    {
                        this.owncarddraw++;
                        this.drawACard("ueberschuessigesmana");
                    }
                    else
                    {
                        this.ownMaxMana++;
                        this.mana++;
                    }
                    if (this.ownMaxMana == 10)
                    {
                        this.owncarddraw++;
                        this.drawACard("ueberschuessigesmana");
                    }
                    else
                    {
                        this.ownMaxMana++;
                        this.mana++;
                    }
                }
                if (choice == 2)
                {
                    this.owncarddraw+=3;
                    this.drawACard("");
                    this.drawACard("");
                    this.drawACard("");
                }
            }

            //special cards#######################

            if (c.CardID == "PRO_001a")// i am murloc
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("PRO_001at");//panther
                callKid(kid, posi, true);
                callKid(kid, posi, true);
                callKid(kid, posi, true);

            }

            if (c.CardID == "PRO_001c")// i am murloc
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_021");//scharfseher
                callKid(kid, posi, true);

            }

            if (c.name == "wildwuchs")
            {
                if (this.ownMaxMana == 10)
                {
                    this.owncarddraw++;
                    this.drawACard("ueberschuessigesmana");
                }
                else
                {
                    this.ownMaxMana++;
                }

            }

            if (c.name == "ueberschuessigesmana")
            {
                this.owncarddraw++;
                this.drawACard("");
            }

            if (c.name == "yseraerwacht")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(5);
                foreach (Minion enemy in temp)
                {
                    if (enemy.name != "ysera")// dont attack ysera
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    if (enemy.name != "ysera")//dont attack ysera
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }
                attackOrHealHero(damage, true);
                attackOrHealHero(damage, false);

            }

            if (c.name == "stampfen" )
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

        }

        private void drawACard(string ss)
        {
            string s = ss;
            if (s == "") s = "unknown";
            if (s == "enemycard") s = "unknown"; // NO PENALITY FOR DRAWING TO MUCH CARDS

            if (this.owncards.Count >= 10) return; // cant hold more than 10 cards
            if (s == "unknown")
            {
                CardDB.Card plchldr = new CardDB.Card();
                plchldr.name = "unknown";
                plchldr.cost = 1000;
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = plchldr;
                hc.position = this.owncards.Count + 1;
                this.owncards.Add(hc);
            }
            if (s == "feuerball")
            {
                CardDB.Card c = CardDB.Instance.getCardData("feuerball");
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = c;
                hc.position = this.owncards.Count + 1;
                this.owncards.Add(hc);
            }

        }

        private void triggerPlayedAMinion(CardDB.Card c, bool own)
        {
            if (own) // effects only for OWN minons
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.silenced) continue;

                    if (m.name == "messerjongleur") 
                    {
                        if (this.enemyMinions.Count >= 1)
                        {
                            List<Minion> temp = new List<Minion>();
                            int damage = 1;
                            List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                            temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                            temp.AddRange(Helpfunctions.TakeList(temp2, 1));
                            foreach (Minion enemy in temp)
                            {
                                minionGetDamagedOrHealed(enemy, damage, 0, false);
                            }

                        }
                        else
                        {
                            this.attackOrHealHero(1, false);
                        }
                    }

                    if (own && m.name == "verhungernderbussard" && (TAG_RACE)c.race == TAG_RACE.PET)
                    {
                        this.owncarddraw++;
                        this.drawACard("");
                    }
                
                }


            }


            //effects for ALL minons
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced) continue;
                if (m.name == "murlocgezeitenrufer" && c.race == 14)
                {
                    minionGetBuffed(m, 1, 0, true);
                }
                if (m.name == "truebaugederalte" && c.race == 14)
                {
                    minionGetBuffed(m, 1, 0, true);
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced) continue;
                //truebaugederalte
                if (m.name == "murlocgezeitenrufer" && c.race == 14)
                {
                    minionGetBuffed(m, 1, 0, false);
                }
                if (m.name == "truebaugederalte" && c.race == 14)
                {
                    minionGetBuffed(m, 1, 0, false);
                }
            }


        }

        private void triggerPlayedASpell(CardDB.Card c)
        {

            bool wilderpyro = false;
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced) continue;

                if (m.name == "manawyrm")
                {
                    minionGetBuffed(m, 1, 0, true);
                }

                if (m.name == "manasuechtige")
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_055o");
                    e.creator = m.entitiyID;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, true);
                }

                if (m.name == "geheimnisbewahrerin" && c.Secret)
                {
                    minionGetBuffed(m, 1, 1, true);
                }

                if (m.name == "erzmagierantonidas")
                {
                    drawACard("feuerball");
                }

                if (m.name == "violetteausbilderin")
                {

                    CardDB.Card d = CardDB.Instance.getCardData("violetterlehrling");
                    callKid(d, m.id, true);
                }

                if (m.name == "goblinauktionator")
                {
                    this.owncarddraw++;
                    drawACard("unknown");
                }
                if (m.name == "wilderpyromant")
                {
                    wilderpyro = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {

                if (m.name == "geheimnisbewahrerin" && c.Secret)
                {
                    minionGetBuffed(m, 1, 1, true);
                }
            }

            if (wilderpyro)
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.silenced) continue;

                    if (m.name == "wilderpyromant")
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        foreach (Minion mnn in temp2)
                        {
                            minionGetDamagedOrHealed(mnn, 1, 0, true);
                        }
                        temp2.Clear();
                        temp2.AddRange(this.enemyMinions);
                        foreach (Minion mnn in temp2)
                        {
                            minionGetDamagedOrHealed(mnn, 1, 0, false);
                        }
                    }
                }
            }

        }

        public void removeCard(int cardpos)
        {

            this.owncards.RemoveAll(x => x.position == (cardpos + 1));
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.position > cardpos + 1)
                {
                    hc.position--;
                }
            }

        }

        public void playCard(CardDB.Card c, int cardpos, int cardEntity, int target, int targetEntity, int choice, int placepos)
        {
            // lock at frostnova (click) / frostblitz (no click)
            this.mana = this.mana - c.getManaCost(this);

            if (c.Secret)
            {
                this.ownSecretsIDList.Add(c.CardID);
                this.playedmagierinderkirintor = false;
            }
            if (c.type == CardDB.cardtype.SPELL) this.playedPreparation = false;


            if (logging) help.logg("play crd" + c.name + " " + cardEntity + " " + c.getManaCost(this) + " trgt " + target);

            if (c.type == CardDB.cardtype.MOB)
            {
                Action b = this.placeAmobSomewhere(c, cardpos, target, choice,placepos);
                b.druidchoice = choice;
                b.owntarget = placepos;
                b.enemyEntitiy = targetEntity;
                b.cardEntitiy = cardEntity;
                this.playactions.Add(b);
                this.mobsplayedThisTurn++;
                if (c.name == "magierinderkirintor") this.playedmagierinderkirintor = true;

            }
            else
            {
                Action a = new Action();
                a.cardplay = true;
                a.card = c;
                a.cardEntitiy = cardEntity;
                a.numEnemysBeforePlayed = this.enemyMinions.Count;

                a.owntarget = 0;
                if (target >= 0)
                {
                    a.owntarget = -1;
                }
                a.enemytarget = target;
                a.enemyEntitiy = targetEntity;
                a.druidchoice = choice;

                if (target == -1)
                {
                    //card with no target
                    if (c.type == CardDB.cardtype.WEAPON)
                    {
                        equipWeapon(c);
                    }
                    playCardWithoutTarget(c, choice);
                }
                else //before : if(target >=0 && target < 20)
                {
                    if (c.type == CardDB.cardtype.WEAPON)
                    {
                        equipWeapon(c);
                    }
                    playCardWithTarget(c, target, choice);
                }

                this.playactions.Add(a);

                if (c.type == CardDB.cardtype.SPELL)
                {
                    this.triggerPlayedASpell(c);
                }
            }

            triggerACardGetPlayed(c);

            removeCard(cardpos);// remove card



            this.ueberladung += c.recallValue;

            this.cardsPlayedThisTurn++;

        }

        private void triggerACardGetPlayed(CardDB.Card c)
        {
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion mnn in temp)
            {
                if (mnn.silenced) continue;
                if (mnn.name == "illidansturmgrimm")
                {
                    CardDB.Card d = CardDB.Instance.getCardData("flammevonazzinoth");
                    callKid(d, mnn.id, true);
                }
                if (mnn.name == "rastloserabenteurer")
                {
                    minionGetBuffed(mnn, 1, 1, true);
                }
                if (mnn.name == "entfesselterelementar" && c.recallValue >= 1)
                {
                    minionGetBuffed(mnn, 1, 1, true);
                }
            }
        }

        public void attackWithWeapon(int target, int targetEntity)
        {
            //this.ownHeroAttackedInRound = true;
            this.ownHeroNumAttackThisTurn++;
            if ((this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 2) || (!this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1))
            {
                this.ownHeroReady = false;
            }
            Action a = new Action();
            a.heroattack = true;
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.owntarget = 100;
            a.ownEntitiy = this.ownHeroEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            this.playactions.Add(a);

            if (this.ownWeaponName == "echtsilberchampion")
            {
                this.attackOrHealHero(-2, true);
            }

            if (logging) help.logg("attck with weapon " +a.owntarget + " "+ a.ownEntitiy + " trgt: " + a.enemytarget + " " +a.enemyEntitiy );

            if (target == 200)
            {
                attackOrHealHero(this.ownheroAngr, false);
                return;
            }

            Minion enemy = this.enemyMinions[target - 10];
            minionGetDamagedOrHealed(enemy, this.ownheroAngr, 0, false);

            if (!this.heroImmuneWhileAttacking)
            {
                attackOrHealHero(enemy.Angr, true);
                if (enemy.name == "wasserelementar")
                {
                    this.ownHeroFrozen = true;
                }
            }

            //todo
            if (ownWeaponName == "blutschrei")
            {
                this.ownWeaponAttack--;
                this.ownheroAngr--;
            }
            else
            {
                this.lowerWeaponDurability(1, true);
            }

        }

        public void activateAbility(CardDB.Card c, int target, int targetEntity)
        {
            string heroname = this.ownHeroName;
            this.ownAbilityReady = false;
            this.mana -= 2;
            Action a = new Action();
            a.useability = true;
            a.card = c;
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            this.playactions.Add(a);

            if (logging) help.logg("play ability on target " + target);

            if (heroname == "mage")
            {
                int damage = 1;
                if (target == 100)
                {
                    attackOrHealHero(damage, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(damage, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, damage, 0, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, damage, 0, false);
                        }
                    }
                }

            }

            if (heroname == "priest")
            {
                int heal = 2;
                if (this.auchenaiseelenpriesterin) heal = -2;

                if (c.name == "gedankenstachel")
                {
                    heal = -1 * 2;
                }
                if (c.name == "gedankenzersplitterung")
                {
                    heal = -1 * 3;
                }

                if (target == 100)
                {
                    attackOrHealHero(-1 * heal, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(-1 * heal, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, 0, heal, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, 0, heal, false);
                        }
                    }
                }

            }

            if (heroname == "warrior")
            {
                this.ownHeroDefence += 2;
            }

            if (heroname == "warlock")
            {
                this.owncarddraw++;
                drawACard("unknown");
                this.attackOrHealHero(2, true);
            }


            if (heroname == "thief")
            {

                CardDB.Card wcard = CardDB.Instance.getCardData("tueckischesmesser");
                this.equipWeapon(wcard);
            }

            if (heroname == "druid")
            {
                this.ownheroAngr += 1;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen) 
                {
                    this.ownHeroReady = true;
                }
                this.ownHeroDefence += 1;
            }


            if (heroname == "hunter")
            {
                this.attackOrHealHero(2, false);
            }

            if (heroname == "pala")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("rekrutdersilbernenhand");
                callKid(kid, posi, true);
            }

            if (heroname == "shaman")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("heiltotem");
                callKid(kid, posi, true);
            }

            if (heroname == "lordjaraxxus")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("hoellenbestie");
                callKid(kid, posi, true);
            }


        }

        public void doAction()
        {
            /*if (this.playactions.Count >= 1)
            {
                Action a = this.playactions[0];

                if (a.cardplay)
                {
                    if (logging) help.logg("play " + a.card.name);
                    if (logging) help.logg("with position " + a.cardplace.X + "," + a.cardplace.Y);
                    help.clicklauf(a.cardplace.X, a.cardplace.Y);
                    if (a.owntarget >= 0)
                    {
                        if (logging) help.logg("on position " + a.ownplace.X + "," + a.ownplace.Y);
                        help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    }
                    if (a.enemytarget >= 0)
                    {
                        if (logging) help.logg("and target to " + a.enemytarget + ": on " + a.targetplace.X + ", " + a.targetplace.Y);
                        help.clicklauf(a.targetplace.X, a.targetplace.Y);
                    }
                }
                if (a.minionplay)
                {
                    if (logging) help.logg("attacker: " + a.owntarget + " enemy: " + a.enemytarget);
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    System.Threading.Thread.Sleep(500);
                    if (logging) help.logg("targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                    help.clicklauf(a.targetplace.X, a.targetplace.Y);
                }
                if (a.heroattack)
                {
                    if (logging) help.logg("attack with hero, enemy: " + a.enemytarget);
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    if (logging) help.logg("targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                    help.clicklauf(a.targetplace.X, a.targetplace.Y);
                }
                if (a.useability)
                {
                    if (logging) help.logg("useability ");
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    if (a.enemytarget >= 0)
                    {
                        if (logging) help.logg("on enemy: " + a.enemytarget + "targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                        help.clicklauf(a.targetplace.X, a.targetplace.Y);
                    }
                }

            }
            else
            {
                // click endturnbutton
                help.clicklauf(939, 353);
            }
            help.laufmaus(915, 400, 6);
             */
        }

        public void printBoard()
        {
            help.logg("board: "+ value);
            help.logg("cardsplayed: " + this.cardsPlayedThisTurn + " handsize: " + this.owncards.Count);
            help.logg("ownhero: ");
            help.logg("ownherohp: " + this.ownHeroHp + " + " + this.ownHeroDefence);
            help.logg("ownheroattac: " + this.ownheroAngr);
            help.logg("ownheroweapon: " + this.ownWeaponAttack + " " + this.ownWeaponDurability + " " + this.ownWeaponName);
            help.logg("ownherostatus: frozen" + this.ownHeroFrozen + " ");
            help.logg("enemyherohp: " + this.enemyHeroHp + " + " + this.enemyHeroDefence);
            help.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                help.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }

            help.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                help.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }


            help.logg("");
        }

        public Action getNextAction()
        {
            if (this.playactions.Count >= 1) return this.playactions[0];
            return null;
        }

        public void printActions()
        {
            foreach (Action a in this.playactions)
            {
                if (a.cardplay)
                {
                    help.logg("play " + a.card.name);
                    if (a.druidchoice >= 1) help.logg("choose choise " + a.druidchoice);
                    help.logg("with position " + a.cardEntitiy);
                    if (a.owntarget >= 0)
                    {
                        help.logg("on position " + a.ownEntitiy);
                    }
                    if (a.enemytarget >= 0)
                    {
                        help.logg("and target to " + a.enemytarget + " " + a.enemyEntitiy);
                    }
                }
                if (a.minionplay)
                {
                    help.logg("attacker: " + a.owntarget + " enemy: " + a.enemytarget);
                    help.logg("targetplace " + a.enemyEntitiy);
                }
                if (a.heroattack)
                {
                    help.logg("attack with hero, enemy: " + a.enemytarget);
                    help.logg("targetplace " + a.enemyEntitiy);
                }
                if (a.useability)
                {
                    help.logg("useability ");
                    if (a.enemytarget >= 0)
                    {
                        help.logg("on enemy: " + a.enemytarget + "targetplace " + a.enemyEntitiy);
                    }
                }
                help.logg("");
            }
        }

    }

}
