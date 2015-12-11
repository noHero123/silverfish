namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public struct GraveYardItem
    {
        public bool own;
        public int entity;
        public CardDB.cardIDEnum cardid;

        public GraveYardItem(CardDB.cardIDEnum id, int entity, bool own)
        {
            this.own = own;
            this.cardid = id;
            this.entity = entity;
        }
    }

    public class SecretItem
    {
        public bool triggered = false;

        public bool canbeTriggeredWithAttackingHero = true;
        public bool canbeTriggeredWithAttackingMinion = true;
        public bool canbeTriggeredWithPlayingMinion = true;
        public bool canbeTriggeredWithKillingMinion = true;
        public bool canbeTriggeredWithHeroPower = true;



        public bool canBe_snaketrap = true;
        public bool canBe_snipe = true;
        public bool canBe_explosive = true;
        public bool canBe_freezing = true;
        public bool canBe_missdirection = true;

        public bool canBe_counterspell = true;
        public bool canBe_icebarrier = true;
        public bool canBe_iceblock = true;
        public bool canBe_mirrorentity = true;
        public bool canBe_spellbender = true;
        public bool canBe_vaporize = true;
        public bool canBe_duplicate = true;

        public bool canBe_eyeforaneye = true;
        public bool canBe_noblesacrifice = true;
        public bool canBe_redemption = true;
        public bool canBe_repentance = true;
        public bool canBe_avenge = true;
        

        //new TGT---
        public bool canBe_effigy = true;
        public bool canBe_beartrap = true;
        public bool canBe_competivespirit = true;

        // LOE
        public bool canBe_Trial = true;
        public bool canBe_Dart = true;//hunter

        public int entityId = 0;

        public SecretItem()
        {
        }

        public SecretItem(SecretItem sec)
        {
            this.triggered = sec.triggered;
            this.canbeTriggeredWithAttackingHero = sec.canbeTriggeredWithAttackingHero;
            this.canbeTriggeredWithAttackingMinion = sec.canbeTriggeredWithAttackingMinion;
            this.canbeTriggeredWithPlayingMinion = sec.canbeTriggeredWithPlayingMinion;
            this.canbeTriggeredWithKillingMinion = sec.canbeTriggeredWithKillingMinion;
            this.canbeTriggeredWithHeroPower = sec.canbeTriggeredWithHeroPower;

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

            this.canBe_effigy = sec.canBe_effigy;
            this.canBe_beartrap = sec.canBe_beartrap;
            this.canBe_competivespirit = sec.canBe_competivespirit;

            this.canBe_Trial = sec.canBe_Trial;
            this.canBe_Dart = sec.canBe_Dart;

            this.entityId = sec.entityId;

        }

        public SecretItem(string secdata)
        {
            this.entityId = Convert.ToInt32(secdata.Split('.')[0]);

            string canbe = secdata.Split('.')[1];
            if (canbe.Length < 17)
            {
                Helpfunctions.Instance.ErrorLog("cant read secret " + secdata + " " + canbe.Length);
            }

            this.canBe_snaketrap = (canbe[0] == '1');
            this.canBe_snipe = (canbe[1] == '1');
            this.canBe_explosive = (canbe[2] == '1');
            this.canBe_freezing = (canbe[3] == '1');
            this.canBe_missdirection = (canbe[4] == '1');

            this.canBe_counterspell = (canbe[5] == '1');
            this.canBe_icebarrier = (canbe[6] == '1');
            this.canBe_iceblock = (canbe[7] == '1');
            this.canBe_mirrorentity = (canbe[8] == '1');
            this.canBe_spellbender = (canbe[9] == '1');
            this.canBe_vaporize = (canbe[10] == '1');
            this.canBe_duplicate = (canbe[11] == '1');

            this.canBe_eyeforaneye = (canbe[12] == '1');
            this.canBe_noblesacrifice = (canbe[13] == '1');
            this.canBe_redemption = (canbe[14] == '1');
            this.canBe_repentance = (canbe[15] == '1');
            this.canBe_avenge = (canbe[16] == '1');

            //update TGT
            try
            {
                this.canBe_effigy = (canbe[17] == '1');
                this.canBe_beartrap = (canbe[18] == '1');
                this.canBe_competivespirit = (canbe[19] == '1');
            }
            catch
            {
                this.canBe_effigy = false;
                this.canBe_beartrap = false;
                this.canBe_competivespirit = false;
            }

            try
            {
                this.canBe_Trial = (canbe[20] == '1');
                this.canBe_Dart = (canbe[21] == '1');
            }
            catch
            {
                this.canBe_Trial = false;
                this.canBe_Dart = false;
            }

            this.updateCanBeTriggered();
        }

        public void updateCanBeTriggered()
        {
            this.canbeTriggeredWithAttackingHero = false;
            this.canbeTriggeredWithAttackingMinion = false;
            this.canbeTriggeredWithPlayingMinion = false;
            this.canbeTriggeredWithKillingMinion = false;
            this.canbeTriggeredWithHeroPower = false;
            

            if (this.canBe_snipe || this.canBe_mirrorentity || this.canBe_repentance) this.canbeTriggeredWithPlayingMinion = true;

            if (this.canBe_explosive || this.canBe_missdirection || this.canBe_freezing || this.canBe_icebarrier || this.canBe_vaporize || this.canBe_noblesacrifice || this.canBe_beartrap) this.canbeTriggeredWithAttackingHero = true;

            if (this.canBe_snaketrap || this.canBe_freezing || this.canBe_noblesacrifice || this.canBe_Trial) this.canbeTriggeredWithAttackingMinion = true;

            if (this.canBe_avenge || this.canBe_redemption || this.canBe_duplicate || this.canBe_effigy) this.canbeTriggeredWithKillingMinion = true;

            if (this.canBe_Dart) this.canbeTriggeredWithHeroPower = true;


        }

        public void usedTrigger_CharIsAttacked(bool DefenderIsHero, bool AttackerIsHero)
        {
            if (DefenderIsHero)
            {
                this.canBe_explosive = false;
                this.canBe_missdirection = false;

                this.canBe_icebarrier = false;
                this.canBe_vaporize = false;

                this.canBe_beartrap = false;

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
            updateCanBeTriggered();
        }

        public void usedTrigger_MinionIsPlayed(int numberMinionsOnBoard)
        {
            this.canBe_snipe = false;
            this.canBe_mirrorentity = false;
            this.canBe_repentance = false;
            if (numberMinionsOnBoard >= 3) this.canBe_Trial = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_SpellIsPlayed(bool minionIsTarget)
        {
            this.canBe_counterspell = false;
            if (minionIsTarget) this.canBe_spellbender = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_MinionDied()
        {
            this.canBe_avenge = false;
            this.canBe_redemption = false;
            this.canBe_duplicate = false;
            this.canBe_effigy = false;

            updateCanBeTriggered();
        }

        public void usedTrigger_HeroGotDmg(bool deadly = false)
        {
            this.canBe_eyeforaneye = false;
            if (deadly) this.canBe_iceblock = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_EndTurn()
        {

            this.canBe_competivespirit = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_HeroPower()
        {

            this.canBe_Dart = false;
            updateCanBeTriggered();
        }

        public string returnAString()
        {
            string retval = "" + this.entityId + ".";
            retval += "" + ((canBe_snaketrap) ? "1" : "0");
            retval += "" + ((canBe_snipe) ? "1" : "0");
            retval += "" + ((canBe_explosive) ? "1" : "0");
            retval += "" + ((canBe_freezing) ? "1" : "0");
            retval += "" + ((canBe_missdirection) ? "1" : "0");

            retval += "" + ((canBe_counterspell) ? "1" : "0");
            retval += "" + ((canBe_icebarrier) ? "1" : "0");
            retval += "" + ((canBe_iceblock) ? "1" : "0");
            retval += "" + ((canBe_mirrorentity) ? "1" : "0");
            retval += "" + ((canBe_spellbender) ? "1" : "0");
            retval += "" + ((canBe_vaporize) ? "1" : "0");
            retval += "" + ((canBe_duplicate) ? "1" : "0");

            retval += "" + ((canBe_eyeforaneye) ? "1" : "0");
            retval += "" + ((canBe_noblesacrifice) ? "1" : "0");
            retval += "" + ((canBe_redemption) ? "1" : "0");
            retval += "" + ((canBe_repentance) ? "1" : "0");
            retval += "" + ((canBe_avenge) ? "1" : "0");

            retval += "" + ((canBe_effigy) ? "1" : "0");
            retval += "" + ((canBe_beartrap) ? "1" : "0");
            retval += "" + ((canBe_competivespirit) ? "1" : "0");

            retval += "" + ((canBe_Trial) ? "1" : "0");

            retval += "" + ((this.canBe_Dart) ? "1" : "0");

            return retval + ",";
        }

        public bool isEqual(SecretItem s)
        {
            bool result = this.entityId == s.entityId;
            result = result && this.canBe_avenge == s.canBe_avenge && this.canBe_counterspell == s.canBe_counterspell && this.canBe_duplicate == s.canBe_duplicate && this.canBe_explosive == s.canBe_explosive;
            result = result && this.canBe_eyeforaneye == s.canBe_eyeforaneye && this.canBe_freezing == s.canBe_freezing && this.canBe_icebarrier == s.canBe_icebarrier && this.canBe_iceblock == s.canBe_iceblock;
            result = result && this.canBe_mirrorentity == s.canBe_mirrorentity && this.canBe_missdirection == s.canBe_missdirection && this.canBe_noblesacrifice == s.canBe_noblesacrifice && this.canBe_redemption == s.canBe_redemption;
            result = result && this.canBe_repentance == s.canBe_repentance && this.canBe_snaketrap == s.canBe_snaketrap && this.canBe_snipe == s.canBe_snipe && this.canBe_spellbender == s.canBe_spellbender && this.canBe_vaporize == s.canBe_vaporize;
            result = result && this.canBe_effigy == s.canBe_effigy && this.canBe_beartrap == s.canBe_beartrap && this.canBe_competivespirit == s.canBe_competivespirit;
            result = result && this.canBe_Trial == s.canBe_Trial;

            result = result && this.canBe_Dart == s.canBe_Dart;

            return result;
        }

    }

    public class Probabilitymaker
    {
        public bool hasDeck = false;

        public Dictionary<CardDB.cardIDEnum, int> ownCardsPlayed = new Dictionary<CardDB.cardIDEnum, int>();
        public Dictionary<CardDB.cardIDEnum, int> enemyCardsPlayed = new Dictionary<CardDB.cardIDEnum, int>();
        List<CardDB.Card> ownDeckGuessed = new List<CardDB.Card>();
        List<CardDB.Card> enemyDeckGuessed = new List<CardDB.Card>();
        List<GraveYardItem> graveyard = new List<GraveYardItem>();
        public List<GraveYardItem> turngraveyard = new List<GraveYardItem>();//MOBS only
        List<GraveYardItem> graveyartTillTurnStart = new List<GraveYardItem>();

        public List<SecretItem> enemySecrets = new List<SecretItem>();

        public int ownGraveYardCommonAttack = 0;
        public int ownGraveYardCommonHP = 0;
        public int ownGraveYardCommonTaunt = 0;

        public int enemyGraveYardCommonAttack = 0;
        public int enemyGraveYardCommonHP = 0;
        public int enemyGraveYardCommonTaunt = 0;

        public int anzMinionSinGrave = 0;

        public bool feugenDead = false;
        public bool stalaggDead = false;

        private static Probabilitymaker instance;
        public static Probabilitymaker Instance
        {
            get
            {
                return instance ?? (instance = new Probabilitymaker());
            }
        }

        private Probabilitymaker()
        {

        }

        public void setOwnCards(List<CardDB.cardIDEnum> list)
        {
            setupDeck(list, ownDeckGuessed, ownCardsPlayed);
        }

        public void setEnemyCards(List<CardDB.cardIDEnum> list)
        {
            setupDeck(list, enemyDeckGuessed, enemyCardsPlayed);
        }

        public string printTurnGraveYard(bool writetobuffer = false, bool dontwrite=false)
        {
            /*string g = "";
            if (Probabilitymaker.Instance.feugenDead) g += " fgn";
            if (Probabilitymaker.Instance.stalaggDead) g += " stlgg";
            Helpfunctions.Instance.logg("GraveYard:" + g);
            if (writetobuffer) Helpfunctions.Instance.writeToBuffer("GraveYard:" + g);*/

            string data = "";
            string s = "ownDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }

            if (!dontwrite)
            {
                Helpfunctions.Instance.logg(s);
                if (writetobuffer) Helpfunctions.Instance.writeToBuffer(s);
            }

            data += s + "\r\n";

            s = "enemyDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (!gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }

            if (!dontwrite)
            {
                Helpfunctions.Instance.logg(s);
                if (writetobuffer) Helpfunctions.Instance.writeToBuffer(s);
            }

            data += s + "\r\n";
            return data;
        }

        public void readTurnGraveYard(string own, string enemy)
        {
            this.turngraveyard.Clear();
            string temp = "";
            temp = own.Replace("ownDiedMinions: ", "");

            foreach (string s in temp.Split(';'))
            {
                if (s == "" || s == " ") continue;
                string id = s.Split(',')[0];
                string ent = s.Split(',')[1];
                GraveYardItem gyi = new GraveYardItem(CardDB.Instance.cardIdstringToEnum(id), Convert.ToInt32(ent), true);
            }

            temp = enemy.Replace("enemyDiedMinions: ", "");

            foreach (string s in temp.Split(';'))
            {
                if (s == "" || s == " ") continue;
                string id = s.Split(',')[0];
                string ent = s.Split(',')[1];
                GraveYardItem gyi = new GraveYardItem(CardDB.Instance.cardIdstringToEnum(id), Convert.ToInt32(ent), false);
            }

        }

        public void setGraveYard(List<GraveYardItem> list, bool turnStart)
        {
            graveyard.Clear();
            graveyard.AddRange(list);
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

        public void setTurnGraveYard(List<GraveYardItem> list)
        {
            this.turngraveyard.Clear();
            this.turngraveyard.AddRange(list);
        }

        private void setupDeck(List<CardDB.cardIDEnum> cardsPlayed, List<CardDB.Card> deckGuessed, Dictionary<CardDB.cardIDEnum, int> knownCards)
        {
            deckGuessed.Clear();
            knownCards.Clear();
            foreach (CardDB.cardIDEnum crdidnm in cardsPlayed)
            {
                if (crdidnm == CardDB.cardIDEnum.GAME_005) continue; //(im sure, he has no coins in his deck :D)
                if (knownCards.ContainsKey(crdidnm))
                {
                    knownCards[crdidnm]++;
                }
                else
                {
                    if (CardDB.Instance.getCardDataFromID(crdidnm).rarity == 5)
                    {
                        //you cant own rare ones more than once!
                        knownCards.Add(crdidnm, 2);
                        continue;
                    }
                    knownCards.Add(crdidnm, 1);
                }
            }

            foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in knownCards)
            {
                if (kvp.Value == 1) deckGuessed.Add(CardDB.Instance.getCardDataFromID(kvp.Key));
            }
        }

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

        public int anzCardsInDeck(CardDB.cardIDEnum cardid)
        {
            int ret = 2;
            CardDB.Card c = CardDB.Instance.getCardDataFromID(cardid);
            if (c.rarity == 5) ret = 1;//you can have only one rare;

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

        public string printGraveyards(bool writetobuffer = false, bool dontwrite = false)
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
            if (!dontwrite)
            {
                Helpfunctions.Instance.logg(og);
                Helpfunctions.Instance.logg(eg);
                if (writetobuffer)
                {
                    Helpfunctions.Instance.writeToBuffer(og);
                    Helpfunctions.Instance.writeToBuffer(eg);
                }
            }
            return og + "\r\n" + eg + "\r\n";
        }

        public void readGraveyards(string owngrave, string enemygrave)
        {
            this.ownCardsPlayed.Clear();
            this.enemyCardsPlayed.Clear();
            string temp = owngrave.Replace("og: ", "");
            this.stalaggDead = false;
            this.feugenDead = false;

            double tempattack = 0;
            double temphp = 0;
            int tempamount = 0;
            int temptaunt = 0;
            foreach (string s in temp.Split(';'))
            {
                string ss = s.Replace(" ", "");
                if (ss == "" || ss == " ") continue;
                string id = ss.Split(',')[0];
                int anz = Convert.ToInt32(ss.Split(',')[1]);
                CardDB.cardIDEnum cdbe = CardDB.cardIDEnum.None;
                try
                {
                    cdbe = (CardDB.cardIDEnum)Convert.ToInt32(id);
                }
                catch
                {
                    
                }
                if (cdbe == CardDB.cardIDEnum.None)
                {
                    try
                    {
                        cdbe = CardDB.Instance.cardIdstringToEnum(id);
                    }
                    catch
                    {

                    }
                }
                this.ownCardsPlayed.Add(cdbe, anz);
                if (cdbe == CardDB.cardIDEnum.FP1_015)
                {
                    this.feugenDead = true;
                }
                if (cdbe == CardDB.cardIDEnum.FP1_014) this.stalaggDead = true;

                CardDB.Card tempcard = CardDB.Instance.getCardDataFromID(cdbe);
                if (tempcard.type == CardDB.cardtype.MOB)
                {
                    this.anzMinionSinGrave++;
                    tempamount++;
                    tempattack += tempcard.Attack * anz;
                    temphp += tempcard.Health * anz;
                    if (tempcard.tank) temptaunt += anz;
                }
            }
            this.ownGraveYardCommonAttack = 0;
            this.ownGraveYardCommonAttack = 0;
            this.ownGraveYardCommonTaunt = 0;
            if(tempamount>=1)
            {
            this.ownGraveYardCommonAttack =  (int)(tempattack / tempamount);
            this.ownGraveYardCommonAttack = (int)(temphp / tempamount);
            if (2 * temptaunt >= tempamount) this.ownGraveYardCommonTaunt = 1;
            }

            tempamount = 0;
            tempattack = 0;
            temphp = 0;
            temptaunt = 0;

            temp = enemygrave.Replace("eg: ", "");
            foreach (string s in temp.Split(';'))
            {
                string ss = s.Replace(" ", "");
                if (ss == "" || ss == " ") continue;
                string id = ss.Split(',')[0];
                int anz = Convert.ToInt32(ss.Split(',')[1]);
                CardDB.cardIDEnum cdbe = CardDB.cardIDEnum.None;
                try
                {
                    cdbe = (CardDB.cardIDEnum)Convert.ToInt32(id);
                }
                catch
                {
 
                }

                if (cdbe == CardDB.cardIDEnum.None)
                {
                    try
                    {
                        cdbe = CardDB.Instance.cardIdstringToEnum(id);
                    }
                    catch
                    {

                    }
                }

                this.enemyCardsPlayed.Add(cdbe, anz);
                if (cdbe == CardDB.cardIDEnum.FP1_015) this.feugenDead = true;
                if (cdbe == CardDB.cardIDEnum.FP1_014) this.stalaggDead = true;

                CardDB.Card tempcard = CardDB.Instance.getCardDataFromID(cdbe);
                if (tempcard.type == CardDB.cardtype.MOB)
                {
                    tempamount++;
                    tempattack += tempcard.Attack * anz;
                    temphp += tempcard.Health * anz;
                    if (tempcard.tank) temptaunt += anz;
                }

            }

            this.enemyGraveYardCommonAttack = 0;
            this.enemyGraveYardCommonHP = 0;
            this.enemyGraveYardCommonTaunt = 0;
            if (tempamount >= 1)
            {
                this.enemyGraveYardCommonAttack = (int)(tempattack / tempamount);
                this.enemyGraveYardCommonHP = (int)(temphp / tempamount);
                if (2 * temptaunt >= tempamount) this.enemyGraveYardCommonTaunt = 1;
            }

        }

        public int getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum cardid, int handsize, int decksize)
        {
            //calculates probability \in [0,...,100]


            int cardsremaining = this.anzCardsInDeck(cardid);
            if (cardsremaining == 0) return 0;

            foreach (CardDB.cardIDEnum playedcard in this.enemyCardsPlayed.Keys)
            {
                handsize += this.enemyCardsPlayed[playedcard];
                if (CardDB.Instance.getCardDataFromID(playedcard).rarity == 5)
                    handsize -= 1;  // don't doublecount legendaries like the dictionary does
            }

            double retval = 0.0;
            //http://de.wikipedia.org/wiki/Hypergeometrische_Verteilung (we calculte 1-p(x=0))

            if (cardsremaining == 1)
            {
                retval = 1.0 - ((double)(decksize)) / ((double)(decksize + handsize));
            }
            else
            {
                retval = 1.0 - ((double)(decksize * (decksize - 1))) / ((double)((decksize + handsize) * (decksize + handsize - 1)));
            }

            retval = Math.Min(retval, 1.0);

            return (int)(100.0 * retval);
        }

        public bool hasCardinGraveyard(CardDB.cardIDEnum cardid)
        {
            foreach (GraveYardItem gyi in this.graveyard)
            {
                if (gyi.cardid == cardid) return true;
            }
            return false;
        }

        public void getEnemySecretGuesses(List<int> enemySecretIds, HeroEnum enemyHeroName)
        {
            List<SecretItem> newlist = new List<SecretItem>();

            foreach (int i in enemySecretIds)
            {
                if (i >= 1000) continue;
                Helpfunctions.Instance.logg("detect secret with id" + i);
                SecretItem sec = getNewSecretGuessedItem(i, enemyHeroName);

                newlist.Add(new SecretItem(sec));
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(newlist);
        }

        public SecretItem getNewSecretGuessedItem(int entityid, HeroEnum enemyHeroName)
        {
            foreach (SecretItem si in this.enemySecrets)
            {
                if (si.entityId == entityid && entityid < 1000) return si;
            }

            SecretItem sec = new SecretItem { entityId = entityid };
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

                sec.canBe_competivespirit = false;
                sec.canBe_effigy = false;

                sec.canBe_Trial = false;
                


                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_554) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_554] >= 2)
                {
                    sec.canBe_snaketrap = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_609) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_609] >= 2)
                {
                    sec.canBe_snipe = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_610) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_610] >= 2)
                {
                    sec.canBe_explosive = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_611) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_611] >= 2)
                {
                    sec.canBe_freezing = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_533) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_533] >= 2)
                {
                    sec.canBe_missdirection = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.AT_060) && enemyCardsPlayed[CardDB.cardIDEnum.AT_060] >= 2)
                {
                    sec.canBe_beartrap = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.LOE_021) && enemyCardsPlayed[CardDB.cardIDEnum.LOE_021] >= 2)
                {
                    sec.canBe_Dart = false;
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

                sec.canBe_competivespirit = false;
                sec.canBe_beartrap = false;

                sec.canBe_Trial = false;
                sec.canBe_Dart = false;

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_287) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_287] >= 2)
                {
                    sec.canBe_counterspell = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_289) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_289] >= 2)
                {
                    sec.canBe_icebarrier = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_295) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_295] >= 2)
                {
                    sec.canBe_iceblock = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_294) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_294] >= 2)
                {
                    sec.canBe_mirrorentity = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.tt_010) && enemyCardsPlayed[CardDB.cardIDEnum.tt_010] >= 2)
                {
                    sec.canBe_spellbender = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_594) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_594] >= 2)
                {
                    sec.canBe_vaporize = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.FP1_018) && enemyCardsPlayed[CardDB.cardIDEnum.FP1_018] >= 2)
                {
                    sec.canBe_duplicate = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.AT_002) && enemyCardsPlayed[CardDB.cardIDEnum.AT_002] >= 2)
                {
                    sec.canBe_effigy = false;
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

                sec.canBe_effigy = false;
                sec.canBe_beartrap = false;
                sec.canBe_Dart = false;



                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_132) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_132] >= 2)
                {
                    sec.canBe_eyeforaneye = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_130) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_130] >= 2)
                {
                    sec.canBe_noblesacrifice = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_136) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_136] >= 2)
                {
                    sec.canBe_redemption = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.EX1_379) && enemyCardsPlayed[CardDB.cardIDEnum.EX1_379] >= 2)
                {
                    sec.canBe_repentance = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.FP1_020) && enemyCardsPlayed[CardDB.cardIDEnum.FP1_020] >= 2)
                {
                    sec.canBe_avenge = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.AT_073) && enemyCardsPlayed[CardDB.cardIDEnum.AT_073] >= 2)
                {
                    sec.canBe_competivespirit = false;
                }

                if (enemyCardsPlayed.ContainsKey(CardDB.cardIDEnum.LOE_027) && enemyCardsPlayed[CardDB.cardIDEnum.LOE_027] >= 2)
                {
                    sec.canBe_Trial = false;
                }

            }

            return sec;
        }

        public string getEnemySecretData()
        {
            string retval = "";
            foreach (SecretItem si in this.enemySecrets)
            {

                retval += si.returnAString();
            }

            return retval;
        }

        public string getEnemySecretData(List<SecretItem> list)
        {
            string retval = "";
            foreach (SecretItem si in list)
            {

                retval += si.returnAString();
            }

            return retval;
        }


        public void setEnemySecretData(List<SecretItem> enemySecretl)
        {
            this.enemySecrets.Clear();
            foreach (SecretItem si in enemySecretl)
            {
                this.enemySecrets.Add(new SecretItem(si));
            }
        }

        public void updateSecretList(List<SecretItem> enemySecretl)
        {
            List<SecretItem> temp = new List<SecretItem>();
            foreach (SecretItem si in this.enemySecrets)
            {
                bool add = false;
                SecretItem seit = null;
                foreach (SecretItem sit in enemySecretl) // enemySecrets have to be updated to latest entitys
                {
                    if (si.entityId == sit.entityId)
                    {
                        seit = sit;
                        add = true;
                    }
                }

                temp.Add(add ? new SecretItem(seit) : new SecretItem(si));
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(temp);

        }

        public void updateSecretList(Playfield p, Playfield old)
        {
            if (p.enemySecretCount == 0) return;

            bool usedspell = false;
            int lastEffectedIsMinion = 0; //2 = minion, 1 = hero
            bool playedMob = false;
            bool enemyMinionDied = false;
            bool attackedWithMob = false;
            bool attackedWithHero = false;
            int attackTargetIsMinion = 0;
            bool enemyHeroGotDmg = false;
            int minionsOnBoard = old.enemyMinions.Count;
            bool endedTurn = false;
            bool usedHeropower = false;

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
                    if (hcard.card.type == CardDB.cardtype.SPELL) usedspell = true;
                    int entityOfLastAffected = Silverfish.getCardTarget(hcard.entity);
                    if (entityOfLastAffected >= 1) lastEffectedIsMinion = 2;
                    if (entityOfLastAffected == p.enemyHero.entitiyID) lastEffectedIsMinion = 1;
                }

                if (hcard != null && hcard.card.type == CardDB.cardtype.MOB)
                {
                    int entityOfLastAffected = Silverfish.getLastAffected(hcard.entity);
                    if (entityOfLastAffected >= 1) lastEffectedIsMinion = 2;
                    if (entityOfLastAffected == p.enemyHero.entitiyID && (p.enemyHero.Hp < old.enemyHero.Hp || p.enemyHero.immune)) lastEffectedIsMinion = 1;

                    entityOfLastAffected = Silverfish.getCardTarget(hcard.entity);
                    if (entityOfLastAffected >= 1)
                    {
                        lastEffectedIsMinion = 2;
                        if (entityOfLastAffected == p.enemyHero.entitiyID) lastEffectedIsMinion = 1;
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
                    if (!gyi.own) pcount++;
                }
                foreach (GraveYardItem gyi in old.diedMinions)
                {
                    if (!gyi.own) ocount++;
                }
                if (pcount > ocount) enemyMinionDied = true;
            }

            //used heropower?
            if (old.own_TIMES_HERO_POWER_USED_THIS_GAME < p.own_TIMES_HERO_POWER_USED_THIS_GAME)
            {
                usedHeropower = true;
            }

            //attacked with mob?

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

            if (newAttackers > oldAttackers) attackedWithMob = true;

            if (p.ownHero.numAttacksThisTurn > old.ownHero.numAttacksThisTurn) attackedWithHero = true;

            if (p.enemyHero.Hp < old.enemyHero.Hp) enemyHeroGotDmg = true;

            if (attackedWithHero || attackedWithMob)
            {
                //check hero first, so we can exclude deathrattles!
                if (p.enemyHero.Hp < old.enemyHero.Hp) attackTargetIsMinion = 1;

                int newDefenders = 0; int oldDefenders = 0;

                foreach (Minion m in p.ownMinions)
                {
                    newDefenders += m.Hp;
                }
                foreach (Minion m in old.ownMinions)
                {
                    oldDefenders += m.Hp;
                }

                if (newDefenders < oldDefenders) attackTargetIsMinion = 2;
            }

            if (old.optionsPlayedThisTurn >= 0 && p.optionsPlayedThisTurn == 0) endedTurn = true;

            foreach (SecretItem si in this.enemySecrets)
            {

                if (attackedWithHero || attackedWithMob) si.usedTrigger_CharIsAttacked(attackTargetIsMinion == 1, attackedWithHero);

                if (enemyHeroGotDmg) si.usedTrigger_HeroGotDmg();

                if (enemyMinionDied) si.usedTrigger_MinionDied();

                if (playedMob) si.usedTrigger_MinionIsPlayed(minionsOnBoard);

                if (usedspell) si.usedTrigger_SpellIsPlayed(lastEffectedIsMinion == 2);

                if (endedTurn) si.usedTrigger_EndTurn();

                if (usedHeropower) si.usedTrigger_HeroPower();

            }
        }

    }

}