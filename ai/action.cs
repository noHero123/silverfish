// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="action.cs">
//   
// </copyright>
// <summary>
//   The action enum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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

    /// <summary>
    ///     The action enum.
    /// </summary>
    public enum actionEnum
    {
        /// <summary>
        ///     The endturn.
        /// </summary>
        endturn = 0, 

        /// <summary>
        ///     The playcard.
        /// </summary>
        playcard, 

        /// <summary>
        ///     The attack with hero.
        /// </summary>
        attackWithHero, 

        /// <summary>
        ///     The use hero power.
        /// </summary>
        useHeroPower, 

        /// <summary>
        ///     The attack with minion.
        /// </summary>
        attackWithMinion
    }

    // todo make to struct
    /// <summary>
    ///     The action.
    /// </summary>
    public class Action
    {
        #region Fields

        /// <summary>
        ///     The action type.
        /// </summary>
        public actionEnum actionType;

        /// <summary>
        ///     The card.
        /// </summary>
        public Handmanager.Handcard card;

        // public int cardEntitiy;

        /// <summary>
        ///     The druidchoice.
        /// </summary>
        public int druidchoice; // 1 left card, 2 right card

        /// <summary>
        ///     The own.
        /// </summary>
        public Minion own;

        /// <summary>
        ///     The penalty.
        /// </summary>
        public int penalty;

        /// <summary>
        ///     The place.
        /// </summary>
        public int place; // = target where card/minion is placed

        /// <summary>
        ///     The target.
        /// </summary>
        public Minion target;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Action"/> Klasse. 
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="hc">
        /// The hc.
        /// </param>
        /// <param name="ownCardEntity">
        /// The own card entity.
        /// </param>
        /// <param name="place">
        /// The place.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="pen">
        /// The pen.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public Action(
            actionEnum type, 
            Handmanager.Handcard hc, 
            Minion ownCardEntity, 
            int place, 
            Minion target, 
            int pen, 
            int choice)
        {
            this.actionType = type;
            this.card = hc;
            this.own = ownCardEntity;
            this.place = place;
            this.target = target;
            this.penalty = pen;
            this.druidchoice = choice;
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Action"/> Klasse. 
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        public Action(string s, Playfield p)
        {
            if (s.StartsWith("play "))
            {
                this.actionType = actionEnum.playcard;

                int cardEnt =
                    Convert.ToInt32(s.Split(new[] { "id " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                int targetEnt = -1;
                if (s.Contains("target "))
                {
                    targetEnt =
                        Convert.ToInt32(
                            s.Split(new[] { "target " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                }

                int place = 0;
                if (s.Contains("pos "))
                {
                    place =
                        Convert.ToInt32(
                            s.Split(new[] { "pos " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                }

                int choice = 0;
                if (s.Contains("choice "))
                {
                    choice =
                        Convert.ToInt32(
                            s.Split(new[] { "choice " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                }

                this.own = null;

                this.card = new Handmanager.Handcard();
                this.card.entity = cardEnt;

                if (targetEnt >= 0)
                {
                    Minion m = new Minion();
                    m.entitiyID = targetEnt;
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

                Minion m = new Minion();
                m.entitiyID = targetEnt;
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

                Minion m = new Minion();
                m.entitiyID = targetEnt;
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

                Minion m = new Minion();
                m.entitiyID = targetEnt;
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
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Action"/> Klasse. 
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        public Action(Action a)
        {
            this.actionType = a.actionType;
            this.card = a.card;
            this.place = a.place;
            this.own = a.own;
            this.target = a.target;
            this.druidchoice = a.druidchoice;
            this.penalty = a.penalty;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The print.
        /// </summary>
        /// <param name="tobuffer">
        /// The tobuffer.
        /// </param>
        public void print(bool tobuffer = false)
        {
            Helpfunctions help = Helpfunctions.Instance;
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
                        playaction += " pos " + this.place;
                    }

                    if (this.druidchoice >= 1)
                    {
                        playaction += " choice " + this.druidchoice;
                    }

                    help.writeToBuffer(playaction);
                }

                if (this.actionType == actionEnum.attackWithMinion)
                {
                    help.writeToBuffer("attack " + this.own.entitiyID + " enemy " + this.target.entitiyID);
                }

                if (this.actionType == actionEnum.attackWithHero)
                {
                    help.writeToBuffer("heroattack " + this.target.entitiyID);
                }

                if (this.actionType == actionEnum.useHeroPower)
                {
                    if (this.target != null)
                    {
                        help.writeToBuffer("useability on target " + this.target.entitiyID);
                    }
                    else
                    {
                        help.writeToBuffer("useability");
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

                if (this.druidchoice >= 1)
                {
                    playaction += " choice " + this.druidchoice;
                }

                help.logg(playaction);
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

            help.logg(string.Empty);
        }

        #endregion
    }
}