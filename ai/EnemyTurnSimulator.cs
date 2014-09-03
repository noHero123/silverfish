using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HREngine.Bots
{

    public class EnemyTurnSimulator
    {

        private List<Playfield> posmoves = new List<Playfield>(7000);
        private int maxwide = 20;
        Movegenerator movegen = Movegenerator.Instance;

        public void simulateEnemysTurn(Playfield rootfield, bool simulateTwoTurns, bool playaround, bool print, int pprob, int pprob2)
        {
            bool havedonesomething = true;
            posmoves.Clear();

            posmoves.Add(new Playfield(rootfield));
            //posmoves[0].prepareNextTurn(false);
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            int enemMana = Math.Min(rootfield.enemyMaxMana + 1, 10);

            if (playaround && !rootfield.loatheb)
            {
                int oldval = Ai.Instance.botBase.getPlayfieldValue(posmoves[0]);
                posmoves[0].value = int.MinValue;
                enemMana = posmoves[0].EnemyCardPlaying(rootfield.enemyHeroName, enemMana, rootfield.enemyAnzCards, pprob, pprob2);
                int newval = Ai.Instance.botBase.getPlayfieldValue(posmoves[0]);
                posmoves[0].value = int.MinValue;
                if (oldval < newval)
                {
                    posmoves.Clear();
                    posmoves.Add(new Playfield(rootfield));
                }
            }

            foreach (Minion m in posmoves[0].enemyMinions)
            {
                if (m.frozen || (m.handcard.card.name == CardDB.cardName.ancientwatcher && !m.silenced))
                {
                    m.Ready = false;
                    continue;
                }
                if (m.Angr == 0) continue;
                m.Ready = true;
                m.numAttacksThisTurn = 0;
            }

            //play ability!
            if (posmoves[0].enemyAbilityReady && enemMana >= 2 && posmoves[0].enemyHeroAblility.card.canplayCard(posmoves[0], 0) && !rootfield.loatheb)
            {
                int abilityPenality = 0;

                havedonesomething = true;
                // if we have mage or priest, we have to target something####################################################
                if (posmoves[0].enemyHeroName == HeroEnum.mage || posmoves[0].enemyHeroName == HeroEnum.priest)
                {

                    List<Minion> trgts = posmoves[0].enemyHeroAblility.card.getTargetsForCardEnemy(posmoves[0]);
                    foreach (Minion trgt in trgts)
                    {
                        if (trgt.isHero) continue;
                        Action a = new Action(actionEnum.useHeroPower, posmoves[0].enemyHeroAblility, null, 0, trgt, abilityPenality, 0);
                        Playfield pf = new Playfield(posmoves[0]);
                        pf.doAction(a);
                        posmoves.Add(pf);
                    }
                }
                else
                {
                    // the other classes dont have to target####################################################
                    Action a = new Action(actionEnum.useHeroPower, posmoves[0].enemyHeroAblility, null, 0, null, abilityPenality, 0);
                    Playfield pf = new Playfield(posmoves[0]);
                    pf.doAction(a);
                    posmoves.Add(pf);
                }

            }

            int count = 0;
            //movegen...
            while (havedonesomething)
            {

                temp.Clear();
                temp.AddRange(posmoves);
                havedonesomething = false;
                Playfield bestold = null;
                int bestoldval = 20000000;
                foreach (Playfield p in temp)
                {

                    if (p.complete)
                    {
                        continue;
                    }

                    List<Action> actions = movegen.getEnemyMoveList(p, false, true, true, 1);// 1 for not using ability moves

                    foreach (Action a in actions)
                    {
                        havedonesomething = true;
                        Playfield pf = new Playfield(p);
                        pf.doAction(a);
                        posmoves.Add(pf);
                        count++;
                    }

                    //p.endCurrentPlayersTurnAndStartTheNextOne(1, false);
                    p.endEnemyTurn();
                    p.guessingHeroHP = rootfield.guessingHeroHP;
                    if (Ai.Instance.botBase.getPlayfieldValue(p) < bestoldval) // want the best enemy-play-> worst for us
                    {
                        bestoldval = Ai.Instance.botBase.getPlayfieldValue(p);
                        bestold = p;
                    }
                    posmoves.Remove(p);

                    if (count >= maxwide) break;
                }

                if (bestoldval <= 10000 && bestold != null)
                {
                    posmoves.Add(bestold);
                }

                deep++;
                if (count >= maxwide) break;
            }

            foreach (Playfield p in posmoves)
            {
                if (!p.complete) p.endEnemyTurn();
            }

            int bestval = int.MaxValue;
            Playfield bestplay = posmoves[0];
            
            foreach (Playfield p in posmoves)
            {
                p.guessingHeroHP = rootfield.guessingHeroHP;
                int val = Ai.Instance.botBase.getPlayfieldValue(p);
                if (bestval > val)// we search the worst value
                {
                    bestplay = p;
                    bestval = val;
                }
            }
            if (print) bestplay.printBoard();
            rootfield.value = bestplay.value;
            if (simulateTwoTurns && bestplay.value > -1000)
            {
                bestplay.prepareNextTurn(true);
                rootfield.value = (int)(0.5 * bestval + 0.5 * Ai.Instance.nextTurnSimulator.doallmoves(bestplay, false));
            }



        }




    }

}
