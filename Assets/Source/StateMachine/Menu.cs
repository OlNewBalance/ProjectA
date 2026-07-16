
namespace Source.StateMachine
{
    public class MenuState: IState
    {
        private Bootstrap _bs;
        public MenuState(Bootstrap bs)
        {
            _bs = bs;
        }
        
        public void Enter()
        {
            _bs.LoadScene("Menu", (() => {}));
        }

        public void Exit()
        {
        }
    }
}