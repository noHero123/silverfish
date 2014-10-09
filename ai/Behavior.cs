// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Behavior.cs" company="">
//   
// </copyright>
// <summary>
//   The behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The behavior.
    /// </summary>
    public abstract class Behavior
    {
        /// <summary>
        /// The get playfield value.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        public virtual float getPlayfieldValue(Playfield p)
        {
            return 0;
        }

        /// <summary>
        /// The get enemy minion value.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public virtual int getEnemyMinionValue(Minion m, Playfield p)
        {
            return 0;
        }

    }
}
