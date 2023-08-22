# MailService
Servicio de Envio de Emails

# Primeros Pasos

## Descripcion
- Servicio de envio de emails mediante la libreria MailKit, el servicio permite enviar archivos pdf, docx, jpg y png, a cualquier usuario siempre que no sobre pase los limites; permite enviar a muchos usuarios y muchos emails, inclusive enviar html como mensaje

## Como poner la contraseña en FromUser
- la contraseña no es la contraseña del correo sino Contraseñas de aplicaciones en google
- lo puede encontrar en Gestionar tu cuenta de Google,
- ahi en Buscar en la cuenta de Google, busca Contraseñas de aplicaciones,
- Coloca la contraseña de su cuenta, 
- luego Seleccionar aplicacion elige: Otra (nombre personalizado),
- luego escribe cualquier nombre, puede poner MailKit
- luego le da a generar,
- luego copia la contraseña que sale y lo pega en Password en la API
Ejemplo:
`{
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
}`
