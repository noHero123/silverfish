// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Probabilitymaker.cs" company="">
//   
// </copyright>
// <summary>
//   The grave yard item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The grave yard item.
    /// </summary>
    public struct GraveYardItem
    {
        #region Fields

        /// <summary>
        ///     The cardid.
        /// </summary>
        public CardDB.cardIDEnum cardid;

        /// <summary>
        ///     The entity.
        /// </summary>
        public int entity;

        /// <summary>
        ///     The own.
        /// </summary>
        public bool own;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="GraveYardItem"/> Struktur. 
        /// Initializes a new instance of the <see cref="GraveYardItem"/> struct.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        public GraveYardItem(CardDB.cardIDEnum id, int entity, bool own)
        {
            this.own = own;
            this.cardid = id;
            this.entity = entity;
        }

        #endregion
    }

    /// <summary>
    ///     The secret item.
    /// </summary>
    public class SecretItem
    {
        #region Fields

        /// <summary>
        ///     The can be_avenge.
        /// </summary>
        public bool canBe_avenge = true;

        /// <summary>
        ///     The can be_counterspell.
        /// </summary>
        public bool canBe_counterspell = true;

        /// <summary>
        ///     The can be_duplicate.
        /// </summary>
        public bool canBe_duplicate = true;

        /// <summary>
        ///     The can be_explosive.
        /// </summary>
        public bool canBe_explosive = true;

        /// <summary>
        ///     The can be_eyeforaneye.
        /// </summary>
        public bool canBe_eyeforaneye = true;

        /// <summary>
        ///     The can be_freezing.
        /// </summary>
        public bool canBe_freezing = true;

        /// <summary>
        ///     The can be_icebarrier.
        /// </summary>
        public bool canBe_icebarrier = true;

        /// <summary>
        ///     The can be_iceblock.
        /// </summary>
        public bool canBe_iceblock = true;

        /// <summary>
        ///     The can be_mirrorentity.
        /// </summary>
        public bool canBe_mirrorentity = true;

        /// <summary>
        ///     The can be_missdirection.
        /// </summary>
        public bool canBe_missdirection = true;

        /// <summary>
        ///     The can be_noblesacrifice.
        /// </summary>
        public bool canBe_noblesacrifice = true;

        /// <summary>
        ///     The can be_redemption.
        /// </summary>
        public bool canBe_redemption = true;

        /// <summary>
        ///     The can be_repentance.
        /// </summary>
        public bool canBe_repentance = true;

        /// <summary>
        ///     The can be_snaketrap.
        /// </summary>
        public bool canBe_snaketrap = true;

        /// <summary>
        ///     The can be_snipe.
        /// </summary>
        public bool canBe_snipe = true;

        /// <summary>
        ///     The can be_spellbender.
        /// </summary>
        public bool canBe_spellbender = true;

        /// <summary>
        ///     The can be_vaporize.
        /// </summary>
        public bool canBe_vaporize = true;

        /// <summary>
        ///     The canbe triggered with attacking hero.
        /// </summary>
        public bool canbeTriggeredWithAttackingHero = true;

        /// <summary>
        ///     The canbe triggered with attacking minion.
        /// </summary>
        public bool canbeTriggeredWithAttackingMinion = true;

        /// <summary>
        ///     The canbe triggered with playing minion.
        /// </summary>
        public bool canbeTriggeredWithPlayingMinion = true;

        /// <summary>
        ///     The entity id.
        /// </summary>
        public int entityId = 0;

        /// <summary>
        ///     The triggered.
        /// </summary>
        public bool triggered = false;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SecretItem"/> Klasse. 
        ///     Initializes a new instance of the <see cref="SecretItem"/> class.
        /// </summary>
        public SecretItem()
        {
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SecretItem"/> Klasse. 
        /// Initializes a new instance of the <see cref="SecretItem"/> class.
        /// </summary>
        /// <param name="sec">
        /// The sec.
        /// </param>
        public SecretItem(SecretItem sec)
        {
            this.triggered = sec.triggered;
            this.canbeTriggeredWithAttackingHero = sec.canbeTriggeredWithAttackingHero;
            this.canbeTriggeredWithAttackingMinion = sec.canbeTriggeredWithAttackingMinion;
            this.canbeTriggeredWithPlayingMinion = sec.canbeTriggeredWithPlayingMinion;

            this.canBe_avenge = sec.canBe_avenge;
            this.canBe_counterspell = sec.canBe_counterspell;
            this.canBe_duplicate = sec.canBe_duplicate;
            this.canBe_explosive = sec.canBe_explosive;
            this.canBe_eyeforaneye = sec.canBe_eyeforaneye;
            this.canBe_freezing = sec.canBe_freezing;
            this.canBe_icebarrier = sec.canBe_icebarrier;
            this.canBe_iceblock = sec.canBe_iceblock;
            this.canBe_mirrorentity = sec.canBe_mirrorentity;
            this.canBe_missdirection = sec.canBe_missdirection;
            this.canBe_noblesacrifice = sec.canBe_noblesacrifice;
            this.canBe_redemption = sec.canBe_redemption;
            this.canBe_repentance = sec.canBe_repentance;
            this.canBe_snaketrap = sec.canBe_snaketrap;
            this.canBe_snipe = sec.canBe_snipe;
            this.canBe_spellbender = sec.canBe_spellbender;
            this.canBe_vaporize = sec.canBe_vaporize;

            this.entityId = sec.entityId;
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SecretItem"/> Klasse. 
        /// Initializes a new instance of the <see cref="SecretItem"/> class.
        /// </summary>
        /// <param name="secdata">
        /// The secdata.
        /// </param>
        public SecretItem(string secdata)
        {
            this.entityId = Convert.ToInt32(secdata.Split('.')[0]);

            string canbe = secdata.Split('.')[1];
            if (canbe.Length < 17)
            {
                Helpfunctions.Instance.ErrorLog("cant read secret " + secdata + " " + canbe.Length);
            }

            this.canBe_snaketrap = (canbe[0] == '1') ? true : false;
            this.canBe_snipe = (canbe[1] == '1') ? true : false;
            this.canBe_explosive = (canbe[2] == '1') ? true : false;
            this.canBe_freezing = (canbe[3] == '1') ? true : false;
            this.canBe_missdirection = (canbe[4] == '1') ? true : false;

            this.canBe_counterspell = (canbe[5] == '1') ? true : false;
            this.canBe_icebarrier = (canbe[6] == '1') ? true : false;
            this.canBe_iceblock = (canbe[7] == '1') ? true : false;
            this.canBe_mirrorentity = (canbe[8] == '1') ? true : false;
            this.canBe_spellbender = (canbe[9] == '1') ? true : false;
            this.canBe_vaporize = (canbe[10] == '1') ? true : false;
            this.canBe_duplicate = (canbe[11] == '1') ? true : false;

            this.canBe_eyeforaneye = (canbe[12] == '1') ? true : false;
            this.canBe_noblesacrifice = (canbe[13] == '1') ? true : false;
            this.canBe_redemption = (canbe[14] == '1') ? true : false;
            this.canBe_repentance = (canbe[15] == '1') ? true : false;
            this.canBe_avenge = (canbe[16] == '1') ? true : false;

            this.updateCanBeTriggered();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The is equal.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool isEqual(SecretItem s)
        {
            bool result = this.entityId == s.entityId;
            result = result && this.canBe_avenge == s.canBe_avenge && this.canBe_counterspell == s.canBe_counterspell
                     && this.canBe_duplicate == s.canBe_duplicate && this.canBe_explosive == s.canBe_explosive;
            result = result && this.canBe_eyeforaneye == s.canBe_eyeforaneye && this.canBe_freezing == s.canBe_freezing
                     && this.canBe_icebarrier == s.canBe_icebarrier && this.canBe_iceblock == s.canBe_iceblock;
            result = result && this.canBe_mirrorentity == s.canBe_mirrorentity
                     && this.canBe_missdirection == s.canBe_missdirection
                     && this.canBe_noblesacrifice == s.canBe_noblesacrifice
                     && this.canBe_redemption == s.canBe_redemption;
            result = result && this.canBe_repentance == s.canBe_repentance && this.canBe_snaketrap == s.canBe_snaketrap
                     && this.canBe_snipe == s.canBe_snipe && this.canBe_spellbender == s.canBe_spellbender
                     && this.canBe_vaporize == s.canBe_vaporize;

            return result;
        }

        /// <summary>
        ///     The return a string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string returnAString()
        {
            string retval = string.Empty + this.entityId + ".";
            retval += string.Empty + (this.canBe_snaketrap ? "1" : "0");
            retval += string.Empty + (this.canBe_snipe ? "1" : "0");
            retval += string.Empty + (this.canBe_explosive ? "1" : "0");
            retval += string.Empty + (this.canBe_freezing ? "1" : "0");
            retval += string.Empty + (this.canBe_missdirection ? "1" : "0");

            retval += string.Empty + (this.canBe_counterspell ? "1" : "0");
            retval += string.Empty + (this.canBe_icebarrier ? "1" : "0");
            retval += string.Empty + (this.canBe_iceblock ? "1" : "0");
            retval += string.Empty + (this.canBe_mirrorentity ? "1" : "0");
            retval += string.Empty + (this.canBe_spellbender ? "1" : "0");
            retval += string.Empty + (this.canBe_vaporize ? "1" : "0");
            retval += string.Empty + (this.canBe_duplicate ? "1" : "0");

            retval += string.Empty + (this.canBe_eyeforaneye ? "1" : "0");
            retval += string.Empty + (this.canBe_noblesacrifice ? "1" : "0");
            retval += string.Empty + (this.canBe_redemption ? "1" : "0");
            retval += string.Empty + (this.canBe_repentance ? "1" : "0");
            retval += string.Empty + (this.canBe_avenge ? "1" : "0");
            return retval + ",";
        }

        /// <summary>
        ///     The update can be triggered.
        /// </summary>
        public void updateCanBeTriggered()
        {
            this.canbeTriggeredWithAttackingHero = false;
            this.canbeTriggeredWithAttackingMinion = false;
            this.canbeTriggeredWithPlayingMinion = false;

            if (this.canBe_snipe || this.canBe_mirrorentity || this.canBe_repentance)
            {
                this.canbeTriggeredWithPlayingMinion = true;
            }

            if (this.canBe_explosive || this.canBe_missdirection || this.canBe_freezing || this.canBe_icebarrier
                || this.canBe_vaporize || this.canBe_noblesacrifice)
            {
                this.canbeTriggeredWithAttackingHero = true;
            }

            if (this.canBe_snaketrap || this.canBe_freezing || this.canBe_noblesacrifice)
            {
                this.canbeTriggeredWithAttackingMinion = true;
            }
        }

        /// <summary>
        /// The used trigger_ char is attacked.
        /// </summary>
        /// <param name="DefenderIsHero">
        /// The defender is hero.
        /// </param>
        /// <param name="AttackerIsHero">
        /// The attacker is hero.
        /// </param>
        public void usedTrigger_CharIsAttacked(bool DefenderIsHero, bool AttackerIsHero)
        {
            if (DefenderIsHero)
            {
                this.canBe_explosive = false;
                this.canBe_missdirection = false;

                this.canBe_icebarrier = false;
                this.canBe_vaporize = false;
            }
            else
            {
                this.canBe_snaketrap = false;
            }

            if (!AttackerIsHero)
            {
                this.canBe_freezing = false;
            }

            this.canBe_noblesacrifice = false;
            this.updateCanBeTriggered();
        }

        /// <summary>
        /// The used trigger_ hero got dmg.
        /// </summary>
        /// <param name="deadly">
        /// The deadly.
        /// </param>
        public void usedTrigger_HeroGotDmg(bool deadly = false)
        {
            this.canBe_eyeforaneye = false;
            if (deadly)
            {
                this.canBe_iceblock = false;
            }

            this.updateCanBeTriggered();
        }

        /// <summary>
        ///     The used trigger_ minion died.
        /// </summary>
        public void usedTrigger_MinionDied()
        {
            this.canBe_avenge = false;
            this.canBe_redemption = false;
            this.canBe_duplicate = false;
            this.updateCanBeTriggered();
        }

        /// <summary>
        ///     The used trigger_ minion is played.
        /// </summary>
        public void usedTrigger_MinionIsPlayed()
        {
            this.canBe_snipe = false;
            this.canBe_mirrorentity = false;
            this.canBe_repentance = false;
            this.updateCanBeTriggered();
        }

        /// <summary>
        /// The used trigger_ spell is played.
        /// </summary>
        /// <param name="minionIsTarget">
        /// The minion is target.
        /// </param>
        public void usedTrigger_SpellIsPlayed(bool minionIsTarget)
        {
            this.canBe_counterspell = false;
            if (minionIsTarget)
            {
                this.canBe_spellbender = false;
            }

            this.updateCanBeTriggered();
        }

        #endregion
    }

    /// <summary>
    ///     The probabilitymaker.
    /// </summary>
    public class Probabilitymaker
    {
        #region Static Fields

        /// <summary>
        ///     The instance.
        /// </summary>
        private static Probabilitymaker instance;

        #endregion

        #region Fields

        /// <summary>
        ///     The enemy cards played.
        /// </summary>
        public Dictionary<CardDB.cardIDEnum, int> enemyCardsPlayed = new Dictionary<CardDB.cardIDEnum, int>();

        /// <summary>
        ///     The enemy secrets.
        /// </summary>
        public List<SecretItem> enemySecrets = new List<SecretItem>();

        /// <summary>
        ///     The feugen dead.
        /// </summary>
        public bool feugenDead = false;

        /// <summary>
        ///     The own cards played.
        /// </summary>
        public Dictionary<CardDB.cardIDEnum, int> ownCardsPlayed = new Dictionary<CardDB.cardIDEnum, int>();

        /// <summary>
        ///     The stalagg dead.
        /// </summary>
        public bool stalaggDead = false;

        /// <summary>
        ///     The turngraveyard.
        /// </summary>
        public List<GraveYardItem> turngraveyard = new List<GraveYardItem>(); // MOBS only

        /// <summary>
        ///     The enemy deck guessed.
        /// </summary>
        private List<CardDB.Card> enemyDeckGuessed = new List<CardDB.Card>();

        /// <summary>
        ///     The graveyard.
        /// </summary>
        private List<GraveYardItem> graveyard = new List<GraveYardItem>();

        /// <summary>
        ///     The graveyart till turn start.
        /// </summary>
        private List<GraveYardItem> graveyartTillTurnStart = new List<GraveYardItem>();

        /// <summary>
        ///     The own deck guessed.
        /// </summary>
        private List<CardDB.Card> ownDeckGuessed = new List<CardDB.Card>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Verhindert, dass eine Standardinstanz der <see cref="Probabilitymaker"/> Klasse erstellt wird. 
        ///     Prevents a default instance of the <see cref="Probabilitymaker"/> class from being created.
        /// </summary>
        private Probabilitymaker()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        public static Probabilitymaker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Probabilitymaker();
                }

                return instance;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The anz cards in deck.
        /// </summary>
        /// <param name="cardid">
        /// The cardid.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int anzCardsInDeck(CardDB.cardIDEnum cardid)
        {
            int ret = 2;
            CardDB.Card c = CardDB.Instance.getCardDataFromID(cardid);
            if (c.rarity == 5)
            {
                ret = 1; // you can have only one rare;
            }

            if (this.enemyCardsPlayed.ContainsKey(cardid))
            {
                if (this.enemyCardsPlayed[cardid] == 1)
                {
                    return 1;
                }

                return 0;
            }

            return ret;
        }

        /// <summary>
        ///     The get enemy secret data.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string getEnemySecretData()
        {
            string retval = string.Empty;
            foreach (SecretItem si in this.enemySecrets)
            {
                retval += si.returnAString();
            }

            return retval;
        }

        /// <summary>
        /// The get enemy secret data.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string getEnemySecretData(List<SecretItem> list)
        {
            string retval = string.Empty;
            foreach (SecretItem si in list)
            {
                retval += si.returnAString();
            }

            return retval;
        }

        /// <summary>
        /// The get enemy secret guesses.
        /// </summary>
        /// <param name="enemySecretIds">
        /// The enemy secret ids.
        /// </param>
        /// <param name="enemyHeroName">
        /// The enemy hero name.
        /// </param>
        public void getEnemySecretGuesses(List<int> enemySecretIds, HeroEnum enemyHeroName)
        {
            List<SecretItem> newlist = new List<SecretItem>();

            foreach (int i in enemySecretIds)
            {
                if (i >= 1000)
                {
                    continue;
                }

                Helpfunctions.Instance.logg("detect secret with id" + i);
                SecretItem sec = this.getNewSecretGuessedItem(i, enemyHeroName);

                newlist.Add(new SecretItem(sec));
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(newlist);
        }

        /// <summary>
        /// The get new secret guessed item.
        /// </summary>
        /// <param name="entityid">
        /// The entityid.
        /// </param>
        /// <param name="enemyHeroName">
        /// The enemy hero name.
        /// </param>
        /// <returns>
        /// The <see cref="SecretItem"/>.
        /// </returns>
        public SecretItem getNewSecretGuessedItem(int entityid, HeroEnum enemyHeroName)
        {
            foreach (SecretItem si in this.enemySecrets)
            {
                if (si.entityId == entityid && entityid < 1000)
                {
                    return si;
                }
            }

            SecretItem sec = new SecretItem();
            sec.entityId = entityid;
            if (enemyHeroName == HeroEnum.hunter)
            {
                sec.canBe_counterspell = false;
                sec.canBe_icebarrier = false;
                sec.canBe_iceblock = false;
                sec.canBe_mirrorentity = false;
                sec.canBe_spellbender = false;
                sec.canBe_vaporize = false;
                sec.canBe_duplicate = false;

                sec.canBe_eyeforaneye = false;
                sec.canBe_noblesacrifice = false;
                sec.canBe_redemption = false;
                sec.canBe_repentance = false;
                sec.canBe_avenge = false;

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_554)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_554] >= 2)
                {
                    sec.canBe_snaketrap = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_609)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_609] >= 2)
                {
                    sec.canBe_snipe = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_610)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_610] >= 2)
                {
                    sec.canBe_explosive = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_611)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_611] >= 2)
                {
                    sec.canBe_freezing = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_533)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_533] >= 2)
                {
                    sec.canBe_missdirection = false;
                }
            }

            if (enemyHeroName == HeroEnum.mage)
            {
                sec.canBe_snaketrap = false;
                sec.canBe_snipe = false;
                sec.canBe_explosive = false;
                sec.canBe_freezing = false;
                sec.canBe_missdirection = false;

                sec.canBe_eyeforaneye = false;
                sec.canBe_noblesacrifice = false;
                sec.canBe_redemption = false;
                sec.canBe_repentance = false;
                sec.canBe_avenge = false;

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_287)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_287] >= 2)
                {
                    sec.canBe_counterspell = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_289)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_289] >= 2)
                {
                    sec.canBe_icebarrier = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_295)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_295] >= 2)
                {
                    sec.canBe_iceblock = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_294)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_294] >= 2)
                {
                    sec.canBe_mirrorentity = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.tt_010)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.tt_010] >= 2)
                {
                    sec.canBe_spellbender = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_594)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_594] >= 2)
                {
                    sec.canBe_vaporize = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.FP1_018)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.FP1_018] >= 2)
                {
                    sec.canBe_duplicate = false;
                }
            }

            if (enemyHeroName == HeroEnum.pala)
            {
                sec.canBe_snaketrap = false;
                sec.canBe_snipe = false;
                sec.canBe_explosive = false;
                sec.canBe_freezing = false;
                sec.canBe_missdirection = false;

                sec.canBe_counterspell = false;
                sec.canBe_icebarrier = false;
                sec.canBe_iceblock = false;
                sec.canBe_mirrorentity = false;
                sec.canBe_spellbender = false;
                sec.canBe_vaporize = false;
                sec.canBe_duplicate = false;

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_132)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_132] >= 2)
                {
                    sec.canBe_eyeforaneye = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_130)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_130] >= 2)
                {
                    sec.canBe_noblesacrifice = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_136)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_136] >= 2)
                {
                    sec.canBe_redemption = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_379)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.EX1_379] >= 2)
                {
                    sec.canBe_repentance = false;
                }

                if (this.enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.FP1_020)
                    && this.enemyCardsPlayed[CardDB.cardIDEnum.FP1_020] >= 2)
                {
                    sec.canBe_avenge = false;
                }
            }

            return sec;
        }

        /// <summary>
        /// The get prob of enemy having card in hand.
        /// </summary>
        /// <param name="cardid">
        /// The cardid.
        /// </param>
        /// <param name="handsize">
        /// The handsize.
        /// </param>
        /// <param name="decksize">
        /// The decksize.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum cardid, int handsize, int decksize)
        {
            // calculates probability \in [0,...,100]
            int cardsremaining = this.anzCardsInDeck(cardid);
            if (cardsremaining == 0)
            {
                return 0;
            }

            double retval = 0.0;

            // http://de.wikipedia.org/wiki/Hypergeometrische_Verteilung (we calculte 1-p(x=0))
            if (cardsremaining == 1)
            {
                retval = 1.0 - decksize / ((double)(decksize + handsize));
            }
            else
            {
                retval = 1.0 - decksize * (decksize - 1) / ((double)((decksize + handsize) * (decksize + handsize - 1)));
            }

            retval = Math.Min(retval, 1.0);

            return (int)(100.0 * retval);
        }

        /// <summary>
        /// The has cardin graveyard.
        /// </summary>
        /// <param name="cardid">
        /// The cardid.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool hasCardinGraveyard(CardDB.cardIDEnum cardid)
        {
            foreach (GraveYardItem gyi in this.graveyard)
            {
                if (gyi.cardid == cardid)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The has enemy this card in deck.
        /// </summary>
        /// <param name="cardid">
        /// The cardid.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool hasEnemyThisCardInDeck(CardDB.cardIDEnum cardid)
        {
            if (this.enemyCardsPlayed.ContainsKey(cardid))
            {
                if (this.enemyCardsPlayed[cardid] == 1)
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// The print graveyards.
        /// </summary>
        /// <param name="writetobuffer">
        /// The writetobuffer.
        /// </param>
        public void printGraveyards(bool writetobuffer = false)
        {
            string og = "og: ";
            foreach (KeyValuePair<CardDB.cardIDEnum, int> e in this.ownCardsPlayed)
            {
                og += (int)e.Key + "," + e.Value + ";";
            }

            string eg = "eg: ";
            foreach (KeyValuePair<CardDB.cardIDEnum, int> e in this.enemyCardsPlayed)
            {
                eg += (int)e.Key + "," + e.Value + ";";
            }

            Helpfunctions.Instance.logg(og);
            Helpfunctions.Instance.logg(eg);
            if (writetobuffer)
            {
                Helpfunctions.Instance.writeToBuffer(og);
                Helpfunctions.Instance.writeToBuffer(eg);
            }
        }

        /// <summary>
        /// The print turn grave yard.
        /// </summary>
        /// <param name="writetobuffer">
        /// The writetobuffer.
        /// </param>
        public void printTurnGraveYard(bool writetobuffer = false)
        {
            /*string g = "";
            if (Probabilitymaker.Instance.feugenDead) g += " fgn";
            if (Probabilitymaker.Instance.stalaggDead) g += " stlgg";
            Helpfunctions.Instance.logg("GraveYard:" + g);
            if (writetobuffer) Helpfunctions.Instance.writeToBuffer("GraveYard:" + g);*/
            string s = "ownDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (gyi.own)
                {
                    s += gyi.cardid + "," + gyi.entity + ";";
                }
            }

            Helpfunctions.Instance.logg(s);
            if (writetobuffer)
            {
                Helpfunctions.Instance.writeToBuffer(s);
            }

            s = "enemyDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (!gyi.own)
                {
                    s += gyi.cardid + "," + gyi.entity + ";";
                }
            }

            Helpfunctions.Instance.logg(s);
            if (writetobuffer)
            {
                Helpfunctions.Instance.writeToBuffer(s);
            }
        }

        /// <summary>
        /// The read graveyards.
        /// </summary>
        /// <param name="owngrave">
        /// The owngrave.
        /// </param>
        /// <param name="enemygrave">
        /// The enemygrave.
        /// </param>
        public void readGraveyards(string owngrave, string enemygrave)
        {
            this.ownCardsPlayed.Clear();
            this.enemyCardsPlayed.Clear();
            string temp = owngrave.Replace("og: ", string.Empty);
            this.stalaggDead = false;
            this.feugenDead = false;
            foreach (string s in temp.Split(';'))
            {
                if (s == string.Empty || s == " ")
                {
                    continue;
                }

                string id = s.Split(',')[0];
                string anz = s.Split(',')[1];
                CardDB.cardIDEnum cdbe = (CardDB.cardIDEnum)Convert.ToInt32(id);
                this.ownCardsPlayed.Add(cdbe, Convert.ToInt32(anz));
                if (cdbe == CardDB.cardIDEnum.FP1_015)
                {
                    this.feugenDead = true;
                }

                if (cdbe == CardDB.cardIDEnum.FP1_014)
                {
                    this.stalaggDead = true;
                }
            }

            temp = enemygrave.Replace("eg: ", string.Empty);
            foreach (string s in temp.Split(';'))
            {
                if (s == string.Empty || s == " ")
                {
                    continue;
                }

                string id = s.Split(',')[0];
                string anz = s.Split(',')[1];
                CardDB.cardIDEnum cdbe = (CardDB.cardIDEnum)Convert.ToInt32(id);
                this.enemyCardsPlayed.Add(cdbe, Convert.ToInt32(anz));
                if (cdbe == CardDB.cardIDEnum.FP1_015)
                {
                    this.feugenDead = true;
                }

                if (cdbe == CardDB.cardIDEnum.FP1_014)
                {
                    this.stalaggDead = true;
                }
            }
        }

        /// <summary>
        /// The read turn grave yard.
        /// </summary>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="enemy">
        /// The enemy.
        /// </param>
        public void readTurnGraveYard(string own, string enemy)
        {
            this.turngraveyard.Clear();
            string temp = string.Empty;
            temp = own.Replace("ownDiedMinions: ", string.Empty);

            foreach (string s in temp.Split(';'))
            {
                if (s == string.Empty || s == " ")
                {
                    continue;
                }

                string id = s.Split(',')[0];
                string ent = s.Split(',')[1];
                GraveYardItem gyi = new GraveYardItem(
                    CardDB.Instance.cardIdstringToEnum(id), 
                    Convert.ToInt32(ent), 
                    true);
            }

            temp = enemy.Replace("enemyDiedMinions: ", string.Empty);

            foreach (string s in temp.Split(';'))
            {
                if (s == string.Empty || s == " ")
                {
                    continue;
                }

                string id = s.Split(',')[0];
                string ent = s.Split(',')[1];
                GraveYardItem gyi = new GraveYardItem(
                    CardDB.Instance.cardIdstringToEnum(id), 
                    Convert.ToInt32(ent), 
                    false);
            }
        }

        /// <summary>
        /// The set enemy cards.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        public void setEnemyCards(List<CardDB.cardIDEnum> list)
        {
            this.setupDeck(list, this.enemyDeckGuessed, this.enemyCardsPlayed);
        }

        /// <summary>
        /// The set enemy secret data.
        /// </summary>
        /// <param name="enemySecretl">
        /// The enemy secretl.
        /// </param>
        public void setEnemySecretData(List<SecretItem> enemySecretl)
        {
            this.enemySecrets.Clear();
            foreach (SecretItem si in enemySecretl)
            {
                this.enemySecrets.Add(new SecretItem(si));
            }
        }

        /// <summary>
        /// The set grave yard.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="turnStart">
        /// The turn start.
        /// </param>
        public void setGraveYard(List<GraveYardItem> list, bool turnStart)
        {
            this.graveyard.Clear();
            this.graveyard.AddRange(list);
            if (turnStart)
            {
                this.graveyartTillTurnStart.Clear();
                this.graveyartTillTurnStart.AddRange(list);
            }

            this.stalaggDead = false;
            this.feugenDead = false;
            this.turngraveyard.Clear();

            foreach (GraveYardItem en in list)
            {
                if (en.cardid == CardDB.cardIDEnum.FP1_015)
                {
                    this.feugenDead = true;
                }

                if (en.cardid == CardDB.cardIDEnum.FP1_014)
                {
                    this.stalaggDead = true;
                }

                bool found = false;

                foreach (GraveYardItem gyi in this.graveyartTillTurnStart)
                {
                    if (en.entity == gyi.entity)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (CardDB.Instance.getCardDataFromID(en.cardid).type == CardDB.cardtype.MOB)
                    {
                        this.turngraveyard.Add(en);
                    }
                }
            }
        }

        /// <summary>
        /// The set own cards.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        public void setOwnCards(List<CardDB.cardIDEnum> list)
        {
            this.setupDeck(list, this.ownDeckGuessed, this.ownCardsPlayed);
        }

        /// <summary>
        /// The set turn grave yard.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        public void setTurnGraveYard(List<GraveYardItem> list)
        {
            this.turngraveyard.Clear();
            this.turngraveyard.AddRange(list);
        }

        /// <summary>
        /// The update secret list.
        /// </summary>
        /// <param name="enemySecretl">
        /// The enemy secretl.
        /// </param>
        public void updateSecretList(List<SecretItem> enemySecretl)
        {
            List<SecretItem> temp = new List<SecretItem>();
            foreach (SecretItem si in this.enemySecrets)
            {
                bool add = false;
                SecretItem seit = null;
                foreach (SecretItem sit in enemySecretl)
                {
                    // enemySecrets have to be updated to latest entitys
                    if (si.entityId == sit.entityId)
                    {
                        seit = sit;
                        add = true;
                    }
                }

                if (add)
                {
                    temp.Add(new SecretItem(seit));
                }
                else
                {
                    temp.Add(new SecretItem(si));
                }
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(temp);
        }

        /// <summary>
        /// The update secret list.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="old">
        /// The old.
        /// </param>
        public void updateSecretList(Playfield p, Playfield old)
        {
            if (p.enemySecretCount == 0)
            {
                return;
            }

            bool usedspell = false;
            int lastEffectedIsMinion = 0; // 2 = minion, 1 = hero
            bool playedMob = false;
            bool enemyMinionDied = false;
            bool attackedWithMob = false;
            bool attackedWithHero = false;
            int attackTargetIsMinion = 0;
            bool enemyHeroGotDmg = false;

            Handmanager.Handcard hcard = null;
            if (p.cardsPlayedThisTurn > old.cardsPlayedThisTurn)
            {
                for (int i = 0; i < old.owncards.Count - 1; i++)
                {
                    if (p.owncards.Count - 1 >= i)
                    {
                        if (old.owncards[i].entity != p.owncards[i].entity)
                        {
                            hcard = old.owncards[i];
                            break;
                        }
                    }
                    else
                    {
                        hcard = old.owncards[i];
                        break;
                    }
                }

                if (hcard != null && hcard.card.type == CardDB.cardtype.SPELL)
                {
                    if (hcard.card.type == CardDB.cardtype.SPELL)
                    {
                        usedspell = true;
                    }

                    int entityOfLastAffected = Silverfish.getCardTarget(hcard.entity);
                    if (entityOfLastAffected >= 1)
                    {
                        lastEffectedIsMinion = 2;
                    }

                    if (entityOfLastAffected == p.enemyHero.entitiyID)
                    {
                        lastEffectedIsMinion = 1;
                    }
                }

                if (hcard != null && hcard.card.type == CardDB.cardtype.MOB)
                {
                    int entityOfLastAffected = Silverfish.getLastAffected(hcard.entity);
                    if (entityOfLastAffected >= 1)
                    {
                        lastEffectedIsMinion = 2;
                    }

                    if (entityOfLastAffected == p.enemyHero.entitiyID
                        && (p.enemyHero.Hp < old.enemyHero.Hp || p.enemyHero.immune))
                    {
                        lastEffectedIsMinion = 1;
                    }

                    entityOfLastAffected = Silverfish.getCardTarget(hcard.entity);
                    if (entityOfLastAffected >= 1)
                    {
                        lastEffectedIsMinion = 2;
                        if (entityOfLastAffected == p.enemyHero.entitiyID)
                        {
                            lastEffectedIsMinion = 1;
                        }
                    }
                }
            }

            if (p.mobsplayedThisTurn > old.mobsplayedThisTurn)
            {
                playedMob = true;
            }

            if (p.diedMinions != null && old.diedMinions != null)
            {
                int pcount = 0;
                int ocount = 0;
                foreach (GraveYardItem gyi in p.diedMinions)
                {
                    if (!gyi.own)
                    {
                        pcount++;
                    }
                }

                foreach (GraveYardItem gyi in old.diedMinions)
                {
                    if (!gyi.own)
                    {
                        ocount++;
                    }
                }

                if (pcount > ocount)
                {
                    enemyMinionDied = true;
                }
            }

            // attacked with mob?
            int newAttackers = 0;
            int oldAttackers = 0;
            foreach (Minion m in p.ownMinions)
            {
                newAttackers += m.numAttacksThisTurn;
            }

            foreach (Minion m in old.ownMinions)
            {
                oldAttackers += m.numAttacksThisTurn;
            }

            if (newAttackers > oldAttackers)
            {
                attackedWithMob = true;
            }

            if (p.ownHero.numAttacksThisTurn > old.ownHero.numAttacksThisTurn)
            {
                attackedWithHero = true;
            }

            if (p.enemyHero.Hp < old.enemyHero.Hp)
            {
                enemyHeroGotDmg = true;
            }

            if (attackedWithHero || attackedWithMob)
            {
                // check hero first, so we can exclude deathrattles!
                if (p.enemyHero.Hp < old.enemyHero.Hp)
                {
                    attackTargetIsMinion = 1;
                }

                int newDefenders = 0;
                int oldDefenders = 0;

                foreach (Minion m in p.ownMinions)
                {
                    newDefenders += m.Hp;
                }

                foreach (Minion m in old.ownMinions)
                {
                    oldDefenders += m.Hp;
                }

                if (newDefenders < oldDefenders)
                {
                    attackTargetIsMinion = 2;
                }
            }

            foreach (SecretItem si in this.enemySecrets)
            {
                if (attackedWithHero || attackedWithMob)
                {
                    si.usedTrigger_CharIsAttacked(attackTargetIsMinion == 1, attackedWithHero);
                }

                if (enemyHeroGotDmg)
                {
                    si.usedTrigger_HeroGotDmg();
                }

                if (enemyMinionDied)
                {
                    si.usedTrigger_MinionDied();
                }

                if (playedMob)
                {
                    si.usedTrigger_MinionIsPlayed();
                }

                if (usedspell)
                {
                    si.usedTrigger_SpellIsPlayed(lastEffectedIsMinion == 2);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The setup deck.
        /// </summary>
        /// <param name="cardsPlayed">
        /// The cards played.
        /// </param>
        /// <param name="deckGuessed">
        /// The deck guessed.
        /// </param>
        /// <param name="knownCards">
        /// The known cards.
        /// </param>
        private void setupDeck(
            List<CardDB.cardIDEnum> cardsPlayed, 
            List<CardDB.Card> deckGuessed, 
            Dictionary<CardDB.cardIDEnum, int> knownCards)
        {
            deckGuessed.Clear();
            knownCards.Clear();
            foreach (CardDB.cardIDEnum crdidnm in cardsPlayed)
            {
                if (crdidnm == CardDB.cardIDEnum.GAME_005)
                {
                    continue; // (im sure, he has no coins in his deck :D)
                }

                if (knownCards.ContainsKey(crdidnm))
                {
                    knownCards[crdidnm]++;
                }
                else
                {
                    if (CardDB.Instance.getCardDataFromID(crdidnm).rarity == 5)
                    {
                        // you cant own rare ones more than once!
                        knownCards.Add(crdidnm, 2);
                        continue;
                    }

                    knownCards.Add(crdidnm, 1);
                }
            }

            foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in knownCards)
            {
                if (kvp.Value == 1)
                {
                    deckGuessed.Add(CardDB.Instance.getCardDataFromID(kvp.Key));
                }
            }
        }

        #endregion
    }
}