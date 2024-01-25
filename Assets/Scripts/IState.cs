public interface IState
{
    // Start is called before the first frame update
    void Enter();
    void Exit();
    void LogicUpdate();
    void PhysicUpdate();
}
