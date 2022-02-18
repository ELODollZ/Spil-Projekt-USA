using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RectGrid_viz : MonoBehaviour
{
    //sætter max nummer af rækker i gridet
    public int mX;
    public int mY;
    [SerializeField]
    GameObject RectGridCell_Prefab;

    GameObject[,] mRectGridCellGameObjects;

    protected Vector2Int[,] mIndices;

    //added later on in the process.
    protected RectGridCell[,] mRectGridCells;

    public Color COLOR_WALKABLE = new Color(42 / 255.0f, 99 / 255.0f, 164 / 255.0f, 1.0f);
    public Color COLOR_NON_WALKABLE = new Color(0.0f, 0.0f, 0.0f, 1.0f);

    public Transform mDestination;
    public NPCMovement mNPCMovement;



    protected void Construct(int numX, int numY)
    {
        mX = numX;
        mY = numY;

        mIndices = new Vector2Int[mX, mY];

        mRectGridCellGameObjects = new GameObject[mX, mY];


        for (int i = 0; i < mX; ++i)

        {
            for (int j = 0; j < mY; ++j)
            {
                mIndices[i, j] = new Vector2Int(i, j);
                mRectGridCellGameObjects[i, j] = Instantiate(
                    RectGridCell_Prefab,
                    new Vector3(i, j, 0.0f),
                    Quaternion.identity);

                mRectGridCellGameObjects[i, j].transform.SetParent(transform);

                mRectGridCellGameObjects[i, j].name = "cell_" + i + "_" + j;

                //added second round
                mRectGridCells[i, j] = new RectGridCell(this, mIndices[i, j]);

                RectGridCell_Viz rectGridCell_Viz =
                    mRectGridCellGameObjects[i, j].GetComponent<RectGridCell_Viz>();

                if (rectGridCell_Viz != null)
                {
                    rectGridCell_Viz.RectGridCell = mRectGridCells[i, j];
                }
            }
        }

    }
    void ResetCamera()
    {
        Camera.main.orthographicSize = mY / 2.0f + 1.0f;
        Camera.main.transform.position = new Vector3(mX / 2.0f - 0.5f, mY / 2.0f - 0.5f, -100.0f);

    }
    public void Start()
    {
        Construct(mX, mY);

        ResetCamera();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCastAndToggleWalkable();
        }

        if (Input.GetMouseButtonDown(1))
        {
            RayCastAndSetDestination();
        }
    }
    public void RayCastAndToggleWalkable()
    {
        Vector2 rayPos = new Vector2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            GameObject obj = hit.transform.gameObject;
            RectGridCell_Viz sc = obj.GetComponent<RectGridCell_Viz>();
            ToggleWalkable(sc);
        }
    }

    public void ToggleWalkable(RectGridCell_Viz sc)
    {
        if (sc == null)
            return;

        int x = sc.RectGridCell.Value.x;
        int y = sc.RectGridCell.Value.y;

        sc.RectGridCell.IsWalkable = !sc.RectGridCell.IsWalkable;

        if (sc.RectGridCell.IsWalkable)
        {
            sc.SetInnerColor(COLOR_WALKABLE);

        }
        else
        {
            sc.SetInnerColor(COLOR_NON_WALKABLE);
        }
    }

    void RayCastAndSetDestination()
    {
        Vector2 rayPos = new Vector2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit)
        {
            GameObject obj = hit.transform.gameObject;
            RectGridCell_Viz sc = obj.GetComponent<RectGridCell_Viz>();
            if (sc == null) return;

            Vector3 pos = mDestination.position;
            pos.x = sc.RectGridCell.Value.x;
            pos.y = sc.RectGridCell.Value.y;
            mDestination.position = pos;

            //Sætter destinationen for NPCen
            mNPCMovement.SetDestination(this, sc.RectGridCell);
        }
    }
    //Laver neighbour cells som jeg kaldte i RectGridCell
    public List<Node<Vector2Int>> GetNeighbourCells(Node<Vector2Int> loc)
    {
        List<Node<Vector2Int>> neighbours = new List<Node<Vector2Int>>();

        int x = loc.Value.x;
        int y = loc.Value.y;

        //tjekker up
        if (y < mY - 1)
        {
            int i = x;
            int j = y + 1;
            if (mRectGridCells[i, j].IsWalkable)
            {
                neighbours.Add(mRectGridCells[i, j]);
            }
        }

        //tjekker op mod højre
        if (y < mY - 1 && x < mX - 1)
        {
            int i = x + 1;
            int j = y + 1;

            if (mRectGridCells[i, j].IsWalkable)
            {
                neighbours.Add(mRectGridCells[i, j]);
            }
        }

        //tjekker til højre
        if (x < mX - 1)
        {
            int i = x + 1;
            int j = y;

            if (mRectGridCells[i, j].IsWalkable)
            {
                neighbours.Add(mRectGridCells[i, j]);
            }

        }

        //tjekker til højre ned
        if (x < mX - 1 && y > 0)
        {
            int i = x + 1;
            int j = y - 1;

            if (mRectGridCells[i, j].IsWalkable)
            {
                if (neighbours.Add(mRectGridCells[i, j]);
            }
        }

        //tjekker ned
        if (y > 0)
        {
            int i = x;
            int j = y - 1;
            if (mRectGridCells[i, j].IsWalkable)
            {
                neighbours.Add(mRectGridCells[i, j]);
            }
        }

        //tjekker ned til venstre
        if (y > 0 && x > 0)
        {
            int i = x - 1;
            int j = y - 1;

            Vector2Int v = mIndices[i, j];

            if (mRectGridCells[i, j].IsWalkable)
            {
                neighbours.Add(mRectGridCells[i, j]);
            }
        }

        //tjekker venstre
        if (x > 0)
        {
            int i = x - 1;
            int j = y;
            if (mRectGridCells[i, j].IsWalkable)
            {
                neighbours.Add(mRectGridCells[i, j]);
            }
        }

        //tjekker venstre op
        if (y > 0 && y < mY - 1)
        {
            int i = x - 1;
            int j = y + 1;
            if (mRectGridCells[i, j].IsWalkable)
            {
                neighbours.Add(mRectGridCells[i, j]);
            }
        }

        return neighbours;
    }
    public static float GetManhattanCost(
        Vector2Int a,
        Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    public static float GetEuclideanCost(
        Vector2Int a,
        Vector2Int b)
    {
        return GetCostBetweenTwoCells(a, b);
    }

    public static float GetCostBetweenTwoCells(
        Vector2Int a,
        Vector2Int b)
    {
        return Mathf.Sqrt(
            (a.x - b.x) * (a.x - b.x) +
            (a.y - b.y) * (a.y - b.y)
            );
    }
    public RectGridCell RectGridCell(int x, int y)
    {
        if (x >= 0 && x < mX && y >= 0 && y < mY)
        {
            return mRectGridCells[x, y];
        }
        return null;

    }
}
