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
        // 마우스 가운데 고정, 마우스 안보이게
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {

        // 마우스 이동 따른 블록 회전
        transform.Rotate(-Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
    }

    private void BlockViewImage()
    {
        float objRotaValueX = this.transform.position.x;
        float objRotaValueY = this.transform.position.y;
        float objRotaValueZ = this.transform.position.z;



    }
}
