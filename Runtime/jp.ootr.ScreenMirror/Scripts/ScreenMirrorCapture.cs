using UdonSharp;
using UnityEngine;

namespace jp.ootr.ScreenMirror
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class ScreenMirrorCapture : UdonSharpBehaviour
    {
        [SerializeField] internal Camera targetCamera;
        [SerializeField] internal int width = 1280;
        [SerializeField] internal int height = 720;

        private void OnEnable()
        {
            if (targetCamera == null) return;
            targetCamera.targetTexture = new RenderTexture(width, height, 24);
            targetCamera.enabled = true;
        }
    }
}
