namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.IO;


    public class ComboBreaker
    {

        enum combotype
        {
            combo,
            target,
            weaponuse
        }

        private Dictionary<CardDB.cardIDEnum, int> playByValue = new Dictionary<CardDB.cardIDEnum, int>();

        private List<combo> combos = new List<combo>();
        private static ComboBreaker instance;

        Handmanager hm = Handmanager.Instance;
        Hrtprozis hp = Hrtprozis.Instance;

        public int attackFaceHP = -1;


        class combo
        {
            public combotype type = combotype.combo;
            public int neededMana = 0;
            public Dictionary<CardDB.cardIDEnum, int> combocards = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> cardspen = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> combocardsTurn0Mobs = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> combocardsTurn0All = new Dictionary<CardDB.cardIDEnum, int>();
            public Dictionary<CardDB.cardIDEnum, int> combocardsTurn1 = new Dictionary<CardDB.cardIDEnum, int>();
            public int penality = 0;
            public int combolength = 0;
            public int combot0len = 0;
            public int combot1len = 0;
            public int combot0lenAll = 0;
            public bool twoTurnCombo = false;
            public int bonusForPlaying = 0;
            public int bonusForPlayingT0 = 0;
            public int bonusForPlayingT1 = 0;
            public CardDB.cardName requiredWeapon = CardDB.cardName.unknown;
            public HeroEnum oHero = HeroEnum.None;

            public combo(string s)
            {
                int i = 0;
                this.neededMana = 0;
                requiredWeapon = CardDB.cardName.unknown;
                this.type = combotype.combo;
                this.twoTurnCombo = false;
                bool fixmana = false;
                if (s.Contains("nxttrn")) this.twoTurnCombo = true;
                if (s.Contains("mana:")) fixmana = true;

                /*foreach (string ding in s.Split(':'))
                {
                    if (i == 0)
                    {
                        if (ding == "c") this.type = combotype.combo;
                        if (ding == "t") this.type = combotype.target;
                        if (ding == "w") this.type = combotype.weaponuse;
                    }
                    if (ding == "" || ding == string.Empty) continue;

                    if (i == 1 && type == combotype.combo)
                    {
                        int m = Convert.ToInt32(ding);
                        neededMana = -1;
                        if (m >= 1) neededMana = m;
                    }
                */
                if (type == combotype.combo)
                {
                    this.combolength = 0;
                    this.combot0len = 0;
                    this.combot1len = 0;
                    this.combot0lenAll = 0;
                    int manat0 = 0;
                    int manat1 = -1;
                    bool t1 = false;
                    foreach (string crdl in s.Split(';')) //ding.Split
                    {
                        if (crdl == "" || crdl == string.Empty) continue;
                        if (crdl == "nxttrn")
                        {
                            t1 = true;
                            continue;
                        }
                        if (crdl.StartsWith("mana:"))
                        {
                            this.neededMana = Convert.ToInt32(crdl.Replace("mana:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("hero:"))
                        {
                            this.oHero = Hrtprozis.Instance.heroNametoEnum(crdl.Replace("hero:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonus:"))
                        {
                            this.bonusForPlaying = Convert.ToInt32(crdl.Replace("bonus:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonusfirst:"))
                        {
                            this.bonusForPlayingT0 = Convert.ToInt32(crdl.Replace("bonusfirst:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonussecond:"))
                        {
                            this.bonusForPlayingT1 = Convert.ToInt32(crdl.Replace("bonussecond:", ""));
                            continue;
                        }
                        string crd = crdl.Split(',')[0];
                        if (t1)
                        {
                            manat1 += CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(crd)).cost;
                        }
                        else
                        {
                            manat0 += CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(crd)).cost;
                        }
                        this.combolength++;

                        if (combocards.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                        {
                            combocards[CardDB.Instance.cardIdstringToEnum(crd)]++;
                        }
                        else
                        {
                            combocards.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                            cardspen.Add(CardDB.Instance.cardIdstringToEnum(crd), Convert.ToInt32(crdl.Split(',')[1]));
                        }

                        if (this.twoTurnCombo)
                        {

                            if (t1)
                            {
                                if (this.combocardsTurn1.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                                {
                                    combocardsTurn1[CardDB.Instance.cardIdstringToEnum(crd)]++;
                                }
                                else
                                {
                                    combocardsTurn1.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                                }
                                this.combot1len++;
                            }
                            else
                            {
                                CardDB.Card lolcrd = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(crd));
                                if (lolcrd.type == CardDB.cardtype.MOB)
                                {
                                    if (this.combocardsTurn0Mobs.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                                    {
                                        combocardsTurn0Mobs[CardDB.Instance.cardIdstringToEnum(crd)]++;
                                    }
                                    else
                                    {
                                        combocardsTurn0Mobs.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                                    }
                                    this.combot0len++;
                                }
                                if (lolcrd.type == CardDB.cardtype.WEAPON)
                                {
                                    this.requiredWeapon = lolcrd.name;
                                }
                                if (this.combocardsTurn0All.ContainsKey(CardDB.Instance.cardIdstringToEnum(crd)))
                                {
                                    combocardsTurn0All[CardDB.Instance.cardIdstringToEnum(crd)]++;
                                }
                                else
                                {
                                    combocardsTurn0All.Add(CardDB.Instance.cardIdstringToEnum(crd), 1);
                                }
                                this.combot0lenAll++;
                            }
                        }


                    }
                    if (!fixmana)
                    {
                        this.neededMana = Math.Max(manat1, manat0);
                    }
                }

                /*if (i == 2 && type == combotype.combo)
                {
                    int m = Convert.ToInt32(ding);
                    penality = 0;
                    if (m >= 1) penality = m;
                }

                i++;
            }*/
                this.bonusForPlaying = Math.Max(bonusForPlaying, 1);
                this.bonusForPlayingT0 = Math.Max(bonusForPlayingT0, 1);
                this.bonusForPlayingT1 = Math.Max(bonusForPlayingT1, 1);
            }

            public int isInCombo(List<Handmanager.Handcard> hand, int omm)
            {
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocards);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }
                if (cardsincombo == this.combolength && omm < this.neededMana) return 1;
                if (cardsincombo == this.combolength) return 2;
                if (cardsincombo >= 1) return 1;
                return 0;
            }

            public int isMultiTurnComboTurn1(List<Handmanager.Handcard> hand, int omm, List<Minion> ownmins, CardDB.cardName weapon)
            {
                if (!twoTurnCombo) return 0;
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn1);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }
                if (cardsincombo == this.combot1len && omm < this.neededMana) return 1;

                if (cardsincombo == this.combot1len)
                {
                    //search for required minions on field
                    int turn0requires = 0;
                    foreach (CardDB.cardIDEnum s in combocardsTurn0Mobs.Keys)
                    {
                        foreach (Minion m in ownmins)
                        {
                            if (!m.playedThisTurn && m.handcard.card.cardIDenum == s)
                            {
                                turn0requires++;
                                break;
                            }
                        }
                    }

                    if (requiredWeapon != CardDB.cardName.unknown && requiredWeapon != weapon) return 1;

                    if (turn0requires >= combot0len) return 2;

                    return 1;
                }
                if (cardsincombo >= 1) return 1;
                return 0;
            }

            public int isMultiTurnComboTurn0(List<Handmanager.Handcard> hand, int omm)
            {
                if (!twoTurnCombo) return 0;
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn0All);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }
                if (cardsincombo == this.combot0lenAll && omm < this.neededMana) return 1;

                if (cardsincombo == this.combot0lenAll)
                {
                    return 2;
                }
                if (cardsincombo >= 1) return 1;
                return 0;
            }


            public bool isMultiTurn1Card(CardDB.Card card)
            {
                if (this.combocardsTurn1.ContainsKey(card.cardIDenum))
                {
                    return true;
                }
                return false;
            }

            public bool isCardInCombo(CardDB.Card card)
            {
                if (this.combocards.ContainsKey(card.cardIDenum))
                {
                    return true;
                }
                return false;
            }

            public int hasPlayedCombo(List<Handmanager.Handcard> hand)
            {
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocards);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }

                if (cardsincombo == this.combolength) return this.bonusForPlaying;
                return 0;
            }

            public int hasPlayedTurn0Combo(List<Handmanager.Handcard> hand)
            {
                if (this.combocardsTurn0All.Count == 0) return 0;
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn0All);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }

                if (cardsincombo == this.combot0lenAll) return this.bonusForPlayingT0;
                return 0;
            }

            public int hasPlayedTurn1Combo(List<Handmanager.Handcard> hand)
            {
                if (this.combocardsTurn1.Count == 0) return 0;
                int cardsincombo = 0;
                Dictionary<CardDB.cardIDEnum, int> combocardscopy = new Dictionary<CardDB.cardIDEnum, int>(this.combocardsTurn1);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.cardIDenum) && combocardscopy[hc.card.cardIDenum] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.cardIDenum]--;
                    }
                }

                if (cardsincombo == this.combot1len) return this.bonusForPlayingT1;
                return 0;
            }

        }

        public static ComboBreaker Instance
        {
            get
            {
                return instance ?? (instance = new ComboBreaker());
            }
        }

        private ComboBreaker()
        {
            readCombos();
            if (attackFaceHP != -1)
            {
                hp.setAttackFaceHP(attackFaceHP);
            }
        }

        private void readCombos()
        {
            string[] lines = new string[0] { };
            combos.Clear();
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "_combo.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _combo.txt");
                Helpfunctions.Instance.ErrorLog("cant find _combo.txt (if you dont created your own combos, ignore this message)");
                return;
            }
            Helpfunctions.Instance.logg("read _combo.txt...");
            Helpfunctions.Instance.ErrorLog("read _combo.txt...");
            foreach (string line in lines)
            {
                string shortline = line.Replace(" ", "");
                if(shortline.StartsWith("//")) continue;
                if (line.Contains("weapon:"))
                {
                    try
                    {
                        this.attackFaceHP = Convert.ToInt32(line.Replace("weapon:", ""));
                    }
                    catch
                    {
                        Helpfunctions.Instance.logg("combomaker cant read: " + line);
                        Helpfunctions.Instance.ErrorLog("combomaker cant read: " + line);
                    }
                }
                else
                {
                    if (line.Contains("cardvalue:"))
                    {
                        try
                        {
                            string cardvalue = line.Replace("cardvalue:", "");
                            CardDB.cardIDEnum ce = CardDB.Instance.cardIdstringToEnum(cardvalue.Split(',')[0]);
                            int val = Convert.ToInt32(cardvalue.Split(',')[1]);
                            if (this.playByValue.ContainsKey(ce)) continue;
                            this.playByValue.Add(ce, val);
                            //Helpfunctions.Instance.ErrorLog("adding: " + line);
                        }
                        catch
                        {
                            Helpfunctions.Instance.logg("combomaker cant read: " + line);
                            Helpfunctions.Instance.ErrorLog("combomaker cant read: " + line);
                        }
                    }
                    else
                    {
                        try
                        {
                            combo c = new combo(line);
                            this.combos.Add(c);
                        }
                        catch
                        {
                            Helpfunctions.Instance.logg("combomaker cant read: " + line);
                            Helpfunctions.Instance.ErrorLog("combomaker cant read: " + line);
                        }
                    }
                }

            }

        }

        public int getPenalityForDestroyingCombo(CardDB.Card crd, Playfield p)
        {
            if (this.combos.Count == 0) return 0;
            int pen = int.MaxValue;
            bool found = false;
            int mana = Math.Max(hp.ownMaxMana, hp.currentMana);
            foreach (combo c in this.combos)
            {
                if ((c.oHero == HeroEnum.None || c.oHero == p.ownHeroName) && c.isCardInCombo(crd))
                {
                    int iia = c.isInCombo(hm.handCards, hp.ownMaxMana);//check if we have all cards for a combo, and if the choosen card is one
                    int iib = c.isMultiTurnComboTurn1(hm.handCards, mana, p.ownMinions, p.ownWeaponName);

                    int iic = Math.Max(iia, iib);
                    if (iia == 2 && iib != 2 && c.isMultiTurn1Card(crd))// it is a card of the combo, is a turn 1 card, but turn 1 is not possible -> we have to play turn 0 cards first
                    {
                        iic = 1;
                    }
                    if (iic == 1) found = true;
                    if (iic == 1 && pen > c.cardspen[crd.cardIDenum]) pen = c.cardspen[crd.cardIDenum];//iic==1 will destroy combo
                    if (iic == 2) pen = 0;//card is ok to play
                }

            }
            if (found) { return pen; }
            return 0;

        }

        public int checkIfComboWasPlayed(List<Action> alist, CardDB.cardName weapon, HeroEnum heroname)
        {
            if (this.combos.Count == 0) return 0;
            //returns a penalty only if the combo could be played, but is not played completely
            List<Handmanager.Handcard> playedcards = new List<Handmanager.Handcard>();
            List<combo> searchingCombo = new List<combo>();
            // only check the cards, that are in a combo that can be played:
            int mana = Math.Max(hp.ownMaxMana, hp.currentMana);
            foreach (Action a in alist)
            {
                if (a.actionType != actionEnum.playcard && a.actionType != actionEnum.useHeroPower) continue;
                CardDB.Card crd = a.card.card;
                //playedcards.Add(a.handcard);
                foreach (combo c in this.combos)
                {
                    if ((c.oHero == HeroEnum.None || c.oHero == heroname) && c.isCardInCombo(crd))
                    {
                        int iia = c.isInCombo(hm.handCards, hp.ownMaxMana);
                        int iib = c.isMultiTurnComboTurn1(hm.handCards, mana, hp.ownMinions, weapon);
                        int iic = Math.Max(iia, iib);
                        if (iia == 2 && iib != 2 && c.isMultiTurn1Card(crd))
                        {
                            iic = 1;
                        }
                        if (iic == 2)
                        {
                            playedcards.Add(a.card); // add only the cards, which dont get a penalty
                        }
                    }

                }
            }

            if (playedcards.Count == 0) return 0;
            bool wholeComboPlayed = false;

            int bonus = 0;
            foreach (combo c in this.combos)
            {
                int iia = c.hasPlayedCombo(playedcards);
                int iib = c.hasPlayedTurn0Combo(playedcards);
                int iic = c.hasPlayedTurn1Combo(playedcards);
                int iie = iia + iib + iic;
                if (iie >= 1)
                {
                    wholeComboPlayed = true;
                    bonus -= iie;
                }
            }

            if (wholeComboPlayed) return bonus;
            return 250;

        }

        public int getPlayValue(CardDB.cardIDEnum ce)
        {
            if (this.playByValue.Count == 0) return 0;
            if (this.playByValue.ContainsKey(ce))
            {
                return this.playByValue[ce];
            }
            return 0;

        }

    }


}