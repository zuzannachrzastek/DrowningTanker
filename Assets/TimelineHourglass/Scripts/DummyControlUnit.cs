using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Timeline control unit example
/// </summary>
public class DummyControlUnit : MonoBehaviour
{
    // Modified by Zuzanna Chrzastek and Maciej Makowka, 2017

    public Timeline timeline;                       // Link to Timeline object
    public float timeout = 15f;                     // Set max time for timer (in seconds)    
    [Tooltip("The image or text that will be shown when player lose the level.")]
    public GameObject TextPrefab;

    [HideInInspector] public GameObject TextPrefabInstance; // A copy of the text prefab to prevent data corruption


    /// <summary>
    /// Check for initial data valid
    /// </summary>
    void Start ()
    {
	    if (    timeline == null)
        {
            Debug.Log("Wrong default settings");
        }
        // Display timer on start
        timeline.PrepareTimer(timeout, GetComponentsInChildren<TimelineEvent>());
    }

    /// <summary>
    /// Start timer
    /// </summary>
    public void StartHourglass()
    {
        //fireplace.StopFire();
        timeline.StartTimer(timeout, GetComponentsInChildren<TimelineEvent>());
    }

    /// <summary>
    /// Pause/Resume timer
    /// </summary>
    public void PauseHourglass()
    {
        timeline.TogglePause();
    }

    /// <summary>
    /// Stop timer
    /// </summary>
    public IEnumerator StopHourglass()
    {
        timeline.StopTimer();

        if (TextPrefab != null)
        {
            TextPrefabInstance = Instantiate(TextPrefab);
            TextPrefabInstance.transform.SetParent(transform, true); // Make the player the parent object of the text element
        }

        //wait few seconds
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Timeline event start handler
    /// </summary>
    /// <param name="eventObj"> Link to active event object </param>
    public void TimelineEventStart(GameObject eventObj)
    {
        
    }

    /// <summary>
    /// Timeline event end handler
    /// </summary>
    /// <param name="eventObj"> Link to active event object </param>
    public void TimelineEventEnd(GameObject eventObj)
    {
        
    }

    /// <summary>
    /// Timeline timeout handler
    /// </summary>
    private void TimelineTimeoutOccur()
    {
        
    }
}
