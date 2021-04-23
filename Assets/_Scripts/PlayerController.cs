using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        public CrosshairScript CrosshairComponent => CrosshairScript;
        [SerializeField] private CrosshairScript CrosshairScript;

        public bool IsJumping;
        public bool IsCollecting;
        public bool GameDone;
    }
}
