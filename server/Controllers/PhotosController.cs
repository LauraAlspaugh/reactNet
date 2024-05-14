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
}