public class Healer : ChangerHealthState
{
    protected override void SendPoints() =>
        _health.GiveHeal(_points);
}