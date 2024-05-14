
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
}