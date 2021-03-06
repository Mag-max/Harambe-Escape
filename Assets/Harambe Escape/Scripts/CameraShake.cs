using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float jumpIter = 4.5f;

    public void Shake()
    {
        float height = Mathf.PerlinNoise(jumpIter, 0f) * 5;
        height = height * height * 0.2f;

        float shakeAmount = height; // degress to shake camera
        float shakePeriodTime = 0.25f; //period of each shake
        float dropOffTime = 1.25f; // how long it takes the shaking to stop


        // camera uses easeShake por LeanTween, shaking until it gets to 0 and stop
        LTDescr shakeTween = LeanTween.rotateAroundLocal(gameObject, Vector3.right, shakeAmount, shakePeriodTime).setEase(LeanTweenType.easeShake).setLoopClamp().setRepeat(-1);
        
        LeanTween.value(gameObject, shakeAmount, 0, dropOffTime).setOnUpdate((float val) => { shakeTween.setTo(Vector3.right * val); }).setEase(LeanTweenType.easeOutQuad);
    }
}
