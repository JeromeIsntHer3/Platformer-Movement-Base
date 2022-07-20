using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)] public float blend;
    [Range(0, 10)] public float horizontalBoundary;
    [Range(0, 10)] public float topBoundary;
    [Range(0, 10)] public float bottomBoundary;

    private Vector3 targetPos;
    private Vector3 finalPos;

    void Update()
    {
        if (target != null)
        {
            //float leftPoint = transform.position.x - leftBoundary;
            //float rightPoint = transform.position.x + rightBoundary;
            //float topPoint = target.position.y + topBoundary;
            //float bottomPoint = target.position.y - bottomBoundary;

            //bool camBehind = target.position.x > leftPoint;
            //bool camAhead = target.position.x < rightPoint;

            //if (!camBehind)
            //{
            //    targetPos = new Vector3(target.position.x, transform.position.y, -10) + offset;
            //    transform.position = Vector3.Slerp(transform.position, targetPos, blend * Time.deltaTime);
            //}
            //else if (!camAhead)
            //{

            //}



            float leftPoint = transform.position.x - horizontalBoundary;
            float rightPoint = transform.position.x + horizontalBoundary;

            bool camBehind = target.position.x < leftPoint;
            bool camInFront = target.position.x > rightPoint;

            if (!camBehind && !camInFront)
            {
                
            }
            else
            {
                targetPos = new Vector3(target.position.x, transform.position.y, -10) + offset;
                transform.position = Vector3.Lerp(transform.position, targetPos, blend * Time.deltaTime);
            }
        }
    }
}