using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace jp.ootr.ScreenMirror
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class ScreenMirrorScreen : UdonSharpBehaviour
    {
        [SerializeField] internal ScreenMirrorCapture targetCapture;
        [SerializeField] internal RawImage rawImage;
        [SerializeField] internal AspectRatioFitter aspectRatioFitter;

        public void OnEnable()
        {
            if (targetCapture == null) return;
            if (aspectRatioFitter == null) return;
            SendCustomEventDelayedFrames(nameof(Setup),1);
        }
        
        public void Setup()
        {
            if (targetCapture == null) return;
            if (aspectRatioFitter == null) return;
            aspectRatioFitter.aspectRatio = (float)targetCapture.width / targetCapture.height;
            rawImage.texture = targetCapture.targetCamera.targetTexture;
        }
    }
}
