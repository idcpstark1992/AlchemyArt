namespace Controllers
{
    public static class BetUtils
    {
        public static int   CurrentBetAmount    { get; private set; }
        public static bool  IsPlayerActorWinner { get; private set; }
        public static int   PlayerSoulsAmount   { get; private set; }
        public static void  SetPlayerSoulsAmount( int _amount ) => PlayerSoulsAmount = _amount;
        public static void  SetBetAmount(int amount)
        {
            CurrentBetAmount = amount;
        }
        public static void  DeleteBetAmount()
        {
            CurrentBetAmount = 0;
        }
        public static void  SetActorWinner(bool _actor)
        {
            IsPlayerActorWinner = _actor;   
        }

    }
}

