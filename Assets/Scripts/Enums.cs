namespace Commons
{
    public enum E_ListenerID : byte
    {
        CARD_SPAWN      = 0,
        ON_RESTARTED    = 4,
        ON_STAND = 5,
        ON_BLOW =6,
        ON_PLAYER_WIN = 7,
        ON_GAME_PHASE = 8,
        ON_ADDED_POINTS = 9,
        ON_GAME_STARTED =10,
        ON_SPECIAL_PLAY=13,
        ON_FINISHED_CARD_TWEEN = 18,
        ON_STATE_MACHINE = 19,
        ON_RESTART_POINTS_MODEL
    }
 
    public enum E_SpecialCombination : byte
    {
        RELANCINA,
        PATITOS,
        NONE
    }

    public enum E_Actors : byte
    {
        PLAYER = 0,
        AI =1
    }

    public enum E_GamePhase :byte
    {
        GAME_IDLE, 
        GAME_BET,
        GAME_INITIAL_DRAW,
        GAME_SPECIAL_CARDS_CHECK,
        GAME_ACTOR_GAME_PLAY,
        GAME_ACTOR_POINTS_COMPRASION,
        GAME_REWARD,
        GAME_BUY,
        GAME_PLAYER_PLAY_CARDS,
        GAME_ACTOR_SWITCH,
        GAME_ACTOR_POINTS_CHECK_MANUAL,
        GAME_RESTARTED,
    }
}
