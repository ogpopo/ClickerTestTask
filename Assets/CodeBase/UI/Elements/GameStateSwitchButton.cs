using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class GameStateSwitchButton : MonoBehaviour
    {
        public enum TargetStates
        {
            None = 0,
            Loading = 1,
            Gameplay = 2
        }
        
        [SerializeField] private TargetStates targetState = 0;
        [SerializeField] private Button button;

        private GameStateMachine _gameStateMachine;
        private ILogService _log;

        [Inject]
        void Construct(GameStateMachine gameStateMachine, ILogService log)
        {
            _gameStateMachine = gameStateMachine;
            _log = log;
        }

        private void OnEnable() => 
            button.onClick.AddListener(OnClick);

        private void OnDisable() => 
            button.onClick.RemoveListener(OnClick);

        private void OnClick()
        {
            switch (targetState)
            {
                case TargetStates.Gameplay: _gameStateMachine.Enter<GameplayState>(); break;
                default: _log.LogError("Not valid option"); break;
            }
        }
    }
}