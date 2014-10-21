using HREngine.API;
using HREngine.API.Actions;
using HREngine.API.Utilities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    public class Silverfish
    {
        public string versionnumber = "113.51";
        private bool singleLog = false;
        private string botbehave = "rush";
        public bool waitingForSilver = false;


        Playfield lastpf;
        Settings sttngs = Settings.Instance;

        List<Minion> ownMinions = new List<Minion>();
        List<Minion> enemyMinions = new List<Minion>();
        List<Handmanager.Handcard> handCards = new List<Handmanager.Handcard>();
        int ownPlayerController = 0;
        List<string> ownSecretList = new List<string>();
        int enemySecretCount = 0;
        List<int> enemySecretList = new List<int>();

        int currentMana = 0;
        int ownMaxMana = 0;
        int numOptionPlayedThisTurn = 0;
        int numMinionsPlayedThisTurn = 0;
        int cardsPlayedThisTurn = 0;
        int ueberladung = 0;

        int enemyMaxMana = 0;

        string ownHeroWeapon = "";
        int heroWeaponAttack = 0;
        int heroWeaponDurability = 0;

        string enemyHeroWeapon = "";
        int enemyWeaponAttack = 0;
        int enemyWeaponDurability = 0;

        string heroname = "";
        string enemyHeroname = "";

        CardDB.Card heroAbility = new CardDB.Card();
        bool ownAbilityisReady = false;
        CardDB.Card enemyAbility = new CardDB.Card();

        int anzcards = 0;
        int enemyAnzCards = 0;

        int ownHeroFatigue = 0;
        int enemyHeroFatigue = 0;
        int ownDecksize = 0;
        int enemyDecksize = 0;

        Minion ownHero;
        Minion enemyHero;

        public Silverfish(bool snglLg)
        {
            this.singleLog = snglLg;
            Helpfunctions.Instance.ErrorLog("init Silverfish");
            string path = HRSettings.Get.Session.Paths.Hearthcrawler + System.IO.Path.DirectorySeparatorChar + "UltimateLogs" + System.IO.Path.DirectorySeparatorChar;
            System.IO.Directory.CreateDirectory(path);
            sttngs.setFilePath(HRSettings.Get.Session.Paths.Hearthcrawler + System.IO.Path.DirectorySeparatorChar + "Bots" + System.IO.Path.DirectorySeparatorChar + "silver" + System.IO.Path.DirectorySeparatorChar);

            Helpfunctions.Instance.ErrorLog(path);

            if (!singleLog)
            {
                sttngs.setLoggPath(path);
            }
            else
            {
                sttngs.setLoggPath(HRSettings.Get.Session.Paths.Hearthcrawler + System.IO.Path.DirectorySeparatorChar);
                sttngs.setLoggFile("UILogg.txt");
                Helpfunctions.Instance.createNewLoggfile();
            }
            PenalityManager.Instance.setCombos();
            Mulligan m = Mulligan.Instance; // read the mulligan list
        }

        public void setnewLoggFile()
        {
            if (!singleLog)
            {
                sttngs.setLoggFile("UILogg" + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss") + ".txt");
                Helpfunctions.Instance.createNewLoggfile();
                Helpfunctions.Instance.ErrorLog("#######################################################");
                Helpfunctions.Instance.ErrorLog("fight is logged in: " + sttngs.logpath + sttngs.logfile);
                Helpfunctions.Instance.ErrorLog("#######################################################");
            }
            else
            {
                sttngs.setLoggFile("UILogg.txt");
            }
        }

        public bool updateEverything(Behavior botbase, bool runExtern = false, bool passiveWait = false)
        {
            this.updateBehaveString(botbase);

            HRPlayer ownPlayer = HRPlayer.GetLocalPlayer();
            HRPlayer enemyPlayer = HRPlayer.GetEnemyPlayer();
            ownPlayerController = ownPlayer.GetHero().GetControllerId();//ownPlayer.GetHero().GetControllerId()


            // create hero + minion data
            getHerostuff();
            getMinions();
            getHandcards();
            getDecks();

            // send ai the data:
            Hrtprozis.Instance.clearAll();
            Handmanager.Instance.clearAll();

            Hrtprozis.Instance.setOwnPlayer(ownPlayerController);
            Handmanager.Instance.setOwnPlayer(ownPlayerController);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + this.ownHero.numAttacksThisTurn;
            foreach (Minion m in this.ownMinions)
            {
                if (m.Hp >= 1) this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
            }

            Hrtprozis.Instance.updatePlayer(this.ownMaxMana, this.currentMana, this.cardsPlayedThisTurn, this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.ueberladung, ownPlayer.GetHero().GetEntityId(), enemyPlayer.GetHero().GetEntityId());
            Hrtprozis.Instance.updateSecretStuff(this.ownSecretList, this.enemySecretCount);

            Hrtprozis.Instance.updateOwnHero(this.ownHeroWeapon, this.heroWeaponAttack, this.heroWeaponDurability, this.heroname, this.heroAbility, this.ownAbilityisReady, this.ownHero);
            Hrtprozis.Instance.updateEnemyHero(this.enemyHeroWeapon, this.enemyWeaponAttack, this.enemyWeaponDurability, this.enemyHeroname, this.enemyMaxMana, this.enemyAbility, this.enemyHero);

            Hrtprozis.Instance.updateMinions(this.ownMinions, this.enemyMinions);
            Handmanager.Instance.setHandcards(this.handCards, this.anzcards, this.enemyAnzCards);

            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownHeroFatigue, this.enemyDecksize, this.enemyHeroFatigue);

            Probabilitymaker.Instance.getEnemySecretGuesses(this.enemySecretList, Hrtprozis.Instance.heroNametoEnum(this.enemyHeroname));

            //learnmode :D

            Playfield p = new Playfield();



            if (lastpf != null)
            {
                if (lastpf.isEqualf(p))
                {
                    return false;
                }

                //board changed we update secrets!
                //if(Ai.Instance.nextMoveGuess!=null) Probabilitymaker.Instance.updateSecretList(Ai.Instance.nextMoveGuess.enemySecretList);
                Probabilitymaker.Instance.updateSecretList(p, lastpf);
                lastpf = p;
            }
            else
            {
                lastpf = p;
            }

            p = new Playfield();//secrets have updated :D
            // calculate stuff
            Helpfunctions.Instance.ErrorLog("calculating stuff... " + DateTime.Now.ToString("HH:mm:ss.ffff"));
            if (runExtern)
            {
                Helpfunctions.Instance.logg("recalc-check###########");
                //p.printBoard();
                //Ai.Instance.nextMoveGuess.printBoard();
                if (p.isEqual(Ai.Instance.nextMoveGuess, true))
                {

                    printstuff(false);
                    Ai.Instance.doNextCalcedMove();

                }
                else
                {
                    printstuff(true);
                    readActionFile(passiveWait);
                }
            }
            else
            {
                printstuff(false);
                Ai.Instance.dosomethingclever(botbase);
            }

            Helpfunctions.Instance.ErrorLog("calculating ended! " + DateTime.Now.ToString("HH:mm:ss.ffff"));

            return true;
        }

        private void getHerostuff()
        {
            Dictionary<int, HREntity> allEntitys = HRGame.GetEntityMap();

            HRPlayer ownPlayer = HRPlayer.GetLocalPlayer();
            HRPlayer enemyPlayer = HRPlayer.GetEnemyPlayer();

            HREntity ownhero = ownPlayer.GetHero();
            HREntity enemyhero = enemyPlayer.GetHero();
            HREntity ownHeroAbility = ownPlayer.GetHeroPower();

            //player stuff#########################
            //this.currentMana =ownPlayer.GetTag(HRGameTag.RESOURCES) - ownPlayer.GetTag(HRGameTag.RESOURCES_USED) + ownPlayer.GetTag(HRGameTag.TEMP_RESOURCES);
            this.currentMana = ownPlayer.GetNumAvailableResources();
            this.ownMaxMana = ownPlayer.GetTag(HRGameTag.RESOURCES);
            this.enemyMaxMana = enemyPlayer.GetTag(HRGameTag.RESOURCES);
            enemySecretCount = HRCard.GetCards(enemyPlayer, HRCardZone.SECRET).Count;
            enemySecretCount = 0;
            //count enemy secrets
            enemySecretList.Clear();
            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.IsSecret() && ent.GetControllerId() == enemyPlayer.GetControllerId() && ent.GetZone() == HRCardZone.SECRET)
                {
                    enemySecretCount++;
                    enemySecretList.Add(ent.GetTag(HRGameTag.ENTITY_ID));
                }
            }



            this.ownSecretList = ownPlayer.GetSecretDefinitions();
            this.numMinionsPlayedThisTurn = ownPlayer.GetTag(HRGameTag.NUM_MINIONS_PLAYED_THIS_TURN);
            this.cardsPlayedThisTurn = ownPlayer.GetTag(HRGameTag.NUM_CARDS_PLAYED_THIS_TURN);
            //if (ownPlayer.HasCombo()) this.cardsPlayedThisTurn = 1;
            this.ueberladung = ownPlayer.GetTag(HRGameTag.RECALL_OWED);

            //get weapon stuff
            this.ownHeroWeapon = "";
            this.heroWeaponAttack = 0;
            this.heroWeaponDurability = 0;

            this.ownHeroFatigue = ownhero.GetFatigue();
            this.enemyHeroFatigue = enemyhero.GetFatigue();

            this.ownDecksize = 0;
            this.enemyDecksize = 0;
            //count decksize
            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.GetControllerId() == ownPlayer.GetControllerId() && ent.GetZone() == HRCardZone.DECK) ownDecksize++;
                if (ent.GetControllerId() == enemyPlayer.GetControllerId() && ent.GetZone() == HRCardZone.DECK) enemyDecksize++;
            }

            //own hero stuff###########################
            int heroAtk = ownhero.GetATK();
            int heroHp = ownhero.GetHealth() - ownhero.GetDamage();
            int heroDefence = ownhero.GetArmor();
            this.heroname = Hrtprozis.Instance.heroIDtoName(ownhero.GetCardId());

            bool heroImmuneToDamageWhileAttacking = false;
            bool herofrozen = ownhero.IsFrozen();
            int heroNumAttacksThisTurn = ownhero.GetNumAttacksThisTurn();
            bool heroHasWindfury = ownhero.HasWindfury();
            bool heroImmune = (ownhero.GetTag(HRGameTag.CANT_BE_DAMAGED) == 1) ? true : false;

            //Helpfunctions.Instance.ErrorLog(ownhero.GetName() + " ready params ex: " + exausted + " " + heroAtk + " " + numberofattacks + " " + herofrozen);


            if (ownPlayer.HasWeapon())
            {
                HREntity weapon = ownPlayer.GetWeaponCard().GetEntity();
                this.ownHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.GetCardId())).name.ToString();
                this.heroWeaponAttack = weapon.GetATK();
                this.heroWeaponDurability = weapon.GetTag(HRGameTag.DURABILITY) - weapon.GetTag(HRGameTag.DAMAGE);//weapon.GetDurability();
                heroImmuneToDamageWhileAttacking = false;
                if (this.ownHeroWeapon == "gladiatorslongbow")
                {
                    heroImmuneToDamageWhileAttacking = true;
                }
                if (this.ownHeroWeapon == "doomhammer")
                {
                    heroHasWindfury = true;
                }

                //Helpfunctions.Instance.ErrorLog("weapon: " + ownHeroWeapon + " " + heroWeaponAttack + " " + heroWeaponDurability);

            }



            //enemy hero stuff###############################################################
            this.enemyHeroname = Hrtprozis.Instance.heroIDtoName(enemyhero.GetCardId());

            int enemyAtk = enemyhero.GetATK();
            int enemyHp = enemyhero.GetHealth() - enemyhero.GetDamage();
            int enemyDefence = enemyhero.GetArmor();
            bool enemyfrozen = enemyhero.IsFrozen();
            bool enemyHeroImmune = (enemyhero.GetTag(HRGameTag.CANT_BE_DAMAGED) == 1) ? true : false;

            this.enemyHeroWeapon = "";
            this.enemyWeaponAttack = 0;
            this.enemyWeaponDurability = 0;
            if (enemyPlayer.HasWeapon())
            {
                HREntity weapon = enemyPlayer.GetWeaponCard().GetEntity();
                this.enemyHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.GetCardId())).name.ToString();
                this.enemyWeaponAttack = weapon.GetATK();
                this.enemyWeaponDurability = weapon.GetDurability();

            }


            //own hero ablity stuff###########################################################

            this.heroAbility = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(ownHeroAbility.GetCardId()));
            this.ownAbilityisReady = (ownHeroAbility.IsExhausted()) ? false : true; // if exhausted, ability is NOT ready
            this.enemyAbility = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(enemyhero.GetHeroPower().GetCardId()));

            //generate Heros
            this.ownHero = new Minion();
            this.enemyHero = new Minion();
            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = ownhero.GetHealth();
            this.enemyHero.maxHp = enemyhero.GetHealth();
            this.ownHero.entitiyID = ownhero.GetEntityId();
            this.enemyHero.entitiyID = enemyhero.GetEntityId();

            this.ownHero.Angr = heroAtk;
            this.ownHero.Hp = heroHp;
            this.ownHero.armor = heroDefence;
            this.ownHero.frozen = herofrozen;
            this.ownHero.immuneWhileAttacking = heroImmuneToDamageWhileAttacking;
            this.ownHero.immune = heroImmune;
            this.ownHero.numAttacksThisTurn = heroNumAttacksThisTurn;
            this.ownHero.windfury = heroHasWindfury;

            this.enemyHero.Angr = enemyAtk;
            this.enemyHero.Hp = enemyHp;
            this.enemyHero.frozen = enemyfrozen;
            this.enemyHero.armor = enemyDefence;
            this.enemyHero.immune = enemyHeroImmune;
            this.enemyHero.Ready = false;

            this.ownHero.updateReadyness();


            //load enchantments of the heros
            List<miniEnch> miniEnchlist = new List<miniEnch>();
            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.GetTag(HRGameTag.ATTACHED) == this.ownHero.entitiyID && ent.GetZone() == HRCardZone.PLAY)
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.GetCardId());
                    int controler = ent.GetTag(HRGameTag.CONTROLLER);
                    int creator = ent.GetTag(HRGameTag.CREATOR);
                    miniEnchlist.Add(new miniEnch(id, creator, controler));
                }

            }

            this.ownHero.loadEnchantments(miniEnchlist, ownhero.GetTag(HRGameTag.CONTROLLER));

            miniEnchlist.Clear();

            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.GetTag(HRGameTag.ATTACHED) == this.enemyHero.entitiyID && ent.GetZone() == HRCardZone.PLAY)
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.GetCardId());
                    int controler = ent.GetTag(HRGameTag.CONTROLLER);
                    int creator = ent.GetTag(HRGameTag.CREATOR);
                    miniEnchlist.Add(new miniEnch(id, creator, controler));
                }

            }

            this.enemyHero.loadEnchantments(miniEnchlist, enemyhero.GetTag(HRGameTag.CONTROLLER));
            //fastmode weapon correction:
            if (ownHero.Angr < this.heroWeaponAttack) ownHero.Angr = this.heroWeaponAttack;
            if (enemyHero.Angr < this.enemyWeaponAttack) enemyHero.Angr = this.enemyWeaponAttack;

        }

        private void getMinions()
        {
            Dictionary<int, HREntity> allEntitys = HRGame.GetEntityMap();
            ownMinions.Clear();
            enemyMinions.Clear();
            HRPlayer ownPlayer = HRPlayer.GetLocalPlayer();
            HRPlayer enemyPlayer = HRPlayer.GetEnemyPlayer();

            // ALL minions on Playfield:
            List<HRCard> list = HRCard.GetCards(ownPlayer, HRCardZone.PLAY);
            list.AddRange(HRCard.GetCards(enemyPlayer, HRCardZone.PLAY));

            List<HREntity> enchantments = new List<HREntity>();


            foreach (HRCard item in list)
            {
                HREntity entitiy = item.GetEntity();
                int zp = entitiy.GetZonePosition();

                if (entitiy.GetCardType() == HRCardType.MINION && zp >= 1)
                {
                    //Helpfunctions.Instance.ErrorLog("zonepos " + zp);
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.GetCardId()));
                    Minion m = new Minion();
                    m.name = c.name;
                    m.handcard.card = c;
                    m.Angr = entitiy.GetATK();
                    m.maxHp = entitiy.GetHealth();
                    m.Hp = m.maxHp - entitiy.GetDamage();
                    if (m.Hp <= 0) continue;
                    m.wounded = false;
                    if (m.maxHp > m.Hp) m.wounded = true;


                    m.exhausted = entitiy.IsExhausted();

                    m.taunt = (entitiy.HasTaunt()) ? true : false;

                    m.numAttacksThisTurn = entitiy.GetNumAttacksThisTurn();

                    int temp = entitiy.GetNumTurnsInPlay();
                    m.playedThisTurn = (temp == 0) ? true : false;

                    m.windfury = (entitiy.HasWindfury()) ? true : false;

                    m.frozen = (entitiy.IsFrozen()) ? true : false;

                    m.divineshild = (entitiy.HasDivineShield()) ? true : false;

                    m.stealth = (entitiy.IsStealthed()) ? true : false;

                    m.poisonous = (entitiy.IsPoisonous()) ? true : false;

                    m.immune = (entitiy.IsImmune()) ? true : false;

                    m.silenced = (entitiy.GetTag(HRGameTag.SILENCED) >= 1) ? true : false;

                    m.charge = 0;

                    if (!m.silenced && m.name == CardDB.cardName.southseadeckhand && entitiy.GetTag(HRGameTag.CHARGE) == 1) m.charge = 1;
                    if (!m.silenced && m.handcard.card.Charge) m.charge = 1;

                    m.zonepos = zp;

                    m.entitiyID = entitiy.GetEntityId();


                    //Helpfunctions.Instance.ErrorLog(  m.name + " ready params ex: " + m.exhausted + " charge: " +m.charge + " attcksthisturn: " + m.numAttacksThisTurn + " playedthisturn " + m.playedThisTurn );


                    List<miniEnch> enchs = new List<miniEnch>();
                    foreach (HREntity ent in allEntitys.Values)
                    {
                        if (ent.GetTag(HRGameTag.ATTACHED) == m.entitiyID && ent.GetZone() == HRCardZone.PLAY)
                        {
                            CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.GetCardId());
                            int creator = ent.GetTag(HRGameTag.CREATOR);
                            int controler = ent.GetTag(HRGameTag.CONTROLLER);
                            enchs.Add(new miniEnch(id, creator, controler));
                        }

                    }

                    m.loadEnchantments(enchs, entitiy.GetControllerId());




                    m.Ready = false; // if exhausted, he is NOT ready

                    m.updateReadyness();


                    if (entitiy.GetControllerId() == this.ownPlayerController) // OWN minion
                    {
                        m.own = true;
                        this.ownMinions.Add(m);
                    }
                    else
                    {
                        m.own = false;
                        this.enemyMinions.Add(m);
                    }

                }
                // minions added

                /*
                if (entitiy.GetCardType() == HRCardType.WEAPON)
                {
                    //Helpfunctions.Instance.ErrorLog("found weapon!");
                    if (entitiy.GetControllerId() == this.ownPlayerController) // OWN weapon
                    {
                        this.ownHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.GetCardId())).name.ToString();
                        this.heroWeaponAttack = entitiy.GetATK();
                        this.heroWeaponDurability = entitiy.GetDurability();
                        //this.heroImmuneToDamageWhileAttacking = false;


                    }
                    else
                    {
                        this.enemyHeroWeapon = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.GetCardId())).name.ToString();
                        this.enemyWeaponAttack = entitiy.GetATK();
                        this.enemyWeaponDurability = entitiy.GetDurability();
                    }
                }

                if (entitiy.GetCardType() == HRCardType.ENCHANTMENT)
                {

                    enchantments.Add(entitiy);
                }
                 */


            }

            /*foreach (HRCard item in list)
            {
                foreach (HREntity e in item.GetEntity().GetEnchantments())
                {
                    enchantments.Add(e);
                }
            }


            // add enchantments to minions
            setEnchantments(enchantments);*/
        }

        private void setEnchantments(List<HREntity> enchantments)
        {
            /*
            foreach (HREntity bhu in enchantments)
            {
                //create enchantment
                Enchantment ench = CardDB.getEnchantmentFromCardID(CardDB.Instance.cardIdstringToEnum(bhu.GetCardId()));
                ench.creator = bhu.GetCreatorId();
                ench.controllerOfCreator = bhu.GetControllerId();
                ench.cantBeDispelled = false;
                //if (bhu.c) ench.cantBeDispelled = true;

                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == bhu.GetAttached())
                    {
                        m.enchantments.Add(ench);
                        //Helpfunctions.Instance.ErrorLog("add enchantment " +bhu.GetCardId()+" to: " + m.entitiyID);
                    }

                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == bhu.GetAttached())
                    {
                        m.enchantments.Add(ench);
                    }

                }

            }
            */
        }

        private void getHandcards()
        {
            handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            List<HRCard> list = HRCard.GetCards(HRPlayer.GetLocalPlayer(), HRCardZone.HAND);

            foreach (HRCard item in list)
            {

                HREntity entitiy = item.GetEntity();

                if (entitiy.GetControllerId() == this.ownPlayerController && entitiy.GetZonePosition() >= 1) // own handcard
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.GetCardId()));
                    //c.cost = entitiy.GetCost();
                    //c.entityID = entitiy.GetEntityId();

                    Handmanager.Handcard hc = new Handmanager.Handcard();
                    hc.card = c;
                    hc.position = entitiy.GetZonePosition();
                    hc.entity = entitiy.GetEntityId();
                    hc.manacost = entitiy.GetCost();
                    handCards.Add(hc);
                    this.anzcards++;
                }


            }

            Dictionary<int, HREntity> allEntitys = HRGame.GetEntityMap();

            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.GetControllerId() != this.ownPlayerController && ent.GetZonePosition() >= 1 && ent.GetZone() == HRCardZone.HAND) // enemy handcard
                {
                    this.enemyAnzCards++;
                }
            }

        }

        private void getDecks()
        {
            Dictionary<int, HREntity> allEntitys = HRGame.GetEntityMap();

            int owncontroler = HRPlayer.GetLocalPlayer().GetControllerId();
            int enemycontroler = HRPlayer.GetEnemyPlayer().GetControllerId();
            List<CardDB.cardIDEnum> ownCards = new List<CardDB.cardIDEnum>();
            List<CardDB.cardIDEnum> enemyCards = new List<CardDB.cardIDEnum>();
            List<GraveYardItem> graveYard = new List<GraveYardItem>();

            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.GetZone() == HRCardZone.SECRET && ent.GetControllerId() == enemycontroler) continue; // cant know enemy secrets :D
                if (ent.GetZone() == HRCardZone.DECK) continue;
                if (ent.GetCardType() == HRCardType.MINION || ent.GetCardType() == HRCardType.WEAPON || ent.GetCardType() == HRCardType.ABILITY)
                {

                    CardDB.cardIDEnum cardid = CardDB.Instance.cardIdstringToEnum(ent.GetCardId());
                    //string owner = "own";
                    //if (ent.GetControllerId() == enemycontroler) owner = "enemy";
                    //if (ent.GetControllerId() == enemycontroler && ent.GetZone() == HRCardZone.HAND) Helpfunctions.Instance.logg("enemy card in hand: " + "cardindeck: " + cardid + " " + ent.GetName());
                    //if (cardid != CardDB.cardIDEnum.None) Helpfunctions.Instance.logg("cardindeck: " + cardid + " " + ent.GetName() + " " + ent.GetZone() + " " + owner + " " + ent.GetCardType());
                    if (cardid != CardDB.cardIDEnum.None)
                    {
                        if (ent.GetZone() == HRCardZone.GRAVEYARD)
                        {
                            GraveYardItem gyi = new GraveYardItem(cardid, ent.GetEntityId(), ent.GetControllerId() == owncontroler);
                            graveYard.Add(gyi);
                        }

                        int creator = ent.GetTag(HRGameTag.CREATOR);
                        if (creator != 0 && creator != owncontroler && creator != enemycontroler) continue; //if creator is someone else, it was not played

                        if (ent.GetControllerId() == owncontroler) //or controler?
                        {
                            if (ent.GetZone() == HRCardZone.GRAVEYARD)
                            {
                                ownCards.Add(cardid);
                            }
                        }
                        else
                        {
                            if (ent.GetZone() == HRCardZone.GRAVEYARD)
                            {
                                enemyCards.Add(cardid);
                            }
                        }
                    }
                }

            }

            Probabilitymaker.Instance.setOwnCards(ownCards);
            Probabilitymaker.Instance.setEnemyCards(enemyCards);
            bool isTurnStart = false;
            if (Ai.Instance.nextMoveGuess.mana == -100)
            {
                isTurnStart = true;
                Ai.Instance.updateTwoTurnSim();
            }
            Probabilitymaker.Instance.setGraveYard(graveYard, isTurnStart);

        }

        private void updateBehaveString(Behavior botbase)
        {
            this.botbehave = "rush";
            if (botbase is BehaviorControl) this.botbehave = "control";
            if (botbase is BehaviorMana) this.botbehave = "mana";
            this.botbehave += " " + Ai.Instance.maxwide;
            this.botbehave += " face " + ComboBreaker.Instance.attackFaceHP;
            if (Settings.Instance.secondTurnAmount > 0)
            {
                if (Ai.Instance.nextMoveGuess.mana == -100)
                {
                    Ai.Instance.updateTwoTurnSim();
                }
                this.botbehave += " twoturnsim " + Settings.Instance.secondTurnAmount + " ntss " + Settings.Instance.nextTurnDeep + " " + Settings.Instance.nextTurnMaxWide + " " + Settings.Instance.nextTurnTotalBoards;
            }

            if (Settings.Instance.playarround)
            {
                this.botbehave += " playaround";
                this.botbehave += " " + Settings.Instance.playaroundprob + " " + Settings.Instance.playaroundprob2;
            }

            this.botbehave += " ets " + Settings.Instance.enemyTurnMaxWide;

            if (Settings.Instance.simEnemySecondTurn)
            {
                this.botbehave += " simEnemy2Turn";
                this.botbehave += " ents " + Settings.Instance.enemySecondTurnMaxWide;
            }

            if (Settings.Instance.useSecretsPlayArround)
            {
                this.botbehave += " secret";
            }

            if (Settings.Instance.secondweight != 0.5f)
            {
                this.botbehave += " weight " + (int)(Settings.Instance.secondweight*100f);
            }




        }

        public static int getLastAffected(int entityid)
        {

            Dictionary<int, HREntity> allEntitys = HRGame.GetEntityMap();

            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.GetTag(HRGameTag.LAST_AFFECTED_BY) == entityid) return ent.GetTag(HRGameTag.ENTITY_ID);
            }

            return 0;
        }

        public static int getCardTarget(int entityid)
        {

            Dictionary<int, HREntity> allEntitys = HRGame.GetEntityMap();

            foreach (HREntity ent in allEntitys.Values)
            {
                if (ent.GetTag(HRGameTag.ENTITY_ID) == entityid) return ent.GetTag(HRGameTag.CARD_TARGET);
            }

            return 0;
        }

        public void testExternal()
        {
            BoardTester bt = new BoardTester("");
            this.currentMana = Hrtprozis.Instance.currentMana;
            this.ownMaxMana = Hrtprozis.Instance.ownMaxMana;
            this.enemyMaxMana = Hrtprozis.Instance.enemyMaxMana;
            printstuff(true);
            readActionFile();
        }

        private void printstuff(bool runEx)
        {
            HRPlayer ownPlayer = HRPlayer.GetLocalPlayer();
            int ownsecretcount = ownPlayer.GetSecretDefinitions().Count;
            string dtimes = DateTime.Now.ToString("HH:mm:ss:ffff");
            string enemysecretIds = "";
            enemysecretIds = Probabilitymaker.Instance.getEnemySecretData();
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("start calculations, current time: " + dtimes + " V" + this.versionnumber + " " + this.botbehave);
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("mana " + currentMana + "/" + ownMaxMana);
            Helpfunctions.Instance.logg("emana " + enemyMaxMana);
            Helpfunctions.Instance.logg("own secretsCount: " + ownsecretcount);

            Helpfunctions.Instance.logg("enemy secretsCount: " + enemySecretCount + " ;" + enemysecretIds);

            Ai.Instance.currentCalculatedBoard = dtimes;

            if (runEx)
            {
                Helpfunctions.Instance.resetBuffer();
                Helpfunctions.Instance.writeBufferToActionFile();
                Helpfunctions.Instance.resetBuffer();

                Helpfunctions.Instance.writeToBuffer("#######################################################################");
                Helpfunctions.Instance.writeToBuffer("#######################################################################");
                Helpfunctions.Instance.writeToBuffer("start calculations, current time: " + dtimes + " V" + this.versionnumber + " " + this.botbehave);
                Helpfunctions.Instance.writeToBuffer("#######################################################################");
                Helpfunctions.Instance.writeToBuffer("mana " + currentMana + "/" + ownMaxMana);
                Helpfunctions.Instance.writeToBuffer("emana " + enemyMaxMana);
                Helpfunctions.Instance.writeToBuffer("own secretsCount: " + ownsecretcount);
                Helpfunctions.Instance.writeToBuffer("enemy secretsCount: " + enemySecretCount + " ;" + enemysecretIds);
            }
            Hrtprozis.Instance.printHero(runEx);
            Hrtprozis.Instance.printOwnMinions(runEx);
            Hrtprozis.Instance.printEnemyMinions(runEx);
            Handmanager.Instance.printcards(runEx);
            Probabilitymaker.Instance.printTurnGraveYard(runEx);
            Probabilitymaker.Instance.printGraveyards(runEx);

            if (runEx) Helpfunctions.Instance.writeBufferToFile();

        }

        public bool readActionFile(bool passiveWaiting = false)
        {
            bool readed = true;
            List<string> alist = new List<string>();
            float value = 0f;
            string boardnumm = "-1";
            this.waitingForSilver = true;
            while (readed)
            {
                try
                {
                    string data = System.IO.File.ReadAllText(Settings.Instance.path + "actionstodo.txt");
                    if (data != "" && data != "<EoF>" && data.EndsWith("<EoF>"))
                    {
                        data = data.Replace("<EoF>", "");
                        //Helpfunctions.Instance.ErrorLog(data);
                        Helpfunctions.Instance.resetBuffer();
                        Helpfunctions.Instance.writeBufferToActionFile();
                        alist.AddRange(data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
                        string board = alist[0];
                        if (board.StartsWith("board "))
                        {
                            boardnumm = (board.Split(' ')[1].Split(' ')[0]);
                            alist.RemoveAt(0);
                            if (boardnumm != Ai.Instance.currentCalculatedBoard)
                            {
                                if (passiveWaiting)
                                {
                                    System.Threading.Thread.Sleep(10);
                                    return false;
                                }
                                continue;
                            }
                        }
                        string first = alist[0];
                        if (first.StartsWith("value "))
                        {
                            value = float.Parse((first.Split(' ')[1].Split(' ')[0]));
                            alist.RemoveAt(0);
                        }
                        readed = false;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(10);
                        if (passiveWaiting)
                        {
                            return false;
                        }
                    }

                }
                catch
                {
                    System.Threading.Thread.Sleep(10);
                }

            }
            this.waitingForSilver = false;
            Helpfunctions.Instance.logg("received " + boardnumm + " actions to do:");
            Ai.Instance.currentCalculatedBoard = "0";
            Playfield p = new Playfield();
            List<Action> aclist = new List<Action>();

            foreach (string a in alist)
            {
                aclist.Add(new Action(a, p));
                Helpfunctions.Instance.logg(a);
            }

            Ai.Instance.setBestMoves(aclist, value);

            return true;
        }


    }

}

