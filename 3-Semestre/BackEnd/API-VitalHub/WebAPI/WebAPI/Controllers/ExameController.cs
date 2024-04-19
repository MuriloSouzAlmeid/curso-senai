using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domains;
using WebAPI.Interfaces;
using WebAPI.Utils.OCR;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IExameRepository _exameRepository;
        private readonly OCRService _ocrService;
        public ExameController(IExameRepository exameRepository, OCRService ocrService) 
        {
            _exameRepository = exameRepository;
            _ocrService = ocrService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ExameViewModel exameViewModel)
        {
            try
            {
                if (exameViewModel.Imagem == null || exameViewModel == null)
                {
                    return BadRequest("Nenhuma Imagem Fornecida");
                }

                using (var stream = exameViewModel.Imagem.OpenReadStream())
                {
                    var result = await _ocrService.RecognizeTextAsync(stream);

                    exameViewModel.Descricao = result;

                    Exame exame = new Exame()
                    {
                        Descricao = exameViewModel.Descricao,
                        ConsultaId = exameViewModel.ConsultaId
                    };

                    _exameRepository.Cadastrar(exame);

                    return Ok(exame);
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult GetByIdConsult(Guid id)
        {
            try
            {
                List<Exame> lista = _exameRepository.BuscarPorIdConsulta(id);

                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}