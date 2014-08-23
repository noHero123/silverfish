// the ai :D
//please ask/write me if you use this in your project

using System;
using System.Collections.Generic;
using System.Text;



//TODO:

//cardids of duplicate + avenge
//nozdormu (for computing time :D)
//faehrtenlesen (tracking)
// lehrensucher cho
//scharmuetzel kills all :D
//todo deathlord-guessing
//todo kelthuzad dont know which minion died this turn in rl




namespace HREngine.Bots
{

    public enum actionEnum
    {
        endturn = 0,
        playcard,
        attackWithHero,
        useHeroPower,
        attackWithMinion
    }

    //todo make to struct
    public class Action
    {

        public actionEnum actionType;
        public Handmanager.Handcard card;
        //public int cardEntitiy;
        public int place; //= target where card/minion is placed
        public Minion own;
        public Minion target;
        public int druidchoice; // 1 left card, 2 right card
        public int penalty;

        public Action(actionEnum type, Handmanager.Handcard hc, Minion ownCardEntity, int place, Minion target, int pen, int choice)
        {
            this.actionType = type;
            this.card = hc;
            this.own = ownCardEntity;
            this.place = place;
            this.target = target;
            this.penalty = pen;
            this.druidchoice = choice;
        }


        public void print()
        {
            Helpfunctions help = Helpfunctions.Instance;
            help.logg("current Action: ");
            if (this.actionType == actionEnum.playcard)
                {
                    help.logg("play " + this.card.card.name);
                    if (this.druidchoice >= 1) help.logg("choose choise " + this.druidchoice);
                    help.logg("with entityid " + this.card.entity);
                    if (this.place >= 0)
                    {
                        help.logg("on position " + this.place);
                    }
                    if (this.target != null)
                    {
                        help.logg("and target to " + this.target.entitiyID );
                    }
                    if (this.penalty > 0)
                    {
                        help.logg("penality for playing " + this.penalty);
                    }
                }
                if (this.actionType == actionEnum.attackWithMinion)
                {
                    help.logg("attacker: " + this.own.entitiyID + " enemy: " + this.target.entitiyID);
                }
                if (this.actionType == actionEnum.attackWithHero)
                {
                    help.logg("attack with hero, enemy: " + this.target.entitiyID);
                }
                if (this.actionType == actionEnum.useHeroPower)
                {
                    help.logg("useability ");
                    if (this.target != null)
                    {
                        help.logg("on enemy: " + this.target.entitiyID);
                    }
                }
                help.logg("");
        }

    }

}
