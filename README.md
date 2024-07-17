# retoTecnicoHermes

Se propone las siguientes estructuras JSON para los objetos colaborador y tarea.

Colaborador
{
  "mensaje": "OK",
  "respuesta": [
    {
        "idColaborador": 1,
        "nombre": "Hermes",
        "apellido": "Brenes"
    }
  ]
}
Solamente se crea un GET mediante la url .../api/Colaborador/Lista en donde se obtiene la lista total de colaboradores almacenada en la base de datos.


Tarea
{
  "mensaje": "OK",
  "respuesta": {
    "idTarea": 13,
    "descripcion": "fin22",
    "estado": "PENDIENTE",
    "prioridad": "BAJA",
    "fechaInicio": "2024-07-17T06:15:55.913",
    "fechaFin": "2024-07-17T06:15:55.913",
    "idColaborador": 9,
    "nota": ""
  }
}
Se crea los puntos GET mediante la url .../api/Tarea/Lista para extraer todas las listas de la base de datos, .../api/Tarea/Obtener/{idTarea} para mostrar una tarea en especifico. POST con la url .../api/Tarea/Guardar y se envia la tarea como "body" de la solicitud. PUT con la url .../api/Tarea/Editar e igualmente se envia la tarea a editar como "body" de la solicitud y por último el DELETE con la url .../api/Tarea/Eliminar/{idTarea}.

Se usaron los estados de error:
200 con el mensaje "OK" indicando que todo el proceso fue exitoso.
400 con el mensaje mostrando los errores presentados.
404 con el mensaje "Tarea no encontrada" para cuando no se obtenga una tarea con el Id pasado por parámetros.
201 con el mensaje "Se ha creado la tarea con éxito" en el caso de que se crea una tarea correctamente.
 