using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]public float blend;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10f) + offset;
            transform.position = Vector3.Slerp(transform.position, targetPos, blend * Time.deltaTime);
        }
    }
}