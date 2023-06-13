//using Microsoft.WindowsAzure.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/", () => "Hello World!");
/*
app.MapPost("/upload", async (IFormFile formFile) => // (IFormFile file) =>
 {
    var connectionString = configuration.GetConnectionString("blobstorage");
    var containerName = "filescontainer";

    try
    {
        // Converte o arquivo em um array de bytes
        using var memoryStream = new MemoryStream();
        // Lê a imagem do corpo da requisição        
        await formFile.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();
        //var fileBytes = context.FileContents;
        // Cria um objeto CloudStorageAccount a partir da string de conexão
        var storageAccount = CloudStorageAccount.Parse(connectionString);

        // Cria um objeto CloudBlobClient a partir da conta de armazenamento
        var blobClient = storageAccount.CreateCloudBlobClient();

        // Cria o contêiner caso ele não exista
        var container = blobClient.GetContainerReference(containerName);
        await container.CreateIfNotExistsAsync();

        // Define o nome do blob a partir do nome do arquivo
        var blobName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

        // Faz upload do arquivo para o blob
        var blob = container.GetBlockBlobReference(blobName);
        await blob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);
        Results.NoContent();
    }
    catch (Exception ex)
    {
        Results.NotFound(ex);
    }
}).Accepts<FormFile>("multipart/form-data");
*/
app.Run();
