using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    private float speed = 15f;

    [SerializeField]
    private GameObject blockSection;

    private void Start()
    {
        // ���콺 ��� ����, ���콺 �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {

        // ���콺 �̵� ���� ��� ȸ��
        transform.Rotate(-Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
    }

    private void BlockViewImage()
    {
        float objRotaValueX = this.transform.position.x;
        float objRotaValueY = this.transform.position.y;
        float objRotaValueZ = this.transform.position.z;



    }
}
