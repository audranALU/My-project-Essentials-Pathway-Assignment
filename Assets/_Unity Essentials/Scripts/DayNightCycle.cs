using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day/Night Cycle")]
    [Tooltip("How many real-world seconds it takes to complete one full day.")]
    [Min(1f)]
    public float dayLengthSeconds = 300f;

    [Tooltip("Starting time of day in hours. 0 = midnight, 6 = sunrise, 12 = noon, 18 = sunset.")]
    [Range(0f, 24f)]
    public float startTime = 6f;

    private float timeOfDay;

    private void Start()
    {
        timeOfDay = startTime;
    }

    private void Update()
    {
        // Convert real-world elapsed time into game-world hours.
        timeOfDay += (24f / dayLengthSeconds) * Time.deltaTime;

        // Loop back to midnight after 24 hours.
        if (timeOfDay >= 24f)
            timeOfDay -= 24f;

        // Convert the current time into a rotation.
        // 6 AM  = sunrise
        // 12 PM = sun overhead
        // 6 PM  = sunset
        float sunAngle = (timeOfDay / 24f) * 360f - 90f;

        transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
    }
}
