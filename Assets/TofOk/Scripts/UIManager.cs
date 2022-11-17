using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* ScreenRecorderKit Required for recording function
using VoxelBusters.CoreLibrary;
using VoxelBusters.ScreenRecorderKit;
*/

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingOpenButton, SettingCloseButton, RecordButton, SaveButton;
    [SerializeField]
    private GameObject SettingPanel;
    [SerializeField]
    private GameObject ColorView;

    private Text m_statusText = null;
    /* ScreenRecorderKit Required for recording function
     private IScreenRecorder m_recorder;
    */

    void Start()
    {
        SettingPanel.GetComponent<CanvasGroup>().alpha = 0;
        SettingPanel.GetComponent<CanvasGroup>().interactable = false;
        SettingPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

        SettingOpenButton.SetActive(true);
        SettingCloseButton.SetActive(false);
        RecordButton.SetActive(true);
        SaveButton.SetActive(false);
    }
    public void SettingPanelOpen()
    {
        SettingPanel.GetComponent<CanvasGroup>().alpha = 1;
        SettingPanel.GetComponent<CanvasGroup>().interactable = true;
        SettingPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        SettingCloseButton.SetActive(true);
        SettingOpenButton.SetActive(false);
    }
    public void SettingPanelClose()
    {
        SettingPanel.GetComponent<CanvasGroup>().alpha = 0;
        SettingPanel.GetComponent<CanvasGroup>().interactable = false;
        SettingPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        SettingOpenButton.SetActive(true);
        SettingCloseButton.SetActive(false);
    }
    public void ColorViewManager()
    {
        if(ColorView.activeInHierarchy == true)
        {
            ColorView.SetActive(false);
        }
        else
        {
            ColorView.SetActive(true);
        }
    }
    /* ScreenRecorderKit Required for recording function
    public void StartRecording()
    {
        RecordButton.SetActive(false);
        SaveButton.SetActive(true);
        CreateVideoRecorder();

        m_recorder.PrepareRecording(callback: (success, error) =>
        {
            if (success)
            {
                SetStatus("Prepare recording successful.");
            }
            else
            {
                SetStatus($"Prepare recording failed with error [{error}]");
            }
        });
        m_recorder.StartRecording();
        SetStatus("Started Recording");
    }

    public void StopRecordingAndSave()
    {
        RecordButton.SetActive(true);
        SaveButton.SetActive(false);
        m_recorder.StopRecording((success, error) =>
        {
            if (success)
            {
                SetStatus("Stopped recording");
            }
            else
            {
                SetStatus($"Failed with error: {error}");
            }
        });
        m_recorder.SaveRecording(null, (result, error) =>
        {
            if (error == null)
            {
                SetStatus("Saved recording successfully :" + result.Path);
            }
            else
            {
                SetStatus($"Failed saving recording [{error}]");
            }
        });
    }

    public void CreateVideoRecorder()
    {
        //Dispose if any recorder instance created earlier
        Cleanup();
        VideoRecorderRuntimeSettings settings = new VideoRecorderRuntimeSettings(enableMicrophone: true);
        ScreenRecorderBuilder builder = ScreenRecorderBuilder.CreateVideoRecorder(settings);
        m_recorder = builder.Build();

        //Register for recording path
        m_recorder.SetOnRecordingAvailable((result) =>
        {
            string path = result.Data as string;
            SetStatus($"File path: {path}");
        });

        SetStatus("Video Recorder Created");
    }

    private void Cleanup()
    {
        if (m_recorder != null)
        {
            if (m_recorder.IsRecording())
            {
                m_recorder.StopRecording();
            }

            m_recorder.Flush();
        }

        m_recorder = null;
    }
    private string GetRecorderName()
    {
        if (m_recorder is VideoRecorder)
            return VideoRecorder.Name;
        else
            return GifRecorder.Name;
    }
    private void SetStatus(string message)
    {
        Debug.Log($"[ScreenRecorder ({GetRecorderName()})] : {message}");

        if (m_statusText != null)
        {
            m_statusText.text = $"[{GetRecorderName()}] {message}";
        }
    }
    */
}
