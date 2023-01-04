using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.UI
{
    public class UIService : ServiceBase
    {
        [SerializeField] private List<UIWindow> _windows;
        private UIWindow _currentWindow;

        public void ChangeWindow(UIWindow windowToOpen)
        {
            if (windowToOpen == _currentWindow)
                return;

            _currentWindow?.Close();
            _currentWindow = windowToOpen;
            _currentWindow.Open();
        }

        public void ChangeWindow<T>() where T : UIWindow
        {
            var windowToOpen = GetWindow<T>();

            if (windowToOpen == _currentWindow)
                return;

            _currentWindow?.Close();
            _currentWindow = windowToOpen;
            _currentWindow.Open();
        }


        public T GetWindow<T>() where T : UIWindow =>
            _windows.OfType<T>().FirstOrDefault();

        public List<T> GetWindows<T>() where T : UIWindow =>
            _windows.OfType<T>().ToList();
    }
}