using CodeBase.Gameplay.States;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CodeBase.Gameplay
{
    public class GameplaySceneBootstraper: IInitializable
    {
        private readonly SceneStateMachine _sceneStateMachine;
        private readonly StatesFactory _statesFactory;
        private readonly ILogService _logService;
        
        public GameplaySceneBootstraper(SceneStateMachine sceneStateMachine, StatesFactory statesFactory, ILogService logService)
        {
            _sceneStateMachine = sceneStateMachine;
            _statesFactory = statesFactory;
            _logService = logService;
        }
        
        public void Initialize()
        {
            _logService.Log("Start game mode scene bootstrapping");
            
            _sceneStateMachine.RegisterState(_statesFactory.Create<StartGameplayState>());
            _sceneStateMachine.RegisterState(_statesFactory.Create<PlayGameplayState>());
            
            _logService.Log("Finish game mode scene bootstrapping");
            
            _sceneStateMachine.Enter<StartGameplayState>().Forget();
        }
    }
}