namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public struct targett
    {
        public int target;
        public int targetEntity;

        public targett(int targ, int ent)
        {
            this.target = targ;
            this.targetEntity = ent;
        }
    }


    public class CardDB
    {
        // Data is stored in hearthstone-folder -> data->win cardxml0
        //(data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
        public enum cardtype
        {
            NONE,
            MOB,
            SPELL,
            WEAPON,
            HEROPWR,
            ENCHANTMENT,

        }

        public enum cardrace
        {
            INVALID,
            BLOODELF,
            DRAENEI,
            DWARF,
            GNOME,
            GOBLIN,
            HUMAN,
            NIGHTELF,
            ORC,
            TAUREN,
            TROLL,
            UNDEAD,
            WORGEN,
            GOBLIN2,
            MURLOC,
            DEMON,
            SCOURGE,
            MECHANICAL,
            ELEMENTAL,
            OGRE,
            PET,
            TOTEM,
            NERUBIAN,
            PIRATE,
            DRAGON
        }


        public enum cardIDEnum
        {
            None,
            //loe####################################
            LOEA10_3,
            LOEA16_3,
            LOEA16_3e,
            LOEA16_4,
            LOEA16_5,
            LOEA16_5t,

            LOE_002,
            LOE_002t,
            LOE_003,
            LOE_006,
            LOE_007,
            LOE_007t,
            LOE_009,
            LOE_009t,
            LOE_010,
            LOE_011,
            LOE_012,
            LOE_016,
            LOE_017,
            LOE_018,
            LOE_019,
            LOE_019t,
            LOE_019t2,
            LOE_020,
            LOE_021,
            LOE_022,
            LOE_023,
            LOE_026,
            LOE_027,
            LOE_029,
            LOE_038,
            LOE_039,
            LOE_046,
            LOE_047,
            LOE_050,
            LOE_051,
            LOE_053,
            LOE_061,
            LOE_073,
            LOE_076,
            LOE_077,
            LOE_079,
            LOE_086,
            LOE_089,
            LOE_089t,
            LOE_089t2,
            LOE_089t3,
            LOE_092,
            LOE_104,
            LOE_105,
            LOE_105e,
            LOE_107,
            LOE_110,
            LOE_110t,
            LOE_111,
            LOE_113,
            LOE_115,
            LOE_115a,
            LOE_115b,
            LOE_116,
            LOE_118,
            LOE_119,

            //TGT####################################
            AT_001,
            AT_002,
            AT_003,
            AT_004,
            AT_005,
            AT_005t,
            AT_006,
            AT_006e,
            AT_007,
            AT_008,
            AT_009,
            AT_010,
            AT_011,
            AT_011e,
            AT_012,
            AT_013,
            AT_013e,
            AT_014,
            AT_014e,
            AT_015,
            AT_016,
            AT_016e,
            AT_017,
            AT_017e,
            AT_018,
            AT_019,
            AT_020,
            AT_021,
            AT_021e,
            AT_022,
            AT_023,
            AT_024,
            AT_024e,
            AT_025,
            AT_026,
            AT_027,
            AT_027e,
            AT_028,
            AT_028e,
            AT_029,
            AT_029e,
            AT_030,
            AT_031,
            AT_032,
            AT_032e,
            AT_033,
            AT_034,
            AT_034e,
            AT_035,
            AT_035t,
            AT_036,
            AT_036t,
            AT_037,
            AT_037a,
            AT_037b,
            AT_037t,
            AT_038,
            AT_039,
            AT_039e,
            AT_040,
            AT_040e,
            AT_041,
            AT_041e,
            AT_042,
            AT_042a,
            AT_042b,
            AT_042t,
            AT_042t2,
            AT_043,
            AT_044,
            AT_045,
            AT_045e,
            AT_045ee,
            AT_046,
            AT_047,
            AT_047e,
            AT_048,
            AT_049,
            AT_049e,
            AT_050,
            AT_050t,
            AT_051,
            AT_052,
            AT_053,
            AT_054,
            AT_055,
            AT_056,
            AT_057,
            AT_057o,
            AT_058,
            AT_059,
            AT_060,
            AT_061,
            AT_061e,
            AT_062,
            AT_063,
            AT_063t,
            AT_064,
            AT_065,
            AT_065e,
            AT_066,
            AT_066e,
            AT_067,
            AT_068,
            AT_068e,
            AT_069,
            AT_069e,
            AT_070,
            AT_071,
            AT_071e,
            AT_072,
            AT_073,
            AT_073e,
            AT_074,
            AT_074e2,
            AT_075,
            AT_075e,
            AT_076,
            AT_077,
            AT_077e,
            AT_078,
            AT_079,
            AT_080,
            AT_081,
            AT_081e,
            AT_082,
            AT_082e,
            AT_083,
            AT_083e,
            AT_084,
            AT_084e,
            AT_085,
            AT_086,
            AT_086e,
            AT_087,
            AT_088,
            AT_089,
            AT_089e,
            AT_090,
            AT_090e,
            AT_091,
            AT_092,
            AT_093,
            AT_094,
            AT_095,
            AT_096,
            AT_096e,
            AT_097,
            AT_098,
            AT_099,
            AT_099t,
            AT_100,
            AT_101,
            AT_102,
            AT_103,
            AT_104,
            AT_105,
            AT_106,
            AT_108,
            AT_109,
            AT_109e,
            AT_110,
            AT_111,
            AT_112,
            AT_113,
            AT_114,
            AT_115,
            AT_115e,
            AT_116,
            AT_116e,
            AT_117,
            AT_117e,
            AT_118,
            AT_119,
            AT_119e,
            AT_120,
            AT_121,
            AT_121e,
            AT_122,
            AT_123,
            AT_124,
            AT_125,
            AT_127,
            AT_128,
            AT_129,
            AT_130,
            AT_131,
            AT_132,
            AT_132_DRUID,
            AT_132_DRUIDe,
            AT_132_HUNTER,
            AT_132_MAGE,
            AT_132_PALADIN,
            AT_132_PRIEST,
            AT_132_ROGUE,
            AT_132_ROGUEt,
            AT_132_SHAMAN,
            AT_132_SHAMANa,
            AT_132_SHAMANb,
            AT_132_SHAMANc,
            AT_132_SHAMANd,
            AT_132_WARLOCK,
            AT_132_WARRIOR,
            AT_133,
            AT_133e,
            //Blackrock#############################
            BRM_001,
            BRM_002,
            BRM_003,
            BRM_004,
            BRM_005,
            BRM_006,
            BRM_006t,
            BRM_007,
            BRM_008,
            BRM_009,
            BRM_010,
            BRM_010a,
            BRM_010b,
            BRM_010t,
            BRM_010t2,
            BRM_011,
            BRM_012,
            BRM_013,
            BRM_014,
            BRM_015,
            BRM_016,
            BRM_017,
            BRM_018,
            BRM_018e,
            BRM_019,
            BRM_020,
            BRM_022,
            BRM_022t,
            BRM_024,
            BRM_025,
            BRM_026,
            BRM_027,
            BRM_027h,
            BRM_027p,
            BRM_027pH,
            BRM_028,
            BRM_028e,
            BRM_029,
            BRM_030,
            BRM_030t,
            BRM_031,
            BRM_033,
            BRM_034,
            //#Blackrock#############################
            CS1h_001,
            CS1_042,
            CS1_112,
            CS1_113,
            CS1_113e,
            CS1_130,
            CS2_003,
            CS2_004,
            CS2_004e,
            CS2_005,
            CS2_005o,
            CS2_007,
            CS2_008,
            CS2_009,
            CS2_009e,
            CS2_011,
            CS2_011o,
            CS2_012,
            CS2_013,
            CS2_013t,
            CS2_017,
            CS2_017o,
            CS2_022,
            CS2_022e,
            CS2_023,
            CS2_024,
            CS2_025,
            CS2_026,
            CS2_027,
            CS2_029,
            CS2_032,
            CS2_033,
            CS2_034,
            CS2_037,
            CS2_039,
            CS2_041,
            CS2_041e,
            CS2_042,
            CS2_045,
            CS2_045e,
            CS2_046,
            CS2_046e,
            CS2_049,
            CS2_050,
            CS2_051,
            CS2_052,
            CS2_056,
            CS2_057,
            CS2_061,
            CS2_062,
            CS2_063,
            CS2_063e,
            CS2_064,
            CS2_065,
            CS2_072,
            CS2_074,
            CS2_074e,
            CS2_075,
            CS2_076,
            CS2_077,
            CS2_080,
            CS2_082,
            CS2_083b,
            CS2_083e,
            CS2_084,
            CS2_084e,
            CS2_087,
            CS2_087e,
            CS2_088,
            CS2_089,
            CS2_091,
            CS2_092,
            CS2_092e,
            CS2_093,
            CS2_094,
            CS2_097,
            CS2_101,
            CS2_101t,
            CS2_102,
            CS2_103,
            CS2_103e2,
            CS2_105,
            CS2_105e,
            CS2_106,
            CS2_108,
            CS2_112,
            CS2_114,
            CS2_118,
            CS2_119,
            CS2_120,
            CS2_121,
            CS2_122,
            CS2_122e,
            CS2_124,
            CS2_125,
            CS2_127,
            CS2_131,
            CS2_141,
            CS2_142,
            CS2_147,
            CS2_150,
            CS2_155,
            CS2_162,
            CS2_168,
            CS2_171,
            CS2_172,
            CS2_173,
            CS2_179,
            CS2_182,
            CS2_186,
            CS2_187,
            CS2_189,
            CS2_196,
            CS2_197,
            CS2_200,
            CS2_201,
            CS2_213,
            CS2_222,
            CS2_222o,
            CS2_226,
            CS2_226e,
            CS2_232,
            CS2_234,
            CS2_235,
            CS2_236,
            CS2_236e,
            CS2_237,
            CS2_boar,
            CS2_mirror,
            CS2_tk1,
            DS1h_292,
            DS1_055,
            DS1_070,
            DS1_070o,
            DS1_175,
            DS1_175o,
            DS1_178,
            DS1_178e,
            DS1_183,
            DS1_184,
            DS1_185,
            DS1_233,
            EX1_011,
            EX1_015,
            EX1_019,
            EX1_019e,
            EX1_025,
            EX1_025t,
            EX1_066,
            EX1_084,
            EX1_084e,
            EX1_129,
            EX1_169,
            EX1_173,
            EX1_244,
            EX1_244e,
            EX1_246,
            EX1_246e,
            EX1_277,
            EX1_278,
            EX1_302,
            EX1_306,
            EX1_308,
            EX1_360,
            EX1_360e,
            EX1_371,
            EX1_399,
            EX1_399e,
            EX1_400,
            EX1_506,
            EX1_506a,
            EX1_508,
            EX1_508o,
            EX1_539,
            EX1_565,
            EX1_565o,
            EX1_581,
            EX1_582,
            EX1_587,
            EX1_593,
            EX1_606,
            EX1_622,
            GAME_001,
            GAME_002,
            GAME_003,
            GAME_003e,
            GAME_004,
            GAME_005,
            GAME_005e,
            GAME_006,
            HERO_01,
            HERO_02,
            HERO_03,
            HERO_04,
            HERO_05,
            HERO_06,
            HERO_07,
            HERO_08,
            HERO_09,
            HERO_01a,
            HERO_02a,
            HERO_03a,
            HERO_04a,
            HERO_05a,
            HERO_06a,
            HERO_07a,
            HERO_08a,
            HERO_09a,
            hexfrog,
            NEW1_003,
            NEW1_004,
            NEW1_009,
            NEW1_011,
            NEW1_031,
            NEW1_032,
            NEW1_033,
            NEW1_033o,
            NEW1_034,
            skele11,
            CS1_069,
            CS1_129,
            CS1_129e,
            CS2_028,
            CS2_031,
            CS2_038,
            CS2_038e,
            CS2_053,
            CS2_053e,
            CS2_059,
            CS2_059o,
            CS2_073,
            CS2_073e,
            CS2_073e2,
            CS2_104,
            CS2_104e,
            CS2_117,
            CS2_146,
            CS2_146o,
            CS2_151,
            CS2_152,
            CS2_161,
            CS2_169,
            CS2_181,
            CS2_181e,
            CS2_188,
            CS2_188o,
            CS2_203,
            CS2_221,
            CS2_221e,
            CS2_227,
            CS2_231,
            CS2_233,
            DREAM_01,
            DREAM_02,
            DREAM_03,
            DREAM_04,
            DREAM_05,
            DREAM_05e,
            DS1_188,
            ds1_whelptoken,
            EX1_001,
            EX1_001e,
            EX1_002,
            EX1_004,
            EX1_004e,
            EX1_005,
            EX1_006,
            EX1_007,
            EX1_008,
            EX1_009,
            EX1_010,
            EX1_012,
            EX1_014,
            EX1_014t,
            EX1_014te,
            EX1_016,
            EX1_017,
            EX1_020,
            EX1_021,
            EX1_023,
            EX1_028,
            EX1_029,
            EX1_032,
            EX1_033,
            EX1_043,
            EX1_043e,
            EX1_044,
            EX1_044e,
            EX1_045,
            EX1_046,
            EX1_046e,
            EX1_048,
            EX1_049,
            EX1_050,
            EX1_055,
            EX1_055o,
            EX1_057,
            EX1_058,
            EX1_059,
            EX1_059e,
            EX1_067,
            EX1_076,
            EX1_080,
            EX1_080o,
            EX1_082,
            EX1_083,
            EX1_085,
            EX1_089,
            EX1_091,
            EX1_093,
            EX1_093e,
            EX1_095,
            EX1_096,
            EX1_097,
            EX1_100,
            EX1_102,
            EX1_103,
            EX1_103e,
            EX1_105,
            EX1_110,
            EX1_110t,
            EX1_116,
            EX1_116t,
            EX1_124,
            EX1_126,
            EX1_128,
            EX1_128e,
            EX1_130,
            EX1_130a,
            EX1_131,
            EX1_131t,
            EX1_132,
            EX1_133,
            EX1_134,
            EX1_136,
            EX1_137,
            EX1_144,
            EX1_145,
            EX1_145o,
            EX1_154,
            EX1_154a,
            EX1_154b,
            EX1_155,
            EX1_155a,
            EX1_155ae,
            EX1_155b,
            EX1_155be,
            EX1_158,
            EX1_158e,
            EX1_158t,
            EX1_160,
            EX1_160a,
            EX1_160b,
            EX1_160be,
            EX1_160t,
            EX1_161,
            EX1_161o,
            EX1_162,
            EX1_162o,
            EX1_164,
            EX1_164a,
            EX1_164b,
            EX1_165,
            EX1_165a,
            EX1_165b,
            EX1_165t1,
            EX1_165t2,
            EX1_166,
            EX1_166a,
            EX1_166b,
            EX1_170,
            EX1_178,
            EX1_178a,
            EX1_178ae,
            EX1_178b,
            EX1_178be,
            EX1_238,
            EX1_241,
            EX1_243,
            EX1_245,
            EX1_247,
            EX1_248,
            EX1_249,
            EX1_250,
            EX1_251,
            EX1_258,
            EX1_258e,
            EX1_259,
            EX1_274,
            EX1_274e,
            EX1_275,
            EX1_279,
            EX1_283,
            EX1_284,
            EX1_287,
            EX1_289,
            EX1_294,
            EX1_295,
            EX1_295o,
            EX1_298,
            EX1_301,
            EX1_303,
            EX1_304,
            EX1_304e,
            EX1_309,
            EX1_310,
            EX1_312,
            EX1_313,
            EX1_315,
            EX1_316,
            EX1_316e,
            EX1_317,
            EX1_317t,
            EX1_319,
            EX1_320,
            EX1_323,
            EX1_323h,
            EX1_323w,
            EX1_332,
            EX1_334,
            EX1_334e,
            EX1_335,
            EX1_339,
            EX1_341,
            EX1_345,
            EX1_345t,
            EX1_349,
            EX1_350,
            EX1_354,
            EX1_355,
            EX1_355e,
            EX1_362,
            EX1_363,
            EX1_363e,
            EX1_363e2,
            EX1_365,
            EX1_366,
            EX1_366e,
            EX1_379,
            EX1_379e,
            EX1_382,
            EX1_382e,
            EX1_383,
            EX1_383t,
            EX1_384,
            EX1_390,
            EX1_391,
            EX1_392,
            EX1_393,
            EX1_396,
            EX1_398,
            EX1_398t,
            EX1_402,
            EX1_405,
            EX1_407,
            EX1_408,
            EX1_409,
            EX1_409e,
            EX1_409t,
            EX1_410,
            EX1_411,
            EX1_411e,
            EX1_411e2,
            EX1_412,
            EX1_414,
            EX1_507,
            EX1_507e,
            EX1_509,
            EX1_509e,
            EX1_522,
            EX1_531,
            EX1_531e,
            EX1_533,
            EX1_534,
            EX1_534t,
            EX1_536,
            EX1_536e,
            EX1_537,
            EX1_538,
            EX1_538t,
            EX1_543,
            EX1_544,
            EX1_549,
            EX1_549o,
            EX1_554,
            EX1_554t,
            EX1_556,
            EX1_557,
            EX1_558,
            EX1_559,
            EX1_560,
            EX1_561,
            EX1_561e,
            EX1_562,
            EX1_563,
            EX1_564,
            EX1_567,
            EX1_570,
            EX1_570e,
            EX1_571,
            EX1_572,
            EX1_573,
            EX1_573a,
            EX1_573ae,
            EX1_573b,
            EX1_573t,
            EX1_575,
            EX1_577,
            EX1_578,
            EX1_583,
            EX1_584,
            EX1_584e,
            EX1_586,
            EX1_590,
            EX1_590e,
            EX1_591,
            EX1_594,
            EX1_595,
            EX1_596,
            EX1_596e,
            EX1_597,
            EX1_598,
            EX1_603,
            EX1_603e,
            EX1_604,
            EX1_604o,
            EX1_607,
            EX1_607e,
            EX1_608,
            EX1_609,
            EX1_610,
            EX1_611,
            EX1_611e,
            EX1_612,
            EX1_612o,
            EX1_613,
            EX1_613e,
            EX1_614,
            EX1_614t,
            EX1_616,
            EX1_617,
            EX1_619,
            EX1_619e,
            EX1_620,
            EX1_621,
            EX1_623,
            EX1_623e,
            EX1_624,
            EX1_625,
            EX1_625t,
            EX1_625t2,
            EX1_626,
            EX1_finkle,
            EX1_tk11,
            EX1_tk28,
            EX1_tk29,
            EX1_tk31,
            EX1_tk33,
            EX1_tk34,
            EX1_tk9,
            NEW1_005,
            NEW1_007,
            NEW1_007a,
            NEW1_007b,
            NEW1_008,
            NEW1_008a,
            NEW1_008b,
            NEW1_010,
            NEW1_012,
            NEW1_012o,
            NEW1_014,
            NEW1_017,
            NEW1_017e,
            NEW1_018,
            NEW1_018e,
            NEW1_019,
            NEW1_020,
            NEW1_021,
            NEW1_022,
            NEW1_023,
            NEW1_024,
            NEW1_024o,
            NEW1_025,
            NEW1_025e,
            NEW1_026,
            NEW1_026t,
            NEW1_027,
            NEW1_027e,
            NEW1_029,
            NEW1_029t,
            NEW1_030,
            NEW1_036,
            NEW1_036e,
            NEW1_036e2,
            NEW1_037,
            NEW1_037e,
            NEW1_038,
            NEW1_038o,
            NEW1_040,
            NEW1_040t,
            NEW1_041,
            skele21,
            tt_004,
            tt_004o,
            tt_010,
            tt_010a,
            CRED_01,
            CRED_02,
            CRED_03,
            CRED_04,
            CRED_05,
            CRED_06,
            CRED_07,
            CRED_08,
            CRED_09,
            CRED_10,
            CRED_11,
            CRED_12,
            CRED_13,
            CRED_14,
            CRED_15,
            CRED_16,
            CRED_17,
            EX1_062,
            NEW1_016,
            TU4a_001,
            TU4a_002,
            TU4a_003,
            TU4a_004,
            TU4a_005,
            TU4a_006,
            TU4b_001,
            TU4c_001,
            TU4c_002,
            TU4c_003,
            TU4c_004,
            TU4c_005,
            TU4c_006,
            TU4c_006e,
            TU4c_007,
            TU4c_008,
            TU4c_008e,
            TU4d_001,
            TU4d_002,
            TU4d_003,
            TU4e_001,
            TU4e_002,
            TU4e_002t,
            TU4e_003,
            TU4e_004,
            TU4e_005,
            TU4e_007,
            TU4f_001,
            TU4f_002,
            TU4f_003,
            TU4f_004,
            TU4f_004o,
            TU4f_005,
            TU4f_006,
            TU4f_006o,
            TU4f_007,
            XXX_001,
            XXX_002,
            XXX_003,
            XXX_004,
            XXX_005,
            XXX_006,
            XXX_007,
            XXX_008,
            XXX_009,
            XXX_009e,
            XXX_010,
            XXX_011,
            XXX_012,
            XXX_013,
            XXX_014,
            XXX_015,
            XXX_016,
            XXX_017,
            XXX_018,
            XXX_019,
            XXX_020,
            XXX_021,
            XXX_022,
            XXX_022e,
            XXX_023,
            XXX_024,
            XXX_025,
            XXX_026,
            XXX_027,
            XXX_028,
            XXX_029,
            XXX_030,
            XXX_039,
            XXX_040,
            XXX_041,
            XXX_042,
            XXX_043,
            XXX_044,
            XXX_045,
            XXX_046,
            XXX_047,
            XXX_048,
            XXX_049,
            XXX_050,
            XXX_051,
            XXX_052,
            XXX_053,
            XXX_054,
            XXX_054e,
            XXX_055,
            XXX_055e,
            XXX_056,
            XXX_057,
            XXX_095,
            XXX_096,
            XXX_097,
            XXX_098,
            XXX_099,
            EX1_112,
            Mekka1,
            Mekka2,
            Mekka3,
            Mekka3e,
            Mekka4,
            Mekka4e,
            Mekka4t,
            PRO_001,
            PRO_001a,
            PRO_001at,
            PRO_001b,
            PRO_001c,
            FP1_001,
            FP1_002,
            FP1_002t,
            FP1_003,
            FP1_004,
            FP1_005,
            FP1_005e,
            FP1_006,
            FP1_007,
            FP1_007t,
            FP1_008,
            FP1_009,
            FP1_010,
            FP1_011,
            FP1_012,
            FP1_012t,
            FP1_013,
            FP1_014,
            FP1_014t,
            FP1_015,
            FP1_016,
            FP1_017,
            FP1_018,
            FP1_019,
            FP1_019t,
            FP1_020,
            FP1_020e,
            FP1_021,
            FP1_022,
            FP1_023,
            FP1_023e,
            FP1_024,
            FP1_025,
            FP1_026,
            FP1_027,
            FP1_028,
            FP1_028e,
            FP1_029,
            FP1_030,
            FP1_030e,
            FP1_031,
            NAX10_01,
            NAX10_01H,
            NAX10_02,
            NAX10_02H,
            NAX10_03,
            NAX10_03H,
            NAX11_01,
            NAX11_01H,
            NAX11_02,
            NAX11_02H,
            NAX11_03,
            NAX11_04,
            NAX11_04e,
            NAX12_01,
            NAX12_01H,
            NAX12_02,
            NAX12_02e,
            NAX12_02H,
            NAX12_03,
            NAX12_03e,
            NAX12_03H,
            NAX12_04,
            NAX12_04e,
            NAX13_01,
            NAX13_01H,
            NAX13_02,
            NAX13_02e,
            NAX13_03,
            NAX13_03e,
            NAX13_04H,
            NAX13_05H,
            NAX14_01,
            NAX14_01H,
            NAX14_02,
            NAX14_03,
            NAX14_04,
            NAX15_01,
            NAX15_01e,
            NAX15_01H,
            NAX15_01He,
            NAX15_02,
            NAX15_02H,
            NAX15_03n,
            NAX15_03t,
            NAX15_04,
            NAX15_04a,
            NAX15_04H,
            NAX15_05,
            NAX1h_01,
            NAX1h_03,
            NAX1h_04,
            NAX1_01,
            NAX1_03,
            NAX1_04,
            NAX1_05,
            NAX2_01,
            NAX2_01H,
            NAX2_03,
            NAX2_03H,
            NAX2_05,
            NAX2_05H,
            NAX3_01,
            NAX3_01H,
            NAX3_02,
            NAX3_02H,
            NAX3_03,
            NAX4_01,
            NAX4_01H,
            NAX4_03,
            NAX4_03H,
            NAX4_04,
            NAX4_04H,
            NAX4_05,
            NAX5_01,
            NAX5_01H,
            NAX5_02,
            NAX5_02H,
            NAX5_03,
            NAX6_01,
            NAX6_01H,
            NAX6_02,
            NAX6_02H,
            NAX6_03,
            NAX6_03t,
            NAX6_03te,
            NAX6_04,
            NAX7_01,
            NAX7_01H,
            NAX7_02,
            NAX7_03,
            NAX7_03H,
            NAX7_04,
            NAX7_04H,
            NAX7_05,
            NAX8_01,
            NAX8_01H,
            NAX8_02,
            NAX8_02H,
            NAX8_03,
            NAX8_03t,
            NAX8_04,
            NAX8_04t,
            NAX8_05,
            NAX8_05t,
            NAX9_01,
            NAX9_01H,
            NAX9_02,
            NAX9_02H,
            NAX9_03,
            NAX9_03H,
            NAX9_04,
            NAX9_04H,
            NAX9_05,
            NAX9_05H,
            NAX9_06,
            NAX9_07,
            NAX9_07e,
            NAXM_001,
            NAXM_002,
            GVG_001,
            GVG_002,
            GVG_003,
            GVG_004,
            GVG_005,
            GVG_006,
            GVG_007,
            GVG_008,
            GVG_009,
            GVG_010,
            GVG_010b,
            GVG_011,
            GVG_011a,
            GVG_012,
            GVG_013,
            GVG_014,
            GVG_014a,
            GVG_015,
            GVG_016,
            GVG_017,
            GVG_018,
            GVG_019,
            GVG_019e,
            GVG_020,
            GVG_021,
            GVG_021e,
            GVG_022,
            GVG_022a,
            GVG_022b,
            GVG_023,
            GVG_023a,
            GVG_024,
            GVG_025,
            GVG_026,
            GVG_027,
            GVG_027e,
            GVG_028,
            GVG_028t,
            GVG_029,
            GVG_030,
            GVG_030a,
            GVG_030ae,
            GVG_030b,
            GVG_030be,
            GVG_031,
            GVG_032,
            GVG_032a,
            GVG_032b,
            GVG_033,
            GVG_034,
            GVG_035,
            GVG_036,
            GVG_036e,
            GVG_037,
            GVG_038,
            GVG_039,
            GVG_040,
            GVG_041,
            GVG_041a,
            GVG_041b,
            GVG_041c,
            GVG_042,
            GVG_043,
            GVG_043e,
            GVG_044,
            GVG_045,
            GVG_045t,
            GVG_046,
            GVG_046e,
            GVG_047,
            GVG_048,
            GVG_048e,
            GVG_049,
            GVG_049e,
            GVG_050,
            GVG_051,
            GVG_052,
            GVG_053,
            GVG_054,
            GVG_055,
            GVG_055e,
            GVG_056,
            GVG_056t,
            GVG_057,
            GVG_057a,
            GVG_058,
            GVG_059,
            GVG_060,
            GVG_060e,
            GVG_061,
            GVG_062,
            GVG_063,
            GVG_063a,
            GVG_064,
            GVG_065,
            GVG_066,
            GVG_067,
            GVG_067a,
            GVG_068,
            GVG_068a,
            GVG_069,
            GVG_069a,
            GVG_070,
            GVG_071,
            GVG_072,
            GVG_073,
            GVG_074,
            GVG_075,
            GVG_076,
            GVG_076a,
            GVG_077,
            GVG_078,
            GVG_079,
            GVG_080,
            GVG_080t,
            GVG_081,
            GVG_082,
            GVG_083,
            GVG_084,
            GVG_085,
            GVG_086,
            GVG_086e,
            GVG_087,
            GVG_088,
            GVG_089,
            GVG_090,
            GVG_091,
            GVG_092,
            GVG_092t,
            GVG_093,
            GVG_094,
            GVG_095,
            GVG_096,
            GVG_097,
            GVG_098,
            GVG_099,
            GVG_100,
            GVG_100e,
            GVG_101,
            GVG_101e,
            GVG_102,
            GVG_102e,
            GVG_103,
            GVG_104,
            GVG_104a,
            GVG_105,
            GVG_106,
            GVG_106e,
            GVG_107,
            GVG_108,
            GVG_109,
            GVG_110,
            GVG_110t,
            GVG_111,
            GVG_111t,
            GVG_112,
            GVG_113,
            GVG_114,
            GVG_115,
            GVG_116,
            GVG_117,
            GVG_118,
            GVG_119,
            GVG_120,
            GVG_121,
            GVG_122,
            GVG_123,
            GVG_123e,
            PART_001,
            PART_001e,
            PART_002,
            PART_003,
            PART_004,
            PART_004e,
            PART_005,
            PART_006,
            PART_006a,
            PART_007,
            PART_007e,
            PlaceholderCard

        }

        public cardIDEnum cardIdstringToEnum(string s)
        {

            if (s == "AT_001") return CardDB.cardIDEnum.AT_001;
            if (s == "AT_002") return CardDB.cardIDEnum.AT_002;
            if (s == "AT_003") return CardDB.cardIDEnum.AT_003;
            if (s == "AT_004") return CardDB.cardIDEnum.AT_004;
            if (s == "AT_005") return CardDB.cardIDEnum.AT_005;
            if (s == "AT_005t") return CardDB.cardIDEnum.AT_005t;
            if (s == "AT_006") return CardDB.cardIDEnum.AT_006;
            if (s == "AT_006e") return CardDB.cardIDEnum.AT_006e;
            if (s == "AT_007") return CardDB.cardIDEnum.AT_007;
            if (s == "AT_008") return CardDB.cardIDEnum.AT_008;
            if (s == "AT_009") return CardDB.cardIDEnum.AT_009;
            if (s == "AT_010") return CardDB.cardIDEnum.AT_010;
            if (s == "AT_011") return CardDB.cardIDEnum.AT_011;
            if (s == "AT_011e") return CardDB.cardIDEnum.AT_011e;
            if (s == "AT_012") return CardDB.cardIDEnum.AT_012;
            if (s == "AT_013") return CardDB.cardIDEnum.AT_013;
            if (s == "AT_013e") return CardDB.cardIDEnum.AT_013e;
            if (s == "AT_014") return CardDB.cardIDEnum.AT_014;
            if (s == "AT_014e") return CardDB.cardIDEnum.AT_014e;
            if (s == "AT_015") return CardDB.cardIDEnum.AT_015;
            if (s == "AT_016") return CardDB.cardIDEnum.AT_016;
            if (s == "AT_016e") return CardDB.cardIDEnum.AT_016e;
            if (s == "AT_017") return CardDB.cardIDEnum.AT_017;
            if (s == "AT_017e") return CardDB.cardIDEnum.AT_017e;
            if (s == "AT_018") return CardDB.cardIDEnum.AT_018;
            if (s == "AT_019") return CardDB.cardIDEnum.AT_019;
            if (s == "AT_020") return CardDB.cardIDEnum.AT_020;
            if (s == "AT_021") return CardDB.cardIDEnum.AT_021;
            if (s == "AT_021e") return CardDB.cardIDEnum.AT_021e;
            if (s == "AT_022") return CardDB.cardIDEnum.AT_022;
            if (s == "AT_023") return CardDB.cardIDEnum.AT_023;
            if (s == "AT_024") return CardDB.cardIDEnum.AT_024;
            if (s == "AT_024e") return CardDB.cardIDEnum.AT_024e;
            if (s == "AT_025") return CardDB.cardIDEnum.AT_025;
            if (s == "AT_026") return CardDB.cardIDEnum.AT_026;
            if (s == "AT_027") return CardDB.cardIDEnum.AT_027;
            if (s == "AT_027e") return CardDB.cardIDEnum.AT_027e;
            if (s == "AT_028") return CardDB.cardIDEnum.AT_028;
            if (s == "AT_028e") return CardDB.cardIDEnum.AT_028e;
            if (s == "AT_029") return CardDB.cardIDEnum.AT_029;
            if (s == "AT_029e") return CardDB.cardIDEnum.AT_029e;
            if (s == "AT_030") return CardDB.cardIDEnum.AT_030;
            if (s == "AT_031") return CardDB.cardIDEnum.AT_031;
            if (s == "AT_032") return CardDB.cardIDEnum.AT_032;
            if (s == "AT_032e") return CardDB.cardIDEnum.AT_032e;
            if (s == "AT_033") return CardDB.cardIDEnum.AT_033;
            if (s == "AT_034") return CardDB.cardIDEnum.AT_034;
            if (s == "AT_034e") return CardDB.cardIDEnum.AT_034e;
            if (s == "AT_035") return CardDB.cardIDEnum.AT_035;
            if (s == "AT_035t") return CardDB.cardIDEnum.AT_035t;
            if (s == "AT_036") return CardDB.cardIDEnum.AT_036;
            if (s == "AT_036t") return CardDB.cardIDEnum.AT_036t;
            if (s == "AT_037") return CardDB.cardIDEnum.AT_037;
            if (s == "AT_037a") return CardDB.cardIDEnum.AT_037a;
            if (s == "AT_037b") return CardDB.cardIDEnum.AT_037b;
            if (s == "AT_037t") return CardDB.cardIDEnum.AT_037t;
            if (s == "AT_038") return CardDB.cardIDEnum.AT_038;
            if (s == "AT_039") return CardDB.cardIDEnum.AT_039;
            if (s == "AT_039e") return CardDB.cardIDEnum.AT_039e;
            if (s == "AT_040") return CardDB.cardIDEnum.AT_040;
            if (s == "AT_040e") return CardDB.cardIDEnum.AT_040e;
            if (s == "AT_041") return CardDB.cardIDEnum.AT_041;
            if (s == "AT_041e") return CardDB.cardIDEnum.AT_041e;
            if (s == "AT_042") return CardDB.cardIDEnum.AT_042;
            if (s == "AT_042a") return CardDB.cardIDEnum.AT_042a;
            if (s == "AT_042b") return CardDB.cardIDEnum.AT_042b;
            if (s == "AT_042t") return CardDB.cardIDEnum.AT_042t;
            if (s == "AT_042t2") return CardDB.cardIDEnum.AT_042t2;
            if (s == "AT_043") return CardDB.cardIDEnum.AT_043;
            if (s == "AT_044") return CardDB.cardIDEnum.AT_044;
            if (s == "AT_045") return CardDB.cardIDEnum.AT_045;
            if (s == "AT_045e") return CardDB.cardIDEnum.AT_045e;
            if (s == "AT_045ee") return CardDB.cardIDEnum.AT_045ee;
            if (s == "AT_046") return CardDB.cardIDEnum.AT_046;
            if (s == "AT_047") return CardDB.cardIDEnum.AT_047;
            if (s == "AT_047e") return CardDB.cardIDEnum.AT_047e;
            if (s == "AT_048") return CardDB.cardIDEnum.AT_048;
            if (s == "AT_049") return CardDB.cardIDEnum.AT_049;
            if (s == "AT_049e") return CardDB.cardIDEnum.AT_049e;
            if (s == "AT_050") return CardDB.cardIDEnum.AT_050;
            if (s == "AT_050t") return CardDB.cardIDEnum.AT_050t;
            if (s == "AT_051") return CardDB.cardIDEnum.AT_051;
            if (s == "AT_052") return CardDB.cardIDEnum.AT_052;
            if (s == "AT_053") return CardDB.cardIDEnum.AT_053;
            if (s == "AT_054") return CardDB.cardIDEnum.AT_054;
            if (s == "AT_055") return CardDB.cardIDEnum.AT_055;
            if (s == "AT_056") return CardDB.cardIDEnum.AT_056;
            if (s == "AT_057") return CardDB.cardIDEnum.AT_057;
            if (s == "AT_057o") return CardDB.cardIDEnum.AT_057o;
            if (s == "AT_058") return CardDB.cardIDEnum.AT_058;
            if (s == "AT_059") return CardDB.cardIDEnum.AT_059;
            if (s == "AT_060") return CardDB.cardIDEnum.AT_060;
            if (s == "AT_061") return CardDB.cardIDEnum.AT_061;
            if (s == "AT_061e") return CardDB.cardIDEnum.AT_061e;
            if (s == "AT_062") return CardDB.cardIDEnum.AT_062;
            if (s == "AT_063") return CardDB.cardIDEnum.AT_063;
            if (s == "AT_063t") return CardDB.cardIDEnum.AT_063t;
            if (s == "AT_064") return CardDB.cardIDEnum.AT_064;
            if (s == "AT_065") return CardDB.cardIDEnum.AT_065;
            if (s == "AT_065e") return CardDB.cardIDEnum.AT_065e;
            if (s == "AT_066") return CardDB.cardIDEnum.AT_066;
            if (s == "AT_066e") return CardDB.cardIDEnum.AT_066e;
            if (s == "AT_067") return CardDB.cardIDEnum.AT_067;
            if (s == "AT_068") return CardDB.cardIDEnum.AT_068;
            if (s == "AT_068e") return CardDB.cardIDEnum.AT_068e;
            if (s == "AT_069") return CardDB.cardIDEnum.AT_069;
            if (s == "AT_069e") return CardDB.cardIDEnum.AT_069e;
            if (s == "AT_070") return CardDB.cardIDEnum.AT_070;
            if (s == "AT_071") return CardDB.cardIDEnum.AT_071;
            if (s == "AT_071e") return CardDB.cardIDEnum.AT_071e;
            if (s == "AT_072") return CardDB.cardIDEnum.AT_072;
            if (s == "AT_073") return CardDB.cardIDEnum.AT_073;
            if (s == "AT_073e") return CardDB.cardIDEnum.AT_073e;
            if (s == "AT_074") return CardDB.cardIDEnum.AT_074;
            if (s == "AT_074e2") return CardDB.cardIDEnum.AT_074e2;
            if (s == "AT_075") return CardDB.cardIDEnum.AT_075;
            if (s == "AT_075e") return CardDB.cardIDEnum.AT_075e;
            if (s == "AT_076") return CardDB.cardIDEnum.AT_076;
            if (s == "AT_077") return CardDB.cardIDEnum.AT_077;
            if (s == "AT_077e") return CardDB.cardIDEnum.AT_077e;
            if (s == "AT_078") return CardDB.cardIDEnum.AT_078;
            if (s == "AT_079") return CardDB.cardIDEnum.AT_079;
            if (s == "AT_080") return CardDB.cardIDEnum.AT_080;
            if (s == "AT_081") return CardDB.cardIDEnum.AT_081;
            if (s == "AT_081e") return CardDB.cardIDEnum.AT_081e;
            if (s == "AT_082") return CardDB.cardIDEnum.AT_082;
            if (s == "AT_082e") return CardDB.cardIDEnum.AT_082e;
            if (s == "AT_083") return CardDB.cardIDEnum.AT_083;
            if (s == "AT_083e") return CardDB.cardIDEnum.AT_083e;
            if (s == "AT_084") return CardDB.cardIDEnum.AT_084;
            if (s == "AT_084e") return CardDB.cardIDEnum.AT_084e;
            if (s == "AT_085") return CardDB.cardIDEnum.AT_085;
            if (s == "AT_086") return CardDB.cardIDEnum.AT_086;
            if (s == "AT_086e") return CardDB.cardIDEnum.AT_086e;
            if (s == "AT_087") return CardDB.cardIDEnum.AT_087;
            if (s == "AT_088") return CardDB.cardIDEnum.AT_088;
            if (s == "AT_089") return CardDB.cardIDEnum.AT_089;
            if (s == "AT_089e") return CardDB.cardIDEnum.AT_089e;
            if (s == "AT_090") return CardDB.cardIDEnum.AT_090;
            if (s == "AT_090e") return CardDB.cardIDEnum.AT_090e;
            if (s == "AT_091") return CardDB.cardIDEnum.AT_091;
            if (s == "AT_092") return CardDB.cardIDEnum.AT_092;
            if (s == "AT_093") return CardDB.cardIDEnum.AT_093;
            if (s == "AT_094") return CardDB.cardIDEnum.AT_094;
            if (s == "AT_095") return CardDB.cardIDEnum.AT_095;
            if (s == "AT_096") return CardDB.cardIDEnum.AT_096;
            if (s == "AT_096e") return CardDB.cardIDEnum.AT_096e;
            if (s == "AT_097") return CardDB.cardIDEnum.AT_097;
            if (s == "AT_098") return CardDB.cardIDEnum.AT_098;
            if (s == "AT_099") return CardDB.cardIDEnum.AT_099;
            if (s == "AT_099t") return CardDB.cardIDEnum.AT_099t;
            if (s == "AT_100") return CardDB.cardIDEnum.AT_100;
            if (s == "AT_101") return CardDB.cardIDEnum.AT_101;
            if (s == "AT_102") return CardDB.cardIDEnum.AT_102;
            if (s == "AT_103") return CardDB.cardIDEnum.AT_103;
            if (s == "AT_104") return CardDB.cardIDEnum.AT_104;
            if (s == "AT_105") return CardDB.cardIDEnum.AT_105;
            if (s == "AT_106") return CardDB.cardIDEnum.AT_106;
            if (s == "AT_108") return CardDB.cardIDEnum.AT_108;
            if (s == "AT_109") return CardDB.cardIDEnum.AT_109;
            if (s == "AT_109e") return CardDB.cardIDEnum.AT_109e;
            if (s == "AT_110") return CardDB.cardIDEnum.AT_110;
            if (s == "AT_111") return CardDB.cardIDEnum.AT_111;
            if (s == "AT_112") return CardDB.cardIDEnum.AT_112;
            if (s == "AT_113") return CardDB.cardIDEnum.AT_113;
            if (s == "AT_114") return CardDB.cardIDEnum.AT_114;
            if (s == "AT_115") return CardDB.cardIDEnum.AT_115;
            if (s == "AT_115e") return CardDB.cardIDEnum.AT_115e;
            if (s == "AT_116") return CardDB.cardIDEnum.AT_116;
            if (s == "AT_116e") return CardDB.cardIDEnum.AT_116e;
            if (s == "AT_117") return CardDB.cardIDEnum.AT_117;
            if (s == "AT_117e") return CardDB.cardIDEnum.AT_117e;
            if (s == "AT_118") return CardDB.cardIDEnum.AT_118;
            if (s == "AT_119") return CardDB.cardIDEnum.AT_119;
            if (s == "AT_119e") return CardDB.cardIDEnum.AT_119e;
            if (s == "AT_120") return CardDB.cardIDEnum.AT_120;
            if (s == "AT_121") return CardDB.cardIDEnum.AT_121;
            if (s == "AT_121e") return CardDB.cardIDEnum.AT_121e;
            if (s == "AT_122") return CardDB.cardIDEnum.AT_122;
            if (s == "AT_123") return CardDB.cardIDEnum.AT_123;
            if (s == "AT_124") return CardDB.cardIDEnum.AT_124;
            if (s == "AT_125") return CardDB.cardIDEnum.AT_125;
            if (s == "AT_127") return CardDB.cardIDEnum.AT_127;
            if (s == "AT_128") return CardDB.cardIDEnum.AT_128;
            if (s == "AT_129") return CardDB.cardIDEnum.AT_129;
            if (s == "AT_130") return CardDB.cardIDEnum.AT_130;
            if (s == "AT_131") return CardDB.cardIDEnum.AT_131;
            if (s == "AT_132") return CardDB.cardIDEnum.AT_132;
            if (s == "AT_132_DRUID") return CardDB.cardIDEnum.AT_132_DRUID;
            if (s == "AT_132_DRUIDe") return CardDB.cardIDEnum.AT_132_DRUIDe;
            if (s == "AT_132_HUNTER") return CardDB.cardIDEnum.AT_132_HUNTER;
            if (s == "AT_132_MAGE") return CardDB.cardIDEnum.AT_132_MAGE;
            if (s == "AT_132_PALADIN") return CardDB.cardIDEnum.AT_132_PALADIN;
            if (s == "AT_132_PRIEST") return CardDB.cardIDEnum.AT_132_PRIEST;
            if (s == "AT_132_ROGUE") return CardDB.cardIDEnum.AT_132_ROGUE;
            if (s == "AT_132_ROGUEt") return CardDB.cardIDEnum.AT_132_ROGUEt;
            if (s == "AT_132_SHAMAN") return CardDB.cardIDEnum.AT_132_SHAMAN;
            if (s == "AT_132_SHAMANa") return CardDB.cardIDEnum.AT_132_SHAMANa;
            if (s == "AT_132_SHAMANb") return CardDB.cardIDEnum.AT_132_SHAMANb;
            if (s == "AT_132_SHAMANc") return CardDB.cardIDEnum.AT_132_SHAMANc;
            if (s == "AT_132_SHAMANd") return CardDB.cardIDEnum.AT_132_SHAMANd;
            if (s == "AT_132_WARLOCK") return CardDB.cardIDEnum.AT_132_WARLOCK;
            if (s == "AT_132_WARRIOR") return CardDB.cardIDEnum.AT_132_WARRIOR;
            if (s == "AT_133") return CardDB.cardIDEnum.AT_133;
            if (s == "AT_133e") return CardDB.cardIDEnum.AT_133e;
            //brock
            if (s == "BRM_001") return CardDB.cardIDEnum.BRM_001;
            if (s == "BRM_002") return CardDB.cardIDEnum.BRM_002;
            if (s == "BRM_003") return CardDB.cardIDEnum.BRM_003;
            if (s == "BRM_004") return CardDB.cardIDEnum.BRM_004;
            if (s == "BRM_005") return CardDB.cardIDEnum.BRM_005;
            if (s == "BRM_006") return CardDB.cardIDEnum.BRM_006;
            if (s == "BRM_006t") return CardDB.cardIDEnum.BRM_006t;
            if (s == "BRM_007") return CardDB.cardIDEnum.BRM_007;
            if (s == "BRM_008") return CardDB.cardIDEnum.BRM_008;
            if (s == "BRM_009") return CardDB.cardIDEnum.BRM_009;
            if (s == "BRM_010") return CardDB.cardIDEnum.BRM_010;
            if (s == "BRM_010a") return CardDB.cardIDEnum.BRM_010a;
            if (s == "BRM_010b") return CardDB.cardIDEnum.BRM_010b;
            if (s == "BRM_010t") return CardDB.cardIDEnum.BRM_010t;
            if (s == "BRM_010t2") return CardDB.cardIDEnum.BRM_010t2;
            if (s == "BRM_011") return CardDB.cardIDEnum.BRM_011;
            if (s == "BRM_012") return CardDB.cardIDEnum.BRM_012;
            if (s == "BRM_013") return CardDB.cardIDEnum.BRM_013;
            if (s == "BRM_014") return CardDB.cardIDEnum.BRM_014;
            if (s == "BRM_015") return CardDB.cardIDEnum.BRM_015;
            if (s == "BRM_016") return CardDB.cardIDEnum.BRM_016;
            if (s == "BRM_017") return CardDB.cardIDEnum.BRM_017;
            if (s == "BRM_018") return CardDB.cardIDEnum.BRM_018;
            if (s == "BRM_018e") return CardDB.cardIDEnum.BRM_018e;
            if (s == "BRM_019") return CardDB.cardIDEnum.BRM_019;
            if (s == "BRM_020") return CardDB.cardIDEnum.BRM_020;
            if (s == "BRM_022") return CardDB.cardIDEnum.BRM_022;
            if (s == "BRM_022t") return CardDB.cardIDEnum.BRM_022t;
            if (s == "BRM_024") return CardDB.cardIDEnum.BRM_024;
            if (s == "BRM_025") return CardDB.cardIDEnum.BRM_025;
            if (s == "BRM_026") return CardDB.cardIDEnum.BRM_026;
            if (s == "BRM_027") return CardDB.cardIDEnum.BRM_027;
            if (s == "BRM_027h") return CardDB.cardIDEnum.BRM_027h;
            if (s == "BRM_027p") return CardDB.cardIDEnum.BRM_027p;
            if (s == "BRM_027pH") return CardDB.cardIDEnum.BRM_027pH;
            if (s == "BRM_028") return CardDB.cardIDEnum.BRM_028;
            if (s == "BRM_028e") return CardDB.cardIDEnum.BRM_028e;
            if (s == "BRM_029") return CardDB.cardIDEnum.BRM_029;
            if (s == "BRM_030") return CardDB.cardIDEnum.BRM_030;
            if (s == "BRM_030t") return CardDB.cardIDEnum.BRM_030t;
            if (s == "BRM_031") return CardDB.cardIDEnum.BRM_031;
            if (s == "BRM_033") return CardDB.cardIDEnum.BRM_033;
            if (s == "BRM_034") return CardDB.cardIDEnum.BRM_034;

            if (s == "CS1h_001") return CardDB.cardIDEnum.CS1h_001;
            if (s == "CS1_042") return CardDB.cardIDEnum.CS1_042;
            if (s == "CS1_112") return CardDB.cardIDEnum.CS1_112;
            if (s == "CS1_113") return CardDB.cardIDEnum.CS1_113;
            if (s == "CS1_113e") return CardDB.cardIDEnum.CS1_113e;
            if (s == "CS1_130") return CardDB.cardIDEnum.CS1_130;
            if (s == "CS2_003") return CardDB.cardIDEnum.CS2_003;
            if (s == "CS2_004") return CardDB.cardIDEnum.CS2_004;
            if (s == "CS2_004e") return CardDB.cardIDEnum.CS2_004e;
            if (s == "CS2_005") return CardDB.cardIDEnum.CS2_005;
            if (s == "CS2_005o") return CardDB.cardIDEnum.CS2_005o;
            if (s == "CS2_007") return CardDB.cardIDEnum.CS2_007;
            if (s == "CS2_008") return CardDB.cardIDEnum.CS2_008;
            if (s == "CS2_009") return CardDB.cardIDEnum.CS2_009;
            if (s == "CS2_009e") return CardDB.cardIDEnum.CS2_009e;
            if (s == "CS2_011") return CardDB.cardIDEnum.CS2_011;
            if (s == "CS2_011o") return CardDB.cardIDEnum.CS2_011o;
            if (s == "CS2_012") return CardDB.cardIDEnum.CS2_012;
            if (s == "CS2_013") return CardDB.cardIDEnum.CS2_013;
            if (s == "CS2_013t") return CardDB.cardIDEnum.CS2_013t;
            if (s == "CS2_017") return CardDB.cardIDEnum.CS2_017;
            if (s == "CS2_017o") return CardDB.cardIDEnum.CS2_017o;
            if (s == "CS2_022") return CardDB.cardIDEnum.CS2_022;
            if (s == "CS2_022e") return CardDB.cardIDEnum.CS2_022e;
            if (s == "CS2_023") return CardDB.cardIDEnum.CS2_023;
            if (s == "CS2_024") return CardDB.cardIDEnum.CS2_024;
            if (s == "CS2_025") return CardDB.cardIDEnum.CS2_025;
            if (s == "CS2_026") return CardDB.cardIDEnum.CS2_026;
            if (s == "CS2_027") return CardDB.cardIDEnum.CS2_027;
            if (s == "CS2_029") return CardDB.cardIDEnum.CS2_029;
            if (s == "CS2_032") return CardDB.cardIDEnum.CS2_032;
            if (s == "CS2_033") return CardDB.cardIDEnum.CS2_033;
            if (s == "CS2_034") return CardDB.cardIDEnum.CS2_034;

            if (s == "CS2_037") return CardDB.cardIDEnum.CS2_037;
            if (s == "CS2_039") return CardDB.cardIDEnum.CS2_039;
            if (s == "CS2_041") return CardDB.cardIDEnum.CS2_041;
            if (s == "CS2_041e") return CardDB.cardIDEnum.CS2_041e;
            if (s == "CS2_042") return CardDB.cardIDEnum.CS2_042;
            if (s == "CS2_045") return CardDB.cardIDEnum.CS2_045;
            if (s == "CS2_045e") return CardDB.cardIDEnum.CS2_045e;
            if (s == "CS2_046") return CardDB.cardIDEnum.CS2_046;
            if (s == "CS2_046e") return CardDB.cardIDEnum.CS2_046e;
            if (s == "CS2_049") return CardDB.cardIDEnum.CS2_049;

            if (s == "CS2_050") return CardDB.cardIDEnum.CS2_050;
            if (s == "CS2_051") return CardDB.cardIDEnum.CS2_051;
            if (s == "CS2_052") return CardDB.cardIDEnum.CS2_052;
            if (s == "CS2_056") return CardDB.cardIDEnum.CS2_056;

            if (s == "CS2_057") return CardDB.cardIDEnum.CS2_057;
            if (s == "CS2_061") return CardDB.cardIDEnum.CS2_061;
            if (s == "CS2_062") return CardDB.cardIDEnum.CS2_062;
            if (s == "CS2_063") return CardDB.cardIDEnum.CS2_063;
            if (s == "CS2_063e") return CardDB.cardIDEnum.CS2_063e;
            if (s == "CS2_064") return CardDB.cardIDEnum.CS2_064;
            if (s == "CS2_065") return CardDB.cardIDEnum.CS2_065;
            if (s == "CS2_072") return CardDB.cardIDEnum.CS2_072;
            if (s == "CS2_074") return CardDB.cardIDEnum.CS2_074;
            if (s == "CS2_074e") return CardDB.cardIDEnum.CS2_074e;
            if (s == "CS2_075") return CardDB.cardIDEnum.CS2_075;
            if (s == "CS2_076") return CardDB.cardIDEnum.CS2_076;
            if (s == "CS2_077") return CardDB.cardIDEnum.CS2_077;
            if (s == "CS2_080") return CardDB.cardIDEnum.CS2_080;
            if (s == "CS2_082") return CardDB.cardIDEnum.CS2_082;
            if (s == "CS2_083b") return CardDB.cardIDEnum.CS2_083b;
            if (s == "CS2_083e") return CardDB.cardIDEnum.CS2_083e;
            if (s == "CS2_084") return CardDB.cardIDEnum.CS2_084;
            if (s == "CS2_084e") return CardDB.cardIDEnum.CS2_084e;
            if (s == "CS2_087") return CardDB.cardIDEnum.CS2_087;
            if (s == "CS2_087e") return CardDB.cardIDEnum.CS2_087e;
            if (s == "CS2_088") return CardDB.cardIDEnum.CS2_088;
            if (s == "CS2_089") return CardDB.cardIDEnum.CS2_089;
            if (s == "CS2_091") return CardDB.cardIDEnum.CS2_091;
            if (s == "CS2_092") return CardDB.cardIDEnum.CS2_092;
            if (s == "CS2_092e") return CardDB.cardIDEnum.CS2_092e;
            if (s == "CS2_093") return CardDB.cardIDEnum.CS2_093;
            if (s == "CS2_094") return CardDB.cardIDEnum.CS2_094;
            if (s == "CS2_097") return CardDB.cardIDEnum.CS2_097;
            if (s == "CS2_101") return CardDB.cardIDEnum.CS2_101;
            if (s == "CS2_101t") return CardDB.cardIDEnum.CS2_101t;
            if (s == "CS2_102") return CardDB.cardIDEnum.CS2_102;

            if (s == "CS2_103") return CardDB.cardIDEnum.CS2_103;
            if (s == "CS2_103e2") return CardDB.cardIDEnum.CS2_103e2;
            if (s == "CS2_105") return CardDB.cardIDEnum.CS2_105;
            if (s == "CS2_105e") return CardDB.cardIDEnum.CS2_105e;
            if (s == "CS2_106") return CardDB.cardIDEnum.CS2_106;
            if (s == "CS2_108") return CardDB.cardIDEnum.CS2_108;
            if (s == "CS2_112") return CardDB.cardIDEnum.CS2_112;
            if (s == "CS2_114") return CardDB.cardIDEnum.CS2_114;
            if (s == "CS2_118") return CardDB.cardIDEnum.CS2_118;
            if (s == "CS2_119") return CardDB.cardIDEnum.CS2_119;
            if (s == "CS2_120") return CardDB.cardIDEnum.CS2_120;
            if (s == "CS2_121") return CardDB.cardIDEnum.CS2_121;
            if (s == "CS2_122") return CardDB.cardIDEnum.CS2_122;
            if (s == "CS2_122e") return CardDB.cardIDEnum.CS2_122e;
            if (s == "CS2_124") return CardDB.cardIDEnum.CS2_124;
            if (s == "CS2_125") return CardDB.cardIDEnum.CS2_125;
            if (s == "CS2_127") return CardDB.cardIDEnum.CS2_127;
            if (s == "CS2_131") return CardDB.cardIDEnum.CS2_131;
            if (s == "CS2_141") return CardDB.cardIDEnum.CS2_141;
            if (s == "CS2_142") return CardDB.cardIDEnum.CS2_142;
            if (s == "CS2_147") return CardDB.cardIDEnum.CS2_147;
            if (s == "CS2_150") return CardDB.cardIDEnum.CS2_150;
            if (s == "CS2_155") return CardDB.cardIDEnum.CS2_155;
            if (s == "CS2_162") return CardDB.cardIDEnum.CS2_162;
            if (s == "CS2_168") return CardDB.cardIDEnum.CS2_168;
            if (s == "CS2_171") return CardDB.cardIDEnum.CS2_171;
            if (s == "CS2_172") return CardDB.cardIDEnum.CS2_172;
            if (s == "CS2_173") return CardDB.cardIDEnum.CS2_173;
            if (s == "CS2_179") return CardDB.cardIDEnum.CS2_179;
            if (s == "CS2_182") return CardDB.cardIDEnum.CS2_182;
            if (s == "CS2_186") return CardDB.cardIDEnum.CS2_186;
            if (s == "CS2_187") return CardDB.cardIDEnum.CS2_187;
            if (s == "CS2_189") return CardDB.cardIDEnum.CS2_189;
            if (s == "CS2_196") return CardDB.cardIDEnum.CS2_196;
            if (s == "CS2_197") return CardDB.cardIDEnum.CS2_197;
            if (s == "CS2_200") return CardDB.cardIDEnum.CS2_200;
            if (s == "CS2_201") return CardDB.cardIDEnum.CS2_201;
            if (s == "CS2_213") return CardDB.cardIDEnum.CS2_213;
            if (s == "CS2_222") return CardDB.cardIDEnum.CS2_222;
            if (s == "CS2_222o") return CardDB.cardIDEnum.CS2_222o;
            if (s == "CS2_226") return CardDB.cardIDEnum.CS2_226;
            if (s == "CS2_226e") return CardDB.cardIDEnum.CS2_226e;
            if (s == "CS2_232") return CardDB.cardIDEnum.CS2_232;
            if (s == "CS2_234") return CardDB.cardIDEnum.CS2_234;
            if (s == "CS2_235") return CardDB.cardIDEnum.CS2_235;
            if (s == "CS2_236") return CardDB.cardIDEnum.CS2_236;
            if (s == "CS2_236e") return CardDB.cardIDEnum.CS2_236e;
            if (s == "CS2_237") return CardDB.cardIDEnum.CS2_237;
            if (s == "CS2_boar") return CardDB.cardIDEnum.CS2_boar;
            if (s == "CS2_mirror") return CardDB.cardIDEnum.CS2_mirror;
            if (s == "CS2_tk1") return CardDB.cardIDEnum.CS2_tk1;
            if (s == "DS1h_292") return CardDB.cardIDEnum.DS1h_292;

            if (s == "DS1_055") return CardDB.cardIDEnum.DS1_055;
            if (s == "DS1_070") return CardDB.cardIDEnum.DS1_070;
            if (s == "DS1_070o") return CardDB.cardIDEnum.DS1_070o;
            if (s == "DS1_175") return CardDB.cardIDEnum.DS1_175;
            if (s == "DS1_175o") return CardDB.cardIDEnum.DS1_175o;
            if (s == "DS1_178") return CardDB.cardIDEnum.DS1_178;
            if (s == "DS1_178e") return CardDB.cardIDEnum.DS1_178e;
            if (s == "DS1_183") return CardDB.cardIDEnum.DS1_183;
            if (s == "DS1_184") return CardDB.cardIDEnum.DS1_184;
            if (s == "DS1_185") return CardDB.cardIDEnum.DS1_185;
            if (s == "DS1_233") return CardDB.cardIDEnum.DS1_233;
            if (s == "EX1_011") return CardDB.cardIDEnum.EX1_011;
            if (s == "EX1_015") return CardDB.cardIDEnum.EX1_015;
            if (s == "EX1_019") return CardDB.cardIDEnum.EX1_019;
            if (s == "EX1_019e") return CardDB.cardIDEnum.EX1_019e;
            if (s == "EX1_025") return CardDB.cardIDEnum.EX1_025;
            if (s == "EX1_025t") return CardDB.cardIDEnum.EX1_025t;
            if (s == "EX1_066") return CardDB.cardIDEnum.EX1_066;
            if (s == "EX1_084") return CardDB.cardIDEnum.EX1_084;
            if (s == "EX1_084e") return CardDB.cardIDEnum.EX1_084e;
            if (s == "EX1_129") return CardDB.cardIDEnum.EX1_129;
            if (s == "EX1_169") return CardDB.cardIDEnum.EX1_169;
            if (s == "EX1_173") return CardDB.cardIDEnum.EX1_173;
            if (s == "EX1_244") return CardDB.cardIDEnum.EX1_244;
            if (s == "EX1_244e") return CardDB.cardIDEnum.EX1_244e;
            if (s == "EX1_246") return CardDB.cardIDEnum.EX1_246;
            if (s == "EX1_246e") return CardDB.cardIDEnum.EX1_246e;
            if (s == "EX1_277") return CardDB.cardIDEnum.EX1_277;
            if (s == "EX1_278") return CardDB.cardIDEnum.EX1_278;
            if (s == "EX1_302") return CardDB.cardIDEnum.EX1_302;
            if (s == "EX1_306") return CardDB.cardIDEnum.EX1_306;
            if (s == "EX1_308") return CardDB.cardIDEnum.EX1_308;
            if (s == "EX1_360") return CardDB.cardIDEnum.EX1_360;
            if (s == "EX1_360e") return CardDB.cardIDEnum.EX1_360e;
            if (s == "EX1_371") return CardDB.cardIDEnum.EX1_371;
            if (s == "EX1_399") return CardDB.cardIDEnum.EX1_399;
            if (s == "EX1_399e") return CardDB.cardIDEnum.EX1_399e;
            if (s == "EX1_400") return CardDB.cardIDEnum.EX1_400;
            if (s == "EX1_506") return CardDB.cardIDEnum.EX1_506;
            if (s == "EX1_506a") return CardDB.cardIDEnum.EX1_506a;
            if (s == "EX1_508") return CardDB.cardIDEnum.EX1_508;
            if (s == "EX1_508o") return CardDB.cardIDEnum.EX1_508o;
            if (s == "EX1_539") return CardDB.cardIDEnum.EX1_539;
            if (s == "EX1_565") return CardDB.cardIDEnum.EX1_565;
            if (s == "EX1_565o") return CardDB.cardIDEnum.EX1_565o;
            if (s == "EX1_581") return CardDB.cardIDEnum.EX1_581;
            if (s == "EX1_582") return CardDB.cardIDEnum.EX1_582;
            if (s == "EX1_587") return CardDB.cardIDEnum.EX1_587;
            if (s == "EX1_593") return CardDB.cardIDEnum.EX1_593;
            if (s == "EX1_606") return CardDB.cardIDEnum.EX1_606;
            if (s == "EX1_622") return CardDB.cardIDEnum.EX1_622;
            if (s == "GAME_001") return CardDB.cardIDEnum.GAME_001;
            if (s == "GAME_002") return CardDB.cardIDEnum.GAME_002;
            if (s == "GAME_003") return CardDB.cardIDEnum.GAME_003;
            if (s == "GAME_003e") return CardDB.cardIDEnum.GAME_003e;
            if (s == "GAME_004") return CardDB.cardIDEnum.GAME_004;
            if (s == "GAME_005") return CardDB.cardIDEnum.GAME_005;
            if (s == "GAME_005e") return CardDB.cardIDEnum.GAME_005e;
            if (s == "GAME_006") return CardDB.cardIDEnum.GAME_006;
            if (s == "HERO_01") return CardDB.cardIDEnum.HERO_01;
            if (s == "HERO_02") return CardDB.cardIDEnum.HERO_02;
            if (s == "HERO_03") return CardDB.cardIDEnum.HERO_03;
            if (s == "HERO_04") return CardDB.cardIDEnum.HERO_04;
            if (s == "HERO_05") return CardDB.cardIDEnum.HERO_05;
            if (s == "HERO_06") return CardDB.cardIDEnum.HERO_06;
            if (s == "HERO_07") return CardDB.cardIDEnum.HERO_07;
            if (s == "HERO_08") return CardDB.cardIDEnum.HERO_08;
            if (s == "HERO_09") return CardDB.cardIDEnum.HERO_09;

            if (s == "HERO_01a") return CardDB.cardIDEnum.HERO_01;
            if (s == "HERO_02a") return CardDB.cardIDEnum.HERO_02;
            if (s == "HERO_03a") return CardDB.cardIDEnum.HERO_03;
            if (s == "HERO_04a") return CardDB.cardIDEnum.HERO_04;
            if (s == "HERO_05a") return CardDB.cardIDEnum.HERO_05;
            if (s == "HERO_06a") return CardDB.cardIDEnum.HERO_06;
            if (s == "HERO_07a") return CardDB.cardIDEnum.HERO_07;
            if (s == "HERO_08a") return CardDB.cardIDEnum.HERO_08;
            if (s == "HERO_09a") return CardDB.cardIDEnum.HERO_09;

            if (s == "hexfrog") return CardDB.cardIDEnum.hexfrog;
            if (s == "NEW1_003") return CardDB.cardIDEnum.NEW1_003;
            if (s == "NEW1_004") return CardDB.cardIDEnum.NEW1_004;
            if (s == "NEW1_009") return CardDB.cardIDEnum.NEW1_009;
            if (s == "NEW1_011") return CardDB.cardIDEnum.NEW1_011;
            if (s == "NEW1_031") return CardDB.cardIDEnum.NEW1_031;
            if (s == "NEW1_032") return CardDB.cardIDEnum.NEW1_032;
            if (s == "NEW1_033") return CardDB.cardIDEnum.NEW1_033;
            if (s == "NEW1_033o") return CardDB.cardIDEnum.NEW1_033o;
            if (s == "NEW1_034") return CardDB.cardIDEnum.NEW1_034;
            if (s == "skele11") return CardDB.cardIDEnum.skele11;
            if (s == "CS1_069") return CardDB.cardIDEnum.CS1_069;
            if (s == "CS1_129") return CardDB.cardIDEnum.CS1_129;
            if (s == "CS1_129e") return CardDB.cardIDEnum.CS1_129e;
            if (s == "CS2_028") return CardDB.cardIDEnum.CS2_028;
            if (s == "CS2_031") return CardDB.cardIDEnum.CS2_031;
            if (s == "CS2_038") return CardDB.cardIDEnum.CS2_038;
            if (s == "CS2_038e") return CardDB.cardIDEnum.CS2_038e;
            if (s == "CS2_053") return CardDB.cardIDEnum.CS2_053;
            if (s == "CS2_053e") return CardDB.cardIDEnum.CS2_053e;
            if (s == "CS2_059") return CardDB.cardIDEnum.CS2_059;
            if (s == "CS2_059o") return CardDB.cardIDEnum.CS2_059o;
            if (s == "CS2_073") return CardDB.cardIDEnum.CS2_073;
            if (s == "CS2_073e") return CardDB.cardIDEnum.CS2_073e;
            if (s == "CS2_073e2") return CardDB.cardIDEnum.CS2_073e2;
            if (s == "CS2_104") return CardDB.cardIDEnum.CS2_104;
            if (s == "CS2_104e") return CardDB.cardIDEnum.CS2_104e;
            if (s == "CS2_117") return CardDB.cardIDEnum.CS2_117;
            if (s == "CS2_146") return CardDB.cardIDEnum.CS2_146;
            if (s == "CS2_146o") return CardDB.cardIDEnum.CS2_146o;
            if (s == "CS2_151") return CardDB.cardIDEnum.CS2_151;
            if (s == "CS2_152") return CardDB.cardIDEnum.CS2_152;
            if (s == "CS2_161") return CardDB.cardIDEnum.CS2_161;
            if (s == "CS2_169") return CardDB.cardIDEnum.CS2_169;
            if (s == "CS2_181") return CardDB.cardIDEnum.CS2_181;
            if (s == "CS2_181e") return CardDB.cardIDEnum.CS2_181e;
            if (s == "CS2_188") return CardDB.cardIDEnum.CS2_188;
            if (s == "CS2_188o") return CardDB.cardIDEnum.CS2_188o;
            if (s == "CS2_203") return CardDB.cardIDEnum.CS2_203;
            if (s == "CS2_221") return CardDB.cardIDEnum.CS2_221;
            if (s == "CS2_221e") return CardDB.cardIDEnum.CS2_221e;
            if (s == "CS2_227") return CardDB.cardIDEnum.CS2_227;
            if (s == "CS2_231") return CardDB.cardIDEnum.CS2_231;
            if (s == "CS2_233") return CardDB.cardIDEnum.CS2_233;
            if (s == "DREAM_01") return CardDB.cardIDEnum.DREAM_01;
            if (s == "DREAM_02") return CardDB.cardIDEnum.DREAM_02;
            if (s == "DREAM_03") return CardDB.cardIDEnum.DREAM_03;
            if (s == "DREAM_04") return CardDB.cardIDEnum.DREAM_04;
            if (s == "DREAM_05") return CardDB.cardIDEnum.DREAM_05;
            if (s == "DREAM_05e") return CardDB.cardIDEnum.DREAM_05e;
            if (s == "DS1_188") return CardDB.cardIDEnum.DS1_188;
            if (s == "ds1_whelptoken") return CardDB.cardIDEnum.ds1_whelptoken;
            if (s == "EX1_001") return CardDB.cardIDEnum.EX1_001;
            if (s == "EX1_001e") return CardDB.cardIDEnum.EX1_001e;
            if (s == "EX1_002") return CardDB.cardIDEnum.EX1_002;
            if (s == "EX1_004") return CardDB.cardIDEnum.EX1_004;
            if (s == "EX1_004e") return CardDB.cardIDEnum.EX1_004e;
            if (s == "EX1_005") return CardDB.cardIDEnum.EX1_005;
            if (s == "EX1_006") return CardDB.cardIDEnum.EX1_006;
            if (s == "EX1_007") return CardDB.cardIDEnum.EX1_007;
            if (s == "EX1_008") return CardDB.cardIDEnum.EX1_008;
            if (s == "EX1_009") return CardDB.cardIDEnum.EX1_009;
            if (s == "EX1_010") return CardDB.cardIDEnum.EX1_010;
            if (s == "EX1_012") return CardDB.cardIDEnum.EX1_012;
            if (s == "EX1_014") return CardDB.cardIDEnum.EX1_014;
            if (s == "EX1_014t") return CardDB.cardIDEnum.EX1_014t;
            if (s == "EX1_014te") return CardDB.cardIDEnum.EX1_014te;
            if (s == "EX1_016") return CardDB.cardIDEnum.EX1_016;
            if (s == "EX1_017") return CardDB.cardIDEnum.EX1_017;
            if (s == "EX1_020") return CardDB.cardIDEnum.EX1_020;
            if (s == "EX1_021") return CardDB.cardIDEnum.EX1_021;
            if (s == "EX1_023") return CardDB.cardIDEnum.EX1_023;
            if (s == "EX1_028") return CardDB.cardIDEnum.EX1_028;
            if (s == "EX1_029") return CardDB.cardIDEnum.EX1_029;
            if (s == "EX1_032") return CardDB.cardIDEnum.EX1_032;
            if (s == "EX1_033") return CardDB.cardIDEnum.EX1_033;
            if (s == "EX1_043") return CardDB.cardIDEnum.EX1_043;
            if (s == "EX1_043e") return CardDB.cardIDEnum.EX1_043e;
            if (s == "EX1_044") return CardDB.cardIDEnum.EX1_044;
            if (s == "EX1_044e") return CardDB.cardIDEnum.EX1_044e;
            if (s == "EX1_045") return CardDB.cardIDEnum.EX1_045;
            if (s == "EX1_046") return CardDB.cardIDEnum.EX1_046;
            if (s == "EX1_046e") return CardDB.cardIDEnum.EX1_046e;
            if (s == "EX1_048") return CardDB.cardIDEnum.EX1_048;
            if (s == "EX1_049") return CardDB.cardIDEnum.EX1_049;
            if (s == "EX1_050") return CardDB.cardIDEnum.EX1_050;
            if (s == "EX1_055") return CardDB.cardIDEnum.EX1_055;
            if (s == "EX1_055o") return CardDB.cardIDEnum.EX1_055o;
            if (s == "EX1_057") return CardDB.cardIDEnum.EX1_057;
            if (s == "EX1_058") return CardDB.cardIDEnum.EX1_058;
            if (s == "EX1_059") return CardDB.cardIDEnum.EX1_059;
            if (s == "EX1_059e") return CardDB.cardIDEnum.EX1_059e;
            if (s == "EX1_067") return CardDB.cardIDEnum.EX1_067;
            if (s == "EX1_076") return CardDB.cardIDEnum.EX1_076;
            if (s == "EX1_080") return CardDB.cardIDEnum.EX1_080;
            if (s == "EX1_080o") return CardDB.cardIDEnum.EX1_080o;
            if (s == "EX1_082") return CardDB.cardIDEnum.EX1_082;
            if (s == "EX1_083") return CardDB.cardIDEnum.EX1_083;
            if (s == "EX1_085") return CardDB.cardIDEnum.EX1_085;
            if (s == "EX1_089") return CardDB.cardIDEnum.EX1_089;
            if (s == "EX1_091") return CardDB.cardIDEnum.EX1_091;
            if (s == "EX1_093") return CardDB.cardIDEnum.EX1_093;
            if (s == "EX1_093e") return CardDB.cardIDEnum.EX1_093e;
            if (s == "EX1_095") return CardDB.cardIDEnum.EX1_095;
            if (s == "EX1_096") return CardDB.cardIDEnum.EX1_096;
            if (s == "EX1_097") return CardDB.cardIDEnum.EX1_097;
            if (s == "EX1_100") return CardDB.cardIDEnum.EX1_100;
            if (s == "EX1_102") return CardDB.cardIDEnum.EX1_102;
            if (s == "EX1_103") return CardDB.cardIDEnum.EX1_103;
            if (s == "EX1_103e") return CardDB.cardIDEnum.EX1_103e;
            if (s == "EX1_105") return CardDB.cardIDEnum.EX1_105;
            if (s == "EX1_110") return CardDB.cardIDEnum.EX1_110;
            if (s == "EX1_110t") return CardDB.cardIDEnum.EX1_110t;
            if (s == "EX1_116") return CardDB.cardIDEnum.EX1_116;
            if (s == "EX1_116t") return CardDB.cardIDEnum.EX1_116t;
            if (s == "EX1_124") return CardDB.cardIDEnum.EX1_124;
            if (s == "EX1_126") return CardDB.cardIDEnum.EX1_126;
            if (s == "EX1_128") return CardDB.cardIDEnum.EX1_128;
            if (s == "EX1_128e") return CardDB.cardIDEnum.EX1_128e;
            if (s == "EX1_130") return CardDB.cardIDEnum.EX1_130;
            if (s == "EX1_130a") return CardDB.cardIDEnum.EX1_130a;
            if (s == "EX1_131") return CardDB.cardIDEnum.EX1_131;
            if (s == "EX1_131t") return CardDB.cardIDEnum.EX1_131t;
            if (s == "EX1_132") return CardDB.cardIDEnum.EX1_132;
            if (s == "EX1_133") return CardDB.cardIDEnum.EX1_133;
            if (s == "EX1_134") return CardDB.cardIDEnum.EX1_134;
            if (s == "EX1_136") return CardDB.cardIDEnum.EX1_136;
            if (s == "EX1_137") return CardDB.cardIDEnum.EX1_137;
            if (s == "EX1_144") return CardDB.cardIDEnum.EX1_144;
            if (s == "EX1_145") return CardDB.cardIDEnum.EX1_145;
            if (s == "EX1_145o") return CardDB.cardIDEnum.EX1_145o;
            if (s == "EX1_154") return CardDB.cardIDEnum.EX1_154;
            if (s == "EX1_154a") return CardDB.cardIDEnum.EX1_154a;
            if (s == "EX1_154b") return CardDB.cardIDEnum.EX1_154b;
            if (s == "EX1_155") return CardDB.cardIDEnum.EX1_155;
            if (s == "EX1_155a") return CardDB.cardIDEnum.EX1_155a;
            if (s == "EX1_155ae") return CardDB.cardIDEnum.EX1_155ae;
            if (s == "EX1_155b") return CardDB.cardIDEnum.EX1_155b;
            if (s == "EX1_155be") return CardDB.cardIDEnum.EX1_155be;
            if (s == "EX1_158") return CardDB.cardIDEnum.EX1_158;
            if (s == "EX1_158e") return CardDB.cardIDEnum.EX1_158e;
            if (s == "EX1_158t") return CardDB.cardIDEnum.EX1_158t;
            if (s == "EX1_160") return CardDB.cardIDEnum.EX1_160;
            if (s == "EX1_160a") return CardDB.cardIDEnum.EX1_160a;
            if (s == "EX1_160b") return CardDB.cardIDEnum.EX1_160b;
            if (s == "EX1_160be") return CardDB.cardIDEnum.EX1_160be;
            if (s == "EX1_160t") return CardDB.cardIDEnum.EX1_160t;
            if (s == "EX1_161") return CardDB.cardIDEnum.EX1_161;
            if (s == "EX1_161o") return CardDB.cardIDEnum.EX1_161o;
            if (s == "EX1_162") return CardDB.cardIDEnum.EX1_162;
            if (s == "EX1_162o") return CardDB.cardIDEnum.EX1_162o;
            if (s == "EX1_164") return CardDB.cardIDEnum.EX1_164;
            if (s == "EX1_164a") return CardDB.cardIDEnum.EX1_164a;
            if (s == "EX1_164b") return CardDB.cardIDEnum.EX1_164b;
            if (s == "EX1_165") return CardDB.cardIDEnum.EX1_165;
            if (s == "EX1_165a") return CardDB.cardIDEnum.EX1_165a;
            if (s == "EX1_165b") return CardDB.cardIDEnum.EX1_165b;
            if (s == "EX1_165t1") return CardDB.cardIDEnum.EX1_165t1;
            if (s == "EX1_165t2") return CardDB.cardIDEnum.EX1_165t2;
            if (s == "EX1_166") return CardDB.cardIDEnum.EX1_166;
            if (s == "EX1_166a") return CardDB.cardIDEnum.EX1_166a;
            if (s == "EX1_166b") return CardDB.cardIDEnum.EX1_166b;
            if (s == "EX1_170") return CardDB.cardIDEnum.EX1_170;
            if (s == "EX1_178") return CardDB.cardIDEnum.EX1_178;
            if (s == "EX1_178a") return CardDB.cardIDEnum.EX1_178a;
            if (s == "EX1_178ae") return CardDB.cardIDEnum.EX1_178ae;
            if (s == "EX1_178b") return CardDB.cardIDEnum.EX1_178b;
            if (s == "EX1_178be") return CardDB.cardIDEnum.EX1_178be;
            if (s == "EX1_238") return CardDB.cardIDEnum.EX1_238;
            if (s == "EX1_241") return CardDB.cardIDEnum.EX1_241;
            if (s == "EX1_243") return CardDB.cardIDEnum.EX1_243;
            if (s == "EX1_245") return CardDB.cardIDEnum.EX1_245;
            if (s == "EX1_247") return CardDB.cardIDEnum.EX1_247;
            if (s == "EX1_248") return CardDB.cardIDEnum.EX1_248;
            if (s == "EX1_249") return CardDB.cardIDEnum.EX1_249;
            if (s == "EX1_250") return CardDB.cardIDEnum.EX1_250;
            if (s == "EX1_251") return CardDB.cardIDEnum.EX1_251;
            if (s == "EX1_258") return CardDB.cardIDEnum.EX1_258;
            if (s == "EX1_258e") return CardDB.cardIDEnum.EX1_258e;
            if (s == "EX1_259") return CardDB.cardIDEnum.EX1_259;
            if (s == "EX1_274") return CardDB.cardIDEnum.EX1_274;
            if (s == "EX1_274e") return CardDB.cardIDEnum.EX1_274e;
            if (s == "EX1_275") return CardDB.cardIDEnum.EX1_275;
            if (s == "EX1_279") return CardDB.cardIDEnum.EX1_279;
            if (s == "EX1_283") return CardDB.cardIDEnum.EX1_283;
            if (s == "EX1_284") return CardDB.cardIDEnum.EX1_284;
            if (s == "EX1_287") return CardDB.cardIDEnum.EX1_287;
            if (s == "EX1_289") return CardDB.cardIDEnum.EX1_289;
            if (s == "EX1_294") return CardDB.cardIDEnum.EX1_294;
            if (s == "EX1_295") return CardDB.cardIDEnum.EX1_295;
            if (s == "EX1_295o") return CardDB.cardIDEnum.EX1_295o;
            if (s == "EX1_298") return CardDB.cardIDEnum.EX1_298;
            if (s == "EX1_301") return CardDB.cardIDEnum.EX1_301;
            if (s == "EX1_303") return CardDB.cardIDEnum.EX1_303;
            if (s == "EX1_304") return CardDB.cardIDEnum.EX1_304;
            if (s == "EX1_304e") return CardDB.cardIDEnum.EX1_304e;
            if (s == "EX1_309") return CardDB.cardIDEnum.EX1_309;
            if (s == "EX1_310") return CardDB.cardIDEnum.EX1_310;
            if (s == "EX1_312") return CardDB.cardIDEnum.EX1_312;
            if (s == "EX1_313") return CardDB.cardIDEnum.EX1_313;
            if (s == "EX1_315") return CardDB.cardIDEnum.EX1_315;
            if (s == "EX1_316") return CardDB.cardIDEnum.EX1_316;
            if (s == "EX1_316e") return CardDB.cardIDEnum.EX1_316e;
            if (s == "EX1_317") return CardDB.cardIDEnum.EX1_317;
            if (s == "EX1_317t") return CardDB.cardIDEnum.EX1_317t;
            if (s == "EX1_319") return CardDB.cardIDEnum.EX1_319;
            if (s == "EX1_320") return CardDB.cardIDEnum.EX1_320;
            if (s == "EX1_323") return CardDB.cardIDEnum.EX1_323;
            if (s == "EX1_323h") return CardDB.cardIDEnum.EX1_323h;
            if (s == "EX1_323w") return CardDB.cardIDEnum.EX1_323w;
            if (s == "EX1_332") return CardDB.cardIDEnum.EX1_332;
            if (s == "EX1_334") return CardDB.cardIDEnum.EX1_334;
            if (s == "EX1_334e") return CardDB.cardIDEnum.EX1_334e;
            if (s == "EX1_335") return CardDB.cardIDEnum.EX1_335;
            if (s == "EX1_339") return CardDB.cardIDEnum.EX1_339;
            if (s == "EX1_341") return CardDB.cardIDEnum.EX1_341;
            if (s == "EX1_345") return CardDB.cardIDEnum.EX1_345;
            if (s == "EX1_345t") return CardDB.cardIDEnum.EX1_345t;
            if (s == "EX1_349") return CardDB.cardIDEnum.EX1_349;
            if (s == "EX1_350") return CardDB.cardIDEnum.EX1_350;
            if (s == "EX1_354") return CardDB.cardIDEnum.EX1_354;
            if (s == "EX1_355") return CardDB.cardIDEnum.EX1_355;
            if (s == "EX1_355e") return CardDB.cardIDEnum.EX1_355e;
            if (s == "EX1_362") return CardDB.cardIDEnum.EX1_362;
            if (s == "EX1_363") return CardDB.cardIDEnum.EX1_363;
            if (s == "EX1_363e") return CardDB.cardIDEnum.EX1_363e;
            if (s == "EX1_363e2") return CardDB.cardIDEnum.EX1_363e2;
            if (s == "EX1_365") return CardDB.cardIDEnum.EX1_365;
            if (s == "EX1_366") return CardDB.cardIDEnum.EX1_366;
            if (s == "EX1_366e") return CardDB.cardIDEnum.EX1_366e;
            if (s == "EX1_379") return CardDB.cardIDEnum.EX1_379;
            if (s == "EX1_379e") return CardDB.cardIDEnum.EX1_379e;
            if (s == "EX1_382") return CardDB.cardIDEnum.EX1_382;
            if (s == "EX1_382e") return CardDB.cardIDEnum.EX1_382e;
            if (s == "EX1_383") return CardDB.cardIDEnum.EX1_383;
            if (s == "EX1_383t") return CardDB.cardIDEnum.EX1_383t;
            if (s == "EX1_384") return CardDB.cardIDEnum.EX1_384;
            if (s == "EX1_390") return CardDB.cardIDEnum.EX1_390;
            if (s == "EX1_391") return CardDB.cardIDEnum.EX1_391;
            if (s == "EX1_392") return CardDB.cardIDEnum.EX1_392;
            if (s == "EX1_393") return CardDB.cardIDEnum.EX1_393;
            if (s == "EX1_396") return CardDB.cardIDEnum.EX1_396;
            if (s == "EX1_398") return CardDB.cardIDEnum.EX1_398;
            if (s == "EX1_398t") return CardDB.cardIDEnum.EX1_398t;
            if (s == "EX1_402") return CardDB.cardIDEnum.EX1_402;
            if (s == "EX1_405") return CardDB.cardIDEnum.EX1_405;
            if (s == "EX1_407") return CardDB.cardIDEnum.EX1_407;
            if (s == "EX1_408") return CardDB.cardIDEnum.EX1_408;
            if (s == "EX1_409") return CardDB.cardIDEnum.EX1_409;
            if (s == "EX1_409e") return CardDB.cardIDEnum.EX1_409e;
            if (s == "EX1_409t") return CardDB.cardIDEnum.EX1_409t;
            if (s == "EX1_410") return CardDB.cardIDEnum.EX1_410;
            if (s == "EX1_411") return CardDB.cardIDEnum.EX1_411;
            if (s == "EX1_411e") return CardDB.cardIDEnum.EX1_411e;
            if (s == "EX1_411e2") return CardDB.cardIDEnum.EX1_411e2;
            if (s == "EX1_412") return CardDB.cardIDEnum.EX1_412;
            if (s == "EX1_414") return CardDB.cardIDEnum.EX1_414;
            if (s == "EX1_507") return CardDB.cardIDEnum.EX1_507;
            if (s == "EX1_507e") return CardDB.cardIDEnum.EX1_507e;
            if (s == "EX1_509") return CardDB.cardIDEnum.EX1_509;
            if (s == "EX1_509e") return CardDB.cardIDEnum.EX1_509e;
            if (s == "EX1_522") return CardDB.cardIDEnum.EX1_522;
            if (s == "EX1_531") return CardDB.cardIDEnum.EX1_531;
            if (s == "EX1_531e") return CardDB.cardIDEnum.EX1_531e;
            if (s == "EX1_533") return CardDB.cardIDEnum.EX1_533;
            if (s == "EX1_534") return CardDB.cardIDEnum.EX1_534;
            if (s == "EX1_534t") return CardDB.cardIDEnum.EX1_534t;
            if (s == "EX1_536") return CardDB.cardIDEnum.EX1_536;
            if (s == "EX1_536e") return CardDB.cardIDEnum.EX1_536e;
            if (s == "EX1_537") return CardDB.cardIDEnum.EX1_537;
            if (s == "EX1_538") return CardDB.cardIDEnum.EX1_538;
            if (s == "EX1_538t") return CardDB.cardIDEnum.EX1_538t;
            if (s == "EX1_543") return CardDB.cardIDEnum.EX1_543;
            if (s == "EX1_544") return CardDB.cardIDEnum.EX1_544;
            if (s == "EX1_549") return CardDB.cardIDEnum.EX1_549;
            if (s == "EX1_549o") return CardDB.cardIDEnum.EX1_549o;
            if (s == "EX1_554") return CardDB.cardIDEnum.EX1_554;
            if (s == "EX1_554t") return CardDB.cardIDEnum.EX1_554t;
            if (s == "EX1_556") return CardDB.cardIDEnum.EX1_556;
            if (s == "EX1_557") return CardDB.cardIDEnum.EX1_557;
            if (s == "EX1_558") return CardDB.cardIDEnum.EX1_558;
            if (s == "EX1_559") return CardDB.cardIDEnum.EX1_559;
            if (s == "EX1_560") return CardDB.cardIDEnum.EX1_560;
            if (s == "EX1_561") return CardDB.cardIDEnum.EX1_561;
            if (s == "EX1_561e") return CardDB.cardIDEnum.EX1_561e;
            if (s == "EX1_562") return CardDB.cardIDEnum.EX1_562;
            if (s == "EX1_563") return CardDB.cardIDEnum.EX1_563;
            if (s == "EX1_564") return CardDB.cardIDEnum.EX1_564;
            if (s == "EX1_567") return CardDB.cardIDEnum.EX1_567;
            if (s == "EX1_570") return CardDB.cardIDEnum.EX1_570;
            if (s == "EX1_570e") return CardDB.cardIDEnum.EX1_570e;
            if (s == "EX1_571") return CardDB.cardIDEnum.EX1_571;
            if (s == "EX1_572") return CardDB.cardIDEnum.EX1_572;
            if (s == "EX1_573") return CardDB.cardIDEnum.EX1_573;
            if (s == "EX1_573a") return CardDB.cardIDEnum.EX1_573a;
            if (s == "EX1_573ae") return CardDB.cardIDEnum.EX1_573ae;
            if (s == "EX1_573b") return CardDB.cardIDEnum.EX1_573b;
            if (s == "EX1_573t") return CardDB.cardIDEnum.EX1_573t;
            if (s == "EX1_575") return CardDB.cardIDEnum.EX1_575;
            if (s == "EX1_577") return CardDB.cardIDEnum.EX1_577;
            if (s == "EX1_578") return CardDB.cardIDEnum.EX1_578;
            if (s == "EX1_583") return CardDB.cardIDEnum.EX1_583;
            if (s == "EX1_584") return CardDB.cardIDEnum.EX1_584;
            if (s == "EX1_584e") return CardDB.cardIDEnum.EX1_584e;
            if (s == "EX1_586") return CardDB.cardIDEnum.EX1_586;
            if (s == "EX1_590") return CardDB.cardIDEnum.EX1_590;
            if (s == "EX1_590e") return CardDB.cardIDEnum.EX1_590e;
            if (s == "EX1_591") return CardDB.cardIDEnum.EX1_591;
            if (s == "EX1_594") return CardDB.cardIDEnum.EX1_594;
            if (s == "EX1_595") return CardDB.cardIDEnum.EX1_595;
            if (s == "EX1_596") return CardDB.cardIDEnum.EX1_596;
            if (s == "EX1_596e") return CardDB.cardIDEnum.EX1_596e;
            if (s == "EX1_597") return CardDB.cardIDEnum.EX1_597;
            if (s == "EX1_598") return CardDB.cardIDEnum.EX1_598;
            if (s == "EX1_603") return CardDB.cardIDEnum.EX1_603;
            if (s == "EX1_603e") return CardDB.cardIDEnum.EX1_603e;
            if (s == "EX1_604") return CardDB.cardIDEnum.EX1_604;
            if (s == "EX1_604o") return CardDB.cardIDEnum.EX1_604o;
            if (s == "EX1_607") return CardDB.cardIDEnum.EX1_607;
            if (s == "EX1_607e") return CardDB.cardIDEnum.EX1_607e;
            if (s == "EX1_608") return CardDB.cardIDEnum.EX1_608;
            if (s == "EX1_609") return CardDB.cardIDEnum.EX1_609;
            if (s == "EX1_610") return CardDB.cardIDEnum.EX1_610;
            if (s == "EX1_611") return CardDB.cardIDEnum.EX1_611;
            if (s == "EX1_611e") return CardDB.cardIDEnum.EX1_611e;
            if (s == "EX1_612") return CardDB.cardIDEnum.EX1_612;
            if (s == "EX1_612o") return CardDB.cardIDEnum.EX1_612o;
            if (s == "EX1_613") return CardDB.cardIDEnum.EX1_613;
            if (s == "EX1_613e") return CardDB.cardIDEnum.EX1_613e;
            if (s == "EX1_614") return CardDB.cardIDEnum.EX1_614;
            if (s == "EX1_614t") return CardDB.cardIDEnum.EX1_614t;
            if (s == "EX1_616") return CardDB.cardIDEnum.EX1_616;
            if (s == "EX1_617") return CardDB.cardIDEnum.EX1_617;
            if (s == "EX1_619") return CardDB.cardIDEnum.EX1_619;
            if (s == "EX1_619e") return CardDB.cardIDEnum.EX1_619e;
            if (s == "EX1_620") return CardDB.cardIDEnum.EX1_620;
            if (s == "EX1_621") return CardDB.cardIDEnum.EX1_621;
            if (s == "EX1_623") return CardDB.cardIDEnum.EX1_623;
            if (s == "EX1_623e") return CardDB.cardIDEnum.EX1_623e;
            if (s == "EX1_624") return CardDB.cardIDEnum.EX1_624;
            if (s == "EX1_625") return CardDB.cardIDEnum.EX1_625;
            if (s == "EX1_625t") return CardDB.cardIDEnum.EX1_625t;
            if (s == "EX1_625t2") return CardDB.cardIDEnum.EX1_625t2;
            if (s == "EX1_626") return CardDB.cardIDEnum.EX1_626;
            if (s == "EX1_finkle") return CardDB.cardIDEnum.EX1_finkle;
            if (s == "EX1_tk11") return CardDB.cardIDEnum.EX1_tk11;
            if (s == "EX1_tk28") return CardDB.cardIDEnum.EX1_tk28;
            if (s == "EX1_tk29") return CardDB.cardIDEnum.EX1_tk29;
            if (s == "EX1_tk31") return CardDB.cardIDEnum.EX1_tk31;
            if (s == "EX1_tk33") return CardDB.cardIDEnum.EX1_tk33;
            if (s == "EX1_tk34") return CardDB.cardIDEnum.EX1_tk34;
            if (s == "EX1_tk9") return CardDB.cardIDEnum.EX1_tk9;
            if (s == "NEW1_005") return CardDB.cardIDEnum.NEW1_005;
            if (s == "NEW1_007") return CardDB.cardIDEnum.NEW1_007;
            if (s == "NEW1_007a") return CardDB.cardIDEnum.NEW1_007a;
            if (s == "NEW1_007b") return CardDB.cardIDEnum.NEW1_007b;
            if (s == "NEW1_008") return CardDB.cardIDEnum.NEW1_008;
            if (s == "NEW1_008a") return CardDB.cardIDEnum.NEW1_008a;
            if (s == "NEW1_008b") return CardDB.cardIDEnum.NEW1_008b;
            if (s == "NEW1_010") return CardDB.cardIDEnum.NEW1_010;
            if (s == "NEW1_012") return CardDB.cardIDEnum.NEW1_012;
            if (s == "NEW1_012o") return CardDB.cardIDEnum.NEW1_012o;
            if (s == "NEW1_014") return CardDB.cardIDEnum.NEW1_014;
            if (s == "NEW1_017") return CardDB.cardIDEnum.NEW1_017;
            if (s == "NEW1_017e") return CardDB.cardIDEnum.NEW1_017e;
            if (s == "NEW1_018") return CardDB.cardIDEnum.NEW1_018;
            if (s == "NEW1_018e") return CardDB.cardIDEnum.NEW1_018e;
            if (s == "NEW1_019") return CardDB.cardIDEnum.NEW1_019;
            if (s == "NEW1_020") return CardDB.cardIDEnum.NEW1_020;
            if (s == "NEW1_021") return CardDB.cardIDEnum.NEW1_021;
            if (s == "NEW1_022") return CardDB.cardIDEnum.NEW1_022;
            if (s == "NEW1_023") return CardDB.cardIDEnum.NEW1_023;
            if (s == "NEW1_024") return CardDB.cardIDEnum.NEW1_024;
            if (s == "NEW1_024o") return CardDB.cardIDEnum.NEW1_024o;
            if (s == "NEW1_025") return CardDB.cardIDEnum.NEW1_025;
            if (s == "NEW1_025e") return CardDB.cardIDEnum.NEW1_025e;
            if (s == "NEW1_026") return CardDB.cardIDEnum.NEW1_026;
            if (s == "NEW1_026t") return CardDB.cardIDEnum.NEW1_026t;
            if (s == "NEW1_027") return CardDB.cardIDEnum.NEW1_027;
            if (s == "NEW1_027e") return CardDB.cardIDEnum.NEW1_027e;
            if (s == "NEW1_029") return CardDB.cardIDEnum.NEW1_029;
            if (s == "NEW1_029t") return CardDB.cardIDEnum.NEW1_029t;
            if (s == "NEW1_030") return CardDB.cardIDEnum.NEW1_030;
            if (s == "NEW1_036") return CardDB.cardIDEnum.NEW1_036;
            if (s == "NEW1_036e") return CardDB.cardIDEnum.NEW1_036e;
            if (s == "NEW1_036e2") return CardDB.cardIDEnum.NEW1_036e2;
            if (s == "NEW1_037") return CardDB.cardIDEnum.NEW1_037;
            if (s == "NEW1_037e") return CardDB.cardIDEnum.NEW1_037e;
            if (s == "NEW1_038") return CardDB.cardIDEnum.NEW1_038;
            if (s == "NEW1_038o") return CardDB.cardIDEnum.NEW1_038o;
            if (s == "NEW1_040") return CardDB.cardIDEnum.NEW1_040;
            if (s == "NEW1_040t") return CardDB.cardIDEnum.NEW1_040t;
            if (s == "NEW1_041") return CardDB.cardIDEnum.NEW1_041;
            if (s == "skele21") return CardDB.cardIDEnum.skele21;
            if (s == "tt_004") return CardDB.cardIDEnum.tt_004;
            if (s == "tt_004o") return CardDB.cardIDEnum.tt_004o;
            if (s == "tt_010") return CardDB.cardIDEnum.tt_010;
            if (s == "tt_010a") return CardDB.cardIDEnum.tt_010a;
            if (s == "CRED_01") return CardDB.cardIDEnum.CRED_01;
            if (s == "CRED_02") return CardDB.cardIDEnum.CRED_02;
            if (s == "CRED_03") return CardDB.cardIDEnum.CRED_03;
            if (s == "CRED_04") return CardDB.cardIDEnum.CRED_04;
            if (s == "CRED_05") return CardDB.cardIDEnum.CRED_05;
            if (s == "CRED_06") return CardDB.cardIDEnum.CRED_06;
            if (s == "CRED_07") return CardDB.cardIDEnum.CRED_07;
            if (s == "CRED_08") return CardDB.cardIDEnum.CRED_08;
            if (s == "CRED_09") return CardDB.cardIDEnum.CRED_09;
            if (s == "CRED_10") return CardDB.cardIDEnum.CRED_10;
            if (s == "CRED_11") return CardDB.cardIDEnum.CRED_11;
            if (s == "CRED_12") return CardDB.cardIDEnum.CRED_12;
            if (s == "CRED_13") return CardDB.cardIDEnum.CRED_13;
            if (s == "CRED_14") return CardDB.cardIDEnum.CRED_14;
            if (s == "CRED_15") return CardDB.cardIDEnum.CRED_15;
            if (s == "CRED_16") return CardDB.cardIDEnum.CRED_16;
            if (s == "CRED_17") return CardDB.cardIDEnum.CRED_17;
            if (s == "EX1_062") return CardDB.cardIDEnum.EX1_062;
            if (s == "NEW1_016") return CardDB.cardIDEnum.NEW1_016;
            if (s == "TU4a_001") return CardDB.cardIDEnum.TU4a_001;
            if (s == "TU4a_002") return CardDB.cardIDEnum.TU4a_002;
            if (s == "TU4a_003") return CardDB.cardIDEnum.TU4a_003;
            if (s == "TU4a_004") return CardDB.cardIDEnum.TU4a_004;
            if (s == "TU4a_005") return CardDB.cardIDEnum.TU4a_005;
            if (s == "TU4a_006") return CardDB.cardIDEnum.TU4a_006;
            if (s == "TU4b_001") return CardDB.cardIDEnum.TU4b_001;
            if (s == "TU4c_001") return CardDB.cardIDEnum.TU4c_001;
            if (s == "TU4c_002") return CardDB.cardIDEnum.TU4c_002;
            if (s == "TU4c_003") return CardDB.cardIDEnum.TU4c_003;
            if (s == "TU4c_004") return CardDB.cardIDEnum.TU4c_004;
            if (s == "TU4c_005") return CardDB.cardIDEnum.TU4c_005;
            if (s == "TU4c_006") return CardDB.cardIDEnum.TU4c_006;
            if (s == "TU4c_006e") return CardDB.cardIDEnum.TU4c_006e;
            if (s == "TU4c_007") return CardDB.cardIDEnum.TU4c_007;
            if (s == "TU4c_008") return CardDB.cardIDEnum.TU4c_008;
            if (s == "TU4c_008e") return CardDB.cardIDEnum.TU4c_008e;
            if (s == "TU4d_001") return CardDB.cardIDEnum.TU4d_001;
            if (s == "TU4d_002") return CardDB.cardIDEnum.TU4d_002;
            if (s == "TU4d_003") return CardDB.cardIDEnum.TU4d_003;
            if (s == "TU4e_001") return CardDB.cardIDEnum.TU4e_001;
            if (s == "TU4e_002") return CardDB.cardIDEnum.TU4e_002;
            if (s == "TU4e_002t") return CardDB.cardIDEnum.TU4e_002t;
            if (s == "TU4e_003") return CardDB.cardIDEnum.TU4e_003;
            if (s == "TU4e_004") return CardDB.cardIDEnum.TU4e_004;
            if (s == "TU4e_005") return CardDB.cardIDEnum.TU4e_005;
            if (s == "TU4e_007") return CardDB.cardIDEnum.TU4e_007;
            if (s == "TU4f_001") return CardDB.cardIDEnum.TU4f_001;
            if (s == "TU4f_002") return CardDB.cardIDEnum.TU4f_002;
            if (s == "TU4f_003") return CardDB.cardIDEnum.TU4f_003;
            if (s == "TU4f_004") return CardDB.cardIDEnum.TU4f_004;
            if (s == "TU4f_004o") return CardDB.cardIDEnum.TU4f_004o;
            if (s == "TU4f_005") return CardDB.cardIDEnum.TU4f_005;
            if (s == "TU4f_006") return CardDB.cardIDEnum.TU4f_006;
            if (s == "TU4f_006o") return CardDB.cardIDEnum.TU4f_006o;
            if (s == "TU4f_007") return CardDB.cardIDEnum.TU4f_007;
            if (s == "XXX_001") return CardDB.cardIDEnum.XXX_001;
            if (s == "XXX_002") return CardDB.cardIDEnum.XXX_002;
            if (s == "XXX_003") return CardDB.cardIDEnum.XXX_003;
            if (s == "XXX_004") return CardDB.cardIDEnum.XXX_004;
            if (s == "XXX_005") return CardDB.cardIDEnum.XXX_005;
            if (s == "XXX_006") return CardDB.cardIDEnum.XXX_006;
            if (s == "XXX_007") return CardDB.cardIDEnum.XXX_007;
            if (s == "XXX_008") return CardDB.cardIDEnum.XXX_008;
            if (s == "XXX_009") return CardDB.cardIDEnum.XXX_009;
            if (s == "XXX_009e") return CardDB.cardIDEnum.XXX_009e;
            if (s == "XXX_010") return CardDB.cardIDEnum.XXX_010;
            if (s == "XXX_011") return CardDB.cardIDEnum.XXX_011;
            if (s == "XXX_012") return CardDB.cardIDEnum.XXX_012;
            if (s == "XXX_013") return CardDB.cardIDEnum.XXX_013;
            if (s == "XXX_014") return CardDB.cardIDEnum.XXX_014;
            if (s == "XXX_015") return CardDB.cardIDEnum.XXX_015;
            if (s == "XXX_016") return CardDB.cardIDEnum.XXX_016;
            if (s == "XXX_017") return CardDB.cardIDEnum.XXX_017;
            if (s == "XXX_018") return CardDB.cardIDEnum.XXX_018;
            if (s == "XXX_019") return CardDB.cardIDEnum.XXX_019;
            if (s == "XXX_020") return CardDB.cardIDEnum.XXX_020;
            if (s == "XXX_021") return CardDB.cardIDEnum.XXX_021;
            if (s == "XXX_022") return CardDB.cardIDEnum.XXX_022;
            if (s == "XXX_022e") return CardDB.cardIDEnum.XXX_022e;
            if (s == "XXX_023") return CardDB.cardIDEnum.XXX_023;
            if (s == "XXX_024") return CardDB.cardIDEnum.XXX_024;
            if (s == "XXX_025") return CardDB.cardIDEnum.XXX_025;
            if (s == "XXX_026") return CardDB.cardIDEnum.XXX_026;
            if (s == "XXX_027") return CardDB.cardIDEnum.XXX_027;
            if (s == "XXX_028") return CardDB.cardIDEnum.XXX_028;
            if (s == "XXX_029") return CardDB.cardIDEnum.XXX_029;
            if (s == "XXX_030") return CardDB.cardIDEnum.XXX_030;
            if (s == "XXX_039") return CardDB.cardIDEnum.XXX_039;
            if (s == "XXX_040") return CardDB.cardIDEnum.XXX_040;
            if (s == "XXX_041") return CardDB.cardIDEnum.XXX_041;
            if (s == "XXX_042") return CardDB.cardIDEnum.XXX_042;
            if (s == "XXX_043") return CardDB.cardIDEnum.XXX_043;
            if (s == "XXX_044") return CardDB.cardIDEnum.XXX_044;
            if (s == "XXX_045") return CardDB.cardIDEnum.XXX_045;
            if (s == "XXX_046") return CardDB.cardIDEnum.XXX_046;
            if (s == "XXX_047") return CardDB.cardIDEnum.XXX_047;
            if (s == "XXX_048") return CardDB.cardIDEnum.XXX_048;
            if (s == "XXX_049") return CardDB.cardIDEnum.XXX_049;
            if (s == "XXX_050") return CardDB.cardIDEnum.XXX_050;
            if (s == "XXX_051") return CardDB.cardIDEnum.XXX_051;
            if (s == "XXX_052") return CardDB.cardIDEnum.XXX_052;
            if (s == "XXX_053") return CardDB.cardIDEnum.XXX_053;
            if (s == "XXX_054") return CardDB.cardIDEnum.XXX_054;
            if (s == "XXX_054e") return CardDB.cardIDEnum.XXX_054e;
            if (s == "XXX_055") return CardDB.cardIDEnum.XXX_055;
            if (s == "XXX_055e") return CardDB.cardIDEnum.XXX_055e;
            if (s == "XXX_056") return CardDB.cardIDEnum.XXX_056;
            if (s == "XXX_057") return CardDB.cardIDEnum.XXX_057;
            if (s == "XXX_095") return CardDB.cardIDEnum.XXX_095;
            if (s == "XXX_096") return CardDB.cardIDEnum.XXX_096;
            if (s == "XXX_097") return CardDB.cardIDEnum.XXX_097;
            if (s == "XXX_098") return CardDB.cardIDEnum.XXX_098;
            if (s == "XXX_099") return CardDB.cardIDEnum.XXX_099;
            if (s == "EX1_112") return CardDB.cardIDEnum.EX1_112;
            if (s == "Mekka1") return CardDB.cardIDEnum.Mekka1;
            if (s == "Mekka2") return CardDB.cardIDEnum.Mekka2;
            if (s == "Mekka3") return CardDB.cardIDEnum.Mekka3;
            if (s == "Mekka3e") return CardDB.cardIDEnum.Mekka3e;
            if (s == "Mekka4") return CardDB.cardIDEnum.Mekka4;
            if (s == "Mekka4e") return CardDB.cardIDEnum.Mekka4e;
            if (s == "Mekka4t") return CardDB.cardIDEnum.Mekka4t;
            if (s == "PRO_001") return CardDB.cardIDEnum.PRO_001;
            if (s == "PRO_001a") return CardDB.cardIDEnum.PRO_001a;
            if (s == "PRO_001at") return CardDB.cardIDEnum.PRO_001at;
            if (s == "PRO_001b") return CardDB.cardIDEnum.PRO_001b;
            if (s == "PRO_001c") return CardDB.cardIDEnum.PRO_001c;
            if (s == "FP1_001") return CardDB.cardIDEnum.FP1_001;
            if (s == "FP1_002") return CardDB.cardIDEnum.FP1_002;
            if (s == "FP1_002t") return CardDB.cardIDEnum.FP1_002t;
            if (s == "FP1_003") return CardDB.cardIDEnum.FP1_003;
            if (s == "FP1_004") return CardDB.cardIDEnum.FP1_004;
            if (s == "FP1_005") return CardDB.cardIDEnum.FP1_005;
            if (s == "FP1_005e") return CardDB.cardIDEnum.FP1_005e;
            if (s == "FP1_006") return CardDB.cardIDEnum.FP1_006;
            if (s == "FP1_007") return CardDB.cardIDEnum.FP1_007;
            if (s == "FP1_007t") return CardDB.cardIDEnum.FP1_007t;
            if (s == "FP1_008") return CardDB.cardIDEnum.FP1_008;
            if (s == "FP1_009") return CardDB.cardIDEnum.FP1_009;
            if (s == "FP1_010") return CardDB.cardIDEnum.FP1_010;
            if (s == "FP1_011") return CardDB.cardIDEnum.FP1_011;
            if (s == "FP1_012") return CardDB.cardIDEnum.FP1_012;
            if (s == "FP1_012t") return CardDB.cardIDEnum.FP1_012t;
            if (s == "FP1_013") return CardDB.cardIDEnum.FP1_013;
            if (s == "FP1_014") return CardDB.cardIDEnum.FP1_014;
            if (s == "FP1_014t") return CardDB.cardIDEnum.FP1_014t;
            if (s == "FP1_015") return CardDB.cardIDEnum.FP1_015;
            if (s == "FP1_016") return CardDB.cardIDEnum.FP1_016;
            if (s == "FP1_017") return CardDB.cardIDEnum.FP1_017;
            if (s == "FP1_018") return CardDB.cardIDEnum.FP1_018;
            if (s == "FP1_019") return CardDB.cardIDEnum.FP1_019;
            if (s == "FP1_019t") return CardDB.cardIDEnum.FP1_019t;
            if (s == "FP1_020") return CardDB.cardIDEnum.FP1_020;
            if (s == "FP1_020e") return CardDB.cardIDEnum.FP1_020e;
            if (s == "FP1_021") return CardDB.cardIDEnum.FP1_021;
            if (s == "FP1_022") return CardDB.cardIDEnum.FP1_022;
            if (s == "FP1_023") return CardDB.cardIDEnum.FP1_023;
            if (s == "FP1_023e") return CardDB.cardIDEnum.FP1_023e;
            if (s == "FP1_024") return CardDB.cardIDEnum.FP1_024;
            if (s == "FP1_025") return CardDB.cardIDEnum.FP1_025;
            if (s == "FP1_026") return CardDB.cardIDEnum.FP1_026;
            if (s == "FP1_027") return CardDB.cardIDEnum.FP1_027;
            if (s == "FP1_028") return CardDB.cardIDEnum.FP1_028;
            if (s == "FP1_028e") return CardDB.cardIDEnum.FP1_028e;
            if (s == "FP1_029") return CardDB.cardIDEnum.FP1_029;
            if (s == "FP1_030") return CardDB.cardIDEnum.FP1_030;
            if (s == "FP1_030e") return CardDB.cardIDEnum.FP1_030e;
            if (s == "FP1_031") return CardDB.cardIDEnum.FP1_031;
            if (s == "NAX10_01") return CardDB.cardIDEnum.NAX10_01;
            if (s == "NAX10_01H") return CardDB.cardIDEnum.NAX10_01H;
            if (s == "NAX10_02") return CardDB.cardIDEnum.NAX10_02;
            if (s == "NAX10_02H") return CardDB.cardIDEnum.NAX10_02H;
            if (s == "NAX10_03") return CardDB.cardIDEnum.NAX10_03;
            if (s == "NAX10_03H") return CardDB.cardIDEnum.NAX10_03H;
            if (s == "NAX11_01") return CardDB.cardIDEnum.NAX11_01;
            if (s == "NAX11_01H") return CardDB.cardIDEnum.NAX11_01H;
            if (s == "NAX11_02") return CardDB.cardIDEnum.NAX11_02;
            if (s == "NAX11_02H") return CardDB.cardIDEnum.NAX11_02H;
            if (s == "NAX11_03") return CardDB.cardIDEnum.NAX11_03;
            if (s == "NAX11_04") return CardDB.cardIDEnum.NAX11_04;
            if (s == "NAX11_04e") return CardDB.cardIDEnum.NAX11_04e;
            if (s == "NAX12_01") return CardDB.cardIDEnum.NAX12_01;
            if (s == "NAX12_01H") return CardDB.cardIDEnum.NAX12_01H;
            if (s == "NAX12_02") return CardDB.cardIDEnum.NAX12_02;
            if (s == "NAX12_02e") return CardDB.cardIDEnum.NAX12_02e;
            if (s == "NAX12_02H") return CardDB.cardIDEnum.NAX12_02H;
            if (s == "NAX12_03") return CardDB.cardIDEnum.NAX12_03;
            if (s == "NAX12_03e") return CardDB.cardIDEnum.NAX12_03e;
            if (s == "NAX12_03H") return CardDB.cardIDEnum.NAX12_03H;
            if (s == "NAX12_04") return CardDB.cardIDEnum.NAX12_04;
            if (s == "NAX12_04e") return CardDB.cardIDEnum.NAX12_04e;
            if (s == "NAX13_01") return CardDB.cardIDEnum.NAX13_01;
            if (s == "NAX13_01H") return CardDB.cardIDEnum.NAX13_01H;
            if (s == "NAX13_02") return CardDB.cardIDEnum.NAX13_02;
            if (s == "NAX13_02e") return CardDB.cardIDEnum.NAX13_02e;
            if (s == "NAX13_03") return CardDB.cardIDEnum.NAX13_03;
            if (s == "NAX13_03e") return CardDB.cardIDEnum.NAX13_03e;
            if (s == "NAX13_04H") return CardDB.cardIDEnum.NAX13_04H;
            if (s == "NAX13_05H") return CardDB.cardIDEnum.NAX13_05H;
            if (s == "NAX14_01") return CardDB.cardIDEnum.NAX14_01;
            if (s == "NAX14_01H") return CardDB.cardIDEnum.NAX14_01H;
            if (s == "NAX14_02") return CardDB.cardIDEnum.NAX14_02;
            if (s == "NAX14_03") return CardDB.cardIDEnum.NAX14_03;
            if (s == "NAX14_04") return CardDB.cardIDEnum.NAX14_04;
            if (s == "NAX15_01") return CardDB.cardIDEnum.NAX15_01;
            if (s == "NAX15_01e") return CardDB.cardIDEnum.NAX15_01e;
            if (s == "NAX15_01H") return CardDB.cardIDEnum.NAX15_01H;
            if (s == "NAX15_01He") return CardDB.cardIDEnum.NAX15_01He;
            if (s == "NAX15_02") return CardDB.cardIDEnum.NAX15_02;
            if (s == "NAX15_02H") return CardDB.cardIDEnum.NAX15_02H;
            if (s == "NAX15_03n") return CardDB.cardIDEnum.NAX15_03n;
            if (s == "NAX15_03t") return CardDB.cardIDEnum.NAX15_03t;
            if (s == "NAX15_04") return CardDB.cardIDEnum.NAX15_04;
            if (s == "NAX15_04a") return CardDB.cardIDEnum.NAX15_04a;
            if (s == "NAX15_04H") return CardDB.cardIDEnum.NAX15_04H;
            if (s == "NAX15_05") return CardDB.cardIDEnum.NAX15_05;
            if (s == "NAX1h_01") return CardDB.cardIDEnum.NAX1h_01;
            if (s == "NAX1h_03") return CardDB.cardIDEnum.NAX1h_03;
            if (s == "NAX1h_04") return CardDB.cardIDEnum.NAX1h_04;
            if (s == "NAX1_01") return CardDB.cardIDEnum.NAX1_01;
            if (s == "NAX1_03") return CardDB.cardIDEnum.NAX1_03;
            if (s == "NAX1_04") return CardDB.cardIDEnum.NAX1_04;
            if (s == "NAX1_05") return CardDB.cardIDEnum.NAX1_05;
            if (s == "NAX2_01") return CardDB.cardIDEnum.NAX2_01;
            if (s == "NAX2_01H") return CardDB.cardIDEnum.NAX2_01H;
            if (s == "NAX2_03") return CardDB.cardIDEnum.NAX2_03;
            if (s == "NAX2_03H") return CardDB.cardIDEnum.NAX2_03H;
            if (s == "NAX2_05") return CardDB.cardIDEnum.NAX2_05;
            if (s == "NAX2_05H") return CardDB.cardIDEnum.NAX2_05H;
            if (s == "NAX3_01") return CardDB.cardIDEnum.NAX3_01;
            if (s == "NAX3_01H") return CardDB.cardIDEnum.NAX3_01H;
            if (s == "NAX3_02") return CardDB.cardIDEnum.NAX3_02;
            if (s == "NAX3_02H") return CardDB.cardIDEnum.NAX3_02H;
            if (s == "NAX3_03") return CardDB.cardIDEnum.NAX3_03;
            if (s == "NAX4_01") return CardDB.cardIDEnum.NAX4_01;
            if (s == "NAX4_01H") return CardDB.cardIDEnum.NAX4_01H;
            if (s == "NAX4_03") return CardDB.cardIDEnum.NAX4_03;
            if (s == "NAX4_03H") return CardDB.cardIDEnum.NAX4_03H;
            if (s == "NAX4_04") return CardDB.cardIDEnum.NAX4_04;
            if (s == "NAX4_04H") return CardDB.cardIDEnum.NAX4_04H;
            if (s == "NAX4_05") return CardDB.cardIDEnum.NAX4_05;
            if (s == "NAX5_01") return CardDB.cardIDEnum.NAX5_01;
            if (s == "NAX5_01H") return CardDB.cardIDEnum.NAX5_01H;
            if (s == "NAX5_02") return CardDB.cardIDEnum.NAX5_02;
            if (s == "NAX5_02H") return CardDB.cardIDEnum.NAX5_02H;
            if (s == "NAX5_03") return CardDB.cardIDEnum.NAX5_03;
            if (s == "NAX6_01") return CardDB.cardIDEnum.NAX6_01;
            if (s == "NAX6_01H") return CardDB.cardIDEnum.NAX6_01H;
            if (s == "NAX6_02") return CardDB.cardIDEnum.NAX6_02;
            if (s == "NAX6_02H") return CardDB.cardIDEnum.NAX6_02H;
            if (s == "NAX6_03") return CardDB.cardIDEnum.NAX6_03;
            if (s == "NAX6_03t") return CardDB.cardIDEnum.NAX6_03t;
            if (s == "NAX6_03te") return CardDB.cardIDEnum.NAX6_03te;
            if (s == "NAX6_04") return CardDB.cardIDEnum.NAX6_04;
            if (s == "NAX7_01") return CardDB.cardIDEnum.NAX7_01;
            if (s == "NAX7_01H") return CardDB.cardIDEnum.NAX7_01H;
            if (s == "NAX7_02") return CardDB.cardIDEnum.NAX7_02;
            if (s == "NAX7_03") return CardDB.cardIDEnum.NAX7_03;
            if (s == "NAX7_03H") return CardDB.cardIDEnum.NAX7_03H;
            if (s == "NAX7_04") return CardDB.cardIDEnum.NAX7_04;
            if (s == "NAX7_04H") return CardDB.cardIDEnum.NAX7_04H;
            if (s == "NAX7_05") return CardDB.cardIDEnum.NAX7_05;
            if (s == "NAX8_01") return CardDB.cardIDEnum.NAX8_01;
            if (s == "NAX8_01H") return CardDB.cardIDEnum.NAX8_01H;
            if (s == "NAX8_02") return CardDB.cardIDEnum.NAX8_02;
            if (s == "NAX8_02H") return CardDB.cardIDEnum.NAX8_02H;
            if (s == "NAX8_03") return CardDB.cardIDEnum.NAX8_03;
            if (s == "NAX8_03t") return CardDB.cardIDEnum.NAX8_03t;
            if (s == "NAX8_04") return CardDB.cardIDEnum.NAX8_04;
            if (s == "NAX8_04t") return CardDB.cardIDEnum.NAX8_04t;
            if (s == "NAX8_05") return CardDB.cardIDEnum.NAX8_05;
            if (s == "NAX8_05t") return CardDB.cardIDEnum.NAX8_05t;
            if (s == "NAX9_01") return CardDB.cardIDEnum.NAX9_01;
            if (s == "NAX9_01H") return CardDB.cardIDEnum.NAX9_01H;
            if (s == "NAX9_02") return CardDB.cardIDEnum.NAX9_02;
            if (s == "NAX9_02H") return CardDB.cardIDEnum.NAX9_02H;
            if (s == "NAX9_03") return CardDB.cardIDEnum.NAX9_03;
            if (s == "NAX9_03H") return CardDB.cardIDEnum.NAX9_03H;
            if (s == "NAX9_04") return CardDB.cardIDEnum.NAX9_04;
            if (s == "NAX9_04H") return CardDB.cardIDEnum.NAX9_04H;
            if (s == "NAX9_05") return CardDB.cardIDEnum.NAX9_05;
            if (s == "NAX9_05H") return CardDB.cardIDEnum.NAX9_05H;
            if (s == "NAX9_06") return CardDB.cardIDEnum.NAX9_06;
            if (s == "NAX9_07") return CardDB.cardIDEnum.NAX9_07;
            if (s == "NAX9_07e") return CardDB.cardIDEnum.NAX9_07e;
            if (s == "NAXM_001") return CardDB.cardIDEnum.NAXM_001;
            if (s == "NAXM_002") return CardDB.cardIDEnum.NAXM_002;
            if (s == "GVG_001") return CardDB.cardIDEnum.GVG_001;
            if (s == "GVG_002") return CardDB.cardIDEnum.GVG_002;
            if (s == "GVG_003") return CardDB.cardIDEnum.GVG_003;
            if (s == "GVG_004") return CardDB.cardIDEnum.GVG_004;
            if (s == "GVG_005") return CardDB.cardIDEnum.GVG_005;
            if (s == "GVG_006") return CardDB.cardIDEnum.GVG_006;
            if (s == "GVG_007") return CardDB.cardIDEnum.GVG_007;
            if (s == "GVG_008") return CardDB.cardIDEnum.GVG_008;
            if (s == "GVG_009") return CardDB.cardIDEnum.GVG_009;
            if (s == "GVG_010") return CardDB.cardIDEnum.GVG_010;
            if (s == "GVG_010b") return CardDB.cardIDEnum.GVG_010b;
            if (s == "GVG_011") return CardDB.cardIDEnum.GVG_011;
            if (s == "GVG_011a") return CardDB.cardIDEnum.GVG_011a;
            if (s == "GVG_012") return CardDB.cardIDEnum.GVG_012;
            if (s == "GVG_013") return CardDB.cardIDEnum.GVG_013;
            if (s == "GVG_014") return CardDB.cardIDEnum.GVG_014;
            if (s == "GVG_014a") return CardDB.cardIDEnum.GVG_014a;
            if (s == "GVG_015") return CardDB.cardIDEnum.GVG_015;
            if (s == "GVG_016") return CardDB.cardIDEnum.GVG_016;
            if (s == "GVG_017") return CardDB.cardIDEnum.GVG_017;
            if (s == "GVG_018") return CardDB.cardIDEnum.GVG_018;
            if (s == "GVG_019") return CardDB.cardIDEnum.GVG_019;
            if (s == "GVG_019e") return CardDB.cardIDEnum.GVG_019e;
            if (s == "GVG_020") return CardDB.cardIDEnum.GVG_020;
            if (s == "GVG_021") return CardDB.cardIDEnum.GVG_021;
            if (s == "GVG_021e") return CardDB.cardIDEnum.GVG_021e;
            if (s == "GVG_022") return CardDB.cardIDEnum.GVG_022;
            if (s == "GVG_022a") return CardDB.cardIDEnum.GVG_022a;
            if (s == "GVG_022b") return CardDB.cardIDEnum.GVG_022b;
            if (s == "GVG_023") return CardDB.cardIDEnum.GVG_023;
            if (s == "GVG_023a") return CardDB.cardIDEnum.GVG_023a;
            if (s == "GVG_024") return CardDB.cardIDEnum.GVG_024;
            if (s == "GVG_025") return CardDB.cardIDEnum.GVG_025;
            if (s == "GVG_026") return CardDB.cardIDEnum.GVG_026;
            if (s == "GVG_027") return CardDB.cardIDEnum.GVG_027;
            if (s == "GVG_027e") return CardDB.cardIDEnum.GVG_027e;
            if (s == "GVG_028") return CardDB.cardIDEnum.GVG_028;
            if (s == "GVG_028t") return CardDB.cardIDEnum.GVG_028t;
            if (s == "GVG_029") return CardDB.cardIDEnum.GVG_029;
            if (s == "GVG_030") return CardDB.cardIDEnum.GVG_030;
            if (s == "GVG_030a") return CardDB.cardIDEnum.GVG_030a;
            if (s == "GVG_030ae") return CardDB.cardIDEnum.GVG_030ae;
            if (s == "GVG_030b") return CardDB.cardIDEnum.GVG_030b;
            if (s == "GVG_030be") return CardDB.cardIDEnum.GVG_030be;
            if (s == "GVG_031") return CardDB.cardIDEnum.GVG_031;
            if (s == "GVG_032") return CardDB.cardIDEnum.GVG_032;
            if (s == "GVG_032a") return CardDB.cardIDEnum.GVG_032a;
            if (s == "GVG_032b") return CardDB.cardIDEnum.GVG_032b;
            if (s == "GVG_033") return CardDB.cardIDEnum.GVG_033;
            if (s == "GVG_034") return CardDB.cardIDEnum.GVG_034;
            if (s == "GVG_035") return CardDB.cardIDEnum.GVG_035;
            if (s == "GVG_036") return CardDB.cardIDEnum.GVG_036;
            if (s == "GVG_036e") return CardDB.cardIDEnum.GVG_036e;
            if (s == "GVG_037") return CardDB.cardIDEnum.GVG_037;
            if (s == "GVG_038") return CardDB.cardIDEnum.GVG_038;
            if (s == "GVG_039") return CardDB.cardIDEnum.GVG_039;
            if (s == "GVG_040") return CardDB.cardIDEnum.GVG_040;
            if (s == "GVG_041") return CardDB.cardIDEnum.GVG_041;
            if (s == "GVG_041a") return CardDB.cardIDEnum.GVG_041a;
            if (s == "GVG_041b") return CardDB.cardIDEnum.GVG_041b;
            if (s == "GVG_041c") return CardDB.cardIDEnum.GVG_041c;
            if (s == "GVG_042") return CardDB.cardIDEnum.GVG_042;
            if (s == "GVG_043") return CardDB.cardIDEnum.GVG_043;
            if (s == "GVG_043e") return CardDB.cardIDEnum.GVG_043e;
            if (s == "GVG_044") return CardDB.cardIDEnum.GVG_044;
            if (s == "GVG_045") return CardDB.cardIDEnum.GVG_045;
            if (s == "GVG_045t") return CardDB.cardIDEnum.GVG_045t;
            if (s == "GVG_046") return CardDB.cardIDEnum.GVG_046;
            if (s == "GVG_046e") return CardDB.cardIDEnum.GVG_046e;
            if (s == "GVG_047") return CardDB.cardIDEnum.GVG_047;
            if (s == "GVG_048") return CardDB.cardIDEnum.GVG_048;
            if (s == "GVG_048e") return CardDB.cardIDEnum.GVG_048e;
            if (s == "GVG_049") return CardDB.cardIDEnum.GVG_049;
            if (s == "GVG_049e") return CardDB.cardIDEnum.GVG_049e;
            if (s == "GVG_050") return CardDB.cardIDEnum.GVG_050;
            if (s == "GVG_051") return CardDB.cardIDEnum.GVG_051;
            if (s == "GVG_052") return CardDB.cardIDEnum.GVG_052;
            if (s == "GVG_053") return CardDB.cardIDEnum.GVG_053;
            if (s == "GVG_054") return CardDB.cardIDEnum.GVG_054;
            if (s == "GVG_055") return CardDB.cardIDEnum.GVG_055;
            if (s == "GVG_055e") return CardDB.cardIDEnum.GVG_055e;
            if (s == "GVG_056") return CardDB.cardIDEnum.GVG_056;
            if (s == "GVG_056t") return CardDB.cardIDEnum.GVG_056t;
            if (s == "GVG_057") return CardDB.cardIDEnum.GVG_057;
            if (s == "GVG_057a") return CardDB.cardIDEnum.GVG_057a;
            if (s == "GVG_058") return CardDB.cardIDEnum.GVG_058;
            if (s == "GVG_059") return CardDB.cardIDEnum.GVG_059;
            if (s == "GVG_060") return CardDB.cardIDEnum.GVG_060;
            if (s == "GVG_060e") return CardDB.cardIDEnum.GVG_060e;
            if (s == "GVG_061") return CardDB.cardIDEnum.GVG_061;
            if (s == "GVG_062") return CardDB.cardIDEnum.GVG_062;
            if (s == "GVG_063") return CardDB.cardIDEnum.GVG_063;
            if (s == "GVG_063a") return CardDB.cardIDEnum.GVG_063a;
            if (s == "GVG_064") return CardDB.cardIDEnum.GVG_064;
            if (s == "GVG_065") return CardDB.cardIDEnum.GVG_065;
            if (s == "GVG_066") return CardDB.cardIDEnum.GVG_066;
            if (s == "GVG_067") return CardDB.cardIDEnum.GVG_067;
            if (s == "GVG_067a") return CardDB.cardIDEnum.GVG_067a;
            if (s == "GVG_068") return CardDB.cardIDEnum.GVG_068;
            if (s == "GVG_068a") return CardDB.cardIDEnum.GVG_068a;
            if (s == "GVG_069") return CardDB.cardIDEnum.GVG_069;
            if (s == "GVG_069a") return CardDB.cardIDEnum.GVG_069a;
            if (s == "GVG_070") return CardDB.cardIDEnum.GVG_070;
            if (s == "GVG_071") return CardDB.cardIDEnum.GVG_071;
            if (s == "GVG_072") return CardDB.cardIDEnum.GVG_072;
            if (s == "GVG_073") return CardDB.cardIDEnum.GVG_073;
            if (s == "GVG_074") return CardDB.cardIDEnum.GVG_074;
            if (s == "GVG_075") return CardDB.cardIDEnum.GVG_075;
            if (s == "GVG_076") return CardDB.cardIDEnum.GVG_076;
            if (s == "GVG_076a") return CardDB.cardIDEnum.GVG_076a;
            if (s == "GVG_077") return CardDB.cardIDEnum.GVG_077;
            if (s == "GVG_078") return CardDB.cardIDEnum.GVG_078;
            if (s == "GVG_079") return CardDB.cardIDEnum.GVG_079;
            if (s == "GVG_080") return CardDB.cardIDEnum.GVG_080;
            if (s == "GVG_080t") return CardDB.cardIDEnum.GVG_080t;
            if (s == "GVG_081") return CardDB.cardIDEnum.GVG_081;
            if (s == "GVG_082") return CardDB.cardIDEnum.GVG_082;
            if (s == "GVG_083") return CardDB.cardIDEnum.GVG_083;
            if (s == "GVG_084") return CardDB.cardIDEnum.GVG_084;
            if (s == "GVG_085") return CardDB.cardIDEnum.GVG_085;
            if (s == "GVG_086") return CardDB.cardIDEnum.GVG_086;
            if (s == "GVG_086e") return CardDB.cardIDEnum.GVG_086e;
            if (s == "GVG_087") return CardDB.cardIDEnum.GVG_087;
            if (s == "GVG_088") return CardDB.cardIDEnum.GVG_088;
            if (s == "GVG_089") return CardDB.cardIDEnum.GVG_089;
            if (s == "GVG_090") return CardDB.cardIDEnum.GVG_090;
            if (s == "GVG_091") return CardDB.cardIDEnum.GVG_091;
            if (s == "GVG_092") return CardDB.cardIDEnum.GVG_092;
            if (s == "GVG_092t") return CardDB.cardIDEnum.GVG_092t;
            if (s == "GVG_093") return CardDB.cardIDEnum.GVG_093;
            if (s == "GVG_094") return CardDB.cardIDEnum.GVG_094;
            if (s == "GVG_095") return CardDB.cardIDEnum.GVG_095;
            if (s == "GVG_096") return CardDB.cardIDEnum.GVG_096;
            if (s == "GVG_097") return CardDB.cardIDEnum.GVG_097;
            if (s == "GVG_098") return CardDB.cardIDEnum.GVG_098;
            if (s == "GVG_099") return CardDB.cardIDEnum.GVG_099;
            if (s == "GVG_100") return CardDB.cardIDEnum.GVG_100;
            if (s == "GVG_100e") return CardDB.cardIDEnum.GVG_100e;
            if (s == "GVG_101") return CardDB.cardIDEnum.GVG_101;
            if (s == "GVG_101e") return CardDB.cardIDEnum.GVG_101e;
            if (s == "GVG_102") return CardDB.cardIDEnum.GVG_102;
            if (s == "GVG_102e") return CardDB.cardIDEnum.GVG_102e;
            if (s == "GVG_103") return CardDB.cardIDEnum.GVG_103;
            if (s == "GVG_104") return CardDB.cardIDEnum.GVG_104;
            if (s == "GVG_104a") return CardDB.cardIDEnum.GVG_104a;
            if (s == "GVG_105") return CardDB.cardIDEnum.GVG_105;
            if (s == "GVG_106") return CardDB.cardIDEnum.GVG_106;
            if (s == "GVG_106e") return CardDB.cardIDEnum.GVG_106e;
            if (s == "GVG_107") return CardDB.cardIDEnum.GVG_107;
            if (s == "GVG_108") return CardDB.cardIDEnum.GVG_108;
            if (s == "GVG_109") return CardDB.cardIDEnum.GVG_109;
            if (s == "GVG_110") return CardDB.cardIDEnum.GVG_110;
            if (s == "GVG_110t") return CardDB.cardIDEnum.GVG_110t;
            if (s == "GVG_111") return CardDB.cardIDEnum.GVG_111;
            if (s == "GVG_111t") return CardDB.cardIDEnum.GVG_111t;
            if (s == "GVG_112") return CardDB.cardIDEnum.GVG_112;
            if (s == "GVG_113") return CardDB.cardIDEnum.GVG_113;
            if (s == "GVG_114") return CardDB.cardIDEnum.GVG_114;
            if (s == "GVG_115") return CardDB.cardIDEnum.GVG_115;
            if (s == "GVG_116") return CardDB.cardIDEnum.GVG_116;
            if (s == "GVG_117") return CardDB.cardIDEnum.GVG_117;
            if (s == "GVG_118") return CardDB.cardIDEnum.GVG_118;
            if (s == "GVG_119") return CardDB.cardIDEnum.GVG_119;
            if (s == "GVG_120") return CardDB.cardIDEnum.GVG_120;
            if (s == "GVG_121") return CardDB.cardIDEnum.GVG_121;
            if (s == "GVG_122") return CardDB.cardIDEnum.GVG_122;
            if (s == "GVG_123") return CardDB.cardIDEnum.GVG_123;
            if (s == "GVG_123e") return CardDB.cardIDEnum.GVG_123e;
            if (s == "PART_001") return CardDB.cardIDEnum.PART_001;
            if (s == "PART_001e") return CardDB.cardIDEnum.PART_001e;
            if (s == "PART_002") return CardDB.cardIDEnum.PART_002;
            if (s == "PART_003") return CardDB.cardIDEnum.PART_003;
            if (s == "PART_004") return CardDB.cardIDEnum.PART_004;
            if (s == "PART_004e") return CardDB.cardIDEnum.PART_004e;
            if (s == "PART_005") return CardDB.cardIDEnum.PART_005;
            if (s == "PART_006") return CardDB.cardIDEnum.PART_006;
            if (s == "PART_006a") return CardDB.cardIDEnum.PART_006a;
            if (s == "PART_007") return CardDB.cardIDEnum.PART_007;
            if (s == "PART_007e") return CardDB.cardIDEnum.PART_007e;

            //alternativ hero-powers
            if (s == "CS2_034_H1") return CardDB.cardIDEnum.CS2_034;
            if (s == "DS1h_292_H1") return CardDB.cardIDEnum.DS1h_292;
            if (s == "CS2_049_H1") return CardDB.cardIDEnum.CS2_049;
            if (s == "CS2_056_H1") return CardDB.cardIDEnum.CS2_056;
            if (s == "CS2_101_H1") return CardDB.cardIDEnum.CS2_101;
            if (s == "CS2_102_H1") return CardDB.cardIDEnum.CS2_102;

            //better version of heropowers
            if (s == "AT_132_DRUID") return CardDB.cardIDEnum.AT_132_DRUID;
            if (s == "AT_132_HUNTER") return CardDB.cardIDEnum.AT_132_HUNTER;
            if (s == "AT_132_MAGE") return CardDB.cardIDEnum.AT_132_MAGE;
            if (s == "AT_132_PALADIN") return CardDB.cardIDEnum.AT_132_PALADIN;
            if (s == "AT_132_PRIEST") return CardDB.cardIDEnum.AT_132_PRIEST;
            if (s == "AT_132_ROGUE") return CardDB.cardIDEnum.AT_132_ROGUE;
            if (s == "AT_132_SHAMAN") return CardDB.cardIDEnum.AT_132_SHAMAN;
            if (s == "AT_132_WARLOCK") return CardDB.cardIDEnum.AT_132_WARLOCK;
            if (s == "AT_132_WARRIOR") return CardDB.cardIDEnum.AT_132_WARRIOR;

            // totems
            if (s == "AT_132_SHAMANa") return CardDB.cardIDEnum.NEW1_009;//Healing Totem
            if (s == "AT_132_SHAMANb") return CardDB.cardIDEnum.CS2_050;//searing
            if (s == "AT_132_SHAMANc") return CardDB.cardIDEnum.CS2_051;//stonwclaw
            if (s == "AT_132_SHAMANd") return CardDB.cardIDEnum.CS2_052;//wrath of air

            //LOE##############
            if (s == "LOEA10_3") return CardDB.cardIDEnum.LOEA10_3;
            if (s == "LOEA16_3") return CardDB.cardIDEnum.LOEA16_3;
            if (s == "LOEA16_3e") return CardDB.cardIDEnum.LOEA16_3e;
            if (s == "LOEA16_4") return CardDB.cardIDEnum.LOEA16_4;
            if (s == "LOEA16_5") return CardDB.cardIDEnum.LOEA16_5;
            if (s == "LOEA16_5t") return CardDB.cardIDEnum.LOEA16_5t;

            if (s == "LOE_002") return CardDB.cardIDEnum.LOE_002;
            if (s == "LOE_002t") return CardDB.cardIDEnum.LOE_002t;
            if (s == "LOE_003") return CardDB.cardIDEnum.LOE_003;
            if (s == "LOE_006") return CardDB.cardIDEnum.LOE_006;
            if (s == "LOE_007") return CardDB.cardIDEnum.LOE_007;
            if (s == "LOE_007t") return CardDB.cardIDEnum.LOE_007t;
            if (s == "LOE_009") return CardDB.cardIDEnum.LOE_009;
            if (s == "LOE_009t") return CardDB.cardIDEnum.LOE_009t;
            if (s == "LOE_010") return CardDB.cardIDEnum.LOE_010;
            if (s == "LOE_011") return CardDB.cardIDEnum.LOE_011;
            if (s == "LOE_012") return CardDB.cardIDEnum.LOE_012;
            if (s == "LOE_016") return CardDB.cardIDEnum.LOE_016;
            if (s == "LOE_017") return CardDB.cardIDEnum.LOE_017;
            if (s == "LOE_018") return CardDB.cardIDEnum.LOE_018;
            if (s == "LOE_019") return CardDB.cardIDEnum.LOE_019;
            if (s == "LOE_019t") return CardDB.cardIDEnum.LOE_019t;
            if (s == "LOE_019t2") return CardDB.cardIDEnum.LOE_019t2;
            if (s == "LOE_020") return CardDB.cardIDEnum.LOE_020;
            if (s == "LOE_021") return CardDB.cardIDEnum.LOE_021;
            if (s == "LOE_022") return CardDB.cardIDEnum.LOE_022;
            if (s == "LOE_023") return CardDB.cardIDEnum.LOE_023;
            if (s == "LOE_026") return CardDB.cardIDEnum.LOE_026;
            if (s == "LOE_027") return CardDB.cardIDEnum.LOE_027;
            if (s == "LOE_029") return CardDB.cardIDEnum.LOE_029;
            if (s == "LOE_038") return CardDB.cardIDEnum.LOE_038;
            if (s == "LOE_039") return CardDB.cardIDEnum.LOE_039;
            if (s == "LOE_046") return CardDB.cardIDEnum.LOE_046;
            if (s == "LOE_047") return CardDB.cardIDEnum.LOE_047;
            if (s == "LOE_050") return CardDB.cardIDEnum.LOE_050;
            if (s == "LOE_051") return CardDB.cardIDEnum.LOE_051;
            if (s == "LOE_053") return CardDB.cardIDEnum.LOE_053;
            if (s == "LOE_061") return CardDB.cardIDEnum.LOE_061;
            if (s == "LOE_073") return CardDB.cardIDEnum.LOE_073;
            if (s == "LOE_076") return CardDB.cardIDEnum.LOE_076;
            if (s == "LOE_077") return CardDB.cardIDEnum.LOE_077;
            if (s == "LOE_079") return CardDB.cardIDEnum.LOE_079;
            if (s == "LOE_086") return CardDB.cardIDEnum.LOE_086;
            if (s == "LOE_089") return CardDB.cardIDEnum.LOE_089;
            if (s == "LOE_089t") return CardDB.cardIDEnum.LOE_089t;
            if (s == "LOE_089t2") return CardDB.cardIDEnum.LOE_089t2;
            if (s == "LOE_089t3") return CardDB.cardIDEnum.LOE_089t3;
            if (s == "LOE_092") return CardDB.cardIDEnum.LOE_092;
            if (s == "LOE_104") return CardDB.cardIDEnum.LOE_104;
            if (s == "LOE_105") return CardDB.cardIDEnum.LOE_105;
            if (s == "LOE_105e") return CardDB.cardIDEnum.LOE_105e;
            if (s == "LOE_107") return CardDB.cardIDEnum.LOE_107;
            if (s == "LOE_110") return CardDB.cardIDEnum.LOE_110;
            if (s == "LOE_110t") return CardDB.cardIDEnum.LOE_110t;
            if (s == "LOE_111") return CardDB.cardIDEnum.LOE_111;
            if (s == "LOE_113") return CardDB.cardIDEnum.LOE_113;
            if (s == "LOE_115") return CardDB.cardIDEnum.LOE_115;
            if (s == "LOE_115a") return CardDB.cardIDEnum.LOE_115a;
            if (s == "LOE_115b") return CardDB.cardIDEnum.LOE_115b;
            if (s == "LOE_116") return CardDB.cardIDEnum.LOE_116;
            if (s == "LOE_118") return CardDB.cardIDEnum.LOE_118;
            if (s == "LOE_119") return CardDB.cardIDEnum.LOE_119;



            //better hero powers of alternative heros
            if (s == "CS2_034_H1_AT_132") return CardDB.cardIDEnum.AT_132_MAGE;
            if (s == "CS2_102_H1_AT_132") return CardDB.cardIDEnum.AT_132_WARRIOR;
            if (s == "DS1h_292_H1_AT_132") return CardDB.cardIDEnum.AT_132_HUNTER;









            if (s == "PlaceholderCard") return CardDB.cardIDEnum.PlaceholderCard;

            return CardDB.cardIDEnum.None;
        }

        public enum cardName
        {
            unknown,
            //LOE
            murloctinyfin,
            lanternofpower,
            timepieceofhorror,
            mirrorofdoom,
            mummyzombie,

            forgottentorch,
            roaringtorch,
            etherealconjurer,
            museumcurator,
            curseofrafaam,
            cursed,
            obsidiandestroyer,
            scarab,
            pitsnake,
            renojackson,
            tombpillager,
            rumblingelemental,
            keeperofuldaman,
            tunneltrogg,
            unearthedraptor,
            maptothegoldenmonkey,
            goldenmonkey,
            desertcamel,
            darttrap,
            fiercemonkey,
            darkpeddler,
            anyfincanhappen,
            sacredtrial,
            jeweledscarab,
            nagaseawitch,
            gorillabota3,
            hugetoad,
            tombspider,
            mountedraptor,
            junglemoonkin,
            djinniofzephyrs,
            anubisathsentinel,
            fossilizeddevilsaur,
            sirfinleymrrgglton,
            brannbronzebeard,
            elisestarseeker,
            summoningstone,
            wobblingrunts,
            rascallyrunt,
            wilyrunt,
            grumblyrunt,
            archthiefrafaam,
            entomb,
            explorershat,
            eeriestatue,
            ancientshade,
            ancientcurse,
            excavatedevil,
            everyfinisawesome,
            ravenidol,
            reliquaryseeker,
            cursedblade,
            animatedarmor,

            //TGT
            flamelance,
            effigy,
            fallenhero,
            arcaneblast,
            polymorphboar,
            dalaranaspirant,
            spellslinger,
            coldarradrake,
            rhonin,
            ramwrangler,
            holychampion,
            spawnofshadows,
            powerwordglory,
            shadowfiend,
            convert,
            confuse,
            twilightguardian,
            confessorpaletress,
            dreadsteed,
            fearsomedoomguard,
            tinyknightofevil,
            fistofjaraxxus,
            voidcrusher,
            demonfuse,
            darkbargain,
            wrathguard,
            wilfredfizzlebang,
            shadopanrider,
            buccaneer,
            undercityvaliant,
            cutpurse,
            shadydealer,
            burgle,
            poisonedblade,
            beneaththegrounds,
            ambush,
            anubarak,
            livingroots,
            sapling,
            darnassusaspirant,
            savagecombatant,
            wildwalker,
            knightofthewild,
            druidofthesaber,
            lionform,
            pantherform,
            sabertoothlion,
            sabertoothpanther,
            astralcommunion,
            mulch,
            aviana,
            tuskarrtotemic,
            draeneitotemcarver,
            healingwave,
            thunderbluffvaliant,
            chargedhammer,
            lightningjolt,
            elementaldestruction,
            totemgolem,
            ancestralknowledge,
            themistcaller,
            flashheal,
            powershot,
            stablemaster,
            kingselekk,
            bravearcher,
            beartrap,
            lockandload,
            ballofspiders,
            acidmaw,
            dreadscale,
            bash,
            kingsdefender,
            orgrimmaraspirant,
            magnatauralpha,
            bolster,
            sparringpartner,
            skycapnkragg,
            alexstraszaschampion,
            varianwrynn,
            competitivespirit,
            sealofchampions,
            warhorsetrainer,
            murlocknight,
            argentlance,
            enterthecoliseum,
            mysteriouschallenger,
            garrisoncommander,
            eadricthepure,
            lowlysquire,
            dragonhawkrider,
            lancecarrier,
            maidenofthelake,
            saboteur,
            argenthorserider,
            mogorschampion,
            boneguardlieutenant,
            muklaschampion,
            tournamentmedic,
            icerager,
            frigidsnobold,
            flamejuggler,
            silentknight,
            clockworkknight,
            tournamentattendee,
            sideshowspelleater,
            kodorider,
            warkodo,
            silverhandregent,
            pitfighter,
            capturedjormungar,
            northseakraken,
            tuskarrjouster,
            injuredkvaldir,
            lightschampion,
            armoredwarhorse,
            argentwatchman,
            coliseummanager,
            refreshmentvendor,
            masterjouster,
            recruiter,
            evilheckler,
            fencingcoach,
            wyrmrestagent,
            masterofceremonies,
            grandcrusader,
            kvaldirraider,
            frostgiant,
            crowdfavorite,
            gormoktheimpaler,
            chillmaw,
            bolframshield,
            icehowl,
            nexuschampionsaraad,
            theskeletonknight,
            fjolalightbane,
            seareaver,
            eydisdarkbane,
            justicartrueheart,
            direshapeshift,
            ballistashot,
            fireblastrank2,
            thesilverhand,
            heal,
            poisoneddaggers,
            poisoneddagger,
            totemicslam,
            soultap,
            tankup,
            gadgetzanjouster,
            //new Heros################
            magnibronzebeard,
            alleriawindrunner,
            medivh,
            //#####################################blackrockcards
            solemnvigil,
            flamewaker,
            dragonsbreath,
            twilightwhelp,
            demonwrath,
            impgangboss,
            gangup,
            darkironskulker,
            volcaniclumberer,
            druidoftheflame,
            firecatform,
            firehawkform,
            lavashock,
            fireguarddestroyer,
            quickshot,
            corerager,
            revenge,
            axeflinger,
            resurrect,
            dragonconsort,
            unchained,
            grimpatron,
            dragonkinsorcerer,
            dragonegg,
            blackwhelp,
            drakonidcrusher,
            volcanicdrake,
            hungrydragon,
            majordomoexecutus,
            //ragnarosthefirelord,
            dieinsect,
            dieinsects,
            emperorthaurissan,
            imperialfavor,
            rendblackhand,
            nefarian,
            tailswipe,
            chromaggus,
            blackwingtechnician,
            blackwingcorruptor,
            //######################################
            lesserheal,
            goldshirefootman,
            holynova,
            mindcontrol,
            holysmite,
            mindvision,
            powerwordshield,
            claw,
            healingtouch,
            moonfire,
            markofthewild,
            savageroar,
            swipe,
            wildgrowth,
            excessmana,
            shapeshift,
            polymorph,
            arcaneintellect,
            frostbolt,
            arcaneexplosion,
            frostnova,
            mirrorimage,
            fireball,
            flamestrike,
            waterelemental,
            fireblast,
            frostshock,
            windfury,
            ancestralhealing,
            fireelemental,
            rockbiterweapon,
            bloodlust,
            totemiccall,
            searingtotem,
            stoneclawtotem,
            wrathofairtotem,
            lifetap,
            shadowbolt,
            drainlife,
            hellfire,
            corruption,
            dreadinfernal,
            voidwalker,
            backstab,
            deadlypoison,
            sinisterstrike,
            assassinate,
            sprint,
            assassinsblade,
            wickedknife,
            daggermastery,
            huntersmark,
            blessingofmight,
            guardianofkings,
            holylight,
            lightsjustice,
            blessingofkings,
            consecration,
            hammerofwrath,
            truesilverchampion,
            reinforce,
            silverhandrecruit,
            armorup,
            charge,
            heroicstrike,
            fierywaraxe,
            execute,
            arcanitereaper,
            cleave,
            magmarager,
            oasissnapjaw,
            rivercrocolisk,
            frostwolfgrunt,
            raidleader,
            wolfrider,
            ironfurgrizzly,
            silverbackpatriarch,
            stormwindknight,
            ironforgerifleman,
            koboldgeomancer,
            gnomishinventor,
            stormpikecommando,
            archmage,
            lordofthearena,
            murlocraider,
            stonetuskboar,
            bloodfenraptor,
            bluegillwarrior,
            senjinshieldmasta,
            chillwindyeti,
            wargolem,
            bootybaybodyguard,
            elvenarcher,
            razorfenhunter,
            ogremagi,
            boulderfistogre,
            corehound,
            recklessrocketeer,
            stormwindchampion,
            frostwolfwarlord,
            ironbarkprotector,
            shadowwordpain,
            northshirecleric,
            divinespirit,
            starvingbuzzard,
            boar,
            sheep,
            steadyshot,
            darkscalehealer,
            houndmaster,
            timberwolf,
            tundrarhino,
            multishot,
            tracking,
            arcaneshot,
            mindblast,
            voodoodoctor,
            noviceengineer,
            shatteredsuncleric,
            dragonlingmechanic,
            mechanicaldragonling,
            acidicswampooze,
            warsongcommander,
            fanofknives,
            innervate,
            starfire,
            totemicmight,
            hex,
            arcanemissiles,
            shiv,
            mortalcoil,
            succubus,
            soulfire,
            humility,
            handofprotection,
            gurubashiberserker,
            whirlwind,
            murloctidehunter,
            murlocscout,
            grimscaleoracle,
            killcommand,
            flametonguetotem,
            sap,
            dalaranmage,
            windspeaker,
            nightblade,
            shieldblock,
            shadowworddeath,
            avatarofthecoin,
            thecoin,
            noooooooooooo,
            garroshhellscream,
            thrall,
            valeerasanguinar,
            utherlightbringer,
            rexxar,
            malfurionstormrage,
            guldan,
            jainaproudmoore,
            anduinwrynn,
            frog,
            sacrificialpact,
            vanish,
            healingtotem,
            korkronelite,
            animalcompanion,
            misha,
            leokk,
            huffer,
            skeleton,
            fencreeper,
            innerfire,
            blizzard,
            icelance,
            ancestralspirit,
            farsight,
            bloodimp,
            coldblood,
            rampage,
            earthenringfarseer,
            southseadeckhand,
            silverhandknight,
            squire,
            ravenholdtassassin,
            youngdragonhawk,
            injuredblademaster,
            abusivesergeant,
            ironbeakowl,
            spitefulsmith,
            venturecomercenary,
            wisp,
            bladeflurry,
            laughingsister,
            yseraawakens,
            emeralddrake,
            dream,
            nightmare,
            gladiatorslongbow,
            whelp,
            lightwarden,
            theblackknight,
            youngpriestess,
            biggamehunter,
            alarmobot,
            acolyteofpain,
            argentsquire,
            angrychicken,
            worgeninfiltrator,
            bloodmagethalnos,
            kingmukla,
            bananas,
            sylvanaswindrunner,
            junglepanther,
            scarletcrusader,
            thrallmarfarseer,
            silvermoonguardian,
            stranglethorntiger,
            lepergnome,
            sunwalker,
            windfuryharpy,
            twilightdrake,
            questingadventurer,
            ancientwatcher,
            darkirondwarf,
            spellbreaker,
            youthfulbrewmaster,
            coldlightoracle,
            manaaddict,
            ancientbrewmaster,
            sunfuryprotector,
            crazedalchemist,
            argentcommander,
            pintsizedsummoner,
            secretkeeper,
            madbomber,
            tinkmasteroverspark,
            mindcontroltech,
            arcanegolem,
            cabalshadowpriest,
            defenderofargus,
            gadgetzanauctioneer,
            loothoarder,
            abomination,
            lorewalkercho,
            demolisher,
            coldlightseer,
            mountaingiant,
            cairnebloodhoof,
            bainebloodhoof,
            leeroyjenkins,
            eviscerate,
            betrayal,
            conceal,
            noblesacrifice,
            defender,
            defiasringleader,
            defiasbandit,
            eyeforaneye,
            perditionsblade,
            si7agent,
            redemption,
            headcrack,
            shadowstep,
            preparation,
            wrath,
            markofnature,
            souloftheforest,
            treant,
            powerofthewild,
            summonapanther,
            leaderofthepack,
            panther,
            naturalize,
            direwolfalpha,
            nourish,
            druidoftheclaw,
            catform,
            bearform,
            keeperofthegrove,
            dispel,
            emperorcobra,
            ancientofwar,
            rooted,
            uproot,
            lightningbolt,
            lavaburst,
            dustdevil,
            earthshock,
            stormforgedaxe,
            feralspirit,
            barongeddon,
            earthelemental,
            forkedlightning,
            unboundelemental,
            lightningstorm,
            etherealarcanist,
            coneofcold,
            pyroblast,
            frostelemental,
            azuredrake,
            counterspell,
            icebarrier,
            mirrorentity,
            iceblock,
            ragnarosthefirelord,
            felguard,
            shadowflame,
            voidterror,
            siphonsoul,
            doomguard,
            twistingnether,
            pitlord,
            summoningportal,
            poweroverwhelming,
            sensedemons,
            worthlessimp,
            flameimp,
            baneofdoom,
            lordjaraxxus,
            bloodfury,
            silence,
            shadowmadness,
            lightspawn,
            thoughtsteal,
            lightwell,
            mindgames,
            shadowofnothing,
            divinefavor,
            prophetvelen,
            layonhands,
            blessedchampion,
            argentprotector,
            blessingofwisdom,
            holywrath,
            swordofjustice,
            repentance,
            aldorpeacekeeper,
            tirionfordring,
            ashbringer,
            avengingwrath,
            taurenwarrior,
            slam,
            battlerage,
            amaniberserker,
            mogushanwarden,
            arathiweaponsmith,
            battleaxe,
            armorsmith,
            shieldbearer,
            brawl,
            mortalstrike,
            upgrade,
            heavyaxe,
            shieldslam,
            gorehowl,
            ragingworgen,
            grommashhellscream,
            murlocwarleader,
            murloctidecaller,
            patientassassin,
            scavenginghyena,
            misdirection,
            savannahhighmane,
            hyena,
            eaglehornbow,
            explosiveshot,
            unleashthehounds,
            hound,
            kingkrush,
            flare,
            bestialwrath,
            snaketrap,
            snake,
            harvestgolem,
            natpagle,
            harrisonjones,
            archmageantonidas,
            nozdormu,
            alexstrasza,
            onyxia,
            malygos,
            facelessmanipulator,
            doomhammer,
            bite,
            forceofnature,
            ysera,
            cenarius,
            demigodsfavor,
            shandoslesson,
            manatidetotem,
            thebeast,
            savagery,
            priestessofelune,
            ancientmage,
            seagiant,
            bloodknight,
            auchenaisoulpriest,
            vaporize,
            cultmaster,
            demonfire,
            impmaster,
            imp,
            crueltaskmaster,
            frothingberserker,
            innerrage,
            sorcerersapprentice,
            snipe,
            explosivetrap,
            freezingtrap,
            kirintormage,
            edwinvancleef,
            illidanstormrage,
            flameofazzinoth,
            manawraith,
            deadlyshot,
            equality,
            moltengiant,
            circleofhealing,
            templeenforcer,
            holyfire,
            shadowform,
            mindspike,
            mindshatter,
            massdispel,
            finkleeinhorn,
            spiritwolf,
            squirrel,
            devilsaur,
            inferno,
            infernal,
            kidnapper,
            starfall,
            ancientoflore,
            ancientteachings,
            ancientsecrets,
            alakirthewindlord,
            manawyrm,
            masterofdisguise,
            hungrycrab,
            bloodsailraider,
            knifejuggler,
            wildpyromancer,
            doomsayer,
            dreadcorsair,
            faeriedragon,
            captaingreenskin,
            bloodsailcorsair,
            violetteacher,
            violetapprentice,
            southseacaptain,
            millhousemanastorm,
            deathwing,
            commandingshout,
            masterswordsmith,
            gruul,
            hogger,
            gnoll,
            stampedingkodo,
            damagedgolem,
            flesheatingghoul,
            spellbender,
            jasonchayes,
            ericdodds,
            bobfitch,
            stevengabriel,
            kyleharrison,
            dereksakamoto,
            zwick,
            benbrode,
            benthompson,
            michaelschweitzer,
            jaybaxter,
            rachelledavis,
            brianschwab,
            yongwoo,
            andybrock,
            hamiltonchu,
            robpardo,
            oldmurkeye,
            captainsparrot,
            riverpawgnoll,
            hoggersmash,
            massivegnoll,
            barreltoss,
            barrel,
            stomp,
            hiddengnome,
            muklasbigbrother,
            willofmukla,
            hemetnesingwary,
            crazedhunter,
            shotgunblast,
            flamesofazzinoth,
            nagamyrmidon,
            warglaiveofazzinoth,
            flameburst,
            dualwarglaives,
            pandarenscout,
            shadopanmonk,
            legacyoftheemperor,
            brewmaster,
            transcendence,
            crazymonkey,
            damage1,
            damage5,
            restore1,
            restore5,
            destroy,
            breakweapon,
            enableforattack,
            freeze,
            enchant,
            silencedebug,
            summonarandomsecret,
            bounce,
            discard,
            mill10,
            crash,
            snakeball,
            draw3cards,
            destroyallminions,
            molasses,
            damageallbut1,
            restoreallhealth,
            freecards,
            destroyallheroes,
            damagereflector,
            donothing,
            enableemotes,
            servercrash,
            revealhand,
            opponentconcede,
            opponentdisconnect,
            becomehogger,
            destroyheropower,
            handtodeck,
            mill30,
            handswapperminion,
            stealcard,
            forceaitouseheropower,
            destroydeck,
            durability,
            destroyallmana,
            destroyamanacrystal,
            makeimmune,
            grantmegawindfury,
            armor,
            weaponbuff,
            stats,
            silencedestroy,
            destroysecrets,
            aibuddyallcharge,
            aibuddydamageownhero5,
            aibuddydestroyminions,
            aibuddynodeckhand,
            aihelperbuddy,
            gelbinmekkatorque,
            homingchicken,
            repairbot,
            emboldener3000,
            poultryizer,
            chicken,
            elitetaurenchieftain,
            iammurloc,
            murloc,
            roguesdoit,
            powerofthehorde,
            zombiechow,
            hauntedcreeper,
            spectralspider,
            echoingooze,
            madscientist,
            shadeofnaxxramas,
            deathcharger,
            nerubianegg,
            nerubian,
            spectralknight,
            deathlord,
            maexxna,
            webspinner,
            sludgebelcher,
            slime,
            kelthuzad,
            stalagg,
            thaddius,
            feugen,
            wailingsoul,
            nerubarweblord,
            duplicate,
            poisonseeds,
            avenge,
            deathsbite,
            voidcaller,
            darkcultist,
            unstableghoul,
            reincarnate,
            anubarambusher,
            stoneskingargoyle,
            undertaker,
            dancingswords,
            loatheb,
            baronrivendare,
            patchwerk,
            hook,
            hatefulstrike,
            grobbulus,
            poisoncloud,
            falloutslime,
            mutatinginjection,
            gluth,
            decimate,
            jaws,
            enrage,
            polarityshift,
            supercharge,
            sapphiron,
            frostbreath,
            frozenchampion,
            purecold,
            frostblast,
            guardianoficecrown,
            chains,
            mrbigglesworth,
            anubrekhan,
            skitter,
            locustswarm,
            grandwidowfaerlina,
            rainoffire,
            worshipper,
            webwrap,
            necroticpoison,
            noththeplaguebringer,
            raisedead,
            plague,
            heigantheunclean,
            eruption,
            mindpocalypse,
            necroticaura,
            deathbloom,
            spore,
            sporeburst,
            instructorrazuvious,
            understudy,
            unbalancingstrike,
            massiveruneblade,
            mindcontrolcrystal,
            gothiktheharvester,
            harvest,
            unrelentingtrainee,
            spectraltrainee,
            unrelentingwarrior,
            spectralwarrior,
            unrelentingrider,
            spectralrider,
            ladyblaumeux,
            thanekorthazz,
            sirzeliek,
            runeblade,
            unholyshadow,
            markofthehorsemen,
            necroknight,
            skeletalsmith,
            flamecannon,
            snowchugger,
            unstableportal,
            goblinblastmage,
            echoofmedivh,
            mechwarper,
            flameleviathan,
            lightbomb,
            shadowbomber,
            velenschosen,
            shrinkmeister,
            lightofthenaaru,
            cogmaster,
            voljin,
            darkbomb,
            felreaver,
            callpet,
            mistressofpain,
            demonheart,
            felcannon,
            malganis,
            tinkerssharpswordoil,
            goblinautobarber,
            cogmasterswrench,
            oneeyedcheat,
            feigndeath,
            ironsensei,
            tradeprincegallywix,
            gallywixscoin,
            ancestorscall,
            anodizedrobocub,
            attackmode,
            tankmode,
            recycle,
            grovetender,
            giftofmana,
            giftofcards,
            treeoflife,
            mechbearcat,
            malorne,
            powermace,
            whirlingzapomatic,
            crackle,
            vitalitytotem,
            siltfinspiritwalker,
            darkwispers,
            neptulon,
            glaivezooka,
            spidertank,
            implosion,
            kingofbeasts,
            sabotage,
            metaltoothleaper,
            gahzrilla,
            bouncingblade,
            warbot,
            crush,
            shieldmaiden,
            ogrewarmaul,
            screwjankclunker,
            ironjuggernaut,
            burrowingmine,
            sealoflight,
            shieldedminibot,
            coghammer,
            quartermaster,
            musterforbattle,
            cobaltguardian,
            bolvarfordragon,
            puddlestomper,
            ogrebrute,
            dunemaulshaman,
            stonesplintertrogg,
            burlyrockjawtrogg,
            antiquehealbot,
            saltydog,
            losttallstrider,
            shadowboxer,
            cobrashot,
            kezanmystic,
            shipscannon,
            explosivesheep,
            animagolem,
            mechanicalyeti,
            forcetankmax,
            druidofthefang,
            gilblinstalker,
            clockworkgnome,
            upgradedrepairbot,
            flyingmachine,
            annoyotron,
            siegeengine,
            steamwheedlesniper,
            ogreninja,
            illuminator,
            madderbomber,
            arcanenullifierx21,
            gnomishexperimenter,
            targetdummy,
            jeeves,
            goblinsapper,
            pilotedshredder,
            lilexorcist,
            gnomereganinfantry,
            bomblobber,
            floatingwatcher,
            scarletpurifier,
            tinkertowntechnician,
            micromachine,
            hobgoblin,
            pilotedskygolem,
            junkbot,
            enhanceomechano,
            recombobulator,
            minimage,
            drboom,
            boombot,
            mimironshead,
            v07tr0n,
            mogortheogre,
            foereaper4000,
            sneedsoldshredder,
            toshley,
            mekgineerthermaplugg,
            gazlowe,
            troggzortheearthinator,
            blingtron3000,
            clockworkgiant,
            weespellstopper,
            sootspewer,
            armorplating,
            timerewinder,
            rustyhorn,
            finickycloakfield,
            emergencycoolant,
            reversingswitch,
            whirlingblades,
            placeholdercard,
        }

        public cardName cardNamestringToEnum(string s)
        {
            //tgt:
            if (s == "flamelance") return CardDB.cardName.flamelance;
            if (s == "effigy") return CardDB.cardName.effigy;
            if (s == "fallenhero") return CardDB.cardName.fallenhero;
            if (s == "arcaneblast") return CardDB.cardName.arcaneblast;
            if (s == "polymorphboar") return CardDB.cardName.polymorphboar;
            if (s == "dalaranaspirant") return CardDB.cardName.dalaranaspirant;
            if (s == "spellslinger") return CardDB.cardName.spellslinger;
            if (s == "coldarradrake") return CardDB.cardName.coldarradrake;
            if (s == "rhonin") return CardDB.cardName.rhonin;
            if (s == "ramwrangler") return CardDB.cardName.ramwrangler;
            if (s == "holychampion") return CardDB.cardName.holychampion;
            if (s == "spawnofshadows") return CardDB.cardName.spawnofshadows;
            if (s == "powerwordglory") return CardDB.cardName.powerwordglory;
            if (s == "shadowfiend") return CardDB.cardName.shadowfiend;
            if (s == "convert") return CardDB.cardName.convert;
            if (s == "confuse") return CardDB.cardName.confuse;
            if (s == "twilightguardian") return CardDB.cardName.twilightguardian;
            if (s == "confessorpaletress") return CardDB.cardName.confessorpaletress;
            if (s == "dreadsteed") return CardDB.cardName.dreadsteed;
            if (s == "fearsomedoomguard") return CardDB.cardName.fearsomedoomguard;
            if (s == "tinyknightofevil") return CardDB.cardName.tinyknightofevil;
            if (s == "fistofjaraxxus") return CardDB.cardName.fistofjaraxxus;
            if (s == "voidcrusher") return CardDB.cardName.voidcrusher;
            if (s == "demonfuse") return CardDB.cardName.demonfuse;
            if (s == "darkbargain") return CardDB.cardName.darkbargain;
            if (s == "wrathguard") return CardDB.cardName.wrathguard;
            if (s == "wilfredfizzlebang") return CardDB.cardName.wilfredfizzlebang;
            if (s == "shadopanrider") return CardDB.cardName.shadopanrider;
            if (s == "buccaneer") return CardDB.cardName.buccaneer;
            if (s == "undercityvaliant") return CardDB.cardName.undercityvaliant;
            if (s == "cutpurse") return CardDB.cardName.cutpurse;
            if (s == "shadydealer") return CardDB.cardName.shadydealer;
            if (s == "burgle") return CardDB.cardName.burgle;
            if (s == "poisonedblade") return CardDB.cardName.poisonedblade;
            if (s == "beneaththegrounds") return CardDB.cardName.beneaththegrounds;
            if (s == "ambush") return CardDB.cardName.ambush;
            if (s == "anubarak") return CardDB.cardName.anubarak;
            if (s == "nerubian") return CardDB.cardName.nerubian;
            if (s == "livingroots") return CardDB.cardName.livingroots;
            if (s == "livingroots") return CardDB.cardName.livingroots;
            if (s == "livingroots") return CardDB.cardName.livingroots;
            if (s == "sapling") return CardDB.cardName.sapling;
            if (s == "darnassusaspirant") return CardDB.cardName.darnassusaspirant;
            if (s == "savagecombatant") return CardDB.cardName.savagecombatant;
            if (s == "wildwalker") return CardDB.cardName.wildwalker;
            if (s == "knightofthewild") return CardDB.cardName.knightofthewild;
            if (s == "druidofthesaber") return CardDB.cardName.druidofthesaber;
            if (s == "lionform") return CardDB.cardName.lionform;
            if (s == "pantherform") return CardDB.cardName.pantherform;
            if (s == "sabertoothlion") return CardDB.cardName.sabertoothlion;
            if (s == "sabertoothpanther") return CardDB.cardName.sabertoothpanther;
            if (s == "astralcommunion") return CardDB.cardName.astralcommunion;
            if (s == "mulch") return CardDB.cardName.mulch;
            if (s == "aviana") return CardDB.cardName.aviana;
            if (s == "tuskarrtotemic") return CardDB.cardName.tuskarrtotemic;
            if (s == "draeneitotemcarver") return CardDB.cardName.draeneitotemcarver;
            if (s == "healingwave") return CardDB.cardName.healingwave;
            if (s == "thunderbluffvaliant") return CardDB.cardName.thunderbluffvaliant;
            if (s == "chargedhammer") return CardDB.cardName.chargedhammer;
            if (s == "lightningjolt") return CardDB.cardName.lightningjolt;
            if (s == "elementaldestruction") return CardDB.cardName.elementaldestruction;
            if (s == "totemgolem") return CardDB.cardName.totemgolem;
            if (s == "ancestralknowledge") return CardDB.cardName.ancestralknowledge;
            if (s == "themistcaller") return CardDB.cardName.themistcaller;
            if (s == "flashheal") return CardDB.cardName.flashheal;
            if (s == "powershot") return CardDB.cardName.powershot;
            if (s == "stablemaster") return CardDB.cardName.stablemaster;
            if (s == "kingselekk") return CardDB.cardName.kingselekk;
            if (s == "bravearcher") return CardDB.cardName.bravearcher;
            if (s == "beartrap") return CardDB.cardName.beartrap;
            if (s == "lockandload") return CardDB.cardName.lockandload;
            if (s == "ballofspiders") return CardDB.cardName.ballofspiders;
            if (s == "acidmaw") return CardDB.cardName.acidmaw;
            if (s == "dreadscale") return CardDB.cardName.dreadscale;
            if (s == "bash") return CardDB.cardName.bash;
            if (s == "kingsdefender") return CardDB.cardName.kingsdefender;
            if (s == "orgrimmaraspirant") return CardDB.cardName.orgrimmaraspirant;
            if (s == "magnatauralpha") return CardDB.cardName.magnatauralpha;
            if (s == "bolster") return CardDB.cardName.bolster;
            if (s == "sparringpartner") return CardDB.cardName.sparringpartner;
            if (s == "skycapnkragg") return CardDB.cardName.skycapnkragg;
            if (s == "alexstraszaschampion") return CardDB.cardName.alexstraszaschampion;
            if (s == "varianwrynn") return CardDB.cardName.varianwrynn;
            if (s == "competitivespirit") return CardDB.cardName.competitivespirit;
            if (s == "sealofchampions") return CardDB.cardName.sealofchampions;
            if (s == "warhorsetrainer") return CardDB.cardName.warhorsetrainer;
            if (s == "murlocknight") return CardDB.cardName.murlocknight;
            if (s == "argentlance") return CardDB.cardName.argentlance;
            if (s == "enterthecoliseum") return CardDB.cardName.enterthecoliseum;
            if (s == "mysteriouschallenger") return CardDB.cardName.mysteriouschallenger;
            if (s == "garrisoncommander") return CardDB.cardName.garrisoncommander;
            if (s == "eadricthepure") return CardDB.cardName.eadricthepure;
            if (s == "lowlysquire") return CardDB.cardName.lowlysquire;
            if (s == "dragonhawkrider") return CardDB.cardName.dragonhawkrider;
            if (s == "lancecarrier") return CardDB.cardName.lancecarrier;
            if (s == "maidenofthelake") return CardDB.cardName.maidenofthelake;
            if (s == "saboteur") return CardDB.cardName.saboteur;
            if (s == "argenthorserider") return CardDB.cardName.argenthorserider;
            if (s == "mogorschampion") return CardDB.cardName.mogorschampion;
            if (s == "boneguardlieutenant") return CardDB.cardName.boneguardlieutenant;
            if (s == "muklaschampion") return CardDB.cardName.muklaschampion;
            if (s == "tournamentmedic") return CardDB.cardName.tournamentmedic;
            if (s == "icerager") return CardDB.cardName.icerager;
            if (s == "frigidsnobold") return CardDB.cardName.frigidsnobold;
            if (s == "flamejuggler") return CardDB.cardName.flamejuggler;
            if (s == "silentknight") return CardDB.cardName.silentknight;
            if (s == "clockworkknight") return CardDB.cardName.clockworkknight;
            if (s == "tournamentattendee") return CardDB.cardName.tournamentattendee;
            if (s == "sideshowspelleater") return CardDB.cardName.sideshowspelleater;
            if (s == "kodorider") return CardDB.cardName.kodorider;
            if (s == "warkodo") return CardDB.cardName.warkodo;
            if (s == "silverhandregent") return CardDB.cardName.silverhandregent;
            if (s == "pitfighter") return CardDB.cardName.pitfighter;
            if (s == "capturedjormungar") return CardDB.cardName.capturedjormungar;
            if (s == "northseakraken") return CardDB.cardName.northseakraken;
            if (s == "tuskarrjouster") return CardDB.cardName.tuskarrjouster;
            if (s == "injuredkvaldir") return CardDB.cardName.injuredkvaldir;
            if (s == "lightschampion") return CardDB.cardName.lightschampion;
            if (s == "armoredwarhorse") return CardDB.cardName.armoredwarhorse;
            if (s == "argentwatchman") return CardDB.cardName.argentwatchman;
            if (s == "coliseummanager") return CardDB.cardName.coliseummanager;
            if (s == "refreshmentvendor") return CardDB.cardName.refreshmentvendor;
            if (s == "masterjouster") return CardDB.cardName.masterjouster;
            if (s == "recruiter") return CardDB.cardName.recruiter;
            if (s == "evilheckler") return CardDB.cardName.evilheckler;
            if (s == "fencingcoach") return CardDB.cardName.fencingcoach;
            if (s == "wyrmrestagent") return CardDB.cardName.wyrmrestagent;
            if (s == "masterofceremonies") return CardDB.cardName.masterofceremonies;
            if (s == "grandcrusader") return CardDB.cardName.grandcrusader;
            if (s == "kvaldirraider") return CardDB.cardName.kvaldirraider;
            if (s == "frostgiant") return CardDB.cardName.frostgiant;
            if (s == "crowdfavorite") return CardDB.cardName.crowdfavorite;
            if (s == "gormoktheimpaler") return CardDB.cardName.gormoktheimpaler;
            if (s == "chillmaw") return CardDB.cardName.chillmaw;
            if (s == "bolframshield") return CardDB.cardName.bolframshield;
            if (s == "icehowl") return CardDB.cardName.icehowl;
            if (s == "nexuschampionsaraad") return CardDB.cardName.nexuschampionsaraad;
            if (s == "theskeletonknight") return CardDB.cardName.theskeletonknight;
            if (s == "fjolalightbane") return CardDB.cardName.fjolalightbane;
            if (s == "seareaver") return CardDB.cardName.seareaver;
            if (s == "eydisdarkbane") return CardDB.cardName.eydisdarkbane;
            if (s == "justicartrueheart") return CardDB.cardName.justicartrueheart;
            if (s == "direshapeshift") return CardDB.cardName.direshapeshift;
            if (s == "ballistashot") return CardDB.cardName.ballistashot;
            if (s == "fireblastrank2") return CardDB.cardName.fireblastrank2;
            if (s == "thesilverhand") return CardDB.cardName.thesilverhand;
            if (s == "heal") return CardDB.cardName.heal;
            if (s == "poisoneddaggers") return CardDB.cardName.poisoneddaggers;
            if (s == "poisoneddagger") return CardDB.cardName.poisoneddagger;
            if (s == "totemicslam") return CardDB.cardName.totemicslam;
            if (s == "healingtotem") return CardDB.cardName.healingtotem;
            if (s == "searingtotem") return CardDB.cardName.searingtotem;
            if (s == "stoneclawtotem") return CardDB.cardName.stoneclawtotem;
            if (s == "wrathofairtotem") return CardDB.cardName.wrathofairtotem;
            if (s == "soultap") return CardDB.cardName.soultap;
            if (s == "tankup") return CardDB.cardName.tankup;
            if (s == "gadgetzanjouster") return CardDB.cardName.gadgetzanjouster;


            //new heros:
            if (s == "magnibronzebeard") return CardDB.cardName.garroshhellscream;
            if (s == "alleriawindrunner") return CardDB.cardName.rexxar;
            if (s == "medivh") return CardDB.cardName.jainaproudmoore;

            //brock:
            if (s == "solemnvigil") return CardDB.cardName.solemnvigil;
            if (s == "flamewaker") return CardDB.cardName.flamewaker;
            if (s == "dragonsbreath") return CardDB.cardName.dragonsbreath;
            if (s == "twilightwhelp") return CardDB.cardName.twilightwhelp;
            if (s == "demonwrath") return CardDB.cardName.demonwrath;
            if (s == "impgangboss") return CardDB.cardName.impgangboss;
            if (s == "gangup") return CardDB.cardName.gangup;
            if (s == "darkironskulker") return CardDB.cardName.darkironskulker;
            if (s == "volcaniclumberer") return CardDB.cardName.volcaniclumberer;
            if (s == "druidoftheflame") return CardDB.cardName.druidoftheflame;
            if (s == "firecatform") return CardDB.cardName.firecatform;
            if (s == "firehawkform") return CardDB.cardName.firehawkform;
            if (s == "lavashock") return CardDB.cardName.lavashock;
            if (s == "fireguarddestroyer") return CardDB.cardName.fireguarddestroyer;
            if (s == "quickshot") return CardDB.cardName.quickshot;
            if (s == "corerager") return CardDB.cardName.corerager;
            if (s == "revenge") return CardDB.cardName.revenge;
            if (s == "axeflinger") return CardDB.cardName.axeflinger;
            if (s == "resurrect") return CardDB.cardName.resurrect;
            if (s == "dragonconsort") return CardDB.cardName.dragonconsort;
            if (s == "unchained") return CardDB.cardName.unchained;
            if (s == "grimpatron") return CardDB.cardName.grimpatron;
            if (s == "dragonkinsorcerer") return CardDB.cardName.dragonkinsorcerer;
            if (s == "dragonegg") return CardDB.cardName.dragonegg;
            if (s == "blackwhelp") return CardDB.cardName.blackwhelp;
            if (s == "drakonidcrusher") return CardDB.cardName.drakonidcrusher;
            if (s == "volcanicdrake") return CardDB.cardName.volcanicdrake;
            if (s == "hungrydragon") return CardDB.cardName.hungrydragon;
            if (s == "majordomoexecutus") return CardDB.cardName.majordomoexecutus;
            if (s == "dieinsect") return CardDB.cardName.dieinsect;
            if (s == "dieinsects") return CardDB.cardName.dieinsects;
            if (s == "emperorthaurissan") return CardDB.cardName.emperorthaurissan;
            if (s == "imperialfavor") return CardDB.cardName.imperialfavor;
            if (s == "rendblackhand") return CardDB.cardName.rendblackhand;
            if (s == "nefarian") return CardDB.cardName.nefarian;
            if (s == "tailswipe") return CardDB.cardName.tailswipe;
            if (s == "chromaggus") return CardDB.cardName.chromaggus;
            if (s == "blackwingtechnician") return CardDB.cardName.blackwingtechnician;
            if (s == "blackwingcorruptor") return CardDB.cardName.blackwingcorruptor;

            if (s == "unknown") return CardDB.cardName.unknown;
            if (s == "lesserheal") return CardDB.cardName.lesserheal;
            if (s == "goldshirefootman") return CardDB.cardName.goldshirefootman;
            if (s == "holynova") return CardDB.cardName.holynova;
            if (s == "mindcontrol") return CardDB.cardName.mindcontrol;
            if (s == "holysmite") return CardDB.cardName.holysmite;
            if (s == "mindvision") return CardDB.cardName.mindvision;
            if (s == "powerwordshield") return CardDB.cardName.powerwordshield;
            if (s == "claw") return CardDB.cardName.claw;
            if (s == "healingtouch") return CardDB.cardName.healingtouch;
            if (s == "moonfire") return CardDB.cardName.moonfire;
            if (s == "markofthewild") return CardDB.cardName.markofthewild;
            if (s == "savageroar") return CardDB.cardName.savageroar;
            if (s == "swipe") return CardDB.cardName.swipe;
            if (s == "wildgrowth") return CardDB.cardName.wildgrowth;
            if (s == "excessmana") return CardDB.cardName.excessmana;
            if (s == "shapeshift") return CardDB.cardName.shapeshift;
            if (s == "polymorph") return CardDB.cardName.polymorph;
            if (s == "arcaneintellect") return CardDB.cardName.arcaneintellect;
            if (s == "frostbolt") return CardDB.cardName.frostbolt;
            if (s == "arcaneexplosion") return CardDB.cardName.arcaneexplosion;
            if (s == "frostnova") return CardDB.cardName.frostnova;
            if (s == "mirrorimage") return CardDB.cardName.mirrorimage;
            if (s == "fireball") return CardDB.cardName.fireball;
            if (s == "flamestrike") return CardDB.cardName.flamestrike;
            if (s == "waterelemental") return CardDB.cardName.waterelemental;
            if (s == "fireblast") return CardDB.cardName.fireblast;
            if (s == "frostshock") return CardDB.cardName.frostshock;
            if (s == "windfury") return CardDB.cardName.windfury;
            if (s == "ancestralhealing") return CardDB.cardName.ancestralhealing;
            if (s == "fireelemental") return CardDB.cardName.fireelemental;
            if (s == "rockbiterweapon") return CardDB.cardName.rockbiterweapon;
            if (s == "bloodlust") return CardDB.cardName.bloodlust;
            if (s == "totemiccall") return CardDB.cardName.totemiccall;
            if (s == "searingtotem") return CardDB.cardName.searingtotem;
            if (s == "stoneclawtotem") return CardDB.cardName.stoneclawtotem;
            if (s == "wrathofairtotem") return CardDB.cardName.wrathofairtotem;
            if (s == "lifetap") return CardDB.cardName.lifetap;
            if (s == "shadowbolt") return CardDB.cardName.shadowbolt;
            if (s == "drainlife") return CardDB.cardName.drainlife;
            if (s == "hellfire") return CardDB.cardName.hellfire;
            if (s == "corruption") return CardDB.cardName.corruption;
            if (s == "dreadinfernal") return CardDB.cardName.dreadinfernal;
            if (s == "voidwalker") return CardDB.cardName.voidwalker;
            if (s == "backstab") return CardDB.cardName.backstab;
            if (s == "deadlypoison") return CardDB.cardName.deadlypoison;
            if (s == "sinisterstrike") return CardDB.cardName.sinisterstrike;
            if (s == "assassinate") return CardDB.cardName.assassinate;
            if (s == "sprint") return CardDB.cardName.sprint;
            if (s == "assassinsblade") return CardDB.cardName.assassinsblade;
            if (s == "wickedknife") return CardDB.cardName.wickedknife;
            if (s == "daggermastery") return CardDB.cardName.daggermastery;
            if (s == "huntersmark") return CardDB.cardName.huntersmark;
            if (s == "blessingofmight") return CardDB.cardName.blessingofmight;
            if (s == "guardianofkings") return CardDB.cardName.guardianofkings;
            if (s == "holylight") return CardDB.cardName.holylight;
            if (s == "lightsjustice") return CardDB.cardName.lightsjustice;
            if (s == "blessingofkings") return CardDB.cardName.blessingofkings;
            if (s == "consecration") return CardDB.cardName.consecration;
            if (s == "hammerofwrath") return CardDB.cardName.hammerofwrath;
            if (s == "truesilverchampion") return CardDB.cardName.truesilverchampion;
            if (s == "reinforce") return CardDB.cardName.reinforce;
            if (s == "silverhandrecruit") return CardDB.cardName.silverhandrecruit;
            if (s == "armorup") return CardDB.cardName.armorup;
            if (s == "charge") return CardDB.cardName.charge;
            if (s == "heroicstrike") return CardDB.cardName.heroicstrike;
            if (s == "fierywaraxe") return CardDB.cardName.fierywaraxe;
            if (s == "execute") return CardDB.cardName.execute;
            if (s == "arcanitereaper") return CardDB.cardName.arcanitereaper;
            if (s == "cleave") return CardDB.cardName.cleave;
            if (s == "magmarager") return CardDB.cardName.magmarager;
            if (s == "oasissnapjaw") return CardDB.cardName.oasissnapjaw;
            if (s == "rivercrocolisk") return CardDB.cardName.rivercrocolisk;
            if (s == "frostwolfgrunt") return CardDB.cardName.frostwolfgrunt;
            if (s == "raidleader") return CardDB.cardName.raidleader;
            if (s == "wolfrider") return CardDB.cardName.wolfrider;
            if (s == "ironfurgrizzly") return CardDB.cardName.ironfurgrizzly;
            if (s == "silverbackpatriarch") return CardDB.cardName.silverbackpatriarch;
            if (s == "stormwindknight") return CardDB.cardName.stormwindknight;
            if (s == "ironforgerifleman") return CardDB.cardName.ironforgerifleman;
            if (s == "koboldgeomancer") return CardDB.cardName.koboldgeomancer;
            if (s == "gnomishinventor") return CardDB.cardName.gnomishinventor;
            if (s == "stormpikecommando") return CardDB.cardName.stormpikecommando;
            if (s == "archmage") return CardDB.cardName.archmage;
            if (s == "lordofthearena") return CardDB.cardName.lordofthearena;
            if (s == "murlocraider") return CardDB.cardName.murlocraider;
            if (s == "stonetuskboar") return CardDB.cardName.stonetuskboar;
            if (s == "bloodfenraptor") return CardDB.cardName.bloodfenraptor;
            if (s == "bluegillwarrior") return CardDB.cardName.bluegillwarrior;
            if (s == "senjinshieldmasta") return CardDB.cardName.senjinshieldmasta;
            if (s == "chillwindyeti") return CardDB.cardName.chillwindyeti;
            if (s == "wargolem") return CardDB.cardName.wargolem;
            if (s == "bootybaybodyguard") return CardDB.cardName.bootybaybodyguard;
            if (s == "elvenarcher") return CardDB.cardName.elvenarcher;
            if (s == "razorfenhunter") return CardDB.cardName.razorfenhunter;
            if (s == "ogremagi") return CardDB.cardName.ogremagi;
            if (s == "boulderfistogre") return CardDB.cardName.boulderfistogre;
            if (s == "corehound") return CardDB.cardName.corehound;
            if (s == "recklessrocketeer") return CardDB.cardName.recklessrocketeer;
            if (s == "stormwindchampion") return CardDB.cardName.stormwindchampion;
            if (s == "frostwolfwarlord") return CardDB.cardName.frostwolfwarlord;
            if (s == "ironbarkprotector") return CardDB.cardName.ironbarkprotector;
            if (s == "shadowwordpain") return CardDB.cardName.shadowwordpain;
            if (s == "northshirecleric") return CardDB.cardName.northshirecleric;
            if (s == "divinespirit") return CardDB.cardName.divinespirit;
            if (s == "starvingbuzzard") return CardDB.cardName.starvingbuzzard;
            if (s == "boar") return CardDB.cardName.boar;
            if (s == "sheep") return CardDB.cardName.sheep;
            if (s == "steadyshot") return CardDB.cardName.steadyshot;
            if (s == "darkscalehealer") return CardDB.cardName.darkscalehealer;
            if (s == "houndmaster") return CardDB.cardName.houndmaster;
            if (s == "timberwolf") return CardDB.cardName.timberwolf;
            if (s == "tundrarhino") return CardDB.cardName.tundrarhino;
            if (s == "multishot") return CardDB.cardName.multishot;
            if (s == "tracking") return CardDB.cardName.tracking;
            if (s == "arcaneshot") return CardDB.cardName.arcaneshot;
            if (s == "mindblast") return CardDB.cardName.mindblast;
            if (s == "voodoodoctor") return CardDB.cardName.voodoodoctor;
            if (s == "noviceengineer") return CardDB.cardName.noviceengineer;
            if (s == "shatteredsuncleric") return CardDB.cardName.shatteredsuncleric;
            if (s == "dragonlingmechanic") return CardDB.cardName.dragonlingmechanic;
            if (s == "mechanicaldragonling") return CardDB.cardName.mechanicaldragonling;
            if (s == "acidicswampooze") return CardDB.cardName.acidicswampooze;
            if (s == "warsongcommander") return CardDB.cardName.warsongcommander;
            if (s == "fanofknives") return CardDB.cardName.fanofknives;
            if (s == "innervate") return CardDB.cardName.innervate;
            if (s == "starfire") return CardDB.cardName.starfire;
            if (s == "totemicmight") return CardDB.cardName.totemicmight;
            if (s == "hex") return CardDB.cardName.hex;
            if (s == "arcanemissiles") return CardDB.cardName.arcanemissiles;
            if (s == "shiv") return CardDB.cardName.shiv;
            if (s == "mortalcoil") return CardDB.cardName.mortalcoil;
            if (s == "succubus") return CardDB.cardName.succubus;
            if (s == "soulfire") return CardDB.cardName.soulfire;
            if (s == "humility") return CardDB.cardName.humility;
            if (s == "handofprotection") return CardDB.cardName.handofprotection;
            if (s == "gurubashiberserker") return CardDB.cardName.gurubashiberserker;
            if (s == "whirlwind") return CardDB.cardName.whirlwind;
            if (s == "murloctidehunter") return CardDB.cardName.murloctidehunter;
            if (s == "murlocscout") return CardDB.cardName.murlocscout;
            if (s == "grimscaleoracle") return CardDB.cardName.grimscaleoracle;
            if (s == "killcommand") return CardDB.cardName.killcommand;
            if (s == "flametonguetotem") return CardDB.cardName.flametonguetotem;
            if (s == "sap") return CardDB.cardName.sap;
            if (s == "dalaranmage") return CardDB.cardName.dalaranmage;
            if (s == "windspeaker") return CardDB.cardName.windspeaker;
            if (s == "nightblade") return CardDB.cardName.nightblade;
            if (s == "shieldblock") return CardDB.cardName.shieldblock;
            if (s == "shadowworddeath") return CardDB.cardName.shadowworddeath;
            if (s == "avatarofthecoin") return CardDB.cardName.avatarofthecoin;
            if (s == "thecoin") return CardDB.cardName.thecoin;
            if (s == "noooooooooooo") return CardDB.cardName.noooooooooooo;
            if (s == "garroshhellscream") return CardDB.cardName.garroshhellscream;
            if (s == "thrall") return CardDB.cardName.thrall;
            if (s == "valeerasanguinar") return CardDB.cardName.valeerasanguinar;
            if (s == "utherlightbringer") return CardDB.cardName.utherlightbringer;
            if (s == "rexxar") return CardDB.cardName.rexxar;
            if (s == "malfurionstormrage") return CardDB.cardName.malfurionstormrage;
            if (s == "guldan") return CardDB.cardName.guldan;
            if (s == "jainaproudmoore") return CardDB.cardName.jainaproudmoore;
            if (s == "anduinwrynn") return CardDB.cardName.anduinwrynn;
            if (s == "frog") return CardDB.cardName.frog;
            if (s == "sacrificialpact") return CardDB.cardName.sacrificialpact;
            if (s == "vanish") return CardDB.cardName.vanish;
            if (s == "healingtotem") return CardDB.cardName.healingtotem;
            if (s == "korkronelite") return CardDB.cardName.korkronelite;
            if (s == "animalcompanion") return CardDB.cardName.animalcompanion;
            if (s == "misha") return CardDB.cardName.misha;
            if (s == "leokk") return CardDB.cardName.leokk;
            if (s == "huffer") return CardDB.cardName.huffer;
            if (s == "skeleton") return CardDB.cardName.skeleton;
            if (s == "fencreeper") return CardDB.cardName.fencreeper;
            if (s == "innerfire") return CardDB.cardName.innerfire;
            if (s == "blizzard") return CardDB.cardName.blizzard;
            if (s == "icelance") return CardDB.cardName.icelance;
            if (s == "ancestralspirit") return CardDB.cardName.ancestralspirit;
            if (s == "farsight") return CardDB.cardName.farsight;
            if (s == "bloodimp") return CardDB.cardName.bloodimp;
            if (s == "coldblood") return CardDB.cardName.coldblood;
            if (s == "rampage") return CardDB.cardName.rampage;
            if (s == "earthenringfarseer") return CardDB.cardName.earthenringfarseer;
            if (s == "southseadeckhand") return CardDB.cardName.southseadeckhand;
            if (s == "silverhandknight") return CardDB.cardName.silverhandknight;
            if (s == "squire") return CardDB.cardName.squire;
            if (s == "ravenholdtassassin") return CardDB.cardName.ravenholdtassassin;
            if (s == "youngdragonhawk") return CardDB.cardName.youngdragonhawk;
            if (s == "injuredblademaster") return CardDB.cardName.injuredblademaster;
            if (s == "abusivesergeant") return CardDB.cardName.abusivesergeant;
            if (s == "ironbeakowl") return CardDB.cardName.ironbeakowl;
            if (s == "spitefulsmith") return CardDB.cardName.spitefulsmith;
            if (s == "venturecomercenary") return CardDB.cardName.venturecomercenary;
            if (s == "wisp") return CardDB.cardName.wisp;
            if (s == "bladeflurry") return CardDB.cardName.bladeflurry;
            if (s == "laughingsister") return CardDB.cardName.laughingsister;
            if (s == "yseraawakens") return CardDB.cardName.yseraawakens;
            if (s == "emeralddrake") return CardDB.cardName.emeralddrake;
            if (s == "dream") return CardDB.cardName.dream;
            if (s == "nightmare") return CardDB.cardName.nightmare;
            if (s == "gladiatorslongbow") return CardDB.cardName.gladiatorslongbow;
            if (s == "whelp") return CardDB.cardName.whelp;
            if (s == "lightwarden") return CardDB.cardName.lightwarden;
            if (s == "theblackknight") return CardDB.cardName.theblackknight;
            if (s == "youngpriestess") return CardDB.cardName.youngpriestess;
            if (s == "biggamehunter") return CardDB.cardName.biggamehunter;
            if (s == "alarmobot") return CardDB.cardName.alarmobot;
            if (s == "acolyteofpain") return CardDB.cardName.acolyteofpain;
            if (s == "argentsquire") return CardDB.cardName.argentsquire;
            if (s == "angrychicken") return CardDB.cardName.angrychicken;
            if (s == "worgeninfiltrator") return CardDB.cardName.worgeninfiltrator;
            if (s == "bloodmagethalnos") return CardDB.cardName.bloodmagethalnos;
            if (s == "kingmukla") return CardDB.cardName.kingmukla;
            if (s == "bananas") return CardDB.cardName.bananas;
            if (s == "sylvanaswindrunner") return CardDB.cardName.sylvanaswindrunner;
            if (s == "junglepanther") return CardDB.cardName.junglepanther;
            if (s == "scarletcrusader") return CardDB.cardName.scarletcrusader;
            if (s == "thrallmarfarseer") return CardDB.cardName.thrallmarfarseer;
            if (s == "silvermoonguardian") return CardDB.cardName.silvermoonguardian;
            if (s == "stranglethorntiger") return CardDB.cardName.stranglethorntiger;
            if (s == "lepergnome") return CardDB.cardName.lepergnome;
            if (s == "sunwalker") return CardDB.cardName.sunwalker;
            if (s == "windfuryharpy") return CardDB.cardName.windfuryharpy;
            if (s == "twilightdrake") return CardDB.cardName.twilightdrake;
            if (s == "questingadventurer") return CardDB.cardName.questingadventurer;
            if (s == "ancientwatcher") return CardDB.cardName.ancientwatcher;
            if (s == "darkirondwarf") return CardDB.cardName.darkirondwarf;
            if (s == "spellbreaker") return CardDB.cardName.spellbreaker;
            if (s == "youthfulbrewmaster") return CardDB.cardName.youthfulbrewmaster;
            if (s == "coldlightoracle") return CardDB.cardName.coldlightoracle;
            if (s == "manaaddict") return CardDB.cardName.manaaddict;
            if (s == "ancientbrewmaster") return CardDB.cardName.ancientbrewmaster;
            if (s == "sunfuryprotector") return CardDB.cardName.sunfuryprotector;
            if (s == "crazedalchemist") return CardDB.cardName.crazedalchemist;
            if (s == "argentcommander") return CardDB.cardName.argentcommander;
            if (s == "pintsizedsummoner") return CardDB.cardName.pintsizedsummoner;
            if (s == "secretkeeper") return CardDB.cardName.secretkeeper;
            if (s == "madbomber") return CardDB.cardName.madbomber;
            if (s == "tinkmasteroverspark") return CardDB.cardName.tinkmasteroverspark;
            if (s == "mindcontroltech") return CardDB.cardName.mindcontroltech;
            if (s == "arcanegolem") return CardDB.cardName.arcanegolem;
            if (s == "cabalshadowpriest") return CardDB.cardName.cabalshadowpriest;
            if (s == "defenderofargus") return CardDB.cardName.defenderofargus;
            if (s == "gadgetzanauctioneer") return CardDB.cardName.gadgetzanauctioneer;
            if (s == "loothoarder") return CardDB.cardName.loothoarder;
            if (s == "abomination") return CardDB.cardName.abomination;
            if (s == "lorewalkercho") return CardDB.cardName.lorewalkercho;
            if (s == "demolisher") return CardDB.cardName.demolisher;
            if (s == "coldlightseer") return CardDB.cardName.coldlightseer;
            if (s == "mountaingiant") return CardDB.cardName.mountaingiant;
            if (s == "cairnebloodhoof") return CardDB.cardName.cairnebloodhoof;
            if (s == "bainebloodhoof") return CardDB.cardName.bainebloodhoof;
            if (s == "leeroyjenkins") return CardDB.cardName.leeroyjenkins;
            if (s == "eviscerate") return CardDB.cardName.eviscerate;
            if (s == "betrayal") return CardDB.cardName.betrayal;
            if (s == "conceal") return CardDB.cardName.conceal;
            if (s == "noblesacrifice") return CardDB.cardName.noblesacrifice;
            if (s == "defender") return CardDB.cardName.defender;
            if (s == "defiasringleader") return CardDB.cardName.defiasringleader;
            if (s == "defiasbandit") return CardDB.cardName.defiasbandit;
            if (s == "eyeforaneye") return CardDB.cardName.eyeforaneye;
            if (s == "perditionsblade") return CardDB.cardName.perditionsblade;
            if (s == "si7agent") return CardDB.cardName.si7agent;
            if (s == "redemption") return CardDB.cardName.redemption;
            if (s == "headcrack") return CardDB.cardName.headcrack;
            if (s == "shadowstep") return CardDB.cardName.shadowstep;
            if (s == "preparation") return CardDB.cardName.preparation;
            if (s == "wrath") return CardDB.cardName.wrath;
            if (s == "markofnature") return CardDB.cardName.markofnature;
            if (s == "souloftheforest") return CardDB.cardName.souloftheforest;
            if (s == "treant") return CardDB.cardName.treant;
            if (s == "powerofthewild") return CardDB.cardName.powerofthewild;
            if (s == "summonapanther") return CardDB.cardName.summonapanther;
            if (s == "leaderofthepack") return CardDB.cardName.leaderofthepack;
            if (s == "panther") return CardDB.cardName.panther;
            if (s == "naturalize") return CardDB.cardName.naturalize;
            if (s == "direwolfalpha") return CardDB.cardName.direwolfalpha;
            if (s == "nourish") return CardDB.cardName.nourish;
            if (s == "druidoftheclaw") return CardDB.cardName.druidoftheclaw;
            if (s == "catform") return CardDB.cardName.catform;
            if (s == "bearform") return CardDB.cardName.bearform;
            if (s == "keeperofthegrove") return CardDB.cardName.keeperofthegrove;
            if (s == "dispel") return CardDB.cardName.dispel;
            if (s == "emperorcobra") return CardDB.cardName.emperorcobra;
            if (s == "ancientofwar") return CardDB.cardName.ancientofwar;
            if (s == "rooted") return CardDB.cardName.rooted;
            if (s == "uproot") return CardDB.cardName.uproot;
            if (s == "lightningbolt") return CardDB.cardName.lightningbolt;
            if (s == "lavaburst") return CardDB.cardName.lavaburst;
            if (s == "dustdevil") return CardDB.cardName.dustdevil;
            if (s == "earthshock") return CardDB.cardName.earthshock;
            if (s == "stormforgedaxe") return CardDB.cardName.stormforgedaxe;
            if (s == "feralspirit") return CardDB.cardName.feralspirit;
            if (s == "barongeddon") return CardDB.cardName.barongeddon;
            if (s == "earthelemental") return CardDB.cardName.earthelemental;
            if (s == "forkedlightning") return CardDB.cardName.forkedlightning;
            if (s == "unboundelemental") return CardDB.cardName.unboundelemental;
            if (s == "lightningstorm") return CardDB.cardName.lightningstorm;
            if (s == "etherealarcanist") return CardDB.cardName.etherealarcanist;
            if (s == "coneofcold") return CardDB.cardName.coneofcold;
            if (s == "pyroblast") return CardDB.cardName.pyroblast;
            if (s == "frostelemental") return CardDB.cardName.frostelemental;
            if (s == "azuredrake") return CardDB.cardName.azuredrake;
            if (s == "counterspell") return CardDB.cardName.counterspell;
            if (s == "icebarrier") return CardDB.cardName.icebarrier;
            if (s == "mirrorentity") return CardDB.cardName.mirrorentity;
            if (s == "iceblock") return CardDB.cardName.iceblock;
            if (s == "ragnarosthefirelord") return CardDB.cardName.ragnarosthefirelord;
            if (s == "felguard") return CardDB.cardName.felguard;
            if (s == "shadowflame") return CardDB.cardName.shadowflame;
            if (s == "voidterror") return CardDB.cardName.voidterror;
            if (s == "siphonsoul") return CardDB.cardName.siphonsoul;
            if (s == "doomguard") return CardDB.cardName.doomguard;
            if (s == "twistingnether") return CardDB.cardName.twistingnether;
            if (s == "pitlord") return CardDB.cardName.pitlord;
            if (s == "summoningportal") return CardDB.cardName.summoningportal;
            if (s == "poweroverwhelming") return CardDB.cardName.poweroverwhelming;
            if (s == "sensedemons") return CardDB.cardName.sensedemons;
            if (s == "worthlessimp") return CardDB.cardName.worthlessimp;
            if (s == "flameimp") return CardDB.cardName.flameimp;
            if (s == "baneofdoom") return CardDB.cardName.baneofdoom;
            if (s == "lordjaraxxus") return CardDB.cardName.lordjaraxxus;
            if (s == "bloodfury") return CardDB.cardName.bloodfury;
            if (s == "silence") return CardDB.cardName.silence;
            if (s == "shadowmadness") return CardDB.cardName.shadowmadness;
            if (s == "lightspawn") return CardDB.cardName.lightspawn;
            if (s == "thoughtsteal") return CardDB.cardName.thoughtsteal;
            if (s == "lightwell") return CardDB.cardName.lightwell;
            if (s == "mindgames") return CardDB.cardName.mindgames;
            if (s == "shadowofnothing") return CardDB.cardName.shadowofnothing;
            if (s == "divinefavor") return CardDB.cardName.divinefavor;
            if (s == "prophetvelen") return CardDB.cardName.prophetvelen;
            if (s == "layonhands") return CardDB.cardName.layonhands;
            if (s == "blessedchampion") return CardDB.cardName.blessedchampion;
            if (s == "argentprotector") return CardDB.cardName.argentprotector;
            if (s == "blessingofwisdom") return CardDB.cardName.blessingofwisdom;
            if (s == "holywrath") return CardDB.cardName.holywrath;
            if (s == "swordofjustice") return CardDB.cardName.swordofjustice;
            if (s == "repentance") return CardDB.cardName.repentance;
            if (s == "aldorpeacekeeper") return CardDB.cardName.aldorpeacekeeper;
            if (s == "tirionfordring") return CardDB.cardName.tirionfordring;
            if (s == "ashbringer") return CardDB.cardName.ashbringer;
            if (s == "avengingwrath") return CardDB.cardName.avengingwrath;
            if (s == "taurenwarrior") return CardDB.cardName.taurenwarrior;
            if (s == "slam") return CardDB.cardName.slam;
            if (s == "battlerage") return CardDB.cardName.battlerage;
            if (s == "amaniberserker") return CardDB.cardName.amaniberserker;
            if (s == "mogushanwarden") return CardDB.cardName.mogushanwarden;
            if (s == "arathiweaponsmith") return CardDB.cardName.arathiweaponsmith;
            if (s == "battleaxe") return CardDB.cardName.battleaxe;
            if (s == "armorsmith") return CardDB.cardName.armorsmith;
            if (s == "shieldbearer") return CardDB.cardName.shieldbearer;
            if (s == "brawl") return CardDB.cardName.brawl;
            if (s == "mortalstrike") return CardDB.cardName.mortalstrike;
            if (s == "upgrade") return CardDB.cardName.upgrade;
            if (s == "heavyaxe") return CardDB.cardName.heavyaxe;
            if (s == "shieldslam") return CardDB.cardName.shieldslam;
            if (s == "gorehowl") return CardDB.cardName.gorehowl;
            if (s == "ragingworgen") return CardDB.cardName.ragingworgen;
            if (s == "grommashhellscream") return CardDB.cardName.grommashhellscream;
            if (s == "murlocwarleader") return CardDB.cardName.murlocwarleader;
            if (s == "murloctidecaller") return CardDB.cardName.murloctidecaller;
            if (s == "patientassassin") return CardDB.cardName.patientassassin;
            if (s == "scavenginghyena") return CardDB.cardName.scavenginghyena;
            if (s == "misdirection") return CardDB.cardName.misdirection;
            if (s == "savannahhighmane") return CardDB.cardName.savannahhighmane;
            if (s == "hyena") return CardDB.cardName.hyena;
            if (s == "eaglehornbow") return CardDB.cardName.eaglehornbow;
            if (s == "explosiveshot") return CardDB.cardName.explosiveshot;
            if (s == "unleashthehounds") return CardDB.cardName.unleashthehounds;
            if (s == "hound") return CardDB.cardName.hound;
            if (s == "kingkrush") return CardDB.cardName.kingkrush;
            if (s == "flare") return CardDB.cardName.flare;
            if (s == "bestialwrath") return CardDB.cardName.bestialwrath;
            if (s == "snaketrap") return CardDB.cardName.snaketrap;
            if (s == "snake") return CardDB.cardName.snake;
            if (s == "harvestgolem") return CardDB.cardName.harvestgolem;
            if (s == "natpagle") return CardDB.cardName.natpagle;
            if (s == "harrisonjones") return CardDB.cardName.harrisonjones;
            if (s == "archmageantonidas") return CardDB.cardName.archmageantonidas;
            if (s == "nozdormu") return CardDB.cardName.nozdormu;
            if (s == "alexstrasza") return CardDB.cardName.alexstrasza;
            if (s == "onyxia") return CardDB.cardName.onyxia;
            if (s == "malygos") return CardDB.cardName.malygos;
            if (s == "facelessmanipulator") return CardDB.cardName.facelessmanipulator;
            if (s == "doomhammer") return CardDB.cardName.doomhammer;
            if (s == "bite") return CardDB.cardName.bite;
            if (s == "forceofnature") return CardDB.cardName.forceofnature;
            if (s == "ysera") return CardDB.cardName.ysera;
            if (s == "cenarius") return CardDB.cardName.cenarius;
            if (s == "demigodsfavor") return CardDB.cardName.demigodsfavor;
            if (s == "shandoslesson") return CardDB.cardName.shandoslesson;
            if (s == "manatidetotem") return CardDB.cardName.manatidetotem;
            if (s == "thebeast") return CardDB.cardName.thebeast;
            if (s == "savagery") return CardDB.cardName.savagery;
            if (s == "priestessofelune") return CardDB.cardName.priestessofelune;
            if (s == "ancientmage") return CardDB.cardName.ancientmage;
            if (s == "seagiant") return CardDB.cardName.seagiant;
            if (s == "bloodknight") return CardDB.cardName.bloodknight;
            if (s == "auchenaisoulpriest") return CardDB.cardName.auchenaisoulpriest;
            if (s == "vaporize") return CardDB.cardName.vaporize;
            if (s == "cultmaster") return CardDB.cardName.cultmaster;
            if (s == "demonfire") return CardDB.cardName.demonfire;
            if (s == "impmaster") return CardDB.cardName.impmaster;
            if (s == "imp") return CardDB.cardName.imp;
            if (s == "crueltaskmaster") return CardDB.cardName.crueltaskmaster;
            if (s == "frothingberserker") return CardDB.cardName.frothingberserker;
            if (s == "innerrage") return CardDB.cardName.innerrage;
            if (s == "sorcerersapprentice") return CardDB.cardName.sorcerersapprentice;
            if (s == "snipe") return CardDB.cardName.snipe;
            if (s == "explosivetrap") return CardDB.cardName.explosivetrap;
            if (s == "freezingtrap") return CardDB.cardName.freezingtrap;
            if (s == "kirintormage") return CardDB.cardName.kirintormage;
            if (s == "edwinvancleef") return CardDB.cardName.edwinvancleef;
            if (s == "illidanstormrage") return CardDB.cardName.illidanstormrage;
            if (s == "flameofazzinoth") return CardDB.cardName.flameofazzinoth;
            if (s == "manawraith") return CardDB.cardName.manawraith;
            if (s == "deadlyshot") return CardDB.cardName.deadlyshot;
            if (s == "equality") return CardDB.cardName.equality;
            if (s == "moltengiant") return CardDB.cardName.moltengiant;
            if (s == "circleofhealing") return CardDB.cardName.circleofhealing;
            if (s == "templeenforcer") return CardDB.cardName.templeenforcer;
            if (s == "holyfire") return CardDB.cardName.holyfire;
            if (s == "shadowform") return CardDB.cardName.shadowform;
            if (s == "mindspike") return CardDB.cardName.mindspike;
            if (s == "mindshatter") return CardDB.cardName.mindshatter;
            if (s == "massdispel") return CardDB.cardName.massdispel;
            if (s == "finkleeinhorn") return CardDB.cardName.finkleeinhorn;
            if (s == "spiritwolf") return CardDB.cardName.spiritwolf;
            if (s == "squirrel") return CardDB.cardName.squirrel;
            if (s == "devilsaur") return CardDB.cardName.devilsaur;
            if (s == "inferno") return CardDB.cardName.inferno;
            if (s == "infernal") return CardDB.cardName.infernal;
            if (s == "kidnapper") return CardDB.cardName.kidnapper;
            if (s == "starfall") return CardDB.cardName.starfall;
            if (s == "ancientoflore") return CardDB.cardName.ancientoflore;
            if (s == "ancientteachings") return CardDB.cardName.ancientteachings;
            if (s == "ancientsecrets") return CardDB.cardName.ancientsecrets;
            if (s == "alakirthewindlord") return CardDB.cardName.alakirthewindlord;
            if (s == "manawyrm") return CardDB.cardName.manawyrm;
            if (s == "masterofdisguise") return CardDB.cardName.masterofdisguise;
            if (s == "hungrycrab") return CardDB.cardName.hungrycrab;
            if (s == "bloodsailraider") return CardDB.cardName.bloodsailraider;
            if (s == "knifejuggler") return CardDB.cardName.knifejuggler;
            if (s == "wildpyromancer") return CardDB.cardName.wildpyromancer;
            if (s == "doomsayer") return CardDB.cardName.doomsayer;
            if (s == "dreadcorsair") return CardDB.cardName.dreadcorsair;
            if (s == "faeriedragon") return CardDB.cardName.faeriedragon;
            if (s == "captaingreenskin") return CardDB.cardName.captaingreenskin;
            if (s == "bloodsailcorsair") return CardDB.cardName.bloodsailcorsair;
            if (s == "violetteacher") return CardDB.cardName.violetteacher;
            if (s == "violetapprentice") return CardDB.cardName.violetapprentice;
            if (s == "southseacaptain") return CardDB.cardName.southseacaptain;
            if (s == "millhousemanastorm") return CardDB.cardName.millhousemanastorm;
            if (s == "deathwing") return CardDB.cardName.deathwing;
            if (s == "commandingshout") return CardDB.cardName.commandingshout;
            if (s == "masterswordsmith") return CardDB.cardName.masterswordsmith;
            if (s == "gruul") return CardDB.cardName.gruul;
            if (s == "hogger") return CardDB.cardName.hogger;
            if (s == "gnoll") return CardDB.cardName.gnoll;
            if (s == "stampedingkodo") return CardDB.cardName.stampedingkodo;
            if (s == "damagedgolem") return CardDB.cardName.damagedgolem;
            if (s == "flesheatingghoul") return CardDB.cardName.flesheatingghoul;
            if (s == "spellbender") return CardDB.cardName.spellbender;
            if (s == "jasonchayes") return CardDB.cardName.jasonchayes;
            if (s == "ericdodds") return CardDB.cardName.ericdodds;
            if (s == "bobfitch") return CardDB.cardName.bobfitch;
            if (s == "stevengabriel") return CardDB.cardName.stevengabriel;
            if (s == "kyleharrison") return CardDB.cardName.kyleharrison;
            if (s == "dereksakamoto") return CardDB.cardName.dereksakamoto;
            if (s == "zwick") return CardDB.cardName.zwick;
            if (s == "benbrode") return CardDB.cardName.benbrode;
            if (s == "benthompson") return CardDB.cardName.benthompson;
            if (s == "michaelschweitzer") return CardDB.cardName.michaelschweitzer;
            if (s == "jaybaxter") return CardDB.cardName.jaybaxter;
            if (s == "rachelledavis") return CardDB.cardName.rachelledavis;
            if (s == "brianschwab") return CardDB.cardName.brianschwab;
            if (s == "yongwoo") return CardDB.cardName.yongwoo;
            if (s == "andybrock") return CardDB.cardName.andybrock;
            if (s == "hamiltonchu") return CardDB.cardName.hamiltonchu;
            if (s == "robpardo") return CardDB.cardName.robpardo;
            if (s == "oldmurkeye") return CardDB.cardName.oldmurkeye;
            if (s == "captainsparrot") return CardDB.cardName.captainsparrot;
            if (s == "riverpawgnoll") return CardDB.cardName.riverpawgnoll;
            if (s == "hoggersmash") return CardDB.cardName.hoggersmash;
            if (s == "massivegnoll") return CardDB.cardName.massivegnoll;
            if (s == "barreltoss") return CardDB.cardName.barreltoss;
            if (s == "barrel") return CardDB.cardName.barrel;
            if (s == "stomp") return CardDB.cardName.stomp;
            if (s == "hiddengnome") return CardDB.cardName.hiddengnome;
            if (s == "muklasbigbrother") return CardDB.cardName.muklasbigbrother;
            if (s == "willofmukla") return CardDB.cardName.willofmukla;
            if (s == "hemetnesingwary") return CardDB.cardName.hemetnesingwary;
            if (s == "crazedhunter") return CardDB.cardName.crazedhunter;
            if (s == "shotgunblast") return CardDB.cardName.shotgunblast;
            if (s == "flamesofazzinoth") return CardDB.cardName.flamesofazzinoth;
            if (s == "nagamyrmidon") return CardDB.cardName.nagamyrmidon;
            if (s == "warglaiveofazzinoth") return CardDB.cardName.warglaiveofazzinoth;
            if (s == "flameburst") return CardDB.cardName.flameburst;
            if (s == "dualwarglaives") return CardDB.cardName.dualwarglaives;
            if (s == "pandarenscout") return CardDB.cardName.pandarenscout;
            if (s == "shadopanmonk") return CardDB.cardName.shadopanmonk;
            if (s == "legacyoftheemperor") return CardDB.cardName.legacyoftheemperor;
            if (s == "brewmaster") return CardDB.cardName.brewmaster;
            if (s == "transcendence") return CardDB.cardName.transcendence;
            if (s == "crazymonkey") return CardDB.cardName.crazymonkey;
            if (s == "damage1") return CardDB.cardName.damage1;
            if (s == "damage5") return CardDB.cardName.damage5;
            if (s == "restore1") return CardDB.cardName.restore1;
            if (s == "restore5") return CardDB.cardName.restore5;
            if (s == "destroy") return CardDB.cardName.destroy;
            if (s == "breakweapon") return CardDB.cardName.breakweapon;
            if (s == "enableforattack") return CardDB.cardName.enableforattack;
            if (s == "freeze") return CardDB.cardName.freeze;
            if (s == "enchant") return CardDB.cardName.enchant;
            if (s == "silencedebug") return CardDB.cardName.silencedebug;
            if (s == "summonarandomsecret") return CardDB.cardName.summonarandomsecret;
            if (s == "bounce") return CardDB.cardName.bounce;
            if (s == "discard") return CardDB.cardName.discard;
            if (s == "mill10") return CardDB.cardName.mill10;
            if (s == "crash") return CardDB.cardName.crash;
            if (s == "snakeball") return CardDB.cardName.snakeball;
            if (s == "draw3cards") return CardDB.cardName.draw3cards;
            if (s == "destroyallminions") return CardDB.cardName.destroyallminions;
            if (s == "molasses") return CardDB.cardName.molasses;
            if (s == "damageallbut1") return CardDB.cardName.damageallbut1;
            if (s == "restoreallhealth") return CardDB.cardName.restoreallhealth;
            if (s == "freecards") return CardDB.cardName.freecards;
            if (s == "destroyallheroes") return CardDB.cardName.destroyallheroes;
            if (s == "damagereflector") return CardDB.cardName.damagereflector;
            if (s == "donothing") return CardDB.cardName.donothing;
            if (s == "enableemotes") return CardDB.cardName.enableemotes;
            if (s == "servercrash") return CardDB.cardName.servercrash;
            if (s == "revealhand") return CardDB.cardName.revealhand;
            if (s == "opponentconcede") return CardDB.cardName.opponentconcede;
            if (s == "opponentdisconnect") return CardDB.cardName.opponentdisconnect;
            if (s == "becomehogger") return CardDB.cardName.becomehogger;
            if (s == "destroyheropower") return CardDB.cardName.destroyheropower;
            if (s == "handtodeck") return CardDB.cardName.handtodeck;
            if (s == "mill30") return CardDB.cardName.mill30;
            if (s == "handswapperminion") return CardDB.cardName.handswapperminion;
            if (s == "stealcard") return CardDB.cardName.stealcard;
            if (s == "forceaitouseheropower") return CardDB.cardName.forceaitouseheropower;
            if (s == "destroydeck") return CardDB.cardName.destroydeck;
            if (s == "1durability") return CardDB.cardName.durability;
            if (s == "destroyallmana") return CardDB.cardName.destroyallmana;
            if (s == "destroyamanacrystal") return CardDB.cardName.destroyamanacrystal;
            if (s == "makeimmune") return CardDB.cardName.makeimmune;
            if (s == "grantmegawindfury") return CardDB.cardName.grantmegawindfury;
            if (s == "armor") return CardDB.cardName.armor;
            if (s == "weaponbuff") return CardDB.cardName.weaponbuff;
            if (s == "1000stats") return CardDB.cardName.stats;
            if (s == "silencedestroy") return CardDB.cardName.silencedestroy;
            if (s == "destroysecrets") return CardDB.cardName.destroysecrets;
            if (s == "aibuddyallcharge") return CardDB.cardName.aibuddyallcharge;
            if (s == "aibuddydamageownhero5") return CardDB.cardName.aibuddydamageownhero5;
            if (s == "aibuddydestroyminions") return CardDB.cardName.aibuddydestroyminions;
            if (s == "aibuddynodeck/hand") return CardDB.cardName.aibuddynodeckhand;
            if (s == "aihelperbuddy") return CardDB.cardName.aihelperbuddy;
            if (s == "gelbinmekkatorque") return CardDB.cardName.gelbinmekkatorque;
            if (s == "homingchicken") return CardDB.cardName.homingchicken;
            if (s == "repairbot") return CardDB.cardName.repairbot;
            if (s == "emboldener3000") return CardDB.cardName.emboldener3000;
            if (s == "poultryizer") return CardDB.cardName.poultryizer;
            if (s == "chicken") return CardDB.cardName.chicken;
            if (s == "elitetaurenchieftain") return CardDB.cardName.elitetaurenchieftain;
            if (s == "iammurloc") return CardDB.cardName.iammurloc;
            if (s == "murloc") return CardDB.cardName.murloc;
            if (s == "roguesdoit") return CardDB.cardName.roguesdoit;
            if (s == "powerofthehorde") return CardDB.cardName.powerofthehorde;
            if (s == "zombiechow") return CardDB.cardName.zombiechow;
            if (s == "hauntedcreeper") return CardDB.cardName.hauntedcreeper;
            if (s == "spectralspider") return CardDB.cardName.spectralspider;
            if (s == "echoingooze") return CardDB.cardName.echoingooze;
            if (s == "madscientist") return CardDB.cardName.madscientist;
            if (s == "shadeofnaxxramas") return CardDB.cardName.shadeofnaxxramas;
            if (s == "deathcharger") return CardDB.cardName.deathcharger;
            if (s == "nerubianegg") return CardDB.cardName.nerubianegg;
            if (s == "nerubian") return CardDB.cardName.nerubian;
            if (s == "spectralknight") return CardDB.cardName.spectralknight;
            if (s == "deathlord") return CardDB.cardName.deathlord;
            if (s == "maexxna") return CardDB.cardName.maexxna;
            if (s == "webspinner") return CardDB.cardName.webspinner;
            if (s == "sludgebelcher") return CardDB.cardName.sludgebelcher;
            if (s == "slime") return CardDB.cardName.slime;
            if (s == "kelthuzad") return CardDB.cardName.kelthuzad;
            if (s == "stalagg") return CardDB.cardName.stalagg;
            if (s == "thaddius") return CardDB.cardName.thaddius;
            if (s == "feugen") return CardDB.cardName.feugen;
            if (s == "wailingsoul") return CardDB.cardName.wailingsoul;
            if (s == "nerubarweblord") return CardDB.cardName.nerubarweblord;
            if (s == "duplicate") return CardDB.cardName.duplicate;
            if (s == "poisonseeds") return CardDB.cardName.poisonseeds;
            if (s == "avenge") return CardDB.cardName.avenge;
            if (s == "deathsbite") return CardDB.cardName.deathsbite;
            if (s == "voidcaller") return CardDB.cardName.voidcaller;
            if (s == "darkcultist") return CardDB.cardName.darkcultist;
            if (s == "unstableghoul") return CardDB.cardName.unstableghoul;
            if (s == "reincarnate") return CardDB.cardName.reincarnate;
            if (s == "anubarambusher") return CardDB.cardName.anubarambusher;
            if (s == "stoneskingargoyle") return CardDB.cardName.stoneskingargoyle;
            if (s == "undertaker") return CardDB.cardName.undertaker;
            if (s == "dancingswords") return CardDB.cardName.dancingswords;
            if (s == "loatheb") return CardDB.cardName.loatheb;
            if (s == "baronrivendare") return CardDB.cardName.baronrivendare;
            if (s == "patchwerk") return CardDB.cardName.patchwerk;
            if (s == "hook") return CardDB.cardName.hook;
            if (s == "hatefulstrike") return CardDB.cardName.hatefulstrike;
            if (s == "grobbulus") return CardDB.cardName.grobbulus;
            if (s == "poisoncloud") return CardDB.cardName.poisoncloud;
            if (s == "falloutslime") return CardDB.cardName.falloutslime;
            if (s == "mutatinginjection") return CardDB.cardName.mutatinginjection;
            if (s == "gluth") return CardDB.cardName.gluth;
            if (s == "decimate") return CardDB.cardName.decimate;
            if (s == "jaws") return CardDB.cardName.jaws;
            if (s == "enrage") return CardDB.cardName.enrage;
            if (s == "polarityshift") return CardDB.cardName.polarityshift;
            if (s == "supercharge") return CardDB.cardName.supercharge;
            if (s == "sapphiron") return CardDB.cardName.sapphiron;
            if (s == "frostbreath") return CardDB.cardName.frostbreath;
            if (s == "frozenchampion") return CardDB.cardName.frozenchampion;
            if (s == "purecold") return CardDB.cardName.purecold;
            if (s == "frostblast") return CardDB.cardName.frostblast;
            if (s == "guardianoficecrown") return CardDB.cardName.guardianoficecrown;
            if (s == "chains") return CardDB.cardName.chains;
            if (s == "mrbigglesworth") return CardDB.cardName.mrbigglesworth;
            if (s == "anubrekhan") return CardDB.cardName.anubrekhan;
            if (s == "skitter") return CardDB.cardName.skitter;
            if (s == "locustswarm") return CardDB.cardName.locustswarm;
            if (s == "grandwidowfaerlina") return CardDB.cardName.grandwidowfaerlina;
            if (s == "rainoffire") return CardDB.cardName.rainoffire;
            if (s == "worshipper") return CardDB.cardName.worshipper;
            if (s == "webwrap") return CardDB.cardName.webwrap;
            if (s == "necroticpoison") return CardDB.cardName.necroticpoison;
            if (s == "noththeplaguebringer") return CardDB.cardName.noththeplaguebringer;
            if (s == "raisedead") return CardDB.cardName.raisedead;
            if (s == "plague") return CardDB.cardName.plague;
            if (s == "heigantheunclean") return CardDB.cardName.heigantheunclean;
            if (s == "eruption") return CardDB.cardName.eruption;
            if (s == "mindpocalypse") return CardDB.cardName.mindpocalypse;
            if (s == "necroticaura") return CardDB.cardName.necroticaura;
            if (s == "deathbloom") return CardDB.cardName.deathbloom;
            if (s == "spore") return CardDB.cardName.spore;
            if (s == "sporeburst") return CardDB.cardName.sporeburst;
            if (s == "instructorrazuvious") return CardDB.cardName.instructorrazuvious;
            if (s == "understudy") return CardDB.cardName.understudy;
            if (s == "unbalancingstrike") return CardDB.cardName.unbalancingstrike;
            if (s == "massiveruneblade") return CardDB.cardName.massiveruneblade;
            if (s == "mindcontrolcrystal") return CardDB.cardName.mindcontrolcrystal;
            if (s == "gothiktheharvester") return CardDB.cardName.gothiktheharvester;
            if (s == "harvest") return CardDB.cardName.harvest;
            if (s == "unrelentingtrainee") return CardDB.cardName.unrelentingtrainee;
            if (s == "spectraltrainee") return CardDB.cardName.spectraltrainee;
            if (s == "unrelentingwarrior") return CardDB.cardName.unrelentingwarrior;
            if (s == "spectralwarrior") return CardDB.cardName.spectralwarrior;
            if (s == "unrelentingrider") return CardDB.cardName.unrelentingrider;
            if (s == "spectralrider") return CardDB.cardName.spectralrider;
            if (s == "ladyblaumeux") return CardDB.cardName.ladyblaumeux;
            if (s == "thanekorthazz") return CardDB.cardName.thanekorthazz;
            if (s == "sirzeliek") return CardDB.cardName.sirzeliek;
            if (s == "runeblade") return CardDB.cardName.runeblade;
            if (s == "unholyshadow") return CardDB.cardName.unholyshadow;
            if (s == "markofthehorsemen") return CardDB.cardName.markofthehorsemen;
            if (s == "necroknight") return CardDB.cardName.necroknight;
            if (s == "skeletalsmith") return CardDB.cardName.skeletalsmith;
            if (s == "flamecannon") return CardDB.cardName.flamecannon;
            if (s == "snowchugger") return CardDB.cardName.snowchugger;
            if (s == "unstableportal") return CardDB.cardName.unstableportal;
            if (s == "goblinblastmage") return CardDB.cardName.goblinblastmage;
            if (s == "echoofmedivh") return CardDB.cardName.echoofmedivh;
            if (s == "mechwarper") return CardDB.cardName.mechwarper;
            if (s == "flameleviathan") return CardDB.cardName.flameleviathan;
            if (s == "lightbomb") return CardDB.cardName.lightbomb;
            if (s == "shadowbomber") return CardDB.cardName.shadowbomber;
            if (s == "velenschosen") return CardDB.cardName.velenschosen;
            if (s == "shrinkmeister") return CardDB.cardName.shrinkmeister;
            if (s == "lightofthenaaru") return CardDB.cardName.lightofthenaaru;
            if (s == "cogmaster") return CardDB.cardName.cogmaster;
            if (s == "voljin") return CardDB.cardName.voljin;
            if (s == "darkbomb") return CardDB.cardName.darkbomb;
            if (s == "felreaver") return CardDB.cardName.felreaver;
            if (s == "callpet") return CardDB.cardName.callpet;
            if (s == "mistressofpain") return CardDB.cardName.mistressofpain;
            if (s == "demonheart") return CardDB.cardName.demonheart;
            if (s == "felcannon") return CardDB.cardName.felcannon;
            if (s == "malganis") return CardDB.cardName.malganis;
            if (s == "tinkerssharpswordoil") return CardDB.cardName.tinkerssharpswordoil;
            if (s == "goblinautobarber") return CardDB.cardName.goblinautobarber;
            if (s == "cogmasterswrench") return CardDB.cardName.cogmasterswrench;
            if (s == "oneeyedcheat") return CardDB.cardName.oneeyedcheat;
            if (s == "feigndeath") return CardDB.cardName.feigndeath;
            if (s == "ironsensei") return CardDB.cardName.ironsensei;
            if (s == "tradeprincegallywix") return CardDB.cardName.tradeprincegallywix;
            if (s == "gallywixscoin") return CardDB.cardName.gallywixscoin;
            if (s == "ancestorscall") return CardDB.cardName.ancestorscall;
            if (s == "anodizedrobocub") return CardDB.cardName.anodizedrobocub;
            if (s == "attackmode") return CardDB.cardName.attackmode;
            if (s == "tankmode") return CardDB.cardName.tankmode;
            if (s == "recycle") return CardDB.cardName.recycle;
            if (s == "grovetender") return CardDB.cardName.grovetender;
            if (s == "giftofmana") return CardDB.cardName.giftofmana;
            if (s == "giftofcards") return CardDB.cardName.giftofcards;
            if (s == "treeoflife") return CardDB.cardName.treeoflife;
            if (s == "mechbearcat") return CardDB.cardName.mechbearcat;
            if (s == "malorne") return CardDB.cardName.malorne;
            if (s == "powermace") return CardDB.cardName.powermace;
            if (s == "whirlingzapomatic") return CardDB.cardName.whirlingzapomatic;
            if (s == "crackle") return CardDB.cardName.crackle;
            if (s == "vitalitytotem") return CardDB.cardName.vitalitytotem;
            if (s == "siltfinspiritwalker") return CardDB.cardName.siltfinspiritwalker;
            if (s == "darkwispers") return CardDB.cardName.darkwispers;
            if (s == "neptulon") return CardDB.cardName.neptulon;
            if (s == "glaivezooka") return CardDB.cardName.glaivezooka;
            if (s == "spidertank") return CardDB.cardName.spidertank;
            if (s == "implosion") return CardDB.cardName.implosion;
            if (s == "kingofbeasts") return CardDB.cardName.kingofbeasts;
            if (s == "sabotage") return CardDB.cardName.sabotage;
            if (s == "metaltoothleaper") return CardDB.cardName.metaltoothleaper;
            if (s == "gahzrilla") return CardDB.cardName.gahzrilla;
            if (s == "bouncingblade") return CardDB.cardName.bouncingblade;
            if (s == "warbot") return CardDB.cardName.warbot;
            if (s == "crush") return CardDB.cardName.crush;
            if (s == "shieldmaiden") return CardDB.cardName.shieldmaiden;
            if (s == "ogrewarmaul") return CardDB.cardName.ogrewarmaul;
            if (s == "screwjankclunker") return CardDB.cardName.screwjankclunker;
            if (s == "ironjuggernaut") return CardDB.cardName.ironjuggernaut;
            if (s == "burrowingmine") return CardDB.cardName.burrowingmine;
            if (s == "sealoflight") return CardDB.cardName.sealoflight;
            if (s == "shieldedminibot") return CardDB.cardName.shieldedminibot;
            if (s == "coghammer") return CardDB.cardName.coghammer;
            if (s == "quartermaster") return CardDB.cardName.quartermaster;
            if (s == "musterforbattle") return CardDB.cardName.musterforbattle;
            if (s == "cobaltguardian") return CardDB.cardName.cobaltguardian;
            if (s == "bolvarfordragon") return CardDB.cardName.bolvarfordragon;
            if (s == "puddlestomper") return CardDB.cardName.puddlestomper;
            if (s == "ogrebrute") return CardDB.cardName.ogrebrute;
            if (s == "dunemaulshaman") return CardDB.cardName.dunemaulshaman;
            if (s == "stonesplintertrogg") return CardDB.cardName.stonesplintertrogg;
            if (s == "burlyrockjawtrogg") return CardDB.cardName.burlyrockjawtrogg;
            if (s == "antiquehealbot") return CardDB.cardName.antiquehealbot;
            if (s == "saltydog") return CardDB.cardName.saltydog;
            if (s == "losttallstrider") return CardDB.cardName.losttallstrider;
            if (s == "shadowboxer") return CardDB.cardName.shadowboxer;
            if (s == "cobrashot") return CardDB.cardName.cobrashot;
            if (s == "kezanmystic") return CardDB.cardName.kezanmystic;
            if (s == "shipscannon") return CardDB.cardName.shipscannon;
            if (s == "explosivesheep") return CardDB.cardName.explosivesheep;
            if (s == "animagolem") return CardDB.cardName.animagolem;
            if (s == "mechanicalyeti") return CardDB.cardName.mechanicalyeti;
            if (s == "forcetankmax") return CardDB.cardName.forcetankmax;
            if (s == "druidofthefang") return CardDB.cardName.druidofthefang;
            if (s == "gilblinstalker") return CardDB.cardName.gilblinstalker;
            if (s == "clockworkgnome") return CardDB.cardName.clockworkgnome;
            if (s == "upgradedrepairbot") return CardDB.cardName.upgradedrepairbot;
            if (s == "flyingmachine") return CardDB.cardName.flyingmachine;
            if (s == "annoyotron") return CardDB.cardName.annoyotron;
            if (s == "siegeengine") return CardDB.cardName.siegeengine;
            if (s == "steamwheedlesniper") return CardDB.cardName.steamwheedlesniper;
            if (s == "ogreninja") return CardDB.cardName.ogreninja;
            if (s == "illuminator") return CardDB.cardName.illuminator;
            if (s == "madderbomber") return CardDB.cardName.madderbomber;
            if (s == "arcanenullifierx21") return CardDB.cardName.arcanenullifierx21;
            if (s == "gnomishexperimenter") return CardDB.cardName.gnomishexperimenter;
            if (s == "targetdummy") return CardDB.cardName.targetdummy;
            if (s == "jeeves") return CardDB.cardName.jeeves;
            if (s == "goblinsapper") return CardDB.cardName.goblinsapper;
            if (s == "pilotedshredder") return CardDB.cardName.pilotedshredder;
            if (s == "lilexorcist") return CardDB.cardName.lilexorcist;
            if (s == "gnomereganinfantry") return CardDB.cardName.gnomereganinfantry;
            if (s == "bomblobber") return CardDB.cardName.bomblobber;
            if (s == "floatingwatcher") return CardDB.cardName.floatingwatcher;
            if (s == "scarletpurifier") return CardDB.cardName.scarletpurifier;
            if (s == "tinkertowntechnician") return CardDB.cardName.tinkertowntechnician;
            if (s == "micromachine") return CardDB.cardName.micromachine;
            if (s == "hobgoblin") return CardDB.cardName.hobgoblin;
            if (s == "pilotedskygolem") return CardDB.cardName.pilotedskygolem;
            if (s == "junkbot") return CardDB.cardName.junkbot;
            if (s == "enhanceomechano") return CardDB.cardName.enhanceomechano;
            if (s == "recombobulator") return CardDB.cardName.recombobulator;
            if (s == "minimage") return CardDB.cardName.minimage;
            if (s == "drboom") return CardDB.cardName.drboom;
            if (s == "boombot") return CardDB.cardName.boombot;
            if (s == "mimironshead") return CardDB.cardName.mimironshead;
            if (s == "v07tr0n") return CardDB.cardName.v07tr0n;
            if (s == "mogortheogre") return CardDB.cardName.mogortheogre;
            if (s == "foereaper4000") return CardDB.cardName.foereaper4000;
            if (s == "sneedsoldshredder") return CardDB.cardName.sneedsoldshredder;
            if (s == "toshley") return CardDB.cardName.toshley;
            if (s == "mekgineerthermaplugg") return CardDB.cardName.mekgineerthermaplugg;
            if (s == "gazlowe") return CardDB.cardName.gazlowe;
            if (s == "troggzortheearthinator") return CardDB.cardName.troggzortheearthinator;
            if (s == "blingtron3000") return CardDB.cardName.blingtron3000;
            if (s == "clockworkgiant") return CardDB.cardName.clockworkgiant;
            if (s == "weespellstopper") return CardDB.cardName.weespellstopper;
            if (s == "sootspewer") return CardDB.cardName.sootspewer;
            if (s == "armorplating") return CardDB.cardName.armorplating;
            if (s == "timerewinder") return CardDB.cardName.timerewinder;
            if (s == "rustyhorn") return CardDB.cardName.rustyhorn;
            if (s == "finickycloakfield") return CardDB.cardName.finickycloakfield;
            if (s == "emergencycoolant") return CardDB.cardName.emergencycoolant;
            if (s == "reversingswitch") return CardDB.cardName.reversingswitch;
            if (s == "whirlingblades") return CardDB.cardName.whirlingblades;
            //LOE

            if (s == "murloctinyfin") return CardDB.cardName.murloctinyfin;
            if (s == "lanternofpower") return CardDB.cardName.lanternofpower;
            if (s == "timepieceofhorror") return CardDB.cardName.timepieceofhorror;
            if (s == "mirrorofdoom") return CardDB.cardName.mirrorofdoom;
            if (s == "mummyzombie") return CardDB.cardName.mummyzombie;

            if (s == "forgottentorch") return CardDB.cardName.forgottentorch;
            if (s == "roaringtorch") return CardDB.cardName.roaringtorch;
            if (s == "etherealconjurer") return CardDB.cardName.etherealconjurer;
            if (s == "museumcurator") return CardDB.cardName.museumcurator;
            if (s == "curseofrafaam") return CardDB.cardName.curseofrafaam;
            if (s == "cursed") return CardDB.cardName.cursed;
            if (s == "obsidiandestroyer") return CardDB.cardName.obsidiandestroyer;
            if (s == "scarab") return CardDB.cardName.scarab;
            if (s == "pitsnake") return CardDB.cardName.pitsnake;
            if (s == "renojackson") return CardDB.cardName.renojackson;
            if (s == "tombpillager") return CardDB.cardName.tombpillager;
            if (s == "rumblingelemental") return CardDB.cardName.rumblingelemental;
            if (s == "keeperofuldaman") return CardDB.cardName.keeperofuldaman;
            if (s == "tunneltrogg") return CardDB.cardName.tunneltrogg;
            if (s == "unearthedraptor") return CardDB.cardName.unearthedraptor;
            if (s == "maptothegoldenmonkey") return CardDB.cardName.maptothegoldenmonkey;
            if (s == "goldenmonkey") return CardDB.cardName.goldenmonkey;
            if (s == "desertcamel") return CardDB.cardName.desertcamel;
            if (s == "darttrap") return CardDB.cardName.darttrap;
            if (s == "fiercemonkey") return CardDB.cardName.fiercemonkey;
            if (s == "darkpeddler") return CardDB.cardName.darkpeddler;
            if (s == "anyfincanhappen") return CardDB.cardName.anyfincanhappen;
            if (s == "sacredtrial") return CardDB.cardName.sacredtrial;
            if (s == "jeweledscarab") return CardDB.cardName.jeweledscarab;
            if (s == "nagaseawitch") return CardDB.cardName.nagaseawitch;
            if (s == "gorillabota3") return CardDB.cardName.gorillabota3;
            if (s == "hugetoad") return CardDB.cardName.hugetoad;
            if (s == "tombspider") return CardDB.cardName.tombspider;
            if (s == "mountedraptor") return CardDB.cardName.mountedraptor;
            if (s == "junglemoonkin") return CardDB.cardName.junglemoonkin;
            if (s == "djinniofzephyrs") return CardDB.cardName.djinniofzephyrs;
            if (s == "anubisathsentinel") return CardDB.cardName.anubisathsentinel;
            if (s == "fossilizeddevilsaur") return CardDB.cardName.fossilizeddevilsaur;
            if (s == "sirfinleymrrgglton") return CardDB.cardName.sirfinleymrrgglton;
            if (s == "brannbronzebeard") return CardDB.cardName.brannbronzebeard;
            if (s == "elisestarseeker") return CardDB.cardName.elisestarseeker;
            if (s == "summoningstone") return CardDB.cardName.summoningstone;
            if (s == "wobblingrunts") return CardDB.cardName.wobblingrunts;
            if (s == "rascallyrunt") return CardDB.cardName.rascallyrunt;
            if (s == "wilyrunt") return CardDB.cardName.wilyrunt;
            if (s == "grumblyrunt") return CardDB.cardName.grumblyrunt;
            if (s == "archthiefrafaam") return CardDB.cardName.archthiefrafaam;
            if (s == "entomb") return CardDB.cardName.entomb;
            if (s == "explorershat") return CardDB.cardName.explorershat;
            if (s == "eeriestatue") return CardDB.cardName.eeriestatue;
            if (s == "ancientshade") return CardDB.cardName.ancientshade;
            if (s == "ancientcurse") return CardDB.cardName.ancientcurse;
            if (s == "excavatedevil") return CardDB.cardName.excavatedevil;
            if (s == "everyfinisawesome") return CardDB.cardName.everyfinisawesome;
            if (s == "ravenidol") return CardDB.cardName.ravenidol;
            if (s == "reliquaryseeker") return CardDB.cardName.reliquaryseeker;
            if (s == "cursedblade") return CardDB.cardName.cursedblade;
            if (s == "animatedarmor") return CardDB.cardName.animatedarmor;


            if (s == "placeholdercard") return CardDB.cardName.placeholdercard;

            return CardDB.cardName.unknown;
        }

        public enum ErrorType2
        {
            NONE,//=0
            REQ_MINION_TARGET,//=1
            REQ_FRIENDLY_TARGET,//=2
            REQ_ENEMY_TARGET,//=3
            REQ_DAMAGED_TARGET,//=4
            REQ_ENCHANTED_TARGET,
            REQ_FROZEN_TARGET,
            REQ_CHARGE_TARGET,
            REQ_TARGET_MAX_ATTACK,//=8
            REQ_NONSELF_TARGET,//=9
            REQ_TARGET_WITH_RACE,//=10
            REQ_TARGET_TO_PLAY,//=11 
            REQ_NUM_MINION_SLOTS,//=12 
            REQ_WEAPON_EQUIPPED,//=13
            REQ_ENOUGH_MANA,//=14
            REQ_YOUR_TURN,
            REQ_NONSTEALTH_ENEMY_TARGET,
            REQ_HERO_TARGET,//17
            REQ_SECRET_CAP,
            REQ_MINION_CAP_IF_TARGET_AVAILABLE,//19
            REQ_MINION_CAP,
            REQ_TARGET_ATTACKED_THIS_TURN,
            REQ_TARGET_IF_AVAILABLE,//=22
            REQ_MINIMUM_ENEMY_MINIONS,//=23 /like spalen :D
            REQ_TARGET_FOR_COMBO,//=24
            REQ_NOT_EXHAUSTED_ACTIVATE,
            REQ_UNIQUE_SECRET,
            REQ_TARGET_TAUNTER,
            REQ_CAN_BE_ATTACKED,
            REQ_ACTION_PWR_IS_MASTER_PWR,
            REQ_TARGET_MAGNET,
            REQ_ATTACK_GREATER_THAN_0,
            REQ_ATTACKER_NOT_FROZEN,
            REQ_HERO_OR_MINION_TARGET,
            REQ_CAN_BE_TARGETED_BY_SPELLS,
            REQ_SUBCARD_IS_PLAYABLE,
            REQ_TARGET_FOR_NO_COMBO,
            REQ_NOT_MINION_JUST_PLAYED,
            REQ_NOT_EXHAUSTED_HERO_POWER,
            REQ_CAN_BE_TARGETED_BY_OPPONENTS,
            REQ_ATTACKER_CAN_ATTACK,
            REQ_TARGET_MIN_ATTACK,//=41
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS,
            REQ_ENEMY_TARGET_NOT_IMMUNE,
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY,//44 (totemic call)
            REQ_MINIMUM_TOTAL_MINIONS,//45 (scharmuetzel)
            REQ_MUST_TARGET_TAUNTER,//=46
            REQ_UNDAMAGED_TARGET,//=47
            REQ_CAN_BE_TARGETED_BY_BATTLECRIES,
            REQ_STEADY_SHOT,//49
            REQ_MINION_OR_ENEMY_HERO,//50
            REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND,//51
            REQ_LEGENDARY_TARGET,//52
            REQ_FRIENDLY_MINION_DIED_THIS_TURN,//53
            REQ_FRIENDLY_MINION_DIED_THIS_GAME,//54
            REQ_ENEMY_WEAPON_EQUIPPED,//55
            REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS,//56
            REQ_TARGET_WITH_BATTLECRY,//57
            REQ_TARGET_WITH_DEATHRATTLE,//58
            REQ_DRAG_TO_PLAY
        }

        public class Card
        {
            //public string CardID = "";
            public cardName name = cardName.unknown;
            public TAG_RACE race = TAG_RACE.INVALID;
            public int rarity = 0;
            public int cost = 0;
            public int Class = 0;
            public cardtype type = CardDB.cardtype.NONE;
            //public string description = "";

            public int Attack = 0;
            public int Health = 0;
            public int Durability = 0;//for weapons
            public bool target = false;
            //public string targettext = "";
            public bool tank = false;
            public bool Silence = false;
            public bool choice = false;
            public bool windfury = false;
            public bool poisionous = false;
            public bool deathrattle = false;
            public bool battlecry = false;
            public bool oneTurnEffect = false;
            public bool Enrage = false;
            public bool Aura = false;
            public bool Elite = false;
            public bool Combo = false;
            public bool Recall = false;
            public int recallValue = 0;
            public bool immuneWhileAttacking = false;
            public bool immuneToSpellpowerg = false;
            public bool Stealth = false;
            public bool Freeze = false;
            public bool AdjacentBuff = false;
            public bool Shield = false;
            public bool Charge = false;
            public bool Secret = false;
            public bool Morph = false;
            public bool Spellpower = false;
            public bool GrantCharge = false;
            public bool HealTarget = false;
            public bool hasInspire = false;
            //playRequirements, reqID= siehe PlayErrors->ErrorType
            public int needEmptyPlacesForPlaying = 0;
            public int needWithMinAttackValueOf = 0;
            public int needWithMaxAttackValueOf = 0;
            public int needRaceForPlaying = 0;
            public int needMinNumberOfEnemy = 0;
            public int needMinTotalMinions = 0;
            public int needMinionsCapIfAvailable = 0;
            public int needMinNumberOfOwnForTarget = -1;


            //additional data
            public bool isToken = false;
            public int isCarddraw = 0;
            public bool damagesTarget = false;
            public bool damagesTargetWithSpecial = false;
            public int targetPriority = 0;
            public bool isSpecialMinion = false;

            public int spellpowervalue = 0;
            public cardIDEnum cardIDenum = cardIDEnum.None;
            public List<ErrorType2> playrequires;

            public SimTemplate sim_card;
            public PenTemplate pen_card;

            public Card()
            {
                playrequires = new List<ErrorType2>();
            }

            public Card(Card c)
            {
                //this.entityID = c.entityID;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;
                //this.CardID = c.CardID;
                this.Charge = c.Charge;
                this.choice = c.choice;
                this.Combo = c.Combo;
                this.cost = c.cost;
                this.deathrattle = c.deathrattle;
                //this.description = c.description;
                this.Durability = c.Durability;
                this.Elite = c.Elite;
                this.Enrage = c.Enrage;
                this.Freeze = c.Freeze;
                this.GrantCharge = c.GrantCharge;
                this.HealTarget = c.HealTarget;
                this.Health = c.Health;
                this.immuneToSpellpowerg = c.immuneToSpellpowerg;
                this.immuneWhileAttacking = c.immuneWhileAttacking;
                this.Morph = c.Morph;
                this.name = c.name;
                this.needEmptyPlacesForPlaying = c.needEmptyPlacesForPlaying;
                this.needMinionsCapIfAvailable = c.needMinionsCapIfAvailable;
                this.needMinNumberOfEnemy = c.needMinNumberOfEnemy;
                this.needMinTotalMinions = c.needMinTotalMinions;
                this.needRaceForPlaying = c.needRaceForPlaying;
                this.needWithMaxAttackValueOf = c.needWithMaxAttackValueOf;
                this.needWithMinAttackValueOf = c.needWithMinAttackValueOf;
                this.oneTurnEffect = c.oneTurnEffect;
                this.playrequires = new List<ErrorType2>(c.playrequires);
                this.poisionous = c.poisionous;
                this.race = c.race;
                this.Recall = c.Recall;
                this.recallValue = c.recallValue;
                this.Secret = c.Secret;
                this.Shield = c.Shield;
                this.Silence = c.Silence;
                this.Spellpower = c.Spellpower;
                this.spellpowervalue = c.spellpowervalue;
                this.Stealth = c.Stealth;
                this.tank = c.tank;
                this.target = c.target;
                //this.targettext = c.targettext;
                this.type = c.type;
                this.windfury = c.windfury;
                this.cardIDenum = c.cardIDenum;
                this.sim_card = c.sim_card;
                this.isToken = c.isToken;
            }

            public bool isRequirementInList(CardDB.ErrorType2 et)
            {
                return this.playrequires.Contains(et);
            }

            public List<Minion> getTargetsForCard(Playfield p)
            {
                //todo make it faster!! 
                //todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                if ((isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS) && p.ownMinions.Count < this.needMinNumberOfOwnForTarget)) return retval;

                bool moreh = isRequirementInList(CardDB.ErrorType2.REQ_MINION_OR_ENEMY_HERO);
                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) || (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS) && p.ownMinions.Count >= this.needMinNumberOfOwnForTarget))
                {
                    addEnemyHero = true;
                    addOwnHero = true;

                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                        enemyMins[k] = true;
                    }

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND))
                {
                    bool dragonInHand = false;
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.race == TAG_RACE.DRAGON)
                        {
                            dragonInHand = true;
                            break;
                        }
                    }
                    if (dragonInHand == false) return retval;
                    //you have dragon on hand!
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                        enemyMins[k] = true;
                    }
                    addEnemyHero = true;
                    addOwnHero = true;

                }

                if (moreh)
                {
                    addEnemyHero = true;//moreh = req_minion_or_enemyHero
                    if (p.weHaveSteamwheedleSniper)
                    {
                        k = -1;
                        foreach (Minion m in p.ownMinions)
                        {
                            k++;
                            if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                            ownMins[k] = true;

                        }
                        k = -1;
                        foreach (Minion m in p.enemyMinions)
                        {
                            k++;
                            if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                            enemyMins[k] = true;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                }


                if (isRequirementInList(CardDB.ErrorType2.REQ_LEGENDARY_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }


                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_DEATHRATTLE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ( !(m.hasDeathrattle() || (m.handcard.card.deathrattle && !m.silenced) ))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!(m.hasDeathrattle() || (m.handcard.card.deathrattle && !m.silenced)))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }
                

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    addOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    addEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero) retval.Add(p.enemyHero);
                if (addOwnHero) retval.Add(p.ownHero);

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k]) retval.Add(m);
                }
                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k]) retval.Add(m);
                }

                return retval;

            }

            public List<Minion> getTargetsForCardEnemy(Playfield p)
            {
                //todo make it faster!! 
                //todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                bool moreh = isRequirementInList(CardDB.ErrorType2.REQ_MINION_OR_ENEMY_HERO);
                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                        enemyMins[k] = true;
                    }

                }

                if (moreh)
                {
                    addOwnHero = true;

                    if (p.enemyHaveSteamwheedleSniper)
                    {
                        k = -1;
                        foreach (Minion m in p.ownMinions)
                        {
                            k++;
                            if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                            ownMins[k] = true;

                        }

                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;
                }


                if (isRequirementInList(CardDB.ErrorType2.REQ_LEGENDARY_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }



                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    addOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    addEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero) retval.Add(p.enemyHero);
                if (addOwnHero) retval.Add(p.ownHero);

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k]) retval.Add(m);
                }
                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k]) retval.Add(m);
                }

                return retval;

            }

            public int getManaCost(Playfield p, int currentcost)//calculates mana from cleaned up mana!
            {
                int retval = currentcost;


                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################

                if (this.type == cardtype.MOB)
                {
                    //Manacosts changes with soeldner der venture co.
                    offset += p.soeldnerDerVenture * 3;
                    //Manacosts changes with mana-ghost
                    offset += p.managespenst;

                    if (this.battlecry)
                    {
                        offset += p.nerubarweblord * 2;
                    }


                }

                // CARDS that decrease the manacosts of others ##############################

                if (this.type == cardtype.MOB)
                {
                    //Manacosts changes with the summoning-portal >_>
                    if (p.beschwoerungsportal >= 1)
                    {
                        int temp = -p.beschwoerungsportal * 2;
                        if (retval >= 1 && retval + temp <= 0) temp = -retval + 1;
                        offset = offset + temp;
                    }


                    //Manacosts changes with the pint-sized summoner
                    if (p.mobsplayedThisTurn == 0)
                    {
                        offset -= p.pintsizedsummoner;
                    }

                    //manacosts changes with Mechwarper
                    if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                    {
                        offset -= p.anzOwnMechwarper;
                    }

                }



                if (this.type == cardtype.SPELL)
                {
                    //Manacosts changes with the zauberlehrling summoner
                    offset -= p.anzOwnsorcerersapprentice;

                    //manacosts are lowered, after we played preparation
                    if (p.playedPreparation)
                    {
                        offset -= 3;
                    }
                }

                if ((this.type == cardtype.MOB || this.type == cardtype.SPELL || this.type == cardtype.WEAPON) && p.anzownNagaSeaWitch >= 1)
                {
                    retval = 5;
                }

                if (this.type == cardtype.MOB)
                {
                    if (p.anzOwnAviana >= 1) retval = 1;
                }


                switch (this.name)
                {
                    case CardDB.cardName.frostgiant:
                        retval = retval + offset - p.own_TIMES_HERO_POWER_USED_THIS_GAME;
                        break;
                    case CardDB.cardName.skycapnkragg:
                        int pirates = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.handcard.card.race == TAG_RACE.PIRATE) pirates++;
                        }
                        retval = retval + offset - pirates;
                        break;

                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case CardDB.cardName.clockworkgiant:
                        retval = retval + offset - p.enemyAnzCards;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHero.Hp;
                        break;
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        retval = retval + offset;
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions)
                        {
                            retval -= 4;
                        }
                        break;

                    //Costs (1) less for each minion that died this turn. - cards:
                    // dont forget to add them in    Handmanager->setHandcards !!!
                    case CardDB.cardName.volcanicdrake:
                    case CardDB.cardName.volcaniclumberer:
                    case CardDB.cardName.dragonsbreath:
                    case CardDB.cardName.solemnvigil:
                        retval = retval - p.anzMinionsDiedThisTurn;
                        break;
                    case CardDB.cardName.everyfinisawesome:
                        int murlocs = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.handcard.card.race == TAG_RACE.MURLOC)
                            {
                                murlocs++;
                            }
                        }
                        retval = retval - murlocs;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }



                if (this.type == cardtype.SPELL)
                {
                    retval += (p.isOwnTurn) ? p.enemyloatheb * 5 : p.ownloatheb * 5;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = 0;
                }

                if (this.type == cardtype.MOB && this.race == TAG_RACE.DRAGON)
                {
                    retval -= (p.isOwnTurn) ? p.ownDragonConsort * 2 : p.enemyDragonConsort * 2;
                }

                if (this.type == cardtype.SPELL)
                {
                    retval += (p.isOwnTurn) ? p.enemyloatheb * 5 : p.ownloatheb * 5;
                }


                if (this.type == cardtype.SPELL && ((p.isOwnTurn && p.enemyHavePlayedMillhouseManastorm) || (!p.isOwnTurn && p.weHavePlayedMillhouseManastorm)))
                {
                    retval = 0;
                }


                if (this.type == cardtype.HEROPWR && p.anzOwnMaidenOfTheLake >= 1)
                {
                    retval = 1;
                }

                if (this.type == cardtype.HEROPWR)
                {
                    retval += (p.isOwnTurn) ? p.enemySaboteur * 5 : p.ownSaboteur * 5; ;
                }

                if (this.type == cardtype.HEROPWR && p.anzOwnFencingCoach >= 1)
                {
                    retval -= 2 * p.anzOwnFencingCoach;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            //calculate the manacosts without the changing effects
            //we calculate the "orginal"-manacosts, because we dont know of effects like icetrap, prep and stuff
            public int getStartManaCosts(Playfield p, int currentcost) //only call this with p = new Playfield()!
            {
                int retval = currentcost;

                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################

                if (this.type == cardtype.MOB)
                {

                    //Manacosts changes with soeldner der venture co.
                    offset += -p.soeldnerDerVenture * 3;
                    //Manacosts changes with mana-ghost
                    offset += -p.managespenst;
                    //weblord
                    if (this.battlecry)
                    {
                        offset += -p.nerubarweblord * 2;
                    }

                    if (p.anzOwnAviana >= 1)
                    {
                        offset += this.cost - 1;
                    }
                    else
                    {
                        if (p.anzownNagaSeaWitch >= 1)
                        {
                            offset += this.cost - 5;
                        }
                    }
                }
                else  //nagaseawitch for other cards
                {
                    if (p.anzownNagaSeaWitch >= 1)
                    {
                        offset += this.cost - 5;
                    }
                }

                

                // CARDS that decrease the manacosts of others ##############################

                if (this.type == cardtype.MOB)
                {

                    //Manacosts changes with the summoning-portal >_>
                    //cant lower the mana to 0
                    offset += p.beschwoerungsportal * 2;

                    //Manacosts changes with the pint-sized summoner
                    if (p.mobsplayedThisTurn == 0)
                    {
                        offset += p.pintsizedsummoner;
                    }

                    //manacosts changes with Mechwarper
                    if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                    {
                        offset += p.anzOwnMechwarper;
                    }
                }


                if (this.type == cardtype.SPELL)
                {

                    //manacosts are lowered, after we played preparation
                    if (p.playedPreparation)
                    {
                        offset += 3;
                    }

                    //Manacosts changes with the zauberlehrling summoner
                    offset += p.anzOwnsorcerersapprentice;

                }


                switch (this.name)
                {

                    case CardDB.cardName.frostgiant:
                        retval = retval + offset + p.own_TIMES_HERO_POWER_USED_THIS_GAME;
                        break;

                    case CardDB.cardName.skycapnkragg:
                        int pirates = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.handcard.card.race == TAG_RACE.PIRATE) pirates++;
                        }
                        retval = retval + offset + pirates;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset + p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset + p.ownMinions.Count + p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset + p.owncards.Count;
                        break;
                    case CardDB.cardName.clockworkgiant:
                        retval = retval + offset + p.enemyAnzCards;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions) retval = retval + offset + 4;
                        break;

                    //Cards with effect: Costs (1) less for each minion that died this turn.
                    case CardDB.cardName.volcanicdrake:
                    case CardDB.cardName.volcaniclumberer:
                    case CardDB.cardName.dragonsbreath:
                    case CardDB.cardName.solemnvigil:
                        retval = retval + p.anzMinionsDiedThisTurn;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = this.cost;
                }

                if (this.type == cardtype.MOB && this.race == TAG_RACE.DRAGON)
                {
                    retval += (p.isOwnTurn) ? p.ownDragonConsort * 2 : p.enemyDragonConsort * 2;
                }

                if (this.type == cardtype.SPELL)
                {
                    retval -= (p.isOwnTurn) ? p.enemyloatheb * 5 : p.ownloatheb * 5;
                }

                if (this.type == cardtype.SPELL && ((p.isOwnTurn && p.enemyHavePlayedMillhouseManastorm) || (!p.isOwnTurn && p.weHavePlayedMillhouseManastorm)))
                {
                    retval = this.cost;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public bool canplayCard(Playfield p, int manacost)
            {
                //is playrequirement?
                bool haveToDoRequires = isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY);
                bool retval = true;
                // cant play if i have to few mana

                if (p.mana < this.getManaCost(p, manacost)) return false;

                // cant play mob, if i have allready 7 mininos
                if (this.type == CardDB.cardtype.MOB && p.ownMinions.Count >= 7) return false;

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_ENEMY_MINIONS))
                {
                    if (p.enemyMinions.Count < this.needMinNumberOfEnemy) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_MINION_DIED_THIS_GAME))
                {
                    if (Probabilitymaker.Instance.anzMinionSinGrave == 0) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
                {
                    if (p.ownMinions.Count > 7 - this.needEmptyPlacesForPlaying) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_WEAPON_EQUIPPED))
                {
                    if (p.ownWeaponName == CardDB.cardName.unknown) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_TOTAL_MINIONS))
                {
                    if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return false;
                }



                if (haveToDoRequires)
                {
                    if (this.getTargetsForCard(p).Count == 0) return false;

                    //it requires a target-> return false if 
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) && isRequirementInList(CardDB.ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE))
                {
                    if (this.getTargetsForCard(p).Count >= 1 && p.ownMinions.Count > 7 - this.needMinionsCapIfAvailable) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY))
                {
                    int difftotem = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.name == CardDB.cardName.healingtotem || m.name == CardDB.cardName.wrathofairtotem || m.name == CardDB.cardName.searingtotem || m.name == CardDB.cardName.stoneclawtotem) difftotem++;
                    }
                    if (difftotem == 4) return false;
                }


                if (this.Secret)
                {
                    if (p.ownSecretsIDList.Contains(this.cardIDenum)) return false;
                    if (p.ownSecretsIDList.Count >= 5) return false;
                }



                return true;
            }



        }

        List<string> namelist = new List<string>();
        List<Card> cardlist = new List<Card>();
        Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();
        List<string> allCardIDS = new List<string>();
        public Card unknownCard;
        public bool installedWrong = false;

        public Card teacherminion;
        public Card illidanminion;
        public Card lepergnome;
        public Card burlyrockjaw;
        public Card grimpatron;
        public Card whelp2a1h;
        public Card imp;
        public Card ligthningJolt;

        private static CardDB instance;

        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();
                    //instance.enumCreator();// only call this to get latest cardids
                    /*foreach (KeyValuePair<cardIDEnum, Card> kvp in instance.cardidToCardList)
                    {
                        Helpfunctions.Instance.logg(kvp.Value.name + " " + kvp.Value.Attack);
                    }*/
                    // have to do it 2 times (or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.cardlist)
                    {
                        c.sim_card = instance.getSimCard(c.cardIDenum);
                        c.pen_card = instance.getPenCard(c.cardIDenum);
                    }
                    instance.setAdditionalData();
                }
                return instance;
            }
        }

        private CardDB()
        {
            string[] lines = new string[0] { };
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "_carddb.txt");
                Helpfunctions.Instance.ErrorLog("read carddb.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _carddb.txt");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("cant find _carddb.txt in " + Settings.Instance.path);
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("you installed it wrong");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                this.installedWrong = true;
            }
            cardlist.Clear();
            this.cardidToCardList.Clear();
            Card c = new Card();
            int de = 0;
            //placeholdercard
            Card plchldr = new Card { name = cardName.unknown, cost = 1000 };
            plchldr.sim_card = new SimTemplate();
            plchldr.pen_card = new PenTemplate();
            this.namelist.Add("unknown");
            this.cardlist.Add(plchldr);
            this.unknownCard = cardlist[0];
            string name = "";
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (c.type == cardtype.ENCHANTMENT)
                    {
                        //Helpfunctions.Instance.logg(c.CardID);
                        //Helpfunctions.Instance.logg(c.name);
                        //Helpfunctions.Instance.logg(c.description);
                        continue;
                    }
                    if (name != "")
                    {
                        this.namelist.Add(name);
                    }
                    name = "";
                    if (c.name != CardDB.cardName.unknown)
                    {

                        this.cardlist.Add(c);
                        //Helpfunctions.Instance.logg(c.name);

                        if (!this.cardidToCardList.ContainsKey(c.cardIDenum))
                        {
                            this.cardidToCardList.Add(c.cardIDenum, c);
                        }
                    }

                }
                if (s.Contains("<Entity version=\"") && s.Contains(" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Split(new string[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);

                    //token:
                    if (temp.EndsWith("t"))
                    {
                        c.isToken = true;
                    }
                    if (temp.Equals("ds1_whelptoken")) c.isToken = true;
                    if (temp.Equals("CS2_mirror")) c.isToken = true;
                    if (temp.Equals("CS2_050")) c.isToken = true;
                    if (temp.Equals("CS2_052")) c.isToken = true;
                    if (temp.Equals("CS2_051")) c.isToken = true;
                    if (temp.Equals("NEW1_009")) c.isToken = true;
                    if (temp.Equals("CS2_152")) c.isToken = true;
                    if (temp.Equals("CS2_boar")) c.isToken = true;
                    if (temp.Equals("EX1_tk11")) c.isToken = true;
                    if (temp.Equals("EX1_506a")) c.isToken = true;
                    if (temp.Equals("skele21")) c.isToken = true;
                    if (temp.Equals("EX1_tk9")) c.isToken = true;
                    if (temp.Equals("EX1_finkle")) c.isToken = true;
                    if (temp.Equals("EX1_598")) c.isToken = true;
                    if (temp.Equals("EX1_tk34")) c.isToken = true;
                    if (temp.Equals("AT_132_SHAMAN")) c.choice = true; // its a choice card

                    //if (c.isToken) Helpfunctions.Instance.ErrorLog(temp +" is token");

                    continue;
                }
                /*
                if (s.Contains("<Entity version=\"1\" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Replace("<Entity version=\"1\" CardID=\"", "");
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);
                    continue;
                }*/

                //health
                if (s.Contains("<Tag enumID=\"45\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }

                //Class
                if (s.Contains("Tag enumID=\"199\"")) //added fopr sake of figure out which class it belongs too... sorry adds a little more data
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Class = Convert.ToInt32(temp);
                    continue;
                }

                //attack
                if (s.Contains("<Tag enumID=\"47\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Attack = Convert.ToInt32(temp);
                    continue;
                }
                //race
                if (s.Contains("<Tag enumID=\"200\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = (TAG_RACE)Convert.ToInt32(temp);
                    continue;
                }
                //rarity
                if (s.Contains("<Tag enumID=\"203\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.rarity = Convert.ToInt32(temp);
                    continue;
                }
                //manacost
                if (s.Contains("<Tag enumID=\"48\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }
                //cardtype
                if (s.Contains("<Tag enumID=\"202\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    if (c.name != CardDB.cardName.unknown)
                    {
                        //Helpfunctions.Instance.logg(temp);
                    }

                    int crdtype = Convert.ToInt32(temp);
                    if (crdtype == 10)
                    {
                        c.type = CardDB.cardtype.HEROPWR;
                    }
                    if (crdtype == 4)
                    {
                        c.type = CardDB.cardtype.MOB;
                    }
                    if (crdtype == 5)
                    {
                        c.type = CardDB.cardtype.SPELL;
                    }
                    if (crdtype == 6)
                    {
                        c.type = CardDB.cardtype.ENCHANTMENT;
                    }
                    if (crdtype == 7)
                    {
                        c.type = CardDB.cardtype.WEAPON;
                    }
                    continue;
                }

                //cardname
                if (s.Contains("<Tag enumID=\"185\""))
                {
                    string temp = s.Split(new string[] { "type=\"String\">" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split(new string[] { "</Tag>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower();

                    temp = temp.Replace("'", "");
                    temp = temp.Replace(" ", "");
                    temp = temp.Replace(":", "");
                    temp = temp.Replace(".", "");
                    temp = temp.Replace(",", "");
                    temp = temp.Replace("!", "");
                    temp = temp.Replace("-", "");

                    //Helpfunctions.Instance.logg(temp);
                    c.name = this.cardNamestringToEnum(temp);
                    name = temp;


                    continue;
                }

                //cardtextinhand
                if (s.Contains("<Tag enumID=\"184\""))
                {
                    string temp = s.Split(new string[] { "type=\"String\">" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split(new string[] { "</Tag>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower();

                    if (temp.Contains("choose one"))
                    {
                        c.choice = true;
                        //Helpfunctions.Instance.logg(c.name + " is choice");
                    }

                    continue;
                }
                //targetingarrowtext
                if (s.Contains("<Tag enumID=\"325\""))
                {

                    string temp = s.Split(new string[] { "type=\"String\">" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split(new string[] { "</Tag>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower();

                    c.target = true;
                    continue;
                }


                //poisonous
                if (s.Contains("<Tag enumID=\"363\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.poisionous = true;
                    continue;
                }
                //enrage
                if (s.Contains("<Tag enumID=\"212\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Enrage = true;
                    continue;
                }
                //OneTurnEffect
                if (s.Contains("<Tag enumID=\"338\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.oneTurnEffect = true;
                    continue;
                }
                //aura
                if (s.Contains("<Tag enumID=\"362\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Aura = true;
                    continue;
                }

                //hasinspire
                if (s.Contains("<Tag enumID=\"403\""))
                {
                    c.hasInspire = true;
                    continue;
                }

                //taunt
                if (s.Contains("<Tag enumID=\"190\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.tank = true;
                    continue;
                }
                //battlecry
                if (s.Contains("<Tag enumID=\"218\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.battlecry = true;
                    continue;
                }
                //windfury
                if (s.Contains("<Tag enumID=\"189\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.windfury = true;
                    continue;
                }
                //deathrattle
                if (s.Contains("<Tag enumID=\"217\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.deathrattle = true;
                    continue;
                }
                //durability
                if (s.Contains("<Tag enumID=\"187\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Durability = Convert.ToInt32(temp);
                    continue;
                }
                //elite
                if (s.Contains("<Tag enumID=\"114\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Elite = true;
                    continue;
                }
                //combo
                if (s.Contains("<Tag enumID=\"220\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Combo = true;
                    continue;
                }
                //recall
                if (s.Contains("<Tag enumID=\"215\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Recall = true;
                    c.recallValue = 1;
                    if (c.name == CardDB.cardName.forkedlightning) c.recallValue = 2;
                    if (c.name == CardDB.cardName.dustdevil) c.recallValue = 2;
                    if (c.name == CardDB.cardName.lightningstorm) c.recallValue = 2;
                    if (c.name == CardDB.cardName.lavaburst) c.recallValue = 2;
                    if (c.name == CardDB.cardName.feralspirit) c.recallValue = 2;
                    if (c.name == CardDB.cardName.doomhammer) c.recallValue = 2;
                    if (c.name == CardDB.cardName.earthelemental) c.recallValue = 3;
                    continue;
                }
                //immunetospellpower
                if (s.Contains("<Tag enumID=\"349\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.immuneToSpellpowerg = true;
                    continue;
                }
                //stealh
                if (s.Contains("<Tag enumID=\"191\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Stealth = true;
                    continue;
                }
                //secret
                if (s.Contains("<Tag enumID=\"219\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Secret = true;
                    continue;
                }
                //freeze
                if (s.Contains("<Tag enumID=\"208\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Freeze = true;
                    continue;
                }
                //adjacentbuff
                if (s.Contains("<Tag enumID=\"350\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.AdjacentBuff = true;
                    continue;
                }
                //divineshield
                if (s.Contains("<Tag enumID=\"194\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Shield = true;
                    continue;
                }
                //charge
                if (s.Contains("<Tag enumID=\"197\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Charge = true;
                    continue;
                }
                //silence
                if (s.Contains("<Tag enumID=\"339\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Silence = true;
                    continue;
                }
                //morph
                if (s.Contains("<Tag enumID=\"293\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Morph = true;
                    continue;
                }
                //spellpower
                if (s.Contains("<Tag enumID=\"192\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Spellpower = true;
                    c.spellpowervalue = 1;
                    if (c.name == CardDB.cardName.ancientmage) c.spellpowervalue = 0;
                    if (c.name == CardDB.cardName.malygos) c.spellpowervalue = 5;
                    continue;
                }
                //grantcharge
                if (s.Contains("<Tag enumID=\"355\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.GrantCharge = true;
                    continue;
                }
                //healtarget
                if (s.Contains("<Tag enumID=\"361\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.HealTarget = true;
                    continue;
                }
                if (s.Contains("<PlayRequirement"))
                {
                    //if (!s.Contains("param=\"\"")) Console.WriteLine(s);

                    string temp = s.Split(new string[] { "reqID=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    ErrorType2 et2 = (ErrorType2)Convert.ToInt32(temp);
                    c.playrequires.Add(et2);
                }


                if (s.Contains("<PlayRequirement reqID=\"12\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needEmptyPlacesForPlaying = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"41\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMinAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"8\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMaxAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"10\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needRaceForPlaying = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"23\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinNumberOfEnemy = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"56\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinNumberOfOwnForTarget = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"45\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinTotalMinions = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"19\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinionsCapIfAvailable = Convert.ToInt32(temp);
                    continue;
                }



                if (s.Contains("<Tag name="))
                {
                    string temp = s.Split(new string[] { "<Tag name=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    /*
                    if (temp != "DevState" && temp != "FlavorText" && temp != "ArtistName" && temp != "Cost" && temp != "EnchantmentIdleVisual" && temp != "EnchantmentBirthVisual" && temp != "Collectible" && temp != "CardSet" && temp != "AttackVisualType" && temp != "CardName" && temp != "Class" && temp != "CardTextInHand" && temp != "Rarity" && temp != "TriggerVisual" && temp != "Faction" && temp != "HowToGetThisGoldCard" && temp != "HowToGetThisCard" && temp != "CardTextInPlay")
                        Helpfunctions.Instance.logg(s);*/
                }


            }

            this.teacherminion = this.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);
            this.illidanminion = this.getCardDataFromID(CardDB.cardIDEnum.EX1_614t);
            this.lepergnome = this.getCardDataFromID(CardDB.cardIDEnum.EX1_029);
            this.burlyrockjaw = this.getCardDataFromID(CardDB.cardIDEnum.GVG_068);
            this.grimpatron = this.getCardDataFromID(CardDB.cardIDEnum.BRM_019);
            this.whelp2a1h = this.getCardDataFromID(CardDB.cardIDEnum.BRM_022t);//whelptoken from blackrock
            this.imp = this.getCardDataFromID(CardDB.cardIDEnum.BRM_006t);//imp from blackrock
            this.ligthningJolt = this.getCardDataFromID(CardDB.cardIDEnum.AT_050t);//deal 2 dmg hero power
        }

        public Card getCardData(CardDB.cardName cardname)
        {

            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return unknownCard;
        }

        public Card getCardDataFromID(cardIDEnum id)
        {
            return this.cardidToCardList.ContainsKey(id) ? this.cardidToCardList[id] : this.unknownCard;
        }

        public SimTemplate getSimCard(cardIDEnum id)
        {
            switch (id)
            {
                    //LOE
                case cardIDEnum.LOEA10_3:
                    return new Sim_LOEA10_3();
                case cardIDEnum.LOEA16_3:
                    return new Sim_LOEA16_3();
                case cardIDEnum.LOEA16_4:
                    return new Sim_LOEA16_4();
                case cardIDEnum.LOEA16_5:
                    return new Sim_LOEA16_5();
                case cardIDEnum.LOEA16_5t:
                    return new Sim_LOEA16_5t();

                case cardIDEnum.LOE_002:
                    return new Sim_LOE_002();
                case cardIDEnum.LOE_002t:
                    return new Sim_LOE_002t();
                case cardIDEnum.LOE_003:
                    return new Sim_LOE_003();
                case cardIDEnum.LOE_006:
                    return new Sim_LOE_006();
                case cardIDEnum.LOE_007:
                    return new Sim_LOE_007();
                case cardIDEnum.LOE_007t:
                    return new Sim_LOE_007t();
                case cardIDEnum.LOE_009:
                    return new Sim_LOE_009();
                case cardIDEnum.LOE_009t:
                    return new Sim_LOE_009t();
                case cardIDEnum.LOE_010:
                    return new Sim_LOE_010();
                case cardIDEnum.LOE_011:
                    return new Sim_LOE_011();
                case cardIDEnum.LOE_012:
                    return new Sim_LOE_012();
                case cardIDEnum.LOE_016:
                    return new Sim_LOE_016();
                case cardIDEnum.LOE_017:
                    return new Sim_LOE_017();
                case cardIDEnum.LOE_018:
                    return new Sim_LOE_018();
                case cardIDEnum.LOE_019:
                    return new Sim_LOE_019();
                case cardIDEnum.LOE_019t:
                    return new Sim_LOE_019t();
                case cardIDEnum.LOE_019t2:
                    return new Sim_LOE_019t2();
                case cardIDEnum.LOE_020:
                    return new Sim_LOE_020();
                case cardIDEnum.LOE_021:
                    return new Sim_LOE_021();
                case cardIDEnum.LOE_022:
                    return new Sim_LOE_022();
                case cardIDEnum.LOE_023:
                    return new Sim_LOE_023();
                case cardIDEnum.LOE_027:
                    return new Sim_LOE_027();
                case cardIDEnum.LOE_029:
                    return new Sim_LOE_029();
                case cardIDEnum.LOE_038:
                    return new Sim_LOE_038();
                case cardIDEnum.LOE_039:
                    return new Sim_LOE_039();
                case cardIDEnum.LOE_046:
                    return new Sim_LOE_046();
                case cardIDEnum.LOE_047:
                    return new Sim_LOE_047();
                case cardIDEnum.LOE_050:
                    return new Sim_LOE_050();
                case cardIDEnum.LOE_051:
                    return new Sim_LOE_051();
                case cardIDEnum.LOE_053:
                    return new Sim_LOE_053();
                case cardIDEnum.LOE_061:
                    return new Sim_LOE_061();
                case cardIDEnum.LOE_073:
                    return new Sim_LOE_073();
                case cardIDEnum.LOE_076:
                    return new Sim_LOE_076();
                case cardIDEnum.LOE_077:
                    return new Sim_LOE_077();
                case cardIDEnum.LOE_079:
                    return new Sim_LOE_079();
                case cardIDEnum.LOE_086:
                    return new Sim_LOE_086();
                case cardIDEnum.LOE_089:
                    return new Sim_LOE_089();
                case cardIDEnum.LOE_089t:
                    return new Sim_LOE_089t();
                case cardIDEnum.LOE_092:
                    return new Sim_LOE_092();
                case cardIDEnum.LOE_104:
                    return new Sim_LOE_104();
                case cardIDEnum.LOE_105:
                    return new Sim_LOE_105();
                case cardIDEnum.LOE_107:
                    return new Sim_LOE_107();
                case cardIDEnum.LOE_110:
                    return new Sim_LOE_110();
                case cardIDEnum.LOE_110t:
                    return new Sim_LOE_110t();
                case cardIDEnum.LOE_111:
                    return new Sim_LOE_111();
                case cardIDEnum.LOE_113:
                    return new Sim_LOE_113();
                case cardIDEnum.LOE_115:
                    return new Sim_LOE_115();
                case cardIDEnum.LOE_115a:
                    return new Sim_LOE_115a();
                case cardIDEnum.LOE_115b:
                    return new Sim_LOE_115b();
                case cardIDEnum.LOE_116:
                    return new Sim_LOE_116();
                case cardIDEnum.LOE_118:
                    return new Sim_LOE_118();
                case cardIDEnum.LOE_119:
                    return new Sim_LOE_119();

                //TGT---------------------------------
                case cardIDEnum.AT_001:
                    return new Sim_AT_001();
                case cardIDEnum.AT_002:
                    return new Sim_AT_002();
                case cardIDEnum.AT_003:
                    return new Sim_AT_003();
                case cardIDEnum.AT_004:
                    return new Sim_AT_004();
                case cardIDEnum.AT_005:
                    return new Sim_AT_005();
                case cardIDEnum.AT_005t:
                    return new Sim_AT_005t();
                case cardIDEnum.AT_006:
                    return new Sim_AT_006();
                case cardIDEnum.AT_007:
                    return new Sim_AT_007();
                case cardIDEnum.AT_008:
                    return new Sim_AT_008();
                case cardIDEnum.AT_009:
                    return new Sim_AT_009();
                case cardIDEnum.AT_010:
                    return new Sim_AT_010();
                case cardIDEnum.AT_011:
                    return new Sim_AT_011();
                case cardIDEnum.AT_012:
                    return new Sim_AT_012();
                case cardIDEnum.AT_013:
                    return new Sim_AT_013();
                case cardIDEnum.AT_014:
                    return new Sim_AT_014();
                case cardIDEnum.AT_015:
                    return new Sim_AT_015();
                case cardIDEnum.AT_016:
                    return new Sim_AT_016();
                case cardIDEnum.AT_017:
                    return new Sim_AT_017();
                case cardIDEnum.AT_018:
                    return new Sim_AT_018();
                case cardIDEnum.AT_019:
                    return new Sim_AT_019();
                case cardIDEnum.AT_020:
                    return new Sim_AT_020();
                case cardIDEnum.AT_021:
                    return new Sim_AT_021();
                case cardIDEnum.AT_022:
                    return new Sim_AT_022();
                case cardIDEnum.AT_023:
                    return new Sim_AT_023();
                case cardIDEnum.AT_024:
                    return new Sim_AT_024();
                case cardIDEnum.AT_025:
                    return new Sim_AT_025();
                case cardIDEnum.AT_026:
                    return new Sim_AT_026();
                case cardIDEnum.AT_027:
                    return new Sim_AT_027();
                case cardIDEnum.AT_028:
                    return new Sim_AT_028();
                case cardIDEnum.AT_029:
                    return new Sim_AT_029();
                case cardIDEnum.AT_030:
                    return new Sim_AT_030();
                case cardIDEnum.AT_031:
                    return new Sim_AT_031();
                case cardIDEnum.AT_032:
                    return new Sim_AT_032();
                case cardIDEnum.AT_033:
                    return new Sim_AT_033();
                case cardIDEnum.AT_034:
                    return new Sim_AT_034();
                case cardIDEnum.AT_035:
                    return new Sim_AT_035();
                case cardIDEnum.AT_035t:
                    return new Sim_AT_035t();
                case cardIDEnum.AT_036:
                    return new Sim_AT_036();
                case cardIDEnum.AT_036t:
                    return new Sim_AT_036t();
                case cardIDEnum.AT_037:
                    return new Sim_AT_037();
                case cardIDEnum.AT_037a:
                    return new Sim_AT_037a();
                case cardIDEnum.AT_037b:
                    return new Sim_AT_037b();
                case cardIDEnum.AT_037t:
                    return new Sim_AT_037t();
                case cardIDEnum.AT_038:
                    return new Sim_AT_038();
                case cardIDEnum.AT_039:
                    return new Sim_AT_039();
                case cardIDEnum.AT_040:
                    return new Sim_AT_040();
                case cardIDEnum.AT_041:
                    return new Sim_AT_041();
                case cardIDEnum.AT_042:
                    return new Sim_AT_042();
                case cardIDEnum.AT_042a:
                    return new Sim_AT_042a();
                case cardIDEnum.AT_042b:
                    return new Sim_AT_042b();
                case cardIDEnum.AT_042t:
                    return new Sim_AT_042t();
                case cardIDEnum.AT_042t2:
                    return new Sim_AT_042t2();
                case cardIDEnum.AT_043:
                    return new Sim_AT_043();
                case cardIDEnum.AT_044:
                    return new Sim_AT_044();
                case cardIDEnum.AT_045:
                    return new Sim_AT_045();
                case cardIDEnum.AT_046:
                    return new Sim_AT_046();
                case cardIDEnum.AT_047:
                    return new Sim_AT_047();
                case cardIDEnum.AT_048:
                    return new Sim_AT_048();
                case cardIDEnum.AT_049:
                    return new Sim_AT_049();
                case cardIDEnum.AT_050:
                    return new Sim_AT_050();
                case cardIDEnum.AT_050t:
                    return new Sim_AT_050t();
                case cardIDEnum.AT_051:
                    return new Sim_AT_051();
                case cardIDEnum.AT_052:
                    return new Sim_AT_052();
                case cardIDEnum.AT_053:
                    return new Sim_AT_053();
                case cardIDEnum.AT_054:
                    return new Sim_AT_054();
                case cardIDEnum.AT_055:
                    return new Sim_AT_055();
                case cardIDEnum.AT_056:
                    return new Sim_AT_056();
                case cardIDEnum.AT_057:
                    return new Sim_AT_057();
                case cardIDEnum.AT_058:
                    return new Sim_AT_058();
                case cardIDEnum.AT_059:
                    return new Sim_AT_059();
                case cardIDEnum.AT_060:
                    return new Sim_AT_060();
                case cardIDEnum.AT_061:
                    return new Sim_AT_061();
                case cardIDEnum.AT_062:
                    return new Sim_AT_062();
                case cardIDEnum.AT_063:
                    return new Sim_AT_063();
                case cardIDEnum.AT_063t:
                    return new Sim_AT_063t();
                case cardIDEnum.AT_064:
                    return new Sim_AT_064();
                case cardIDEnum.AT_065:
                    return new Sim_AT_065();
                case cardIDEnum.AT_066:
                    return new Sim_AT_066();
                case cardIDEnum.AT_067:
                    return new Sim_AT_067();
                case cardIDEnum.AT_068:
                    return new Sim_AT_068();
                case cardIDEnum.AT_069:
                    return new Sim_AT_069();
                case cardIDEnum.AT_070:
                    return new Sim_AT_070();
                case cardIDEnum.AT_071:
                    return new Sim_AT_071();
                case cardIDEnum.AT_072:
                    return new Sim_AT_072();
                case cardIDEnum.AT_073:
                    return new Sim_AT_073();
                case cardIDEnum.AT_074:
                    return new Sim_AT_074();
                case cardIDEnum.AT_075:
                    return new Sim_AT_075();
                case cardIDEnum.AT_076:
                    return new Sim_AT_076();
                case cardIDEnum.AT_077:
                    return new Sim_AT_077();
                case cardIDEnum.AT_078:
                    return new Sim_AT_078();
                case cardIDEnum.AT_079:
                    return new Sim_AT_079();
                case cardIDEnum.AT_080:
                    return new Sim_AT_080();
                case cardIDEnum.AT_081:
                    return new Sim_AT_081();
                case cardIDEnum.AT_082:
                    return new Sim_AT_082();
                case cardIDEnum.AT_083:
                    return new Sim_AT_083();
                case cardIDEnum.AT_084:
                    return new Sim_AT_084();
                case cardIDEnum.AT_085:
                    return new Sim_AT_085();
                case cardIDEnum.AT_086:
                    return new Sim_AT_086();
                case cardIDEnum.AT_087:
                    return new Sim_AT_087();
                case cardIDEnum.AT_088:
                    return new Sim_AT_088();
                case cardIDEnum.AT_089:
                    return new Sim_AT_089();
                case cardIDEnum.AT_090:
                    return new Sim_AT_090();
                case cardIDEnum.AT_091:
                    return new Sim_AT_091();
                case cardIDEnum.AT_092:
                    return new Sim_AT_092();
                case cardIDEnum.AT_093:
                    return new Sim_AT_093();
                case cardIDEnum.AT_094:
                    return new Sim_AT_094();
                case cardIDEnum.AT_095:
                    return new Sim_AT_095();
                case cardIDEnum.AT_096:
                    return new Sim_AT_096();
                case cardIDEnum.AT_097:
                    return new Sim_AT_097();
                case cardIDEnum.AT_098:
                    return new Sim_AT_098();
                case cardIDEnum.AT_099:
                    return new Sim_AT_099();
                case cardIDEnum.AT_099t:
                    return new Sim_AT_099t();
                case cardIDEnum.AT_100:
                    return new Sim_AT_100();
                case cardIDEnum.AT_101:
                    return new Sim_AT_101();
                case cardIDEnum.AT_102:
                    return new Sim_AT_102();
                case cardIDEnum.AT_103:
                    return new Sim_AT_103();
                case cardIDEnum.AT_104:
                    return new Sim_AT_104();
                case cardIDEnum.AT_105:
                    return new Sim_AT_105();
                case cardIDEnum.AT_106:
                    return new Sim_AT_106();
                case cardIDEnum.AT_108:
                    return new Sim_AT_108();
                case cardIDEnum.AT_109:
                    return new Sim_AT_109();
                case cardIDEnum.AT_110:
                    return new Sim_AT_110();
                case cardIDEnum.AT_111:
                    return new Sim_AT_111();
                case cardIDEnum.AT_112:
                    return new Sim_AT_112();
                case cardIDEnum.AT_113:
                    return new Sim_AT_113();
                case cardIDEnum.AT_114:
                    return new Sim_AT_114();
                case cardIDEnum.AT_115:
                    return new Sim_AT_115();
                case cardIDEnum.AT_116:
                    return new Sim_AT_116();
                case cardIDEnum.AT_117:
                    return new Sim_AT_117();
                case cardIDEnum.AT_118:
                    return new Sim_AT_118();
                case cardIDEnum.AT_119:
                    return new Sim_AT_119();
                case cardIDEnum.AT_120:
                    return new Sim_AT_120();
                case cardIDEnum.AT_121:
                    return new Sim_AT_121();
                case cardIDEnum.AT_122:
                    return new Sim_AT_122();
                case cardIDEnum.AT_123:
                    return new Sim_AT_123();
                case cardIDEnum.AT_124:
                    return new Sim_AT_124();
                case cardIDEnum.AT_125:
                    return new Sim_AT_125();
                case cardIDEnum.AT_127:
                    return new Sim_AT_127();
                case cardIDEnum.AT_128:
                    return new Sim_AT_128();
                case cardIDEnum.AT_129:
                    return new Sim_AT_129();
                case cardIDEnum.AT_130:
                    return new Sim_AT_130();
                case cardIDEnum.AT_131:
                    return new Sim_AT_131();
                case cardIDEnum.AT_132:
                    return new Sim_AT_132();
                case cardIDEnum.AT_132_DRUID:
                    return new Sim_AT_132_DRUID();
                case cardIDEnum.AT_132_HUNTER:
                    return new Sim_AT_132_HUNTER();
                case cardIDEnum.AT_132_MAGE:
                    return new Sim_AT_132_MAGE();
                case cardIDEnum.AT_132_PALADIN:
                    return new Sim_AT_132_PALADIN();
                case cardIDEnum.AT_132_PRIEST:
                    return new Sim_AT_132_PRIEST();
                case cardIDEnum.AT_132_ROGUE:
                    return new Sim_AT_132_ROGUE();
                case cardIDEnum.AT_132_ROGUEt:
                    return new Sim_AT_132_ROGUEt();
                case cardIDEnum.AT_132_SHAMAN:
                    return new Sim_AT_132_SHAMAN();
                case cardIDEnum.AT_132_SHAMANa:
                    return new Sim_AT_132_SHAMANa();
                case cardIDEnum.AT_132_SHAMANb:
                    return new Sim_AT_132_SHAMANb();
                case cardIDEnum.AT_132_SHAMANc:
                    return new Sim_AT_132_SHAMANc();
                case cardIDEnum.AT_132_SHAMANd:
                    return new Sim_AT_132_SHAMANd();
                case cardIDEnum.AT_132_WARLOCK:
                    return new Sim_AT_132_WARLOCK();
                case cardIDEnum.AT_132_WARRIOR:
                    return new Sim_AT_132_WARRIOR();
                case cardIDEnum.AT_133:
                    return new Sim_AT_133();

                case cardIDEnum.BRM_001:
                    return new Sim_BRM_001();
                case cardIDEnum.BRM_002:
                    return new Sim_BRM_002();
                case cardIDEnum.BRM_003:
                    return new Sim_BRM_003();
                case cardIDEnum.BRM_004:
                    return new Sim_BRM_004();
                case cardIDEnum.BRM_005:
                    return new Sim_BRM_005();
                case cardIDEnum.BRM_006:
                    return new Sim_BRM_006();
                case cardIDEnum.BRM_007:
                    return new Sim_BRM_007();
                case cardIDEnum.BRM_008:
                    return new Sim_BRM_008();
                case cardIDEnum.BRM_009:
                    return new Sim_BRM_009();
                case cardIDEnum.BRM_010:
                    return new Sim_BRM_010();
                case cardIDEnum.BRM_010a:
                    return new Sim_BRM_010a();
                case cardIDEnum.BRM_010b:
                    return new Sim_BRM_010b();
                case cardIDEnum.BRM_010t:
                    return new Sim_BRM_010t();
                case cardIDEnum.BRM_010t2:
                    return new Sim_BRM_010t2();
                case cardIDEnum.BRM_011:
                    return new Sim_BRM_011();
                case cardIDEnum.BRM_012:
                    return new Sim_BRM_012();
                case cardIDEnum.BRM_013:
                    return new Sim_BRM_013();
                case cardIDEnum.BRM_014:
                    return new Sim_BRM_014();
                case cardIDEnum.BRM_015:
                    return new Sim_BRM_015();
                case cardIDEnum.BRM_016:
                    return new Sim_BRM_016();
                case cardIDEnum.BRM_017:
                    return new Sim_BRM_017();
                case cardIDEnum.BRM_018:
                    return new Sim_BRM_018();
                case cardIDEnum.BRM_019:
                    return new Sim_BRM_019();
                case cardIDEnum.BRM_020:
                    return new Sim_BRM_020();
                case cardIDEnum.BRM_022:
                    return new Sim_BRM_022();
                case cardIDEnum.BRM_024:
                    return new Sim_BRM_024();
                case cardIDEnum.BRM_025:
                    return new Sim_BRM_025();
                case cardIDEnum.BRM_026:
                    return new Sim_BRM_026();
                case cardIDEnum.BRM_027:
                    return new Sim_BRM_027();
                case cardIDEnum.BRM_027h:
                    return new Sim_BRM_027h();
                case cardIDEnum.BRM_027p:
                    return new Sim_BRM_027p();
                case cardIDEnum.BRM_027pH:
                    return new Sim_BRM_027pH();
                case cardIDEnum.BRM_028:
                    return new Sim_BRM_028();
                case cardIDEnum.BRM_029:
                    return new Sim_BRM_029();
                case cardIDEnum.BRM_030:
                    return new Sim_BRM_030();
                case cardIDEnum.BRM_030t:
                    return new Sim_BRM_030t();
                case cardIDEnum.BRM_031:
                    return new Sim_BRM_031();
                case cardIDEnum.BRM_033:
                    return new Sim_BRM_033();
                case cardIDEnum.BRM_034:
                    return new Sim_BRM_034();



                case cardIDEnum.NEW1_007b:
                    return new Sim_NEW1_007b();
                case cardIDEnum.EX1_613:
                    return new Sim_EX1_613();
                case cardIDEnum.EX1_133:
                    return new Sim_EX1_133();
                case cardIDEnum.NEW1_018:
                    return new Sim_NEW1_018();
                case cardIDEnum.EX1_012:
                    return new Sim_EX1_012();
                case cardIDEnum.EX1_178a:
                    return new Sim_EX1_178a();
                case cardIDEnum.CS2_231:
                    return new Sim_CS2_231();
                case cardIDEnum.CS2_179:
                    return new Sim_CS2_179();
                case cardIDEnum.EX1_244:
                    return new Sim_EX1_244();
                case cardIDEnum.EX1_178b:
                    return new Sim_EX1_178b();
                case cardIDEnum.EX1_573b:
                    return new Sim_EX1_573b();
                case cardIDEnum.NEW1_007a:
                    return new Sim_NEW1_007a();
                case cardIDEnum.EX1_345t:
                    return new Sim_EX1_345t();
                case cardIDEnum.FP1_007t:
                    return new Sim_FP1_007t();
                case cardIDEnum.EX1_025:
                    return new Sim_EX1_025();
                case cardIDEnum.EX1_396:
                    return new Sim_EX1_396();
                case cardIDEnum.NEW1_017:
                    return new Sim_NEW1_017();
                case cardIDEnum.NEW1_008a:
                    return new Sim_NEW1_008a();
                case cardIDEnum.EX1_533:
                    return new Sim_EX1_533();
                case cardIDEnum.EX1_522:
                    return new Sim_EX1_522();

                // case CardDB.cardIDEnum.NAX11_04: return new Sim_NAX11_04();
                case cardIDEnum.NEW1_026:
                    return new Sim_NEW1_026();
                case cardIDEnum.EX1_398:
                    return new Sim_EX1_398();

                // case CardDB.cardIDEnum.NAX4_04: return new Sim_NAX4_04();
                case cardIDEnum.EX1_007:
                    return new Sim_EX1_007();
                case cardIDEnum.CS1_112:
                    return new Sim_CS1_112();
                case cardIDEnum.NEW1_036:
                    return new Sim_NEW1_036();
                case cardIDEnum.EX1_258:
                    return new Sim_EX1_258();
                case cardIDEnum.HERO_01:
                    return new Sim_HERO_01();
                case cardIDEnum.CS2_087:
                    return new Sim_CS2_087();
                case cardIDEnum.DREAM_05:
                    return new Sim_DREAM_05();
                case cardIDEnum.CS2_092:
                    return new Sim_CS2_092();
                case cardIDEnum.CS2_022:
                    return new Sim_CS2_022();
                case cardIDEnum.EX1_046:
                    return new Sim_EX1_046();
                case cardIDEnum.PRO_001b:
                    return new Sim_PRO_001b();
                case cardIDEnum.PRO_001a:
                    return new Sim_PRO_001a();
                case cardIDEnum.CS2_103:
                    return new Sim_CS2_103();
                case cardIDEnum.NEW1_041:
                    return new Sim_NEW1_041();
                case cardIDEnum.EX1_360:
                    return new Sim_EX1_360();
                case cardIDEnum.FP1_023:
                    return new Sim_FP1_023();
                case cardIDEnum.NEW1_038:
                    return new Sim_NEW1_038();
                case cardIDEnum.CS2_009:
                    return new Sim_CS2_009();
                case cardIDEnum.EX1_010:
                    return new Sim_EX1_010();
                case cardIDEnum.CS2_024:
                    return new Sim_CS2_024();
                case cardIDEnum.EX1_565:
                    return new Sim_EX1_565();
                case cardIDEnum.CS2_076:
                    return new Sim_CS2_076();
                case cardIDEnum.FP1_004:
                    return new Sim_FP1_004();
                case cardIDEnum.CS2_162:
                    return new Sim_CS2_162();
                case cardIDEnum.EX1_110t:
                    return new Sim_EX1_110t();
                case cardIDEnum.CS2_181:
                    return new Sim_CS2_181();
                case cardIDEnum.EX1_309:
                    return new Sim_EX1_309();
                case cardIDEnum.EX1_354:
                    return new Sim_EX1_354();
                case cardIDEnum.EX1_023:
                    return new Sim_EX1_023();
                case cardIDEnum.NEW1_034:
                    return new Sim_NEW1_034();
                case cardIDEnum.CS2_003:
                    return new Sim_CS2_003();
                case cardIDEnum.HERO_06:
                    return new Sim_HERO_06();
                case cardIDEnum.CS2_201:
                    return new Sim_CS2_201();
                case cardIDEnum.EX1_508:
                    return new Sim_EX1_508();
                case cardIDEnum.EX1_259:
                    return new Sim_EX1_259();
                case cardIDEnum.EX1_341:
                    return new Sim_EX1_341();
                case cardIDEnum.EX1_103:
                    return new Sim_EX1_103();
                case cardIDEnum.FP1_021:
                    return new Sim_FP1_021();
                case cardIDEnum.EX1_411:
                    return new Sim_EX1_411();
                case cardIDEnum.CS2_053:
                    return new Sim_CS2_053();
                case cardIDEnum.CS2_182:
                    return new Sim_CS2_182();
                case cardIDEnum.CS2_008:
                    return new Sim_CS2_008();
                case cardIDEnum.CS2_233:
                    return new Sim_CS2_233();
                case cardIDEnum.EX1_626:
                    return new Sim_EX1_626();
                case cardIDEnum.EX1_059:
                    return new Sim_EX1_059();
                case cardIDEnum.EX1_334:
                    return new Sim_EX1_334();
                case cardIDEnum.EX1_619:
                    return new Sim_EX1_619();
                case cardIDEnum.NEW1_032:
                    return new Sim_NEW1_032();
                case cardIDEnum.EX1_158t:
                    return new Sim_EX1_158t();
                case cardIDEnum.EX1_006:
                    return new Sim_EX1_006();
                case cardIDEnum.NEW1_031:
                    return new Sim_NEW1_031();
                case cardIDEnum.DREAM_04:
                    return new Sim_DREAM_04();
                case cardIDEnum.EX1_004:
                    return new Sim_EX1_004();
                case cardIDEnum.EX1_095:
                    return new Sim_EX1_095();
                case cardIDEnum.NEW1_007:
                    return new Sim_NEW1_007();
                case cardIDEnum.EX1_275:
                    return new Sim_EX1_275();
                case cardIDEnum.EX1_245:
                    return new Sim_EX1_245();
                case cardIDEnum.EX1_383:
                    return new Sim_EX1_383();
                case cardIDEnum.FP1_016:
                    return new Sim_FP1_016();
                case cardIDEnum.CS2_125:
                    return new Sim_CS2_125();
                case cardIDEnum.EX1_137:
                    return new Sim_EX1_137();
                case cardIDEnum.DS1_185:
                    return new Sim_DS1_185();
                case cardIDEnum.FP1_010:
                    return new Sim_FP1_010();
                case cardIDEnum.EX1_598:
                    return new Sim_EX1_598();
                case cardIDEnum.EX1_304:
                    return new Sim_EX1_304();
                case cardIDEnum.EX1_302:
                    return new Sim_EX1_302();
                case cardIDEnum.EX1_614t:
                    return new Sim_EX1_614t();
                case cardIDEnum.CS2_108:
                    return new Sim_CS2_108();
                case cardIDEnum.CS2_046:
                    return new Sim_CS2_046();
                case cardIDEnum.EX1_014t:
                    return new Sim_EX1_014t();
                case cardIDEnum.NEW1_005:
                    return new Sim_NEW1_005();
                case cardIDEnum.EX1_062:
                    return new Sim_EX1_062();
                case cardIDEnum.Mekka1:
                    return new Sim_Mekka1();
                case cardIDEnum.tt_010a:
                    return new Sim_tt_010a();
                case cardIDEnum.CS2_072:
                    return new Sim_CS2_072();
                case cardIDEnum.EX1_tk28:
                    return new Sim_EX1_tk28();
                case cardIDEnum.FP1_014:
                    return new Sim_FP1_014();
                case cardIDEnum.EX1_409t:
                    return new Sim_EX1_409t();
                case cardIDEnum.EX1_507:
                    return new Sim_EX1_507();
                case cardIDEnum.EX1_144:
                    return new Sim_EX1_144();
                case cardIDEnum.CS2_038:
                    return new Sim_CS2_038();
                case cardIDEnum.EX1_093:
                    return new Sim_EX1_093();
                case cardIDEnum.CS2_080:
                    return new Sim_CS2_080();
                case cardIDEnum.EX1_005:
                    return new Sim_EX1_005();
                case cardIDEnum.EX1_382:
                    return new Sim_EX1_382();
                case cardIDEnum.CS2_028:
                    return new Sim_CS2_028();
                case cardIDEnum.EX1_538:
                    return new Sim_EX1_538();
                case cardIDEnum.DREAM_02:
                    return new Sim_DREAM_02();
                case cardIDEnum.EX1_581:
                    return new Sim_EX1_581();
                case cardIDEnum.EX1_131t:
                    return new Sim_EX1_131t();
                case cardIDEnum.CS2_147:
                    return new Sim_CS2_147();
                case cardIDEnum.CS1_113:
                    return new Sim_CS1_113();
                case cardIDEnum.CS2_161:
                    return new Sim_CS2_161();
                case cardIDEnum.CS2_031:
                    return new Sim_CS2_031();
                case cardIDEnum.EX1_166b:
                    return new Sim_EX1_166b();
                case cardIDEnum.EX1_066:
                    return new Sim_EX1_066();
                case cardIDEnum.EX1_355:
                    return new Sim_EX1_355();
                case cardIDEnum.EX1_534:
                    return new Sim_EX1_534();
                case cardIDEnum.EX1_162:
                    return new Sim_EX1_162();
                case cardIDEnum.EX1_363:
                    return new Sim_EX1_363();
                case cardIDEnum.EX1_164a:
                    return new Sim_EX1_164a();
                case cardIDEnum.CS2_188:
                    return new Sim_CS2_188();
                case cardIDEnum.EX1_016:
                    return new Sim_EX1_016();
                case cardIDEnum.EX1_603:
                    return new Sim_EX1_603();
                case cardIDEnum.EX1_238:
                    return new Sim_EX1_238();
                case cardIDEnum.EX1_166:
                    return new Sim_EX1_166();
                case cardIDEnum.DS1h_292:
                    return new Sim_DS1h_292();
                case cardIDEnum.DS1_183:
                    return new Sim_DS1_183();
                case cardIDEnum.EX1_076:
                    return new Sim_EX1_076();
                case cardIDEnum.EX1_048:
                    return new Sim_EX1_048();
                case cardIDEnum.FP1_026:
                    return new Sim_FP1_026();
                case cardIDEnum.CS2_074:
                    return new Sim_CS2_074();
                case cardIDEnum.FP1_027:
                    return new Sim_FP1_027();
                case cardIDEnum.EX1_323w:
                    return new Sim_EX1_323w();
                case cardIDEnum.EX1_129:
                    return new Sim_EX1_129();
                case cardIDEnum.EX1_405:
                    return new Sim_EX1_405();
                case cardIDEnum.EX1_317:
                    return new Sim_EX1_317();
                case cardIDEnum.EX1_606:
                    return new Sim_EX1_606();
                case cardIDEnum.FP1_006:
                    return new Sim_FP1_006();
                case cardIDEnum.NEW1_008:
                    return new Sim_NEW1_008();
                case cardIDEnum.CS2_119:
                    return new Sim_CS2_119();
                case cardIDEnum.CS2_121:
                    return new Sim_CS2_121();
                case cardIDEnum.CS1h_001:
                    return new Sim_CS1h_001();
                case cardIDEnum.EX1_tk34:
                    return new Sim_EX1_tk34();
                case cardIDEnum.NEW1_020:
                    return new Sim_NEW1_020();
                case cardIDEnum.CS2_196:
                    return new Sim_CS2_196();
                case cardIDEnum.EX1_312:
                    return new Sim_EX1_312();
                case cardIDEnum.FP1_022:
                    return new Sim_FP1_022();
                case cardIDEnum.EX1_160b:
                    return new Sim_EX1_160b();
                case cardIDEnum.EX1_563:
                    return new Sim_EX1_563();
                case cardIDEnum.FP1_031:
                    return new Sim_FP1_031();
                case cardIDEnum.NEW1_029:
                    return new Sim_NEW1_029();
                case cardIDEnum.CS1_129:
                    return new Sim_CS1_129();
                case cardIDEnum.HERO_03:
                    return new Sim_HERO_03();
                case cardIDEnum.Mekka4t:
                    return new Sim_Mekka4t();
                case cardIDEnum.EX1_158:
                    return new Sim_EX1_158();
                case cardIDEnum.NEW1_025:
                    return new Sim_NEW1_025();
                case cardIDEnum.FP1_012t:
                    return new Sim_FP1_012t();
                case cardIDEnum.EX1_083:
                    return new Sim_EX1_083();
                case cardIDEnum.EX1_295:
                    return new Sim_EX1_295();
                case cardIDEnum.EX1_407:
                    return new Sim_EX1_407();
                case cardIDEnum.NEW1_004:
                    return new Sim_NEW1_004();
                case cardIDEnum.FP1_019:
                    return new Sim_FP1_019();
                case cardIDEnum.PRO_001at:
                    return new Sim_PRO_001at();
                case cardIDEnum.EX1_625t:
                    return new Sim_EX1_625t();
                case cardIDEnum.EX1_014:
                    return new Sim_EX1_014();
                case cardIDEnum.CS2_097:
                    return new Sim_CS2_097();
                case cardIDEnum.EX1_558:
                    return new Sim_EX1_558();
                case cardIDEnum.EX1_tk29:
                    return new Sim_EX1_tk29();
                case cardIDEnum.CS2_186:
                    return new Sim_CS2_186();
                case cardIDEnum.EX1_084:
                    return new Sim_EX1_084();
                case cardIDEnum.NEW1_012:
                    return new Sim_NEW1_012();
                case cardIDEnum.FP1_014t:
                    return new Sim_FP1_014t();
                case cardIDEnum.EX1_578:
                    return new Sim_EX1_578();
                case cardIDEnum.CS2_221:
                    return new Sim_CS2_221();
                case cardIDEnum.EX1_019:
                    return new Sim_EX1_019();
                case cardIDEnum.FP1_019t:
                    return new Sim_FP1_019t();
                case cardIDEnum.EX1_132:
                    return new Sim_EX1_132();
                case cardIDEnum.EX1_284:
                    return new Sim_EX1_284();
                case cardIDEnum.EX1_105:
                    return new Sim_EX1_105();
                case cardIDEnum.NEW1_011:
                    return new Sim_NEW1_011();
                case cardIDEnum.EX1_017:
                    return new Sim_EX1_017();
                case cardIDEnum.EX1_249:
                    return new Sim_EX1_249();
                case cardIDEnum.FP1_002t:
                    return new Sim_FP1_002t();
                case cardIDEnum.EX1_313:
                    return new Sim_EX1_313();
                case cardIDEnum.EX1_155b:
                    return new Sim_EX1_155b();
                case cardIDEnum.NEW1_033:
                    return new Sim_NEW1_033();
                case cardIDEnum.CS2_106:
                    return new Sim_CS2_106();
                case cardIDEnum.FP1_018:
                    return new Sim_FP1_018();
                case cardIDEnum.DS1_233:
                    return new Sim_DS1_233();
                case cardIDEnum.DS1_175:
                    return new Sim_DS1_175();
                case cardIDEnum.NEW1_024:
                    return new Sim_NEW1_024();
                case cardIDEnum.CS2_189:
                    return new Sim_CS2_189();
                case cardIDEnum.NEW1_037:
                    return new Sim_NEW1_037();
                case cardIDEnum.EX1_414:
                    return new Sim_EX1_414();
                case cardIDEnum.EX1_538t:
                    return new Sim_EX1_538t();
                case cardIDEnum.EX1_586:
                    return new Sim_EX1_586();
                case cardIDEnum.EX1_310:
                    return new Sim_EX1_310();
                case cardIDEnum.NEW1_010:
                    return new Sim_NEW1_010();
                case cardIDEnum.EX1_534t:
                    return new Sim_EX1_534t();
                case cardIDEnum.FP1_028:
                    return new Sim_FP1_028();
                case cardIDEnum.EX1_604:
                    return new Sim_EX1_604();
                case cardIDEnum.EX1_160:
                    return new Sim_EX1_160();
                case cardIDEnum.EX1_165t1:
                    return new Sim_EX1_165t1();
                case cardIDEnum.CS2_062:
                    return new Sim_CS2_062();
                case cardIDEnum.CS2_155:
                    return new Sim_CS2_155();
                case cardIDEnum.CS2_213:
                    return new Sim_CS2_213();
                case cardIDEnum.CS2_004:
                    return new Sim_CS2_004();
                case cardIDEnum.CS2_023:
                    return new Sim_CS2_023();
                case cardIDEnum.EX1_164:
                    return new Sim_EX1_164();
                case cardIDEnum.EX1_009:
                    return new Sim_EX1_009();
                case cardIDEnum.FP1_007:
                    return new Sim_FP1_007();
                case cardIDEnum.EX1_345:
                    return new Sim_EX1_345();
                case cardIDEnum.EX1_116:
                    return new Sim_EX1_116();
                case cardIDEnum.EX1_399:
                    return new Sim_EX1_399();
                case cardIDEnum.EX1_587:
                    return new Sim_EX1_587();
                case cardIDEnum.EX1_571:
                    return new Sim_EX1_571();
                case cardIDEnum.EX1_335:
                    return new Sim_EX1_335();
                case cardIDEnum.HERO_08:
                    return new Sim_HERO_08();
                case cardIDEnum.EX1_166a:
                    return new Sim_EX1_166a();
                case cardIDEnum.EX1_finkle:
                    return new Sim_EX1_finkle();
                case cardIDEnum.EX1_164b:
                    return new Sim_EX1_164b();
                case cardIDEnum.EX1_283:
                    return new Sim_EX1_283();
                case cardIDEnum.EX1_339:
                    return new Sim_EX1_339();
                case cardIDEnum.EX1_531:
                    return new Sim_EX1_531();
                case cardIDEnum.EX1_134:
                    return new Sim_EX1_134();
                case cardIDEnum.EX1_350:
                    return new Sim_EX1_350();
                case cardIDEnum.EX1_308:
                    return new Sim_EX1_308();
                case cardIDEnum.CS2_197:
                    return new Sim_CS2_197();
                case cardIDEnum.skele21:
                    return new Sim_skele21();
                case cardIDEnum.FP1_013:
                    return new Sim_FP1_013();
                case cardIDEnum.EX1_509:
                    return new Sim_EX1_509();
                case cardIDEnum.EX1_612:
                    return new Sim_EX1_612();
                case cardIDEnum.EX1_021:
                    return new Sim_EX1_021();
                case cardIDEnum.CS2_226:
                    return new Sim_CS2_226();
                case cardIDEnum.EX1_608:
                    return new Sim_EX1_608();
                case cardIDEnum.EX1_624:
                    return new Sim_EX1_624();
                case cardIDEnum.EX1_616:
                    return new Sim_EX1_616();
                case cardIDEnum.EX1_008:
                    return new Sim_EX1_008();
                case cardIDEnum.PlaceholderCard:
                    return new Sim_PlaceholderCard();
                case cardIDEnum.EX1_045:
                    return new Sim_EX1_045();
                case cardIDEnum.EX1_015:
                    return new Sim_EX1_015();
                case cardIDEnum.CS2_171:
                    return new Sim_CS2_171();
                case cardIDEnum.CS2_041:
                    return new Sim_CS2_041();
                case cardIDEnum.EX1_128:
                    return new Sim_EX1_128();
                case cardIDEnum.CS2_112:
                    return new Sim_CS2_112();
                case cardIDEnum.HERO_07:
                    return new Sim_HERO_07();
                case cardIDEnum.EX1_412:
                    return new Sim_EX1_412();
                case cardIDEnum.CS2_117:
                    return new Sim_CS2_117();
                case cardIDEnum.EX1_562:
                    return new Sim_EX1_562();
                case cardIDEnum.EX1_055:
                    return new Sim_EX1_055();
                case cardIDEnum.FP1_012:
                    return new Sim_FP1_012();
                case cardIDEnum.EX1_317t:
                    return new Sim_EX1_317t();
                case cardIDEnum.EX1_278:
                    return new Sim_EX1_278();
                case cardIDEnum.CS2_tk1:
                    return new Sim_CS2_tk1();
                case cardIDEnum.EX1_590:
                    return new Sim_EX1_590();
                case cardIDEnum.CS1_130:
                    return new Sim_CS1_130();
                case cardIDEnum.NEW1_008b:
                    return new Sim_NEW1_008b();
                case cardIDEnum.EX1_365:
                    return new Sim_EX1_365();
                case cardIDEnum.CS2_141:
                    return new Sim_CS2_141();
                case cardIDEnum.PRO_001:
                    return new Sim_PRO_001();
                case cardIDEnum.CS2_173:
                    return new Sim_CS2_173();
                case cardIDEnum.CS2_017:
                    return new Sim_CS2_017();
                case cardIDEnum.EX1_392:
                    return new Sim_EX1_392();
                case cardIDEnum.EX1_593:
                    return new Sim_EX1_593();
                case cardIDEnum.EX1_049:
                    return new Sim_EX1_049();
                case cardIDEnum.EX1_002:
                    return new Sim_EX1_002();
                case cardIDEnum.CS2_056:
                    return new Sim_CS2_056();
                case cardIDEnum.EX1_596:
                    return new Sim_EX1_596();
                case cardIDEnum.EX1_136:
                    return new Sim_EX1_136();
                case cardIDEnum.EX1_323:
                    return new Sim_EX1_323();
                case cardIDEnum.CS2_073:
                    return new Sim_CS2_073();
                case cardIDEnum.EX1_001:
                    return new Sim_EX1_001();
                case cardIDEnum.EX1_044:
                    return new Sim_EX1_044();
                case cardIDEnum.Mekka4:
                    return new Sim_Mekka4();
                case cardIDEnum.CS2_142:
                    return new Sim_CS2_142();
                case cardIDEnum.EX1_573:
                    return new Sim_EX1_573();
                case cardIDEnum.FP1_009:
                    return new Sim_FP1_009();
                case cardIDEnum.CS2_050:
                    return new Sim_CS2_050();
                case cardIDEnum.EX1_390:
                    return new Sim_EX1_390();
                case cardIDEnum.EX1_610:
                    return new Sim_EX1_610();
                case cardIDEnum.hexfrog:
                    return new Sim_hexfrog();
                case cardIDEnum.CS2_082:
                    return new Sim_CS2_082();
                case cardIDEnum.NEW1_040:
                    return new Sim_NEW1_040();
                case cardIDEnum.DREAM_01:
                    return new Sim_DREAM_01();
                case cardIDEnum.EX1_595:
                    return new Sim_EX1_595();
                case cardIDEnum.CS2_013:
                    return new Sim_CS2_013();
                case cardIDEnum.CS2_077:
                    return new Sim_CS2_077();
                case cardIDEnum.NEW1_014:
                    return new Sim_NEW1_014();
                case cardIDEnum.GAME_002:
                    return new Sim_GAME_002();
                case cardIDEnum.EX1_165:
                    return new Sim_EX1_165();
                case cardIDEnum.CS2_013t:
                    return new Sim_CS2_013t();
                case cardIDEnum.EX1_tk11:
                    return new Sim_EX1_tk11();
                case cardIDEnum.EX1_591:
                    return new Sim_EX1_591();
                case cardIDEnum.EX1_549:
                    return new Sim_EX1_549();
                case cardIDEnum.CS2_045:
                    return new Sim_CS2_045();
                case cardIDEnum.CS2_237:
                    return new Sim_CS2_237();
                case cardIDEnum.CS2_027:
                    return new Sim_CS2_027();
                case cardIDEnum.CS2_101t:
                    return new Sim_CS2_101t();
                case cardIDEnum.CS2_063:
                    return new Sim_CS2_063();
                case cardIDEnum.EX1_145:
                    return new Sim_EX1_145();
                case cardIDEnum.EX1_110:
                    return new Sim_EX1_110();
                case cardIDEnum.EX1_408:
                    return new Sim_EX1_408();
                case cardIDEnum.EX1_544:
                    return new Sim_EX1_544();
                case cardIDEnum.CS2_151:
                    return new Sim_CS2_151();
                case cardIDEnum.CS2_088:
                    return new Sim_CS2_088();
                case cardIDEnum.EX1_057:
                    return new Sim_EX1_057();
                case cardIDEnum.FP1_020:
                    return new Sim_FP1_020();
                case cardIDEnum.CS2_169:
                    return new Sim_CS2_169();
                case cardIDEnum.EX1_573t:
                    return new Sim_EX1_573t();
                case cardIDEnum.EX1_323h:
                    return new Sim_EX1_323h();
                case cardIDEnum.EX1_tk9:
                    return new Sim_EX1_tk9();
                case cardIDEnum.CS2_037:
                    return new Sim_CS2_037();
                case cardIDEnum.CS2_007:
                    return new Sim_CS2_007();
                case cardIDEnum.CS2_227:
                    return new Sim_CS2_227();
                case cardIDEnum.NEW1_003:
                    return new Sim_NEW1_003();
                case cardIDEnum.GAME_006:
                    return new Sim_GAME_006();
                case cardIDEnum.EX1_320:
                    return new Sim_EX1_320();
                case cardIDEnum.EX1_097:
                    return new Sim_EX1_097();
                case cardIDEnum.tt_004:
                    return new Sim_tt_004();
                case cardIDEnum.EX1_096:
                    return new Sim_EX1_096();
                case cardIDEnum.EX1_126:
                    return new Sim_EX1_126();
                case cardIDEnum.EX1_577:
                    return new Sim_EX1_577();
                case cardIDEnum.EX1_319:
                    return new Sim_EX1_319();
                case cardIDEnum.EX1_611:
                    return new Sim_EX1_611();
                case cardIDEnum.CS2_146:
                    return new Sim_CS2_146();
                case cardIDEnum.EX1_154b:
                    return new Sim_EX1_154b();
                case cardIDEnum.skele11:
                    return new Sim_skele11();
                case cardIDEnum.EX1_165t2:
                    return new Sim_EX1_165t2();
                case cardIDEnum.CS2_172:
                    return new Sim_CS2_172();
                case cardIDEnum.CS2_114:
                    return new Sim_CS2_114();
                case cardIDEnum.CS1_069:
                    return new Sim_CS1_069();
                case cardIDEnum.EX1_173:
                    return new Sim_EX1_173();
                case cardIDEnum.CS1_042:
                    return new Sim_CS1_042();
                case cardIDEnum.EX1_506a:
                    return new Sim_EX1_506a();
                case cardIDEnum.EX1_298:
                    return new Sim_EX1_298();
                case cardIDEnum.CS2_104:
                    return new Sim_CS2_104();
                case cardIDEnum.FP1_001:
                    return new Sim_FP1_001();
                case cardIDEnum.HERO_02:
                    return new Sim_HERO_02();
                case cardIDEnum.CS2_051:
                    return new Sim_CS2_051();
                case cardIDEnum.NEW1_016:
                    return new Sim_NEW1_016();
                case cardIDEnum.EX1_033:
                    return new Sim_EX1_033();
                case cardIDEnum.EX1_028:
                    return new Sim_EX1_028();
                case cardIDEnum.EX1_621:
                    return new Sim_EX1_621();
                case cardIDEnum.EX1_554:
                    return new Sim_EX1_554();
                case cardIDEnum.EX1_091:
                    return new Sim_EX1_091();
                case cardIDEnum.FP1_017:
                    return new Sim_FP1_017();
                case cardIDEnum.EX1_409:
                    return new Sim_EX1_409();
                case cardIDEnum.EX1_410:
                    return new Sim_EX1_410();
                case cardIDEnum.CS2_039:
                    return new Sim_CS2_039();
                case cardIDEnum.EX1_557:
                    return new Sim_EX1_557();
                case cardIDEnum.DS1_070:
                    return new Sim_DS1_070();
                case cardIDEnum.CS2_033:
                    return new Sim_CS2_033();
                case cardIDEnum.EX1_536:
                    return new Sim_EX1_536();
                case cardIDEnum.EX1_559:
                    return new Sim_EX1_559();
                case cardIDEnum.CS2_052:
                    return new Sim_CS2_052();
                case cardIDEnum.EX1_539:
                    return new Sim_EX1_539();
                case cardIDEnum.EX1_575:
                    return new Sim_EX1_575();
                case cardIDEnum.CS2_083b:
                    return new Sim_CS2_083b();
                case cardIDEnum.CS2_061:
                    return new Sim_CS2_061();
                case cardIDEnum.NEW1_021:
                    return new Sim_NEW1_021();
                case cardIDEnum.DS1_055:
                    return new Sim_DS1_055();
                case cardIDEnum.EX1_625:
                    return new Sim_EX1_625();
                case cardIDEnum.CS2_026:
                    return new Sim_CS2_026();
                case cardIDEnum.EX1_294:
                    return new Sim_EX1_294();
                case cardIDEnum.EX1_287:
                    return new Sim_EX1_287();
                case cardIDEnum.EX1_625t2:
                    return new Sim_EX1_625t2();
                case cardIDEnum.CS2_118:
                    return new Sim_CS2_118();
                case cardIDEnum.CS2_124:
                    return new Sim_CS2_124();
                case cardIDEnum.Mekka3:
                    return new Sim_Mekka3();
                case cardIDEnum.EX1_112:
                    return new Sim_EX1_112();
                case cardIDEnum.FP1_011:
                    return new Sim_FP1_011();
                case cardIDEnum.HERO_04:
                    return new Sim_HERO_04();
                case cardIDEnum.EX1_607:
                    return new Sim_EX1_607();
                case cardIDEnum.DREAM_03:
                    return new Sim_DREAM_03();
                case cardIDEnum.FP1_003:
                    return new Sim_FP1_003();
                case cardIDEnum.CS2_105:
                    return new Sim_CS2_105();
                case cardIDEnum.FP1_002:
                    return new Sim_FP1_002();
                case cardIDEnum.EX1_567:
                    return new Sim_EX1_567();
                case cardIDEnum.FP1_008:
                    return new Sim_FP1_008();
                case cardIDEnum.DS1_184:
                    return new Sim_DS1_184();
                case cardIDEnum.CS2_029:
                    return new Sim_CS2_029();
                case cardIDEnum.GAME_005:
                    return new Sim_GAME_005();
                case cardIDEnum.CS2_187:
                    return new Sim_CS2_187();
                case cardIDEnum.EX1_020:
                    return new Sim_EX1_020();
                case cardIDEnum.EX1_011:
                    return new Sim_EX1_011();
                case cardIDEnum.CS2_057:
                    return new Sim_CS2_057();
                case cardIDEnum.EX1_274:
                    return new Sim_EX1_274();
                case cardIDEnum.EX1_306:
                    return new Sim_EX1_306();
                case cardIDEnum.EX1_170:
                    return new Sim_EX1_170();
                case cardIDEnum.EX1_617:
                    return new Sim_EX1_617();
                case cardIDEnum.CS2_101:
                    return new Sim_CS2_101();
                case cardIDEnum.FP1_015:
                    return new Sim_FP1_015();
                case cardIDEnum.CS2_005:
                    return new Sim_CS2_005();
                case cardIDEnum.EX1_537:
                    return new Sim_EX1_537();
                case cardIDEnum.EX1_384:
                    return new Sim_EX1_384();
                case cardIDEnum.EX1_362:
                    return new Sim_EX1_362();
                case cardIDEnum.EX1_301:
                    return new Sim_EX1_301();
                case cardIDEnum.CS2_235:
                    return new Sim_CS2_235();
                case cardIDEnum.EX1_029:
                    return new Sim_EX1_029();
                case cardIDEnum.CS2_042:
                    return new Sim_CS2_042();
                case cardIDEnum.EX1_155a:
                    return new Sim_EX1_155a();
                case cardIDEnum.CS2_102:
                    return new Sim_CS2_102();
                case cardIDEnum.EX1_609:
                    return new Sim_EX1_609();
                case cardIDEnum.NEW1_027:
                    return new Sim_NEW1_027();
                case cardIDEnum.EX1_165a:
                    return new Sim_EX1_165a();
                case cardIDEnum.EX1_570:
                    return new Sim_EX1_570();
                case cardIDEnum.EX1_131:
                    return new Sim_EX1_131();
                case cardIDEnum.EX1_556:
                    return new Sim_EX1_556();
                case cardIDEnum.EX1_543:
                    return new Sim_EX1_543();
                case cardIDEnum.NEW1_009:
                    return new Sim_NEW1_009();
                case cardIDEnum.EX1_100:
                    return new Sim_EX1_100();
                case cardIDEnum.EX1_573a:
                    return new Sim_EX1_573a();
                case cardIDEnum.CS2_084:
                    return new Sim_CS2_084();
                case cardIDEnum.EX1_582:
                    return new Sim_EX1_582();
                case cardIDEnum.EX1_043:
                    return new Sim_EX1_043();
                case cardIDEnum.EX1_050:
                    return new Sim_EX1_050();
                case cardIDEnum.FP1_005:
                    return new Sim_FP1_005();
                case cardIDEnum.EX1_620:
                    return new Sim_EX1_620();
                case cardIDEnum.EX1_303:
                    return new Sim_EX1_303();
                case cardIDEnum.HERO_09:
                    return new Sim_HERO_09();
                case cardIDEnum.HERO_01a://hero_xxa is same as hero_xx
                    return new Sim_HERO_01();
                case cardIDEnum.HERO_02a:
                    return new Sim_HERO_02();
                case cardIDEnum.HERO_03a:
                    return new Sim_HERO_03();
                case cardIDEnum.HERO_04a:
                    return new Sim_HERO_04();
                case cardIDEnum.HERO_05a:
                    return new Sim_HERO_05();
                case cardIDEnum.HERO_06a:
                    return new Sim_HERO_06();
                case cardIDEnum.HERO_07a:
                    return new Sim_HERO_07();
                case cardIDEnum.HERO_08a:
                    return new Sim_HERO_08();
                case cardIDEnum.HERO_09a:
                    return new Sim_HERO_09();
                case cardIDEnum.EX1_067:
                    return new Sim_EX1_067();
                case cardIDEnum.EX1_277:
                    return new Sim_EX1_277();
                case cardIDEnum.Mekka2:
                    return new Sim_Mekka2();
                case cardIDEnum.FP1_024:
                    return new Sim_FP1_024();
                case cardIDEnum.FP1_030:
                    return new Sim_FP1_030();
                case cardIDEnum.EX1_178:
                    return new Sim_EX1_178();
                case cardIDEnum.CS2_222:
                    return new Sim_CS2_222();
                case cardIDEnum.EX1_160a:
                    return new Sim_EX1_160a();
                case cardIDEnum.CS2_012:
                    return new Sim_CS2_012();
                case cardIDEnum.EX1_246:
                    return new Sim_EX1_246();
                case cardIDEnum.EX1_572:
                    return new Sim_EX1_572();
                case cardIDEnum.EX1_089:
                    return new Sim_EX1_089();
                case cardIDEnum.CS2_059:
                    return new Sim_CS2_059();
                case cardIDEnum.EX1_279:
                    return new Sim_EX1_279();
                case cardIDEnum.CS2_168:
                    return new Sim_CS2_168();
                case cardIDEnum.tt_010:
                    return new Sim_tt_010();
                case cardIDEnum.NEW1_023:
                    return new Sim_NEW1_023();
                case cardIDEnum.CS2_075:
                    return new Sim_CS2_075();
                case cardIDEnum.EX1_316:
                    return new Sim_EX1_316();
                case cardIDEnum.CS2_025:
                    return new Sim_CS2_025();
                case cardIDEnum.CS2_234:
                    return new Sim_CS2_234();
                case cardIDEnum.EX1_130:
                    return new Sim_EX1_130();
                case cardIDEnum.CS2_064:
                    return new Sim_CS2_064();
                case cardIDEnum.EX1_161:
                    return new Sim_EX1_161();
                case cardIDEnum.CS2_049:
                    return new Sim_CS2_049();
                case cardIDEnum.EX1_154:
                    return new Sim_EX1_154();
                case cardIDEnum.EX1_080:
                    return new Sim_EX1_080();
                case cardIDEnum.NEW1_022:
                    return new Sim_NEW1_022();
                case cardIDEnum.EX1_251:
                    return new Sim_EX1_251();
                case cardIDEnum.FP1_025:
                    return new Sim_FP1_025();
                case cardIDEnum.EX1_371:
                    return new Sim_EX1_371();
                case cardIDEnum.CS2_mirror:
                    return new Sim_CS2_mirror();
                case cardIDEnum.EX1_594:
                    return new Sim_EX1_594();
                case cardIDEnum.EX1_560:
                    return new Sim_EX1_560();
                case cardIDEnum.CS2_236:
                    return new Sim_CS2_236();
                case cardIDEnum.EX1_402:
                    return new Sim_EX1_402();
                case cardIDEnum.EX1_506:
                    return new Sim_EX1_506();
                case cardIDEnum.DS1_178:
                    return new Sim_DS1_178();
                case cardIDEnum.EX1_315:
                    return new Sim_EX1_315();
                case cardIDEnum.CS2_094:
                    return new Sim_CS2_094();
                case cardIDEnum.NEW1_040t:
                    return new Sim_NEW1_040t();
                case cardIDEnum.CS2_131:
                    return new Sim_CS2_131();
                case cardIDEnum.EX1_082:
                    return new Sim_EX1_082();
                case cardIDEnum.CS2_093:
                    return new Sim_CS2_093();
                case cardIDEnum.CS2_boar:
                    return new Sim_CS2_boar();
                case cardIDEnum.NEW1_019:
                    return new Sim_NEW1_019();
                case cardIDEnum.EX1_289:
                    return new Sim_EX1_289();
                case cardIDEnum.EX1_025t:
                    return new Sim_EX1_025t();
                case cardIDEnum.EX1_398t:
                    return new Sim_EX1_398t();
                case cardIDEnum.CS2_091:
                    return new Sim_CS2_091();
                case cardIDEnum.EX1_241:
                    return new Sim_EX1_241();
                case cardIDEnum.EX1_085:
                    return new Sim_EX1_085();
                case cardIDEnum.CS2_200:
                    return new Sim_CS2_200();
                case cardIDEnum.CS2_034:
                    return new Sim_CS2_034();
                case cardIDEnum.EX1_583:
                    return new Sim_EX1_583();
                case cardIDEnum.EX1_584:
                    return new Sim_EX1_584();
                case cardIDEnum.EX1_155:
                    return new Sim_EX1_155();
                case cardIDEnum.EX1_622:
                    return new Sim_EX1_622();
                case cardIDEnum.CS2_203:
                    return new Sim_CS2_203();
                case cardIDEnum.EX1_124:
                    return new Sim_EX1_124();
                case cardIDEnum.EX1_379:
                    return new Sim_EX1_379();
                case cardIDEnum.EX1_032:
                    return new Sim_EX1_032();
                case cardIDEnum.EX1_391:
                    return new Sim_EX1_391();
                case cardIDEnum.EX1_366:
                    return new Sim_EX1_366();
                case cardIDEnum.EX1_400:
                    return new Sim_EX1_400();
                case cardIDEnum.EX1_614:
                    return new Sim_EX1_614();
                case cardIDEnum.EX1_561:
                    return new Sim_EX1_561();
                case cardIDEnum.EX1_332:
                    return new Sim_EX1_332();
                case cardIDEnum.HERO_05:
                    return new Sim_HERO_05();
                case cardIDEnum.CS2_065:
                    return new Sim_CS2_065();
                case cardIDEnum.ds1_whelptoken:
                    return new Sim_ds1_whelptoken();
                case cardIDEnum.CS2_032:
                    return new Sim_CS2_032();
                case cardIDEnum.CS2_120:
                    return new Sim_CS2_120();
                case cardIDEnum.EX1_247:
                    return new Sim_EX1_247();
                case cardIDEnum.EX1_154a:
                    return new Sim_EX1_154a();
                case cardIDEnum.EX1_554t:
                    return new Sim_EX1_554t();
                case cardIDEnum.NEW1_026t:
                    return new Sim_NEW1_026t();
                case cardIDEnum.EX1_623:
                    return new Sim_EX1_623();
                case cardIDEnum.EX1_383t:
                    return new Sim_EX1_383t();
                case cardIDEnum.EX1_597:
                    return new Sim_EX1_597();
                case cardIDEnum.EX1_130a:
                    return new Sim_EX1_130a();
                case cardIDEnum.CS2_011:
                    return new Sim_CS2_011();
                case cardIDEnum.EX1_169:
                    return new Sim_EX1_169();
                case cardIDEnum.EX1_tk33:
                    return new Sim_EX1_tk33();
                case cardIDEnum.EX1_250:
                    return new Sim_EX1_250();
                case cardIDEnum.EX1_564:
                    return new Sim_EX1_564();
                case cardIDEnum.EX1_349:
                    return new Sim_EX1_349();
                case cardIDEnum.EX1_102:
                    return new Sim_EX1_102();
                case cardIDEnum.EX1_058:
                    return new Sim_EX1_058();
                case cardIDEnum.EX1_243:
                    return new Sim_EX1_243();
                case cardIDEnum.PRO_001c:
                    return new Sim_PRO_001c();
                case cardIDEnum.EX1_116t:
                    return new Sim_EX1_116t();
                case cardIDEnum.FP1_029:
                    return new Sim_FP1_029();
                case cardIDEnum.CS2_089:
                    return new Sim_CS2_089();
                case cardIDEnum.EX1_248:
                    return new Sim_EX1_248();
                case cardIDEnum.CS2_122:
                    return new Sim_CS2_122();
                case cardIDEnum.EX1_393:
                    return new Sim_EX1_393();
                case cardIDEnum.CS2_232:
                    return new Sim_CS2_232();
                case cardIDEnum.EX1_165b:
                    return new Sim_EX1_165b();
                case cardIDEnum.NEW1_030:
                    return new Sim_NEW1_030();
                case cardIDEnum.CS2_150:
                    return new Sim_CS2_150();
                case cardIDEnum.CS2_152:
                    return new Sim_CS2_152();
                case cardIDEnum.EX1_160t:
                    return new Sim_EX1_160t();
                case cardIDEnum.CS2_127:
                    return new Sim_CS2_127();
                case cardIDEnum.DS1_188:
                    return new Sim_DS1_188();
                case CardDB.cardIDEnum.GVG_001:
                    return new Sim_GVG_001();
                case CardDB.cardIDEnum.GVG_002:
                    return new Sim_GVG_002();
                case CardDB.cardIDEnum.GVG_003:
                    return new Sim_GVG_003();
                case CardDB.cardIDEnum.GVG_004:
                    return new Sim_GVG_004();
                case CardDB.cardIDEnum.GVG_005:
                    return new Sim_GVG_005();
                case CardDB.cardIDEnum.GVG_006:
                    return new Sim_GVG_006();
                case CardDB.cardIDEnum.GVG_007:
                    return new Sim_GVG_007();
                case CardDB.cardIDEnum.GVG_008:
                    return new Sim_GVG_008();
                case CardDB.cardIDEnum.GVG_009:
                    return new Sim_GVG_009();
                case CardDB.cardIDEnum.GVG_010:
                    return new Sim_GVG_010();
                case CardDB.cardIDEnum.GVG_011:
                    return new Sim_GVG_011();
                case CardDB.cardIDEnum.GVG_012:
                    return new Sim_GVG_012();
                case CardDB.cardIDEnum.GVG_013:
                    return new Sim_GVG_013();
                case CardDB.cardIDEnum.GVG_014:
                    return new Sim_GVG_014();
                case CardDB.cardIDEnum.GVG_015:
                    return new Sim_GVG_015();
                case CardDB.cardIDEnum.GVG_016:
                    return new Sim_GVG_016();
                case CardDB.cardIDEnum.GVG_017:
                    return new Sim_GVG_017();
                case CardDB.cardIDEnum.GVG_018:
                    return new Sim_GVG_018();
                case CardDB.cardIDEnum.GVG_019:
                    return new Sim_GVG_019();
                case CardDB.cardIDEnum.GVG_020:
                    return new Sim_GVG_020();
                case CardDB.cardIDEnum.GVG_021:
                    return new Sim_GVG_021();
                case CardDB.cardIDEnum.GVG_022:
                    return new Sim_GVG_022();
                case CardDB.cardIDEnum.GVG_023:
                    return new Sim_GVG_023();
                case CardDB.cardIDEnum.GVG_024:
                    return new Sim_GVG_024();
                case CardDB.cardIDEnum.GVG_025:
                    return new Sim_GVG_025();
                case CardDB.cardIDEnum.GVG_026:
                    return new Sim_GVG_026();
                case CardDB.cardIDEnum.GVG_027:
                    return new Sim_GVG_027();
                case CardDB.cardIDEnum.GVG_028:
                    return new Sim_GVG_028();
                case CardDB.cardIDEnum.GVG_028t:
                    return new Sim_GVG_028t();
                case CardDB.cardIDEnum.GVG_029:
                    return new Sim_GVG_029();
                case CardDB.cardIDEnum.GVG_030:
                    return new Sim_GVG_030();
                case CardDB.cardIDEnum.GVG_030a:
                    return new Sim_GVG_030a();
                case CardDB.cardIDEnum.GVG_030b:
                    return new Sim_GVG_030b();
                case CardDB.cardIDEnum.GVG_031:
                    return new Sim_GVG_031();
                case CardDB.cardIDEnum.GVG_032:
                    return new Sim_GVG_032();
                case CardDB.cardIDEnum.GVG_032a:
                    return new Sim_GVG_032a();
                case CardDB.cardIDEnum.GVG_032b:
                    return new Sim_GVG_032b();
                case CardDB.cardIDEnum.GVG_033:
                    return new Sim_GVG_033();
                case CardDB.cardIDEnum.GVG_034:
                    return new Sim_GVG_034();
                case CardDB.cardIDEnum.GVG_035:
                    return new Sim_GVG_035();
                case CardDB.cardIDEnum.GVG_036:
                    return new Sim_GVG_036();
                case CardDB.cardIDEnum.GVG_037:
                    return new Sim_GVG_037();
                case CardDB.cardIDEnum.GVG_038:
                    return new Sim_GVG_038();
                case CardDB.cardIDEnum.GVG_039:
                    return new Sim_GVG_039();
                case CardDB.cardIDEnum.GVG_040:
                    return new Sim_GVG_040();
                case CardDB.cardIDEnum.GVG_041:
                    return new Sim_GVG_041();
                case CardDB.cardIDEnum.GVG_041a:
                    return new Sim_GVG_041a();
                case CardDB.cardIDEnum.GVG_041b:
                    return new Sim_GVG_041b();
                case CardDB.cardIDEnum.GVG_042:
                    return new Sim_GVG_042();
                case CardDB.cardIDEnum.GVG_043:
                    return new Sim_GVG_043();
                case CardDB.cardIDEnum.GVG_044:
                    return new Sim_GVG_044();
                case CardDB.cardIDEnum.GVG_045:
                    return new Sim_GVG_045();
                case CardDB.cardIDEnum.GVG_045t:
                    return new Sim_GVG_045t();
                case CardDB.cardIDEnum.GVG_046:
                    return new Sim_GVG_046();
                case CardDB.cardIDEnum.GVG_047:
                    return new Sim_GVG_047();
                case CardDB.cardIDEnum.GVG_048:
                    return new Sim_GVG_048();
                case CardDB.cardIDEnum.GVG_049:
                    return new Sim_GVG_049();
                case CardDB.cardIDEnum.GVG_050:
                    return new Sim_GVG_050();
                case CardDB.cardIDEnum.GVG_051:
                    return new Sim_GVG_051();
                case CardDB.cardIDEnum.GVG_052:
                    return new Sim_GVG_052();
                case CardDB.cardIDEnum.GVG_053:
                    return new Sim_GVG_053();
                case CardDB.cardIDEnum.GVG_054:
                    return new Sim_GVG_054();
                case CardDB.cardIDEnum.GVG_055:
                    return new Sim_GVG_055();
                case CardDB.cardIDEnum.GVG_056:
                    return new Sim_GVG_056();
                case CardDB.cardIDEnum.GVG_056t:
                    return new Sim_GVG_056t();
                case CardDB.cardIDEnum.GVG_057:
                    return new Sim_GVG_057();
                case CardDB.cardIDEnum.GVG_058:
                    return new Sim_GVG_058();
                case CardDB.cardIDEnum.GVG_059:
                    return new Sim_GVG_059();
                case CardDB.cardIDEnum.GVG_060:
                    return new Sim_GVG_060();
                case CardDB.cardIDEnum.GVG_061:
                    return new Sim_GVG_061();
                case CardDB.cardIDEnum.GVG_062:
                    return new Sim_GVG_062();
                case CardDB.cardIDEnum.GVG_063:
                    return new Sim_GVG_063();
                case CardDB.cardIDEnum.GVG_064:
                    return new Sim_GVG_064();
                case CardDB.cardIDEnum.GVG_065:
                    return new Sim_GVG_065();
                case CardDB.cardIDEnum.GVG_066:
                    return new Sim_GVG_066();
                case CardDB.cardIDEnum.GVG_067:
                    return new Sim_GVG_067();
                case CardDB.cardIDEnum.GVG_068:
                    return new Sim_GVG_068();
                case CardDB.cardIDEnum.GVG_069:
                    return new Sim_GVG_069();
                case CardDB.cardIDEnum.GVG_070:
                    return new Sim_GVG_070();
                case CardDB.cardIDEnum.GVG_071:
                    return new Sim_GVG_071();
                case CardDB.cardIDEnum.GVG_072:
                    return new Sim_GVG_072();
                case CardDB.cardIDEnum.GVG_073:
                    return new Sim_GVG_073();
                case CardDB.cardIDEnum.GVG_074:
                    return new Sim_GVG_074();
                case CardDB.cardIDEnum.GVG_075:
                    return new Sim_GVG_075();
                case CardDB.cardIDEnum.GVG_076:
                    return new Sim_GVG_076();
                case CardDB.cardIDEnum.GVG_077:
                    return new Sim_GVG_077();
                case CardDB.cardIDEnum.GVG_078:
                    return new Sim_GVG_078();
                case CardDB.cardIDEnum.GVG_079:
                    return new Sim_GVG_079();
                case CardDB.cardIDEnum.GVG_080:
                    return new Sim_GVG_080();
                case CardDB.cardIDEnum.GVG_080t:
                    return new Sim_GVG_080t();
                case CardDB.cardIDEnum.GVG_081:
                    return new Sim_GVG_081();
                case CardDB.cardIDEnum.GVG_082:
                    return new Sim_GVG_082();
                case CardDB.cardIDEnum.GVG_083:
                    return new Sim_GVG_083();
                case CardDB.cardIDEnum.GVG_084:
                    return new Sim_GVG_084();
                case CardDB.cardIDEnum.GVG_085:
                    return new Sim_GVG_085();
                case CardDB.cardIDEnum.GVG_086:
                    return new Sim_GVG_086();
                case CardDB.cardIDEnum.GVG_087:
                    return new Sim_GVG_087();
                case CardDB.cardIDEnum.GVG_088:
                    return new Sim_GVG_088();
                case CardDB.cardIDEnum.GVG_089:
                    return new Sim_GVG_089();
                case CardDB.cardIDEnum.GVG_090:
                    return new Sim_GVG_090();
                case CardDB.cardIDEnum.GVG_091:
                    return new Sim_GVG_091();
                case CardDB.cardIDEnum.GVG_092:
                    return new Sim_GVG_092();
                case CardDB.cardIDEnum.GVG_093:
                    return new Sim_GVG_093();
                case CardDB.cardIDEnum.GVG_094:
                    return new Sim_GVG_094();
                case CardDB.cardIDEnum.GVG_095:
                    return new Sim_GVG_095();
                case CardDB.cardIDEnum.GVG_096:
                    return new Sim_GVG_096();
                case CardDB.cardIDEnum.GVG_097:
                    return new Sim_GVG_097();
                case CardDB.cardIDEnum.GVG_098:
                    return new Sim_GVG_098();
                case CardDB.cardIDEnum.GVG_099:
                    return new Sim_GVG_099();
                case CardDB.cardIDEnum.GVG_100:
                    return new Sim_GVG_100();
                case CardDB.cardIDEnum.GVG_101:
                    return new Sim_GVG_101();
                case CardDB.cardIDEnum.GVG_102:
                    return new Sim_GVG_102();
                case CardDB.cardIDEnum.GVG_103:
                    return new Sim_GVG_103();
                case CardDB.cardIDEnum.GVG_104:
                    return new Sim_GVG_104();
                case CardDB.cardIDEnum.GVG_105:
                    return new Sim_GVG_105();
                case CardDB.cardIDEnum.GVG_106:
                    return new Sim_GVG_106();
                case CardDB.cardIDEnum.GVG_107:
                    return new Sim_GVG_107();
                case CardDB.cardIDEnum.GVG_108:
                    return new Sim_GVG_108();
                case CardDB.cardIDEnum.GVG_109:
                    return new Sim_GVG_109();
                case CardDB.cardIDEnum.GVG_110:
                    return new Sim_GVG_110();
                case CardDB.cardIDEnum.GVG_110t:
                    return new Sim_GVG_110t();
                case CardDB.cardIDEnum.GVG_111:
                    return new Sim_GVG_111();
                case CardDB.cardIDEnum.GVG_111t:
                    return new Sim_GVG_111t();
                case CardDB.cardIDEnum.GVG_112:
                    return new Sim_GVG_112();
                case CardDB.cardIDEnum.GVG_113:
                    return new Sim_GVG_113();
                case CardDB.cardIDEnum.GVG_114:
                    return new Sim_GVG_114();
                case CardDB.cardIDEnum.GVG_115:
                    return new Sim_GVG_115();
                case CardDB.cardIDEnum.GVG_116:
                    return new Sim_GVG_116();
                case CardDB.cardIDEnum.GVG_117:
                    return new Sim_GVG_117();
                case CardDB.cardIDEnum.GVG_118:
                    return new Sim_GVG_118();
                case CardDB.cardIDEnum.GVG_119:
                    return new Sim_GVG_119();
                case CardDB.cardIDEnum.GVG_120:
                    return new Sim_GVG_120();
                case CardDB.cardIDEnum.GVG_121:
                    return new Sim_GVG_121();
                case CardDB.cardIDEnum.GVG_122:
                    return new Sim_GVG_122();
                case CardDB.cardIDEnum.GVG_123:
                    return new Sim_GVG_123();
                case CardDB.cardIDEnum.PART_001:
                    return new Sim_PART_001();
                case CardDB.cardIDEnum.PART_002:
                    return new Sim_PART_002();
                case CardDB.cardIDEnum.PART_003:
                    return new Sim_PART_003();
                case CardDB.cardIDEnum.PART_004:
                    return new Sim_PART_004();
                case CardDB.cardIDEnum.PART_005:
                    return new Sim_PART_005();
                case CardDB.cardIDEnum.PART_006:
                    return new Sim_PART_006();
                case CardDB.cardIDEnum.PART_007:
                    return new Sim_PART_007();
            }

            return new SimTemplate();
        }

        public PenTemplate getPenCard(cardIDEnum id)
        {
            switch (id)
            {
                case cardIDEnum.CS1h_001:
                    return new Pen_CS1h_001();
                case cardIDEnum.CS1_042:
                    return new Pen_CS1_042();
                case cardIDEnum.CS1_112:
                    return new Pen_CS1_112();
                case cardIDEnum.CS1_113:
                    return new Pen_CS1_113();
                case cardIDEnum.CS1_130:
                    return new Pen_CS1_130();
                case cardIDEnum.CS2_003:
                    return new Pen_CS2_003();
                case cardIDEnum.CS2_004:
                    return new Pen_CS2_004();
                case cardIDEnum.CS2_005:
                    return new Pen_CS2_005();
                case cardIDEnum.CS2_007:
                    return new Pen_CS2_007();
                case cardIDEnum.CS2_008:
                    return new Pen_CS2_008();
                case cardIDEnum.CS2_009:
                    return new Pen_CS2_009();
                case cardIDEnum.CS2_011:
                    return new Pen_CS2_011();
                case cardIDEnum.CS2_012:
                    return new Pen_CS2_012();
                case cardIDEnum.CS2_013:
                    return new Pen_CS2_013();
                case cardIDEnum.CS2_013t:
                    return new Pen_CS2_013t();
                case cardIDEnum.CS2_017:
                    return new Pen_CS2_017();
                case cardIDEnum.CS2_022:
                    return new Pen_CS2_022();
                case cardIDEnum.CS2_023:
                    return new Pen_CS2_023();
                case cardIDEnum.CS2_024:
                    return new Pen_CS2_024();
                case cardIDEnum.CS2_025:
                    return new Pen_CS2_025();
                case cardIDEnum.CS2_026:
                    return new Pen_CS2_026();
                case cardIDEnum.CS2_027:
                    return new Pen_CS2_027();
                case cardIDEnum.CS2_029:
                    return new Pen_CS2_029();
                case cardIDEnum.CS2_032:
                    return new Pen_CS2_032();
                case cardIDEnum.CS2_033:
                    return new Pen_CS2_033();
                case cardIDEnum.CS2_034:
                    return new Pen_CS2_034();
                case cardIDEnum.CS2_037:
                    return new Pen_CS2_037();
                case cardIDEnum.CS2_039:
                    return new Pen_CS2_039();
                case cardIDEnum.CS2_041:
                    return new Pen_CS2_041();
                case cardIDEnum.CS2_042:
                    return new Pen_CS2_042();
                case cardIDEnum.CS2_045:
                    return new Pen_CS2_045();
                case cardIDEnum.CS2_046:
                    return new Pen_CS2_046();
                case cardIDEnum.CS2_049:
                    return new Pen_CS2_049();
                case cardIDEnum.CS2_050:
                    return new Pen_CS2_050();
                case cardIDEnum.CS2_051:
                    return new Pen_CS2_051();
                case cardIDEnum.CS2_052:
                    return new Pen_CS2_052();
                case cardIDEnum.CS2_056:
                    return new Pen_CS2_056();
                case cardIDEnum.CS2_057:
                    return new Pen_CS2_057();
                case cardIDEnum.CS2_061:
                    return new Pen_CS2_061();
                case cardIDEnum.CS2_062:
                    return new Pen_CS2_062();
                case cardIDEnum.CS2_063:
                    return new Pen_CS2_063();
                case cardIDEnum.CS2_064:
                    return new Pen_CS2_064();
                case cardIDEnum.CS2_065:
                    return new Pen_CS2_065();
                case cardIDEnum.CS2_072:
                    return new Pen_CS2_072();
                case cardIDEnum.CS2_074:
                    return new Pen_CS2_074();
                case cardIDEnum.CS2_075:
                    return new Pen_CS2_075();
                case cardIDEnum.CS2_076:
                    return new Pen_CS2_076();
                case cardIDEnum.CS2_077:
                    return new Pen_CS2_077();
                case cardIDEnum.CS2_080:
                    return new Pen_CS2_080();
                case cardIDEnum.CS2_082:
                    return new Pen_CS2_082();
                case cardIDEnum.CS2_083b:
                    return new Pen_CS2_083b();
                case cardIDEnum.CS2_084:
                    return new Pen_CS2_084();
                case cardIDEnum.CS2_087:
                    return new Pen_CS2_087();
                case cardIDEnum.CS2_088:
                    return new Pen_CS2_088();
                case cardIDEnum.CS2_089:
                    return new Pen_CS2_089();
                case cardIDEnum.CS2_091:
                    return new Pen_CS2_091();
                case cardIDEnum.CS2_092:
                    return new Pen_CS2_092();
                case cardIDEnum.CS2_093:
                    return new Pen_CS2_093();
                case cardIDEnum.CS2_094:
                    return new Pen_CS2_094();
                case cardIDEnum.CS2_097:
                    return new Pen_CS2_097();
                case cardIDEnum.CS2_101:
                    return new Pen_CS2_101();
                case cardIDEnum.CS2_101t:
                    return new Pen_CS2_101t();
                case cardIDEnum.CS2_102:
                    return new Pen_CS2_102();
                case cardIDEnum.CS2_103:
                    return new Pen_CS2_103();
                case cardIDEnum.CS2_105:
                    return new Pen_CS2_105();
                case cardIDEnum.CS2_106:
                    return new Pen_CS2_106();
                case cardIDEnum.CS2_108:
                    return new Pen_CS2_108();
                case cardIDEnum.CS2_112:
                    return new Pen_CS2_112();
                case cardIDEnum.CS2_114:
                    return new Pen_CS2_114();
                case cardIDEnum.CS2_118:
                    return new Pen_CS2_118();
                case cardIDEnum.CS2_119:
                    return new Pen_CS2_119();
                case cardIDEnum.CS2_120:
                    return new Pen_CS2_120();
                case cardIDEnum.CS2_121:
                    return new Pen_CS2_121();
                case cardIDEnum.CS2_122:
                    return new Pen_CS2_122();
                case cardIDEnum.CS2_124:
                    return new Pen_CS2_124();
                case cardIDEnum.CS2_125:
                    return new Pen_CS2_125();
                case cardIDEnum.CS2_127:
                    return new Pen_CS2_127();
                case cardIDEnum.CS2_131:
                    return new Pen_CS2_131();
                case cardIDEnum.CS2_141:
                    return new Pen_CS2_141();
                case cardIDEnum.CS2_142:
                    return new Pen_CS2_142();
                case cardIDEnum.CS2_147:
                    return new Pen_CS2_147();
                case cardIDEnum.CS2_150:
                    return new Pen_CS2_150();
                case cardIDEnum.CS2_155:
                    return new Pen_CS2_155();
                case cardIDEnum.CS2_162:
                    return new Pen_CS2_162();
                case cardIDEnum.CS2_168:
                    return new Pen_CS2_168();
                case cardIDEnum.CS2_171:
                    return new Pen_CS2_171();
                case cardIDEnum.CS2_172:
                    return new Pen_CS2_172();
                case cardIDEnum.CS2_173:
                    return new Pen_CS2_173();
                case cardIDEnum.CS2_179:
                    return new Pen_CS2_179();
                case cardIDEnum.CS2_182:
                    return new Pen_CS2_182();
                case cardIDEnum.CS2_186:
                    return new Pen_CS2_186();
                case cardIDEnum.CS2_187:
                    return new Pen_CS2_187();
                case cardIDEnum.CS2_189:
                    return new Pen_CS2_189();
                case cardIDEnum.CS2_196:
                    return new Pen_CS2_196();
                case cardIDEnum.CS2_197:
                    return new Pen_CS2_197();
                case cardIDEnum.CS2_200:
                    return new Pen_CS2_200();
                case cardIDEnum.CS2_201:
                    return new Pen_CS2_201();
                case cardIDEnum.CS2_213:
                    return new Pen_CS2_213();
                case cardIDEnum.CS2_222:
                    return new Pen_CS2_222();
                case cardIDEnum.CS2_226:
                    return new Pen_CS2_226();
                case cardIDEnum.CS2_232:
                    return new Pen_CS2_232();
                case cardIDEnum.CS2_234:
                    return new Pen_CS2_234();
                case cardIDEnum.CS2_235:
                    return new Pen_CS2_235();
                case cardIDEnum.CS2_236:
                    return new Pen_CS2_236();
                case cardIDEnum.CS2_237:
                    return new Pen_CS2_237();
                case cardIDEnum.CS2_boar:
                    return new Pen_CS2_boar();
                case cardIDEnum.CS2_mirror:
                    return new Pen_CS2_mirror();
                case cardIDEnum.CS2_tk1:
                    return new Pen_CS2_tk1();
                case cardIDEnum.DS1h_292:
                    return new Pen_DS1h_292();
                case cardIDEnum.DS1_055:
                    return new Pen_DS1_055();
                case cardIDEnum.DS1_070:
                    return new Pen_DS1_070();
                case cardIDEnum.DS1_175:
                    return new Pen_DS1_175();
                case cardIDEnum.DS1_178:
                    return new Pen_DS1_178();
                case cardIDEnum.DS1_183:
                    return new Pen_DS1_183();
                case cardIDEnum.DS1_184:
                    return new Pen_DS1_184();
                case cardIDEnum.DS1_185:
                    return new Pen_DS1_185();
                case cardIDEnum.DS1_233:
                    return new Pen_DS1_233();
                case cardIDEnum.EX1_011:
                    return new Pen_EX1_011();
                case cardIDEnum.EX1_015:
                    return new Pen_EX1_015();
                case cardIDEnum.EX1_019:
                    return new Pen_EX1_019();
                case cardIDEnum.EX1_025:
                    return new Pen_EX1_025();
                case cardIDEnum.EX1_025t:
                    return new Pen_EX1_025t();
                case cardIDEnum.EX1_066:
                    return new Pen_EX1_066();
                case cardIDEnum.EX1_084:
                    return new Pen_EX1_084();
                case cardIDEnum.EX1_129:
                    return new Pen_EX1_129();
                case cardIDEnum.EX1_169:
                    return new Pen_EX1_169();
                case cardIDEnum.EX1_173:
                    return new Pen_EX1_173();
                case cardIDEnum.EX1_244:
                    return new Pen_EX1_244();
                case cardIDEnum.EX1_246:
                    return new Pen_EX1_246();
                case cardIDEnum.EX1_277:
                    return new Pen_EX1_277();
                case cardIDEnum.EX1_278:
                    return new Pen_EX1_278();
                case cardIDEnum.EX1_302:
                    return new Pen_EX1_302();
                case cardIDEnum.EX1_306:
                    return new Pen_EX1_306();
                case cardIDEnum.EX1_308:
                    return new Pen_EX1_308();
                case cardIDEnum.EX1_360:
                    return new Pen_EX1_360();
                case cardIDEnum.EX1_371:
                    return new Pen_EX1_371();
                case cardIDEnum.EX1_399:
                    return new Pen_EX1_399();
                case cardIDEnum.EX1_400:
                    return new Pen_EX1_400();
                case cardIDEnum.EX1_506:
                    return new Pen_EX1_506();
                case cardIDEnum.EX1_506a:
                    return new Pen_EX1_506a();
                case cardIDEnum.EX1_508:
                    return new Pen_EX1_508();
                case cardIDEnum.EX1_539:
                    return new Pen_EX1_539();
                case cardIDEnum.EX1_565:
                    return new Pen_EX1_565();
                case cardIDEnum.EX1_581:
                    return new Pen_EX1_581();
                case cardIDEnum.EX1_582:
                    return new Pen_EX1_582();
                case cardIDEnum.EX1_587:
                    return new Pen_EX1_587();
                case cardIDEnum.EX1_593:
                    return new Pen_EX1_593();
                case cardIDEnum.EX1_606:
                    return new Pen_EX1_606();
                case cardIDEnum.EX1_622:
                    return new Pen_EX1_622();
                case cardIDEnum.GAME_002:
                    return new Pen_GAME_002();
                case cardIDEnum.GAME_005:
                    return new Pen_GAME_005();
                case cardIDEnum.GAME_006:
                    return new Pen_GAME_006();
                case cardIDEnum.HERO_01:
                    return new Pen_HERO_01();
                case cardIDEnum.HERO_02:
                    return new Pen_HERO_02();
                case cardIDEnum.HERO_03:
                    return new Pen_HERO_03();
                case cardIDEnum.HERO_04:
                    return new Pen_HERO_04();
                case cardIDEnum.HERO_05:
                    return new Pen_HERO_05();
                case cardIDEnum.HERO_06:
                    return new Pen_HERO_06();
                case cardIDEnum.HERO_07:
                    return new Pen_HERO_07();
                case cardIDEnum.HERO_08:
                    return new Pen_HERO_08();
                case cardIDEnum.HERO_09:
                    return new Pen_HERO_09();
                case cardIDEnum.hexfrog:
                    return new Pen_hexfrog();
                case cardIDEnum.NEW1_003:
                    return new Pen_NEW1_003();
                case cardIDEnum.NEW1_004:
                    return new Pen_NEW1_004();
                case cardIDEnum.NEW1_009:
                    return new Pen_NEW1_009();
                case cardIDEnum.NEW1_011:
                    return new Pen_NEW1_011();
                case cardIDEnum.NEW1_031:
                    return new Pen_NEW1_031();
                case cardIDEnum.NEW1_032:
                    return new Pen_NEW1_032();
                case cardIDEnum.NEW1_033:
                    return new Pen_NEW1_033();
                case cardIDEnum.NEW1_034:
                    return new Pen_NEW1_034();
                case cardIDEnum.skele11:
                    return new Pen_skele11();
                case cardIDEnum.CS1_069:
                    return new Pen_CS1_069();
                case cardIDEnum.CS1_129:
                    return new Pen_CS1_129();
                case cardIDEnum.CS2_028:
                    return new Pen_CS2_028();
                case cardIDEnum.CS2_031:
                    return new Pen_CS2_031();
                case cardIDEnum.CS2_038:
                    return new Pen_CS2_038();
                case cardIDEnum.CS2_053:
                    return new Pen_CS2_053();
                case cardIDEnum.CS2_059:
                    return new Pen_CS2_059();
                case cardIDEnum.CS2_073:
                    return new Pen_CS2_073();
                case cardIDEnum.CS2_104:
                    return new Pen_CS2_104();
                case cardIDEnum.CS2_117:
                    return new Pen_CS2_117();
                case cardIDEnum.CS2_146:
                    return new Pen_CS2_146();
                case cardIDEnum.CS2_151:
                    return new Pen_CS2_151();
                case cardIDEnum.CS2_152:
                    return new Pen_CS2_152();
                case cardIDEnum.CS2_161:
                    return new Pen_CS2_161();
                case cardIDEnum.CS2_169:
                    return new Pen_CS2_169();
                case cardIDEnum.CS2_181:
                    return new Pen_CS2_181();
                case cardIDEnum.CS2_188:
                    return new Pen_CS2_188();
                case cardIDEnum.CS2_203:
                    return new Pen_CS2_203();
                case cardIDEnum.CS2_221:
                    return new Pen_CS2_221();
                case cardIDEnum.CS2_227:
                    return new Pen_CS2_227();
                case cardIDEnum.CS2_231:
                    return new Pen_CS2_231();
                case cardIDEnum.CS2_233:
                    return new Pen_CS2_233();
                case cardIDEnum.DREAM_01:
                    return new Pen_DREAM_01();
                case cardIDEnum.DREAM_02:
                    return new Pen_DREAM_02();
                case cardIDEnum.DREAM_03:
                    return new Pen_DREAM_03();
                case cardIDEnum.DREAM_04:
                    return new Pen_DREAM_04();
                case cardIDEnum.DREAM_05:
                    return new Pen_DREAM_05();
                case cardIDEnum.DS1_188:
                    return new Pen_DS1_188();
                case cardIDEnum.ds1_whelptoken:
                    return new Pen_ds1_whelptoken();
                case cardIDEnum.EX1_001:
                    return new Pen_EX1_001();
                case cardIDEnum.EX1_002:
                    return new Pen_EX1_002();
                case cardIDEnum.EX1_004:
                    return new Pen_EX1_004();
                case cardIDEnum.EX1_005:
                    return new Pen_EX1_005();
                case cardIDEnum.EX1_006:
                    return new Pen_EX1_006();
                case cardIDEnum.EX1_007:
                    return new Pen_EX1_007();
                case cardIDEnum.EX1_008:
                    return new Pen_EX1_008();
                case cardIDEnum.EX1_009:
                    return new Pen_EX1_009();
                case cardIDEnum.EX1_010:
                    return new Pen_EX1_010();
                case cardIDEnum.EX1_012:
                    return new Pen_EX1_012();
                case cardIDEnum.EX1_014:
                    return new Pen_EX1_014();
                case cardIDEnum.EX1_014t:
                    return new Pen_EX1_014t();
                case cardIDEnum.EX1_016:
                    return new Pen_EX1_016();
                case cardIDEnum.EX1_017:
                    return new Pen_EX1_017();
                case cardIDEnum.EX1_020:
                    return new Pen_EX1_020();
                case cardIDEnum.EX1_021:
                    return new Pen_EX1_021();
                case cardIDEnum.EX1_023:
                    return new Pen_EX1_023();
                case cardIDEnum.EX1_028:
                    return new Pen_EX1_028();
                case cardIDEnum.EX1_029:
                    return new Pen_EX1_029();
                case cardIDEnum.EX1_032:
                    return new Pen_EX1_032();
                case cardIDEnum.EX1_033:
                    return new Pen_EX1_033();
                case cardIDEnum.EX1_043:
                    return new Pen_EX1_043();
                case cardIDEnum.EX1_044:
                    return new Pen_EX1_044();
                case cardIDEnum.EX1_045:
                    return new Pen_EX1_045();
                case cardIDEnum.EX1_046:
                    return new Pen_EX1_046();
                case cardIDEnum.EX1_048:
                    return new Pen_EX1_048();
                case cardIDEnum.EX1_049:
                    return new Pen_EX1_049();
                case cardIDEnum.EX1_050:
                    return new Pen_EX1_050();
                case cardIDEnum.EX1_055:
                    return new Pen_EX1_055();
                case cardIDEnum.EX1_057:
                    return new Pen_EX1_057();
                case cardIDEnum.EX1_058:
                    return new Pen_EX1_058();
                case cardIDEnum.EX1_059:
                    return new Pen_EX1_059();
                case cardIDEnum.EX1_067:
                    return new Pen_EX1_067();
                case cardIDEnum.EX1_076:
                    return new Pen_EX1_076();
                case cardIDEnum.EX1_080:
                    return new Pen_EX1_080();
                case cardIDEnum.EX1_082:
                    return new Pen_EX1_082();
                case cardIDEnum.EX1_083:
                    return new Pen_EX1_083();
                case cardIDEnum.EX1_085:
                    return new Pen_EX1_085();
                case cardIDEnum.EX1_089:
                    return new Pen_EX1_089();
                case cardIDEnum.EX1_091:
                    return new Pen_EX1_091();
                case cardIDEnum.EX1_093:
                    return new Pen_EX1_093();
                case cardIDEnum.EX1_095:
                    return new Pen_EX1_095();
                case cardIDEnum.EX1_096:
                    return new Pen_EX1_096();
                case cardIDEnum.EX1_097:
                    return new Pen_EX1_097();
                case cardIDEnum.EX1_100:
                    return new Pen_EX1_100();
                case cardIDEnum.EX1_102:
                    return new Pen_EX1_102();
                case cardIDEnum.EX1_103:
                    return new Pen_EX1_103();
                case cardIDEnum.EX1_105:
                    return new Pen_EX1_105();
                case cardIDEnum.EX1_110:
                    return new Pen_EX1_110();
                case cardIDEnum.EX1_110t:
                    return new Pen_EX1_110t();
                case cardIDEnum.EX1_116:
                    return new Pen_EX1_116();
                case cardIDEnum.EX1_116t:
                    return new Pen_EX1_116t();
                case cardIDEnum.EX1_124:
                    return new Pen_EX1_124();
                case cardIDEnum.EX1_126:
                    return new Pen_EX1_126();
                case cardIDEnum.EX1_128:
                    return new Pen_EX1_128();
                case cardIDEnum.EX1_130:
                    return new Pen_EX1_130();
                case cardIDEnum.EX1_130a:
                    return new Pen_EX1_130a();
                case cardIDEnum.EX1_131:
                    return new Pen_EX1_131();
                case cardIDEnum.EX1_131t:
                    return new Pen_EX1_131t();
                case cardIDEnum.EX1_132:
                    return new Pen_EX1_132();
                case cardIDEnum.EX1_133:
                    return new Pen_EX1_133();
                case cardIDEnum.EX1_134:
                    return new Pen_EX1_134();
                case cardIDEnum.EX1_136:
                    return new Pen_EX1_136();
                case cardIDEnum.EX1_137:
                    return new Pen_EX1_137();
                case cardIDEnum.EX1_144:
                    return new Pen_EX1_144();
                case cardIDEnum.EX1_145:
                    return new Pen_EX1_145();
                case cardIDEnum.EX1_154:
                    return new Pen_EX1_154();
                case cardIDEnum.EX1_154a:
                    return new Pen_EX1_154a();
                case cardIDEnum.EX1_154b:
                    return new Pen_EX1_154b();
                case cardIDEnum.EX1_155:
                    return new Pen_EX1_155();
                case cardIDEnum.EX1_155a:
                    return new Pen_EX1_155a();
                case cardIDEnum.EX1_155b:
                    return new Pen_EX1_155b();
                case cardIDEnum.EX1_158:
                    return new Pen_EX1_158();
                case cardIDEnum.EX1_158t:
                    return new Pen_EX1_158t();
                case cardIDEnum.EX1_160:
                    return new Pen_EX1_160();
                case cardIDEnum.EX1_160a:
                    return new Pen_EX1_160a();
                case cardIDEnum.EX1_160b:
                    return new Pen_EX1_160b();
                case cardIDEnum.EX1_160t:
                    return new Pen_EX1_160t();
                case cardIDEnum.EX1_161:
                    return new Pen_EX1_161();
                case cardIDEnum.EX1_162:
                    return new Pen_EX1_162();
                case cardIDEnum.EX1_164:
                    return new Pen_EX1_164();
                case cardIDEnum.EX1_164a:
                    return new Pen_EX1_164a();
                case cardIDEnum.EX1_164b:
                    return new Pen_EX1_164b();
                case cardIDEnum.EX1_165:
                    return new Pen_EX1_165();
                case cardIDEnum.EX1_165a:
                    return new Pen_EX1_165a();
                case cardIDEnum.EX1_165b:
                    return new Pen_EX1_165b();
                case cardIDEnum.EX1_165t1:
                    return new Pen_EX1_165t1();
                case cardIDEnum.EX1_165t2:
                    return new Pen_EX1_165t2();
                case cardIDEnum.EX1_166:
                    return new Pen_EX1_166();
                case cardIDEnum.EX1_166a:
                    return new Pen_EX1_166a();
                case cardIDEnum.EX1_166b:
                    return new Pen_EX1_166b();
                case cardIDEnum.EX1_170:
                    return new Pen_EX1_170();
                case cardIDEnum.EX1_178:
                    return new Pen_EX1_178();
                case cardIDEnum.EX1_178a:
                    return new Pen_EX1_178a();
                case cardIDEnum.EX1_178b:
                    return new Pen_EX1_178b();
                case cardIDEnum.EX1_238:
                    return new Pen_EX1_238();
                case cardIDEnum.EX1_241:
                    return new Pen_EX1_241();
                case cardIDEnum.EX1_243:
                    return new Pen_EX1_243();
                case cardIDEnum.EX1_245:
                    return new Pen_EX1_245();
                case cardIDEnum.EX1_247:
                    return new Pen_EX1_247();
                case cardIDEnum.EX1_248:
                    return new Pen_EX1_248();
                case cardIDEnum.EX1_249:
                    return new Pen_EX1_249();
                case cardIDEnum.EX1_250:
                    return new Pen_EX1_250();
                case cardIDEnum.EX1_251:
                    return new Pen_EX1_251();
                case cardIDEnum.EX1_258:
                    return new Pen_EX1_258();
                case cardIDEnum.EX1_259:
                    return new Pen_EX1_259();
                case cardIDEnum.EX1_274:
                    return new Pen_EX1_274();
                case cardIDEnum.EX1_275:
                    return new Pen_EX1_275();
                case cardIDEnum.EX1_279:
                    return new Pen_EX1_279();
                case cardIDEnum.EX1_283:
                    return new Pen_EX1_283();
                case cardIDEnum.EX1_284:
                    return new Pen_EX1_284();
                case cardIDEnum.EX1_287:
                    return new Pen_EX1_287();
                case cardIDEnum.EX1_289:
                    return new Pen_EX1_289();
                case cardIDEnum.EX1_294:
                    return new Pen_EX1_294();
                case cardIDEnum.EX1_295:
                    return new Pen_EX1_295();
                case cardIDEnum.EX1_298:
                    return new Pen_EX1_298();
                case cardIDEnum.EX1_301:
                    return new Pen_EX1_301();
                case cardIDEnum.EX1_303:
                    return new Pen_EX1_303();
                case cardIDEnum.EX1_304:
                    return new Pen_EX1_304();
                case cardIDEnum.EX1_309:
                    return new Pen_EX1_309();
                case cardIDEnum.EX1_310:
                    return new Pen_EX1_310();
                case cardIDEnum.EX1_312:
                    return new Pen_EX1_312();
                case cardIDEnum.EX1_313:
                    return new Pen_EX1_313();
                case cardIDEnum.EX1_315:
                    return new Pen_EX1_315();
                case cardIDEnum.EX1_316:
                    return new Pen_EX1_316();
                case cardIDEnum.EX1_317:
                    return new Pen_EX1_317();
                case cardIDEnum.EX1_317t:
                    return new Pen_EX1_317t();
                case cardIDEnum.EX1_319:
                    return new Pen_EX1_319();
                case cardIDEnum.EX1_320:
                    return new Pen_EX1_320();
                case cardIDEnum.EX1_323:
                    return new Pen_EX1_323();
                case cardIDEnum.EX1_323h:
                    return new Pen_EX1_323h();
                case cardIDEnum.EX1_323w:
                    return new Pen_EX1_323w();
                case cardIDEnum.EX1_332:
                    return new Pen_EX1_332();
                case cardIDEnum.EX1_334:
                    return new Pen_EX1_334();
                case cardIDEnum.EX1_335:
                    return new Pen_EX1_335();
                case cardIDEnum.EX1_339:
                    return new Pen_EX1_339();
                case cardIDEnum.EX1_341:
                    return new Pen_EX1_341();
                case cardIDEnum.EX1_345:
                    return new Pen_EX1_345();
                case cardIDEnum.EX1_345t:
                    return new Pen_EX1_345t();
                case cardIDEnum.EX1_349:
                    return new Pen_EX1_349();
                case cardIDEnum.EX1_350:
                    return new Pen_EX1_350();
                case cardIDEnum.EX1_354:
                    return new Pen_EX1_354();
                case cardIDEnum.EX1_355:
                    return new Pen_EX1_355();
                case cardIDEnum.EX1_362:
                    return new Pen_EX1_362();
                case cardIDEnum.EX1_363:
                    return new Pen_EX1_363();
                case cardIDEnum.EX1_365:
                    return new Pen_EX1_365();
                case cardIDEnum.EX1_366:
                    return new Pen_EX1_366();
                case cardIDEnum.EX1_379:
                    return new Pen_EX1_379();
                case cardIDEnum.EX1_382:
                    return new Pen_EX1_382();
                case cardIDEnum.EX1_383:
                    return new Pen_EX1_383();
                case cardIDEnum.EX1_383t:
                    return new Pen_EX1_383t();
                case cardIDEnum.EX1_384:
                    return new Pen_EX1_384();
                case cardIDEnum.EX1_390:
                    return new Pen_EX1_390();
                case cardIDEnum.EX1_391:
                    return new Pen_EX1_391();
                case cardIDEnum.EX1_392:
                    return new Pen_EX1_392();
                case cardIDEnum.EX1_393:
                    return new Pen_EX1_393();
                case cardIDEnum.EX1_396:
                    return new Pen_EX1_396();
                case cardIDEnum.EX1_398:
                    return new Pen_EX1_398();
                case cardIDEnum.EX1_398t:
                    return new Pen_EX1_398t();
                case cardIDEnum.EX1_402:
                    return new Pen_EX1_402();
                case cardIDEnum.EX1_405:
                    return new Pen_EX1_405();
                case cardIDEnum.EX1_407:
                    return new Pen_EX1_407();
                case cardIDEnum.EX1_408:
                    return new Pen_EX1_408();
                case cardIDEnum.EX1_409:
                    return new Pen_EX1_409();
                case cardIDEnum.EX1_409t:
                    return new Pen_EX1_409t();
                case cardIDEnum.EX1_410:
                    return new Pen_EX1_410();
                case cardIDEnum.EX1_411:
                    return new Pen_EX1_411();
                case cardIDEnum.EX1_412:
                    return new Pen_EX1_412();
                case cardIDEnum.EX1_414:
                    return new Pen_EX1_414();
                case cardIDEnum.EX1_507:
                    return new Pen_EX1_507();
                case cardIDEnum.EX1_509:
                    return new Pen_EX1_509();
                case cardIDEnum.EX1_522:
                    return new Pen_EX1_522();
                case cardIDEnum.EX1_531:
                    return new Pen_EX1_531();
                case cardIDEnum.EX1_533:
                    return new Pen_EX1_533();
                case cardIDEnum.EX1_534:
                    return new Pen_EX1_534();
                case cardIDEnum.EX1_534t:
                    return new Pen_EX1_534t();
                case cardIDEnum.EX1_536:
                    return new Pen_EX1_536();
                case cardIDEnum.EX1_537:
                    return new Pen_EX1_537();
                case cardIDEnum.EX1_538:
                    return new Pen_EX1_538();
                case cardIDEnum.EX1_538t:
                    return new Pen_EX1_538t();
                case cardIDEnum.EX1_543:
                    return new Pen_EX1_543();
                case cardIDEnum.EX1_544:
                    return new Pen_EX1_544();
                case cardIDEnum.EX1_549:
                    return new Pen_EX1_549();
                case cardIDEnum.EX1_554:
                    return new Pen_EX1_554();
                case cardIDEnum.EX1_554t:
                    return new Pen_EX1_554t();
                case cardIDEnum.EX1_556:
                    return new Pen_EX1_556();
                case cardIDEnum.EX1_557:
                    return new Pen_EX1_557();
                case cardIDEnum.EX1_558:
                    return new Pen_EX1_558();
                case cardIDEnum.EX1_559:
                    return new Pen_EX1_559();
                case cardIDEnum.EX1_560:
                    return new Pen_EX1_560();
                case cardIDEnum.EX1_561:
                    return new Pen_EX1_561();
                case cardIDEnum.EX1_562:
                    return new Pen_EX1_562();
                case cardIDEnum.EX1_563:
                    return new Pen_EX1_563();
                case cardIDEnum.EX1_564:
                    return new Pen_EX1_564();
                case cardIDEnum.EX1_567:
                    return new Pen_EX1_567();
                case cardIDEnum.EX1_570:
                    return new Pen_EX1_570();
                case cardIDEnum.EX1_571:
                    return new Pen_EX1_571();
                case cardIDEnum.EX1_572:
                    return new Pen_EX1_572();
                case cardIDEnum.EX1_573:
                    return new Pen_EX1_573();
                case cardIDEnum.EX1_573a:
                    return new Pen_EX1_573a();
                case cardIDEnum.EX1_573b:
                    return new Pen_EX1_573b();
                case cardIDEnum.EX1_573t:
                    return new Pen_EX1_573t();
                case cardIDEnum.EX1_575:
                    return new Pen_EX1_575();
                case cardIDEnum.EX1_577:
                    return new Pen_EX1_577();
                case cardIDEnum.EX1_578:
                    return new Pen_EX1_578();
                case cardIDEnum.EX1_583:
                    return new Pen_EX1_583();
                case cardIDEnum.EX1_584:
                    return new Pen_EX1_584();
                case cardIDEnum.EX1_586:
                    return new Pen_EX1_586();
                case cardIDEnum.EX1_590:
                    return new Pen_EX1_590();
                case cardIDEnum.EX1_591:
                    return new Pen_EX1_591();
                case cardIDEnum.EX1_594:
                    return new Pen_EX1_594();
                case cardIDEnum.EX1_595:
                    return new Pen_EX1_595();
                case cardIDEnum.EX1_596:
                    return new Pen_EX1_596();
                case cardIDEnum.EX1_597:
                    return new Pen_EX1_597();
                case cardIDEnum.EX1_598:
                    return new Pen_EX1_598();
                case cardIDEnum.EX1_603:
                    return new Pen_EX1_603();
                case cardIDEnum.EX1_604:
                    return new Pen_EX1_604();
                case cardIDEnum.EX1_607:
                    return new Pen_EX1_607();
                case cardIDEnum.EX1_608:
                    return new Pen_EX1_608();
                case cardIDEnum.EX1_609:
                    return new Pen_EX1_609();
                case cardIDEnum.EX1_610:
                    return new Pen_EX1_610();
                case cardIDEnum.EX1_611:
                    return new Pen_EX1_611();
                case cardIDEnum.EX1_612:
                    return new Pen_EX1_612();
                case cardIDEnum.EX1_613:
                    return new Pen_EX1_613();
                case cardIDEnum.EX1_614:
                    return new Pen_EX1_614();
                case cardIDEnum.EX1_614t:
                    return new Pen_EX1_614t();
                case cardIDEnum.EX1_616:
                    return new Pen_EX1_616();
                case cardIDEnum.EX1_617:
                    return new Pen_EX1_617();
                case cardIDEnum.EX1_619:
                    return new Pen_EX1_619();
                case cardIDEnum.EX1_620:
                    return new Pen_EX1_620();
                case cardIDEnum.EX1_621:
                    return new Pen_EX1_621();
                case cardIDEnum.EX1_623:
                    return new Pen_EX1_623();
                case cardIDEnum.EX1_624:
                    return new Pen_EX1_624();
                case cardIDEnum.EX1_625:
                    return new Pen_EX1_625();
                case cardIDEnum.EX1_625t:
                    return new Pen_EX1_625t();
                case cardIDEnum.EX1_625t2:
                    return new Pen_EX1_625t2();
                case cardIDEnum.EX1_626:
                    return new Pen_EX1_626();
                case cardIDEnum.EX1_finkle:
                    return new Pen_EX1_finkle();
                case cardIDEnum.EX1_tk11:
                    return new Pen_EX1_tk11();
                case cardIDEnum.EX1_tk28:
                    return new Pen_EX1_tk28();
                case cardIDEnum.EX1_tk29:
                    return new Pen_EX1_tk29();
                case cardIDEnum.EX1_tk33:
                    return new Pen_EX1_tk33();
                case cardIDEnum.EX1_tk34:
                    return new Pen_EX1_tk34();
                case cardIDEnum.EX1_tk9:
                    return new Pen_EX1_tk9();
                case cardIDEnum.NEW1_005:
                    return new Pen_NEW1_005();
                case cardIDEnum.NEW1_007:
                    return new Pen_NEW1_007();
                case cardIDEnum.NEW1_007a:
                    return new Pen_NEW1_007a();
                case cardIDEnum.NEW1_007b:
                    return new Pen_NEW1_007b();
                case cardIDEnum.NEW1_008:
                    return new Pen_NEW1_008();
                case cardIDEnum.NEW1_008a:
                    return new Pen_NEW1_008a();
                case cardIDEnum.NEW1_008b:
                    return new Pen_NEW1_008b();
                case cardIDEnum.NEW1_010:
                    return new Pen_NEW1_010();
                case cardIDEnum.NEW1_012:
                    return new Pen_NEW1_012();
                case cardIDEnum.NEW1_014:
                    return new Pen_NEW1_014();
                case cardIDEnum.NEW1_017:
                    return new Pen_NEW1_017();
                case cardIDEnum.NEW1_018:
                    return new Pen_NEW1_018();
                case cardIDEnum.NEW1_019:
                    return new Pen_NEW1_019();
                case cardIDEnum.NEW1_020:
                    return new Pen_NEW1_020();
                case cardIDEnum.NEW1_021:
                    return new Pen_NEW1_021();
                case cardIDEnum.NEW1_022:
                    return new Pen_NEW1_022();
                case cardIDEnum.NEW1_023:
                    return new Pen_NEW1_023();
                case cardIDEnum.NEW1_024:
                    return new Pen_NEW1_024();
                case cardIDEnum.NEW1_025:
                    return new Pen_NEW1_025();
                case cardIDEnum.NEW1_026:
                    return new Pen_NEW1_026();
                case cardIDEnum.NEW1_026t:
                    return new Pen_NEW1_026t();
                case cardIDEnum.NEW1_027:
                    return new Pen_NEW1_027();
                case cardIDEnum.NEW1_029:
                    return new Pen_NEW1_029();
                case cardIDEnum.NEW1_030:
                    return new Pen_NEW1_030();
                case cardIDEnum.NEW1_036:
                    return new Pen_NEW1_036();
                case cardIDEnum.NEW1_037:
                    return new Pen_NEW1_037();
                case cardIDEnum.NEW1_038:
                    return new Pen_NEW1_038();
                case cardIDEnum.NEW1_040:
                    return new Pen_NEW1_040();
                case cardIDEnum.NEW1_040t:
                    return new Pen_NEW1_040t();
                case cardIDEnum.NEW1_041:
                    return new Pen_NEW1_041();
                case cardIDEnum.skele21:
                    return new Pen_skele21();
                case cardIDEnum.tt_004:
                    return new Pen_tt_004();
                case cardIDEnum.tt_010:
                    return new Pen_tt_010();
                case cardIDEnum.tt_010a:
                    return new Pen_tt_010a();
                case cardIDEnum.HERO_01a:
                    return new Pen_HERO_01a();
                case cardIDEnum.HERO_05a:
                    return new Pen_HERO_05a();
                case cardIDEnum.HERO_08a:
                    return new Pen_HERO_08a();
                case cardIDEnum.EX1_062:
                    return new Pen_EX1_062();
                case cardIDEnum.NEW1_016:
                    return new Pen_NEW1_016();
                case cardIDEnum.EX1_112:
                    return new Pen_EX1_112();
                case cardIDEnum.Mekka1:
                    return new Pen_Mekka1();
                case cardIDEnum.Mekka2:
                    return new Pen_Mekka2();
                case cardIDEnum.Mekka3:
                    return new Pen_Mekka3();
                case cardIDEnum.Mekka4:
                    return new Pen_Mekka4();
                case cardIDEnum.Mekka4t:
                    return new Pen_Mekka4t();
                case cardIDEnum.PRO_001:
                    return new Pen_PRO_001();
                case cardIDEnum.PRO_001a:
                    return new Pen_PRO_001a();
                case cardIDEnum.PRO_001at:
                    return new Pen_PRO_001at();
                case cardIDEnum.PRO_001b:
                    return new Pen_PRO_001b();
                case cardIDEnum.PRO_001c:
                    return new Pen_PRO_001c();
                case cardIDEnum.FP1_001:
                    return new Pen_FP1_001();
                case cardIDEnum.FP1_002:
                    return new Pen_FP1_002();
                case cardIDEnum.FP1_002t:
                    return new Pen_FP1_002t();
                case cardIDEnum.FP1_003:
                    return new Pen_FP1_003();
                case cardIDEnum.FP1_004:
                    return new Pen_FP1_004();
                case cardIDEnum.FP1_005:
                    return new Pen_FP1_005();
                case cardIDEnum.FP1_006:
                    return new Pen_FP1_006();
                case cardIDEnum.FP1_007:
                    return new Pen_FP1_007();
                case cardIDEnum.FP1_007t:
                    return new Pen_FP1_007t();
                case cardIDEnum.FP1_008:
                    return new Pen_FP1_008();
                case cardIDEnum.FP1_009:
                    return new Pen_FP1_009();
                case cardIDEnum.FP1_010:
                    return new Pen_FP1_010();
                case cardIDEnum.FP1_011:
                    return new Pen_FP1_011();
                case cardIDEnum.FP1_012:
                    return new Pen_FP1_012();
                case cardIDEnum.FP1_012t:
                    return new Pen_FP1_012t();
                case cardIDEnum.FP1_013:
                    return new Pen_FP1_013();
                case cardIDEnum.FP1_014:
                    return new Pen_FP1_014();
                case cardIDEnum.FP1_014t:
                    return new Pen_FP1_014t();
                case cardIDEnum.FP1_015:
                    return new Pen_FP1_015();
                case cardIDEnum.FP1_016:
                    return new Pen_FP1_016();
                case cardIDEnum.FP1_017:
                    return new Pen_FP1_017();
                case cardIDEnum.FP1_018:
                    return new Pen_FP1_018();
                case cardIDEnum.FP1_019:
                    return new Pen_FP1_019();
                case cardIDEnum.FP1_019t:
                    return new Pen_FP1_019t();
                case cardIDEnum.FP1_020:
                    return new Pen_FP1_020();
                case cardIDEnum.FP1_021:
                    return new Pen_FP1_021();
                case cardIDEnum.FP1_022:
                    return new Pen_FP1_022();
                case cardIDEnum.FP1_023:
                    return new Pen_FP1_023();
                case cardIDEnum.FP1_024:
                    return new Pen_FP1_024();
                case cardIDEnum.FP1_025:
                    return new Pen_FP1_025();
                case cardIDEnum.FP1_026:
                    return new Pen_FP1_026();
                case cardIDEnum.FP1_027:
                    return new Pen_FP1_027();
                case cardIDEnum.FP1_028:
                    return new Pen_FP1_028();
                case cardIDEnum.FP1_029:
                    return new Pen_FP1_029();
                case cardIDEnum.FP1_030:
                    return new Pen_FP1_030();
                case cardIDEnum.FP1_031:
                    return new Pen_FP1_031();
                case cardIDEnum.GVG_001:
                    return new Pen_GVG_001();
                case cardIDEnum.GVG_002:
                    return new Pen_GVG_002();
                case cardIDEnum.GVG_003:
                    return new Pen_GVG_003();
                case cardIDEnum.GVG_004:
                    return new Pen_GVG_004();
                case cardIDEnum.GVG_005:
                    return new Pen_GVG_005();
                case cardIDEnum.GVG_006:
                    return new Pen_GVG_006();
                case cardIDEnum.GVG_007:
                    return new Pen_GVG_007();
                case cardIDEnum.GVG_008:
                    return new Pen_GVG_008();
                case cardIDEnum.GVG_009:
                    return new Pen_GVG_009();
                case cardIDEnum.GVG_010:
                    return new Pen_GVG_010();
                case cardIDEnum.GVG_011:
                    return new Pen_GVG_011();
                case cardIDEnum.GVG_012:
                    return new Pen_GVG_012();
                case cardIDEnum.GVG_013:
                    return new Pen_GVG_013();
                case cardIDEnum.GVG_014:
                    return new Pen_GVG_014();
                case cardIDEnum.GVG_015:
                    return new Pen_GVG_015();
                case cardIDEnum.GVG_016:
                    return new Pen_GVG_016();
                case cardIDEnum.GVG_017:
                    return new Pen_GVG_017();
                case cardIDEnum.GVG_018:
                    return new Pen_GVG_018();
                case cardIDEnum.GVG_019:
                    return new Pen_GVG_019();
                case cardIDEnum.GVG_020:
                    return new Pen_GVG_020();
                case cardIDEnum.GVG_021:
                    return new Pen_GVG_021();
                case cardIDEnum.GVG_022:
                    return new Pen_GVG_022();
                case cardIDEnum.GVG_023:
                    return new Pen_GVG_023();
                case cardIDEnum.GVG_024:
                    return new Pen_GVG_024();
                case cardIDEnum.GVG_025:
                    return new Pen_GVG_025();
                case cardIDEnum.GVG_026:
                    return new Pen_GVG_026();
                case cardIDEnum.GVG_027:
                    return new Pen_GVG_027();
                case cardIDEnum.GVG_028:
                    return new Pen_GVG_028();
                case cardIDEnum.GVG_028t:
                    return new Pen_GVG_028t();
                case cardIDEnum.GVG_029:
                    return new Pen_GVG_029();
                case cardIDEnum.GVG_030:
                    return new Pen_GVG_030();
                case cardIDEnum.GVG_030a:
                    return new Pen_GVG_030a();
                case cardIDEnum.GVG_030b:
                    return new Pen_GVG_030b();
                case cardIDEnum.GVG_031:
                    return new Pen_GVG_031();
                case cardIDEnum.GVG_032:
                    return new Pen_GVG_032();
                case cardIDEnum.GVG_032a:
                    return new Pen_GVG_032a();
                case cardIDEnum.GVG_032b:
                    return new Pen_GVG_032b();
                case cardIDEnum.GVG_033:
                    return new Pen_GVG_033();
                case cardIDEnum.GVG_034:
                    return new Pen_GVG_034();
                case cardIDEnum.GVG_035:
                    return new Pen_GVG_035();
                case cardIDEnum.GVG_036:
                    return new Pen_GVG_036();
                case cardIDEnum.GVG_037:
                    return new Pen_GVG_037();
                case cardIDEnum.GVG_038:
                    return new Pen_GVG_038();
                case cardIDEnum.GVG_039:
                    return new Pen_GVG_039();
                case cardIDEnum.GVG_040:
                    return new Pen_GVG_040();
                case cardIDEnum.GVG_041:
                    return new Pen_GVG_041();
                case cardIDEnum.GVG_041a:
                    return new Pen_GVG_041a();
                case cardIDEnum.GVG_041b:
                    return new Pen_GVG_041b();
                case cardIDEnum.GVG_042:
                    return new Pen_GVG_042();
                case cardIDEnum.GVG_043:
                    return new Pen_GVG_043();
                case cardIDEnum.GVG_044:
                    return new Pen_GVG_044();
                case cardIDEnum.GVG_045:
                    return new Pen_GVG_045();
                case cardIDEnum.GVG_045t:
                    return new Pen_GVG_045t();
                case cardIDEnum.GVG_046:
                    return new Pen_GVG_046();
                case cardIDEnum.GVG_047:
                    return new Pen_GVG_047();
                case cardIDEnum.GVG_048:
                    return new Pen_GVG_048();
                case cardIDEnum.GVG_049:
                    return new Pen_GVG_049();
                case cardIDEnum.GVG_050:
                    return new Pen_GVG_050();
                case cardIDEnum.GVG_051:
                    return new Pen_GVG_051();
                case cardIDEnum.GVG_052:
                    return new Pen_GVG_052();
                case cardIDEnum.GVG_053:
                    return new Pen_GVG_053();
                case cardIDEnum.GVG_054:
                    return new Pen_GVG_054();
                case cardIDEnum.GVG_055:
                    return new Pen_GVG_055();
                case cardIDEnum.GVG_056:
                    return new Pen_GVG_056();
                case cardIDEnum.GVG_056t:
                    return new Pen_GVG_056t();
                case cardIDEnum.GVG_057:
                    return new Pen_GVG_057();
                case cardIDEnum.GVG_058:
                    return new Pen_GVG_058();
                case cardIDEnum.GVG_059:
                    return new Pen_GVG_059();
                case cardIDEnum.GVG_060:
                    return new Pen_GVG_060();
                case cardIDEnum.GVG_061:
                    return new Pen_GVG_061();
                case cardIDEnum.GVG_062:
                    return new Pen_GVG_062();
                case cardIDEnum.GVG_063:
                    return new Pen_GVG_063();
                case cardIDEnum.GVG_064:
                    return new Pen_GVG_064();
                case cardIDEnum.GVG_065:
                    return new Pen_GVG_065();
                case cardIDEnum.GVG_066:
                    return new Pen_GVG_066();
                case cardIDEnum.GVG_067:
                    return new Pen_GVG_067();
                case cardIDEnum.GVG_068:
                    return new Pen_GVG_068();
                case cardIDEnum.GVG_069:
                    return new Pen_GVG_069();
                case cardIDEnum.GVG_070:
                    return new Pen_GVG_070();
                case cardIDEnum.GVG_071:
                    return new Pen_GVG_071();
                case cardIDEnum.GVG_072:
                    return new Pen_GVG_072();
                case cardIDEnum.GVG_073:
                    return new Pen_GVG_073();
                case cardIDEnum.GVG_074:
                    return new Pen_GVG_074();
                case cardIDEnum.GVG_075:
                    return new Pen_GVG_075();
                case cardIDEnum.GVG_076:
                    return new Pen_GVG_076();
                case cardIDEnum.GVG_077:
                    return new Pen_GVG_077();
                case cardIDEnum.GVG_078:
                    return new Pen_GVG_078();
                case cardIDEnum.GVG_079:
                    return new Pen_GVG_079();
                case cardIDEnum.GVG_080:
                    return new Pen_GVG_080();
                case cardIDEnum.GVG_080t:
                    return new Pen_GVG_080t();
                case cardIDEnum.GVG_081:
                    return new Pen_GVG_081();
                case cardIDEnum.GVG_082:
                    return new Pen_GVG_082();
                case cardIDEnum.GVG_083:
                    return new Pen_GVG_083();
                case cardIDEnum.GVG_084:
                    return new Pen_GVG_084();
                case cardIDEnum.GVG_085:
                    return new Pen_GVG_085();
                case cardIDEnum.GVG_086:
                    return new Pen_GVG_086();
                case cardIDEnum.GVG_087:
                    return new Pen_GVG_087();
                case cardIDEnum.GVG_088:
                    return new Pen_GVG_088();
                case cardIDEnum.GVG_089:
                    return new Pen_GVG_089();
                case cardIDEnum.GVG_090:
                    return new Pen_GVG_090();
                case cardIDEnum.GVG_091:
                    return new Pen_GVG_091();
                case cardIDEnum.GVG_092:
                    return new Pen_GVG_092();
                case cardIDEnum.GVG_092t:
                    return new Pen_GVG_092t();
                case cardIDEnum.GVG_093:
                    return new Pen_GVG_093();
                case cardIDEnum.GVG_094:
                    return new Pen_GVG_094();
                case cardIDEnum.GVG_095:
                    return new Pen_GVG_095();
                case cardIDEnum.GVG_096:
                    return new Pen_GVG_096();
                case cardIDEnum.GVG_097:
                    return new Pen_GVG_097();
                case cardIDEnum.GVG_098:
                    return new Pen_GVG_098();
                case cardIDEnum.GVG_099:
                    return new Pen_GVG_099();
                case cardIDEnum.GVG_100:
                    return new Pen_GVG_100();
                case cardIDEnum.GVG_101:
                    return new Pen_GVG_101();
                case cardIDEnum.GVG_102:
                    return new Pen_GVG_102();
                case cardIDEnum.GVG_103:
                    return new Pen_GVG_103();
                case cardIDEnum.GVG_104:
                    return new Pen_GVG_104();
                case cardIDEnum.GVG_105:
                    return new Pen_GVG_105();
                case cardIDEnum.GVG_106:
                    return new Pen_GVG_106();
                case cardIDEnum.GVG_107:
                    return new Pen_GVG_107();
                case cardIDEnum.GVG_108:
                    return new Pen_GVG_108();
                case cardIDEnum.GVG_109:
                    return new Pen_GVG_109();
                case cardIDEnum.GVG_110:
                    return new Pen_GVG_110();
                case cardIDEnum.GVG_110t:
                    return new Pen_GVG_110t();
                case cardIDEnum.GVG_111:
                    return new Pen_GVG_111();
                case cardIDEnum.GVG_111t:
                    return new Pen_GVG_111t();
                case cardIDEnum.GVG_112:
                    return new Pen_GVG_112();
                case cardIDEnum.GVG_113:
                    return new Pen_GVG_113();
                case cardIDEnum.GVG_114:
                    return new Pen_GVG_114();
                case cardIDEnum.GVG_115:
                    return new Pen_GVG_115();
                case cardIDEnum.GVG_116:
                    return new Pen_GVG_116();
                case cardIDEnum.GVG_117:
                    return new Pen_GVG_117();
                case cardIDEnum.GVG_118:
                    return new Pen_GVG_118();
                case cardIDEnum.GVG_119:
                    return new Pen_GVG_119();
                case cardIDEnum.GVG_120:
                    return new Pen_GVG_120();
                case cardIDEnum.GVG_121:
                    return new Pen_GVG_121();
                case cardIDEnum.GVG_122:
                    return new Pen_GVG_122();
                case cardIDEnum.GVG_123:
                    return new Pen_GVG_123();
                case cardIDEnum.PART_001:
                    return new Pen_PART_001();
                case cardIDEnum.PART_002:
                    return new Pen_PART_002();
                case cardIDEnum.PART_003:
                    return new Pen_PART_003();
                case cardIDEnum.PART_004:
                    return new Pen_PART_004();
                case cardIDEnum.PART_005:
                    return new Pen_PART_005();
                case cardIDEnum.PART_006:
                    return new Pen_PART_006();
                case cardIDEnum.PART_007:
                    return new Pen_PART_007();
                case cardIDEnum.AT_001:
                    return new Pen_AT_001();
                case cardIDEnum.AT_002:
                    return new Pen_AT_002();
                case cardIDEnum.AT_003:
                    return new Pen_AT_003();
                case cardIDEnum.AT_004:
                    return new Pen_AT_004();
                case cardIDEnum.AT_005:
                    return new Pen_AT_005();
                case cardIDEnum.AT_005t:
                    return new Pen_AT_005t();
                case cardIDEnum.AT_006:
                    return new Pen_AT_006();
                case cardIDEnum.AT_007:
                    return new Pen_AT_007();
                case cardIDEnum.AT_008:
                    return new Pen_AT_008();
                case cardIDEnum.AT_009:
                    return new Pen_AT_009();
                case cardIDEnum.AT_010:
                    return new Pen_AT_010();
                case cardIDEnum.AT_011:
                    return new Pen_AT_011();
                case cardIDEnum.AT_012:
                    return new Pen_AT_012();
                case cardIDEnum.AT_013:
                    return new Pen_AT_013();
                case cardIDEnum.AT_014:
                    return new Pen_AT_014();
                case cardIDEnum.AT_015:
                    return new Pen_AT_015();
                case cardIDEnum.AT_016:
                    return new Pen_AT_016();
                case cardIDEnum.AT_017:
                    return new Pen_AT_017();
                case cardIDEnum.AT_018:
                    return new Pen_AT_018();
                case cardIDEnum.AT_019:
                    return new Pen_AT_019();
                case cardIDEnum.AT_020:
                    return new Pen_AT_020();
                case cardIDEnum.AT_021:
                    return new Pen_AT_021();
                case cardIDEnum.AT_022:
                    return new Pen_AT_022();
                case cardIDEnum.AT_023:
                    return new Pen_AT_023();
                case cardIDEnum.AT_024:
                    return new Pen_AT_024();
                case cardIDEnum.AT_025:
                    return new Pen_AT_025();
                case cardIDEnum.AT_026:
                    return new Pen_AT_026();
                case cardIDEnum.AT_027:
                    return new Pen_AT_027();
                case cardIDEnum.AT_028:
                    return new Pen_AT_028();
                case cardIDEnum.AT_029:
                    return new Pen_AT_029();
                case cardIDEnum.AT_030:
                    return new Pen_AT_030();
                case cardIDEnum.AT_031:
                    return new Pen_AT_031();
                case cardIDEnum.AT_032:
                    return new Pen_AT_032();
                case cardIDEnum.AT_033:
                    return new Pen_AT_033();
                case cardIDEnum.AT_034:
                    return new Pen_AT_034();
                case cardIDEnum.AT_035:
                    return new Pen_AT_035();
                case cardIDEnum.AT_035t:
                    return new Pen_AT_035t();
                case cardIDEnum.AT_036:
                    return new Pen_AT_036();
                case cardIDEnum.AT_036t:
                    return new Pen_AT_036t();
                case cardIDEnum.AT_037:
                    return new Pen_AT_037();
                case cardIDEnum.AT_037a:
                    return new Pen_AT_037a();
                case cardIDEnum.AT_037b:
                    return new Pen_AT_037b();
                case cardIDEnum.AT_037t:
                    return new Pen_AT_037t();
                case cardIDEnum.AT_038:
                    return new Pen_AT_038();
                case cardIDEnum.AT_039:
                    return new Pen_AT_039();
                case cardIDEnum.AT_040:
                    return new Pen_AT_040();
                case cardIDEnum.AT_041:
                    return new Pen_AT_041();
                case cardIDEnum.AT_042:
                    return new Pen_AT_042();
                case cardIDEnum.AT_042a:
                    return new Pen_AT_042a();
                case cardIDEnum.AT_042b:
                    return new Pen_AT_042b();
                case cardIDEnum.AT_042t:
                    return new Pen_AT_042t();
                case cardIDEnum.AT_042t2:
                    return new Pen_AT_042t2();
                case cardIDEnum.AT_043:
                    return new Pen_AT_043();
                case cardIDEnum.AT_044:
                    return new Pen_AT_044();
                case cardIDEnum.AT_045:
                    return new Pen_AT_045();
                case cardIDEnum.AT_046:
                    return new Pen_AT_046();
                case cardIDEnum.AT_047:
                    return new Pen_AT_047();
                case cardIDEnum.AT_048:
                    return new Pen_AT_048();
                case cardIDEnum.AT_049:
                    return new Pen_AT_049();
                case cardIDEnum.AT_050:
                    return new Pen_AT_050();
                case cardIDEnum.AT_050t:
                    return new Pen_AT_050t();
                case cardIDEnum.AT_051:
                    return new Pen_AT_051();
                case cardIDEnum.AT_052:
                    return new Pen_AT_052();
                case cardIDEnum.AT_053:
                    return new Pen_AT_053();
                case cardIDEnum.AT_054:
                    return new Pen_AT_054();
                case cardIDEnum.AT_055:
                    return new Pen_AT_055();
                case cardIDEnum.AT_056:
                    return new Pen_AT_056();
                case cardIDEnum.AT_057:
                    return new Pen_AT_057();
                case cardIDEnum.AT_058:
                    return new Pen_AT_058();
                case cardIDEnum.AT_059:
                    return new Pen_AT_059();
                case cardIDEnum.AT_060:
                    return new Pen_AT_060();
                case cardIDEnum.AT_061:
                    return new Pen_AT_061();
                case cardIDEnum.AT_062:
                    return new Pen_AT_062();
                case cardIDEnum.AT_063:
                    return new Pen_AT_063();
                case cardIDEnum.AT_063t:
                    return new Pen_AT_063t();
                case cardIDEnum.AT_064:
                    return new Pen_AT_064();
                case cardIDEnum.AT_065:
                    return new Pen_AT_065();
                case cardIDEnum.AT_066:
                    return new Pen_AT_066();
                case cardIDEnum.AT_067:
                    return new Pen_AT_067();
                case cardIDEnum.AT_068:
                    return new Pen_AT_068();
                case cardIDEnum.AT_069:
                    return new Pen_AT_069();
                case cardIDEnum.AT_070:
                    return new Pen_AT_070();
                case cardIDEnum.AT_071:
                    return new Pen_AT_071();
                case cardIDEnum.AT_072:
                    return new Pen_AT_072();
                case cardIDEnum.AT_073:
                    return new Pen_AT_073();
                case cardIDEnum.AT_074:
                    return new Pen_AT_074();
                case cardIDEnum.AT_075:
                    return new Pen_AT_075();
                case cardIDEnum.AT_076:
                    return new Pen_AT_076();
                case cardIDEnum.AT_077:
                    return new Pen_AT_077();
                case cardIDEnum.AT_078:
                    return new Pen_AT_078();
                case cardIDEnum.AT_079:
                    return new Pen_AT_079();
                case cardIDEnum.AT_080:
                    return new Pen_AT_080();
                case cardIDEnum.AT_081:
                    return new Pen_AT_081();
                case cardIDEnum.AT_082:
                    return new Pen_AT_082();
                case cardIDEnum.AT_083:
                    return new Pen_AT_083();
                case cardIDEnum.AT_084:
                    return new Pen_AT_084();
                case cardIDEnum.AT_085:
                    return new Pen_AT_085();
                case cardIDEnum.AT_086:
                    return new Pen_AT_086();
                case cardIDEnum.AT_087:
                    return new Pen_AT_087();
                case cardIDEnum.AT_088:
                    return new Pen_AT_088();
                case cardIDEnum.AT_089:
                    return new Pen_AT_089();
                case cardIDEnum.AT_090:
                    return new Pen_AT_090();
                case cardIDEnum.AT_091:
                    return new Pen_AT_091();
                case cardIDEnum.AT_092:
                    return new Pen_AT_092();
                case cardIDEnum.AT_093:
                    return new Pen_AT_093();
                case cardIDEnum.AT_094:
                    return new Pen_AT_094();
                case cardIDEnum.AT_095:
                    return new Pen_AT_095();
                case cardIDEnum.AT_096:
                    return new Pen_AT_096();
                case cardIDEnum.AT_097:
                    return new Pen_AT_097();
                case cardIDEnum.AT_098:
                    return new Pen_AT_098();
                case cardIDEnum.AT_099:
                    return new Pen_AT_099();
                case cardIDEnum.AT_099t:
                    return new Pen_AT_099t();
                case cardIDEnum.AT_100:
                    return new Pen_AT_100();
                case cardIDEnum.AT_101:
                    return new Pen_AT_101();
                case cardIDEnum.AT_102:
                    return new Pen_AT_102();
                case cardIDEnum.AT_103:
                    return new Pen_AT_103();
                case cardIDEnum.AT_104:
                    return new Pen_AT_104();
                case cardIDEnum.AT_105:
                    return new Pen_AT_105();
                case cardIDEnum.AT_106:
                    return new Pen_AT_106();
                case cardIDEnum.AT_108:
                    return new Pen_AT_108();
                case cardIDEnum.AT_109:
                    return new Pen_AT_109();
                case cardIDEnum.AT_110:
                    return new Pen_AT_110();
                case cardIDEnum.AT_111:
                    return new Pen_AT_111();
                case cardIDEnum.AT_112:
                    return new Pen_AT_112();
                case cardIDEnum.AT_113:
                    return new Pen_AT_113();
                case cardIDEnum.AT_114:
                    return new Pen_AT_114();
                case cardIDEnum.AT_115:
                    return new Pen_AT_115();
                case cardIDEnum.AT_116:
                    return new Pen_AT_116();
                case cardIDEnum.AT_117:
                    return new Pen_AT_117();
                case cardIDEnum.AT_118:
                    return new Pen_AT_118();
                case cardIDEnum.AT_119:
                    return new Pen_AT_119();
                case cardIDEnum.AT_120:
                    return new Pen_AT_120();
                case cardIDEnum.AT_121:
                    return new Pen_AT_121();
                case cardIDEnum.AT_122:
                    return new Pen_AT_122();
                case cardIDEnum.AT_123:
                    return new Pen_AT_123();
                case cardIDEnum.AT_124:
                    return new Pen_AT_124();
                case cardIDEnum.AT_125:
                    return new Pen_AT_125();
                case cardIDEnum.AT_127:
                    return new Pen_AT_127();
                case cardIDEnum.AT_128:
                    return new Pen_AT_128();
                case cardIDEnum.AT_129:
                    return new Pen_AT_129();
                case cardIDEnum.AT_130:
                    return new Pen_AT_130();
                case cardIDEnum.AT_131:
                    return new Pen_AT_131();
                case cardIDEnum.AT_132:
                    return new Pen_AT_132();
                case cardIDEnum.AT_132_DRUID:
                    return new Pen_AT_132_DRUID();
                case cardIDEnum.AT_132_HUNTER:
                    return new Pen_AT_132_HUNTER();
                case cardIDEnum.AT_132_MAGE:
                    return new Pen_AT_132_MAGE();
                case cardIDEnum.AT_132_PALADIN:
                    return new Pen_AT_132_PALADIN();
                case cardIDEnum.AT_132_PRIEST:
                    return new Pen_AT_132_PRIEST();
                case cardIDEnum.AT_132_ROGUE:
                    return new Pen_AT_132_ROGUE();
                case cardIDEnum.AT_132_ROGUEt:
                    return new Pen_AT_132_ROGUEt();
                case cardIDEnum.AT_132_SHAMAN:
                    return new Pen_AT_132_SHAMAN();
                case cardIDEnum.AT_132_SHAMANa:
                    return new Pen_AT_132_SHAMANa();
                case cardIDEnum.AT_132_SHAMANb:
                    return new Pen_AT_132_SHAMANb();
                case cardIDEnum.AT_132_SHAMANc:
                    return new Pen_AT_132_SHAMANc();
                case cardIDEnum.AT_132_SHAMANd:
                    return new Pen_AT_132_SHAMANd();
                case cardIDEnum.AT_132_WARLOCK:
                    return new Pen_AT_132_WARLOCK();
                case cardIDEnum.AT_132_WARRIOR:
                    return new Pen_AT_132_WARRIOR();
                case cardIDEnum.AT_133:
                    return new Pen_AT_133();

                case cardIDEnum.LOE_002:
                    return new Pen_LOE_002();
                case cardIDEnum.LOE_002t:
                    return new Pen_LOE_002t();
                case cardIDEnum.LOE_003:
                    return new Pen_LOE_003();
                case cardIDEnum.LOE_006:
                    return new Pen_LOE_006();
                case cardIDEnum.LOE_007:
                    return new Pen_LOE_007();
                case cardIDEnum.LOE_007t:
                    return new Pen_LOE_007t();
                case cardIDEnum.LOE_009:
                    return new Pen_LOE_009();
                case cardIDEnum.LOE_009t:
                    return new Pen_LOE_009t();
                case cardIDEnum.LOE_010:
                    return new Pen_LOE_010();
                case cardIDEnum.LOE_011:
                    return new Pen_LOE_011();
                case cardIDEnum.LOE_012:
                    return new Pen_LOE_012();
                case cardIDEnum.LOE_016:
                    return new Pen_LOE_016();
                case cardIDEnum.LOE_017:
                    return new Pen_LOE_017();
                case cardIDEnum.LOE_018:
                    return new Pen_LOE_018();
                case cardIDEnum.LOE_019:
                    return new Pen_LOE_019();
                case cardIDEnum.LOE_019t:
                    return new Pen_LOE_019t();
                case cardIDEnum.LOE_019t2:
                    return new Pen_LOE_019t2();
                case cardIDEnum.LOE_020:
                    return new Pen_LOE_020();
                case cardIDEnum.LOE_021:
                    return new Pen_LOE_021();
                case cardIDEnum.LOE_022:
                    return new Pen_LOE_022();
                case cardIDEnum.LOE_023:
                    return new Pen_LOE_023();
                case cardIDEnum.LOE_026:
                    return new Pen_LOE_026();
                case cardIDEnum.LOE_027:
                    return new Pen_LOE_027();
                case cardIDEnum.LOE_029:
                    return new Pen_LOE_029();
                case cardIDEnum.LOE_038:
                    return new Pen_LOE_038();
                case cardIDEnum.LOE_039:
                    return new Pen_LOE_039();
                case cardIDEnum.LOE_046:
                    return new Pen_LOE_046();
                case cardIDEnum.LOE_047:
                    return new Pen_LOE_047();
                case cardIDEnum.LOE_050:
                    return new Pen_LOE_050();
                case cardIDEnum.LOE_051:
                    return new Pen_LOE_051();
                case cardIDEnum.LOE_053:
                    return new Pen_LOE_053();
                case cardIDEnum.LOE_061:
                    return new Pen_LOE_061();
                case cardIDEnum.LOE_073:
                    return new Pen_LOE_073();
                case cardIDEnum.LOE_076:
                    return new Pen_LOE_076();
                case cardIDEnum.LOE_077:
                    return new Pen_LOE_077();
                case cardIDEnum.LOE_079:
                    return new Pen_LOE_079();
                case cardIDEnum.LOE_086:
                    return new Pen_LOE_086();
                case cardIDEnum.LOE_089:
                    return new Pen_LOE_089();
                case cardIDEnum.LOE_089t:
                    return new Pen_LOE_089t();
                case cardIDEnum.LOE_089t2:
                    return new Pen_LOE_089t2();
                case cardIDEnum.LOE_089t3:
                    return new Pen_LOE_089t3();
                case cardIDEnum.LOE_092:
                    return new Pen_LOE_092();
                case cardIDEnum.LOE_104:
                    return new Pen_LOE_104();
                case cardIDEnum.LOE_105:
                    return new Pen_LOE_105();
                case cardIDEnum.LOE_107:
                    return new Pen_LOE_107();
                case cardIDEnum.LOE_110:
                    return new Pen_LOE_110();
                case cardIDEnum.LOE_110t:
                    return new Pen_LOE_110t();
                case cardIDEnum.LOE_111:
                    return new Pen_LOE_111();
                case cardIDEnum.LOE_113:
                    return new Pen_LOE_113();
                case cardIDEnum.LOE_115:
                    return new Pen_LOE_115();
                case cardIDEnum.LOE_115a:
                    return new Pen_LOE_115a();
                case cardIDEnum.LOE_115b:
                    return new Pen_LOE_115b();
                case cardIDEnum.LOE_116:
                    return new Pen_LOE_116();
                case cardIDEnum.LOE_118:
                    return new Pen_LOE_118();
                case cardIDEnum.LOE_119:
                    return new Pen_LOE_119();
                case cardIDEnum.PlaceholderCard:
                    return new Pen_PlaceholderCard();
            }

            return new PenTemplate();
        }

        private void setAdditionalData()
        {
            PenalityManager pen = PenalityManager.Instance;

            foreach (Card c in this.cardlist)
            {
                if (pen.cardDrawBattleCryDatabase.ContainsKey(c.name))
                {
                    c.isCarddraw = pen.cardDrawBattleCryDatabase[c.name];
                }

                if (pen.DamageTargetSpecialDatabase.ContainsKey(c.name))
                {
                    c.damagesTargetWithSpecial = true;
                }

                if (pen.DamageTargetDatabase.ContainsKey(c.name))
                {
                    c.damagesTarget = true;
                }

                if (pen.priorityTargets.ContainsKey(c.name))
                {
                    c.targetPriority = pen.priorityTargets[c.name];
                }

                if (pen.specialMinions.ContainsKey(c.name))
                {
                    c.isSpecialMinion = true;
                }
            }
        }

    }

}