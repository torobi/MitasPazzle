namespace Domain.ITransition
{
    public interface ITransitionHandler
    {
        public void GoTo(Destination destination);
        
    }
    public enum Destination
    {
        TitleScene,
        RuleScene,
        MainScene
    }
}
