using Api_Imagenes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Imagenes.Controllers
{
    [Route("Imagenes")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        [HttpPost("SuvirImagen")]
        public IActionResult SuvirImagen(ImagenesMoldels Imagene)
        {
            try
            {
                if (Imagene.Imagenes.Length == 0)
                    return BadRequest("Imagen no encontrada");

                var path = Path.Combine("wwwroot/Imagenes");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Random random = new();

                 path += "/" + random.Next(9999) + Imagene.Imagenes.FileName.Replace(" ", "");

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Imagene.Imagenes.CopyTo(stream);
                }


                return Ok(Imagene.Imagenes);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
