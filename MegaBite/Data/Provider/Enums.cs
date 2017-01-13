namespace MegaBite.Data.Provider
{
    public enum ProviderType : int
    {
        Unknown = 0,
        CloudBlob,
        CloudTable,
        Entity,
        File,
        Memory,
        Mock,
        WebAPI,
    }
}