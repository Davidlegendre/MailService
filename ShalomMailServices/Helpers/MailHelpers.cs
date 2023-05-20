using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using MimeKit;
using ShalomMailService.Models;
using ShalomMailServices.Controllers;
using ShalomMailServices.Models;
using System.IO.Compression;
using System.IO;

namespace ShalomMailServices.Helpers
{
    public class MailHelpers
    {
        /*en el metodo GetFromUser, coloque sus credenciales*/

        //si agrega mas, tambien debe actualizar IsCorrectFileType, esta mas abajo...
        Dictionary<FileType, string> fileTypes = new Dictionary<FileType, string>() {
            { FileType.Other, "" },
            { FileType.PDF, "application/pdf" },
            { FileType.DOCX, "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            {  FileType.PNG, "image/png" }, 
            {FileType.JPG, "image/jpeg"}
        };

        Dictionary<TypeEmail, string> tiposEmails = new Dictionary<TypeEmail, string>() {
            { TypeEmail.Gmail,  "smtp.gmail.com"},
            { TypeEmail.Outlook, "smtp.live.com" }
        };

        public List<FiletypeModelList> GetFiletypeModels() { 
            var lista = new List<FiletypeModelList>();
            var tipos = Enum.GetValues(typeof(FileType));
            foreach(var type in tipos)
            {
                if ((FileType)type != FileType.Other)
                {
                    lista.Add(new FiletypeModelList() { Tipo = ((FileType)type).ToString() });
                }
            }
            return lista;

        }

        public FromUser GetFromUser() {
            return new FromUser() { 
                Email = "",
                IDTipoEmail = Controllers.TypeEmail.Gmail,
                NombreYApellido = "",
                Password = ""
                /*
                 *  la contraseña no es la contraseña del correo sino Contraseñas de aplicaciones en google
                    lo puede encontrar en Gestionar tu cuenta de Google,
                    ahi en Buscar en la cuenta de Google, busca Contraseñas de aplicaciones,
                    Coloca la contraseña de su cuenta, 
                    luego Seleccionar aplicacion elige: Otra (nombre personalizado),
                    luego escribe cualquier nombre, puede poner MailKit
                    luego le da a generar,
                    luego copia la contraseña que sale y lo pega en Password aqui en la clase
                 */
            };
        }

        public bool IsCorrectFileType(List<IFormFile> file) {
            bool result = true;
            foreach (var item in file)
            {
                if (item.ContentType != fileTypes.GetValueOrDefault(FileType.PDF)
                && item.ContentType != fileTypes.GetValueOrDefault(FileType.JPG)
                && item.ContentType != fileTypes.GetValueOrDefault(FileType.PNG)
                && item.ContentType != fileTypes.GetValueOrDefault(FileType.DOCX))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public async Task<ResultSendEmail> SendEmail(FromUser fromuser, MailModel mail, List<IFormFile>? file = null) {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromuser.NombreYApellido, fromuser.Email));
            message.Subject = mail.Subject;
            mail.ToUser.ForEach(x => {
                message.To.Add(new MailboxAddress(x.Nombre, x.Email));                
            });
           

            var builder = new BodyBuilder();
            if (!mail.IsHTMLBody) builder.TextBody = @mail.Body; else builder.HtmlBody = @mail.Body;
           
            if ( file != null)
            {
                var sum = file.Sum(x => x.Length);

                //maximo 24Mb
                if (sum > 25165824)
                {
                    return new ResultSendEmail() { Mensaje = "El peso de los archivos sobrepasa los 24Mb", isError = true };
                }

                foreach (var item in file)
                {
                    using (var memorystream = new MemoryStream())
                    {
                        await item.CopyToAsync(memorystream);
                        builder.Attachments.Add(item.FileName, memorystream.ToArray());
                    }
                }

            }
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(tiposEmails[fromuser.IDTipoEmail], 465, SecureSocketOptions.SslOnConnect);

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(fromuser.Email, fromuser.Password);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            return new ResultSendEmail() { Mensaje = "Mensaje Enviado", isError = false };
        }
    }
}
