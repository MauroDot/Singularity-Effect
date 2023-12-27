using UnityEngine;
using UnityEngine.UI; // Required for UI elements

[RequireComponent(typeof(SphereCollider))]
public class Singularity : MonoBehaviour
{
    [SerializeField] public float GRAVITY_PULL = 100f;
    public static float m_GravityRadius = 1f;

    [SerializeField] private Slider gravitySlider; // Reference to the UI Slider
    [SerializeField] private Text gravityPercentageText; // Reference to the UI Text
    [SerializeField] private float gravityAdjustmentSpeed = 10f; // Speed of adjusting the gravity pull

    void Awake()
    {
        m_GravityRadius = GetComponent<SphereCollider>().radius;

        if (GetComponent<SphereCollider>())
        {
            GetComponent<SphereCollider>().isTrigger = true;
        }

        if (gravitySlider != null)
        {
            gravitySlider.value = GRAVITY_PULL;
            gravitySlider.minValue = 0;
            gravitySlider.maxValue = 200;
            gravitySlider.onValueChanged.AddListener(HandleSliderChange); // Add listener
        }
    }

    void Update()
    {
        AdjustGravityPull();
    }

    void AdjustGravityPull()
    {
        GRAVITY_PULL += Input.GetAxis("Mouse ScrollWheel") * gravityAdjustmentSpeed;
        GRAVITY_PULL = Mathf.Clamp(GRAVITY_PULL, gravitySlider.minValue, gravitySlider.maxValue);

        if (gravitySlider != null && !Input.GetMouseButton(0)) // Check if the mouse is not being used to drag the slider
        {
            gravitySlider.value = GRAVITY_PULL;
        }

        UpdateGravityText();
    }

    void HandleSliderChange(float value)
    {
        GRAVITY_PULL = value;
        UpdateGravityText();
    }

    void UpdateGravityText()
    {
        if (gravityPercentageText != null)
        {
            float percentage = (GRAVITY_PULL / gravitySlider.maxValue) * 100f;
            gravityPercentageText.text = $"Gravity Pull: {percentage:0.0}%";
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody && other.GetComponent<SingularityPullable>())
        {
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
        }
    }
}

