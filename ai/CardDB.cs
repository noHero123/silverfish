using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HREngine.Bots
{
    public struct targett
    {
        public int target ;
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
            XXX_040,
            NAX5_01H,
            CS2_188o,
            NAX6_02H,
            NEW1_007b,
            NAX6_02e,
            TU4c_003,
            XXX_024,
            EX1_613,
            NAX8_01,
            EX1_295o,
            CS2_059o,
            EX1_133,
            NEW1_018,
            NAX15_03t,
            EX1_012,
            EX1_178a,
            CS2_231,
            EX1_019e,
            CRED_12,
            CS2_179,
            CS2_045e,
            EX1_244,
            EX1_178b,
            XXX_030,
            NAX8_05,
            EX1_573b,
            TU4d_001,
            NEW1_007a,
            NAX12_02H,
            EX1_345t,
            FP1_007t,
            EX1_025,
            EX1_396,
            NAX9_03,
            NEW1_017,
            NEW1_008a,
            EX1_587e,
            EX1_533,
            EX1_522,
            NAX11_04,
            NEW1_026,
            EX1_398,
            NAX4_04,
            EX1_007,
            CS1_112,
            CRED_17,
            NEW1_036,
            NAX3_03,
            EX1_355e,
            EX1_258,
            HERO_01,
            XXX_009,
            NAX6_01H,
            NAX12_04e,
            CS2_087,
            DREAM_05,
            NEW1_036e,
            CS2_092,
            CS2_022,
            EX1_046,
            XXX_005,
            PRO_001b,
            XXX_022,
            PRO_001a,
            NAX6_04,
            NAX7_05,
            CS2_103,
            NEW1_041,
            EX1_360,
            FP1_023,
            NEW1_038,
            CS2_009,
            NAX10_01H,
            EX1_010,
            CS2_024,
            NAX9_05,
            EX1_565,
            CS2_076,
            FP1_004,
            CS2_046e,
            CS2_162,
            EX1_110t,
            CS2_104e,
            CS2_181,
            EX1_309,
            EX1_354,
            NAX10_02H,
            NAX7_04H,
            TU4f_001,
            XXX_018,
            EX1_023,
            XXX_048,
            XXX_049,
            NEW1_034,
            CS2_003,
            HERO_06,
            CS2_201,
            EX1_508,
            EX1_259,
            EX1_341,
            DREAM_05e,
            CRED_09,
            EX1_103,
            FP1_021,
            EX1_411,
            NAX1_04,
            CS2_053,
            CS2_182,
            CS2_008,
            CS2_233,
            EX1_626,
            EX1_059,
            EX1_334,
            EX1_619,
            NEW1_032,
            EX1_158t,
            EX1_006,
            NEW1_031,
            NAX10_03,
            DREAM_04,
            NAX1h_01,
            CS2_022e,
            EX1_611e,
            EX1_004,
            EX1_014te,
            FP1_005e,
            NAX12_03e,
            EX1_095,
            NEW1_007,
            EX1_275,
            EX1_245,
            EX1_383,
            FP1_016,
            EX1_016t,
            CS2_125,
            EX1_137,
            EX1_178ae,
            DS1_185,
            FP1_010,
            EX1_598,
            NAX9_07,
            EX1_304,
            EX1_302,
            XXX_017,
            CS2_011o,
            EX1_614t,
            TU4a_006,
            Mekka3e,
            CS2_108,
            CS2_046,
            EX1_014t,
            NEW1_005,
            EX1_062,
            EX1_366e,
            Mekka1,
            XXX_007,
            tt_010a,
            CS2_017o,
            CS2_072,
            EX1_tk28,
            EX1_604o,
            FP1_014,
            EX1_084e,
            NAX3_01H,
            NAX2_01,
            EX1_409t,
            CRED_07,
            NAX3_02H,
            TU4e_002,
            EX1_507,
            EX1_144,
            CS2_038,
            EX1_093,
            CS2_080,
            CS1_129e,
            XXX_013,
            EX1_005,
            EX1_382,
            NAX13_02e,
            FP1_020e,
            EX1_603e,
            CS2_028,
            TU4f_002,
            EX1_538,
            GAME_003e,
            DREAM_02,
            EX1_581,
            NAX15_01H,
            EX1_131t,
            CS2_147,
            CS1_113,
            CS2_161,
            CS2_031,
            EX1_166b,
            EX1_066,
            TU4c_007,
            EX1_355,
            EX1_507e,
            EX1_534,
            EX1_162,
            TU4a_004,
            EX1_363,
            EX1_164a,
            CS2_188,
            EX1_016,
            NAX6_03t,
            EX1_tk31,
            EX1_603,
            EX1_238,
            EX1_166,
            DS1h_292,
            DS1_183,
            NAX15_03n,
            NAX8_02H,
            NAX7_01H,
            NAX9_02H,
            CRED_11,
            XXX_019,
            EX1_076,
            EX1_048,
            CS2_038e,
            FP1_026,
            CS2_074,
            FP1_027,
            EX1_323w,
            EX1_129,
            NEW1_024o,
            NAX11_02,
            EX1_405,
            EX1_317,
            EX1_606,
            EX1_590e,
            XXX_044,
            CS2_074e,
            TU4a_005,
            FP1_006,
            EX1_258e,
            TU4f_004o,
            NEW1_008,
            CS2_119,
            NEW1_017e,
            EX1_334e,
            TU4e_001,
            CS2_121,
            CS1h_001,
            EX1_tk34,
            NEW1_020,
            CS2_196,
            EX1_312,
            NAX1_01,
            FP1_022,
            EX1_160b,
            EX1_563,
            XXX_039,
            FP1_031,
            CS2_087e,
            EX1_613e,
            NAX9_02,
            NEW1_029,
            CS1_129,
            HERO_03,
            Mekka4t,
            EX1_158,
            XXX_010,
            NEW1_025,
            FP1_012t,
            EX1_083,
            EX1_295,
            EX1_407,
            NEW1_004,
            FP1_019,
            PRO_001at,
            NAX13_03e,
            EX1_625t,
            EX1_014,
            CRED_04,
            NAX12_01H,
            CS2_097,
            EX1_558,
            XXX_047,
            EX1_tk29,
            CS2_186,
            EX1_084,
            NEW1_012,
            FP1_014t,
            NAX1_03,
            EX1_623e,
            EX1_578,
            CS2_073e2,
            CS2_221,
            EX1_019,
            NAX15_04a,
            FP1_019t,
            EX1_132,
            EX1_284,
            EX1_105,
            NEW1_011,
            NAX9_07e,
            EX1_017,
            EX1_249,
            EX1_162o,
            FP1_002t,
            NAX3_02,
            EX1_313,
            EX1_549o,
            EX1_091o,
            CS2_084e,
            EX1_155b,
            NAX11_01,
            NEW1_033,
            CS2_106,
            XXX_002,
            FP1_018,
            NEW1_036e2,
            XXX_004,
            NAX11_02H,
            CS2_122e,
            DS1_233,
            DS1_175,
            NEW1_024,
            CS2_189,
            CRED_10,
            NEW1_037,
            EX1_414,
            EX1_538t,
            FP1_030e,
            EX1_586,
            EX1_310,
            NEW1_010,
            CS2_103e,
            EX1_080o,
            CS2_005o,
            EX1_363e2,
            EX1_534t,
            FP1_028,
            EX1_604,
            EX1_160,
            EX1_165t1,
            CS2_062,
            CS2_155,
            CS2_213,
            TU4f_007,
            GAME_004,
            NAX5_01,
            XXX_020,
            NAX15_02H,
            CS2_004,
            NAX2_03H,
            EX1_561e,
            CS2_023,
            EX1_164,
            EX1_009,
            NAX6_01,
            FP1_007,
            NAX1h_04,
            NAX2_05H,
            NAX10_02,
            EX1_345,
            EX1_116,
            EX1_399,
            EX1_587,
            XXX_026,
            EX1_571,
            EX1_335,
            XXX_050,
            TU4e_004,
            HERO_08,
            EX1_166a,
            NAX2_03,
            EX1_finkle,
            NAX4_03H,
            EX1_164b,
            EX1_283,
            EX1_339,
            CRED_13,
            EX1_178be,
            EX1_531,
            EX1_134,
            EX1_350,
            EX1_308,
            CS2_197,
            skele21,
            CS2_222o,
            XXX_015,
            FP1_013,
            NEW1_006,
            EX1_399e,
            EX1_509,
            EX1_612,
            NAX8_05t,
            NAX9_05H,
            EX1_021,
            CS2_041e,
            CS2_226,
            EX1_608,
            NAX13_05H,
            NAX13_04H,
            TU4c_008,
            EX1_624,
            EX1_616,
            EX1_008,
            PlaceholderCard,
            XXX_016,
            EX1_045,
            EX1_015,
            GAME_003,
            CS2_171,
            CS2_041,
            EX1_128,
            CS2_112,
            HERO_07,
            EX1_412,
            EX1_612o,
            CS2_117,
            XXX_009e,
            EX1_562,
            EX1_055,
            NAX9_06,
            TU4e_007,
            FP1_012,
            EX1_317t,
            EX1_004e,
            EX1_278,
            CS2_tk1,
            EX1_590,
            CS1_130,
            NEW1_008b,
            EX1_365,
            CS2_141,
            PRO_001,
            NAX8_04t,
            CS2_173,
            CS2_017,
            CRED_16,
            EX1_392,
            EX1_593,
            FP1_023e,
            NAX1_05,
            TU4d_002,
            CRED_15,
            EX1_049,
            EX1_002,
            TU4f_005,
            NEW1_029t,
            TU4a_001,
            CS2_056,
            EX1_596,
            EX1_136,
            EX1_323,
            CS2_073,
            EX1_246e,
            NAX12_01,
            EX1_244e,
            EX1_001,
            EX1_607e,
            EX1_044,
            EX1_573ae,
            XXX_025,
            CRED_06,
            Mekka4,
            CS2_142,
            TU4f_004,
            NAX5_02H,
            EX1_411e2,
            EX1_573,
            FP1_009,
            CS2_050,
            NAX4_03,
            CS2_063e,
            NAX2_05,
            EX1_390,
            EX1_610,
            hexfrog,
            CS2_181e,
            NAX6_02,
            XXX_027,
            CS2_082,
            NEW1_040,
            DREAM_01,
            EX1_595,
            CS2_013,
            CS2_077,
            NEW1_014,
            CRED_05,
            GAME_002,
            EX1_165,
            CS2_013t,
            NAX4_04H,
            EX1_tk11,
            EX1_591,
            EX1_549,
            CS2_045,
            CS2_237,
            CS2_027,
            EX1_508o,
            NAX14_03,
            CS2_101t,
            CS2_063,
            EX1_145,
            NAX1h_03,
            EX1_110,
            EX1_408,
            EX1_544,
            TU4c_006,
            NAXM_001,
            CS2_151,
            CS2_073e,
            XXX_006,
            CS2_088,
            EX1_057,
            FP1_020,
            CS2_169,
            EX1_573t,
            EX1_323h,
            EX1_tk9,
            NEW1_018e,
            CS2_037,
            CS2_007,
            EX1_059e2,
            CS2_227,
            NAX7_03H,
            NAX9_01H,
            EX1_570e,
            NEW1_003,
            GAME_006,
            EX1_320,
            EX1_097,
            tt_004,
            EX1_360e,
            EX1_096,
            DS1_175o,
            EX1_596e,
            XXX_014,
            EX1_158e,
            NAX14_01,
            CRED_01,
            CRED_08,
            EX1_126,
            EX1_577,
            EX1_319,
            EX1_611,
            CS2_146,
            EX1_154b,
            skele11,
            EX1_165t2,
            CS2_172,
            CS2_114,
            CS1_069,
            XXX_003,
            XXX_042,
            NAX8_02,
            EX1_173,
            CS1_042,
            NAX8_03,
            EX1_506a,
            EX1_298,
            CS2_104,
            FP1_001,
            HERO_02,
            EX1_316e,
            NAX7_01,
            EX1_044e,
            CS2_051,
            NEW1_016,
            EX1_304e,
            EX1_033,
            NAX8_04,
            EX1_028,
            XXX_011,
            EX1_621,
            EX1_554,
            EX1_091,
            FP1_017,
            EX1_409,
            EX1_363e,
            EX1_410,
            TU4e_005,
            CS2_039,
            NAX12_04,
            EX1_557,
            CS2_105e,
            EX1_128e,
            XXX_021,
            DS1_070,
            CS2_033,
            EX1_536,
            TU4a_003,
            EX1_559,
            XXX_023,
            NEW1_033o,
            NAX15_04H,
            CS2_004e,
            CS2_052,
            EX1_539,
            EX1_575,
            CS2_083b,
            CS2_061,
            NEW1_021,
            DS1_055,
            EX1_625,
            EX1_382e,
            CS2_092e,
            CS2_026,
            NAX14_04,
            NEW1_012o,
            EX1_619e,
            EX1_294,
            EX1_287,
            EX1_509e,
            EX1_625t2,
            CS2_118,
            CS2_124,
            Mekka3,
            NAX13_02,
            EX1_112,
            FP1_011,
            CS2_009e,
            HERO_04,
            EX1_607,
            DREAM_03,
            NAX11_04e,
            EX1_103e,
            XXX_046,
            FP1_003,
            CS2_105,
            FP1_002,
            TU4c_002,
            CRED_14,
            EX1_567,
            TU4c_004,
            NAX10_03H,
            FP1_008,
            DS1_184,
            CS2_029,
            GAME_005,
            CS2_187,
            EX1_020,
            NAX15_01He,
            EX1_011,
            CS2_057,
            EX1_274,
            EX1_306,
            NEW1_038o,
            EX1_170,
            EX1_617,
            CS1_113e,
            CS2_101,
            FP1_015,
            NAX13_03,
            CS2_005,
            EX1_537,
            EX1_384,
            TU4a_002,
            NAX9_04,
            EX1_362,
            NAX12_02,
            FP1_028e,
            TU4c_005,
            EX1_301,
            CS2_235,
            NAX4_05,
            EX1_029,
            CS2_042,
            EX1_155a,
            CS2_102,
            EX1_609,
            NEW1_027,
            CS2_236e,
            CS2_083e,
            NAX6_03te,
            EX1_165a,
            EX1_570,
            EX1_131,
            EX1_556,
            EX1_543,
            XXX_096,
            TU4c_008e,
            EX1_379e,
            NEW1_009,
            EX1_100,
            EX1_274e,
            CRED_02,
            EX1_573a,
            CS2_084,
            EX1_582,
            EX1_043,
            EX1_050,
            TU4b_001,
            FP1_005,
            EX1_620,
            NAX15_01,
            NAX6_03,
            EX1_303,
            HERO_09,
            EX1_067,
            XXX_028,
            EX1_277,
            Mekka2,
            NAX14_01H,
            NAX15_04,
            FP1_024,
            FP1_030,
            CS2_221e,
            EX1_178,
            CS2_222,
            EX1_409e,
            tt_004o,
            EX1_155ae,
            NAX11_01H,
            EX1_160a,
            NAX15_02,
            NAX15_05,
            NEW1_025e,
            CS2_012,
            XXX_099,
            EX1_246,
            EX1_572,
            EX1_089,
            CS2_059,
            EX1_279,
            NAX12_02e,
            CS2_168,
            tt_010,
            NEW1_023,
            CS2_075,
            EX1_316,
            CS2_025,
            CS2_234,
            XXX_043,
            GAME_001,
            NAX5_02,
            EX1_130,
            EX1_584e,
            CS2_064,
            EX1_161,
            CS2_049,
            NAX13_01,
            EX1_154,
            EX1_080,
            NEW1_022,
            NAX2_01H,
            EX1_160be,
            NAX12_03,
            EX1_251,
            FP1_025,
            EX1_371,
            CS2_mirror,
            NAX4_01H,
            EX1_594,
            NAX14_02,
            TU4c_006e,
            EX1_560,
            CS2_236,
            TU4f_006,
            EX1_402,
            NAX3_01,
            EX1_506,
            NEW1_027e,
            DS1_070o,
            XXX_045,
            XXX_029,
            DS1_178,
            XXX_098,
            EX1_315,
            CS2_094,
            NAX13_01H,
            TU4e_002t,
            EX1_046e,
            NEW1_040t,
            GAME_005e,
            CS2_131,
            XXX_008,
            EX1_531e,
            CS2_226e,
            XXX_022e,
            DS1_178e,
            CS2_226o,
            NAX9_04H,
            Mekka4e,
            EX1_082,
            CS2_093,
            EX1_411e,
            NAX8_03t,
            EX1_145o,
            NAX7_04,
            CS2_boar,
            NEW1_019,
            EX1_289,
            EX1_025t,
            EX1_398t,
            NAX12_03H,
            EX1_055o,
            CS2_091,
            EX1_241,
            EX1_085,
            CS2_200,
            CS2_034,
            EX1_583,
            EX1_584,
            EX1_155,
            EX1_622,
            CS2_203,
            EX1_124,
            EX1_379,
            NAX7_02,
            CS2_053e,
            EX1_032,
            NAX9_01,
            TU4e_003,
            CS2_146o,
            NAX8_01H,
            XXX_041,
            NAXM_002,
            EX1_391,
            EX1_366,
            EX1_059e,
            XXX_012,
            EX1_565o,
            EX1_001e,
            TU4f_003,
            EX1_400,
            EX1_614,
            EX1_561,
            EX1_332,
            HERO_05,
            CS2_065,
            ds1_whelptoken,
            EX1_536e,
            CS2_032,
            CS2_120,
            EX1_155be,
            EX1_247,
            EX1_154a,
            EX1_554t,
            CS2_103e2,
            TU4d_003,
            NEW1_026t,
            EX1_623,
            EX1_383t,
            NAX7_03,
            EX1_597,
            TU4f_006o,
            EX1_130a,
            CS2_011,
            EX1_169,
            EX1_tk33,
            NAX11_03,
            NAX4_01,
            NAX10_01,
            EX1_250,
            EX1_564,
            NAX5_03,
            EX1_043e,
            EX1_349,
            XXX_097,
            EX1_102,
            EX1_058,
            EX1_243,
            PRO_001c,
            EX1_116t,
            NAX15_01e,
            FP1_029,
            CS2_089,
            TU4c_001,
            EX1_248,
            NEW1_037e,
            CS2_122,
            EX1_393,
            CS2_232,
            EX1_165b,
            NEW1_030,
            EX1_161o,
            EX1_093e,
            CS2_150,
            CS2_152,
            NAX9_03H,
            EX1_160t,
            CS2_127,
            CRED_03,
            DS1_188,
            XXX_001,
        }

        public cardIDEnum cardIdstringToEnum(string s)
        {
            if (s == "XXX_040") return CardDB.cardIDEnum.XXX_040;
            if (s == "NAX5_01H") return CardDB.cardIDEnum.NAX5_01H;
            if (s == "CS2_188o") return CardDB.cardIDEnum.CS2_188o;
            if (s == "NAX6_02H") return CardDB.cardIDEnum.NAX6_02H;
            if (s == "NEW1_007b") return CardDB.cardIDEnum.NEW1_007b;
            if (s == "NAX6_02e") return CardDB.cardIDEnum.NAX6_02e;
            if (s == "TU4c_003") return CardDB.cardIDEnum.TU4c_003;
            if (s == "XXX_024") return CardDB.cardIDEnum.XXX_024;
            if (s == "EX1_613") return CardDB.cardIDEnum.EX1_613;
            if (s == "NAX8_01") return CardDB.cardIDEnum.NAX8_01;
            if (s == "EX1_295o") return CardDB.cardIDEnum.EX1_295o;
            if (s == "CS2_059o") return CardDB.cardIDEnum.CS2_059o;
            if (s == "EX1_133") return CardDB.cardIDEnum.EX1_133;
            if (s == "NEW1_018") return CardDB.cardIDEnum.NEW1_018;
            if (s == "NAX15_03t") return CardDB.cardIDEnum.NAX15_03t;
            if (s == "EX1_012") return CardDB.cardIDEnum.EX1_012;
            if (s == "EX1_178a") return CardDB.cardIDEnum.EX1_178a;
            if (s == "CS2_231") return CardDB.cardIDEnum.CS2_231;
            if (s == "EX1_019e") return CardDB.cardIDEnum.EX1_019e;
            if (s == "CRED_12") return CardDB.cardIDEnum.CRED_12;
            if (s == "CS2_179") return CardDB.cardIDEnum.CS2_179;
            if (s == "CS2_045e") return CardDB.cardIDEnum.CS2_045e;
            if (s == "EX1_244") return CardDB.cardIDEnum.EX1_244;
            if (s == "EX1_178b") return CardDB.cardIDEnum.EX1_178b;
            if (s == "XXX_030") return CardDB.cardIDEnum.XXX_030;
            if (s == "NAX8_05") return CardDB.cardIDEnum.NAX8_05;
            if (s == "EX1_573b") return CardDB.cardIDEnum.EX1_573b;
            if (s == "TU4d_001") return CardDB.cardIDEnum.TU4d_001;
            if (s == "NEW1_007a") return CardDB.cardIDEnum.NEW1_007a;
            if (s == "NAX12_02H") return CardDB.cardIDEnum.NAX12_02H;
            if (s == "EX1_345t") return CardDB.cardIDEnum.EX1_345t;
            if (s == "FP1_007t") return CardDB.cardIDEnum.FP1_007t;
            if (s == "EX1_025") return CardDB.cardIDEnum.EX1_025;
            if (s == "EX1_396") return CardDB.cardIDEnum.EX1_396;
            if (s == "NAX9_03") return CardDB.cardIDEnum.NAX9_03;
            if (s == "NEW1_017") return CardDB.cardIDEnum.NEW1_017;
            if (s == "NEW1_008a") return CardDB.cardIDEnum.NEW1_008a;
            if (s == "EX1_587e") return CardDB.cardIDEnum.EX1_587e;
            if (s == "EX1_533") return CardDB.cardIDEnum.EX1_533;
            if (s == "EX1_522") return CardDB.cardIDEnum.EX1_522;
            if (s == "NAX11_04") return CardDB.cardIDEnum.NAX11_04;
            if (s == "NEW1_026") return CardDB.cardIDEnum.NEW1_026;
            if (s == "EX1_398") return CardDB.cardIDEnum.EX1_398;
            if (s == "NAX4_04") return CardDB.cardIDEnum.NAX4_04;
            if (s == "EX1_007") return CardDB.cardIDEnum.EX1_007;
            if (s == "CS1_112") return CardDB.cardIDEnum.CS1_112;
            if (s == "CRED_17") return CardDB.cardIDEnum.CRED_17;
            if (s == "NEW1_036") return CardDB.cardIDEnum.NEW1_036;
            if (s == "NAX3_03") return CardDB.cardIDEnum.NAX3_03;
            if (s == "EX1_355e") return CardDB.cardIDEnum.EX1_355e;
            if (s == "EX1_258") return CardDB.cardIDEnum.EX1_258;
            if (s == "HERO_01") return CardDB.cardIDEnum.HERO_01;
            if (s == "XXX_009") return CardDB.cardIDEnum.XXX_009;
            if (s == "NAX6_01H") return CardDB.cardIDEnum.NAX6_01H;
            if (s == "NAX12_04e") return CardDB.cardIDEnum.NAX12_04e;
            if (s == "CS2_087") return CardDB.cardIDEnum.CS2_087;
            if (s == "DREAM_05") return CardDB.cardIDEnum.DREAM_05;
            if (s == "NEW1_036e") return CardDB.cardIDEnum.NEW1_036e;
            if (s == "CS2_092") return CardDB.cardIDEnum.CS2_092;
            if (s == "CS2_022") return CardDB.cardIDEnum.CS2_022;
            if (s == "EX1_046") return CardDB.cardIDEnum.EX1_046;
            if (s == "XXX_005") return CardDB.cardIDEnum.XXX_005;
            if (s == "PRO_001b") return CardDB.cardIDEnum.PRO_001b;
            if (s == "XXX_022") return CardDB.cardIDEnum.XXX_022;
            if (s == "PRO_001a") return CardDB.cardIDEnum.PRO_001a;
            if (s == "NAX6_04") return CardDB.cardIDEnum.NAX6_04;
            if (s == "NAX7_05") return CardDB.cardIDEnum.NAX7_05;
            if (s == "CS2_103") return CardDB.cardIDEnum.CS2_103;
            if (s == "NEW1_041") return CardDB.cardIDEnum.NEW1_041;
            if (s == "EX1_360") return CardDB.cardIDEnum.EX1_360;
            if (s == "FP1_023") return CardDB.cardIDEnum.FP1_023;
            if (s == "NEW1_038") return CardDB.cardIDEnum.NEW1_038;
            if (s == "CS2_009") return CardDB.cardIDEnum.CS2_009;
            if (s == "NAX10_01H") return CardDB.cardIDEnum.NAX10_01H;
            if (s == "EX1_010") return CardDB.cardIDEnum.EX1_010;
            if (s == "CS2_024") return CardDB.cardIDEnum.CS2_024;
            if (s == "NAX9_05") return CardDB.cardIDEnum.NAX9_05;
            if (s == "EX1_565") return CardDB.cardIDEnum.EX1_565;
            if (s == "CS2_076") return CardDB.cardIDEnum.CS2_076;
            if (s == "FP1_004") return CardDB.cardIDEnum.FP1_004;
            if (s == "CS2_046e") return CardDB.cardIDEnum.CS2_046e;
            if (s == "CS2_162") return CardDB.cardIDEnum.CS2_162;
            if (s == "EX1_110t") return CardDB.cardIDEnum.EX1_110t;
            if (s == "CS2_104e") return CardDB.cardIDEnum.CS2_104e;
            if (s == "CS2_181") return CardDB.cardIDEnum.CS2_181;
            if (s == "EX1_309") return CardDB.cardIDEnum.EX1_309;
            if (s == "EX1_354") return CardDB.cardIDEnum.EX1_354;
            if (s == "NAX10_02H") return CardDB.cardIDEnum.NAX10_02H;
            if (s == "NAX7_04H") return CardDB.cardIDEnum.NAX7_04H;
            if (s == "TU4f_001") return CardDB.cardIDEnum.TU4f_001;
            if (s == "XXX_018") return CardDB.cardIDEnum.XXX_018;
            if (s == "EX1_023") return CardDB.cardIDEnum.EX1_023;
            if (s == "XXX_048") return CardDB.cardIDEnum.XXX_048;
            if (s == "XXX_049") return CardDB.cardIDEnum.XXX_049;
            if (s == "NEW1_034") return CardDB.cardIDEnum.NEW1_034;
            if (s == "CS2_003") return CardDB.cardIDEnum.CS2_003;
            if (s == "HERO_06") return CardDB.cardIDEnum.HERO_06;
            if (s == "CS2_201") return CardDB.cardIDEnum.CS2_201;
            if (s == "EX1_508") return CardDB.cardIDEnum.EX1_508;
            if (s == "EX1_259") return CardDB.cardIDEnum.EX1_259;
            if (s == "EX1_341") return CardDB.cardIDEnum.EX1_341;
            if (s == "DREAM_05e") return CardDB.cardIDEnum.DREAM_05e;
            if (s == "CRED_09") return CardDB.cardIDEnum.CRED_09;
            if (s == "EX1_103") return CardDB.cardIDEnum.EX1_103;
            if (s == "FP1_021") return CardDB.cardIDEnum.FP1_021;
            if (s == "EX1_411") return CardDB.cardIDEnum.EX1_411;
            if (s == "NAX1_04") return CardDB.cardIDEnum.NAX1_04;
            if (s == "CS2_053") return CardDB.cardIDEnum.CS2_053;
            if (s == "CS2_182") return CardDB.cardIDEnum.CS2_182;
            if (s == "CS2_008") return CardDB.cardIDEnum.CS2_008;
            if (s == "CS2_233") return CardDB.cardIDEnum.CS2_233;
            if (s == "EX1_626") return CardDB.cardIDEnum.EX1_626;
            if (s == "EX1_059") return CardDB.cardIDEnum.EX1_059;
            if (s == "EX1_334") return CardDB.cardIDEnum.EX1_334;
            if (s == "EX1_619") return CardDB.cardIDEnum.EX1_619;
            if (s == "NEW1_032") return CardDB.cardIDEnum.NEW1_032;
            if (s == "EX1_158t") return CardDB.cardIDEnum.EX1_158t;
            if (s == "EX1_006") return CardDB.cardIDEnum.EX1_006;
            if (s == "NEW1_031") return CardDB.cardIDEnum.NEW1_031;
            if (s == "NAX10_03") return CardDB.cardIDEnum.NAX10_03;
            if (s == "DREAM_04") return CardDB.cardIDEnum.DREAM_04;
            if (s == "NAX1h_01") return CardDB.cardIDEnum.NAX1h_01;
            if (s == "CS2_022e") return CardDB.cardIDEnum.CS2_022e;
            if (s == "EX1_611e") return CardDB.cardIDEnum.EX1_611e;
            if (s == "EX1_004") return CardDB.cardIDEnum.EX1_004;
            if (s == "EX1_014te") return CardDB.cardIDEnum.EX1_014te;
            if (s == "FP1_005e") return CardDB.cardIDEnum.FP1_005e;
            if (s == "NAX12_03e") return CardDB.cardIDEnum.NAX12_03e;
            if (s == "EX1_095") return CardDB.cardIDEnum.EX1_095;
            if (s == "NEW1_007") return CardDB.cardIDEnum.NEW1_007;
            if (s == "EX1_275") return CardDB.cardIDEnum.EX1_275;
            if (s == "EX1_245") return CardDB.cardIDEnum.EX1_245;
            if (s == "EX1_383") return CardDB.cardIDEnum.EX1_383;
            if (s == "FP1_016") return CardDB.cardIDEnum.FP1_016;
            if (s == "EX1_016t") return CardDB.cardIDEnum.EX1_016t;
            if (s == "CS2_125") return CardDB.cardIDEnum.CS2_125;
            if (s == "EX1_137") return CardDB.cardIDEnum.EX1_137;
            if (s == "EX1_178ae") return CardDB.cardIDEnum.EX1_178ae;
            if (s == "DS1_185") return CardDB.cardIDEnum.DS1_185;
            if (s == "FP1_010") return CardDB.cardIDEnum.FP1_010;
            if (s == "EX1_598") return CardDB.cardIDEnum.EX1_598;
            if (s == "NAX9_07") return CardDB.cardIDEnum.NAX9_07;
            if (s == "EX1_304") return CardDB.cardIDEnum.EX1_304;
            if (s == "EX1_302") return CardDB.cardIDEnum.EX1_302;
            if (s == "XXX_017") return CardDB.cardIDEnum.XXX_017;
            if (s == "CS2_011o") return CardDB.cardIDEnum.CS2_011o;
            if (s == "EX1_614t") return CardDB.cardIDEnum.EX1_614t;
            if (s == "TU4a_006") return CardDB.cardIDEnum.TU4a_006;
            if (s == "Mekka3e") return CardDB.cardIDEnum.Mekka3e;
            if (s == "CS2_108") return CardDB.cardIDEnum.CS2_108;
            if (s == "CS2_046") return CardDB.cardIDEnum.CS2_046;
            if (s == "EX1_014t") return CardDB.cardIDEnum.EX1_014t;
            if (s == "NEW1_005") return CardDB.cardIDEnum.NEW1_005;
            if (s == "EX1_062") return CardDB.cardIDEnum.EX1_062;
            if (s == "EX1_366e") return CardDB.cardIDEnum.EX1_366e;
            if (s == "Mekka1") return CardDB.cardIDEnum.Mekka1;
            if (s == "XXX_007") return CardDB.cardIDEnum.XXX_007;
            if (s == "tt_010a") return CardDB.cardIDEnum.tt_010a;
            if (s == "CS2_017o") return CardDB.cardIDEnum.CS2_017o;
            if (s == "CS2_072") return CardDB.cardIDEnum.CS2_072;
            if (s == "EX1_tk28") return CardDB.cardIDEnum.EX1_tk28;
            if (s == "EX1_604o") return CardDB.cardIDEnum.EX1_604o;
            if (s == "FP1_014") return CardDB.cardIDEnum.FP1_014;
            if (s == "EX1_084e") return CardDB.cardIDEnum.EX1_084e;
            if (s == "NAX3_01H") return CardDB.cardIDEnum.NAX3_01H;
            if (s == "NAX2_01") return CardDB.cardIDEnum.NAX2_01;
            if (s == "EX1_409t") return CardDB.cardIDEnum.EX1_409t;
            if (s == "CRED_07") return CardDB.cardIDEnum.CRED_07;
            if (s == "NAX3_02H") return CardDB.cardIDEnum.NAX3_02H;
            if (s == "TU4e_002") return CardDB.cardIDEnum.TU4e_002;
            if (s == "EX1_507") return CardDB.cardIDEnum.EX1_507;
            if (s == "EX1_144") return CardDB.cardIDEnum.EX1_144;
            if (s == "CS2_038") return CardDB.cardIDEnum.CS2_038;
            if (s == "EX1_093") return CardDB.cardIDEnum.EX1_093;
            if (s == "CS2_080") return CardDB.cardIDEnum.CS2_080;
            if (s == "CS1_129e") return CardDB.cardIDEnum.CS1_129e;
            if (s == "XXX_013") return CardDB.cardIDEnum.XXX_013;
            if (s == "EX1_005") return CardDB.cardIDEnum.EX1_005;
            if (s == "EX1_382") return CardDB.cardIDEnum.EX1_382;
            if (s == "NAX13_02e") return CardDB.cardIDEnum.NAX13_02e;
            if (s == "FP1_020e") return CardDB.cardIDEnum.FP1_020e;
            if (s == "EX1_603e") return CardDB.cardIDEnum.EX1_603e;
            if (s == "CS2_028") return CardDB.cardIDEnum.CS2_028;
            if (s == "TU4f_002") return CardDB.cardIDEnum.TU4f_002;
            if (s == "EX1_538") return CardDB.cardIDEnum.EX1_538;
            if (s == "GAME_003e") return CardDB.cardIDEnum.GAME_003e;
            if (s == "DREAM_02") return CardDB.cardIDEnum.DREAM_02;
            if (s == "EX1_581") return CardDB.cardIDEnum.EX1_581;
            if (s == "NAX15_01H") return CardDB.cardIDEnum.NAX15_01H;
            if (s == "EX1_131t") return CardDB.cardIDEnum.EX1_131t;
            if (s == "CS2_147") return CardDB.cardIDEnum.CS2_147;
            if (s == "CS1_113") return CardDB.cardIDEnum.CS1_113;
            if (s == "CS2_161") return CardDB.cardIDEnum.CS2_161;
            if (s == "CS2_031") return CardDB.cardIDEnum.CS2_031;
            if (s == "EX1_166b") return CardDB.cardIDEnum.EX1_166b;
            if (s == "EX1_066") return CardDB.cardIDEnum.EX1_066;
            if (s == "TU4c_007") return CardDB.cardIDEnum.TU4c_007;
            if (s == "EX1_355") return CardDB.cardIDEnum.EX1_355;
            if (s == "EX1_507e") return CardDB.cardIDEnum.EX1_507e;
            if (s == "EX1_534") return CardDB.cardIDEnum.EX1_534;
            if (s == "EX1_162") return CardDB.cardIDEnum.EX1_162;
            if (s == "TU4a_004") return CardDB.cardIDEnum.TU4a_004;
            if (s == "EX1_363") return CardDB.cardIDEnum.EX1_363;
            if (s == "EX1_164a") return CardDB.cardIDEnum.EX1_164a;
            if (s == "CS2_188") return CardDB.cardIDEnum.CS2_188;
            if (s == "EX1_016") return CardDB.cardIDEnum.EX1_016;
            if (s == "NAX6_03t") return CardDB.cardIDEnum.NAX6_03t;
            if (s == "EX1_tk31") return CardDB.cardIDEnum.EX1_tk31;
            if (s == "EX1_603") return CardDB.cardIDEnum.EX1_603;
            if (s == "EX1_238") return CardDB.cardIDEnum.EX1_238;
            if (s == "EX1_166") return CardDB.cardIDEnum.EX1_166;
            if (s == "DS1h_292") return CardDB.cardIDEnum.DS1h_292;
            if (s == "DS1_183") return CardDB.cardIDEnum.DS1_183;
            if (s == "NAX15_03n") return CardDB.cardIDEnum.NAX15_03n;
            if (s == "NAX8_02H") return CardDB.cardIDEnum.NAX8_02H;
            if (s == "NAX7_01H") return CardDB.cardIDEnum.NAX7_01H;
            if (s == "NAX9_02H") return CardDB.cardIDEnum.NAX9_02H;
            if (s == "CRED_11") return CardDB.cardIDEnum.CRED_11;
            if (s == "XXX_019") return CardDB.cardIDEnum.XXX_019;
            if (s == "EX1_076") return CardDB.cardIDEnum.EX1_076;
            if (s == "EX1_048") return CardDB.cardIDEnum.EX1_048;
            if (s == "CS2_038e") return CardDB.cardIDEnum.CS2_038e;
            if (s == "FP1_026") return CardDB.cardIDEnum.FP1_026;
            if (s == "CS2_074") return CardDB.cardIDEnum.CS2_074;
            if (s == "FP1_027") return CardDB.cardIDEnum.FP1_027;
            if (s == "EX1_323w") return CardDB.cardIDEnum.EX1_323w;
            if (s == "EX1_129") return CardDB.cardIDEnum.EX1_129;
            if (s == "NEW1_024o") return CardDB.cardIDEnum.NEW1_024o;
            if (s == "NAX11_02") return CardDB.cardIDEnum.NAX11_02;
            if (s == "EX1_405") return CardDB.cardIDEnum.EX1_405;
            if (s == "EX1_317") return CardDB.cardIDEnum.EX1_317;
            if (s == "EX1_606") return CardDB.cardIDEnum.EX1_606;
            if (s == "EX1_590e") return CardDB.cardIDEnum.EX1_590e;
            if (s == "XXX_044") return CardDB.cardIDEnum.XXX_044;
            if (s == "CS2_074e") return CardDB.cardIDEnum.CS2_074e;
            if (s == "TU4a_005") return CardDB.cardIDEnum.TU4a_005;
            if (s == "FP1_006") return CardDB.cardIDEnum.FP1_006;
            if (s == "EX1_258e") return CardDB.cardIDEnum.EX1_258e;
            if (s == "TU4f_004o") return CardDB.cardIDEnum.TU4f_004o;
            if (s == "NEW1_008") return CardDB.cardIDEnum.NEW1_008;
            if (s == "CS2_119") return CardDB.cardIDEnum.CS2_119;
            if (s == "NEW1_017e") return CardDB.cardIDEnum.NEW1_017e;
            if (s == "EX1_334e") return CardDB.cardIDEnum.EX1_334e;
            if (s == "TU4e_001") return CardDB.cardIDEnum.TU4e_001;
            if (s == "CS2_121") return CardDB.cardIDEnum.CS2_121;
            if (s == "CS1h_001") return CardDB.cardIDEnum.CS1h_001;
            if (s == "EX1_tk34") return CardDB.cardIDEnum.EX1_tk34;
            if (s == "NEW1_020") return CardDB.cardIDEnum.NEW1_020;
            if (s == "CS2_196") return CardDB.cardIDEnum.CS2_196;
            if (s == "EX1_312") return CardDB.cardIDEnum.EX1_312;
            if (s == "NAX1_01") return CardDB.cardIDEnum.NAX1_01;
            if (s == "FP1_022") return CardDB.cardIDEnum.FP1_022;
            if (s == "EX1_160b") return CardDB.cardIDEnum.EX1_160b;
            if (s == "EX1_563") return CardDB.cardIDEnum.EX1_563;
            if (s == "XXX_039") return CardDB.cardIDEnum.XXX_039;
            if (s == "FP1_031") return CardDB.cardIDEnum.FP1_031;
            if (s == "CS2_087e") return CardDB.cardIDEnum.CS2_087e;
            if (s == "EX1_613e") return CardDB.cardIDEnum.EX1_613e;
            if (s == "NAX9_02") return CardDB.cardIDEnum.NAX9_02;
            if (s == "NEW1_029") return CardDB.cardIDEnum.NEW1_029;
            if (s == "CS1_129") return CardDB.cardIDEnum.CS1_129;
            if (s == "HERO_03") return CardDB.cardIDEnum.HERO_03;
            if (s == "Mekka4t") return CardDB.cardIDEnum.Mekka4t;
            if (s == "EX1_158") return CardDB.cardIDEnum.EX1_158;
            if (s == "XXX_010") return CardDB.cardIDEnum.XXX_010;
            if (s == "NEW1_025") return CardDB.cardIDEnum.NEW1_025;
            if (s == "FP1_012t") return CardDB.cardIDEnum.FP1_012t;
            if (s == "EX1_083") return CardDB.cardIDEnum.EX1_083;
            if (s == "EX1_295") return CardDB.cardIDEnum.EX1_295;
            if (s == "EX1_407") return CardDB.cardIDEnum.EX1_407;
            if (s == "NEW1_004") return CardDB.cardIDEnum.NEW1_004;
            if (s == "FP1_019") return CardDB.cardIDEnum.FP1_019;
            if (s == "PRO_001at") return CardDB.cardIDEnum.PRO_001at;
            if (s == "NAX13_03e") return CardDB.cardIDEnum.NAX13_03e;
            if (s == "EX1_625t") return CardDB.cardIDEnum.EX1_625t;
            if (s == "EX1_014") return CardDB.cardIDEnum.EX1_014;
            if (s == "CRED_04") return CardDB.cardIDEnum.CRED_04;
            if (s == "NAX12_01H") return CardDB.cardIDEnum.NAX12_01H;
            if (s == "CS2_097") return CardDB.cardIDEnum.CS2_097;
            if (s == "EX1_558") return CardDB.cardIDEnum.EX1_558;
            if (s == "XXX_047") return CardDB.cardIDEnum.XXX_047;
            if (s == "EX1_tk29") return CardDB.cardIDEnum.EX1_tk29;
            if (s == "CS2_186") return CardDB.cardIDEnum.CS2_186;
            if (s == "EX1_084") return CardDB.cardIDEnum.EX1_084;
            if (s == "NEW1_012") return CardDB.cardIDEnum.NEW1_012;
            if (s == "FP1_014t") return CardDB.cardIDEnum.FP1_014t;
            if (s == "NAX1_03") return CardDB.cardIDEnum.NAX1_03;
            if (s == "EX1_623e") return CardDB.cardIDEnum.EX1_623e;
            if (s == "EX1_578") return CardDB.cardIDEnum.EX1_578;
            if (s == "CS2_073e2") return CardDB.cardIDEnum.CS2_073e2;
            if (s == "CS2_221") return CardDB.cardIDEnum.CS2_221;
            if (s == "EX1_019") return CardDB.cardIDEnum.EX1_019;
            if (s == "NAX15_04a") return CardDB.cardIDEnum.NAX15_04a;
            if (s == "FP1_019t") return CardDB.cardIDEnum.FP1_019t;
            if (s == "EX1_132") return CardDB.cardIDEnum.EX1_132;
            if (s == "EX1_284") return CardDB.cardIDEnum.EX1_284;
            if (s == "EX1_105") return CardDB.cardIDEnum.EX1_105;
            if (s == "NEW1_011") return CardDB.cardIDEnum.NEW1_011;
            if (s == "NAX9_07e") return CardDB.cardIDEnum.NAX9_07e;
            if (s == "EX1_017") return CardDB.cardIDEnum.EX1_017;
            if (s == "EX1_249") return CardDB.cardIDEnum.EX1_249;
            if (s == "EX1_162o") return CardDB.cardIDEnum.EX1_162o;
            if (s == "FP1_002t") return CardDB.cardIDEnum.FP1_002t;
            if (s == "NAX3_02") return CardDB.cardIDEnum.NAX3_02;
            if (s == "EX1_313") return CardDB.cardIDEnum.EX1_313;
            if (s == "EX1_549o") return CardDB.cardIDEnum.EX1_549o;
            if (s == "EX1_091o") return CardDB.cardIDEnum.EX1_091o;
            if (s == "CS2_084e") return CardDB.cardIDEnum.CS2_084e;
            if (s == "EX1_155b") return CardDB.cardIDEnum.EX1_155b;
            if (s == "NAX11_01") return CardDB.cardIDEnum.NAX11_01;
            if (s == "NEW1_033") return CardDB.cardIDEnum.NEW1_033;
            if (s == "CS2_106") return CardDB.cardIDEnum.CS2_106;
            if (s == "XXX_002") return CardDB.cardIDEnum.XXX_002;
            if (s == "FP1_018") return CardDB.cardIDEnum.FP1_018;
            if (s == "NEW1_036e2") return CardDB.cardIDEnum.NEW1_036e2;
            if (s == "XXX_004") return CardDB.cardIDEnum.XXX_004;
            if (s == "NAX11_02H") return CardDB.cardIDEnum.NAX11_02H;
            if (s == "CS2_122e") return CardDB.cardIDEnum.CS2_122e;
            if (s == "DS1_233") return CardDB.cardIDEnum.DS1_233;
            if (s == "DS1_175") return CardDB.cardIDEnum.DS1_175;
            if (s == "NEW1_024") return CardDB.cardIDEnum.NEW1_024;
            if (s == "CS2_189") return CardDB.cardIDEnum.CS2_189;
            if (s == "CRED_10") return CardDB.cardIDEnum.CRED_10;
            if (s == "NEW1_037") return CardDB.cardIDEnum.NEW1_037;
            if (s == "EX1_414") return CardDB.cardIDEnum.EX1_414;
            if (s == "EX1_538t") return CardDB.cardIDEnum.EX1_538t;
            if (s == "FP1_030e") return CardDB.cardIDEnum.FP1_030e;
            if (s == "EX1_586") return CardDB.cardIDEnum.EX1_586;
            if (s == "EX1_310") return CardDB.cardIDEnum.EX1_310;
            if (s == "NEW1_010") return CardDB.cardIDEnum.NEW1_010;
            if (s == "CS2_103e") return CardDB.cardIDEnum.CS2_103e;
            if (s == "EX1_080o") return CardDB.cardIDEnum.EX1_080o;
            if (s == "CS2_005o") return CardDB.cardIDEnum.CS2_005o;
            if (s == "EX1_363e2") return CardDB.cardIDEnum.EX1_363e2;
            if (s == "EX1_534t") return CardDB.cardIDEnum.EX1_534t;
            if (s == "FP1_028") return CardDB.cardIDEnum.FP1_028;
            if (s == "EX1_604") return CardDB.cardIDEnum.EX1_604;
            if (s == "EX1_160") return CardDB.cardIDEnum.EX1_160;
            if (s == "EX1_165t1") return CardDB.cardIDEnum.EX1_165t1;
            if (s == "CS2_062") return CardDB.cardIDEnum.CS2_062;
            if (s == "CS2_155") return CardDB.cardIDEnum.CS2_155;
            if (s == "CS2_213") return CardDB.cardIDEnum.CS2_213;
            if (s == "TU4f_007") return CardDB.cardIDEnum.TU4f_007;
            if (s == "GAME_004") return CardDB.cardIDEnum.GAME_004;
            if (s == "NAX5_01") return CardDB.cardIDEnum.NAX5_01;
            if (s == "XXX_020") return CardDB.cardIDEnum.XXX_020;
            if (s == "NAX15_02H") return CardDB.cardIDEnum.NAX15_02H;
            if (s == "CS2_004") return CardDB.cardIDEnum.CS2_004;
            if (s == "NAX2_03H") return CardDB.cardIDEnum.NAX2_03H;
            if (s == "EX1_561e") return CardDB.cardIDEnum.EX1_561e;
            if (s == "CS2_023") return CardDB.cardIDEnum.CS2_023;
            if (s == "EX1_164") return CardDB.cardIDEnum.EX1_164;
            if (s == "EX1_009") return CardDB.cardIDEnum.EX1_009;
            if (s == "NAX6_01") return CardDB.cardIDEnum.NAX6_01;
            if (s == "FP1_007") return CardDB.cardIDEnum.FP1_007;
            if (s == "NAX1h_04") return CardDB.cardIDEnum.NAX1h_04;
            if (s == "NAX2_05H") return CardDB.cardIDEnum.NAX2_05H;
            if (s == "NAX10_02") return CardDB.cardIDEnum.NAX10_02;
            if (s == "EX1_345") return CardDB.cardIDEnum.EX1_345;
            if (s == "EX1_116") return CardDB.cardIDEnum.EX1_116;
            if (s == "EX1_399") return CardDB.cardIDEnum.EX1_399;
            if (s == "EX1_587") return CardDB.cardIDEnum.EX1_587;
            if (s == "XXX_026") return CardDB.cardIDEnum.XXX_026;
            if (s == "EX1_571") return CardDB.cardIDEnum.EX1_571;
            if (s == "EX1_335") return CardDB.cardIDEnum.EX1_335;
            if (s == "XXX_050") return CardDB.cardIDEnum.XXX_050;
            if (s == "TU4e_004") return CardDB.cardIDEnum.TU4e_004;
            if (s == "HERO_08") return CardDB.cardIDEnum.HERO_08;
            if (s == "EX1_166a") return CardDB.cardIDEnum.EX1_166a;
            if (s == "NAX2_03") return CardDB.cardIDEnum.NAX2_03;
            if (s == "EX1_finkle") return CardDB.cardIDEnum.EX1_finkle;
            if (s == "NAX4_03H") return CardDB.cardIDEnum.NAX4_03H;
            if (s == "EX1_164b") return CardDB.cardIDEnum.EX1_164b;
            if (s == "EX1_283") return CardDB.cardIDEnum.EX1_283;
            if (s == "EX1_339") return CardDB.cardIDEnum.EX1_339;
            if (s == "CRED_13") return CardDB.cardIDEnum.CRED_13;
            if (s == "EX1_178be") return CardDB.cardIDEnum.EX1_178be;
            if (s == "EX1_531") return CardDB.cardIDEnum.EX1_531;
            if (s == "EX1_134") return CardDB.cardIDEnum.EX1_134;
            if (s == "EX1_350") return CardDB.cardIDEnum.EX1_350;
            if (s == "EX1_308") return CardDB.cardIDEnum.EX1_308;
            if (s == "CS2_197") return CardDB.cardIDEnum.CS2_197;
            if (s == "skele21") return CardDB.cardIDEnum.skele21;
            if (s == "CS2_222o") return CardDB.cardIDEnum.CS2_222o;
            if (s == "XXX_015") return CardDB.cardIDEnum.XXX_015;
            if (s == "FP1_013") return CardDB.cardIDEnum.FP1_013;
            if (s == "NEW1_006") return CardDB.cardIDEnum.NEW1_006;
            if (s == "EX1_399e") return CardDB.cardIDEnum.EX1_399e;
            if (s == "EX1_509") return CardDB.cardIDEnum.EX1_509;
            if (s == "EX1_612") return CardDB.cardIDEnum.EX1_612;
            if (s == "NAX8_05t") return CardDB.cardIDEnum.NAX8_05t;
            if (s == "NAX9_05H") return CardDB.cardIDEnum.NAX9_05H;
            if (s == "EX1_021") return CardDB.cardIDEnum.EX1_021;
            if (s == "CS2_041e") return CardDB.cardIDEnum.CS2_041e;
            if (s == "CS2_226") return CardDB.cardIDEnum.CS2_226;
            if (s == "EX1_608") return CardDB.cardIDEnum.EX1_608;
            if (s == "NAX13_05H") return CardDB.cardIDEnum.NAX13_05H;
            if (s == "NAX13_04H") return CardDB.cardIDEnum.NAX13_04H;
            if (s == "TU4c_008") return CardDB.cardIDEnum.TU4c_008;
            if (s == "EX1_624") return CardDB.cardIDEnum.EX1_624;
            if (s == "EX1_616") return CardDB.cardIDEnum.EX1_616;
            if (s == "EX1_008") return CardDB.cardIDEnum.EX1_008;
            if (s == "PlaceholderCard") return CardDB.cardIDEnum.PlaceholderCard;
            if (s == "XXX_016") return CardDB.cardIDEnum.XXX_016;
            if (s == "EX1_045") return CardDB.cardIDEnum.EX1_045;
            if (s == "EX1_015") return CardDB.cardIDEnum.EX1_015;
            if (s == "GAME_003") return CardDB.cardIDEnum.GAME_003;
            if (s == "CS2_171") return CardDB.cardIDEnum.CS2_171;
            if (s == "CS2_041") return CardDB.cardIDEnum.CS2_041;
            if (s == "EX1_128") return CardDB.cardIDEnum.EX1_128;
            if (s == "CS2_112") return CardDB.cardIDEnum.CS2_112;
            if (s == "HERO_07") return CardDB.cardIDEnum.HERO_07;
            if (s == "EX1_412") return CardDB.cardIDEnum.EX1_412;
            if (s == "EX1_612o") return CardDB.cardIDEnum.EX1_612o;
            if (s == "CS2_117") return CardDB.cardIDEnum.CS2_117;
            if (s == "XXX_009e") return CardDB.cardIDEnum.XXX_009e;
            if (s == "EX1_562") return CardDB.cardIDEnum.EX1_562;
            if (s == "EX1_055") return CardDB.cardIDEnum.EX1_055;
            if (s == "NAX9_06") return CardDB.cardIDEnum.NAX9_06;
            if (s == "TU4e_007") return CardDB.cardIDEnum.TU4e_007;
            if (s == "FP1_012") return CardDB.cardIDEnum.FP1_012;
            if (s == "EX1_317t") return CardDB.cardIDEnum.EX1_317t;
            if (s == "EX1_004e") return CardDB.cardIDEnum.EX1_004e;
            if (s == "EX1_278") return CardDB.cardIDEnum.EX1_278;
            if (s == "CS2_tk1") return CardDB.cardIDEnum.CS2_tk1;
            if (s == "EX1_590") return CardDB.cardIDEnum.EX1_590;
            if (s == "CS1_130") return CardDB.cardIDEnum.CS1_130;
            if (s == "NEW1_008b") return CardDB.cardIDEnum.NEW1_008b;
            if (s == "EX1_365") return CardDB.cardIDEnum.EX1_365;
            if (s == "CS2_141") return CardDB.cardIDEnum.CS2_141;
            if (s == "PRO_001") return CardDB.cardIDEnum.PRO_001;
            if (s == "NAX8_04t") return CardDB.cardIDEnum.NAX8_04t;
            if (s == "CS2_173") return CardDB.cardIDEnum.CS2_173;
            if (s == "CS2_017") return CardDB.cardIDEnum.CS2_017;
            if (s == "CRED_16") return CardDB.cardIDEnum.CRED_16;
            if (s == "EX1_392") return CardDB.cardIDEnum.EX1_392;
            if (s == "EX1_593") return CardDB.cardIDEnum.EX1_593;
            if (s == "FP1_023e") return CardDB.cardIDEnum.FP1_023e;
            if (s == "NAX1_05") return CardDB.cardIDEnum.NAX1_05;
            if (s == "TU4d_002") return CardDB.cardIDEnum.TU4d_002;
            if (s == "CRED_15") return CardDB.cardIDEnum.CRED_15;
            if (s == "EX1_049") return CardDB.cardIDEnum.EX1_049;
            if (s == "EX1_002") return CardDB.cardIDEnum.EX1_002;
            if (s == "TU4f_005") return CardDB.cardIDEnum.TU4f_005;
            if (s == "NEW1_029t") return CardDB.cardIDEnum.NEW1_029t;
            if (s == "TU4a_001") return CardDB.cardIDEnum.TU4a_001;
            if (s == "CS2_056") return CardDB.cardIDEnum.CS2_056;
            if (s == "EX1_596") return CardDB.cardIDEnum.EX1_596;
            if (s == "EX1_136") return CardDB.cardIDEnum.EX1_136;
            if (s == "EX1_323") return CardDB.cardIDEnum.EX1_323;
            if (s == "CS2_073") return CardDB.cardIDEnum.CS2_073;
            if (s == "EX1_246e") return CardDB.cardIDEnum.EX1_246e;
            if (s == "NAX12_01") return CardDB.cardIDEnum.NAX12_01;
            if (s == "EX1_244e") return CardDB.cardIDEnum.EX1_244e;
            if (s == "EX1_001") return CardDB.cardIDEnum.EX1_001;
            if (s == "EX1_607e") return CardDB.cardIDEnum.EX1_607e;
            if (s == "EX1_044") return CardDB.cardIDEnum.EX1_044;
            if (s == "EX1_573ae") return CardDB.cardIDEnum.EX1_573ae;
            if (s == "XXX_025") return CardDB.cardIDEnum.XXX_025;
            if (s == "CRED_06") return CardDB.cardIDEnum.CRED_06;
            if (s == "Mekka4") return CardDB.cardIDEnum.Mekka4;
            if (s == "CS2_142") return CardDB.cardIDEnum.CS2_142;
            if (s == "TU4f_004") return CardDB.cardIDEnum.TU4f_004;
            if (s == "NAX5_02H") return CardDB.cardIDEnum.NAX5_02H;
            if (s == "EX1_411e2") return CardDB.cardIDEnum.EX1_411e2;
            if (s == "EX1_573") return CardDB.cardIDEnum.EX1_573;
            if (s == "FP1_009") return CardDB.cardIDEnum.FP1_009;
            if (s == "CS2_050") return CardDB.cardIDEnum.CS2_050;
            if (s == "NAX4_03") return CardDB.cardIDEnum.NAX4_03;
            if (s == "CS2_063e") return CardDB.cardIDEnum.CS2_063e;
            if (s == "NAX2_05") return CardDB.cardIDEnum.NAX2_05;
            if (s == "EX1_390") return CardDB.cardIDEnum.EX1_390;
            if (s == "EX1_610") return CardDB.cardIDEnum.EX1_610;
            if (s == "hexfrog") return CardDB.cardIDEnum.hexfrog;
            if (s == "CS2_181e") return CardDB.cardIDEnum.CS2_181e;
            if (s == "NAX6_02") return CardDB.cardIDEnum.NAX6_02;
            if (s == "XXX_027") return CardDB.cardIDEnum.XXX_027;
            if (s == "CS2_082") return CardDB.cardIDEnum.CS2_082;
            if (s == "NEW1_040") return CardDB.cardIDEnum.NEW1_040;
            if (s == "DREAM_01") return CardDB.cardIDEnum.DREAM_01;
            if (s == "EX1_595") return CardDB.cardIDEnum.EX1_595;
            if (s == "CS2_013") return CardDB.cardIDEnum.CS2_013;
            if (s == "CS2_077") return CardDB.cardIDEnum.CS2_077;
            if (s == "NEW1_014") return CardDB.cardIDEnum.NEW1_014;
            if (s == "CRED_05") return CardDB.cardIDEnum.CRED_05;
            if (s == "GAME_002") return CardDB.cardIDEnum.GAME_002;
            if (s == "EX1_165") return CardDB.cardIDEnum.EX1_165;
            if (s == "CS2_013t") return CardDB.cardIDEnum.CS2_013t;
            if (s == "NAX4_04H") return CardDB.cardIDEnum.NAX4_04H;
            if (s == "EX1_tk11") return CardDB.cardIDEnum.EX1_tk11;
            if (s == "EX1_591") return CardDB.cardIDEnum.EX1_591;
            if (s == "EX1_549") return CardDB.cardIDEnum.EX1_549;
            if (s == "CS2_045") return CardDB.cardIDEnum.CS2_045;
            if (s == "CS2_237") return CardDB.cardIDEnum.CS2_237;
            if (s == "CS2_027") return CardDB.cardIDEnum.CS2_027;
            if (s == "EX1_508o") return CardDB.cardIDEnum.EX1_508o;
            if (s == "NAX14_03") return CardDB.cardIDEnum.NAX14_03;
            if (s == "CS2_101t") return CardDB.cardIDEnum.CS2_101t;
            if (s == "CS2_063") return CardDB.cardIDEnum.CS2_063;
            if (s == "EX1_145") return CardDB.cardIDEnum.EX1_145;
            if (s == "NAX1h_03") return CardDB.cardIDEnum.NAX1h_03;
            if (s == "EX1_110") return CardDB.cardIDEnum.EX1_110;
            if (s == "EX1_408") return CardDB.cardIDEnum.EX1_408;
            if (s == "EX1_544") return CardDB.cardIDEnum.EX1_544;
            if (s == "TU4c_006") return CardDB.cardIDEnum.TU4c_006;
            if (s == "NAXM_001") return CardDB.cardIDEnum.NAXM_001;
            if (s == "CS2_151") return CardDB.cardIDEnum.CS2_151;
            if (s == "CS2_073e") return CardDB.cardIDEnum.CS2_073e;
            if (s == "XXX_006") return CardDB.cardIDEnum.XXX_006;
            if (s == "CS2_088") return CardDB.cardIDEnum.CS2_088;
            if (s == "EX1_057") return CardDB.cardIDEnum.EX1_057;
            if (s == "FP1_020") return CardDB.cardIDEnum.FP1_020;
            if (s == "CS2_169") return CardDB.cardIDEnum.CS2_169;
            if (s == "EX1_573t") return CardDB.cardIDEnum.EX1_573t;
            if (s == "EX1_323h") return CardDB.cardIDEnum.EX1_323h;
            if (s == "EX1_tk9") return CardDB.cardIDEnum.EX1_tk9;
            if (s == "NEW1_018e") return CardDB.cardIDEnum.NEW1_018e;
            if (s == "CS2_037") return CardDB.cardIDEnum.CS2_037;
            if (s == "CS2_007") return CardDB.cardIDEnum.CS2_007;
            if (s == "EX1_059e2") return CardDB.cardIDEnum.EX1_059e2;
            if (s == "CS2_227") return CardDB.cardIDEnum.CS2_227;
            if (s == "NAX7_03H") return CardDB.cardIDEnum.NAX7_03H;
            if (s == "NAX9_01H") return CardDB.cardIDEnum.NAX9_01H;
            if (s == "EX1_570e") return CardDB.cardIDEnum.EX1_570e;
            if (s == "NEW1_003") return CardDB.cardIDEnum.NEW1_003;
            if (s == "GAME_006") return CardDB.cardIDEnum.GAME_006;
            if (s == "EX1_320") return CardDB.cardIDEnum.EX1_320;
            if (s == "EX1_097") return CardDB.cardIDEnum.EX1_097;
            if (s == "tt_004") return CardDB.cardIDEnum.tt_004;
            if (s == "EX1_360e") return CardDB.cardIDEnum.EX1_360e;
            if (s == "EX1_096") return CardDB.cardIDEnum.EX1_096;
            if (s == "DS1_175o") return CardDB.cardIDEnum.DS1_175o;
            if (s == "EX1_596e") return CardDB.cardIDEnum.EX1_596e;
            if (s == "XXX_014") return CardDB.cardIDEnum.XXX_014;
            if (s == "EX1_158e") return CardDB.cardIDEnum.EX1_158e;
            if (s == "NAX14_01") return CardDB.cardIDEnum.NAX14_01;
            if (s == "CRED_01") return CardDB.cardIDEnum.CRED_01;
            if (s == "CRED_08") return CardDB.cardIDEnum.CRED_08;
            if (s == "EX1_126") return CardDB.cardIDEnum.EX1_126;
            if (s == "EX1_577") return CardDB.cardIDEnum.EX1_577;
            if (s == "EX1_319") return CardDB.cardIDEnum.EX1_319;
            if (s == "EX1_611") return CardDB.cardIDEnum.EX1_611;
            if (s == "CS2_146") return CardDB.cardIDEnum.CS2_146;
            if (s == "EX1_154b") return CardDB.cardIDEnum.EX1_154b;
            if (s == "skele11") return CardDB.cardIDEnum.skele11;
            if (s == "EX1_165t2") return CardDB.cardIDEnum.EX1_165t2;
            if (s == "CS2_172") return CardDB.cardIDEnum.CS2_172;
            if (s == "CS2_114") return CardDB.cardIDEnum.CS2_114;
            if (s == "CS1_069") return CardDB.cardIDEnum.CS1_069;
            if (s == "XXX_003") return CardDB.cardIDEnum.XXX_003;
            if (s == "XXX_042") return CardDB.cardIDEnum.XXX_042;
            if (s == "NAX8_02") return CardDB.cardIDEnum.NAX8_02;
            if (s == "EX1_173") return CardDB.cardIDEnum.EX1_173;
            if (s == "CS1_042") return CardDB.cardIDEnum.CS1_042;
            if (s == "NAX8_03") return CardDB.cardIDEnum.NAX8_03;
            if (s == "EX1_506a") return CardDB.cardIDEnum.EX1_506a;
            if (s == "EX1_298") return CardDB.cardIDEnum.EX1_298;
            if (s == "CS2_104") return CardDB.cardIDEnum.CS2_104;
            if (s == "FP1_001") return CardDB.cardIDEnum.FP1_001;
            if (s == "HERO_02") return CardDB.cardIDEnum.HERO_02;
            if (s == "EX1_316e") return CardDB.cardIDEnum.EX1_316e;
            if (s == "NAX7_01") return CardDB.cardIDEnum.NAX7_01;
            if (s == "EX1_044e") return CardDB.cardIDEnum.EX1_044e;
            if (s == "CS2_051") return CardDB.cardIDEnum.CS2_051;
            if (s == "NEW1_016") return CardDB.cardIDEnum.NEW1_016;
            if (s == "EX1_304e") return CardDB.cardIDEnum.EX1_304e;
            if (s == "EX1_033") return CardDB.cardIDEnum.EX1_033;
            if (s == "NAX8_04") return CardDB.cardIDEnum.NAX8_04;
            if (s == "EX1_028") return CardDB.cardIDEnum.EX1_028;
            if (s == "XXX_011") return CardDB.cardIDEnum.XXX_011;
            if (s == "EX1_621") return CardDB.cardIDEnum.EX1_621;
            if (s == "EX1_554") return CardDB.cardIDEnum.EX1_554;
            if (s == "EX1_091") return CardDB.cardIDEnum.EX1_091;
            if (s == "FP1_017") return CardDB.cardIDEnum.FP1_017;
            if (s == "EX1_409") return CardDB.cardIDEnum.EX1_409;
            if (s == "EX1_363e") return CardDB.cardIDEnum.EX1_363e;
            if (s == "EX1_410") return CardDB.cardIDEnum.EX1_410;
            if (s == "TU4e_005") return CardDB.cardIDEnum.TU4e_005;
            if (s == "CS2_039") return CardDB.cardIDEnum.CS2_039;
            if (s == "NAX12_04") return CardDB.cardIDEnum.NAX12_04;
            if (s == "EX1_557") return CardDB.cardIDEnum.EX1_557;
            if (s == "CS2_105e") return CardDB.cardIDEnum.CS2_105e;
            if (s == "EX1_128e") return CardDB.cardIDEnum.EX1_128e;
            if (s == "XXX_021") return CardDB.cardIDEnum.XXX_021;
            if (s == "DS1_070") return CardDB.cardIDEnum.DS1_070;
            if (s == "CS2_033") return CardDB.cardIDEnum.CS2_033;
            if (s == "EX1_536") return CardDB.cardIDEnum.EX1_536;
            if (s == "TU4a_003") return CardDB.cardIDEnum.TU4a_003;
            if (s == "EX1_559") return CardDB.cardIDEnum.EX1_559;
            if (s == "XXX_023") return CardDB.cardIDEnum.XXX_023;
            if (s == "NEW1_033o") return CardDB.cardIDEnum.NEW1_033o;
            if (s == "NAX15_04H") return CardDB.cardIDEnum.NAX15_04H;
            if (s == "CS2_004e") return CardDB.cardIDEnum.CS2_004e;
            if (s == "CS2_052") return CardDB.cardIDEnum.CS2_052;
            if (s == "EX1_539") return CardDB.cardIDEnum.EX1_539;
            if (s == "EX1_575") return CardDB.cardIDEnum.EX1_575;
            if (s == "CS2_083b") return CardDB.cardIDEnum.CS2_083b;
            if (s == "CS2_061") return CardDB.cardIDEnum.CS2_061;
            if (s == "NEW1_021") return CardDB.cardIDEnum.NEW1_021;
            if (s == "DS1_055") return CardDB.cardIDEnum.DS1_055;
            if (s == "EX1_625") return CardDB.cardIDEnum.EX1_625;
            if (s == "EX1_382e") return CardDB.cardIDEnum.EX1_382e;
            if (s == "CS2_092e") return CardDB.cardIDEnum.CS2_092e;
            if (s == "CS2_026") return CardDB.cardIDEnum.CS2_026;
            if (s == "NAX14_04") return CardDB.cardIDEnum.NAX14_04;
            if (s == "NEW1_012o") return CardDB.cardIDEnum.NEW1_012o;
            if (s == "EX1_619e") return CardDB.cardIDEnum.EX1_619e;
            if (s == "EX1_294") return CardDB.cardIDEnum.EX1_294;
            if (s == "EX1_287") return CardDB.cardIDEnum.EX1_287;
            if (s == "EX1_509e") return CardDB.cardIDEnum.EX1_509e;
            if (s == "EX1_625t2") return CardDB.cardIDEnum.EX1_625t2;
            if (s == "CS2_118") return CardDB.cardIDEnum.CS2_118;
            if (s == "CS2_124") return CardDB.cardIDEnum.CS2_124;
            if (s == "Mekka3") return CardDB.cardIDEnum.Mekka3;
            if (s == "NAX13_02") return CardDB.cardIDEnum.NAX13_02;
            if (s == "EX1_112") return CardDB.cardIDEnum.EX1_112;
            if (s == "FP1_011") return CardDB.cardIDEnum.FP1_011;
            if (s == "CS2_009e") return CardDB.cardIDEnum.CS2_009e;
            if (s == "HERO_04") return CardDB.cardIDEnum.HERO_04;
            if (s == "EX1_607") return CardDB.cardIDEnum.EX1_607;
            if (s == "DREAM_03") return CardDB.cardIDEnum.DREAM_03;
            if (s == "NAX11_04e") return CardDB.cardIDEnum.NAX11_04e;
            if (s == "EX1_103e") return CardDB.cardIDEnum.EX1_103e;
            if (s == "XXX_046") return CardDB.cardIDEnum.XXX_046;
            if (s == "FP1_003") return CardDB.cardIDEnum.FP1_003;
            if (s == "CS2_105") return CardDB.cardIDEnum.CS2_105;
            if (s == "FP1_002") return CardDB.cardIDEnum.FP1_002;
            if (s == "TU4c_002") return CardDB.cardIDEnum.TU4c_002;
            if (s == "CRED_14") return CardDB.cardIDEnum.CRED_14;
            if (s == "EX1_567") return CardDB.cardIDEnum.EX1_567;
            if (s == "TU4c_004") return CardDB.cardIDEnum.TU4c_004;
            if (s == "NAX10_03H") return CardDB.cardIDEnum.NAX10_03H;
            if (s == "FP1_008") return CardDB.cardIDEnum.FP1_008;
            if (s == "DS1_184") return CardDB.cardIDEnum.DS1_184;
            if (s == "CS2_029") return CardDB.cardIDEnum.CS2_029;
            if (s == "GAME_005") return CardDB.cardIDEnum.GAME_005;
            if (s == "CS2_187") return CardDB.cardIDEnum.CS2_187;
            if (s == "EX1_020") return CardDB.cardIDEnum.EX1_020;
            if (s == "NAX15_01He") return CardDB.cardIDEnum.NAX15_01He;
            if (s == "EX1_011") return CardDB.cardIDEnum.EX1_011;
            if (s == "CS2_057") return CardDB.cardIDEnum.CS2_057;
            if (s == "EX1_274") return CardDB.cardIDEnum.EX1_274;
            if (s == "EX1_306") return CardDB.cardIDEnum.EX1_306;
            if (s == "NEW1_038o") return CardDB.cardIDEnum.NEW1_038o;
            if (s == "EX1_170") return CardDB.cardIDEnum.EX1_170;
            if (s == "EX1_617") return CardDB.cardIDEnum.EX1_617;
            if (s == "CS1_113e") return CardDB.cardIDEnum.CS1_113e;
            if (s == "CS2_101") return CardDB.cardIDEnum.CS2_101;
            if (s == "FP1_015") return CardDB.cardIDEnum.FP1_015;
            if (s == "NAX13_03") return CardDB.cardIDEnum.NAX13_03;
            if (s == "CS2_005") return CardDB.cardIDEnum.CS2_005;
            if (s == "EX1_537") return CardDB.cardIDEnum.EX1_537;
            if (s == "EX1_384") return CardDB.cardIDEnum.EX1_384;
            if (s == "TU4a_002") return CardDB.cardIDEnum.TU4a_002;
            if (s == "NAX9_04") return CardDB.cardIDEnum.NAX9_04;
            if (s == "EX1_362") return CardDB.cardIDEnum.EX1_362;
            if (s == "NAX12_02") return CardDB.cardIDEnum.NAX12_02;
            if (s == "FP1_028e") return CardDB.cardIDEnum.FP1_028e;
            if (s == "TU4c_005") return CardDB.cardIDEnum.TU4c_005;
            if (s == "EX1_301") return CardDB.cardIDEnum.EX1_301;
            if (s == "CS2_235") return CardDB.cardIDEnum.CS2_235;
            if (s == "NAX4_05") return CardDB.cardIDEnum.NAX4_05;
            if (s == "EX1_029") return CardDB.cardIDEnum.EX1_029;
            if (s == "CS2_042") return CardDB.cardIDEnum.CS2_042;
            if (s == "EX1_155a") return CardDB.cardIDEnum.EX1_155a;
            if (s == "CS2_102") return CardDB.cardIDEnum.CS2_102;
            if (s == "EX1_609") return CardDB.cardIDEnum.EX1_609;
            if (s == "NEW1_027") return CardDB.cardIDEnum.NEW1_027;
            if (s == "CS2_236e") return CardDB.cardIDEnum.CS2_236e;
            if (s == "CS2_083e") return CardDB.cardIDEnum.CS2_083e;
            if (s == "NAX6_03te") return CardDB.cardIDEnum.NAX6_03te;
            if (s == "EX1_165a") return CardDB.cardIDEnum.EX1_165a;
            if (s == "EX1_570") return CardDB.cardIDEnum.EX1_570;
            if (s == "EX1_131") return CardDB.cardIDEnum.EX1_131;
            if (s == "EX1_556") return CardDB.cardIDEnum.EX1_556;
            if (s == "EX1_543") return CardDB.cardIDEnum.EX1_543;
            if (s == "XXX_096") return CardDB.cardIDEnum.XXX_096;
            if (s == "TU4c_008e") return CardDB.cardIDEnum.TU4c_008e;
            if (s == "EX1_379e") return CardDB.cardIDEnum.EX1_379e;
            if (s == "NEW1_009") return CardDB.cardIDEnum.NEW1_009;
            if (s == "EX1_100") return CardDB.cardIDEnum.EX1_100;
            if (s == "EX1_274e") return CardDB.cardIDEnum.EX1_274e;
            if (s == "CRED_02") return CardDB.cardIDEnum.CRED_02;
            if (s == "EX1_573a") return CardDB.cardIDEnum.EX1_573a;
            if (s == "CS2_084") return CardDB.cardIDEnum.CS2_084;
            if (s == "EX1_582") return CardDB.cardIDEnum.EX1_582;
            if (s == "EX1_043") return CardDB.cardIDEnum.EX1_043;
            if (s == "EX1_050") return CardDB.cardIDEnum.EX1_050;
            if (s == "TU4b_001") return CardDB.cardIDEnum.TU4b_001;
            if (s == "FP1_005") return CardDB.cardIDEnum.FP1_005;
            if (s == "EX1_620") return CardDB.cardIDEnum.EX1_620;
            if (s == "NAX15_01") return CardDB.cardIDEnum.NAX15_01;
            if (s == "NAX6_03") return CardDB.cardIDEnum.NAX6_03;
            if (s == "EX1_303") return CardDB.cardIDEnum.EX1_303;
            if (s == "HERO_09") return CardDB.cardIDEnum.HERO_09;
            if (s == "EX1_067") return CardDB.cardIDEnum.EX1_067;
            if (s == "XXX_028") return CardDB.cardIDEnum.XXX_028;
            if (s == "EX1_277") return CardDB.cardIDEnum.EX1_277;
            if (s == "Mekka2") return CardDB.cardIDEnum.Mekka2;
            if (s == "NAX14_01H") return CardDB.cardIDEnum.NAX14_01H;
            if (s == "NAX15_04") return CardDB.cardIDEnum.NAX15_04;
            if (s == "FP1_024") return CardDB.cardIDEnum.FP1_024;
            if (s == "FP1_030") return CardDB.cardIDEnum.FP1_030;
            if (s == "CS2_221e") return CardDB.cardIDEnum.CS2_221e;
            if (s == "EX1_178") return CardDB.cardIDEnum.EX1_178;
            if (s == "CS2_222") return CardDB.cardIDEnum.CS2_222;
            if (s == "EX1_409e") return CardDB.cardIDEnum.EX1_409e;
            if (s == "tt_004o") return CardDB.cardIDEnum.tt_004o;
            if (s == "EX1_155ae") return CardDB.cardIDEnum.EX1_155ae;
            if (s == "NAX11_01H") return CardDB.cardIDEnum.NAX11_01H;
            if (s == "EX1_160a") return CardDB.cardIDEnum.EX1_160a;
            if (s == "NAX15_02") return CardDB.cardIDEnum.NAX15_02;
            if (s == "NAX15_05") return CardDB.cardIDEnum.NAX15_05;
            if (s == "NEW1_025e") return CardDB.cardIDEnum.NEW1_025e;
            if (s == "CS2_012") return CardDB.cardIDEnum.CS2_012;
            if (s == "XXX_099") return CardDB.cardIDEnum.XXX_099;
            if (s == "EX1_246") return CardDB.cardIDEnum.EX1_246;
            if (s == "EX1_572") return CardDB.cardIDEnum.EX1_572;
            if (s == "EX1_089") return CardDB.cardIDEnum.EX1_089;
            if (s == "CS2_059") return CardDB.cardIDEnum.CS2_059;
            if (s == "EX1_279") return CardDB.cardIDEnum.EX1_279;
            if (s == "NAX12_02e") return CardDB.cardIDEnum.NAX12_02e;
            if (s == "CS2_168") return CardDB.cardIDEnum.CS2_168;
            if (s == "tt_010") return CardDB.cardIDEnum.tt_010;
            if (s == "NEW1_023") return CardDB.cardIDEnum.NEW1_023;
            if (s == "CS2_075") return CardDB.cardIDEnum.CS2_075;
            if (s == "EX1_316") return CardDB.cardIDEnum.EX1_316;
            if (s == "CS2_025") return CardDB.cardIDEnum.CS2_025;
            if (s == "CS2_234") return CardDB.cardIDEnum.CS2_234;
            if (s == "XXX_043") return CardDB.cardIDEnum.XXX_043;
            if (s == "GAME_001") return CardDB.cardIDEnum.GAME_001;
            if (s == "NAX5_02") return CardDB.cardIDEnum.NAX5_02;
            if (s == "EX1_130") return CardDB.cardIDEnum.EX1_130;
            if (s == "EX1_584e") return CardDB.cardIDEnum.EX1_584e;
            if (s == "CS2_064") return CardDB.cardIDEnum.CS2_064;
            if (s == "EX1_161") return CardDB.cardIDEnum.EX1_161;
            if (s == "CS2_049") return CardDB.cardIDEnum.CS2_049;
            if (s == "NAX13_01") return CardDB.cardIDEnum.NAX13_01;
            if (s == "EX1_154") return CardDB.cardIDEnum.EX1_154;
            if (s == "EX1_080") return CardDB.cardIDEnum.EX1_080;
            if (s == "NEW1_022") return CardDB.cardIDEnum.NEW1_022;
            if (s == "NAX2_01H") return CardDB.cardIDEnum.NAX2_01H;
            if (s == "EX1_160be") return CardDB.cardIDEnum.EX1_160be;
            if (s == "NAX12_03") return CardDB.cardIDEnum.NAX12_03;
            if (s == "EX1_251") return CardDB.cardIDEnum.EX1_251;
            if (s == "FP1_025") return CardDB.cardIDEnum.FP1_025;
            if (s == "EX1_371") return CardDB.cardIDEnum.EX1_371;
            if (s == "CS2_mirror") return CardDB.cardIDEnum.CS2_mirror;
            if (s == "NAX4_01H") return CardDB.cardIDEnum.NAX4_01H;
            if (s == "EX1_594") return CardDB.cardIDEnum.EX1_594;
            if (s == "NAX14_02") return CardDB.cardIDEnum.NAX14_02;
            if (s == "TU4c_006e") return CardDB.cardIDEnum.TU4c_006e;
            if (s == "EX1_560") return CardDB.cardIDEnum.EX1_560;
            if (s == "CS2_236") return CardDB.cardIDEnum.CS2_236;
            if (s == "TU4f_006") return CardDB.cardIDEnum.TU4f_006;
            if (s == "EX1_402") return CardDB.cardIDEnum.EX1_402;
            if (s == "NAX3_01") return CardDB.cardIDEnum.NAX3_01;
            if (s == "EX1_506") return CardDB.cardIDEnum.EX1_506;
            if (s == "NEW1_027e") return CardDB.cardIDEnum.NEW1_027e;
            if (s == "DS1_070o") return CardDB.cardIDEnum.DS1_070o;
            if (s == "XXX_045") return CardDB.cardIDEnum.XXX_045;
            if (s == "XXX_029") return CardDB.cardIDEnum.XXX_029;
            if (s == "DS1_178") return CardDB.cardIDEnum.DS1_178;
            if (s == "XXX_098") return CardDB.cardIDEnum.XXX_098;
            if (s == "EX1_315") return CardDB.cardIDEnum.EX1_315;
            if (s == "CS2_094") return CardDB.cardIDEnum.CS2_094;
            if (s == "NAX13_01H") return CardDB.cardIDEnum.NAX13_01H;
            if (s == "TU4e_002t") return CardDB.cardIDEnum.TU4e_002t;
            if (s == "EX1_046e") return CardDB.cardIDEnum.EX1_046e;
            if (s == "NEW1_040t") return CardDB.cardIDEnum.NEW1_040t;
            if (s == "GAME_005e") return CardDB.cardIDEnum.GAME_005e;
            if (s == "CS2_131") return CardDB.cardIDEnum.CS2_131;
            if (s == "XXX_008") return CardDB.cardIDEnum.XXX_008;
            if (s == "EX1_531e") return CardDB.cardIDEnum.EX1_531e;
            if (s == "CS2_226e") return CardDB.cardIDEnum.CS2_226e;
            if (s == "XXX_022e") return CardDB.cardIDEnum.XXX_022e;
            if (s == "DS1_178e") return CardDB.cardIDEnum.DS1_178e;
            if (s == "CS2_226o") return CardDB.cardIDEnum.CS2_226o;
            if (s == "NAX9_04H") return CardDB.cardIDEnum.NAX9_04H;
            if (s == "Mekka4e") return CardDB.cardIDEnum.Mekka4e;
            if (s == "EX1_082") return CardDB.cardIDEnum.EX1_082;
            if (s == "CS2_093") return CardDB.cardIDEnum.CS2_093;
            if (s == "EX1_411e") return CardDB.cardIDEnum.EX1_411e;
            if (s == "NAX8_03t") return CardDB.cardIDEnum.NAX8_03t;
            if (s == "EX1_145o") return CardDB.cardIDEnum.EX1_145o;
            if (s == "NAX7_04") return CardDB.cardIDEnum.NAX7_04;
            if (s == "CS2_boar") return CardDB.cardIDEnum.CS2_boar;
            if (s == "NEW1_019") return CardDB.cardIDEnum.NEW1_019;
            if (s == "EX1_289") return CardDB.cardIDEnum.EX1_289;
            if (s == "EX1_025t") return CardDB.cardIDEnum.EX1_025t;
            if (s == "EX1_398t") return CardDB.cardIDEnum.EX1_398t;
            if (s == "NAX12_03H") return CardDB.cardIDEnum.NAX12_03H;
            if (s == "EX1_055o") return CardDB.cardIDEnum.EX1_055o;
            if (s == "CS2_091") return CardDB.cardIDEnum.CS2_091;
            if (s == "EX1_241") return CardDB.cardIDEnum.EX1_241;
            if (s == "EX1_085") return CardDB.cardIDEnum.EX1_085;
            if (s == "CS2_200") return CardDB.cardIDEnum.CS2_200;
            if (s == "CS2_034") return CardDB.cardIDEnum.CS2_034;
            if (s == "EX1_583") return CardDB.cardIDEnum.EX1_583;
            if (s == "EX1_584") return CardDB.cardIDEnum.EX1_584;
            if (s == "EX1_155") return CardDB.cardIDEnum.EX1_155;
            if (s == "EX1_622") return CardDB.cardIDEnum.EX1_622;
            if (s == "CS2_203") return CardDB.cardIDEnum.CS2_203;
            if (s == "EX1_124") return CardDB.cardIDEnum.EX1_124;
            if (s == "EX1_379") return CardDB.cardIDEnum.EX1_379;
            if (s == "NAX7_02") return CardDB.cardIDEnum.NAX7_02;
            if (s == "CS2_053e") return CardDB.cardIDEnum.CS2_053e;
            if (s == "EX1_032") return CardDB.cardIDEnum.EX1_032;
            if (s == "NAX9_01") return CardDB.cardIDEnum.NAX9_01;
            if (s == "TU4e_003") return CardDB.cardIDEnum.TU4e_003;
            if (s == "CS2_146o") return CardDB.cardIDEnum.CS2_146o;
            if (s == "NAX8_01H") return CardDB.cardIDEnum.NAX8_01H;
            if (s == "XXX_041") return CardDB.cardIDEnum.XXX_041;
            if (s == "NAXM_002") return CardDB.cardIDEnum.NAXM_002;
            if (s == "EX1_391") return CardDB.cardIDEnum.EX1_391;
            if (s == "EX1_366") return CardDB.cardIDEnum.EX1_366;
            if (s == "EX1_059e") return CardDB.cardIDEnum.EX1_059e;
            if (s == "XXX_012") return CardDB.cardIDEnum.XXX_012;
            if (s == "EX1_565o") return CardDB.cardIDEnum.EX1_565o;
            if (s == "EX1_001e") return CardDB.cardIDEnum.EX1_001e;
            if (s == "TU4f_003") return CardDB.cardIDEnum.TU4f_003;
            if (s == "EX1_400") return CardDB.cardIDEnum.EX1_400;
            if (s == "EX1_614") return CardDB.cardIDEnum.EX1_614;
            if (s == "EX1_561") return CardDB.cardIDEnum.EX1_561;
            if (s == "EX1_332") return CardDB.cardIDEnum.EX1_332;
            if (s == "HERO_05") return CardDB.cardIDEnum.HERO_05;
            if (s == "CS2_065") return CardDB.cardIDEnum.CS2_065;
            if (s == "ds1_whelptoken") return CardDB.cardIDEnum.ds1_whelptoken;
            if (s == "EX1_536e") return CardDB.cardIDEnum.EX1_536e;
            if (s == "CS2_032") return CardDB.cardIDEnum.CS2_032;
            if (s == "CS2_120") return CardDB.cardIDEnum.CS2_120;
            if (s == "EX1_155be") return CardDB.cardIDEnum.EX1_155be;
            if (s == "EX1_247") return CardDB.cardIDEnum.EX1_247;
            if (s == "EX1_154a") return CardDB.cardIDEnum.EX1_154a;
            if (s == "EX1_554t") return CardDB.cardIDEnum.EX1_554t;
            if (s == "CS2_103e2") return CardDB.cardIDEnum.CS2_103e2;
            if (s == "TU4d_003") return CardDB.cardIDEnum.TU4d_003;
            if (s == "NEW1_026t") return CardDB.cardIDEnum.NEW1_026t;
            if (s == "EX1_623") return CardDB.cardIDEnum.EX1_623;
            if (s == "EX1_383t") return CardDB.cardIDEnum.EX1_383t;
            if (s == "NAX7_03") return CardDB.cardIDEnum.NAX7_03;
            if (s == "EX1_597") return CardDB.cardIDEnum.EX1_597;
            if (s == "TU4f_006o") return CardDB.cardIDEnum.TU4f_006o;
            if (s == "EX1_130a") return CardDB.cardIDEnum.EX1_130a;
            if (s == "CS2_011") return CardDB.cardIDEnum.CS2_011;
            if (s == "EX1_169") return CardDB.cardIDEnum.EX1_169;
            if (s == "EX1_tk33") return CardDB.cardIDEnum.EX1_tk33;
            if (s == "NAX11_03") return CardDB.cardIDEnum.NAX11_03;
            if (s == "NAX4_01") return CardDB.cardIDEnum.NAX4_01;
            if (s == "NAX10_01") return CardDB.cardIDEnum.NAX10_01;
            if (s == "EX1_250") return CardDB.cardIDEnum.EX1_250;
            if (s == "EX1_564") return CardDB.cardIDEnum.EX1_564;
            if (s == "NAX5_03") return CardDB.cardIDEnum.NAX5_03;
            if (s == "EX1_043e") return CardDB.cardIDEnum.EX1_043e;
            if (s == "EX1_349") return CardDB.cardIDEnum.EX1_349;
            if (s == "XXX_097") return CardDB.cardIDEnum.XXX_097;
            if (s == "EX1_102") return CardDB.cardIDEnum.EX1_102;
            if (s == "EX1_058") return CardDB.cardIDEnum.EX1_058;
            if (s == "EX1_243") return CardDB.cardIDEnum.EX1_243;
            if (s == "PRO_001c") return CardDB.cardIDEnum.PRO_001c;
            if (s == "EX1_116t") return CardDB.cardIDEnum.EX1_116t;
            if (s == "NAX15_01e") return CardDB.cardIDEnum.NAX15_01e;
            if (s == "FP1_029") return CardDB.cardIDEnum.FP1_029;
            if (s == "CS2_089") return CardDB.cardIDEnum.CS2_089;
            if (s == "TU4c_001") return CardDB.cardIDEnum.TU4c_001;
            if (s == "EX1_248") return CardDB.cardIDEnum.EX1_248;
            if (s == "NEW1_037e") return CardDB.cardIDEnum.NEW1_037e;
            if (s == "CS2_122") return CardDB.cardIDEnum.CS2_122;
            if (s == "EX1_393") return CardDB.cardIDEnum.EX1_393;
            if (s == "CS2_232") return CardDB.cardIDEnum.CS2_232;
            if (s == "EX1_165b") return CardDB.cardIDEnum.EX1_165b;
            if (s == "NEW1_030") return CardDB.cardIDEnum.NEW1_030;
            if (s == "EX1_161o") return CardDB.cardIDEnum.EX1_161o;
            if (s == "EX1_093e") return CardDB.cardIDEnum.EX1_093e;
            if (s == "CS2_150") return CardDB.cardIDEnum.CS2_150;
            if (s == "CS2_152") return CardDB.cardIDEnum.CS2_152;
            if (s == "NAX9_03H") return CardDB.cardIDEnum.NAX9_03H;
            if (s == "EX1_160t") return CardDB.cardIDEnum.EX1_160t;
            if (s == "CS2_127") return CardDB.cardIDEnum.CS2_127;
            if (s == "CRED_03") return CardDB.cardIDEnum.CRED_03;
            if (s == "DS1_188") return CardDB.cardIDEnum.DS1_188;
            if (s == "XXX_001") return CardDB.cardIDEnum.XXX_001;
            return CardDB.cardIDEnum.None;
        }

        public enum cardName
        {
            unknown,
            hogger,
            heigantheunclean,
            necroticaura,
            starfall,
            barrel,
            damagereflector,
            edwinvancleef,
            gothiktheharvester,
            perditionsblade,
            bloodsailraider,
            guardianoficecrown,
            bloodmagethalnos,
            rooted,
            wisp,
            rachelledavis,
            senjinshieldmasta,
            totemicmight,
            uproot,
            opponentdisconnect,
            unrelentingrider,
            shandoslesson,
            hemetnesingwary,
            decimate,
            shadowofnothing,
            nerubian,
            dragonlingmechanic,
            mogushanwarden,
            thanekorthazz,
            hungrycrab,
            ancientteachings,
            misdirection,
            patientassassin,
            mutatinginjection,
            violetteacher,
            arathiweaponsmith,
            raisedead,
            acolyteofpain,
            holynova,
            robpardo,
            commandingshout,
            necroticpoison,
            unboundelemental,
            garroshhellscream,
            enchant,
            loatheb,
            blessingofmight,
            nightmare,
            blessingofkings,
            polymorph,
            darkirondwarf,
            destroy,
            roguesdoit,
            freecards,
            iammurloc,
            sporeburst,
            mindcontrolcrystal,
            charge,
            stampedingkodo,
            humility,
            darkcultist,
            gruul,
            markofthewild,
            patchwerk,
            worgeninfiltrator,
            frostbolt,
            runeblade,
            flametonguetotem,
            assassinate,
            madscientist,
            lordofthearena,
            bainebloodhoof,
            injuredblademaster,
            siphonsoul,
            layonhands,
            hook,
            massiveruneblade,
            lorewalkercho,
            destroyallminions,
            silvermoonguardian,
            destroyallmana,
            huffer,
            mindvision,
            malfurionstormrage,
            corehound,
            grimscaleoracle,
            lightningstorm,
            lightwell,
            benthompson,
            coldlightseer,
            deathsbite,
            gorehowl,
            skitter,
            farsight,
            chillwindyeti,
            moonfire,
            bladeflurry,
            massdispel,
            crazedalchemist,
            shadowmadness,
            equality,
            misha,
            treant,
            alarmobot,
            animalcompanion,
            hatefulstrike,
            dream,
            anubrekhan,
            youngpriestess,
            gadgetzanauctioneer,
            coneofcold,
            earthshock,
            tirionfordring,
            wailingsoul,
            skeleton,
            ironfurgrizzly,
            headcrack,
            arcaneshot,
            maexxna,
            imp,
            markofthehorsemen,
            voidterror,
            mortalcoil,
            draw3cards,
            flameofazzinoth,
            jainaproudmoore,
            execute,
            bloodlust,
            bananas,
            kidnapper,
            oldmurkeye,
            homingchicken,
            enableforattack,
            spellbender,
            backstab,
            squirrel,
            stalagg,
            grandwidowfaerlina,
            heavyaxe,
            zwick,
            webwrap,
            flamesofazzinoth,
            murlocwarleader,
            shadowstep,
            ancestralspirit,
            defenderofargus,
            assassinsblade,
            discard,
            biggamehunter,
            aldorpeacekeeper,
            blizzard,
            pandarenscout,
            unleashthehounds,
            yseraawakens,
            sap,
            kelthuzad,
            defiasbandit,
            gnomishinventor,
            mindcontrol,
            ravenholdtassassin,
            icelance,
            dispel,
            acidicswampooze,
            muklasbigbrother,
            blessedchampion,
            savannahhighmane,
            direwolfalpha,
            hoggersmash,
            blessingofwisdom,
            nourish,
            abusivesergeant,
            sylvanaswindrunner,
            spore,
            crueltaskmaster,
            lightningbolt,
            keeperofthegrove,
            steadyshot,
            multishot,
            harvest,
            instructorrazuvious,
            ladyblaumeux,
            jaybaxter,
            molasses,
            pintsizedsummoner,
            spellbreaker,
            anubarambusher,
            deadlypoison,
            stoneskingargoyle,
            bloodfury,
            fanofknives,
            poisoncloud,
            shieldbearer,
            sensedemons,
            shieldblock,
            handswapperminion,
            massivegnoll,
            deathcharger,
            ancientoflore,
            oasissnapjaw,
            illidanstormrage,
            frostwolfgrunt,
            lesserheal,
            infernal,
            wildpyromancer,
            razorfenhunter,
            twistingnether,
            voidcaller,
            leaderofthepack,
            malygos,
            becomehogger,
            baronrivendare,
            millhousemanastorm,
            innerfire,
            valeerasanguinar,
            chicken,
            souloftheforest,
            silencedebug,
            bloodsailcorsair,
            slime,
            tinkmasteroverspark,
            iceblock,
            brawl,
            vanish,
            poisonseeds,
            murloc,
            mindspike,
            kingmukla,
            stevengabriel,
            gluth,
            truesilverchampion,
            harrisonjones,
            destroydeck,
            devilsaur,
            wargolem,
            warsongcommander,
            manawyrm,
            thaddius,
            savagery,
            spitefulsmith,
            shatteredsuncleric,
            eyeforaneye,
            azuredrake,
            mountaingiant,
            korkronelite,
            junglepanther,
            barongeddon,
            spectralspider,
            pitlord,
            markofnature,
            grobbulus,
            leokk,
            fierywaraxe,
            damage5,
            duplicate,
            restore5,
            mindblast,
            timberwolf,
            captaingreenskin,
            elvenarcher,
            michaelschweitzer,
            masterswordsmith,
            grommashhellscream,
            hound,
            seagiant,
            doomguard,
            alakirthewindlord,
            hyena,
            undertaker,
            frothingberserker,
            powerofthewild,
            druidoftheclaw,
            hellfire,
            archmage,
            recklessrocketeer,
            crazymonkey,
            damageallbut1,
            frostblast,
            powerwordshield,
            rainoffire,
            arcaneintellect,
            angrychicken,
            nerubianegg,
            worshipper,
            mindgames,
            leeroyjenkins,
            gurubashiberserker,
            windspeaker,
            enableemotes,
            forceofnature,
            lightspawn,
            destroyamanacrystal,
            warglaiveofazzinoth,
            finkleeinhorn,
            frostelemental,
            thoughtsteal,
            brianschwab,
            scavenginghyena,
            si7agent,
            prophetvelen,
            soulfire,
            ogremagi,
            damagedgolem,
            crash,
            adrenalinerush,
            murloctidecaller,
            kirintormage,
            spectralrider,
            thrallmarfarseer,
            frostwolfwarlord,
            sorcerersapprentice,
            feugen,
            willofmukla,
            holyfire,
            manawraith,
            argentsquire,
            placeholdercard,
            snakeball,
            ancientwatcher,
            noviceengineer,
            stonetuskboar,
            ancestralhealing,
            conceal,
            arcanitereaper,
            guldan,
            ragingworgen,
            earthenringfarseer,
            onyxia,
            manaaddict,
            unholyshadow,
            dualwarglaives,
            sludgebelcher,
            worthlessimp,
            shiv,
            sheep,
            bloodknight,
            holysmite,
            ancientsecrets,
            holywrath,
            ironforgerifleman,
            elitetaurenchieftain,
            spectralwarrior,
            bluegillwarrior,
            shapeshift,
            hamiltonchu,
            battlerage,
            nightblade,
            locustswarm,
            crazedhunter,
            andybrock,
            youthfulbrewmaster,
            theblackknight,
            brewmaster,
            lifetap,
            demonfire,
            redemption,
            lordjaraxxus,
            coldblood,
            lightwarden,
            questingadventurer,
            donothing,
            dereksakamoto,
            poultryizer,
            koboldgeomancer,
            legacyoftheemperor,
            eruption,
            cenarius,
            deathlord,
            searingtotem,
            taurenwarrior,
            explosivetrap,
            frog,
            servercrash,
            wickedknife,
            laughingsister,
            cultmaster,
            wildgrowth,
            sprint,
            masterofdisguise,
            kyleharrison,
            avatarofthecoin,
            excessmana,
            spiritwolf,
            auchenaisoulpriest,
            bestialwrath,
            rockbiterweapon,
            starvingbuzzard,
            mirrorimage,
            frozenchampion,
            silverhandrecruit,
            corruption,
            preparation,
            cairnebloodhoof,
            mortalstrike,
            flare,
            necroknight,
            silverhandknight,
            breakweapon,
            guardianofkings,
            ancientbrewmaster,
            avenge,
            youngdragonhawk,
            frostshock,
            healingtouch,
            venturecomercenary,
            unbalancingstrike,
            sacrificialpact,
            noooooooooooo,
            baneofdoom,
            abomination,
            flesheatingghoul,
            loothoarder,
            mill10,
            sapphiron,
            jasonchayes,
            benbrode,
            betrayal,
            thebeast,
            flameimp,
            freezingtrap,
            southseadeckhand,
            wrath,
            bloodfenraptor,
            cleave,
            fencreeper,
            restore1,
            handtodeck,
            starfire,
            goldshirefootman,
            unrelentingtrainee,
            murlocscout,
            ragnarosthefirelord,
            rampage,
            zombiechow,
            thrall,
            stoneclawtotem,
            captainsparrot,
            windfuryharpy,
            unrelentingwarrior,
            stranglethorntiger,
            summonarandomsecret,
            circleofhealing,
            snaketrap,
            cabalshadowpriest,
            nerubarweblord,
            upgrade,
            shieldslam,
            flameburst,
            windfury,
            enrage,
            natpagle,
            restoreallhealth,
            houndmaster,
            waterelemental,
            eaglehornbow,
            gnoll,
            archmageantonidas,
            destroyallheroes,
            chains,
            wrathofairtotem,
            killcommand,
            manatidetotem,
            daggermastery,
            drainlife,
            doomsayer,
            darkscalehealer,
            shadowform,
            frostnova,
            purecold,
            mirrorentity,
            counterspell,
            mindshatter,
            magmarager,
            wolfrider,
            emboldener3000,
            polarityshift,
            gelbinmekkatorque,
            webspinner,
            utherlightbringer,
            innerrage,
            emeralddrake,
            forceaitouseheropower,
            echoingooze,
            heroicstrike,
            hauntedcreeper,
            barreltoss,
            yongwoo,
            doomhammer,
            stomp,
            spectralknight,
            tracking,
            fireball,
            thecoin,
            bootybaybodyguard,
            scarletcrusader,
            voodoodoctor,
            shadowbolt,
            etherealarcanist,
            succubus,
            emperorcobra,
            deadlyshot,
            reinforce,
            supercharge,
            claw,
            explosiveshot,
            avengingwrath,
            riverpawgnoll,
            sirzeliek,
            argentprotector,
            hiddengnome,
            felguard,
            northshirecleric,
            plague,
            lepergnome,
            fireelemental,
            armorup,
            snipe,
            southseacaptain,
            catform,
            bite,
            defiasringleader,
            harvestgolem,
            kingkrush,
            aibuddydamageownhero5,
            healingtotem,
            ericdodds,
            demigodsfavor,
            huntersmark,
            dalaranmage,
            twilightdrake,
            coldlightoracle,
            shadeofnaxxramas,
            moltengiant,
            deathbloom,
            shadowflame,
            anduinwrynn,
            argentcommander,
            revealhand,
            arcanemissiles,
            repairbot,
            unstableghoul,
            ancientofwar,
            stormwindchampion,
            summonapanther,
            mrbigglesworth,
            swipe,
            aihelperbuddy,
            hex,
            ysera,
            arcanegolem,
            bloodimp,
            pyroblast,
            murlocraider,
            faeriedragon,
            sinisterstrike,
            poweroverwhelming,
            arcaneexplosion,
            shadowwordpain,
            mill30,
            noblesacrifice,
            dreadinfernal,
            naturalize,
            totemiccall,
            secretkeeper,
            dreadcorsair,
            jaws,
            forkedlightning,
            reincarnate,
            handofprotection,
            noththeplaguebringer,
            vaporize,
            frostbreath,
            nozdormu,
            divinespirit,
            transcendence,
            armorsmith,
            murloctidehunter,
            stealcard,
            opponentconcede,
            tundrarhino,
            summoningportal,
            hammerofwrath,
            stormwindknight,
            freeze,
            madbomber,
            consecration,
            spectraltrainee,
            boar,
            knifejuggler,
            icebarrier,
            mechanicaldragonling,
            battleaxe,
            lightsjustice,
            lavaburst,
            mindcontroltech,
            boulderfistogre,
            fireblast,
            priestessofelune,
            ancientmage,
            shadowworddeath,
            ironbeakowl,
            eviscerate,
            repentance,
            understudy,
            sunwalker,
            nagamyrmidon,
            destroyheropower,
            skeletalsmith,
            slam,
            swordofjustice,
            bounce,
            shadopanmonk,
            whirlwind,
            alexstrasza,
            silence,
            rexxar,
            voidwalker,
            whelp,
            flamestrike,
            rivercrocolisk,
            stormforgedaxe,
            snake,
            shotgunblast,
            violetapprentice,
            templeenforcer,
            ashbringer,
            impmaster,
            defender,
            savageroar,
            innervate,
            inferno,
            falloutslime,
            earthelemental,
            facelessmanipulator,
            mindpocalypse,
            divinefavor,
            aibuddydestroyminions,
            demolisher,
            sunfuryprotector,
            dustdevil,
            powerofthehorde,
            dancingswords,
            holylight,
            feralspirit,
            raidleader,
            amaniberserker,
            ironbarkprotector,
            bearform,
            deathwing,
            stormpikecommando,
            squire,
            panther,
            silverbackpatriarch,
            bobfitch,
            gladiatorslongbow,
            damage1,
        }

        public cardName cardNamestringToEnum(string s)
        {
            if (s == "unknown") return CardDB.cardName.unknown;
            if (s == "hogger") return CardDB.cardName.hogger;
            if (s == "heigantheunclean") return CardDB.cardName.heigantheunclean;
            if (s == "necroticaura") return CardDB.cardName.necroticaura;
            if (s == "starfall") return CardDB.cardName.starfall;
            if (s == "barrel") return CardDB.cardName.barrel;
            if (s == "damagereflector") return CardDB.cardName.damagereflector;
            if (s == "edwinvancleef") return CardDB.cardName.edwinvancleef;
            if (s == "gothiktheharvester") return CardDB.cardName.gothiktheharvester;
            if (s == "perditionsblade") return CardDB.cardName.perditionsblade;
            if (s == "bloodsailraider") return CardDB.cardName.bloodsailraider;
            if (s == "guardianoficecrown") return CardDB.cardName.guardianoficecrown;
            if (s == "bloodmagethalnos") return CardDB.cardName.bloodmagethalnos;
            if (s == "rooted") return CardDB.cardName.rooted;
            if (s == "wisp") return CardDB.cardName.wisp;
            if (s == "rachelledavis") return CardDB.cardName.rachelledavis;
            if (s == "senjinshieldmasta") return CardDB.cardName.senjinshieldmasta;
            if (s == "totemicmight") return CardDB.cardName.totemicmight;
            if (s == "uproot") return CardDB.cardName.uproot;
            if (s == "opponentdisconnect") return CardDB.cardName.opponentdisconnect;
            if (s == "unrelentingrider") return CardDB.cardName.unrelentingrider;
            if (s == "shandoslesson") return CardDB.cardName.shandoslesson;
            if (s == "hemetnesingwary") return CardDB.cardName.hemetnesingwary;
            if (s == "decimate") return CardDB.cardName.decimate;
            if (s == "shadowofnothing") return CardDB.cardName.shadowofnothing;
            if (s == "nerubian") return CardDB.cardName.nerubian;
            if (s == "dragonlingmechanic") return CardDB.cardName.dragonlingmechanic;
            if (s == "mogushanwarden") return CardDB.cardName.mogushanwarden;
            if (s == "thanekorthazz") return CardDB.cardName.thanekorthazz;
            if (s == "hungrycrab") return CardDB.cardName.hungrycrab;
            if (s == "ancientteachings") return CardDB.cardName.ancientteachings;
            if (s == "misdirection") return CardDB.cardName.misdirection;
            if (s == "patientassassin") return CardDB.cardName.patientassassin;
            if (s == "mutatinginjection") return CardDB.cardName.mutatinginjection;
            if (s == "violetteacher") return CardDB.cardName.violetteacher;
            if (s == "arathiweaponsmith") return CardDB.cardName.arathiweaponsmith;
            if (s == "raisedead") return CardDB.cardName.raisedead;
            if (s == "acolyteofpain") return CardDB.cardName.acolyteofpain;
            if (s == "holynova") return CardDB.cardName.holynova;
            if (s == "robpardo") return CardDB.cardName.robpardo;
            if (s == "commandingshout") return CardDB.cardName.commandingshout;
            if (s == "necroticpoison") return CardDB.cardName.necroticpoison;
            if (s == "unboundelemental") return CardDB.cardName.unboundelemental;
            if (s == "garroshhellscream") return CardDB.cardName.garroshhellscream;
            if (s == "enchant") return CardDB.cardName.enchant;
            if (s == "loatheb") return CardDB.cardName.loatheb;
            if (s == "blessingofmight") return CardDB.cardName.blessingofmight;
            if (s == "nightmare") return CardDB.cardName.nightmare;
            if (s == "blessingofkings") return CardDB.cardName.blessingofkings;
            if (s == "polymorph") return CardDB.cardName.polymorph;
            if (s == "darkirondwarf") return CardDB.cardName.darkirondwarf;
            if (s == "destroy") return CardDB.cardName.destroy;
            if (s == "roguesdoit") return CardDB.cardName.roguesdoit;
            if (s == "freecards") return CardDB.cardName.freecards;
            if (s == "iammurloc") return CardDB.cardName.iammurloc;
            if (s == "sporeburst") return CardDB.cardName.sporeburst;
            if (s == "mindcontrolcrystal") return CardDB.cardName.mindcontrolcrystal;
            if (s == "charge") return CardDB.cardName.charge;
            if (s == "stampedingkodo") return CardDB.cardName.stampedingkodo;
            if (s == "humility") return CardDB.cardName.humility;
            if (s == "darkcultist") return CardDB.cardName.darkcultist;
            if (s == "gruul") return CardDB.cardName.gruul;
            if (s == "markofthewild") return CardDB.cardName.markofthewild;
            if (s == "patchwerk") return CardDB.cardName.patchwerk;
            if (s == "worgeninfiltrator") return CardDB.cardName.worgeninfiltrator;
            if (s == "frostbolt") return CardDB.cardName.frostbolt;
            if (s == "runeblade") return CardDB.cardName.runeblade;
            if (s == "flametonguetotem") return CardDB.cardName.flametonguetotem;
            if (s == "assassinate") return CardDB.cardName.assassinate;
            if (s == "madscientist") return CardDB.cardName.madscientist;
            if (s == "lordofthearena") return CardDB.cardName.lordofthearena;
            if (s == "bainebloodhoof") return CardDB.cardName.bainebloodhoof;
            if (s == "injuredblademaster") return CardDB.cardName.injuredblademaster;
            if (s == "siphonsoul") return CardDB.cardName.siphonsoul;
            if (s == "layonhands") return CardDB.cardName.layonhands;
            if (s == "hook") return CardDB.cardName.hook;
            if (s == "massiveruneblade") return CardDB.cardName.massiveruneblade;
            if (s == "lorewalkercho") return CardDB.cardName.lorewalkercho;
            if (s == "destroyallminions") return CardDB.cardName.destroyallminions;
            if (s == "silvermoonguardian") return CardDB.cardName.silvermoonguardian;
            if (s == "destroyallmana") return CardDB.cardName.destroyallmana;
            if (s == "huffer") return CardDB.cardName.huffer;
            if (s == "mindvision") return CardDB.cardName.mindvision;
            if (s == "malfurionstormrage") return CardDB.cardName.malfurionstormrage;
            if (s == "corehound") return CardDB.cardName.corehound;
            if (s == "grimscaleoracle") return CardDB.cardName.grimscaleoracle;
            if (s == "lightningstorm") return CardDB.cardName.lightningstorm;
            if (s == "lightwell") return CardDB.cardName.lightwell;
            if (s == "benthompson") return CardDB.cardName.benthompson;
            if (s == "coldlightseer") return CardDB.cardName.coldlightseer;
            if (s == "deathsbite") return CardDB.cardName.deathsbite;
            if (s == "gorehowl") return CardDB.cardName.gorehowl;
            if (s == "skitter") return CardDB.cardName.skitter;
            if (s == "farsight") return CardDB.cardName.farsight;
            if (s == "chillwindyeti") return CardDB.cardName.chillwindyeti;
            if (s == "moonfire") return CardDB.cardName.moonfire;
            if (s == "bladeflurry") return CardDB.cardName.bladeflurry;
            if (s == "massdispel") return CardDB.cardName.massdispel;
            if (s == "crazedalchemist") return CardDB.cardName.crazedalchemist;
            if (s == "shadowmadness") return CardDB.cardName.shadowmadness;
            if (s == "equality") return CardDB.cardName.equality;
            if (s == "misha") return CardDB.cardName.misha;
            if (s == "treant") return CardDB.cardName.treant;
            if (s == "alarmobot") return CardDB.cardName.alarmobot;
            if (s == "animalcompanion") return CardDB.cardName.animalcompanion;
            if (s == "hatefulstrike") return CardDB.cardName.hatefulstrike;
            if (s == "dream") return CardDB.cardName.dream;
            if (s == "anubrekhan") return CardDB.cardName.anubrekhan;
            if (s == "youngpriestess") return CardDB.cardName.youngpriestess;
            if (s == "gadgetzanauctioneer") return CardDB.cardName.gadgetzanauctioneer;
            if (s == "coneofcold") return CardDB.cardName.coneofcold;
            if (s == "earthshock") return CardDB.cardName.earthshock;
            if (s == "tirionfordring") return CardDB.cardName.tirionfordring;
            if (s == "wailingsoul") return CardDB.cardName.wailingsoul;
            if (s == "skeleton") return CardDB.cardName.skeleton;
            if (s == "ironfurgrizzly") return CardDB.cardName.ironfurgrizzly;
            if (s == "headcrack") return CardDB.cardName.headcrack;
            if (s == "arcaneshot") return CardDB.cardName.arcaneshot;
            if (s == "maexxna") return CardDB.cardName.maexxna;
            if (s == "imp") return CardDB.cardName.imp;
            if (s == "markofthehorsemen") return CardDB.cardName.markofthehorsemen;
            if (s == "voidterror") return CardDB.cardName.voidterror;
            if (s == "mortalcoil") return CardDB.cardName.mortalcoil;
            if (s == "draw3cards") return CardDB.cardName.draw3cards;
            if (s == "flameofazzinoth") return CardDB.cardName.flameofazzinoth;
            if (s == "jainaproudmoore") return CardDB.cardName.jainaproudmoore;
            if (s == "execute") return CardDB.cardName.execute;
            if (s == "bloodlust") return CardDB.cardName.bloodlust;
            if (s == "bananas") return CardDB.cardName.bananas;
            if (s == "kidnapper") return CardDB.cardName.kidnapper;
            if (s == "oldmurkeye") return CardDB.cardName.oldmurkeye;
            if (s == "homingchicken") return CardDB.cardName.homingchicken;
            if (s == "enableforattack") return CardDB.cardName.enableforattack;
            if (s == "spellbender") return CardDB.cardName.spellbender;
            if (s == "backstab") return CardDB.cardName.backstab;
            if (s == "squirrel") return CardDB.cardName.squirrel;
            if (s == "stalagg") return CardDB.cardName.stalagg;
            if (s == "grandwidowfaerlina") return CardDB.cardName.grandwidowfaerlina;
            if (s == "heavyaxe") return CardDB.cardName.heavyaxe;
            if (s == "zwick") return CardDB.cardName.zwick;
            if (s == "webwrap") return CardDB.cardName.webwrap;
            if (s == "flamesofazzinoth") return CardDB.cardName.flamesofazzinoth;
            if (s == "murlocwarleader") return CardDB.cardName.murlocwarleader;
            if (s == "shadowstep") return CardDB.cardName.shadowstep;
            if (s == "ancestralspirit") return CardDB.cardName.ancestralspirit;
            if (s == "defenderofargus") return CardDB.cardName.defenderofargus;
            if (s == "assassinsblade") return CardDB.cardName.assassinsblade;
            if (s == "discard") return CardDB.cardName.discard;
            if (s == "biggamehunter") return CardDB.cardName.biggamehunter;
            if (s == "aldorpeacekeeper") return CardDB.cardName.aldorpeacekeeper;
            if (s == "blizzard") return CardDB.cardName.blizzard;
            if (s == "pandarenscout") return CardDB.cardName.pandarenscout;
            if (s == "unleashthehounds") return CardDB.cardName.unleashthehounds;
            if (s == "yseraawakens") return CardDB.cardName.yseraawakens;
            if (s == "sap") return CardDB.cardName.sap;
            if (s == "kelthuzad") return CardDB.cardName.kelthuzad;
            if (s == "defiasbandit") return CardDB.cardName.defiasbandit;
            if (s == "gnomishinventor") return CardDB.cardName.gnomishinventor;
            if (s == "mindcontrol") return CardDB.cardName.mindcontrol;
            if (s == "ravenholdtassassin") return CardDB.cardName.ravenholdtassassin;
            if (s == "icelance") return CardDB.cardName.icelance;
            if (s == "dispel") return CardDB.cardName.dispel;
            if (s == "acidicswampooze") return CardDB.cardName.acidicswampooze;
            if (s == "muklasbigbrother") return CardDB.cardName.muklasbigbrother;
            if (s == "blessedchampion") return CardDB.cardName.blessedchampion;
            if (s == "savannahhighmane") return CardDB.cardName.savannahhighmane;
            if (s == "direwolfalpha") return CardDB.cardName.direwolfalpha;
            if (s == "hoggersmash") return CardDB.cardName.hoggersmash;
            if (s == "blessingofwisdom") return CardDB.cardName.blessingofwisdom;
            if (s == "nourish") return CardDB.cardName.nourish;
            if (s == "abusivesergeant") return CardDB.cardName.abusivesergeant;
            if (s == "sylvanaswindrunner") return CardDB.cardName.sylvanaswindrunner;
            if (s == "spore") return CardDB.cardName.spore;
            if (s == "crueltaskmaster") return CardDB.cardName.crueltaskmaster;
            if (s == "lightningbolt") return CardDB.cardName.lightningbolt;
            if (s == "keeperofthegrove") return CardDB.cardName.keeperofthegrove;
            if (s == "steadyshot") return CardDB.cardName.steadyshot;
            if (s == "multishot") return CardDB.cardName.multishot;
            if (s == "harvest") return CardDB.cardName.harvest;
            if (s == "instructorrazuvious") return CardDB.cardName.instructorrazuvious;
            if (s == "ladyblaumeux") return CardDB.cardName.ladyblaumeux;
            if (s == "jaybaxter") return CardDB.cardName.jaybaxter;
            if (s == "molasses") return CardDB.cardName.molasses;
            if (s == "pintsizedsummoner") return CardDB.cardName.pintsizedsummoner;
            if (s == "spellbreaker") return CardDB.cardName.spellbreaker;
            if (s == "anubarambusher") return CardDB.cardName.anubarambusher;
            if (s == "deadlypoison") return CardDB.cardName.deadlypoison;
            if (s == "stoneskingargoyle") return CardDB.cardName.stoneskingargoyle;
            if (s == "bloodfury") return CardDB.cardName.bloodfury;
            if (s == "fanofknives") return CardDB.cardName.fanofknives;
            if (s == "poisoncloud") return CardDB.cardName.poisoncloud;
            if (s == "shieldbearer") return CardDB.cardName.shieldbearer;
            if (s == "sensedemons") return CardDB.cardName.sensedemons;
            if (s == "shieldblock") return CardDB.cardName.shieldblock;
            if (s == "handswapperminion") return CardDB.cardName.handswapperminion;
            if (s == "massivegnoll") return CardDB.cardName.massivegnoll;
            if (s == "deathcharger") return CardDB.cardName.deathcharger;
            if (s == "ancientoflore") return CardDB.cardName.ancientoflore;
            if (s == "oasissnapjaw") return CardDB.cardName.oasissnapjaw;
            if (s == "illidanstormrage") return CardDB.cardName.illidanstormrage;
            if (s == "frostwolfgrunt") return CardDB.cardName.frostwolfgrunt;
            if (s == "lesserheal") return CardDB.cardName.lesserheal;
            if (s == "infernal") return CardDB.cardName.infernal;
            if (s == "wildpyromancer") return CardDB.cardName.wildpyromancer;
            if (s == "razorfenhunter") return CardDB.cardName.razorfenhunter;
            if (s == "twistingnether") return CardDB.cardName.twistingnether;
            if (s == "voidcaller") return CardDB.cardName.voidcaller;
            if (s == "leaderofthepack") return CardDB.cardName.leaderofthepack;
            if (s == "malygos") return CardDB.cardName.malygos;
            if (s == "becomehogger") return CardDB.cardName.becomehogger;
            if (s == "baronrivendare") return CardDB.cardName.baronrivendare;
            if (s == "millhousemanastorm") return CardDB.cardName.millhousemanastorm;
            if (s == "innerfire") return CardDB.cardName.innerfire;
            if (s == "valeerasanguinar") return CardDB.cardName.valeerasanguinar;
            if (s == "chicken") return CardDB.cardName.chicken;
            if (s == "souloftheforest") return CardDB.cardName.souloftheforest;
            if (s == "silencedebug") return CardDB.cardName.silencedebug;
            if (s == "bloodsailcorsair") return CardDB.cardName.bloodsailcorsair;
            if (s == "slime") return CardDB.cardName.slime;
            if (s == "tinkmasteroverspark") return CardDB.cardName.tinkmasteroverspark;
            if (s == "iceblock") return CardDB.cardName.iceblock;
            if (s == "brawl") return CardDB.cardName.brawl;
            if (s == "vanish") return CardDB.cardName.vanish;
            if (s == "poisonseeds") return CardDB.cardName.poisonseeds;
            if (s == "murloc") return CardDB.cardName.murloc;
            if (s == "mindspike") return CardDB.cardName.mindspike;
            if (s == "kingmukla") return CardDB.cardName.kingmukla;
            if (s == "stevengabriel") return CardDB.cardName.stevengabriel;
            if (s == "gluth") return CardDB.cardName.gluth;
            if (s == "truesilverchampion") return CardDB.cardName.truesilverchampion;
            if (s == "harrisonjones") return CardDB.cardName.harrisonjones;
            if (s == "destroydeck") return CardDB.cardName.destroydeck;
            if (s == "devilsaur") return CardDB.cardName.devilsaur;
            if (s == "wargolem") return CardDB.cardName.wargolem;
            if (s == "warsongcommander") return CardDB.cardName.warsongcommander;
            if (s == "manawyrm") return CardDB.cardName.manawyrm;
            if (s == "thaddius") return CardDB.cardName.thaddius;
            if (s == "savagery") return CardDB.cardName.savagery;
            if (s == "spitefulsmith") return CardDB.cardName.spitefulsmith;
            if (s == "shatteredsuncleric") return CardDB.cardName.shatteredsuncleric;
            if (s == "eyeforaneye") return CardDB.cardName.eyeforaneye;
            if (s == "azuredrake") return CardDB.cardName.azuredrake;
            if (s == "mountaingiant") return CardDB.cardName.mountaingiant;
            if (s == "korkronelite") return CardDB.cardName.korkronelite;
            if (s == "junglepanther") return CardDB.cardName.junglepanther;
            if (s == "barongeddon") return CardDB.cardName.barongeddon;
            if (s == "spectralspider") return CardDB.cardName.spectralspider;
            if (s == "pitlord") return CardDB.cardName.pitlord;
            if (s == "markofnature") return CardDB.cardName.markofnature;
            if (s == "grobbulus") return CardDB.cardName.grobbulus;
            if (s == "leokk") return CardDB.cardName.leokk;
            if (s == "fierywaraxe") return CardDB.cardName.fierywaraxe;
            if (s == "damage5") return CardDB.cardName.damage5;
            if (s == "duplicate") return CardDB.cardName.duplicate;
            if (s == "restore5") return CardDB.cardName.restore5;
            if (s == "mindblast") return CardDB.cardName.mindblast;
            if (s == "timberwolf") return CardDB.cardName.timberwolf;
            if (s == "captaingreenskin") return CardDB.cardName.captaingreenskin;
            if (s == "elvenarcher") return CardDB.cardName.elvenarcher;
            if (s == "michaelschweitzer") return CardDB.cardName.michaelschweitzer;
            if (s == "masterswordsmith") return CardDB.cardName.masterswordsmith;
            if (s == "grommashhellscream") return CardDB.cardName.grommashhellscream;
            if (s == "hound") return CardDB.cardName.hound;
            if (s == "seagiant") return CardDB.cardName.seagiant;
            if (s == "doomguard") return CardDB.cardName.doomguard;
            if (s == "alakirthewindlord") return CardDB.cardName.alakirthewindlord;
            if (s == "hyena") return CardDB.cardName.hyena;
            if (s == "undertaker") return CardDB.cardName.undertaker;
            if (s == "frothingberserker") return CardDB.cardName.frothingberserker;
            if (s == "powerofthewild") return CardDB.cardName.powerofthewild;
            if (s == "druidoftheclaw") return CardDB.cardName.druidoftheclaw;
            if (s == "hellfire") return CardDB.cardName.hellfire;
            if (s == "archmage") return CardDB.cardName.archmage;
            if (s == "recklessrocketeer") return CardDB.cardName.recklessrocketeer;
            if (s == "crazymonkey") return CardDB.cardName.crazymonkey;
            if (s == "damageallbut1") return CardDB.cardName.damageallbut1;
            if (s == "frostblast") return CardDB.cardName.frostblast;
            if (s == "powerwordshield") return CardDB.cardName.powerwordshield;
            if (s == "rainoffire") return CardDB.cardName.rainoffire;
            if (s == "arcaneintellect") return CardDB.cardName.arcaneintellect;
            if (s == "angrychicken") return CardDB.cardName.angrychicken;
            if (s == "nerubianegg") return CardDB.cardName.nerubianegg;
            if (s == "worshipper") return CardDB.cardName.worshipper;
            if (s == "mindgames") return CardDB.cardName.mindgames;
            if (s == "leeroyjenkins") return CardDB.cardName.leeroyjenkins;
            if (s == "gurubashiberserker") return CardDB.cardName.gurubashiberserker;
            if (s == "windspeaker") return CardDB.cardName.windspeaker;
            if (s == "enableemotes") return CardDB.cardName.enableemotes;
            if (s == "forceofnature") return CardDB.cardName.forceofnature;
            if (s == "lightspawn") return CardDB.cardName.lightspawn;
            if (s == "destroyamanacrystal") return CardDB.cardName.destroyamanacrystal;
            if (s == "warglaiveofazzinoth") return CardDB.cardName.warglaiveofazzinoth;
            if (s == "finkleeinhorn") return CardDB.cardName.finkleeinhorn;
            if (s == "frostelemental") return CardDB.cardName.frostelemental;
            if (s == "thoughtsteal") return CardDB.cardName.thoughtsteal;
            if (s == "brianschwab") return CardDB.cardName.brianschwab;
            if (s == "scavenginghyena") return CardDB.cardName.scavenginghyena;
            if (s == "si7agent") return CardDB.cardName.si7agent;
            if (s == "prophetvelen") return CardDB.cardName.prophetvelen;
            if (s == "soulfire") return CardDB.cardName.soulfire;
            if (s == "ogremagi") return CardDB.cardName.ogremagi;
            if (s == "damagedgolem") return CardDB.cardName.damagedgolem;
            if (s == "crash") return CardDB.cardName.crash;
            if (s == "adrenalinerush") return CardDB.cardName.adrenalinerush;
            if (s == "murloctidecaller") return CardDB.cardName.murloctidecaller;
            if (s == "kirintormage") return CardDB.cardName.kirintormage;
            if (s == "spectralrider") return CardDB.cardName.spectralrider;
            if (s == "thrallmarfarseer") return CardDB.cardName.thrallmarfarseer;
            if (s == "frostwolfwarlord") return CardDB.cardName.frostwolfwarlord;
            if (s == "sorcerersapprentice") return CardDB.cardName.sorcerersapprentice;
            if (s == "feugen") return CardDB.cardName.feugen;
            if (s == "willofmukla") return CardDB.cardName.willofmukla;
            if (s == "holyfire") return CardDB.cardName.holyfire;
            if (s == "manawraith") return CardDB.cardName.manawraith;
            if (s == "argentsquire") return CardDB.cardName.argentsquire;
            if (s == "placeholdercard") return CardDB.cardName.placeholdercard;
            if (s == "snakeball") return CardDB.cardName.snakeball;
            if (s == "ancientwatcher") return CardDB.cardName.ancientwatcher;
            if (s == "noviceengineer") return CardDB.cardName.noviceengineer;
            if (s == "stonetuskboar") return CardDB.cardName.stonetuskboar;
            if (s == "ancestralhealing") return CardDB.cardName.ancestralhealing;
            if (s == "conceal") return CardDB.cardName.conceal;
            if (s == "arcanitereaper") return CardDB.cardName.arcanitereaper;
            if (s == "guldan") return CardDB.cardName.guldan;
            if (s == "ragingworgen") return CardDB.cardName.ragingworgen;
            if (s == "earthenringfarseer") return CardDB.cardName.earthenringfarseer;
            if (s == "onyxia") return CardDB.cardName.onyxia;
            if (s == "manaaddict") return CardDB.cardName.manaaddict;
            if (s == "unholyshadow") return CardDB.cardName.unholyshadow;
            if (s == "dualwarglaives") return CardDB.cardName.dualwarglaives;
            if (s == "sludgebelcher") return CardDB.cardName.sludgebelcher;
            if (s == "worthlessimp") return CardDB.cardName.worthlessimp;
            if (s == "shiv") return CardDB.cardName.shiv;
            if (s == "sheep") return CardDB.cardName.sheep;
            if (s == "bloodknight") return CardDB.cardName.bloodknight;
            if (s == "holysmite") return CardDB.cardName.holysmite;
            if (s == "ancientsecrets") return CardDB.cardName.ancientsecrets;
            if (s == "holywrath") return CardDB.cardName.holywrath;
            if (s == "ironforgerifleman") return CardDB.cardName.ironforgerifleman;
            if (s == "elitetaurenchieftain") return CardDB.cardName.elitetaurenchieftain;
            if (s == "spectralwarrior") return CardDB.cardName.spectralwarrior;
            if (s == "bluegillwarrior") return CardDB.cardName.bluegillwarrior;
            if (s == "shapeshift") return CardDB.cardName.shapeshift;
            if (s == "hamiltonchu") return CardDB.cardName.hamiltonchu;
            if (s == "battlerage") return CardDB.cardName.battlerage;
            if (s == "nightblade") return CardDB.cardName.nightblade;
            if (s == "locustswarm") return CardDB.cardName.locustswarm;
            if (s == "crazedhunter") return CardDB.cardName.crazedhunter;
            if (s == "andybrock") return CardDB.cardName.andybrock;
            if (s == "youthfulbrewmaster") return CardDB.cardName.youthfulbrewmaster;
            if (s == "theblackknight") return CardDB.cardName.theblackknight;
            if (s == "brewmaster") return CardDB.cardName.brewmaster;
            if (s == "lifetap") return CardDB.cardName.lifetap;
            if (s == "demonfire") return CardDB.cardName.demonfire;
            if (s == "redemption") return CardDB.cardName.redemption;
            if (s == "lordjaraxxus") return CardDB.cardName.lordjaraxxus;
            if (s == "coldblood") return CardDB.cardName.coldblood;
            if (s == "lightwarden") return CardDB.cardName.lightwarden;
            if (s == "questingadventurer") return CardDB.cardName.questingadventurer;
            if (s == "donothing") return CardDB.cardName.donothing;
            if (s == "dereksakamoto") return CardDB.cardName.dereksakamoto;
            if (s == "poultryizer") return CardDB.cardName.poultryizer;
            if (s == "koboldgeomancer") return CardDB.cardName.koboldgeomancer;
            if (s == "legacyoftheemperor") return CardDB.cardName.legacyoftheemperor;
            if (s == "eruption") return CardDB.cardName.eruption;
            if (s == "cenarius") return CardDB.cardName.cenarius;
            if (s == "deathlord") return CardDB.cardName.deathlord;
            if (s == "searingtotem") return CardDB.cardName.searingtotem;
            if (s == "taurenwarrior") return CardDB.cardName.taurenwarrior;
            if (s == "explosivetrap") return CardDB.cardName.explosivetrap;
            if (s == "frog") return CardDB.cardName.frog;
            if (s == "servercrash") return CardDB.cardName.servercrash;
            if (s == "wickedknife") return CardDB.cardName.wickedknife;
            if (s == "laughingsister") return CardDB.cardName.laughingsister;
            if (s == "cultmaster") return CardDB.cardName.cultmaster;
            if (s == "wildgrowth") return CardDB.cardName.wildgrowth;
            if (s == "sprint") return CardDB.cardName.sprint;
            if (s == "masterofdisguise") return CardDB.cardName.masterofdisguise;
            if (s == "kyleharrison") return CardDB.cardName.kyleharrison;
            if (s == "avatarofthecoin") return CardDB.cardName.avatarofthecoin;
            if (s == "excessmana") return CardDB.cardName.excessmana;
            if (s == "spiritwolf") return CardDB.cardName.spiritwolf;
            if (s == "auchenaisoulpriest") return CardDB.cardName.auchenaisoulpriest;
            if (s == "bestialwrath") return CardDB.cardName.bestialwrath;
            if (s == "rockbiterweapon") return CardDB.cardName.rockbiterweapon;
            if (s == "starvingbuzzard") return CardDB.cardName.starvingbuzzard;
            if (s == "mirrorimage") return CardDB.cardName.mirrorimage;
            if (s == "frozenchampion") return CardDB.cardName.frozenchampion;
            if (s == "silverhandrecruit") return CardDB.cardName.silverhandrecruit;
            if (s == "corruption") return CardDB.cardName.corruption;
            if (s == "preparation") return CardDB.cardName.preparation;
            if (s == "cairnebloodhoof") return CardDB.cardName.cairnebloodhoof;
            if (s == "mortalstrike") return CardDB.cardName.mortalstrike;
            if (s == "flare") return CardDB.cardName.flare;
            if (s == "necroknight") return CardDB.cardName.necroknight;
            if (s == "silverhandknight") return CardDB.cardName.silverhandknight;
            if (s == "breakweapon") return CardDB.cardName.breakweapon;
            if (s == "guardianofkings") return CardDB.cardName.guardianofkings;
            if (s == "ancientbrewmaster") return CardDB.cardName.ancientbrewmaster;
            if (s == "avenge") return CardDB.cardName.avenge;
            if (s == "youngdragonhawk") return CardDB.cardName.youngdragonhawk;
            if (s == "frostshock") return CardDB.cardName.frostshock;
            if (s == "healingtouch") return CardDB.cardName.healingtouch;
            if (s == "venturecomercenary") return CardDB.cardName.venturecomercenary;
            if (s == "unbalancingstrike") return CardDB.cardName.unbalancingstrike;
            if (s == "sacrificialpact") return CardDB.cardName.sacrificialpact;
            if (s == "noooooooooooo") return CardDB.cardName.noooooooooooo;
            if (s == "baneofdoom") return CardDB.cardName.baneofdoom;
            if (s == "abomination") return CardDB.cardName.abomination;
            if (s == "flesheatingghoul") return CardDB.cardName.flesheatingghoul;
            if (s == "loothoarder") return CardDB.cardName.loothoarder;
            if (s == "mill10") return CardDB.cardName.mill10;
            if (s == "sapphiron") return CardDB.cardName.sapphiron;
            if (s == "jasonchayes") return CardDB.cardName.jasonchayes;
            if (s == "benbrode") return CardDB.cardName.benbrode;
            if (s == "betrayal") return CardDB.cardName.betrayal;
            if (s == "thebeast") return CardDB.cardName.thebeast;
            if (s == "flameimp") return CardDB.cardName.flameimp;
            if (s == "freezingtrap") return CardDB.cardName.freezingtrap;
            if (s == "southseadeckhand") return CardDB.cardName.southseadeckhand;
            if (s == "wrath") return CardDB.cardName.wrath;
            if (s == "bloodfenraptor") return CardDB.cardName.bloodfenraptor;
            if (s == "cleave") return CardDB.cardName.cleave;
            if (s == "fencreeper") return CardDB.cardName.fencreeper;
            if (s == "restore1") return CardDB.cardName.restore1;
            if (s == "handtodeck") return CardDB.cardName.handtodeck;
            if (s == "starfire") return CardDB.cardName.starfire;
            if (s == "goldshirefootman") return CardDB.cardName.goldshirefootman;
            if (s == "unrelentingtrainee") return CardDB.cardName.unrelentingtrainee;
            if (s == "murlocscout") return CardDB.cardName.murlocscout;
            if (s == "ragnarosthefirelord") return CardDB.cardName.ragnarosthefirelord;
            if (s == "rampage") return CardDB.cardName.rampage;
            if (s == "zombiechow") return CardDB.cardName.zombiechow;
            if (s == "thrall") return CardDB.cardName.thrall;
            if (s == "stoneclawtotem") return CardDB.cardName.stoneclawtotem;
            if (s == "captainsparrot") return CardDB.cardName.captainsparrot;
            if (s == "windfuryharpy") return CardDB.cardName.windfuryharpy;
            if (s == "unrelentingwarrior") return CardDB.cardName.unrelentingwarrior;
            if (s == "stranglethorntiger") return CardDB.cardName.stranglethorntiger;
            if (s == "summonarandomsecret") return CardDB.cardName.summonarandomsecret;
            if (s == "circleofhealing") return CardDB.cardName.circleofhealing;
            if (s == "snaketrap") return CardDB.cardName.snaketrap;
            if (s == "cabalshadowpriest") return CardDB.cardName.cabalshadowpriest;
            if (s == "nerubarweblord") return CardDB.cardName.nerubarweblord;
            if (s == "upgrade") return CardDB.cardName.upgrade;
            if (s == "shieldslam") return CardDB.cardName.shieldslam;
            if (s == "flameburst") return CardDB.cardName.flameburst;
            if (s == "windfury") return CardDB.cardName.windfury;
            if (s == "enrage") return CardDB.cardName.enrage;
            if (s == "natpagle") return CardDB.cardName.natpagle;
            if (s == "restoreallhealth") return CardDB.cardName.restoreallhealth;
            if (s == "houndmaster") return CardDB.cardName.houndmaster;
            if (s == "waterelemental") return CardDB.cardName.waterelemental;
            if (s == "eaglehornbow") return CardDB.cardName.eaglehornbow;
            if (s == "gnoll") return CardDB.cardName.gnoll;
            if (s == "archmageantonidas") return CardDB.cardName.archmageantonidas;
            if (s == "destroyallheroes") return CardDB.cardName.destroyallheroes;
            if (s == "chains") return CardDB.cardName.chains;
            if (s == "wrathofairtotem") return CardDB.cardName.wrathofairtotem;
            if (s == "killcommand") return CardDB.cardName.killcommand;
            if (s == "manatidetotem") return CardDB.cardName.manatidetotem;
            if (s == "daggermastery") return CardDB.cardName.daggermastery;
            if (s == "drainlife") return CardDB.cardName.drainlife;
            if (s == "doomsayer") return CardDB.cardName.doomsayer;
            if (s == "darkscalehealer") return CardDB.cardName.darkscalehealer;
            if (s == "shadowform") return CardDB.cardName.shadowform;
            if (s == "frostnova") return CardDB.cardName.frostnova;
            if (s == "purecold") return CardDB.cardName.purecold;
            if (s == "mirrorentity") return CardDB.cardName.mirrorentity;
            if (s == "counterspell") return CardDB.cardName.counterspell;
            if (s == "mindshatter") return CardDB.cardName.mindshatter;
            if (s == "magmarager") return CardDB.cardName.magmarager;
            if (s == "wolfrider") return CardDB.cardName.wolfrider;
            if (s == "emboldener3000") return CardDB.cardName.emboldener3000;
            if (s == "polarityshift") return CardDB.cardName.polarityshift;
            if (s == "gelbinmekkatorque") return CardDB.cardName.gelbinmekkatorque;
            if (s == "webspinner") return CardDB.cardName.webspinner;
            if (s == "utherlightbringer") return CardDB.cardName.utherlightbringer;
            if (s == "innerrage") return CardDB.cardName.innerrage;
            if (s == "emeralddrake") return CardDB.cardName.emeralddrake;
            if (s == "forceaitouseheropower") return CardDB.cardName.forceaitouseheropower;
            if (s == "echoingooze") return CardDB.cardName.echoingooze;
            if (s == "heroicstrike") return CardDB.cardName.heroicstrike;
            if (s == "hauntedcreeper") return CardDB.cardName.hauntedcreeper;
            if (s == "barreltoss") return CardDB.cardName.barreltoss;
            if (s == "yongwoo") return CardDB.cardName.yongwoo;
            if (s == "doomhammer") return CardDB.cardName.doomhammer;
            if (s == "stomp") return CardDB.cardName.stomp;
            if (s == "spectralknight") return CardDB.cardName.spectralknight;
            if (s == "tracking") return CardDB.cardName.tracking;
            if (s == "fireball") return CardDB.cardName.fireball;
            if (s == "thecoin") return CardDB.cardName.thecoin;
            if (s == "bootybaybodyguard") return CardDB.cardName.bootybaybodyguard;
            if (s == "scarletcrusader") return CardDB.cardName.scarletcrusader;
            if (s == "voodoodoctor") return CardDB.cardName.voodoodoctor;
            if (s == "shadowbolt") return CardDB.cardName.shadowbolt;
            if (s == "etherealarcanist") return CardDB.cardName.etherealarcanist;
            if (s == "succubus") return CardDB.cardName.succubus;
            if (s == "emperorcobra") return CardDB.cardName.emperorcobra;
            if (s == "deadlyshot") return CardDB.cardName.deadlyshot;
            if (s == "reinforce") return CardDB.cardName.reinforce;
            if (s == "supercharge") return CardDB.cardName.supercharge;
            if (s == "claw") return CardDB.cardName.claw;
            if (s == "explosiveshot") return CardDB.cardName.explosiveshot;
            if (s == "avengingwrath") return CardDB.cardName.avengingwrath;
            if (s == "riverpawgnoll") return CardDB.cardName.riverpawgnoll;
            if (s == "sirzeliek") return CardDB.cardName.sirzeliek;
            if (s == "argentprotector") return CardDB.cardName.argentprotector;
            if (s == "hiddengnome") return CardDB.cardName.hiddengnome;
            if (s == "felguard") return CardDB.cardName.felguard;
            if (s == "northshirecleric") return CardDB.cardName.northshirecleric;
            if (s == "plague") return CardDB.cardName.plague;
            if (s == "lepergnome") return CardDB.cardName.lepergnome;
            if (s == "fireelemental") return CardDB.cardName.fireelemental;
            if (s == "armorup") return CardDB.cardName.armorup;
            if (s == "snipe") return CardDB.cardName.snipe;
            if (s == "southseacaptain") return CardDB.cardName.southseacaptain;
            if (s == "catform") return CardDB.cardName.catform;
            if (s == "bite") return CardDB.cardName.bite;
            if (s == "defiasringleader") return CardDB.cardName.defiasringleader;
            if (s == "harvestgolem") return CardDB.cardName.harvestgolem;
            if (s == "kingkrush") return CardDB.cardName.kingkrush;
            if (s == "aibuddydamageownhero5") return CardDB.cardName.aibuddydamageownhero5;
            if (s == "healingtotem") return CardDB.cardName.healingtotem;
            if (s == "ericdodds") return CardDB.cardName.ericdodds;
            if (s == "demigodsfavor") return CardDB.cardName.demigodsfavor;
            if (s == "huntersmark") return CardDB.cardName.huntersmark;
            if (s == "dalaranmage") return CardDB.cardName.dalaranmage;
            if (s == "twilightdrake") return CardDB.cardName.twilightdrake;
            if (s == "coldlightoracle") return CardDB.cardName.coldlightoracle;
            if (s == "shadeofnaxxramas") return CardDB.cardName.shadeofnaxxramas;
            if (s == "moltengiant") return CardDB.cardName.moltengiant;
            if (s == "deathbloom") return CardDB.cardName.deathbloom;
            if (s == "shadowflame") return CardDB.cardName.shadowflame;
            if (s == "anduinwrynn") return CardDB.cardName.anduinwrynn;
            if (s == "argentcommander") return CardDB.cardName.argentcommander;
            if (s == "revealhand") return CardDB.cardName.revealhand;
            if (s == "arcanemissiles") return CardDB.cardName.arcanemissiles;
            if (s == "repairbot") return CardDB.cardName.repairbot;
            if (s == "unstableghoul") return CardDB.cardName.unstableghoul;
            if (s == "ancientofwar") return CardDB.cardName.ancientofwar;
            if (s == "stormwindchampion") return CardDB.cardName.stormwindchampion;
            if (s == "summonapanther") return CardDB.cardName.summonapanther;
            if (s == "mrbigglesworth") return CardDB.cardName.mrbigglesworth;
            if (s == "swipe") return CardDB.cardName.swipe;
            if (s == "aihelperbuddy") return CardDB.cardName.aihelperbuddy;
            if (s == "hex") return CardDB.cardName.hex;
            if (s == "ysera") return CardDB.cardName.ysera;
            if (s == "arcanegolem") return CardDB.cardName.arcanegolem;
            if (s == "bloodimp") return CardDB.cardName.bloodimp;
            if (s == "pyroblast") return CardDB.cardName.pyroblast;
            if (s == "murlocraider") return CardDB.cardName.murlocraider;
            if (s == "faeriedragon") return CardDB.cardName.faeriedragon;
            if (s == "sinisterstrike") return CardDB.cardName.sinisterstrike;
            if (s == "poweroverwhelming") return CardDB.cardName.poweroverwhelming;
            if (s == "arcaneexplosion") return CardDB.cardName.arcaneexplosion;
            if (s == "shadowwordpain") return CardDB.cardName.shadowwordpain;
            if (s == "mill30") return CardDB.cardName.mill30;
            if (s == "noblesacrifice") return CardDB.cardName.noblesacrifice;
            if (s == "dreadinfernal") return CardDB.cardName.dreadinfernal;
            if (s == "naturalize") return CardDB.cardName.naturalize;
            if (s == "totemiccall") return CardDB.cardName.totemiccall;
            if (s == "secretkeeper") return CardDB.cardName.secretkeeper;
            if (s == "dreadcorsair") return CardDB.cardName.dreadcorsair;
            if (s == "jaws") return CardDB.cardName.jaws;
            if (s == "forkedlightning") return CardDB.cardName.forkedlightning;
            if (s == "reincarnate") return CardDB.cardName.reincarnate;
            if (s == "handofprotection") return CardDB.cardName.handofprotection;
            if (s == "noththeplaguebringer") return CardDB.cardName.noththeplaguebringer;
            if (s == "vaporize") return CardDB.cardName.vaporize;
            if (s == "frostbreath") return CardDB.cardName.frostbreath;
            if (s == "nozdormu") return CardDB.cardName.nozdormu;
            if (s == "divinespirit") return CardDB.cardName.divinespirit;
            if (s == "transcendence") return CardDB.cardName.transcendence;
            if (s == "armorsmith") return CardDB.cardName.armorsmith;
            if (s == "murloctidehunter") return CardDB.cardName.murloctidehunter;
            if (s == "stealcard") return CardDB.cardName.stealcard;
            if (s == "opponentconcede") return CardDB.cardName.opponentconcede;
            if (s == "tundrarhino") return CardDB.cardName.tundrarhino;
            if (s == "summoningportal") return CardDB.cardName.summoningportal;
            if (s == "hammerofwrath") return CardDB.cardName.hammerofwrath;
            if (s == "stormwindknight") return CardDB.cardName.stormwindknight;
            if (s == "freeze") return CardDB.cardName.freeze;
            if (s == "madbomber") return CardDB.cardName.madbomber;
            if (s == "consecration") return CardDB.cardName.consecration;
            if (s == "spectraltrainee") return CardDB.cardName.spectraltrainee;
            if (s == "boar") return CardDB.cardName.boar;
            if (s == "knifejuggler") return CardDB.cardName.knifejuggler;
            if (s == "icebarrier") return CardDB.cardName.icebarrier;
            if (s == "mechanicaldragonling") return CardDB.cardName.mechanicaldragonling;
            if (s == "battleaxe") return CardDB.cardName.battleaxe;
            if (s == "lightsjustice") return CardDB.cardName.lightsjustice;
            if (s == "lavaburst") return CardDB.cardName.lavaburst;
            if (s == "mindcontroltech") return CardDB.cardName.mindcontroltech;
            if (s == "boulderfistogre") return CardDB.cardName.boulderfistogre;
            if (s == "fireblast") return CardDB.cardName.fireblast;
            if (s == "priestessofelune") return CardDB.cardName.priestessofelune;
            if (s == "ancientmage") return CardDB.cardName.ancientmage;
            if (s == "shadowworddeath") return CardDB.cardName.shadowworddeath;
            if (s == "ironbeakowl") return CardDB.cardName.ironbeakowl;
            if (s == "eviscerate") return CardDB.cardName.eviscerate;
            if (s == "repentance") return CardDB.cardName.repentance;
            if (s == "understudy") return CardDB.cardName.understudy;
            if (s == "sunwalker") return CardDB.cardName.sunwalker;
            if (s == "nagamyrmidon") return CardDB.cardName.nagamyrmidon;
            if (s == "destroyheropower") return CardDB.cardName.destroyheropower;
            if (s == "skeletalsmith") return CardDB.cardName.skeletalsmith;
            if (s == "slam") return CardDB.cardName.slam;
            if (s == "swordofjustice") return CardDB.cardName.swordofjustice;
            if (s == "bounce") return CardDB.cardName.bounce;
            if (s == "shadopanmonk") return CardDB.cardName.shadopanmonk;
            if (s == "whirlwind") return CardDB.cardName.whirlwind;
            if (s == "alexstrasza") return CardDB.cardName.alexstrasza;
            if (s == "silence") return CardDB.cardName.silence;
            if (s == "rexxar") return CardDB.cardName.rexxar;
            if (s == "voidwalker") return CardDB.cardName.voidwalker;
            if (s == "whelp") return CardDB.cardName.whelp;
            if (s == "flamestrike") return CardDB.cardName.flamestrike;
            if (s == "rivercrocolisk") return CardDB.cardName.rivercrocolisk;
            if (s == "stormforgedaxe") return CardDB.cardName.stormforgedaxe;
            if (s == "snake") return CardDB.cardName.snake;
            if (s == "shotgunblast") return CardDB.cardName.shotgunblast;
            if (s == "violetapprentice") return CardDB.cardName.violetapprentice;
            if (s == "templeenforcer") return CardDB.cardName.templeenforcer;
            if (s == "ashbringer") return CardDB.cardName.ashbringer;
            if (s == "impmaster") return CardDB.cardName.impmaster;
            if (s == "defender") return CardDB.cardName.defender;
            if (s == "savageroar") return CardDB.cardName.savageroar;
            if (s == "innervate") return CardDB.cardName.innervate;
            if (s == "inferno") return CardDB.cardName.inferno;
            if (s == "falloutslime") return CardDB.cardName.falloutslime;
            if (s == "earthelemental") return CardDB.cardName.earthelemental;
            if (s == "facelessmanipulator") return CardDB.cardName.facelessmanipulator;
            if (s == "mindpocalypse") return CardDB.cardName.mindpocalypse;
            if (s == "divinefavor") return CardDB.cardName.divinefavor;
            if (s == "aibuddydestroyminions") return CardDB.cardName.aibuddydestroyminions;
            if (s == "demolisher") return CardDB.cardName.demolisher;
            if (s == "sunfuryprotector") return CardDB.cardName.sunfuryprotector;
            if (s == "dustdevil") return CardDB.cardName.dustdevil;
            if (s == "powerofthehorde") return CardDB.cardName.powerofthehorde;
            if (s == "dancingswords") return CardDB.cardName.dancingswords;
            if (s == "holylight") return CardDB.cardName.holylight;
            if (s == "feralspirit") return CardDB.cardName.feralspirit;
            if (s == "raidleader") return CardDB.cardName.raidleader;
            if (s == "amaniberserker") return CardDB.cardName.amaniberserker;
            if (s == "ironbarkprotector") return CardDB.cardName.ironbarkprotector;
            if (s == "bearform") return CardDB.cardName.bearform;
            if (s == "deathwing") return CardDB.cardName.deathwing;
            if (s == "stormpikecommando") return CardDB.cardName.stormpikecommando;
            if (s == "squire") return CardDB.cardName.squire;
            if (s == "panther") return CardDB.cardName.panther;
            if (s == "silverbackpatriarch") return CardDB.cardName.silverbackpatriarch;
            if (s == "bobfitch") return CardDB.cardName.bobfitch;
            if (s == "gladiatorslongbow") return CardDB.cardName.gladiatorslongbow;
            if (s == "damage1") return CardDB.cardName.damage1;
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
            REQ_UNDAMAGED_TARGET//=47
        }
        
        public class Card
        {
            //public string CardID = "";
            public cardName name = cardName.unknown;
            public int race = 0;
            public int rarity = 0;
            public int cost = 0;
            public cardtype type = CardDB.cardtype.NONE;
            //public string description = "";
            public int carddraw = 0;

            public bool hasEffect = false;// has the minion an effect, but not battlecry

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
            //playRequirements, reqID= siehe PlayErrors->ErrorType
            public int needEmptyPlacesForPlaying = 0;
            public int needWithMinAttackValueOf = 0;
            public int needWithMaxAttackValueOf = 0;
            public int needRaceForPlaying = 0;
            public int needMinNumberOfEnemy = 0;
            public int needMinTotalMinions = 0;
            public int needMinionsCapIfAvailable = 0;
            public bool isToken = false;

            public int spellpowervalue = 0;
            public cardIDEnum cardIDenum = cardIDEnum.None;
            public List<ErrorType2> playrequires;

            public SimTemplate sim_card;

            public Card()
            {
                playrequires = new List<ErrorType2>();
            }

            public Card(Card c)
            {
                //this.entityID = c.entityID;
                this.hasEffect = c.hasEffect;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;
                this.carddraw = c.carddraw;
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
                if (this.playrequires.Contains(et)) return true;
                return false;
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

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight)) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight)) || m.stealth) continue;
                        enemyMins[k] = true;
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
                    if (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON) addOwnHero = true;
                    if (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON) addEnemyHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
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

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight)) || m.stealth) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister) || m.name == CardDB.cardName.spectralknight)) continue;
                        enemyMins[k] = true;
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
                    if (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON) addOwnHero = true;
                    if (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON) addEnemyHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!(m.handcard.card.race == this.needRaceForPlaying))
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

            public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects
            {
                int retval = this.cost;
                int offset = 0;

                if (this.type == cardtype.MOB)
                {
                    offset += p.soeldnerDerVenture * 3;

                    offset += p.managespenst;

                    int temp = -(p.startedWithbeschwoerungsportal) * 2;
                    if (retval + temp <= 0) temp = -retval + 1;
                    offset = offset + temp;

                    if (p.mobsplayedThisTurn == 0)
                    {
                        offset -= p.winzigebeschwoererin;
                    }

                    if (this.battlecry)
                    {
                        offset += p.nerubarweblord * 2;
                    }

                }

                if (this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset -= (p.anzOwnsorcerersapprentice);
                    if (p.playedPreparation)
                    { //if the number of zauberlehrlings change
                        offset -= 3;
                    }

                }

                switch (this.name)
                {
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHero.Hp;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public int getManaCost(Playfield p, int currentcost)//calculates mana from current mana
            {
                int retval = currentcost;


                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################
                //Manacosts changes with soeldner der venture co.
                if (p.soeldnerDerVenture != p.startedWithsoeldnerDerVenture && this.type == cardtype.MOB)
                {
                    offset += (p.soeldnerDerVenture - p.startedWithsoeldnerDerVenture) * 3;
                }

                //Manacosts changes with mana-ghost
                if (p.managespenst != p.startedWithManagespenst && this.type == cardtype.MOB)
                {
                    offset += (p.managespenst - p.startedWithManagespenst);
                }

                if (this.battlecry && p.nerubarweblord != p.startedWithnerubarweblord && this.type == cardtype.MOB)
                {
                    offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                }


                // CARDS that decrease the manacosts of others ##############################

                //Manacosts changes with the summoning-portal >_>
                if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal && this.type == cardtype.MOB)
                { //cant lower the mana to 0
                    int temp = (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                    if (retval + temp <= 0) temp = -retval + 1;
                    offset = offset + temp;
                }

                //Manacosts changes with the pint-sized summoner
                if (p.winzigebeschwoererin >= 1 && p.mobsplayedThisTurn >= 1 && p.startedWithMobsPlayedThisTurn == 0 && this.type == cardtype.MOB)
                { // if we start oure calculations with 0 mobs played, then the cardcost are 1 mana to low in the further calculations (with the little summoner on field)
                    offset += p.winzigebeschwoererin;
                }
                if (p.mobsplayedThisTurn == 0 && p.winzigebeschwoererin <= p.startedWithWinzigebeschwoererin && this.type == cardtype.MOB)
                { // one pint-sized summoner got killed, before we played the first mob -> the manacost are higher of all mobs
                    offset += (p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin);
                }

                //Manacosts changes with the zauberlehrling summoner
                if (p.anzOwnsorcerersapprentice != p.anzOwnsorcerersapprenticeStarted && this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset += (p.anzOwnsorcerersapprenticeStarted - p.anzOwnsorcerersapprentice);
                }



                //manacosts are lowered, after we played preparation
                if (p.playedPreparation && this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset -= 3;
                }


                switch (this.name)
                {
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack + p.ownWeaponAttackStarted; // if weapon attack change we change manacost
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHero.Hp + p.ownHeroHpStarted;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = 0;
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
                    }

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
                Helpfunctions.Instance.ErrorLog("cant find _carddb.txt");
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
            Card plchldr = new Card();
            plchldr.name = CardDB.cardName.unknown;
            plchldr.cost = 1000;
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
                    if(temp.Equals("ds1_whelptoken")) c.isToken=true;
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
                    //if (c.isToken) Helpfunctions.Instance.ErrorLog(temp);

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

                if (s.Contains("<Tag name=\"Health\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Atk\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Attack = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Race\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Rarity\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.rarity = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Cost\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"CardType\""))
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

                if (s.Contains("<Tag name=\"CardName\" "))
                {
                    de = 0;
                    continue;
                }
                if (s.Contains("<Tag name=\"CardTextInHand\" "))
                {
                    de = 1;
                    continue;
                }
                if (s.Contains("<Tag name=\"TargetingArrowText\" "))
                {
                    c.target = true;
                    de = 2;
                    continue;
                }

                if (s.Contains("<enUS>"))
                {
                    string temp = s.Replace("<enUS>", "");

                    temp = temp.Replace("</enUS>", "");
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower();
                    if (de == 0)
                    {
                        temp = temp.Replace("'", "");
                        temp = temp.Replace(" ", "");
                        temp = temp.Replace(":", "");
                        temp = temp.Replace(".", "");
                        temp = temp.Replace("!", "");
                        temp = temp.Replace("-", "");
                        //temp = temp.Replace("ß", "ss");
                        //temp = temp.Replace("ü", "ue");
                        //temp = temp.Replace("ä", "ae");
                        //temp = temp.Replace("ö", "oe");

                        //Helpfunctions.Instance.logg(temp);
                        c.name = this.cardNamestringToEnum(temp);
                        name = temp;
                        if (PenalityManager.Instance.specialMinions.ContainsKey(this.cardNamestringToEnum(temp))) c.hasEffect = true;

                    }
                    if (de == 1)
                    {
                        //c.description = temp;
                        //if (c.description.Contains("choose one"))
                        if (temp.Contains("choose one"))
                        {
                            c.choice = true;
                            //Helpfunctions.Instance.logg(c.name + " is choice");
                        }
                    }
                    if (de == 2)
                    {
                        //c.targettext = temp;
                    }
                    de = -1;
                    continue;
                }
                if (s.Contains("<Tag name=\"Poisonous\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.poisionous = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Enrage\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Enrage = true;
                    continue;
                }

                if (s.Contains("<Tag name=\"OneTurnEffect\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.oneTurnEffect = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Aura\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Aura = true;
                    continue;
                }


                if (s.Contains("<Tag name=\"Taunt\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.tank = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Battlecry\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.battlecry = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Windfury\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.windfury = true;
                    continue;
                }

                if (s.Contains("<Tag name=\"Deathrattle\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.deathrattle = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Durability\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Durability = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Elite\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Elite = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Combo\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Combo = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Recall\""))
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

                if (s.Contains("<Tag name=\"ImmuneToSpellpower\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.immuneToSpellpowerg = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Stealth\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Stealth = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Secret\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Secret = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Freeze\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Freeze = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"AdjacentBuff\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.AdjacentBuff = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Divine Shield\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Shield = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Charge\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Charge = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Silence\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Silence = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Morph\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Morph = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Spellpower\""))
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
                if (s.Contains("<Tag name=\"GrantCharge\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.GrantCharge = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"HealTarget\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.HealTarget = true;
                    continue;
                }
                if (s.Contains("<PlayRequirement"))
                {
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

        }

        public Card getCardData(CardDB.cardName cardname)
        {
            Card c = new Card();

            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return c;
        }

        public Card getCardDataFromID(cardIDEnum id)
        {
            if (this.cardidToCardList.ContainsKey(id))
            {
                return cardidToCardList[id];
                //return new Card(cardidToCardList[id]);
            }

            return new Card();
        }

        public SimTemplate getSimCard(cardIDEnum id)
        {
            //if (id == CardDB.cardIDEnum.XXX_040) return new Sim_XXX_040();
            //if (id == CardDB.cardIDEnum.NAX5_01H) return new Sim_NAX5_01H();
            //if (id == CardDB.cardIDEnum.CS2_188o) return new Sim_CS2_188o();
            //if (id == CardDB.cardIDEnum.NAX6_02H) return new Sim_NAX6_02H();
            if (id == CardDB.cardIDEnum.NEW1_007b) return new Sim_NEW1_007b();
            //if (id == CardDB.cardIDEnum.NAX6_02e) return new Sim_NAX6_02e();
            //if (id == CardDB.cardIDEnum.TU4c_003) return new Sim_TU4c_003();
            //if (id == CardDB.cardIDEnum.XXX_024) return new Sim_XXX_024();
            if (id == CardDB.cardIDEnum.EX1_613) return new Sim_EX1_613();
            //if (id == CardDB.cardIDEnum.NAX8_01) return new Sim_NAX8_01();
            //if (id == CardDB.cardIDEnum.EX1_295o) return new Sim_EX1_295o();
            //if (id == CardDB.cardIDEnum.CS2_059o) return new Sim_CS2_059o();
            if (id == CardDB.cardIDEnum.EX1_133) return new Sim_EX1_133();
            if (id == CardDB.cardIDEnum.NEW1_018) return new Sim_NEW1_018();
            //if (id == CardDB.cardIDEnum.NAX15_03t) return new Sim_NAX15_03t();
            if (id == CardDB.cardIDEnum.EX1_012) return new Sim_EX1_012();
            if (id == CardDB.cardIDEnum.EX1_178a) return new Sim_EX1_178a();
            if (id == CardDB.cardIDEnum.CS2_231) return new Sim_CS2_231();
            //if (id == CardDB.cardIDEnum.EX1_019e) return new Sim_EX1_019e();
            //if (id == CardDB.cardIDEnum.CRED_12) return new Sim_CRED_12();
            if (id == CardDB.cardIDEnum.CS2_179) return new Sim_CS2_179();
            //if (id == CardDB.cardIDEnum.CS2_045e) return new Sim_CS2_045e();
            if (id == CardDB.cardIDEnum.EX1_244) return new Sim_EX1_244();
            if (id == CardDB.cardIDEnum.EX1_178b) return new Sim_EX1_178b();
            //if (id == CardDB.cardIDEnum.XXX_030) return new Sim_XXX_030();
            //if (id == CardDB.cardIDEnum.NAX8_05) return new Sim_NAX8_05();
            if (id == CardDB.cardIDEnum.EX1_573b) return new Sim_EX1_573b();
            //if (id == CardDB.cardIDEnum.TU4d_001) return new Sim_TU4d_001();
            if (id == CardDB.cardIDEnum.NEW1_007a) return new Sim_NEW1_007a();
            //if (id == CardDB.cardIDEnum.NAX12_02H) return new Sim_NAX12_02H();
            if (id == CardDB.cardIDEnum.EX1_345t) return new Sim_EX1_345t();
            if (id == CardDB.cardIDEnum.FP1_007t) return new Sim_FP1_007t();
            if (id == CardDB.cardIDEnum.EX1_025) return new Sim_EX1_025();
            if (id == CardDB.cardIDEnum.EX1_396) return new Sim_EX1_396();
            //if (id == CardDB.cardIDEnum.NAX9_03) return new Sim_NAX9_03();
            if (id == CardDB.cardIDEnum.NEW1_017) return new Sim_NEW1_017();
            if (id == CardDB.cardIDEnum.NEW1_008a) return new Sim_NEW1_008a();
            //if (id == CardDB.cardIDEnum.EX1_587e) return new Sim_EX1_587e();
            if (id == CardDB.cardIDEnum.EX1_533) return new Sim_EX1_533();
            if (id == CardDB.cardIDEnum.EX1_522) return new Sim_EX1_522();
            //if (id == CardDB.cardIDEnum.NAX11_04) return new Sim_NAX11_04();
            if (id == CardDB.cardIDEnum.NEW1_026) return new Sim_NEW1_026();
            if (id == CardDB.cardIDEnum.EX1_398) return new Sim_EX1_398();
            //if (id == CardDB.cardIDEnum.NAX4_04) return new Sim_NAX4_04();
            if (id == CardDB.cardIDEnum.EX1_007) return new Sim_EX1_007();
            if (id == CardDB.cardIDEnum.CS1_112) return new Sim_CS1_112();
            //if (id == CardDB.cardIDEnum.CRED_17) return new Sim_CRED_17();
            if (id == CardDB.cardIDEnum.NEW1_036) return new Sim_NEW1_036();
            //if (id == CardDB.cardIDEnum.NAX3_03) return new Sim_NAX3_03();
            //if (id == CardDB.cardIDEnum.EX1_355e) return new Sim_EX1_355e();
            if (id == CardDB.cardIDEnum.EX1_258) return new Sim_EX1_258();
            if (id == CardDB.cardIDEnum.HERO_01) return new Sim_HERO_01();
            //if (id == CardDB.cardIDEnum.XXX_009) return new Sim_XXX_009();
            //if (id == CardDB.cardIDEnum.NAX6_01H) return new Sim_NAX6_01H();
            //if (id == CardDB.cardIDEnum.NAX12_04e) return new Sim_NAX12_04e();
            if (id == CardDB.cardIDEnum.CS2_087) return new Sim_CS2_087();
            if (id == CardDB.cardIDEnum.DREAM_05) return new Sim_DREAM_05();
            //if (id == CardDB.cardIDEnum.NEW1_036e) return new Sim_NEW1_036e();
            if (id == CardDB.cardIDEnum.CS2_092) return new Sim_CS2_092();
            if (id == CardDB.cardIDEnum.CS2_022) return new Sim_CS2_022();
            if (id == CardDB.cardIDEnum.EX1_046) return new Sim_EX1_046();
            //if (id == CardDB.cardIDEnum.XXX_005) return new Sim_XXX_005();
            if (id == CardDB.cardIDEnum.PRO_001b) return new Sim_PRO_001b();
            //if (id == CardDB.cardIDEnum.XXX_022) return new Sim_XXX_022();
            if (id == CardDB.cardIDEnum.PRO_001a) return new Sim_PRO_001a();
            //if (id == CardDB.cardIDEnum.NAX6_04) return new Sim_NAX6_04();
            //if (id == CardDB.cardIDEnum.NAX7_05) return new Sim_NAX7_05();
            if (id == CardDB.cardIDEnum.CS2_103) return new Sim_CS2_103();
            if (id == CardDB.cardIDEnum.NEW1_041) return new Sim_NEW1_041();
            if (id == CardDB.cardIDEnum.EX1_360) return new Sim_EX1_360();
            if (id == CardDB.cardIDEnum.FP1_023) return new Sim_FP1_023();
            if (id == CardDB.cardIDEnum.NEW1_038) return new Sim_NEW1_038();
            if (id == CardDB.cardIDEnum.CS2_009) return new Sim_CS2_009();
            //if (id == CardDB.cardIDEnum.NAX10_01H) return new Sim_NAX10_01H();
            if (id == CardDB.cardIDEnum.EX1_010) return new Sim_EX1_010();
            if (id == CardDB.cardIDEnum.CS2_024) return new Sim_CS2_024();
            //if (id == CardDB.cardIDEnum.NAX9_05) return new Sim_NAX9_05();
            if (id == CardDB.cardIDEnum.EX1_565) return new Sim_EX1_565();
            if (id == CardDB.cardIDEnum.CS2_076) return new Sim_CS2_076();
            if (id == CardDB.cardIDEnum.FP1_004) return new Sim_FP1_004();
            //if (id == CardDB.cardIDEnum.CS2_046e) return new Sim_CS2_046e();
            if (id == CardDB.cardIDEnum.CS2_162) return new Sim_CS2_162();
            if (id == CardDB.cardIDEnum.EX1_110t) return new Sim_EX1_110t();
            //if (id == CardDB.cardIDEnum.CS2_104e) return new Sim_CS2_104e();
            if (id == CardDB.cardIDEnum.CS2_181) return new Sim_CS2_181();
            if (id == CardDB.cardIDEnum.EX1_309) return new Sim_EX1_309();
            if (id == CardDB.cardIDEnum.EX1_354) return new Sim_EX1_354();
            //if (id == CardDB.cardIDEnum.NAX10_02H) return new Sim_NAX10_02H();
            //if (id == CardDB.cardIDEnum.NAX7_04H) return new Sim_NAX7_04H();
            //if (id == CardDB.cardIDEnum.TU4f_001) return new Sim_TU4f_001();
            //if (id == CardDB.cardIDEnum.XXX_018) return new Sim_XXX_018();
            if (id == CardDB.cardIDEnum.EX1_023) return new Sim_EX1_023();
            //if (id == CardDB.cardIDEnum.XXX_048) return new Sim_XXX_048();
            //if (id == CardDB.cardIDEnum.XXX_049) return new Sim_XXX_049();
            if (id == CardDB.cardIDEnum.NEW1_034) return new Sim_NEW1_034();
            if (id == CardDB.cardIDEnum.CS2_003) return new Sim_CS2_003();
            if (id == CardDB.cardIDEnum.HERO_06) return new Sim_HERO_06();
            if (id == CardDB.cardIDEnum.CS2_201) return new Sim_CS2_201();
            if (id == CardDB.cardIDEnum.EX1_508) return new Sim_EX1_508();
            if (id == CardDB.cardIDEnum.EX1_259) return new Sim_EX1_259();
            if (id == CardDB.cardIDEnum.EX1_341) return new Sim_EX1_341();
            //if (id == CardDB.cardIDEnum.DREAM_05e) return new Sim_DREAM_05e();
            //if (id == CardDB.cardIDEnum.CRED_09) return new Sim_CRED_09();
            if (id == CardDB.cardIDEnum.EX1_103) return new Sim_EX1_103();
            if (id == CardDB.cardIDEnum.FP1_021) return new Sim_FP1_021();
            if (id == CardDB.cardIDEnum.EX1_411) return new Sim_EX1_411();
            //if (id == CardDB.cardIDEnum.NAX1_04) return new Sim_NAX1_04();
            if (id == CardDB.cardIDEnum.CS2_053) return new Sim_CS2_053();
            if (id == CardDB.cardIDEnum.CS2_182) return new Sim_CS2_182();
            if (id == CardDB.cardIDEnum.CS2_008) return new Sim_CS2_008();
            if (id == CardDB.cardIDEnum.CS2_233) return new Sim_CS2_233();
            if (id == CardDB.cardIDEnum.EX1_626) return new Sim_EX1_626();
            if (id == CardDB.cardIDEnum.EX1_059) return new Sim_EX1_059();
            if (id == CardDB.cardIDEnum.EX1_334) return new Sim_EX1_334();
            if (id == CardDB.cardIDEnum.EX1_619) return new Sim_EX1_619();
            if (id == CardDB.cardIDEnum.NEW1_032) return new Sim_NEW1_032();
            if (id == CardDB.cardIDEnum.EX1_158t) return new Sim_EX1_158t();
            if (id == CardDB.cardIDEnum.EX1_006) return new Sim_EX1_006();
            if (id == CardDB.cardIDEnum.NEW1_031) return new Sim_NEW1_031();
            //if (id == CardDB.cardIDEnum.NAX10_03) return new Sim_NAX10_03();
            if (id == CardDB.cardIDEnum.DREAM_04) return new Sim_DREAM_04();
            //if (id == CardDB.cardIDEnum.NAX1h_01) return new Sim_NAX1h_01();
            //if (id == CardDB.cardIDEnum.CS2_022e) return new Sim_CS2_022e();
            //if (id == CardDB.cardIDEnum.EX1_611e) return new Sim_EX1_611e();
            if (id == CardDB.cardIDEnum.EX1_004) return new Sim_EX1_004();
            //if (id == CardDB.cardIDEnum.EX1_014te) return new Sim_EX1_014te();
            //if (id == CardDB.cardIDEnum.FP1_005e) return new Sim_FP1_005e();
            //if (id == CardDB.cardIDEnum.NAX12_03e) return new Sim_NAX12_03e();
            if (id == CardDB.cardIDEnum.EX1_095) return new Sim_EX1_095();
            if (id == CardDB.cardIDEnum.NEW1_007) return new Sim_NEW1_007();
            if (id == CardDB.cardIDEnum.EX1_275) return new Sim_EX1_275();
            if (id == CardDB.cardIDEnum.EX1_245) return new Sim_EX1_245();
            if (id == CardDB.cardIDEnum.EX1_383) return new Sim_EX1_383();
            if (id == CardDB.cardIDEnum.FP1_016) return new Sim_FP1_016();
            if (id == CardDB.cardIDEnum.EX1_016t) return new Sim_EX1_016t();
            if (id == CardDB.cardIDEnum.CS2_125) return new Sim_CS2_125();
            if (id == CardDB.cardIDEnum.EX1_137) return new Sim_EX1_137();
            //if (id == CardDB.cardIDEnum.EX1_178ae) return new Sim_EX1_178ae();
            if (id == CardDB.cardIDEnum.DS1_185) return new Sim_DS1_185();
            if (id == CardDB.cardIDEnum.FP1_010) return new Sim_FP1_010();
            if (id == CardDB.cardIDEnum.EX1_598) return new Sim_EX1_598();
            //if (id == CardDB.cardIDEnum.NAX9_07) return new Sim_NAX9_07();
            if (id == CardDB.cardIDEnum.EX1_304) return new Sim_EX1_304();
            if (id == CardDB.cardIDEnum.EX1_302) return new Sim_EX1_302();
            //if (id == CardDB.cardIDEnum.XXX_017) return new Sim_XXX_017();
            //if (id == CardDB.cardIDEnum.CS2_011o) return new Sim_CS2_011o();
            if (id == CardDB.cardIDEnum.EX1_614t) return new Sim_EX1_614t();
            //if (id == CardDB.cardIDEnum.TU4a_006) return new Sim_TU4a_006();
            //if (id == CardDB.cardIDEnum.Mekka3e) return new Sim_Mekka3e();
            if (id == CardDB.cardIDEnum.CS2_108) return new Sim_CS2_108();
            if (id == CardDB.cardIDEnum.CS2_046) return new Sim_CS2_046();
            if (id == CardDB.cardIDEnum.EX1_014t) return new Sim_EX1_014t();
            if (id == CardDB.cardIDEnum.NEW1_005) return new Sim_NEW1_005();
            if (id == CardDB.cardIDEnum.EX1_062) return new Sim_EX1_062();
            //if (id == CardDB.cardIDEnum.EX1_366e) return new Sim_EX1_366e();
            if (id == CardDB.cardIDEnum.Mekka1) return new Sim_Mekka1();
            //if (id == CardDB.cardIDEnum.XXX_007) return new Sim_XXX_007();
            if (id == CardDB.cardIDEnum.tt_010a) return new Sim_tt_010a();
            //if (id == CardDB.cardIDEnum.CS2_017o) return new Sim_CS2_017o();
            if (id == CardDB.cardIDEnum.CS2_072) return new Sim_CS2_072();
            if (id == CardDB.cardIDEnum.EX1_tk28) return new Sim_EX1_tk28();
            //if (id == CardDB.cardIDEnum.EX1_604o) return new Sim_EX1_604o();
            if (id == CardDB.cardIDEnum.FP1_014) return new Sim_FP1_014();
            //if (id == CardDB.cardIDEnum.EX1_084e) return new Sim_EX1_084e();
            //if (id == CardDB.cardIDEnum.NAX3_01H) return new Sim_NAX3_01H();
            //if (id == CardDB.cardIDEnum.NAX2_01) return new Sim_NAX2_01();
            if (id == CardDB.cardIDEnum.EX1_409t) return new Sim_EX1_409t();
            //if (id == CardDB.cardIDEnum.CRED_07) return new Sim_CRED_07();
            //if (id == CardDB.cardIDEnum.NAX3_02H) return new Sim_NAX3_02H();
            //if (id == CardDB.cardIDEnum.TU4e_002) return new Sim_TU4e_002();
            if (id == CardDB.cardIDEnum.EX1_507) return new Sim_EX1_507();
            if (id == CardDB.cardIDEnum.EX1_144) return new Sim_EX1_144();
            if (id == CardDB.cardIDEnum.CS2_038) return new Sim_CS2_038();
            if (id == CardDB.cardIDEnum.EX1_093) return new Sim_EX1_093();
            if (id == CardDB.cardIDEnum.CS2_080) return new Sim_CS2_080();
            //if (id == CardDB.cardIDEnum.CS1_129e) return new Sim_CS1_129e();
            //if (id == CardDB.cardIDEnum.XXX_013) return new Sim_XXX_013();
            if (id == CardDB.cardIDEnum.EX1_005) return new Sim_EX1_005();
            if (id == CardDB.cardIDEnum.EX1_382) return new Sim_EX1_382();
            //if (id == CardDB.cardIDEnum.NAX13_02e) return new Sim_NAX13_02e();
            //if (id == CardDB.cardIDEnum.FP1_020e) return new Sim_FP1_020e();
            //if (id == CardDB.cardIDEnum.EX1_603e) return new Sim_EX1_603e();
            if (id == CardDB.cardIDEnum.CS2_028) return new Sim_CS2_028();
            //if (id == CardDB.cardIDEnum.TU4f_002) return new Sim_TU4f_002();
            if (id == CardDB.cardIDEnum.EX1_538) return new Sim_EX1_538();
            //if (id == CardDB.cardIDEnum.GAME_003e) return new Sim_GAME_003e();
            if (id == CardDB.cardIDEnum.DREAM_02) return new Sim_DREAM_02();
            if (id == CardDB.cardIDEnum.EX1_581) return new Sim_EX1_581();
            //if (id == CardDB.cardIDEnum.NAX15_01H) return new Sim_NAX15_01H();
            if (id == CardDB.cardIDEnum.EX1_131t) return new Sim_EX1_131t();
            if (id == CardDB.cardIDEnum.CS2_147) return new Sim_CS2_147();
            if (id == CardDB.cardIDEnum.CS1_113) return new Sim_CS1_113();
            if (id == CardDB.cardIDEnum.CS2_161) return new Sim_CS2_161();
            if (id == CardDB.cardIDEnum.CS2_031) return new Sim_CS2_031();
            if (id == CardDB.cardIDEnum.EX1_166b) return new Sim_EX1_166b();
            if (id == CardDB.cardIDEnum.EX1_066) return new Sim_EX1_066();
            //if (id == CardDB.cardIDEnum.TU4c_007) return new Sim_TU4c_007();
            if (id == CardDB.cardIDEnum.EX1_355) return new Sim_EX1_355();
            //if (id == CardDB.cardIDEnum.EX1_507e) return new Sim_EX1_507e();
            if (id == CardDB.cardIDEnum.EX1_534) return new Sim_EX1_534();
            if (id == CardDB.cardIDEnum.EX1_162) return new Sim_EX1_162();
            //if (id == CardDB.cardIDEnum.TU4a_004) return new Sim_TU4a_004();
            if (id == CardDB.cardIDEnum.EX1_363) return new Sim_EX1_363();
            if (id == CardDB.cardIDEnum.EX1_164a) return new Sim_EX1_164a();
            if (id == CardDB.cardIDEnum.CS2_188) return new Sim_CS2_188();
            if (id == CardDB.cardIDEnum.EX1_016) return new Sim_EX1_016();
            //if (id == CardDB.cardIDEnum.NAX6_03t) return new Sim_NAX6_03t();
            //if (id == CardDB.cardIDEnum.EX1_tk31) return new Sim_EX1_tk31();
            if (id == CardDB.cardIDEnum.EX1_603) return new Sim_EX1_603();
            if (id == CardDB.cardIDEnum.EX1_238) return new Sim_EX1_238();
            if (id == CardDB.cardIDEnum.EX1_166) return new Sim_EX1_166();
            if (id == CardDB.cardIDEnum.DS1h_292) return new Sim_DS1h_292();
            if (id == CardDB.cardIDEnum.DS1_183) return new Sim_DS1_183();
            //if (id == CardDB.cardIDEnum.NAX15_03n) return new Sim_NAX15_03n();
            //if (id == CardDB.cardIDEnum.NAX8_02H) return new Sim_NAX8_02H();
            //if (id == CardDB.cardIDEnum.NAX7_01H) return new Sim_NAX7_01H();
            //if (id == CardDB.cardIDEnum.NAX9_02H) return new Sim_NAX9_02H();
            //if (id == CardDB.cardIDEnum.CRED_11) return new Sim_CRED_11();
            //if (id == CardDB.cardIDEnum.XXX_019) return new Sim_XXX_019();
            if (id == CardDB.cardIDEnum.EX1_076) return new Sim_EX1_076();
            if (id == CardDB.cardIDEnum.EX1_048) return new Sim_EX1_048();
            //if (id == CardDB.cardIDEnum.CS2_038e) return new Sim_CS2_038e();
            if (id == CardDB.cardIDEnum.FP1_026) return new Sim_FP1_026();
            if (id == CardDB.cardIDEnum.CS2_074) return new Sim_CS2_074();
            if (id == CardDB.cardIDEnum.FP1_027) return new Sim_FP1_027();
            if (id == CardDB.cardIDEnum.EX1_323w) return new Sim_EX1_323w();
            if (id == CardDB.cardIDEnum.EX1_129) return new Sim_EX1_129();
            //if (id == CardDB.cardIDEnum.NEW1_024o) return new Sim_NEW1_024o();
            //if (id == CardDB.cardIDEnum.NAX11_02) return new Sim_NAX11_02();
            if (id == CardDB.cardIDEnum.EX1_405) return new Sim_EX1_405();
            if (id == CardDB.cardIDEnum.EX1_317) return new Sim_EX1_317();
            if (id == CardDB.cardIDEnum.EX1_606) return new Sim_EX1_606();
            //if (id == CardDB.cardIDEnum.EX1_590e) return new Sim_EX1_590e();
            //if (id == CardDB.cardIDEnum.XXX_044) return new Sim_XXX_044();
            //if (id == CardDB.cardIDEnum.CS2_074e) return new Sim_CS2_074e();
            //if (id == CardDB.cardIDEnum.TU4a_005) return new Sim_TU4a_005();
            if (id == CardDB.cardIDEnum.FP1_006) return new Sim_FP1_006();
            //if (id == CardDB.cardIDEnum.EX1_258e) return new Sim_EX1_258e();
            //if (id == CardDB.cardIDEnum.TU4f_004o) return new Sim_TU4f_004o();
            if (id == CardDB.cardIDEnum.NEW1_008) return new Sim_NEW1_008();
            if (id == CardDB.cardIDEnum.CS2_119) return new Sim_CS2_119();
            //if (id == CardDB.cardIDEnum.NEW1_017e) return new Sim_NEW1_017e();
            //if (id == CardDB.cardIDEnum.EX1_334e) return new Sim_EX1_334e();
            //if (id == CardDB.cardIDEnum.TU4e_001) return new Sim_TU4e_001();
            if (id == CardDB.cardIDEnum.CS2_121) return new Sim_CS2_121();
            if (id == CardDB.cardIDEnum.CS1h_001) return new Sim_CS1h_001();
            if (id == CardDB.cardIDEnum.EX1_tk34) return new Sim_EX1_tk34();
            if (id == CardDB.cardIDEnum.NEW1_020) return new Sim_NEW1_020();
            if (id == CardDB.cardIDEnum.CS2_196) return new Sim_CS2_196();
            if (id == CardDB.cardIDEnum.EX1_312) return new Sim_EX1_312();
            //if (id == CardDB.cardIDEnum.NAX1_01) return new Sim_NAX1_01();
            if (id == CardDB.cardIDEnum.FP1_022) return new Sim_FP1_022();
            if (id == CardDB.cardIDEnum.EX1_160b) return new Sim_EX1_160b();
            if (id == CardDB.cardIDEnum.EX1_563) return new Sim_EX1_563();
            //if (id == CardDB.cardIDEnum.XXX_039) return new Sim_XXX_039();
            if (id == CardDB.cardIDEnum.FP1_031) return new Sim_FP1_031();
            //if (id == CardDB.cardIDEnum.CS2_087e) return new Sim_CS2_087e();
            //if (id == CardDB.cardIDEnum.EX1_613e) return new Sim_EX1_613e();
            //if (id == CardDB.cardIDEnum.NAX9_02) return new Sim_NAX9_02();
            if (id == CardDB.cardIDEnum.NEW1_029) return new Sim_NEW1_029();
            if (id == CardDB.cardIDEnum.CS1_129) return new Sim_CS1_129();
            if (id == CardDB.cardIDEnum.HERO_03) return new Sim_HERO_03();
            if (id == CardDB.cardIDEnum.Mekka4t) return new Sim_Mekka4t();
            if (id == CardDB.cardIDEnum.EX1_158) return new Sim_EX1_158();
            //if (id == CardDB.cardIDEnum.XXX_010) return new Sim_XXX_010();
            if (id == CardDB.cardIDEnum.NEW1_025) return new Sim_NEW1_025();
            if (id == CardDB.cardIDEnum.FP1_012t) return new Sim_FP1_012t();
            if (id == CardDB.cardIDEnum.EX1_083) return new Sim_EX1_083();
            if (id == CardDB.cardIDEnum.EX1_295) return new Sim_EX1_295();
            if (id == CardDB.cardIDEnum.EX1_407) return new Sim_EX1_407();
            if (id == CardDB.cardIDEnum.NEW1_004) return new Sim_NEW1_004();
            if (id == CardDB.cardIDEnum.FP1_019) return new Sim_FP1_019();
            if (id == CardDB.cardIDEnum.PRO_001at) return new Sim_PRO_001at();
            //if (id == CardDB.cardIDEnum.NAX13_03e) return new Sim_NAX13_03e();
            if (id == CardDB.cardIDEnum.EX1_625t) return new Sim_EX1_625t();
            if (id == CardDB.cardIDEnum.EX1_014) return new Sim_EX1_014();
            //if (id == CardDB.cardIDEnum.CRED_04) return new Sim_CRED_04();
            //if (id == CardDB.cardIDEnum.NAX12_01H) return new Sim_NAX12_01H();
            if (id == CardDB.cardIDEnum.CS2_097) return new Sim_CS2_097();
            if (id == CardDB.cardIDEnum.EX1_558) return new Sim_EX1_558();
            //if (id == CardDB.cardIDEnum.XXX_047) return new Sim_XXX_047();
            if (id == CardDB.cardIDEnum.EX1_tk29) return new Sim_EX1_tk29();
            if (id == CardDB.cardIDEnum.CS2_186) return new Sim_CS2_186();
            if (id == CardDB.cardIDEnum.EX1_084) return new Sim_EX1_084();
            if (id == CardDB.cardIDEnum.NEW1_012) return new Sim_NEW1_012();
            if (id == CardDB.cardIDEnum.FP1_014t) return new Sim_FP1_014t();
            //if (id == CardDB.cardIDEnum.NAX1_03) return new Sim_NAX1_03();
            //if (id == CardDB.cardIDEnum.EX1_623e) return new Sim_EX1_623e();
            if (id == CardDB.cardIDEnum.EX1_578) return new Sim_EX1_578();
            //if (id == CardDB.cardIDEnum.CS2_073e2) return new Sim_CS2_073e2();
            if (id == CardDB.cardIDEnum.CS2_221) return new Sim_CS2_221();
            if (id == CardDB.cardIDEnum.EX1_019) return new Sim_EX1_019();
            //if (id == CardDB.cardIDEnum.NAX15_04a) return new Sim_NAX15_04a();
            if (id == CardDB.cardIDEnum.FP1_019t) return new Sim_FP1_019t();
            if (id == CardDB.cardIDEnum.EX1_132) return new Sim_EX1_132();
            if (id == CardDB.cardIDEnum.EX1_284) return new Sim_EX1_284();
            if (id == CardDB.cardIDEnum.EX1_105) return new Sim_EX1_105();
            if (id == CardDB.cardIDEnum.NEW1_011) return new Sim_NEW1_011();
            //if (id == CardDB.cardIDEnum.NAX9_07e) return new Sim_NAX9_07e();
            if (id == CardDB.cardIDEnum.EX1_017) return new Sim_EX1_017();
            if (id == CardDB.cardIDEnum.EX1_249) return new Sim_EX1_249();
            //if (id == CardDB.cardIDEnum.EX1_162o) return new Sim_EX1_162o();
            if (id == CardDB.cardIDEnum.FP1_002t) return new Sim_FP1_002t();
            //if (id == CardDB.cardIDEnum.NAX3_02) return new Sim_NAX3_02();
            if (id == CardDB.cardIDEnum.EX1_313) return new Sim_EX1_313();
            //if (id == CardDB.cardIDEnum.EX1_549o) return new Sim_EX1_549o();
            //if (id == CardDB.cardIDEnum.EX1_091o) return new Sim_EX1_091o();
            //if (id == CardDB.cardIDEnum.CS2_084e) return new Sim_CS2_084e();
            if (id == CardDB.cardIDEnum.EX1_155b) return new Sim_EX1_155b();
            // (id == CardDB.cardIDEnum.NAX11_01) return new Sim_NAX11_01();
            if (id == CardDB.cardIDEnum.NEW1_033) return new Sim_NEW1_033();
            if (id == CardDB.cardIDEnum.CS2_106) return new Sim_CS2_106();
            //if (id == CardDB.cardIDEnum.XXX_002) return new Sim_XXX_002();
            if (id == CardDB.cardIDEnum.FP1_018) return new Sim_FP1_018();
            //if (id == CardDB.cardIDEnum.NEW1_036e2) return new Sim_NEW1_036e2();
            //if (id == CardDB.cardIDEnum.XXX_004) return new Sim_XXX_004();
            //if (id == CardDB.cardIDEnum.NAX11_02H) return new Sim_NAX11_02H();
            //if (id == CardDB.cardIDEnum.CS2_122e) return new Sim_CS2_122e();
            if (id == CardDB.cardIDEnum.DS1_233) return new Sim_DS1_233();
            if (id == CardDB.cardIDEnum.DS1_175) return new Sim_DS1_175();
            if (id == CardDB.cardIDEnum.NEW1_024) return new Sim_NEW1_024();
            if (id == CardDB.cardIDEnum.CS2_189) return new Sim_CS2_189();
            //if (id == CardDB.cardIDEnum.CRED_10) return new Sim_CRED_10();
            if (id == CardDB.cardIDEnum.NEW1_037) return new Sim_NEW1_037();
            if (id == CardDB.cardIDEnum.EX1_414) return new Sim_EX1_414();
            if (id == CardDB.cardIDEnum.EX1_538t) return new Sim_EX1_538t();
            //if (id == CardDB.cardIDEnum.FP1_030e) return new Sim_FP1_030e();
            if (id == CardDB.cardIDEnum.EX1_586) return new Sim_EX1_586();
            if (id == CardDB.cardIDEnum.EX1_310) return new Sim_EX1_310();
            if (id == CardDB.cardIDEnum.NEW1_010) return new Sim_NEW1_010();
            //if (id == CardDB.cardIDEnum.CS2_103e) return new Sim_CS2_103e();
            //if (id == CardDB.cardIDEnum.EX1_080o) return new Sim_EX1_080o();
            //if (id == CardDB.cardIDEnum.CS2_005o) return new Sim_CS2_005o();
            //if (id == CardDB.cardIDEnum.EX1_363e2) return new Sim_EX1_363e2();
            if (id == CardDB.cardIDEnum.EX1_534t) return new Sim_EX1_534t();
            if (id == CardDB.cardIDEnum.FP1_028) return new Sim_FP1_028();
            if (id == CardDB.cardIDEnum.EX1_604) return new Sim_EX1_604();
            if (id == CardDB.cardIDEnum.EX1_160) return new Sim_EX1_160();
            if (id == CardDB.cardIDEnum.EX1_165t1) return new Sim_EX1_165t1();
            if (id == CardDB.cardIDEnum.CS2_062) return new Sim_CS2_062();
            if (id == CardDB.cardIDEnum.CS2_155) return new Sim_CS2_155();
            if (id == CardDB.cardIDEnum.CS2_213) return new Sim_CS2_213();
            //if (id == CardDB.cardIDEnum.TU4f_007) return new Sim_TU4f_007();
            //if (id == CardDB.cardIDEnum.GAME_004) return new Sim_GAME_004();
            //if (id == CardDB.cardIDEnum.NAX5_01) return new Sim_NAX5_01();
            //if (id == CardDB.cardIDEnum.XXX_020) return new Sim_XXX_020();
            //if (id == CardDB.cardIDEnum.NAX15_02H) return new Sim_NAX15_02H();
            if (id == CardDB.cardIDEnum.CS2_004) return new Sim_CS2_004();
            //if (id == CardDB.cardIDEnum.NAX2_03H) return new Sim_NAX2_03H();
            //if (id == CardDB.cardIDEnum.EX1_561e) return new Sim_EX1_561e();
            if (id == CardDB.cardIDEnum.CS2_023) return new Sim_CS2_023();
            if (id == CardDB.cardIDEnum.EX1_164) return new Sim_EX1_164();
            if (id == CardDB.cardIDEnum.EX1_009) return new Sim_EX1_009();
            //if (id == CardDB.cardIDEnum.NAX6_01) return new Sim_NAX6_01();
            if (id == CardDB.cardIDEnum.FP1_007) return new Sim_FP1_007();
            //if (id == CardDB.cardIDEnum.NAX1h_04) return new Sim_NAX1h_04();
            //if (id == CardDB.cardIDEnum.NAX2_05H) return new Sim_NAX2_05H();
            //if (id == CardDB.cardIDEnum.NAX10_02) return new Sim_NAX10_02();
            if (id == CardDB.cardIDEnum.EX1_345) return new Sim_EX1_345();
            if (id == CardDB.cardIDEnum.EX1_116) return new Sim_EX1_116();
            if (id == CardDB.cardIDEnum.EX1_399) return new Sim_EX1_399();
            if (id == CardDB.cardIDEnum.EX1_587) return new Sim_EX1_587();
            //if (id == CardDB.cardIDEnum.XXX_026) return new Sim_XXX_026();
            if (id == CardDB.cardIDEnum.EX1_571) return new Sim_EX1_571();
            if (id == CardDB.cardIDEnum.EX1_335) return new Sim_EX1_335();
            //if (id == CardDB.cardIDEnum.XXX_050) return new Sim_XXX_050();
            //if (id == CardDB.cardIDEnum.TU4e_004) return new Sim_TU4e_004();
            if (id == CardDB.cardIDEnum.HERO_08) return new Sim_HERO_08();
            if (id == CardDB.cardIDEnum.EX1_166a) return new Sim_EX1_166a();
            //if (id == CardDB.cardIDEnum.NAX2_03) return new Sim_NAX2_03();
            if (id == CardDB.cardIDEnum.EX1_finkle) return new Sim_EX1_finkle();
            //if (id == CardDB.cardIDEnum.NAX4_03H) return new Sim_NAX4_03H();
            if (id == CardDB.cardIDEnum.EX1_164b) return new Sim_EX1_164b();
            if (id == CardDB.cardIDEnum.EX1_283) return new Sim_EX1_283();
            if (id == CardDB.cardIDEnum.EX1_339) return new Sim_EX1_339();
            //if (id == CardDB.cardIDEnum.CRED_13) return new Sim_CRED_13();
            //if (id == CardDB.cardIDEnum.EX1_178be) return new Sim_EX1_178be();
            if (id == CardDB.cardIDEnum.EX1_531) return new Sim_EX1_531();
            if (id == CardDB.cardIDEnum.EX1_134) return new Sim_EX1_134();
            if (id == CardDB.cardIDEnum.EX1_350) return new Sim_EX1_350();
            if (id == CardDB.cardIDEnum.EX1_308) return new Sim_EX1_308();
            if (id == CardDB.cardIDEnum.CS2_197) return new Sim_CS2_197();
            if (id == CardDB.cardIDEnum.skele21) return new Sim_skele21();
            //if (id == CardDB.cardIDEnum.CS2_222o) return new Sim_CS2_222o();
            //if (id == CardDB.cardIDEnum.XXX_015) return new Sim_XXX_015();
            if (id == CardDB.cardIDEnum.FP1_013) return new Sim_FP1_013();
            if (id == CardDB.cardIDEnum.NEW1_006) return new Sim_NEW1_006();
            //if (id == CardDB.cardIDEnum.EX1_399e) return new Sim_EX1_399e();
            if (id == CardDB.cardIDEnum.EX1_509) return new Sim_EX1_509();
            if (id == CardDB.cardIDEnum.EX1_612) return new Sim_EX1_612();
            //if (id == CardDB.cardIDEnum.NAX8_05t) return new Sim_NAX8_05t();
            //if (id == CardDB.cardIDEnum.NAX9_05H) return new Sim_NAX9_05H();
            if (id == CardDB.cardIDEnum.EX1_021) return new Sim_EX1_021();
            //if (id == CardDB.cardIDEnum.CS2_041e) return new Sim_CS2_041e();
            if (id == CardDB.cardIDEnum.CS2_226) return new Sim_CS2_226();
            if (id == CardDB.cardIDEnum.EX1_608) return new Sim_EX1_608();
            //if (id == CardDB.cardIDEnum.NAX13_05H) return new Sim_NAX13_05H();
            //if (id == CardDB.cardIDEnum.NAX13_04H) return new Sim_NAX13_04H();
            //if (id == CardDB.cardIDEnum.TU4c_008) return new Sim_TU4c_008();
            if (id == CardDB.cardIDEnum.EX1_624) return new Sim_EX1_624();
            if (id == CardDB.cardIDEnum.EX1_616) return new Sim_EX1_616();
            if (id == CardDB.cardIDEnum.EX1_008) return new Sim_EX1_008();
            if (id == CardDB.cardIDEnum.PlaceholderCard) return new Sim_PlaceholderCard();
            //if (id == CardDB.cardIDEnum.XXX_016) return new Sim_XXX_016();
            if (id == CardDB.cardIDEnum.EX1_045) return new Sim_EX1_045();
            if (id == CardDB.cardIDEnum.EX1_015) return new Sim_EX1_015();
            //if (id == CardDB.cardIDEnum.GAME_003) return new Sim_GAME_003();
            if (id == CardDB.cardIDEnum.CS2_171) return new Sim_CS2_171();
            if (id == CardDB.cardIDEnum.CS2_041) return new Sim_CS2_041();
            if (id == CardDB.cardIDEnum.EX1_128) return new Sim_EX1_128();
            if (id == CardDB.cardIDEnum.CS2_112) return new Sim_CS2_112();
            if (id == CardDB.cardIDEnum.HERO_07) return new Sim_HERO_07();
            if (id == CardDB.cardIDEnum.EX1_412) return new Sim_EX1_412();
            //if (id == CardDB.cardIDEnum.EX1_612o) return new Sim_EX1_612o();
            if (id == CardDB.cardIDEnum.CS2_117) return new Sim_CS2_117();
            //if (id == CardDB.cardIDEnum.XXX_009e) return new Sim_XXX_009e();
            if (id == CardDB.cardIDEnum.EX1_562) return new Sim_EX1_562();
            if (id == CardDB.cardIDEnum.EX1_055) return new Sim_EX1_055();
            //if (id == CardDB.cardIDEnum.NAX9_06) return new Sim_NAX9_06();
            //if (id == CardDB.cardIDEnum.TU4e_007) return new Sim_TU4e_007();
            if (id == CardDB.cardIDEnum.FP1_012) return new Sim_FP1_012();
            if (id == CardDB.cardIDEnum.EX1_317t) return new Sim_EX1_317t();
            //if (id == CardDB.cardIDEnum.EX1_004e) return new Sim_EX1_004e();
            if (id == CardDB.cardIDEnum.EX1_278) return new Sim_EX1_278();
            if (id == CardDB.cardIDEnum.CS2_tk1) return new Sim_CS2_tk1();
            if (id == CardDB.cardIDEnum.EX1_590) return new Sim_EX1_590();
            if (id == CardDB.cardIDEnum.CS1_130) return new Sim_CS1_130();
            if (id == CardDB.cardIDEnum.NEW1_008b) return new Sim_NEW1_008b();
            if (id == CardDB.cardIDEnum.EX1_365) return new Sim_EX1_365();
            if (id == CardDB.cardIDEnum.CS2_141) return new Sim_CS2_141();
            if (id == CardDB.cardIDEnum.PRO_001) return new Sim_PRO_001();
            //if (id == CardDB.cardIDEnum.NAX8_04t) return new Sim_NAX8_04t();
            if (id == CardDB.cardIDEnum.CS2_173) return new Sim_CS2_173();
            if (id == CardDB.cardIDEnum.CS2_017) return new Sim_CS2_017();
            //if (id == CardDB.cardIDEnum.CRED_16) return new Sim_CRED_16();
            if (id == CardDB.cardIDEnum.EX1_392) return new Sim_EX1_392();
            if (id == CardDB.cardIDEnum.EX1_593) return new Sim_EX1_593();
            //if (id == CardDB.cardIDEnum.FP1_023e) return new Sim_FP1_023e();
            //if (id == CardDB.cardIDEnum.NAX1_05) return new Sim_NAX1_05();
            //if (id == CardDB.cardIDEnum.TU4d_002) return new Sim_TU4d_002();
            //if (id == CardDB.cardIDEnum.CRED_15) return new Sim_CRED_15();
            if (id == CardDB.cardIDEnum.EX1_049) return new Sim_EX1_049();
            if (id == CardDB.cardIDEnum.EX1_002) return new Sim_EX1_002();
            //if (id == CardDB.cardIDEnum.TU4f_005) return new Sim_TU4f_005();
            //if (id == CardDB.cardIDEnum.NEW1_029t) return new Sim_NEW1_029t();
            //if (id == CardDB.cardIDEnum.TU4a_001) return new Sim_TU4a_001();
            if (id == CardDB.cardIDEnum.CS2_056) return new Sim_CS2_056();
            if (id == CardDB.cardIDEnum.EX1_596) return new Sim_EX1_596();
            if (id == CardDB.cardIDEnum.EX1_136) return new Sim_EX1_136();
            if (id == CardDB.cardIDEnum.EX1_323) return new Sim_EX1_323();
            if (id == CardDB.cardIDEnum.CS2_073) return new Sim_CS2_073();
            //if (id == CardDB.cardIDEnum.EX1_246e) return new Sim_EX1_246e();
            //if (id == CardDB.cardIDEnum.NAX12_01) return new Sim_NAX12_01();
            //if (id == CardDB.cardIDEnum.EX1_244e) return new Sim_EX1_244e();
            if (id == CardDB.cardIDEnum.EX1_001) return new Sim_EX1_001();
            //if (id == CardDB.cardIDEnum.EX1_607e) return new Sim_EX1_607e();
            if (id == CardDB.cardIDEnum.EX1_044) return new Sim_EX1_044();
            //if (id == CardDB.cardIDEnum.EX1_573ae) return new Sim_EX1_573ae();
            //if (id == CardDB.cardIDEnum.XXX_025) return new Sim_XXX_025();
            //if (id == CardDB.cardIDEnum.CRED_06) return new Sim_CRED_06();
            if (id == CardDB.cardIDEnum.Mekka4) return new Sim_Mekka4();
            if (id == CardDB.cardIDEnum.CS2_142) return new Sim_CS2_142();
            //if (id == CardDB.cardIDEnum.TU4f_004) return new Sim_TU4f_004();
            //if (id == CardDB.cardIDEnum.NAX5_02H) return new Sim_NAX5_02H();
            //if (id == CardDB.cardIDEnum.EX1_411e2) return new Sim_EX1_411e2();
            if (id == CardDB.cardIDEnum.EX1_573) return new Sim_EX1_573();
            if (id == CardDB.cardIDEnum.FP1_009) return new Sim_FP1_009();
            if (id == CardDB.cardIDEnum.CS2_050) return new Sim_CS2_050();
            //if (id == CardDB.cardIDEnum.NAX4_03) return new Sim_NAX4_03();
            //if (id == CardDB.cardIDEnum.CS2_063e) return new Sim_CS2_063e();
            //if (id == CardDB.cardIDEnum.NAX2_05) return new Sim_NAX2_05();
            if (id == CardDB.cardIDEnum.EX1_390) return new Sim_EX1_390();
            if (id == CardDB.cardIDEnum.EX1_610) return new Sim_EX1_610();
            if (id == CardDB.cardIDEnum.hexfrog) return new Sim_hexfrog();
            //if (id == CardDB.cardIDEnum.CS2_181e) return new Sim_CS2_181e();
            //if (id == CardDB.cardIDEnum.NAX6_02) return new Sim_NAX6_02();
            //if (id == CardDB.cardIDEnum.XXX_027) return new Sim_XXX_027();
            if (id == CardDB.cardIDEnum.CS2_082) return new Sim_CS2_082();
            if (id == CardDB.cardIDEnum.NEW1_040) return new Sim_NEW1_040();
            if (id == CardDB.cardIDEnum.DREAM_01) return new Sim_DREAM_01();
            if (id == CardDB.cardIDEnum.EX1_595) return new Sim_EX1_595();
            if (id == CardDB.cardIDEnum.CS2_013) return new Sim_CS2_013();
            if (id == CardDB.cardIDEnum.CS2_077) return new Sim_CS2_077();
            if (id == CardDB.cardIDEnum.NEW1_014) return new Sim_NEW1_014();
            //if (id == CardDB.cardIDEnum.CRED_05) return new Sim_CRED_05();
            if (id == CardDB.cardIDEnum.GAME_002) return new Sim_GAME_002();
            if (id == CardDB.cardIDEnum.EX1_165) return new Sim_EX1_165();
            if (id == CardDB.cardIDEnum.CS2_013t) return new Sim_CS2_013t();
            //if (id == CardDB.cardIDEnum.NAX4_04H) return new Sim_NAX4_04H();
            if (id == CardDB.cardIDEnum.EX1_tk11) return new Sim_EX1_tk11();
            if (id == CardDB.cardIDEnum.EX1_591) return new Sim_EX1_591();
            if (id == CardDB.cardIDEnum.EX1_549) return new Sim_EX1_549();
            if (id == CardDB.cardIDEnum.CS2_045) return new Sim_CS2_045();
            if (id == CardDB.cardIDEnum.CS2_237) return new Sim_CS2_237();
            if (id == CardDB.cardIDEnum.CS2_027) return new Sim_CS2_027();
            //if (id == CardDB.cardIDEnum.EX1_508o) return new Sim_EX1_508o();
            //if (id == CardDB.cardIDEnum.NAX14_03) return new Sim_NAX14_03();
            if (id == CardDB.cardIDEnum.CS2_101t) return new Sim_CS2_101t();
            if (id == CardDB.cardIDEnum.CS2_063) return new Sim_CS2_063();
            if (id == CardDB.cardIDEnum.EX1_145) return new Sim_EX1_145();
            //if (id == CardDB.cardIDEnum.NAX1h_03) return new Sim_NAX1h_03();
            if (id == CardDB.cardIDEnum.EX1_110) return new Sim_EX1_110();
            if (id == CardDB.cardIDEnum.EX1_408) return new Sim_EX1_408();
            if (id == CardDB.cardIDEnum.EX1_544) return new Sim_EX1_544();
            //if (id == CardDB.cardIDEnum.TU4c_006) return new Sim_TU4c_006();
            //if (id == CardDB.cardIDEnum.NAXM_001) return new Sim_NAXM_001();
            if (id == CardDB.cardIDEnum.CS2_151) return new Sim_CS2_151();
            //if (id == CardDB.cardIDEnum.CS2_073e) return new Sim_CS2_073e();
            //if (id == CardDB.cardIDEnum.XXX_006) return new Sim_XXX_006();
            if (id == CardDB.cardIDEnum.CS2_088) return new Sim_CS2_088();
            if (id == CardDB.cardIDEnum.EX1_057) return new Sim_EX1_057();
            if (id == CardDB.cardIDEnum.FP1_020) return new Sim_FP1_020();
            if (id == CardDB.cardIDEnum.CS2_169) return new Sim_CS2_169();
            if (id == CardDB.cardIDEnum.EX1_573t) return new Sim_EX1_573t();
            if (id == CardDB.cardIDEnum.EX1_323h) return new Sim_EX1_323h();
            if (id == CardDB.cardIDEnum.EX1_tk9) return new Sim_EX1_tk9();
            //if (id == CardDB.cardIDEnum.NEW1_018e) return new Sim_NEW1_018e();
            if (id == CardDB.cardIDEnum.CS2_037) return new Sim_CS2_037();
            if (id == CardDB.cardIDEnum.CS2_007) return new Sim_CS2_007();
            //if (id == CardDB.cardIDEnum.EX1_059e2) return new Sim_EX1_059e2();
            if (id == CardDB.cardIDEnum.CS2_227) return new Sim_CS2_227();
            //if (id == CardDB.cardIDEnum.NAX7_03H) return new Sim_NAX7_03H();
            //if (id == CardDB.cardIDEnum.NAX9_01H) return new Sim_NAX9_01H();
            //if (id == CardDB.cardIDEnum.EX1_570e) return new Sim_EX1_570e();
            if (id == CardDB.cardIDEnum.NEW1_003) return new Sim_NEW1_003();
            if (id == CardDB.cardIDEnum.GAME_006) return new Sim_GAME_006();
            if (id == CardDB.cardIDEnum.EX1_320) return new Sim_EX1_320();
            if (id == CardDB.cardIDEnum.EX1_097) return new Sim_EX1_097();
            if (id == CardDB.cardIDEnum.tt_004) return new Sim_tt_004();
            //if (id == CardDB.cardIDEnum.EX1_360e) return new Sim_EX1_360e();
            if (id == CardDB.cardIDEnum.EX1_096) return new Sim_EX1_096();
            //if (id == CardDB.cardIDEnum.DS1_175o) return new Sim_DS1_175o();
            //if (id == CardDB.cardIDEnum.EX1_596e) return new Sim_EX1_596e();
            //if (id == CardDB.cardIDEnum.XXX_014) return new Sim_XXX_014();
            //if (id == CardDB.cardIDEnum.EX1_158e) return new Sim_EX1_158e();
            //if (id == CardDB.cardIDEnum.NAX14_01) return new Sim_NAX14_01();
            //if (id == CardDB.cardIDEnum.CRED_01) return new Sim_CRED_01();
            //if (id == CardDB.cardIDEnum.CRED_08) return new Sim_CRED_08();
            if (id == CardDB.cardIDEnum.EX1_126) return new Sim_EX1_126();
            if (id == CardDB.cardIDEnum.EX1_577) return new Sim_EX1_577();
            if (id == CardDB.cardIDEnum.EX1_319) return new Sim_EX1_319();
            if (id == CardDB.cardIDEnum.EX1_611) return new Sim_EX1_611();
            if (id == CardDB.cardIDEnum.CS2_146) return new Sim_CS2_146();
            if (id == CardDB.cardIDEnum.EX1_154b) return new Sim_EX1_154b();
            if (id == CardDB.cardIDEnum.skele11) return new Sim_skele11();
            if (id == CardDB.cardIDEnum.EX1_165t2) return new Sim_EX1_165t2();
            if (id == CardDB.cardIDEnum.CS2_172) return new Sim_CS2_172();
            if (id == CardDB.cardIDEnum.CS2_114) return new Sim_CS2_114();
            if (id == CardDB.cardIDEnum.CS1_069) return new Sim_CS1_069();
            //if (id == CardDB.cardIDEnum.XXX_003) return new Sim_XXX_003();
            //if (id == CardDB.cardIDEnum.XXX_042) return new Sim_XXX_042();
            //if (id == CardDB.cardIDEnum.NAX8_02) return new Sim_NAX8_02();
            if (id == CardDB.cardIDEnum.EX1_173) return new Sim_EX1_173();
            if (id == CardDB.cardIDEnum.CS1_042) return new Sim_CS1_042();
            //if (id == CardDB.cardIDEnum.NAX8_03) return new Sim_NAX8_03();
            if (id == CardDB.cardIDEnum.EX1_506a) return new Sim_EX1_506a();
            if (id == CardDB.cardIDEnum.EX1_298) return new Sim_EX1_298();
            if (id == CardDB.cardIDEnum.CS2_104) return new Sim_CS2_104();
            if (id == CardDB.cardIDEnum.FP1_001) return new Sim_FP1_001();
            if (id == CardDB.cardIDEnum.HERO_02) return new Sim_HERO_02();
            //if (id == CardDB.cardIDEnum.EX1_316e) return new Sim_EX1_316e();
            //if (id == CardDB.cardIDEnum.NAX7_01) return new Sim_NAX7_01();
            //if (id == CardDB.cardIDEnum.EX1_044e) return new Sim_EX1_044e();
            if (id == CardDB.cardIDEnum.CS2_051) return new Sim_CS2_051();
            if (id == CardDB.cardIDEnum.NEW1_016) return new Sim_NEW1_016();
            //if (id == CardDB.cardIDEnum.EX1_304e) return new Sim_EX1_304e();
            if (id == CardDB.cardIDEnum.EX1_033) return new Sim_EX1_033();
            //if (id == CardDB.cardIDEnum.NAX8_04) return new Sim_NAX8_04();
            if (id == CardDB.cardIDEnum.EX1_028) return new Sim_EX1_028();
            //if (id == CardDB.cardIDEnum.XXX_011) return new Sim_XXX_011();
            if (id == CardDB.cardIDEnum.EX1_621) return new Sim_EX1_621();
            if (id == CardDB.cardIDEnum.EX1_554) return new Sim_EX1_554();
            if (id == CardDB.cardIDEnum.EX1_091) return new Sim_EX1_091();
            if (id == CardDB.cardIDEnum.FP1_017) return new Sim_FP1_017();
            if (id == CardDB.cardIDEnum.EX1_409) return new Sim_EX1_409();
            //if (id == CardDB.cardIDEnum.EX1_363e) return new Sim_EX1_363e();
            if (id == CardDB.cardIDEnum.EX1_410) return new Sim_EX1_410();
            //if (id == CardDB.cardIDEnum.TU4e_005) return new Sim_TU4e_005();
            if (id == CardDB.cardIDEnum.CS2_039) return new Sim_CS2_039();
            //if (id == CardDB.cardIDEnum.NAX12_04) return new Sim_NAX12_04();
            if (id == CardDB.cardIDEnum.EX1_557) return new Sim_EX1_557();
            //if (id == CardDB.cardIDEnum.CS2_105e) return new Sim_CS2_105e();
            //if (id == CardDB.cardIDEnum.EX1_128e) return new Sim_EX1_128e();
            //if (id == CardDB.cardIDEnum.XXX_021) return new Sim_XXX_021();
            if (id == CardDB.cardIDEnum.DS1_070) return new Sim_DS1_070();
            if (id == CardDB.cardIDEnum.CS2_033) return new Sim_CS2_033();
            if (id == CardDB.cardIDEnum.EX1_536) return new Sim_EX1_536();
            //if (id == CardDB.cardIDEnum.TU4a_003) return new Sim_TU4a_003();
            if (id == CardDB.cardIDEnum.EX1_559) return new Sim_EX1_559();
            //if (id == CardDB.cardIDEnum.XXX_023) return new Sim_XXX_023();
            //if (id == CardDB.cardIDEnum.NEW1_033o) return new Sim_NEW1_033o();
            //if (id == CardDB.cardIDEnum.NAX15_04H) return new Sim_NAX15_04H();
            //if (id == CardDB.cardIDEnum.CS2_004e) return new Sim_CS2_004e();
            if (id == CardDB.cardIDEnum.CS2_052) return new Sim_CS2_052();
            if (id == CardDB.cardIDEnum.EX1_539) return new Sim_EX1_539();
            if (id == CardDB.cardIDEnum.EX1_575) return new Sim_EX1_575();
            if (id == CardDB.cardIDEnum.CS2_083b) return new Sim_CS2_083b();
            if (id == CardDB.cardIDEnum.CS2_061) return new Sim_CS2_061();
            if (id == CardDB.cardIDEnum.NEW1_021) return new Sim_NEW1_021();
            if (id == CardDB.cardIDEnum.DS1_055) return new Sim_DS1_055();
            if (id == CardDB.cardIDEnum.EX1_625) return new Sim_EX1_625();
            //if (id == CardDB.cardIDEnum.EX1_382e) return new Sim_EX1_382e();
            //if (id == CardDB.cardIDEnum.CS2_092e) return new Sim_CS2_092e();
            if (id == CardDB.cardIDEnum.CS2_026) return new Sim_CS2_026();
            //if (id == CardDB.cardIDEnum.NAX14_04) return new Sim_NAX14_04();
            //if (id == CardDB.cardIDEnum.NEW1_012o) return new Sim_NEW1_012o();
            //if (id == CardDB.cardIDEnum.EX1_619e) return new Sim_EX1_619e();
            if (id == CardDB.cardIDEnum.EX1_294) return new Sim_EX1_294();
            if (id == CardDB.cardIDEnum.EX1_287) return new Sim_EX1_287();
            //if (id == CardDB.cardIDEnum.EX1_509e) return new Sim_EX1_509e();
            if (id == CardDB.cardIDEnum.EX1_625t2) return new Sim_EX1_625t2();
            if (id == CardDB.cardIDEnum.CS2_118) return new Sim_CS2_118();
            if (id == CardDB.cardIDEnum.CS2_124) return new Sim_CS2_124();
            if (id == CardDB.cardIDEnum.Mekka3) return new Sim_Mekka3();
            //if (id == CardDB.cardIDEnum.NAX13_02) return new Sim_NAX13_02();
            if (id == CardDB.cardIDEnum.EX1_112) return new Sim_EX1_112();
            if (id == CardDB.cardIDEnum.FP1_011) return new Sim_FP1_011();
            //if (id == CardDB.cardIDEnum.CS2_009e) return new Sim_CS2_009e();
            if (id == CardDB.cardIDEnum.HERO_04) return new Sim_HERO_04();
            if (id == CardDB.cardIDEnum.EX1_607) return new Sim_EX1_607();
            if (id == CardDB.cardIDEnum.DREAM_03) return new Sim_DREAM_03();
            //if (id == CardDB.cardIDEnum.NAX11_04e) return new Sim_NAX11_04e();
            //if (id == CardDB.cardIDEnum.EX1_103e) return new Sim_EX1_103e();
            //if (id == CardDB.cardIDEnum.XXX_046) return new Sim_XXX_046();
            if (id == CardDB.cardIDEnum.FP1_003) return new Sim_FP1_003();
            if (id == CardDB.cardIDEnum.CS2_105) return new Sim_CS2_105();
            if (id == CardDB.cardIDEnum.FP1_002) return new Sim_FP1_002();
            //if (id == CardDB.cardIDEnum.TU4c_002) return new Sim_TU4c_002();
            //if (id == CardDB.cardIDEnum.CRED_14) return new Sim_CRED_14();
            if (id == CardDB.cardIDEnum.EX1_567) return new Sim_EX1_567();
            //if (id == CardDB.cardIDEnum.TU4c_004) return new Sim_TU4c_004();
            //if (id == CardDB.cardIDEnum.NAX10_03H) return new Sim_NAX10_03H();
            if (id == CardDB.cardIDEnum.FP1_008) return new Sim_FP1_008();
            if (id == CardDB.cardIDEnum.DS1_184) return new Sim_DS1_184();
            if (id == CardDB.cardIDEnum.CS2_029) return new Sim_CS2_029();
            if (id == CardDB.cardIDEnum.GAME_005) return new Sim_GAME_005();
            if (id == CardDB.cardIDEnum.CS2_187) return new Sim_CS2_187();
            if (id == CardDB.cardIDEnum.EX1_020) return new Sim_EX1_020();
            //if (id == CardDB.cardIDEnum.NAX15_01He) return new Sim_NAX15_01He();
            if (id == CardDB.cardIDEnum.EX1_011) return new Sim_EX1_011();
            if (id == CardDB.cardIDEnum.CS2_057) return new Sim_CS2_057();
            if (id == CardDB.cardIDEnum.EX1_274) return new Sim_EX1_274();
            if (id == CardDB.cardIDEnum.EX1_306) return new Sim_EX1_306();
            //if (id == CardDB.cardIDEnum.NEW1_038o) return new Sim_NEW1_038o();
            if (id == CardDB.cardIDEnum.EX1_170) return new Sim_EX1_170();
            if (id == CardDB.cardIDEnum.EX1_617) return new Sim_EX1_617();
            //if (id == CardDB.cardIDEnum.CS1_113e) return new Sim_CS1_113e();
            if (id == CardDB.cardIDEnum.CS2_101) return new Sim_CS2_101();
            if (id == CardDB.cardIDEnum.FP1_015) return new Sim_FP1_015();
            //if (id == CardDB.cardIDEnum.NAX13_03) return new Sim_NAX13_03();
            if (id == CardDB.cardIDEnum.CS2_005) return new Sim_CS2_005();
            if (id == CardDB.cardIDEnum.EX1_537) return new Sim_EX1_537();
            if (id == CardDB.cardIDEnum.EX1_384) return new Sim_EX1_384();
            //if (id == CardDB.cardIDEnum.TU4a_002) return new Sim_TU4a_002();
            //if (id == CardDB.cardIDEnum.NAX9_04) return new Sim_NAX9_04();
            if (id == CardDB.cardIDEnum.EX1_362) return new Sim_EX1_362();
            //if (id == CardDB.cardIDEnum.NAX12_02) return new Sim_NAX12_02();
            //if (id == CardDB.cardIDEnum.FP1_028e) return new Sim_FP1_028e();
            //if (id == CardDB.cardIDEnum.TU4c_005) return new Sim_TU4c_005();
            if (id == CardDB.cardIDEnum.EX1_301) return new Sim_EX1_301();
            if (id == CardDB.cardIDEnum.CS2_235) return new Sim_CS2_235();
            //if (id == CardDB.cardIDEnum.NAX4_05) return new Sim_NAX4_05();
            if (id == CardDB.cardIDEnum.EX1_029) return new Sim_EX1_029();
            if (id == CardDB.cardIDEnum.CS2_042) return new Sim_CS2_042();
            if (id == CardDB.cardIDEnum.EX1_155a) return new Sim_EX1_155a();
            if (id == CardDB.cardIDEnum.CS2_102) return new Sim_CS2_102();
            if (id == CardDB.cardIDEnum.EX1_609) return new Sim_EX1_609();
            if (id == CardDB.cardIDEnum.NEW1_027) return new Sim_NEW1_027();
            //if (id == CardDB.cardIDEnum.CS2_236e) return new Sim_CS2_236e();
            //if (id == CardDB.cardIDEnum.CS2_083e) return new Sim_CS2_083e();
            //if (id == CardDB.cardIDEnum.NAX6_03te) return new Sim_NAX6_03te();
            if (id == CardDB.cardIDEnum.EX1_165a) return new Sim_EX1_165a();
            if (id == CardDB.cardIDEnum.EX1_570) return new Sim_EX1_570();
            if (id == CardDB.cardIDEnum.EX1_131) return new Sim_EX1_131();
            if (id == CardDB.cardIDEnum.EX1_556) return new Sim_EX1_556();
            if (id == CardDB.cardIDEnum.EX1_543) return new Sim_EX1_543();
            //if (id == CardDB.cardIDEnum.XXX_096) return new Sim_XXX_096();
            //if (id == CardDB.cardIDEnum.TU4c_008e) return new Sim_TU4c_008e();
            //if (id == CardDB.cardIDEnum.EX1_379e) return new Sim_EX1_379e();
            if (id == CardDB.cardIDEnum.NEW1_009) return new Sim_NEW1_009();
            if (id == CardDB.cardIDEnum.EX1_100) return new Sim_EX1_100();
            //if (id == CardDB.cardIDEnum.EX1_274e) return new Sim_EX1_274e();
            //if (id == CardDB.cardIDEnum.CRED_02) return new Sim_CRED_02();
            if (id == CardDB.cardIDEnum.EX1_573a) return new Sim_EX1_573a();
            if (id == CardDB.cardIDEnum.CS2_084) return new Sim_CS2_084();
            if (id == CardDB.cardIDEnum.EX1_582) return new Sim_EX1_582();
            if (id == CardDB.cardIDEnum.EX1_043) return new Sim_EX1_043();
            if (id == CardDB.cardIDEnum.EX1_050) return new Sim_EX1_050();
            //if (id == CardDB.cardIDEnum.TU4b_001) return new Sim_TU4b_001();
            if (id == CardDB.cardIDEnum.FP1_005) return new Sim_FP1_005();
            if (id == CardDB.cardIDEnum.EX1_620) return new Sim_EX1_620();
            //if (id == CardDB.cardIDEnum.NAX15_01) return new Sim_NAX15_01();
            //if (id == CardDB.cardIDEnum.NAX6_03) return new Sim_NAX6_03();
            if (id == CardDB.cardIDEnum.EX1_303) return new Sim_EX1_303();
            if (id == CardDB.cardIDEnum.HERO_09) return new Sim_HERO_09();
            if (id == CardDB.cardIDEnum.EX1_067) return new Sim_EX1_067();
            //if (id == CardDB.cardIDEnum.XXX_028) return new Sim_XXX_028();
            if (id == CardDB.cardIDEnum.EX1_277) return new Sim_EX1_277();
            if (id == CardDB.cardIDEnum.Mekka2) return new Sim_Mekka2();
            //if (id == CardDB.cardIDEnum.NAX14_01H) return new Sim_NAX14_01H();
            //if (id == CardDB.cardIDEnum.NAX15_04) return new Sim_NAX15_04();
            if (id == CardDB.cardIDEnum.FP1_024) return new Sim_FP1_024();
            if (id == CardDB.cardIDEnum.FP1_030) return new Sim_FP1_030();
            //if (id == CardDB.cardIDEnum.CS2_221e) return new Sim_CS2_221e();
            if (id == CardDB.cardIDEnum.EX1_178) return new Sim_EX1_178();
            if (id == CardDB.cardIDEnum.CS2_222) return new Sim_CS2_222();
            //if (id == CardDB.cardIDEnum.EX1_409e) return new Sim_EX1_409e();
            //if (id == CardDB.cardIDEnum.tt_004o) return new Sim_tt_004o();
            //if (id == CardDB.cardIDEnum.EX1_155ae) return new Sim_EX1_155ae();
            //if (id == CardDB.cardIDEnum.NAX11_01H) return new Sim_NAX11_01H();
            if (id == CardDB.cardIDEnum.EX1_160a) return new Sim_EX1_160a();
            //if (id == CardDB.cardIDEnum.NAX15_02) return new Sim_NAX15_02();
            //if (id == CardDB.cardIDEnum.NAX15_05) return new Sim_NAX15_05();
            //if (id == CardDB.cardIDEnum.NEW1_025e) return new Sim_NEW1_025e();
            if (id == CardDB.cardIDEnum.CS2_012) return new Sim_CS2_012();
            //if (id == CardDB.cardIDEnum.XXX_099) return new Sim_XXX_099();
            if (id == CardDB.cardIDEnum.EX1_246) return new Sim_EX1_246();
            if (id == CardDB.cardIDEnum.EX1_572) return new Sim_EX1_572();
            if (id == CardDB.cardIDEnum.EX1_089) return new Sim_EX1_089();
            if (id == CardDB.cardIDEnum.CS2_059) return new Sim_CS2_059();
            if (id == CardDB.cardIDEnum.EX1_279) return new Sim_EX1_279();
            //if (id == CardDB.cardIDEnum.NAX12_02e) return new Sim_NAX12_02e();
            if (id == CardDB.cardIDEnum.CS2_168) return new Sim_CS2_168();
            if (id == CardDB.cardIDEnum.tt_010) return new Sim_tt_010();
            if (id == CardDB.cardIDEnum.NEW1_023) return new Sim_NEW1_023();
            if (id == CardDB.cardIDEnum.CS2_075) return new Sim_CS2_075();
            if (id == CardDB.cardIDEnum.EX1_316) return new Sim_EX1_316();
            if (id == CardDB.cardIDEnum.CS2_025) return new Sim_CS2_025();
            if (id == CardDB.cardIDEnum.CS2_234) return new Sim_CS2_234();
            //if (id == CardDB.cardIDEnum.XXX_043) return new Sim_XXX_043();
            //if (id == CardDB.cardIDEnum.GAME_001) return new Sim_GAME_001();
            //if (id == CardDB.cardIDEnum.NAX5_02) return new Sim_NAX5_02();
            if (id == CardDB.cardIDEnum.EX1_130) return new Sim_EX1_130();
            //if (id == CardDB.cardIDEnum.EX1_584e) return new Sim_EX1_584e();
            if (id == CardDB.cardIDEnum.CS2_064) return new Sim_CS2_064();
            if (id == CardDB.cardIDEnum.EX1_161) return new Sim_EX1_161();
            if (id == CardDB.cardIDEnum.CS2_049) return new Sim_CS2_049();
            //if (id == CardDB.cardIDEnum.NAX13_01) return new Sim_NAX13_01();
            if (id == CardDB.cardIDEnum.EX1_154) return new Sim_EX1_154();
            if (id == CardDB.cardIDEnum.EX1_080) return new Sim_EX1_080();
            if (id == CardDB.cardIDEnum.NEW1_022) return new Sim_NEW1_022();
            //if (id == CardDB.cardIDEnum.NAX2_01H) return new Sim_NAX2_01H();
            //if (id == CardDB.cardIDEnum.EX1_160be) return new Sim_EX1_160be();
            //if (id == CardDB.cardIDEnum.NAX12_03) return new Sim_NAX12_03();
            if (id == CardDB.cardIDEnum.EX1_251) return new Sim_EX1_251();
            if (id == CardDB.cardIDEnum.FP1_025) return new Sim_FP1_025();
            if (id == CardDB.cardIDEnum.EX1_371) return new Sim_EX1_371();
            if (id == CardDB.cardIDEnum.CS2_mirror) return new Sim_CS2_mirror();
            //if (id == CardDB.cardIDEnum.NAX4_01H) return new Sim_NAX4_01H();
            if (id == CardDB.cardIDEnum.EX1_594) return new Sim_EX1_594();
            //if (id == CardDB.cardIDEnum.NAX14_02) return new Sim_NAX14_02();
            //if (id == CardDB.cardIDEnum.TU4c_006e) return new Sim_TU4c_006e();
            if (id == CardDB.cardIDEnum.EX1_560) return new Sim_EX1_560();
            if (id == CardDB.cardIDEnum.CS2_236) return new Sim_CS2_236();
            //if (id == CardDB.cardIDEnum.TU4f_006) return new Sim_TU4f_006();
            if (id == CardDB.cardIDEnum.EX1_402) return new Sim_EX1_402();
            //if (id == CardDB.cardIDEnum.NAX3_01) return new Sim_NAX3_01();
            if (id == CardDB.cardIDEnum.EX1_506) return new Sim_EX1_506();
            //if (id == CardDB.cardIDEnum.NEW1_027e) return new Sim_NEW1_027e();
            //if (id == CardDB.cardIDEnum.DS1_070o) return new Sim_DS1_070o();
            //if (id == CardDB.cardIDEnum.XXX_045) return new Sim_XXX_045();
            //if (id == CardDB.cardIDEnum.XXX_029) return new Sim_XXX_029();
            if (id == CardDB.cardIDEnum.DS1_178) return new Sim_DS1_178();
            //if (id == CardDB.cardIDEnum.XXX_098) return new Sim_XXX_098();
            if (id == CardDB.cardIDEnum.EX1_315) return new Sim_EX1_315();
            if (id == CardDB.cardIDEnum.CS2_094) return new Sim_CS2_094();
            //if (id == CardDB.cardIDEnum.NAX13_01H) return new Sim_NAX13_01H();
            //if (id == CardDB.cardIDEnum.TU4e_002t) return new Sim_TU4e_002t();
            //if (id == CardDB.cardIDEnum.EX1_046e) return new Sim_EX1_046e();
            if (id == CardDB.cardIDEnum.NEW1_040t) return new Sim_NEW1_040t();
            //if (id == CardDB.cardIDEnum.GAME_005e) return new Sim_GAME_005e();
            if (id == CardDB.cardIDEnum.CS2_131) return new Sim_CS2_131();
            //if (id == CardDB.cardIDEnum.XXX_008) return new Sim_XXX_008();
            //if (id == CardDB.cardIDEnum.EX1_531e) return new Sim_EX1_531e();
            //if (id == CardDB.cardIDEnum.CS2_226e) return new Sim_CS2_226e();
            //if (id == CardDB.cardIDEnum.XXX_022e) return new Sim_XXX_022e();
            //if (id == CardDB.cardIDEnum.DS1_178e) return new Sim_DS1_178e();
            //if (id == CardDB.cardIDEnum.CS2_226o) return new Sim_CS2_226o();
            //if (id == CardDB.cardIDEnum.NAX9_04H) return new Sim_NAX9_04H();
            //if (id == CardDB.cardIDEnum.Mekka4e) return new Sim_Mekka4e();
            if (id == CardDB.cardIDEnum.EX1_082) return new Sim_EX1_082();
            if (id == CardDB.cardIDEnum.CS2_093) return new Sim_CS2_093();
            //if (id == CardDB.cardIDEnum.EX1_411e) return new Sim_EX1_411e();
            //if (id == CardDB.cardIDEnum.NAX8_03t) return new Sim_NAX8_03t();
            //if (id == CardDB.cardIDEnum.EX1_145o) return new Sim_EX1_145o();
            //if (id == CardDB.cardIDEnum.NAX7_04) return new Sim_NAX7_04();
            if (id == CardDB.cardIDEnum.CS2_boar) return new Sim_CS2_boar();
            if (id == CardDB.cardIDEnum.NEW1_019) return new Sim_NEW1_019();
            if (id == CardDB.cardIDEnum.EX1_289) return new Sim_EX1_289();
            if (id == CardDB.cardIDEnum.EX1_025t) return new Sim_EX1_025t();
            if (id == CardDB.cardIDEnum.EX1_398t) return new Sim_EX1_398t();
            //if (id == CardDB.cardIDEnum.NAX12_03H) return new Sim_NAX12_03H();
            //if (id == CardDB.cardIDEnum.EX1_055o) return new Sim_EX1_055o();
            if (id == CardDB.cardIDEnum.CS2_091) return new Sim_CS2_091();
            if (id == CardDB.cardIDEnum.EX1_241) return new Sim_EX1_241();
            if (id == CardDB.cardIDEnum.EX1_085) return new Sim_EX1_085();
            if (id == CardDB.cardIDEnum.CS2_200) return new Sim_CS2_200();
            if (id == CardDB.cardIDEnum.CS2_034) return new Sim_CS2_034();
            if (id == CardDB.cardIDEnum.EX1_583) return new Sim_EX1_583();
            if (id == CardDB.cardIDEnum.EX1_584) return new Sim_EX1_584();
            if (id == CardDB.cardIDEnum.EX1_155) return new Sim_EX1_155();
            if (id == CardDB.cardIDEnum.EX1_622) return new Sim_EX1_622();
            if (id == CardDB.cardIDEnum.CS2_203) return new Sim_CS2_203();
            if (id == CardDB.cardIDEnum.EX1_124) return new Sim_EX1_124();
            if (id == CardDB.cardIDEnum.EX1_379) return new Sim_EX1_379();
            //if (id == CardDB.cardIDEnum.NAX7_02) return new Sim_NAX7_02();
            //if (id == CardDB.cardIDEnum.CS2_053e) return new Sim_CS2_053e();
            if (id == CardDB.cardIDEnum.EX1_032) return new Sim_EX1_032();
            //if (id == CardDB.cardIDEnum.NAX9_01) return new Sim_NAX9_01();
            //if (id == CardDB.cardIDEnum.TU4e_003) return new Sim_TU4e_003();
            //if (id == CardDB.cardIDEnum.CS2_146o) return new Sim_CS2_146o();
            //if (id == CardDB.cardIDEnum.NAX8_01H) return new Sim_NAX8_01H();
            //if (id == CardDB.cardIDEnum.XXX_041) return new Sim_XXX_041();
            //if (id == CardDB.cardIDEnum.NAXM_002) return new Sim_NAXM_002();
            if (id == CardDB.cardIDEnum.EX1_391) return new Sim_EX1_391();
            if (id == CardDB.cardIDEnum.EX1_366) return new Sim_EX1_366();
            //if (id == CardDB.cardIDEnum.EX1_059e) return new Sim_EX1_059e();
            //if (id == CardDB.cardIDEnum.XXX_012) return new Sim_XXX_012();
            //if (id == CardDB.cardIDEnum.EX1_565o) return new Sim_EX1_565o();
            //if (id == CardDB.cardIDEnum.EX1_001e) return new Sim_EX1_001e();
            //if (id == CardDB.cardIDEnum.TU4f_003) return new Sim_TU4f_003();
            if (id == CardDB.cardIDEnum.EX1_400) return new Sim_EX1_400();
            if (id == CardDB.cardIDEnum.EX1_614) return new Sim_EX1_614();
            if (id == CardDB.cardIDEnum.EX1_561) return new Sim_EX1_561();
            if (id == CardDB.cardIDEnum.EX1_332) return new Sim_EX1_332();
            if (id == CardDB.cardIDEnum.HERO_05) return new Sim_HERO_05();
            if (id == CardDB.cardIDEnum.CS2_065) return new Sim_CS2_065();
            if (id == CardDB.cardIDEnum.ds1_whelptoken) return new Sim_ds1_whelptoken();
            //if (id == CardDB.cardIDEnum.EX1_536e) return new Sim_EX1_536e();
            if (id == CardDB.cardIDEnum.CS2_032) return new Sim_CS2_032();
            if (id == CardDB.cardIDEnum.CS2_120) return new Sim_CS2_120();
            //if (id == CardDB.cardIDEnum.EX1_155be) return new Sim_EX1_155be();
            if (id == CardDB.cardIDEnum.EX1_247) return new Sim_EX1_247();
            if (id == CardDB.cardIDEnum.EX1_154a) return new Sim_EX1_154a();
            if (id == CardDB.cardIDEnum.EX1_554t) return new Sim_EX1_554t();
            //if (id == CardDB.cardIDEnum.CS2_103e2) return new Sim_CS2_103e2();
            //if (id == CardDB.cardIDEnum.TU4d_003) return new Sim_TU4d_003();
            if (id == CardDB.cardIDEnum.NEW1_026t) return new Sim_NEW1_026t();
            if (id == CardDB.cardIDEnum.EX1_623) return new Sim_EX1_623();
            if (id == CardDB.cardIDEnum.EX1_383t) return new Sim_EX1_383t();
            //if (id == CardDB.cardIDEnum.NAX7_03) return new Sim_NAX7_03();
            if (id == CardDB.cardIDEnum.EX1_597) return new Sim_EX1_597();
            //if (id == CardDB.cardIDEnum.TU4f_006o) return new Sim_TU4f_006o();
            if (id == CardDB.cardIDEnum.EX1_130a) return new Sim_EX1_130a();
            if (id == CardDB.cardIDEnum.CS2_011) return new Sim_CS2_011();
            if (id == CardDB.cardIDEnum.EX1_169) return new Sim_EX1_169();
            if (id == CardDB.cardIDEnum.EX1_tk33) return new Sim_EX1_tk33();
            //if (id == CardDB.cardIDEnum.NAX11_03) return new Sim_NAX11_03();
            //if (id == CardDB.cardIDEnum.NAX4_01) return new Sim_NAX4_01();
            //if (id == CardDB.cardIDEnum.NAX10_01) return new Sim_NAX10_01();
            if (id == CardDB.cardIDEnum.EX1_250) return new Sim_EX1_250();
            if (id == CardDB.cardIDEnum.EX1_564) return new Sim_EX1_564();
            //if (id == CardDB.cardIDEnum.NAX5_03) return new Sim_NAX5_03();
            //if (id == CardDB.cardIDEnum.EX1_043e) return new Sim_EX1_043e();
            if (id == CardDB.cardIDEnum.EX1_349) return new Sim_EX1_349();
            //if (id == CardDB.cardIDEnum.XXX_097) return new Sim_XXX_097();
            if (id == CardDB.cardIDEnum.EX1_102) return new Sim_EX1_102();
            if (id == CardDB.cardIDEnum.EX1_058) return new Sim_EX1_058();
            if (id == CardDB.cardIDEnum.EX1_243) return new Sim_EX1_243();
            if (id == CardDB.cardIDEnum.PRO_001c) return new Sim_PRO_001c();
            if (id == CardDB.cardIDEnum.EX1_116t) return new Sim_EX1_116t();
            //if (id == CardDB.cardIDEnum.NAX15_01e) return new Sim_NAX15_01e();
            if (id == CardDB.cardIDEnum.FP1_029) return new Sim_FP1_029();
            if (id == CardDB.cardIDEnum.CS2_089) return new Sim_CS2_089();
            //if (id == CardDB.cardIDEnum.TU4c_001) return new Sim_TU4c_001();
            if (id == CardDB.cardIDEnum.EX1_248) return new Sim_EX1_248();
            //if (id == CardDB.cardIDEnum.NEW1_037e) return new Sim_NEW1_037e();
            if (id == CardDB.cardIDEnum.CS2_122) return new Sim_CS2_122();
            if (id == CardDB.cardIDEnum.EX1_393) return new Sim_EX1_393();
            if (id == CardDB.cardIDEnum.CS2_232) return new Sim_CS2_232();
            if (id == CardDB.cardIDEnum.EX1_165b) return new Sim_EX1_165b();
            if (id == CardDB.cardIDEnum.NEW1_030) return new Sim_NEW1_030();
            //if (id == CardDB.cardIDEnum.EX1_161o) return new Sim_EX1_161o();
            //if (id == CardDB.cardIDEnum.EX1_093e) return new Sim_EX1_093e();
            if (id == CardDB.cardIDEnum.CS2_150) return new Sim_CS2_150();
            if (id == CardDB.cardIDEnum.CS2_152) return new Sim_CS2_152();
            //if (id == CardDB.cardIDEnum.NAX9_03H) return new Sim_NAX9_03H();
            if (id == CardDB.cardIDEnum.EX1_160t) return new Sim_EX1_160t();
            if (id == CardDB.cardIDEnum.CS2_127) return new Sim_CS2_127();
            //if (id == CardDB.cardIDEnum.CRED_03) return new Sim_CRED_03();
            if (id == CardDB.cardIDEnum.DS1_188) return new Sim_DS1_188();
            //if (id == CardDB.cardIDEnum.XXX_001) return new Sim_XXX_001();
            return new SimTemplate();
        }

        private void enumCreator()
        {
            //call this, if carddb.txt was changed, to get latest public enum cardIDEnum
            Helpfunctions.Instance.logg("public enum cardIDEnum");
            Helpfunctions.Instance.logg("{");
            Helpfunctions.Instance.logg("None,");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");



            Helpfunctions.Instance.logg("public cardIDEnum cardIdstringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardIDEnum." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardIDEnum.None;");
            Helpfunctions.Instance.logg("}");

            List<string> namelist = new List<string>();

            foreach (string cardid in this.namelist)
            {
                if (namelist.Contains(cardid)) continue;
                namelist.Add(cardid);
            }


            Helpfunctions.Instance.logg("public enum cardName");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");

            Helpfunctions.Instance.logg("public cardName cardNamestringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardName." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardName.unknown;");
            Helpfunctions.Instance.logg("}");

            // simcard creator:

            Helpfunctions.Instance.logg("public SimTemplate getSimCard(cardIDEnum id)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg("if(id == CardDB.cardIDEnum." + cardid + ") return new Sim_" + cardid + "();");
            }
            Helpfunctions.Instance.logg("return new SimTemplate();");
            Helpfunctions.Instance.logg("}");

        }


    }

}
