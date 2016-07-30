namespace SlackTrack.Commands
{
    public interface ICommandAction
    {
        bool IsMatch(SlackCommand command);
        SlackResponse Action(SlackCommand command);
    }
}