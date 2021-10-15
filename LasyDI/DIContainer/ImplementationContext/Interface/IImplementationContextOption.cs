namespace LasyDI.DIContainer
{
    internal interface IImplementationContextOption
    {
        BindType BindType { get; }
        InstanceType InstanceType { get; }
    }
}
