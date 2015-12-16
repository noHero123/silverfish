using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Triton.Game.Data;
using log4net;
using Logger = Triton.Common.LogUtilities.Logger;

//work mostly done by Hearthbuddy team, added something, to make it work with my version of silverfish 
//( my mulligan have another syntax, other features), to not destroy/double work of HB's comunity

namespace HREngine.Bots
{
    /*
This programm allows:
    (lowest priority)
    -Hold all cards that cost less than XXX (manarule)
    (average priority)
    -Hold defined cards (possible to select 1 or 2 cards)
    -Discard defined card (all cards)
    (high priority)
    -Creating rules that allow to Discard (all) cards, depending on the presence of other cards.
    (highest priority)
    -Creating rules that allow to Hold 1 or 2 cards, depending on the presence of other cards.

as well as

    -Can create rules like: if I have a coin, then ...
    -Can create rules for different pairs of ownHero-enemyHero (any or all).
    -It allowed the simultaneous existence of rules with different priorities for the same card 
     with the same hero pairs (i.e. possible 3 rules at the same time).
     */

	 
	 
    public class Mulligan
    {
        string PathHBMulligan = "";
        public bool mulliganRulesLoaded = false;
        Dictionary<string, string> MulliganRules = new Dictionary<string, string>();
        Dictionary<CardDB.cardIDEnum, string> MulliganRulesManual = new Dictionary<CardDB.cardIDEnum, string>();
        List<CardIDEntity> cards = new List<CardIDEntity>();
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

		 public TAG_CLASS heroEnumtoTagClass(HeroEnum he)
        {
            switch (he)
            {
                case HeroEnum.druid: return TAG_CLASS.DRUID;
                case HeroEnum.hunter: return TAG_CLASS.HUNTER;
                case HeroEnum.mage: return TAG_CLASS.MAGE;
                case HeroEnum.pala: return TAG_CLASS.PALADIN;
                case HeroEnum.priest: return TAG_CLASS.PRIEST;
                case HeroEnum.shaman: return TAG_CLASS.SHAMAN;
                case HeroEnum.thief: return TAG_CLASS.ROGUE;
                case HeroEnum.warlock: return TAG_CLASS.WARLOCK;
                case HeroEnum.warrior: return TAG_CLASS.WARRIOR;
                default: return TAG_CLASS.INVALID;
            }
        }

        public HeroEnum heroTAG_CLASSstringToEnum(string s)
        {
            switch (s)
            {
                case "DRUID": return HeroEnum.druid;
                case "HUNTER": return HeroEnum.hunter;
                case "MAGE": return HeroEnum.mage;
                case "PALADIN": return HeroEnum.pala;
                case "PRIEST": return HeroEnum.priest;
                case "SHAMAN": return HeroEnum.shaman;
                case "ROGUE": return HeroEnum.thief;
                case "WARLOCK": return HeroEnum.warlock;
                case "WARRIOR": return HeroEnum.warrior;
                default: return HeroEnum.None;
            }
        }

        public void setAutoConcede(bool mode)
        {
            
        }

        public class CardIDEntity
        {
            public CardDB.cardIDEnum id = CardDB.cardIDEnum.None;
            public int entitiy = 0;
            public int hold = 0;
            public int holdByRule = 0;
            public int holdByManarule = 1;
            public string holdReason = "";
            public CardIDEntity(string id_string, int entt)
            {
                this.id = CardDB.Instance.cardIdstringToEnum(id_string);
                this.entitiy = entt;
            }
        }


        private static Mulligan instance;

