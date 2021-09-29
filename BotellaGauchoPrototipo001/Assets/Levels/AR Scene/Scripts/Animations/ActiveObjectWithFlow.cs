using Managers;
using System.Collections;
using UnityEngine;

public class ActiveObjectWithFlow : MonoBehaviour
{
    [Header("Setting")]
    public float high;
    public float speedMove;
    public float speedScale;

    public bool playOnAwake;

    public GameObject ploof;

    public AudioClip clip;

    [Header("Debug")]
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 startScale;
    [SerializeField] private float scalePercent = 0;

    private void Start()
    {
        if(playOnAwake)
            Active();
    }

    /// <summary>
    /// Active the object and make a spawn effect
    /// </summary>
    public void Active()
    {
        //AudioManager.Instance.PlayOneShotInSource("ActiveObjectWithFlow",clip);

        //Save the Initial setting
        startPosition = transform.position;
        startScale = transform.localScale;

        //Equipara la velocidad de expansion de todos los objetos
        scalePercent = (startScale.x + startScale.y + startScale.z) * (speedScale / 100);

        //Set the position more higher
        transform.position = new Vector3(startPosition.x, startPosition.y + high, startPosition.z);
        //And scale in 0
        transform.localScale = Vector3.zero;

        //Shop up the object
        gameObject.SetActive(true);
       
        //Scale to the initial scale
        StartCoroutine(Expand());
    }

    /// <summary>
    /// Move object to a target position
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveToPosition()
    {
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        float speed = speedMove;
        while (Mathf.Abs(transform.position.y - startPosition.y) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed  * Time.deltaTime);
            yield return fixedUpdate;
        }

       // Instantiate(ploof, transform.position, Quaternion.LookRotation(new Vector3(0,1,0),Vector3.up)).transform.SetParent(transform);    
    }

    /// <summary>
    /// Scale the object to a target scale
    /// </summary>
    /// <returns></returns>
    private IEnumerator Expand()
    {
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        while (Mathf.Abs(transform.localScale.y - startScale.y) > 0f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, startScale, scalePercent * Time.deltaTime);
            yield return fixedUpdate;
        }

        //Move to the initial position
        StartCoroutine(MoveToPosition());
    }
}