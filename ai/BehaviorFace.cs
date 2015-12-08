using System.Collections.Generic;

namespace HREngine.Bots
{
    public class BehaviorFace : Behavior
    {
        PenalityManager penman = PenalityManager.Instance;

        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000) return p.value;
            int retval = 0;
            retval -= p.evaluatePenality;
            retval += p.owncards.Count * 3;

            retval += p.ownHero.Hp + p.ownHero.armor;
            retval += -3 * (p.enemyHero.Hp + p.enemyHero.armor);

            // when enemy hp is low, we need more face
            if (p.enemyHero.Hp + p.enemyHero.armor < 15)
            {
                retval += 2 * (15 - p.enemyHero.Hp - p.enemyHero.armor);
            }

            retval += p.ownMaxMana * 15 - p.enemyMaxMana * 15;

            if (p.ownWeaponAttack >= 1 && !p.ownHero.frozen)
            {
                retval += p.ownWeaponAttack * p.ownWeaponDurability;
            }

            if (!p.enemyHero.frozen)
            {
                retval -= p.enemyWeaponDurability * p.enemyWeaponAttack;
            }
            else
            {
                if (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.priest && p.enemyHeroName != HeroEnum.warlock)
                {
                    retval += 11;
                }
            }

            //RR card draw value depending on the turn and distance to lethal
            //RR if lethal is close, carddraw value is increased


            if (p.turnCounter == 0 && Ai.Instance.lethalMissing <= 5) //RR
            {
                retval += p.owncarddraw * 100;
            }
            if (p.ownMaxMana < 4)
            {
                retval += p.owncarddraw * 2;
            }
            else
            {
                // value card draw this turn > card draw next turn (the sooner the better)
                retval += (p.turnCounter < 2 ? p.owncarddraw * 5 : p.owncarddraw * 3);
            }
            //retval += p.owncarddraw * 5;
            retval -= p.enemycarddraw * 15;

            bool useAbili = false;
            int usecoin = 0;
            foreach (Action a in p.playactions)
            {
                if (a.actionType == actionEnum.attackWithHero && p.enemyHero.Hp <= p.attackFaceHP) retval++;
                if (a.actionType == actionEnum.useHeroPower) useAbili = true;
                if (p.ownHeroName == HeroEnum.warrior && a.actionType == actionEnum.attackWithHero && useAbili) retval -= 1;
                //if (a.actionType == actionEnum.useHeroPower && a.card.card.name == CardDB.cardName.lesserheal && (!a.target.own)) retval -= 5;
                if (a.actionType != actionEnum.playcard) continue;
                if (a.card.card.name == CardDB.cardName.thecoin)
                {
                    usecoin = 1;
                }
                if (a.card.card.name == CardDB.cardName.innervate)
                {
                    usecoin = 2;
                }
            }
            if (usecoin >= 1 && useAbili && p.ownMaxMana <= 2) retval -= 40;
            if (usecoin >= 1 && p.manaTurnEnd >= usecoin && p.owncards.Count <= 8) retval -= 100 * p.manaTurnEnd;
            int heropowermana = p.ownHeroAblility.card.getManaCost(p, 2);
            if (p.manaTurnEnd >= heropowermana && !useAbili && p.ownAbilityReady)
            {
                if (!(p.ownHeroName == HeroEnum.thief && (p.ownWeaponDurability >= 2 || p.ownWeaponAttack >= 2))) retval -= 20;
            }
            if (useAbili) retval -= 3;  // penalty in case the hero power was chosen over playing a card (penalty == card count bonus)
            if (useAbili && usecoin == 2) retval -= 5;  // prevent being wasteful with innervate if we could've just not used hero power for 2mana
            //if (usecoin && p.mana >= 1) retval -= 20;

