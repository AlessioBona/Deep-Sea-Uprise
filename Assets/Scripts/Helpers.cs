using UnityEngine;

namespace DefaultNamespace
{
    public static class Helpers
    {
        public static Vector2 ToPlaneVector2(this Vector3 vec)
        {
            return new Vector2(vec.x, vec.z);
        }
        public static Vector3 ToPlaneVector3(this Vector2 vec)
        {
            return new Vector3(vec.x,0, vec.y);
        }
    }
}