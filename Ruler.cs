using HREngine.API;
using HREngine.API.Utilities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HREngine.Bots
{
    public class Ruler
    {
        public enum RuleEntity
        {
            Enemy,
            EnemyMinionField,
            Player,
            PlayerMinionField
        }

        public enum RuleMethod
        {
            GetHealth,
            GetAttack,
            GetMana,
            GetByMinHealth,
            GetByMaxHealth,
            GetByMinAttack,
            GetByMaxAttack,
            HasTaunt,
            HasCharge,
            HasFreeze,
            HasCardOnField,
            GetNumCardsOnHand,
            GetNumCardsOnField,
            HasCardOnHand
        }

        public enum RuleOperator
        {
            Equal,
            LessThan,
            LessOrEqualThan,
            Greater,
            GreaterOrEuqalThan,
            NotEqual
        }

        public static bool isAllowdByRule(string cardID, int target, Playfield p)
        {
            bool retval = true;
            //todo get rule from id
            HREngine.Private.HREngineRules hrrules = GetRulesForCard(cardID);

            HREngine.Private.RuleCollection playrules = hrrules.PlayRule;

            foreach (HREngine.Private.Rule rule in playrules.Rules)
            {

            }


            return retval;
        }

        public static bool isPlayRuleOK(HREngine.Private.Rule rule, Playfield p)
        {
            bool retval = true;
            RuleEntity entity = (RuleEntity)rule.Entity;
            RuleMethod method = (RuleMethod)rule.Method;
            // wrong target
            if (entity == RuleEntity.PlayerMinionField)
            {
                List<int> values = new List<int>();
                foreach (Minion m in p.ownMinions)
                {
                    if (method == RuleMethod.GetAttack)
                    {
                        values.Add(m.Angr);
                    }
                    if (method == RuleMethod.GetHealth)
                    {
                        values.Add(m.Hp);
                    }
                    if (method == RuleMethod.GetMana)
                    {
                        values.Add(m.Hp);
                    }
                }
                
            }

            if (entity == RuleEntity.EnemyMinionField) return false;
            return retval;
        }

        public static bool HasRule(String CardID)
        {
            string strFilePath = String.Format("{0}{1}.xml",
               HRSettings.Get.CustomRuleFilePath,
               CardID.ToUpper());
            return File.Exists(strFilePath);
        }

        public static bool HasRule(HRCard Card)
        {
            return HasRule(Card.GetEntity().GetCardId());
        }

        public static bool HasRule(HREntity Card)
        {
            return HasRule(Card.GetCardId());
        }

        public static HREngine.Private.HREngineRules GetRulesForCard(String CardID)
        {
            if (!HasRule(CardID))
                return null;

            try
            {
                string strFilePath = String.Format("{0}{1}.xml",
                   HRSettings.Get.CustomRuleFilePath,
                   CardID.ToUpper());

                byte[] buffer = File.ReadAllBytes(strFilePath);
                if (buffer.Length > 0)
                {
                    XmlSerializer serialzer = new XmlSerializer(typeof(HREngine.Private.HREngineRules));
                    object result = serialzer.Deserialize(new MemoryStream(buffer));
                    if (result != null)
                        return (HREngine.Private.HREngineRules)result;
                }
            }
            catch (Exception e)
            {
                Helpfunctions.Instance.ErrorLog("Exception when deserialize XML Rule.");
                Helpfunctions.Instance.ErrorLog(e.Message);
            }

            return null;
        }

        public static HREngine.Private.HREngineRules GetRulesForCard(HRCard Card)
        {
            return GetRulesForCard(Card.GetEntity().GetCardId());
        }

        public static HREngine.Private.HREngineRules GetRulesForCard(HREntity Card)
        {
            return GetRulesForCard(Card.GetCardId());
        }

        

    }
}
