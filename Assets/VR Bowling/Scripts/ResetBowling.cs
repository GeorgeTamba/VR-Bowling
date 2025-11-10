using UnityEngine;

public class ResetBowling : MonoBehaviour
{
    [Header("References")]
    public Transform ball;
    public Transform pinsParent;

    private Vector3 ballStartPos;
    private Quaternion ballStartRot;
    private Vector3[] pinsStartPos;
    private Quaternion[] pinsStartRot;
    private Rigidbody ballRb;
    private Rigidbody[] pinsRb;

    void Start()
    {
        if (ball != null)
        {
            ballStartPos = ball.position;
            ballStartRot = ball.rotation;
            ballRb = ball.GetComponent<Rigidbody>();
        }

        if (pinsParent != null)
        {
            int count = pinsParent.childCount;
            pinsStartPos = new Vector3[count];
            pinsStartRot = new Quaternion[count];
            pinsRb = new Rigidbody[count];

            for (int i = 0; i < count; i++)
            {
                var pin = pinsParent.GetChild(i);
                pinsStartPos[i] = pin.position;
                pinsStartRot[i] = pin.rotation;
                pinsRb[i] = pin.GetComponent<Rigidbody>();
            }
        }
    }

    public void ResetAll()
    {
        // Reset Ball
        if (ballRb != null)
        {
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            ball.position = ballStartPos;
            ball.rotation = ballStartRot;
        }

        // Reset Pins
        if (pinsParent != null)
        {
            for (int i = 0; i < pinsParent.childCount; i++)
            {
                var pin = pinsParent.GetChild(i);
                pinsRb[i].linearVelocity = Vector3.zero;
                pinsRb[i].angularVelocity = Vector3.zero;
                pin.position = pinsStartPos[i];
                pin.rotation = pinsStartRot[i];
            }
        }
    }
}
