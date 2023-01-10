using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MapGenerator : MonoBehaviour
{
    public Color ColorFloor;
    public Color ColorWal;
    public Color ColorCurveWall;
    public Color ColorEdgeWall;
    // 적 등장 위치
    public Color ColorResponse = new Color(64, 128, 128);

    public Transform Terrain;
    public Texture2D MapInfo;
    public float tileSize = 4.0f;
    private int mapWidth;
    private int mapHeight;
    public GameObject Floor;
    public GameObject Wall;
    public GameObject CurveWall;
    public GameObject EdgeWall;
    public GameObject Floor_Response;




    public void BuildGenerator()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        mapWidth = MapInfo.width;   //52
        mapHeight = MapInfo.height; //44
        Debug.Log(MapInfo.width);
        Debug.Log(MapInfo.height);

        Color[] pixels = MapInfo.GetPixels();

        Debug.Log(pixels.Length);

        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                Color pixelColor = pixels[i * mapHeight + j];       // 0
                Debug.Log(pixelColor);
                // 바닥
                if (pixelColor == Color.white)
                {
                    GameObject floor = GameObject.Instantiate(Floor, Terrain);
                    floor.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                }
                // 벽
                if (pixelColor == Color.red)
                {
                    GameObject wall = GameObject.Instantiate(Wall, Terrain);
                    wall.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                    wall.transform.Rotate(new Vector3(0, GetWallRot(pixels, i, j), 0), Space.Self);
                }
                // 커브 벽
                if (pixelColor == Color.green)
                {
                    GameObject curveWall = GameObject.Instantiate(CurveWall, Terrain);
                    curveWall.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                    curveWall.transform.Rotate(new Vector3(0, GetCurveWallRot(pixels, i, j), 0), Space.Self);
                }
                // 모서리 벽
                if (pixelColor == Color.blue)
                {
                    GameObject edgeWall = GameObject.Instantiate(EdgeWall, Terrain);
                    edgeWall.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                    edgeWall.transform.Rotate(new Vector3(0, GetEdgeWall(pixels, i, j), 0), Space.Self);
                }
                // 몬스터 생성 위치
                if (pixelColor == ColorResponse)
                {
                    GameObject floor = GameObject.Instantiate(Floor_Response, Terrain);
                    floor.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                }

            }

        }
    }

    private float GetWallRot(Color[] pixels, int i, int j)
    {
        // 오른쪽
        float rot = 0f;
        // 아래
        if (i - 1 >= 0 && (pixels[(i - 1) * mapHeight + j] == Color.black || pixels[(i - 1) * mapHeight + j] == Color.cyan))
        {
            rot = 90f;
        }
        // 왼쪽
        else if (j - 1 >= 0 && (pixels[i * mapHeight + (j - 1)] == Color.black || pixels[i * mapHeight + (j - 1)] == Color.cyan))
        {
            rot = 180f;
        }
        // 위
        else if (i + 1 < mapHeight && (pixels[(i + 1) * mapHeight + j] == Color.black || pixels[(i + 1) * mapHeight + j] == Color.cyan))
        {
            rot = -90f;
        }
        return rot;
    }

    private float GetCurveWallRot(Color[] pixels, int i, int j)
    {
        // 오른쪽 위
        float rot = 0f;
        // 오른쪽 아래
        if (((pixels[i * mapHeight + j - 1] == Color.black || pixels[i * mapHeight + j - 1] == Color.cyan)) && ((pixels[(i - 1) * mapHeight + j] == Color.black) || (pixels[(i - 1) * mapHeight + j] == Color.cyan)))
        {
            rot = 180f;
        }
        // 왼쪽 위
        if (((pixels[i * mapHeight + j - 1] == Color.black) || (pixels[i * mapHeight + j - 1] == Color.cyan)) && ((pixels[(i + 1) * mapHeight + j] == Color.black) || (pixels[(i + 1) * mapHeight + j] == Color.cyan)))
        {
            rot = -90f;
        }
        // 왼쪽 아래
        if (((pixels[i * mapHeight + j + 1] == Color.black) || (pixels[i * mapHeight + j + 1] == Color.cyan)) && ((pixels[(i - 1) * mapHeight + j] == Color.black) || (pixels[(i - 1) * mapHeight + j] == Color.cyan)))
        {
            rot = 90f;
        }
        return rot;
    }

    private float GetEdgeWall(Color[] pixels, int i, int j)
    {
        // 오른쪽 위
        float rot = 0f;
        // 오른쪽 아래
        if (i - 1 >= 0 && j + 1 < mapWidth && (pixels[(i - 1) * mapHeight + (j + 1)] == Color.black || pixels[(i - 1) * mapHeight + (j + 1)] == Color.cyan))
        {
            rot = 90f;
        }
        // 왼쪽 위
        else if (i - 1 >= 0 && j - 1 >= 0 && (pixels[(i - 1) * mapHeight + (j - 1)] == Color.black || pixels[(i - 1) * mapHeight + (j - 1)] == Color.cyan))
        {
            rot = 180f;
        }
        // 왼쪽 아래
        else if (i + 1 < mapHeight && j - 1 >= 0 && (pixels[(i + 1) * mapHeight + (j - 1)] == Color.black || pixels[(i + 1) * mapHeight + (j - 1)] == Color.cyan))
        {
            rot = -90f;
        }
        return rot;
    }


}
