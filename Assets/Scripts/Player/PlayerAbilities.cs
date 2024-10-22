using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public KeyCode shield, melee, laser;

    [Header("Shield")]
    public Transform objectToScale;
    public Vector3 startScale;
    public Vector3 endScale;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float lerpTime = 1.0f;
    
   
    public bool isLerping = false;
   


    [Header("Melee")]
    public GameObject slashPrefab;
    public Transform meleeTarget;
    public GameObject meleeZone;
    public float meleeCooldown;
    public Quaternion offset;

    [Header("Laser")]
    public Transform playerTransform;
    public float laserDistance = 10f;
    private LineRenderer lineRenderer;
    public float resetDelay = 1f;
    public LayerMask layerMask;


    public static PlayerAbilities instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shield) )
        {
           
            if (!UIController.instance.canRefresh )
            {
               StartLerping();

            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Melee();

        }

        if(Input.GetKeyDown(laser) && UIController.instance.playerAbilities[2].isCooldown == false)
        {
            Beam();
            StartCoroutine(ResetLineRenderer());
        }

       
        if ( UIController.instance.playerAbilities[1].isCooldown == false || UIController.instance.canRefresh  )
        {
            ResetLerping();
            
        }
        

        if (meleeCooldown <= 0)
        {
            meleeZone.SetActive(false);
            meleeCooldown = 0.15f;
        }
        else
        {
            meleeCooldown -= Time.deltaTime;
        }




    }
    void StartLerping()
    {
        if (!isLerping)
        {
            isLerping = true;
            StartCoroutine(ScaleObject());
        }
    }

    void ResetLerping()
    {
        StopCoroutine(ScaleObject());
        objectToScale.localScale = startScale;
        objectToScale.localPosition = new Vector3(0,3.5f,0);
        isLerping = false;
       
    } 

    IEnumerator ScaleObject()
    {
        float currentLerpTime = 0.0f;
        
        
        while (currentLerpTime < lerpTime)
        {
            currentLerpTime += Time.deltaTime;
            float t = currentLerpTime / lerpTime;
            objectToScale.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }
        

        currentLerpTime = 0.0f;
        while (currentLerpTime < lerpTime)
        {
            currentLerpTime += Time.deltaTime;
            float t = currentLerpTime / lerpTime;
            objectToScale.localPosition = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        
    }


    public void Melee()
    {
        GameObject temp = Instantiate(slashPrefab, transform.position, transform.rotation * offset,parent:this.transform);
        Destroy(temp, 1f);
        meleeZone.SetActive(true);
        
    }

    public void Beam()
    {
        Vector3 direction = playerTransform.forward * laserDistance;
        lineRenderer.SetPosition(0, playerTransform.position);
        lineRenderer.SetPosition(1, playerTransform.position + direction);

        RaycastHit[] hits = Physics.RaycastAll(playerTransform.position, direction, laserDistance, layerMask);

        foreach (RaycastHit hit in hits)
        {
            Destroy(hit.collider.gameObject);
        }
    }

    IEnumerator ResetLineRenderer()
    {
        yield return new WaitForSeconds(resetDelay);
        lineRenderer.positionCount = 0;
        lineRenderer.positionCount = 2;
    }


}
