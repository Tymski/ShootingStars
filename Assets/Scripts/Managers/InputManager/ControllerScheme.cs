using UnityEngine;
using GamepadInput;

namespace Managers.InputManager
{
    [CreateAssetMenu(menuName = "Klagenfurt/Controller Scheme")]
    public class ControllerScheme : ScriptableObject
    {
        public bool IsGamepad;
        public bool IsRightPlayer;
        public GamePad.Index ControllerIndex;

        public string AxisX;
        public string AxisY;
        public KeyCode ButtonA;
        public KeyCode ButtonB;
        public KeyCode ButtonX;
        public KeyCode ButtonY;
    }
}
