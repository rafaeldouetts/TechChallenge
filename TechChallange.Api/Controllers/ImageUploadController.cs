using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*
using Microsoft.WindowsAzure.Storage;

namespace TechChallangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, int userId)
        {
            var connectionString = "sua string de conexão";
            var containerName = "seu container";

            try
            {
                // Converte o arquivo em um array de bytes
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();

                // Cria um objeto CloudStorageAccount a partir da string de conexão
                var storageAccount = CloudStorageAccount.Parse(connectionString);

                // Cria um objeto CloudBlobClient a partir da conta de armazenamento
                var blobClient = storageAccount.CreateCloudBlobClient();

                // Cria o contêiner caso ele não exista
                var container = blobClient.GetContainerReference(containerName);
                await container.CreateIfNotExistsAsync();

                // Define o nome do blob a partir do nome do arquivo
                var blobName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Faz upload do arquivo para o blob
                var blob = container.GetBlockBlobReference(blobName);
                await blob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);

                // Retorna uma resposta de sucesso
                return Ok();
            }
            catch (Exception ex)
            {
                // Retorna uma resposta de erro
                return BadRequest(ex.Message);
            }
        }

    }
}
*/