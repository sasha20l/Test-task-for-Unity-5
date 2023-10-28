using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{

    public GameObject Tile;

    public float seamBetweenTiles = 0;
    public float cornerTilesInArea = 0;
    public float bias = 0;


    private float seamBetweenTilesClone;
    private float cornerTilesInAreaClone;
    private float biasClone;


    private Vector3 firstTileSlope;

    private Vector3 firstTilePos = new Vector3(0, 0, 0);

    GameObject lastPref;
    GameObject StartPrefPos;

    bool flag = true;
    bool biasFlag = true;


    void Start()
    {

       seamBetweenTilesClone = seamBetweenTiles;
       cornerTilesInAreaClone = cornerTilesInArea;
       biasClone = bias;




        Create();
        
    }

    void LateUpdate()
    {
        if (flag)
        {
            print(areaInt());
            flag = false;
        }

        ChangeSettings();


    }
    
    void ChangeSettings()
    {
        if (seamBetweenTilesClone != seamBetweenTiles || cornerTilesInAreaClone != cornerTilesInArea || biasClone != bias)
        {
            seamBetweenTilesClone = seamBetweenTiles;
            cornerTilesInAreaClone = cornerTilesInArea;
            biasClone = bias;

            GameObject[] objectsForLook = GameObject.FindGameObjectsWithTag("parent_object");
            foreach (GameObject i in objectsForLook)
            {
                Destroy(i);
            }
            firstTilePos = new Vector3(0, 0, 0);
            Create();
            flag = true;
        }
    }


    public int areaInt()
    {
        GameObject[] objectsForLook = GameObject.FindGameObjectsWithTag("area");
    
        return objectsForLook.Length;
    }

    void Create()
    {
        cornerTilesInArea = AngleOfRotation(cornerTilesInArea);
        if (cornerTilesInArea > 45 && cornerTilesInArea < 70)
        {
            firstTilePos = new Vector3(0, 0, 450);

        }
        else if (cornerTilesInArea >= 70)
        {
            firstTilePos = new Vector3(0, 0, 800);
        }

        firstTileSlope = new Vector3(0, cornerTilesInArea, 0);

        Vector3 lastPrefPos;

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if (i == 0 && j == 0)
                {
                    var pref = Instantiate(Tile, firstTilePos, Quaternion.Euler(firstTileSlope));
                    StartPrefPos = pref;
                    lastPref = StartPrefPos;
                }
                else
                {
                    lastPrefPos = StartPrefPos.transform.position + (100 * lastPref.transform.right * j + lastPref.transform.right * seamBetweenTiles * j + lastPref.transform.forward * seamBetweenTiles * i + 100 * lastPref.transform.forward * i);// + new Vector3(j*100,0,0);
                    lastPref = Instantiate(Tile, lastPrefPos, Quaternion.Euler(firstTileSlope));
                }
            }
            if (biasFlag)
            {
                biasFlag = false;
                StartPrefPos.transform.position = StartPrefPos.transform.position + bias * lastPref.transform.right;
            }
            else 
            {
                StartPrefPos.transform.position = StartPrefPos.transform.position - bias * lastPref.transform.right;
                biasFlag = true; 
            }
            
        }
    }
    private float AngleOfRotation(float angle)
    {
        if (angle <= 0 || angle > 360) return 0;
        var angl = angle;
        if (angl > 270 && angl < 361) angl = 90 - (360-angl);
        else if (angl > 180 && angl < 270) angl = 90 - (270 - angl);
        else if (angl > 90 && angl < 180) angl = 90 - (180 - angl);

        //if (angl > 45 && angl < 90) return (angl - 45);
        return angl; 
    }
}
