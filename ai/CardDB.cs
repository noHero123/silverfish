// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardDB.cs" company="">
//   
// </copyright>
// <summary>
//   The targett.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    using System.IO;

    /// <summary>
    /// The targett.
    /// </summary>
    public struct targett
    {
        /// <summary>
        /// The target.
        /// </summary>
        public int target ;

        /// <summary>
        /// The target entity.
        /// </summary>
        public int targetEntity;

        /// <summary>
        /// Initializes a new instance of the <see cref="targett"/> struct.
        /// </summary>
        /// <param name="targ">
        /// The targ.
        /// </param>
        /// <param name="ent">
        /// The ent.
        /// </param>
        public targett(int targ, int ent)
        {
            this.target = targ;
            this.targetEntity = ent;
        }
    }

    /// <summary>
    /// The card db.
    /// </summary>
    public class CardDB
    {
        // Data is stored in hearthstone-folder -> data->win cardxml0
        // (data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
        /// <summary>
        /// The cardtype.
        /// </summary>
        public enum cardtype
        {
            /// <summary>
            /// The none.
            /// </summary>
            NONE, 

            /// <summary>
            /// The mob.
            /// </summary>
            MOB, 

            /// <summary>
            /// The spell.
            /// </summary>
            SPELL, 

            /// <summary>
            /// The weapon.
            /// </summary>
            WEAPON, 

            /// <summary>
            /// The heropwr.
            /// </summary>
            HEROPWR, 

            /// <summary>
            /// The enchantment.
            /// </summary>
            ENCHANTMENT, 

        }

        /// <summary>
        /// The cardrace.
        /// </summary>
        public enum cardrace
        {
            /// <summary>
            /// The invalid.
            /// </summary>
            INVALID, 

            /// <summary>
            /// The bloodelf.
            /// </summary>
            BLOODELF, 

            /// <summary>
            /// The draenei.
            /// </summary>
            DRAENEI, 

            /// <summary>
            /// The dwarf.
            /// </summary>
            DWARF, 

            /// <summary>
            /// The gnome.
            /// </summary>
            GNOME, 

            /// <summary>
            /// The goblin.
            /// </summary>
            GOBLIN, 

            /// <summary>
            /// The human.
            /// </summary>
            HUMAN, 

            /// <summary>
            /// The nightelf.
            /// </summary>
            NIGHTELF, 

            /// <summary>
            /// The orc.
            /// </summary>
            ORC, 

            /// <summary>
            /// The tauren.
            /// </summary>
            TAUREN, 

            /// <summary>
            /// The troll.
            /// </summary>
            TROLL, 

            /// <summary>
            /// The undead.
            /// </summary>
            UNDEAD, 

            /// <summary>
            /// The worgen.
            /// </summary>
            WORGEN, 

            /// <summary>
            /// The gobli n 2.
            /// </summary>
            GOBLIN2, 

            /// <summary>
            /// The murloc.
            /// </summary>
            MURLOC, 

            /// <summary>
            /// The demon.
            /// </summary>
            DEMON, 

            /// <summary>
            /// The scourge.
            /// </summary>
            SCOURGE, 

            /// <summary>
            /// The mechanical.
            /// </summary>
            MECHANICAL, 

            /// <summary>
            /// The elemental.
            /// </summary>
            ELEMENTAL, 

            /// <summary>
            /// The ogre.
            /// </summary>
            OGRE, 

            /// <summary>
            /// The pet.
            /// </summary>
            PET, 

            /// <summary>
            /// The totem.
            /// </summary>
            TOTEM, 

            /// <summary>
            /// The nerubian.
            /// </summary>
            NERUBIAN, 

            /// <summary>
            /// The pirate.
            /// </summary>
            PIRATE, 

            /// <summary>
            /// The dragon.
            /// </summary>
            DRAGON
        }

        /// <summary>
        /// The card id enum.
        /// </summary>
        public enum cardIDEnum
        {
            /// <summary>
            /// The none.
            /// </summary>
            None, 

            /// <summary>
            /// The xx x_040.
            /// </summary>
            XXX_040, 

            /// <summary>
            /// The na x 5_01 h.
            /// </summary>
            NAX5_01H, 

            /// <summary>
            /// The c s 2_188 o.
            /// </summary>
            CS2_188o, 

            /// <summary>
            /// The na x 6_02 h.
            /// </summary>
            NAX6_02H, 

            /// <summary>
            /// The ne w 1_007 b.
            /// </summary>
            NEW1_007b, 

            /// <summary>
            /// The na x 6_02 e.
            /// </summary>
            NAX6_02e, 

            /// <summary>
            /// The t u 4 c_003.
            /// </summary>
            TU4c_003, 

            /// <summary>
            /// The xx x_024.
            /// </summary>
            XXX_024, 

            /// <summary>
            /// The e x 1_613.
            /// </summary>
            EX1_613, 

            /// <summary>
            /// The na x 8_01.
            /// </summary>
            NAX8_01, 

            /// <summary>
            /// The e x 1_295 o.
            /// </summary>
            EX1_295o, 

            /// <summary>
            /// The c s 2_059 o.
            /// </summary>
            CS2_059o, 

            /// <summary>
            /// The e x 1_133.
            /// </summary>
            EX1_133, 

            /// <summary>
            /// The ne w 1_018.
            /// </summary>
            NEW1_018, 

            /// <summary>
            /// The na x 15_03 t.
            /// </summary>
            NAX15_03t, 

            /// <summary>
            /// The e x 1_012.
            /// </summary>
            EX1_012, 

            /// <summary>
            /// The e x 1_178 a.
            /// </summary>
            EX1_178a, 

            /// <summary>
            /// The c s 2_231.
            /// </summary>
            CS2_231, 

            /// <summary>
            /// The e x 1_019 e.
            /// </summary>
            EX1_019e, 

            /// <summary>
            /// The cre d_12.
            /// </summary>
            CRED_12, 

            /// <summary>
            /// The c s 2_179.
            /// </summary>
            CS2_179, 

            /// <summary>
            /// The c s 2_045 e.
            /// </summary>
            CS2_045e, 

            /// <summary>
            /// The e x 1_244.
            /// </summary>
            EX1_244, 

            /// <summary>
            /// The e x 1_178 b.
            /// </summary>
            EX1_178b, 

            /// <summary>
            /// The xx x_030.
            /// </summary>
            XXX_030, 

            /// <summary>
            /// The na x 8_05.
            /// </summary>
            NAX8_05, 

            /// <summary>
            /// The e x 1_573 b.
            /// </summary>
            EX1_573b, 

            /// <summary>
            /// The t u 4 d_001.
            /// </summary>
            TU4d_001, 

            /// <summary>
            /// The ne w 1_007 a.
            /// </summary>
            NEW1_007a, 

            /// <summary>
            /// The na x 12_02 h.
            /// </summary>
            NAX12_02H, 

            /// <summary>
            /// The e x 1_345 t.
            /// </summary>
            EX1_345t, 

            /// <summary>
            /// The f p 1_007 t.
            /// </summary>
            FP1_007t, 

            /// <summary>
            /// The e x 1_025.
            /// </summary>
            EX1_025, 

            /// <summary>
            /// The e x 1_396.
            /// </summary>
            EX1_396, 

            /// <summary>
            /// The na x 9_03.
            /// </summary>
            NAX9_03, 

            /// <summary>
            /// The ne w 1_017.
            /// </summary>
            NEW1_017, 

            /// <summary>
            /// The ne w 1_008 a.
            /// </summary>
            NEW1_008a, 

            /// <summary>
            /// The e x 1_587 e.
            /// </summary>
            EX1_587e, 

            /// <summary>
            /// The e x 1_533.
            /// </summary>
            EX1_533, 

            /// <summary>
            /// The e x 1_522.
            /// </summary>
            EX1_522, 

            /// <summary>
            /// The na x 11_04.
            /// </summary>
            NAX11_04, 

            /// <summary>
            /// The ne w 1_026.
            /// </summary>
            NEW1_026, 

            /// <summary>
            /// The e x 1_398.
            /// </summary>
            EX1_398, 

            /// <summary>
            /// The na x 4_04.
            /// </summary>
            NAX4_04, 

            /// <summary>
            /// The e x 1_007.
            /// </summary>
            EX1_007, 

            /// <summary>
            /// The c s 1_112.
            /// </summary>
            CS1_112, 

            /// <summary>
            /// The cre d_17.
            /// </summary>
            CRED_17, 

            /// <summary>
            /// The ne w 1_036.
            /// </summary>
            NEW1_036, 

            /// <summary>
            /// The na x 3_03.
            /// </summary>
            NAX3_03, 

            /// <summary>
            /// The e x 1_355 e.
            /// </summary>
            EX1_355e, 

            /// <summary>
            /// The e x 1_258.
            /// </summary>
            EX1_258, 

            /// <summary>
            /// The her o_01.
            /// </summary>
            HERO_01, 

            /// <summary>
            /// The xx x_009.
            /// </summary>
            XXX_009, 

            /// <summary>
            /// The na x 6_01 h.
            /// </summary>
            NAX6_01H, 

            /// <summary>
            /// The na x 12_04 e.
            /// </summary>
            NAX12_04e, 

            /// <summary>
            /// The c s 2_087.
            /// </summary>
            CS2_087, 

            /// <summary>
            /// The drea m_05.
            /// </summary>
            DREAM_05, 

            /// <summary>
            /// The ne w 1_036 e.
            /// </summary>
            NEW1_036e, 

            /// <summary>
            /// The c s 2_092.
            /// </summary>
            CS2_092, 

            /// <summary>
            /// The c s 2_022.
            /// </summary>
            CS2_022, 

            /// <summary>
            /// The e x 1_046.
            /// </summary>
            EX1_046, 

            /// <summary>
            /// The xx x_005.
            /// </summary>
            XXX_005, 

            /// <summary>
            /// The pr o_001 b.
            /// </summary>
            PRO_001b, 

            /// <summary>
            /// The xx x_022.
            /// </summary>
            XXX_022, 

            /// <summary>
            /// The pr o_001 a.
            /// </summary>
            PRO_001a, 

            /// <summary>
            /// The na x 6_04.
            /// </summary>
            NAX6_04, 

            /// <summary>
            /// The na x 7_05.
            /// </summary>
            NAX7_05, 

            /// <summary>
            /// The c s 2_103.
            /// </summary>
            CS2_103, 

            /// <summary>
            /// The ne w 1_041.
            /// </summary>
            NEW1_041, 

            /// <summary>
            /// The e x 1_360.
            /// </summary>
            EX1_360, 

            /// <summary>
            /// The f p 1_023.
            /// </summary>
            FP1_023, 

            /// <summary>
            /// The ne w 1_038.
            /// </summary>
            NEW1_038, 

            /// <summary>
            /// The c s 2_009.
            /// </summary>
            CS2_009, 

            /// <summary>
            /// The na x 10_01 h.
            /// </summary>
            NAX10_01H, 

            /// <summary>
            /// The e x 1_010.
            /// </summary>
            EX1_010, 

            /// <summary>
            /// The c s 2_024.
            /// </summary>
            CS2_024, 

            /// <summary>
            /// The na x 9_05.
            /// </summary>
            NAX9_05, 

            /// <summary>
            /// The e x 1_565.
            /// </summary>
            EX1_565, 

            /// <summary>
            /// The c s 2_076.
            /// </summary>
            CS2_076, 

            /// <summary>
            /// The f p 1_004.
            /// </summary>
            FP1_004, 

            /// <summary>
            /// The c s 2_046 e.
            /// </summary>
            CS2_046e, 

            /// <summary>
            /// The c s 2_162.
            /// </summary>
            CS2_162, 

            /// <summary>
            /// The e x 1_110 t.
            /// </summary>
            EX1_110t, 

            /// <summary>
            /// The c s 2_104 e.
            /// </summary>
            CS2_104e, 

            /// <summary>
            /// The c s 2_181.
            /// </summary>
            CS2_181, 

            /// <summary>
            /// The e x 1_309.
            /// </summary>
            EX1_309, 

            /// <summary>
            /// The e x 1_354.
            /// </summary>
            EX1_354, 

            /// <summary>
            /// The na x 10_02 h.
            /// </summary>
            NAX10_02H, 

            /// <summary>
            /// The na x 7_04 h.
            /// </summary>
            NAX7_04H, 

            /// <summary>
            /// The t u 4 f_001.
            /// </summary>
            TU4f_001, 

            /// <summary>
            /// The xx x_018.
            /// </summary>
            XXX_018, 

            /// <summary>
            /// The e x 1_023.
            /// </summary>
            EX1_023, 

            /// <summary>
            /// The xx x_048.
            /// </summary>
            XXX_048, 

            /// <summary>
            /// The xx x_049.
            /// </summary>
            XXX_049, 

            /// <summary>
            /// The ne w 1_034.
            /// </summary>
            NEW1_034, 

            /// <summary>
            /// The c s 2_003.
            /// </summary>
            CS2_003, 

            /// <summary>
            /// The her o_06.
            /// </summary>
            HERO_06, 

            /// <summary>
            /// The c s 2_201.
            /// </summary>
            CS2_201, 

            /// <summary>
            /// The e x 1_508.
            /// </summary>
            EX1_508, 

            /// <summary>
            /// The e x 1_259.
            /// </summary>
            EX1_259, 

            /// <summary>
            /// The e x 1_341.
            /// </summary>
            EX1_341, 

            /// <summary>
            /// The drea m_05 e.
            /// </summary>
            DREAM_05e, 

            /// <summary>
            /// The cre d_09.
            /// </summary>
            CRED_09, 

            /// <summary>
            /// The e x 1_103.
            /// </summary>
            EX1_103, 

            /// <summary>
            /// The f p 1_021.
            /// </summary>
            FP1_021, 

            /// <summary>
            /// The e x 1_411.
            /// </summary>
            EX1_411, 

            /// <summary>
            /// The na x 1_04.
            /// </summary>
            NAX1_04, 

            /// <summary>
            /// The c s 2_053.
            /// </summary>
            CS2_053, 

            /// <summary>
            /// The c s 2_182.
            /// </summary>
            CS2_182, 

            /// <summary>
            /// The c s 2_008.
            /// </summary>
            CS2_008, 

            /// <summary>
            /// The c s 2_233.
            /// </summary>
            CS2_233, 

            /// <summary>
            /// The e x 1_626.
            /// </summary>
            EX1_626, 

            /// <summary>
            /// The e x 1_059.
            /// </summary>
            EX1_059, 

            /// <summary>
            /// The e x 1_334.
            /// </summary>
            EX1_334, 

            /// <summary>
            /// The e x 1_619.
            /// </summary>
            EX1_619, 

            /// <summary>
            /// The ne w 1_032.
            /// </summary>
            NEW1_032, 

            /// <summary>
            /// The e x 1_158 t.
            /// </summary>
            EX1_158t, 

            /// <summary>
            /// The e x 1_006.
            /// </summary>
            EX1_006, 

            /// <summary>
            /// The ne w 1_031.
            /// </summary>
            NEW1_031, 

            /// <summary>
            /// The na x 10_03.
            /// </summary>
            NAX10_03, 

            /// <summary>
            /// The drea m_04.
            /// </summary>
            DREAM_04, 

            /// <summary>
            /// The na x 1 h_01.
            /// </summary>
            NAX1h_01, 

            /// <summary>
            /// The c s 2_022 e.
            /// </summary>
            CS2_022e, 

            /// <summary>
            /// The e x 1_611 e.
            /// </summary>
            EX1_611e, 

            /// <summary>
            /// The e x 1_004.
            /// </summary>
            EX1_004, 

            /// <summary>
            /// The e x 1_014 te.
            /// </summary>
            EX1_014te, 

            /// <summary>
            /// The f p 1_005 e.
            /// </summary>
            FP1_005e, 

            /// <summary>
            /// The na x 12_03 e.
            /// </summary>
            NAX12_03e, 

            /// <summary>
            /// The e x 1_095.
            /// </summary>
            EX1_095, 

            /// <summary>
            /// The ne w 1_007.
            /// </summary>
            NEW1_007, 

            /// <summary>
            /// The e x 1_275.
            /// </summary>
            EX1_275, 

            /// <summary>
            /// The e x 1_245.
            /// </summary>
            EX1_245, 

            /// <summary>
            /// The e x 1_383.
            /// </summary>
            EX1_383, 

            /// <summary>
            /// The f p 1_016.
            /// </summary>
            FP1_016, 

            /// <summary>
            /// The e x 1_016 t.
            /// </summary>
            EX1_016t, 

            /// <summary>
            /// The c s 2_125.
            /// </summary>
            CS2_125, 

            /// <summary>
            /// The e x 1_137.
            /// </summary>
            EX1_137, 

            /// <summary>
            /// The e x 1_178 ae.
            /// </summary>
            EX1_178ae, 

            /// <summary>
            /// The d s 1_185.
            /// </summary>
            DS1_185, 

            /// <summary>
            /// The f p 1_010.
            /// </summary>
            FP1_010, 

            /// <summary>
            /// The e x 1_598.
            /// </summary>
            EX1_598, 

            /// <summary>
            /// The na x 9_07.
            /// </summary>
            NAX9_07, 

            /// <summary>
            /// The e x 1_304.
            /// </summary>
            EX1_304, 

            /// <summary>
            /// The e x 1_302.
            /// </summary>
            EX1_302, 

            /// <summary>
            /// The xx x_017.
            /// </summary>
            XXX_017, 

            /// <summary>
            /// The c s 2_011 o.
            /// </summary>
            CS2_011o, 

            /// <summary>
            /// The e x 1_614 t.
            /// </summary>
            EX1_614t, 

            /// <summary>
            /// The t u 4 a_006.
            /// </summary>
            TU4a_006, 

            /// <summary>
            /// The mekka 3 e.
            /// </summary>
            Mekka3e, 

            /// <summary>
            /// The c s 2_108.
            /// </summary>
            CS2_108, 

            /// <summary>
            /// The c s 2_046.
            /// </summary>
            CS2_046, 

            /// <summary>
            /// The e x 1_014 t.
            /// </summary>
            EX1_014t, 

            /// <summary>
            /// The ne w 1_005.
            /// </summary>
            NEW1_005, 

            /// <summary>
            /// The e x 1_062.
            /// </summary>
            EX1_062, 

            /// <summary>
            /// The e x 1_366 e.
            /// </summary>
            EX1_366e, 

            /// <summary>
            /// The mekka 1.
            /// </summary>
            Mekka1, 

            /// <summary>
            /// The xx x_007.
            /// </summary>
            XXX_007, 

            /// <summary>
            /// The tt_010 a.
            /// </summary>
            tt_010a, 

            /// <summary>
            /// The c s 2_017 o.
            /// </summary>
            CS2_017o, 

            /// <summary>
            /// The c s 2_072.
            /// </summary>
            CS2_072, 

            /// <summary>
            /// The e x 1_tk 28.
            /// </summary>
            EX1_tk28, 

            /// <summary>
            /// The e x 1_604 o.
            /// </summary>
            EX1_604o, 

            /// <summary>
            /// The f p 1_014.
            /// </summary>
            FP1_014, 

            /// <summary>
            /// The e x 1_084 e.
            /// </summary>
            EX1_084e, 

            /// <summary>
            /// The na x 3_01 h.
            /// </summary>
            NAX3_01H, 

            /// <summary>
            /// The na x 2_01.
            /// </summary>
            NAX2_01, 

            /// <summary>
            /// The e x 1_409 t.
            /// </summary>
            EX1_409t, 

            /// <summary>
            /// The cre d_07.
            /// </summary>
            CRED_07, 

            /// <summary>
            /// The na x 3_02 h.
            /// </summary>
            NAX3_02H, 

            /// <summary>
            /// The t u 4 e_002.
            /// </summary>
            TU4e_002, 

            /// <summary>
            /// The e x 1_507.
            /// </summary>
            EX1_507, 

            /// <summary>
            /// The e x 1_144.
            /// </summary>
            EX1_144, 

            /// <summary>
            /// The c s 2_038.
            /// </summary>
            CS2_038, 

            /// <summary>
            /// The e x 1_093.
            /// </summary>
            EX1_093, 

            /// <summary>
            /// The c s 2_080.
            /// </summary>
            CS2_080, 

            /// <summary>
            /// The c s 1_129 e.
            /// </summary>
            CS1_129e, 

            /// <summary>
            /// The xx x_013.
            /// </summary>
            XXX_013, 

            /// <summary>
            /// The e x 1_005.
            /// </summary>
            EX1_005, 

            /// <summary>
            /// The e x 1_382.
            /// </summary>
            EX1_382, 

            /// <summary>
            /// The na x 13_02 e.
            /// </summary>
            NAX13_02e, 

            /// <summary>
            /// The f p 1_020 e.
            /// </summary>
            FP1_020e, 

            /// <summary>
            /// The e x 1_603 e.
            /// </summary>
            EX1_603e, 

            /// <summary>
            /// The c s 2_028.
            /// </summary>
            CS2_028, 

            /// <summary>
            /// The t u 4 f_002.
            /// </summary>
            TU4f_002, 

            /// <summary>
            /// The e x 1_538.
            /// </summary>
            EX1_538, 

            /// <summary>
            /// The gam e_003 e.
            /// </summary>
            GAME_003e, 

            /// <summary>
            /// The drea m_02.
            /// </summary>
            DREAM_02, 

            /// <summary>
            /// The e x 1_581.
            /// </summary>
            EX1_581, 

            /// <summary>
            /// The na x 15_01 h.
            /// </summary>
            NAX15_01H, 

            /// <summary>
            /// The e x 1_131 t.
            /// </summary>
            EX1_131t, 

            /// <summary>
            /// The c s 2_147.
            /// </summary>
            CS2_147, 

            /// <summary>
            /// The c s 1_113.
            /// </summary>
            CS1_113, 

            /// <summary>
            /// The c s 2_161.
            /// </summary>
            CS2_161, 

            /// <summary>
            /// The c s 2_031.
            /// </summary>
            CS2_031, 

            /// <summary>
            /// The e x 1_166 b.
            /// </summary>
            EX1_166b, 

            /// <summary>
            /// The e x 1_066.
            /// </summary>
            EX1_066, 

            /// <summary>
            /// The t u 4 c_007.
            /// </summary>
            TU4c_007, 

            /// <summary>
            /// The e x 1_355.
            /// </summary>
            EX1_355, 

            /// <summary>
            /// The e x 1_507 e.
            /// </summary>
            EX1_507e, 

            /// <summary>
            /// The e x 1_534.
            /// </summary>
            EX1_534, 

            /// <summary>
            /// The e x 1_162.
            /// </summary>
            EX1_162, 

            /// <summary>
            /// The t u 4 a_004.
            /// </summary>
            TU4a_004, 

            /// <summary>
            /// The e x 1_363.
            /// </summary>
            EX1_363, 

            /// <summary>
            /// The e x 1_164 a.
            /// </summary>
            EX1_164a, 

            /// <summary>
            /// The c s 2_188.
            /// </summary>
            CS2_188, 

            /// <summary>
            /// The e x 1_016.
            /// </summary>
            EX1_016, 

            /// <summary>
            /// The na x 6_03 t.
            /// </summary>
            NAX6_03t, 

            /// <summary>
            /// The e x 1_tk 31.
            /// </summary>
            EX1_tk31, 

            /// <summary>
            /// The e x 1_603.
            /// </summary>
            EX1_603, 

            /// <summary>
            /// The e x 1_238.
            /// </summary>
            EX1_238, 

            /// <summary>
            /// The e x 1_166.
            /// </summary>
            EX1_166, 

            /// <summary>
            /// The d s 1 h_292.
            /// </summary>
            DS1h_292, 

            /// <summary>
            /// The d s 1_183.
            /// </summary>
            DS1_183, 

            /// <summary>
            /// The na x 15_03 n.
            /// </summary>
            NAX15_03n, 

            /// <summary>
            /// The na x 8_02 h.
            /// </summary>
            NAX8_02H, 

            /// <summary>
            /// The na x 7_01 h.
            /// </summary>
            NAX7_01H, 

            /// <summary>
            /// The na x 9_02 h.
            /// </summary>
            NAX9_02H, 

            /// <summary>
            /// The cre d_11.
            /// </summary>
            CRED_11, 

            /// <summary>
            /// The xx x_019.
            /// </summary>
            XXX_019, 

            /// <summary>
            /// The e x 1_076.
            /// </summary>
            EX1_076, 

            /// <summary>
            /// The e x 1_048.
            /// </summary>
            EX1_048, 

            /// <summary>
            /// The c s 2_038 e.
            /// </summary>
            CS2_038e, 

            /// <summary>
            /// The f p 1_026.
            /// </summary>
            FP1_026, 

            /// <summary>
            /// The c s 2_074.
            /// </summary>
            CS2_074, 

            /// <summary>
            /// The f p 1_027.
            /// </summary>
            FP1_027, 

            /// <summary>
            /// The e x 1_323 w.
            /// </summary>
            EX1_323w, 

            /// <summary>
            /// The e x 1_129.
            /// </summary>
            EX1_129, 

            /// <summary>
            /// The ne w 1_024 o.
            /// </summary>
            NEW1_024o, 

            /// <summary>
            /// The na x 11_02.
            /// </summary>
            NAX11_02, 

            /// <summary>
            /// The e x 1_405.
            /// </summary>
            EX1_405, 

            /// <summary>
            /// The e x 1_317.
            /// </summary>
            EX1_317, 

            /// <summary>
            /// The e x 1_606.
            /// </summary>
            EX1_606, 

            /// <summary>
            /// The e x 1_590 e.
            /// </summary>
            EX1_590e, 

            /// <summary>
            /// The xx x_044.
            /// </summary>
            XXX_044, 

            /// <summary>
            /// The c s 2_074 e.
            /// </summary>
            CS2_074e, 

            /// <summary>
            /// The t u 4 a_005.
            /// </summary>
            TU4a_005, 

            /// <summary>
            /// The f p 1_006.
            /// </summary>
            FP1_006, 

            /// <summary>
            /// The e x 1_258 e.
            /// </summary>
            EX1_258e, 

            /// <summary>
            /// The t u 4 f_004 o.
            /// </summary>
            TU4f_004o, 

            /// <summary>
            /// The ne w 1_008.
            /// </summary>
            NEW1_008, 

            /// <summary>
            /// The c s 2_119.
            /// </summary>
            CS2_119, 

            /// <summary>
            /// The ne w 1_017 e.
            /// </summary>
            NEW1_017e, 

            /// <summary>
            /// The e x 1_334 e.
            /// </summary>
            EX1_334e, 

            /// <summary>
            /// The t u 4 e_001.
            /// </summary>
            TU4e_001, 

            /// <summary>
            /// The c s 2_121.
            /// </summary>
            CS2_121, 

            /// <summary>
            /// The c s 1 h_001.
            /// </summary>
            CS1h_001, 

            /// <summary>
            /// The e x 1_tk 34.
            /// </summary>
            EX1_tk34, 

            /// <summary>
            /// The ne w 1_020.
            /// </summary>
            NEW1_020, 

            /// <summary>
            /// The c s 2_196.
            /// </summary>
            CS2_196, 

            /// <summary>
            /// The e x 1_312.
            /// </summary>
            EX1_312, 

            /// <summary>
            /// The na x 1_01.
            /// </summary>
            NAX1_01, 

            /// <summary>
            /// The f p 1_022.
            /// </summary>
            FP1_022, 

            /// <summary>
            /// The e x 1_160 b.
            /// </summary>
            EX1_160b, 

            /// <summary>
            /// The e x 1_563.
            /// </summary>
            EX1_563, 

            /// <summary>
            /// The xx x_039.
            /// </summary>
            XXX_039, 

            /// <summary>
            /// The f p 1_031.
            /// </summary>
            FP1_031, 

            /// <summary>
            /// The c s 2_087 e.
            /// </summary>
            CS2_087e, 

            /// <summary>
            /// The e x 1_613 e.
            /// </summary>
            EX1_613e, 

            /// <summary>
            /// The na x 9_02.
            /// </summary>
            NAX9_02, 

            /// <summary>
            /// The ne w 1_029.
            /// </summary>
            NEW1_029, 

            /// <summary>
            /// The c s 1_129.
            /// </summary>
            CS1_129, 

            /// <summary>
            /// The her o_03.
            /// </summary>
            HERO_03, 

            /// <summary>
            /// The mekka 4 t.
            /// </summary>
            Mekka4t, 

            /// <summary>
            /// The e x 1_158.
            /// </summary>
            EX1_158, 

            /// <summary>
            /// The xx x_010.
            /// </summary>
            XXX_010, 

            /// <summary>
            /// The ne w 1_025.
            /// </summary>
            NEW1_025, 

            /// <summary>
            /// The f p 1_012 t.
            /// </summary>
            FP1_012t, 

            /// <summary>
            /// The e x 1_083.
            /// </summary>
            EX1_083, 

            /// <summary>
            /// The e x 1_295.
            /// </summary>
            EX1_295, 

            /// <summary>
            /// The e x 1_407.
            /// </summary>
            EX1_407, 

            /// <summary>
            /// The ne w 1_004.
            /// </summary>
            NEW1_004, 

            /// <summary>
            /// The f p 1_019.
            /// </summary>
            FP1_019, 

            /// <summary>
            /// The pr o_001 at.
            /// </summary>
            PRO_001at, 

            /// <summary>
            /// The na x 13_03 e.
            /// </summary>
            NAX13_03e, 

            /// <summary>
            /// The e x 1_625 t.
            /// </summary>
            EX1_625t, 

            /// <summary>
            /// The e x 1_014.
            /// </summary>
            EX1_014, 

            /// <summary>
            /// The cre d_04.
            /// </summary>
            CRED_04, 

            /// <summary>
            /// The na x 12_01 h.
            /// </summary>
            NAX12_01H, 

            /// <summary>
            /// The c s 2_097.
            /// </summary>
            CS2_097, 

            /// <summary>
            /// The e x 1_558.
            /// </summary>
            EX1_558, 

            /// <summary>
            /// The xx x_047.
            /// </summary>
            XXX_047, 

            /// <summary>
            /// The e x 1_tk 29.
            /// </summary>
            EX1_tk29, 

            /// <summary>
            /// The c s 2_186.
            /// </summary>
            CS2_186, 

            /// <summary>
            /// The e x 1_084.
            /// </summary>
            EX1_084, 

            /// <summary>
            /// The ne w 1_012.
            /// </summary>
            NEW1_012, 

            /// <summary>
            /// The f p 1_014 t.
            /// </summary>
            FP1_014t, 

            /// <summary>
            /// The na x 1_03.
            /// </summary>
            NAX1_03, 

            /// <summary>
            /// The e x 1_623 e.
            /// </summary>
            EX1_623e, 

            /// <summary>
            /// The e x 1_578.
            /// </summary>
            EX1_578, 

            /// <summary>
            /// The c s 2_073 e 2.
            /// </summary>
            CS2_073e2, 

            /// <summary>
            /// The c s 2_221.
            /// </summary>
            CS2_221, 

            /// <summary>
            /// The e x 1_019.
            /// </summary>
            EX1_019, 

            /// <summary>
            /// The na x 15_04 a.
            /// </summary>
            NAX15_04a, 

            /// <summary>
            /// The f p 1_019 t.
            /// </summary>
            FP1_019t, 

            /// <summary>
            /// The e x 1_132.
            /// </summary>
            EX1_132, 

            /// <summary>
            /// The e x 1_284.
            /// </summary>
            EX1_284, 

            /// <summary>
            /// The e x 1_105.
            /// </summary>
            EX1_105, 

            /// <summary>
            /// The ne w 1_011.
            /// </summary>
            NEW1_011, 

            /// <summary>
            /// The na x 9_07 e.
            /// </summary>
            NAX9_07e, 

            /// <summary>
            /// The e x 1_017.
            /// </summary>
            EX1_017, 

            /// <summary>
            /// The e x 1_249.
            /// </summary>
            EX1_249, 

            /// <summary>
            /// The e x 1_162 o.
            /// </summary>
            EX1_162o, 

            /// <summary>
            /// The f p 1_002 t.
            /// </summary>
            FP1_002t, 

            /// <summary>
            /// The na x 3_02.
            /// </summary>
            NAX3_02, 

            /// <summary>
            /// The e x 1_313.
            /// </summary>
            EX1_313, 

            /// <summary>
            /// The e x 1_549 o.
            /// </summary>
            EX1_549o, 

            /// <summary>
            /// The e x 1_091 o.
            /// </summary>
            EX1_091o, 

            /// <summary>
            /// The c s 2_084 e.
            /// </summary>
            CS2_084e, 

            /// <summary>
            /// The e x 1_155 b.
            /// </summary>
            EX1_155b, 

            /// <summary>
            /// The na x 11_01.
            /// </summary>
            NAX11_01, 

            /// <summary>
            /// The ne w 1_033.
            /// </summary>
            NEW1_033, 

            /// <summary>
            /// The c s 2_106.
            /// </summary>
            CS2_106, 

            /// <summary>
            /// The xx x_002.
            /// </summary>
            XXX_002, 

            /// <summary>
            /// The f p 1_018.
            /// </summary>
            FP1_018, 

            /// <summary>
            /// The ne w 1_036 e 2.
            /// </summary>
            NEW1_036e2, 

            /// <summary>
            /// The xx x_004.
            /// </summary>
            XXX_004, 

            /// <summary>
            /// The na x 11_02 h.
            /// </summary>
            NAX11_02H, 

            /// <summary>
            /// The c s 2_122 e.
            /// </summary>
            CS2_122e, 

            /// <summary>
            /// The d s 1_233.
            /// </summary>
            DS1_233, 

            /// <summary>
            /// The d s 1_175.
            /// </summary>
            DS1_175, 

            /// <summary>
            /// The ne w 1_024.
            /// </summary>
            NEW1_024, 

            /// <summary>
            /// The c s 2_189.
            /// </summary>
            CS2_189, 

            /// <summary>
            /// The cre d_10.
            /// </summary>
            CRED_10, 

            /// <summary>
            /// The ne w 1_037.
            /// </summary>
            NEW1_037, 

            /// <summary>
            /// The e x 1_414.
            /// </summary>
            EX1_414, 

            /// <summary>
            /// The e x 1_538 t.
            /// </summary>
            EX1_538t, 

            /// <summary>
            /// The f p 1_030 e.
            /// </summary>
            FP1_030e, 

            /// <summary>
            /// The e x 1_586.
            /// </summary>
            EX1_586, 

            /// <summary>
            /// The e x 1_310.
            /// </summary>
            EX1_310, 

            /// <summary>
            /// The ne w 1_010.
            /// </summary>
            NEW1_010, 

            /// <summary>
            /// The c s 2_103 e.
            /// </summary>
            CS2_103e, 

            /// <summary>
            /// The e x 1_080 o.
            /// </summary>
            EX1_080o, 

            /// <summary>
            /// The c s 2_005 o.
            /// </summary>
            CS2_005o, 

            /// <summary>
            /// The e x 1_363 e 2.
            /// </summary>
            EX1_363e2, 

            /// <summary>
            /// The e x 1_534 t.
            /// </summary>
            EX1_534t, 

            /// <summary>
            /// The f p 1_028.
            /// </summary>
            FP1_028, 

            /// <summary>
            /// The e x 1_604.
            /// </summary>
            EX1_604, 

            /// <summary>
            /// The e x 1_160.
            /// </summary>
            EX1_160, 

            /// <summary>
            /// The e x 1_165 t 1.
            /// </summary>
            EX1_165t1, 

            /// <summary>
            /// The c s 2_062.
            /// </summary>
            CS2_062, 

            /// <summary>
            /// The c s 2_155.
            /// </summary>
            CS2_155, 

            /// <summary>
            /// The c s 2_213.
            /// </summary>
            CS2_213, 

            /// <summary>
            /// The t u 4 f_007.
            /// </summary>
            TU4f_007, 

            /// <summary>
            /// The gam e_004.
            /// </summary>
            GAME_004, 

            /// <summary>
            /// The na x 5_01.
            /// </summary>
            NAX5_01, 

            /// <summary>
            /// The xx x_020.
            /// </summary>
            XXX_020, 

            /// <summary>
            /// The na x 15_02 h.
            /// </summary>
            NAX15_02H, 

            /// <summary>
            /// The c s 2_004.
            /// </summary>
            CS2_004, 

            /// <summary>
            /// The na x 2_03 h.
            /// </summary>
            NAX2_03H, 

            /// <summary>
            /// The e x 1_561 e.
            /// </summary>
            EX1_561e, 

            /// <summary>
            /// The c s 2_023.
            /// </summary>
            CS2_023, 

            /// <summary>
            /// The e x 1_164.
            /// </summary>
            EX1_164, 

            /// <summary>
            /// The e x 1_009.
            /// </summary>
            EX1_009, 

            /// <summary>
            /// The na x 6_01.
            /// </summary>
            NAX6_01, 

            /// <summary>
            /// The f p 1_007.
            /// </summary>
            FP1_007, 

            /// <summary>
            /// The na x 1 h_04.
            /// </summary>
            NAX1h_04, 

            /// <summary>
            /// The na x 2_05 h.
            /// </summary>
            NAX2_05H, 

            /// <summary>
            /// The na x 10_02.
            /// </summary>
            NAX10_02, 

            /// <summary>
            /// The e x 1_345.
            /// </summary>
            EX1_345, 

            /// <summary>
            /// The e x 1_116.
            /// </summary>
            EX1_116, 

            /// <summary>
            /// The e x 1_399.
            /// </summary>
            EX1_399, 

            /// <summary>
            /// The e x 1_587.
            /// </summary>
            EX1_587, 

            /// <summary>
            /// The xx x_026.
            /// </summary>
            XXX_026, 

            /// <summary>
            /// The e x 1_571.
            /// </summary>
            EX1_571, 

            /// <summary>
            /// The e x 1_335.
            /// </summary>
            EX1_335, 

            /// <summary>
            /// The xx x_050.
            /// </summary>
            XXX_050, 

            /// <summary>
            /// The t u 4 e_004.
            /// </summary>
            TU4e_004, 

            /// <summary>
            /// The her o_08.
            /// </summary>
            HERO_08, 

            /// <summary>
            /// The e x 1_166 a.
            /// </summary>
            EX1_166a, 

            /// <summary>
            /// The na x 2_03.
            /// </summary>
            NAX2_03, 

            /// <summary>
            /// The e x 1_finkle.
            /// </summary>
            EX1_finkle, 

            /// <summary>
            /// The na x 4_03 h.
            /// </summary>
            NAX4_03H, 

            /// <summary>
            /// The e x 1_164 b.
            /// </summary>
            EX1_164b, 

            /// <summary>
            /// The e x 1_283.
            /// </summary>
            EX1_283, 

            /// <summary>
            /// The e x 1_339.
            /// </summary>
            EX1_339, 

            /// <summary>
            /// The cre d_13.
            /// </summary>
            CRED_13, 

            /// <summary>
            /// The e x 1_178 be.
            /// </summary>
            EX1_178be, 

            /// <summary>
            /// The e x 1_531.
            /// </summary>
            EX1_531, 

            /// <summary>
            /// The e x 1_134.
            /// </summary>
            EX1_134, 

            /// <summary>
            /// The e x 1_350.
            /// </summary>
            EX1_350, 

            /// <summary>
            /// The e x 1_308.
            /// </summary>
            EX1_308, 

            /// <summary>
            /// The c s 2_197.
            /// </summary>
            CS2_197, 

            /// <summary>
            /// The skele 21.
            /// </summary>
            skele21, 

            /// <summary>
            /// The c s 2_222 o.
            /// </summary>
            CS2_222o, 

            /// <summary>
            /// The xx x_015.
            /// </summary>
            XXX_015, 

            /// <summary>
            /// The f p 1_013.
            /// </summary>
            FP1_013, 

            /// <summary>
            /// The ne w 1_006.
            /// </summary>
            NEW1_006, 

            /// <summary>
            /// The e x 1_399 e.
            /// </summary>
            EX1_399e, 

            /// <summary>
            /// The e x 1_509.
            /// </summary>
            EX1_509, 

            /// <summary>
            /// The e x 1_612.
            /// </summary>
            EX1_612, 

            /// <summary>
            /// The na x 8_05 t.
            /// </summary>
            NAX8_05t, 

            /// <summary>
            /// The na x 9_05 h.
            /// </summary>
            NAX9_05H, 

            /// <summary>
            /// The e x 1_021.
            /// </summary>
            EX1_021, 

            /// <summary>
            /// The c s 2_041 e.
            /// </summary>
            CS2_041e, 

            /// <summary>
            /// The c s 2_226.
            /// </summary>
            CS2_226, 

            /// <summary>
            /// The e x 1_608.
            /// </summary>
            EX1_608, 

            /// <summary>
            /// The na x 13_05 h.
            /// </summary>
            NAX13_05H, 

            /// <summary>
            /// The na x 13_04 h.
            /// </summary>
            NAX13_04H, 

            /// <summary>
            /// The t u 4 c_008.
            /// </summary>
            TU4c_008, 

            /// <summary>
            /// The e x 1_624.
            /// </summary>
            EX1_624, 

            /// <summary>
            /// The e x 1_616.
            /// </summary>
            EX1_616, 

            /// <summary>
            /// The e x 1_008.
            /// </summary>
            EX1_008, 

            /// <summary>
            /// The placeholder card.
            /// </summary>
            PlaceholderCard, 

            /// <summary>
            /// The xx x_016.
            /// </summary>
            XXX_016, 

            /// <summary>
            /// The e x 1_045.
            /// </summary>
            EX1_045, 

            /// <summary>
            /// The e x 1_015.
            /// </summary>
            EX1_015, 

            /// <summary>
            /// The gam e_003.
            /// </summary>
            GAME_003, 

            /// <summary>
            /// The c s 2_171.
            /// </summary>
            CS2_171, 

            /// <summary>
            /// The c s 2_041.
            /// </summary>
            CS2_041, 

            /// <summary>
            /// The e x 1_128.
            /// </summary>
            EX1_128, 

            /// <summary>
            /// The c s 2_112.
            /// </summary>
            CS2_112, 

            /// <summary>
            /// The her o_07.
            /// </summary>
            HERO_07, 

            /// <summary>
            /// The e x 1_412.
            /// </summary>
            EX1_412, 

            /// <summary>
            /// The e x 1_612 o.
            /// </summary>
            EX1_612o, 

            /// <summary>
            /// The c s 2_117.
            /// </summary>
            CS2_117, 

            /// <summary>
            /// The xx x_009 e.
            /// </summary>
            XXX_009e, 

            /// <summary>
            /// The e x 1_562.
            /// </summary>
            EX1_562, 

            /// <summary>
            /// The e x 1_055.
            /// </summary>
            EX1_055, 

            /// <summary>
            /// The na x 9_06.
            /// </summary>
            NAX9_06, 

            /// <summary>
            /// The t u 4 e_007.
            /// </summary>
            TU4e_007, 

            /// <summary>
            /// The f p 1_012.
            /// </summary>
            FP1_012, 

            /// <summary>
            /// The e x 1_317 t.
            /// </summary>
            EX1_317t, 

            /// <summary>
            /// The e x 1_004 e.
            /// </summary>
            EX1_004e, 

            /// <summary>
            /// The e x 1_278.
            /// </summary>
            EX1_278, 

            /// <summary>
            /// The c s 2_tk 1.
            /// </summary>
            CS2_tk1, 

            /// <summary>
            /// The e x 1_590.
            /// </summary>
            EX1_590, 

            /// <summary>
            /// The c s 1_130.
            /// </summary>
            CS1_130, 

            /// <summary>
            /// The ne w 1_008 b.
            /// </summary>
            NEW1_008b, 

            /// <summary>
            /// The e x 1_365.
            /// </summary>
            EX1_365, 

            /// <summary>
            /// The c s 2_141.
            /// </summary>
            CS2_141, 

            /// <summary>
            /// The pr o_001.
            /// </summary>
            PRO_001, 

            /// <summary>
            /// The na x 8_04 t.
            /// </summary>
            NAX8_04t, 

            /// <summary>
            /// The c s 2_173.
            /// </summary>
            CS2_173, 

            /// <summary>
            /// The c s 2_017.
            /// </summary>
            CS2_017, 

            /// <summary>
            /// The cre d_16.
            /// </summary>
            CRED_16, 

            /// <summary>
            /// The e x 1_392.
            /// </summary>
            EX1_392, 

            /// <summary>
            /// The e x 1_593.
            /// </summary>
            EX1_593, 

            /// <summary>
            /// The f p 1_023 e.
            /// </summary>
            FP1_023e, 

            /// <summary>
            /// The na x 1_05.
            /// </summary>
            NAX1_05, 

            /// <summary>
            /// The t u 4 d_002.
            /// </summary>
            TU4d_002, 

            /// <summary>
            /// The cre d_15.
            /// </summary>
            CRED_15, 

            /// <summary>
            /// The e x 1_049.
            /// </summary>
            EX1_049, 

            /// <summary>
            /// The e x 1_002.
            /// </summary>
            EX1_002, 

            /// <summary>
            /// The t u 4 f_005.
            /// </summary>
            TU4f_005, 

            /// <summary>
            /// The ne w 1_029 t.
            /// </summary>
            NEW1_029t, 

            /// <summary>
            /// The t u 4 a_001.
            /// </summary>
            TU4a_001, 

            /// <summary>
            /// The c s 2_056.
            /// </summary>
            CS2_056, 

            /// <summary>
            /// The e x 1_596.
            /// </summary>
            EX1_596, 

            /// <summary>
            /// The e x 1_136.
            /// </summary>
            EX1_136, 

            /// <summary>
            /// The e x 1_323.
            /// </summary>
            EX1_323, 

            /// <summary>
            /// The c s 2_073.
            /// </summary>
            CS2_073, 

            /// <summary>
            /// The e x 1_246 e.
            /// </summary>
            EX1_246e, 

            /// <summary>
            /// The na x 12_01.
            /// </summary>
            NAX12_01, 

            /// <summary>
            /// The e x 1_244 e.
            /// </summary>
            EX1_244e, 

            /// <summary>
            /// The e x 1_001.
            /// </summary>
            EX1_001, 

            /// <summary>
            /// The e x 1_607 e.
            /// </summary>
            EX1_607e, 

            /// <summary>
            /// The e x 1_044.
            /// </summary>
            EX1_044, 

            /// <summary>
            /// The e x 1_573 ae.
            /// </summary>
            EX1_573ae, 

            /// <summary>
            /// The xx x_025.
            /// </summary>
            XXX_025, 

            /// <summary>
            /// The cre d_06.
            /// </summary>
            CRED_06, 

            /// <summary>
            /// The mekka 4.
            /// </summary>
            Mekka4, 

            /// <summary>
            /// The c s 2_142.
            /// </summary>
            CS2_142, 

            /// <summary>
            /// The t u 4 f_004.
            /// </summary>
            TU4f_004, 

            /// <summary>
            /// The na x 5_02 h.
            /// </summary>
            NAX5_02H, 

            /// <summary>
            /// The e x 1_411 e 2.
            /// </summary>
            EX1_411e2, 

            /// <summary>
            /// The e x 1_573.
            /// </summary>
            EX1_573, 

            /// <summary>
            /// The f p 1_009.
            /// </summary>
            FP1_009, 

            /// <summary>
            /// The c s 2_050.
            /// </summary>
            CS2_050, 

            /// <summary>
            /// The na x 4_03.
            /// </summary>
            NAX4_03, 

            /// <summary>
            /// The c s 2_063 e.
            /// </summary>
            CS2_063e, 

            /// <summary>
            /// The na x 2_05.
            /// </summary>
            NAX2_05, 

            /// <summary>
            /// The e x 1_390.
            /// </summary>
            EX1_390, 

            /// <summary>
            /// The e x 1_610.
            /// </summary>
            EX1_610, 

            /// <summary>
            /// The hexfrog.
            /// </summary>
            hexfrog, 

            /// <summary>
            /// The c s 2_181 e.
            /// </summary>
            CS2_181e, 

            /// <summary>
            /// The na x 6_02.
            /// </summary>
            NAX6_02, 

            /// <summary>
            /// The xx x_027.
            /// </summary>
            XXX_027, 

            /// <summary>
            /// The c s 2_082.
            /// </summary>
            CS2_082, 

            /// <summary>
            /// The ne w 1_040.
            /// </summary>
            NEW1_040, 

            /// <summary>
            /// The drea m_01.
            /// </summary>
            DREAM_01, 

            /// <summary>
            /// The e x 1_595.
            /// </summary>
            EX1_595, 

            /// <summary>
            /// The c s 2_013.
            /// </summary>
            CS2_013, 

            /// <summary>
            /// The c s 2_077.
            /// </summary>
            CS2_077, 

            /// <summary>
            /// The ne w 1_014.
            /// </summary>
            NEW1_014, 

            /// <summary>
            /// The cre d_05.
            /// </summary>
            CRED_05, 

            /// <summary>
            /// The gam e_002.
            /// </summary>
            GAME_002, 

            /// <summary>
            /// The e x 1_165.
            /// </summary>
            EX1_165, 

            /// <summary>
            /// The c s 2_013 t.
            /// </summary>
            CS2_013t, 

            /// <summary>
            /// The na x 4_04 h.
            /// </summary>
            NAX4_04H, 

            /// <summary>
            /// The e x 1_tk 11.
            /// </summary>
            EX1_tk11, 

            /// <summary>
            /// The e x 1_591.
            /// </summary>
            EX1_591, 

            /// <summary>
            /// The e x 1_549.
            /// </summary>
            EX1_549, 

            /// <summary>
            /// The c s 2_045.
            /// </summary>
            CS2_045, 

            /// <summary>
            /// The c s 2_237.
            /// </summary>
            CS2_237, 

            /// <summary>
            /// The c s 2_027.
            /// </summary>
            CS2_027, 

            /// <summary>
            /// The e x 1_508 o.
            /// </summary>
            EX1_508o, 

            /// <summary>
            /// The na x 14_03.
            /// </summary>
            NAX14_03, 

            /// <summary>
            /// The c s 2_101 t.
            /// </summary>
            CS2_101t, 

            /// <summary>
            /// The c s 2_063.
            /// </summary>
            CS2_063, 

            /// <summary>
            /// The e x 1_145.
            /// </summary>
            EX1_145, 

            /// <summary>
            /// The na x 1 h_03.
            /// </summary>
            NAX1h_03, 

            /// <summary>
            /// The e x 1_110.
            /// </summary>
            EX1_110, 

            /// <summary>
            /// The e x 1_408.
            /// </summary>
            EX1_408, 

            /// <summary>
            /// The e x 1_544.
            /// </summary>
            EX1_544, 

            /// <summary>
            /// The t u 4 c_006.
            /// </summary>
            TU4c_006, 

            /// <summary>
            /// The nax m_001.
            /// </summary>
            NAXM_001, 

            /// <summary>
            /// The c s 2_151.
            /// </summary>
            CS2_151, 

            /// <summary>
            /// The c s 2_073 e.
            /// </summary>
            CS2_073e, 

            /// <summary>
            /// The xx x_006.
            /// </summary>
            XXX_006, 

            /// <summary>
            /// The c s 2_088.
            /// </summary>
            CS2_088, 

            /// <summary>
            /// The e x 1_057.
            /// </summary>
            EX1_057, 

            /// <summary>
            /// The f p 1_020.
            /// </summary>
            FP1_020, 

            /// <summary>
            /// The c s 2_169.
            /// </summary>
            CS2_169, 

            /// <summary>
            /// The e x 1_573 t.
            /// </summary>
            EX1_573t, 

            /// <summary>
            /// The e x 1_323 h.
            /// </summary>
            EX1_323h, 

            /// <summary>
            /// The e x 1_tk 9.
            /// </summary>
            EX1_tk9, 

            /// <summary>
            /// The ne w 1_018 e.
            /// </summary>
            NEW1_018e, 

            /// <summary>
            /// The c s 2_037.
            /// </summary>
            CS2_037, 

            /// <summary>
            /// The c s 2_007.
            /// </summary>
            CS2_007, 

            /// <summary>
            /// The e x 1_059 e 2.
            /// </summary>
            EX1_059e2, 

            /// <summary>
            /// The c s 2_227.
            /// </summary>
            CS2_227, 

            /// <summary>
            /// The na x 7_03 h.
            /// </summary>
            NAX7_03H, 

            /// <summary>
            /// The na x 9_01 h.
            /// </summary>
            NAX9_01H, 

            /// <summary>
            /// The e x 1_570 e.
            /// </summary>
            EX1_570e, 

            /// <summary>
            /// The ne w 1_003.
            /// </summary>
            NEW1_003, 

            /// <summary>
            /// The gam e_006.
            /// </summary>
            GAME_006, 

            /// <summary>
            /// The e x 1_320.
            /// </summary>
            EX1_320, 

            /// <summary>
            /// The e x 1_097.
            /// </summary>
            EX1_097, 

            /// <summary>
            /// The tt_004.
            /// </summary>
            tt_004, 

            /// <summary>
            /// The e x 1_360 e.
            /// </summary>
            EX1_360e, 

            /// <summary>
            /// The e x 1_096.
            /// </summary>
            EX1_096, 

            /// <summary>
            /// The d s 1_175 o.
            /// </summary>
            DS1_175o, 

            /// <summary>
            /// The e x 1_596 e.
            /// </summary>
            EX1_596e, 

            /// <summary>
            /// The xx x_014.
            /// </summary>
            XXX_014, 

            /// <summary>
            /// The e x 1_158 e.
            /// </summary>
            EX1_158e, 

            /// <summary>
            /// The na x 14_01.
            /// </summary>
            NAX14_01, 

            /// <summary>
            /// The cre d_01.
            /// </summary>
            CRED_01, 

            /// <summary>
            /// The cre d_08.
            /// </summary>
            CRED_08, 

            /// <summary>
            /// The e x 1_126.
            /// </summary>
            EX1_126, 

            /// <summary>
            /// The e x 1_577.
            /// </summary>
            EX1_577, 

            /// <summary>
            /// The e x 1_319.
            /// </summary>
            EX1_319, 

            /// <summary>
            /// The e x 1_611.
            /// </summary>
            EX1_611, 

            /// <summary>
            /// The c s 2_146.
            /// </summary>
            CS2_146, 

            /// <summary>
            /// The e x 1_154 b.
            /// </summary>
            EX1_154b, 

            /// <summary>
            /// The skele 11.
            /// </summary>
            skele11, 

            /// <summary>
            /// The e x 1_165 t 2.
            /// </summary>
            EX1_165t2, 

            /// <summary>
            /// The c s 2_172.
            /// </summary>
            CS2_172, 

            /// <summary>
            /// The c s 2_114.
            /// </summary>
            CS2_114, 

            /// <summary>
            /// The c s 1_069.
            /// </summary>
            CS1_069, 

            /// <summary>
            /// The xx x_003.
            /// </summary>
            XXX_003, 

            /// <summary>
            /// The xx x_042.
            /// </summary>
            XXX_042, 

            /// <summary>
            /// The na x 8_02.
            /// </summary>
            NAX8_02, 

            /// <summary>
            /// The e x 1_173.
            /// </summary>
            EX1_173, 

            /// <summary>
            /// The c s 1_042.
            /// </summary>
            CS1_042, 

            /// <summary>
            /// The na x 8_03.
            /// </summary>
            NAX8_03, 

            /// <summary>
            /// The e x 1_506 a.
            /// </summary>
            EX1_506a, 

            /// <summary>
            /// The e x 1_298.
            /// </summary>
            EX1_298, 

            /// <summary>
            /// The c s 2_104.
            /// </summary>
            CS2_104, 

            /// <summary>
            /// The f p 1_001.
            /// </summary>
            FP1_001, 

            /// <summary>
            /// The her o_02.
            /// </summary>
            HERO_02, 

            /// <summary>
            /// The e x 1_316 e.
            /// </summary>
            EX1_316e, 

            /// <summary>
            /// The na x 7_01.
            /// </summary>
            NAX7_01, 

            /// <summary>
            /// The e x 1_044 e.
            /// </summary>
            EX1_044e, 

            /// <summary>
            /// The c s 2_051.
            /// </summary>
            CS2_051, 

            /// <summary>
            /// The ne w 1_016.
            /// </summary>
            NEW1_016, 

            /// <summary>
            /// The e x 1_304 e.
            /// </summary>
            EX1_304e, 

            /// <summary>
            /// The e x 1_033.
            /// </summary>
            EX1_033, 

            /// <summary>
            /// The na x 8_04.
            /// </summary>
            NAX8_04, 

            /// <summary>
            /// The e x 1_028.
            /// </summary>
            EX1_028, 

            /// <summary>
            /// The xx x_011.
            /// </summary>
            XXX_011, 

            /// <summary>
            /// The e x 1_621.
            /// </summary>
            EX1_621, 

            /// <summary>
            /// The e x 1_554.
            /// </summary>
            EX1_554, 

            /// <summary>
            /// The e x 1_091.
            /// </summary>
            EX1_091, 

            /// <summary>
            /// The f p 1_017.
            /// </summary>
            FP1_017, 

            /// <summary>
            /// The e x 1_409.
            /// </summary>
            EX1_409, 

            /// <summary>
            /// The e x 1_363 e.
            /// </summary>
            EX1_363e, 

            /// <summary>
            /// The e x 1_410.
            /// </summary>
            EX1_410, 

            /// <summary>
            /// The t u 4 e_005.
            /// </summary>
            TU4e_005, 

            /// <summary>
            /// The c s 2_039.
            /// </summary>
            CS2_039, 

            /// <summary>
            /// The na x 12_04.
            /// </summary>
            NAX12_04, 

            /// <summary>
            /// The e x 1_557.
            /// </summary>
            EX1_557, 

            /// <summary>
            /// The c s 2_105 e.
            /// </summary>
            CS2_105e, 

            /// <summary>
            /// The e x 1_128 e.
            /// </summary>
            EX1_128e, 

            /// <summary>
            /// The xx x_021.
            /// </summary>
            XXX_021, 

            /// <summary>
            /// The d s 1_070.
            /// </summary>
            DS1_070, 

            /// <summary>
            /// The c s 2_033.
            /// </summary>
            CS2_033, 

            /// <summary>
            /// The e x 1_536.
            /// </summary>
            EX1_536, 

            /// <summary>
            /// The t u 4 a_003.
            /// </summary>
            TU4a_003, 

            /// <summary>
            /// The e x 1_559.
            /// </summary>
            EX1_559, 

            /// <summary>
            /// The xx x_023.
            /// </summary>
            XXX_023, 

            /// <summary>
            /// The ne w 1_033 o.
            /// </summary>
            NEW1_033o, 

            /// <summary>
            /// The na x 15_04 h.
            /// </summary>
            NAX15_04H, 

            /// <summary>
            /// The c s 2_004 e.
            /// </summary>
            CS2_004e, 

            /// <summary>
            /// The c s 2_052.
            /// </summary>
            CS2_052, 

            /// <summary>
            /// The e x 1_539.
            /// </summary>
            EX1_539, 

            /// <summary>
            /// The e x 1_575.
            /// </summary>
            EX1_575, 

            /// <summary>
            /// The c s 2_083 b.
            /// </summary>
            CS2_083b, 

            /// <summary>
            /// The c s 2_061.
            /// </summary>
            CS2_061, 

            /// <summary>
            /// The ne w 1_021.
            /// </summary>
            NEW1_021, 

            /// <summary>
            /// The d s 1_055.
            /// </summary>
            DS1_055, 

            /// <summary>
            /// The e x 1_625.
            /// </summary>
            EX1_625, 

            /// <summary>
            /// The e x 1_382 e.
            /// </summary>
            EX1_382e, 

            /// <summary>
            /// The c s 2_092 e.
            /// </summary>
            CS2_092e, 

            /// <summary>
            /// The c s 2_026.
            /// </summary>
            CS2_026, 

            /// <summary>
            /// The na x 14_04.
            /// </summary>
            NAX14_04, 

            /// <summary>
            /// The ne w 1_012 o.
            /// </summary>
            NEW1_012o, 

            /// <summary>
            /// The e x 1_619 e.
            /// </summary>
            EX1_619e, 

            /// <summary>
            /// The e x 1_294.
            /// </summary>
            EX1_294, 

            /// <summary>
            /// The e x 1_287.
            /// </summary>
            EX1_287, 

            /// <summary>
            /// The e x 1_509 e.
            /// </summary>
            EX1_509e, 

            /// <summary>
            /// The e x 1_625 t 2.
            /// </summary>
            EX1_625t2, 

            /// <summary>
            /// The c s 2_118.
            /// </summary>
            CS2_118, 

            /// <summary>
            /// The c s 2_124.
            /// </summary>
            CS2_124, 

            /// <summary>
            /// The mekka 3.
            /// </summary>
            Mekka3, 

            /// <summary>
            /// The na x 13_02.
            /// </summary>
            NAX13_02, 

            /// <summary>
            /// The e x 1_112.
            /// </summary>
            EX1_112, 

            /// <summary>
            /// The f p 1_011.
            /// </summary>
            FP1_011, 

            /// <summary>
            /// The c s 2_009 e.
            /// </summary>
            CS2_009e, 

            /// <summary>
            /// The her o_04.
            /// </summary>
            HERO_04, 

            /// <summary>
            /// The e x 1_607.
            /// </summary>
            EX1_607, 

            /// <summary>
            /// The drea m_03.
            /// </summary>
            DREAM_03, 

            /// <summary>
            /// The na x 11_04 e.
            /// </summary>
            NAX11_04e, 

            /// <summary>
            /// The e x 1_103 e.
            /// </summary>
            EX1_103e, 

            /// <summary>
            /// The xx x_046.
            /// </summary>
            XXX_046, 

            /// <summary>
            /// The f p 1_003.
            /// </summary>
            FP1_003, 

            /// <summary>
            /// The c s 2_105.
            /// </summary>
            CS2_105, 

            /// <summary>
            /// The f p 1_002.
            /// </summary>
            FP1_002, 

            /// <summary>
            /// The t u 4 c_002.
            /// </summary>
            TU4c_002, 

            /// <summary>
            /// The cre d_14.
            /// </summary>
            CRED_14, 

            /// <summary>
            /// The e x 1_567.
            /// </summary>
            EX1_567, 

            /// <summary>
            /// The t u 4 c_004.
            /// </summary>
            TU4c_004, 

            /// <summary>
            /// The na x 10_03 h.
            /// </summary>
            NAX10_03H, 

            /// <summary>
            /// The f p 1_008.
            /// </summary>
            FP1_008, 

            /// <summary>
            /// The d s 1_184.
            /// </summary>
            DS1_184, 

            /// <summary>
            /// The c s 2_029.
            /// </summary>
            CS2_029, 

            /// <summary>
            /// The gam e_005.
            /// </summary>
            GAME_005, 

            /// <summary>
            /// The c s 2_187.
            /// </summary>
            CS2_187, 

            /// <summary>
            /// The e x 1_020.
            /// </summary>
            EX1_020, 

            /// <summary>
            /// The na x 15_01 he.
            /// </summary>
            NAX15_01He, 

            /// <summary>
            /// The e x 1_011.
            /// </summary>
            EX1_011, 

            /// <summary>
            /// The c s 2_057.
            /// </summary>
            CS2_057, 

            /// <summary>
            /// The e x 1_274.
            /// </summary>
            EX1_274, 

            /// <summary>
            /// The e x 1_306.
            /// </summary>
            EX1_306, 

            /// <summary>
            /// The ne w 1_038 o.
            /// </summary>
            NEW1_038o, 

            /// <summary>
            /// The e x 1_170.
            /// </summary>
            EX1_170, 

            /// <summary>
            /// The e x 1_617.
            /// </summary>
            EX1_617, 

            /// <summary>
            /// The c s 1_113 e.
            /// </summary>
            CS1_113e, 

            /// <summary>
            /// The c s 2_101.
            /// </summary>
            CS2_101, 

            /// <summary>
            /// The f p 1_015.
            /// </summary>
            FP1_015, 

            /// <summary>
            /// The na x 13_03.
            /// </summary>
            NAX13_03, 

            /// <summary>
            /// The c s 2_005.
            /// </summary>
            CS2_005, 

            /// <summary>
            /// The e x 1_537.
            /// </summary>
            EX1_537, 

            /// <summary>
            /// The e x 1_384.
            /// </summary>
            EX1_384, 

            /// <summary>
            /// The t u 4 a_002.
            /// </summary>
            TU4a_002, 

            /// <summary>
            /// The na x 9_04.
            /// </summary>
            NAX9_04, 

            /// <summary>
            /// The e x 1_362.
            /// </summary>
            EX1_362, 

            /// <summary>
            /// The na x 12_02.
            /// </summary>
            NAX12_02, 

            /// <summary>
            /// The f p 1_028 e.
            /// </summary>
            FP1_028e, 

            /// <summary>
            /// The t u 4 c_005.
            /// </summary>
            TU4c_005, 

            /// <summary>
            /// The e x 1_301.
            /// </summary>
            EX1_301, 

            /// <summary>
            /// The c s 2_235.
            /// </summary>
            CS2_235, 

            /// <summary>
            /// The na x 4_05.
            /// </summary>
            NAX4_05, 

            /// <summary>
            /// The e x 1_029.
            /// </summary>
            EX1_029, 

            /// <summary>
            /// The c s 2_042.
            /// </summary>
            CS2_042, 

            /// <summary>
            /// The e x 1_155 a.
            /// </summary>
            EX1_155a, 

            /// <summary>
            /// The c s 2_102.
            /// </summary>
            CS2_102, 

            /// <summary>
            /// The e x 1_609.
            /// </summary>
            EX1_609, 

            /// <summary>
            /// The ne w 1_027.
            /// </summary>
            NEW1_027, 

            /// <summary>
            /// The c s 2_236 e.
            /// </summary>
            CS2_236e, 

            /// <summary>
            /// The c s 2_083 e.
            /// </summary>
            CS2_083e, 

            /// <summary>
            /// The na x 6_03 te.
            /// </summary>
            NAX6_03te, 

            /// <summary>
            /// The e x 1_165 a.
            /// </summary>
            EX1_165a, 

            /// <summary>
            /// The e x 1_570.
            /// </summary>
            EX1_570, 

            /// <summary>
            /// The e x 1_131.
            /// </summary>
            EX1_131, 

            /// <summary>
            /// The e x 1_556.
            /// </summary>
            EX1_556, 

            /// <summary>
            /// The e x 1_543.
            /// </summary>
            EX1_543, 

            /// <summary>
            /// The xx x_096.
            /// </summary>
            XXX_096, 

            /// <summary>
            /// The t u 4 c_008 e.
            /// </summary>
            TU4c_008e, 

            /// <summary>
            /// The e x 1_379 e.
            /// </summary>
            EX1_379e, 

            /// <summary>
            /// The ne w 1_009.
            /// </summary>
            NEW1_009, 

            /// <summary>
            /// The e x 1_100.
            /// </summary>
            EX1_100, 

            /// <summary>
            /// The e x 1_274 e.
            /// </summary>
            EX1_274e, 

            /// <summary>
            /// The cre d_02.
            /// </summary>
            CRED_02, 

            /// <summary>
            /// The e x 1_573 a.
            /// </summary>
            EX1_573a, 

            /// <summary>
            /// The c s 2_084.
            /// </summary>
            CS2_084, 

            /// <summary>
            /// The e x 1_582.
            /// </summary>
            EX1_582, 

            /// <summary>
            /// The e x 1_043.
            /// </summary>
            EX1_043, 

            /// <summary>
            /// The e x 1_050.
            /// </summary>
            EX1_050, 

            /// <summary>
            /// The t u 4 b_001.
            /// </summary>
            TU4b_001, 

            /// <summary>
            /// The f p 1_005.
            /// </summary>
            FP1_005, 

            /// <summary>
            /// The e x 1_620.
            /// </summary>
            EX1_620, 

            /// <summary>
            /// The na x 15_01.
            /// </summary>
            NAX15_01, 

            /// <summary>
            /// The na x 6_03.
            /// </summary>
            NAX6_03, 

            /// <summary>
            /// The e x 1_303.
            /// </summary>
            EX1_303, 

            /// <summary>
            /// The her o_09.
            /// </summary>
            HERO_09, 

            /// <summary>
            /// The e x 1_067.
            /// </summary>
            EX1_067, 

            /// <summary>
            /// The xx x_028.
            /// </summary>
            XXX_028, 

            /// <summary>
            /// The e x 1_277.
            /// </summary>
            EX1_277, 

            /// <summary>
            /// The mekka 2.
            /// </summary>
            Mekka2, 

            /// <summary>
            /// The na x 14_01 h.
            /// </summary>
            NAX14_01H, 

            /// <summary>
            /// The na x 15_04.
            /// </summary>
            NAX15_04, 

            /// <summary>
            /// The f p 1_024.
            /// </summary>
            FP1_024, 

            /// <summary>
            /// The f p 1_030.
            /// </summary>
            FP1_030, 

            /// <summary>
            /// The c s 2_221 e.
            /// </summary>
            CS2_221e, 

            /// <summary>
            /// The e x 1_178.
            /// </summary>
            EX1_178, 

            /// <summary>
            /// The c s 2_222.
            /// </summary>
            CS2_222, 

            /// <summary>
            /// The e x 1_409 e.
            /// </summary>
            EX1_409e, 

            /// <summary>
            /// The tt_004 o.
            /// </summary>
            tt_004o, 

            /// <summary>
            /// The e x 1_155 ae.
            /// </summary>
            EX1_155ae, 

            /// <summary>
            /// The na x 11_01 h.
            /// </summary>
            NAX11_01H, 

            /// <summary>
            /// The e x 1_160 a.
            /// </summary>
            EX1_160a, 

            /// <summary>
            /// The na x 15_02.
            /// </summary>
            NAX15_02, 

            /// <summary>
            /// The na x 15_05.
            /// </summary>
            NAX15_05, 

            /// <summary>
            /// The ne w 1_025 e.
            /// </summary>
            NEW1_025e, 

            /// <summary>
            /// The c s 2_012.
            /// </summary>
            CS2_012, 

            /// <summary>
            /// The xx x_099.
            /// </summary>
            XXX_099, 

            /// <summary>
            /// The e x 1_246.
            /// </summary>
            EX1_246, 

            /// <summary>
            /// The e x 1_572.
            /// </summary>
            EX1_572, 

            /// <summary>
            /// The e x 1_089.
            /// </summary>
            EX1_089, 

            /// <summary>
            /// The c s 2_059.
            /// </summary>
            CS2_059, 

            /// <summary>
            /// The e x 1_279.
            /// </summary>
            EX1_279, 

            /// <summary>
            /// The na x 12_02 e.
            /// </summary>
            NAX12_02e, 

            /// <summary>
            /// The c s 2_168.
            /// </summary>
            CS2_168, 

            /// <summary>
            /// The tt_010.
            /// </summary>
            tt_010, 

            /// <summary>
            /// The ne w 1_023.
            /// </summary>
            NEW1_023, 

            /// <summary>
            /// The c s 2_075.
            /// </summary>
            CS2_075, 

            /// <summary>
            /// The e x 1_316.
            /// </summary>
            EX1_316, 

            /// <summary>
            /// The c s 2_025.
            /// </summary>
            CS2_025, 

            /// <summary>
            /// The c s 2_234.
            /// </summary>
            CS2_234, 

            /// <summary>
            /// The xx x_043.
            /// </summary>
            XXX_043, 

            /// <summary>
            /// The gam e_001.
            /// </summary>
            GAME_001, 

            /// <summary>
            /// The na x 5_02.
            /// </summary>
            NAX5_02, 

            /// <summary>
            /// The e x 1_130.
            /// </summary>
            EX1_130, 

            /// <summary>
            /// The e x 1_584 e.
            /// </summary>
            EX1_584e, 

            /// <summary>
            /// The c s 2_064.
            /// </summary>
            CS2_064, 

            /// <summary>
            /// The e x 1_161.
            /// </summary>
            EX1_161, 

            /// <summary>
            /// The c s 2_049.
            /// </summary>
            CS2_049, 

            /// <summary>
            /// The na x 13_01.
            /// </summary>
            NAX13_01, 

            /// <summary>
            /// The e x 1_154.
            /// </summary>
            EX1_154, 

            /// <summary>
            /// The e x 1_080.
            /// </summary>
            EX1_080, 

            /// <summary>
            /// The ne w 1_022.
            /// </summary>
            NEW1_022, 

            /// <summary>
            /// The na x 2_01 h.
            /// </summary>
            NAX2_01H, 

            /// <summary>
            /// The e x 1_160 be.
            /// </summary>
            EX1_160be, 

            /// <summary>
            /// The na x 12_03.
            /// </summary>
            NAX12_03, 

            /// <summary>
            /// The e x 1_251.
            /// </summary>
            EX1_251, 

            /// <summary>
            /// The f p 1_025.
            /// </summary>
            FP1_025, 

            /// <summary>
            /// The e x 1_371.
            /// </summary>
            EX1_371, 

            /// <summary>
            /// The c s 2_mirror.
            /// </summary>
            CS2_mirror, 

            /// <summary>
            /// The na x 4_01 h.
            /// </summary>
            NAX4_01H, 

            /// <summary>
            /// The e x 1_594.
            /// </summary>
            EX1_594, 

            /// <summary>
            /// The na x 14_02.
            /// </summary>
            NAX14_02, 

            /// <summary>
            /// The t u 4 c_006 e.
            /// </summary>
            TU4c_006e, 

            /// <summary>
            /// The e x 1_560.
            /// </summary>
            EX1_560, 

            /// <summary>
            /// The c s 2_236.
            /// </summary>
            CS2_236, 

            /// <summary>
            /// The t u 4 f_006.
            /// </summary>
            TU4f_006, 

            /// <summary>
            /// The e x 1_402.
            /// </summary>
            EX1_402, 

            /// <summary>
            /// The na x 3_01.
            /// </summary>
            NAX3_01, 

            /// <summary>
            /// The e x 1_506.
            /// </summary>
            EX1_506, 

            /// <summary>
            /// The ne w 1_027 e.
            /// </summary>
            NEW1_027e, 

            /// <summary>
            /// The d s 1_070 o.
            /// </summary>
            DS1_070o, 

            /// <summary>
            /// The xx x_045.
            /// </summary>
            XXX_045, 

            /// <summary>
            /// The xx x_029.
            /// </summary>
            XXX_029, 

            /// <summary>
            /// The d s 1_178.
            /// </summary>
            DS1_178, 

            /// <summary>
            /// The xx x_098.
            /// </summary>
            XXX_098, 

            /// <summary>
            /// The e x 1_315.
            /// </summary>
            EX1_315, 

            /// <summary>
            /// The c s 2_094.
            /// </summary>
            CS2_094, 

            /// <summary>
            /// The na x 13_01 h.
            /// </summary>
            NAX13_01H, 

            /// <summary>
            /// The t u 4 e_002 t.
            /// </summary>
            TU4e_002t, 

            /// <summary>
            /// The e x 1_046 e.
            /// </summary>
            EX1_046e, 

            /// <summary>
            /// The ne w 1_040 t.
            /// </summary>
            NEW1_040t, 

            /// <summary>
            /// The gam e_005 e.
            /// </summary>
            GAME_005e, 

            /// <summary>
            /// The c s 2_131.
            /// </summary>
            CS2_131, 

            /// <summary>
            /// The xx x_008.
            /// </summary>
            XXX_008, 

            /// <summary>
            /// The e x 1_531 e.
            /// </summary>
            EX1_531e, 

            /// <summary>
            /// The c s 2_226 e.
            /// </summary>
            CS2_226e, 

            /// <summary>
            /// The xx x_022 e.
            /// </summary>
            XXX_022e, 

            /// <summary>
            /// The d s 1_178 e.
            /// </summary>
            DS1_178e, 

            /// <summary>
            /// The c s 2_226 o.
            /// </summary>
            CS2_226o, 

            /// <summary>
            /// The na x 9_04 h.
            /// </summary>
            NAX9_04H, 

            /// <summary>
            /// The mekka 4 e.
            /// </summary>
            Mekka4e, 

            /// <summary>
            /// The e x 1_082.
            /// </summary>
            EX1_082, 

            /// <summary>
            /// The c s 2_093.
            /// </summary>
            CS2_093, 

            /// <summary>
            /// The e x 1_411 e.
            /// </summary>
            EX1_411e, 

            /// <summary>
            /// The na x 8_03 t.
            /// </summary>
            NAX8_03t, 

            /// <summary>
            /// The e x 1_145 o.
            /// </summary>
            EX1_145o, 

            /// <summary>
            /// The na x 7_04.
            /// </summary>
            NAX7_04, 

            /// <summary>
            /// The c s 2_boar.
            /// </summary>
            CS2_boar, 

            /// <summary>
            /// The ne w 1_019.
            /// </summary>
            NEW1_019, 

            /// <summary>
            /// The e x 1_289.
            /// </summary>
            EX1_289, 

            /// <summary>
            /// The e x 1_025 t.
            /// </summary>
            EX1_025t, 

            /// <summary>
            /// The e x 1_398 t.
            /// </summary>
            EX1_398t, 

            /// <summary>
            /// The na x 12_03 h.
            /// </summary>
            NAX12_03H, 

            /// <summary>
            /// The e x 1_055 o.
            /// </summary>
            EX1_055o, 

            /// <summary>
            /// The c s 2_091.
            /// </summary>
            CS2_091, 

            /// <summary>
            /// The e x 1_241.
            /// </summary>
            EX1_241, 

            /// <summary>
            /// The e x 1_085.
            /// </summary>
            EX1_085, 

            /// <summary>
            /// The c s 2_200.
            /// </summary>
            CS2_200, 

            /// <summary>
            /// The c s 2_034.
            /// </summary>
            CS2_034, 

            /// <summary>
            /// The e x 1_583.
            /// </summary>
            EX1_583, 

            /// <summary>
            /// The e x 1_584.
            /// </summary>
            EX1_584, 

            /// <summary>
            /// The e x 1_155.
            /// </summary>
            EX1_155, 

            /// <summary>
            /// The e x 1_622.
            /// </summary>
            EX1_622, 

            /// <summary>
            /// The c s 2_203.
            /// </summary>
            CS2_203, 

            /// <summary>
            /// The e x 1_124.
            /// </summary>
            EX1_124, 

            /// <summary>
            /// The e x 1_379.
            /// </summary>
            EX1_379, 

            /// <summary>
            /// The na x 7_02.
            /// </summary>
            NAX7_02, 

            /// <summary>
            /// The c s 2_053 e.
            /// </summary>
            CS2_053e, 

            /// <summary>
            /// The e x 1_032.
            /// </summary>
            EX1_032, 

            /// <summary>
            /// The na x 9_01.
            /// </summary>
            NAX9_01, 

            /// <summary>
            /// The t u 4 e_003.
            /// </summary>
            TU4e_003, 

            /// <summary>
            /// The c s 2_146 o.
            /// </summary>
            CS2_146o, 

            /// <summary>
            /// The na x 8_01 h.
            /// </summary>
            NAX8_01H, 

            /// <summary>
            /// The xx x_041.
            /// </summary>
            XXX_041, 

            /// <summary>
            /// The nax m_002.
            /// </summary>
            NAXM_002, 

            /// <summary>
            /// The e x 1_391.
            /// </summary>
            EX1_391, 

            /// <summary>
            /// The e x 1_366.
            /// </summary>
            EX1_366, 

            /// <summary>
            /// The e x 1_059 e.
            /// </summary>
            EX1_059e, 

            /// <summary>
            /// The xx x_012.
            /// </summary>
            XXX_012, 

            /// <summary>
            /// The e x 1_565 o.
            /// </summary>
            EX1_565o, 

            /// <summary>
            /// The e x 1_001 e.
            /// </summary>
            EX1_001e, 

            /// <summary>
            /// The t u 4 f_003.
            /// </summary>
            TU4f_003, 

            /// <summary>
            /// The e x 1_400.
            /// </summary>
            EX1_400, 

            /// <summary>
            /// The e x 1_614.
            /// </summary>
            EX1_614, 

            /// <summary>
            /// The e x 1_561.
            /// </summary>
            EX1_561, 

            /// <summary>
            /// The e x 1_332.
            /// </summary>
            EX1_332, 

            /// <summary>
            /// The her o_05.
            /// </summary>
            HERO_05, 

            /// <summary>
            /// The c s 2_065.
            /// </summary>
            CS2_065, 

            /// <summary>
            /// The ds 1_whelptoken.
            /// </summary>
            ds1_whelptoken, 

            /// <summary>
            /// The e x 1_536 e.
            /// </summary>
            EX1_536e, 

            /// <summary>
            /// The c s 2_032.
            /// </summary>
            CS2_032, 

            /// <summary>
            /// The c s 2_120.
            /// </summary>
            CS2_120, 

            /// <summary>
            /// The e x 1_155 be.
            /// </summary>
            EX1_155be, 

            /// <summary>
            /// The e x 1_247.
            /// </summary>
            EX1_247, 

            /// <summary>
            /// The e x 1_154 a.
            /// </summary>
            EX1_154a, 

            /// <summary>
            /// The e x 1_554 t.
            /// </summary>
            EX1_554t, 

            /// <summary>
            /// The c s 2_103 e 2.
            /// </summary>
            CS2_103e2, 

            /// <summary>
            /// The t u 4 d_003.
            /// </summary>
            TU4d_003, 

            /// <summary>
            /// The ne w 1_026 t.
            /// </summary>
            NEW1_026t, 

            /// <summary>
            /// The e x 1_623.
            /// </summary>
            EX1_623, 

            /// <summary>
            /// The e x 1_383 t.
            /// </summary>
            EX1_383t, 

            /// <summary>
            /// The na x 7_03.
            /// </summary>
            NAX7_03, 

            /// <summary>
            /// The e x 1_597.
            /// </summary>
            EX1_597, 

            /// <summary>
            /// The t u 4 f_006 o.
            /// </summary>
            TU4f_006o, 

            /// <summary>
            /// The e x 1_130 a.
            /// </summary>
            EX1_130a, 

            /// <summary>
            /// The c s 2_011.
            /// </summary>
            CS2_011, 

            /// <summary>
            /// The e x 1_169.
            /// </summary>
            EX1_169, 

            /// <summary>
            /// The e x 1_tk 33.
            /// </summary>
            EX1_tk33, 

            /// <summary>
            /// The na x 11_03.
            /// </summary>
            NAX11_03, 

            /// <summary>
            /// The na x 4_01.
            /// </summary>
            NAX4_01, 

            /// <summary>
            /// The na x 10_01.
            /// </summary>
            NAX10_01, 

            /// <summary>
            /// The e x 1_250.
            /// </summary>
            EX1_250, 

            /// <summary>
            /// The e x 1_564.
            /// </summary>
            EX1_564, 

            /// <summary>
            /// The na x 5_03.
            /// </summary>
            NAX5_03, 

            /// <summary>
            /// The e x 1_043 e.
            /// </summary>
            EX1_043e, 

            /// <summary>
            /// The e x 1_349.
            /// </summary>
            EX1_349, 

            /// <summary>
            /// The xx x_097.
            /// </summary>
            XXX_097, 

            /// <summary>
            /// The e x 1_102.
            /// </summary>
            EX1_102, 

            /// <summary>
            /// The e x 1_058.
            /// </summary>
            EX1_058, 

            /// <summary>
            /// The e x 1_243.
            /// </summary>
            EX1_243, 

            /// <summary>
            /// The pr o_001 c.
            /// </summary>
            PRO_001c, 

            /// <summary>
            /// The e x 1_116 t.
            /// </summary>
            EX1_116t, 

            /// <summary>
            /// The na x 15_01 e.
            /// </summary>
            NAX15_01e, 

            /// <summary>
            /// The f p 1_029.
            /// </summary>
            FP1_029, 

            /// <summary>
            /// The c s 2_089.
            /// </summary>
            CS2_089, 

            /// <summary>
            /// The t u 4 c_001.
            /// </summary>
            TU4c_001, 

            /// <summary>
            /// The e x 1_248.
            /// </summary>
            EX1_248, 

            /// <summary>
            /// The ne w 1_037 e.
            /// </summary>
            NEW1_037e, 

            /// <summary>
            /// The c s 2_122.
            /// </summary>
            CS2_122, 

            /// <summary>
            /// The e x 1_393.
            /// </summary>
            EX1_393, 

            /// <summary>
            /// The c s 2_232.
            /// </summary>
            CS2_232, 

            /// <summary>
            /// The e x 1_165 b.
            /// </summary>
            EX1_165b, 

            /// <summary>
            /// The ne w 1_030.
            /// </summary>
            NEW1_030, 

            /// <summary>
            /// The e x 1_161 o.
            /// </summary>
            EX1_161o, 

            /// <summary>
            /// The e x 1_093 e.
            /// </summary>
            EX1_093e, 

            /// <summary>
            /// The c s 2_150.
            /// </summary>
            CS2_150, 

            /// <summary>
            /// The c s 2_152.
            /// </summary>
            CS2_152, 

            /// <summary>
            /// The na x 9_03 h.
            /// </summary>
            NAX9_03H, 

            /// <summary>
            /// The e x 1_160 t.
            /// </summary>
            EX1_160t, 

            /// <summary>
            /// The c s 2_127.
            /// </summary>
            CS2_127, 

            /// <summary>
            /// The cre d_03.
            /// </summary>
            CRED_03, 

            /// <summary>
            /// The d s 1_188.
            /// </summary>
            DS1_188, 

            /// <summary>
            /// The xx x_001.
            /// </summary>
            XXX_001, 
        }

        /// <summary>
        /// The card idstring to enum.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="cardIDEnum"/>.
        /// </returns>
        public cardIDEnum cardIdstringToEnum(string s)
        {
            if (s == "XXX_040") return cardIDEnum.XXX_040;
            if (s == "NAX5_01H") return cardIDEnum.NAX5_01H;
            if (s == "CS2_188o") return cardIDEnum.CS2_188o;
            if (s == "NAX6_02H") return cardIDEnum.NAX6_02H;
            if (s == "NEW1_007b") return cardIDEnum.NEW1_007b;
            if (s == "NAX6_02e") return cardIDEnum.NAX6_02e;
            if (s == "TU4c_003") return cardIDEnum.TU4c_003;
            if (s == "XXX_024") return cardIDEnum.XXX_024;
            if (s == "EX1_613") return cardIDEnum.EX1_613;
            if (s == "NAX8_01") return cardIDEnum.NAX8_01;
            if (s == "EX1_295o") return cardIDEnum.EX1_295o;
            if (s == "CS2_059o") return cardIDEnum.CS2_059o;
            if (s == "EX1_133") return cardIDEnum.EX1_133;
            if (s == "NEW1_018") return cardIDEnum.NEW1_018;
            if (s == "NAX15_03t") return cardIDEnum.NAX15_03t;
            if (s == "EX1_012") return cardIDEnum.EX1_012;
            if (s == "EX1_178a") return cardIDEnum.EX1_178a;
            if (s == "CS2_231") return cardIDEnum.CS2_231;
            if (s == "EX1_019e") return cardIDEnum.EX1_019e;
            if (s == "CRED_12") return cardIDEnum.CRED_12;
            if (s == "CS2_179") return cardIDEnum.CS2_179;
            if (s == "CS2_045e") return cardIDEnum.CS2_045e;
            if (s == "EX1_244") return cardIDEnum.EX1_244;
            if (s == "EX1_178b") return cardIDEnum.EX1_178b;
            if (s == "XXX_030") return cardIDEnum.XXX_030;
            if (s == "NAX8_05") return cardIDEnum.NAX8_05;
            if (s == "EX1_573b") return cardIDEnum.EX1_573b;
            if (s == "TU4d_001") return cardIDEnum.TU4d_001;
            if (s == "NEW1_007a") return cardIDEnum.NEW1_007a;
            if (s == "NAX12_02H") return cardIDEnum.NAX12_02H;
            if (s == "EX1_345t") return cardIDEnum.EX1_345t;
            if (s == "FP1_007t") return cardIDEnum.FP1_007t;
            if (s == "EX1_025") return cardIDEnum.EX1_025;
            if (s == "EX1_396") return cardIDEnum.EX1_396;
            if (s == "NAX9_03") return cardIDEnum.NAX9_03;
            if (s == "NEW1_017") return cardIDEnum.NEW1_017;
            if (s == "NEW1_008a") return cardIDEnum.NEW1_008a;
            if (s == "EX1_587e") return cardIDEnum.EX1_587e;
            if (s == "EX1_533") return cardIDEnum.EX1_533;
            if (s == "EX1_522") return cardIDEnum.EX1_522;
            if (s == "NAX11_04") return cardIDEnum.NAX11_04;
            if (s == "NEW1_026") return cardIDEnum.NEW1_026;
            if (s == "EX1_398") return cardIDEnum.EX1_398;
            if (s == "NAX4_04") return cardIDEnum.NAX4_04;
            if (s == "EX1_007") return cardIDEnum.EX1_007;
            if (s == "CS1_112") return cardIDEnum.CS1_112;
            if (s == "CRED_17") return cardIDEnum.CRED_17;
            if (s == "NEW1_036") return cardIDEnum.NEW1_036;
            if (s == "NAX3_03") return cardIDEnum.NAX3_03;
            if (s == "EX1_355e") return cardIDEnum.EX1_355e;
            if (s == "EX1_258") return cardIDEnum.EX1_258;
            if (s == "HERO_01") return cardIDEnum.HERO_01;
            if (s == "XXX_009") return cardIDEnum.XXX_009;
            if (s == "NAX6_01H") return cardIDEnum.NAX6_01H;
            if (s == "NAX12_04e") return cardIDEnum.NAX12_04e;
            if (s == "CS2_087") return cardIDEnum.CS2_087;
            if (s == "DREAM_05") return cardIDEnum.DREAM_05;
            if (s == "NEW1_036e") return cardIDEnum.NEW1_036e;
            if (s == "CS2_092") return cardIDEnum.CS2_092;
            if (s == "CS2_022") return cardIDEnum.CS2_022;
            if (s == "EX1_046") return cardIDEnum.EX1_046;
            if (s == "XXX_005") return cardIDEnum.XXX_005;
            if (s == "PRO_001b") return cardIDEnum.PRO_001b;
            if (s == "XXX_022") return cardIDEnum.XXX_022;
            if (s == "PRO_001a") return cardIDEnum.PRO_001a;
            if (s == "NAX6_04") return cardIDEnum.NAX6_04;
            if (s == "NAX7_05") return cardIDEnum.NAX7_05;
            if (s == "CS2_103") return cardIDEnum.CS2_103;
            if (s == "NEW1_041") return cardIDEnum.NEW1_041;
            if (s == "EX1_360") return cardIDEnum.EX1_360;
            if (s == "FP1_023") return cardIDEnum.FP1_023;
            if (s == "NEW1_038") return cardIDEnum.NEW1_038;
            if (s == "CS2_009") return cardIDEnum.CS2_009;
            if (s == "NAX10_01H") return cardIDEnum.NAX10_01H;
            if (s == "EX1_010") return cardIDEnum.EX1_010;
            if (s == "CS2_024") return cardIDEnum.CS2_024;
            if (s == "NAX9_05") return cardIDEnum.NAX9_05;
            if (s == "EX1_565") return cardIDEnum.EX1_565;
            if (s == "CS2_076") return cardIDEnum.CS2_076;
            if (s == "FP1_004") return cardIDEnum.FP1_004;
            if (s == "CS2_046e") return cardIDEnum.CS2_046e;
            if (s == "CS2_162") return cardIDEnum.CS2_162;
            if (s == "EX1_110t") return cardIDEnum.EX1_110t;
            if (s == "CS2_104e") return cardIDEnum.CS2_104e;
            if (s == "CS2_181") return cardIDEnum.CS2_181;
            if (s == "EX1_309") return cardIDEnum.EX1_309;
            if (s == "EX1_354") return cardIDEnum.EX1_354;
            if (s == "NAX10_02H") return cardIDEnum.NAX10_02H;
            if (s == "NAX7_04H") return cardIDEnum.NAX7_04H;
            if (s == "TU4f_001") return cardIDEnum.TU4f_001;
            if (s == "XXX_018") return cardIDEnum.XXX_018;
            if (s == "EX1_023") return cardIDEnum.EX1_023;
            if (s == "XXX_048") return cardIDEnum.XXX_048;
            if (s == "XXX_049") return cardIDEnum.XXX_049;
            if (s == "NEW1_034") return cardIDEnum.NEW1_034;
            if (s == "CS2_003") return cardIDEnum.CS2_003;
            if (s == "HERO_06") return cardIDEnum.HERO_06;
            if (s == "CS2_201") return cardIDEnum.CS2_201;
            if (s == "EX1_508") return cardIDEnum.EX1_508;
            if (s == "EX1_259") return cardIDEnum.EX1_259;
            if (s == "EX1_341") return cardIDEnum.EX1_341;
            if (s == "DREAM_05e") return cardIDEnum.DREAM_05e;
            if (s == "CRED_09") return cardIDEnum.CRED_09;
            if (s == "EX1_103") return cardIDEnum.EX1_103;
            if (s == "FP1_021") return cardIDEnum.FP1_021;
            if (s == "EX1_411") return cardIDEnum.EX1_411;
            if (s == "NAX1_04") return cardIDEnum.NAX1_04;
            if (s == "CS2_053") return cardIDEnum.CS2_053;
            if (s == "CS2_182") return cardIDEnum.CS2_182;
            if (s == "CS2_008") return cardIDEnum.CS2_008;
            if (s == "CS2_233") return cardIDEnum.CS2_233;
            if (s == "EX1_626") return cardIDEnum.EX1_626;
            if (s == "EX1_059") return cardIDEnum.EX1_059;
            if (s == "EX1_334") return cardIDEnum.EX1_334;
            if (s == "EX1_619") return cardIDEnum.EX1_619;
            if (s == "NEW1_032") return cardIDEnum.NEW1_032;
            if (s == "EX1_158t") return cardIDEnum.EX1_158t;
            if (s == "EX1_006") return cardIDEnum.EX1_006;
            if (s == "NEW1_031") return cardIDEnum.NEW1_031;
            if (s == "NAX10_03") return cardIDEnum.NAX10_03;
            if (s == "DREAM_04") return cardIDEnum.DREAM_04;
            if (s == "NAX1h_01") return cardIDEnum.NAX1h_01;
            if (s == "CS2_022e") return cardIDEnum.CS2_022e;
            if (s == "EX1_611e") return cardIDEnum.EX1_611e;
            if (s == "EX1_004") return cardIDEnum.EX1_004;
            if (s == "EX1_014te") return cardIDEnum.EX1_014te;
            if (s == "FP1_005e") return cardIDEnum.FP1_005e;
            if (s == "NAX12_03e") return cardIDEnum.NAX12_03e;
            if (s == "EX1_095") return cardIDEnum.EX1_095;
            if (s == "NEW1_007") return cardIDEnum.NEW1_007;
            if (s == "EX1_275") return cardIDEnum.EX1_275;
            if (s == "EX1_245") return cardIDEnum.EX1_245;
            if (s == "EX1_383") return cardIDEnum.EX1_383;
            if (s == "FP1_016") return cardIDEnum.FP1_016;
            if (s == "EX1_016t") return cardIDEnum.EX1_016t;
            if (s == "CS2_125") return cardIDEnum.CS2_125;
            if (s == "EX1_137") return cardIDEnum.EX1_137;
            if (s == "EX1_178ae") return cardIDEnum.EX1_178ae;
            if (s == "DS1_185") return cardIDEnum.DS1_185;
            if (s == "FP1_010") return cardIDEnum.FP1_010;
            if (s == "EX1_598") return cardIDEnum.EX1_598;
            if (s == "NAX9_07") return cardIDEnum.NAX9_07;
            if (s == "EX1_304") return cardIDEnum.EX1_304;
            if (s == "EX1_302") return cardIDEnum.EX1_302;
            if (s == "XXX_017") return cardIDEnum.XXX_017;
            if (s == "CS2_011o") return cardIDEnum.CS2_011o;
            if (s == "EX1_614t") return cardIDEnum.EX1_614t;
            if (s == "TU4a_006") return cardIDEnum.TU4a_006;
            if (s == "Mekka3e") return cardIDEnum.Mekka3e;
            if (s == "CS2_108") return cardIDEnum.CS2_108;
            if (s == "CS2_046") return cardIDEnum.CS2_046;
            if (s == "EX1_014t") return cardIDEnum.EX1_014t;
            if (s == "NEW1_005") return cardIDEnum.NEW1_005;
            if (s == "EX1_062") return cardIDEnum.EX1_062;
            if (s == "EX1_366e") return cardIDEnum.EX1_366e;
            if (s == "Mekka1") return cardIDEnum.Mekka1;
            if (s == "XXX_007") return cardIDEnum.XXX_007;
            if (s == "tt_010a") return cardIDEnum.tt_010a;
            if (s == "CS2_017o") return cardIDEnum.CS2_017o;
            if (s == "CS2_072") return cardIDEnum.CS2_072;
            if (s == "EX1_tk28") return cardIDEnum.EX1_tk28;
            if (s == "EX1_604o") return cardIDEnum.EX1_604o;
            if (s == "FP1_014") return cardIDEnum.FP1_014;
            if (s == "EX1_084e") return cardIDEnum.EX1_084e;
            if (s == "NAX3_01H") return cardIDEnum.NAX3_01H;
            if (s == "NAX2_01") return cardIDEnum.NAX2_01;
            if (s == "EX1_409t") return cardIDEnum.EX1_409t;
            if (s == "CRED_07") return cardIDEnum.CRED_07;
            if (s == "NAX3_02H") return cardIDEnum.NAX3_02H;
            if (s == "TU4e_002") return cardIDEnum.TU4e_002;
            if (s == "EX1_507") return cardIDEnum.EX1_507;
            if (s == "EX1_144") return cardIDEnum.EX1_144;
            if (s == "CS2_038") return cardIDEnum.CS2_038;
            if (s == "EX1_093") return cardIDEnum.EX1_093;
            if (s == "CS2_080") return cardIDEnum.CS2_080;
            if (s == "CS1_129e") return cardIDEnum.CS1_129e;
            if (s == "XXX_013") return cardIDEnum.XXX_013;
            if (s == "EX1_005") return cardIDEnum.EX1_005;
            if (s == "EX1_382") return cardIDEnum.EX1_382;
            if (s == "NAX13_02e") return cardIDEnum.NAX13_02e;
            if (s == "FP1_020e") return cardIDEnum.FP1_020e;
            if (s == "EX1_603e") return cardIDEnum.EX1_603e;
            if (s == "CS2_028") return cardIDEnum.CS2_028;
            if (s == "TU4f_002") return cardIDEnum.TU4f_002;
            if (s == "EX1_538") return cardIDEnum.EX1_538;
            if (s == "GAME_003e") return cardIDEnum.GAME_003e;
            if (s == "DREAM_02") return cardIDEnum.DREAM_02;
            if (s == "EX1_581") return cardIDEnum.EX1_581;
            if (s == "NAX15_01H") return cardIDEnum.NAX15_01H;
            if (s == "EX1_131t") return cardIDEnum.EX1_131t;
            if (s == "CS2_147") return cardIDEnum.CS2_147;
            if (s == "CS1_113") return cardIDEnum.CS1_113;
            if (s == "CS2_161") return cardIDEnum.CS2_161;
            if (s == "CS2_031") return cardIDEnum.CS2_031;
            if (s == "EX1_166b") return cardIDEnum.EX1_166b;
            if (s == "EX1_066") return cardIDEnum.EX1_066;
            if (s == "TU4c_007") return cardIDEnum.TU4c_007;
            if (s == "EX1_355") return cardIDEnum.EX1_355;
            if (s == "EX1_507e") return cardIDEnum.EX1_507e;
            if (s == "EX1_534") return cardIDEnum.EX1_534;
            if (s == "EX1_162") return cardIDEnum.EX1_162;
            if (s == "TU4a_004") return cardIDEnum.TU4a_004;
            if (s == "EX1_363") return cardIDEnum.EX1_363;
            if (s == "EX1_164a") return cardIDEnum.EX1_164a;
            if (s == "CS2_188") return cardIDEnum.CS2_188;
            if (s == "EX1_016") return cardIDEnum.EX1_016;
            if (s == "NAX6_03t") return cardIDEnum.NAX6_03t;
            if (s == "EX1_tk31") return cardIDEnum.EX1_tk31;
            if (s == "EX1_603") return cardIDEnum.EX1_603;
            if (s == "EX1_238") return cardIDEnum.EX1_238;
            if (s == "EX1_166") return cardIDEnum.EX1_166;
            if (s == "DS1h_292") return cardIDEnum.DS1h_292;
            if (s == "DS1_183") return cardIDEnum.DS1_183;
            if (s == "NAX15_03n") return cardIDEnum.NAX15_03n;
            if (s == "NAX8_02H") return cardIDEnum.NAX8_02H;
            if (s == "NAX7_01H") return cardIDEnum.NAX7_01H;
            if (s == "NAX9_02H") return cardIDEnum.NAX9_02H;
            if (s == "CRED_11") return cardIDEnum.CRED_11;
            if (s == "XXX_019") return cardIDEnum.XXX_019;
            if (s == "EX1_076") return cardIDEnum.EX1_076;
            if (s == "EX1_048") return cardIDEnum.EX1_048;
            if (s == "CS2_038e") return cardIDEnum.CS2_038e;
            if (s == "FP1_026") return cardIDEnum.FP1_026;
            if (s == "CS2_074") return cardIDEnum.CS2_074;
            if (s == "FP1_027") return cardIDEnum.FP1_027;
            if (s == "EX1_323w") return cardIDEnum.EX1_323w;
            if (s == "EX1_129") return cardIDEnum.EX1_129;
            if (s == "NEW1_024o") return cardIDEnum.NEW1_024o;
            if (s == "NAX11_02") return cardIDEnum.NAX11_02;
            if (s == "EX1_405") return cardIDEnum.EX1_405;
            if (s == "EX1_317") return cardIDEnum.EX1_317;
            if (s == "EX1_606") return cardIDEnum.EX1_606;
            if (s == "EX1_590e") return cardIDEnum.EX1_590e;
            if (s == "XXX_044") return cardIDEnum.XXX_044;
            if (s == "CS2_074e") return cardIDEnum.CS2_074e;
            if (s == "TU4a_005") return cardIDEnum.TU4a_005;
            if (s == "FP1_006") return cardIDEnum.FP1_006;
            if (s == "EX1_258e") return cardIDEnum.EX1_258e;
            if (s == "TU4f_004o") return cardIDEnum.TU4f_004o;
            if (s == "NEW1_008") return cardIDEnum.NEW1_008;
            if (s == "CS2_119") return cardIDEnum.CS2_119;
            if (s == "NEW1_017e") return cardIDEnum.NEW1_017e;
            if (s == "EX1_334e") return cardIDEnum.EX1_334e;
            if (s == "TU4e_001") return cardIDEnum.TU4e_001;
            if (s == "CS2_121") return cardIDEnum.CS2_121;
            if (s == "CS1h_001") return cardIDEnum.CS1h_001;
            if (s == "EX1_tk34") return cardIDEnum.EX1_tk34;
            if (s == "NEW1_020") return cardIDEnum.NEW1_020;
            if (s == "CS2_196") return cardIDEnum.CS2_196;
            if (s == "EX1_312") return cardIDEnum.EX1_312;
            if (s == "NAX1_01") return cardIDEnum.NAX1_01;
            if (s == "FP1_022") return cardIDEnum.FP1_022;
            if (s == "EX1_160b") return cardIDEnum.EX1_160b;
            if (s == "EX1_563") return cardIDEnum.EX1_563;
            if (s == "XXX_039") return cardIDEnum.XXX_039;
            if (s == "FP1_031") return cardIDEnum.FP1_031;
            if (s == "CS2_087e") return cardIDEnum.CS2_087e;
            if (s == "EX1_613e") return cardIDEnum.EX1_613e;
            if (s == "NAX9_02") return cardIDEnum.NAX9_02;
            if (s == "NEW1_029") return cardIDEnum.NEW1_029;
            if (s == "CS1_129") return cardIDEnum.CS1_129;
            if (s == "HERO_03") return cardIDEnum.HERO_03;
            if (s == "Mekka4t") return cardIDEnum.Mekka4t;
            if (s == "EX1_158") return cardIDEnum.EX1_158;
            if (s == "XXX_010") return cardIDEnum.XXX_010;
            if (s == "NEW1_025") return cardIDEnum.NEW1_025;
            if (s == "FP1_012t") return cardIDEnum.FP1_012t;
            if (s == "EX1_083") return cardIDEnum.EX1_083;
            if (s == "EX1_295") return cardIDEnum.EX1_295;
            if (s == "EX1_407") return cardIDEnum.EX1_407;
            if (s == "NEW1_004") return cardIDEnum.NEW1_004;
            if (s == "FP1_019") return cardIDEnum.FP1_019;
            if (s == "PRO_001at") return cardIDEnum.PRO_001at;
            if (s == "NAX13_03e") return cardIDEnum.NAX13_03e;
            if (s == "EX1_625t") return cardIDEnum.EX1_625t;
            if (s == "EX1_014") return cardIDEnum.EX1_014;
            if (s == "CRED_04") return cardIDEnum.CRED_04;
            if (s == "NAX12_01H") return cardIDEnum.NAX12_01H;
            if (s == "CS2_097") return cardIDEnum.CS2_097;
            if (s == "EX1_558") return cardIDEnum.EX1_558;
            if (s == "XXX_047") return cardIDEnum.XXX_047;
            if (s == "EX1_tk29") return cardIDEnum.EX1_tk29;
            if (s == "CS2_186") return cardIDEnum.CS2_186;
            if (s == "EX1_084") return cardIDEnum.EX1_084;
            if (s == "NEW1_012") return cardIDEnum.NEW1_012;
            if (s == "FP1_014t") return cardIDEnum.FP1_014t;
            if (s == "NAX1_03") return cardIDEnum.NAX1_03;
            if (s == "EX1_623e") return cardIDEnum.EX1_623e;
            if (s == "EX1_578") return cardIDEnum.EX1_578;
            if (s == "CS2_073e2") return cardIDEnum.CS2_073e2;
            if (s == "CS2_221") return cardIDEnum.CS2_221;
            if (s == "EX1_019") return cardIDEnum.EX1_019;
            if (s == "NAX15_04a") return cardIDEnum.NAX15_04a;
            if (s == "FP1_019t") return cardIDEnum.FP1_019t;
            if (s == "EX1_132") return cardIDEnum.EX1_132;
            if (s == "EX1_284") return cardIDEnum.EX1_284;
            if (s == "EX1_105") return cardIDEnum.EX1_105;
            if (s == "NEW1_011") return cardIDEnum.NEW1_011;
            if (s == "NAX9_07e") return cardIDEnum.NAX9_07e;
            if (s == "EX1_017") return cardIDEnum.EX1_017;
            if (s == "EX1_249") return cardIDEnum.EX1_249;
            if (s == "EX1_162o") return cardIDEnum.EX1_162o;
            if (s == "FP1_002t") return cardIDEnum.FP1_002t;
            if (s == "NAX3_02") return cardIDEnum.NAX3_02;
            if (s == "EX1_313") return cardIDEnum.EX1_313;
            if (s == "EX1_549o") return cardIDEnum.EX1_549o;
            if (s == "EX1_091o") return cardIDEnum.EX1_091o;
            if (s == "CS2_084e") return cardIDEnum.CS2_084e;
            if (s == "EX1_155b") return cardIDEnum.EX1_155b;
            if (s == "NAX11_01") return cardIDEnum.NAX11_01;
            if (s == "NEW1_033") return cardIDEnum.NEW1_033;
            if (s == "CS2_106") return cardIDEnum.CS2_106;
            if (s == "XXX_002") return cardIDEnum.XXX_002;
            if (s == "FP1_018") return cardIDEnum.FP1_018;
            if (s == "NEW1_036e2") return cardIDEnum.NEW1_036e2;
            if (s == "XXX_004") return cardIDEnum.XXX_004;
            if (s == "NAX11_02H") return cardIDEnum.NAX11_02H;
            if (s == "CS2_122e") return cardIDEnum.CS2_122e;
            if (s == "DS1_233") return cardIDEnum.DS1_233;
            if (s == "DS1_175") return cardIDEnum.DS1_175;
            if (s == "NEW1_024") return cardIDEnum.NEW1_024;
            if (s == "CS2_189") return cardIDEnum.CS2_189;
            if (s == "CRED_10") return cardIDEnum.CRED_10;
            if (s == "NEW1_037") return cardIDEnum.NEW1_037;
            if (s == "EX1_414") return cardIDEnum.EX1_414;
            if (s == "EX1_538t") return cardIDEnum.EX1_538t;
            if (s == "FP1_030e") return cardIDEnum.FP1_030e;
            if (s == "EX1_586") return cardIDEnum.EX1_586;
            if (s == "EX1_310") return cardIDEnum.EX1_310;
            if (s == "NEW1_010") return cardIDEnum.NEW1_010;
            if (s == "CS2_103e") return cardIDEnum.CS2_103e;
            if (s == "EX1_080o") return cardIDEnum.EX1_080o;
            if (s == "CS2_005o") return cardIDEnum.CS2_005o;
            if (s == "EX1_363e2") return cardIDEnum.EX1_363e2;
            if (s == "EX1_534t") return cardIDEnum.EX1_534t;
            if (s == "FP1_028") return cardIDEnum.FP1_028;
            if (s == "EX1_604") return cardIDEnum.EX1_604;
            if (s == "EX1_160") return cardIDEnum.EX1_160;
            if (s == "EX1_165t1") return cardIDEnum.EX1_165t1;
            if (s == "CS2_062") return cardIDEnum.CS2_062;
            if (s == "CS2_155") return cardIDEnum.CS2_155;
            if (s == "CS2_213") return cardIDEnum.CS2_213;
            if (s == "TU4f_007") return cardIDEnum.TU4f_007;
            if (s == "GAME_004") return cardIDEnum.GAME_004;
            if (s == "NAX5_01") return cardIDEnum.NAX5_01;
            if (s == "XXX_020") return cardIDEnum.XXX_020;
            if (s == "NAX15_02H") return cardIDEnum.NAX15_02H;
            if (s == "CS2_004") return cardIDEnum.CS2_004;
            if (s == "NAX2_03H") return cardIDEnum.NAX2_03H;
            if (s == "EX1_561e") return cardIDEnum.EX1_561e;
            if (s == "CS2_023") return cardIDEnum.CS2_023;
            if (s == "EX1_164") return cardIDEnum.EX1_164;
            if (s == "EX1_009") return cardIDEnum.EX1_009;
            if (s == "NAX6_01") return cardIDEnum.NAX6_01;
            if (s == "FP1_007") return cardIDEnum.FP1_007;
            if (s == "NAX1h_04") return cardIDEnum.NAX1h_04;
            if (s == "NAX2_05H") return cardIDEnum.NAX2_05H;
            if (s == "NAX10_02") return cardIDEnum.NAX10_02;
            if (s == "EX1_345") return cardIDEnum.EX1_345;
            if (s == "EX1_116") return cardIDEnum.EX1_116;
            if (s == "EX1_399") return cardIDEnum.EX1_399;
            if (s == "EX1_587") return cardIDEnum.EX1_587;
            if (s == "XXX_026") return cardIDEnum.XXX_026;
            if (s == "EX1_571") return cardIDEnum.EX1_571;
            if (s == "EX1_335") return cardIDEnum.EX1_335;
            if (s == "XXX_050") return cardIDEnum.XXX_050;
            if (s == "TU4e_004") return cardIDEnum.TU4e_004;
            if (s == "HERO_08") return cardIDEnum.HERO_08;
            if (s == "EX1_166a") return cardIDEnum.EX1_166a;
            if (s == "NAX2_03") return cardIDEnum.NAX2_03;
            if (s == "EX1_finkle") return cardIDEnum.EX1_finkle;
            if (s == "NAX4_03H") return cardIDEnum.NAX4_03H;
            if (s == "EX1_164b") return cardIDEnum.EX1_164b;
            if (s == "EX1_283") return cardIDEnum.EX1_283;
            if (s == "EX1_339") return cardIDEnum.EX1_339;
            if (s == "CRED_13") return cardIDEnum.CRED_13;
            if (s == "EX1_178be") return cardIDEnum.EX1_178be;
            if (s == "EX1_531") return cardIDEnum.EX1_531;
            if (s == "EX1_134") return cardIDEnum.EX1_134;
            if (s == "EX1_350") return cardIDEnum.EX1_350;
            if (s == "EX1_308") return cardIDEnum.EX1_308;
            if (s == "CS2_197") return cardIDEnum.CS2_197;
            if (s == "skele21") return cardIDEnum.skele21;
            if (s == "CS2_222o") return cardIDEnum.CS2_222o;
            if (s == "XXX_015") return cardIDEnum.XXX_015;
            if (s == "FP1_013") return cardIDEnum.FP1_013;
            if (s == "NEW1_006") return cardIDEnum.NEW1_006;
            if (s == "EX1_399e") return cardIDEnum.EX1_399e;
            if (s == "EX1_509") return cardIDEnum.EX1_509;
            if (s == "EX1_612") return cardIDEnum.EX1_612;
            if (s == "NAX8_05t") return cardIDEnum.NAX8_05t;
            if (s == "NAX9_05H") return cardIDEnum.NAX9_05H;
            if (s == "EX1_021") return cardIDEnum.EX1_021;
            if (s == "CS2_041e") return cardIDEnum.CS2_041e;
            if (s == "CS2_226") return cardIDEnum.CS2_226;
            if (s == "EX1_608") return cardIDEnum.EX1_608;
            if (s == "NAX13_05H") return cardIDEnum.NAX13_05H;
            if (s == "NAX13_04H") return cardIDEnum.NAX13_04H;
            if (s == "TU4c_008") return cardIDEnum.TU4c_008;
            if (s == "EX1_624") return cardIDEnum.EX1_624;
            if (s == "EX1_616") return cardIDEnum.EX1_616;
            if (s == "EX1_008") return cardIDEnum.EX1_008;
            if (s == "PlaceholderCard") return cardIDEnum.PlaceholderCard;
            if (s == "XXX_016") return cardIDEnum.XXX_016;
            if (s == "EX1_045") return cardIDEnum.EX1_045;
            if (s == "EX1_015") return cardIDEnum.EX1_015;
            if (s == "GAME_003") return cardIDEnum.GAME_003;
            if (s == "CS2_171") return cardIDEnum.CS2_171;
            if (s == "CS2_041") return cardIDEnum.CS2_041;
            if (s == "EX1_128") return cardIDEnum.EX1_128;
            if (s == "CS2_112") return cardIDEnum.CS2_112;
            if (s == "HERO_07") return cardIDEnum.HERO_07;
            if (s == "EX1_412") return cardIDEnum.EX1_412;
            if (s == "EX1_612o") return cardIDEnum.EX1_612o;
            if (s == "CS2_117") return cardIDEnum.CS2_117;
            if (s == "XXX_009e") return cardIDEnum.XXX_009e;
            if (s == "EX1_562") return cardIDEnum.EX1_562;
            if (s == "EX1_055") return cardIDEnum.EX1_055;
            if (s == "NAX9_06") return cardIDEnum.NAX9_06;
            if (s == "TU4e_007") return cardIDEnum.TU4e_007;
            if (s == "FP1_012") return cardIDEnum.FP1_012;
            if (s == "EX1_317t") return cardIDEnum.EX1_317t;
            if (s == "EX1_004e") return cardIDEnum.EX1_004e;
            if (s == "EX1_278") return cardIDEnum.EX1_278;
            if (s == "CS2_tk1") return cardIDEnum.CS2_tk1;
            if (s == "EX1_590") return cardIDEnum.EX1_590;
            if (s == "CS1_130") return cardIDEnum.CS1_130;
            if (s == "NEW1_008b") return cardIDEnum.NEW1_008b;
            if (s == "EX1_365") return cardIDEnum.EX1_365;
            if (s == "CS2_141") return cardIDEnum.CS2_141;
            if (s == "PRO_001") return cardIDEnum.PRO_001;
            if (s == "NAX8_04t") return cardIDEnum.NAX8_04t;
            if (s == "CS2_173") return cardIDEnum.CS2_173;
            if (s == "CS2_017") return cardIDEnum.CS2_017;
            if (s == "CRED_16") return cardIDEnum.CRED_16;
            if (s == "EX1_392") return cardIDEnum.EX1_392;
            if (s == "EX1_593") return cardIDEnum.EX1_593;
            if (s == "FP1_023e") return cardIDEnum.FP1_023e;
            if (s == "NAX1_05") return cardIDEnum.NAX1_05;
            if (s == "TU4d_002") return cardIDEnum.TU4d_002;
            if (s == "CRED_15") return cardIDEnum.CRED_15;
            if (s == "EX1_049") return cardIDEnum.EX1_049;
            if (s == "EX1_002") return cardIDEnum.EX1_002;
            if (s == "TU4f_005") return cardIDEnum.TU4f_005;
            if (s == "NEW1_029t") return cardIDEnum.NEW1_029t;
            if (s == "TU4a_001") return cardIDEnum.TU4a_001;
            if (s == "CS2_056") return cardIDEnum.CS2_056;
            if (s == "EX1_596") return cardIDEnum.EX1_596;
            if (s == "EX1_136") return cardIDEnum.EX1_136;
            if (s == "EX1_323") return cardIDEnum.EX1_323;
            if (s == "CS2_073") return cardIDEnum.CS2_073;
            if (s == "EX1_246e") return cardIDEnum.EX1_246e;
            if (s == "NAX12_01") return cardIDEnum.NAX12_01;
            if (s == "EX1_244e") return cardIDEnum.EX1_244e;
            if (s == "EX1_001") return cardIDEnum.EX1_001;
            if (s == "EX1_607e") return cardIDEnum.EX1_607e;
            if (s == "EX1_044") return cardIDEnum.EX1_044;
            if (s == "EX1_573ae") return cardIDEnum.EX1_573ae;
            if (s == "XXX_025") return cardIDEnum.XXX_025;
            if (s == "CRED_06") return cardIDEnum.CRED_06;
            if (s == "Mekka4") return cardIDEnum.Mekka4;
            if (s == "CS2_142") return cardIDEnum.CS2_142;
            if (s == "TU4f_004") return cardIDEnum.TU4f_004;
            if (s == "NAX5_02H") return cardIDEnum.NAX5_02H;
            if (s == "EX1_411e2") return cardIDEnum.EX1_411e2;
            if (s == "EX1_573") return cardIDEnum.EX1_573;
            if (s == "FP1_009") return cardIDEnum.FP1_009;
            if (s == "CS2_050") return cardIDEnum.CS2_050;
            if (s == "NAX4_03") return cardIDEnum.NAX4_03;
            if (s == "CS2_063e") return cardIDEnum.CS2_063e;
            if (s == "NAX2_05") return cardIDEnum.NAX2_05;
            if (s == "EX1_390") return cardIDEnum.EX1_390;
            if (s == "EX1_610") return cardIDEnum.EX1_610;
            if (s == "hexfrog") return cardIDEnum.hexfrog;
            if (s == "CS2_181e") return cardIDEnum.CS2_181e;
            if (s == "NAX6_02") return cardIDEnum.NAX6_02;
            if (s == "XXX_027") return cardIDEnum.XXX_027;
            if (s == "CS2_082") return cardIDEnum.CS2_082;
            if (s == "NEW1_040") return cardIDEnum.NEW1_040;
            if (s == "DREAM_01") return cardIDEnum.DREAM_01;
            if (s == "EX1_595") return cardIDEnum.EX1_595;
            if (s == "CS2_013") return cardIDEnum.CS2_013;
            if (s == "CS2_077") return cardIDEnum.CS2_077;
            if (s == "NEW1_014") return cardIDEnum.NEW1_014;
            if (s == "CRED_05") return cardIDEnum.CRED_05;
            if (s == "GAME_002") return cardIDEnum.GAME_002;
            if (s == "EX1_165") return cardIDEnum.EX1_165;
            if (s == "CS2_013t") return cardIDEnum.CS2_013t;
            if (s == "NAX4_04H") return cardIDEnum.NAX4_04H;
            if (s == "EX1_tk11") return cardIDEnum.EX1_tk11;
            if (s == "EX1_591") return cardIDEnum.EX1_591;
            if (s == "EX1_549") return cardIDEnum.EX1_549;
            if (s == "CS2_045") return cardIDEnum.CS2_045;
            if (s == "CS2_237") return cardIDEnum.CS2_237;
            if (s == "CS2_027") return cardIDEnum.CS2_027;
            if (s == "EX1_508o") return cardIDEnum.EX1_508o;
            if (s == "NAX14_03") return cardIDEnum.NAX14_03;
            if (s == "CS2_101t") return cardIDEnum.CS2_101t;
            if (s == "CS2_063") return cardIDEnum.CS2_063;
            if (s == "EX1_145") return cardIDEnum.EX1_145;
            if (s == "NAX1h_03") return cardIDEnum.NAX1h_03;
            if (s == "EX1_110") return cardIDEnum.EX1_110;
            if (s == "EX1_408") return cardIDEnum.EX1_408;
            if (s == "EX1_544") return cardIDEnum.EX1_544;
            if (s == "TU4c_006") return cardIDEnum.TU4c_006;
            if (s == "NAXM_001") return cardIDEnum.NAXM_001;
            if (s == "CS2_151") return cardIDEnum.CS2_151;
            if (s == "CS2_073e") return cardIDEnum.CS2_073e;
            if (s == "XXX_006") return cardIDEnum.XXX_006;
            if (s == "CS2_088") return cardIDEnum.CS2_088;
            if (s == "EX1_057") return cardIDEnum.EX1_057;
            if (s == "FP1_020") return cardIDEnum.FP1_020;
            if (s == "CS2_169") return cardIDEnum.CS2_169;
            if (s == "EX1_573t") return cardIDEnum.EX1_573t;
            if (s == "EX1_323h") return cardIDEnum.EX1_323h;
            if (s == "EX1_tk9") return cardIDEnum.EX1_tk9;
            if (s == "NEW1_018e") return cardIDEnum.NEW1_018e;
            if (s == "CS2_037") return cardIDEnum.CS2_037;
            if (s == "CS2_007") return cardIDEnum.CS2_007;
            if (s == "EX1_059e2") return cardIDEnum.EX1_059e2;
            if (s == "CS2_227") return cardIDEnum.CS2_227;
            if (s == "NAX7_03H") return cardIDEnum.NAX7_03H;
            if (s == "NAX9_01H") return cardIDEnum.NAX9_01H;
            if (s == "EX1_570e") return cardIDEnum.EX1_570e;
            if (s == "NEW1_003") return cardIDEnum.NEW1_003;
            if (s == "GAME_006") return cardIDEnum.GAME_006;
            if (s == "EX1_320") return cardIDEnum.EX1_320;
            if (s == "EX1_097") return cardIDEnum.EX1_097;
            if (s == "tt_004") return cardIDEnum.tt_004;
            if (s == "EX1_360e") return cardIDEnum.EX1_360e;
            if (s == "EX1_096") return cardIDEnum.EX1_096;
            if (s == "DS1_175o") return cardIDEnum.DS1_175o;
            if (s == "EX1_596e") return cardIDEnum.EX1_596e;
            if (s == "XXX_014") return cardIDEnum.XXX_014;
            if (s == "EX1_158e") return cardIDEnum.EX1_158e;
            if (s == "NAX14_01") return cardIDEnum.NAX14_01;
            if (s == "CRED_01") return cardIDEnum.CRED_01;
            if (s == "CRED_08") return cardIDEnum.CRED_08;
            if (s == "EX1_126") return cardIDEnum.EX1_126;
            if (s == "EX1_577") return cardIDEnum.EX1_577;
            if (s == "EX1_319") return cardIDEnum.EX1_319;
            if (s == "EX1_611") return cardIDEnum.EX1_611;
            if (s == "CS2_146") return cardIDEnum.CS2_146;
            if (s == "EX1_154b") return cardIDEnum.EX1_154b;
            if (s == "skele11") return cardIDEnum.skele11;
            if (s == "EX1_165t2") return cardIDEnum.EX1_165t2;
            if (s == "CS2_172") return cardIDEnum.CS2_172;
            if (s == "CS2_114") return cardIDEnum.CS2_114;
            if (s == "CS1_069") return cardIDEnum.CS1_069;
            if (s == "XXX_003") return cardIDEnum.XXX_003;
            if (s == "XXX_042") return cardIDEnum.XXX_042;
            if (s == "NAX8_02") return cardIDEnum.NAX8_02;
            if (s == "EX1_173") return cardIDEnum.EX1_173;
            if (s == "CS1_042") return cardIDEnum.CS1_042;
            if (s == "NAX8_03") return cardIDEnum.NAX8_03;
            if (s == "EX1_506a") return cardIDEnum.EX1_506a;
            if (s == "EX1_298") return cardIDEnum.EX1_298;
            if (s == "CS2_104") return cardIDEnum.CS2_104;
            if (s == "FP1_001") return cardIDEnum.FP1_001;
            if (s == "HERO_02") return cardIDEnum.HERO_02;
            if (s == "EX1_316e") return cardIDEnum.EX1_316e;
            if (s == "NAX7_01") return cardIDEnum.NAX7_01;
            if (s == "EX1_044e") return cardIDEnum.EX1_044e;
            if (s == "CS2_051") return cardIDEnum.CS2_051;
            if (s == "NEW1_016") return cardIDEnum.NEW1_016;
            if (s == "EX1_304e") return cardIDEnum.EX1_304e;
            if (s == "EX1_033") return cardIDEnum.EX1_033;
            if (s == "NAX8_04") return cardIDEnum.NAX8_04;
            if (s == "EX1_028") return cardIDEnum.EX1_028;
            if (s == "XXX_011") return cardIDEnum.XXX_011;
            if (s == "EX1_621") return cardIDEnum.EX1_621;
            if (s == "EX1_554") return cardIDEnum.EX1_554;
            if (s == "EX1_091") return cardIDEnum.EX1_091;
            if (s == "FP1_017") return cardIDEnum.FP1_017;
            if (s == "EX1_409") return cardIDEnum.EX1_409;
            if (s == "EX1_363e") return cardIDEnum.EX1_363e;
            if (s == "EX1_410") return cardIDEnum.EX1_410;
            if (s == "TU4e_005") return cardIDEnum.TU4e_005;
            if (s == "CS2_039") return cardIDEnum.CS2_039;
            if (s == "NAX12_04") return cardIDEnum.NAX12_04;
            if (s == "EX1_557") return cardIDEnum.EX1_557;
            if (s == "CS2_105e") return cardIDEnum.CS2_105e;
            if (s == "EX1_128e") return cardIDEnum.EX1_128e;
            if (s == "XXX_021") return cardIDEnum.XXX_021;
            if (s == "DS1_070") return cardIDEnum.DS1_070;
            if (s == "CS2_033") return cardIDEnum.CS2_033;
            if (s == "EX1_536") return cardIDEnum.EX1_536;
            if (s == "TU4a_003") return cardIDEnum.TU4a_003;
            if (s == "EX1_559") return cardIDEnum.EX1_559;
            if (s == "XXX_023") return cardIDEnum.XXX_023;
            if (s == "NEW1_033o") return cardIDEnum.NEW1_033o;
            if (s == "NAX15_04H") return cardIDEnum.NAX15_04H;
            if (s == "CS2_004e") return cardIDEnum.CS2_004e;
            if (s == "CS2_052") return cardIDEnum.CS2_052;
            if (s == "EX1_539") return cardIDEnum.EX1_539;
            if (s == "EX1_575") return cardIDEnum.EX1_575;
            if (s == "CS2_083b") return cardIDEnum.CS2_083b;
            if (s == "CS2_061") return cardIDEnum.CS2_061;
            if (s == "NEW1_021") return cardIDEnum.NEW1_021;
            if (s == "DS1_055") return cardIDEnum.DS1_055;
            if (s == "EX1_625") return cardIDEnum.EX1_625;
            if (s == "EX1_382e") return cardIDEnum.EX1_382e;
            if (s == "CS2_092e") return cardIDEnum.CS2_092e;
            if (s == "CS2_026") return cardIDEnum.CS2_026;
            if (s == "NAX14_04") return cardIDEnum.NAX14_04;
            if (s == "NEW1_012o") return cardIDEnum.NEW1_012o;
            if (s == "EX1_619e") return cardIDEnum.EX1_619e;
            if (s == "EX1_294") return cardIDEnum.EX1_294;
            if (s == "EX1_287") return cardIDEnum.EX1_287;
            if (s == "EX1_509e") return cardIDEnum.EX1_509e;
            if (s == "EX1_625t2") return cardIDEnum.EX1_625t2;
            if (s == "CS2_118") return cardIDEnum.CS2_118;
            if (s == "CS2_124") return cardIDEnum.CS2_124;
            if (s == "Mekka3") return cardIDEnum.Mekka3;
            if (s == "NAX13_02") return cardIDEnum.NAX13_02;
            if (s == "EX1_112") return cardIDEnum.EX1_112;
            if (s == "FP1_011") return cardIDEnum.FP1_011;
            if (s == "CS2_009e") return cardIDEnum.CS2_009e;
            if (s == "HERO_04") return cardIDEnum.HERO_04;
            if (s == "EX1_607") return cardIDEnum.EX1_607;
            if (s == "DREAM_03") return cardIDEnum.DREAM_03;
            if (s == "NAX11_04e") return cardIDEnum.NAX11_04e;
            if (s == "EX1_103e") return cardIDEnum.EX1_103e;
            if (s == "XXX_046") return cardIDEnum.XXX_046;
            if (s == "FP1_003") return cardIDEnum.FP1_003;
            if (s == "CS2_105") return cardIDEnum.CS2_105;
            if (s == "FP1_002") return cardIDEnum.FP1_002;
            if (s == "TU4c_002") return cardIDEnum.TU4c_002;
            if (s == "CRED_14") return cardIDEnum.CRED_14;
            if (s == "EX1_567") return cardIDEnum.EX1_567;
            if (s == "TU4c_004") return cardIDEnum.TU4c_004;
            if (s == "NAX10_03H") return cardIDEnum.NAX10_03H;
            if (s == "FP1_008") return cardIDEnum.FP1_008;
            if (s == "DS1_184") return cardIDEnum.DS1_184;
            if (s == "CS2_029") return cardIDEnum.CS2_029;
            if (s == "GAME_005") return cardIDEnum.GAME_005;
            if (s == "CS2_187") return cardIDEnum.CS2_187;
            if (s == "EX1_020") return cardIDEnum.EX1_020;
            if (s == "NAX15_01He") return cardIDEnum.NAX15_01He;
            if (s == "EX1_011") return cardIDEnum.EX1_011;
            if (s == "CS2_057") return cardIDEnum.CS2_057;
            if (s == "EX1_274") return cardIDEnum.EX1_274;
            if (s == "EX1_306") return cardIDEnum.EX1_306;
            if (s == "NEW1_038o") return cardIDEnum.NEW1_038o;
            if (s == "EX1_170") return cardIDEnum.EX1_170;
            if (s == "EX1_617") return cardIDEnum.EX1_617;
            if (s == "CS1_113e") return cardIDEnum.CS1_113e;
            if (s == "CS2_101") return cardIDEnum.CS2_101;
            if (s == "FP1_015") return cardIDEnum.FP1_015;
            if (s == "NAX13_03") return cardIDEnum.NAX13_03;
            if (s == "CS2_005") return cardIDEnum.CS2_005;
            if (s == "EX1_537") return cardIDEnum.EX1_537;
            if (s == "EX1_384") return cardIDEnum.EX1_384;
            if (s == "TU4a_002") return cardIDEnum.TU4a_002;
            if (s == "NAX9_04") return cardIDEnum.NAX9_04;
            if (s == "EX1_362") return cardIDEnum.EX1_362;
            if (s == "NAX12_02") return cardIDEnum.NAX12_02;
            if (s == "FP1_028e") return cardIDEnum.FP1_028e;
            if (s == "TU4c_005") return cardIDEnum.TU4c_005;
            if (s == "EX1_301") return cardIDEnum.EX1_301;
            if (s == "CS2_235") return cardIDEnum.CS2_235;
            if (s == "NAX4_05") return cardIDEnum.NAX4_05;
            if (s == "EX1_029") return cardIDEnum.EX1_029;
            if (s == "CS2_042") return cardIDEnum.CS2_042;
            if (s == "EX1_155a") return cardIDEnum.EX1_155a;
            if (s == "CS2_102") return cardIDEnum.CS2_102;
            if (s == "EX1_609") return cardIDEnum.EX1_609;
            if (s == "NEW1_027") return cardIDEnum.NEW1_027;
            if (s == "CS2_236e") return cardIDEnum.CS2_236e;
            if (s == "CS2_083e") return cardIDEnum.CS2_083e;
            if (s == "NAX6_03te") return cardIDEnum.NAX6_03te;
            if (s == "EX1_165a") return cardIDEnum.EX1_165a;
            if (s == "EX1_570") return cardIDEnum.EX1_570;
            if (s == "EX1_131") return cardIDEnum.EX1_131;
            if (s == "EX1_556") return cardIDEnum.EX1_556;
            if (s == "EX1_543") return cardIDEnum.EX1_543;
            if (s == "XXX_096") return cardIDEnum.XXX_096;
            if (s == "TU4c_008e") return cardIDEnum.TU4c_008e;
            if (s == "EX1_379e") return cardIDEnum.EX1_379e;
            if (s == "NEW1_009") return cardIDEnum.NEW1_009;
            if (s == "EX1_100") return cardIDEnum.EX1_100;
            if (s == "EX1_274e") return cardIDEnum.EX1_274e;
            if (s == "CRED_02") return cardIDEnum.CRED_02;
            if (s == "EX1_573a") return cardIDEnum.EX1_573a;
            if (s == "CS2_084") return cardIDEnum.CS2_084;
            if (s == "EX1_582") return cardIDEnum.EX1_582;
            if (s == "EX1_043") return cardIDEnum.EX1_043;
            if (s == "EX1_050") return cardIDEnum.EX1_050;
            if (s == "TU4b_001") return cardIDEnum.TU4b_001;
            if (s == "FP1_005") return cardIDEnum.FP1_005;
            if (s == "EX1_620") return cardIDEnum.EX1_620;
            if (s == "NAX15_01") return cardIDEnum.NAX15_01;
            if (s == "NAX6_03") return cardIDEnum.NAX6_03;
            if (s == "EX1_303") return cardIDEnum.EX1_303;
            if (s == "HERO_09") return cardIDEnum.HERO_09;
            if (s == "EX1_067") return cardIDEnum.EX1_067;
            if (s == "XXX_028") return cardIDEnum.XXX_028;
            if (s == "EX1_277") return cardIDEnum.EX1_277;
            if (s == "Mekka2") return cardIDEnum.Mekka2;
            if (s == "NAX14_01H") return cardIDEnum.NAX14_01H;
            if (s == "NAX15_04") return cardIDEnum.NAX15_04;
            if (s == "FP1_024") return cardIDEnum.FP1_024;
            if (s == "FP1_030") return cardIDEnum.FP1_030;
            if (s == "CS2_221e") return cardIDEnum.CS2_221e;
            if (s == "EX1_178") return cardIDEnum.EX1_178;
            if (s == "CS2_222") return cardIDEnum.CS2_222;
            if (s == "EX1_409e") return cardIDEnum.EX1_409e;
            if (s == "tt_004o") return cardIDEnum.tt_004o;
            if (s == "EX1_155ae") return cardIDEnum.EX1_155ae;
            if (s == "NAX11_01H") return cardIDEnum.NAX11_01H;
            if (s == "EX1_160a") return cardIDEnum.EX1_160a;
            if (s == "NAX15_02") return cardIDEnum.NAX15_02;
            if (s == "NAX15_05") return cardIDEnum.NAX15_05;
            if (s == "NEW1_025e") return cardIDEnum.NEW1_025e;
            if (s == "CS2_012") return cardIDEnum.CS2_012;
            if (s == "XXX_099") return cardIDEnum.XXX_099;
            if (s == "EX1_246") return cardIDEnum.EX1_246;
            if (s == "EX1_572") return cardIDEnum.EX1_572;
            if (s == "EX1_089") return cardIDEnum.EX1_089;
            if (s == "CS2_059") return cardIDEnum.CS2_059;
            if (s == "EX1_279") return cardIDEnum.EX1_279;
            if (s == "NAX12_02e") return cardIDEnum.NAX12_02e;
            if (s == "CS2_168") return cardIDEnum.CS2_168;
            if (s == "tt_010") return cardIDEnum.tt_010;
            if (s == "NEW1_023") return cardIDEnum.NEW1_023;
            if (s == "CS2_075") return cardIDEnum.CS2_075;
            if (s == "EX1_316") return cardIDEnum.EX1_316;
            if (s == "CS2_025") return cardIDEnum.CS2_025;
            if (s == "CS2_234") return cardIDEnum.CS2_234;
            if (s == "XXX_043") return cardIDEnum.XXX_043;
            if (s == "GAME_001") return cardIDEnum.GAME_001;
            if (s == "NAX5_02") return cardIDEnum.NAX5_02;
            if (s == "EX1_130") return cardIDEnum.EX1_130;
            if (s == "EX1_584e") return cardIDEnum.EX1_584e;
            if (s == "CS2_064") return cardIDEnum.CS2_064;
            if (s == "EX1_161") return cardIDEnum.EX1_161;
            if (s == "CS2_049") return cardIDEnum.CS2_049;
            if (s == "NAX13_01") return cardIDEnum.NAX13_01;
            if (s == "EX1_154") return cardIDEnum.EX1_154;
            if (s == "EX1_080") return cardIDEnum.EX1_080;
            if (s == "NEW1_022") return cardIDEnum.NEW1_022;
            if (s == "NAX2_01H") return cardIDEnum.NAX2_01H;
            if (s == "EX1_160be") return cardIDEnum.EX1_160be;
            if (s == "NAX12_03") return cardIDEnum.NAX12_03;
            if (s == "EX1_251") return cardIDEnum.EX1_251;
            if (s == "FP1_025") return cardIDEnum.FP1_025;
            if (s == "EX1_371") return cardIDEnum.EX1_371;
            if (s == "CS2_mirror") return cardIDEnum.CS2_mirror;
            if (s == "NAX4_01H") return cardIDEnum.NAX4_01H;
            if (s == "EX1_594") return cardIDEnum.EX1_594;
            if (s == "NAX14_02") return cardIDEnum.NAX14_02;
            if (s == "TU4c_006e") return cardIDEnum.TU4c_006e;
            if (s == "EX1_560") return cardIDEnum.EX1_560;
            if (s == "CS2_236") return cardIDEnum.CS2_236;
            if (s == "TU4f_006") return cardIDEnum.TU4f_006;
            if (s == "EX1_402") return cardIDEnum.EX1_402;
            if (s == "NAX3_01") return cardIDEnum.NAX3_01;
            if (s == "EX1_506") return cardIDEnum.EX1_506;
            if (s == "NEW1_027e") return cardIDEnum.NEW1_027e;
            if (s == "DS1_070o") return cardIDEnum.DS1_070o;
            if (s == "XXX_045") return cardIDEnum.XXX_045;
            if (s == "XXX_029") return cardIDEnum.XXX_029;
            if (s == "DS1_178") return cardIDEnum.DS1_178;
            if (s == "XXX_098") return cardIDEnum.XXX_098;
            if (s == "EX1_315") return cardIDEnum.EX1_315;
            if (s == "CS2_094") return cardIDEnum.CS2_094;
            if (s == "NAX13_01H") return cardIDEnum.NAX13_01H;
            if (s == "TU4e_002t") return cardIDEnum.TU4e_002t;
            if (s == "EX1_046e") return cardIDEnum.EX1_046e;
            if (s == "NEW1_040t") return cardIDEnum.NEW1_040t;
            if (s == "GAME_005e") return cardIDEnum.GAME_005e;
            if (s == "CS2_131") return cardIDEnum.CS2_131;
            if (s == "XXX_008") return cardIDEnum.XXX_008;
            if (s == "EX1_531e") return cardIDEnum.EX1_531e;
            if (s == "CS2_226e") return cardIDEnum.CS2_226e;
            if (s == "XXX_022e") return cardIDEnum.XXX_022e;
            if (s == "DS1_178e") return cardIDEnum.DS1_178e;
            if (s == "CS2_226o") return cardIDEnum.CS2_226o;
            if (s == "NAX9_04H") return cardIDEnum.NAX9_04H;
            if (s == "Mekka4e") return cardIDEnum.Mekka4e;
            if (s == "EX1_082") return cardIDEnum.EX1_082;
            if (s == "CS2_093") return cardIDEnum.CS2_093;
            if (s == "EX1_411e") return cardIDEnum.EX1_411e;
            if (s == "NAX8_03t") return cardIDEnum.NAX8_03t;
            if (s == "EX1_145o") return cardIDEnum.EX1_145o;
            if (s == "NAX7_04") return cardIDEnum.NAX7_04;
            if (s == "CS2_boar") return cardIDEnum.CS2_boar;
            if (s == "NEW1_019") return cardIDEnum.NEW1_019;
            if (s == "EX1_289") return cardIDEnum.EX1_289;
            if (s == "EX1_025t") return cardIDEnum.EX1_025t;
            if (s == "EX1_398t") return cardIDEnum.EX1_398t;
            if (s == "NAX12_03H") return cardIDEnum.NAX12_03H;
            if (s == "EX1_055o") return cardIDEnum.EX1_055o;
            if (s == "CS2_091") return cardIDEnum.CS2_091;
            if (s == "EX1_241") return cardIDEnum.EX1_241;
            if (s == "EX1_085") return cardIDEnum.EX1_085;
            if (s == "CS2_200") return cardIDEnum.CS2_200;
            if (s == "CS2_034") return cardIDEnum.CS2_034;
            if (s == "EX1_583") return cardIDEnum.EX1_583;
            if (s == "EX1_584") return cardIDEnum.EX1_584;
            if (s == "EX1_155") return cardIDEnum.EX1_155;
            if (s == "EX1_622") return cardIDEnum.EX1_622;
            if (s == "CS2_203") return cardIDEnum.CS2_203;
            if (s == "EX1_124") return cardIDEnum.EX1_124;
            if (s == "EX1_379") return cardIDEnum.EX1_379;
            if (s == "NAX7_02") return cardIDEnum.NAX7_02;
            if (s == "CS2_053e") return cardIDEnum.CS2_053e;
            if (s == "EX1_032") return cardIDEnum.EX1_032;
            if (s == "NAX9_01") return cardIDEnum.NAX9_01;
            if (s == "TU4e_003") return cardIDEnum.TU4e_003;
            if (s == "CS2_146o") return cardIDEnum.CS2_146o;
            if (s == "NAX8_01H") return cardIDEnum.NAX8_01H;
            if (s == "XXX_041") return cardIDEnum.XXX_041;
            if (s == "NAXM_002") return cardIDEnum.NAXM_002;
            if (s == "EX1_391") return cardIDEnum.EX1_391;
            if (s == "EX1_366") return cardIDEnum.EX1_366;
            if (s == "EX1_059e") return cardIDEnum.EX1_059e;
            if (s == "XXX_012") return cardIDEnum.XXX_012;
            if (s == "EX1_565o") return cardIDEnum.EX1_565o;
            if (s == "EX1_001e") return cardIDEnum.EX1_001e;
            if (s == "TU4f_003") return cardIDEnum.TU4f_003;
            if (s == "EX1_400") return cardIDEnum.EX1_400;
            if (s == "EX1_614") return cardIDEnum.EX1_614;
            if (s == "EX1_561") return cardIDEnum.EX1_561;
            if (s == "EX1_332") return cardIDEnum.EX1_332;
            if (s == "HERO_05") return cardIDEnum.HERO_05;
            if (s == "CS2_065") return cardIDEnum.CS2_065;
            if (s == "ds1_whelptoken") return cardIDEnum.ds1_whelptoken;
            if (s == "EX1_536e") return cardIDEnum.EX1_536e;
            if (s == "CS2_032") return cardIDEnum.CS2_032;
            if (s == "CS2_120") return cardIDEnum.CS2_120;
            if (s == "EX1_155be") return cardIDEnum.EX1_155be;
            if (s == "EX1_247") return cardIDEnum.EX1_247;
            if (s == "EX1_154a") return cardIDEnum.EX1_154a;
            if (s == "EX1_554t") return cardIDEnum.EX1_554t;
            if (s == "CS2_103e2") return cardIDEnum.CS2_103e2;
            if (s == "TU4d_003") return cardIDEnum.TU4d_003;
            if (s == "NEW1_026t") return cardIDEnum.NEW1_026t;
            if (s == "EX1_623") return cardIDEnum.EX1_623;
            if (s == "EX1_383t") return cardIDEnum.EX1_383t;
            if (s == "NAX7_03") return cardIDEnum.NAX7_03;
            if (s == "EX1_597") return cardIDEnum.EX1_597;
            if (s == "TU4f_006o") return cardIDEnum.TU4f_006o;
            if (s == "EX1_130a") return cardIDEnum.EX1_130a;
            if (s == "CS2_011") return cardIDEnum.CS2_011;
            if (s == "EX1_169") return cardIDEnum.EX1_169;
            if (s == "EX1_tk33") return cardIDEnum.EX1_tk33;
            if (s == "NAX11_03") return cardIDEnum.NAX11_03;
            if (s == "NAX4_01") return cardIDEnum.NAX4_01;
            if (s == "NAX10_01") return cardIDEnum.NAX10_01;
            if (s == "EX1_250") return cardIDEnum.EX1_250;
            if (s == "EX1_564") return cardIDEnum.EX1_564;
            if (s == "NAX5_03") return cardIDEnum.NAX5_03;
            if (s == "EX1_043e") return cardIDEnum.EX1_043e;
            if (s == "EX1_349") return cardIDEnum.EX1_349;
            if (s == "XXX_097") return cardIDEnum.XXX_097;
            if (s == "EX1_102") return cardIDEnum.EX1_102;
            if (s == "EX1_058") return cardIDEnum.EX1_058;
            if (s == "EX1_243") return cardIDEnum.EX1_243;
            if (s == "PRO_001c") return cardIDEnum.PRO_001c;
            if (s == "EX1_116t") return cardIDEnum.EX1_116t;
            if (s == "NAX15_01e") return cardIDEnum.NAX15_01e;
            if (s == "FP1_029") return cardIDEnum.FP1_029;
            if (s == "CS2_089") return cardIDEnum.CS2_089;
            if (s == "TU4c_001") return cardIDEnum.TU4c_001;
            if (s == "EX1_248") return cardIDEnum.EX1_248;
            if (s == "NEW1_037e") return cardIDEnum.NEW1_037e;
            if (s == "CS2_122") return cardIDEnum.CS2_122;
            if (s == "EX1_393") return cardIDEnum.EX1_393;
            if (s == "CS2_232") return cardIDEnum.CS2_232;
            if (s == "EX1_165b") return cardIDEnum.EX1_165b;
            if (s == "NEW1_030") return cardIDEnum.NEW1_030;
            if (s == "EX1_161o") return cardIDEnum.EX1_161o;
            if (s == "EX1_093e") return cardIDEnum.EX1_093e;
            if (s == "CS2_150") return cardIDEnum.CS2_150;
            if (s == "CS2_152") return cardIDEnum.CS2_152;
            if (s == "NAX9_03H") return cardIDEnum.NAX9_03H;
            if (s == "EX1_160t") return cardIDEnum.EX1_160t;
            if (s == "CS2_127") return cardIDEnum.CS2_127;
            if (s == "CRED_03") return cardIDEnum.CRED_03;
            if (s == "DS1_188") return cardIDEnum.DS1_188;
            if (s == "XXX_001") return cardIDEnum.XXX_001;
            return cardIDEnum.None;
        }

        /// <summary>
        /// The card name.
        /// </summary>
        public enum cardName
        {
            /// <summary>
            /// The unknown.
            /// </summary>
            unknown, 

            /// <summary>
            /// The hogger.
            /// </summary>
            hogger, 

            /// <summary>
            /// The heigantheunclean.
            /// </summary>
            heigantheunclean, 

            /// <summary>
            /// The necroticaura.
            /// </summary>
            necroticaura, 

            /// <summary>
            /// The starfall.
            /// </summary>
            starfall, 

            /// <summary>
            /// The barrel.
            /// </summary>
            barrel, 

            /// <summary>
            /// The damagereflector.
            /// </summary>
            damagereflector, 

            /// <summary>
            /// The edwinvancleef.
            /// </summary>
            edwinvancleef, 

            /// <summary>
            /// The gothiktheharvester.
            /// </summary>
            gothiktheharvester, 

            /// <summary>
            /// The perditionsblade.
            /// </summary>
            perditionsblade, 

            /// <summary>
            /// The bloodsailraider.
            /// </summary>
            bloodsailraider, 

            /// <summary>
            /// The guardianoficecrown.
            /// </summary>
            guardianoficecrown, 

            /// <summary>
            /// The bloodmagethalnos.
            /// </summary>
            bloodmagethalnos, 

            /// <summary>
            /// The rooted.
            /// </summary>
            rooted, 

            /// <summary>
            /// The wisp.
            /// </summary>
            wisp, 

            /// <summary>
            /// The rachelledavis.
            /// </summary>
            rachelledavis, 

            /// <summary>
            /// The senjinshieldmasta.
            /// </summary>
            senjinshieldmasta, 

            /// <summary>
            /// The totemicmight.
            /// </summary>
            totemicmight, 

            /// <summary>
            /// The uproot.
            /// </summary>
            uproot, 

            /// <summary>
            /// The opponentdisconnect.
            /// </summary>
            opponentdisconnect, 

            /// <summary>
            /// The unrelentingrider.
            /// </summary>
            unrelentingrider, 

            /// <summary>
            /// The shandoslesson.
            /// </summary>
            shandoslesson, 

            /// <summary>
            /// The hemetnesingwary.
            /// </summary>
            hemetnesingwary, 

            /// <summary>
            /// The decimate.
            /// </summary>
            decimate, 

            /// <summary>
            /// The shadowofnothing.
            /// </summary>
            shadowofnothing, 

            /// <summary>
            /// The nerubian.
            /// </summary>
            nerubian, 

            /// <summary>
            /// The dragonlingmechanic.
            /// </summary>
            dragonlingmechanic, 

            /// <summary>
            /// The mogushanwarden.
            /// </summary>
            mogushanwarden, 

            /// <summary>
            /// The thanekorthazz.
            /// </summary>
            thanekorthazz, 

            /// <summary>
            /// The hungrycrab.
            /// </summary>
            hungrycrab, 

            /// <summary>
            /// The ancientteachings.
            /// </summary>
            ancientteachings, 

            /// <summary>
            /// The misdirection.
            /// </summary>
            misdirection, 

            /// <summary>
            /// The patientassassin.
            /// </summary>
            patientassassin, 

            /// <summary>
            /// The mutatinginjection.
            /// </summary>
            mutatinginjection, 

            /// <summary>
            /// The violetteacher.
            /// </summary>
            violetteacher, 

            /// <summary>
            /// The arathiweaponsmith.
            /// </summary>
            arathiweaponsmith, 

            /// <summary>
            /// The raisedead.
            /// </summary>
            raisedead, 

            /// <summary>
            /// The acolyteofpain.
            /// </summary>
            acolyteofpain, 

            /// <summary>
            /// The holynova.
            /// </summary>
            holynova, 

            /// <summary>
            /// The robpardo.
            /// </summary>
            robpardo, 

            /// <summary>
            /// The commandingshout.
            /// </summary>
            commandingshout, 

            /// <summary>
            /// The necroticpoison.
            /// </summary>
            necroticpoison, 

            /// <summary>
            /// The unboundelemental.
            /// </summary>
            unboundelemental, 

            /// <summary>
            /// The garroshhellscream.
            /// </summary>
            garroshhellscream, 

            /// <summary>
            /// The enchant.
            /// </summary>
            enchant, 

            /// <summary>
            /// The loatheb.
            /// </summary>
            loatheb, 

            /// <summary>
            /// The blessingofmight.
            /// </summary>
            blessingofmight, 

            /// <summary>
            /// The nightmare.
            /// </summary>
            nightmare, 

            /// <summary>
            /// The blessingofkings.
            /// </summary>
            blessingofkings, 

            /// <summary>
            /// The polymorph.
            /// </summary>
            polymorph, 

            /// <summary>
            /// The darkirondwarf.
            /// </summary>
            darkirondwarf, 

            /// <summary>
            /// The destroy.
            /// </summary>
            destroy, 

            /// <summary>
            /// The roguesdoit.
            /// </summary>
            roguesdoit, 

            /// <summary>
            /// The freecards.
            /// </summary>
            freecards, 

            /// <summary>
            /// The iammurloc.
            /// </summary>
            iammurloc, 

            /// <summary>
            /// The sporeburst.
            /// </summary>
            sporeburst, 

            /// <summary>
            /// The mindcontrolcrystal.
            /// </summary>
            mindcontrolcrystal, 

            /// <summary>
            /// The charge.
            /// </summary>
            charge, 

            /// <summary>
            /// The stampedingkodo.
            /// </summary>
            stampedingkodo, 

            /// <summary>
            /// The humility.
            /// </summary>
            humility, 

            /// <summary>
            /// The darkcultist.
            /// </summary>
            darkcultist, 

            /// <summary>
            /// The gruul.
            /// </summary>
            gruul, 

            /// <summary>
            /// The markofthewild.
            /// </summary>
            markofthewild, 

            /// <summary>
            /// The patchwerk.
            /// </summary>
            patchwerk, 

            /// <summary>
            /// The worgeninfiltrator.
            /// </summary>
            worgeninfiltrator, 

            /// <summary>
            /// The frostbolt.
            /// </summary>
            frostbolt, 

            /// <summary>
            /// The runeblade.
            /// </summary>
            runeblade, 

            /// <summary>
            /// The flametonguetotem.
            /// </summary>
            flametonguetotem, 

            /// <summary>
            /// The assassinate.
            /// </summary>
            assassinate, 

            /// <summary>
            /// The madscientist.
            /// </summary>
            madscientist, 

            /// <summary>
            /// The lordofthearena.
            /// </summary>
            lordofthearena, 

            /// <summary>
            /// The bainebloodhoof.
            /// </summary>
            bainebloodhoof, 

            /// <summary>
            /// The injuredblademaster.
            /// </summary>
            injuredblademaster, 

            /// <summary>
            /// The siphonsoul.
            /// </summary>
            siphonsoul, 

            /// <summary>
            /// The layonhands.
            /// </summary>
            layonhands, 

            /// <summary>
            /// The hook.
            /// </summary>
            hook, 

            /// <summary>
            /// The massiveruneblade.
            /// </summary>
            massiveruneblade, 

            /// <summary>
            /// The lorewalkercho.
            /// </summary>
            lorewalkercho, 

            /// <summary>
            /// The destroyallminions.
            /// </summary>
            destroyallminions, 

            /// <summary>
            /// The silvermoonguardian.
            /// </summary>
            silvermoonguardian, 

            /// <summary>
            /// The destroyallmana.
            /// </summary>
            destroyallmana, 

            /// <summary>
            /// The huffer.
            /// </summary>
            huffer, 

            /// <summary>
            /// The mindvision.
            /// </summary>
            mindvision, 

            /// <summary>
            /// The malfurionstormrage.
            /// </summary>
            malfurionstormrage, 

            /// <summary>
            /// The corehound.
            /// </summary>
            corehound, 

            /// <summary>
            /// The grimscaleoracle.
            /// </summary>
            grimscaleoracle, 

            /// <summary>
            /// The lightningstorm.
            /// </summary>
            lightningstorm, 

            /// <summary>
            /// The lightwell.
            /// </summary>
            lightwell, 

            /// <summary>
            /// The benthompson.
            /// </summary>
            benthompson, 

            /// <summary>
            /// The coldlightseer.
            /// </summary>
            coldlightseer, 

            /// <summary>
            /// The deathsbite.
            /// </summary>
            deathsbite, 

            /// <summary>
            /// The gorehowl.
            /// </summary>
            gorehowl, 

            /// <summary>
            /// The skitter.
            /// </summary>
            skitter, 

            /// <summary>
            /// The farsight.
            /// </summary>
            farsight, 

            /// <summary>
            /// The chillwindyeti.
            /// </summary>
            chillwindyeti, 

            /// <summary>
            /// The moonfire.
            /// </summary>
            moonfire, 

            /// <summary>
            /// The bladeflurry.
            /// </summary>
            bladeflurry, 

            /// <summary>
            /// The massdispel.
            /// </summary>
            massdispel, 

            /// <summary>
            /// The crazedalchemist.
            /// </summary>
            crazedalchemist, 

            /// <summary>
            /// The shadowmadness.
            /// </summary>
            shadowmadness, 

            /// <summary>
            /// The equality.
            /// </summary>
            equality, 

            /// <summary>
            /// The misha.
            /// </summary>
            misha, 

            /// <summary>
            /// The treant.
            /// </summary>
            treant, 

            /// <summary>
            /// The alarmobot.
            /// </summary>
            alarmobot, 

            /// <summary>
            /// The animalcompanion.
            /// </summary>
            animalcompanion, 

            /// <summary>
            /// The hatefulstrike.
            /// </summary>
            hatefulstrike, 

            /// <summary>
            /// The dream.
            /// </summary>
            dream, 

            /// <summary>
            /// The anubrekhan.
            /// </summary>
            anubrekhan, 

            /// <summary>
            /// The youngpriestess.
            /// </summary>
            youngpriestess, 

            /// <summary>
            /// The gadgetzanauctioneer.
            /// </summary>
            gadgetzanauctioneer, 

            /// <summary>
            /// The coneofcold.
            /// </summary>
            coneofcold, 

            /// <summary>
            /// The earthshock.
            /// </summary>
            earthshock, 

            /// <summary>
            /// The tirionfordring.
            /// </summary>
            tirionfordring, 

            /// <summary>
            /// The wailingsoul.
            /// </summary>
            wailingsoul, 

            /// <summary>
            /// The skeleton.
            /// </summary>
            skeleton, 

            /// <summary>
            /// The ironfurgrizzly.
            /// </summary>
            ironfurgrizzly, 

            /// <summary>
            /// The headcrack.
            /// </summary>
            headcrack, 

            /// <summary>
            /// The arcaneshot.
            /// </summary>
            arcaneshot, 

            /// <summary>
            /// The maexxna.
            /// </summary>
            maexxna, 

            /// <summary>
            /// The imp.
            /// </summary>
            imp, 

            /// <summary>
            /// The markofthehorsemen.
            /// </summary>
            markofthehorsemen, 

            /// <summary>
            /// The voidterror.
            /// </summary>
            voidterror, 

            /// <summary>
            /// The mortalcoil.
            /// </summary>
            mortalcoil, 

            /// <summary>
            /// The draw 3 cards.
            /// </summary>
            draw3cards, 

            /// <summary>
            /// The flameofazzinoth.
            /// </summary>
            flameofazzinoth, 

            /// <summary>
            /// The jainaproudmoore.
            /// </summary>
            jainaproudmoore, 

            /// <summary>
            /// The execute.
            /// </summary>
            execute, 

            /// <summary>
            /// The bloodlust.
            /// </summary>
            bloodlust, 

            /// <summary>
            /// The bananas.
            /// </summary>
            bananas, 

            /// <summary>
            /// The kidnapper.
            /// </summary>
            kidnapper, 

            /// <summary>
            /// The oldmurkeye.
            /// </summary>
            oldmurkeye, 

            /// <summary>
            /// The homingchicken.
            /// </summary>
            homingchicken, 

            /// <summary>
            /// The enableforattack.
            /// </summary>
            enableforattack, 

            /// <summary>
            /// The spellbender.
            /// </summary>
            spellbender, 

            /// <summary>
            /// The backstab.
            /// </summary>
            backstab, 

            /// <summary>
            /// The squirrel.
            /// </summary>
            squirrel, 

            /// <summary>
            /// The stalagg.
            /// </summary>
            stalagg, 

            /// <summary>
            /// The grandwidowfaerlina.
            /// </summary>
            grandwidowfaerlina, 

            /// <summary>
            /// The heavyaxe.
            /// </summary>
            heavyaxe, 

            /// <summary>
            /// The zwick.
            /// </summary>
            zwick, 

            /// <summary>
            /// The webwrap.
            /// </summary>
            webwrap, 

            /// <summary>
            /// The flamesofazzinoth.
            /// </summary>
            flamesofazzinoth, 

            /// <summary>
            /// The murlocwarleader.
            /// </summary>
            murlocwarleader, 

            /// <summary>
            /// The shadowstep.
            /// </summary>
            shadowstep, 

            /// <summary>
            /// The ancestralspirit.
            /// </summary>
            ancestralspirit, 

            /// <summary>
            /// The defenderofargus.
            /// </summary>
            defenderofargus, 

            /// <summary>
            /// The assassinsblade.
            /// </summary>
            assassinsblade, 

            /// <summary>
            /// The discard.
            /// </summary>
            discard, 

            /// <summary>
            /// The biggamehunter.
            /// </summary>
            biggamehunter, 

            /// <summary>
            /// The aldorpeacekeeper.
            /// </summary>
            aldorpeacekeeper, 

            /// <summary>
            /// The blizzard.
            /// </summary>
            blizzard, 

            /// <summary>
            /// The pandarenscout.
            /// </summary>
            pandarenscout, 

            /// <summary>
            /// The unleashthehounds.
            /// </summary>
            unleashthehounds, 

            /// <summary>
            /// The yseraawakens.
            /// </summary>
            yseraawakens, 

            /// <summary>
            /// The sap.
            /// </summary>
            sap, 

            /// <summary>
            /// The kelthuzad.
            /// </summary>
            kelthuzad, 

            /// <summary>
            /// The defiasbandit.
            /// </summary>
            defiasbandit, 

            /// <summary>
            /// The gnomishinventor.
            /// </summary>
            gnomishinventor, 

            /// <summary>
            /// The mindcontrol.
            /// </summary>
            mindcontrol, 

            /// <summary>
            /// The ravenholdtassassin.
            /// </summary>
            ravenholdtassassin, 

            /// <summary>
            /// The icelance.
            /// </summary>
            icelance, 

            /// <summary>
            /// The dispel.
            /// </summary>
            dispel, 

            /// <summary>
            /// The acidicswampooze.
            /// </summary>
            acidicswampooze, 

            /// <summary>
            /// The muklasbigbrother.
            /// </summary>
            muklasbigbrother, 

            /// <summary>
            /// The blessedchampion.
            /// </summary>
            blessedchampion, 

            /// <summary>
            /// The savannahhighmane.
            /// </summary>
            savannahhighmane, 

            /// <summary>
            /// The direwolfalpha.
            /// </summary>
            direwolfalpha, 

            /// <summary>
            /// The hoggersmash.
            /// </summary>
            hoggersmash, 

            /// <summary>
            /// The blessingofwisdom.
            /// </summary>
            blessingofwisdom, 

            /// <summary>
            /// The nourish.
            /// </summary>
            nourish, 

            /// <summary>
            /// The abusivesergeant.
            /// </summary>
            abusivesergeant, 

            /// <summary>
            /// The sylvanaswindrunner.
            /// </summary>
            sylvanaswindrunner, 

            /// <summary>
            /// The spore.
            /// </summary>
            spore, 

            /// <summary>
            /// The crueltaskmaster.
            /// </summary>
            crueltaskmaster, 

            /// <summary>
            /// The lightningbolt.
            /// </summary>
            lightningbolt, 

            /// <summary>
            /// The keeperofthegrove.
            /// </summary>
            keeperofthegrove, 

            /// <summary>
            /// The steadyshot.
            /// </summary>
            steadyshot, 

            /// <summary>
            /// The multishot.
            /// </summary>
            multishot, 

            /// <summary>
            /// The harvest.
            /// </summary>
            harvest, 

            /// <summary>
            /// The instructorrazuvious.
            /// </summary>
            instructorrazuvious, 

            /// <summary>
            /// The ladyblaumeux.
            /// </summary>
            ladyblaumeux, 

            /// <summary>
            /// The jaybaxter.
            /// </summary>
            jaybaxter, 

            /// <summary>
            /// The molasses.
            /// </summary>
            molasses, 

            /// <summary>
            /// The pintsizedsummoner.
            /// </summary>
            pintsizedsummoner, 

            /// <summary>
            /// The spellbreaker.
            /// </summary>
            spellbreaker, 

            /// <summary>
            /// The anubarambusher.
            /// </summary>
            anubarambusher, 

            /// <summary>
            /// The deadlypoison.
            /// </summary>
            deadlypoison, 

            /// <summary>
            /// The stoneskingargoyle.
            /// </summary>
            stoneskingargoyle, 

            /// <summary>
            /// The bloodfury.
            /// </summary>
            bloodfury, 

            /// <summary>
            /// The fanofknives.
            /// </summary>
            fanofknives, 

            /// <summary>
            /// The poisoncloud.
            /// </summary>
            poisoncloud, 

            /// <summary>
            /// The shieldbearer.
            /// </summary>
            shieldbearer, 

            /// <summary>
            /// The sensedemons.
            /// </summary>
            sensedemons, 

            /// <summary>
            /// The shieldblock.
            /// </summary>
            shieldblock, 

            /// <summary>
            /// The handswapperminion.
            /// </summary>
            handswapperminion, 

            /// <summary>
            /// The massivegnoll.
            /// </summary>
            massivegnoll, 

            /// <summary>
            /// The deathcharger.
            /// </summary>
            deathcharger, 

            /// <summary>
            /// The ancientoflore.
            /// </summary>
            ancientoflore, 

            /// <summary>
            /// The oasissnapjaw.
            /// </summary>
            oasissnapjaw, 

            /// <summary>
            /// The illidanstormrage.
            /// </summary>
            illidanstormrage, 

            /// <summary>
            /// The frostwolfgrunt.
            /// </summary>
            frostwolfgrunt, 

            /// <summary>
            /// The lesserheal.
            /// </summary>
            lesserheal, 

            /// <summary>
            /// The infernal.
            /// </summary>
            infernal, 

            /// <summary>
            /// The wildpyromancer.
            /// </summary>
            wildpyromancer, 

            /// <summary>
            /// The razorfenhunter.
            /// </summary>
            razorfenhunter, 

            /// <summary>
            /// The twistingnether.
            /// </summary>
            twistingnether, 

            /// <summary>
            /// The voidcaller.
            /// </summary>
            voidcaller, 

            /// <summary>
            /// The leaderofthepack.
            /// </summary>
            leaderofthepack, 

            /// <summary>
            /// The malygos.
            /// </summary>
            malygos, 

            /// <summary>
            /// The becomehogger.
            /// </summary>
            becomehogger, 

            /// <summary>
            /// The baronrivendare.
            /// </summary>
            baronrivendare, 

            /// <summary>
            /// The millhousemanastorm.
            /// </summary>
            millhousemanastorm, 

            /// <summary>
            /// The innerfire.
            /// </summary>
            innerfire, 

            /// <summary>
            /// The valeerasanguinar.
            /// </summary>
            valeerasanguinar, 

            /// <summary>
            /// The chicken.
            /// </summary>
            chicken, 

            /// <summary>
            /// The souloftheforest.
            /// </summary>
            souloftheforest, 

            /// <summary>
            /// The silencedebug.
            /// </summary>
            silencedebug, 

            /// <summary>
            /// The bloodsailcorsair.
            /// </summary>
            bloodsailcorsair, 

            /// <summary>
            /// The slime.
            /// </summary>
            slime, 

            /// <summary>
            /// The tinkmasteroverspark.
            /// </summary>
            tinkmasteroverspark, 

            /// <summary>
            /// The iceblock.
            /// </summary>
            iceblock, 

            /// <summary>
            /// The brawl.
            /// </summary>
            brawl, 

            /// <summary>
            /// The vanish.
            /// </summary>
            vanish, 

            /// <summary>
            /// The poisonseeds.
            /// </summary>
            poisonseeds, 

            /// <summary>
            /// The murloc.
            /// </summary>
            murloc, 

            /// <summary>
            /// The mindspike.
            /// </summary>
            mindspike, 

            /// <summary>
            /// The kingmukla.
            /// </summary>
            kingmukla, 

            /// <summary>
            /// The stevengabriel.
            /// </summary>
            stevengabriel, 

            /// <summary>
            /// The gluth.
            /// </summary>
            gluth, 

            /// <summary>
            /// The truesilverchampion.
            /// </summary>
            truesilverchampion, 

            /// <summary>
            /// The harrisonjones.
            /// </summary>
            harrisonjones, 

            /// <summary>
            /// The destroydeck.
            /// </summary>
            destroydeck, 

            /// <summary>
            /// The devilsaur.
            /// </summary>
            devilsaur, 

            /// <summary>
            /// The wargolem.
            /// </summary>
            wargolem, 

            /// <summary>
            /// The warsongcommander.
            /// </summary>
            warsongcommander, 

            /// <summary>
            /// The manawyrm.
            /// </summary>
            manawyrm, 

            /// <summary>
            /// The thaddius.
            /// </summary>
            thaddius, 

            /// <summary>
            /// The savagery.
            /// </summary>
            savagery, 

            /// <summary>
            /// The spitefulsmith.
            /// </summary>
            spitefulsmith, 

            /// <summary>
            /// The shatteredsuncleric.
            /// </summary>
            shatteredsuncleric, 

            /// <summary>
            /// The eyeforaneye.
            /// </summary>
            eyeforaneye, 

            /// <summary>
            /// The azuredrake.
            /// </summary>
            azuredrake, 

            /// <summary>
            /// The mountaingiant.
            /// </summary>
            mountaingiant, 

            /// <summary>
            /// The korkronelite.
            /// </summary>
            korkronelite, 

            /// <summary>
            /// The junglepanther.
            /// </summary>
            junglepanther, 

            /// <summary>
            /// The barongeddon.
            /// </summary>
            barongeddon, 

            /// <summary>
            /// The spectralspider.
            /// </summary>
            spectralspider, 

            /// <summary>
            /// The pitlord.
            /// </summary>
            pitlord, 

            /// <summary>
            /// The markofnature.
            /// </summary>
            markofnature, 

            /// <summary>
            /// The grobbulus.
            /// </summary>
            grobbulus, 

            /// <summary>
            /// The leokk.
            /// </summary>
            leokk, 

            /// <summary>
            /// The fierywaraxe.
            /// </summary>
            fierywaraxe, 

            /// <summary>
            /// The damage 5.
            /// </summary>
            damage5, 

            /// <summary>
            /// The duplicate.
            /// </summary>
            duplicate, 

            /// <summary>
            /// The restore 5.
            /// </summary>
            restore5, 

            /// <summary>
            /// The mindblast.
            /// </summary>
            mindblast, 

            /// <summary>
            /// The timberwolf.
            /// </summary>
            timberwolf, 

            /// <summary>
            /// The captaingreenskin.
            /// </summary>
            captaingreenskin, 

            /// <summary>
            /// The elvenarcher.
            /// </summary>
            elvenarcher, 

            /// <summary>
            /// The michaelschweitzer.
            /// </summary>
            michaelschweitzer, 

            /// <summary>
            /// The masterswordsmith.
            /// </summary>
            masterswordsmith, 

            /// <summary>
            /// The grommashhellscream.
            /// </summary>
            grommashhellscream, 

            /// <summary>
            /// The hound.
            /// </summary>
            hound, 

            /// <summary>
            /// The seagiant.
            /// </summary>
            seagiant, 

            /// <summary>
            /// The doomguard.
            /// </summary>
            doomguard, 

            /// <summary>
            /// The alakirthewindlord.
            /// </summary>
            alakirthewindlord, 

            /// <summary>
            /// The hyena.
            /// </summary>
            hyena, 

            /// <summary>
            /// The undertaker.
            /// </summary>
            undertaker, 

            /// <summary>
            /// The frothingberserker.
            /// </summary>
            frothingberserker, 

            /// <summary>
            /// The powerofthewild.
            /// </summary>
            powerofthewild, 

            /// <summary>
            /// The druidoftheclaw.
            /// </summary>
            druidoftheclaw, 

            /// <summary>
            /// The hellfire.
            /// </summary>
            hellfire, 

            /// <summary>
            /// The archmage.
            /// </summary>
            archmage, 

            /// <summary>
            /// The recklessrocketeer.
            /// </summary>
            recklessrocketeer, 

            /// <summary>
            /// The crazymonkey.
            /// </summary>
            crazymonkey, 

            /// <summary>
            /// The damageallbut 1.
            /// </summary>
            damageallbut1, 

            /// <summary>
            /// The frostblast.
            /// </summary>
            frostblast, 

            /// <summary>
            /// The powerwordshield.
            /// </summary>
            powerwordshield, 

            /// <summary>
            /// The rainoffire.
            /// </summary>
            rainoffire, 

            /// <summary>
            /// The arcaneintellect.
            /// </summary>
            arcaneintellect, 

            /// <summary>
            /// The angrychicken.
            /// </summary>
            angrychicken, 

            /// <summary>
            /// The nerubianegg.
            /// </summary>
            nerubianegg, 

            /// <summary>
            /// The worshipper.
            /// </summary>
            worshipper, 

            /// <summary>
            /// The mindgames.
            /// </summary>
            mindgames, 

            /// <summary>
            /// The leeroyjenkins.
            /// </summary>
            leeroyjenkins, 

            /// <summary>
            /// The gurubashiberserker.
            /// </summary>
            gurubashiberserker, 

            /// <summary>
            /// The windspeaker.
            /// </summary>
            windspeaker, 

            /// <summary>
            /// The enableemotes.
            /// </summary>
            enableemotes, 

            /// <summary>
            /// The forceofnature.
            /// </summary>
            forceofnature, 

            /// <summary>
            /// The lightspawn.
            /// </summary>
            lightspawn, 

            /// <summary>
            /// The destroyamanacrystal.
            /// </summary>
            destroyamanacrystal, 

            /// <summary>
            /// The warglaiveofazzinoth.
            /// </summary>
            warglaiveofazzinoth, 

            /// <summary>
            /// The finkleeinhorn.
            /// </summary>
            finkleeinhorn, 

            /// <summary>
            /// The frostelemental.
            /// </summary>
            frostelemental, 

            /// <summary>
            /// The thoughtsteal.
            /// </summary>
            thoughtsteal, 

            /// <summary>
            /// The brianschwab.
            /// </summary>
            brianschwab, 

            /// <summary>
            /// The scavenginghyena.
            /// </summary>
            scavenginghyena, 

            /// <summary>
            /// The si 7 agent.
            /// </summary>
            si7agent, 

            /// <summary>
            /// The prophetvelen.
            /// </summary>
            prophetvelen, 

            /// <summary>
            /// The soulfire.
            /// </summary>
            soulfire, 

            /// <summary>
            /// The ogremagi.
            /// </summary>
            ogremagi, 

            /// <summary>
            /// The damagedgolem.
            /// </summary>
            damagedgolem, 

            /// <summary>
            /// The crash.
            /// </summary>
            crash, 

            /// <summary>
            /// The adrenalinerush.
            /// </summary>
            adrenalinerush, 

            /// <summary>
            /// The murloctidecaller.
            /// </summary>
            murloctidecaller, 

            /// <summary>
            /// The kirintormage.
            /// </summary>
            kirintormage, 

            /// <summary>
            /// The spectralrider.
            /// </summary>
            spectralrider, 

            /// <summary>
            /// The thrallmarfarseer.
            /// </summary>
            thrallmarfarseer, 

            /// <summary>
            /// The frostwolfwarlord.
            /// </summary>
            frostwolfwarlord, 

            /// <summary>
            /// The sorcerersapprentice.
            /// </summary>
            sorcerersapprentice, 

            /// <summary>
            /// The feugen.
            /// </summary>
            feugen, 

            /// <summary>
            /// The willofmukla.
            /// </summary>
            willofmukla, 

            /// <summary>
            /// The holyfire.
            /// </summary>
            holyfire, 

            /// <summary>
            /// The manawraith.
            /// </summary>
            manawraith, 

            /// <summary>
            /// The argentsquire.
            /// </summary>
            argentsquire, 

            /// <summary>
            /// The placeholdercard.
            /// </summary>
            placeholdercard, 

            /// <summary>
            /// The snakeball.
            /// </summary>
            snakeball, 

            /// <summary>
            /// The ancientwatcher.
            /// </summary>
            ancientwatcher, 

            /// <summary>
            /// The noviceengineer.
            /// </summary>
            noviceengineer, 

            /// <summary>
            /// The stonetuskboar.
            /// </summary>
            stonetuskboar, 

            /// <summary>
            /// The ancestralhealing.
            /// </summary>
            ancestralhealing, 

            /// <summary>
            /// The conceal.
            /// </summary>
            conceal, 

            /// <summary>
            /// The arcanitereaper.
            /// </summary>
            arcanitereaper, 

            /// <summary>
            /// The guldan.
            /// </summary>
            guldan, 

            /// <summary>
            /// The ragingworgen.
            /// </summary>
            ragingworgen, 

            /// <summary>
            /// The earthenringfarseer.
            /// </summary>
            earthenringfarseer, 

            /// <summary>
            /// The onyxia.
            /// </summary>
            onyxia, 

            /// <summary>
            /// The manaaddict.
            /// </summary>
            manaaddict, 

            /// <summary>
            /// The unholyshadow.
            /// </summary>
            unholyshadow, 

            /// <summary>
            /// The dualwarglaives.
            /// </summary>
            dualwarglaives, 

            /// <summary>
            /// The sludgebelcher.
            /// </summary>
            sludgebelcher, 

            /// <summary>
            /// The worthlessimp.
            /// </summary>
            worthlessimp, 

            /// <summary>
            /// The shiv.
            /// </summary>
            shiv, 

            /// <summary>
            /// The sheep.
            /// </summary>
            sheep, 

            /// <summary>
            /// The bloodknight.
            /// </summary>
            bloodknight, 

            /// <summary>
            /// The holysmite.
            /// </summary>
            holysmite, 

            /// <summary>
            /// The ancientsecrets.
            /// </summary>
            ancientsecrets, 

            /// <summary>
            /// The holywrath.
            /// </summary>
            holywrath, 

            /// <summary>
            /// The ironforgerifleman.
            /// </summary>
            ironforgerifleman, 

            /// <summary>
            /// The elitetaurenchieftain.
            /// </summary>
            elitetaurenchieftain, 

            /// <summary>
            /// The spectralwarrior.
            /// </summary>
            spectralwarrior, 

            /// <summary>
            /// The bluegillwarrior.
            /// </summary>
            bluegillwarrior, 

            /// <summary>
            /// The shapeshift.
            /// </summary>
            shapeshift, 

            /// <summary>
            /// The hamiltonchu.
            /// </summary>
            hamiltonchu, 

            /// <summary>
            /// The battlerage.
            /// </summary>
            battlerage, 

            /// <summary>
            /// The nightblade.
            /// </summary>
            nightblade, 

            /// <summary>
            /// The locustswarm.
            /// </summary>
            locustswarm, 

            /// <summary>
            /// The crazedhunter.
            /// </summary>
            crazedhunter, 

            /// <summary>
            /// The andybrock.
            /// </summary>
            andybrock, 

            /// <summary>
            /// The youthfulbrewmaster.
            /// </summary>
            youthfulbrewmaster, 

            /// <summary>
            /// The theblackknight.
            /// </summary>
            theblackknight, 

            /// <summary>
            /// The brewmaster.
            /// </summary>
            brewmaster, 

            /// <summary>
            /// The lifetap.
            /// </summary>
            lifetap, 

            /// <summary>
            /// The demonfire.
            /// </summary>
            demonfire, 

            /// <summary>
            /// The redemption.
            /// </summary>
            redemption, 

            /// <summary>
            /// The lordjaraxxus.
            /// </summary>
            lordjaraxxus, 

            /// <summary>
            /// The coldblood.
            /// </summary>
            coldblood, 

            /// <summary>
            /// The lightwarden.
            /// </summary>
            lightwarden, 

            /// <summary>
            /// The questingadventurer.
            /// </summary>
            questingadventurer, 

            /// <summary>
            /// The donothing.
            /// </summary>
            donothing, 

            /// <summary>
            /// The dereksakamoto.
            /// </summary>
            dereksakamoto, 

            /// <summary>
            /// The poultryizer.
            /// </summary>
            poultryizer, 

            /// <summary>
            /// The koboldgeomancer.
            /// </summary>
            koboldgeomancer, 

            /// <summary>
            /// The legacyoftheemperor.
            /// </summary>
            legacyoftheemperor, 

            /// <summary>
            /// The eruption.
            /// </summary>
            eruption, 

            /// <summary>
            /// The cenarius.
            /// </summary>
            cenarius, 

            /// <summary>
            /// The deathlord.
            /// </summary>
            deathlord, 

            /// <summary>
            /// The searingtotem.
            /// </summary>
            searingtotem, 

            /// <summary>
            /// The taurenwarrior.
            /// </summary>
            taurenwarrior, 

            /// <summary>
            /// The explosivetrap.
            /// </summary>
            explosivetrap, 

            /// <summary>
            /// The frog.
            /// </summary>
            frog, 

            /// <summary>
            /// The servercrash.
            /// </summary>
            servercrash, 

            /// <summary>
            /// The wickedknife.
            /// </summary>
            wickedknife, 

            /// <summary>
            /// The laughingsister.
            /// </summary>
            laughingsister, 

            /// <summary>
            /// The cultmaster.
            /// </summary>
            cultmaster, 

            /// <summary>
            /// The wildgrowth.
            /// </summary>
            wildgrowth, 

            /// <summary>
            /// The sprint.
            /// </summary>
            sprint, 

            /// <summary>
            /// The masterofdisguise.
            /// </summary>
            masterofdisguise, 

            /// <summary>
            /// The kyleharrison.
            /// </summary>
            kyleharrison, 

            /// <summary>
            /// The avatarofthecoin.
            /// </summary>
            avatarofthecoin, 

            /// <summary>
            /// The excessmana.
            /// </summary>
            excessmana, 

            /// <summary>
            /// The spiritwolf.
            /// </summary>
            spiritwolf, 

            /// <summary>
            /// The auchenaisoulpriest.
            /// </summary>
            auchenaisoulpriest, 

            /// <summary>
            /// The bestialwrath.
            /// </summary>
            bestialwrath, 

            /// <summary>
            /// The rockbiterweapon.
            /// </summary>
            rockbiterweapon, 

            /// <summary>
            /// The starvingbuzzard.
            /// </summary>
            starvingbuzzard, 

            /// <summary>
            /// The mirrorimage.
            /// </summary>
            mirrorimage, 

            /// <summary>
            /// The frozenchampion.
            /// </summary>
            frozenchampion, 

            /// <summary>
            /// The silverhandrecruit.
            /// </summary>
            silverhandrecruit, 

            /// <summary>
            /// The corruption.
            /// </summary>
            corruption, 

            /// <summary>
            /// The preparation.
            /// </summary>
            preparation, 

            /// <summary>
            /// The cairnebloodhoof.
            /// </summary>
            cairnebloodhoof, 

            /// <summary>
            /// The mortalstrike.
            /// </summary>
            mortalstrike, 

            /// <summary>
            /// The flare.
            /// </summary>
            flare, 

            /// <summary>
            /// The necroknight.
            /// </summary>
            necroknight, 

            /// <summary>
            /// The silverhandknight.
            /// </summary>
            silverhandknight, 

            /// <summary>
            /// The breakweapon.
            /// </summary>
            breakweapon, 

            /// <summary>
            /// The guardianofkings.
            /// </summary>
            guardianofkings, 

            /// <summary>
            /// The ancientbrewmaster.
            /// </summary>
            ancientbrewmaster, 

            /// <summary>
            /// The avenge.
            /// </summary>
            avenge, 

            /// <summary>
            /// The youngdragonhawk.
            /// </summary>
            youngdragonhawk, 

            /// <summary>
            /// The frostshock.
            /// </summary>
            frostshock, 

            /// <summary>
            /// The healingtouch.
            /// </summary>
            healingtouch, 

            /// <summary>
            /// The venturecomercenary.
            /// </summary>
            venturecomercenary, 

            /// <summary>
            /// The unbalancingstrike.
            /// </summary>
            unbalancingstrike, 

            /// <summary>
            /// The sacrificialpact.
            /// </summary>
            sacrificialpact, 

            /// <summary>
            /// The noooooooooooo.
            /// </summary>
            noooooooooooo, 

            /// <summary>
            /// The baneofdoom.
            /// </summary>
            baneofdoom, 

            /// <summary>
            /// The abomination.
            /// </summary>
            abomination, 

            /// <summary>
            /// The flesheatingghoul.
            /// </summary>
            flesheatingghoul, 

            /// <summary>
            /// The loothoarder.
            /// </summary>
            loothoarder, 

            /// <summary>
            /// The mill 10.
            /// </summary>
            mill10, 

            /// <summary>
            /// The sapphiron.
            /// </summary>
            sapphiron, 

            /// <summary>
            /// The jasonchayes.
            /// </summary>
            jasonchayes, 

            /// <summary>
            /// The benbrode.
            /// </summary>
            benbrode, 

            /// <summary>
            /// The betrayal.
            /// </summary>
            betrayal, 

            /// <summary>
            /// The thebeast.
            /// </summary>
            thebeast, 

            /// <summary>
            /// The flameimp.
            /// </summary>
            flameimp, 

            /// <summary>
            /// The freezingtrap.
            /// </summary>
            freezingtrap, 

            /// <summary>
            /// The southseadeckhand.
            /// </summary>
            southseadeckhand, 

            /// <summary>
            /// The wrath.
            /// </summary>
            wrath, 

            /// <summary>
            /// The bloodfenraptor.
            /// </summary>
            bloodfenraptor, 

            /// <summary>
            /// The cleave.
            /// </summary>
            cleave, 

            /// <summary>
            /// The fencreeper.
            /// </summary>
            fencreeper, 

            /// <summary>
            /// The restore 1.
            /// </summary>
            restore1, 

            /// <summary>
            /// The handtodeck.
            /// </summary>
            handtodeck, 

            /// <summary>
            /// The starfire.
            /// </summary>
            starfire, 

            /// <summary>
            /// The goldshirefootman.
            /// </summary>
            goldshirefootman, 

            /// <summary>
            /// The unrelentingtrainee.
            /// </summary>
            unrelentingtrainee, 

            /// <summary>
            /// The murlocscout.
            /// </summary>
            murlocscout, 

            /// <summary>
            /// The ragnarosthefirelord.
            /// </summary>
            ragnarosthefirelord, 

            /// <summary>
            /// The rampage.
            /// </summary>
            rampage, 

            /// <summary>
            /// The zombiechow.
            /// </summary>
            zombiechow, 

            /// <summary>
            /// The thrall.
            /// </summary>
            thrall, 

            /// <summary>
            /// The stoneclawtotem.
            /// </summary>
            stoneclawtotem, 

            /// <summary>
            /// The captainsparrot.
            /// </summary>
            captainsparrot, 

            /// <summary>
            /// The windfuryharpy.
            /// </summary>
            windfuryharpy, 

            /// <summary>
            /// The unrelentingwarrior.
            /// </summary>
            unrelentingwarrior, 

            /// <summary>
            /// The stranglethorntiger.
            /// </summary>
            stranglethorntiger, 

            /// <summary>
            /// The summonarandomsecret.
            /// </summary>
            summonarandomsecret, 

            /// <summary>
            /// The circleofhealing.
            /// </summary>
            circleofhealing, 

            /// <summary>
            /// The snaketrap.
            /// </summary>
            snaketrap, 

            /// <summary>
            /// The cabalshadowpriest.
            /// </summary>
            cabalshadowpriest, 

            /// <summary>
            /// The nerubarweblord.
            /// </summary>
            nerubarweblord, 

            /// <summary>
            /// The upgrade.
            /// </summary>
            upgrade, 

            /// <summary>
            /// The shieldslam.
            /// </summary>
            shieldslam, 

            /// <summary>
            /// The flameburst.
            /// </summary>
            flameburst, 

            /// <summary>
            /// The windfury.
            /// </summary>
            windfury, 

            /// <summary>
            /// The enrage.
            /// </summary>
            enrage, 

            /// <summary>
            /// The natpagle.
            /// </summary>
            natpagle, 

            /// <summary>
            /// The restoreallhealth.
            /// </summary>
            restoreallhealth, 

            /// <summary>
            /// The houndmaster.
            /// </summary>
            houndmaster, 

            /// <summary>
            /// The waterelemental.
            /// </summary>
            waterelemental, 

            /// <summary>
            /// The eaglehornbow.
            /// </summary>
            eaglehornbow, 

            /// <summary>
            /// The gnoll.
            /// </summary>
            gnoll, 

            /// <summary>
            /// The archmageantonidas.
            /// </summary>
            archmageantonidas, 

            /// <summary>
            /// The destroyallheroes.
            /// </summary>
            destroyallheroes, 

            /// <summary>
            /// The chains.
            /// </summary>
            chains, 

            /// <summary>
            /// The wrathofairtotem.
            /// </summary>
            wrathofairtotem, 

            /// <summary>
            /// The killcommand.
            /// </summary>
            killcommand, 

            /// <summary>
            /// The manatidetotem.
            /// </summary>
            manatidetotem, 

            /// <summary>
            /// The daggermastery.
            /// </summary>
            daggermastery, 

            /// <summary>
            /// The drainlife.
            /// </summary>
            drainlife, 

            /// <summary>
            /// The doomsayer.
            /// </summary>
            doomsayer, 

            /// <summary>
            /// The darkscalehealer.
            /// </summary>
            darkscalehealer, 

            /// <summary>
            /// The shadowform.
            /// </summary>
            shadowform, 

            /// <summary>
            /// The frostnova.
            /// </summary>
            frostnova, 

            /// <summary>
            /// The purecold.
            /// </summary>
            purecold, 

            /// <summary>
            /// The mirrorentity.
            /// </summary>
            mirrorentity, 

            /// <summary>
            /// The counterspell.
            /// </summary>
            counterspell, 

            /// <summary>
            /// The mindshatter.
            /// </summary>
            mindshatter, 

            /// <summary>
            /// The magmarager.
            /// </summary>
            magmarager, 

            /// <summary>
            /// The wolfrider.
            /// </summary>
            wolfrider, 

            /// <summary>
            /// The emboldener 3000.
            /// </summary>
            emboldener3000, 

            /// <summary>
            /// The polarityshift.
            /// </summary>
            polarityshift, 

            /// <summary>
            /// The gelbinmekkatorque.
            /// </summary>
            gelbinmekkatorque, 

            /// <summary>
            /// The webspinner.
            /// </summary>
            webspinner, 

            /// <summary>
            /// The utherlightbringer.
            /// </summary>
            utherlightbringer, 

            /// <summary>
            /// The innerrage.
            /// </summary>
            innerrage, 

            /// <summary>
            /// The emeralddrake.
            /// </summary>
            emeralddrake, 

            /// <summary>
            /// The forceaitouseheropower.
            /// </summary>
            forceaitouseheropower, 

            /// <summary>
            /// The echoingooze.
            /// </summary>
            echoingooze, 

            /// <summary>
            /// The heroicstrike.
            /// </summary>
            heroicstrike, 

            /// <summary>
            /// The hauntedcreeper.
            /// </summary>
            hauntedcreeper, 

            /// <summary>
            /// The barreltoss.
            /// </summary>
            barreltoss, 

            /// <summary>
            /// The yongwoo.
            /// </summary>
            yongwoo, 

            /// <summary>
            /// The doomhammer.
            /// </summary>
            doomhammer, 

            /// <summary>
            /// The stomp.
            /// </summary>
            stomp, 

            /// <summary>
            /// The spectralknight.
            /// </summary>
            spectralknight, 

            /// <summary>
            /// The tracking.
            /// </summary>
            tracking, 

            /// <summary>
            /// The fireball.
            /// </summary>
            fireball, 

            /// <summary>
            /// The thecoin.
            /// </summary>
            thecoin, 

            /// <summary>
            /// The bootybaybodyguard.
            /// </summary>
            bootybaybodyguard, 

            /// <summary>
            /// The scarletcrusader.
            /// </summary>
            scarletcrusader, 

            /// <summary>
            /// The voodoodoctor.
            /// </summary>
            voodoodoctor, 

            /// <summary>
            /// The shadowbolt.
            /// </summary>
            shadowbolt, 

            /// <summary>
            /// The etherealarcanist.
            /// </summary>
            etherealarcanist, 

            /// <summary>
            /// The succubus.
            /// </summary>
            succubus, 

            /// <summary>
            /// The emperorcobra.
            /// </summary>
            emperorcobra, 

            /// <summary>
            /// The deadlyshot.
            /// </summary>
            deadlyshot, 

            /// <summary>
            /// The reinforce.
            /// </summary>
            reinforce, 

            /// <summary>
            /// The supercharge.
            /// </summary>
            supercharge, 

            /// <summary>
            /// The claw.
            /// </summary>
            claw, 

            /// <summary>
            /// The explosiveshot.
            /// </summary>
            explosiveshot, 

            /// <summary>
            /// The avengingwrath.
            /// </summary>
            avengingwrath, 

            /// <summary>
            /// The riverpawgnoll.
            /// </summary>
            riverpawgnoll, 

            /// <summary>
            /// The sirzeliek.
            /// </summary>
            sirzeliek, 

            /// <summary>
            /// The argentprotector.
            /// </summary>
            argentprotector, 

            /// <summary>
            /// The hiddengnome.
            /// </summary>
            hiddengnome, 

            /// <summary>
            /// The felguard.
            /// </summary>
            felguard, 

            /// <summary>
            /// The northshirecleric.
            /// </summary>
            northshirecleric, 

            /// <summary>
            /// The plague.
            /// </summary>
            plague, 

            /// <summary>
            /// The lepergnome.
            /// </summary>
            lepergnome, 

            /// <summary>
            /// The fireelemental.
            /// </summary>
            fireelemental, 

            /// <summary>
            /// The armorup.
            /// </summary>
            armorup, 

            /// <summary>
            /// The snipe.
            /// </summary>
            snipe, 

            /// <summary>
            /// The southseacaptain.
            /// </summary>
            southseacaptain, 

            /// <summary>
            /// The catform.
            /// </summary>
            catform, 

            /// <summary>
            /// The bite.
            /// </summary>
            bite, 

            /// <summary>
            /// The defiasringleader.
            /// </summary>
            defiasringleader, 

            /// <summary>
            /// The harvestgolem.
            /// </summary>
            harvestgolem, 

            /// <summary>
            /// The kingkrush.
            /// </summary>
            kingkrush, 

            /// <summary>
            /// The aibuddydamageownhero 5.
            /// </summary>
            aibuddydamageownhero5, 

            /// <summary>
            /// The healingtotem.
            /// </summary>
            healingtotem, 

            /// <summary>
            /// The ericdodds.
            /// </summary>
            ericdodds, 

            /// <summary>
            /// The demigodsfavor.
            /// </summary>
            demigodsfavor, 

            /// <summary>
            /// The huntersmark.
            /// </summary>
            huntersmark, 

            /// <summary>
            /// The dalaranmage.
            /// </summary>
            dalaranmage, 

            /// <summary>
            /// The twilightdrake.
            /// </summary>
            twilightdrake, 

            /// <summary>
            /// The coldlightoracle.
            /// </summary>
            coldlightoracle, 

            /// <summary>
            /// The shadeofnaxxramas.
            /// </summary>
            shadeofnaxxramas, 

            /// <summary>
            /// The moltengiant.
            /// </summary>
            moltengiant, 

            /// <summary>
            /// The deathbloom.
            /// </summary>
            deathbloom, 

            /// <summary>
            /// The shadowflame.
            /// </summary>
            shadowflame, 

            /// <summary>
            /// The anduinwrynn.
            /// </summary>
            anduinwrynn, 

            /// <summary>
            /// The argentcommander.
            /// </summary>
            argentcommander, 

            /// <summary>
            /// The revealhand.
            /// </summary>
            revealhand, 

            /// <summary>
            /// The arcanemissiles.
            /// </summary>
            arcanemissiles, 

            /// <summary>
            /// The repairbot.
            /// </summary>
            repairbot, 

            /// <summary>
            /// The unstableghoul.
            /// </summary>
            unstableghoul, 

            /// <summary>
            /// The ancientofwar.
            /// </summary>
            ancientofwar, 

            /// <summary>
            /// The stormwindchampion.
            /// </summary>
            stormwindchampion, 

            /// <summary>
            /// The summonapanther.
            /// </summary>
            summonapanther, 

            /// <summary>
            /// The mrbigglesworth.
            /// </summary>
            mrbigglesworth, 

            /// <summary>
            /// The swipe.
            /// </summary>
            swipe, 

            /// <summary>
            /// The aihelperbuddy.
            /// </summary>
            aihelperbuddy, 

            /// <summary>
            /// The hex.
            /// </summary>
            hex, 

            /// <summary>
            /// The ysera.
            /// </summary>
            ysera, 

            /// <summary>
            /// The arcanegolem.
            /// </summary>
            arcanegolem, 

            /// <summary>
            /// The bloodimp.
            /// </summary>
            bloodimp, 

            /// <summary>
            /// The pyroblast.
            /// </summary>
            pyroblast, 

            /// <summary>
            /// The murlocraider.
            /// </summary>
            murlocraider, 

            /// <summary>
            /// The faeriedragon.
            /// </summary>
            faeriedragon, 

            /// <summary>
            /// The sinisterstrike.
            /// </summary>
            sinisterstrike, 

            /// <summary>
            /// The poweroverwhelming.
            /// </summary>
            poweroverwhelming, 

            /// <summary>
            /// The arcaneexplosion.
            /// </summary>
            arcaneexplosion, 

            /// <summary>
            /// The shadowwordpain.
            /// </summary>
            shadowwordpain, 

            /// <summary>
            /// The mill 30.
            /// </summary>
            mill30, 

            /// <summary>
            /// The noblesacrifice.
            /// </summary>
            noblesacrifice, 

            /// <summary>
            /// The dreadinfernal.
            /// </summary>
            dreadinfernal, 

            /// <summary>
            /// The naturalize.
            /// </summary>
            naturalize, 

            /// <summary>
            /// The totemiccall.
            /// </summary>
            totemiccall, 

            /// <summary>
            /// The secretkeeper.
            /// </summary>
            secretkeeper, 

            /// <summary>
            /// The dreadcorsair.
            /// </summary>
            dreadcorsair, 

            /// <summary>
            /// The jaws.
            /// </summary>
            jaws, 

            /// <summary>
            /// The forkedlightning.
            /// </summary>
            forkedlightning, 

            /// <summary>
            /// The reincarnate.
            /// </summary>
            reincarnate, 

            /// <summary>
            /// The handofprotection.
            /// </summary>
            handofprotection, 

            /// <summary>
            /// The noththeplaguebringer.
            /// </summary>
            noththeplaguebringer, 

            /// <summary>
            /// The vaporize.
            /// </summary>
            vaporize, 

            /// <summary>
            /// The frostbreath.
            /// </summary>
            frostbreath, 

            /// <summary>
            /// The nozdormu.
            /// </summary>
            nozdormu, 

            /// <summary>
            /// The divinespirit.
            /// </summary>
            divinespirit, 

            /// <summary>
            /// The transcendence.
            /// </summary>
            transcendence, 

            /// <summary>
            /// The armorsmith.
            /// </summary>
            armorsmith, 

            /// <summary>
            /// The murloctidehunter.
            /// </summary>
            murloctidehunter, 

            /// <summary>
            /// The stealcard.
            /// </summary>
            stealcard, 

            /// <summary>
            /// The opponentconcede.
            /// </summary>
            opponentconcede, 

            /// <summary>
            /// The tundrarhino.
            /// </summary>
            tundrarhino, 

            /// <summary>
            /// The summoningportal.
            /// </summary>
            summoningportal, 

            /// <summary>
            /// The hammerofwrath.
            /// </summary>
            hammerofwrath, 

            /// <summary>
            /// The stormwindknight.
            /// </summary>
            stormwindknight, 

            /// <summary>
            /// The freeze.
            /// </summary>
            freeze, 

            /// <summary>
            /// The madbomber.
            /// </summary>
            madbomber, 

            /// <summary>
            /// The consecration.
            /// </summary>
            consecration, 

            /// <summary>
            /// The spectraltrainee.
            /// </summary>
            spectraltrainee, 

            /// <summary>
            /// The boar.
            /// </summary>
            boar, 

            /// <summary>
            /// The knifejuggler.
            /// </summary>
            knifejuggler, 

            /// <summary>
            /// The icebarrier.
            /// </summary>
            icebarrier, 

            /// <summary>
            /// The mechanicaldragonling.
            /// </summary>
            mechanicaldragonling, 

            /// <summary>
            /// The battleaxe.
            /// </summary>
            battleaxe, 

            /// <summary>
            /// The lightsjustice.
            /// </summary>
            lightsjustice, 

            /// <summary>
            /// The lavaburst.
            /// </summary>
            lavaburst, 

            /// <summary>
            /// The mindcontroltech.
            /// </summary>
            mindcontroltech, 

            /// <summary>
            /// The boulderfistogre.
            /// </summary>
            boulderfistogre, 

            /// <summary>
            /// The fireblast.
            /// </summary>
            fireblast, 

            /// <summary>
            /// The priestessofelune.
            /// </summary>
            priestessofelune, 

            /// <summary>
            /// The ancientmage.
            /// </summary>
            ancientmage, 

            /// <summary>
            /// The shadowworddeath.
            /// </summary>
            shadowworddeath, 

            /// <summary>
            /// The ironbeakowl.
            /// </summary>
            ironbeakowl, 

            /// <summary>
            /// The eviscerate.
            /// </summary>
            eviscerate, 

            /// <summary>
            /// The repentance.
            /// </summary>
            repentance, 

            /// <summary>
            /// The understudy.
            /// </summary>
            understudy, 

            /// <summary>
            /// The sunwalker.
            /// </summary>
            sunwalker, 

            /// <summary>
            /// The nagamyrmidon.
            /// </summary>
            nagamyrmidon, 

            /// <summary>
            /// The destroyheropower.
            /// </summary>
            destroyheropower, 

            /// <summary>
            /// The skeletalsmith.
            /// </summary>
            skeletalsmith, 

            /// <summary>
            /// The slam.
            /// </summary>
            slam, 

            /// <summary>
            /// The swordofjustice.
            /// </summary>
            swordofjustice, 

            /// <summary>
            /// The bounce.
            /// </summary>
            bounce, 

            /// <summary>
            /// The shadopanmonk.
            /// </summary>
            shadopanmonk, 

            /// <summary>
            /// The whirlwind.
            /// </summary>
            whirlwind, 

            /// <summary>
            /// The alexstrasza.
            /// </summary>
            alexstrasza, 

            /// <summary>
            /// The silence.
            /// </summary>
            silence, 

            /// <summary>
            /// The rexxar.
            /// </summary>
            rexxar, 

            /// <summary>
            /// The voidwalker.
            /// </summary>
            voidwalker, 

            /// <summary>
            /// The whelp.
            /// </summary>
            whelp, 

            /// <summary>
            /// The flamestrike.
            /// </summary>
            flamestrike, 

            /// <summary>
            /// The rivercrocolisk.
            /// </summary>
            rivercrocolisk, 

            /// <summary>
            /// The stormforgedaxe.
            /// </summary>
            stormforgedaxe, 

            /// <summary>
            /// The snake.
            /// </summary>
            snake, 

            /// <summary>
            /// The shotgunblast.
            /// </summary>
            shotgunblast, 

            /// <summary>
            /// The violetapprentice.
            /// </summary>
            violetapprentice, 

            /// <summary>
            /// The templeenforcer.
            /// </summary>
            templeenforcer, 

            /// <summary>
            /// The ashbringer.
            /// </summary>
            ashbringer, 

            /// <summary>
            /// The impmaster.
            /// </summary>
            impmaster, 

            /// <summary>
            /// The defender.
            /// </summary>
            defender, 

            /// <summary>
            /// The savageroar.
            /// </summary>
            savageroar, 

            /// <summary>
            /// The innervate.
            /// </summary>
            innervate, 

            /// <summary>
            /// The inferno.
            /// </summary>
            inferno, 

            /// <summary>
            /// The falloutslime.
            /// </summary>
            falloutslime, 

            /// <summary>
            /// The earthelemental.
            /// </summary>
            earthelemental, 

            /// <summary>
            /// The facelessmanipulator.
            /// </summary>
            facelessmanipulator, 

            /// <summary>
            /// The mindpocalypse.
            /// </summary>
            mindpocalypse, 

            /// <summary>
            /// The divinefavor.
            /// </summary>
            divinefavor, 

            /// <summary>
            /// The aibuddydestroyminions.
            /// </summary>
            aibuddydestroyminions, 

            /// <summary>
            /// The demolisher.
            /// </summary>
            demolisher, 

            /// <summary>
            /// The sunfuryprotector.
            /// </summary>
            sunfuryprotector, 

            /// <summary>
            /// The dustdevil.
            /// </summary>
            dustdevil, 

            /// <summary>
            /// The powerofthehorde.
            /// </summary>
            powerofthehorde, 

            /// <summary>
            /// The dancingswords.
            /// </summary>
            dancingswords, 

            /// <summary>
            /// The holylight.
            /// </summary>
            holylight, 

            /// <summary>
            /// The feralspirit.
            /// </summary>
            feralspirit, 

            /// <summary>
            /// The raidleader.
            /// </summary>
            raidleader, 

            /// <summary>
            /// The amaniberserker.
            /// </summary>
            amaniberserker, 

            /// <summary>
            /// The ironbarkprotector.
            /// </summary>
            ironbarkprotector, 

            /// <summary>
            /// The bearform.
            /// </summary>
            bearform, 

            /// <summary>
            /// The deathwing.
            /// </summary>
            deathwing, 

            /// <summary>
            /// The stormpikecommando.
            /// </summary>
            stormpikecommando, 

            /// <summary>
            /// The squire.
            /// </summary>
            squire, 

            /// <summary>
            /// The panther.
            /// </summary>
            panther, 

            /// <summary>
            /// The silverbackpatriarch.
            /// </summary>
            silverbackpatriarch, 

            /// <summary>
            /// The bobfitch.
            /// </summary>
            bobfitch, 

            /// <summary>
            /// The gladiatorslongbow.
            /// </summary>
            gladiatorslongbow, 

            /// <summary>
            /// The damage 1.
            /// </summary>
            damage1, 
        }

        /// <summary>
        /// The card namestring to enum.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="cardName"/>.
        /// </returns>
        public cardName cardNamestringToEnum(string s)
        {
            if (s == "unknown") return cardName.unknown;
            if (s == "hogger") return cardName.hogger;
            if (s == "heigantheunclean") return cardName.heigantheunclean;
            if (s == "necroticaura") return cardName.necroticaura;
            if (s == "starfall") return cardName.starfall;
            if (s == "barrel") return cardName.barrel;
            if (s == "damagereflector") return cardName.damagereflector;
            if (s == "edwinvancleef") return cardName.edwinvancleef;
            if (s == "gothiktheharvester") return cardName.gothiktheharvester;
            if (s == "perditionsblade") return cardName.perditionsblade;
            if (s == "bloodsailraider") return cardName.bloodsailraider;
            if (s == "guardianoficecrown") return cardName.guardianoficecrown;
            if (s == "bloodmagethalnos") return cardName.bloodmagethalnos;
            if (s == "rooted") return cardName.rooted;
            if (s == "wisp") return cardName.wisp;
            if (s == "rachelledavis") return cardName.rachelledavis;
            if (s == "senjinshieldmasta") return cardName.senjinshieldmasta;
            if (s == "totemicmight") return cardName.totemicmight;
            if (s == "uproot") return cardName.uproot;
            if (s == "opponentdisconnect") return cardName.opponentdisconnect;
            if (s == "unrelentingrider") return cardName.unrelentingrider;
            if (s == "shandoslesson") return cardName.shandoslesson;
            if (s == "hemetnesingwary") return cardName.hemetnesingwary;
            if (s == "decimate") return cardName.decimate;
            if (s == "shadowofnothing") return cardName.shadowofnothing;
            if (s == "nerubian") return cardName.nerubian;
            if (s == "dragonlingmechanic") return cardName.dragonlingmechanic;
            if (s == "mogushanwarden") return cardName.mogushanwarden;
            if (s == "thanekorthazz") return cardName.thanekorthazz;
            if (s == "hungrycrab") return cardName.hungrycrab;
            if (s == "ancientteachings") return cardName.ancientteachings;
            if (s == "misdirection") return cardName.misdirection;
            if (s == "patientassassin") return cardName.patientassassin;
            if (s == "mutatinginjection") return cardName.mutatinginjection;
            if (s == "violetteacher") return cardName.violetteacher;
            if (s == "arathiweaponsmith") return cardName.arathiweaponsmith;
            if (s == "raisedead") return cardName.raisedead;
            if (s == "acolyteofpain") return cardName.acolyteofpain;
            if (s == "holynova") return cardName.holynova;
            if (s == "robpardo") return cardName.robpardo;
            if (s == "commandingshout") return cardName.commandingshout;
            if (s == "necroticpoison") return cardName.necroticpoison;
            if (s == "unboundelemental") return cardName.unboundelemental;
            if (s == "garroshhellscream") return cardName.garroshhellscream;
            if (s == "enchant") return cardName.enchant;
            if (s == "loatheb") return cardName.loatheb;
            if (s == "blessingofmight") return cardName.blessingofmight;
            if (s == "nightmare") return cardName.nightmare;
            if (s == "blessingofkings") return cardName.blessingofkings;
            if (s == "polymorph") return cardName.polymorph;
            if (s == "darkirondwarf") return cardName.darkirondwarf;
            if (s == "destroy") return cardName.destroy;
            if (s == "roguesdoit") return cardName.roguesdoit;
            if (s == "freecards") return cardName.freecards;
            if (s == "iammurloc") return cardName.iammurloc;
            if (s == "sporeburst") return cardName.sporeburst;
            if (s == "mindcontrolcrystal") return cardName.mindcontrolcrystal;
            if (s == "charge") return cardName.charge;
            if (s == "stampedingkodo") return cardName.stampedingkodo;
            if (s == "humility") return cardName.humility;
            if (s == "darkcultist") return cardName.darkcultist;
            if (s == "gruul") return cardName.gruul;
            if (s == "markofthewild") return cardName.markofthewild;
            if (s == "patchwerk") return cardName.patchwerk;
            if (s == "worgeninfiltrator") return cardName.worgeninfiltrator;
            if (s == "frostbolt") return cardName.frostbolt;
            if (s == "runeblade") return cardName.runeblade;
            if (s == "flametonguetotem") return cardName.flametonguetotem;
            if (s == "assassinate") return cardName.assassinate;
            if (s == "madscientist") return cardName.madscientist;
            if (s == "lordofthearena") return cardName.lordofthearena;
            if (s == "bainebloodhoof") return cardName.bainebloodhoof;
            if (s == "injuredblademaster") return cardName.injuredblademaster;
            if (s == "siphonsoul") return cardName.siphonsoul;
            if (s == "layonhands") return cardName.layonhands;
            if (s == "hook") return cardName.hook;
            if (s == "massiveruneblade") return cardName.massiveruneblade;
            if (s == "lorewalkercho") return cardName.lorewalkercho;
            if (s == "destroyallminions") return cardName.destroyallminions;
            if (s == "silvermoonguardian") return cardName.silvermoonguardian;
            if (s == "destroyallmana") return cardName.destroyallmana;
            if (s == "huffer") return cardName.huffer;
            if (s == "mindvision") return cardName.mindvision;
            if (s == "malfurionstormrage") return cardName.malfurionstormrage;
            if (s == "corehound") return cardName.corehound;
            if (s == "grimscaleoracle") return cardName.grimscaleoracle;
            if (s == "lightningstorm") return cardName.lightningstorm;
            if (s == "lightwell") return cardName.lightwell;
            if (s == "benthompson") return cardName.benthompson;
            if (s == "coldlightseer") return cardName.coldlightseer;
            if (s == "deathsbite") return cardName.deathsbite;
            if (s == "gorehowl") return cardName.gorehowl;
            if (s == "skitter") return cardName.skitter;
            if (s == "farsight") return cardName.farsight;
            if (s == "chillwindyeti") return cardName.chillwindyeti;
            if (s == "moonfire") return cardName.moonfire;
            if (s == "bladeflurry") return cardName.bladeflurry;
            if (s == "massdispel") return cardName.massdispel;
            if (s == "crazedalchemist") return cardName.crazedalchemist;
            if (s == "shadowmadness") return cardName.shadowmadness;
            if (s == "equality") return cardName.equality;
            if (s == "misha") return cardName.misha;
            if (s == "treant") return cardName.treant;
            if (s == "alarmobot") return cardName.alarmobot;
            if (s == "animalcompanion") return cardName.animalcompanion;
            if (s == "hatefulstrike") return cardName.hatefulstrike;
            if (s == "dream") return cardName.dream;
            if (s == "anubrekhan") return cardName.anubrekhan;
            if (s == "youngpriestess") return cardName.youngpriestess;
            if (s == "gadgetzanauctioneer") return cardName.gadgetzanauctioneer;
            if (s == "coneofcold") return cardName.coneofcold;
            if (s == "earthshock") return cardName.earthshock;
            if (s == "tirionfordring") return cardName.tirionfordring;
            if (s == "wailingsoul") return cardName.wailingsoul;
            if (s == "skeleton") return cardName.skeleton;
            if (s == "ironfurgrizzly") return cardName.ironfurgrizzly;
            if (s == "headcrack") return cardName.headcrack;
            if (s == "arcaneshot") return cardName.arcaneshot;
            if (s == "maexxna") return cardName.maexxna;
            if (s == "imp") return cardName.imp;
            if (s == "markofthehorsemen") return cardName.markofthehorsemen;
            if (s == "voidterror") return cardName.voidterror;
            if (s == "mortalcoil") return cardName.mortalcoil;
            if (s == "draw3cards") return cardName.draw3cards;
            if (s == "flameofazzinoth") return cardName.flameofazzinoth;
            if (s == "jainaproudmoore") return cardName.jainaproudmoore;
            if (s == "execute") return cardName.execute;
            if (s == "bloodlust") return cardName.bloodlust;
            if (s == "bananas") return cardName.bananas;
            if (s == "kidnapper") return cardName.kidnapper;
            if (s == "oldmurkeye") return cardName.oldmurkeye;
            if (s == "homingchicken") return cardName.homingchicken;
            if (s == "enableforattack") return cardName.enableforattack;
            if (s == "spellbender") return cardName.spellbender;
            if (s == "backstab") return cardName.backstab;
            if (s == "squirrel") return cardName.squirrel;
            if (s == "stalagg") return cardName.stalagg;
            if (s == "grandwidowfaerlina") return cardName.grandwidowfaerlina;
            if (s == "heavyaxe") return cardName.heavyaxe;
            if (s == "zwick") return cardName.zwick;
            if (s == "webwrap") return cardName.webwrap;
            if (s == "flamesofazzinoth") return cardName.flamesofazzinoth;
            if (s == "murlocwarleader") return cardName.murlocwarleader;
            if (s == "shadowstep") return cardName.shadowstep;
            if (s == "ancestralspirit") return cardName.ancestralspirit;
            if (s == "defenderofargus") return cardName.defenderofargus;
            if (s == "assassinsblade") return cardName.assassinsblade;
            if (s == "discard") return cardName.discard;
            if (s == "biggamehunter") return cardName.biggamehunter;
            if (s == "aldorpeacekeeper") return cardName.aldorpeacekeeper;
            if (s == "blizzard") return cardName.blizzard;
            if (s == "pandarenscout") return cardName.pandarenscout;
            if (s == "unleashthehounds") return cardName.unleashthehounds;
            if (s == "yseraawakens") return cardName.yseraawakens;
            if (s == "sap") return cardName.sap;
            if (s == "kelthuzad") return cardName.kelthuzad;
            if (s == "defiasbandit") return cardName.defiasbandit;
            if (s == "gnomishinventor") return cardName.gnomishinventor;
            if (s == "mindcontrol") return cardName.mindcontrol;
            if (s == "ravenholdtassassin") return cardName.ravenholdtassassin;
            if (s == "icelance") return cardName.icelance;
            if (s == "dispel") return cardName.dispel;
            if (s == "acidicswampooze") return cardName.acidicswampooze;
            if (s == "muklasbigbrother") return cardName.muklasbigbrother;
            if (s == "blessedchampion") return cardName.blessedchampion;
            if (s == "savannahhighmane") return cardName.savannahhighmane;
            if (s == "direwolfalpha") return cardName.direwolfalpha;
            if (s == "hoggersmash") return cardName.hoggersmash;
            if (s == "blessingofwisdom") return cardName.blessingofwisdom;
            if (s == "nourish") return cardName.nourish;
            if (s == "abusivesergeant") return cardName.abusivesergeant;
            if (s == "sylvanaswindrunner") return cardName.sylvanaswindrunner;
            if (s == "spore") return cardName.spore;
            if (s == "crueltaskmaster") return cardName.crueltaskmaster;
            if (s == "lightningbolt") return cardName.lightningbolt;
            if (s == "keeperofthegrove") return cardName.keeperofthegrove;
            if (s == "steadyshot") return cardName.steadyshot;
            if (s == "multishot") return cardName.multishot;
            if (s == "harvest") return cardName.harvest;
            if (s == "instructorrazuvious") return cardName.instructorrazuvious;
            if (s == "ladyblaumeux") return cardName.ladyblaumeux;
            if (s == "jaybaxter") return cardName.jaybaxter;
            if (s == "molasses") return cardName.molasses;
            if (s == "pintsizedsummoner") return cardName.pintsizedsummoner;
            if (s == "spellbreaker") return cardName.spellbreaker;
            if (s == "anubarambusher") return cardName.anubarambusher;
            if (s == "deadlypoison") return cardName.deadlypoison;
            if (s == "stoneskingargoyle") return cardName.stoneskingargoyle;
            if (s == "bloodfury") return cardName.bloodfury;
            if (s == "fanofknives") return cardName.fanofknives;
            if (s == "poisoncloud") return cardName.poisoncloud;
            if (s == "shieldbearer") return cardName.shieldbearer;
            if (s == "sensedemons") return cardName.sensedemons;
            if (s == "shieldblock") return cardName.shieldblock;
            if (s == "handswapperminion") return cardName.handswapperminion;
            if (s == "massivegnoll") return cardName.massivegnoll;
            if (s == "deathcharger") return cardName.deathcharger;
            if (s == "ancientoflore") return cardName.ancientoflore;
            if (s == "oasissnapjaw") return cardName.oasissnapjaw;
            if (s == "illidanstormrage") return cardName.illidanstormrage;
            if (s == "frostwolfgrunt") return cardName.frostwolfgrunt;
            if (s == "lesserheal") return cardName.lesserheal;
            if (s == "infernal") return cardName.infernal;
            if (s == "wildpyromancer") return cardName.wildpyromancer;
            if (s == "razorfenhunter") return cardName.razorfenhunter;
            if (s == "twistingnether") return cardName.twistingnether;
            if (s == "voidcaller") return cardName.voidcaller;
            if (s == "leaderofthepack") return cardName.leaderofthepack;
            if (s == "malygos") return cardName.malygos;
            if (s == "becomehogger") return cardName.becomehogger;
            if (s == "baronrivendare") return cardName.baronrivendare;
            if (s == "millhousemanastorm") return cardName.millhousemanastorm;
            if (s == "innerfire") return cardName.innerfire;
            if (s == "valeerasanguinar") return cardName.valeerasanguinar;
            if (s == "chicken") return cardName.chicken;
            if (s == "souloftheforest") return cardName.souloftheforest;
            if (s == "silencedebug") return cardName.silencedebug;
            if (s == "bloodsailcorsair") return cardName.bloodsailcorsair;
            if (s == "slime") return cardName.slime;
            if (s == "tinkmasteroverspark") return cardName.tinkmasteroverspark;
            if (s == "iceblock") return cardName.iceblock;
            if (s == "brawl") return cardName.brawl;
            if (s == "vanish") return cardName.vanish;
            if (s == "poisonseeds") return cardName.poisonseeds;
            if (s == "murloc") return cardName.murloc;
            if (s == "mindspike") return cardName.mindspike;
            if (s == "kingmukla") return cardName.kingmukla;
            if (s == "stevengabriel") return cardName.stevengabriel;
            if (s == "gluth") return cardName.gluth;
            if (s == "truesilverchampion") return cardName.truesilverchampion;
            if (s == "harrisonjones") return cardName.harrisonjones;
            if (s == "destroydeck") return cardName.destroydeck;
            if (s == "devilsaur") return cardName.devilsaur;
            if (s == "wargolem") return cardName.wargolem;
            if (s == "warsongcommander") return cardName.warsongcommander;
            if (s == "manawyrm") return cardName.manawyrm;
            if (s == "thaddius") return cardName.thaddius;
            if (s == "savagery") return cardName.savagery;
            if (s == "spitefulsmith") return cardName.spitefulsmith;
            if (s == "shatteredsuncleric") return cardName.shatteredsuncleric;
            if (s == "eyeforaneye") return cardName.eyeforaneye;
            if (s == "azuredrake") return cardName.azuredrake;
            if (s == "mountaingiant") return cardName.mountaingiant;
            if (s == "korkronelite") return cardName.korkronelite;
            if (s == "junglepanther") return cardName.junglepanther;
            if (s == "barongeddon") return cardName.barongeddon;
            if (s == "spectralspider") return cardName.spectralspider;
            if (s == "pitlord") return cardName.pitlord;
            if (s == "markofnature") return cardName.markofnature;
            if (s == "grobbulus") return cardName.grobbulus;
            if (s == "leokk") return cardName.leokk;
            if (s == "fierywaraxe") return cardName.fierywaraxe;
            if (s == "damage5") return cardName.damage5;
            if (s == "duplicate") return cardName.duplicate;
            if (s == "restore5") return cardName.restore5;
            if (s == "mindblast") return cardName.mindblast;
            if (s == "timberwolf") return cardName.timberwolf;
            if (s == "captaingreenskin") return cardName.captaingreenskin;
            if (s == "elvenarcher") return cardName.elvenarcher;
            if (s == "michaelschweitzer") return cardName.michaelschweitzer;
            if (s == "masterswordsmith") return cardName.masterswordsmith;
            if (s == "grommashhellscream") return cardName.grommashhellscream;
            if (s == "hound") return cardName.hound;
            if (s == "seagiant") return cardName.seagiant;
            if (s == "doomguard") return cardName.doomguard;
            if (s == "alakirthewindlord") return cardName.alakirthewindlord;
            if (s == "hyena") return cardName.hyena;
            if (s == "undertaker") return cardName.undertaker;
            if (s == "frothingberserker") return cardName.frothingberserker;
            if (s == "powerofthewild") return cardName.powerofthewild;
            if (s == "druidoftheclaw") return cardName.druidoftheclaw;
            if (s == "hellfire") return cardName.hellfire;
            if (s == "archmage") return cardName.archmage;
            if (s == "recklessrocketeer") return cardName.recklessrocketeer;
            if (s == "crazymonkey") return cardName.crazymonkey;
            if (s == "damageallbut1") return cardName.damageallbut1;
            if (s == "frostblast") return cardName.frostblast;
            if (s == "powerwordshield") return cardName.powerwordshield;
            if (s == "rainoffire") return cardName.rainoffire;
            if (s == "arcaneintellect") return cardName.arcaneintellect;
            if (s == "angrychicken") return cardName.angrychicken;
            if (s == "nerubianegg") return cardName.nerubianegg;
            if (s == "worshipper") return cardName.worshipper;
            if (s == "mindgames") return cardName.mindgames;
            if (s == "leeroyjenkins") return cardName.leeroyjenkins;
            if (s == "gurubashiberserker") return cardName.gurubashiberserker;
            if (s == "windspeaker") return cardName.windspeaker;
            if (s == "enableemotes") return cardName.enableemotes;
            if (s == "forceofnature") return cardName.forceofnature;
            if (s == "lightspawn") return cardName.lightspawn;
            if (s == "destroyamanacrystal") return cardName.destroyamanacrystal;
            if (s == "warglaiveofazzinoth") return cardName.warglaiveofazzinoth;
            if (s == "finkleeinhorn") return cardName.finkleeinhorn;
            if (s == "frostelemental") return cardName.frostelemental;
            if (s == "thoughtsteal") return cardName.thoughtsteal;
            if (s == "brianschwab") return cardName.brianschwab;
            if (s == "scavenginghyena") return cardName.scavenginghyena;
            if (s == "si7agent") return cardName.si7agent;
            if (s == "prophetvelen") return cardName.prophetvelen;
            if (s == "soulfire") return cardName.soulfire;
            if (s == "ogremagi") return cardName.ogremagi;
            if (s == "damagedgolem") return cardName.damagedgolem;
            if (s == "crash") return cardName.crash;
            if (s == "adrenalinerush") return cardName.adrenalinerush;
            if (s == "murloctidecaller") return cardName.murloctidecaller;
            if (s == "kirintormage") return cardName.kirintormage;
            if (s == "spectralrider") return cardName.spectralrider;
            if (s == "thrallmarfarseer") return cardName.thrallmarfarseer;
            if (s == "frostwolfwarlord") return cardName.frostwolfwarlord;
            if (s == "sorcerersapprentice") return cardName.sorcerersapprentice;
            if (s == "feugen") return cardName.feugen;
            if (s == "willofmukla") return cardName.willofmukla;
            if (s == "holyfire") return cardName.holyfire;
            if (s == "manawraith") return cardName.manawraith;
            if (s == "argentsquire") return cardName.argentsquire;
            if (s == "placeholdercard") return cardName.placeholdercard;
            if (s == "snakeball") return cardName.snakeball;
            if (s == "ancientwatcher") return cardName.ancientwatcher;
            if (s == "noviceengineer") return cardName.noviceengineer;
            if (s == "stonetuskboar") return cardName.stonetuskboar;
            if (s == "ancestralhealing") return cardName.ancestralhealing;
            if (s == "conceal") return cardName.conceal;
            if (s == "arcanitereaper") return cardName.arcanitereaper;
            if (s == "guldan") return cardName.guldan;
            if (s == "ragingworgen") return cardName.ragingworgen;
            if (s == "earthenringfarseer") return cardName.earthenringfarseer;
            if (s == "onyxia") return cardName.onyxia;
            if (s == "manaaddict") return cardName.manaaddict;
            if (s == "unholyshadow") return cardName.unholyshadow;
            if (s == "dualwarglaives") return cardName.dualwarglaives;
            if (s == "sludgebelcher") return cardName.sludgebelcher;
            if (s == "worthlessimp") return cardName.worthlessimp;
            if (s == "shiv") return cardName.shiv;
            if (s == "sheep") return cardName.sheep;
            if (s == "bloodknight") return cardName.bloodknight;
            if (s == "holysmite") return cardName.holysmite;
            if (s == "ancientsecrets") return cardName.ancientsecrets;
            if (s == "holywrath") return cardName.holywrath;
            if (s == "ironforgerifleman") return cardName.ironforgerifleman;
            if (s == "elitetaurenchieftain") return cardName.elitetaurenchieftain;
            if (s == "spectralwarrior") return cardName.spectralwarrior;
            if (s == "bluegillwarrior") return cardName.bluegillwarrior;
            if (s == "shapeshift") return cardName.shapeshift;
            if (s == "hamiltonchu") return cardName.hamiltonchu;
            if (s == "battlerage") return cardName.battlerage;
            if (s == "nightblade") return cardName.nightblade;
            if (s == "locustswarm") return cardName.locustswarm;
            if (s == "crazedhunter") return cardName.crazedhunter;
            if (s == "andybrock") return cardName.andybrock;
            if (s == "youthfulbrewmaster") return cardName.youthfulbrewmaster;
            if (s == "theblackknight") return cardName.theblackknight;
            if (s == "brewmaster") return cardName.brewmaster;
            if (s == "lifetap") return cardName.lifetap;
            if (s == "demonfire") return cardName.demonfire;
            if (s == "redemption") return cardName.redemption;
            if (s == "lordjaraxxus") return cardName.lordjaraxxus;
            if (s == "coldblood") return cardName.coldblood;
            if (s == "lightwarden") return cardName.lightwarden;
            if (s == "questingadventurer") return cardName.questingadventurer;
            if (s == "donothing") return cardName.donothing;
            if (s == "dereksakamoto") return cardName.dereksakamoto;
            if (s == "poultryizer") return cardName.poultryizer;
            if (s == "koboldgeomancer") return cardName.koboldgeomancer;
            if (s == "legacyoftheemperor") return cardName.legacyoftheemperor;
            if (s == "eruption") return cardName.eruption;
            if (s == "cenarius") return cardName.cenarius;
            if (s == "deathlord") return cardName.deathlord;
            if (s == "searingtotem") return cardName.searingtotem;
            if (s == "taurenwarrior") return cardName.taurenwarrior;
            if (s == "explosivetrap") return cardName.explosivetrap;
            if (s == "frog") return cardName.frog;
            if (s == "servercrash") return cardName.servercrash;
            if (s == "wickedknife") return cardName.wickedknife;
            if (s == "laughingsister") return cardName.laughingsister;
            if (s == "cultmaster") return cardName.cultmaster;
            if (s == "wildgrowth") return cardName.wildgrowth;
            if (s == "sprint") return cardName.sprint;
            if (s == "masterofdisguise") return cardName.masterofdisguise;
            if (s == "kyleharrison") return cardName.kyleharrison;
            if (s == "avatarofthecoin") return cardName.avatarofthecoin;
            if (s == "excessmana") return cardName.excessmana;
            if (s == "spiritwolf") return cardName.spiritwolf;
            if (s == "auchenaisoulpriest") return cardName.auchenaisoulpriest;
            if (s == "bestialwrath") return cardName.bestialwrath;
            if (s == "rockbiterweapon") return cardName.rockbiterweapon;
            if (s == "starvingbuzzard") return cardName.starvingbuzzard;
            if (s == "mirrorimage") return cardName.mirrorimage;
            if (s == "frozenchampion") return cardName.frozenchampion;
            if (s == "silverhandrecruit") return cardName.silverhandrecruit;
            if (s == "corruption") return cardName.corruption;
            if (s == "preparation") return cardName.preparation;
            if (s == "cairnebloodhoof") return cardName.cairnebloodhoof;
            if (s == "mortalstrike") return cardName.mortalstrike;
            if (s == "flare") return cardName.flare;
            if (s == "necroknight") return cardName.necroknight;
            if (s == "silverhandknight") return cardName.silverhandknight;
            if (s == "breakweapon") return cardName.breakweapon;
            if (s == "guardianofkings") return cardName.guardianofkings;
            if (s == "ancientbrewmaster") return cardName.ancientbrewmaster;
            if (s == "avenge") return cardName.avenge;
            if (s == "youngdragonhawk") return cardName.youngdragonhawk;
            if (s == "frostshock") return cardName.frostshock;
            if (s == "healingtouch") return cardName.healingtouch;
            if (s == "venturecomercenary") return cardName.venturecomercenary;
            if (s == "unbalancingstrike") return cardName.unbalancingstrike;
            if (s == "sacrificialpact") return cardName.sacrificialpact;
            if (s == "noooooooooooo") return cardName.noooooooooooo;
            if (s == "baneofdoom") return cardName.baneofdoom;
            if (s == "abomination") return cardName.abomination;
            if (s == "flesheatingghoul") return cardName.flesheatingghoul;
            if (s == "loothoarder") return cardName.loothoarder;
            if (s == "mill10") return cardName.mill10;
            if (s == "sapphiron") return cardName.sapphiron;
            if (s == "jasonchayes") return cardName.jasonchayes;
            if (s == "benbrode") return cardName.benbrode;
            if (s == "betrayal") return cardName.betrayal;
            if (s == "thebeast") return cardName.thebeast;
            if (s == "flameimp") return cardName.flameimp;
            if (s == "freezingtrap") return cardName.freezingtrap;
            if (s == "southseadeckhand") return cardName.southseadeckhand;
            if (s == "wrath") return cardName.wrath;
            if (s == "bloodfenraptor") return cardName.bloodfenraptor;
            if (s == "cleave") return cardName.cleave;
            if (s == "fencreeper") return cardName.fencreeper;
            if (s == "restore1") return cardName.restore1;
            if (s == "handtodeck") return cardName.handtodeck;
            if (s == "starfire") return cardName.starfire;
            if (s == "goldshirefootman") return cardName.goldshirefootman;
            if (s == "unrelentingtrainee") return cardName.unrelentingtrainee;
            if (s == "murlocscout") return cardName.murlocscout;
            if (s == "ragnarosthefirelord") return cardName.ragnarosthefirelord;
            if (s == "rampage") return cardName.rampage;
            if (s == "zombiechow") return cardName.zombiechow;
            if (s == "thrall") return cardName.thrall;
            if (s == "stoneclawtotem") return cardName.stoneclawtotem;
            if (s == "captainsparrot") return cardName.captainsparrot;
            if (s == "windfuryharpy") return cardName.windfuryharpy;
            if (s == "unrelentingwarrior") return cardName.unrelentingwarrior;
            if (s == "stranglethorntiger") return cardName.stranglethorntiger;
            if (s == "summonarandomsecret") return cardName.summonarandomsecret;
            if (s == "circleofhealing") return cardName.circleofhealing;
            if (s == "snaketrap") return cardName.snaketrap;
            if (s == "cabalshadowpriest") return cardName.cabalshadowpriest;
            if (s == "nerubarweblord") return cardName.nerubarweblord;
            if (s == "upgrade") return cardName.upgrade;
            if (s == "shieldslam") return cardName.shieldslam;
            if (s == "flameburst") return cardName.flameburst;
            if (s == "windfury") return cardName.windfury;
            if (s == "enrage") return cardName.enrage;
            if (s == "natpagle") return cardName.natpagle;
            if (s == "restoreallhealth") return cardName.restoreallhealth;
            if (s == "houndmaster") return cardName.houndmaster;
            if (s == "waterelemental") return cardName.waterelemental;
            if (s == "eaglehornbow") return cardName.eaglehornbow;
            if (s == "gnoll") return cardName.gnoll;
            if (s == "archmageantonidas") return cardName.archmageantonidas;
            if (s == "destroyallheroes") return cardName.destroyallheroes;
            if (s == "chains") return cardName.chains;
            if (s == "wrathofairtotem") return cardName.wrathofairtotem;
            if (s == "killcommand") return cardName.killcommand;
            if (s == "manatidetotem") return cardName.manatidetotem;
            if (s == "daggermastery") return cardName.daggermastery;
            if (s == "drainlife") return cardName.drainlife;
            if (s == "doomsayer") return cardName.doomsayer;
            if (s == "darkscalehealer") return cardName.darkscalehealer;
            if (s == "shadowform") return cardName.shadowform;
            if (s == "frostnova") return cardName.frostnova;
            if (s == "purecold") return cardName.purecold;
            if (s == "mirrorentity") return cardName.mirrorentity;
            if (s == "counterspell") return cardName.counterspell;
            if (s == "mindshatter") return cardName.mindshatter;
            if (s == "magmarager") return cardName.magmarager;
            if (s == "wolfrider") return cardName.wolfrider;
            if (s == "emboldener3000") return cardName.emboldener3000;
            if (s == "polarityshift") return cardName.polarityshift;
            if (s == "gelbinmekkatorque") return cardName.gelbinmekkatorque;
            if (s == "webspinner") return cardName.webspinner;
            if (s == "utherlightbringer") return cardName.utherlightbringer;
            if (s == "innerrage") return cardName.innerrage;
            if (s == "emeralddrake") return cardName.emeralddrake;
            if (s == "forceaitouseheropower") return cardName.forceaitouseheropower;
            if (s == "echoingooze") return cardName.echoingooze;
            if (s == "heroicstrike") return cardName.heroicstrike;
            if (s == "hauntedcreeper") return cardName.hauntedcreeper;
            if (s == "barreltoss") return cardName.barreltoss;
            if (s == "yongwoo") return cardName.yongwoo;
            if (s == "doomhammer") return cardName.doomhammer;
            if (s == "stomp") return cardName.stomp;
            if (s == "spectralknight") return cardName.spectralknight;
            if (s == "tracking") return cardName.tracking;
            if (s == "fireball") return cardName.fireball;
            if (s == "thecoin") return cardName.thecoin;
            if (s == "bootybaybodyguard") return cardName.bootybaybodyguard;
            if (s == "scarletcrusader") return cardName.scarletcrusader;
            if (s == "voodoodoctor") return cardName.voodoodoctor;
            if (s == "shadowbolt") return cardName.shadowbolt;
            if (s == "etherealarcanist") return cardName.etherealarcanist;
            if (s == "succubus") return cardName.succubus;
            if (s == "emperorcobra") return cardName.emperorcobra;
            if (s == "deadlyshot") return cardName.deadlyshot;
            if (s == "reinforce") return cardName.reinforce;
            if (s == "supercharge") return cardName.supercharge;
            if (s == "claw") return cardName.claw;
            if (s == "explosiveshot") return cardName.explosiveshot;
            if (s == "avengingwrath") return cardName.avengingwrath;
            if (s == "riverpawgnoll") return cardName.riverpawgnoll;
            if (s == "sirzeliek") return cardName.sirzeliek;
            if (s == "argentprotector") return cardName.argentprotector;
            if (s == "hiddengnome") return cardName.hiddengnome;
            if (s == "felguard") return cardName.felguard;
            if (s == "northshirecleric") return cardName.northshirecleric;
            if (s == "plague") return cardName.plague;
            if (s == "lepergnome") return cardName.lepergnome;
            if (s == "fireelemental") return cardName.fireelemental;
            if (s == "armorup") return cardName.armorup;
            if (s == "snipe") return cardName.snipe;
            if (s == "southseacaptain") return cardName.southseacaptain;
            if (s == "catform") return cardName.catform;
            if (s == "bite") return cardName.bite;
            if (s == "defiasringleader") return cardName.defiasringleader;
            if (s == "harvestgolem") return cardName.harvestgolem;
            if (s == "kingkrush") return cardName.kingkrush;
            if (s == "aibuddydamageownhero5") return cardName.aibuddydamageownhero5;
            if (s == "healingtotem") return cardName.healingtotem;
            if (s == "ericdodds") return cardName.ericdodds;
            if (s == "demigodsfavor") return cardName.demigodsfavor;
            if (s == "huntersmark") return cardName.huntersmark;
            if (s == "dalaranmage") return cardName.dalaranmage;
            if (s == "twilightdrake") return cardName.twilightdrake;
            if (s == "coldlightoracle") return cardName.coldlightoracle;
            if (s == "shadeofnaxxramas") return cardName.shadeofnaxxramas;
            if (s == "moltengiant") return cardName.moltengiant;
            if (s == "deathbloom") return cardName.deathbloom;
            if (s == "shadowflame") return cardName.shadowflame;
            if (s == "anduinwrynn") return cardName.anduinwrynn;
            if (s == "argentcommander") return cardName.argentcommander;
            if (s == "revealhand") return cardName.revealhand;
            if (s == "arcanemissiles") return cardName.arcanemissiles;
            if (s == "repairbot") return cardName.repairbot;
            if (s == "unstableghoul") return cardName.unstableghoul;
            if (s == "ancientofwar") return cardName.ancientofwar;
            if (s == "stormwindchampion") return cardName.stormwindchampion;
            if (s == "summonapanther") return cardName.summonapanther;
            if (s == "mrbigglesworth") return cardName.mrbigglesworth;
            if (s == "swipe") return cardName.swipe;
            if (s == "aihelperbuddy") return cardName.aihelperbuddy;
            if (s == "hex") return cardName.hex;
            if (s == "ysera") return cardName.ysera;
            if (s == "arcanegolem") return cardName.arcanegolem;
            if (s == "bloodimp") return cardName.bloodimp;
            if (s == "pyroblast") return cardName.pyroblast;
            if (s == "murlocraider") return cardName.murlocraider;
            if (s == "faeriedragon") return cardName.faeriedragon;
            if (s == "sinisterstrike") return cardName.sinisterstrike;
            if (s == "poweroverwhelming") return cardName.poweroverwhelming;
            if (s == "arcaneexplosion") return cardName.arcaneexplosion;
            if (s == "shadowwordpain") return cardName.shadowwordpain;
            if (s == "mill30") return cardName.mill30;
            if (s == "noblesacrifice") return cardName.noblesacrifice;
            if (s == "dreadinfernal") return cardName.dreadinfernal;
            if (s == "naturalize") return cardName.naturalize;
            if (s == "totemiccall") return cardName.totemiccall;
            if (s == "secretkeeper") return cardName.secretkeeper;
            if (s == "dreadcorsair") return cardName.dreadcorsair;
            if (s == "jaws") return cardName.jaws;
            if (s == "forkedlightning") return cardName.forkedlightning;
            if (s == "reincarnate") return cardName.reincarnate;
            if (s == "handofprotection") return cardName.handofprotection;
            if (s == "noththeplaguebringer") return cardName.noththeplaguebringer;
            if (s == "vaporize") return cardName.vaporize;
            if (s == "frostbreath") return cardName.frostbreath;
            if (s == "nozdormu") return cardName.nozdormu;
            if (s == "divinespirit") return cardName.divinespirit;
            if (s == "transcendence") return cardName.transcendence;
            if (s == "armorsmith") return cardName.armorsmith;
            if (s == "murloctidehunter") return cardName.murloctidehunter;
            if (s == "stealcard") return cardName.stealcard;
            if (s == "opponentconcede") return cardName.opponentconcede;
            if (s == "tundrarhino") return cardName.tundrarhino;
            if (s == "summoningportal") return cardName.summoningportal;
            if (s == "hammerofwrath") return cardName.hammerofwrath;
            if (s == "stormwindknight") return cardName.stormwindknight;
            if (s == "freeze") return cardName.freeze;
            if (s == "madbomber") return cardName.madbomber;
            if (s == "consecration") return cardName.consecration;
            if (s == "spectraltrainee") return cardName.spectraltrainee;
            if (s == "boar") return cardName.boar;
            if (s == "knifejuggler") return cardName.knifejuggler;
            if (s == "icebarrier") return cardName.icebarrier;
            if (s == "mechanicaldragonling") return cardName.mechanicaldragonling;
            if (s == "battleaxe") return cardName.battleaxe;
            if (s == "lightsjustice") return cardName.lightsjustice;
            if (s == "lavaburst") return cardName.lavaburst;
            if (s == "mindcontroltech") return cardName.mindcontroltech;
            if (s == "boulderfistogre") return cardName.boulderfistogre;
            if (s == "fireblast") return cardName.fireblast;
            if (s == "priestessofelune") return cardName.priestessofelune;
            if (s == "ancientmage") return cardName.ancientmage;
            if (s == "shadowworddeath") return cardName.shadowworddeath;
            if (s == "ironbeakowl") return cardName.ironbeakowl;
            if (s == "eviscerate") return cardName.eviscerate;
            if (s == "repentance") return cardName.repentance;
            if (s == "understudy") return cardName.understudy;
            if (s == "sunwalker") return cardName.sunwalker;
            if (s == "nagamyrmidon") return cardName.nagamyrmidon;
            if (s == "destroyheropower") return cardName.destroyheropower;
            if (s == "skeletalsmith") return cardName.skeletalsmith;
            if (s == "slam") return cardName.slam;
            if (s == "swordofjustice") return cardName.swordofjustice;
            if (s == "bounce") return cardName.bounce;
            if (s == "shadopanmonk") return cardName.shadopanmonk;
            if (s == "whirlwind") return cardName.whirlwind;
            if (s == "alexstrasza") return cardName.alexstrasza;
            if (s == "silence") return cardName.silence;
            if (s == "rexxar") return cardName.rexxar;
            if (s == "voidwalker") return cardName.voidwalker;
            if (s == "whelp") return cardName.whelp;
            if (s == "flamestrike") return cardName.flamestrike;
            if (s == "rivercrocolisk") return cardName.rivercrocolisk;
            if (s == "stormforgedaxe") return cardName.stormforgedaxe;
            if (s == "snake") return cardName.snake;
            if (s == "shotgunblast") return cardName.shotgunblast;
            if (s == "violetapprentice") return cardName.violetapprentice;
            if (s == "templeenforcer") return cardName.templeenforcer;
            if (s == "ashbringer") return cardName.ashbringer;
            if (s == "impmaster") return cardName.impmaster;
            if (s == "defender") return cardName.defender;
            if (s == "savageroar") return cardName.savageroar;
            if (s == "innervate") return cardName.innervate;
            if (s == "inferno") return cardName.inferno;
            if (s == "falloutslime") return cardName.falloutslime;
            if (s == "earthelemental") return cardName.earthelemental;
            if (s == "facelessmanipulator") return cardName.facelessmanipulator;
            if (s == "mindpocalypse") return cardName.mindpocalypse;
            if (s == "divinefavor") return cardName.divinefavor;
            if (s == "aibuddydestroyminions") return cardName.aibuddydestroyminions;
            if (s == "demolisher") return cardName.demolisher;
            if (s == "sunfuryprotector") return cardName.sunfuryprotector;
            if (s == "dustdevil") return cardName.dustdevil;
            if (s == "powerofthehorde") return cardName.powerofthehorde;
            if (s == "dancingswords") return cardName.dancingswords;
            if (s == "holylight") return cardName.holylight;
            if (s == "feralspirit") return cardName.feralspirit;
            if (s == "raidleader") return cardName.raidleader;
            if (s == "amaniberserker") return cardName.amaniberserker;
            if (s == "ironbarkprotector") return cardName.ironbarkprotector;
            if (s == "bearform") return cardName.bearform;
            if (s == "deathwing") return cardName.deathwing;
            if (s == "stormpikecommando") return cardName.stormpikecommando;
            if (s == "squire") return cardName.squire;
            if (s == "panther") return cardName.panther;
            if (s == "silverbackpatriarch") return cardName.silverbackpatriarch;
            if (s == "bobfitch") return cardName.bobfitch;
            if (s == "gladiatorslongbow") return cardName.gladiatorslongbow;
            if (s == "damage1") return cardName.damage1;
            return cardName.unknown;
        }

        /// <summary>
        /// The error type 2.
        /// </summary>
        public enum ErrorType2
        {
            /// <summary>
            /// The none.
            /// </summary>
            NONE, // =0

            /// <summary>
            /// The re q_ minio n_ target.
            /// </summary>
            REQ_MINION_TARGET, // =1

            /// <summary>
            /// The re q_ friendl y_ target.
            /// </summary>
            REQ_FRIENDLY_TARGET, // =2

            /// <summary>
            /// The re q_ enem y_ target.
            /// </summary>
            REQ_ENEMY_TARGET, // =3

            /// <summary>
            /// The re q_ damage d_ target.
            /// </summary>
            REQ_DAMAGED_TARGET, // =4

            /// <summary>
            /// The re q_ enchante d_ target.
            /// </summary>
            REQ_ENCHANTED_TARGET, 

            /// <summary>
            /// The re q_ froze n_ target.
            /// </summary>
            REQ_FROZEN_TARGET, 

            /// <summary>
            /// The re q_ charg e_ target.
            /// </summary>
            REQ_CHARGE_TARGET, 

            /// <summary>
            /// The re q_ targe t_ ma x_ attack.
            /// </summary>
            REQ_TARGET_MAX_ATTACK, // =8

            /// <summary>
            /// The re q_ nonsel f_ target.
            /// </summary>
            REQ_NONSELF_TARGET, // =9

            /// <summary>
            /// The re q_ targe t_ wit h_ race.
            /// </summary>
            REQ_TARGET_WITH_RACE, // =10

            /// <summary>
            /// The re q_ targe t_ t o_ play.
            /// </summary>
            REQ_TARGET_TO_PLAY, // =11 

            /// <summary>
            /// The re q_ nu m_ minio n_ slots.
            /// </summary>
            REQ_NUM_MINION_SLOTS, // =12 

            /// <summary>
            /// The re q_ weapo n_ equipped.
            /// </summary>
            REQ_WEAPON_EQUIPPED, // =13

            /// <summary>
            /// The re q_ enoug h_ mana.
            /// </summary>
            REQ_ENOUGH_MANA, // =14

            /// <summary>
            /// The re q_ you r_ turn.
            /// </summary>
            REQ_YOUR_TURN, 

            /// <summary>
            /// The re q_ nonstealt h_ enem y_ target.
            /// </summary>
            REQ_NONSTEALTH_ENEMY_TARGET, 

            /// <summary>
            /// The re q_ her o_ target.
            /// </summary>
            REQ_HERO_TARGET, // 17

            /// <summary>
            /// The re q_ secre t_ cap.
            /// </summary>
            REQ_SECRET_CAP, 

            /// <summary>
            /// The re q_ minio n_ ca p_ i f_ targe t_ available.
            /// </summary>
            REQ_MINION_CAP_IF_TARGET_AVAILABLE, // 19

            /// <summary>
            /// The re q_ minio n_ cap.
            /// </summary>
            REQ_MINION_CAP, 

            /// <summary>
            /// The re q_ targe t_ attacke d_ thi s_ turn.
            /// </summary>
            REQ_TARGET_ATTACKED_THIS_TURN, 

            /// <summary>
            /// The re q_ targe t_ i f_ available.
            /// </summary>
            REQ_TARGET_IF_AVAILABLE, // =22

            /// <summary>
            /// The re q_ minimu m_ enem y_ minions.
            /// </summary>
            REQ_MINIMUM_ENEMY_MINIONS, // =23 /like spalen :D

            /// <summary>
            /// The re q_ targe t_ fo r_ combo.
            /// </summary>
            REQ_TARGET_FOR_COMBO, // =24

            /// <summary>
            /// The re q_ no t_ exhauste d_ activate.
            /// </summary>
            REQ_NOT_EXHAUSTED_ACTIVATE, 

            /// <summary>
            /// The re q_ uniqu e_ secret.
            /// </summary>
            REQ_UNIQUE_SECRET, 

            /// <summary>
            /// The re q_ targe t_ taunter.
            /// </summary>
            REQ_TARGET_TAUNTER, 

            /// <summary>
            /// The re q_ ca n_ b e_ attacked.
            /// </summary>
            REQ_CAN_BE_ATTACKED, 

            /// <summary>
            /// The re q_ actio n_ pw r_ i s_ maste r_ pwr.
            /// </summary>
            REQ_ACTION_PWR_IS_MASTER_PWR, 

            /// <summary>
            /// The re q_ targe t_ magnet.
            /// </summary>
            REQ_TARGET_MAGNET, 

            /// <summary>
            /// The re q_ attac k_ greate r_ tha n_0.
            /// </summary>
            REQ_ATTACK_GREATER_THAN_0, 

            /// <summary>
            /// The re q_ attacke r_ no t_ frozen.
            /// </summary>
            REQ_ATTACKER_NOT_FROZEN, 

            /// <summary>
            /// The re q_ her o_ o r_ minio n_ target.
            /// </summary>
            REQ_HERO_OR_MINION_TARGET, 

            /// <summary>
            /// The re q_ ca n_ b e_ targete d_ b y_ spells.
            /// </summary>
            REQ_CAN_BE_TARGETED_BY_SPELLS, 

            /// <summary>
            /// The re q_ subcar d_ i s_ playable.
            /// </summary>
            REQ_SUBCARD_IS_PLAYABLE, 

            /// <summary>
            /// The re q_ targe t_ fo r_ n o_ combo.
            /// </summary>
            REQ_TARGET_FOR_NO_COMBO, 

            /// <summary>
            /// The re q_ no t_ minio n_ jus t_ played.
            /// </summary>
            REQ_NOT_MINION_JUST_PLAYED, 

            /// <summary>
            /// The re q_ no t_ exhauste d_ her o_ power.
            /// </summary>
            REQ_NOT_EXHAUSTED_HERO_POWER, 

            /// <summary>
            /// The re q_ ca n_ b e_ targete d_ b y_ opponents.
            /// </summary>
            REQ_CAN_BE_TARGETED_BY_OPPONENTS, 

            /// <summary>
            /// The re q_ attacke r_ ca n_ attack.
            /// </summary>
            REQ_ATTACKER_CAN_ATTACK, 

            /// <summary>
            /// The re q_ targe t_ mi n_ attack.
            /// </summary>
            REQ_TARGET_MIN_ATTACK, // =41

            /// <summary>
            /// The re q_ ca n_ b e_ targete d_ b y_ her o_ powers.
            /// </summary>
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS, 

            /// <summary>
            /// The re q_ enem y_ targe t_ no t_ immune.
            /// </summary>
            REQ_ENEMY_TARGET_NOT_IMMUNE, 

            /// <summary>
            /// The re q_ entir e_ entourag e_ no t_ i n_ play.
            /// </summary>
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY, // 44 (totemic call)

            /// <summary>
            /// The re q_ minimu m_ tota l_ minions.
            /// </summary>
            REQ_MINIMUM_TOTAL_MINIONS, // 45 (scharmuetzel)

            /// <summary>
            /// The re q_ mus t_ targe t_ taunter.
            /// </summary>
            REQ_MUST_TARGET_TAUNTER, // =46

            /// <summary>
            /// The re q_ undamage d_ target.
            /// </summary>
            REQ_UNDAMAGED_TARGET// =47
        }

        /// <summary>
        /// The card.
        /// </summary>
        public class Card
        {
            // public string CardID = "";
            /// <summary>
            /// The name.
            /// </summary>
            public cardName name = cardName.unknown;

            /// <summary>
            /// The race.
            /// </summary>
            public int race = 0;

            /// <summary>
            /// The rarity.
            /// </summary>
            public int rarity = 0;

            /// <summary>
            /// The cost.
            /// </summary>
            public int cost = 0;

            /// <summary>
            /// The type.
            /// </summary>
            public cardtype type = cardtype.NONE;

            // public string description = "";

            /// <summary>
            /// The attack.
            /// </summary>
            public int Attack = 0;

            /// <summary>
            /// The health.
            /// </summary>
            public int Health = 0;

            /// <summary>
            /// The durability.
            /// </summary>
            public int Durability = 0; // for weapons

            /// <summary>
            /// The target.
            /// </summary>
            public bool target = false;

            // public string targettext = "";
            /// <summary>
            /// The tank.
            /// </summary>
            public bool tank = false;

            /// <summary>
            /// The silence.
            /// </summary>
            public bool Silence = false;

            /// <summary>
            /// The choice.
            /// </summary>
            public bool choice = false;

            /// <summary>
            /// The windfury.
            /// </summary>
            public bool windfury = false;

            /// <summary>
            /// The poisionous.
            /// </summary>
            public bool poisionous = false;

            /// <summary>
            /// The deathrattle.
            /// </summary>
            public bool deathrattle = false;

            /// <summary>
            /// The battlecry.
            /// </summary>
            public bool battlecry = false;

            /// <summary>
            /// The one turn effect.
            /// </summary>
            public bool oneTurnEffect = false;

            /// <summary>
            /// The enrage.
            /// </summary>
            public bool Enrage = false;

            /// <summary>
            /// The aura.
            /// </summary>
            public bool Aura = false;

            /// <summary>
            /// The elite.
            /// </summary>
            public bool Elite = false;

            /// <summary>
            /// The combo.
            /// </summary>
            public bool Combo = false;

            /// <summary>
            /// The recall.
            /// </summary>
            public bool Recall = false;

            /// <summary>
            /// The recall value.
            /// </summary>
            public int recallValue = 0;

            /// <summary>
            /// The immune while attacking.
            /// </summary>
            public bool immuneWhileAttacking = false;

            /// <summary>
            /// The immune to spellpowerg.
            /// </summary>
            public bool immuneToSpellpowerg = false;

            /// <summary>
            /// The stealth.
            /// </summary>
            public bool Stealth = false;

            /// <summary>
            /// The freeze.
            /// </summary>
            public bool Freeze = false;

            /// <summary>
            /// The adjacent buff.
            /// </summary>
            public bool AdjacentBuff = false;

            /// <summary>
            /// The shield.
            /// </summary>
            public bool Shield = false;

            /// <summary>
            /// The charge.
            /// </summary>
            public bool Charge = false;

            /// <summary>
            /// The secret.
            /// </summary>
            public bool Secret = false;

            /// <summary>
            /// The morph.
            /// </summary>
            public bool Morph = false;

            /// <summary>
            /// The spellpower.
            /// </summary>
            public bool Spellpower = false;

            /// <summary>
            /// The grant charge.
            /// </summary>
            public bool GrantCharge = false;

            /// <summary>
            /// The heal target.
            /// </summary>
            public bool HealTarget = false;

            // playRequirements, reqID= siehe PlayErrors->ErrorType
            /// <summary>
            /// The need empty places for playing.
            /// </summary>
            public int needEmptyPlacesForPlaying = 0;

            /// <summary>
            /// The need with min attack value of.
            /// </summary>
            public int needWithMinAttackValueOf = 0;

            /// <summary>
            /// The need with max attack value of.
            /// </summary>
            public int needWithMaxAttackValueOf = 0;

            /// <summary>
            /// The need race for playing.
            /// </summary>
            public int needRaceForPlaying = 0;

            /// <summary>
            /// The need min number of enemy.
            /// </summary>
            public int needMinNumberOfEnemy = 0;

            /// <summary>
            /// The need min total minions.
            /// </summary>
            public int needMinTotalMinions = 0;

            /// <summary>
            /// The need minions cap if available.
            /// </summary>
            public int needMinionsCapIfAvailable = 0;

            // additional data
            /// <summary>
            /// The is token.
            /// </summary>
            public bool isToken = false;

            /// <summary>
            /// The is carddraw.
            /// </summary>
            public int isCarddraw = 0;

            /// <summary>
            /// The damages target.
            /// </summary>
            public bool damagesTarget = false;

            /// <summary>
            /// The damages target with special.
            /// </summary>
            public bool damagesTargetWithSpecial = false;

            /// <summary>
            /// The target priority.
            /// </summary>
            public int targetPriority = 0;

            /// <summary>
            /// The is special minion.
            /// </summary>
            public bool isSpecialMinion = false;

            /// <summary>
            /// The spellpowervalue.
            /// </summary>
            public int spellpowervalue = 0;

            /// <summary>
            /// The card i denum.
            /// </summary>
            public cardIDEnum cardIDenum = cardIDEnum.None;

            /// <summary>
            /// The playrequires.
            /// </summary>
            public List<ErrorType2> playrequires;

            /// <summary>
            /// The sim_card.
            /// </summary>
            public SimTemplate sim_card;

            /// <summary>
            /// Initializes a new instance of the <see cref="Card"/> class.
            /// </summary>
            public Card()
            {
                this.playrequires = new List<ErrorType2>();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Card"/> class.
            /// </summary>
            /// <param name="c">
            /// The c.
            /// </param>
            public Card(Card c)
            {
                // this.entityID = c.entityID;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;

                // this.CardID = c.CardID;
                this.Charge = c.Charge;
                this.choice = c.choice;
                this.Combo = c.Combo;
                this.cost = c.cost;
                this.deathrattle = c.deathrattle;

                // this.description = c.description;
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

                // this.targettext = c.targettext;
                this.type = c.type;
                this.windfury = c.windfury;
                this.cardIDenum = c.cardIDenum;
                this.sim_card = c.sim_card;
                this.isToken = c.isToken;
            }

            /// <summary>
            /// The is requirement in list.
            /// </summary>
            /// <param name="et">
            /// The et.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool isRequirementInList(ErrorType2 et)
            {
                if (this.playrequires.Contains(et))
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            /// The get targets for card.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="List"/>.
            /// </returns>
            public List<Minion> getTargetsForCard(Playfield p)
            {
                // todo make it faster!! 
                // todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++)
                {
                    ownMins[i] = false;
                }

                for (int i = 0; i < enemyMins.Length; i++)
                {
                    enemyMins[i] = false;
                }

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0)
                {
                    return retval;
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_TO_PLAY)
                    || this.isRequirementInList(ErrorType2.REQ_NONSELF_TARGET)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_IF_AVAILABLE)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                            && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister
                                || m.name == cardName.spectralknight))
                        {
                            continue;
                        }

                        ownMins[k] = true;
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                             && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister
                                 || m.name == cardName.spectralknight)) || m.stealth)
                        {
                            continue;
                        }

                        enemyMins[k] = true;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }

                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (this.isRequirementInList(ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_ENEMY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_DAMAGED_TARGET))
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

                if (this.isRequirementInList(ErrorType2.REQ_UNDAMAGED_TARGET))
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

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MAX_ATTACK))
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

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MIN_ATTACK))
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

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    if (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addOwnHero = true;
                    }

                    if (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addEnemyHero = true;
                    }

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

                if (this.isRequirementInList(ErrorType2.REQ_MUST_TARGET_TAUNTER))
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

                if (addEnemyHero)
                {
                    retval.Add(p.enemyHero);
                }

                if (addOwnHero)
                {
                    retval.Add(p.ownHero);
                }

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k])
                    {
                        retval.Add(m);
                    }
                }

                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k])
                    {
                        retval.Add(m);
                    }
                }

                return retval;
            }

            /// <summary>
            /// The get targets for card enemy.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="List"/>.
            /// </returns>
            public List<Minion> getTargetsForCardEnemy(Playfield p)
            {
                // todo make it faster!! 
                // todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++)
                {
                    ownMins[i] = false;
                }

                for (int i = 0; i < enemyMins.Length; i++)
                {
                    enemyMins[i] = false;
                }

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0)
                {
                    return retval;
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_TO_PLAY)
                    || this.isRequirementInList(ErrorType2.REQ_NONSELF_TARGET)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_IF_AVAILABLE)
                    || this.isRequirementInList(ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                             && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister
                                 || m.name == cardName.spectralknight)) || m.stealth)
                        {
                            continue;
                        }

                        ownMins[k] = true;
                    }

                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)
                            && (m.name == cardName.faeriedragon || m.name == cardName.laughingsister)
                            || m.name == cardName.spectralknight)
                        {
                            continue;
                        }

                        enemyMins[k] = true;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }

                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (this.isRequirementInList(ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++)
                    {
                        ownMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_ENEMY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++)
                    {
                        enemyMins[i] = false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_DAMAGED_TARGET))
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

                if (this.isRequirementInList(ErrorType2.REQ_UNDAMAGED_TARGET))
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

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MAX_ATTACK))
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

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_MIN_ATTACK))
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

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    if (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addOwnHero = true;
                    }

                    if (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON)
                    {
                        addEnemyHero = true;
                    }

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

                if (this.isRequirementInList(ErrorType2.REQ_MUST_TARGET_TAUNTER))
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

                if (addEnemyHero)
                {
                    retval.Add(p.enemyHero);
                }

                if (addOwnHero)
                {
                    retval.Add(p.ownHero);
                }

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k])
                    {
                        retval.Add(m);
                    }
                }

                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k])
                    {
                        retval.Add(m);
                    }
                }

                return retval;
            }

            /// <summary>
            /// The calculate mana cost.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <returns>
            /// The <see cref="int"/>.
            /// </returns>
            public int calculateManaCost(Playfield p)
            {
                // calculates the mana from orginal mana, needed for back-to hand effects
                int retval = this.cost;
                int offset = 0;

                if (this.type == cardtype.MOB)
                {
                    offset += p.soeldnerDerVenture * 3;

                    offset += p.managespenst;

                    int temp = -p.startedWithbeschwoerungsportal * 2;
                    if (retval + temp <= 0)
                    {
                        temp = -retval + 1;
                    }

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
                {
                    // if the number of zauberlehrlings change
                    offset -= p.anzOwnsorcerersapprentice;
                    if (p.playedPreparation)
                    {
                        // if the number of zauberlehrlings change
                        offset -= 3;
                    }
                }

                switch (this.name)
                {
                    case cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case cardName.moltengiant:
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

            /// <summary>
            /// The get mana cost.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <param name="currentcost">
            /// The currentcost.
            /// </param>
            /// <returns>
            /// The <see cref="int"/>.
            /// </returns>
            public int getManaCost(Playfield p, int currentcost)
            {
                // calculates mana from current mana
                int retval = currentcost;

                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################
                // Manacosts changes with soeldner der venture co.
                if (p.soeldnerDerVenture != p.startedWithsoeldnerDerVenture && this.type == cardtype.MOB)
                {
                    offset += (p.soeldnerDerVenture - p.startedWithsoeldnerDerVenture) * 3;
                }

                // Manacosts changes with mana-ghost
                if (p.managespenst != p.startedWithManagespenst && this.type == cardtype.MOB)
                {
                    offset += p.managespenst - p.startedWithManagespenst;
                }

                if (this.battlecry && p.nerubarweblord != p.startedWithnerubarweblord && this.type == cardtype.MOB)
                {
                    offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                }

                // CARDS that decrease the manacosts of others ##############################

                // Manacosts changes with the summoning-portal >_>
                if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal && this.type == cardtype.MOB)
                {
                    // cant lower the mana to 0
                    int temp = (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                    if (retval + temp <= 0)
                    {
                        temp = -retval + 1;
                    }

                    offset = offset + temp;
                }

                // Manacosts changes with the pint-sized summoner
                if (p.winzigebeschwoererin >= 1 && p.mobsplayedThisTurn >= 1 && p.startedWithMobsPlayedThisTurn == 0
                    && this.type == cardtype.MOB)
                {
                    // if we start oure calculations with 0 mobs played, then the cardcost are 1 mana to low in the further calculations (with the little summoner on field)
                    offset += p.winzigebeschwoererin;
                }

                if (p.mobsplayedThisTurn == 0 && p.winzigebeschwoererin <= p.startedWithWinzigebeschwoererin
                    && this.type == cardtype.MOB)
                {
                    // one pint-sized summoner got killed, before we played the first mob -> the manacost are higher of all mobs
                    offset += p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin;
                }

                // Manacosts changes with the zauberlehrling summoner
                if (p.anzOwnsorcerersapprentice != p.anzOwnsorcerersapprenticeStarted && this.type == cardtype.SPELL)
                {
                    // if the number of zauberlehrlings change
                    offset += p.anzOwnsorcerersapprenticeStarted - p.anzOwnsorcerersapprentice;
                }

                // manacosts are lowered, after we played preparation
                if (p.playedPreparation && this.type == cardtype.SPELL)
                {
                    // if the number of zauberlehrlings change
                    offset -= 3;
                }

                switch (this.name)
                {
                    case cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack + p.ownWeaponAttackStarted;
                            
                            // if weapon attack change we change manacost
                        break;
                    case cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted;
                        break;
                    case cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case cardName.moltengiant:
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

            /// <summary>
            /// The canplay card.
            /// </summary>
            /// <param name="p">
            /// The p.
            /// </param>
            /// <param name="manacost">
            /// The manacost.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool canplayCard(Playfield p, int manacost)
            {
                // is playrequirement?
                bool haveToDoRequires = this.isRequirementInList(ErrorType2.REQ_TARGET_TO_PLAY);
                bool retval = true;

                // cant play if i have to few mana
                if (p.mana < this.getManaCost(p, manacost))
                {
                    return false;
                }

                // cant play mob, if i have allready 7 mininos
                if (this.type == cardtype.MOB && p.ownMinions.Count >= 7)
                {
                    return false;
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINIMUM_ENEMY_MINIONS))
                {
                    if (p.enemyMinions.Count < this.needMinNumberOfEnemy)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_NUM_MINION_SLOTS))
                {
                    if (p.ownMinions.Count > 7 - this.needEmptyPlacesForPlaying)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_WEAPON_EQUIPPED))
                {
                    if (p.ownWeaponName == cardName.unknown)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_MINIMUM_TOTAL_MINIONS))
                {
                    if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count)
                    {
                        return false;
                    }
                }

                if (haveToDoRequires)
                {
                    if (this.getTargetsForCard(p).Count == 0)
                    {
                        return false;
                    }

                    // it requires a target-> return false if 
                }

                if (this.isRequirementInList(ErrorType2.REQ_TARGET_IF_AVAILABLE)
                    && this.isRequirementInList(ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE))
                {
                    if (this.getTargetsForCard(p).Count >= 1 && p.ownMinions.Count > 7 - this.needMinionsCapIfAvailable)
                    {
                        return false;
                    }
                }

                if (this.isRequirementInList(ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY))
                {
                    int difftotem = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.name == cardName.healingtotem || m.name == cardName.wrathofairtotem
                            || m.name == cardName.searingtotem || m.name == cardName.stoneclawtotem)
                        {
                            difftotem++;
                        }
                    }

                    if (difftotem == 4)
                    {
                        return false;
                    }
                }

                if (this.Secret)
                {
                    if (p.ownSecretsIDList.Contains(this.cardIDenum))
                    {
                        return false;
                    }

                    if (p.ownSecretsIDList.Count >= 5)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// The namelist.
        /// </summary>
        List<string> namelist = new List<string>();

        /// <summary>
        /// The cardlist.
        /// </summary>
        List<Card> cardlist = new List<Card>();

        /// <summary>
        /// The cardid to card list.
        /// </summary>
        Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();

        /// <summary>
        /// The all card ids.
        /// </summary>
        List<string> allCardIDS = new List<string>();

        /// <summary>
        /// The unknown card.
        /// </summary>
        public Card unknownCard;

        /// <summary>
        /// The installed wrong.
        /// </summary>
        public bool installedWrong = false;

        /// <summary>
        /// The teacherminion.
        /// </summary>
        public Card teacherminion;

        /// <summary>
        /// The illidanminion.
        /// </summary>
        public Card illidanminion;

        /// <summary>
        /// The instance.
        /// </summary>
        private static CardDB instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();

                    // instance.enumCreator();// only call this to get latest cardids
                    /*foreach (KeyValuePair<cardIDEnum, Card> kvp in instance.cardidToCardList)
                    {
                        Helpfunctions.Instance.logg(kvp.Value.name + " " + kvp.Value.Attack);
                    }*/
                    // have to do it 2 times (or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.cardlist)
                    {
                        c.sim_card = instance.getSimCard(c.cardIDenum);
                    }

                    instance.setAdditionalData();
                }

                return instance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="CardDB"/> class from being created.
        /// </summary>
        private CardDB()
        {
            string[] lines = { };
            try
            {
                string path = Settings.Instance.path;
                lines = File.ReadAllLines(path + "_carddb.txt");
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

            this.cardlist.Clear();
            this.cardidToCardList.Clear();
            Card c = new Card();
            int de = 0;

            // placeholdercard
            Card plchldr = new Card();
            plchldr.name = cardName.unknown;
            plchldr.cost = 1000;
            this.namelist.Add("unknown");
            this.cardlist.Add(plchldr);
            this.unknownCard = this.cardlist[0];
            string name = string.Empty;
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (c.type == cardtype.ENCHANTMENT)
                    {
                        // Helpfunctions.Instance.logg(c.CardID);
                        // Helpfunctions.Instance.logg(c.name);
                        // Helpfunctions.Instance.logg(c.description);
                        continue;
                    }

                    if (name != string.Empty)
                    {
                        this.namelist.Add(name);
                    }

                    name = string.Empty;
                    if (c.name != cardName.unknown)
                    {
                        this.cardlist.Add(c);

                        // Helpfunctions.Instance.logg(c.name);
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
                    string temp = s.Split(new[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", string.Empty);

                    // c.CardID = temp;
                    this.allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);

                    // token:
                    if (temp.EndsWith("t"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("ds1_whelptoken"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_mirror"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_050"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_052"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_051"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("NEW1_009"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_152"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("CS2_boar"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_tk11"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_506a"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("skele21"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_tk9"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_finkle"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_598"))
                    {
                        c.isToken = true;
                    }

                    if (temp.Equals("EX1_tk34"))
                    {
                        c.isToken = true;
                    }

                    // if (c.isToken) Helpfunctions.Instance.ErrorLog(temp);
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
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Atk\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Attack = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Race\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Rarity\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.rarity = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Cost\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"CardType\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    if (c.name != cardName.unknown)
                    {
                        // Helpfunctions.Instance.logg(temp);
                    }

                    int crdtype = Convert.ToInt32(temp);
                    if (crdtype == 10)
                    {
                        c.type = cardtype.HEROPWR;
                    }

                    if (crdtype == 4)
                    {
                        c.type = cardtype.MOB;
                    }

                    if (crdtype == 5)
                    {
                        c.type = cardtype.SPELL;
                    }

                    if (crdtype == 6)
                    {
                        c.type = cardtype.ENCHANTMENT;
                    }

                    if (crdtype == 7)
                    {
                        c.type = cardtype.WEAPON;
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
                    string temp = s.Replace("<enUS>", string.Empty);

                    temp = temp.Replace("</enUS>", string.Empty);
                    temp = temp.Replace("&lt;", string.Empty);
                    temp = temp.Replace("b&gt;", string.Empty);
                    temp = temp.Replace("/b&gt;", string.Empty);
                    temp = temp.ToLower();
                    if (de == 0)
                    {
                        temp = temp.Replace("'", string.Empty);
                        temp = temp.Replace(" ", string.Empty);
                        temp = temp.Replace(":", string.Empty);
                        temp = temp.Replace(".", string.Empty);
                        temp = temp.Replace("!", string.Empty);
                        temp = temp.Replace("-", string.Empty);

                        // temp = temp.Replace("ß", "ss");
                        // temp = temp.Replace("ü", "ue");
                        // temp = temp.Replace("ä", "ae");
                        // temp = temp.Replace("ö", "oe");

                        // Helpfunctions.Instance.logg(temp);
                        c.name = this.cardNamestringToEnum(temp);
                        name = temp;
                    }

                    if (de == 1)
                    {
                        // c.description = temp;
                        // if (c.description.Contains("choose one"))
                        if (temp.Contains("choose one"))
                        {
                            c.choice = true;

                            // Helpfunctions.Instance.logg(c.name + " is choice");
                        }
                    }

                    if (de == 2)
                    {
                        // c.targettext = temp;
                    }

                    de = -1;
                    continue;
                }

                if (s.Contains("<Tag name=\"Poisonous\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.poisionous = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Enrage\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Enrage = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"OneTurnEffect\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.oneTurnEffect = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Aura\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Aura = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Taunt\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.tank = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Battlecry\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.battlecry = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Windfury\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.windfury = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Deathrattle\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.deathrattle = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Durability\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Durability = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"Elite\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Elite = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Combo\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Combo = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Recall\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Recall = true;
                    }

                    c.recallValue = 1;
                    if (c.name == cardName.forkedlightning)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.dustdevil)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.lightningstorm)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.lavaburst)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.feralspirit)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.doomhammer)
                    {
                        c.recallValue = 2;
                    }

                    if (c.name == cardName.earthelemental)
                    {
                        c.recallValue = 3;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"ImmuneToSpellpower\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.immuneToSpellpowerg = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Stealth\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Stealth = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Secret\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Secret = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Freeze\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Freeze = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"AdjacentBuff\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.AdjacentBuff = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Divine Shield\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Shield = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Charge\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Charge = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Silence\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Silence = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Morph\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Morph = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"Spellpower\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.Spellpower = true;
                    }

                    c.spellpowervalue = 1;
                    if (c.name == cardName.ancientmage)
                    {
                        c.spellpowervalue = 0;
                    }

                    if (c.name == cardName.malygos)
                    {
                        c.spellpowervalue = 5;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"GrantCharge\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.GrantCharge = true;
                    }

                    continue;
                }

                if (s.Contains("<Tag name=\"HealTarget\""))
                {
                    string temp = s.Split(new[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        c.HealTarget = true;
                    }

                    continue;
                }

                if (s.Contains("<PlayRequirement"))
                {
                    string temp = s.Split(new[] { "reqID=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    ErrorType2 et2 = (ErrorType2)Convert.ToInt32(temp);
                    c.playrequires.Add(et2);
                }

                if (s.Contains("<PlayRequirement reqID=\"12\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needEmptyPlacesForPlaying = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"41\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMinAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"8\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMaxAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"10\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needRaceForPlaying = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"23\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinNumberOfEnemy = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"45\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinTotalMinions = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("PlayRequirement reqID=\"19\" param=\""))
                {
                    string temp = s.Split(new[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinionsCapIfAvailable = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name="))
                {
                    string temp = s.Split(new[] { "<Tag name=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];

                    /*
                    if (temp != "DevState" && temp != "FlavorText" && temp != "ArtistName" && temp != "Cost" && temp != "EnchantmentIdleVisual" && temp != "EnchantmentBirthVisual" && temp != "Collectible" && temp != "CardSet" && temp != "AttackVisualType" && temp != "CardName" && temp != "Class" && temp != "CardTextInHand" && temp != "Rarity" && temp != "TriggerVisual" && temp != "Faction" && temp != "HowToGetThisGoldCard" && temp != "HowToGetThisCard" && temp != "CardTextInPlay")
                        Helpfunctions.Instance.logg(s);*/
                }
            }

            this.teacherminion = this.getCardDataFromID(cardIDEnum.NEW1_026t);
            this.illidanminion = this.getCardDataFromID(cardIDEnum.EX1_614t);
        }

        /// <summary>
        /// The get card data.
        /// </summary>
        /// <param name="cardname">
        /// The cardname.
        /// </param>
        /// <returns>
        /// The <see cref="Card"/>.
        /// </returns>
        public Card getCardData(cardName cardname)
        {
            
            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return this.unknownCard;
        }

        /// <summary>
        /// The get card data from id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Card"/>.
        /// </returns>
        public Card getCardDataFromID(cardIDEnum id)
        {
            if (this.cardidToCardList.ContainsKey(id))
            {
                return this.cardidToCardList[id];

                // return new Card(cardidToCardList[id]);
            }

            return this.unknownCard;
        }

        /// <summary>
        /// The get sim card.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SimTemplate"/>.
        /// </returns>
        public SimTemplate getSimCard(cardIDEnum id)
        {
            // if (id == CardDB.cardIDEnum.XXX_040) return new Sim_XXX_040();
            // if (id == CardDB.cardIDEnum.NAX5_01H) return new Sim_NAX5_01H();
            // if (id == CardDB.cardIDEnum.CS2_188o) return new Sim_CS2_188o();
            // if (id == CardDB.cardIDEnum.NAX6_02H) return new Sim_NAX6_02H();
            if (id == cardIDEnum.NEW1_007b)
            {
                return new Sim_NEW1_007b();
            }

            // if (id == CardDB.cardIDEnum.NAX6_02e) return new Sim_NAX6_02e();
            // if (id == CardDB.cardIDEnum.TU4c_003) return new Sim_TU4c_003();
            // if (id == CardDB.cardIDEnum.XXX_024) return new Sim_XXX_024();
            if (id == cardIDEnum.EX1_613)
            {
                return new Sim_EX1_613();
            }

            // if (id == CardDB.cardIDEnum.NAX8_01) return new Sim_NAX8_01();
            // if (id == CardDB.cardIDEnum.EX1_295o) return new Sim_EX1_295o();
            // if (id == CardDB.cardIDEnum.CS2_059o) return new Sim_CS2_059o();
            if (id == cardIDEnum.EX1_133)
            {
                return new Sim_EX1_133();
            }

            if (id == cardIDEnum.NEW1_018)
            {
                return new Sim_NEW1_018();
            }

            // if (id == CardDB.cardIDEnum.NAX15_03t) return new Sim_NAX15_03t();
            if (id == cardIDEnum.EX1_012)
            {
                return new Sim_EX1_012();
            }

            if (id == cardIDEnum.EX1_178a)
            {
                return new Sim_EX1_178a();
            }

            if (id == cardIDEnum.CS2_231)
            {
                return new Sim_CS2_231();
            }

            // if (id == CardDB.cardIDEnum.EX1_019e) return new Sim_EX1_019e();
            // if (id == CardDB.cardIDEnum.CRED_12) return new Sim_CRED_12();
            if (id == cardIDEnum.CS2_179)
            {
                return new Sim_CS2_179();
            }

            // if (id == CardDB.cardIDEnum.CS2_045e) return new Sim_CS2_045e();
            if (id == cardIDEnum.EX1_244)
            {
                return new Sim_EX1_244();
            }

            if (id == cardIDEnum.EX1_178b)
            {
                return new Sim_EX1_178b();
            }

            // if (id == CardDB.cardIDEnum.XXX_030) return new Sim_XXX_030();
            // if (id == CardDB.cardIDEnum.NAX8_05) return new Sim_NAX8_05();
            if (id == cardIDEnum.EX1_573b)
            {
                return new Sim_EX1_573b();
            }

            // if (id == CardDB.cardIDEnum.TU4d_001) return new Sim_TU4d_001();
            if (id == cardIDEnum.NEW1_007a)
            {
                return new Sim_NEW1_007a();
            }

            // if (id == CardDB.cardIDEnum.NAX12_02H) return new Sim_NAX12_02H();
            if (id == cardIDEnum.EX1_345t)
            {
                return new Sim_EX1_345t();
            }

            if (id == cardIDEnum.FP1_007t)
            {
                return new Sim_FP1_007t();
            }

            if (id == cardIDEnum.EX1_025)
            {
                return new Sim_EX1_025();
            }

            if (id == cardIDEnum.EX1_396)
            {
                return new Sim_EX1_396();
            }

            // if (id == CardDB.cardIDEnum.NAX9_03) return new Sim_NAX9_03();
            if (id == cardIDEnum.NEW1_017)
            {
                return new Sim_NEW1_017();
            }

            if (id == cardIDEnum.NEW1_008a)
            {
                return new Sim_NEW1_008a();
            }

            // if (id == CardDB.cardIDEnum.EX1_587e) return new Sim_EX1_587e();
            if (id == cardIDEnum.EX1_533)
            {
                return new Sim_EX1_533();
            }

            if (id == cardIDEnum.EX1_522)
            {
                return new Sim_EX1_522();
            }

            // if (id == CardDB.cardIDEnum.NAX11_04) return new Sim_NAX11_04();
            if (id == cardIDEnum.NEW1_026)
            {
                return new Sim_NEW1_026();
            }

            if (id == cardIDEnum.EX1_398)
            {
                return new Sim_EX1_398();
            }

            // if (id == CardDB.cardIDEnum.NAX4_04) return new Sim_NAX4_04();
            if (id == cardIDEnum.EX1_007)
            {
                return new Sim_EX1_007();
            }

            if (id == cardIDEnum.CS1_112)
            {
                return new Sim_CS1_112();
            }

            // if (id == CardDB.cardIDEnum.CRED_17) return new Sim_CRED_17();
            if (id == cardIDEnum.NEW1_036)
            {
                return new Sim_NEW1_036();
            }

            // if (id == CardDB.cardIDEnum.NAX3_03) return new Sim_NAX3_03();
            // if (id == CardDB.cardIDEnum.EX1_355e) return new Sim_EX1_355e();
            if (id == cardIDEnum.EX1_258)
            {
                return new Sim_EX1_258();
            }

            if (id == cardIDEnum.HERO_01)
            {
                return new Sim_HERO_01();
            }

            // if (id == CardDB.cardIDEnum.XXX_009) return new Sim_XXX_009();
            // if (id == CardDB.cardIDEnum.NAX6_01H) return new Sim_NAX6_01H();
            // if (id == CardDB.cardIDEnum.NAX12_04e) return new Sim_NAX12_04e();
            if (id == cardIDEnum.CS2_087)
            {
                return new Sim_CS2_087();
            }

            if (id == cardIDEnum.DREAM_05)
            {
                return new Sim_DREAM_05();
            }

            // if (id == CardDB.cardIDEnum.NEW1_036e) return new Sim_NEW1_036e();
            if (id == cardIDEnum.CS2_092)
            {
                return new Sim_CS2_092();
            }

            if (id == cardIDEnum.CS2_022)
            {
                return new Sim_CS2_022();
            }

            if (id == cardIDEnum.EX1_046)
            {
                return new Sim_EX1_046();
            }

            // if (id == CardDB.cardIDEnum.XXX_005) return new Sim_XXX_005();
            if (id == cardIDEnum.PRO_001b)
            {
                return new Sim_PRO_001b();
            }

            // if (id == CardDB.cardIDEnum.XXX_022) return new Sim_XXX_022();
            if (id == cardIDEnum.PRO_001a)
            {
                return new Sim_PRO_001a();
            }

            // if (id == CardDB.cardIDEnum.NAX6_04) return new Sim_NAX6_04();
            // if (id == CardDB.cardIDEnum.NAX7_05) return new Sim_NAX7_05();
            if (id == cardIDEnum.CS2_103)
            {
                return new Sim_CS2_103();
            }

            if (id == cardIDEnum.NEW1_041)
            {
                return new Sim_NEW1_041();
            }

            if (id == cardIDEnum.EX1_360)
            {
                return new Sim_EX1_360();
            }

            if (id == cardIDEnum.FP1_023)
            {
                return new Sim_FP1_023();
            }

            if (id == cardIDEnum.NEW1_038)
            {
                return new Sim_NEW1_038();
            }

            if (id == cardIDEnum.CS2_009)
            {
                return new Sim_CS2_009();
            }

            // if (id == CardDB.cardIDEnum.NAX10_01H) return new Sim_NAX10_01H();
            if (id == cardIDEnum.EX1_010)
            {
                return new Sim_EX1_010();
            }

            if (id == cardIDEnum.CS2_024)
            {
                return new Sim_CS2_024();
            }

            // if (id == CardDB.cardIDEnum.NAX9_05) return new Sim_NAX9_05();
            if (id == cardIDEnum.EX1_565)
            {
                return new Sim_EX1_565();
            }

            if (id == cardIDEnum.CS2_076)
            {
                return new Sim_CS2_076();
            }

            if (id == cardIDEnum.FP1_004)
            {
                return new Sim_FP1_004();
            }

            // if (id == CardDB.cardIDEnum.CS2_046e) return new Sim_CS2_046e();
            if (id == cardIDEnum.CS2_162)
            {
                return new Sim_CS2_162();
            }

            if (id == cardIDEnum.EX1_110t)
            {
                return new Sim_EX1_110t();
            }

            // if (id == CardDB.cardIDEnum.CS2_104e) return new Sim_CS2_104e();
            if (id == cardIDEnum.CS2_181)
            {
                return new Sim_CS2_181();
            }

            if (id == cardIDEnum.EX1_309)
            {
                return new Sim_EX1_309();
            }

            if (id == cardIDEnum.EX1_354)
            {
                return new Sim_EX1_354();
            }

            // if (id == CardDB.cardIDEnum.NAX10_02H) return new Sim_NAX10_02H();
            // if (id == CardDB.cardIDEnum.NAX7_04H) return new Sim_NAX7_04H();
            // if (id == CardDB.cardIDEnum.TU4f_001) return new Sim_TU4f_001();
            // if (id == CardDB.cardIDEnum.XXX_018) return new Sim_XXX_018();
            if (id == cardIDEnum.EX1_023)
            {
                return new Sim_EX1_023();
            }

            // if (id == CardDB.cardIDEnum.XXX_048) return new Sim_XXX_048();
            // if (id == CardDB.cardIDEnum.XXX_049) return new Sim_XXX_049();
            if (id == cardIDEnum.NEW1_034)
            {
                return new Sim_NEW1_034();
            }

            if (id == cardIDEnum.CS2_003)
            {
                return new Sim_CS2_003();
            }

            if (id == cardIDEnum.HERO_06)
            {
                return new Sim_HERO_06();
            }

            if (id == cardIDEnum.CS2_201)
            {
                return new Sim_CS2_201();
            }

            if (id == cardIDEnum.EX1_508)
            {
                return new Sim_EX1_508();
            }

            if (id == cardIDEnum.EX1_259)
            {
                return new Sim_EX1_259();
            }

            if (id == cardIDEnum.EX1_341)
            {
                return new Sim_EX1_341();
            }

            // if (id == CardDB.cardIDEnum.DREAM_05e) return new Sim_DREAM_05e();
            // if (id == CardDB.cardIDEnum.CRED_09) return new Sim_CRED_09();
            if (id == cardIDEnum.EX1_103)
            {
                return new Sim_EX1_103();
            }

            if (id == cardIDEnum.FP1_021)
            {
                return new Sim_FP1_021();
            }

            if (id == cardIDEnum.EX1_411)
            {
                return new Sim_EX1_411();
            }

            // if (id == CardDB.cardIDEnum.NAX1_04) return new Sim_NAX1_04();
            if (id == cardIDEnum.CS2_053)
            {
                return new Sim_CS2_053();
            }

            if (id == cardIDEnum.CS2_182)
            {
                return new Sim_CS2_182();
            }

            if (id == cardIDEnum.CS2_008)
            {
                return new Sim_CS2_008();
            }

            if (id == cardIDEnum.CS2_233)
            {
                return new Sim_CS2_233();
            }

            if (id == cardIDEnum.EX1_626)
            {
                return new Sim_EX1_626();
            }

            if (id == cardIDEnum.EX1_059)
            {
                return new Sim_EX1_059();
            }

            if (id == cardIDEnum.EX1_334)
            {
                return new Sim_EX1_334();
            }

            if (id == cardIDEnum.EX1_619)
            {
                return new Sim_EX1_619();
            }

            if (id == cardIDEnum.NEW1_032)
            {
                return new Sim_NEW1_032();
            }

            if (id == cardIDEnum.EX1_158t)
            {
                return new Sim_EX1_158t();
            }

            if (id == cardIDEnum.EX1_006)
            {
                return new Sim_EX1_006();
            }

            if (id == cardIDEnum.NEW1_031)
            {
                return new Sim_NEW1_031();
            }

            // if (id == CardDB.cardIDEnum.NAX10_03) return new Sim_NAX10_03();
            if (id == cardIDEnum.DREAM_04)
            {
                return new Sim_DREAM_04();
            }

            // if (id == CardDB.cardIDEnum.NAX1h_01) return new Sim_NAX1h_01();
            // if (id == CardDB.cardIDEnum.CS2_022e) return new Sim_CS2_022e();
            // if (id == CardDB.cardIDEnum.EX1_611e) return new Sim_EX1_611e();
            if (id == cardIDEnum.EX1_004)
            {
                return new Sim_EX1_004();
            }

            // if (id == CardDB.cardIDEnum.EX1_014te) return new Sim_EX1_014te();
            // if (id == CardDB.cardIDEnum.FP1_005e) return new Sim_FP1_005e();
            // if (id == CardDB.cardIDEnum.NAX12_03e) return new Sim_NAX12_03e();
            if (id == cardIDEnum.EX1_095)
            {
                return new Sim_EX1_095();
            }

            if (id == cardIDEnum.NEW1_007)
            {
                return new Sim_NEW1_007();
            }

            if (id == cardIDEnum.EX1_275)
            {
                return new Sim_EX1_275();
            }

            if (id == cardIDEnum.EX1_245)
            {
                return new Sim_EX1_245();
            }

            if (id == cardIDEnum.EX1_383)
            {
                return new Sim_EX1_383();
            }

            if (id == cardIDEnum.FP1_016)
            {
                return new Sim_FP1_016();
            }

            if (id == cardIDEnum.EX1_016t)
            {
                return new Sim_EX1_016t();
            }

            if (id == cardIDEnum.CS2_125)
            {
                return new Sim_CS2_125();
            }

            if (id == cardIDEnum.EX1_137)
            {
                return new Sim_EX1_137();
            }

            // if (id == CardDB.cardIDEnum.EX1_178ae) return new Sim_EX1_178ae();
            if (id == cardIDEnum.DS1_185)
            {
                return new Sim_DS1_185();
            }

            if (id == cardIDEnum.FP1_010)
            {
                return new Sim_FP1_010();
            }

            if (id == cardIDEnum.EX1_598)
            {
                return new Sim_EX1_598();
            }

            // if (id == CardDB.cardIDEnum.NAX9_07) return new Sim_NAX9_07();
            if (id == cardIDEnum.EX1_304)
            {
                return new Sim_EX1_304();
            }

            if (id == cardIDEnum.EX1_302)
            {
                return new Sim_EX1_302();
            }

            // if (id == CardDB.cardIDEnum.XXX_017) return new Sim_XXX_017();
            // if (id == CardDB.cardIDEnum.CS2_011o) return new Sim_CS2_011o();
            if (id == cardIDEnum.EX1_614t)
            {
                return new Sim_EX1_614t();
            }

            // if (id == CardDB.cardIDEnum.TU4a_006) return new Sim_TU4a_006();
            // if (id == CardDB.cardIDEnum.Mekka3e) return new Sim_Mekka3e();
            if (id == cardIDEnum.CS2_108)
            {
                return new Sim_CS2_108();
            }

            if (id == cardIDEnum.CS2_046)
            {
                return new Sim_CS2_046();
            }

            if (id == cardIDEnum.EX1_014t)
            {
                return new Sim_EX1_014t();
            }

            if (id == cardIDEnum.NEW1_005)
            {
                return new Sim_NEW1_005();
            }

            if (id == cardIDEnum.EX1_062)
            {
                return new Sim_EX1_062();
            }

            // if (id == CardDB.cardIDEnum.EX1_366e) return new Sim_EX1_366e();
            if (id == cardIDEnum.Mekka1)
            {
                return new Sim_Mekka1();
            }

            // if (id == CardDB.cardIDEnum.XXX_007) return new Sim_XXX_007();
            if (id == cardIDEnum.tt_010a)
            {
                return new Sim_tt_010a();
            }

            // if (id == CardDB.cardIDEnum.CS2_017o) return new Sim_CS2_017o();
            if (id == cardIDEnum.CS2_072)
            {
                return new Sim_CS2_072();
            }

            if (id == cardIDEnum.EX1_tk28)
            {
                return new Sim_EX1_tk28();
            }

            // if (id == CardDB.cardIDEnum.EX1_604o) return new Sim_EX1_604o();
            if (id == cardIDEnum.FP1_014)
            {
                return new Sim_FP1_014();
            }

            // if (id == CardDB.cardIDEnum.EX1_084e) return new Sim_EX1_084e();
            // if (id == CardDB.cardIDEnum.NAX3_01H) return new Sim_NAX3_01H();
            // if (id == CardDB.cardIDEnum.NAX2_01) return new Sim_NAX2_01();
            if (id == cardIDEnum.EX1_409t)
            {
                return new Sim_EX1_409t();
            }

            // if (id == CardDB.cardIDEnum.CRED_07) return new Sim_CRED_07();
            // if (id == CardDB.cardIDEnum.NAX3_02H) return new Sim_NAX3_02H();
            // if (id == CardDB.cardIDEnum.TU4e_002) return new Sim_TU4e_002();
            if (id == cardIDEnum.EX1_507)
            {
                return new Sim_EX1_507();
            }

            if (id == cardIDEnum.EX1_144)
            {
                return new Sim_EX1_144();
            }

            if (id == cardIDEnum.CS2_038)
            {
                return new Sim_CS2_038();
            }

            if (id == cardIDEnum.EX1_093)
            {
                return new Sim_EX1_093();
            }

            if (id == cardIDEnum.CS2_080)
            {
                return new Sim_CS2_080();
            }

            // if (id == CardDB.cardIDEnum.CS1_129e) return new Sim_CS1_129e();
            // if (id == CardDB.cardIDEnum.XXX_013) return new Sim_XXX_013();
            if (id == cardIDEnum.EX1_005)
            {
                return new Sim_EX1_005();
            }

            if (id == cardIDEnum.EX1_382)
            {
                return new Sim_EX1_382();
            }

            // if (id == CardDB.cardIDEnum.NAX13_02e) return new Sim_NAX13_02e();
            // if (id == CardDB.cardIDEnum.FP1_020e) return new Sim_FP1_020e();
            // if (id == CardDB.cardIDEnum.EX1_603e) return new Sim_EX1_603e();
            if (id == cardIDEnum.CS2_028)
            {
                return new Sim_CS2_028();
            }

            // if (id == CardDB.cardIDEnum.TU4f_002) return new Sim_TU4f_002();
            if (id == cardIDEnum.EX1_538)
            {
                return new Sim_EX1_538();
            }

            // if (id == CardDB.cardIDEnum.GAME_003e) return new Sim_GAME_003e();
            if (id == cardIDEnum.DREAM_02)
            {
                return new Sim_DREAM_02();
            }

            if (id == cardIDEnum.EX1_581)
            {
                return new Sim_EX1_581();
            }

            // if (id == CardDB.cardIDEnum.NAX15_01H) return new Sim_NAX15_01H();
            if (id == cardIDEnum.EX1_131t)
            {
                return new Sim_EX1_131t();
            }

            if (id == cardIDEnum.CS2_147)
            {
                return new Sim_CS2_147();
            }

            if (id == cardIDEnum.CS1_113)
            {
                return new Sim_CS1_113();
            }

            if (id == cardIDEnum.CS2_161)
            {
                return new Sim_CS2_161();
            }

            if (id == cardIDEnum.CS2_031)
            {
                return new Sim_CS2_031();
            }

            if (id == cardIDEnum.EX1_166b)
            {
                return new Sim_EX1_166b();
            }

            if (id == cardIDEnum.EX1_066)
            {
                return new Sim_EX1_066();
            }

            // if (id == CardDB.cardIDEnum.TU4c_007) return new Sim_TU4c_007();
            if (id == cardIDEnum.EX1_355)
            {
                return new Sim_EX1_355();
            }

            // if (id == CardDB.cardIDEnum.EX1_507e) return new Sim_EX1_507e();
            if (id == cardIDEnum.EX1_534)
            {
                return new Sim_EX1_534();
            }

            if (id == cardIDEnum.EX1_162)
            {
                return new Sim_EX1_162();
            }

            // if (id == CardDB.cardIDEnum.TU4a_004) return new Sim_TU4a_004();
            if (id == cardIDEnum.EX1_363)
            {
                return new Sim_EX1_363();
            }

            if (id == cardIDEnum.EX1_164a)
            {
                return new Sim_EX1_164a();
            }

            if (id == cardIDEnum.CS2_188)
            {
                return new Sim_CS2_188();
            }

            if (id == cardIDEnum.EX1_016)
            {
                return new Sim_EX1_016();
            }

            // if (id == CardDB.cardIDEnum.NAX6_03t) return new Sim_NAX6_03t();
            // if (id == CardDB.cardIDEnum.EX1_tk31) return new Sim_EX1_tk31();
            if (id == cardIDEnum.EX1_603)
            {
                return new Sim_EX1_603();
            }

            if (id == cardIDEnum.EX1_238)
            {
                return new Sim_EX1_238();
            }

            if (id == cardIDEnum.EX1_166)
            {
                return new Sim_EX1_166();
            }

            if (id == cardIDEnum.DS1h_292)
            {
                return new Sim_DS1h_292();
            }

            if (id == cardIDEnum.DS1_183)
            {
                return new Sim_DS1_183();
            }

            // if (id == CardDB.cardIDEnum.NAX15_03n) return new Sim_NAX15_03n();
            // if (id == CardDB.cardIDEnum.NAX8_02H) return new Sim_NAX8_02H();
            // if (id == CardDB.cardIDEnum.NAX7_01H) return new Sim_NAX7_01H();
            // if (id == CardDB.cardIDEnum.NAX9_02H) return new Sim_NAX9_02H();
            // if (id == CardDB.cardIDEnum.CRED_11) return new Sim_CRED_11();
            // if (id == CardDB.cardIDEnum.XXX_019) return new Sim_XXX_019();
            if (id == cardIDEnum.EX1_076)
            {
                return new Sim_EX1_076();
            }

            if (id == cardIDEnum.EX1_048)
            {
                return new Sim_EX1_048();
            }

            // if (id == CardDB.cardIDEnum.CS2_038e) return new Sim_CS2_038e();
            if (id == cardIDEnum.FP1_026)
            {
                return new Sim_FP1_026();
            }

            if (id == cardIDEnum.CS2_074)
            {
                return new Sim_CS2_074();
            }

            if (id == cardIDEnum.FP1_027)
            {
                return new Sim_FP1_027();
            }

            if (id == cardIDEnum.EX1_323w)
            {
                return new Sim_EX1_323w();
            }

            if (id == cardIDEnum.EX1_129)
            {
                return new Sim_EX1_129();
            }

            // if (id == CardDB.cardIDEnum.NEW1_024o) return new Sim_NEW1_024o();
            // if (id == CardDB.cardIDEnum.NAX11_02) return new Sim_NAX11_02();
            if (id == cardIDEnum.EX1_405)
            {
                return new Sim_EX1_405();
            }

            if (id == cardIDEnum.EX1_317)
            {
                return new Sim_EX1_317();
            }

            if (id == cardIDEnum.EX1_606)
            {
                return new Sim_EX1_606();
            }

            // if (id == CardDB.cardIDEnum.EX1_590e) return new Sim_EX1_590e();
            // if (id == CardDB.cardIDEnum.XXX_044) return new Sim_XXX_044();
            // if (id == CardDB.cardIDEnum.CS2_074e) return new Sim_CS2_074e();
            // if (id == CardDB.cardIDEnum.TU4a_005) return new Sim_TU4a_005();
            if (id == cardIDEnum.FP1_006)
            {
                return new Sim_FP1_006();
            }

            // if (id == CardDB.cardIDEnum.EX1_258e) return new Sim_EX1_258e();
            // if (id == CardDB.cardIDEnum.TU4f_004o) return new Sim_TU4f_004o();
            if (id == cardIDEnum.NEW1_008)
            {
                return new Sim_NEW1_008();
            }

            if (id == cardIDEnum.CS2_119)
            {
                return new Sim_CS2_119();
            }

            // if (id == CardDB.cardIDEnum.NEW1_017e) return new Sim_NEW1_017e();
            // if (id == CardDB.cardIDEnum.EX1_334e) return new Sim_EX1_334e();
            // if (id == CardDB.cardIDEnum.TU4e_001) return new Sim_TU4e_001();
            if (id == cardIDEnum.CS2_121)
            {
                return new Sim_CS2_121();
            }

            if (id == cardIDEnum.CS1h_001)
            {
                return new Sim_CS1h_001();
            }

            if (id == cardIDEnum.EX1_tk34)
            {
                return new Sim_EX1_tk34();
            }

            if (id == cardIDEnum.NEW1_020)
            {
                return new Sim_NEW1_020();
            }

            if (id == cardIDEnum.CS2_196)
            {
                return new Sim_CS2_196();
            }

            if (id == cardIDEnum.EX1_312)
            {
                return new Sim_EX1_312();
            }

            // if (id == CardDB.cardIDEnum.NAX1_01) return new Sim_NAX1_01();
            if (id == cardIDEnum.FP1_022)
            {
                return new Sim_FP1_022();
            }

            if (id == cardIDEnum.EX1_160b)
            {
                return new Sim_EX1_160b();
            }

            if (id == cardIDEnum.EX1_563)
            {
                return new Sim_EX1_563();
            }

            // if (id == CardDB.cardIDEnum.XXX_039) return new Sim_XXX_039();
            if (id == cardIDEnum.FP1_031)
            {
                return new Sim_FP1_031();
            }

            // if (id == CardDB.cardIDEnum.CS2_087e) return new Sim_CS2_087e();
            // if (id == CardDB.cardIDEnum.EX1_613e) return new Sim_EX1_613e();
            // if (id == CardDB.cardIDEnum.NAX9_02) return new Sim_NAX9_02();
            if (id == cardIDEnum.NEW1_029)
            {
                return new Sim_NEW1_029();
            }

            if (id == cardIDEnum.CS1_129)
            {
                return new Sim_CS1_129();
            }

            if (id == cardIDEnum.HERO_03)
            {
                return new Sim_HERO_03();
            }

            if (id == cardIDEnum.Mekka4t)
            {
                return new Sim_Mekka4t();
            }

            if (id == cardIDEnum.EX1_158)
            {
                return new Sim_EX1_158();
            }

            // if (id == CardDB.cardIDEnum.XXX_010) return new Sim_XXX_010();
            if (id == cardIDEnum.NEW1_025)
            {
                return new Sim_NEW1_025();
            }

            if (id == cardIDEnum.FP1_012t)
            {
                return new Sim_FP1_012t();
            }

            if (id == cardIDEnum.EX1_083)
            {
                return new Sim_EX1_083();
            }

            if (id == cardIDEnum.EX1_295)
            {
                return new Sim_EX1_295();
            }

            if (id == cardIDEnum.EX1_407)
            {
                return new Sim_EX1_407();
            }

            if (id == cardIDEnum.NEW1_004)
            {
                return new Sim_NEW1_004();
            }

            if (id == cardIDEnum.FP1_019)
            {
                return new Sim_FP1_019();
            }

            if (id == cardIDEnum.PRO_001at)
            {
                return new Sim_PRO_001at();
            }

            // if (id == CardDB.cardIDEnum.NAX13_03e) return new Sim_NAX13_03e();
            if (id == cardIDEnum.EX1_625t)
            {
                return new Sim_EX1_625t();
            }

            if (id == cardIDEnum.EX1_014)
            {
                return new Sim_EX1_014();
            }

            // if (id == CardDB.cardIDEnum.CRED_04) return new Sim_CRED_04();
            // if (id == CardDB.cardIDEnum.NAX12_01H) return new Sim_NAX12_01H();
            if (id == cardIDEnum.CS2_097)
            {
                return new Sim_CS2_097();
            }

            if (id == cardIDEnum.EX1_558)
            {
                return new Sim_EX1_558();
            }

            // if (id == CardDB.cardIDEnum.XXX_047) return new Sim_XXX_047();
            if (id == cardIDEnum.EX1_tk29)
            {
                return new Sim_EX1_tk29();
            }

            if (id == cardIDEnum.CS2_186)
            {
                return new Sim_CS2_186();
            }

            if (id == cardIDEnum.EX1_084)
            {
                return new Sim_EX1_084();
            }

            if (id == cardIDEnum.NEW1_012)
            {
                return new Sim_NEW1_012();
            }

            if (id == cardIDEnum.FP1_014t)
            {
                return new Sim_FP1_014t();
            }

            // if (id == CardDB.cardIDEnum.NAX1_03) return new Sim_NAX1_03();
            // if (id == CardDB.cardIDEnum.EX1_623e) return new Sim_EX1_623e();
            if (id == cardIDEnum.EX1_578)
            {
                return new Sim_EX1_578();
            }

            // if (id == CardDB.cardIDEnum.CS2_073e2) return new Sim_CS2_073e2();
            if (id == cardIDEnum.CS2_221)
            {
                return new Sim_CS2_221();
            }

            if (id == cardIDEnum.EX1_019)
            {
                return new Sim_EX1_019();
            }

            // if (id == CardDB.cardIDEnum.NAX15_04a) return new Sim_NAX15_04a();
            if (id == cardIDEnum.FP1_019t)
            {
                return new Sim_FP1_019t();
            }

            if (id == cardIDEnum.EX1_132)
            {
                return new Sim_EX1_132();
            }

            if (id == cardIDEnum.EX1_284)
            {
                return new Sim_EX1_284();
            }

            if (id == cardIDEnum.EX1_105)
            {
                return new Sim_EX1_105();
            }

            if (id == cardIDEnum.NEW1_011)
            {
                return new Sim_NEW1_011();
            }

            // if (id == CardDB.cardIDEnum.NAX9_07e) return new Sim_NAX9_07e();
            if (id == cardIDEnum.EX1_017)
            {
                return new Sim_EX1_017();
            }

            if (id == cardIDEnum.EX1_249)
            {
                return new Sim_EX1_249();
            }

            // if (id == CardDB.cardIDEnum.EX1_162o) return new Sim_EX1_162o();
            if (id == cardIDEnum.FP1_002t)
            {
                return new Sim_FP1_002t();
            }

            // if (id == CardDB.cardIDEnum.NAX3_02) return new Sim_NAX3_02();
            if (id == cardIDEnum.EX1_313)
            {
                return new Sim_EX1_313();
            }

            // if (id == CardDB.cardIDEnum.EX1_549o) return new Sim_EX1_549o();
            // if (id == CardDB.cardIDEnum.EX1_091o) return new Sim_EX1_091o();
            // if (id == CardDB.cardIDEnum.CS2_084e) return new Sim_CS2_084e();
            if (id == cardIDEnum.EX1_155b)
            {
                return new Sim_EX1_155b();
            }

            // (id == CardDB.cardIDEnum.NAX11_01) return new Sim_NAX11_01();
            if (id == cardIDEnum.NEW1_033)
            {
                return new Sim_NEW1_033();
            }

            if (id == cardIDEnum.CS2_106)
            {
                return new Sim_CS2_106();
            }

            // if (id == CardDB.cardIDEnum.XXX_002) return new Sim_XXX_002();
            if (id == cardIDEnum.FP1_018)
            {
                return new Sim_FP1_018();
            }

            // if (id == CardDB.cardIDEnum.NEW1_036e2) return new Sim_NEW1_036e2();
            // if (id == CardDB.cardIDEnum.XXX_004) return new Sim_XXX_004();
            // if (id == CardDB.cardIDEnum.NAX11_02H) return new Sim_NAX11_02H();
            // if (id == CardDB.cardIDEnum.CS2_122e) return new Sim_CS2_122e();
            if (id == cardIDEnum.DS1_233)
            {
                return new Sim_DS1_233();
            }

            if (id == cardIDEnum.DS1_175)
            {
                return new Sim_DS1_175();
            }

            if (id == cardIDEnum.NEW1_024)
            {
                return new Sim_NEW1_024();
            }

            if (id == cardIDEnum.CS2_189)
            {
                return new Sim_CS2_189();
            }

            // if (id == CardDB.cardIDEnum.CRED_10) return new Sim_CRED_10();
            if (id == cardIDEnum.NEW1_037)
            {
                return new Sim_NEW1_037();
            }

            if (id == cardIDEnum.EX1_414)
            {
                return new Sim_EX1_414();
            }

            if (id == cardIDEnum.EX1_538t)
            {
                return new Sim_EX1_538t();
            }

            // if (id == CardDB.cardIDEnum.FP1_030e) return new Sim_FP1_030e();
            if (id == cardIDEnum.EX1_586)
            {
                return new Sim_EX1_586();
            }

            if (id == cardIDEnum.EX1_310)
            {
                return new Sim_EX1_310();
            }

            if (id == cardIDEnum.NEW1_010)
            {
                return new Sim_NEW1_010();
            }

            // if (id == CardDB.cardIDEnum.CS2_103e) return new Sim_CS2_103e();
            // if (id == CardDB.cardIDEnum.EX1_080o) return new Sim_EX1_080o();
            // if (id == CardDB.cardIDEnum.CS2_005o) return new Sim_CS2_005o();
            // if (id == CardDB.cardIDEnum.EX1_363e2) return new Sim_EX1_363e2();
            if (id == cardIDEnum.EX1_534t)
            {
                return new Sim_EX1_534t();
            }

            if (id == cardIDEnum.FP1_028)
            {
                return new Sim_FP1_028();
            }

            if (id == cardIDEnum.EX1_604)
            {
                return new Sim_EX1_604();
            }

            if (id == cardIDEnum.EX1_160)
            {
                return new Sim_EX1_160();
            }

            if (id == cardIDEnum.EX1_165t1)
            {
                return new Sim_EX1_165t1();
            }

            if (id == cardIDEnum.CS2_062)
            {
                return new Sim_CS2_062();
            }

            if (id == cardIDEnum.CS2_155)
            {
                return new Sim_CS2_155();
            }

            if (id == cardIDEnum.CS2_213)
            {
                return new Sim_CS2_213();
            }

            // if (id == CardDB.cardIDEnum.TU4f_007) return new Sim_TU4f_007();
            // if (id == CardDB.cardIDEnum.GAME_004) return new Sim_GAME_004();
            // if (id == CardDB.cardIDEnum.NAX5_01) return new Sim_NAX5_01();
            // if (id == CardDB.cardIDEnum.XXX_020) return new Sim_XXX_020();
            // if (id == CardDB.cardIDEnum.NAX15_02H) return new Sim_NAX15_02H();
            if (id == cardIDEnum.CS2_004)
            {
                return new Sim_CS2_004();
            }

            // if (id == CardDB.cardIDEnum.NAX2_03H) return new Sim_NAX2_03H();
            // if (id == CardDB.cardIDEnum.EX1_561e) return new Sim_EX1_561e();
            if (id == cardIDEnum.CS2_023)
            {
                return new Sim_CS2_023();
            }

            if (id == cardIDEnum.EX1_164)
            {
                return new Sim_EX1_164();
            }

            if (id == cardIDEnum.EX1_009)
            {
                return new Sim_EX1_009();
            }

            // if (id == CardDB.cardIDEnum.NAX6_01) return new Sim_NAX6_01();
            if (id == cardIDEnum.FP1_007)
            {
                return new Sim_FP1_007();
            }

            // if (id == CardDB.cardIDEnum.NAX1h_04) return new Sim_NAX1h_04();
            // if (id == CardDB.cardIDEnum.NAX2_05H) return new Sim_NAX2_05H();
            // if (id == CardDB.cardIDEnum.NAX10_02) return new Sim_NAX10_02();
            if (id == cardIDEnum.EX1_345)
            {
                return new Sim_EX1_345();
            }

            if (id == cardIDEnum.EX1_116)
            {
                return new Sim_EX1_116();
            }

            if (id == cardIDEnum.EX1_399)
            {
                return new Sim_EX1_399();
            }

            if (id == cardIDEnum.EX1_587)
            {
                return new Sim_EX1_587();
            }

            // if (id == CardDB.cardIDEnum.XXX_026) return new Sim_XXX_026();
            if (id == cardIDEnum.EX1_571)
            {
                return new Sim_EX1_571();
            }

            if (id == cardIDEnum.EX1_335)
            {
                return new Sim_EX1_335();
            }

            // if (id == CardDB.cardIDEnum.XXX_050) return new Sim_XXX_050();
            // if (id == CardDB.cardIDEnum.TU4e_004) return new Sim_TU4e_004();
            if (id == cardIDEnum.HERO_08)
            {
                return new Sim_HERO_08();
            }

            if (id == cardIDEnum.EX1_166a)
            {
                return new Sim_EX1_166a();
            }

            // if (id == CardDB.cardIDEnum.NAX2_03) return new Sim_NAX2_03();
            if (id == cardIDEnum.EX1_finkle)
            {
                return new Sim_EX1_finkle();
            }

            // if (id == CardDB.cardIDEnum.NAX4_03H) return new Sim_NAX4_03H();
            if (id == cardIDEnum.EX1_164b)
            {
                return new Sim_EX1_164b();
            }

            if (id == cardIDEnum.EX1_283)
            {
                return new Sim_EX1_283();
            }

            if (id == cardIDEnum.EX1_339)
            {
                return new Sim_EX1_339();
            }

            // if (id == CardDB.cardIDEnum.CRED_13) return new Sim_CRED_13();
            // if (id == CardDB.cardIDEnum.EX1_178be) return new Sim_EX1_178be();
            if (id == cardIDEnum.EX1_531)
            {
                return new Sim_EX1_531();
            }

            if (id == cardIDEnum.EX1_134)
            {
                return new Sim_EX1_134();
            }

            if (id == cardIDEnum.EX1_350)
            {
                return new Sim_EX1_350();
            }

            if (id == cardIDEnum.EX1_308)
            {
                return new Sim_EX1_308();
            }

            if (id == cardIDEnum.CS2_197)
            {
                return new Sim_CS2_197();
            }

            if (id == cardIDEnum.skele21)
            {
                return new Sim_skele21();
            }

            // if (id == CardDB.cardIDEnum.CS2_222o) return new Sim_CS2_222o();
            // if (id == CardDB.cardIDEnum.XXX_015) return new Sim_XXX_015();
            if (id == cardIDEnum.FP1_013)
            {
                return new Sim_FP1_013();
            }

            if (id == cardIDEnum.NEW1_006)
            {
                return new Sim_NEW1_006();
            }

            // if (id == CardDB.cardIDEnum.EX1_399e) return new Sim_EX1_399e();
            if (id == cardIDEnum.EX1_509)
            {
                return new Sim_EX1_509();
            }

            if (id == cardIDEnum.EX1_612)
            {
                return new Sim_EX1_612();
            }

            // if (id == CardDB.cardIDEnum.NAX8_05t) return new Sim_NAX8_05t();
            // if (id == CardDB.cardIDEnum.NAX9_05H) return new Sim_NAX9_05H();
            if (id == cardIDEnum.EX1_021)
            {
                return new Sim_EX1_021();
            }

            // if (id == CardDB.cardIDEnum.CS2_041e) return new Sim_CS2_041e();
            if (id == cardIDEnum.CS2_226)
            {
                return new Sim_CS2_226();
            }

            if (id == cardIDEnum.EX1_608)
            {
                return new Sim_EX1_608();
            }

            // if (id == CardDB.cardIDEnum.NAX13_05H) return new Sim_NAX13_05H();
            // if (id == CardDB.cardIDEnum.NAX13_04H) return new Sim_NAX13_04H();
            // if (id == CardDB.cardIDEnum.TU4c_008) return new Sim_TU4c_008();
            if (id == cardIDEnum.EX1_624)
            {
                return new Sim_EX1_624();
            }

            if (id == cardIDEnum.EX1_616)
            {
                return new Sim_EX1_616();
            }

            if (id == cardIDEnum.EX1_008)
            {
                return new Sim_EX1_008();
            }

            if (id == cardIDEnum.PlaceholderCard)
            {
                return new Sim_PlaceholderCard();
            }

            // if (id == CardDB.cardIDEnum.XXX_016) return new Sim_XXX_016();
            if (id == cardIDEnum.EX1_045)
            {
                return new Sim_EX1_045();
            }

            if (id == cardIDEnum.EX1_015)
            {
                return new Sim_EX1_015();
            }

            // if (id == CardDB.cardIDEnum.GAME_003) return new Sim_GAME_003();
            if (id == cardIDEnum.CS2_171)
            {
                return new Sim_CS2_171();
            }

            if (id == cardIDEnum.CS2_041)
            {
                return new Sim_CS2_041();
            }

            if (id == cardIDEnum.EX1_128)
            {
                return new Sim_EX1_128();
            }

            if (id == cardIDEnum.CS2_112)
            {
                return new Sim_CS2_112();
            }

            if (id == cardIDEnum.HERO_07)
            {
                return new Sim_HERO_07();
            }

            if (id == cardIDEnum.EX1_412)
            {
                return new Sim_EX1_412();
            }

            // if (id == CardDB.cardIDEnum.EX1_612o) return new Sim_EX1_612o();
            if (id == cardIDEnum.CS2_117)
            {
                return new Sim_CS2_117();
            }

            // if (id == CardDB.cardIDEnum.XXX_009e) return new Sim_XXX_009e();
            if (id == cardIDEnum.EX1_562)
            {
                return new Sim_EX1_562();
            }

            if (id == cardIDEnum.EX1_055)
            {
                return new Sim_EX1_055();
            }

            // if (id == CardDB.cardIDEnum.NAX9_06) return new Sim_NAX9_06();
            // if (id == CardDB.cardIDEnum.TU4e_007) return new Sim_TU4e_007();
            if (id == cardIDEnum.FP1_012)
            {
                return new Sim_FP1_012();
            }

            if (id == cardIDEnum.EX1_317t)
            {
                return new Sim_EX1_317t();
            }

            // if (id == CardDB.cardIDEnum.EX1_004e) return new Sim_EX1_004e();
            if (id == cardIDEnum.EX1_278)
            {
                return new Sim_EX1_278();
            }

            if (id == cardIDEnum.CS2_tk1)
            {
                return new Sim_CS2_tk1();
            }

            if (id == cardIDEnum.EX1_590)
            {
                return new Sim_EX1_590();
            }

            if (id == cardIDEnum.CS1_130)
            {
                return new Sim_CS1_130();
            }

            if (id == cardIDEnum.NEW1_008b)
            {
                return new Sim_NEW1_008b();
            }

            if (id == cardIDEnum.EX1_365)
            {
                return new Sim_EX1_365();
            }

            if (id == cardIDEnum.CS2_141)
            {
                return new Sim_CS2_141();
            }

            if (id == cardIDEnum.PRO_001)
            {
                return new Sim_PRO_001();
            }

            // if (id == CardDB.cardIDEnum.NAX8_04t) return new Sim_NAX8_04t();
            if (id == cardIDEnum.CS2_173)
            {
                return new Sim_CS2_173();
            }

            if (id == cardIDEnum.CS2_017)
            {
                return new Sim_CS2_017();
            }

            // if (id == CardDB.cardIDEnum.CRED_16) return new Sim_CRED_16();
            if (id == cardIDEnum.EX1_392)
            {
                return new Sim_EX1_392();
            }

            if (id == cardIDEnum.EX1_593)
            {
                return new Sim_EX1_593();
            }

            // if (id == CardDB.cardIDEnum.FP1_023e) return new Sim_FP1_023e();
            // if (id == CardDB.cardIDEnum.NAX1_05) return new Sim_NAX1_05();
            // if (id == CardDB.cardIDEnum.TU4d_002) return new Sim_TU4d_002();
            // if (id == CardDB.cardIDEnum.CRED_15) return new Sim_CRED_15();
            if (id == cardIDEnum.EX1_049)
            {
                return new Sim_EX1_049();
            }

            if (id == cardIDEnum.EX1_002)
            {
                return new Sim_EX1_002();
            }

            // if (id == CardDB.cardIDEnum.TU4f_005) return new Sim_TU4f_005();
            // if (id == CardDB.cardIDEnum.NEW1_029t) return new Sim_NEW1_029t();
            // if (id == CardDB.cardIDEnum.TU4a_001) return new Sim_TU4a_001();
            if (id == cardIDEnum.CS2_056)
            {
                return new Sim_CS2_056();
            }

            if (id == cardIDEnum.EX1_596)
            {
                return new Sim_EX1_596();
            }

            if (id == cardIDEnum.EX1_136)
            {
                return new Sim_EX1_136();
            }

            if (id == cardIDEnum.EX1_323)
            {
                return new Sim_EX1_323();
            }

            if (id == cardIDEnum.CS2_073)
            {
                return new Sim_CS2_073();
            }

            // if (id == CardDB.cardIDEnum.EX1_246e) return new Sim_EX1_246e();
            // if (id == CardDB.cardIDEnum.NAX12_01) return new Sim_NAX12_01();
            // if (id == CardDB.cardIDEnum.EX1_244e) return new Sim_EX1_244e();
            if (id == cardIDEnum.EX1_001)
            {
                return new Sim_EX1_001();
            }

            // if (id == CardDB.cardIDEnum.EX1_607e) return new Sim_EX1_607e();
            if (id == cardIDEnum.EX1_044)
            {
                return new Sim_EX1_044();
            }

            // if (id == CardDB.cardIDEnum.EX1_573ae) return new Sim_EX1_573ae();
            // if (id == CardDB.cardIDEnum.XXX_025) return new Sim_XXX_025();
            // if (id == CardDB.cardIDEnum.CRED_06) return new Sim_CRED_06();
            if (id == cardIDEnum.Mekka4)
            {
                return new Sim_Mekka4();
            }

            if (id == cardIDEnum.CS2_142)
            {
                return new Sim_CS2_142();
            }

            // if (id == CardDB.cardIDEnum.TU4f_004) return new Sim_TU4f_004();
            // if (id == CardDB.cardIDEnum.NAX5_02H) return new Sim_NAX5_02H();
            // if (id == CardDB.cardIDEnum.EX1_411e2) return new Sim_EX1_411e2();
            if (id == cardIDEnum.EX1_573)
            {
                return new Sim_EX1_573();
            }

            if (id == cardIDEnum.FP1_009)
            {
                return new Sim_FP1_009();
            }

            if (id == cardIDEnum.CS2_050)
            {
                return new Sim_CS2_050();
            }

            // if (id == CardDB.cardIDEnum.NAX4_03) return new Sim_NAX4_03();
            // if (id == CardDB.cardIDEnum.CS2_063e) return new Sim_CS2_063e();
            // if (id == CardDB.cardIDEnum.NAX2_05) return new Sim_NAX2_05();
            if (id == cardIDEnum.EX1_390)
            {
                return new Sim_EX1_390();
            }

            if (id == cardIDEnum.EX1_610)
            {
                return new Sim_EX1_610();
            }

            if (id == cardIDEnum.hexfrog)
            {
                return new Sim_hexfrog();
            }

            // if (id == CardDB.cardIDEnum.CS2_181e) return new Sim_CS2_181e();
            // if (id == CardDB.cardIDEnum.NAX6_02) return new Sim_NAX6_02();
            // if (id == CardDB.cardIDEnum.XXX_027) return new Sim_XXX_027();
            if (id == cardIDEnum.CS2_082)
            {
                return new Sim_CS2_082();
            }

            if (id == cardIDEnum.NEW1_040)
            {
                return new Sim_NEW1_040();
            }

            if (id == cardIDEnum.DREAM_01)
            {
                return new Sim_DREAM_01();
            }

            if (id == cardIDEnum.EX1_595)
            {
                return new Sim_EX1_595();
            }

            if (id == cardIDEnum.CS2_013)
            {
                return new Sim_CS2_013();
            }

            if (id == cardIDEnum.CS2_077)
            {
                return new Sim_CS2_077();
            }

            if (id == cardIDEnum.NEW1_014)
            {
                return new Sim_NEW1_014();
            }

            // if (id == CardDB.cardIDEnum.CRED_05) return new Sim_CRED_05();
            if (id == cardIDEnum.GAME_002)
            {
                return new Sim_GAME_002();
            }

            if (id == cardIDEnum.EX1_165)
            {
                return new Sim_EX1_165();
            }

            if (id == cardIDEnum.CS2_013t)
            {
                return new Sim_CS2_013t();
            }

            // if (id == CardDB.cardIDEnum.NAX4_04H) return new Sim_NAX4_04H();
            if (id == cardIDEnum.EX1_tk11)
            {
                return new Sim_EX1_tk11();
            }

            if (id == cardIDEnum.EX1_591)
            {
                return new Sim_EX1_591();
            }

            if (id == cardIDEnum.EX1_549)
            {
                return new Sim_EX1_549();
            }

            if (id == cardIDEnum.CS2_045)
            {
                return new Sim_CS2_045();
            }

            if (id == cardIDEnum.CS2_237)
            {
                return new Sim_CS2_237();
            }

            if (id == cardIDEnum.CS2_027)
            {
                return new Sim_CS2_027();
            }

            // if (id == CardDB.cardIDEnum.EX1_508o) return new Sim_EX1_508o();
            // if (id == CardDB.cardIDEnum.NAX14_03) return new Sim_NAX14_03();
            if (id == cardIDEnum.CS2_101t)
            {
                return new Sim_CS2_101t();
            }

            if (id == cardIDEnum.CS2_063)
            {
                return new Sim_CS2_063();
            }

            if (id == cardIDEnum.EX1_145)
            {
                return new Sim_EX1_145();
            }

            // if (id == CardDB.cardIDEnum.NAX1h_03) return new Sim_NAX1h_03();
            if (id == cardIDEnum.EX1_110)
            {
                return new Sim_EX1_110();
            }

            if (id == cardIDEnum.EX1_408)
            {
                return new Sim_EX1_408();
            }

            if (id == cardIDEnum.EX1_544)
            {
                return new Sim_EX1_544();
            }

            // if (id == CardDB.cardIDEnum.TU4c_006) return new Sim_TU4c_006();
            // if (id == CardDB.cardIDEnum.NAXM_001) return new Sim_NAXM_001();
            if (id == cardIDEnum.CS2_151)
            {
                return new Sim_CS2_151();
            }

            // if (id == CardDB.cardIDEnum.CS2_073e) return new Sim_CS2_073e();
            // if (id == CardDB.cardIDEnum.XXX_006) return new Sim_XXX_006();
            if (id == cardIDEnum.CS2_088)
            {
                return new Sim_CS2_088();
            }

            if (id == cardIDEnum.EX1_057)
            {
                return new Sim_EX1_057();
            }

            if (id == cardIDEnum.FP1_020)
            {
                return new Sim_FP1_020();
            }

            if (id == cardIDEnum.CS2_169)
            {
                return new Sim_CS2_169();
            }

            if (id == cardIDEnum.EX1_573t)
            {
                return new Sim_EX1_573t();
            }

            if (id == cardIDEnum.EX1_323h)
            {
                return new Sim_EX1_323h();
            }

            if (id == cardIDEnum.EX1_tk9)
            {
                return new Sim_EX1_tk9();
            }

            // if (id == CardDB.cardIDEnum.NEW1_018e) return new Sim_NEW1_018e();
            if (id == cardIDEnum.CS2_037)
            {
                return new Sim_CS2_037();
            }

            if (id == cardIDEnum.CS2_007)
            {
                return new Sim_CS2_007();
            }

            // if (id == CardDB.cardIDEnum.EX1_059e2) return new Sim_EX1_059e2();
            if (id == cardIDEnum.CS2_227)
            {
                return new Sim_CS2_227();
            }

            // if (id == CardDB.cardIDEnum.NAX7_03H) return new Sim_NAX7_03H();
            // if (id == CardDB.cardIDEnum.NAX9_01H) return new Sim_NAX9_01H();
            // if (id == CardDB.cardIDEnum.EX1_570e) return new Sim_EX1_570e();
            if (id == cardIDEnum.NEW1_003)
            {
                return new Sim_NEW1_003();
            }

            if (id == cardIDEnum.GAME_006)
            {
                return new Sim_GAME_006();
            }

            if (id == cardIDEnum.EX1_320)
            {
                return new Sim_EX1_320();
            }

            if (id == cardIDEnum.EX1_097)
            {
                return new Sim_EX1_097();
            }

            if (id == cardIDEnum.tt_004)
            {
                return new Sim_tt_004();
            }

            // if (id == CardDB.cardIDEnum.EX1_360e) return new Sim_EX1_360e();
            if (id == cardIDEnum.EX1_096)
            {
                return new Sim_EX1_096();
            }

            // if (id == CardDB.cardIDEnum.DS1_175o) return new Sim_DS1_175o();
            // if (id == CardDB.cardIDEnum.EX1_596e) return new Sim_EX1_596e();
            // if (id == CardDB.cardIDEnum.XXX_014) return new Sim_XXX_014();
            // if (id == CardDB.cardIDEnum.EX1_158e) return new Sim_EX1_158e();
            // if (id == CardDB.cardIDEnum.NAX14_01) return new Sim_NAX14_01();
            // if (id == CardDB.cardIDEnum.CRED_01) return new Sim_CRED_01();
            // if (id == CardDB.cardIDEnum.CRED_08) return new Sim_CRED_08();
            if (id == cardIDEnum.EX1_126)
            {
                return new Sim_EX1_126();
            }

            if (id == cardIDEnum.EX1_577)
            {
                return new Sim_EX1_577();
            }

            if (id == cardIDEnum.EX1_319)
            {
                return new Sim_EX1_319();
            }

            if (id == cardIDEnum.EX1_611)
            {
                return new Sim_EX1_611();
            }

            if (id == cardIDEnum.CS2_146)
            {
                return new Sim_CS2_146();
            }

            if (id == cardIDEnum.EX1_154b)
            {
                return new Sim_EX1_154b();
            }

            if (id == cardIDEnum.skele11)
            {
                return new Sim_skele11();
            }

            if (id == cardIDEnum.EX1_165t2)
            {
                return new Sim_EX1_165t2();
            }

            if (id == cardIDEnum.CS2_172)
            {
                return new Sim_CS2_172();
            }

            if (id == cardIDEnum.CS2_114)
            {
                return new Sim_CS2_114();
            }

            if (id == cardIDEnum.CS1_069)
            {
                return new Sim_CS1_069();
            }

            // if (id == CardDB.cardIDEnum.XXX_003) return new Sim_XXX_003();
            // if (id == CardDB.cardIDEnum.XXX_042) return new Sim_XXX_042();
            // if (id == CardDB.cardIDEnum.NAX8_02) return new Sim_NAX8_02();
            if (id == cardIDEnum.EX1_173)
            {
                return new Sim_EX1_173();
            }

            if (id == cardIDEnum.CS1_042)
            {
                return new Sim_CS1_042();
            }

            // if (id == CardDB.cardIDEnum.NAX8_03) return new Sim_NAX8_03();
            if (id == cardIDEnum.EX1_506a)
            {
                return new Sim_EX1_506a();
            }

            if (id == cardIDEnum.EX1_298)
            {
                return new Sim_EX1_298();
            }

            if (id == cardIDEnum.CS2_104)
            {
                return new Sim_CS2_104();
            }

            if (id == cardIDEnum.FP1_001)
            {
                return new Sim_FP1_001();
            }

            if (id == cardIDEnum.HERO_02)
            {
                return new Sim_HERO_02();
            }

            // if (id == CardDB.cardIDEnum.EX1_316e) return new Sim_EX1_316e();
            // if (id == CardDB.cardIDEnum.NAX7_01) return new Sim_NAX7_01();
            // if (id == CardDB.cardIDEnum.EX1_044e) return new Sim_EX1_044e();
            if (id == cardIDEnum.CS2_051)
            {
                return new Sim_CS2_051();
            }

            if (id == cardIDEnum.NEW1_016)
            {
                return new Sim_NEW1_016();
            }

            // if (id == CardDB.cardIDEnum.EX1_304e) return new Sim_EX1_304e();
            if (id == cardIDEnum.EX1_033)
            {
                return new Sim_EX1_033();
            }

            // if (id == CardDB.cardIDEnum.NAX8_04) return new Sim_NAX8_04();
            if (id == cardIDEnum.EX1_028)
            {
                return new Sim_EX1_028();
            }

            // if (id == CardDB.cardIDEnum.XXX_011) return new Sim_XXX_011();
            if (id == cardIDEnum.EX1_621)
            {
                return new Sim_EX1_621();
            }

            if (id == cardIDEnum.EX1_554)
            {
                return new Sim_EX1_554();
            }

            if (id == cardIDEnum.EX1_091)
            {
                return new Sim_EX1_091();
            }

            if (id == cardIDEnum.FP1_017)
            {
                return new Sim_FP1_017();
            }

            if (id == cardIDEnum.EX1_409)
            {
                return new Sim_EX1_409();
            }

            // if (id == CardDB.cardIDEnum.EX1_363e) return new Sim_EX1_363e();
            if (id == cardIDEnum.EX1_410)
            {
                return new Sim_EX1_410();
            }

            // if (id == CardDB.cardIDEnum.TU4e_005) return new Sim_TU4e_005();
            if (id == cardIDEnum.CS2_039)
            {
                return new Sim_CS2_039();
            }

            // if (id == CardDB.cardIDEnum.NAX12_04) return new Sim_NAX12_04();
            if (id == cardIDEnum.EX1_557)
            {
                return new Sim_EX1_557();
            }

            // if (id == CardDB.cardIDEnum.CS2_105e) return new Sim_CS2_105e();
            // if (id == CardDB.cardIDEnum.EX1_128e) return new Sim_EX1_128e();
            // if (id == CardDB.cardIDEnum.XXX_021) return new Sim_XXX_021();
            if (id == cardIDEnum.DS1_070)
            {
                return new Sim_DS1_070();
            }

            if (id == cardIDEnum.CS2_033)
            {
                return new Sim_CS2_033();
            }

            if (id == cardIDEnum.EX1_536)
            {
                return new Sim_EX1_536();
            }

            // if (id == CardDB.cardIDEnum.TU4a_003) return new Sim_TU4a_003();
            if (id == cardIDEnum.EX1_559)
            {
                return new Sim_EX1_559();
            }

            // if (id == CardDB.cardIDEnum.XXX_023) return new Sim_XXX_023();
            // if (id == CardDB.cardIDEnum.NEW1_033o) return new Sim_NEW1_033o();
            // if (id == CardDB.cardIDEnum.NAX15_04H) return new Sim_NAX15_04H();
            // if (id == CardDB.cardIDEnum.CS2_004e) return new Sim_CS2_004e();
            if (id == cardIDEnum.CS2_052)
            {
                return new Sim_CS2_052();
            }

            if (id == cardIDEnum.EX1_539)
            {
                return new Sim_EX1_539();
            }

            if (id == cardIDEnum.EX1_575)
            {
                return new Sim_EX1_575();
            }

            if (id == cardIDEnum.CS2_083b)
            {
                return new Sim_CS2_083b();
            }

            if (id == cardIDEnum.CS2_061)
            {
                return new Sim_CS2_061();
            }

            if (id == cardIDEnum.NEW1_021)
            {
                return new Sim_NEW1_021();
            }

            if (id == cardIDEnum.DS1_055)
            {
                return new Sim_DS1_055();
            }

            if (id == cardIDEnum.EX1_625)
            {
                return new Sim_EX1_625();
            }

            // if (id == CardDB.cardIDEnum.EX1_382e) return new Sim_EX1_382e();
            // if (id == CardDB.cardIDEnum.CS2_092e) return new Sim_CS2_092e();
            if (id == cardIDEnum.CS2_026)
            {
                return new Sim_CS2_026();
            }

            // if (id == CardDB.cardIDEnum.NAX14_04) return new Sim_NAX14_04();
            // if (id == CardDB.cardIDEnum.NEW1_012o) return new Sim_NEW1_012o();
            // if (id == CardDB.cardIDEnum.EX1_619e) return new Sim_EX1_619e();
            if (id == cardIDEnum.EX1_294)
            {
                return new Sim_EX1_294();
            }

            if (id == cardIDEnum.EX1_287)
            {
                return new Sim_EX1_287();
            }

            // if (id == CardDB.cardIDEnum.EX1_509e) return new Sim_EX1_509e();
            if (id == cardIDEnum.EX1_625t2)
            {
                return new Sim_EX1_625t2();
            }

            if (id == cardIDEnum.CS2_118)
            {
                return new Sim_CS2_118();
            }

            if (id == cardIDEnum.CS2_124)
            {
                return new Sim_CS2_124();
            }

            if (id == cardIDEnum.Mekka3)
            {
                return new Sim_Mekka3();
            }

            // if (id == CardDB.cardIDEnum.NAX13_02) return new Sim_NAX13_02();
            if (id == cardIDEnum.EX1_112)
            {
                return new Sim_EX1_112();
            }

            if (id == cardIDEnum.FP1_011)
            {
                return new Sim_FP1_011();
            }

            // if (id == CardDB.cardIDEnum.CS2_009e) return new Sim_CS2_009e();
            if (id == cardIDEnum.HERO_04)
            {
                return new Sim_HERO_04();
            }

            if (id == cardIDEnum.EX1_607)
            {
                return new Sim_EX1_607();
            }

            if (id == cardIDEnum.DREAM_03)
            {
                return new Sim_DREAM_03();
            }

            // if (id == CardDB.cardIDEnum.NAX11_04e) return new Sim_NAX11_04e();
            // if (id == CardDB.cardIDEnum.EX1_103e) return new Sim_EX1_103e();
            // if (id == CardDB.cardIDEnum.XXX_046) return new Sim_XXX_046();
            if (id == cardIDEnum.FP1_003)
            {
                return new Sim_FP1_003();
            }

            if (id == cardIDEnum.CS2_105)
            {
                return new Sim_CS2_105();
            }

            if (id == cardIDEnum.FP1_002)
            {
                return new Sim_FP1_002();
            }

            // if (id == CardDB.cardIDEnum.TU4c_002) return new Sim_TU4c_002();
            // if (id == CardDB.cardIDEnum.CRED_14) return new Sim_CRED_14();
            if (id == cardIDEnum.EX1_567)
            {
                return new Sim_EX1_567();
            }

            // if (id == CardDB.cardIDEnum.TU4c_004) return new Sim_TU4c_004();
            // if (id == CardDB.cardIDEnum.NAX10_03H) return new Sim_NAX10_03H();
            if (id == cardIDEnum.FP1_008)
            {
                return new Sim_FP1_008();
            }

            if (id == cardIDEnum.DS1_184)
            {
                return new Sim_DS1_184();
            }

            if (id == cardIDEnum.CS2_029)
            {
                return new Sim_CS2_029();
            }

            if (id == cardIDEnum.GAME_005)
            {
                return new Sim_GAME_005();
            }

            if (id == cardIDEnum.CS2_187)
            {
                return new Sim_CS2_187();
            }

            if (id == cardIDEnum.EX1_020)
            {
                return new Sim_EX1_020();
            }

            // if (id == CardDB.cardIDEnum.NAX15_01He) return new Sim_NAX15_01He();
            if (id == cardIDEnum.EX1_011)
            {
                return new Sim_EX1_011();
            }

            if (id == cardIDEnum.CS2_057)
            {
                return new Sim_CS2_057();
            }

            if (id == cardIDEnum.EX1_274)
            {
                return new Sim_EX1_274();
            }

            if (id == cardIDEnum.EX1_306)
            {
                return new Sim_EX1_306();
            }

            // if (id == CardDB.cardIDEnum.NEW1_038o) return new Sim_NEW1_038o();
            if (id == cardIDEnum.EX1_170)
            {
                return new Sim_EX1_170();
            }

            if (id == cardIDEnum.EX1_617)
            {
                return new Sim_EX1_617();
            }

            // if (id == CardDB.cardIDEnum.CS1_113e) return new Sim_CS1_113e();
            if (id == cardIDEnum.CS2_101)
            {
                return new Sim_CS2_101();
            }

            if (id == cardIDEnum.FP1_015)
            {
                return new Sim_FP1_015();
            }

            // if (id == CardDB.cardIDEnum.NAX13_03) return new Sim_NAX13_03();
            if (id == cardIDEnum.CS2_005)
            {
                return new Sim_CS2_005();
            }

            if (id == cardIDEnum.EX1_537)
            {
                return new Sim_EX1_537();
            }

            if (id == cardIDEnum.EX1_384)
            {
                return new Sim_EX1_384();
            }

            // if (id == CardDB.cardIDEnum.TU4a_002) return new Sim_TU4a_002();
            // if (id == CardDB.cardIDEnum.NAX9_04) return new Sim_NAX9_04();
            if (id == cardIDEnum.EX1_362)
            {
                return new Sim_EX1_362();
            }

            // if (id == CardDB.cardIDEnum.NAX12_02) return new Sim_NAX12_02();
            // if (id == CardDB.cardIDEnum.FP1_028e) return new Sim_FP1_028e();
            // if (id == CardDB.cardIDEnum.TU4c_005) return new Sim_TU4c_005();
            if (id == cardIDEnum.EX1_301)
            {
                return new Sim_EX1_301();
            }

            if (id == cardIDEnum.CS2_235)
            {
                return new Sim_CS2_235();
            }

            // if (id == CardDB.cardIDEnum.NAX4_05) return new Sim_NAX4_05();
            if (id == cardIDEnum.EX1_029)
            {
                return new Sim_EX1_029();
            }

            if (id == cardIDEnum.CS2_042)
            {
                return new Sim_CS2_042();
            }

            if (id == cardIDEnum.EX1_155a)
            {
                return new Sim_EX1_155a();
            }

            if (id == cardIDEnum.CS2_102)
            {
                return new Sim_CS2_102();
            }

            if (id == cardIDEnum.EX1_609)
            {
                return new Sim_EX1_609();
            }

            if (id == cardIDEnum.NEW1_027)
            {
                return new Sim_NEW1_027();
            }

            // if (id == CardDB.cardIDEnum.CS2_236e) return new Sim_CS2_236e();
            // if (id == CardDB.cardIDEnum.CS2_083e) return new Sim_CS2_083e();
            // if (id == CardDB.cardIDEnum.NAX6_03te) return new Sim_NAX6_03te();
            if (id == cardIDEnum.EX1_165a)
            {
                return new Sim_EX1_165a();
            }

            if (id == cardIDEnum.EX1_570)
            {
                return new Sim_EX1_570();
            }

            if (id == cardIDEnum.EX1_131)
            {
                return new Sim_EX1_131();
            }

            if (id == cardIDEnum.EX1_556)
            {
                return new Sim_EX1_556();
            }

            if (id == cardIDEnum.EX1_543)
            {
                return new Sim_EX1_543();
            }

            // if (id == CardDB.cardIDEnum.XXX_096) return new Sim_XXX_096();
            // if (id == CardDB.cardIDEnum.TU4c_008e) return new Sim_TU4c_008e();
            // if (id == CardDB.cardIDEnum.EX1_379e) return new Sim_EX1_379e();
            if (id == cardIDEnum.NEW1_009)
            {
                return new Sim_NEW1_009();
            }

            if (id == cardIDEnum.EX1_100)
            {
                return new Sim_EX1_100();
            }

            // if (id == CardDB.cardIDEnum.EX1_274e) return new Sim_EX1_274e();
            // if (id == CardDB.cardIDEnum.CRED_02) return new Sim_CRED_02();
            if (id == cardIDEnum.EX1_573a)
            {
                return new Sim_EX1_573a();
            }

            if (id == cardIDEnum.CS2_084)
            {
                return new Sim_CS2_084();
            }

            if (id == cardIDEnum.EX1_582)
            {
                return new Sim_EX1_582();
            }

            if (id == cardIDEnum.EX1_043)
            {
                return new Sim_EX1_043();
            }

            if (id == cardIDEnum.EX1_050)
            {
                return new Sim_EX1_050();
            }

            // if (id == CardDB.cardIDEnum.TU4b_001) return new Sim_TU4b_001();
            if (id == cardIDEnum.FP1_005)
            {
                return new Sim_FP1_005();
            }

            if (id == cardIDEnum.EX1_620)
            {
                return new Sim_EX1_620();
            }

            // if (id == CardDB.cardIDEnum.NAX15_01) return new Sim_NAX15_01();
            // if (id == CardDB.cardIDEnum.NAX6_03) return new Sim_NAX6_03();
            if (id == cardIDEnum.EX1_303)
            {
                return new Sim_EX1_303();
            }

            if (id == cardIDEnum.HERO_09)
            {
                return new Sim_HERO_09();
            }

            if (id == cardIDEnum.EX1_067)
            {
                return new Sim_EX1_067();
            }

            // if (id == CardDB.cardIDEnum.XXX_028) return new Sim_XXX_028();
            if (id == cardIDEnum.EX1_277)
            {
                return new Sim_EX1_277();
            }

            if (id == cardIDEnum.Mekka2)
            {
                return new Sim_Mekka2();
            }

            // if (id == CardDB.cardIDEnum.NAX14_01H) return new Sim_NAX14_01H();
            // if (id == CardDB.cardIDEnum.NAX15_04) return new Sim_NAX15_04();
            if (id == cardIDEnum.FP1_024)
            {
                return new Sim_FP1_024();
            }

            if (id == cardIDEnum.FP1_030)
            {
                return new Sim_FP1_030();
            }

            // if (id == CardDB.cardIDEnum.CS2_221e) return new Sim_CS2_221e();
            if (id == cardIDEnum.EX1_178)
            {
                return new Sim_EX1_178();
            }

            if (id == cardIDEnum.CS2_222)
            {
                return new Sim_CS2_222();
            }

            // if (id == CardDB.cardIDEnum.EX1_409e) return new Sim_EX1_409e();
            // if (id == CardDB.cardIDEnum.tt_004o) return new Sim_tt_004o();
            // if (id == CardDB.cardIDEnum.EX1_155ae) return new Sim_EX1_155ae();
            // if (id == CardDB.cardIDEnum.NAX11_01H) return new Sim_NAX11_01H();
            if (id == cardIDEnum.EX1_160a)
            {
                return new Sim_EX1_160a();
            }

            // if (id == CardDB.cardIDEnum.NAX15_02) return new Sim_NAX15_02();
            // if (id == CardDB.cardIDEnum.NAX15_05) return new Sim_NAX15_05();
            // if (id == CardDB.cardIDEnum.NEW1_025e) return new Sim_NEW1_025e();
            if (id == cardIDEnum.CS2_012)
            {
                return new Sim_CS2_012();
            }

            // if (id == CardDB.cardIDEnum.XXX_099) return new Sim_XXX_099();
            if (id == cardIDEnum.EX1_246)
            {
                return new Sim_EX1_246();
            }

            if (id == cardIDEnum.EX1_572)
            {
                return new Sim_EX1_572();
            }

            if (id == cardIDEnum.EX1_089)
            {
                return new Sim_EX1_089();
            }

            if (id == cardIDEnum.CS2_059)
            {
                return new Sim_CS2_059();
            }

            if (id == cardIDEnum.EX1_279)
            {
                return new Sim_EX1_279();
            }

            // if (id == CardDB.cardIDEnum.NAX12_02e) return new Sim_NAX12_02e();
            if (id == cardIDEnum.CS2_168)
            {
                return new Sim_CS2_168();
            }

            if (id == cardIDEnum.tt_010)
            {
                return new Sim_tt_010();
            }

            if (id == cardIDEnum.NEW1_023)
            {
                return new Sim_NEW1_023();
            }

            if (id == cardIDEnum.CS2_075)
            {
                return new Sim_CS2_075();
            }

            if (id == cardIDEnum.EX1_316)
            {
                return new Sim_EX1_316();
            }

            if (id == cardIDEnum.CS2_025)
            {
                return new Sim_CS2_025();
            }

            if (id == cardIDEnum.CS2_234)
            {
                return new Sim_CS2_234();
            }

            // if (id == CardDB.cardIDEnum.XXX_043) return new Sim_XXX_043();
            // if (id == CardDB.cardIDEnum.GAME_001) return new Sim_GAME_001();
            // if (id == CardDB.cardIDEnum.NAX5_02) return new Sim_NAX5_02();
            if (id == cardIDEnum.EX1_130)
            {
                return new Sim_EX1_130();
            }

            // if (id == CardDB.cardIDEnum.EX1_584e) return new Sim_EX1_584e();
            if (id == cardIDEnum.CS2_064)
            {
                return new Sim_CS2_064();
            }

            if (id == cardIDEnum.EX1_161)
            {
                return new Sim_EX1_161();
            }

            if (id == cardIDEnum.CS2_049)
            {
                return new Sim_CS2_049();
            }

            // if (id == CardDB.cardIDEnum.NAX13_01) return new Sim_NAX13_01();
            if (id == cardIDEnum.EX1_154)
            {
                return new Sim_EX1_154();
            }

            if (id == cardIDEnum.EX1_080)
            {
                return new Sim_EX1_080();
            }

            if (id == cardIDEnum.NEW1_022)
            {
                return new Sim_NEW1_022();
            }

            // if (id == CardDB.cardIDEnum.NAX2_01H) return new Sim_NAX2_01H();
            // if (id == CardDB.cardIDEnum.EX1_160be) return new Sim_EX1_160be();
            // if (id == CardDB.cardIDEnum.NAX12_03) return new Sim_NAX12_03();
            if (id == cardIDEnum.EX1_251)
            {
                return new Sim_EX1_251();
            }

            if (id == cardIDEnum.FP1_025)
            {
                return new Sim_FP1_025();
            }

            if (id == cardIDEnum.EX1_371)
            {
                return new Sim_EX1_371();
            }

            if (id == cardIDEnum.CS2_mirror)
            {
                return new Sim_CS2_mirror();
            }

            // if (id == CardDB.cardIDEnum.NAX4_01H) return new Sim_NAX4_01H();
            if (id == cardIDEnum.EX1_594)
            {
                return new Sim_EX1_594();
            }

            // if (id == CardDB.cardIDEnum.NAX14_02) return new Sim_NAX14_02();
            // if (id == CardDB.cardIDEnum.TU4c_006e) return new Sim_TU4c_006e();
            if (id == cardIDEnum.EX1_560)
            {
                return new Sim_EX1_560();
            }

            if (id == cardIDEnum.CS2_236)
            {
                return new Sim_CS2_236();
            }

            // if (id == CardDB.cardIDEnum.TU4f_006) return new Sim_TU4f_006();
            if (id == cardIDEnum.EX1_402)
            {
                return new Sim_EX1_402();
            }

            // if (id == CardDB.cardIDEnum.NAX3_01) return new Sim_NAX3_01();
            if (id == cardIDEnum.EX1_506)
            {
                return new Sim_EX1_506();
            }

            // if (id == CardDB.cardIDEnum.NEW1_027e) return new Sim_NEW1_027e();
            // if (id == CardDB.cardIDEnum.DS1_070o) return new Sim_DS1_070o();
            // if (id == CardDB.cardIDEnum.XXX_045) return new Sim_XXX_045();
            // if (id == CardDB.cardIDEnum.XXX_029) return new Sim_XXX_029();
            if (id == cardIDEnum.DS1_178)
            {
                return new Sim_DS1_178();
            }

            // if (id == CardDB.cardIDEnum.XXX_098) return new Sim_XXX_098();
            if (id == cardIDEnum.EX1_315)
            {
                return new Sim_EX1_315();
            }

            if (id == cardIDEnum.CS2_094)
            {
                return new Sim_CS2_094();
            }

            // if (id == CardDB.cardIDEnum.NAX13_01H) return new Sim_NAX13_01H();
            // if (id == CardDB.cardIDEnum.TU4e_002t) return new Sim_TU4e_002t();
            // if (id == CardDB.cardIDEnum.EX1_046e) return new Sim_EX1_046e();
            if (id == cardIDEnum.NEW1_040t)
            {
                return new Sim_NEW1_040t();
            }

            // if (id == CardDB.cardIDEnum.GAME_005e) return new Sim_GAME_005e();
            if (id == cardIDEnum.CS2_131)
            {
                return new Sim_CS2_131();
            }

            // if (id == CardDB.cardIDEnum.XXX_008) return new Sim_XXX_008();
            // if (id == CardDB.cardIDEnum.EX1_531e) return new Sim_EX1_531e();
            // if (id == CardDB.cardIDEnum.CS2_226e) return new Sim_CS2_226e();
            // if (id == CardDB.cardIDEnum.XXX_022e) return new Sim_XXX_022e();
            // if (id == CardDB.cardIDEnum.DS1_178e) return new Sim_DS1_178e();
            // if (id == CardDB.cardIDEnum.CS2_226o) return new Sim_CS2_226o();
            // if (id == CardDB.cardIDEnum.NAX9_04H) return new Sim_NAX9_04H();
            // if (id == CardDB.cardIDEnum.Mekka4e) return new Sim_Mekka4e();
            if (id == cardIDEnum.EX1_082)
            {
                return new Sim_EX1_082();
            }

            if (id == cardIDEnum.CS2_093)
            {
                return new Sim_CS2_093();
            }

            // if (id == CardDB.cardIDEnum.EX1_411e) return new Sim_EX1_411e();
            // if (id == CardDB.cardIDEnum.NAX8_03t) return new Sim_NAX8_03t();
            // if (id == CardDB.cardIDEnum.EX1_145o) return new Sim_EX1_145o();
            // if (id == CardDB.cardIDEnum.NAX7_04) return new Sim_NAX7_04();
            if (id == cardIDEnum.CS2_boar)
            {
                return new Sim_CS2_boar();
            }

            if (id == cardIDEnum.NEW1_019)
            {
                return new Sim_NEW1_019();
            }

            if (id == cardIDEnum.EX1_289)
            {
                return new Sim_EX1_289();
            }

            if (id == cardIDEnum.EX1_025t)
            {
                return new Sim_EX1_025t();
            }

            if (id == cardIDEnum.EX1_398t)
            {
                return new Sim_EX1_398t();
            }

            // if (id == CardDB.cardIDEnum.NAX12_03H) return new Sim_NAX12_03H();
            // if (id == CardDB.cardIDEnum.EX1_055o) return new Sim_EX1_055o();
            if (id == cardIDEnum.CS2_091)
            {
                return new Sim_CS2_091();
            }

            if (id == cardIDEnum.EX1_241)
            {
                return new Sim_EX1_241();
            }

            if (id == cardIDEnum.EX1_085)
            {
                return new Sim_EX1_085();
            }

            if (id == cardIDEnum.CS2_200)
            {
                return new Sim_CS2_200();
            }

            if (id == cardIDEnum.CS2_034)
            {
                return new Sim_CS2_034();
            }

            if (id == cardIDEnum.EX1_583)
            {
                return new Sim_EX1_583();
            }

            if (id == cardIDEnum.EX1_584)
            {
                return new Sim_EX1_584();
            }

            if (id == cardIDEnum.EX1_155)
            {
                return new Sim_EX1_155();
            }

            if (id == cardIDEnum.EX1_622)
            {
                return new Sim_EX1_622();
            }

            if (id == cardIDEnum.CS2_203)
            {
                return new Sim_CS2_203();
            }

            if (id == cardIDEnum.EX1_124)
            {
                return new Sim_EX1_124();
            }

            if (id == cardIDEnum.EX1_379)
            {
                return new Sim_EX1_379();
            }

            // if (id == CardDB.cardIDEnum.NAX7_02) return new Sim_NAX7_02();
            // if (id == CardDB.cardIDEnum.CS2_053e) return new Sim_CS2_053e();
            if (id == cardIDEnum.EX1_032)
            {
                return new Sim_EX1_032();
            }

            // if (id == CardDB.cardIDEnum.NAX9_01) return new Sim_NAX9_01();
            // if (id == CardDB.cardIDEnum.TU4e_003) return new Sim_TU4e_003();
            // if (id == CardDB.cardIDEnum.CS2_146o) return new Sim_CS2_146o();
            // if (id == CardDB.cardIDEnum.NAX8_01H) return new Sim_NAX8_01H();
            // if (id == CardDB.cardIDEnum.XXX_041) return new Sim_XXX_041();
            // if (id == CardDB.cardIDEnum.NAXM_002) return new Sim_NAXM_002();
            if (id == cardIDEnum.EX1_391)
            {
                return new Sim_EX1_391();
            }

            if (id == cardIDEnum.EX1_366)
            {
                return new Sim_EX1_366();
            }

            // if (id == CardDB.cardIDEnum.EX1_059e) return new Sim_EX1_059e();
            // if (id == CardDB.cardIDEnum.XXX_012) return new Sim_XXX_012();
            // if (id == CardDB.cardIDEnum.EX1_565o) return new Sim_EX1_565o();
            // if (id == CardDB.cardIDEnum.EX1_001e) return new Sim_EX1_001e();
            // if (id == CardDB.cardIDEnum.TU4f_003) return new Sim_TU4f_003();
            if (id == cardIDEnum.EX1_400)
            {
                return new Sim_EX1_400();
            }

            if (id == cardIDEnum.EX1_614)
            {
                return new Sim_EX1_614();
            }

            if (id == cardIDEnum.EX1_561)
            {
                return new Sim_EX1_561();
            }

            if (id == cardIDEnum.EX1_332)
            {
                return new Sim_EX1_332();
            }

            if (id == cardIDEnum.HERO_05)
            {
                return new Sim_HERO_05();
            }

            if (id == cardIDEnum.CS2_065)
            {
                return new Sim_CS2_065();
            }

            if (id == cardIDEnum.ds1_whelptoken)
            {
                return new Sim_ds1_whelptoken();
            }

            // if (id == CardDB.cardIDEnum.EX1_536e) return new Sim_EX1_536e();
            if (id == cardIDEnum.CS2_032)
            {
                return new Sim_CS2_032();
            }

            if (id == cardIDEnum.CS2_120)
            {
                return new Sim_CS2_120();
            }

            // if (id == CardDB.cardIDEnum.EX1_155be) return new Sim_EX1_155be();
            if (id == cardIDEnum.EX1_247)
            {
                return new Sim_EX1_247();
            }

            if (id == cardIDEnum.EX1_154a)
            {
                return new Sim_EX1_154a();
            }

            if (id == cardIDEnum.EX1_554t)
            {
                return new Sim_EX1_554t();
            }

            // if (id == CardDB.cardIDEnum.CS2_103e2) return new Sim_CS2_103e2();
            // if (id == CardDB.cardIDEnum.TU4d_003) return new Sim_TU4d_003();
            if (id == cardIDEnum.NEW1_026t)
            {
                return new Sim_NEW1_026t();
            }

            if (id == cardIDEnum.EX1_623)
            {
                return new Sim_EX1_623();
            }

            if (id == cardIDEnum.EX1_383t)
            {
                return new Sim_EX1_383t();
            }

            // if (id == CardDB.cardIDEnum.NAX7_03) return new Sim_NAX7_03();
            if (id == cardIDEnum.EX1_597)
            {
                return new Sim_EX1_597();
            }

            // if (id == CardDB.cardIDEnum.TU4f_006o) return new Sim_TU4f_006o();
            if (id == cardIDEnum.EX1_130a)
            {
                return new Sim_EX1_130a();
            }

            if (id == cardIDEnum.CS2_011)
            {
                return new Sim_CS2_011();
            }

            if (id == cardIDEnum.EX1_169)
            {
                return new Sim_EX1_169();
            }

            if (id == cardIDEnum.EX1_tk33)
            {
                return new Sim_EX1_tk33();
            }

            // if (id == CardDB.cardIDEnum.NAX11_03) return new Sim_NAX11_03();
            // if (id == CardDB.cardIDEnum.NAX4_01) return new Sim_NAX4_01();
            // if (id == CardDB.cardIDEnum.NAX10_01) return new Sim_NAX10_01();
            if (id == cardIDEnum.EX1_250)
            {
                return new Sim_EX1_250();
            }

            if (id == cardIDEnum.EX1_564)
            {
                return new Sim_EX1_564();
            }

            // if (id == CardDB.cardIDEnum.NAX5_03) return new Sim_NAX5_03();
            // if (id == CardDB.cardIDEnum.EX1_043e) return new Sim_EX1_043e();
            if (id == cardIDEnum.EX1_349)
            {
                return new Sim_EX1_349();
            }

            // if (id == CardDB.cardIDEnum.XXX_097) return new Sim_XXX_097();
            if (id == cardIDEnum.EX1_102)
            {
                return new Sim_EX1_102();
            }

            if (id == cardIDEnum.EX1_058)
            {
                return new Sim_EX1_058();
            }

            if (id == cardIDEnum.EX1_243)
            {
                return new Sim_EX1_243();
            }

            if (id == cardIDEnum.PRO_001c)
            {
                return new Sim_PRO_001c();
            }

            if (id == cardIDEnum.EX1_116t)
            {
                return new Sim_EX1_116t();
            }

            // if (id == CardDB.cardIDEnum.NAX15_01e) return new Sim_NAX15_01e();
            if (id == cardIDEnum.FP1_029)
            {
                return new Sim_FP1_029();
            }

            if (id == cardIDEnum.CS2_089)
            {
                return new Sim_CS2_089();
            }

            // if (id == CardDB.cardIDEnum.TU4c_001) return new Sim_TU4c_001();
            if (id == cardIDEnum.EX1_248)
            {
                return new Sim_EX1_248();
            }

            // if (id == CardDB.cardIDEnum.NEW1_037e) return new Sim_NEW1_037e();
            if (id == cardIDEnum.CS2_122)
            {
                return new Sim_CS2_122();
            }

            if (id == cardIDEnum.EX1_393)
            {
                return new Sim_EX1_393();
            }

            if (id == cardIDEnum.CS2_232)
            {
                return new Sim_CS2_232();
            }

            if (id == cardIDEnum.EX1_165b)
            {
                return new Sim_EX1_165b();
            }

            if (id == cardIDEnum.NEW1_030)
            {
                return new Sim_NEW1_030();
            }

            // if (id == CardDB.cardIDEnum.EX1_161o) return new Sim_EX1_161o();
            // if (id == CardDB.cardIDEnum.EX1_093e) return new Sim_EX1_093e();
            if (id == cardIDEnum.CS2_150)
            {
                return new Sim_CS2_150();
            }

            if (id == cardIDEnum.CS2_152)
            {
                return new Sim_CS2_152();
            }

            // if (id == CardDB.cardIDEnum.NAX9_03H) return new Sim_NAX9_03H();
            if (id == cardIDEnum.EX1_160t)
            {
                return new Sim_EX1_160t();
            }

            if (id == cardIDEnum.CS2_127)
            {
                return new Sim_CS2_127();
            }

            // if (id == CardDB.cardIDEnum.CRED_03) return new Sim_CRED_03();
            if (id == cardIDEnum.DS1_188)
            {
                return new Sim_DS1_188();
            }

            // if (id == CardDB.cardIDEnum.XXX_001) return new Sim_XXX_001();
            return new SimTemplate();
        }

        /// <summary>
        /// The enum creator.
        /// </summary>
        private void enumCreator()
        {
            // call this, if carddb.txt was changed, to get latest public enum cardIDEnum
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

        /// <summary>
        /// The set additional data.
        /// </summary>
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
