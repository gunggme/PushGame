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
    public Color ColorCoinFloor;
    public Color ColorEnermyFloor;
    public Color ColorKeyFloor;
    public Color ColorPlayerFloor;
    // �� ���� ��ġ
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
    public GameObject Enermy_Floor;
    public GameObject Key_Floor;
    public GameObject Player_Floor;
    public GameObject Coin_Floor;




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
                //Debug.Log(pixelColor);
                // �ٴ�
                if (pixelColor == ColorFloor)
                {
                    GameObject floor = GameObject.Instantiate(Floor, Terrain);
                    floor.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                }
                // ��
                if (pixelColor == ColorWal)
                {
                    Debug.Log("��������");
                    GameObject wall = GameObject.Instantiate(Wall, Terrain);
                    wall.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                    wall.transform.Rotate(new Vector3(0, GetWallRot(pixels, i, j), 0), Space.Self);
                }
                // Ŀ�� ��
                if (pixelColor == ColorCurveWall)
                {
                    GameObject curveWall = GameObject.Instantiate(CurveWall, Terrain);
                    curveWall.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                    curveWall.transform.Rotate(new Vector3(0, GetCurveWallRot(pixels, i, j), 0), Space.Self);
                }
                // �𼭸� ��
                if (pixelColor == ColorEdgeWall)
                {
                    GameObject edgeWall = GameObject.Instantiate(EdgeWall, Terrain);
                    edgeWall.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                    edgeWall.transform.Rotate(new Vector3(0, GetEdgeWall(pixels, i, j), 0), Space.Self);
                }
                // ���� ���� ��ġ
                if (pixelColor == ColorEnermyFloor)
                {
                    GameObject floor = GameObject.Instantiate(Enermy_Floor, Terrain);
                    floor.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                }
                //���� ���� ��ġ
                if(pixelColor == ColorKeyFloor)
                {
                    GameObject floor = GameObject.Instantiate(Key_Floor, Terrain);
                    floor.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                }
                //�÷��̾� ���� ��ġ
                if (pixelColor == ColorPlayerFloor)
                {
                    GameObject floor = GameObject.Instantiate(Player_Floor, Terrain);
                    floor.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                }
                //���� ���� ��ġ
                if (pixelColor == ColorCoinFloor)
                {
                    GameObject floor = GameObject.Instantiate(Coin_Floor, Terrain);
                    floor.transform.position = new Vector3(j * tileSize, 0, i * tileSize);
                }

            }

        }
    }

    private float GetWallRot(Color[] pixels, int i, int j)
    {
        // ������
        float rot = 0f;
        // �Ʒ�
        if (i - 1 >= 0 && (pixels[(i - 1) * mapHeight + j] == Color.white || pixels[(i - 1) * mapHeight + j] == Color.cyan))
        {
            rot = 90f;
        }
        // ����
        else if (j - 1 >= 0 && (pixels[i * mapHeight + (j - 1)] == Color.white || pixels[i * mapHeight + (j - 1)] == Color.cyan))
        {
            rot = 180f;
        }
        // ��
        else if (i + 1 < mapHeight && (pixels[(i + 1) * mapHeight + j] == Color.white || pixels[(i + 1) * mapHeight + j] == Color.cyan))
        {
            rot = -90f;
        }
        return rot;
    }

    private float GetCurveWallRot(Color[] pixels, int i, int j)
    {
        // ������ ��
        float rot = 0f;
        // ������ �Ʒ�
        if (((pixels[i * mapHeight + j - 1] == Color.white || pixels[i * mapHeight + j - 1] == Color.cyan)) && ((pixels[(i - 1) * mapHeight + j] == Color.white) || (pixels[(i - 1) * mapHeight + j] == Color.cyan)))
        {
            rot = 180f;
        }
        // ���� ��
        if (((pixels[i * mapHeight + j - 1] == Color.white) || (pixels[i * mapHeight + j - 1] == Color.cyan)) && ((pixels[(i + 1) * mapHeight + j] == Color.white) || (pixels[(i + 1) * mapHeight + j] == Color.cyan)))
        {
            rot = -90f;
        }
        // ���� �Ʒ�
        if (((pixels[i * mapHeight + j + 1] == Color.white) || (pixels[i * mapHeight + j + 1] == Color.cyan)) && ((pixels[(i - 1) * mapHeight + j] == Color.white) || (pixels[(i - 1) * mapHeight + j] == Color.cyan)))
        {
            rot = 90f;
        }
        return rot;
    }

    private float GetEdgeWall(Color[] pixels, int i, int j)
    {
        // ������ ��
        float rot = 0f;
        // ������ �Ʒ�
        if (i - 1 >= 0 && j + 1 < mapWidth && (pixels[(i - 1) * mapHeight + (j + 1)] == Color.white || pixels[(i - 1) * mapHeight + (j + 1)] == Color.cyan))
        {
            rot = 90f;
        }
        // ���� ��
        else if (i - 1 >= 0 && j - 1 >= 0 && (pixels[(i - 1) * mapHeight + (j - 1)] == Color.white || pixels[(i - 1) * mapHeight + (j - 1)] == Color.cyan))
        {
            rot = 180f;
        }
        // ���� �Ʒ�
        else if (i + 1 < mapHeight && j - 1 >= 0 && (pixels[(i + 1) * mapHeight + (j - 1)] == Color.white || pixels[(i + 1) * mapHeight + (j - 1)] == Color.cyan))
        {
            rot = -90f;
        }
        return rot;
    }


}
