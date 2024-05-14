
namespace reactNet.Services;
public class PhotosService
{
    private readonly PhotosRepository _photosRepository;

    public PhotosService(PhotosRepository photosRepository)
    {
        _photosRepository = photosRepository;
    }

    internal Photo CreatePhoto(Photo photoData)
    {
        Photo photo = _photosRepository.CreatePhoto(photoData);
        return photo;
    }
}