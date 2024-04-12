using Azure.Storage.Blobs;

namespace WebAPI.Utils.BlobStorage
{
    public static class AzureBlobStorageHelper
    {
        public static async Task<string> UploadImageBlobAsync(IFormFile arquivo, string stringConexao, string nomeContainer) {
			try
			{
				//verifica se foi feito o envio de um arquivo
				if(arquivo != null)
				{
					//gerou o nome do arquivo com sua extensão
					var blobName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(arquivo.FileName);

					//criou o cara responsável pela conexão com o blob passando a string de conexão
					var blobServiceClient = new BlobServiceClient(stringConexao);

					//nome do container que a imagem será salva
					var blobContainerClient = blobServiceClient.GetBlobContainerClient(nomeContainer);

					//obtem um blob client usando o blob name ???
					var blobClient = blobContainerClient.GetBlobClient(blobName);

					//recurso que faz a conexão com o blobStorage
					using(var stream = arquivo.OpenReadStream())
					{
						//passa o arquivo para a função de upload
						await blobClient.UploadAsync(stream, true);
					}

					//pega a url do arquivo setado
					return blobClient.Uri.ToString();
				}
				else
				{
					string imagemPadrao = "https://blobvitalhubmurilosouza.blob.core.windows.net/containervitalhubmurilosouza/profilePattern.png";

                    return imagemPadrao;
				}
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
