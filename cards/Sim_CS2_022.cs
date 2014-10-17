using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_022 : SimTemplate//Polymorph
    {

        private CardDB.Card sheep = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_tk1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, sheep);
        }

    }
}
