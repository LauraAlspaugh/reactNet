namespace reactNet.Repositories;
public class PhotosRepository
{
    private readonly IDbConnection _db;

    public PhotosRepository(IDbConnection db)
    {
        _db = db;
    }
}