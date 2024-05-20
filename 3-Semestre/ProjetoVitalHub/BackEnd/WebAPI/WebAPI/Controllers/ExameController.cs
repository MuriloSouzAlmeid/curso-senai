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
        public IActionResult Post(Guid idConsulta, string descricaoExame)
        {
            try
            {
                Exame novoExame = new Exame();

                novoExame.ConsultaId = idConsulta;
                novoExame.Descricao = descricaoExame;

                _exameRepository.Cadastrar(novoExame);

                return Ok("Exame cadastrado com sucesso");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost("TranscreverTextoOCR")]
        public async Task<IActionResult> PostImageOCR([FromForm] ExameViewModel exameViewModel)
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

                    return Ok(result);
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