using CodeBase.Services.ClickProvider;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Gameplay.Components
{
    public class ClickElementComponent : MonoBehaviour
    {
        [SerializeField] private Button _clickButton;

        private IClickProvider _clickProvider;
        
        [Inject]
        private void Construct(IClickProvider clickProvider)
        {
            _clickProvider = clickProvider;
        }

        private void OnEnable()
        {
            _clickButton.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _clickButton.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _clickProvider.OnClick();
        }
    }
}