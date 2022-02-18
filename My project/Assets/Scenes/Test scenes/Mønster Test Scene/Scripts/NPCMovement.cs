using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public float Speed = 1.0f;

    public Queue<Vector2> mWayPoints = new Queue<Vector2>();

    PathFinder<Vector2Int> mPathFinder = new AStarPathFinder<Vector2Int>();
     
    void start()
    {
        mPathFinder.onSuccess = OnSuccessPathFinding;
        mPathFinder.onFailure = OnFaliurePathFinding;
        mPathFinder.HeuristicCost = RectGrid_viz.GetManhattanCost;
        mPathFinder.NodeTraversalCost = RectGrid_viz.GetEuclideanCost;
        StartCoroutine(Coroutine_MoveTo());
    }

    public void AddWayPoint(Vector2 pt)

    {
        mWayPoints.Enqueue(pt);

    }
    public void SetDesination(
        RectGrid_viz map,
        RectGridCell desination)
    {
        AddWayPoint(desination.Value);
    }

    public IEnumerator Coroutine_MoveTo()
    {
        while (true)
        {
            while (mWayPoints.Count > 0)
            {
                yield return StartCoroutine(
                    Coroutine_MoveToPoint(mWayPoints.Dequeue(), Speed));

            }
            yield return null;
        }
    }
    private IEnumerator Coroutine_MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();

        }
        objectToMove.transform.position = end;

    }

    IEnumerator Coroutine_MoveToPoint(Vector2 p, float speed)

    {
        Vector3 endP = new Vector3(p.x, p.y, transform.z);
        float duration = (transform.position - endP).magnitude / speed;
        yield return StartCoroutine(
            Coroutine_MoveOverSeconds(
                transform.gameObject, endP, duration));
    }


    public void SetDestination(
        RectGrid_viz map,
        RectGridCell destination)
    {
        if (mPathFinder.Status == PathFinderStatus.RUNNING)
        {
            Debug.Log( "PathFinder køre allerede. kan ikke sætte distination lige nu");
            return;
        }

        mWayPoints.Clear();

        RectGridCell start = map.GetRectGridCell(
            (int)transform.position.x,
            (int)transform.position.y);
        if (start == null) return;
        mPathFinder.Initialize(start, destination);
        StartCoroutine(Coroutine_FindPathSteps());
    }

    IEnumerator Coroutine_FindPathSteps()
    {
        while (mPathFinder.Status == PathFinderStatus.RUNNING)
        {
            mPathFinder.step();
            yield return null;
        }
    }

    void OnSuccessPathFinding()
    {
        PathFinder<Vector2Int>.PathFinderNode node = mPathFinder.CurrentNode;
        List<Vector2Int> reverse_indices = new List<Vector2Int>();
        while (node != null)
        {
            reverse_indices.Add(node.Location.Value);
            node = node.Parent;
        }

        for (int i = reverse_indices.Count - 1; i >= 0; i--)
        {
            AddWayPoint(new Vector2(reverse_indices[i].x, reverse_indices[i].y));
        }
    }

    void OnFaliurePathFinding()
    {
        Debug.Log("Kan ikke finde Path");
    }
}
