using System;
using Sirenix.OdinInspector;

namespace Services.UI
{
    public abstract class UIWindow : SerializedMonoBehaviour, IUIObject
    {
        public event Action<IUIObject> PanelOpen;
        public event Action<IUIObject> PanelClose;

        public abstract void Initialize();

        public virtual void Open()
        {
            PanelOpen?.Invoke(this);
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            PanelClose?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}