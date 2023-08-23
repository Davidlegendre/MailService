# MailService
Servicio de Envio de Emails, tiene soporte para publicar en Docker

# Primeros Pasos

## Descripcion
- Servicio de envio de emails mediante la libreria MailKit, el servicio permite enviar archivos pdf, docx, jpg y png, a cualquier usuario siempre que no sobre pase los limites; permite enviar a muchos usuarios y muchos emails, inclusive enviar html como mensaje

## Como poner la contraseña en FromUser
- La contraseña no es la contraseña del correo sino Contraseñas de aplicaciones en google
- Lo puede encontrar en Gestionar tu cuenta de Google,
- Ahi en Buscar en la cuenta de Google, busca Contraseñas de aplicaciones,
- Coloca la contraseña de su cuenta, 
- Luego Seleccionar aplicacion elige: Otra (nombre personalizado),
- Luego escribe cualquier nombre, puede poner MailKit
- Luego le da a generar,
- Luego copia la contraseña que sale y lo pega en Password en la API
>Ejemplo:
```{
  "fromUser": {
    "nombreYApellido": "string", <= aca vas a poner tu nombre y apellido
    "email": "string", <= email tuyo
    "password": "string" <= la contraseña sacada de los pasos de arriba
  },
  "toUser": [ <= es una lista
    {
      "nombre": "string", <= nombre a quien quieres enviar
      "email": "string" <= email a quien quieres enviar
    }
  ],
  "subject": "string", <= sujeto
  "isHTMLBody": true, <= si es true, enviara body como html pero sino es texto
  "body": "string" <= body
}
```
### Tamaño de Archivos
> El tamaño de los archivos a enviar es: 24Mb

## Rutas
### /api/Mail/send [POST]
> Envia el correo normal (es decir sin archivos), puede enviar a una lista de usuarios, pero cuidado no se exceda ya que puede enviarlo a la carpeta Spam
> Puede enviar HTML Estatico, solo cambiando IsHTMLBody a True y enviando en Body un HTML String, recuerde que debe estar en una sola linea, como un string lineal
 
### /api/Mail/sendwithfile [POST]
> Envia un correo por formdata, puede enviar a multiples usuarios con multiples archivos soportados (JPG, PNG, PDF, DOCx).
> En ToUser debe tener la estructura de ToUser, eso en tipo string, pero tipo lista como array:
```
[
    {
      "nombre": "string", 
      "email": "string"
    }
]
```
### /api/Mail/TiposArchivosPermitidos [GET]
> Devuelve los tipos de archivos soportados (JPG, PNG, PDF, DOCX)

### Autor
David Legendre
- [LinkedIn](https://www.linkedin.com/in/david-legendre-albites-904a361a7/)

### Librerias
- MailKit
- FluentValidation

### Software Usado
Visual Studio 2022 (.NET 6.0)