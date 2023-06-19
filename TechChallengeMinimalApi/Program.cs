using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

var politica = "CorsPolicy-public";

builder.Services.AddCors(option => option.AddPolicy(politica, builder => builder.WithOrigins("http://localhost:4200", "https://localhost")

	 .AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
				.Build()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//cors 
app.UseCors("CorsPolicy-public");

app.MapPost("/Upload", async (IFormFile formFile) =>
 {
    var connectionString = configuration.GetConnectionString("blobstorage");
    var containerName = "filescontainer";

    try
    {
        // Converte o arquivo em um array de bytes
        using var memoryStream = new MemoryStream();
        // L� a imagem do corpo da requisi��o        
        await formFile.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();
        // Cria um objeto CloudStorageAccount a partir da string de conex�o
        var storageAccount = CloudStorageAccount.Parse(connectionString);

        // Cria um objeto CloudBlobClient a partir da conta de armazenamento
        var blobClient = storageAccount.CreateCloudBlobClient();

        // Cria o cont�iner caso ele n�o exista
        var container = blobClient.GetContainerReference(containerName);
        await container.CreateIfNotExistsAsync();

         // Define o nome do blob a partir do nome do arquivo
         var blobName = Guid.NewGuid().ToString(); // + Path.GetExtension(formFile.FileName);

        // Faz upload do arquivo para o blob
        var blob = container.GetBlockBlobReference(blobName);
        await blob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);

         // Obt�m a URL de acesso ao blob
         //var blobUrl = blob.Uri.ToString();
         return Results.Ok(blobName);
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex);
    }
}).Accepts<FormFile>("multipart/form-data").WithTags("FileManagement");

app.MapGet("/GetSpecific", async (string blobName) =>
{
    string blobUrlWithSas = await GetBlobUrlWithSas(blobName, configuration);

    return Results.Ok(blobUrlWithSas);
}).WithName("GetSingle").WithTags("FileManagement");

app.MapGet("/GetMany", async (string stringBlobNameList) =>
{
    try
    {        
        List<string> blobNameList = stringBlobNameList.Split(',').ToList();
        var result = new Dictionary<string, string>();

        foreach (string blobName in blobNameList)
        {
            string blobUrlWithSas = await GetBlobUrlWithSas(blobName, configuration);
            if (!string.IsNullOrEmpty(blobUrlWithSas))
            {
                result.Add(blobName, blobUrlWithSas);
            }
        }
        return Results.Ok(result);
    } 
    catch (Exception ex)
    {
        return Results.NotFound(ex);
    }
}).WithName("GetMany").WithTags("FileManagement");

app.Run();

static async Task<string> GetBlobUrlWithSas(string blobName, IConfigurationRoot configuration)
{
    var containerName = "filescontainer";
    var connectionString = configuration.GetConnectionString("blobstorage");
    var storageAccount = CloudStorageAccount.Parse(connectionString);

    // Cria um objeto CloudBlobClient a partir da conta de armazenamento
    var blobClient = storageAccount.CreateCloudBlobClient();

    // Cria o cont�iner caso ele n�o exista
    var container = blobClient.GetContainerReference(containerName);
    await container.CreateIfNotExistsAsync();
    

    // Cria a referencia do Blob
    var blob = container.GetBlobReference(blobName);

    var checkIfExists = await blob.ExistsAsync();
    if (!checkIfExists) return string.Empty; 
    // Obt�m o SAS Token para o blob
    var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy
    {
        SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1), // Define o tempo de expira��o do SAS Token
        Permissions = SharedAccessBlobPermissions.Read // Define as permiss�es do SAS Token (somente leitura neste caso)
    });

    // Constr�i a URL do blob com o SAS Token
    var blobUrlWithSas = blob.Uri + sasToken;
    return blobUrlWithSas;
}