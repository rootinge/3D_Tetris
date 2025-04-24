using System.Collections;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    private float speed = 15f;

    // �ܸ� Ȯ�ο� ���� ���
    [SerializeField]
    private GameObject sectionBlock;


    [SerializeField]
    private float rotationMoveSpeed = 20.0f;

    private bool isRotating = false;
    private bool isSectoinRotating = false;

    private void Start()
    {
        // ���콺 ��� ����, ���콺 �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        if(!isRotating)
        {
            // ���콺 �̵� ���� ��� ȸ��
            transform.Rotate(-Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
            if (!isSectoinRotating)
                SectionBlockRotationMove();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)
        {
            BlockViewImage(this.gameObject);
        }

        
        
    }

    private void SectionBlockRotationMove()
    {
        // ���Ǻ�� ���� ȸ����
        Vector3 sectionObjRotation = sectionBlock.transform.rotation.eulerAngles;

        // ���κ�� ���� ȸ����
        Vector3 mainObjRotation = this.transform.rotation.eulerAngles;

        if(Mathf.Abs(Mathf.Abs(sectionObjRotation.x - 180) - Mathf.Abs(mainObjRotation.x - 180)) >= 45)
        {
           
            isSectoinRotating = true;
            BlockViewImage(sectionBlock);
        }
        else if (Mathf.Abs(Mathf.Abs(sectionObjRotation.y - 180) - Mathf.Abs(mainObjRotation.y - 180)) >= 45)
        {
            isSectoinRotating = true;
            BlockViewImage(sectionBlock);
        }
        else if (Mathf.Abs(Mathf.Abs(sectionObjRotation.z - 180) - Mathf.Abs(mainObjRotation.z - 180)) >= 45)
        {
            isSectoinRotating = true;
            BlockViewImage(sectionBlock);
        } 

    }



    // �����ִ� ����� ���� ����
    private void BlockViewImage(GameObject gameObject)
    {
        Vector3 objRotation = this.transform.rotation.eulerAngles;


        
        for (int i = 0; i <= 360; i += 90)
        {
            
            if (Mathf.Abs(i - objRotation.x) < 45)
            {
                objRotation.x = i;
            }

            if (Mathf.Abs(i - objRotation.y) < 45)
            {
                objRotation.y = i;
            }

            if (Mathf.Abs(i - objRotation.z) < 45)
            {
                objRotation.z = i;
            }
        }

        if(gameObject == sectionBlock)
        {
            gameObject.transform.eulerAngles = objRotation;
            isSectoinRotating = false;
        }
        else
        {
            StartCoroutine(BlockRotationMove(gameObject, objRotation));
        }


    }


    IEnumerator BlockRotationMove(GameObject gameObject, Vector3 targetRotation)
    {
        isRotating = true;

        // ���� ȸ����
        Vector3 currentRotation = gameObject.transform.eulerAngles;

        while (Vector3.Distance(currentRotation, targetRotation) > 0.01f)
        {
            // ���� ȸ������ �ε巴�� ����
            currentRotation = Vector3.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationMoveSpeed);
            gameObject.transform.eulerAngles = currentRotation;

            yield return null;
        }

        gameObject.transform.eulerAngles = targetRotation;


        isRotating = false;

        
    } 
}


