using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)] public float blend;
    [Range(0, 10)] public float leftBoundary;
    [Range(0, 10)] public float rightBoundary;
    [Range(0, 10)] public float topBoundary;
    [Range(0, 10)] public float bottomBoundary;

    private Vector3 targetPos;
    private Vector3 finalPos;

    void Update()
    {
        if (target != null)
        {
            float leftDist = transform.position.x - leftBoundary;
            float rightDist = transform.position.x + rightBoundary;
            float topDist = target.position.y + topBoundary;
            float bottomDist = target.position.y - bottomBoundary;

            bool withinRange = target.position.x > leftDist && target.position.x < rightDist;

            if (!withinRange)
            {
                targetPos = new Vector3(target.position.x, transform.position.y, -10) + offset;
                transform.position = Vector3.Slerp(transform.position, targetPos, blend * Time.deltaTime);
                //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -leftDist, rightDist),
                //    Mathf.Clamp(transform.position.y, topDist, -bottomDist), transform.position.z);
            }
            else
            {
                
            }
        }
    }
}