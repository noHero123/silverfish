// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pen_EX1_549.cs" company="">
//   
// </copyright>
// <summary>
//   The pen_ e x 1_549.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The pen_ e x 1_549.
    /// </summary>
    class Pen_EX1_549 : PenTemplate
	{
	    // bestialwrath

// verleiht einem wildtier +2 angriff und immunität/ in diesem zug.
        /// <summary>
        /// The get play penalty.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        /// <param name="isLethal">
        /// The is lethal.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            {
                if (target.own)
                {
                    if (!m.Ready)
                    {
                        return 50;
                    }

                    if (m.Hp == 1 && !m.divineshild)
                    {
                        return 10;
                    }
                }
                else
                {
                    return 500;
                }

                return 0;
            }
		}

	}
}