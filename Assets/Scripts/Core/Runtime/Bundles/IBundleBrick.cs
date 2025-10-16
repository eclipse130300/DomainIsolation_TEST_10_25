namespace Shop.Bundles
{
    public interface IBundleBrick
    {
        public void Apply();

        public bool IsAvailable();
    }
}