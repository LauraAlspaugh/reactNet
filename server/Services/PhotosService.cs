namespace reactNet.Services;
public class PhotosService
{
    private readonly PhotosRepository _photosRepository;

    public PhotosService(PhotosRepository photosRepository)
    {
        _photosRepository = photosRepository;
    }
}