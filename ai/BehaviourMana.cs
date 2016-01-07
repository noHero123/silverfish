namespace HREngine.Bots
{
    using System;

    public class BehaviorMana : Behavior
    {
        PenalityManager penman = PenalityManager.Instance;


        public override float getPlayfieldValue(Playfield p)
        {

            if (p.value >= -2000000) return p.value;
            int retval = 0;
            int hpboarder = 10;
            if (p.ownHeroName == HeroEnum.warlock && p.enemyHeroName != HeroEnum.mage) hpboarder = 6;
            int aggroboarder = 11;
            retval -= p.evaluatePenality;
            retval += p.owncards.Count * 5;

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
                retval -= 2 * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor) * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor);
            }

            if (p.enemyHero.Hp + p.enemyHero.armor > aggroboarder)
            {
                retval += -p.enemyHero.Hp - p.enemyHero.armor;
            }
            else
            {
                retval += 3 * (aggroboarder + 1 - p.enemyHero.Hp - p.enemyHero.armor);
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
            if (Ai.Instance.lethalMissing <= 5 && p.turnCounter == 0) //RR
            {
                retval += p.owncarddraw * 100;
            }
            if (p.ownMaxMana <= 4)
            {
                retval += p.owncarddraw * 2;
            }
            else
            {
                //retval += p.owncarddraw * 5;
                // value card draw this turn > card draw next turn (the sooner the better)
                retval += (p.turnCounter < 2 ? p.owncarddraw * 5 : p.owncarddraw * 3);
            }

            //retval += p.owncarddraw * 5;
            retval -= (p.enemycarddraw - p.anzEnemyCursed) * 10;

            //int owntaunt = 0;
            int readycount = 0;
            int ownMinionsCount = 0;

            bool enemyhaspatron = false;

            //
            bool canPingMinions = (p.ownHeroAblility.card.name == CardDB.cardName.fireblast);
            bool hasPingedMinion = false;


            foreach (Minion m in p.enemyMinions)
            {
                if (m.name == CardDB.cardName.grimpatron && !m.silenced) enemyhaspatron = true;

                int currMinionValue = this.getEnemyMinionValue(m, p);

                // Give a bonus for 1 hp minions as a mage, since we can remove it easier in the future with ping.
                // But we make sure we only give this bonus once among all enemies. We also give another +1 bonus once if the atk >= 4.
                if (canPingMinions && !hasPingedMinion && currMinionValue > 2 && m.Hp == 1)
                {
                    currMinionValue -= 1;
                    canPingMinions = false;  // only 1 per turn (-1 bonus regardless of atk)
                    hasPingedMinion = true;
                }
                if (hasPingedMinion && currMinionValue > 2 && m.Hp == 1 && m.Angr >= 4)
                {
                    currMinionValue -= 1;
                    hasPingedMinion = false;  // only 1 per turn (-1 bonus additional for atk >= 4)
                }

                retval -= currMinionValue;

                //hasTank = hasTank || m.taunt;
            }

            foreach (Minion m in p.ownMinions)
            {
                retval += 5;
                retval += m.Hp * 2;
                retval += m.Angr * 2;
                retval += m.handcard.card.rarity;
                if (!m.playedThisTurn && m.windfury) retval += m.Angr;
                if (m.divineshild) retval += 1;
                if (m.stealth) retval += 1;
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
                if (m.handcard.card.name == CardDB.cardName.direwolfalpha || m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.stormwindchampion || m.handcard.card.name == CardDB.cardName.raidleader) retval += 10;
                if (m.handcard.card.name == CardDB.cardName.bloodmagethalnos) retval += 10;
                if (m.handcard.card.name == CardDB.cardName.nerubianegg)
                {
                    if (m.Angr >= 1) retval += 2;
                    if (m.divineshild || (m.maxHp > 2 && !m.destroyOnOwnTurnEnd)) retval -= 10;
                    if (p.ownMinions.Count >= 3) retval += 15;
                }
                if (m.Ready) readycount++;
                if (m.maxHp >= 4 && (m.Angr > 2 || m.Hp > 3)) ownMinionsCount++;
            }



            /*if (p.enemyMinions.Count >= 0)
            {
                int anz = p.enemyMinions.Count;
                if (owntaunt == 0) retval -= 10 * anz;
                retval += owntaunt * 10 - 11 * anz;
            }*/

            bool useAbili = false;
            int usecoin = 0;
            //bool lastCoin = false;
            foreach (Action a in p.playactions)
            {
                //lastCoin = false;
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
                //save spell for all classes: (except for rouge if he has no combo)
                if (a.target == null) continue;
                if (p.ownHeroName != HeroEnum.thief && a.card.card.type == CardDB.cardtype.SPELL && (!a.target.own && a.target.isHero) && a.card.card.name != CardDB.cardName.shieldblock) retval -= 11;
                if (p.ownHeroName == HeroEnum.thief && a.card.card.type == CardDB.cardtype.SPELL && (a.target.isHero && !a.target.own)) retval -= 11;
            }
            //dont waste mana!!
            if (usecoin >= 1 && useAbili && p.ownMaxMana <= 2) retval -= 40;
            if (usecoin >= 1 && p.manaTurnEnd >= usecoin && p.owncards.Count <= 8) retval -= 100 * p.manaTurnEnd;
            int heropowermana = p.ownHeroAblility.card.getManaCost(p, 2);
            if (p.manaTurnEnd >= heropowermana && !useAbili && p.ownAbilityReady)
            {
                if (!(p.ownHeroName == HeroEnum.thief && (p.ownWeaponDurability >= 2 || p.ownWeaponAttack >= 2))) retval -= 20;
                if (p.ownHeroName == HeroEnum.pala && enemyhaspatron) retval += 20;
            }
            if (useAbili && usecoin == 2) retval -= 5;
            //if (usecoin && p.manaTurnEnd >= 1 && p.owncards.Count <= 8) retval -= 100;

            int mobsInHand = 0;
            int bigMobsInHand = 0;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == CardDB.cardtype.MOB)
                {
                    mobsInHand++;
                    if (hc.card.Attack >= 3 && hc.card.Health >= 3) bigMobsInHand++;
                }
            }

            //stuff for not flooding board
            int mobsturnbegin = Hrtprozis.Instance.ownMinions.Count;
            if (ownMinionsCount > mobsturnbegin)
            {
                if (ownMinionsCount - p.enemyMinions.Count >= 3)
                {
                    retval += bigMobsInHand * 50 + mobsInHand * 10;
                }

                if (p.turnCounter <= 1 && p.ownMinions.Count - p.enemyMinions.Count >= 4)
                {
                    retval -= (p.ownMinions.Count - p.enemyMinions.Count - 3) * 10;
                }
            }


            //bool hasTank = false;


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
            retval -= p.enemySecretCount;
            retval -= p.numEnemySecretsTurnEnd * 50;
            //Helpfunctions.Instance.ErrorLog("sc:" + p.enemySecretCount+ " " + p.numEnemySecretsTurnEnd);

            //testing eval without lostdmg
            //retval -= p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2

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
                //Helpfunctions.Instance.ErrorLog("turncounter " + p.turnCounter + " " + retval);
                if (p.turnCounter == 0) // own turn 
                {
                    //worst case: we die on own turn
                    retval += p.owncarddraw * 100;
                    retval = -10000;
                }
                else
                {
                    if (p.turnCounter == 1) // enemys first turn
                    {
                        retval += p.owncarddraw * 100;
                        retval -= 1000;
                    }
                    if (p.turnCounter >= 2)
                    {
                        //carddraw next turn doesnt count this turn :D
                        retval -= 100;
                    }
                }



            }

            //if (p.ownHero.Hp <= 0 && p.turnCounter < 2) retval = -10000;

            // give a bonus for making the enemy spend more mana dealing with our board, so boards where the enemy makes different plays
            // aren't considered as equal value (i.e. attacking the enemy and making him spend mana to heal vs not attacking at all)
            if (p.turnCounter == 1 || p.turnCounter == 3) retval += p.enemyMaxMana - p.mana;

            p.value = retval;
            return retval;
        }

        //other value of the board for enemys turn? (currently the same as getplayfield value)
        public override float getPlayfieldValueEnemy(Playfield p)
        {
            return getPlayfieldValue(p);
        }


        public override int getEnemyMinionValue(Minion m, Playfield p)
        {

            int retval = 5;
            retval += m.Hp * 2;
            if (!m.frozen && !((m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord) && !m.silenced))
            {
                retval += m.Angr * 2;
                if (m.windfury) retval += m.Angr * 2;
                if (m.Angr >= 4) retval += 10;
                if (m.Angr >= 7)
                {
                    //this might be faster, than creating new lists, use findall and loop over them
                    int enemyAttackerscount = 0;
                    int ownTauntCount = 0;
                    int ownTauntHP = 0;
                    int enemyTotalAttack = 0;

                    foreach (Minion min in p.enemyMinions)
                    {
                        if (min.Angr >= 1)
                        {
                            enemyTotalAttack += min.Angr;
                            enemyAttackerscount++;
                        }

                    }

                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.taunt)
                        {
                            ownTauntCount++;
                            ownTauntHP += min.Hp;
                        }
                    }

                    if (ownTauntCount < enemyAttackerscount && ownTauntHP <= enemyTotalAttack) retval += 30;

                }
            }

            if (m.Angr == 0) retval -= 7;

            retval += m.handcard.card.rarity;
            if (m.taunt) retval += 5;
            if (m.divineshild) retval += m.Angr;
            if (m.divineshild && m.taunt) retval += 5;
            if (m.stealth) retval += 1;

            if (m.poisonous) retval += 4;

            if (m.handcard.card.targetPriority >= 1 && !m.silenced)
            {
                retval += m.handcard.card.targetPriority;
            }
            if (m.name == CardDB.cardName.nerubianegg && m.Angr <= 3 && !m.taunt) retval = 0;



            return retval;
        }

    }


}