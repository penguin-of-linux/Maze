using UnityEngine;

public static class Vector2Extensions
{
    public static float GetAngleFromCathetuses(this Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }
}