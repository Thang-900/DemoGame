using UnityEngine;

public class Play : MonoBehaviour
{
    public float speed = 5f;                 // tốc độ di chuyển
    public float mouseSensitivity = 100f;    // độ nhạy chuột
    public float minY = -60f;                // giới hạn xoay xuống
    public float maxY = 60f;                 // giới hạn xoay lên

    private CharacterController controller;
    private float rotationX = 0f;   // góc xoay theo trục X (ngẩng/ngửa)
    private float rotationY = 0f;   // góc xoay theo trục Y (trái/phải)
    private float rotationZ = 0f;   // góc xoay theo trục Z (nghiêng)

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Ẩn con trỏ chuột
    }

    void Update()
    {
        // --- Di chuyển WASD ---
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // --- Xoay theo chuột ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Xoay quanh trục Y (không giới hạn)
        rotationY += mouseX;

        // Xoay quanh trục X (có giới hạn)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        // Z (nếu muốn nghiêng người theo phím)
        if (Input.GetKey(KeyCode.Q)) rotationZ += 50f * Time.deltaTime; // nghiêng trái
        if (Input.GetKey(KeyCode.E)) rotationZ -= 50f * Time.deltaTime; // nghiêng phải

        // Áp dụng xoay theo cả 3 trục
        transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }
}
