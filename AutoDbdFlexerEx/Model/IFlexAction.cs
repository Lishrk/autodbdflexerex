namespace AutoDbdFlexerEx.Model
{
    public interface IFlexAction
    {
        bool Active { get; }
        ActionConfig Config { get; set; }

        void Start();
        void Stop();
        void Toggle();
    }
}
