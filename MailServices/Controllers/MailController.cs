using FluentValidation.Results;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using MailService.Models;
using MailServices.Helpers;
using MailServices.Models;
using MailServices.Validations;

namespace MailServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {

        private readonly MailHelpers _mailHelpers;
        public MailController(MailHelpers mailHelpers)
        {
            _mailHelpers = mailHelpers;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] MailModel mail)
        {
            var validator = new MailModelValidation();
            var result = validator.Validate(mail);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _mailHelpers.SendEmail(mail.FromUser, mail);

            return Ok(new { mensaje = "Mensaje Enviado" });
        }


        [HttpPost("sendwithfile")]
        public async Task<IActionResult> SendWithFile([FromForm] List<IFormFile> FileDetails, [FromForm] MailModelForFrom mails) {

            if (FileDetails.Count == 0)
                return BadRequest(new { mensaje = "Los archivos son requeridos" });

            if (!_mailHelpers.IsCorrectFileType(FileDetails))
                return BadRequest(new { mensaje = "Algunos archivos no estan en el formato permitido" });


            var validator = new MailModelForFromValidation();
            var result = validator.Validate(mails);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var touser = JsonConvert.DeserializeObject<List<ToUser>>(mails.ToUser);

            var mail = new MailModel() {
                Body = mails.Body,
                IsHTMLBody = mails.IsHTMLBody,
                Subject = mails.Subject,
                ToUser = touser
            };

            var sendresult = await _mailHelpers.SendEmail(mails.FromUser, mail, FileDetails);

            return sendresult.isError ? BadRequest(sendresult) : Ok(sendresult);
        }

        [HttpGet("TiposArchivosPermitidos")]
        public List<FiletypeModelList> GetTiposFilesPermitidos() {
            return _mailHelpers.GetFiletypeModels();
        }

    }

    public enum TypeEmail
    { 
      Gmail,
      Outlook
    }
}
