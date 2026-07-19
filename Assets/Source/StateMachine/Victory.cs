namespace Source.StateMachine
{
    public class Victory: IState
    {
        private Bootstrap _bs;

        public Victory(Bootstrap bs)
        {
            _bs = bs;
        }
        
        public void Enter()
        {
            _bs.CleanupFromGame();
            _bs.LoadScene("Victory", () =>
            {
                _bs.StartVictory();
            });
        }

        public void Exit()
        {
            
        }
    }
}