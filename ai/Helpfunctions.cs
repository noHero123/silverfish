// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Helpfunctions.cs" company="">
//   
// </copyright>
// <summary>
//   The helpfunctions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace HREngine.Bots
{
    using HREngine.API.Utilities;

    /// <summary>
    /// The helpfunctions.
    /// </summary>
    public class Helpfunctions
    {
        /// <summary>
        /// The take list.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<T> TakeList<T>(IEnumerable<T> source, int limit)
        {
            List<T> retlist = new List<T>();
            int i = 0;

            foreach (T item in source)
            {
                retlist.Add(item);
                i++;

                if (i >= limit) break;
            }

            return retlist;
        }

        /// <summary>
        /// The runningbot.
        /// </summary>
        public bool runningbot = false;

        /// <summary>
        /// The instance.
        /// </summary>
        private static Helpfunctions instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Helpfunctions Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Helpfunctions();
                }

                return instance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Helpfunctions"/> class from being created.
        /// </summary>
        private Helpfunctions()
        {

            File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, string.Empty);
        }

        /// <summary>
        /// The writelogg.
        /// </summary>
        private bool writelogg = true;

        /// <summary>
        /// The loggonoff.
        /// </summary>
        /// <param name="onoff">
        /// The onoff.
        /// </param>
        public void loggonoff(bool onoff)
        {
            // writelogg = onoff;
        }

        /// <summary>
        /// The create new loggfile.
        /// </summary>
        public void createNewLoggfile()
        {
            File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, string.Empty);
        }

        /// <summary>
        /// The logg.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        public void logg(string s)
        {


            if (!this.writelogg) return;
            try
            {
                using (StreamWriter sw = File.AppendText(Settings.Instance.logpath + Settings.Instance.logfile))
                {
                    sw.WriteLine(s);
                }
            }
            catch { }
        }

        /// <summary>
        /// The unix time stamp to date time.
        /// </summary>
        /// <param name="unixTimeStamp">
        /// The unix time stamp.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        public DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// The error log.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        public void ErrorLog(string s)
        {
            HRLog.Write(s);
        }

        /// <summary>
        /// The sendbuffer.
        /// </summary>
        string sendbuffer = string.Empty;

        /// <summary>
        /// The reset buffer.
        /// </summary>
        public void resetBuffer()
        {
            this.sendbuffer = string.Empty;
        }

        /// <summary>
        /// The write to buffer.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void writeToBuffer(string data)
        {
            this.sendbuffer += "\r\n" + data;
        }

        /// <summary>
        /// The write buffer to file.
        /// </summary>
        public void writeBufferToFile()
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            while (writed)
            {
                try
                {
                    File.WriteAllText(Settings.Instance.path + "crrntbrd.txt", this.sendbuffer);
                    writed = false;
                }
                catch
                {
                    writed = true;
                }
            }

            this.sendbuffer = string.Empty;
        }

        /// <summary>
        /// The write buffer to action file.
        /// </summary>
        public void writeBufferToActionFile()
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            while (writed)
            {
                try
                {
                    File.WriteAllText(Settings.Instance.path + "actionstodo.txt", this.sendbuffer);
                    writed = false;
                }
                catch
                {
                    writed = true;
                }
            }

            this.sendbuffer = string.Empty;

        }
   
    }

}
