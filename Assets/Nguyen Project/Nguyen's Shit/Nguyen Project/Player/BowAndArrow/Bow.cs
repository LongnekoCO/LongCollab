using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public Text arrowText; 
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    public bool facingRight = true;
    public LineRenderer line;
    GameObject target;
    public GameObject crosshair;
    public float fireRate = 0.5f;

    public GameObject player; 

    private PlayerMovementScript playerScript;

    public bool canShoot;

    public SpringJoint2D springy; 

    public List<GameObject>arrowsSelect =  new List<GameObject>();
    public int selectedWeapon = 0;

    private BowAnimation bowAnim; 

    private void Start()
    {

        bowAnim = GetComponent<BowAnimation>();
        points = new GameObject[numberOfPoints];

        //for(int i = 0; i < numberOfPoints; i++)
        //{
        //    points[i] = Instantiate(point, shotPoint.position, Quaternion.identity); 

        //}

        playerScript = this.GetComponentInParent<PlayerMovementScript>();

        SelectWeapon();
        //arrow = arrowsSelect[0];

        line.enabled = false;
        springy.enabled = false;

        canShoot = true;
        player = this.transform.parent.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;

        crosshair.transform.position = mousePosition;

        if(Input.GetMouseButtonUp(0) && canShoot == true)
        {
            Shoot();
            StartCoroutine(Rate());
        }

        //for(int i = 0; i < numberOfPoints; i++)
        //{
        //    points[i].transform.position = PointPosition(i * spaceBetweenPoints); 
        //}



        if(playerScript.facingRight == false)
        {
            if(facingRight == true)
            {
                Flip();
            }
            
        }
        else if(playerScript.facingRight == true)
        {
           if(facingRight == false)
            {
                Flip();
            }
        }


        

        int previousSelectedWeapon = selectedWeapon; 

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= arrowsSelect.Count - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = arrowsSelect.Count - 1;
            else
                selectedWeapon--;
        }

        
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon(); 
        }

        if(target != null)
        {
            line.SetPosition(0, shotPoint.position);
            line.SetPosition(1, target.transform.position); 
        }

    }

    IEnumerator Rate()
    {
        canShoot = false;
        //bowAnim.canAnim = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
        //bowAnim.canAnim = true;
    }

    void SelectWeapon()
    {
        int i = 0; 
        foreach(GameObject arrows in arrowsSelect)
        {
            if (i == selectedWeapon)
            {
                arrow = arrowsSelect[selectedWeapon];
                StartCoroutine(ArrowTextChoose());
            }                               
            i++; 
        }
    }

    public void TargetHit(GameObject hit)
    {
        target = hit;
        canShoot = false;
        line.enabled = true;
        springy.enabled = true;
        springy.connectedBody = target.GetComponent<Rigidbody2D>();
        player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    public void TargetHitGrappling(GameObject hit)
    {
        target = hit;
        canShoot = false;
        line.enabled = true;
        springy.enabled = true;
        springy.connectedBody = target.GetComponent<Rigidbody2D>();
    }

    public void ReleaseGrappling()
    {
        line.enabled = false;
        springy.enabled = false;
        target = null;
        canShoot = true;
    }

    public void Release()
    {
        line.enabled = false;
        springy.enabled = false;
        target = null;
        player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        canShoot = true;
    }


    IEnumerator ArrowTextChoose()
    {
        arrowText.gameObject.SetActive(true);
        arrowText.text = arrow.name + " selected";
        yield return new WaitForSeconds(1f);
        arrowText.gameObject.SetActive(false);

    }


    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce; 
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position; 
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector2 bowScale = this.transform.localScale;
        bowScale.x = bowScale.x * -1;
        this.transform.localScale = bowScale;
    }
}
