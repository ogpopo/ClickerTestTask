using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public interface IStateMachine
    {
        UniTask Enter<TState>() where TState : class, IState;
        void RegisterState<TState>(TState state) where TState : IExitableState;
    }
}