using System;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

namespace CodeBase.UI.Extensions
{
    // implemented by following this guide: https://www.youtube.com/watch?v=U6h6p1tJ7XM
    public struct ButtonAwaiter : INotifyCompletion
    {
        private readonly Button _button;
        private Action _storedContinuation;

        public ButtonAwaiter(Button button)
        {
            _button = button;
            _storedContinuation = null;
        }

        public bool IsCompleted => false;

        public Button GetResult() => _button;
        
        public void OnCompleted(Action continuation)
        {
            _storedContinuation = continuation;
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _storedContinuation.Invoke();
            _button.onClick.RemoveListener(OnClick);
            _storedContinuation = null;
        }
    }
}