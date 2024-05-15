



namespace reactNet.Repositories;
public class PhotosRepository
{
    private readonly IDbConnection _db;

    public PhotosRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Photo CreatePhoto(Photo photoData)
    {
        string sql = @"
    INSERT INTO 
    photos(title, description, img, creatorId)
    VALUES(@Title, @Description, @Img, @CreatorId);
    SELECT 
    pho.*,
    acc.*
    FROM photos pho
    JOIN accounts acc ON pho.creatorId = acc.id
    WHERE pho.id = LAST_INSERT_ID();
";
        Photo photo = _db.Query<Photo, Account, Photo>(sql, (photo, account) =>
         {
             photo.Creator = account;
             return photo;
         }, photoData).FirstOrDefault();
        return photo;
    }

    internal void DestroyPhoto(int photoId, string userId)
    {
        string sql = "DELETE FROM photos WHERE id = @photoId LIMIT 1;";
        _db.Execute(sql, new { photoId });
    }

    internal Photo GetPhotoById(int photoId)
    {
        string sql = @"
       SELECT 
       pho.*,
       acc.*
       FROM photos pho
       JOIN accounts acc ON pho.creatorId = acc.id
       WHERE pho.id = @photoId;
       ";
        Photo photo = _db.Query<Photo, Account, Photo>(sql, (photo, account) =>
        {
            photo.Creator = account;
            return photo;
        }, new { photoId }).FirstOrDefault();
        return photo;
    }

    internal List<Photo> GetPhotos()
    {
        string sql = @"
    SELECT 
    pho.*,
    acc.*
    FROM photos pho
    JOIN accounts acc ON pho.creatorId = acc.id
    ";
        List<Photo> photos = _db.Query<Photo, Account, Photo>(sql, (photo, account) =>
        {
            photo.Creator = account;
            return photo;
        }).ToList();
        return photos;
    }
}