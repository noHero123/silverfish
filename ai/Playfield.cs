namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public struct triggerCounter
    {
        public int minionsGotHealed;
        public int ownMinionsGotHealed;

        public int charsGotHealed;
        public int owncharsGotHealed;

        public int ownMinionsGotDmg;
        public int enemyMinionsGotDmg;

        public int ownHeroGotDmg;
        public int enemyHeroGotDmg;

        public int ownMinionsDied;
        public int enemyMinionsDied;
        public int ownBeastDied;
        public int enemyBeastDied;
        public int ownMechanicDied;
        public int enemyMechanicDied;
        public int ownMurlocDied;
        public int enemyMurlocDied;

        public bool ownMinionsChanged;
        public bool enemyMininsChanged;
    }

    //todo save "started" variables outside (they doesnt change)

    public class Playfield
    {
        //Todo: delete all new list<minion>
        //TODO: graveyard change (list <card,owner>)
        //Todo: vanish clear all auras/buffs (NEW1_004)

        public bool logging = false;
        public bool complete = false;

        public bool isServer = false;
        public static Random randomGeneratorInstance = new Random();//speedup thanxs to xytrix
        public Random randomGenerator = null;  // local reference to prevent changing all code locations

        //dont have to be copied! (server doesnt copy)
        public List<Handmanager.Handcard> myDeck ;
        public List<Handmanager.Handcard> enemyDeck ;
        public List<Handmanager.Handcard> EnemyCards ;
        public List<CardDB.cardIDEnum> EnemySecretsIDList ;
        //------------

        public int nextEntity = 70;

        public triggerCounter tempTrigger = new triggerCounter();

        //Entity=PLAYER tag=HEROPOWER_ACTIVATIONS_THIS_TURN
        //Entity=PLAYER tag=NUM_TIMES_HERO_POWER_USED_THIS_GAME

        //aura minions##########################
        //todo reduce buffing vars
        public int anzOwnRaidleader = 0;
        public int anzEnemyRaidleader = 0;
        public int anzOwnStormwindChamps = 0;
        public int anzEnemyStormwindChamps = 0;
        public int anzOwnTundrarhino = 0;
        public int anzEnemyTundrarhino = 0;
        public int anzOwnTimberWolfs = 0;
        public int anzEnemyTimberWolfs = 0;
        public int anzMurlocWarleader = 0;
        public int anzGrimscaleOracle = 0;
        public int anzOwnAuchenaiSoulpriest = 0;
        public int anzEnemyAuchenaiSoulpriest = 0;
        public int anzOwnsorcerersapprentice = 0;
        public int anzEnemysorcerersapprentice = 0;
        public int anzOwnSouthseacaptain = 0;
        public int anzEnemySouthseacaptain = 0;
        public int anzOwnMalGanis = 0;
        public int anzEnemyMalGanis = 0;

        //new ones TGT##########################

        public int ownSaboteur = 0;
        public int enemySaboteur = 0;
        public int anzOwnFencingCoach = 0;
        public int anzEnemyFencingCoach = 0;

        public int anzOwnGarrisonCommander = 0;//also used for ColdarraDrake
        public int anzEnemyGarrisonCommander = 0;//also used for ColdarraDrake
        public int anzOwnFallenHeros = 0;
        public int anzEnemyFallenHeros = 0;
        public int anzownShadowfiends = 0;
        public int anzEnemyShadowfiends = 0;
        public int anzOwnFizzlebang=0;
        public int anzEnemyFizzlebang=0;
        public int anzOwnBuccaneer = 0;
        public int anzEnemyBuccaneer = 0;
        public int anzOwnAviana = 0;
        public int anzEnemyAviana = 0;
        public int  anzOwnAcidMaw =0;
        public int anzEnemyAcidMaw=0;
        public int anzOwnWarhorseTrainer = 0;
        public int anzEnemyWarhorseTrainer = 0;
        public int anzOwnMaidenOfTheLake = 0;
        public int anzEnemyMaidenOfTheLake = 0;

        public int anzOwnWarsongCommanders = 0;
        public int anzEnemyWarsongCommanders = 0;

        //new ones LOE##########################

        public int anzOwnBranns = 0;
        public int anzEnemyBranns = 0;

        //##########################

        public int anzOwnMechwarper = 0;
        public int anzOwnMechwarperStarted = 0;
        public int anzEnemyMechwarper = 0;
        public int anzEnemyMechwarperStarted = 0;

        public bool feugenDead = false;
        public bool stalaggDead = false;

        public bool weHavePlayedMillhouseManastorm = false;
        public bool enemyHavePlayedMillhouseManastorm = false;

        public bool weHaveSteamwheedleSniper = false;
        public bool enemyHaveSteamwheedleSniper = false;

        public bool needGraveyard = false;


        public int doublepriest = 0;
        public int enemydoublepriest = 0;

        public int ownDragonConsort = 0;
        public int enemyDragonConsort = 0;

        public int ownBaronRivendare = 0;
        public int enemyBaronRivendare = 0;
        //#########################################
        //new variables LOE
        public int selectedChoice = -1;
        public int anzownNagaSeaWitch = 0;
        public int anzenemyNagaSeaWitch = 0;
        public int anzOwnAnimatedArmor = 0;
        public int anzEnemyAnimatedArmor = 0;
        public int anzEnemyCursed = 0;
        //############################

        public int tempanzOwnCards = 0; // for Goblin Sapper
        public int tempanzEnemyCards = 0;// for Goblin Sapper

        public bool isOwnTurn = true; // its your turn?
        public int turnCounter = 0;
        public bool sEnemTurn = false;//should the enemy turn be simulated?

        public bool attacked = false;
        public int attackFaceHP = 15;

        public int evaluatePenality = 0;
        public int ownController = 0;

        //public int ownHeroEntity = -1;
        //public int enemyHeroEntity = -1;

        public int hashcode = 0;
        public float value = Int32.MinValue;
        //public int guessingHeroHP = 30;

        public int mana = 0;
        public int manaTurnEnd = 0;
        public int numEnemySecretsTurnEnd = 0;



        public List<CardDB.cardIDEnum> ownSecretsIDList = new List<CardDB.cardIDEnum>();
        public List<SecretItem> enemySecretList = new List<SecretItem>();

        public int enemySecretCount = 0;

        public Minion ownHero;
        public Minion enemyHero;
        public HeroEnum ownHeroName = HeroEnum.druid;
        public HeroEnum enemyHeroName = HeroEnum.druid;

        public CardDB.cardName ownWeaponName = CardDB.cardName.unknown;
        public int ownWeaponAttack = 0;
        public int ownWeaponDurability = 0;

        public CardDB.cardName enemyWeaponName = CardDB.cardName.unknown;
        public int enemyWeaponAttack = 0;
        public int enemyWeaponDurability = 0;

        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public List<GraveYardItem> diedMinions = null;
        public int anzMinionsDiedThisTurn = 0;

        public int numPlayerMinionsAtTurnStart = 0;
        public int loathebLastTurn = 0;  // only checked for turn 2 bonus

        public List<Handmanager.Handcard> owncards = new List<Handmanager.Handcard>();
        public int owncarddraw = 0;

        public List<Action> playactions = new List<Action>();

        public int enemycarddraw = 0;
        public int enemyAnzCards = 0;

        public int spellpower = 0;
        public int enemyspellpower = 0;

        public bool playedmagierinderkirintor = false;
        public bool playedPreparation = false;

        public int ownloatheb = 0;
        public int enemyloatheb = 0;

        public int pintsizedsummoner = 0;
        public int managespenst = 0;
        public int soeldnerDerVenture = 0;
        public int beschwoerungsportal = 0;
        public int nerubarweblord = 0;

        public int mobsplayedThisTurn = 0;

        
        public int optionsPlayedThisTurn = 0;
        public int cardsPlayedThisTurn = 0;
        public int owedRecall = 0; //=recall
        public int currentRecall = 0;
        public int enemyRecall = 0;
        public int enemyCurrentRecall = 0;//only needed for enemys turn sim.

        public int enemyOptionsDoneThisTurn = 0;

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int lostDamage = 0;
        public int lostHeal = 0;
        public int lostWeaponDamage = 0;

        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int ownHeroFatigue = 0;
        public int enemyHeroFatigue = 0;

        public int heroPowerActivationsThisTurn = 0;//new----------
        public int lockAndLoads = 0;//new------------

        public bool ownAbilityReady = false;
        public Handmanager.Handcard ownHeroAblility;
        public int own_TIMES_HERO_POWER_USED_THIS_GAME = 0;//new----------

        public bool enemyAbilityReady = false;
        public Handmanager.Handcard enemyHeroAblility;
        public int enemy_TIMES_HERO_POWER_USED_THIS_GAME = 0;//new----------

        // just for saving which minion to revive with secrets (=the first one that died);
        public CardDB.cardIDEnum revivingOwnMinion = CardDB.cardIDEnum.None;
        public CardDB.cardIDEnum revivingEnemyMinion = CardDB.cardIDEnum.None;

        //Helpfunctions help = Helpfunctions.Instance;

        private void addMinionsReal(List<Minion> source, List<Minion> trgt)
        {
            foreach (Minion m in source)
            {
                trgt.Add(new Minion(m));
            }

        }

        private void addCardsReal(List<Handmanager.Handcard> source)
        {

            foreach (Handmanager.Handcard m in source)
            {
                this.owncards.Add(new Handmanager.Handcard(m));
            }

        }

        public Playfield()
        {
            this.nextEntity = 1000;
            this.randomGenerator = randomGeneratorInstance;
            //this.simulateEnemyTurn = Ai.Instance.simulateEnemyTurn;
            this.ownController = Hrtprozis.Instance.getOwnController();

            //this.ownHeroEntity = Hrtprozis.Instance.ownHeroEntity;
            //this.enemyHeroEntity = Hrtprozis.Instance.enemyHeroEntitiy;

            this.mana = Hrtprozis.Instance.currentMana;
            this.manaTurnEnd = this.mana;
            this.numEnemySecretsTurnEnd = 0;
            this.ownMaxMana = Hrtprozis.Instance.ownMaxMana;
            this.enemyMaxMana = Hrtprozis.Instance.enemyMaxMana;
            this.evaluatePenality = 0;
            this.ownSecretsIDList.AddRange(Hrtprozis.Instance.ownSecretList);
            this.enemySecretCount = Hrtprozis.Instance.enemySecretCount;


            this.attackFaceHP = Hrtprozis.Instance.attackFaceHp;

            this.complete = false;

            addMinionsReal(Hrtprozis.Instance.ownMinions, ownMinions);
            addMinionsReal(Hrtprozis.Instance.enemyMinions, enemyMinions);
            this.ownHero = new Minion(Hrtprozis.Instance.ownHero);
            this.enemyHero = new Minion(Hrtprozis.Instance.enemyHero);
            addCardsReal(Handmanager.Instance.handCards);

            this.enemySecretList.Clear();
            if (Settings.Instance.useSecretsPlayArround)
            {
                foreach (SecretItem si in Probabilitymaker.Instance.enemySecrets)
                {
                    this.enemySecretList.Add(new SecretItem(si));
                }
            }

            this.ownHeroName = Hrtprozis.Instance.heroname;
            this.enemyHeroName = Hrtprozis.Instance.enemyHeroname;


            //####buffs#############################

            this.anzOwnRaidleader = 0;
            this.anzEnemyRaidleader = 0;
            this.anzOwnStormwindChamps = 0;
            this.anzEnemyStormwindChamps = 0;
            this.anzOwnTundrarhino = 0;
            this.anzEnemyTundrarhino = 0;
            this.anzOwnTimberWolfs = 0;
            this.anzEnemyTimberWolfs = 0;
            this.anzMurlocWarleader = 0;
            this.anzGrimscaleOracle = 0;
            this.anzOwnAuchenaiSoulpriest = 0;
            this.anzEnemyAuchenaiSoulpriest = 0;
            this.anzOwnsorcerersapprentice = 0;
            this.anzEnemysorcerersapprentice = 0;
            this.anzOwnSouthseacaptain = 0;
            this.anzEnemySouthseacaptain = 0;
            this.anzOwnWarsongCommanders = 0;
            this.anzEnemyWarsongCommanders = 0;
            this.anzownNagaSeaWitch = 0;
            this.anzenemyNagaSeaWitch = 0;

            this.feugenDead = Probabilitymaker.Instance.feugenDead;
            this.stalaggDead = Probabilitymaker.Instance.stalaggDead;

            this.doublepriest = 0;
            this.enemydoublepriest = 0;

            this.ownDragonConsort = Hrtprozis.Instance.ownDragonConsort;
            this.enemyDragonConsort = Hrtprozis.Instance.enemyDragonConsort;

            //tgt---new
            this.weHavePlayedMillhouseManastorm = (Hrtprozis.Instance.ownMillhouse >= 1) ? true : false;//CHANGED!!!
            this.enemyHavePlayedMillhouseManastorm = (Hrtprozis.Instance.enemyMillhouse >= 1) ? true : false; //CHANGED!!!
            this.ownloatheb = Hrtprozis.Instance.ownLoatheb;//CHANGED!!!
            this.enemyloatheb = Hrtprozis.Instance.enemyLoatheb;//CHANGED!!!
            this.ownSaboteur = Hrtprozis.Instance.ownSaboteur;
            this.enemySaboteur = Hrtprozis.Instance.enemySaboteur;
            this.anzOwnFencingCoach = Hrtprozis.Instance.ownFenciCoaches;
            this.anzEnemyFencingCoach = 0; // dont needed yet. D:
            //----


            this.playedmagierinderkirintor = (Hrtprozis.Instance.ownKirinTorEffect>=1)? true:false;
            this.playedPreparation = (Hrtprozis.Instance.ownPreparation >= 1) ? true : false;

            this.ownBaronRivendare = 0;
            this.enemyBaronRivendare = 0;
            //#########################################

            this.ownWeaponDurability = Hrtprozis.Instance.heroWeaponDurability;
            this.ownWeaponAttack = Hrtprozis.Instance.heroWeaponAttack;
            this.ownWeaponName = Hrtprozis.Instance.ownHeroWeapon;
            this.owncarddraw = 0;


            this.enemyWeaponAttack = Hrtprozis.Instance.enemyWeaponAttack;//dont know jet
            this.enemyWeaponName = Hrtprozis.Instance.enemyHeroWeapon;
            this.enemyWeaponDurability = Hrtprozis.Instance.enemyWeaponDurability;
            this.enemycarddraw = 0;

            this.enemyAnzCards = Handmanager.Instance.enemyAnzCards;

            this.ownAbilityReady = Hrtprozis.Instance.ownAbilityisReady;
            this.ownHeroAblility = new Handmanager.Handcard(Hrtprozis.Instance.heroAbility);
            this.enemyHeroAblility = new Handmanager.Handcard(Hrtprozis.Instance.enemyAbility);
            this.enemyAbilityReady = false;

            this.own_TIMES_HERO_POWER_USED_THIS_GAME = Hrtprozis.Instance.ownHeroPowerUsesThisGame;
            this.enemy_TIMES_HERO_POWER_USED_THIS_GAME = Hrtprozis.Instance.enemyHeroPowerUsesThisGame;
            this.heroPowerActivationsThisTurn = Hrtprozis.Instance.heroPowerUsesThisTurn;
            this.lockAndLoads = Hrtprozis.Instance.lockAndLoads;


            this.mobsplayedThisTurn = Hrtprozis.Instance.numMinionsPlayedThisTurn;
            this.cardsPlayedThisTurn = Hrtprozis.Instance.cardsPlayedThisTurn;
            //todo:
            this.optionsPlayedThisTurn = Hrtprozis.Instance.numOptionsPlayedThisTurn;

            this.owedRecall = Hrtprozis.Instance.owedRecall;
            this.currentRecall = Hrtprozis.Instance.ownCurrentRecall;
            this.enemyRecall = Hrtprozis.Instance.enemyRecall;
            this.enemyCurrentRecall = 0;

            this.ownHeroFatigue = Hrtprozis.Instance.ownHeroFatigue;
            this.enemyHeroFatigue = Hrtprozis.Instance.enemyHeroFatigue;
            this.ownDeckSize = Hrtprozis.Instance.ownDeckSize;
            this.enemyDeckSize = Hrtprozis.Instance.enemyDeckSize;

            this.anzEnemyCursed = Hrtprozis.Instance.enemyCursedCardsinHand;


            this.selectedChoice = -1;

            this.pintsizedsummoner = 0;
            this.managespenst = 0;
            this.soeldnerDerVenture = 0;
            this.beschwoerungsportal = 0;
            this.nerubarweblord = 0;

            this.ownBaronRivendare = 0;
            this.enemyBaronRivendare = 0;

            needGraveyard = false;

            anzOwnGarrisonCommander = 0;
            anzEnemyGarrisonCommander = 0;
            anzOwnFallenHeros = 0;
            anzEnemyFallenHeros = 0;
            anzownShadowfiends = 0;
            anzEnemyShadowfiends = 0;
            anzOwnFizzlebang=0;
            anzEnemyFizzlebang=0;
            anzOwnBuccaneer = 0;
            anzEnemyBuccaneer = 0;
            anzOwnAviana = 0;
            anzEnemyAviana = 0;
            anzOwnAcidMaw =0;
            anzEnemyAcidMaw=0;
            anzOwnWarhorseTrainer = 0;
            anzEnemyWarhorseTrainer = 0;
            anzOwnMaidenOfTheLake = 0;
            anzEnemyMaidenOfTheLake = 0;
            anzOwnBranns = 0;
            anzEnemyBranns = 0;

            anzOwnAnimatedArmor = 0;
            anzEnemyAnimatedArmor = 0;

            this.spellpower = 0;
            this.enemyspellpower = 0;

            int i = -1;
            int anz = this.ownMinions.Count;
            foreach (Minion m in this.ownMinions)
            {
                i++;
                if (m.playedThisTurn && m.name == CardDB.cardName.loatheb) this.ownloatheb ++;

                spellpower = spellpower + m.spellpower;
                if (m.silenced) continue;
                //spellpower += m.handcard.card.spellpowervalue; // its allready in m.spellpower! (if you are updating it in silverfish.getMinions() :P)
                if (m.name == CardDB.cardName.prophetvelen) this.doublepriest++;

                if (m.name == CardDB.cardName.weespellstopper)
                {
                    if (i > 0) this.ownMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                    if (i < anz - 1) this.ownMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                }
                if (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight || m.name == CardDB.cardName.arcanenullifierx21) m.cantBeTargetedBySpellsOrHeroPowers = true;

                if (m.name == CardDB.cardName.pintsizedsummoner)
                {
                    this.pintsizedsummoner++;
                }

                if (m.name == CardDB.cardName.manawraith)
                {
                    this.managespenst++;
                }
                if (m.name == CardDB.cardName.nerubarweblord)
                {
                    this.nerubarweblord++;
                }
                if (m.name == CardDB.cardName.venturecomercenary)
                {
                    this.soeldnerDerVenture++;
                }
                if (m.name == CardDB.cardName.summoningportal)
                {
                    this.beschwoerungsportal++;
                }

                if (m.name == CardDB.cardName.baronrivendare)
                {
                    this.ownBaronRivendare++;
                }
                if (m.name == CardDB.cardName.kelthuzad)
                {
                    this.needGraveyard = true;
                }

                //TGT-----

                if (m.name == CardDB.cardName.coldarradrake) this.anzOwnGarrisonCommander += 1000;
                if (m.name == CardDB.cardName.garrisoncommander) this.anzOwnGarrisonCommander += 1;
                if (m.name == CardDB.cardName.fallenhero) this.anzOwnFallenHeros += 1;
                if (m.name == CardDB.cardName.shadowfiend) this.anzownShadowfiends += 1;
                if (m.name == CardDB.cardName.wilfredfizzlebang) this.anzOwnFizzlebang += 1;
                if (m.name == CardDB.cardName.buccaneer) this.anzOwnBuccaneer += 1;
                if (m.name == CardDB.cardName.aviana) this.anzOwnAviana += 1;
                if (m.name == CardDB.cardName.acidmaw) this.anzOwnAcidMaw += 1;
                if (m.name == CardDB.cardName.warhorsetrainer) this.anzOwnWarhorseTrainer += 1;
                if (m.name == CardDB.cardName.maidenofthelake) this.anzOwnMaidenOfTheLake += 1;
                if (m.name == CardDB.cardName.warsongcommander) this.anzOwnWarsongCommanders += 1;

                if (m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.leokk) this.anzOwnRaidleader++;
                if (m.name == CardDB.cardName.malganis) this.anzOwnMalGanis++;
                if (m.name == CardDB.cardName.stormwindchampion) this.anzOwnStormwindChamps++;
                if (m.name == CardDB.cardName.tundrarhino) this.anzOwnTundrarhino++;
                if (m.name == CardDB.cardName.timberwolf) this.anzOwnTimberWolfs++;
                if (m.name == CardDB.cardName.murlocwarleader) this.anzMurlocWarleader++;
                if (m.name == CardDB.cardName.grimscaleoracle) this.anzGrimscaleOracle++;
                if (m.name == CardDB.cardName.auchenaisoulpriest) this.anzOwnAuchenaiSoulpriest++;

                if (m.name == CardDB.cardName.nagaseawitch) this.anzownNagaSeaWitch++;

                if (m.name == CardDB.cardName.fallenhero) this.anzOwnFallenHeros++;

                if (m.name == CardDB.cardName.brannbronzebeard) this.anzOwnBranns++;

                if (m.name == CardDB.cardName.animatedarmor) this.anzOwnAnimatedArmor++;

                if (m.name == CardDB.cardName.sorcerersapprentice)
                {
                    this.anzOwnsorcerersapprentice++;
                }
                if (m.name == CardDB.cardName.southseacaptain) this.anzOwnSouthseacaptain++;
                if (m.name == CardDB.cardName.mechwarper)
                {
                    this.anzOwnMechwarper++;
                    this.anzOwnMechwarperStarted++;
                }
                if (m.name == CardDB.cardName.steamwheedlesniper && this.ownHeroName == HeroEnum.hunter)
                {
                    this.weHaveSteamwheedleSniper = true;
                }

            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.name == CardDB.cardName.kelthuzad)
                {
                    this.needGraveyard = true;
                }
            }

            i = - 1;
            anz = this.enemyMinions.Count;
            foreach (Minion m in this.enemyMinions)
            {
                i++;
                this.enemyspellpower = this.enemyspellpower + m.spellpower;
                //enemyspellpower += m.handcard.card.spellpowervalue;//its allready in m.spellpower!!!
                
                if (m.silenced) continue;

                if (m.name == CardDB.cardName.weespellstopper)
                {
                    if (i > 0) this.enemyMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                    if (i < anz - 1) this.enemyMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                }
                if (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight || m.name == CardDB.cardName.arcanenullifierx21) m.cantBeTargetedBySpellsOrHeroPowers = true;

                if (m.name == CardDB.cardName.prophetvelen) this.enemydoublepriest++;
                if (m.name == CardDB.cardName.manawraith)
                {
                    this.managespenst++;
                }
                if (m.name == CardDB.cardName.nerubarweblord)
                {
                    this.nerubarweblord++;
                }
                if (m.name == CardDB.cardName.baronrivendare)
                {
                    this.enemyBaronRivendare++;
                }
                if (m.name == CardDB.cardName.kelthuzad)
                {
                    this.needGraveyard = true;
                }

                if (m.name == CardDB.cardName.coldarradrake)
                {
                    this.anzEnemyGarrisonCommander += 1000;
                }

                if (m.name == CardDB.cardName.coldarradrake) this.anzEnemyGarrisonCommander += 1000;
                if (m.name == CardDB.cardName.garrisoncommander) this.anzEnemyGarrisonCommander += 1;
                if (m.name == CardDB.cardName.fallenhero) this.anzEnemyFallenHeros += 1;
                if (m.name == CardDB.cardName.shadowfiend) this.anzEnemyShadowfiends += 1;
                if (m.name == CardDB.cardName.wilfredfizzlebang) this.anzEnemyFizzlebang += 1;
                if (m.name == CardDB.cardName.buccaneer) this.anzEnemyBuccaneer += 1;
                if (m.name == CardDB.cardName.aviana) this.anzEnemyAviana += 1;
                if (m.name == CardDB.cardName.acidmaw) this.anzEnemyAcidMaw += 1;
                if (m.name == CardDB.cardName.warhorsetrainer) this.anzEnemyWarhorseTrainer += 1;
                if (m.name == CardDB.cardName.maidenofthelake) this.anzEnemyMaidenOfTheLake += 1;
                if (m.name == CardDB.cardName.warsongcommander) this.anzEnemyWarsongCommanders += 1;

                if (m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.leokk) this.anzEnemyRaidleader++;
                if (m.name == CardDB.cardName.malganis) this.anzEnemyMalGanis++;
                if (m.name == CardDB.cardName.stormwindchampion) this.anzEnemyStormwindChamps++;
                if (m.name == CardDB.cardName.tundrarhino) this.anzEnemyTundrarhino++;
                if (m.name == CardDB.cardName.timberwolf) this.anzEnemyTimberWolfs++;
                if (m.name == CardDB.cardName.murlocwarleader) this.anzMurlocWarleader++;
                if (m.name == CardDB.cardName.grimscaleoracle) this.anzGrimscaleOracle++;
                if (m.name == CardDB.cardName.auchenaisoulpriest) this.anzEnemyAuchenaiSoulpriest++;

                if (m.name == CardDB.cardName.nagaseawitch) this.anzenemyNagaSeaWitch++;

                if (m.name == CardDB.cardName.fallenhero) this.anzEnemyFallenHeros++;

                if (m.name == CardDB.cardName.brannbronzebeard) this.anzEnemyBranns++;

                if (m.name == CardDB.cardName.animatedarmor) this.anzEnemyAnimatedArmor++;

                if (m.name == CardDB.cardName.sorcerersapprentice)
                {
                    this.anzEnemysorcerersapprentice++;
                }
                if (m.name == CardDB.cardName.southseacaptain) this.anzEnemySouthseacaptain++;
                if (m.name == CardDB.cardName.mechwarper)
                {
                    this.anzEnemyMechwarper++;
                    this.anzEnemyMechwarperStarted++;
                }
                if (m.name == CardDB.cardName.steamwheedlesniper && this.enemyHeroName == HeroEnum.hunter)
                {
                    this.enemyHaveSteamwheedleSniper = true;
                }
            }
            if (this.enemySecretCount >= 1) this.needGraveyard = true;
            if (this.needGraveyard) this.diedMinions = new List<GraveYardItem>(Probabilitymaker.Instance.turngraveyard);
            this.anzMinionsDiedThisTurn = Hrtprozis.Instance.numberMinionsDiedThisTurn;

            this.tempanzOwnCards = this.owncards.Count;
            this.tempanzEnemyCards = this.enemyAnzCards;

            //calculate the "real"-manacosts of a card
            foreach (Handmanager.Handcard hm in this.owncards)
            {
                hm.manacost = hm.card.getStartManaCosts(this, hm.manacost);
            }


        }

        public Playfield(Playfield p)
        {
            this.isServer = p.isServer;
            this.nextEntity = p.nextEntity;
            this.randomGenerator = randomGeneratorInstance;

            this.isOwnTurn = p.isOwnTurn;
            this.turnCounter = p.turnCounter;

            this.attacked = p.attacked;
            this.sEnemTurn = p.sEnemTurn;
            this.ownController = p.ownController;
            //this.ownHeroEntity = p.ownHeroEntity;
            //this.enemyHeroEntity = p.enemyHeroEntity;

            this.evaluatePenality = p.evaluatePenality;
            this.ownSecretsIDList.AddRange(p.ownSecretsIDList);

            this.enemySecretCount = p.enemySecretCount;

            this.enemySecretList.Clear();
            if (Settings.Instance.useSecretsPlayArround)
            {
                foreach (SecretItem si in p.enemySecretList)
                {
                    this.enemySecretList.Add(new SecretItem(si));
                }
            }

            this.mana = p.mana;
            this.manaTurnEnd = p.manaTurnEnd;
            this.numEnemySecretsTurnEnd = p.numEnemySecretsTurnEnd;
            this.ownMaxMana = p.ownMaxMana;
            this.enemyMaxMana = p.enemyMaxMana;
            addMinionsReal(p.ownMinions, ownMinions);
            addMinionsReal(p.enemyMinions, enemyMinions);
            this.ownHero = new Minion(p.ownHero);
            this.enemyHero = new Minion(p.enemyHero);
            addCardsReal(p.owncards);

            this.ownHeroName = p.ownHeroName;
            this.enemyHeroName = p.enemyHeroName;

            this.playactions.AddRange(p.playactions);
            this.complete = false;

            this.attackFaceHP = p.attackFaceHP;

            this.owncarddraw = p.owncarddraw;

            this.enemyWeaponAttack = p.enemyWeaponAttack;
            this.enemyWeaponDurability = p.enemyWeaponDurability;
            this.enemyWeaponName = p.enemyWeaponName;
            this.enemycarddraw = p.enemycarddraw;
            this.enemyAnzCards = p.enemyAnzCards;

            this.ownWeaponDurability = p.ownWeaponDurability;
            this.ownWeaponAttack = p.ownWeaponAttack;
            this.ownWeaponName = p.ownWeaponName;

            this.lostDamage = p.lostDamage;
            this.lostWeaponDamage = p.lostWeaponDamage;
            this.lostHeal = p.lostHeal;

            this.ownAbilityReady = p.ownAbilityReady;
            this.enemyAbilityReady = p.enemyAbilityReady;
            this.ownHeroAblility = new Handmanager.Handcard(p.ownHeroAblility);
            this.enemyHeroAblility = new Handmanager.Handcard(p.enemyHeroAblility);

            //tgt new
            this.own_TIMES_HERO_POWER_USED_THIS_GAME = p.own_TIMES_HERO_POWER_USED_THIS_GAME;
            this.enemy_TIMES_HERO_POWER_USED_THIS_GAME = p.enemy_TIMES_HERO_POWER_USED_THIS_GAME;
            this.heroPowerActivationsThisTurn = p.heroPowerActivationsThisTurn;
            this.lockAndLoads = p.lockAndLoads;
            this.ownSaboteur = p.ownSaboteur;//dont ask...
            this.enemySaboteur = p.enemySaboteur;//dont ask... :D
            this.anzOwnFencingCoach = p.anzOwnFencingCoach;
            this.anzEnemyFencingCoach = p.anzEnemyFencingCoach; // dont needed yet. D:
            //---

            this.spellpower = 0;
            this.mobsplayedThisTurn = p.mobsplayedThisTurn;
            this.optionsPlayedThisTurn = p.optionsPlayedThisTurn;
            this.cardsPlayedThisTurn = p.cardsPlayedThisTurn;
            this.owedRecall = p.owedRecall;
            this.currentRecall = p.currentRecall;
            this.enemyRecall = p.enemyRecall;
            this.enemyCurrentRecall = p.enemyCurrentRecall;

            this.ownDeckSize = p.ownDeckSize;
            this.enemyDeckSize = p.enemyDeckSize;
            this.ownHeroFatigue = p.ownHeroFatigue;
            this.enemyHeroFatigue = p.enemyHeroFatigue;

            //need the following for manacost-calculation

            this.playedmagierinderkirintor = p.playedmagierinderkirintor;


            this.nerubarweblord = p.nerubarweblord;
            this.pintsizedsummoner = p.pintsizedsummoner;
            this.managespenst = p.managespenst;
            this.soeldnerDerVenture = p.soeldnerDerVenture;
            this.ownloatheb = p.ownloatheb;
            this.enemyloatheb = p.enemyloatheb;

            this.spellpower = p.spellpower;
            this.enemyspellpower = p.enemyspellpower;

            this.needGraveyard = p.needGraveyard;
            if (p.needGraveyard) this.diedMinions = new List<GraveYardItem>(p.diedMinions);

            this.anzEnemyCursed = p.anzEnemyCursed;

            //####buffs#############################

            this.anzOwnRaidleader = p.anzOwnRaidleader;
            this.anzEnemyRaidleader = p.anzEnemyRaidleader;
            this.anzOwnMalGanis = p.anzOwnMalGanis;
            this.anzEnemyMalGanis = p.anzEnemyMalGanis;
            this.anzOwnStormwindChamps = p.anzOwnStormwindChamps;
            this.anzEnemyStormwindChamps = p.anzEnemyStormwindChamps;
            this.anzOwnTundrarhino = p.anzOwnTundrarhino;
            this.anzEnemyTundrarhino = p.anzEnemyTundrarhino;
            this.anzOwnTimberWolfs = p.anzOwnTimberWolfs;
            this.anzEnemyTimberWolfs = p.anzEnemyTimberWolfs;
            this.anzMurlocWarleader = p.anzMurlocWarleader;
            this.anzGrimscaleOracle = p.anzGrimscaleOracle;
            this.anzOwnAuchenaiSoulpriest = p.anzOwnAuchenaiSoulpriest;
            this.anzEnemyAuchenaiSoulpriest = p.anzEnemyAuchenaiSoulpriest;
            this.anzOwnsorcerersapprentice = p.anzOwnsorcerersapprentice;
            this.anzEnemysorcerersapprentice = p.anzEnemysorcerersapprentice;
            this.anzOwnSouthseacaptain = p.anzOwnSouthseacaptain;
            this.anzEnemySouthseacaptain = p.anzEnemySouthseacaptain;
            this.anzOwnMechwarper = p.anzOwnMechwarper;
            this.anzOwnMechwarperStarted = p.anzOwnMechwarperStarted;
            this.anzEnemyMechwarper = p.anzEnemyMechwarper;
            this.anzEnemyMechwarperStarted = p.anzEnemyMechwarperStarted;
            this.anzOwnWarsongCommanders = p.anzOwnWarsongCommanders;
            this.anzEnemyWarsongCommanders = p.anzEnemyWarsongCommanders;

            this.feugenDead = p.feugenDead;
            this.stalaggDead = p.stalaggDead;

            this.weHavePlayedMillhouseManastorm = p.weHavePlayedMillhouseManastorm;
            this.enemyHavePlayedMillhouseManastorm = p.enemyHavePlayedMillhouseManastorm;

            this.doublepriest = p.doublepriest;
            this.enemydoublepriest = p.enemydoublepriest;

            this.ownDragonConsort = p.ownDragonConsort;
            this.enemyDragonConsort = p.enemyDragonConsort;

            this.ownBaronRivendare = p.ownBaronRivendare;
            this.enemyBaronRivendare = p.enemyBaronRivendare;

            this.weHaveSteamwheedleSniper = p.weHaveSteamwheedleSniper;
            this.enemyHaveSteamwheedleSniper = p.enemyHaveSteamwheedleSniper;



            anzOwnGarrisonCommander = p.anzOwnGarrisonCommander;
            anzEnemyGarrisonCommander = p.anzEnemyGarrisonCommander;
            anzOwnFallenHeros = p.anzOwnFallenHeros;
            anzEnemyFallenHeros = p.anzEnemyFallenHeros;

            anzownShadowfiends = p.anzownShadowfiends;
            anzEnemyShadowfiends = p.anzEnemyShadowfiends;

            //tgt new-----
            anzOwnFizzlebang = p.anzOwnFizzlebang;
            anzEnemyFizzlebang = p.anzEnemyFizzlebang;
            anzOwnBuccaneer = p.anzOwnBuccaneer;
            anzEnemyBuccaneer = p.anzEnemyBuccaneer;
            anzOwnAviana = p.anzOwnAviana;
            anzEnemyAviana = p.anzEnemyAviana;
            anzOwnAcidMaw = p.anzOwnAcidMaw;
            anzEnemyAcidMaw = p.anzEnemyAcidMaw;
            anzOwnWarhorseTrainer = p.anzOwnWarhorseTrainer;
            anzEnemyWarhorseTrainer = p.anzEnemyWarhorseTrainer;
            anzOwnMaidenOfTheLake = p.anzOwnMaidenOfTheLake;
            anzEnemyMaidenOfTheLake = p.anzEnemyMaidenOfTheLake;

            //loe new---
            anzOwnBranns = p.anzOwnBranns;
            anzEnemyBranns = p.anzEnemyBranns;

            this.anzownNagaSeaWitch = p.anzownNagaSeaWitch;
            this.anzenemyNagaSeaWitch = p.anzenemyNagaSeaWitch;
            this.anzOwnAnimatedArmor = p.anzOwnAnimatedArmor ;
            this.anzEnemyAnimatedArmor = p.anzEnemyAnimatedArmor;
            //#########################################

            this.selectedChoice = p.selectedChoice;

            this.anzMinionsDiedThisTurn = p.anzMinionsDiedThisTurn;

            this.tempanzOwnCards = this.owncards.Count;
            this.tempanzEnemyCards = this.enemyAnzCards;

        }

        public void swapAll()
        {
            ////copied form dfreelan (thx :D)

            // minion counters----------------------------------------------------------------------

            Swap(ref anzOwnRaidleader, ref anzEnemyRaidleader);
            Swap(ref anzOwnStormwindChamps, ref anzEnemyStormwindChamps);
            Swap(ref anzOwnTundrarhino, ref anzEnemyTundrarhino);
            Swap(ref anzOwnTimberWolfs, ref anzEnemyTimberWolfs);
            //Swap(ref anzMurlocWarleader, ref anzMurlocWarleader);//dont need to swapped, we have one int for both players
            //Swap(ref anzGrimscaleOracle, ref anzGrimscaleOracle);//dont need to swapped, we have one int for both players
            Swap(ref anzOwnAuchenaiSoulpriest, ref anzEnemyAuchenaiSoulpriest);
            Swap(ref anzOwnsorcerersapprentice, ref anzEnemysorcerersapprentice);
            Swap(ref anzOwnSouthseacaptain, ref anzEnemySouthseacaptain);
            Swap(ref anzOwnMalGanis, ref anzEnemyMalGanis);
            Swap(ref anzOwnMechwarper, ref anzEnemyMechwarper);
            Swap(ref anzOwnMechwarperStarted, ref anzEnemyMechwarperStarted);
            Swap(ref weHavePlayedMillhouseManastorm, ref enemyHavePlayedMillhouseManastorm);
            Swap(ref weHaveSteamwheedleSniper, ref enemyHaveSteamwheedleSniper);
            Swap(ref doublepriest, ref enemydoublepriest);
            Swap(ref ownDragonConsort, ref enemyDragonConsort);
            Swap(ref ownBaronRivendare, ref enemyBaronRivendare);

            //tgt new
             Swap(ref anzOwnGarrisonCommander, ref anzEnemyGarrisonCommander);
             Swap(ref anzOwnFallenHeros, ref anzEnemyFallenHeros);
             Swap(ref anzownShadowfiends, ref anzEnemyShadowfiends);
             Swap(ref anzOwnFizzlebang, ref anzEnemyFizzlebang);
             Swap(ref anzOwnBuccaneer, ref anzEnemyBuccaneer);
             Swap(ref anzOwnAviana, ref anzEnemyAviana);
             Swap(ref anzOwnAcidMaw, ref anzEnemyAcidMaw);
             Swap(ref anzOwnWarhorseTrainer, ref anzEnemyWarhorseTrainer);
             Swap(ref anzOwnMaidenOfTheLake, ref anzEnemyMaidenOfTheLake);





            Swap(ref tempanzOwnCards, ref tempanzEnemyCards);// for Goblin Sapper NEEDED?
            Swap(ref this.ownSecretsIDList, ref EnemySecretsIDList);
            enemySecretList.Clear();
            enemySecretCount = this.EnemySecretsIDList.Count;

            

            //TODO: feugenDead = false;
            //TODO: stalaggDead = false;

            //TODO: public bool needGraveyard = false;

            if(ownController == 1) 
            {
                ownController = 2;
            }
            else
            {
                ownController = 1;
            }

            Swap(ref enemyDeck, ref myDeck);
            //swap mana
            
             Swap(ref ownHero, ref enemyHero);
            Swap(ref ownHeroName, ref enemyHeroName);
            swapReferences(ownWeaponName, enemyWeaponName);
            Swap(ref ownWeaponAttack, ref enemyWeaponAttack);
            Swap(ref ownWeaponDurability, ref enemyWeaponDurability);

            // swap minions
            Swap(ref ownMinions, ref enemyMinions);

            if(diedMinions!=null) diedMinions.Clear();
            Swap(ref owncards, ref EnemyCards);

            Swap(ref spellpower, ref enemyspellpower);
            Swap(ref ownloatheb, ref enemyloatheb);

            ownloatheb = 0;
            Swap(ref ownMaxMana, ref enemyMaxMana);

            anzMinionsDiedThisTurn = 0;
            owncarddraw = 0;
            enemycarddraw = 0;
            playactions.Clear();
            enemyAnzCards = owncards.Count;

            playedmagierinderkirintor = false;
            playedPreparation = false;
            pintsizedsummoner = 0;

            //managespenst = 0;
            

        mobsplayedThisTurn = 0;
        optionsPlayedThisTurn = 0;
        cardsPlayedThisTurn = 0;

        /*public int owedRecall = 0; //=recall
        public int currentRecall = 0;
        public int enemyRecall = 0;
        public int enemyCurrentRecall = 0;//only needed for enemys turn sim.
            */

        enemyOptionsDoneThisTurn = 0;
        heroPowerActivationsThisTurn = 0;

        lostDamage = 0;
        lostHeal = 0;
        lostWeaponDamage = 0;
        Swap(ref ownDeckSize, ref enemyDeckSize);
        
            
        Swap(ref ownHeroFatigue, ref enemyHeroFatigue);

        ownAbilityReady = true;
        enemyAbilityReady = true;

        //tgt---
        Swap(ref ownHeroAblility, ref enemyHeroAblility);
        Swap(ref own_TIMES_HERO_POWER_USED_THIS_GAME, ref enemy_TIMES_HERO_POWER_USED_THIS_GAME);
        Swap(ref ownSaboteur, ref enemySaboteur);
        Swap(ref anzOwnFencingCoach, ref anzEnemyFencingCoach);
        //---

        // just for saving which minion to revive with secrets (=the first one that died);
        swapReferences(revivingOwnMinion, revivingEnemyMinion);


            //count...
            soeldnerDerVenture = 0;
            beschwoerungsportal = 0;
            nerubarweblord = 0;


            foreach(Minion m in this.ownMinions)
            {
                m.own = true;
                if (m.silenced) continue;
                if (m.name == CardDB.cardName.nerubarweblord) nerubarweblord++;
                if (m.name == CardDB.cardName.summoningportal) beschwoerungsportal++;
                if (m.name == CardDB.cardName.venturecomercenary) soeldnerDerVenture++;
            }

            foreach (Minion m in this.enemyMinions)
            {
                m.own = false;
            }
        }
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public void swapReferences(Object obj1, Object obj2)
        {
            Object temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
        
        public void setDecksAndHands(List<Handmanager.Handcard> ownDeck, List<Handmanager.Handcard> oppDeck, List<Handmanager.Handcard> oppCards)
        {
            this.myDeck = new List<Handmanager.Handcard>(ownDeck);
            this.enemyDeck = new List<Handmanager.Handcard>(oppDeck);
            this.EnemyCards = new List<Handmanager.Handcard>(oppCards);
            this.EnemySecretsIDList = new List<CardDB.cardIDEnum>();
        }


        public void copyValuesFrom(Playfield p)
        {

        }

        public bool isEqual(Playfield p, bool logg)
        {
            if (logg)
            {
                if (this.value != p.value) return false;
            }
            if (this.enemySecretCount != p.enemySecretCount)
            {

                if (logg) Helpfunctions.Instance.logg("enemy secrets changed ");
                return false;
            }

            if (this.enemySecretCount >= 1)
            {
                for (int i = 0; i < this.enemySecretList.Count; i++)
                {
                    if (!this.enemySecretList[i].isEqual(p.enemySecretList[i]))
                    {
                        if (logg) Helpfunctions.Instance.logg("enemy secrets changed! ");
                        return false;
                    }
                }
            }

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana)
            {
                if (logg) Helpfunctions.Instance.logg("mana changed " + this.mana + " " + p.mana + " " + this.enemyMaxMana + " " + p.enemyMaxMana + " " + this.ownMaxMana + " " + p.ownMaxMana);
                return false;
            }

            if (this.ownDeckSize != p.ownDeckSize || this.enemyDeckSize != p.enemyDeckSize || this.ownHeroFatigue != p.ownHeroFatigue || this.enemyHeroFatigue != p.enemyHeroFatigue)
            {
                if (logg) Helpfunctions.Instance.logg("deck/fatigue changed " + this.ownDeckSize + " " + p.ownDeckSize + " " + this.enemyDeckSize + " " + p.enemyDeckSize + " " + this.ownHeroFatigue + " " + p.ownHeroFatigue + " " + this.enemyHeroFatigue + " " + p.enemyHeroFatigue);
            }

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.owedRecall != p.owedRecall || this.ownAbilityReady != p.ownAbilityReady)
            {
                if (logg) Helpfunctions.Instance.logg("stuff changed " + this.cardsPlayedThisTurn + " " + p.cardsPlayedThisTurn + " " + this.mobsplayedThisTurn + " " + p.mobsplayedThisTurn + " " + this.owedRecall + " " + p.owedRecall + " " + this.ownAbilityReady + " " + p.ownAbilityReady);
                return false;
            }

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName)
            {
                if (logg) Helpfunctions.Instance.logg("hero name changed ");
                return false;
            }

            if (this.ownHero.Hp != p.ownHero.Hp || this.ownHero.Angr != p.ownHero.Angr || this.ownHero.armor != p.ownHero.armor || this.ownHero.frozen != p.ownHero.frozen || this.ownHero.immuneWhileAttacking != p.ownHero.immuneWhileAttacking || this.ownHero.immune != p.ownHero.immune)
            {
                if (logg) Helpfunctions.Instance.logg("ownhero changed " + this.ownHero.Hp + " " + p.ownHero.Hp + " " + this.ownHero.Angr + " " + p.ownHero.Angr + " " + this.ownHero.armor + " " + p.ownHero.armor + " " + this.ownHero.frozen + " " + p.ownHero.frozen + " " + this.ownHero.immuneWhileAttacking + " " + p.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + p.ownHero.immune);
                return false;
            }
            if (this.ownHero.Ready != p.ownHero.Ready || this.ownWeaponAttack != p.ownWeaponAttack || this.ownWeaponDurability != p.ownWeaponDurability || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury)
            {
                if (logg) Helpfunctions.Instance.logg("weapon changed " + this.ownHero.Ready + " " + p.ownHero.Ready + " " + this.ownWeaponAttack + " " + p.ownWeaponAttack + " " + this.ownWeaponDurability + " " + p.ownWeaponDurability + " " + this.ownHero.numAttacksThisTurn + " " + p.ownHero.numAttacksThisTurn + " " + this.ownHero.windfury + " " + p.ownHero.windfury);
                return false;
            }
            if (this.enemyHero.Hp != p.enemyHero.Hp || this.enemyWeaponAttack != p.enemyWeaponAttack || this.enemyHero.armor != p.enemyHero.armor || this.enemyWeaponDurability != p.enemyWeaponDurability || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune)
            {
                if (logg) Helpfunctions.Instance.logg("enemyhero changed " + this.enemyHero.Hp + " " + p.enemyHero.Hp + " " + this.enemyWeaponAttack + " " + p.enemyWeaponAttack + " " + this.enemyHero.armor + " " + p.enemyHero.armor + " " + this.enemyWeaponDurability + " " + p.enemyWeaponDurability + " " + this.enemyHero.frozen + " " + p.enemyHero.frozen + " " + this.enemyHero.immune + " " + p.enemyHero.immune);
                return false;
            }

            /*if (this.auchenaiseelenpriesterin != p.auchenaiseelenpriesterin || this.winzigebeschwoererin != p.winzigebeschwoererin || this.zauberlehrling != p.zauberlehrling || this.managespenst != p.managespenst || this.soeldnerDerVenture != p.soeldnerDerVenture || this.beschwoerungsportal != p.beschwoerungsportal || this.doublepriest != p.doublepriest)
            {
                Helpfunctions.Instance.logg("special minions changed " + this.auchenaiseelenpriesterin + " " + p.auchenaiseelenpriesterin + " " + this.winzigebeschwoererin + " " + p.winzigebeschwoererin + " " + this.zauberlehrling + " " + p.zauberlehrling + " " + this.managespenst + " " + p.managespenst + " " + this.soeldnerDerVenture + " " + p.soeldnerDerVenture + " " + this.beschwoerungsportal + " " + p.beschwoerungsportal + " " + this.doublepriest + " " + p.doublepriest);
                return false;
            }*/

            if (this.ownHeroAblility.card.name != p.ownHeroAblility.card.name)
            {
                if (logg) Helpfunctions.Instance.logg("hero ability changed ");
                return false;
            }

            if (this.spellpower != p.spellpower)
            {
                if (logg) Helpfunctions.Instance.logg("spellpower changed");
                return false;
            }

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count)
            {
                if (logg) Helpfunctions.Instance.logg("minions count or hand changed");
                return false;
            }

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;

            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("ownminions changed");
                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("enemyminions changed");
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.getManaCost(this) != pishc.getManaCost(p))
                {
                    if (logg) Helpfunctions.Instance.logg("handcard changed: " + dishc.card.name);
                    return false;
                }
            }

            // now we're sure the boards are equal, we are just updating entitys (for spawned stuff etc)

            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                if (dis.entitiyID != pis.entitiyID) Ai.Instance.updateEntitiy(pis.entitiyID, dis.entitiyID);

            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                if (dis.entitiyID != pis.entitiyID) Ai.Instance.updateEntitiy(pis.entitiyID, dis.entitiyID);

            }
            if (this.ownSecretsIDList.Count != p.ownSecretsIDList.Count)
            {
                if (logg) Helpfunctions.Instance.logg("secretsCount changed");
                return false;
            }
            for (int i = 0; i < this.ownSecretsIDList.Count; i++)
            {
                if (this.ownSecretsIDList[i] != p.ownSecretsIDList[i])
                {
                    if (logg) Helpfunctions.Instance.logg("secrets changed");
                    return false;
                }
            }
            return true;
        }

        public bool isEqualf(Playfield p)
        {
            if (this.value != p.value) return false;

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count) return false;

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.owedRecall != p.owedRecall || this.ownAbilityReady != p.ownAbilityReady) return false;

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana) return false;

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName || this.enemySecretCount != p.enemySecretCount) return false;

            if (this.ownHero.Hp != p.ownHero.Hp || this.ownHero.Angr != p.ownHero.Angr || this.ownHero.armor != p.ownHero.armor || this.ownHero.frozen != p.ownHero.frozen || this.ownHero.immuneWhileAttacking != p.ownHero.immuneWhileAttacking || this.ownHero.immune != p.ownHero.immune) return false;

            if (this.ownHero.Ready != p.ownHero.Ready || this.ownWeaponAttack != p.ownWeaponAttack || this.ownWeaponDurability != p.ownWeaponDurability || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury) return false;

            if (this.enemyHero.Hp != p.enemyHero.Hp || this.enemyWeaponAttack != p.enemyWeaponAttack || this.enemyHero.armor != p.enemyHero.armor || this.enemyWeaponDurability != p.enemyWeaponDurability || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune) return false;

            if (this.ownHeroAblility.card.name != p.ownHeroAblility.card.name || this.spellpower != p.spellpower) return false;

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {

                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.manacost != pishc.manacost)
                {
                    return false;
                }
            }

            if (this.enemySecretCount >= 1)
            {
                for (int i = 0; i < this.enemySecretList.Count; i++)
                {
                    if (!this.enemySecretList[i].isEqual(p.enemySecretList[i]))
                    {
                        return false;
                    }
                }
            }

            if (this.ownSecretsIDList.Count != p.ownSecretsIDList.Count)
            {
                return false;
            }
            for (int i = 0; i < this.ownSecretsIDList.Count; i++)
            {
                if (this.ownSecretsIDList[i] != p.ownSecretsIDList[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int retval = 0;
            retval += 10000 * this.ownMinions.Count + 100 * this.enemyMinions.Count + 1000 * this.mana + 100000 * (this.ownHero.Hp + this.enemyHero.Hp) + this.owncards.Count + this.enemycarddraw + this.cardsPlayedThisTurn + this.mobsplayedThisTurn + this.ownHero.Angr + this.ownHero.armor + this.ownWeaponAttack + this.enemyWeaponDurability;
            return retval;
        }


        //stuff for playing around enemy aoes
        public void enemyPlaysAoe(int pprob, int pprob2)
        {
            if (this.enemyloatheb == 0)
            {
                Playfield p = new Playfield(this);
                float oldval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                p.EnemyCardPlaying(p.enemyHeroName, p.mana, p.enemyAnzCards, pprob, pprob2);
                float newval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                if (oldval > newval) // new board is better for enemy (value is smaller)
                {
                    this.copyValuesFrom(p);
                }
            }
        }

        public int EnemyCardPlaying(HeroEnum enemyHeroNamee, int currmana, int cardcount, int playAroundProb, int pap2)
        {
            int mana = currmana;
            if (cardcount == 0) return currmana;

            bool useAOE = false;
            int mobscount = 0;
            foreach (Minion min in this.ownMinions)
            {
                if (min.maxHp >= 2 && min.Angr >= 2) mobscount++;
            }

            if (mobscount >= 3) useAOE = true;

            if (enemyHeroNamee == HeroEnum.warrior)
            {
                bool usewhirlwind = true;
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.Hp == 1) usewhirlwind = false;
                }
                if (this.ownMinions.Count <= 3) usewhirlwind = false;

                if (usewhirlwind)
                {
                    mana = EnemyPlaysACard(CardDB.cardName.whirlwind, mana, playAroundProb, pap2);
                }
            }

            if (!useAOE) return mana;

            if (enemyHeroNamee == HeroEnum.mage)
            {
                mana = EnemyPlaysACard(CardDB.cardName.flamestrike, mana, playAroundProb, pap2);
                mana = EnemyPlaysACard(CardDB.cardName.blizzard, mana, playAroundProb, pap2);
            }

            if (enemyHeroNamee == HeroEnum.hunter)
            {
                mana = EnemyPlaysACard(CardDB.cardName.unleashthehounds, mana, playAroundProb, pap2);
            }

            if (enemyHeroNamee == HeroEnum.priest)
            {
                mana = EnemyPlaysACard(CardDB.cardName.holynova, mana, playAroundProb, pap2);
            }

            if (enemyHeroNamee == HeroEnum.shaman)
            {
                mana = EnemyPlaysACard(CardDB.cardName.lightningstorm, mana, playAroundProb, pap2);
            }

            if (enemyHeroNamee == HeroEnum.pala)
            {
                mana = EnemyPlaysACard(CardDB.cardName.consecration, mana, playAroundProb, pap2);
            }

            if (enemyHeroNamee == HeroEnum.druid)
            {
                mana = EnemyPlaysACard(CardDB.cardName.swipe, mana, playAroundProb, pap2);
            }



            return mana;
        }

        public int EnemyPlaysACard(CardDB.cardName cardname, int currmana, int playAroundProb, int pap2)
        {

            //todo manacosts
            if (cardname == CardDB.cardName.flamestrike && currmana >= 7)
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_032, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                List<Minion> temp = this.ownMinions;
                int damage = getEnemySpellDamageDamage(4);
                foreach (Minion enemy in temp)
                {
                    enemy.cantLowerHPbelowONE = dontkill;
                    this.minionGetDamageOrHeal(enemy, damage);
                    enemy.cantLowerHPbelowONE = false;
                }

                currmana -= 7;
                return currmana;
            }

            if (cardname == CardDB.cardName.blizzard && currmana >= 6)
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_028, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                List<Minion> temp = this.ownMinions;
                int damage = getEnemySpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                    enemy.cantLowerHPbelowONE = dontkill;
                    this.minionGetDamageOrHeal(enemy, damage);
                    enemy.cantLowerHPbelowONE = false;
                }

                currmana -= 6;
                return currmana;
            }


            if (cardname == CardDB.cardName.unleashthehounds && currmana >= 5)
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_538, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                int anz = this.ownMinions.Count;
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t);//hound
                for (int i = 0; i < anz; i++)
                {
                    callKid(kid, posi, false);
                }
                currmana -= 5;
                return currmana;
            }





            if (cardname == CardDB.cardName.holynova && currmana >= 5)
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS1_112, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                List<Minion> temp = this.enemyMinions;
                int heal = getEnemySpellHeal(2);
                int damage = getEnemySpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    this.minionGetDamageOrHeal(enemy, -heal);
                }
                this.minionGetDamageOrHeal(this.enemyHero, -heal);
                temp = this.ownMinions;
                foreach (Minion enemy in temp)
                {
                    enemy.cantLowerHPbelowONE = dontkill;
                    this.minionGetDamageOrHeal(enemy, damage);
                    enemy.cantLowerHPbelowONE = false;
                }
                this.minionGetDamageOrHeal(this.ownHero, damage);
                currmana -= 5;
                return currmana;
            }




            if (cardname == CardDB.cardName.lightningstorm && currmana >= 4)//3
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_259, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                List<Minion> temp = this.ownMinions;
                int damage = getEnemySpellDamageDamage(3);
                foreach (Minion enemy in temp)
                {
                    enemy.cantLowerHPbelowONE = dontkill;
                    this.minionGetDamageOrHeal(enemy, damage);
                    enemy.cantLowerHPbelowONE = false;
                }
                currmana -= 3;
                return currmana;
            }



            if (cardname == CardDB.cardName.whirlwind && currmana >= 3)//1
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_400, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                List<Minion> temp = this.enemyMinions;
                int damage = getEnemySpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    this.minionGetDamageOrHeal(enemy, damage);
                }
                temp = this.ownMinions;
                foreach (Minion enemy in temp)
                {
                    enemy.cantLowerHPbelowONE = dontkill;
                    this.minionGetDamageOrHeal(enemy, damage);
                    enemy.cantLowerHPbelowONE = false;
                }
                currmana -= 1;
                return currmana;
            }



            if (cardname == CardDB.cardName.consecration && currmana >= 4)
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_093, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                List<Minion> temp = this.ownMinions;
                int damage = getEnemySpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    enemy.cantLowerHPbelowONE = dontkill;
                    this.minionGetDamageOrHeal(enemy, damage);
                    enemy.cantLowerHPbelowONE = false;
                }

                this.minionGetDamageOrHeal(this.ownHero, damage);
                currmana -= 4;
                return currmana;
            }



            if (cardname == CardDB.cardName.swipe && currmana >= 4)
            {
                bool dontkill = false;
                int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_012, this.enemyAnzCards, this.enemyDeckSize);
                if (playAroundProb > prob) return currmana;
                if (pap2 > prob) dontkill = true;

                int damage = getEnemySpellDamageDamage(4);
                // all others get 1 spelldamage
                int damage1 = getEnemySpellDamageDamage(1);

                List<Minion> temp = this.ownMinions;
                Minion target = null;
                foreach (Minion mnn in temp)
                {
                    if (mnn.Hp <= damage || mnn.handcard.card.isSpecialMinion || target == null)
                    {
                        target = mnn;
                    }
                }
                foreach (Minion mnn in temp.ToArray())
                {
                    if (mnn.entitiyID == target.entitiyID)
                    {
                        mnn.cantLowerHPbelowONE = dontkill;
                        this.minionGetDamageOrHeal(mnn, damage1);
                        mnn.cantLowerHPbelowONE = false;
                    }
                    else
                    {
                        mnn.cantLowerHPbelowONE = dontkill;
                        this.minionGetDamageOrHeal(mnn, damage);
                        mnn.cantLowerHPbelowONE = false;
                    }
                }
                currmana -= 4;
                return currmana;
            }





            return currmana;
        }

        public int getNextEntity()
        {
            //i dont trust return this.nextEntity++; !!!
            int retval = this.nextEntity;
            this.nextEntity++;
            return retval;
        }


        // get all minions which are attackable
        public List<Minion> getAttackTargets(bool own)
        {
            List<Minion> trgts = new List<Minion>();
            List<Minion> trgts2 = new List<Minion>();
            bool hasTaunts = false;
            if (own)
            {
                if (!this.enemyHero.immune) trgts2.Add(this.enemyHero);
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.stealth) continue; // cant target stealth

                    if (m.taunt)
                    {
                        hasTaunts = true;
                        trgts.Add(m);
                    }
                    else
                    {
                        trgts2.Add(m);
                    }
                }
            }
            else
            {

                foreach (Minion m in this.ownMinions)
                {
                    if (m.stealth) continue; // cant target stealth

                    if (m.taunt)
                    {
                        hasTaunts = true;
                        trgts.Add(m);
                    }
                    else
                    {
                        trgts2.Add(m);
                    }
                }

                if (!this.ownHero.immune) trgts2.Add(this.ownHero);
                //if (trgts2.Count == 0 && !this.ownHero.immune) trgts2.Add(this.ownHero);
            }

            if (hasTaunts) return trgts;

            return trgts2;


        }

        public int getBestPlace(CardDB.Card card, bool lethal)
        {
            //we return the zonepos!
            if (card.type != CardDB.cardtype.MOB) return 1;
            if (this.ownMinions.Count == 0) return 1;
            if (this.ownMinions.Count == 1) return 2;

            int[] places = new int[this.ownMinions.Count];
            int i = 0;
            int tempval = 0;
            if (lethal && card.name == CardDB.cardName.defenderofargus)
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (m.Ready)
                    {
                        tempval -= m.Angr - 1;
                        if (m.windfury) tempval -= m.Angr - 1;
                    }
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
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl + 1;
            }
            if (card.name == CardDB.cardName.sunfuryprotector || card.name == CardDB.cardName.defenderofargus) // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
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
                        tempval -= m.Hp + 2;
                    }

                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem) tempval += 50;
                    if (m.handcard.card.name == CardDB.cardName.raidleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.grimscaleoracle) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha) tempval += 50;
                    if (m.handcard.card.name == CardDB.cardName.murlocwarleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.southseacaptain) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.stormwindchampion) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.timberwolf) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.leokk) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.northshirecleric) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.sorcerersapprentice) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.pintsizedsummoner) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.summoningportal) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.scavenginghyena) tempval += 10;

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
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl + 1;
            }

            int cardIsBuffer = 0;
            bool placebuff = false;
            if (card.name == CardDB.cardName.flametonguetotem || card.name == CardDB.cardName.direwolfalpha)
            {
                placebuff = true;
                if (card.name == CardDB.cardName.flametonguetotem) cardIsBuffer = 2;
                if (card.name == CardDB.cardName.direwolfalpha) cardIsBuffer = 1;
            }
            bool commander = false;
            foreach (Minion m in this.ownMinions)
            {
                if (m.handcard.card.name == CardDB.cardName.warsongcommander) commander = true;
                if (m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.direwolfalpha) placebuff = true;
            }
            //attackmaxing :D
            if (placebuff)
            {


                int cval = 0;
                if (card.Charge) // ... || (card.Attack <= 3 && commander) //warsong commander fix
                {
                    cval = card.Attack;
                    if (card.windfury) cval += card.Attack;

                    if (commander)//warsong commander fix
                    {
                        cval +=1;
                        if (card.windfury) cval += 1;
                    }
                }
                if (card.name == CardDB.cardName.nerubianegg)
                {
                    cval += 1;
                }
                cval++;
                i = 0;
                int[] buffplaces = new int[this.ownMinions.Count];
                int[] whirlwindplaces = new int[this.ownMinions.Count];
                int gesval = 0;
                foreach (Minion m in this.ownMinions)
                {
                    buffplaces[i] = 0;
                    whirlwindplaces[i] = 1;
                    places[i] = 0;
                    tempval = -1;
                    if (!m.Ready && m.Angr == 0 && !m.playedThisTurn) tempval = 0;
                    if (m.Ready)
                    {
                        tempval = m.Angr;
                        if (m.windfury && m.numAttacksThisTurn == 0)
                        {
                            tempval += m.Angr;
                            whirlwindplaces[i] = 2;
                        }


                    }
                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem)
                    {
                        buffplaces[i] = 2;
                    }
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha)
                    {
                        buffplaces[i] = 1;
                    }
                    tempval++;
                    places[i] = tempval;
                    gesval += tempval;
                    i++;
                }
                //gesval = whole possible damage
                int bplace = 0;
                int bvale = 0;
                tempval = 0;
                i = 0;
                for (int j = 0; j <= this.ownMinions.Count; j++)
                {
                    tempval = gesval;
                    int current = cval;
                    int prev = 0;
                    int next = 0;
                    if (i >= 1)
                    {
                        tempval -= places[i - 1];
                        prev = places[i - 1];
                        if (prev >= 0) prev += whirlwindplaces[i - 1] * cardIsBuffer;
                        if (current > 0) current += buffplaces[i - 1];

                        if (i < this.ownMinions.Count)
                        {
                            prev -= whirlwindplaces[i - 1] * buffplaces[i];
                        }
                    }
                    if (i < this.ownMinions.Count)
                    {
                        tempval -= places[i];
                        next = places[i];
                        if (next >= 0) next += whirlwindplaces[i] * cardIsBuffer;
                        if (current > 0) current += buffplaces[i];
                        if (i >= 1)
                        {
                            next -= whirlwindplaces[i] * buffplaces[i - 1];
                        }
                    }
                    tempval += current + prev + next;
                    if (tempval > bvale)
                    {
                        bplace = i;
                        bvale = tempval;
                    }
                    i++;
                }
                return bplace + 1;

            }

            // normal placement
            int cardvalue = card.Attack * 2 + card.Health;
            if (card.tank)
            {
                cardvalue += 5;
                cardvalue += card.Health;
            }

            if (card.name == CardDB.cardName.flametonguetotem) cardvalue += 90;
            if (card.name == CardDB.cardName.raidleader) cardvalue += 10;
            if (card.name == CardDB.cardName.grimscaleoracle) cardvalue += 10;
            if (card.name == CardDB.cardName.direwolfalpha) cardvalue += 90;
            if (card.name == CardDB.cardName.murlocwarleader) cardvalue += 10;
            if (card.name == CardDB.cardName.southseacaptain) cardvalue += 10;
            if (card.name == CardDB.cardName.stormwindchampion) cardvalue += 10;
            if (card.name == CardDB.cardName.timberwolf) cardvalue += 10;
            if (card.name == CardDB.cardName.leokk) cardvalue += 10;
            if (card.name == CardDB.cardName.northshirecleric) cardvalue += 10;
            if (card.name == CardDB.cardName.sorcerersapprentice) cardvalue += 10;
            if (card.name == CardDB.cardName.pintsizedsummoner) cardvalue += 10;
            if (card.name == CardDB.cardName.summoningportal) cardvalue += 10;
            if (card.name == CardDB.cardName.scavenginghyena) cardvalue += 10;
            if (card.name == CardDB.cardName.faeriedragon) cardvalue += 40;
            cardvalue += 1;

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
                if (!m.silenced)
                {
                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem) tempval += 90;
                    if (m.handcard.card.name == CardDB.cardName.raidleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.grimscaleoracle) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha) tempval += 90;
                    if (m.handcard.card.name == CardDB.cardName.murlocwarleader) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.southseacaptain) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.stormwindchampion) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.timberwolf) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.leokk) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.northshirecleric) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.sorcerersapprentice) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.pintsizedsummoner) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.summoningportal) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.scavenginghyena) tempval += 10;
                    if (m.handcard.card.name == CardDB.cardName.faeriedragon) tempval += 40;
                    if (m.stealth) tempval += 40;
                }
                places[i] = tempval;

                i++;
            }

            //bigminion if >=10
            int bestplace = 0;
            int bestvale = 0;
            tempval = 0;
            i = 0;
            for (int j = 0; j <= this.ownMinions.Count; j++)
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
                        bestplace = i;
                        bestvale = tempval;
                    }
                }

                i++;
            }

            return bestplace + 1;
        }

        public int guessHeroDamage(bool own = false)
        {
            List<Minion> attackingMinions = (own ? this.ownMinions : this.enemyMinions);
            Minion attackingHero = (own ? this.ownHero : this.enemyHero);
            HeroEnum attackingHeroName = (own ? this.ownHeroName : this.enemyHeroName);
            int weaponAttack = (own ? this.ownWeaponAttack : this.enemyWeaponAttack);
            CardDB.cardName weaponName = (own ? this.ownWeaponName : this.enemyWeaponName);
            List<Minion> targetMinions = (own ? this.enemyMinions : this.ownMinions);
            Minion targetHero = (own ? this.enemyHero : this.ownHero);

            int ghd = 0;
            foreach (Minion m in attackingMinions)
            {
                if (m.frozen) continue;
                if (m.name == CardDB.cardName.ancientwatcher && !m.silenced)
                {
                    continue;
                }
                ghd += m.Angr;
                if (m.windfury) ghd += m.Angr;
            }

            if (!attackingHero.frozen)
            {
                if (weaponAttack >= 1)
                {
                    ghd += weaponAttack;
                    if (attackingHero.windfury || weaponName == CardDB.cardName.doomhammer) ghd += weaponAttack;
                }
                else
                {
                    if (attackingHeroName == HeroEnum.thief) ghd++;
                }

                if (attackingHeroName == HeroEnum.druid) ghd++;
            }

            if (attackingHeroName == HeroEnum.mage) ghd++;
            if (attackingHeroName == HeroEnum.hunter) ghd += 2;


            foreach (Minion m in targetMinions)
            {
                if (m.taunt) ghd -= m.Hp;
                if (m.taunt && m.divineshild) ghd -= 1;
            }

            int guessingHeroDamage = Math.Max(0, ghd);
            if (targetHero.immune) guessingHeroDamage = 0;
            //this.guessingHeroHP = this.ownHero.Hp + this.ownHero.armor - guessingHeroDamage;

            return guessingHeroDamage;
        }

        public void simulateTraps()
        {
            //todo rework this
            // DONT KILL ENEMY HERO (cause its only guessing)
            foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
            {
                //hunter secrets############

                if (secretID == CardDB.cardIDEnum.AT_060) //beartrap
                {

                    //call 3 snakes (if possible)
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_125);//bear
                    callKid(kid, posi, true);
                }

                if (secretID == CardDB.cardIDEnum.EX1_554) //snaketrap
                {

                    //call 3 snakes (if possible)
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t);//snake
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                }
                if (secretID == CardDB.cardIDEnum.EX1_609) //snipe
                {
                    //kill weakest minion of enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDamageOrHeal(m, 4);
                }
                if (secretID == CardDB.cardIDEnum.EX1_610) //explosive trap
                {
                    //take 2 damage to each enemy
                    List<Minion> temp = this.enemyMinions;
                    foreach (Minion m in temp)
                    {
                        minionGetDamageOrHeal(m, 2);
                    }
                    attackEnemyHeroWithoutKill(2);
                }
                if (secretID == CardDB.cardIDEnum.EX1_611) //freezing trap
                {
                    //return weakest enemy minion to hand
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionReturnToHand(m, false, 0);
                }
                if (secretID == CardDB.cardIDEnum.EX1_533) // missdirection
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Angr = 0;
                    this.evaluatePenality -= this.enemyMinions.Count;// the more the enemy minions has on board, the more the posibility to destroy something other :D
                }

                //mage secrets############
                if (secretID == CardDB.cardIDEnum.EX1_287) //counterspell
                {
                    // what should we do?
                    this.evaluatePenality -= 8;
                }

                if (secretID == CardDB.cardIDEnum.EX1_289) //ice barrier
                {
                    this.ownHero.armor += 8;
                }

                if (secretID == CardDB.cardIDEnum.EX1_295) //ice block
                {
                    //set the guessed Damage to zero
                    this.ownHero.immune = true;
                }

                if (secretID == CardDB.cardIDEnum.EX1_294) //mirror entity
                {
                    // summon a weak minion (thx to xytrix)
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid;
                    switch ((this.ownMaxMana + 2) / 3)  // conservative, but scales a little as the game progresses
                    {
                        case 1:
                        default: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t); break;  // 1/1 snake turns 1-3
                        case 2: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t); break; // 2/2 treant turns 4-6
                        case 3: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_172); break; // 3/2 bloodfen raptor turns 7-9
                        case 4: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_036t); break; // 4/4 nerubian turn 10
                    }
                    callKid(kid, posi, true);
                }
                if (secretID == CardDB.cardIDEnum.tt_010) //spellbender
                {
                    //whut???
                    // add 2 to your defence (most attack-buffs give +2, lots of damage spells too)
                    this.evaluatePenality -= 4;
                }
                if (secretID == CardDB.cardIDEnum.EX1_594) // vaporize
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDestroyed(m);
                }
                if (secretID == CardDB.cardIDEnum.FP1_018) // duplicate
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    drawACard(m.handcard.card.cardIDenum, true);
                    drawACard(m.handcard.card.cardIDenum, true);
                }
                if (secretID == CardDB.cardIDEnum.AT_002) // effigy
                {
                    if (this.ownMinions.Count == 0) continue;

                    // assume enemy kills our lowest mana cost minion, and we get a vanilla drop of manacost-1
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.handcard.card.cost.CompareTo(b.handcard.card.cost));

                    int cardCost = Math.Min(8, Math.Max(temp[0].handcard.card.cost - 1, 0));  // min cost 0 (wisp), max cost 8 (giants, etc)
                    this.evaluatePenality -= cardCost * 3;  // value as if we played a vanilla minion of the same cost (i.e. 2*atk + hp, but atk==hp)
                }

                //pala secrets############
                if (secretID == CardDB.cardIDEnum.EX1_132) // eye for an eye
                {
                    // enemy takes one damage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    attackEnemyHeroWithoutKill(m.Angr);
                }
                if (secretID == CardDB.cardIDEnum.EX1_130) // noble sacrifice
                {
                    //spawn a 2/1 taunt!
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_130a);
                    callKid(kid, posi, true);

                }

                if (secretID == CardDB.cardIDEnum.EX1_136) // redemption
                {
                    // we give our weakest minion a divine shield :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;

                    bool buffed = false;
                    foreach (Minion m in temp)
                    {
                        if (m.divineshild) continue;
                        m.divineshild = true;
                        buffed = true;
                        break;
                    }

                    // all our minions have divine shield? redemption really shines here, so give weakest minion more hp.
                    if (!buffed) temp[0].Hp += temp[0].handcard.card.Health;  // don't count already buffed hp
                }

                if (secretID == CardDB.cardIDEnum.EX1_379) // repentance
                {
                    // set his current lowest hp minion to x/1
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Hp = 1;
                    m.maxHp = 1;
                }

                if (secretID == CardDB.cardIDEnum.FP1_020) // avenge
                {
                    if (this.numPlayerMinionsAtTurnStart < 2) continue;

                    // we give our weakest minion +3/+2 :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0)
                    {
                        // even though there's no minions to buff because the board was cleared, we still got value for the secret
                        this.evaluatePenality -= 8;
                        continue;
                    }
                    foreach (Minion m in temp)
                    {
                        minionGetBuffed(m, 3, 2);
                        break;
                    }
                }
            }

            this.doDmgTriggers();
        }



        //old one, will be replaced soon
        public void endTurn(bool simulateTwoTurns, bool playaround, bool print = false, int pprob = 0, int pprob2 = 0)
        {
            bool doServerstuff = this.isServer;

            if (!doServerstuff)
            {
                this.value = int.MinValue;
                if (!this.enemyHero.immune && this.turnCounter == 0)
                {
                    this.manaTurnEnd = this.mana;
                    this.numEnemySecretsTurnEnd = this.enemySecretCount;
                    bool eHasTaunt = false;
                    
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.taunt) eHasTaunt = true;
                    }

                    eHasTaunt = true;

                    int hasReady = 0;
                    foreach (Minion m in this.ownMinions)
                    {
                        if (!m.stealth && m.Ready && m.Angr>=1) hasReady++;
                    }

                    if (!eHasTaunt && !this.enemyHero.immune)
                    {


                        this.evaluatePenality += 100 * hasReady;
                    }
                    else
                    {
                        if (!simulateTwoTurns)
                        {
                            if (this.enemySecretCount >= 1)
                            {
                                this.evaluatePenality += 2 * hasReady;
                            }

                            this.evaluatePenality += 40 * hasReady;
                        }
                    }

                }

                if (!this.enemyHero.immune && this.turnCounter == 2)//own next turn
                {
                    bool eHasTaunt = false;
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.taunt) eHasTaunt = true;
                    }
                    if (!eHasTaunt && this.enemySecretCount == 0)
                    {
                        int attack = 0;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Ready) attack += m.Angr;
                            if (m.Ready && m.windfury && m.numAttacksThisTurn == 0) attack += m.Angr;
                        }
                        if (this.enemyHero.armor == 0)
                        {
                            this.enemyHero.Hp -= attack;
                        }
                        else
                        {
                            if (this.enemyHero.armor >= attack)
                            {
                                this.enemyHero.armor -= attack;
                            }
                            else 
                            {
                                this.enemyHero.Hp += this.enemyHero.armor - attack;
                                this.enemyHero.armor = 0;
                            }
                        }
                    }

                }


            }
            //this.turnCounter++;
            //penalty for destroying combo

            if (!doServerstuff)
            {
                this.evaluatePenality += ComboBreaker.Instance.checkIfComboWasPlayed(this.playactions, this.ownWeaponName, this.ownHeroName);
                if (this.complete) return;
            }



            this.triggerEndTurn(this.isOwnTurn);
            this.isOwnTurn = !this.isOwnTurn;
            this.triggerStartTurn(this.isOwnTurn);
            this.optionsPlayedThisTurn = 0;
            if (doServerstuff)
            {
                this.isOwnTurn = !this.isOwnTurn;
            }
            if (!doServerstuff)
            {
                if (!this.isOwnTurn) simulateTraps();

                if (!sEnemTurn && !this.isOwnTurn) // it was at the biginning our turn -> now its enems
                {
                    //guessHeroDamage();
                    this.triggerEndTurn(false);
                    this.triggerStartTurn(true);
                    this.complete = true;
                }
                else
                {
                    //guessHeroDamage();
                    /*
                    if (this.guessingHeroHP >= 1)
                    {
                        //simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                        this.prepareNextTurn(this.isOwnTurn);

                        if (this.turnCounter >= 2)
                            Ai.Instance.enemySecondTurnSim.simulateEnemysTurn(this, simulateTwoTurns, playaround, print, pprob, pprob2);
                        else
                            Ai.Instance.enemyTurnSim.simulateEnemysTurn(this, simulateTwoTurns, playaround, print, pprob, pprob2);
                    }
                    this.complete = true;*/
                }
            }

        }

        //prepares the turn for the next player
        public void prepareNextTurn(bool own)
        {
            //call this after start turn trigger!

            if (own)
            {
                this.ownMaxMana = Math.Min(10, this.ownMaxMana + 1);
                this.mana = this.ownMaxMana - this.owedRecall;
                this.currentRecall = this.owedRecall;
                this.owedRecall = 0;
                foreach (Minion m in ownMinions)
                {
                    m.numAttacksThisTurn = 0;
                    m.playedThisTurn = false;
                    m.updateReadyness(this);
                    m.canAttackNormal = false;
                    if (m.concedal)
                    {
                        m.concedal = false;
                        m.stealth = false;
                    }

                }
                //unfreeze the enemy minions
                foreach (Minion m in enemyMinions)
                {
                    m.frozen = false;
                    m.canAttackNormal = false;
                    //m.immune = false;
                }
                this.enemyHero.frozen = false;


                this.ownHero.Angr = this.ownWeaponAttack;
                this.ownHero.numAttacksThisTurn = 0;
                this.ownAbilityReady = true;
                this.ownHero.updateReadyness();
                this.playedPreparation = false;
                this.playedmagierinderkirintor = false;

                this.weHavePlayedMillhouseManastorm = false;
                loathebLastTurn = this.ownloatheb;
                this.ownloatheb = 0;
                this.ownSaboteur = 0;
                
                this.owncarddraw = 0;//todo: realy?
                this.sEnemTurn = false;

            }
            else
            {

                this.enemyMaxMana = Math.Min(10, this.enemyMaxMana + 1);
                this.mana = this.enemyMaxMana - this.enemyRecall ;
                this.enemyCurrentRecall = this.enemyRecall;
                this.enemyRecall = 0;
                foreach (Minion m in enemyMinions)
                {
                    //m.immune = true;
                    m.numAttacksThisTurn = 0;
                    m.playedThisTurn = false;
                    m.updateReadyness(this);
                    m.canAttackNormal = false;
                    if (m.concedal)
                    {
                        m.concedal = false;
                        m.stealth = false;
                    }
                }
                //unfreeze the own minions
                foreach (Minion m in ownMinions)
                {
                    m.frozen = false;
                }
                this.ownHero.frozen = false;

                this.enemyHero.Angr = this.enemyWeaponAttack;
                this.enemyHero.numAttacksThisTurn = 0;
                this.enemyAbilityReady = true;
                this.enemyHero.updateReadyness();
                this.enemyOptionsDoneThisTurn = 0;
                this.heroPowerActivationsThisTurn = 0;

                this.enemyHavePlayedMillhouseManastorm = false;
                this.enemyloatheb = 0;
                this.enemySaboteur = 0;
                
                this.playedPreparation = false;
                this.playedmagierinderkirintor = false;

                this.sEnemTurn = false;
                
            }
            this.turnCounter++;
            this.attacked = false;
            this.optionsPlayedThisTurn = 0;
            this.cardsPlayedThisTurn = 0;
            this.mobsplayedThisTurn = 0;

            this.heroPowerActivationsThisTurn = 0;
            this.lockAndLoads = 0;

            this.anzMinionsDiedThisTurn = 0;

            this.complete = false;

            this.value = int.MinValue;
            if (this.diedMinions != null) this.diedMinions.Clear();//contains only the minions that died in this turn!
        }

        public void endEnemyTurn() //
        {

            //do face-attack:

            if (!this.ownHero.immune && (this.turnCounter == 1 || this.turnCounter == 3))// enemys turn ends -> attack with all minions face (if there is no taunt)
            {
                //Helpfunctions.Instance.ErrorLog(turnCounter + " bef " + this.ownHero.Hp + " " + this.ownHero.armor);
                bool oHasTaunt = false;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.taunt) oHasTaunt = true;
                }
                if (!oHasTaunt && this.ownSecretsIDList.Count == 0)
                {
                    int attack = 0;
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.Ready) attack += m.Angr;
                        if (m.Ready && m.windfury && m.numAttacksThisTurn == 0) attack += m.Angr;
                        m.Ready = false;
                    }

                    if (this.ownHero.armor == 0)
                    {
                        this.ownHero.Hp -= attack;
                    }
                    else
                    {
                        if (this.ownHero.armor >= attack)
                        {
                            this.ownHero.armor -= attack;
                        }
                        else
                        {
                            this.ownHero.Hp += this.ownHero.armor - attack;
                            this.ownHero.armor = 0;
                        }
                    }
                }

                if (this.turnCounter == 3)// enemys turn ends -> attack with all minions face (if there is no taunt)
                {
                    if (this.ownHero.Hp <= 0) this.ownHero.Hp = 0;
                }
                //Helpfunctions.Instance.ErrorLog("aft " + this.ownHero.Hp + " " + this.ownHero.armor);

            }

            this.triggerEndTurn(false);
            //this.turnCounter++;
            this.isOwnTurn = true;
            this.triggerStartTurn(true);
            this.complete = true;
            //Ai.Instance.botBase.getPlayfieldValue(this);

        }


        //spelldamage calculation---------------------------------------------------
        public int getSpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.spellpower;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getSpellHeal(int heal)
        {
            int retval = heal;
            if (this.anzOwnAuchenaiSoulpriest >= 1)
            {
                retval *= -1;
                retval -= this.spellpower;
            }
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getMinionHeal(int heal)
        {
            return (this.anzOwnAuchenaiSoulpriest >= 1) ? -heal : heal;
        }

        public int getEnemySpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.enemyspellpower;
            if (this.enemydoublepriest >= 1) retval *= (2 * this.enemydoublepriest);
            return retval;
        }

        public int getEnemySpellHeal(int heal)
        {
            int retval = heal;
            if (this.anzOwnAuchenaiSoulpriest >= 1)
            {
                retval *= -1;
                retval -= this.enemyspellpower;
            }
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getEnemyMinionHeal(int heal)
        {
            return (this.anzEnemyAuchenaiSoulpriest >= 1) ? -heal : heal;
        }


        // do the action--------------------------------------------------------------

        public void doAction(Action aa)
        {
            //CREATE NEW MINIONS (cant use a.target or a.own) (dont belong to this board)
            Minion trgt = null;
            Minion o = null;
            Handmanager.Handcard ha = null;
            if (aa.target != null)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (aa.target.entitiyID == m.entitiyID)
                    {
                        trgt = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (aa.target.entitiyID == m.entitiyID)
                    {
                        trgt = m;
                        break;
                    }
                }
                if (aa.target.entitiyID == this.ownHero.entitiyID) trgt = this.ownHero;
                if (aa.target.entitiyID == this.enemyHero.entitiyID) trgt = this.enemyHero;
            }
            if (aa.own != null)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (aa.own.entitiyID == m.entitiyID)
                    {
                        o = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (aa.own.entitiyID == m.entitiyID)
                    {
                        o = m;
                        break;
                    }
                }
                if (aa.own.entitiyID == this.ownHero.entitiyID) o = this.ownHero;
                if (aa.own.entitiyID == this.enemyHero.entitiyID) o = this.enemyHero;
            }

            if (aa.card != null)
            {
                foreach (Handmanager.Handcard hh in this.owncards)
                {
                    if (hh.entity == aa.card.entity)
                    {
                        ha = hh;
                        break;
                    }
                }
                if (aa.tracking >= 1 )
                {
                    ha = Handmanager.Instance.getCardChoice(aa.tracking - 1);
                }
                if (aa.actionType == actionEnum.useHeroPower)
                {
                    ha = this.isOwnTurn ? this.ownHeroAblility : this.enemyHeroAblility;
                }
            }
            // create and execute the action------------------------------------------------------------------------
            Action a = new Action(aa.actionType, ha, o, aa.place, trgt, aa.penalty, aa.druidchoice, aa.tracking);

            //druidchoice correction, and save tracking-choice
            if (a.tracking >= 1)
            {
                int codedchoice = a.druidchoice;
                this.selectedChoice = a.tracking;

            }

            //save the action if its our first turn
            if (this.turnCounter == 0) this.playactions.Add(a);
            //if (this.isOwnTurn) this.playactions.Add(a);

            // its a minion attack--------------------------------
            if (a.actionType == actionEnum.attackWithMinion)
            {
                this.evaluatePenality += a.penalty;
                Minion target = a.target;
                //secret stuff
                int newTarget = this.secretTrigger_CharIsAttacked(a.own, target);

                if (newTarget >= 1)
                {
                    //search new target!
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                    //Helpfunctions.Instance.ErrorLog("missdirection target = " + target.entitiyID);
                }
                if (a.own.Hp >= 1) minionAttacksMinion(a.own, target);
            }
            else
            {
                // its an hero attack--------------------------------
                if (a.actionType == actionEnum.attackWithHero)
                {
                    //secret trigger is inside
                    //Console.WriteLine("HERO ATTACK:::::::::::::###################################");
                    attackWithWeapon(a.own, a.target, a.penalty);
                    //Console.WriteLine("HERO ATTACK:::::::::::::###################################");
                }
                else
                {
                    // its an playing-card--------------------------------
                    if (a.actionType == actionEnum.playcard)
                    {
                        if (this.isOwnTurn)
                        {
                            playACard(a.card, a.target, a.place, a.druidchoice, a.penalty);
                        }
                        else
                        {
                            //enemyplaysACard();
                        }
                    }
                    else
                    {
                        // its using the hero power--------------------------------
                        if (a.actionType == actionEnum.useHeroPower)
                        {
                            playHeroPower(a.target, a.penalty, this.isOwnTurn);
                        }
                    }
                }
            }







            if (this.isOwnTurn)
            {
                this.optionsPlayedThisTurn++;
            }
            else
            {
                this.enemyOptionsDoneThisTurn++;
            }

        }

        //minion attacks a minion

        //dontcount = betrayal effect!
        public void minionAttacksMinion(Minion attacker, Minion defender, bool dontcount = false)
        {

            if (attacker.isHero)
            {
                if (defender.isHero)
                {

                    defender.getDamageOrHeal(attacker.Angr, this, true, false);
                }
                else
                {

                    int enem_attack = defender.Angr;

                    defender.getDamageOrHeal(attacker.Angr, this, true, false);

                    if (!this.ownHero.immuneWhileAttacking)
                    {
                        int oldhp = attacker.Hp;
                        attacker.getDamageOrHeal(enem_attack, this, true, false);
                        if (!defender.silenced && oldhp > attacker.Hp)
                        {
                            if (defender.handcard.card.name == CardDB.cardName.waterelemental || defender.handcard.card.name == CardDB.cardName.snowchugger)
                            {
                                attacker.frozen = true;
                            }

                            this.triggerAMinionDealedDmg(defender, oldhp - attacker.Hp, enem_attack);
                        }
                    }
                }
                doDmgTriggers();
                return;
            }

            if (!dontcount)
            {
                attacker.numAttacksThisTurn++;
                attacker.stealth = false;
                if ((attacker.windfury && attacker.numAttacksThisTurn == 2) || !attacker.windfury)
                {
                    attacker.Ready = false;
                }

            }
            

            if (logging) Helpfunctions.Instance.logg(".attck with" + attacker.name + " A " + attacker.Angr + " H " + attacker.Hp);

            int attackerAngr = attacker.Angr;
            int defAngr = defender.Angr;

            //trigger attack ---------------------------
            this.triggerAMinionIsGoingToAttack(attacker,defender);
            //------------------------------------------

            if (defender.isHero)//target is enemy hero
            {

                int oldhp = defender.Hp;
                defender.getDamageOrHeal(attacker.Angr, this, true, false);
                if (!attacker.silenced && oldhp > defender.Hp) // attacker did dmg
                {

                    if (attacker.handcard.card.name == CardDB.cardName.waterelemental || attacker.handcard.card.name == CardDB.cardName.snowchugger) defender.frozen = true;

                    this.triggerAMinionDealedDmg(attacker, oldhp - defender.Hp, attackerAngr);
                }
                doDmgTriggers();
                return;
            }



            //defender gets dmg
            int oldHP = defender.Hp;
            defender.getDamageOrHeal(attackerAngr, this, true, false);
            if (!attacker.silenced && oldHP > defender.Hp && (attacker.handcard.card.name == CardDB.cardName.waterelemental || attacker.handcard.card.name == CardDB.cardName.snowchugger)) defender.frozen = true;
            bool defenderGotDmg = oldHP > defender.Hp;

            bool attackerGotDmg = false;

            //attacker gets dmg
            if (!dontcount)//betrayal effect :D
            {
                oldHP = attacker.Hp;
                attacker.getDamageOrHeal(defAngr, this, true, false);

                if (!defender.silenced && oldHP > attacker.Hp)
                {
                   if(defender.handcard.card.name == CardDB.cardName.waterelemental || defender.handcard.card.name == CardDB.cardName.snowchugger) attacker.frozen = true;

                   this.triggerAMinionDealedDmg(defender, oldHP - attacker.Hp, defAngr);
                }
                attackerGotDmg = oldHP > attacker.Hp;
            }


            //trigger poisonous effect of attacker + defender (even if they died due to attacking/defending)

            if (defenderGotDmg && !attacker.silenced && attacker.handcard.card.poisionous && !defender.isHero)
            {
                minionGetDestroyed(defender);
            }

            if (attackerGotDmg && !defender.silenced && defender.handcard.card.poisionous && !attacker.isHero)
            {
                minionGetDestroyed(attacker);
            }

            if (!dontcount) //foe reaper reaps!
            {
                if ((attacker.name == CardDB.cardName.foereaper4000 || attacker.name == CardDB.cardName.magnatauralpha) && !attacker.silenced)
                {
                    List<Minion> temp = (attacker.own) ? this.enemyMinions : this.ownMinions;
                    foreach (Minion mnn in temp)
                    {
                        if (mnn.zonepos + 1 == defender.zonepos || mnn.zonepos - 1 == defender.zonepos)
                        {
                            this.minionAttacksMinion(attacker, mnn, true);
                        }
                    }
                }
            }

            this.doDmgTriggers();

            

        }

        //a hero attacks a minion
        public void attackWithWeapon(Minion hero, Minion target, int penality)
        {
            bool own = hero.own;
            this.attacked = true;
            this.evaluatePenality += penality;
            hero.numAttacksThisTurn++;

            //hero will end his readyness
            hero.updateReadyness();

            //heal whether truesilverchampion equipped
            if (own)
            {
                if (this.ownWeaponName == CardDB.cardName.truesilverchampion)
                {
                    int heal = this.getMinionHeal(2);//minionheal because it's ignoring spellpower
                    this.minionGetDamageOrHeal(hero, -heal);
                    doDmgTriggers();
                }
            }
            else
            {
                if (this.enemyWeaponName == CardDB.cardName.truesilverchampion)
                {
                    int heal = this.getEnemyMinionHeal(2);
                    this.minionGetDamageOrHeal(hero, -heal);
                    doDmgTriggers();
                }
            }

            if (logging) Helpfunctions.Instance.logg("attck with weapon trgt: " + target.entitiyID);

            // hero attacks enemy----------------------------------------------------------------------------------

            if (target.isHero)// trigger secret and change target if necessary
            {
                int newTarget = this.secretTrigger_CharIsAttacked(hero, target);
                if (newTarget >= 1)
                {
                    //search new target!
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                }

            }
            this.minionAttacksMinion(hero, target);
            //-----------------------------------------------------------------------------------------------------

            //gorehowl is not killed if he attacks minions
            if (own)
            {
                if (ownWeaponName == CardDB.cardName.gorehowl && !target.isHero)
                {
                    this.ownWeaponAttack--;
                    hero.Angr--;
                }
                else
                {
                    this.lowerWeaponDurability(1, true);
                }
            }
            else
            {
                if (enemyWeaponName == CardDB.cardName.gorehowl && !target.isHero)
                {
                    this.enemyWeaponAttack--;
                    hero.Angr--;
                }
                else
                {
                    this.lowerWeaponDurability(1, false);
                }
            }

        }

        //play a minion trigger stuff:
        // 1 whenever you play a card whatever triggers
        // 2 Auras
        // 5 whenever you summon a minion triggers (like starving buzzard)
        // 3 battlecry
        // 3.5 place minion
        // 3.75 dmg/died/dthrttl triggers
        // 4 secret: minion is played
        // 4.5 dmg/died/dthrttl triggers
        // 5 after you summon a minion triggers
        // 5.5 dmg/died/dthrttl triggers
        public void playACard(Handmanager.Handcard hc, Minion target, int position, int choice, int penality)
        {

            CardDB.Card c = hc.card;
            this.evaluatePenality += penality;
            this.mana = this.mana - hc.getManaCost(this);
            removeCard(hc);// remove card from hand
            

            this.triggerCardsChanged(true);

            if (c.type == CardDB.cardtype.SPELL)
            {
                this.playedPreparation = false;
            }
            if (c.race == TAG_RACE.DRAGON) //dragon
            {
                this.ownDragonConsort = 0;
            }
            if (c.Secret)
            {
                this.ownSecretsIDList.Add(c.cardIDenum);
                this.playedmagierinderkirintor = false;
            }


            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + hc.entity + " mana " + hc.getManaCost(this) + " trgt " + target);


            this.triggerACardWillBePlayed(hc, true, target, choice);
            int newTarget = secretTrigger_SpellIsPlayed(target, c.type == CardDB.cardtype.SPELL);
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
            }
            if (newTarget != -2) // trigger spell-secrets!
            {

                if (c.type == CardDB.cardtype.MOB)
                {
                    this.placeAmobSomewhere(hc, target, choice, position);
                    this.mobsplayedThisTurn++;

                }
                else
                {

                    c.sim_card.onCardPlay(this, true, target, choice);
                    this.doDmgTriggers();
                    //secret trigger? do here


                }

                //atm only 2 cards trigger this
                if (c.type == CardDB.cardtype.SPELL)
                {
                    this.triggerACardWasPlayed(c, true);
                    this.doDmgTriggers();
                }
            }

            //this.ueberladung += c.recallValue;
            this.cardsPlayedThisTurn++;

        }

        public void enemyplaysACard(CardDB.Card c, Minion target, int position, int choice, int penality)
        {

            Handmanager.Handcard hc = new Handmanager.Handcard(c);
            hc.entity = this.getNextEntity();
            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("enemy play crd " + c.name + " trgt " + target);

            if (c.race == TAG_RACE.DRAGON) //dragon
            {
                this.enemyDragonConsort = 0;
            }

            this.enemyAnzCards--;//might be deleted if he got a real hand

            this.triggerACardWillBePlayed(hc, false, target, choice);
            this.triggerCardsChanged(false);

            int newTarget = secretTrigger_SpellIsPlayed(target, c.type == CardDB.cardtype.SPELL);
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
            }
            if (newTarget != -2) // trigger spell-secrets!
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    //todo mob playing
                    //this.placeAmobSomewhere(hc, target, choice, position);

                }
                else
                {
                    c.sim_card.onCardPlay(this, false, target, choice);
                    this.doDmgTriggers();
                    //secret trigger? do here


                }
            }

            //atm only 2 cards trigger this
            if (c.type == CardDB.cardtype.SPELL)
            {
                this.triggerACardWasPlayed(c, false);
                this.doDmgTriggers();
            }

        }


        public void playHeroPower(Minion target, int penality, bool ownturn)
        {

            CardDB.Card c = (ownturn) ? this.ownHeroAblility.card : this.enemyHeroAblility.card;
            this.heroPowerActivationsThisTurn++;
            if (ownturn)
            {
                this.own_TIMES_HERO_POWER_USED_THIS_GAME++;
                int allowedUses = 1;
                if (this.anzOwnGarrisonCommander >= 1)
                {
                    if (this.anzOwnGarrisonCommander < 1000) allowedUses = 2;
                    if (this.anzOwnGarrisonCommander >= 1000) allowedUses = 1000;
                }
                if (this.heroPowerActivationsThisTurn >= allowedUses)
                {
                    this.ownAbilityReady = false;
                }

            }
            else
            {
                this.enemy_TIMES_HERO_POWER_USED_THIS_GAME++;
                int allowedUses = 1;
                if (this.anzEnemyGarrisonCommander >= 1)
                {
                    if (this.anzEnemyGarrisonCommander < 1000) allowedUses = 2;
                    if (this.anzEnemyGarrisonCommander >= 1000) allowedUses = 1000;
                }
                if (this.heroPowerActivationsThisTurn >= allowedUses)
                {
                    this.enemyAbilityReady = false;
                }
                
            }
            int cost = c.getManaCost(this,2);

            
            this.evaluatePenality += penality;
            this.mana = this.mana - cost;
            this.anzOwnFencingCoach = 0;

            this.secretTrigger_HeroPowerUsed(ownturn);

            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " trgt " + target);

            c.sim_card.onCardPlay(this, ownturn, target, 0);
            this.doDmgTriggers();

            foreach (Minion m in (ownturn) ? this.ownMinions.ToArray() : this.enemyMinions.ToArray())
            {
                if (!m.silenced) m.handcard.card.sim_card.onInspire(this, m);
            }
            this.doDmgTriggers();
        }


        //lower durability of weapon + destroy them (deathrattle) 
        //todo: test death's bite's dearthrattle
        public void lowerWeaponDurability(int value, bool own)
        {

            if (own)
            {
                if (this.ownWeaponDurability <= 0) return;
                this.ownWeaponDurability -= value;
                if (this.ownWeaponDurability <= 0)
                {
                    //todo deathrattle deathsbite

                    if (this.ownWeaponName == CardDB.cardName.powermace && this.ownMinions.Count>=1)
                    {
                        if (this.isServer)
                        {
                            List<Minion> temp = new List<Minion>();
                            foreach (Minion m in ownMinions)
                            {
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                                {
                                    temp.Add(m);
                                }
                            }
                            Minion choosen = this.getRandomMinionOfThatList(temp);
                            if (choosen != null) this.minionGetBuffed(choosen, 2, 2);
                        }
                        else
                        {
                            int sum = 1000;
                            Minion t = null;

                            foreach (Minion m in ownMinions)
                            {
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                                {
                                    int s = m.maxHp + m.Angr;
                                    if (s < sum)
                                    {
                                        t = m;
                                        sum = s;
                                    }
                                }

                            }

                            if (t != null && sum < 999)
                            {
                                this.minionGetBuffed(t, 2, 2);
                            }
                        }
                    }

                    if (this.ownWeaponName == CardDB.cardName.deathsbite)
                    {
                        int anz = 1;
                        if (this.ownBaronRivendare >= 1) anz = 2;
                        int dmg = getSpellDamageDamage(1);
                        foreach (Minion m in this.ownMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        foreach (Minion m in this.enemyMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        this.doDmgTriggers();

                    }

                    if (this.ownWeaponName == CardDB.cardName.chargedhammer)
                    {
                        this.ownHeroAblility = new Handmanager.Handcard(CardDB.Instance.ligthningJolt);
                        if(this.isOwnTurn) this.heroPowerActivationsThisTurn = 0;

                    }


                    this.ownHero.Angr -= this.ownWeaponAttack;
                    this.ownWeaponDurability = 0;
                    this.ownWeaponAttack = 0;
                    this.ownWeaponName = CardDB.cardName.unknown;
                    this.ownHero.windfury = false;

                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.playedThisTurn && m.name == CardDB.cardName.southseadeckhand)
                        {
                            m.charge--;
                            m.updateReadyness(this);
                        }
                    }
                    this.ownHero.updateReadyness();
                }
            }
            else
            {
                if (this.enemyWeaponDurability <= 0) return;
                this.enemyWeaponDurability -= value;
                if (this.enemyWeaponDurability <= 0)
                {
                    //deathrattle deathsbite

                    if (this.ownWeaponName == CardDB.cardName.powermace && this.enemyMinions.Count >= 1)
                    {
                        if (this.isServer)
                        {
                            List<Minion> temp = new List<Minion>();
                            foreach (Minion m in enemyMinions)
                            {
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                                {
                                    temp.Add(m);
                                }
                            }
                            Minion choosen = this.getRandomMinionOfThatList(temp);
                            if (choosen != null) this.minionGetBuffed(choosen, 2, 2);
                        }
                        else
                        {
                            int sum = 1000;
                            Minion t = null;

                            foreach (Minion m in enemyMinions)
                            {
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                                {
                                    int s = m.maxHp + m.Angr;
                                    if (s < sum)
                                    {
                                        t = m;
                                        sum = s;
                                    }
                                }

                            }

                            if (t != null && sum < 999)
                            {
                                this.minionGetBuffed(t, 2, 2);
                            }
                        }
                    }

                    if (this.enemyWeaponName == CardDB.cardName.deathsbite)
                    {
                        int anz = 1;
                        if (this.enemyBaronRivendare >= 1) anz = 2;
                        int dmg = getEnemySpellDamageDamage(1);
                        foreach (Minion m in this.ownMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        foreach (Minion m in this.enemyMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        this.doDmgTriggers();
                    }

                    if (this.enemyWeaponName == CardDB.cardName.chargedhammer)
                    {
                        this.enemyHeroAblility = new Handmanager.Handcard(CardDB.Instance.ligthningJolt);
                        if (!this.isOwnTurn) this.heroPowerActivationsThisTurn = 0;

                    }

                    this.enemyHero.Angr -= this.enemyWeaponAttack;
                    this.enemyWeaponDurability = 0;
                    this.enemyWeaponAttack = 0;
                    this.enemyWeaponName = CardDB.cardName.unknown;
                    this.enemyHero.windfury = false;
                    this.enemyHero.updateReadyness();
                }
            }
        }



        public void doDmgTriggers()
        {
            //we do the these trigger manualy (to less minions) (we could trigger them with m.handcard.card.sim_card.ontrigger...)
            if (this.tempTrigger.charsGotHealed >= 1)
            {
                triggerACharGotHealed();//possible effects: gain attack
                this.tempTrigger.charsGotHealed = 0;
                this.tempTrigger.owncharsGotHealed = 0;
            }

            if (this.tempTrigger.minionsGotHealed >= 1)
            {
                triggerAMinionGotHealed();//possible effects: draw card
                this.tempTrigger.minionsGotHealed = 0;
                this.tempTrigger.ownMinionsGotHealed = 0;
            }


            if (this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg + this.tempTrigger.ownHeroGotDmg + this.tempTrigger.enemyHeroGotDmg>= 1)
            {
                triggerAMinionGotDmg(); //possible effects: draw card, gain armor, gain attack
                this.tempTrigger.ownMinionsGotDmg = 0;
                this.tempTrigger.enemyMinionsGotDmg = 0;
                this.tempTrigger.ownHeroGotDmg = 0;
                this.tempTrigger.enemyHeroGotDmg = 0;
            }

            if (this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                triggerAMinionDied(); //possible effects: draw card, gain attack + hp
                if (this.tempTrigger.ownMinionsDied >= 1) this.tempTrigger.ownMinionsChanged = true;
                if (this.tempTrigger.enemyMinionsDied >= 1) this.tempTrigger.enemyMininsChanged = true;
                this.tempTrigger.ownMinionsDied = 0;
                this.tempTrigger.enemyMinionsDied = 0;
                this.tempTrigger.ownBeastDied = 0;
                this.tempTrigger.enemyBeastDied = 0;
                this.tempTrigger.ownMurlocDied = 0;
                this.tempTrigger.enemyMurlocDied = 0;
                this.tempTrigger.ownMechanicDied = 0;
                this.tempTrigger.enemyMechanicDied = 0;
            }

            updateBoards();
            if (this.tempTrigger.charsGotHealed + this.tempTrigger.minionsGotHealed + this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg + this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                doDmgTriggers();
            }
        }

        public void triggerACharGotHealed()
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden)
                {
                    if (turnCounter == 0)
                    {
                        for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                        {
                            mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                        }
                    }
                    else
                    {
                        //we are doing this, because we dont do a "real" search on enemys turn
                        for (int i = 0; i < this.tempTrigger.owncharsGotHealed; i++)
                        {
                            mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                        }
                    }
                    
                }

                if (mnn.handcard.card.name == CardDB.cardName.shadowboxer)
                {
                    for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                    {
                        mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.holychampion)
                {
                    if (turnCounter == 0)
                    {
                        for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                        {
                            mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                        }
                    }
                    else 
                    {
                        //we are doing this, because we dont do a "real" search on enemys turn
                        for (int i = 0; i < this.tempTrigger.owncharsGotHealed; i++)
                        {
                            mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                        }
                    }
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden)
                {
                    for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                    {
                        mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                    }

                }

                if (mnn.handcard.card.name == CardDB.cardName.shadowboxer)
                {
                    for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                    {
                        mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.holychampion)
                {
                    for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                    {
                        mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn, true);
                    }
                }
            }
        }

        public void triggerAMinionGotHealed()
        {
            //also dead minions trigger this
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.northshirecleric)
                {
                    for (int i = 0; i < this.tempTrigger.minionsGotHealed; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }
            }

            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.northshirecleric)
                {
                    for (int i = 0; i < this.tempTrigger.minionsGotHealed; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }
            }
        }

        public void triggerAMinionGotDmg()
        {
            /*
            int anz = this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg;
            for (int i = 0; i < anz; i++)
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, i < this.tempTrigger.ownMinionsGotDmg);
                }

                foreach (Minion m in this.enemyMinions)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, i < this.tempTrigger.ownMinionsGotDmg);
                }
            }*/

            // only 4 minions.. we do this manually :D
            //allso dead minion trigger this!

            if (this.anzOwnAcidMaw + this.anzEnemyAcidMaw >= 1)
            {
                int anzam = this.anzOwnAcidMaw + this.anzEnemyAcidMaw;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.anzGotDmg >= 1)
                    {
                        if (!m.silenced && m.name == CardDB.cardName.acidmaw && anzam == 1) continue;
                        this.minionGetDestroyed(m);
                    }
                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.anzGotDmg >= 1)
                    {
                        if (!m.silenced && m.name == CardDB.cardName.acidmaw && anzam == 1) continue;
                        this.minionGetDestroyed(m);
                    }
                }
            }

            int grimpatrons = 0;
            int eggs = 0;
            int imps = 0;
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced)
                {
                    m.anzGotDmg = 0;
                    m.gotDmgRaw = 0;

                    continue;
                }

                if (m.name == CardDB.cardName.frothingberserker)
                {
                    this.minionGetBuffed(m, this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg, 0);
                }

                if (m.name == CardDB.cardName.gurubashiberserker && m.anzGotDmg >= 1)
                {
                    this.minionGetBuffed(m, 3 * m.anzGotDmg, 0);
                }

                if (m.name == CardDB.cardName.acolyteofpain && m.anzGotDmg >= 1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }

                if (m.name == CardDB.cardName.armorsmith)
                {
                    for(int i = 0;i< this.tempTrigger.ownMinionsGotDmg;i++)
                    {
                    this.minionGetArmor(this.ownHero,1);
                    }
                }

                if (m.name == CardDB.cardName.gahzrilla && m.anzGotDmg >= 1)
                {
                    int attackbuff = m.Angr * (int)Math.Pow(2, m.anzGotDmg) - m.Angr;
                    this.minionGetBuffed(m, attackbuff, 0);
                }

                if (this.isOwnTurn && m.name == CardDB.cardName.floatingwatcher && this.ownHero.anzGotDmg>=1)
                {
                    this.minionGetBuffed(m, 2 * this.ownHero.anzGotDmg, 2 * this.ownHero.anzGotDmg);
                }

                if (m.name == CardDB.cardName.mechbearcat && m.anzGotDmg>=1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.PART_001, true, true);
                    }
                }

                if (m.name == CardDB.cardName.grimpatron && m.Hp>=1 && m.anzGotDmg >= 1)
                {
                    grimpatrons+= m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.dragonegg && m.anzGotDmg >= 1)//todo: maybe only if it survives?
                {
                    eggs += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.impgangboss && m.anzGotDmg >= 1)
                {
                    imps += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.axeflinger && m.anzGotDmg >= 1)
                {
                    this.minionGetDamageOrHeal(this.enemyHero, 2 * m.anzGotDmg, true);
                }

                if (m.name == CardDB.cardName.wrathguard && m.anzGotDmg >= 1)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, m.own);
                }

                m.anzGotDmg = 0;
                m.gotDmgRaw = 0;


            }

            //summon grimpatrons and eggs and imps
            for (int i = 0; i < grimpatrons; i++)
            {
                int pos = this.ownMinions.Count;
                this.callKid(CardDB.Instance.grimpatron, pos, true);
            }
            for (int i = 0; i < eggs; i++)
            {
                int pos = this.ownMinions.Count;
                this.callKid(CardDB.Instance.whelp2a1h, pos, true);
            }
            for (int i = 0; i < imps; i++)
            {
                int pos = this.ownMinions.Count;
                this.callKid(CardDB.Instance.imp, pos, true);
            }

            //enemys minions
            grimpatrons = 0;
            eggs = 0;
            imps = 0;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced)
                {
                    m.anzGotDmg = 0;
                    m.gotDmgRaw = 0;
                    continue;
                }

                if (m.name == CardDB.cardName.frothingberserker)
                {
                    this.minionGetBuffed(m, this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg, 0);
                }

                if (m.name == CardDB.cardName.gurubashiberserker && m.anzGotDmg >= 1)
                {
                    this.minionGetBuffed(m, 3 * m.anzGotDmg, 0);
                }

                if (m.name == CardDB.cardName.acolyteofpain && m.anzGotDmg >= 1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }

                if (m.name == CardDB.cardName.armorsmith)
                {
                    for (int i = 0; i < this.tempTrigger.enemyMinionsGotDmg; i++)
                    {
                        this.minionGetArmor(this.enemyHero, 1);
                    }
                }

                if (m.name == CardDB.cardName.gahzrilla && m.anzGotDmg >= 1)
                {

                    int attackbuff = m.Angr * (int)Math.Pow(2, m.anzGotDmg) - m.Angr;
                    this.minionGetBuffed(m, attackbuff, 0);
                }

                if (!this.isOwnTurn && m.name == CardDB.cardName.floatingwatcher && this.enemyHero.anzGotDmg >= 1)
                {
                    this.minionGetBuffed(m, 2 * this.enemyHero.anzGotDmg, 2 * this.enemyHero.anzGotDmg);
                }

                if (m.name == CardDB.cardName.mechbearcat && m.anzGotDmg >= 1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.PART_001, false, true);
                    }
                }


                if (m.name == CardDB.cardName.grimpatron && m.Hp >= 1 && m.anzGotDmg >= 1)
                {
                    grimpatrons += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.dragonegg && m.anzGotDmg >= 1)//todo: maybe only if it survives?
                {
                    eggs += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.impgangboss && m.anzGotDmg >= 1)
                {
                    imps += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.axeflinger && m.anzGotDmg >= 1)
                {
                    this.minionGetDamageOrHeal(this.ownHero, 2 * m.anzGotDmg, true);
                }

                if (m.name == CardDB.cardName.wrathguard && m.anzGotDmg >= 1)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, m.own);
                }

                m.anzGotDmg = 0;
                m.gotDmgRaw = 0;
            }

            //summon grimpatrons
            for (int i = 0; i < grimpatrons; i++)
            {
                int pos = this.enemyMinions.Count;
                this.callKid(CardDB.Instance.grimpatron, pos, false);
            }
            for (int i = 0; i < eggs; i++)
            {
                int pos = this.enemyMinions.Count;
                this.callKid(CardDB.Instance.whelp2a1h, pos, false);
            }
            for (int i = 0; i < imps; i++)
            {
                int pos = this.enemyMinions.Count;
                this.callKid(CardDB.Instance.imp, pos, false);
            }

            this.ownHero.anzGotDmg = 0;
            this.enemyHero.anzGotDmg = 0;
        }

        public void triggerAMinionDied()
        {
            int summonOwn = 0;
            int summonEnemy = 0;
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.Hp <= 0) continue;
                if (mnn.handcard.card.name == CardDB.cardName.cultmaster)
                {
                    int anz = this.tempTrigger.ownMinionsDied;
                    if (mnn.Hp <= 0) anz--;//only other minions

                    for (int i = 0; i < anz; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.flesheatingghoul)
                {
                    this.minionGetBuffed(mnn, this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied, 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.scavenginghyena)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.ownBeastDied, this.tempTrigger.ownBeastDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.oldmurkeye)
                {
                    this.minionGetBuffed(mnn, -1 * (this.tempTrigger.ownMurlocDied + this.tempTrigger.enemyMurlocDied), 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.siltfinspiritwalker)
                {
                    for (int i = 0; i < this.tempTrigger.ownMurlocDied; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.cogmaster )
                {
                    if (this.tempTrigger.ownMechanicDied >= 1)
                    {
                        //check if we have more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Hp >=1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            //we have no living mechanics -> debuff cogmaster
                            this.minionGetBuffed(mnn, -2, 0);
                        }



                    }
                }

                if ( mnn.handcard.card.name == CardDB.cardName.cogmasterswrench)
                {
                    if (this.tempTrigger.ownMechanicDied >= 1)
                    {
                        //check if we have more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Hp >= 1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            this.ownWeaponAttack -= 2;
                            this.minionGetBuffed(this.ownHero, -2, 0);
                        }



                    }
                }


                if (mnn.handcard.card.name == CardDB.cardName.junkbot)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.ownMechanicDied, 2*this.tempTrigger.ownMechanicDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.mekgineerthermaplugg)
                {
                    summonOwn += this.tempTrigger.enemyMinionsDied;
                }

                if (mnn.handcard.card.name == CardDB.cardName.eeriestatue)
                {
                    mnn.updateReadyness(this);
                }

            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.Hp <= 0) continue;
                if (mnn.handcard.card.name == CardDB.cardName.cultmaster)
                {
                    int anz = this.tempTrigger.enemyMinionsDied;
                    if (mnn.Hp <= 0) anz--;//only other minions

                    for (int i = 0; i < anz; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.flesheatingghoul)
                {
                    this.minionGetBuffed(mnn, this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied, 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.scavenginghyena)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.enemyBeastDied, this.tempTrigger.enemyBeastDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.oldmurkeye)
                {
                    this.minionGetBuffed(mnn, -1 * (this.tempTrigger.ownMurlocDied + this.tempTrigger.enemyMurlocDied), 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.siltfinspiritwalker)
                {
                    for (int i = 0; i < this.tempTrigger.enemyMurlocDied; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.cogmaster)
                {
                    if (this.tempTrigger.enemyMechanicDied >= 1)
                    {
                        //check if we have more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.enemyMinions)
                        {
                            if (m.Hp >= 1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            //we have no living mechanics -> debuff cogmaster
                            this.minionGetBuffed(mnn, -2, 0);
                        }



                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.cogmasterswrench)
                {
                    if (this.tempTrigger.ownMechanicDied >= 1)
                    {
                        //check if we have more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Hp >= 1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            this.enemyWeaponAttack -= 2;
                            this.minionGetBuffed(this.enemyHero, -2, 0);
                        }



                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.junkbot)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.enemyMechanicDied, 2 * this.tempTrigger.enemyMechanicDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.mekgineerthermaplugg)
                {
                    summonEnemy += this.tempTrigger.ownMinionsDied;
                }

                if (mnn.handcard.card.name == CardDB.cardName.eeriestatue)
                {
                    mnn.updateReadyness(this);
                }
            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.name == CardDB.cardName.bolvarfordragon) hc.addattack += this.tempTrigger.ownMinionsDied;
            }

            if (summonOwn >= 1)
            {
                for (int i = 0; i < summonOwn; i++)
                {
                    int pos = this.ownMinions.Count ;
                    this.callKid(CardDB.Instance.lepergnome, pos, true);
                }
            }
            if (summonEnemy >= 1)
            {
                for (int i = 0; i < summonEnemy; i++)
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.lepergnome, pos, false);
                }
            }
        }

        public void triggerAMinionIsGoingToAttack(Minion attacker, Minion defender)
        {
            //todo trigger secret her too
            //blessing of wisdom (truesilver is located in attackWithWeapon(...))
            if (attacker.ownBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.ownBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardIDEnum.None, true);
                }
            }
            if (attacker.enemyBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.enemyBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardIDEnum.None, false);
                }
            }

            if (attacker.ownPowerWordGlory >= 1)
            {
                for (int i = 0; i < attacker.ownPowerWordGlory; i++)
                {
                    int heal = this.getMinionHeal(4);
                    this.minionGetDamageOrHeal(this.ownHero, -heal, true);
                }
            }

            if (attacker.enemyPowerWordGlory >= 1)
            {
                for (int i = 0; i < attacker.enemyPowerWordGlory; i++)
                {
                    int heal = this.getEnemyMinionHeal(4);
                    this.minionGetDamageOrHeal(this.enemyHero, -heal, true);
                }
            }

            if (defender.isHero && attacker.name == CardDB.cardName.cutpurse)
            {
                this.drawACard(CardDB.cardIDEnum.GAME_005, attacker.own);
            }

        }

        public void triggerAMinionDealedDmg(Minion m, int dmgDone, int attackvalue)
        {
            //only GVG_018 has such an trigger!
            if (m.name == CardDB.cardName.mistressofpain && dmgDone >= 1)
            {
                if (m.own)
                {
                    if (this.anzOwnAuchenaiSoulpriest >= 1) // you have a soulpriest? lol you die!!!
                    {
                        this.ownHero.Hp = 0;
                    }
                    else
                    {
                        this.minionGetDamageOrHeal(this.ownHero, -attackvalue);
                    }
                }
                else
                {
                    if (this.anzEnemyAuchenaiSoulpriest >= 1) // you have a soulpriest? lol you die!!!
                    {
                        this.enemyHero.Hp = 0;
                    }
                    else
                    {
                        this.minionGetDamageOrHeal(this.enemyHero, -attackvalue);
                    }
                }
            }
 
        }

        public void triggerACardWillBePlayed(Handmanager.Handcard hc, bool own, Minion target, int choice)
        {
            if (this.isOwnTurn == own && this.lockAndLoads>=1 && hc.card.type == CardDB.cardtype.SPELL)
            {
                for (int i = 0; i < this.lockAndLoads; i++)
                {
                    if (this.isServer)
                    {
                        //TODO (draw a hunter card)
                        this.drawACard(CardDB.cardIDEnum.None, own, true);
                    }
                    else
                    {
                        this.drawACard(CardDB.cardIDEnum.None, own, true);
                    }
                }
            }

            if (own)
            {
                int violetteacher = 0; //we count violetteacher to avoid copying ownminions
                int illidan = 0;
                int burly = 0;

                if (target!=null && target.name == CardDB.cardName.dragonkinsorcerer && target.own == own && hc.card.type == CardDB.cardtype.SPELL)
                {
                    this.minionGetBuffed(target, 1, 1);
                }

                int summonstones = 0;
                Minion summoningStone = null;

                foreach (Minion m in this.ownMinions)
                {
                    if (m.silenced) continue;

                    if (own && m.name == CardDB.cardName.illidanstormrage)
                    {
                        illidan++;
                        continue;
                    }

                    if (own && m.name == CardDB.cardName.violetteacher)
                    {
                        if (hc.card.type == CardDB.cardtype.SPELL)
                        {
                            violetteacher++;
                        }
                        continue;
                    }
                    if (own && m.name == CardDB.cardName.hobgoblin)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB && hc.card.Attack == 1 )
                        {
                            hc.addattack += 2;
                            hc.addHp += 2;
                        }
                        continue;
                    }

                    if (own && m.name == CardDB.cardName.summoningstone)
                    {
                        summonstones++;
                        summoningStone = m;
                        continue;
                    }

                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                }

                for (int i = 0; i < summonstones; i++)
                {
                    summoningStone.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, summoningStone, target, choice);
                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.name == CardDB.cardName.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardName.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                    }
                }

                for (int i = 0; i < violetteacher; i++)
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.teacherminion, pos, own);
                }

                for (int i = 0; i < illidan; i++)
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.illidanminion, pos, own);
                }

                for (int i = 0; i < burly; i++)//summon for enemy !
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, !own);
                }
                
                
            }
            else
            {
                int violetteacher = 0; //we count violetteacher to avoid copying ownminions
                int illidan = 0;
                int burly = 0;

                if (target!=null && target.name == CardDB.cardName.dragonkinsorcerer && target.own == own && hc.card.type == CardDB.cardtype.SPELL)
                {
                    this.minionGetBuffed(target, 1, 1);
                }

                int summonstones = 0;
                Minion summoningStone = null;

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.silenced) continue;
                    if (!own && m.name == CardDB.cardName.illidanstormrage)
                    {
                        illidan++;
                        continue;
                    }
                    if (!own && m.name == CardDB.cardName.violetteacher)
                    {
                        if (hc.card.type == CardDB.cardtype.SPELL)
                        {
                            violetteacher++;
                        }
                        continue;
                    }
                    if (!own && m.name == CardDB.cardName.hobgoblin)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB && hc.card.Attack == 1)
                        {
                            hc.addattack += 2;
                            hc.addHp += 2;
                        }
                        continue;
                    }

                    if (!own && m.name == CardDB.cardName.summoningstone)
                    {
                        summonstones++;
                        summoningStone = m;
                        continue;
                    }


                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                }

                for (int i = 0; i < summonstones; i++)
                {
                    summoningStone.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, summoningStone, target, choice);
                }

                foreach (Minion m in this.ownMinions)
                {
                    if (m.name == CardDB.cardName.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardName.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                    }
                }
                for (int i = 0; i < violetteacher; i++)
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.teacherminion, pos, own);
                }
                for (int i = 0; i < illidan; i++)
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.illidanminion, pos, own);
                }

                for (int i = 0; i < burly; i++)//summon for us
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, own);
                }
            }

        }

        public void triggerACardWasPlayed(CardDB.Card c, bool own)
        {
            //we do the effects manually :D (just 2 minions)
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced || m.Hp <= 0) continue;

                if (own && m.name == CardDB.cardName.flamewaker && c.type == CardDB.cardtype.SPELL)
                {
                    m.handcard.card.sim_card.onCardWasPlayed(this, c, own, m);
                }

                if (m.name == CardDB.cardName.secretkeeper && c.Secret)
                {
                    this.minionGetBuffed(m, 1, 1);
                }
                if (own && m.name == CardDB.cardName.wildpyromancer && c.type == CardDB.cardtype.SPELL)
                {
                    this.allMinionsGetDamage(1);
                }
                if (own && m.name == CardDB.cardName.rumblingelemental && c.type == CardDB.cardtype.MOB && c.battlecry==true)
                {
                    this.doDmgToRandomEnemyCLIENT2(2, true, own);
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced || m.Hp <= 0) continue;

                if (!own && m.name == CardDB.cardName.flamewaker && c.type == CardDB.cardtype.SPELL)
                {
                    m.handcard.card.sim_card.onCardWasPlayed(this, c, own, m);
                }

                if (m.name == CardDB.cardName.secretkeeper && c.Secret)
                {
                    this.minionGetBuffed(m, 1, 1);
                }
                if (!own && m.name == CardDB.cardName.wildpyromancer && c.type == CardDB.cardtype.SPELL)
                {
                    this.allMinionsGetDamage(1);
                }
                if (!own && m.name == CardDB.cardName.rumblingelemental && c.type == CardDB.cardtype.MOB && c.battlecry == true)
                {
                    this.doDmgToRandomEnemyCLIENT2(2, true, own);
                }
            }


        }

        public void triggerAMinionIsSummoned(Minion m)
        {
            if (m.own)
            {
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }

                foreach (Minion mnn in this.enemyMinions)
                {
                    if (mnn.silenced) continue;
                    if (mnn.name == CardDB.cardName.murloctidecaller) mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }

                if (this.ownWeaponName == CardDB.cardName.swordofjustice)
                {
                    this.minionGetBuffed(m, 1, 1);
                    this.lowerWeaponDurability(1, true);
                }

                if(m.handcard.card.race == TAG_RACE.PET) 
                {
                    foreach (Handmanager.Handcard hc in this.owncards)
                    {
                        if (hc.card.cardIDenum == CardDB.cardIDEnum.AT_041)
                        {
                            if (hc.manacost >= 1) hc.manacost--;
                        }
                    }

                }
            }
            else
            {
                foreach (Minion mnn in this.enemyMinions)
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }

                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.silenced) continue;
                    if (mnn.name == CardDB.cardName.murloctidecaller) mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }
                if (this.enemyWeaponName == CardDB.cardName.swordofjustice)
                {
                    this.minionGetBuffed(m, 1, 1);
                    this.lowerWeaponDurability(1, false);
                }

                if (this.isServer && m.handcard.card.race == TAG_RACE.PET)
                {
                    foreach (Handmanager.Handcard hc in this.EnemyCards)
                    {
                        if (hc.card.cardIDenum == CardDB.cardIDEnum.AT_041)
                        {
                            if (hc.manacost >= 1) hc.manacost--;
                        }
                    }

                }
            }

        }

        public void triggerAMinionWasSummoned(Minion mnn)
        {
            if (mnn.own)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.silenced) continue;
                    if (m.name == CardDB.cardName.knifejuggler)
                    {
                        m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);
                    }

                    if (m.handcard.card.name == CardDB.cardName.eeriestatue)
                    {
                        m.updateReadyness(this);
                    }

                }
            }
            else
            {
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.silenced) continue;
                    if (m.name == CardDB.cardName.knifejuggler)
                    {
                        m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);
                    }

                    if (m.handcard.card.name == CardDB.cardName.eeriestatue)
                    {
                        m.updateReadyness(this);
                    }
                }
            }

        }

        public void triggerEndTurn(bool ownturn)
        {
            //todo sort them
            //List<Minion> temp = (ownturn)? this.ownMinions : this.enemyMinions;

            List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in ownm.ToArray())
            {
                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                }
                if (ownturn == m.own && m.destroyOnOwnTurnEnd) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnEnd) this.minionGetDestroyed(m);
            }
            List<Minion> enemm = (ownturn) ? this.enemyMinions : this.ownMinions;
            foreach (Minion m in enemm.ToArray())
            {
                //only gruul + kelthuzad
                if (!m.silenced && (m.name == CardDB.cardName.gruul || m.name == CardDB.cardName.kelthuzad || m.name == CardDB.cardName.animagolem || m.name == CardDB.cardName.jeeves))
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                }
                if (ownturn == m.own && m.destroyOnOwnTurnEnd) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnEnd) this.minionGetDestroyed(m);
            }

            this.doDmgTriggers();

            //shadowmadness
            foreach (Minion m in ownm.ToArray())
            {

                if (m.shadowmadnessed)
                {
                    m.shadowmadnessed = false;
                    this.minionGetControlled(m, !m.own, false);
                }

            }

            this.doDmgTriggers();

            this.playedmagierinderkirintor = false;



            foreach (Minion m in this.ownMinions)
            {
                this.minionGetTempBuff(m, -m.tempAttack, 0);
                m.immune = false;
                m.cantLowerHPbelowONE = false;
            }
            foreach (Minion m in this.enemyMinions)
            {
                this.minionGetTempBuff(m, -m.tempAttack, 0);
                m.immune = false;
                m.cantLowerHPbelowONE = false;
            }

        }

        public void triggerStartTurn(bool ownturn)
        {
            this.numPlayerMinionsAtTurnStart = this.ownMinions.Count;
            if (ownturn)
            {
                int at073 = 0;
                foreach (CardDB.cardIDEnum cie in this.ownSecretsIDList)
                {
                    if (cie == CardDB.cardIDEnum.AT_073)
                    {
                        at073++;
                    }
                }
                if (at073 >= 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        this.minionGetBuffed(m, at073, at073);
                    }
                    this.ownSecretsIDList.RemoveAll(x => x == CardDB.cardIDEnum.AT_073);
                }
            }
            else
            {
                if (this.isServer)
                {
                    int at073 = 0;
                    foreach (CardDB.cardIDEnum cie in this.EnemySecretsIDList)
                    {
                        if (cie == CardDB.cardIDEnum.AT_073)
                        {
                            at073++;
                        }
                    }
                    if (at073 >= 1)
                    {
                        foreach (Minion m in this.enemyMinions)
                        {
                            this.minionGetBuffed(m, at073, at073);
                        }
                        this.EnemySecretsIDList.RemoveAll(x => x == CardDB.cardIDEnum.AT_073);
                    }
                }
                else
                {
                    int triggered = 0;
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_competivespirit)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_132).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_EndTurn();
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_competivespirit = false;
                            }
                        }
                    }
                }
            }
            List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
            int summonbigone = -1;
            foreach (Minion m in ownm)
            {
                m.playedThisTurn = false;
                m.numAttacksThisTurn = 0;
                m.updateReadyness(this);
                if (!m.silenced)
                {
                    if (m.name == CardDB.cardName.mimironshead)
                    {
                        summonbigone = m.zonepos - 1;
                    }
                    else
                    {
                        m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                    }
                }
                if (ownturn == m.own && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
            }

            if (summonbigone >= 0)
            {
                ownm[summonbigone].handcard.card.sim_card.onTurnStartTrigger(this, ownm[summonbigone], ownturn);
            }

            List<Minion> enemm = (ownturn) ? this.enemyMinions : this.ownMinions;
            foreach (Minion m in enemm)
            {
                if (!m.silenced)
                {
                    if (m.name == CardDB.cardName.micromachine) m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                }
                if (ownturn == m.own && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
            }

            //cursed-card effect
            if (ownturn)
            {
                foreach (Handmanager.Handcard hc in this.owncards)
                {
                    if (hc.card.cardIDenum == CardDB.cardIDEnum.LOE_007t)
                    {
                        this.minionGetDamageOrHeal(this.ownHero, 2, true);
                    }
                }
            }
            else
            {
                if(this.anzEnemyCursed>=1)this.minionGetDamageOrHeal(this.enemyHero, 2 * this.anzEnemyCursed, true);
            }

            this.doDmgTriggers();

            this.drawACard(CardDB.cardIDEnum.None, ownturn);
            this.doDmgTriggers();
        }

        public void triggerAHeroGotArmor(bool ownHero)
        {
            foreach (Minion m in ((ownHero) ? this.ownMinions : this.enemyMinions))
            {
                if (m.name == CardDB.cardName.siegeengine)
                {
                    this.minionGetBuffed(m, 1, 0);
                }
            }
        }

        public void changeRecall(bool own, int value)
        {
            int oldrecall = 0;
            int newrecall = 0;
            List<Minion> tempminions = this.ownMinions;
            if (own)
            {
                oldrecall = this.owedRecall;
                this.owedRecall = Math.Max(10,this.owedRecall+value);
                newrecall = this.owedRecall;
            }
            else
            {
                oldrecall = this.enemyRecall;
                this.enemyRecall = Math.Max(10, this.enemyRecall + value);
                newrecall = this.enemyRecall;
                tempminions = this.enemyMinions;
            };

            if (oldrecall < newrecall)
            {
                foreach (Minion m in tempminions)
                {
                    if (!m.silenced && m.name == CardDB.cardName.tunneltrogg)
                    {
                        this.minionGetBuffed(m, newrecall - oldrecall, 0);
                    }
                }
            }
        }

        public void triggerACardWasDiscarded(bool own)
        {
            if (own)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.name == CardDB.cardName.tinyknightofevil && !m.silenced)
                    {
                        m.handcard.card.sim_card.onCardWasDiscarded(this, own, m);
                    }
                }
            }
            else
            {
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.name == CardDB.cardName.tinyknightofevil && !m.silenced)
                    {
                        m.handcard.card.sim_card.onCardWasDiscarded(this, own, m);
                    }
                }
            }

            this.triggerCardsChanged(own);
        }

        public void triggerCardsChanged(bool own)
        {
            if (own)
            {
                if (this.tempanzOwnCards >= 6 && this.owncards.Count <= 5)
                {
                    //delete effect of enemy Goblin Sapper
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, -4, 0);
                        }
                    }
                }
                if (this.owncards.Count >= 6 && this.tempanzOwnCards <= 5)
                {
                    //add effect of enemy Goblin Sapper
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, 4, 0);
                        }
                    }
                }

                this.tempanzOwnCards = this.owncards.Count;
            }
            else
            {
                if (this.tempanzEnemyCards >= 6 && this.enemyAnzCards <= 5)
                {
                    //delete effect of own Goblin Sapper
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, -4, 0);
                        }
                    }
                }
                if (this.enemyAnzCards >= 6 && this.tempanzEnemyCards <= 5)
                {
                    //add effect of own Goblin Sapper
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, 4, 0);
                        }
                    }
                }

                this.tempanzEnemyCards = this.enemyAnzCards;
            }
        }


        public void secretTrigger_HeroPowerUsed(bool own)
        {
            int triggered = 0;
            if (own != this.isOwnTurn)
            {
                if (this.isOwnTurn && this.enemySecretCount >= 1)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_Dart)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_021).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_HeroGotDmg();
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_Dart = false;
                            }
                        }
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }

        public int secretTrigger_CharIsAttacked(Minion attacker, Minion defender)
        {
            int newTarget = 0;
            int triggered = 0;
            if (this.isOwnTurn && this.enemySecretCount >= 1)
            {

                if (defender.isHero && !defender.own)
                {
                    foreach (SecretItem si in this.enemySecretList.ToArray())
                    {
                        if (si.canBe_explosive)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_610).sim_card.onSecretPlay(this, false, 0);
                            doDmgTriggers();
                            //Helpfunctions.Instance.ErrorLog("trigger explosive" + attacker.Hp);
                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_explosive = false;
                            }
                        }

                        if (!attacker.isHero && si.canBe_vaporize)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_594).sim_card.onSecretPlay(this, false, attacker, 0);
                            doDmgTriggers();

                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_vaporize = false;
                            }
                        }

                        if (si.canBe_missdirection)
                        {
                            if (!(attacker.isHero && this.ownMinions.Count + this.enemyMinions.Count == 0))
                            {
                                triggered++;
                                CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_533).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                                si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                                //Helpfunctions.Instance.ErrorLog("trigger miss " + attacker.Hp);
                                foreach (SecretItem sii in this.enemySecretList)
                                {
                                    sii.canBe_missdirection = false;
                                }
                            }
                        }

                        if (si.canBe_icebarrier)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_289).sim_card.onSecretPlay(this, false, defender, 0);
                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_icebarrier = false;
                            }
                        }

                        if (si.canBe_beartrap)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_060).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_beartrap = false;
                            }

                        }

                    }

                }

                if (!defender.isHero && !defender.own)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {

                        if (si.canBe_snaketrap)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_CharIsAttacked(false, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_snaketrap = false;
                            }
                        }
                    }
                }

                if (!attacker.isHero && attacker.own) // minion attacks
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_freezing)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_611).sim_card.onSecretPlay(this, false, attacker, 0);
                            si.usedTrigger_CharIsAttacked(defender.isHero, attacker.isHero);
                            //Helpfunctions.Instance.ErrorLog("trigger freeze " + attacker.Hp);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_freezing = false;
                            }
                        }
                    }
                }

                foreach (SecretItem si in this.enemySecretList)
                {

                    if (si.canBe_noblesacrifice)
                    {
                        //triggered++;
                        bool ishero = defender.isHero;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_130).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                        si.usedTrigger_CharIsAttacked(ishero, attacker.isHero);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_noblesacrifice = false;
                        }
                    }
                }


            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

            return newTarget;
        }

        public void secretTrigger_HeroGotDmg(bool own, int dmg)
        {
            int triggered = 0;
            if (own != this.isOwnTurn)
            {
                if (this.isOwnTurn && this.enemySecretCount >= 1)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_eyeforaneye)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_132).sim_card.onSecretPlay(this, false, dmg);
                            si.usedTrigger_HeroGotDmg();
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_eyeforaneye = false;
                            }
                        }

                        if (si.canBe_iceblock && this.enemyHero.Hp <= 0)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_295).sim_card.onSecretPlay(this, false, this.enemyHero, dmg);
                            si.usedTrigger_HeroGotDmg(true);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_iceblock = false;
                            }

                        }
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }

        public void secretTrigger_MinionIsPlayed(Minion playedMinion)
        {
            int triggered = 0;
            
            if (this.isOwnTurn && playedMinion.own && this.enemySecretCount >= 1)
            {
                int minionCount = this.ownMinions.Count -1; //played minion is allready placed
                foreach (SecretItem si in this.enemySecretList.ToArray())
                {
                    if (si.canBe_snipe)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_609).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        doDmgTriggers();
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_snipe = false;
                        }
                    }

                    if (si.canBe_Trial && minionCount >= 3)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_027).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        doDmgTriggers();
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_Trial = false;
                        }
                    }

                    if (si.canBe_mirrorentity)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_294).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_mirrorentity = false;
                        }

                    }

                    if (si.canBe_repentance)
                    {
                        //triggered++;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_379).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_repentance = false;
                        }
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }

        public int secretTrigger_SpellIsPlayed(Minion target, bool isSpell)
        {
            int triggered = 0;
            if (this.isOwnTurn && isSpell && this.enemySecretCount >= 1) //actual secrets need a spell played!
            {
                foreach (SecretItem si in this.enemySecretList)
                {

                    if (si.canBe_counterspell)
                    {
                        triggered++;
                        // dont use spell!
                        si.usedTrigger_SpellIsPlayed(false);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_counterspell = false;
                        }

                        if (turnCounter == 0)
                        {
                            this.evaluatePenality -= triggered * 50;
                        }
                        return -2;//spellbender will NEVER trigger
                    }
                }



                foreach (SecretItem si in this.enemySecretList)
                {

                    if (si.canBe_spellbender && target != null && !target.isHero)
                    {
                        triggered++;
                        int retval = 0;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.tt_010).sim_card.onSecretPlay(this, false, null, target, out retval);
                        si.usedTrigger_SpellIsPlayed(true);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_spellbender = false;
                        }

                        if (turnCounter == 0)
                        {
                            this.evaluatePenality -= triggered * 50;
                        }
                        return retval;// the new target
                    }




                }

            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

            return 0;

        }

        public void secretTrigger_MinionDied(bool own)
        {
            int triggered = 0;

            if (this.isOwnTurn && !own && this.enemySecretCount >= 1)
            {
                List<SecretItem> templist = new List<SecretItem>(this.enemySecretList);
                foreach (SecretItem si in templist)
                {
                    if (si.canBe_duplicate)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_018).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_duplicate = false;
                        }
                    }

                    if (si.canBe_redemption)
                    {
                        //triggered++;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_136).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_redemption = false;
                        }
                    }

                    if (si.canBe_effigy)
                    {
                        //triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_002).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_effigy = false;
                        }
                    }

                    if (si.canBe_avenge)
                    {
                        //triggered++;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_020).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_avenge = false;
                        }
                    }


                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }



        public void doDeathrattles(List<Minion> deathrattles)
        {
            //todo sort them from oldest to newest (first played, first deathrattle)
            //https://www.youtube.com/watch?v=2WrbqsOSbhc
            foreach (Minion m in deathrattles)
            {
                if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                for (int i = 0; i < m.souloftheforest; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own);
                }

                for (int i = 0; i < m.ancestralspirit; i++)
                {
                    CardDB.Card kid = m.handcard.card;
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own);
                }

                for (int i = 0; i < m.explorersHat; i++)
                {
                    this.drawACard(CardDB.cardIDEnum.LOE_105, m.own, true);
                }

                //baron rivendare ??
                if ((m.own && this.ownBaronRivendare >= 1) || (!m.own && this.enemyBaronRivendare >= 1))
                {
                    if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                    for (int i = 0; i < m.souloftheforest; i++)
                    {
                        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                        int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                        callKid(kid, pos, m.own);
                    }

                    for (int i = 0; i < m.ancestralspirit; i++)
                    {
                        CardDB.Card kid = m.handcard.card;
                        int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                        callKid(kid, pos, m.own);
                    }

                    for (int i = 0; i < m.explorersHat; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.LOE_105, m.own, true);
                    }

                }
            }


        }


        public void updateBoards()
        {


            if (!this.tempTrigger.ownMinionsChanged && !this.tempTrigger.enemyMininsChanged) return;
            List<Minion> deathrattles = new List<Minion>();

            bool minionOwnReviving = false;
            bool minionEnemyReviving = false;

            if (this.tempTrigger.ownMinionsChanged)
            {
                this.tempTrigger.ownMinionsChanged = false;
                List<Minion> temp = new List<Minion>();
                int i = 1;
                foreach (Minion m in this.ownMinions)
                {
                    //delete adjacent buffs
                    this.minionGetAdjacentBuff(m, -m.AdjacentAngr, 0);
                    m.cantBeTargetedBySpellsOrHeroPowers = false;
                    if ((m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.spectralknight || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.arcanenullifierx21) && !m.silenced)
                    {
                        m.cantBeTargetedBySpellsOrHeroPowers = true;
                    }

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        if (this.revivingOwnMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingOwnMinion = m.handcard.card.cardIDenum;
                            minionOwnReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.souloftheforest >= 1 || m.explorersHat >= 1)
                        {
                            deathrattles.Add(m);
                        }
                        // end aura of minion m
                        m.endAura(this);

                        /*if (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem || m.ancestralspirit>=1)
                        {
                            this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
                        }*/

                    }
                    else
                    {
                        m.zonepos = i;
                        temp.Add(m);
                        i++;
                    }

                }
                this.ownMinions = temp;
                this.updateAdjacentBuffs(true);
            }

            if (this.tempTrigger.enemyMininsChanged)
            {
                this.tempTrigger.enemyMininsChanged = false;
                List<Minion> temp = new List<Minion>();
                int i = 1;
                foreach (Minion m in this.enemyMinions)
                {
                    //delete adjacent buffs
                    this.minionGetAdjacentBuff(m, -m.AdjacentAngr, 0);
                    m.cantBeTargetedBySpellsOrHeroPowers = false;
                    if ((m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.spectralknight || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.arcanenullifierx21) && !m.silenced)
                    {
                        m.cantBeTargetedBySpellsOrHeroPowers = true;
                    }

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        if (this.revivingEnemyMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingEnemyMinion = m.handcard.card.cardIDenum;
                            minionEnemyReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.souloftheforest >= 1 || m.explorersHat>=1)
                        {
                            deathrattles.Add(m);
                        }

                        m.endAura(this);

                        if ((!m.silenced && (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem)) || m.ancestralspirit >= 1)
                        {
                            if (Ai.Instance.botBase != null) this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
                        }
                    }
                    else
                    {
                        m.zonepos = i;
                        temp.Add(m);
                        i++;
                    }

                }
                this.enemyMinions = temp;
                this.updateAdjacentBuffs(false);
            }


            if (deathrattles.Count >= 1) this.doDeathrattles(deathrattles);

            if (minionOwnReviving)
            {
                this.secretTrigger_MinionDied(true);
                this.revivingOwnMinion = CardDB.cardIDEnum.None;
            }

            if (minionEnemyReviving)
            {
                this.secretTrigger_MinionDied(false);
                this.revivingEnemyMinion = CardDB.cardIDEnum.None;
            }
            //update buffs

        }

        public void minionGetOrEraseAllAreaBuffs(Minion m, bool get)
        {
            if (m.isHero) return;
            int angr = 0;
            int vert = 0;

            if (m.handcard.card.race == TAG_RACE.MURLOC)
            {
                angr += 2 * anzMurlocWarleader + anzGrimscaleOracle;
                vert += anzMurlocWarleader;

            }

            if (!m.silenced) // if they are not silenced, these minions will give a buff, but cant buff themselfes
            {
                if (m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.leokk || m.name == CardDB.cardName.timberwolf) angr--;
                if (m.name == CardDB.cardName.stormwindchampion || m.name == CardDB.cardName.southseacaptain)
                {
                    angr--;
                    vert--;
                }
                if (m.name == CardDB.cardName.murlocwarleader)
                {
                    angr -= 2;
                    vert--;
                }
                if (m.name == CardDB.cardName.grimscaleoracle)
                {
                    angr--;
                }
            }


            if (m.own)
            {
                // todo charge:  m.charge -= anzOwnTundrarhino;
                if (get) m.charge += anzOwnTundrarhino;
                else m.charge -= anzOwnTundrarhino;
                angr += anzOwnRaidleader;
                angr += anzOwnStormwindChamps;
                vert += anzOwnStormwindChamps;
                if (m.handcard.card.race == TAG_RACE.PET)
                {
                    angr += anzOwnTimberWolfs;
                }
                if (m.handcard.card.race == TAG_RACE.PIRATE)
                {
                    angr += anzOwnSouthseacaptain;
                    vert += anzOwnSouthseacaptain;

                }
                if (m.handcard.card.race == TAG_RACE.DEMON)
                {
                    angr += anzOwnMalGanis *2;
                    vert += anzOwnMalGanis * 2;

                }

                if (m.charge >= 1)
                {
                    angr += this.anzOwnWarsongCommanders;
                }

                if (m.name == CardDB.cardName.silverhandrecruit)
                {
                    angr += anzOwnWarhorseTrainer;
                }

            }
            else
            {
                if (get) m.charge += anzEnemyTundrarhino;
                else m.charge -= anzEnemyTundrarhino;
                angr += anzEnemyRaidleader;
                angr += anzEnemyStormwindChamps;
                vert += anzEnemyStormwindChamps;

                if (m.handcard.card.race == TAG_RACE.PET)
                {
                    angr += anzEnemyTimberWolfs;
                }
                if (m.handcard.card.race == TAG_RACE.PIRATE)
                {
                    angr += anzEnemySouthseacaptain;
                    vert += anzEnemySouthseacaptain;
                }
                if (m.handcard.card.race == TAG_RACE.DEMON)
                {
                    angr += anzEnemyMalGanis * 2;
                    vert += anzEnemyMalGanis * 2;

                }

                if (m.charge >= 1)
                {
                    angr += this.anzEnemyWarsongCommanders;
                }

                if (m.name == CardDB.cardName.silverhandrecruit)
                {
                    angr += anzEnemyWarhorseTrainer;
                }
            }

            if (get)
            {
                this.minionGetBuffed(m, angr, vert);
            }
            else
            {
                this.minionGetBuffed(m, -angr, -vert);
            }

        }

        public void updateAdjacentBuffs(bool own)
        {
            //only call this after update board
            if (own)
            {
                int anz = this.ownMinions.Count;
                for (int i = 0; i < anz; i++)
                {
                    Minion m = this.ownMinions[i];
                    if (!m.silenced)
                    {
                        if (m.name == CardDB.cardName.direwolfalpha)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.ownMinions[i - 1], 1, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.ownMinions[i + 1], 1, 0);
                        }

                        if (m.name == CardDB.cardName.flametonguetotem)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.ownMinions[i - 1], 2, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.ownMinions[i + 1], 2, 0);
                        }

                        if (m.name == CardDB.cardName.weespellstopper)
                        {
                            if (i > 0) this.ownMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            if (i < anz - 1) this.ownMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        }
                    }
                }
            }
            else
            {
                int anz = this.enemyMinions.Count;
                for (int i = 0; i < anz; i++)
                {
                    Minion m = this.enemyMinions[i];
                    if (!m.silenced)
                    {
                        if (m.name == CardDB.cardName.direwolfalpha)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.enemyMinions[i - 1], 1, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.enemyMinions[i + 1], 1, 0);
                        }

                        if (m.name == CardDB.cardName.flametonguetotem)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.enemyMinions[i - 1], 2, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.enemyMinions[i + 1], 2, 0);
                        }

                        if (m.name == CardDB.cardName.weespellstopper)
                        {
                            if (i > 0) this.enemyMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            if (i < anz - 1) this.enemyMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        }
                    }
                }
            }
        }

        public Minion createNewMinion(Handmanager.Handcard hc, int zonepos, bool own)
        {
            Minion m = new Minion();
            Handmanager.Handcard handc = new Handmanager.Handcard(hc);
            //Handmanager.Handcard handc = hc; // new Handcard(hc)?
            m.handcard = handc;
            m.own = own;
            m.isHero = false;
            m.entitiyID = hc.entity;
            m.Angr = hc.card.Attack + hc.addattack;
            m.Hp = hc.card.Health + hc.addHp;

            hc.addattack = 0;
            hc.addHp = 0;

            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.zonepos = zonepos;
            m.windfury = hc.card.windfury;
            m.taunt = hc.card.tank;
            m.charge = (hc.card.Charge) ? 1 : 0;
            m.divineshild = hc.card.Shield;
            m.poisonous = hc.card.poisionous;
            m.stealth = hc.card.Stealth;
            m.spellpower = 0; //we set this value in onAuraStarts!

            m.updateReadyness(this);

            if (m.name == CardDB.cardName.lightspawn)
            {
                m.Angr = m.Hp;
            }


            //trigger on summon effect!
            this.triggerAMinionIsSummoned(m);
            //activate onAura effect
            m.handcard.card.sim_card.onAuraStarts(this, m);
            //buffs minion
            this.minionGetOrEraseAllAreaBuffs(m, true);
            return m;
        }

        public void placeAmobSomewhere(Handmanager.Handcard hc, Minion target, int choice, int zonepos)
        {
            int mobplace = zonepos;

            //create the new minion + trigger Summon effects + buffs it
            Minion m = createNewMinion(hc, mobplace, true);


            //trigger the battlecry!
            m.handcard.card.sim_card.getBattlecryEffect(this, m, target, choice);
            if (m.own)
            {
                if (this.anzOwnBranns >= 1)
                {
                    m.handcard.card.sim_card.getBattlecryEffect(this, m, target, choice);
                }
            }
            else
            {
                if (this.anzEnemyBranns >= 1)
                {
                    m.handcard.card.sim_card.getBattlecryEffect(this, m, target, choice);
                }
            }

            

            //add minion to list + do triggers + do secret trigger +  minion was played trigger
            addMinionToBattlefield(m);

            secretTrigger_MinionIsPlayed(m);


            if (logging) Helpfunctions.Instance.logg("added " + m.handcard.card.name);
        }

        public void addMinionToBattlefield(Minion m, bool isSummon = true)
        {
            List<Minion> temp = (m.own) ? this.ownMinions : this.enemyMinions;
            if (temp.Count >= m.zonepos && m.zonepos >= 1)
            {
                temp.Insert(m.zonepos - 1, m);
            }
            else
            {
                temp.Add(m);
            }
            if (m.own) this.tempTrigger.ownMinionsChanged = true;
            else this.tempTrigger.enemyMininsChanged = true;
            doDmgTriggers();


            //minion was played secrets? trigger here---- (+ do triggers)


            //trigger a minion was summoned
            triggerAMinionWasSummoned(m);
            doDmgTriggers();

        }

        public void equipWeapon(CardDB.Card c, bool own)
        {
            Minion hero = (own) ? this.ownHero : this.enemyHero;
            if (own)
            {
                if (this.ownWeaponDurability >= 1)
                {
                    this.lostWeaponDamage += this.ownWeaponDurability * this.ownWeaponAttack;
                    this.lowerWeaponDurability(1000, true);
                    hero.Angr -= this.ownWeaponAttack;
                }
                this.ownWeaponAttack = c.Attack + this.anzOwnBuccaneer;
                this.ownWeaponDurability = c.Durability;
                this.ownWeaponName = c.name;
            }
            else
            {
                if (this.enemyWeaponDurability >= 1)
                {
                    hero.Angr -= this.enemyWeaponAttack;
                }
                this.enemyWeaponAttack = c.Attack + this.anzEnemyBuccaneer;
                this.enemyWeaponDurability = c.Durability;
                this.enemyWeaponName = c.name;
            }



            hero.Angr += c.Attack;

            hero.windfury = (c.name == CardDB.cardName.doomhammer);

            hero.updateReadyness();

            hero.immuneWhileAttacking = (c.name == CardDB.cardName.gladiatorslongbow);

            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.playedThisTurn && m.name == CardDB.cardName.southseadeckhand)
                {
                    minionGetCharge(m);
                }
            }

        }


        public void callKid(CardDB.Card c, int zonepos, bool own, bool spawnKid = false, bool oneMoreIsAllowed = false)
        {
            //spawnKid = true if its a minion spawned with another one (battlecry)
            int allowed = 7;
            allowed += (oneMoreIsAllowed) ? 1 : 0;
            allowed -= (spawnKid) ? 1 : 0;

            if (own)
            {
                if (this.ownMinions.Count >= allowed)
                {
                    if(spawnKid) this.evaluatePenality += 20;
                    return;
                }
            }
            else
            {
                if (this.enemyMinions.Count >= allowed)
                {
                    if (spawnKid) this.evaluatePenality -= 20;
                    return;
                }
            }
            //int mobplace = zonepos + 1;//todo check this?
            int mobplace = (spawnKid ? zonepos : zonepos + 1);
            //create minion (+triggers)
            Handmanager.Handcard hc = new Handmanager.Handcard(c) { entity = this.getNextEntity() };
            Minion m = createNewMinion(hc, mobplace, own);
            //put it on battle field (+triggers)
            addMinionToBattlefield(m);

        }



        public void minionGetSilenced(Minion m)
        {
            //minion cant die due to silencing!
            m.becomeSilence(this);

        }

        public void allMinionsGetSilenced(bool own)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                m.becomeSilence(this);
            }
        }

        public void drawACard(CardDB.cardIDEnum ss, bool own, bool no_pen = false, bool reduceManaToZero = false)
        {
            CardDB.cardIDEnum s = ss;

            // cant hold more than 10 cards
            int draw = 1;//number of card drawn!
            if (!no_pen)
            {
                List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
                foreach (Minion m in temp)
                {
                    if (m.name == CardDB.cardName.chromaggus && !m.silenced) draw++;
                }
            }
            int oldenemyanz = this.enemyAnzCards;

            if (own)
            {
                oldenemyanz = this.owncards.Count;

                if (s == CardDB.cardIDEnum.None && !no_pen) // draw a card from deck :D
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.ownHero.getDamageOrHeal(this.ownHeroFatigue, this, false, true);
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            this.evaluatePenality += 15 * draw;
                            //return;
                        }
                        else
                        {
                            this.owncarddraw += draw;
                        }
                    }

                }
                else
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 5;
                        //return;
                    }
                    else
                    {
                        this.owncarddraw++;
                    }

                }


            }
            else
            {
                
                if (s == CardDB.cardIDEnum.None && !no_pen) // draw a card from deck :D
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.enemyHero.getDamageOrHeal(this.enemyHeroFatigue, this, false, true);
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards >= 10)
                        {
                            this.evaluatePenality -= 50;
                            //return;
                        }
                        else
                        {
                            this.enemycarddraw += draw;
                            this.enemyAnzCards += draw;
                        }
                    }

                }
                else
                {
                    if (this.enemyAnzCards >= 10)
                    {
                        this.evaluatePenality -= 50;
                        //return;
                    }
                    else
                    {
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                    }

                }
                //if (this.enemyAnzCards != oldenemyanz) this.triggerCardsChanged(false);
                //return;
            }

            if (this.isServer)
            {
                //we are a server, we know what we draw! :D

                for (int i = 0; i < draw; i++)
                {

                    if (own)
                    {

                        if (s == CardDB.cardIDEnum.None && !no_pen) // draw a card random card from deck :D
                        {
                            if (i == 0)
                            {
                                drawFirstCardFromDeck(own, reduceManaToZero);
                            }
                            else
                            {
                                drawFirstCardFromDeck(own);
                            }
                        }
                        else
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                            int manac = Math.Max(0, c.cost - this.anzownShadowfiends);
                            if (i == 0 && reduceManaToZero) manac = 0;
                            Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = manac, entity = this.getNextEntity() };
                            this.owncards.Add(hc);
                        }

                    }
                    else
                    {
                        //ENEMY DRAWS A CARD
                        if (s == CardDB.cardIDEnum.None && !no_pen) // draw a card random card from deck :D
                        {
                            if (i == 0)
                            {
                                drawFirstCardFromDeck(own, reduceManaToZero);
                            }
                            else 
                            {
                                drawFirstCardFromDeck(own);
                            }
                           
                        }
                        else
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                            int manac = Math.Max(0, c.cost - this.anzEnemyShadowfiends);
                            Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.EnemyCards.Count + 1, manacost = manac, entity = this.getNextEntity() };
                            this.EnemyCards.Add(hc);
                        }
                    }
                }


            }
            else
            {
                //simulated draw:
                if (own)
                {
                    if (s == CardDB.cardIDEnum.None)
                    {
                        CardDB.Card plchldr =  CardDB.Instance.unknownCard;
                       
                        for (int i = 0; i < draw; i++)
                        {
                            Handmanager.Handcard hc = new Handmanager.Handcard { card = plchldr, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                            if (i == 0 && reduceManaToZero) hc.manacost = 0;
                            this.owncards.Add(hc);
                        }
                    }
                    else
                    {
                        CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                        int manac = Math.Max(0, c.cost - this.anzownShadowfiends);
                        Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = manac, entity = this.getNextEntity() };
                        this.owncards.Add(hc);
                    }
                }
            }

            if (own)
            {
                if (this.owncards.Count != oldenemyanz) this.triggerCardsChanged(true);
            }
            else
            {
                if (this.enemyAnzCards != oldenemyanz) this.triggerCardsChanged(false);
            }

        }

        private void drawFirstCardFromDeck(bool own, bool reducemana=false)
        {
            List<Handmanager.Handcard> tempdeck = this.enemyDeck;
            List<Handmanager.Handcard> temphand = this.EnemyCards;
            //List<Handmanager.Handcard> tempgrave = this.Enemygrave;
            if (own)
            {
                tempdeck = this.myDeck;
                temphand = this.owncards;
            }

            if (tempdeck.Count >= 1) 
            {
                Handmanager.Handcard hc = tempdeck[0];
                int manac =  Math.Max(0, hc.card.cost - ((own)?this.anzownShadowfiends:this.anzEnemyShadowfiends));
                if (reducemana) manac = 0;
                tempdeck.RemoveAt(0);
                if (temphand.Count <= 9)
                {
                    hc.position = temphand.Count + 1;
                    hc.manacost = manac;
                    temphand.Add(hc);
                }

            }


        }

        public void removeCard(Handmanager.Handcard hcc)
        {
            //todo test this and remove toarray()
            //this.owncards.RemoveAll(x => x.entity == hcc.entity);

            int i = 1;
            foreach (Handmanager.Handcard hc in this.owncards.ToArray())
            {
                if (hc.entity == hcc.entity)
                {
                    this.owncards.Remove(hc);
                    continue;
                }
                this.owncards[i - 1].position = i;
                //hc.position = i;
                i++;
            }

        }

        


        // some helpfunctions 


        public void attackEnemyHeroWithoutKill(int dmg)
        {
            this.enemyHero.cantLowerHPbelowONE = true;
            this.minionGetDamageOrHeal(this.enemyHero, dmg);
            this.enemyHero.cantLowerHPbelowONE = false;
        }

        public void minionGetDestroyed(Minion m)
        {
            if (m.Hp > 0)
            {
                m.Hp = 0;
                m.minionDied(this);
            }

        }

        public void allMinionsGetDestroyed()
        {
            foreach (Minion m in this.ownMinions)
            {
                minionGetDestroyed(m);
            }
            foreach (Minion m in this.enemyMinions)
            {
                minionGetDestroyed(m);
            }
        }


        public void minionGetArmor(Minion m, int armor)
        {
            m.armor += armor;
            this.triggerAHeroGotArmor(m.own);
        }

        public void minionReturnToHand(Minion m, bool own, int manachange)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;

            m.endAura(this);

            temp.Remove(m);

            if (own)
            {
                CardDB.Card c = m.handcard.card;
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, entity = m.entitiyID, manacost = c.cost + manachange };
                if (this.owncards.Count < 10)
                {
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
                else
                {
                    this.drawACard(CardDB.cardIDEnum.None, true);
                }
                this.tempTrigger.ownMinionsChanged = true;
            }
            else
            {
                if (this.isServer)
                {
                    CardDB.Card c = m.handcard.card;
                    Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, entity = m.entitiyID, manacost = c.cost + manachange };
                    if (this.EnemyCards.Count < 10)
                    {
                        this.EnemyCards.Add(hc);
                        this.triggerCardsChanged(false);
                    }
                    else
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                    this.tempTrigger.enemyMininsChanged = true;
                    return;
                }

                this.drawACard(CardDB.cardIDEnum.None, false);
                this.tempTrigger.enemyMininsChanged = true;
            }

        }

        public void minionTransform(Minion m, CardDB.Card c)
        {
            m.endAura(this);

            Handmanager.Handcard hc = new Handmanager.Handcard(c){ entity = this.getNextEntity() }; // m.entityID;
            int ancestral = m.ancestralspirit;
            if (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem || ancestral >= 1)
            {
                if (Ai.Instance.botBase != null) this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
            }

            //necessary???
            /*Minion tranform = createNewMinion(hc, m.zonepos, m.own);
            Minion temp = new Minion();
            temp.setMinionTominion(m);
            m.setMinionTominion(tranform);*/

            m.setMinionTominion(createNewMinion(hc, m.zonepos, m.own));

            m.handcard.card.sim_card.onAuraStarts(this, m);
            this.minionGetOrEraseAllAreaBuffs(m, true);

            if (m.own)
            {
                this.tempTrigger.ownMinionsChanged = true;
            }
            else
            {
                this.tempTrigger.enemyMininsChanged = true;
            }

            if (logging) Helpfunctions.Instance.logg("minion got sheep" + m.name + " " + m.Angr);
        }

        public void minionGetControlled(Minion m, bool newOwner, bool canAttack)
        {
            List<Minion> newOwnerList = (newOwner) ? this.ownMinions : this.enemyMinions;
            List<Minion> oldOwnerList = (newOwner) ? this.enemyMinions : this.ownMinions;



            if (newOwnerList.Count >= 7) return;

            this.tempTrigger.ownMinionsChanged = true;
            this.tempTrigger.enemyMininsChanged = true;

            //end buffs/aura
            m.endAura(this);

            this.minionGetOrEraseAllAreaBuffs(m, false);

            //remove minion from list
            oldOwnerList.Remove(m);

            //change site (and minion is played in this turn)
            m.playedThisTurn = true;
            m.own = !m.own;

            // add minion to new list + new buffs
            newOwnerList.Add(m);
            m.handcard.card.sim_card.onAuraStarts(this, m);
            this.minionGetOrEraseAllAreaBuffs(m, true);

            if (m.charge >= 1 || canAttack) // minion can attack if its shadowmadnessed (canAttack = true) or it has charge
            {
                this.minionGetCharge(m);
            }
            m.updateReadyness(this);

        }



        public void minionGetWindfurry(Minion m)
        {
            if (m.windfury) return;
            m.windfury = true;
            m.updateReadyness(this);
        }

        public void minionGetCharge(Minion m)
        {
            this.minionGetOrEraseAllAreaBuffs(m, false);//because of warsong commander
            m.charge++;
            m.updateReadyness(this);
            this.minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionLostCharge(Minion m)
        {
            this.minionGetOrEraseAllAreaBuffs(m, false);//because of warsong commander
            m.charge--;
            m.updateReadyness(this);
            this.minionGetOrEraseAllAreaBuffs(m, true);
        }



        public void minionGetTempBuff(Minion m, int tempAttack, int tempHp)
        {
            if (!m.silenced && m.name == CardDB.cardName.lightspawn) return;
            if (tempAttack < 0 && -tempAttack > m.Angr)
            {
                tempAttack = -m.Angr;
            }
            m.tempAttack += tempAttack;
            m.Angr += tempAttack;
        }

        public void minionGetAdjacentBuff(Minion m, int angr, int vert)
        {
            if (!m.silenced && m.name == CardDB.cardName.lightspawn) return;
            m.Angr += angr;
            m.AdjacentAngr += angr;
        }

        public void minionGetBuffed(Minion m, int attackbuff, int hpbuff)
        {
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


            m.wounded = (m.maxHp != m.Hp);

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }

        }

        public void minionSetAngrToOne(Minion m)
        {
            if (!m.silenced && m.name == CardDB.cardName.lightspawn) return;
            m.Angr = 1;
            m.tempAttack = 0;
            this.minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionSetLifetoOne(Minion m)
        {
            minionGetOrEraseAllAreaBuffs(m, false);
            m.Hp = 1;
            m.maxHp = 1;
            if (m.wounded && !m.silenced) m.handcard.card.sim_card.onEnrageStop(this, m);
            m.wounded = false;
            minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionSetAngrToHP(Minion m)
        {
            m.Angr = m.Hp;
            m.tempAttack = 0;
            this.minionGetOrEraseAllAreaBuffs(m, true);

        }

        public void minionSwapAngrAndHP(Minion m)
        {
            this.minionGetOrEraseAllAreaBuffs(m, false);
            bool woundedbef = m.wounded;
            int temp = m.Angr;
            m.Angr = m.Hp;
            m.Hp = temp;
            m.maxHp = temp;
            m.wounded = false;
            if (woundedbef) m.handcard.card.sim_card.onEnrageStop(this, m);
            if (m.Hp <= 0)
            {
                if (m.own) this.tempTrigger.ownMinionsDied++;
                else this.tempTrigger.enemyMinionsDied++;
            }

            this.minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionGetDamageOrHeal(Minion m, int dmgOrHeal, bool dontDmgLoss = false)
        {
            m.getDamageOrHeal(dmgOrHeal, this, false, dontDmgLoss);
        }



        public void allMinionOfASideGetDamage(bool own, int damages, bool frozen = false)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                if (frozen) m.frozen = true;
                minionGetDamageOrHeal(m, damages, true);
            }
        }

        public void allCharsOfASideGetDamage(bool own, int damages)
        {
            //ALL CHARS get same dmg
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                minionGetDamageOrHeal(m, damages, true);
            }

            this.minionGetDamageOrHeal(own ? this.ownHero : this.enemyHero, damages);
        }

        public void allCharsGetDamage(int damages)
        {
            foreach (Minion m in this.ownMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
            minionGetDamageOrHeal(this.ownHero, damages);
            minionGetDamageOrHeal(this.enemyHero, damages);
        }

        public void allMinionsGetDamage(int damages)
        {
            foreach (Minion m in this.ownMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
        }

        public enum searchmode
        {
            searchLowestHP,
            searchHighestHP,
            searchLowestAttack, 
            searchHighestAttack,
        }

        public Minion searchRandomMinion(List<Minion> minions, searchmode mode)
        {
            //get = 0 -> get lowest hp
            //get = 1 -> get highest hp
            //get = 2 -> get lowest attack
            //get = 3 -> get highest attack
            int get = (int)mode;

            if (minions.Count == 0) return null;
            Minion ret = minions[0];
            int value = 0;
            switch (get)
            {
                case 1:
                        value = 0;
                    break;
                case 2:
                        value = 2048;
                    break;
                case 3:
                        value = 0;
                    break;
                default:
                        value = 2048;
                    break;
            }

            foreach (Minion m in minions)
            {
                if (m.Hp <= 0) continue;

                switch (get)
                {
                    case 1: 
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                        }
                        break;
                    case 2:
                        if (m.Angr < value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        break;
                    case 3:
                        if (m.Angr > value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        break;
                    default: 
                        if (m.Hp < value)
                        {
                            ret = m;
                            value = m.Hp;
                        }
                        break;
                }
            }
            //if (ret.Hp <= 0) return null;
            return ret;
        }

        
        public void debugMinions()
        {
            Helpfunctions.Instance.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp, maxhp: " + m.name + ", " + m.Angr + ", " + m.Hp + ", " + m.maxHp);
            }

            Helpfunctions.Instance.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }
        }

        public void printBoard(int boardnumber = -1)
        {
            float copy = value;
            if (boardnumber >= 0)
            {
                Helpfunctions.Instance.logg("index: "+boardnumber + " board: " + value + " ++++++++++++++++++++++");
            }
            else
            {
                Helpfunctions.Instance.logg("board: " + value + " ++++++++++++++++++++++");
            }
            Helpfunctions.Instance.logg("pen " + this.evaluatePenality);
            if (this.selectedChoice >= 1) Helpfunctions.Instance.logg("tracking " + this.selectedChoice);
            Helpfunctions.Instance.logg("mana " + this.mana + "/" + this.ownMaxMana + " turnEndMana " + this.manaTurnEnd);
            Helpfunctions.Instance.logg("cardsplayed: " + this.cardsPlayedThisTurn + " handsize: " + this.owncards.Count + " eh " + this.enemyAnzCards + " " + this.enemycarddraw);

            Helpfunctions.Instance.logg("ownhero: ");
            Helpfunctions.Instance.logg("ownherohp: " + this.ownHero.Hp + " + " + this.ownHero.armor);
            Helpfunctions.Instance.logg("ownheroattac: " + this.ownHero.Angr);
            Helpfunctions.Instance.logg("ownheroweapon: " + this.ownWeaponAttack + " " + this.ownWeaponDurability + " " + this.ownWeaponName);
            Helpfunctions.Instance.logg("ownherostatus: frozen" + this.ownHero.frozen + " ");
            Helpfunctions.Instance.logg("enemyherohp: " + this.enemyHero.Hp + " + " + this.enemyHero.armor + ((this.enemyHero.immune) ? " immune" : ""));

            if (this.enemySecretCount >= 1) Helpfunctions.Instance.logg("enemySecrets: " + this.enemySecretCount + " " + Probabilitymaker.Instance.getEnemySecretData(this.enemySecretList));
            /*foreach (Action a in this.playactions)
            {
                a.print();
            }*/
            Helpfunctions.Instance.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                String attrib = "";
                if (m.taunt) attrib += " tnt";
                if (m.Ready) attrib += " Ready";
                if (m.stealth) attrib += " stlth";
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp + " " + m.entitiyID + attrib);
            }

            Helpfunctions.Instance.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                String attrib = "";
                if (m.taunt) attrib += " tnt";
                if (m.stealth) attrib += " stlth";
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp + " " + m.entitiyID + attrib);
            }


            Helpfunctions.Instance.logg("");
        }

        public void printBoardDebug()
        {
            Helpfunctions.Instance.logg("hero " + this.ownHero.Hp + " " + this.ownHero.armor + " " + this.ownHero.entitiyID);
            Helpfunctions.Instance.logg("ehero " + this.enemyHero.Hp + " " + this.enemyHero.armor + " " + this.enemyHero.entitiyID);
            foreach (Minion m in ownMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entitiyID);
            }
            Helpfunctions.Instance.logg("-");
            foreach (Minion m in enemyMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entitiyID);
            }
            Helpfunctions.Instance.logg("-");
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                Helpfunctions.Instance.logg(hc.position + " " + hc.card.name + " " + hc.entity);
            }
        }

        public Action getNextAction()
        {
            if (this.playactions.Count >= 1) return this.playactions[0];
            return null;
        }

        public void printActions(bool toBuffer = false)
        {
            foreach (Action a in this.playactions)
            {
                a.print(toBuffer);
                Helpfunctions.Instance.logg("");
            }
        }

        public void printActionforDummies(Action a)
        {
            if (a.actionType == actionEnum.playcard)
            {
                Helpfunctions.Instance.ErrorLog("play " + a.card.card.name);
                if (a.druidchoice >= 1)
                {
                    string choose = (a.druidchoice == 1) ? "left card" : "right card";
                    Helpfunctions.Instance.ErrorLog("choose the " + choose);
                }
                if (a.place >= 1)
                {
                    Helpfunctions.Instance.ErrorLog("on position " + a.place);
                }
                if (a.target != null)
                {
                    if (!a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("and target to the enemy " + ename);
                    }

                    if (a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("and target to your own" + ename);
                    }

                    if (a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("and target your own hero");
                    }

                    if (!a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("and target to the enemy hero");
                    }
                }

            }
            if (a.actionType == actionEnum.attackWithMinion)
            {
                string name = "" + a.own.name;
                if (a.target.isHero)
                {
                    Helpfunctions.Instance.ErrorLog("attack with: " + name + " the enemy hero");
                }
                else
                {
                    string ename = "" + a.target.name;
                    Helpfunctions.Instance.ErrorLog("attack with: " + name + " the enemy: " + ename);
                }

            }

            if (a.actionType == actionEnum.attackWithHero)
            {
                if (a.target.isHero)
                {
                    Helpfunctions.Instance.ErrorLog("attack with your hero the enemy hero!");
                }
                else
                {
                    string ename = "" + a.target.name;
                    Helpfunctions.Instance.ErrorLog("attack with the hero, and choose the enemy: " + ename);
                }
            }
            if (a.actionType == actionEnum.useHeroPower)
            {
                Helpfunctions.Instance.ErrorLog("use your Heropower ");
                if (a.target != null)
                {
                    if (!a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("on enemy: " + ename);
                    }

                    if (a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("on your own: " + ename);
                    }

                    if (a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("on your own hero");
                    }

                    if (!a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("on your the enemy hero");
                    }

                }
            }
            Helpfunctions.Instance.ErrorLog("");

        }

        public string getCompleteBoardForSimulating(String settings, String version, String time)
        {
            //returns same string as: 
            /*
            string dtimes = DateTime.Now.ToString("HH:mm:ss:ffff");
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("start calculations, current time: " + dtimes + " V" + "115.55" + " " + p.settings);
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("mana " + p.curMana + "/" + p.maxMana);
            hpf.writeToBuffer("emana " + opponent.maxMana);
            hpf.writeToBuffer("own secretsCount: " + ownsecretcount);
            hpf.writeToBuffer("enemy secretsCount: " + enemySecretCount + " ;" + enemysecretIds);

            Hrtprozis.Instance.printHero(runEx);
            Hrtprozis.Instance.printOwnMinions(runEx);
            Hrtprozis.Instance.printEnemyMinions(runEx);
            
            Handmanager.Instance.printcards(runEx);
            
            Probabilitymaker.Instance.printTurnGraveYard(runEx);
            Probabilitymaker.Instance.printGraveyards(runEx);
            */

            string choice = Handmanager.Instance.getCardChoiceString();
            Probabilitymaker probm = Probabilitymaker.Instance;
            String data = "#######################################################################"+"\r\n";
            data += "start calculations, current time: " + time + " V" + version + " " + settings + "\r\n";
            data += "#######################################################################" + "\r\n";
            if (choice != "") data += choice + "\r\n"; 
            data +="mana " + this.mana + "/" + this.ownMaxMana+"\r\n";
            data +="emana " + this.enemyMaxMana+"\r\n";
            data +="own secretsCount: " + this.ownSecretsIDList.Count+"\r\n";
            data += "enemy secretsCount: " + this.enemySecretCount + " ;" + probm.getEnemySecretData() + "\r\n";

            //print hero:-------------------------------------------------------------------------------
            data += "player:" + "\r\n";
            
            int ownPlayerController= this.ownController;

            int ownmillhouse = (this.weHavePlayedMillhouseManastorm)? 1:0;
            int enemymillhouse = (this.enemyHavePlayedMillhouseManastorm)? 1:0;
            int ownKirinTorEffect = (this.playedmagierinderkirintor) ? 1:0;
            int ownPreparation = (this.playedPreparation) ? 1:0;

            data += this.mobsplayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.owedRecall + " " + ownPlayerController + " " + this.anzMinionsDiedThisTurn + " " + this.currentRecall + " " + this.enemyRecall + " " + this.heroPowerActivationsThisTurn +  " " +  this.lockAndLoads +"\r\n";
            data += this.ownDragonConsort + " " + this.enemyDragonConsort + " " + this.ownloatheb + " " + this.enemyloatheb + " " + ownmillhouse + " " + enemymillhouse + " " + ownKirinTorEffect + " " + ownPreparation+  " " + this.ownSaboteur + " " + this.enemySaboteur + " " +  this.anzOwnFencingCoach + "\r\n";
            data += "ownhero:" + "\r\n";
            data += Hrtprozis.heroEnumtoName(this.ownHeroName)+ " " + this.ownHero.Hp + " " + this.ownHero.maxHp + " " + this.ownHero.armor + " " + this.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + this.ownHero.entitiyID + " " + this.ownHero.Ready + " " + this.ownHero.numAttacksThisTurn + " " + this.ownHero.frozen + " " + this.ownHero.Angr + " " + this.ownHero.tempAttack+ "\r\n";
            data += "weapon: " + this.ownWeaponAttack + " " + this.ownWeaponDurability  + " " + this.ownWeaponName + "\r\n";
            data += "ability: " + this.ownAbilityReady + " " + this.ownHeroAblility.card.cardIDenum + " " +  this.own_TIMES_HERO_POWER_USED_THIS_GAME+"\r\n";
            string secs = "";
            foreach (CardDB.cardIDEnum sec in this.ownSecretsIDList)
            {
                secs += sec + " ";
            }
            data += "osecrets: " + secs+ "\r\n";
            data += "enemyhero:"+ "\r\n";
            data += Hrtprozis.heroEnumtoName(this.enemyHeroName) + " " + this.enemyHero.Hp + " " + this.enemyHero.maxHp + " " + this.enemyHero.armor + " " + this.enemyHero.frozen + " " + this.enemyHero.immune + " " + this.enemyHero.entitiyID+ "\r\n";
            data += "weapon: " + this.enemyWeaponAttack + " " + this.enemyWeaponDurability + " " + this.enemyWeaponName+ "\r\n";
            data += "ability: " + "True" + " " + this.enemyHeroAblility.card.cardIDenum+ " " + this.enemy_TIMES_HERO_POWER_USED_THIS_GAME + "\r\n";
            data += "fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " " + this.enemyHeroFatigue+ "\r\n";

            //print own Minions

            data += "OwnMinions:" + "\r\n";
            foreach (Minion m in this.ownMinions)
            {
                String mini = this.getMinionString(m);
                data += mini + "\r\n";

            }

            //print enemy Minions
            data += "EnemyMinions:" + "\r\n";
            foreach (Minion m in this.enemyMinions)
            {
                String mini = this.getMinionString(m);
                data += mini + "\r\n";

            }

            //print cards!

            data +="Own Handcards: "+ "\r\n";
            foreach (Handmanager.Handcard c in this.owncards)
            {
                if (c.isChoiceTemp) continue;  // don't print fake 'discover' card
                data +="pos " + c.position + " " + c.card.name + " " + c.getManaCost(this) + " entity " + c.entity + " " + c.card.cardIDenum + " " + c.addattack+ " " + c.addHp + "\r\n";
            }
            data += "Enemy cards: " + this.enemyAnzCards + "\r\n";

            //Probabilitymaker.Instance.printTurnGraveYard(runEx)
            data += Probabilitymaker.Instance.printTurnGraveYard(false, true); //dont need \r\n

            //Probabilitymaker.Instance.printGraveyards(runEx);
            data += Probabilitymaker.Instance.printGraveyards(false, true); //dont need \r\n

            return data;
        }

        public string getMinionString(Minion m)
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
            if (m.tempAttack != 0) mini += " tmpattck(" + m.tempAttack + ")";
            if (m.spellpower >= 1) mini += " spllpwr(" + m.spellpower + ")";

            if (m.ancestralspirit >= 1) mini += " ancstrl(" + m.ancestralspirit + ")";
            if (m.ownBlessingOfWisdom >= 1) mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
            if (m.enemyBlessingOfWisdom >= 1) mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
            if (m.souloftheforest >= 1) mini += " souloffrst(" + m.souloftheforest + ")";

            if (m.ownPowerWordGlory >= 1) mini += " ownPWG(" + m.ownPowerWordGlory + ")";
            if (m.enemyPowerWordGlory >= 1) mini += " enemyPWG(" + m.enemyPowerWordGlory + ")";

            if (m.explorersHat >= 1) mini += " explht(" + m.explorersHat + ")";


            return mini;
        }

        //can return null
        public Minion getRandomMinionFromSide_SERVER(bool own, bool includeHero)
        {
            List<Minion> temp = new List<Minion>();

            foreach(Minion m in  (own) ? this.ownMinions : this.enemyMinions)
            {
                if (m.Hp >= 1) temp.Add(m);
            }

            if (includeHero) temp.Add((own) ? this.ownHero : this.enemyHero);

            if (temp.Count == 0) return null;

            return temp[this.randomGenerator.Next(0, temp.Count)];
        }

        public Minion getRandomCharExcept_SERVER(Minion thisNot, bool includeHero)
        {
            List<Minion> temp = new List<Minion>();

            foreach (Minion m in this.ownMinions)
            {
                if (m == thisNot) continue;
                if (m.Hp >= 1) temp.Add(m);
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m == thisNot) continue;
                if (m.Hp >= 1) temp.Add(m);
            }

            if (includeHero) temp.Add(this.ownHero);
            if (includeHero) temp.Add(this.enemyHero);

            if (temp.Count == 0) return null;

            return temp[this.randomGenerator.Next(0, temp.Count)];
        }

        public Minion getRandomCharOfASideExcept_SERVER(Minion thisNot, bool own, bool includeHero)
        {
            List<Minion> temp = new List<Minion>();

            foreach (Minion m in ((own) ? this.ownMinions : this.enemyMinions))
            {
                if (m == thisNot) continue;
                if (m.Hp >= 1) temp.Add(m);
            }

            if (includeHero && own) temp.Add(this.ownHero);
            if (includeHero && !own) temp.Add(this.enemyHero);

            if (temp.Count == 0) return null;

            return temp[this.randomGenerator.Next(0, temp.Count)];
        }


        public int getRandomNumber_SERVER(int minInclude, int maxInclude)
        {
            return this.randomGenerator.Next(minInclude, maxInclude + 1);

        }

        public void discardRandomCard_SERVER(bool own)
        {
            if (!this.isServer) return;
            if (own)
            {
                if(this.owncards.Count >=1)
                {
                    int start = this.getRandomNumber_SERVER(0, this.owncards.Count-1);
                    this.owncards.RemoveRange(start, 1);
                    this.triggerCardsChanged(true);
                }
            }
            else
            {
                if (this.EnemyCards.Count >= 1)
                {
                    int start = this.getRandomNumber_SERVER(0, this.EnemyCards.Count - 1);
                    this.EnemyCards.RemoveRange(start, 1);
                    this.triggerCardsChanged(false);
                }
            }
        }

        public List<CardDB.cardIDEnum> copyRandomCardFromDeck_SERVER(bool own)
        {
            List<Handmanager.Handcard> tempdeck = (own) ? this.myDeck : this.enemyDeck ;
            List<CardDB.cardIDEnum> choosen = new List<CardDB.cardIDEnum>();
            if(tempdeck.Count == 0) return choosen;
            int r1 = this.randomGenerator.Next(0, tempdeck.Count);
            choosen.Add(tempdeck[r1].card.cardIDenum);
            if(tempdeck.Count == 1) return choosen;
            int r2 = this.randomGenerator.Next(0, tempdeck.Count - 1);
            if (r2 >= r1) r2++;
            choosen.Add(tempdeck[r2].card.cardIDenum);
            return choosen;
        }

        public CardDB.cardIDEnum getRandomSparePart_SERVER()
        {
            int random = this.getRandomNumber_SERVER(1, 7);
            if (random == 1) return CardDB.cardIDEnum.PART_001;
            if (random == 2) return CardDB.cardIDEnum.PART_002;
            if (random == 3) return CardDB.cardIDEnum.PART_003;
            if (random == 4) return CardDB.cardIDEnum.PART_004;
            if (random == 5) return CardDB.cardIDEnum.PART_005;
            if (random == 6) return CardDB.cardIDEnum.PART_006;
            return CardDB.cardIDEnum.PART_007;
        }

        public void removeCard_SERVER(Handmanager.Handcard hcc, bool own)
        {
            //todo test this and remove toarray()
            //this.owncards.RemoveAll(x => x.entity == hcc.entity);
            if (own)
            {
                int i = 1;
                foreach (Handmanager.Handcard hc in this.owncards.ToArray())
                {
                    if (hc.entity == hcc.entity)
                    {
                        this.owncards.Remove(hc);
                        continue;
                    }
                    this.owncards[i - 1].position = i;
                    //hc.position = i;
                    i++;
                }
            }
            else
            {
                int i = 1;
                foreach (Handmanager.Handcard hc in this.EnemyCards.ToArray())
                {
                    if (hc.entity == hcc.entity)
                    {
                        this.EnemyCards.Remove(hc);
                        continue;
                    }
                    this.EnemyCards[i - 1].position = i;
                    //hc.position = i;
                    i++;
                }
            }

        }

        public Minion getRandomMinionOfThatList(List<Minion> liste)
        {
            if (liste.Count == 0) return null;
            int random = this.getRandomNumber_SERVER(0, liste.Count - 1);
            return liste[random];
        }

        public void disCardACard(bool own, bool all = false)
        {
            //TODO ... (guess random effect :D)
            if (own)
            {
                if (this.owncards.Count >= 1)
                {
                    this.owncarddraw -= 1;
                    Handmanager.Handcard removedCard = this.owncards[0];
                    if (removedCard.card.cardIDenum == CardDB.cardIDEnum.AT_022)
                    {
                        removedCard.card.sim_card.onCardIsDiscarded(this, removedCard.card, true);
                    }
                    this.owncards.RemoveAt(0);
                    this.triggerACardWasDiscarded(true);
                }


            }
            else
            {
                if (this.enemyAnzCards >= 1)
                {
                    this.enemycarddraw--;
                    this.enemyAnzCards--;
                    this.triggerACardWasDiscarded(false);
                }
            }
        }


        public Minion searchRandomMinionForDamage(List<Minion> enemies, int damage, bool ownPlay, bool includeEnemyHero)
        {
            // own = true -> search for us the worst-case scenario (i.e. random target = enemy's lowest atk minion that doesn't die)
            // own = false -> search for enemy the best-case scenario (i.e. random target = our highest atk minion that can die)
            Minion targetHero = (ownPlay ? this.enemyHero : this.ownHero);
            Minion selected = (includeEnemyHero ? targetHero : null);

            if (enemies.Count == 0) return selected;
            if (includeEnemyHero && !ownPlay && damage >= this.ownHero.Hp) return this.ownHero;  // best-case for enemy: if it can kill us, it will

            List<Minion> temp = new List<Minion>(enemies);
            if (ownPlay)
                temp.Sort((a, b) => a.Angr.CompareTo(b.Angr)); // increasing Atk
            else
                temp.Sort((a, b) => -a.Angr.CompareTo(b.Angr)); // decreasing Atk

            Minion firstAlive = null;
            foreach (Minion m in temp)
            {
                if (m.Hp <= 0) continue;
                if (firstAlive == null) firstAlive = m;

                if ((ownPlay && m.Hp > damage) || (!ownPlay && m.Hp <= damage))
                    return m;
            }

            if (includeEnemyHero && ownPlay && damage < this.enemyHero.Hp - 15) return this.enemyHero;  // worst-case for us: no minions damaged

            // no minions found = all ours live or all enemies die (so just return the first one, highest/lowest atk)
            return (firstAlive == null ? targetHero : firstAlive);
        }


        public void doDmgToRandomEnemyCLIENT2(int dmg, bool targetHero, bool ownPlay)
        {
            /* //TODO
            if (!targetHero)
            {
                Minion m = this.searchRandomMinion((side) ? this.ownMinions : this.enemyMinions, Playfield.searchmode.searchHighestHP);
                if (m != null) this.minionGetDamageOrHeal(m, dmg);
            }
            else
            {
                Minion m = this.searchRandomMinion((side) ? this.ownMinions : this.enemyMinions, Playfield.searchmode.searchHighestHP);
                if (m != null)
                {
                    int hp = (side) ? this.ownHero.Hp : this.enemyHero.Hp;
                    if (m.Hp <= dmg && hp-5 > dmg)
                    {
                        this.minionGetDamageOrHeal((side) ? this.ownHero : this.enemyHero, dmg);
                    }
                    else
                    {
                        this.minionGetDamageOrHeal(m, dmg);
                    }
                }
                else
                {
                    this.minionGetDamageOrHeal((side) ? this.ownHero : this.enemyHero, dmg);
                }*/

             Minion m = this.searchRandomMinionForDamage((ownPlay ? this.enemyMinions : this.ownMinions), dmg, ownPlay, targetHero);
             if (m != null) this.minionGetDamageOrHeal(m, dmg);

            }
        
    }

   

}