            if (p.ownHeroName == HeroEnum.pala)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.avenge && p.manaTurnEnd >= hc.getManaCost(p))
                    {
                        retval -= 8;
                        break;
                    }
                }
            }

            foreach (Minion m in p.ownMinions)
            {
                retval += m.Hp * 1;
                retval += m.Angr * 2;
                retval += m.handcard.card.rarity;
                if (m.windfury) retval += m.Angr;
                if (m.divineshild) retval += ((m.Angr + 2) / 3) + ((m.Hp + 2) / 3);
                if (m.stealth) retval += 1;
                if (m.taunt) retval += 1;
                if (m.handcard.card.isSpecialMinion)
                {
                    retval += 1;
                    if (!m.taunt && m.stealth) retval += (m.Angr < 4 ? 10 : 20);
                }
                //if (m.handcard.card.name == CardDB.cardName.silverhandrecruit && m.Angr == 1 && m.Hp == 1) retval -= 5;
                if (m.handcard.card.name == CardDB.cardName.direwolfalpha || m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.stormwindchampion || m.handcard.card.name == CardDB.cardName.raidleader) retval += 10;
                if (m.handcard.card.name == CardDB.cardName.nerubianegg)
                {
                    if (m.Angr >= 1) retval += 2;
                    if ((!m.taunt && m.Angr == 0) && (m.divineshild || m.maxHp > 2)) retval -= 10;
                    if (p.ownMinions.Count >= 3) retval += 15;
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                retval -= this.getEnemyMinionValue(m, p);
            }

            retval -= p.enemySecretCount;
            retval -= p.numEnemySecretsTurnEnd * 50;
            retval -= p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;
            if (p.ownMinions.Count == 0) retval -= 20;
            if (p.enemyMinions.Count >= 4) retval -= 20;
            if (p.enemyHero.Hp <= 0)
            {
                if (p.turnCounter <= 1)
                {
                    retval = 10000;
                }
                else
                {
                    retval += 50;//10000
                    if (p.numPlayerMinionsAtTurnStart == 0) retval += 50; // if we can kill the enemy even after a board clear, bigger bonus
                    if (p.loathebLastTurn > 0) retval += 50;  // give a bonus to turn 2 sims where we played loatheb in turn 1 to protect our lethal board
                }
            }
            else if (p.ownHero.Hp > 0)
            {
                // if our damage on board is lethal, give a strong bonus so enemy AI avoids this outcome in its turn (i.e. AI will clear our minions if it can instead of ignoring them)
                if (p.turnCounter == 1 && p.guessHeroDamage(true) >= p.enemyHero.Hp + p.enemyHero.armor) retval += 100;
            }

            //soulfire etc
            int deletecardsAtLast = 0;
            foreach (Action a in p.playactions)
            {
                if (a.actionType != actionEnum.playcard) continue;
                if (a.card.card.name == CardDB.cardName.soulfire || a.card.card.name == CardDB.cardName.doomguard || a.card.card.name == CardDB.cardName.succubus) deletecardsAtLast = 1;
                if (deletecardsAtLast == 1 && !(a.card.card.name == CardDB.cardName.soulfire || a.card.card.name == CardDB.cardName.doomguard || a.card.card.name == CardDB.cardName.succubus)) retval -= 20;
            }

            if (p.enemyHero.Hp >= 1 && p.ownHero.Hp <= 0)
            {
                //Helpfunctions.Instance.ErrorLog("turncounter " + p.turnCounter);

                if (p.turnCounter == 0) // own turn 
                {
                    //worst case: we die on own turn
                    retval += p.owncarddraw * 500;
                    retval = -10000;
                }
                else
                {
                    if (p.turnCounter == 1) // enemys first turn
                    {
                        retval += p.owncarddraw * 500;
                        retval -= 1000;
                    }
                    if (p.turnCounter >= 2)
                    {
                        //carddraw next turn doesnt count this turn :D
                        retval -= 100;
                    }
                }



            }

            /*if (p.enemyHero.Hp >= 1 && p.ownHero.Hp <= 0)
            {
                if (p.turnCounter < 2) retval += p.owncarddraw * 500;
                retval -= 1000;
            }
            if (p.ownHero.Hp <= 0) retval = -10000;*/

            // give a bonus for making the enemy spend more mana dealing with our board, so boards where the enemy makes different plays
            // aren't considered as equal value (i.e. attacking the enemy and making him spend mana to heal vs not attacking at all)
            if (p.turnCounter == 1 || p.turnCounter == 3) retval += p.enemyMaxMana - p.mana;

            p.value = retval;
            return retval;
        }

        public override int getEnemyMinionValue(Minion m, Playfield p)
        {

            int retval = 1;  // Give a base value of 1, so in the event of equal boards next turn vs this turn, minion removal is prioritzed earlier rather than later.;
            if (m.name == CardDB.cardName.cutpurse) retval += 40;
            if (m.taunt || (m.handcard.card.targetPriority >= 1 && !m.silenced))
            {
                retval += m.Hp;
                if (!m.frozen && !((m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord) && !m.silenced))
                {
                    retval += m.Angr * 2;
                    if (m.windfury) retval += 2 * m.Angr;
                }
                if (m.taunt && m.Angr > 0) retval += 5;
                if (m.divineshild) retval += m.Angr;
                if (m.frozen) retval -= 1; // because its bad for enemy :D
                if (m.poisonous) retval += 4;
                retval += m.handcard.card.rarity;


                if (!m.frozen && m.Angr >= 4) retval += 20 + m.Hp;
                if (!m.frozen && m.Angr >= 7)
                {
                    List<Minion> myTaunts = p.ownMinions.FindAll(own => own.taunt);
                    List<Minion> enemyAttackers = p.enemyMinions.FindAll(enm => enm.entitiyID != m.entitiyID && enm.Angr > 0 && !enm.frozen);
                    int totalTauntHp = 0;
                    int totalAtkDmg = 0;
                    myTaunts.ForEach(taunt => totalTauntHp += taunt.Hp);
                    enemyAttackers.ForEach(atkr => totalAtkDmg += atkr.Angr);
                    if (myTaunts.Count < enemyAttackers.Count && totalTauntHp <= totalAtkDmg) retval += 30 + m.Hp;
                }
                if (m.name == CardDB.cardName.nerubianegg && m.Angr <= 3 && !m.taunt) retval = 0;
            }

            if (m.handcard.card.targetPriority >= 1 && !m.silenced) retval += m.handcard.card.targetPriority;


            return retval;
        }


    }

}