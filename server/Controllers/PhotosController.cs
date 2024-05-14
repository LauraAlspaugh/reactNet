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
}