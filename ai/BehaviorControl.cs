namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    public class BehaviorControl : Behavior
    {
        PenalityManager penman = PenalityManager.Instance;

        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000) return p.value;
            int retval = 0;
            int hpboarder = 10;
            if (p.ownHeroName == HeroEnum.warlock && p.enemyHeroName != HeroEnum.mage) hpboarder = 6;
            int aggroboarder = 8;

            /////////////////////////// to find lethal
            if (p.ownHeroName == HeroEnum.druid)
            {
                bool FON = false;
                int FONMC = 0;
                bool SR = false;
                int SRMC = 0;
                foreach (Handmanager.Handcard hcc in p.owncards)
                {
                    if (hcc.card.name == CardDB.cardName.forceofnature)
                    {
                        FON = true;
                        FONMC = hcc.getManaCost(p);
                    }
                    if (hcc.card.name == CardDB.cardName.savageroar) 
                    {
                        SR = true;
                        SRMC = hcc.getManaCost(p);
                    }
                }
                bool TAUNT = false;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt) TAUNT = true;
                }
                bool HPCHECK = false;
                //priest
                if (p.enemyHero.Hp <= 10 && (p.enemyHeroName == HeroEnum.priest && p.enemyHeroAblility.card.name == CardDB.cardName.heal)) HPCHECK = true;
                if (p.enemyHero.Hp <= 12 && (p.enemyHeroName == HeroEnum.priest && p.enemyHeroAblility.card.name == CardDB.cardName.lesserheal)) HPCHECK = true;
                //warrior
                if (p.enemyHero.Hp <= 10 && (p.enemyHeroName == HeroEnum.warrior && p.enemyHeroAblility.card.name == CardDB.cardName.tankup)) HPCHECK = true;
                if (p.enemyHero.Hp <= 12 && (p.enemyHeroName == HeroEnum.warrior && p.enemyHeroAblility.card.name == CardDB.cardName.armorup)) HPCHECK = true;
                //else
                if (p.enemyHero.Hp <= 14 && (p.enemyHeroName != HeroEnum.priest || p.enemyHeroName != HeroEnum.warrior)) HPCHECK = true;
                

                if (FON && SR && !TAUNT && FONMC + SRMC <= p.ownMaxMana + 1 && !p.enemyHero.immune && p.enemySecretCount == 0 && HPCHECK) retval += 100;
                if (FON && SR && !TAUNT && FONMC + SRMC <= p.ownMaxMana + 1 && !p.enemyHero.immune && p.enemySecretCount == 0 && HPCHECK) retval += 100;
            }


            ///////////////////////////


            retval -= p.evaluatePenality;
            retval += p.owncards.Count * 3;


            retval += p.ownMaxMana;
            retval -= p.enemyMaxMana;
            
            retval += p.ownMaxMana * 20 - p.enemyMaxMana * 20;

            if (p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.druid) retval -= 2 * p.enemyspellpower;

            if (p.ownHero.Hp + p.ownHero.armor > hpboarder)
            {
                retval += p.ownHero.Hp + p.ownHero.armor;
            }
            else
            {
                retval += (p.ownHero.Hp + p.ownHero.armor);
                retval -= 2 * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor) * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor);
            }

            

            if (p.enemyHero.Hp + p.enemyHero.armor > aggroboarder)
            {
                retval += -p.enemyHero.Hp - p.enemyHero.armor;
            }
            else
            {
                retval += 2 * (aggroboarder + 1 - p.enemyHero.Hp - p.enemyHero.armor);
            }

            if (p.ownWeaponAttack >= 1)
            {
                retval += p.ownWeaponAttack * p.ownWeaponDurability;
            }

            if (!p.enemyHero.frozen)
            {
                retval -= p.enemyWeaponDurability * p.enemyWeaponAttack;
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    retval += 12;
                }
            }
            
            //RR card draw value depending on the turn and distance to lethal
            //RR if lethal is close, carddraw value is increased
            if (Ai.Instance.lethalMissing <= 5) //RR
            {
                retval += p.owncarddraw * 100;
            }
            if (p.ownMaxMana < 4)
            {
                retval += p.owncarddraw * 3;
            }
            else
            {
                retval += p.owncarddraw * 5;
            }

            if (p.ownHero.Hp >= 14 && p.ownMaxMana >= 7) retval += p.owncarddraw * 4;

            //retval += p.owncarddraw * 5;
            retval -= p.enemycarddraw * 5;

            //int owntaunt = 0;
            int readycount = 0;
            int ownMinionsCount = 0;
            foreach (Minion m in p.ownMinions)
            {
                retval += 5;
                retval += m.Hp * 2;
                retval += m.Angr * 2;

                if (p.enemyHeroName == HeroEnum.hunter && p.ownMaxMana <= 4) retval += m.Hp * 2;
                if (p.enemyHeroName == HeroEnum.hunter && m.taunt) retval += m.Hp;


                retval += m.handcard.card.rarity;
                if (p.ownHeroName == HeroEnum.hunter && (TAG_RACE)m.handcard.card.race == TAG_RACE.PET) retval++;
                if (p.ownHeroName == HeroEnum.pala && m.name == CardDB.cardName.silverhandrecruit) retval++;

                if (m.name == CardDB.cardName.treant && !m.silenced) retval -= 2* (m.Hp + m.Angr) + 5 + 4;

                if (m.handcard.card.deathrattle && !m.silenced) retval += Math.Max(m.handcard.card.cost - 2, 1); //priority to deathrattal
                if (m.divineshild) retval += m.Angr * 2 + m.handcard.card.cost; // to save divineshild

                

                if (!m.playedThisTurn && m.windfury) retval += m.Angr;

                if (m.stealth) retval += m.Angr;
                if (m.handcard.card.isSpecialMinion)
                {
                    retval += 1;
                    if (!m.taunt && m.stealth) retval += 20;
                }
                else
                {
                    if (m.Angr <= 2 && m.Hp <= 2 && !m.divineshild) retval -= 5;
                }
                //if (m.Angr <= m.Hp + 1) retval += m.Angr;
                //if (!m.taunt && m.stealth && penman.specialMinions.ContainsKey(m.name)) retval += 20;
                //if (m.poisonous) retval += 1;
                if (m.divineshild && m.taunt) retval += 4;
                //if (m.taunt && m.handcard.card.name == CardDB.cardName.frog) owntaunt++;
                //if (m.handcard.card.isToken && m.Angr <= 2 && m.Hp <= 2) retval -= 5;
                //if (!penman.specialMinions.ContainsKey(m.name) && m.Angr <= 2 && m.Hp <= 2) retval -= 5;
                if (p.ownMinions.Count >= 2 && (m.handcard.card.name == CardDB.cardName.direwolfalpha || m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.stormwindchampion || m.handcard.card.name == CardDB.cardName.raidleader)) retval += 5 * (p.ownMinions.Count);
                if (m.handcard.card.name == CardDB.cardName.nerubianegg)
                {
                    if (m.Angr >= 1) retval += 2;
                    if ((!m.taunt && m.Angr == 0) && (m.divineshild || m.maxHp > 2)) retval -= 10;
                }
                if (m.Ready) readycount++;
                if (m.Hp <= 4 && (m.Angr > 2 || m.Hp > 3)) ownMinionsCount++;
            }

            /*if (p.enemyMinions.Count >= 0)
            {
                int anz = p.enemyMinions.Count;
                if (owntaunt == 0) retval -= 10 * anz;
                retval += owntaunt * 10 - 11 * anz;
            }*/

            bool useAbili = false;
            bool usecoin = false;
            //bool lastCoin = false;

            bool hasweapon = false;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == CardDB.cardtype.WEAPON) hasweapon = true;
            }

            foreach (Action a in p.playactions)
            {
                if (a.actionType == actionEnum.playcard && a.card.card.type == CardDB.cardtype.MOB && p.enemyHeroName == HeroEnum.hunter) retval += 15; 


                if (p.ownHeroName != HeroEnum.thief && a.actionType == actionEnum.attackWithHero && p.ownWeaponAttack == 1) retval += 10;
                //lastCoin = false;
                if (a.actionType == actionEnum.attackWithHero && p.enemyHero.Hp >= p.attackFaceHP && p.ownWeaponAttack >=2 && p.ownHero.Hp >=12 && !hasweapon) retval += -10;
                if (a.actionType == actionEnum.useHeroPower) useAbili = true;
                if (p.ownHeroName == HeroEnum.warrior && a.actionType == actionEnum.attackWithHero && useAbili) retval -= 1;
                //if (a.actionType == actionEnum.useHeroPower && a.card.card.name == CardDB.cardName.lesserheal && (!a.target.own)) retval -= 5;
                if (a.actionType != actionEnum.playcard) continue;
                if ((a.card.card.name == CardDB.cardName.thecoin || a.card.card.name == CardDB.cardName.innervate))
                {
                    usecoin = true;
                    //lastCoin = true;

                }
                //save spell for all classes: (except for rouge if he has no combo)
                if (a.target == null) continue;
                if (p.ownHeroName != HeroEnum.thief && a.card.card.type == CardDB.cardtype.SPELL && (!a.target.own && a.target.isHero && a.target.Hp>=10) && a.card.card.name != CardDB.cardName.shieldblock ) retval -= 30;
                if (p.ownHeroName == HeroEnum.thief && a.card.card.type == CardDB.cardtype.SPELL && (a.target.isHero && !a.target.own)) retval -= 11;
            }
            //dont waste mana!!
            if (usecoin && useAbili && p.ownMaxMana <= 5) retval -= 10;
            if (usecoin && p.manaTurnEnd >= 1) retval -= 20 * p.manaTurnEnd;

            int heropowermana = p.ownHeroAblility.getManaCost(p);
            if (p.manaTurnEnd >= heropowermana && !useAbili && p.ownAbilityReady)
            {
                //penalty except thief
                if (!(p.ownHeroName == HeroEnum.thief && (p.ownWeaponDurability >= 2 || p.ownWeaponAttack >= 2))) retval -= 5;
                                
            }


            /*


            //use all cards
            int hasmob = 0;
           
            
            foreach (Handmanager.Handcard hcc in p.owncards)
            {

                if (hcc.manacost <= p.mana && (hcc.card.type == CardDB.cardtype.MOB || hcc.card.name == CardDB.cardName.animalcompanion) && hcc.card.name != CardDB.cardName.ironbeakowl && hcc.card.name != CardDB.cardName.biggamehunter && hcc.card.name != CardDB.cardName.kezanmystic && hcc.card.name != CardDB.cardName.theblackknight && hcc.card.name != CardDB.cardName.rendblackhand) hasmob++; // 핸드 하수인체크
            }
             

            if (hasmob >=1 && p.manaTurnEnd >= 1) retval -= 15 * p.manaTurnEnd;


            */

            





            //if (usecoin && p.manaTurnEnd >= 1 && p.owncards.Count <= 8) retval -= 100;

            int mobsInHand = 0;
            int bigMobsInHand = 0;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == CardDB.cardtype.MOB)
                {
                    mobsInHand++;
                    if (hc.card.Attack >= 3) bigMobsInHand++;
                }
            }

            if (ownMinionsCount - p.enemyMinions.Count >= 4 && bigMobsInHand >= 1)
            {
                retval += bigMobsInHand * 25;
            }


            //bool hasTank = false;
            foreach (Minion m in p.enemyMinions)
            {
                retval -= this.getEnemyMinionValue(m, p);
                //hasTank = hasTank || m.taunt;
            }

            /*foreach (SecretItem si in p.enemySecretList)
            {
                if (readycount >= 1 && !hasTank && si.canbeTriggeredWithAttackingHero)
                {
                    retval -= 100;
                }
                if (readycount >= 1 && p.enemyMinions.Count >= 1 && si.canbeTriggeredWithAttackingMinion)
                {
                    retval -= 100;
                }
                if (si.canbeTriggeredWithPlayingMinion && mobsInHand >= 1)
                {
                    retval -= 25;
                }
            }*/

            retval -= 3 * p.enemySecretCount;
            retval -= 2 * p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;

            //if (p.ownMinions.Count == 0) retval -= 20;
            //if (p.enemyMinions.Count == 0) retval += 20;
            if (p.enemyHero.Hp <= 0)
            {
                if (p.turnCounter <= 1)
                {
                    retval = 10000;
                }
                else
                {
                    retval += 50;
                }
            }
            //soulfire etc
            int deletecardsAtLast = 0;
            foreach (Action a in p.playactions)
            {
                if (a.actionType != actionEnum.playcard) continue;
                if (a.card.card.name == CardDB.cardName.soulfire || a.card.card.name == CardDB.cardName.doomguard || a.card.card.name == CardDB.cardName.succubus) deletecardsAtLast = 1;
                if (deletecardsAtLast == 1 && !(a.card.card.name == CardDB.cardName.soulfire || a.card.card.name == CardDB.cardName.doomguard || a.card.card.name == CardDB.cardName.succubus)) retval -= 20;
            }
            if (p.enemyHero.Hp >= 1 && p.guessingHeroHP <= 0)
            {
                if (p.turnCounter < 2) retval += p.owncarddraw * 100;
                retval -= 1000;
            }
            
            if (p.ownHero.Hp <= 0) //retval = -10000;
            {
                if (p.turnCounter <= 1)
                {
                    retval += p.owncarddraw * 3000;
                    retval -= 10000;
                }
                else
                {
                    retval -= 10000;
                }

                
            }

            p.value = retval;
            return retval;
        }



        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            int retval = 5;
            retval += m.Hp * 2;
            if (!m.frozen && !((m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord) && !m.silenced))
            {
                retval += m.Angr * 2;
                if (m.windfury) retval += m.Angr * 2;
                if (m.Angr >= 5) retval += m.Angr-2;
                if (m.Angr >= 7) retval += m.Angr-2;
            }

            //if (m.Angr == 0) retval -= 7;

            retval += m.handcard.card.rarity;

            if (m.taunt) retval += 5;
            
            if (m.divineshild && m.taunt) retval += 5;
            if (m.stealth) retval += 1;

            if (m.poisonous) retval += 4;

            if (p.enemyHeroName == HeroEnum.hunter && p.ownHero.Hp<=12) retval += m.Angr;

            if (p.enemyHeroName == HeroEnum.hunter && (TAG_RACE)m.handcard.card.race == TAG_RACE.PET) retval++;
            if (p.enemyHeroName == HeroEnum.shaman && (TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) retval++;
            if (p.enemyHeroName == HeroEnum.pala && m.name == CardDB.cardName.silverhandrecruit) retval++;
            if (p.enemyHeroName == HeroEnum.mage && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) retval++;
            if (p.enemyHeroName == HeroEnum.mage && m.name == CardDB.cardName.flamewaker) retval+=5;
            if (m.handcard.card.deathrattle && !m.silenced) retval -= Math.Max(m.handcard.card.cost - 2, 1); //not priority to deathrattle (bad for us)

            if (m.divineshild) retval += m.Angr + 1;
            if (m.divineshild && m.name == CardDB.cardName.annoyotron && m.Angr == 1) retval += 3;
            if (!m.silenced && (m.name == CardDB.cardName.wrathofairtotem || m.name == CardDB.cardName.flametonguetotem)) retval += 3;

            int hasenemyattack = 0;
            foreach (Minion mn in p.enemyMinions)
            {
                hasenemyattack += mn.Angr;
                retval++;
            }
            hasenemyattack += p.enemyHero.Angr;
            if (p.enemyHeroName == HeroEnum.hunter) hasenemyattack += 2;
            if (p.enemyHeroName == HeroEnum.druid || p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.thief) hasenemyattack++;

            if (m.divineshild && m.Angr == 1) retval += 5;

            if (m.Angr == 0) retval += m.Hp + 3;
            if (m.name == CardDB.cardName.wrathofairtotem && !m.silenced) retval += 4;

            if ((p.ownHero.Hp + p.ownHero.armor) - hasenemyattack <= 10) retval += 4 * m.Angr;// we can die next turn


            if (p.ownSecretsIDList.Contains(CardDB.cardIDEnum.EX1_611) && p.enemyMinions.Count == 1) retval -= m.Hp + m.Angr + m.handcard.card.cost; // if has freezingtrap, priority to kill weakness 

            if (m.handcard.card.targetPriority >= 1 && !m.silenced)
            {
                retval += m.handcard.card.targetPriority;
            }
            if (m.name == CardDB.cardName.nerubianegg && m.Angr <= 3 && !m.taunt) retval = 0;
            return retval;
        }

    }

}