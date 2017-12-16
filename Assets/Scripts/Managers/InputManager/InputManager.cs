using UnityEngine;

namespace Managers.InputManager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private Player[] _players;

        public void Awake()
        {
            foreach (var player in _players)
            {
                player.InitializePlayer();
            }
        }

        public Player GetPlayer(int id)
        {
            return _players[id];
        }

        private void Update()
        {
            foreach (var player in _players)
            {
                player.Update();
            }
        }
    }

}