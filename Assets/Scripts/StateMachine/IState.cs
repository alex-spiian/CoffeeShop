public interface IState
{
    
    void Initialize(StateMachine stateMachine);
    public void OnEnter();
}