
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
    using System;

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
        public int tracking=0; // 1= leftmost card
        public int penalty;

        public Action(actionEnum type, Handmanager.Handcard hc, Minion ownCardEntity, int place, Minion target, int pen, int choice, int track = 0)
        {
            this.actionType = type;
            this.card = hc;
            this.own = ownCardEntity;
            this.place = place;
            this.target = target;
            this.penalty = pen;
            this.druidchoice = choice;
            this.tracking = track;

        }

        public Action(string s, Playfield p)
        {
            if (s.StartsWith("play "))
            {
                this.actionType = actionEnum.playcard;

                int cardEnt = Convert.ToInt32(s.Split(new string[] { "id " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                int targetEnt = -1;
                if (s.Contains("target ")) targetEnt = Convert.ToInt32(s.Split(new string[] { "target " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                int place = 0;
                if (s.Contains("pos ")) place = Convert.ToInt32(s.Split(new string[] { "pos " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                int choice = 0;
                if (s.Contains("choice ")) choice = Convert.ToInt32(s.Split(new string[] { "choice " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                this.own = null;

                this.card = new Handmanager.Handcard { entity = cardEnt };

                if (targetEnt >= 0)
                {
                    Minion m = new Minion { entitiyID = targetEnt };
                    this.target = m;
                }
                else
                {
                    this.target = null;
                }

                this.place = place;
                this.druidchoice = choice;

            }

            if (s.StartsWith("attack "))
            {
                this.actionType = actionEnum.attackWithMinion;

                int ownEnt = Convert.ToInt32(s.Split(' ')[1].Split(' ')[0]);
                int targetEnt = Convert.ToInt32(s.Split(' ')[3].Split(' ')[0]);

                this.place = 0;
                this.druidchoice = 0;

                this.card = null;

                Minion m = new Minion { entitiyID = targetEnt };
                this.target = m;

                Minion o = new Minion();
                o.entitiyID = ownEnt;
                this.own = o;
            }

            if (s.StartsWith("heroattack "))
            {
                this.actionType = actionEnum.attackWithHero;

                int targetEnt = Convert.ToInt32(s.Split(' ')[1].Split(' ')[0]);

                this.place = 0;
                this.druidchoice = 0;

                this.card = null;

                Minion m = new Minion { entitiyID = targetEnt };
                this.target = m;

                this.own = p.ownHero;

            }

            if (s.StartsWith("useability on target "))
            {
                this.actionType = actionEnum.useHeroPower;

                int targetEnt = Convert.ToInt32(s.Split(' ')[3].Split(' ')[0]);

                this.place = 0;
                this.druidchoice = 0;

                this.card = null;

                Minion m = new Minion { entitiyID = targetEnt };
                this.target = m;

                this.own = null;

            }

            if (s == "useability")
            {
                this.actionType = actionEnum.useHeroPower;
                this.place = 0;
                this.druidchoice = 0;
                this.card = null;
                this.own = null;
                this.target = null;
            }

            if (s.Contains(" discover "))
            {
                string dc = s.Split(new string[] { " discover " }, StringSplitOptions.RemoveEmptyEntries)[1];
                this.tracking = Convert.ToInt32(dc);
            }

        }

        public Action(Action a)
        {
            this.actionType = a.actionType;
            this.card = a.card;
            this.place = a.place;
            this.own = a.own;
            this.target = a.target;
            this.druidchoice = a.druidchoice;
            this.penalty = a.penalty;
            this.tracking = a.tracking;
        }

        public void print(bool tobuffer = false)
        {
            Helpfunctions help = Helpfunctions.Instance;
            string discover = "";
            if (this.tracking >= 1) discover = " discover "+tracking;
            if (tobuffer)
            {
                if (this.actionType == actionEnum.playcard)
                {
                    string playaction = "play ";

                    playaction += "id " + this.card.entity;
                    if (this.target != null)
                    {
                        playaction += " target " + this.target.entitiyID;
                    }

                    if (this.place >= 0)
                    {
                        playaction += " pos " +this.place;
                    }

                    if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                    help.writeToBuffer(playaction + discover);
                }
                if (this.actionType == actionEnum.attackWithMinion)
                {
                    help.writeToBuffer("attack " + this.own.entitiyID + " enemy " + this.target.entitiyID + discover);
                }
                if (this.actionType == actionEnum.attackWithHero)
                {
                    help.writeToBuffer("heroattack " + this.target.entitiyID + discover);
                }
                if (this.actionType == actionEnum.useHeroPower)
                {

                    if (this.target != null)
                    {
                        help.writeToBuffer("useability on target " + this.target.entitiyID + discover);
                    }
                    else
                    {
                        help.writeToBuffer("useability" + discover);
                    }
                }
                return;
            }
            if (this.actionType == actionEnum.playcard)
            {
                string playaction = "play ";

                playaction += "id " + this.card.entity;
                if (this.target != null)
                {
                    playaction += " target " + this.target.entitiyID;
                }

                if (this.place >= 0)
                {
                    playaction += " pos " + this.place;
                }

                if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                help.logg(playaction + discover);
            }
            if (this.actionType == actionEnum.attackWithMinion)
            {
                help.logg("attacker: " + this.own.entitiyID + " enemy: " + this.target.entitiyID + discover);
            }
            if (this.actionType == actionEnum.attackWithHero)
            {
                help.logg("attack with hero, enemy: " + this.target.entitiyID + discover);
            }
            if (this.actionType == actionEnum.useHeroPower)
            {
                help.logg("useability " + discover);
                if (this.target != null)
                {
                    help.logg("on enemy: " + this.target.entitiyID + discover);
                }
            }
            help.logg("");
        }

    }

    
}