        public static Mulligan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Mulligan();
                }
                return instance;
            }
        }

        private Mulligan()
        {
            readRules();
        }

        private void readRules()
        {
            PathHBMulligan = Settings.Instance.path + "_mulligan.txt";

            if (!System.IO.File.Exists(PathHBMulligan))
            {
                Helpfunctions.Instance.ErrorLog("cant find _mulligan.txt (if you dont created your own mulliganfile, ignore this message)");
                return;
            }
            try
            {
                string[] readText = System.IO.File.ReadAllLines(PathHBMulligan);
                MulliganRules.Clear();
                foreach (string tmp in readText)
                {
                    if (tmp == "" || tmp == null) continue;
                    if (tmp.StartsWith("//")) continue;
                    string[] oneRule = tmp.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (MulliganRules.ContainsKey(oneRule[0])) MulliganRules[oneRule[0]] = oneRule[1];
                    else MulliganRules.Add(oneRule[0], oneRule[1]);
                }
            }
            catch (Exception ee)
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] _mulligan.txt - read error. We continue without user-defined rules. Only the default rules.");
                return;
            }
            Helpfunctions.Instance.ErrorLog("[Mulligan] Load rules...");
            validateRule();
        }


        private void validateRule()
        {
            List<string> rejectedRule = new List<string>();
            int repairedRules = 0;
            Dictionary<string, string> MulliganRulesTmp = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> oneRule in MulliganRules)
            {
                string[] ruleKey = oneRule.Key.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string[] ruleValue = oneRule.Value.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string ruleValueOne = oneRule.Value;

                if (ruleKey.Length != 4 || ruleValue.Length != 2) { rejectedRule.Add(joinSomeTxt(oneRule.Key, ":", oneRule.Value)); continue; }

                //ruleKey[0]CardDB.cardIDEnum, [1]HeroEnum ownMHero, [2]HeroEnum enemyMHero, [3]"Hold"||"Discard")
                if (ruleKey[0] != CardDB.Instance.cardIdstringToEnum(ruleKey[0]).ToString()) { rejectedRule.Add(joinSomeTxt(oneRule.Key, ":", oneRule.Value)); continue; }
                if (ruleKey[1] != Hrtprozis.Instance.heroNametoEnum(ruleKey[1]).ToString()) { rejectedRule.Add(joinSomeTxt(oneRule.Key, ":", oneRule.Value)); continue; }
                if (ruleKey[2] != Hrtprozis.Instance.heroNametoEnum(ruleKey[2]).ToString()) { rejectedRule.Add(joinSomeTxt(oneRule.Key, ":", oneRule.Value)); continue; }
                if (ruleKey[3] != "Hold" && ruleKey[3] != "Discard") { rejectedRule.Add(joinSomeTxt(oneRule.Key, ":", oneRule.Value)); continue; }

                //ruleValue[0]int allowedQuantity (1||2), [1]string additionalRule ("/"=no addition rules || "0-20"-int manarule || CardDB.cardIDEnum:CardDB.cardIDEnum:CardDB.cardIDEnum:....)
                try
                {
                    Convert.ToInt32(ruleValue[0]);
                }
                catch (Exception eee) { rejectedRule.Add(joinSomeTxt(oneRule.Key, ":", oneRule.Value)); continue; }

                if (ruleValue[1] != "/")
                {
                    if (ruleValue[1].Length < 4) // if lenght < 4 then it a manarule
                    {
                        int manaRule = 4;
                        try
                        {
                            manaRule = Convert.ToInt32(ruleValue[1]);
                        }
                        catch { }
                        if (manaRule < 0) manaRule = 0;
                        else if (manaRule > 100) manaRule = 100;

                        StringBuilder tmpSB = new StringBuilder(ruleValue[0], 500);
                        tmpSB.Append(";").Append(manaRule);
                        ruleValueOne = tmpSB.ToString();
                    }
                    else
                    {
                        bool wasBreak = false;
                        string[] addedCards = ruleValue[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        Dictionary<CardDB.cardIDEnum, string> MulliganRulesManualTmp = new Dictionary<CardDB.cardIDEnum, string>();
                        foreach (string s in addedCards)
                        {
                            CardDB.cardIDEnum tempID = CardDB.Instance.cardIdstringToEnum(s);
                            if (s != tempID.ToString())
                            {
                                rejectedRule.Add(joinSomeTxt(oneRule.Key, ":", oneRule.Value));
                                wasBreak = true;
                                break;
                            }
                            else
                            {
                                if (MulliganRulesManualTmp.ContainsKey(tempID)) { repairedRules++; continue; }
                                else MulliganRulesManualTmp.Add(tempID, "");
                            }
                        }
                        if (wasBreak) continue;
                        StringBuilder tmpSB = new StringBuilder(ruleValue[0], 500);
                        tmpSB.Append(";");
                        for (int i = 0; i < MulliganRulesManualTmp.Count; i++)
                        {
                            if (i + 1 == MulliganRulesManualTmp.Count) break;
                            tmpSB.Append(MulliganRulesManualTmp.ElementAt(0));
                        }
                        tmpSB.Append(MulliganRulesManualTmp.ElementAt(MulliganRulesManualTmp.Count - 1).Key.ToString());
                        ruleValueOne = tmpSB.ToString();
                    }
                }

                MulliganRulesTmp.Add(oneRule.Key, ruleValueOne);
            }

            if (rejectedRule.Count > 0)
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] List of rejected Rules:");
                foreach (string tmp in rejectedRule)
                {
                    Helpfunctions.Instance.ErrorLog(tmp);
                }
                Helpfunctions.Instance.ErrorLog("[Mulligan] End list of rejected Rules:");
            }

            if (repairedRules > 0) Helpfunctions.Instance.ErrorLog(repairedRules.ToString() + " repaired rules");
            MulliganRules.Clear();

            foreach (KeyValuePair<string, string> oneRule in MulliganRulesTmp)
            {
                MulliganRules.Add(oneRule.Key, oneRule.Value);
            }
            Helpfunctions.Instance.ErrorLog("[Mulligan] " + MulliganRules.Count + " rules loaded successfully");
            mulliganRulesLoaded = true;
        }

        private string getMullRuleKey(CardDB.cardIDEnum cardIDM = CardDB.cardIDEnum.None, HeroEnum ownMHero = HeroEnum.None, HeroEnum enemyMHero = HeroEnum.None, bool HoldM = false)
        {
            StringBuilder MullRuleKey = new StringBuilder("", 500);
            MullRuleKey.Append(cardIDM).Append(";").Append(ownMHero).Append(";").Append(enemyMHero).Append(";").Append(HoldM ? "Hold" : "Discard");
            return MullRuleKey.ToString();
        }

        private string joinSomeTxt(string sPrefix = "", string rKey = "", string sDelimeter = "", string sValue = "")
        {
            StringBuilder retValue = new StringBuilder("", 500);
            retValue.Append(sPrefix).Append(rKey).Append(sDelimeter).Append(sValue);
            return retValue.ToString();
        }


        public void getHoldList(MulliganData mulliganData)
        {
            cards.Clear();

            for (var i = 0; i < mulliganData.Cards.Count; i++)
            {
                cards.Add(new CardIDEntity(mulliganData.Cards[i].Entity.Id, i));
            }
            HeroEnum ownHeroClass = heroTAG_CLASSstringToEnum(mulliganData.UserClass.ToString());
            HeroEnum enemyHeroClass = heroTAG_CLASSstringToEnum(mulliganData.OpponentClass.ToString());

            if (!(cards.Count == 3 || cards.Count == 4))
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] Mulligan is not used, since it got number of cards: " + cards.Count.ToString());
                return;
            }

            int manaRule = 4;
            string MullRuleKey = getMullRuleKey(CardDB.cardIDEnum.None, ownHeroClass, enemyHeroClass, false);
            if (MulliganRules.ContainsKey(MullRuleKey))
            {
                string[] temp = MulliganRules[MullRuleKey].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                manaRule = Convert.ToInt32(temp[1]);
            }
            else
            {
                MullRuleKey = getMullRuleKey(CardDB.cardIDEnum.None, ownHeroClass, HeroEnum.None, false);
                if (MulliganRules.ContainsKey(MullRuleKey))
                {
                    string[] temp = MulliganRules[MullRuleKey].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    manaRule = Convert.ToInt32(temp[1]);
                }
            }

            CardIDEntity Coin = new CardIDEntity("GAME_005", -888);
            if (cards.Count == 4) cards.Add(Coin); //we have a coin

            foreach (CardIDEntity CardIDEntityC in cards)
            {
                int allowedQuantity = 2;
                CardDB.Card c = CardDB.Instance.getCardDataFromID(CardIDEntityC.id);
                if (CardIDEntityC.hold == 0 && CardIDEntityC.holdByRule == 0)
                {
                    if (c.cost < manaRule)
                    {
                        CardIDEntityC.holdByManarule = 2;
                        CardIDEntityC.holdReason = joinSomeTxt("hold because the card cost:", c.cost.ToString(), " is less then Manarule cost:", manaRule.ToString());
                    }
                    else
                    {
                        CardIDEntityC.holdByManarule = -2;
                        CardIDEntityC.holdReason = joinSomeTxt("discard because the card cost:", c.cost.ToString(), " is not less then Manarule cost:", manaRule.ToString());
                    }
                }

                //check Hold
                int hasRuleHold = 0; //0=None, 1=All, 2=Class, 11=All+Rule, 12=Class+Rule
                int hasRuleDiscard = 0; //0=None, -1=All, -2=Class, -11=All+Rule, -12=Class+Rule

                string MullRuleValueHold = "";
                string MullRuleKeyHold = getMullRuleKey(c.cardIDenum, ownHeroClass, enemyHeroClass, true);
                if (MulliganRules.ContainsKey(MullRuleKeyHold))
                {
                    MullRuleValueHold = MulliganRules[MullRuleKeyHold];
                    hasRuleHold = 2;
                }
                else
                {
                    MullRuleKeyHold = getMullRuleKey(c.cardIDenum, ownHeroClass, HeroEnum.None, true); //key for ALL enemy
                    if (MulliganRules.ContainsKey(MullRuleKeyHold)) { MullRuleValueHold = MulliganRules[MullRuleKeyHold]; hasRuleHold = 1; }
                }

                if (MullRuleValueHold != "")
                {
                    string[] temp = MullRuleValueHold.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp[0] == "1") allowedQuantity = 1;
                    if (temp[1] != "/") hasRuleHold += 10;
                }
                else hasRuleHold = 0;

                //check Discard
                string MullRuleValueDiscard = "";
                string MullRuleKeyDiscard = getMullRuleKey(c.cardIDenum, ownHeroClass, enemyHeroClass, false);
                if (MulliganRules.ContainsKey(MullRuleKeyDiscard))
                {
                    MullRuleValueDiscard = MulliganRules[MullRuleKeyDiscard];
                    hasRuleDiscard = -2;
                }
                else
                {
                    MullRuleKeyDiscard = getMullRuleKey(c.cardIDenum, ownHeroClass, HeroEnum.None, false); //key for ALL enemy
                    if (MulliganRules.ContainsKey(MullRuleKeyDiscard)) { MullRuleValueDiscard = MulliganRules[MullRuleKeyDiscard]; hasRuleDiscard = -1; }
                }

                if (MullRuleValueDiscard != "")
                {
                    string[] temp = MullRuleValueDiscard.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp[1] != "/") hasRuleDiscard -= 10;
                }
                else hasRuleDiscard = 0;

                //superimpose Class rules to All rules
                bool useHold = false;
                bool useDiscard = false;
                bool useHoldRule = false;
                bool useDiscardRule = false;

                if (hasRuleHold == 2)
                {
                    useHold = true;
                    if (hasRuleDiscard < -10) useDiscardRule = true;
                }
                else if (hasRuleDiscard == -2)
                {
                    useDiscard = true;
                    if (hasRuleHold > 10) useHoldRule = true;
                }

                if (hasRuleHold == 1)
                {
                    if (hasRuleDiscard == 0 || hasRuleDiscard < -10) useHold = true;
                    if (hasRuleDiscard < -10) useDiscardRule = true;
                }
                else if (hasRuleDiscard == -1)
                {
                    if (hasRuleHold == 0 || hasRuleHold > 10) useDiscard = true;
                    if (hasRuleHold > 10) useHoldRule = true;
                }

                if (hasRuleDiscard == 0 && hasRuleHold > 10) useHoldRule = true;
                else if (hasRuleHold == 0 && hasRuleDiscard < -10) useDiscardRule = true;

                //apply the rules
                if (useDiscardRule)
                {
                    string[] temp = MullRuleValueDiscard.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                    if (temp[1] != "/")
                    {
                        string[] addedCards = temp[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        MulliganRulesManual.Clear();
                        foreach (string s in addedCards) { MulliganRulesManual.Add(CardDB.Instance.cardIdstringToEnum(s), ""); }

                        foreach (CardIDEntity tmp in cards)
                        {
                            if (CardIDEntityC.entitiy == tmp.entitiy) continue;
                            if (MulliganRulesManual.ContainsKey(tmp.id))
                            {
                                CardIDEntityC.holdByRule = -2;
                                CardIDEntityC.holdReason = joinSomeTxt("discard by rule: ", MullRuleKeyDiscard, ":", MulliganRules[MullRuleKeyDiscard]);
                                break;
                            }
                        }
                    }
                }
                else if (useDiscard)
                {
                    CardIDEntityC.hold = -2;
                    CardIDEntityC.holdReason = joinSomeTxt("discard by rule: ", MullRuleKeyDiscard, ":", MulliganRules[MullRuleKeyDiscard]);
                }

                if (useHoldRule)
                {
                    string[] temp = MullRuleValueHold.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    if (CardIDEntityC.holdByRule == 0)
                    {
                        string[] addedCards = temp[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        MulliganRulesManual.Clear();
                        foreach (string s in addedCards) { MulliganRulesManual.Add(CardDB.Instance.cardIdstringToEnum(s), ""); }

                        bool foundFreeCard = false;
                        for (int i = 0; i < cards.Count; i++)
                        {
                            if (CardIDEntityC.entitiy == cards[i].entitiy) continue;
                            if (MulliganRulesManual.ContainsKey(cards[i].id)) //we found the right card
                            {
                                CardIDEntityC.holdByRule = 2;
                                CardIDEntityC.holdReason = joinSomeTxt("hold by rule: ", MullRuleKeyHold, ":", MulliganRules[MullRuleKeyHold]);
                                if (cards[i].holdByRule < 0) //if the right card is busy, check other cards
                                {
                                    for (int j = i; j < cards.Count; j++)
                                    {
                                        if (CardIDEntityC.entitiy == cards[j].entitiy) continue;
                                        if (MulliganRulesManual.ContainsKey(cards[j].id))
                                        {
                                            if (cards[j].holdByRule < 0) continue;
                                            foundFreeCard = true;
                                            cards[j].holdByRule = 2;
                                            cards[j].holdReason = joinSomeTxt("hold by rule: ", MullRuleKeyHold, ":", MulliganRules[MullRuleKeyHold]);
                                            break;
                                        }
                                    }
                                    if (!foundFreeCard)
                                    {
                                        foundFreeCard = true;
                                        cards[i].holdByRule = 2;
                                        cards[i].holdReason = joinSomeTxt("hold by rule: ", MullRuleKeyHold, ":", MulliganRules[MullRuleKeyHold]);
                                        break;
                                    }
                                }
                                else
                                {
                                    foundFreeCard = true;
                                    cards[i].holdByRule = 2;
                                    cards[i].holdReason = joinSomeTxt("hold by rule: ", MullRuleKeyHold, ":", MulliganRules[MullRuleKeyHold]);
                                }

                                if (allowedQuantity == 1)
                                {
                                    foreach (CardIDEntity tmp in cards)
                                    {
                                        if (tmp.entitiy == CardIDEntityC.entitiy) continue;
                                        if (tmp.id == CardIDEntityC.id)
                                        {
                                            tmp.holdByRule = -2;
                                            tmp.holdReason = joinSomeTxt("discard by rule: ", MullRuleKeyHold, ":", MulliganRules[MullRuleKeyHold]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (useHold && CardIDEntityC.holdByRule != -2)
                {
                    if (CardIDEntityC.hold == 0)
                    {
                        CardIDEntityC.hold = 2;
                        CardIDEntityC.holdReason = joinSomeTxt("hold by rule: ", MullRuleKeyHold, ":", MulliganRules[MullRuleKeyHold]);
                        if (allowedQuantity == 1)
                        {
                            CardIDEntityC.hold = 1;
                            foreach (CardIDEntity tmp in cards)
                            {
                                if (tmp.entitiy == CardIDEntityC.entitiy) continue;
                                if (tmp.id == CardIDEntityC.id)
                                {
                                    tmp.hold = -2;
                                    tmp.holdReason = joinSomeTxt("discard Second card by rule: ", MullRuleKeyHold, ":", MulliganRules[MullRuleKeyHold]);
                                }
                            }
                        }
                    }
                }
            }

            if (cards.Count == 5) cards.Remove(Coin);

            foreach (CardIDEntity c in cards)
            {
                if (c.holdByRule == 0)
                {
                    if (c.hold == 0)
                    {
                        c.holdByRule = c.holdByManarule;
                    }
                    else
                    {
                        c.holdByRule = c.hold;
                    }
                }
            }


            for (var i = 0; i < mulliganData.Cards.Count; i++)
            {
                mulliganData.Mulligans[i] = (cards[i].holdByRule > 0) ? false : true;
                Log.InfoFormat("[Mulligan] {0} {1}.", mulliganData.Cards[i].Entity.Name, cards[i].holdReason);
            }
            return;
        }

    }

}