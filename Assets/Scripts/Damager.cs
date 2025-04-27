public class Damager : ChangerHealthState
{
    protected override void SendPoints() =>
        _health.GiveDamage(_points);
}