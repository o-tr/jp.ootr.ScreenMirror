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
        [SerializeField] internal CustomScaler.CustomScaler customScaler;
        private float _defaultCameraSize;

        private void OnEnable()
        {
            if (targetCamera == null) return;
            targetCamera.targetTexture = new RenderTexture(width, height, 24);
            targetCamera.enabled = true;
            _defaultCameraSize = targetCamera.orthographicSize;
            UpdateCameraSize();
            if (customScaler == null) return;
            customScaler.AddEventListener(this);
        }

        public void OnScaleChanged()
        {
            UpdateCameraSize();
        }
        
        private void UpdateCameraSize()
        {
            targetCamera.orthographicSize = _defaultCameraSize * targetCamera.transform.lossyScale.x;
        }
    }
}
