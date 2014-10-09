// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TAGGS.cs" company="">
//   
// </copyright>
// <summary>
//   The side.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The side.
    /// </summary>
    public enum Side
    {
        /// <summary>
        /// The neutral.
        /// </summary>
        NEUTRAL, 

        /// <summary>
        /// The friendly.
        /// </summary>
        FRIENDLY, 

        /// <summary>
        /// The opposing.
        /// </summary>
        OPPOSING
    }

    /// <summary>
    /// The gam e_ ta gs.
    /// </summary>
    public enum GAME_TAGs
    {
        /// <summary>
        /// The state.
        /// </summary>
        STATE = 204, 

        /// <summary>
        /// The turn.
        /// </summary>
        TURN = 20, 

        /// <summary>
        /// The step.
        /// </summary>
        STEP = 19, 

        /// <summary>
        /// The nex t_ step.
        /// </summary>
        NEXT_STEP = 198, 

        /// <summary>
        /// The tea m_ id.
        /// </summary>
        TEAM_ID = 31, 

        /// <summary>
        /// The playe r_ id.
        /// </summary>
        PLAYER_ID = 30, 

        /// <summary>
        /// The starthandsize.
        /// </summary>
        STARTHANDSIZE = 29, 

        /// <summary>
        /// The maxhandsize.
        /// </summary>
        MAXHANDSIZE = 28, 

        /// <summary>
        /// The maxresources.
        /// </summary>
        MAXRESOURCES = 176, 

        /// <summary>
        /// The timeout.
        /// </summary>
        TIMEOUT = 7, 

        /// <summary>
        /// The tur n_ start.
        /// </summary>
        TURN_START, 

        /// <summary>
        /// The tur n_ time r_ slush.
        /// </summary>
        TURN_TIMER_SLUSH, 

        /// <summary>
        /// The gol d_ rewar d_ state.
        /// </summary>
        GOLD_REWARD_STATE = 13, 

        /// <summary>
        /// The firs t_ player.
        /// </summary>
        FIRST_PLAYER = 24, 

        /// <summary>
        /// The curren t_ player.
        /// </summary>
        CURRENT_PLAYER = 23, 

        /// <summary>
        /// The her o_ entity.
        /// </summary>
        HERO_ENTITY = 27, 

        /// <summary>
        /// The resources.
        /// </summary>
        RESOURCES = 26, 

        /// <summary>
        /// The resource s_ used.
        /// </summary>
        RESOURCES_USED = 25, 

        /// <summary>
        /// The fatigue.
        /// </summary>
        FATIGUE = 22, 

        /// <summary>
        /// The playstate.
        /// </summary>
        PLAYSTATE = 17, 

        /// <summary>
        /// The curren t_ spellpower.
        /// </summary>
        CURRENT_SPELLPOWER = 291, 

        /// <summary>
        /// The mulliga n_ state.
        /// </summary>
        MULLIGAN_STATE = 305, 

        /// <summary>
        /// The han d_ revealed.
        /// </summary>
        HAND_REVEALED = 348, 

        /// <summary>
        /// The cardname.
        /// </summary>
        CARDNAME = 185, 

        /// <summary>
        /// The cardtex t_ inhand.
        /// </summary>
        CARDTEXT_INHAND = 184, 

        /// <summary>
        /// The cardrace.
        /// </summary>
        CARDRACE = 200, 

        /// <summary>
        /// The cardtype.
        /// </summary>
        CARDTYPE = 202, 

        /// <summary>
        /// The cost.
        /// </summary>
        COST = 48, 

        /// <summary>
        /// The health.
        /// </summary>
        HEALTH = 45, 

        /// <summary>
        /// The atk.
        /// </summary>
        ATK = 47, 

        /// <summary>
        /// The durability.
        /// </summary>
        DURABILITY = 187, 

        /// <summary>
        /// The armor.
        /// </summary>
        ARMOR = 292, 

        /// <summary>
        /// The predamage.
        /// </summary>
        PREDAMAGE = 318, 

        /// <summary>
        /// The targetin g_ arro w_ text.
        /// </summary>
        TARGETING_ARROW_TEXT = 325, 

        /// <summary>
        /// The las t_ affecte d_ by.
        /// </summary>
        LAST_AFFECTED_BY = 18, 

        /// <summary>
        /// The enchantmen t_ birt h_ visual.
        /// </summary>
        ENCHANTMENT_BIRTH_VISUAL = 330, 

        /// <summary>
        /// The enchantmen t_ idl e_ visual.
        /// </summary>
        ENCHANTMENT_IDLE_VISUAL, 

        /// <summary>
        /// The premium.
        /// </summary>
        PREMIUM = 12, 

        /// <summary>
        /// The ignor e_ damage.
        /// </summary>
        IGNORE_DAMAGE = 1, 

        /// <summary>
        /// The ignor e_ damag e_ off.
        /// </summary>
        IGNORE_DAMAGE_OFF = 354, 

        /// <summary>
        /// The entit y_ id.
        /// </summary>
        ENTITY_ID = 53, 

        /// <summary>
        /// The definition.
        /// </summary>
        DEFINITION = 52, 

        /// <summary>
        /// The owner.
        /// </summary>
        OWNER = 51, 

        /// <summary>
        /// The controller.
        /// </summary>
        CONTROLLER = 50, 

        /// <summary>
        /// The zone.
        /// </summary>
        ZONE = 49, 

        /// <summary>
        /// The exhausted.
        /// </summary>
        EXHAUSTED = 43, 

        /// <summary>
        /// The attached.
        /// </summary>
        ATTACHED = 40, 

        /// <summary>
        /// The propose d_ attacker.
        /// </summary>
        PROPOSED_ATTACKER = 39, 

        /// <summary>
        /// The attacking.
        /// </summary>
        ATTACKING = 38, 

        /// <summary>
        /// The propose d_ defender.
        /// </summary>
        PROPOSED_DEFENDER = 37, 

        /// <summary>
        /// The defending.
        /// </summary>
        DEFENDING = 36, 

        /// <summary>
        /// The protected.
        /// </summary>
        PROTECTED = 35, 

        /// <summary>
        /// The protecting.
        /// </summary>
        PROTECTING = 34, 

        /// <summary>
        /// The recentl y_ arrived.
        /// </summary>
        RECENTLY_ARRIVED = 33, 

        /// <summary>
        /// The damage.
        /// </summary>
        DAMAGE = 44, 

        /// <summary>
        /// The trigge r_ visual.
        /// </summary>
        TRIGGER_VISUAL = 32, 

        /// <summary>
        /// The taunt.
        /// </summary>
        TAUNT = 190, 

        /// <summary>
        /// The spellpower.
        /// </summary>
        SPELLPOWER = 192, 

        /// <summary>
        /// The divin e_ shield.
        /// </summary>
        DIVINE_SHIELD = 194, 

        /// <summary>
        /// The charge.
        /// </summary>
        CHARGE = 197, 

        /// <summary>
        /// The secret.
        /// </summary>
        SECRET = 219, 

        /// <summary>
        /// The morph.
        /// </summary>
        MORPH = 293, 

        /// <summary>
        /// The divin e_ shiel d_ ready.
        /// </summary>
        DIVINE_SHIELD_READY = 314, 

        /// <summary>
        /// The taun t_ ready.
        /// </summary>
        TAUNT_READY = 306, 

        /// <summary>
        /// The stealt h_ ready.
        /// </summary>
        STEALTH_READY, 

        /// <summary>
        /// The charg e_ ready.
        /// </summary>
        CHARGE_READY, 

        /// <summary>
        /// The creator.
        /// </summary>
        CREATOR = 313, 

        /// <summary>
        /// The can t_ draw.
        /// </summary>
        CANT_DRAW = 232, 

        /// <summary>
        /// The can t_ play.
        /// </summary>
        CANT_PLAY = 231, 

        /// <summary>
        /// The can t_ discard.
        /// </summary>
        CANT_DISCARD = 230, 

        /// <summary>
        /// The can t_ destroy.
        /// </summary>
        CANT_DESTROY = 229, 

        /// <summary>
        /// The can t_ target.
        /// </summary>
        CANT_TARGET = 228, 

        /// <summary>
        /// The can t_ attack.
        /// </summary>
        CANT_ATTACK = 227, 

        /// <summary>
        /// The can t_ exhaust.
        /// </summary>
        CANT_EXHAUST = 226, 

        /// <summary>
        /// The can t_ ready.
        /// </summary>
        CANT_READY = 225, 

        /// <summary>
        /// The can t_ remov e_ fro m_ game.
        /// </summary>
        CANT_REMOVE_FROM_GAME = 224, 

        /// <summary>
        /// The can t_ se t_ aside.
        /// </summary>
        CANT_SET_ASIDE = 223, 

        /// <summary>
        /// The can t_ damage.
        /// </summary>
        CANT_DAMAGE = 222, 

        /// <summary>
        /// The can t_ heal.
        /// </summary>
        CANT_HEAL = 221, 

        /// <summary>
        /// The can t_ b e_ destroyed.
        /// </summary>
        CANT_BE_DESTROYED = 247, 

        /// <summary>
        /// The can t_ b e_ targeted.
        /// </summary>
        CANT_BE_TARGETED = 246, 

        /// <summary>
        /// The can t_ b e_ attacked.
        /// </summary>
        CANT_BE_ATTACKED = 245, 

        /// <summary>
        /// The can t_ b e_ exhausted.
        /// </summary>
        CANT_BE_EXHAUSTED = 244, 

        /// <summary>
        /// The can t_ b e_ readied.
        /// </summary>
        CANT_BE_READIED = 243, 

        /// <summary>
        /// The can t_ b e_ remove d_ fro m_ game.
        /// </summary>
        CANT_BE_REMOVED_FROM_GAME = 242, 

        /// <summary>
        /// The can t_ b e_ se t_ aside.
        /// </summary>
        CANT_BE_SET_ASIDE = 241, 

        /// <summary>
        /// The can t_ b e_ damaged.
        /// </summary>
        CANT_BE_DAMAGED = 240, 

        /// <summary>
        /// The can t_ b e_ healed.
        /// </summary>
        CANT_BE_HEALED = 239, 

        /// <summary>
        /// The can t_ b e_ summonin g_ sick.
        /// </summary>
        CANT_BE_SUMMONING_SICK = 253, 

        /// <summary>
        /// The can t_ b e_ dispelled.
        /// </summary>
        CANT_BE_DISPELLED = 314, 

        /// <summary>
        /// The incomin g_ damag e_ cap.
        /// </summary>
        INCOMING_DAMAGE_CAP = 238, 

        /// <summary>
        /// The incomin g_ damag e_ adjustment.
        /// </summary>
        INCOMING_DAMAGE_ADJUSTMENT = 237, 

        /// <summary>
        /// The incomin g_ damag e_ multiplier.
        /// </summary>
        INCOMING_DAMAGE_MULTIPLIER = 236, 

        /// <summary>
        /// The incomin g_ healin g_ cap.
        /// </summary>
        INCOMING_HEALING_CAP = 235, 

        /// <summary>
        /// The incomin g_ healin g_ adjustment.
        /// </summary>
        INCOMING_HEALING_ADJUSTMENT = 234, 

        /// <summary>
        /// The incomin g_ healin g_ multiplier.
        /// </summary>
        INCOMING_HEALING_MULTIPLIER = 233, 

        /// <summary>
        /// The frozen.
        /// </summary>
        FROZEN = 260, 

        /// <summary>
        /// The jus t_ played.
        /// </summary>
        JUST_PLAYED, 

        /// <summary>
        /// The linkedcard.
        /// </summary>
        LINKEDCARD, 

        /// <summary>
        /// The zon e_ position.
        /// </summary>
        ZONE_POSITION, 

        /// <summary>
        /// The can t_ b e_ frozen.
        /// </summary>
        CANT_BE_FROZEN, 

        /// <summary>
        /// The comb o_ active.
        /// </summary>
        COMBO_ACTIVE = 266, 

        /// <summary>
        /// The car d_ target.
        /// </summary>
        CARD_TARGET, 

        /// <summary>
        /// The nu m_ card s_ playe d_ thi s_ turn.
        /// </summary>
        NUM_CARDS_PLAYED_THIS_TURN = 269, 

        /// <summary>
        /// The can t_ b e_ targete d_ b y_ opponents.
        /// </summary>
        CANT_BE_TARGETED_BY_OPPONENTS, 

        /// <summary>
        /// The nu m_ turn s_ i n_ play.
        /// </summary>
        NUM_TURNS_IN_PLAY, 

        /// <summary>
        /// The summoned.
        /// </summary>
        SUMMONED = 205, 

        /// <summary>
        /// The enraged.
        /// </summary>
        ENRAGED = 212, 

        /// <summary>
        /// The silenced.
        /// </summary>
        SILENCED = 188, 

        /// <summary>
        /// The windfury.
        /// </summary>
        WINDFURY, 

        /// <summary>
        /// The loyalty.
        /// </summary>
        LOYALTY = 216, 

        /// <summary>
        /// The deathrattle.
        /// </summary>
        DEATHRATTLE, 

        /// <summary>
        /// The adjacen t_ buff.
        /// </summary>
        ADJACENT_BUFF = 350, 

        /// <summary>
        /// The stealth.
        /// </summary>
        STEALTH = 191, 

        /// <summary>
        /// The battlecry.
        /// </summary>
        BATTLECRY = 218, 

        /// <summary>
        /// The nu m_ turn s_ left.
        /// </summary>
        NUM_TURNS_LEFT = 272, 

        /// <summary>
        /// The outgoin g_ damag e_ cap.
        /// </summary>
        OUTGOING_DAMAGE_CAP, 

        /// <summary>
        /// The outgoin g_ damag e_ adjustment.
        /// </summary>
        OUTGOING_DAMAGE_ADJUSTMENT, 

        /// <summary>
        /// The outgoin g_ damag e_ multiplier.
        /// </summary>
        OUTGOING_DAMAGE_MULTIPLIER, 

        /// <summary>
        /// The outgoin g_ healin g_ cap.
        /// </summary>
        OUTGOING_HEALING_CAP, 

        /// <summary>
        /// The outgoin g_ healin g_ adjustment.
        /// </summary>
        OUTGOING_HEALING_ADJUSTMENT, 

        /// <summary>
        /// The outgoin g_ healin g_ multiplier.
        /// </summary>
        OUTGOING_HEALING_MULTIPLIER, 

        /// <summary>
        /// The incomin g_ abilit y_ damag e_ adjustment.
        /// </summary>
        INCOMING_ABILITY_DAMAGE_ADJUSTMENT, 

        /// <summary>
        /// The incomin g_ comba t_ damag e_ adjustment.
        /// </summary>
        INCOMING_COMBAT_DAMAGE_ADJUSTMENT, 

        /// <summary>
        /// The outgoin g_ abilit y_ damag e_ adjustment.
        /// </summary>
        OUTGOING_ABILITY_DAMAGE_ADJUSTMENT, 

        /// <summary>
        /// The outgoin g_ comba t_ damag e_ adjustment.
        /// </summary>
        OUTGOING_COMBAT_DAMAGE_ADJUSTMENT, 

        /// <summary>
        /// The outgoin g_ abilit y_ damag e_ multiplier.
        /// </summary>
        OUTGOING_ABILITY_DAMAGE_MULTIPLIER, 

        /// <summary>
        /// The outgoin g_ abilit y_ damag e_ cap.
        /// </summary>
        OUTGOING_ABILITY_DAMAGE_CAP, 

        /// <summary>
        /// The incomin g_ abilit y_ damag e_ multiplier.
        /// </summary>
        INCOMING_ABILITY_DAMAGE_MULTIPLIER, 

        /// <summary>
        /// The incomin g_ abilit y_ damag e_ cap.
        /// </summary>
        INCOMING_ABILITY_DAMAGE_CAP, 

        /// <summary>
        /// The outgoin g_ comba t_ damag e_ multiplier.
        /// </summary>
        OUTGOING_COMBAT_DAMAGE_MULTIPLIER, 

        /// <summary>
        /// The outgoin g_ comba t_ damag e_ cap.
        /// </summary>
        OUTGOING_COMBAT_DAMAGE_CAP, 

        /// <summary>
        /// The incomin g_ comba t_ damag e_ multiplier.
        /// </summary>
        INCOMING_COMBAT_DAMAGE_MULTIPLIER, 

        /// <summary>
        /// The incomin g_ comba t_ damag e_ cap.
        /// </summary>
        INCOMING_COMBAT_DAMAGE_CAP, 

        /// <summary>
        /// The i s_ morphed.
        /// </summary>
        IS_MORPHED = 294, 

        /// <summary>
        /// The tem p_ resources.
        /// </summary>
        TEMP_RESOURCES, 

        /// <summary>
        /// The recal l_ owed.
        /// </summary>
        RECALL_OWED, 

        /// <summary>
        /// The nu m_ attack s_ thi s_ turn.
        /// </summary>
        NUM_ATTACKS_THIS_TURN, 

        /// <summary>
        /// The nex t_ all y_ buff.
        /// </summary>
        NEXT_ALLY_BUFF = 302, 

        /// <summary>
        /// The magnet.
        /// </summary>
        MAGNET, 

        /// <summary>
        /// The firs t_ car d_ playe d_ thi s_ turn.
        /// </summary>
        FIRST_CARD_PLAYED_THIS_TURN, 

        /// <summary>
        /// The car d_ id.
        /// </summary>
        CARD_ID = 186, 

        /// <summary>
        /// The can t_ b e_ targete d_ b y_ abilities.
        /// </summary>
        CANT_BE_TARGETED_BY_ABILITIES = 311, 

        /// <summary>
        /// The shouldexitcombat.
        /// </summary>
        SHOULDEXITCOMBAT, 

        /// <summary>
        /// The paren t_ card.
        /// </summary>
        PARENT_CARD = 316, 

        /// <summary>
        /// The nu m_ minion s_ playe d_ thi s_ turn.
        /// </summary>
        NUM_MINIONS_PLAYED_THIS_TURN, 

        /// <summary>
        /// The can t_ b e_ targete d_ b y_ her o_ powers.
        /// </summary>
        CANT_BE_TARGETED_BY_HERO_POWERS = 332, 

        /// <summary>
        /// The combo.
        /// </summary>
        COMBO = 220, 

        /// <summary>
        /// The elite.
        /// </summary>
        ELITE = 114, 

        /// <summary>
        /// The car d_ set.
        /// </summary>
        CARD_SET = 183, 

        /// <summary>
        /// The faction.
        /// </summary>
        FACTION = 201, 

        /// <summary>
        /// The rarity.
        /// </summary>
        RARITY = 203, 

        /// <summary>
        /// The class.
        /// </summary>
        CLASS = 199, 

        /// <summary>
        /// The missio n_ event.
        /// </summary>
        MISSION_EVENT = 6, 

        /// <summary>
        /// The freeze.
        /// </summary>
        FREEZE = 208, 

        /// <summary>
        /// The recall.
        /// </summary>
        RECALL = 215, 

        /// <summary>
        /// The silence.
        /// </summary>
        SILENCE = 339, 

        /// <summary>
        /// The counter.
        /// </summary>
        COUNTER, 

        /// <summary>
        /// The artistname.
        /// </summary>
        ARTISTNAME = 342, 

        /// <summary>
        /// The flavortext.
        /// </summary>
        FLAVORTEXT = 351, 

        /// <summary>
        /// The force d_ play.
        /// </summary>
        FORCED_PLAY, 

        /// <summary>
        /// The lo w_ healt h_ threshold.
        /// </summary>
        LOW_HEALTH_THRESHOLD, 

        /// <summary>
        /// The spellpowe r_ double.
        /// </summary>
        SPELLPOWER_DOUBLE = 356, 

        /// <summary>
        /// The healin g_ double.
        /// </summary>
        HEALING_DOUBLE, 

        /// <summary>
        /// The nu m_ option s_ playe d_ thi s_ turn.
        /// </summary>
        NUM_OPTIONS_PLAYED_THIS_TURN, 

        /// <summary>
        /// The nu m_ options.
        /// </summary>
        NUM_OPTIONS, 

        /// <summary>
        /// The t o_ b e_ destroyed.
        /// </summary>
        TO_BE_DESTROYED, 

        /// <summary>
        /// The healt h_ minimum.
        /// </summary>
        HEALTH_MINIMUM = 337, 

        /// <summary>
        /// The aura.
        /// </summary>
        AURA = 362, 

        /// <summary>
        /// The poisonous.
        /// </summary>
        POISONOUS, 

        /// <summary>
        /// The ho w_ t o_ earn.
        /// </summary>
        HOW_TO_EARN, 

        /// <summary>
        /// The ho w_ t o_ ear n_ golden.
        /// </summary>
        HOW_TO_EARN_GOLDEN, 

        /// <summary>
        /// The ta g_ her o_ powe r_ double.
        /// </summary>
        TAG_HERO_POWER_DOUBLE, 

        /// <summary>
        /// The ta g_ a i_ mus t_ play.
        /// </summary>
        TAG_AI_MUST_PLAY, 

        /// <summary>
        /// The nu m_ minion s_ playe r_ kille d_ thi s_ turn.
        /// </summary>
        NUM_MINIONS_PLAYER_KILLED_THIS_TURN, 

        /// <summary>
        /// The nu m_ minion s_ kille d_ thi s_ turn.
        /// </summary>
        NUM_MINIONS_KILLED_THIS_TURN, 

        /// <summary>
        /// The affecte d_ b y_ spel l_ power.
        /// </summary>
        AFFECTED_BY_SPELL_POWER, 

        /// <summary>
        /// The extr a_ deathrattles.
        /// </summary>
        EXTRA_DEATHRATTLES, 

        /// <summary>
        /// The star t_ wit h_1_ health.
        /// </summary>
        START_WITH_1_HEALTH, 

        /// <summary>
        /// The immun e_ whil e_ attacking.
        /// </summary>
        IMMUNE_WHILE_ATTACKING, 

        /// <summary>
        /// The multipl y_ her o_ damage.
        /// </summary>
        MULTIPLY_HERO_DAMAGE, 

        /// <summary>
        /// The multipl y_ buf f_ value.
        /// </summary>
        MULTIPLY_BUFF_VALUE, 

        /// <summary>
        /// The custo m_ keywor d_ effect.
        /// </summary>
        CUSTOM_KEYWORD_EFFECT, 

        /// <summary>
        /// The topdeck.
        /// </summary>
        TOPDECK
    }

    /// <summary>
    /// The ta g_ zone.
    /// </summary>
    public enum TAG_ZONE
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The play.
        /// </summary>
        PLAY, 

        /// <summary>
        /// The deck.
        /// </summary>
        DECK, 

        /// <summary>
        /// The hand.
        /// </summary>
        HAND, 

        /// <summary>
        /// The graveyard.
        /// </summary>
        GRAVEYARD, 

        /// <summary>
        /// The removedfromgame.
        /// </summary>
        REMOVEDFROMGAME, 

        /// <summary>
        /// The setaside.
        /// </summary>
        SETASIDE, 

        /// <summary>
        /// The secret.
        /// </summary>
        SECRET
    }

    /// <summary>
    /// The ta g_ mulligan.
    /// </summary>
    public enum TAG_MULLIGAN
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The input.
        /// </summary>
        INPUT, 

        /// <summary>
        /// The dealing.
        /// </summary>
        DEALING, 

        /// <summary>
        /// The waiting.
        /// </summary>
        WAITING, 

        /// <summary>
        /// The done.
        /// </summary>
        DONE
    }

    /// <summary>
    /// The ta g_ class.
    /// </summary>
    public enum TAG_CLASS
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The deathknight.
        /// </summary>
        DEATHKNIGHT, 

        /// <summary>
        /// The druid.
        /// </summary>
        DRUID, 

        /// <summary>
        /// The hunter.
        /// </summary>
        HUNTER, 

        /// <summary>
        /// The mage.
        /// </summary>
        MAGE, 

        /// <summary>
        /// The paladin.
        /// </summary>
        PALADIN, 

        /// <summary>
        /// The priest.
        /// </summary>
        PRIEST, 

        /// <summary>
        /// The rogue.
        /// </summary>
        ROGUE, 

        /// <summary>
        /// The shaman.
        /// </summary>
        SHAMAN, 

        /// <summary>
        /// The warlock.
        /// </summary>
        WARLOCK, 

        /// <summary>
        /// The warrior.
        /// </summary>
        WARRIOR, 

        /// <summary>
        /// The dream.
        /// </summary>
        DREAM

    }

    /// <summary>
    /// The ta g_ cardtype.
    /// </summary>
    public enum TAG_CARDTYPE
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The game.
        /// </summary>
        GAME, 

        /// <summary>
        /// The player.
        /// </summary>
        PLAYER, 

        /// <summary>
        /// The hero.
        /// </summary>
        HERO, 

        /// <summary>
        /// The minion.
        /// </summary>
        MINION, 

        /// <summary>
        /// The ability.
        /// </summary>
        ABILITY, 

        /// <summary>
        /// The enchantment.
        /// </summary>
        ENCHANTMENT, 

        /// <summary>
        /// The weapon.
        /// </summary>
        WEAPON, 

        /// <summary>
        /// The item.
        /// </summary>
        ITEM, 

        /// <summary>
        /// The token.
        /// </summary>
        TOKEN, 

        /// <summary>
        /// The her o_ power.
        /// </summary>
        HERO_POWER
    }

    /// <summary>
    /// The attack type.
    /// </summary>
    public enum AttackType
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The regular.
        /// </summary>
        REGULAR, 

        /// <summary>
        /// The proposed.
        /// </summary>
        PROPOSED, 

        /// <summary>
        /// The canceled.
        /// </summary>
        CANCELED, 

        /// <summary>
        /// The onl y_ attacker.
        /// </summary>
        ONLY_ATTACKER, 

        /// <summary>
        /// The onl y_ defender.
        /// </summary>
        ONLY_DEFENDER, 

        /// <summary>
        /// The onl y_ propose d_ attacker.
        /// </summary>
        ONLY_PROPOSED_ATTACKER, 

        /// <summary>
        /// The onl y_ propose d_ defender.
        /// </summary>
        ONLY_PROPOSED_DEFENDER, 

        /// <summary>
        /// The waitin g_ o n_ propose d_ attacker.
        /// </summary>
        WAITING_ON_PROPOSED_ATTACKER, 

        /// <summary>
        /// The waitin g_ o n_ propose d_ defender.
        /// </summary>
        WAITING_ON_PROPOSED_DEFENDER, 

        /// <summary>
        /// The waitin g_ o n_ attacker.
        /// </summary>
        WAITING_ON_ATTACKER, 

        /// <summary>
        /// The waitin g_ o n_ defender.
        /// </summary>
        WAITING_ON_DEFENDER
    }

    /// <summary>
    /// The ta g_ playstate.
    /// </summary>
    public enum TAG_PLAYSTATE
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The playing.
        /// </summary>
        PLAYING, 

        /// <summary>
        /// The winning.
        /// </summary>
        WINNING, 

        /// <summary>
        /// The losing.
        /// </summary>
        LOSING, 

        /// <summary>
        /// The won.
        /// </summary>
        WON, 

        /// <summary>
        /// The lost.
        /// </summary>
        LOST, 

        /// <summary>
        /// The tied.
        /// </summary>
        TIED, 

        /// <summary>
        /// The disconnected.
        /// </summary>
        DISCONNECTED, 

        /// <summary>
        /// The quit.
        /// </summary>
        QUIT
    }

    /// <summary>
    /// The ta g_ race.
    /// </summary>
    public enum TAG_RACE
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
    /// The ta g_ state.
    /// </summary>
    public enum TAG_STATE
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The loading.
        /// </summary>
        LOADING, 

        /// <summary>
        /// The running.
        /// </summary>
        RUNNING, 

        /// <summary>
        /// The complete.
        /// </summary>
        COMPLETE
    }

    /// <summary>
    /// The ta g_ step.
    /// </summary>
    public enum TAG_STEP
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The begi n_ first.
        /// </summary>
        BEGIN_FIRST, 

        /// <summary>
        /// The begi n_ shuffle.
        /// </summary>
        BEGIN_SHUFFLE, 

        /// <summary>
        /// The begi n_ draw.
        /// </summary>
        BEGIN_DRAW, 

        /// <summary>
        /// The begi n_ mulligan.
        /// </summary>
        BEGIN_MULLIGAN, 

        /// <summary>
        /// The mai n_ begin.
        /// </summary>
        MAIN_BEGIN, 

        /// <summary>
        /// The mai n_ ready.
        /// </summary>
        MAIN_READY, 

        /// <summary>
        /// The mai n_ resource.
        /// </summary>
        MAIN_RESOURCE, 

        /// <summary>
        /// The mai n_ draw.
        /// </summary>
        MAIN_DRAW, 

        /// <summary>
        /// The mai n_ start.
        /// </summary>
        MAIN_START, 

        /// <summary>
        /// The mai n_ action.
        /// </summary>
        MAIN_ACTION, 

        /// <summary>
        /// The mai n_ combat.
        /// </summary>
        MAIN_COMBAT, 

        /// <summary>
        /// The mai n_ end.
        /// </summary>
        MAIN_END, 

        /// <summary>
        /// The mai n_ next.
        /// </summary>
        MAIN_NEXT, 

        /// <summary>
        /// The fina l_ wrapup.
        /// </summary>
        FINAL_WRAPUP, 

        /// <summary>
        /// The fina l_ gameover.
        /// </summary>
        FINAL_GAMEOVER, 

        /// <summary>
        /// The mai n_ cleanup.
        /// </summary>
        MAIN_CLEANUP, 

        /// <summary>
        /// The mai n_ star t_ triggers.
        /// </summary>
        MAIN_START_TRIGGERS
    }

    /// <summary>
    /// The choic e_ type.
    /// </summary>
    public enum CHOICE_TYPE
    {
        /// <summary>
        /// The invalid.
        /// </summary>
        INVALID, 

        /// <summary>
        /// The mulligan.
        /// </summary>
        MULLIGAN, 

        /// <summary>
        /// The general.
        /// </summary>
        GENERAL
    }
}
