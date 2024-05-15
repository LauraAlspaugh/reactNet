namespace reactNet.Controllers;
[ApiController]
[Route("[controller]")]
public class PhotosController : ControllerBase
{
    private readonly PhotosService _photosService;
    private readonly Auth0Provider _auth0Provider;

    public PhotosController(Auth0Provider auth0Provider)
    {
        _auth0Provider = auth0Provider;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Photo>> CreatePhoto([FromBody] Photo photoData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            photoData.CreatorId = userInfo.Id;
            Photo photo = _photosService.CreatePhoto(photoData);
            return Ok(photo);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }

    }
    [HttpGet]
    public ActionResult<List<Photo>> GetPhotos()
    {
        try
        {
            List<Photo> photos = _photosService.GetPhotos();
            return Ok(photos);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{photoId}")]
    public ActionResult<Photo> GetPhotoById(int photoId)
    {
        try
        {
            Photo photo = _photosService.GetPhotoById(photoId);
            return Ok(photo);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpDelete("{photoId}")]
    public async Task<ActionResult<string>> DestroyPhoto(int photoId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _photosService.DestroyPhoto(userId, photoId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}