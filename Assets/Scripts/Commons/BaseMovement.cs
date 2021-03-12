using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [Tooltip("Delay time after reach each point")]
    [SerializeField] float delay = 0f;

    // move (slerp) on a path with multi target points
    protected IEnumerator FollowPath(List<Transform> path, Action callback = null)
    {
        foreach (Transform point in path)
        {
            // wait until reach next point
            yield return StartCoroutine(MoveTowards(point));
            // delay time after reach each point
            yield return new WaitForSeconds(delay);
        }

        if (callback != null) callback();
    }


    // move (slerp) to a single target point
    protected IEnumerator MoveTowards(Transform point)
    {
        while (transform.position != point.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

            // wait until next frame
            yield return null;
        }
    }
}
