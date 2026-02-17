using System;
using System.Collections;
using System.Collections.Generic;
using TofAr.V0.Hand;
using UnityEngine;
using UnityEngine.UI;

public class TofOkManager : MonoBehaviour
{
    [Header("Brush Setting")]
    /// <summary>
    /// ink object.
    /// (scale = 0.02 in my sample)
    /// </summary>
    public GameObject[] pointBrush;
    private int pointBrushIndex = 0;

    private int touchIndex = 0;
    //LineRenderer
    private LineRenderer lineRenderer;
    public GameObject lineBrush;
    //用来索引端点
    private int index = 0;
    //端点数
    private int LengthOfLineRenderer = 0;

    public AudioClip Sound;
    private AudioSource source;

    [Header("Make Up Setting")]
    /* 选择功能
    [System.Serializable]
    public enum TypeOfBrush
    {
        Point,
        Line
    }
    */
    public bool togglePoint;
    public bool toggleLine;
    public bool toggleFace;

    public Material transparentFace;
    private Material defaultFace;

    /* 选择功能
    public TypeOfBrush typeOfBrush;
    public Dropdown dropdown;
    */

    private Transform TofObjects;

    private GameObject FaceTarget;
    // 存放笔刷，位置和旋转跟随AR Face
    [HideInInspector]
    public List<GameObject> Container = new List<GameObject>();

    public float nrDrawing = 0.5f;
    private Vector3 prePosition = Vector3.zero;

    /// <summary>
    /// The interval between the generation time of each brush and the previous brush.
    /// (scale = 0.02 in my sample)
    /// </summary>
    public int interval = 3;

    public float threshold = 0.05f;

    private float blendTipDistance = 0.1f;

    private bool isTouched = false;

    private Vector3 relativeTips;

    private int intervalIndex = 0;

    private bool drawPoint = false;
    private bool drawLine = false;
    private Vector3 drawPosition;


    private void Awake()
    {
        GameObject.Find("Canvas/SafeArea/Settings/ToggleBrush/TogglePoint").GetComponent<Toggle>().isOn = togglePoint;
        GameObject.Find("Canvas/SafeArea/Settings/ToggleBrush/ToggleLine").GetComponent<Toggle>().isOn = toggleLine;
        GameObject.Find("Canvas/SafeArea/Settings/ToggleBrush/ToggleFace").GetComponent<Toggle>().isOn = toggleFace;

    }


    public static void BlendDropDownWithEnum(Dropdown dropdown, Enum targetEnum)
    {
        Type enumType = targetEnum.GetType();
        List<Dropdown.OptionData> addOptions = new List<Dropdown.OptionData>();

        for (int i = 0; i < Enum.GetNames(enumType).Length; i++)
        {
            addOptions.Add(new Dropdown.OptionData(Enum.GetName(enumType, i)));
        }
        dropdown.ClearOptions();//Clear old options
        dropdown.AddOptions(addOptions);//Add new options
    }
    void Start()
    {
        TofObjects = Camera.main.transform.Find("RelativePositionContainer");
        FaceTarget = Camera.main.transform.Find("FaceObject/FaceModel").gameObject;

        TofArHandManager.OnFrameArrived += FrameArrived;

        faceJewelry.transform.SetParent(FaceTarget.transform);
        faceJewelry.transform.localPosition = Vector3.zero;
        GameObject faceMesh = faceJewelry.transform.Find("faceMesh").gameObject;
        defaultFace = faceMesh.GetComponent<Renderer>().sharedMaterial;
        faceMesh.SetActive(false);

        Toggle faceToggle = GameObject.Find("Canvas/SafeArea/Settings/ToggleBrush/ToggleFace").GetComponent<Toggle>();

        faceToggle.onValueChanged.AddListener((value) => {
            FaceMaterialManager(value);
        });

        source = GetComponent<AudioSource>();
    }
    void FaceMaterialManager(bool isOn)
    {
        if (isOn)
        {
            FaceTarget.GetComponent<Renderer>().material = defaultFace;
        }
        else
        {
            FaceTarget.GetComponent<Renderer>().material = transparentFace;
        }
    }

