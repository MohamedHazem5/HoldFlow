namespace HoldFlow.BL.Managers
{
    public class ImageManager : Manager<Image>, IImageManager
    {
        public ImageManager(IImageRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}