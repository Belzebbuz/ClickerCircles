using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public static Border Instance { get; private set; }
    
    [Range(0, 1)]  [SerializeField] private float coefHiegth;

    private float width;
    private float height;
    private float CenterOX;
    private float TopBorder;
    private float LeftBorder;
    private float RightBorder;

    private Camera camera;
    
    private void Awake()
    {
        Instance = this;
        camera = Camera.main;
        height = camera.pixelHeight;
        width = camera.pixelWidth;
        RightBorder = camera.ScreenToWorldPoint(new Vector2(width, 0)).x;
        TopBorder = camera.ScreenToWorldPoint(new Vector2(0, height)).y;
        LeftBorder = camera.ScreenToWorldPoint(new Vector2(0, 0)).x;
        CenterOX = camera.ScreenToWorldPoint(new Vector2(width * 0.5f, 0)).x;
    }
    public float colorPoint()
    {
        return CenterOX + 1;
    }
    public float GetDestroyPoint()
    {
        return RightBorder + 1 ;
    }
    public Vector3 GetSpawnPoint()
    {
        return new Vector3(LeftBorder - 1, TopBorder - TopBorder * coefHiegth, 0);
    }
    public Vector3 GetCheckRingPoint()
    {
        return new Vector3(CenterOX, TopBorder - TopBorder * coefHiegth, 0);
    }
    public Vector3 MissPoint()
    {
        return new Vector3(RightBorder - 1.5f, TopBorder - TopBorder * coefHiegth, 0);
    }
}
