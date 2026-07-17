namespace Source.StateMachine
{
    public class GameOver: IState
    {
        private Bootstrap _bs;

        public GameOver(Bootstrap bs)
        {
            _bs = bs;
        }
        
        public void Enter()
        {
            _bs.CleanupFromGame();
            _bs.LoadScene("GameOver", () =>
            {
                _bs.StartGameOver();
            });
        }

        public void Exit()
        {
            
        }
    }
}