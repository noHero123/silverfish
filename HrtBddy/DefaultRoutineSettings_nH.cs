using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using log4net;
using Newtonsoft.Json;
using Triton.Bot.Settings;
using Triton.Common;
using Triton.Game.Mapping;
using Logger = Triton.Common.LogUtilities.Logger;

//work mostly done by Hearthbuddy team

namespace HREngine.Bots
{
    /// <summary>Settings for the DefaultRoutine. </summary>
    public class DefaultRoutineSettings : JsonSettings
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private static DefaultRoutineSettings _instance;

        /// <summary>The current instance for this class. </summary>
        public static DefaultRoutineSettings Instance
        {
            get { return _instance ?? (_instance = new DefaultRoutineSettings()); }
        }

        /// <summary>The default ctor. Will use the settings path "DefaultRoutine".</summary>
        public DefaultRoutineSettings()
            : base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "DefaultRoutine")))
        {
        }

        private TAG_CLASS _arenaPreferredClass1;
        private TAG_CLASS _arenaPreferredClass2;
        private TAG_CLASS _arenaPreferredClass3;
        private TAG_CLASS _arenaPreferredClass4;
        private TAG_CLASS _arenaPreferredClass5;

        private TAG_MODE _botBehave;

        /// <summary>
        /// The first hero choice for arena if present.
        /// </summary>
        [DefaultValue(TAG_CLASS.HUNTER)]
        public TAG_CLASS ArenaPreferredClass1
        {
            get { return _arenaPreferredClass1; }
            set
            {
                if (!value.Equals(_arenaPreferredClass1))
                {
                    _arenaPreferredClass1 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass1);
                }
                Log.InfoFormat("[DefaultRoutineSettings] ArenaPreferredClass1 = {0}.", _arenaPreferredClass1);
            }
        }

        /// <summary>
        /// The second hero choice for arena if present.
        /// </summary>
        [DefaultValue(TAG_CLASS.WARLOCK)]
        public TAG_CLASS ArenaPreferredClass2
        {
            get { return _arenaPreferredClass2; }
            set
            {
                if (!value.Equals(_arenaPreferredClass2))
                {
                    _arenaPreferredClass2 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass2);
                }
                Log.InfoFormat("[DefaultRoutineSettings] ArenaPreferredClass2 = {0}.", _arenaPreferredClass2);
            }
        }

        /// <summary>
        /// The third hero choice for arena if present.
        /// </summary>
        [DefaultValue(TAG_CLASS.PRIEST)]
        public TAG_CLASS ArenaPreferredClass3
        {
            get { return _arenaPreferredClass3; }
            set
            {
                if (!value.Equals(_arenaPreferredClass3))
                {
                    _arenaPreferredClass3 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass3);
                }
                Log.InfoFormat("[DefaultRoutineSettings] ArenaPreferredClass3 = {0}.", _arenaPreferredClass3);
            }
        }

        /// <summary>
        /// The fourth hero choice for arena if present.
        /// </summary>
        [DefaultValue(TAG_CLASS.ROGUE)]
        public TAG_CLASS ArenaPreferredClass4
        {
            get { return _arenaPreferredClass4; }
            set
            {
                if (!value.Equals(_arenaPreferredClass4))
                {
                    _arenaPreferredClass4 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass4);
                }
                Log.InfoFormat("[DefaultRoutineSettings] ArenaPreferredClass4 = {0}.", _arenaPreferredClass4);
            }
        }

        /// <summary>
        /// The fifth hero choice for arena if present.
        /// </summary>
        [DefaultValue(TAG_CLASS.WARRIOR)]
        public TAG_CLASS ArenaPreferredClass5
        {
            get { return _arenaPreferredClass5; }
            set
            {
                if (!value.Equals(_arenaPreferredClass5))
                {
                    _arenaPreferredClass5 = value;
                    NotifyPropertyChanged(() => ArenaPreferredClass5);
                }
                Log.InfoFormat("[DefaultRoutineSettings] ArenaPreferredClass5 = {0}.", _arenaPreferredClass5);
            }
        }

        

        private ObservableCollection<TAG_CLASS> _allClasses;

        /// <summary>All enum values for this type.</summary>
        [JsonIgnore]
        public ObservableCollection<TAG_CLASS> AllClasses
        {
            get
            {
                return _allClasses ?? (_allClasses = new ObservableCollection<TAG_CLASS>
                {
                    TAG_CLASS.DRUID,
                    TAG_CLASS.HUNTER,
                    TAG_CLASS.MAGE,
                    TAG_CLASS.PALADIN,
                    TAG_CLASS.PRIEST,
                    TAG_CLASS.ROGUE,
                    TAG_CLASS.SHAMAN,
                    TAG_CLASS.WARLOCK,
                    TAG_CLASS.WARRIOR,
                });
            }
        }


        /// <summary>
        /// The behave.
        /// </summary>
        [DefaultValue(TAG_MODE.DEFAULT)]
        public TAG_MODE BotBehaviour
        {
            get { return _botBehave; }
            set
            {
                if (!value.Equals(_botBehave))
                {
                    _botBehave = value;
                    NotifyPropertyChanged(() => BotBehaviour);
                }
                Log.InfoFormat("[DefaultRoutineSettings] BotBehaviour = {0}.", _botBehave);
            }
        }

        private ObservableCollection<TAG_MODE> _allModes;

        /// <summary>All enum values for this type.</summary>
        [JsonIgnore]
        public ObservableCollection<TAG_MODE> AllModes
        {
            get
            {
                return _allModes ?? (_allModes = new ObservableCollection<TAG_MODE>
                {
                    TAG_MODE.DEFAULT,
                    TAG_MODE.CONTROL,
                    TAG_MODE.RUSH,
                    TAG_MODE.FACE,
                    TAG_MODE.TEST,
                });
            }
        }

        
    }

    public enum TAG_MODE
    {
        DEFAULT,
        CONTROL,
        RUSH,
        FACE,
        TEST
    }
}
