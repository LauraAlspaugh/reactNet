


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

    internal string DestroyPhoto(string userId, int photoId)
    {
        Photo photo = GetPhotoById(photoId);
        if (photo.CreatorId != userId)
        {
            throw new Exception("not yours to destroy!");

        }
        _photosRepository.DestroyPhoto(photoId, userId);
        return "It truly is gone";
    }

    internal Photo GetPhotoById(int photoId)
    {
        Photo photo = _photosRepository.GetPhotoById(photoId);
        if (photo == null)
        {
            throw new Exception("not a valid id");
        }
        return photo;
    }

    internal List<Photo> GetPhotos()
    {
        List<Photo> photos = _photosRepository.GetPhotos();
        return photos;
    }
}