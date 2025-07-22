[CreateAssetMenu(menuName = "Obstacle Behavior")]
public class ObstacleBehavior : ScriptableObject
{
    public float moveSpeed = 2.0f;
    public string obstacleType; // "plane", "cloud", or "cake_slice"
}