    private void FrameArrived(object sender)
    {
        #region TofArHandManager
        /* 
         * 显式转换 sender 为 TofArHandManager
         * Manage the connection with TofAr Hand component
                    Has the following functions
                    Hand recognition settings
                    Get hand data
                    Event for stream start
                    Event for stream end
                    Event for frame arrival
                    Event for gesture estimation result
                    Playback of recording file
         */
        #endregion
        TofArHandManager mgr = (TofArHandManager)sender;

        #region HandStatus
        /*
        右手
        RightHand,
        左手
        LeftHand,
        无手 
        NoHand,
        手指
        Tip,
        双手
        BothHands,
        不明
        UnknownHand
         */
        #endregion
        HandStatus status = mgr.HandData.Data.handStatus;

        // 在Front Cam里左右手是镜像相反的
        switch(status)
        {
            case HandStatus.LeftHand:
                LeftHand(mgr);
                break;
            case HandStatus.RightHand:
                RightHand(mgr);
                break;
            case HandStatus.BothHands:
                break;
            default:
                break;
        }
    }
    void LeftHand(TofArHandManager mgr)
    {
        Vector3[] leftHandPoints = mgr.HandData.Data.featurePointsLeft;

        Vector3 leftIndexTip = leftHandPoints[(int)HandPointIndex.IndexTip];
        Vector3 leftThumbTip = leftHandPoints[(int)HandPointIndex.ThumbTip];

        Hand(leftHandPoints, leftIndexTip, leftThumbTip);
    }
    void RightHand(TofArHandManager mgr)
    {
        Vector3[] rightHandPoints = mgr.HandData.Data.featurePointsRight;

        Vector3 rightIndexTip = rightHandPoints[(int)HandPointIndex.IndexTip];
        Vector3 rightThumbTip = rightHandPoints[(int)HandPointIndex.ThumbTip];

        Hand(rightHandPoints, rightIndexTip, rightThumbTip);
    }

    void Hand(Vector3[] handPoints,Vector3 indexTip,Vector3 thumbTip)
    {
        float tipDistance = Vector3.Distance(indexTip, thumbTip);

        //Debug.Log("tipDistance: " + tipDistance);
        blendTipDistance = blendTipDistance * 0.7f + tipDistance * 0.3f; // blend
        //Debug.Log("tipDistanceRight: " + tipDistanceRight);
        if (blendTipDistance <= threshold)
        {
            if (toggleLine)
            {
                    touchIndex++;
                    if (touchIndex == 1)
                    {
                        Container.Add(Instantiate(lineBrush));
                        // Fix brushs on AR Face.
                        int currectCount = Container.Count - 1;
                        Container[currectCount].transform.parent = FaceTarget.transform;
                        lineRenderer = Container[currectCount].GetComponent<LineRenderer>();
                        
                    }
            }
            Vector3 handAverage = Vector3.zero;
            for (int i = 0; i < 22; i++)
            {
                handAverage += handPoints[i];
            }
            handAverage /= 22;

            if (!isTouched)
            {
                Vector3 tips = (indexTip + thumbTip) / 2;

                // register relative position 
                relativeTips = tips - handAverage;

                // reset temp position for NR
                prePosition = Vector3.zero;

                isTouched = true;
            }

            if (intervalIndex == 0)
            {
                // tracking with hand average (not with tips)
                drawPosition = handAverage + relativeTips;

                // draw
                drawPoint = true;
                drawLine = true;

                intervalIndex = interval;
            }
        }
        else
        {
            isTouched = false;
            drawPoint = false;
            drawLine = false;
            touchIndex = 0;
        }
    }

    [Header("Jewelry Setting")]
    public GameObject faceJewelry;

    void Update()
    {
        /* 选择功能
        typeOfBrush = (TypeOfBrush)dropdown.value;
        */
        togglePoint = GameObject.Find("Canvas/SafeArea/Settings/ToggleBrush/TogglePoint").GetComponent<Toggle>().isOn;
        toggleLine = GameObject.Find("Canvas/SafeArea/Settings/ToggleBrush/ToggleLine").GetComponent<Toggle>().isOn;

        if (intervalIndex > 0)
        {
            intervalIndex--;
        }
        if (togglePoint)
        {
            if (drawPoint)
            {
                drawPoint = false;
                Container.Add(Instantiate(pointBrush[pointBrushIndex]));
                pointBrushIndex++;
                if (pointBrushIndex >= pointBrush.Length)
                {
                    pointBrushIndex = 0;
                }

                Vector3 newPos = TofObjects.rotation * drawPosition + TofObjects.position;

                if (prePosition != Vector3.zero)
                {
                    newPos = newPos * nrDrawing + prePosition * (1 - nrDrawing);
                }

                int currectCount = Container.Count - 1;
                Container[currectCount].transform.position = newPos;
                Container[currectCount].transform.LookAt(FaceTarget.transform);
                prePosition = newPos;

                // Fix brushs on AR Face.
                Container[currectCount].transform.parent = FaceTarget.transform;
            }
        }
        if (toggleLine)
        {
            if (drawLine)
            {
                Vector3 newPos = TofObjects.rotation * drawPosition + TofObjects.position;
                if (prePosition != Vector3.zero)
                {
                    newPos = newPos * nrDrawing + prePosition * (1 - nrDrawing);
                }
                prePosition = newPos;
                //端点数+1
                LengthOfLineRenderer++;
                //设置线段的端点数
                lineRenderer.positionCount = LengthOfLineRenderer;
                //连续绘制线段
                while (index < LengthOfLineRenderer)
                {
                    //两点确定一条直线，所以我们依次绘制点就可以形成线段了
                    lineRenderer.SetPosition(index, newPos);
                    index++;
                }
                source.PlayOneShot(Sound, 1F);
            }
            else
            {
                index = 0;
                LengthOfLineRenderer = 0;
            }
        }
    }


}
