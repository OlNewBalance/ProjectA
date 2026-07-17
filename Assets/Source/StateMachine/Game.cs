
namespace Source.StateMachine
{
    public class Game: IState
    {
        private Bootstrap _bs;
        
        public Game(Bootstrap bs)
        {
            _bs = bs;
        }
        
        public void Enter()
        {
             _bs.LoadScene(GameScene.Earth, () =>
             {
                 _bs.StartGame();
             });
        }

        public void Exit()
        {
            _bs.CleanupFromGame();
        }
    }
}