# prueba-craft-code
Prueba craft code

PASO 1: Eliminamos comentarios
Se eliminan los comentarios porque no son necesarios y en muchas ocasiones no aportan nada

PASO 2: Aplicamos guard clause
Se aplica guard clause en los if else de validación de subida del archivo para que quede más claro

PASO 3: Extract method
Se extrae la lógica a una función para encapsularla

PASO 4: Extract method y naming
Se separa el código extraido en funciones aislando la responsabilidad de partes del código y tratando de describir qué hace
También se renombran algunas variables para que tengan un nombre más explícito

PASO 5: Extract class
Movemos el código aislado en funciones a un use case específico para liberar de lógica el controlador

PASO 6: Excepcions de validación
Se crean excepciones en el controlador y en el use case, al ser una API y devover un JSON debería poder devolver las excepciones formateadas

PASO 7: Extract class, excepciones, value objects
Se crea una entidad User
Se crean los value objects correspondientes
Se crean las excpciones correspondientes
Se abstrae el reposirotio para desacoplar la dependencia de persistencia
Se crean las excepciones correspondientes

PASO 8: Eliminamos código muerto
No se usa el parámetro Users, además no tiene sentido porque pasamos un excel
Se elimina el código encargado de crear una conexión a base de datos que no se utilizaba

PASO 9: Extract method
Se extrae a una función el código que guarda el archivo y devuelve un path

PASO 10: Abstracción y extract class
Se elimina la necesidad de instanciar directamente el servicio Test2Entity en el repositorio

PASO 11: Extract Method - User factory, Repository y excepciones
Se crea una factoría para gestionar la creación del usuario desde la fila de excel ya que no es responsabilidad del use case hacer eso.

PASO 12: Extract class - Servicio de gestión de archivos
Se mueve la lógica de trabajo con los archivos a un servicio, 
se implementa el patrón template method para implementar las funcionalidades propias del proceso de archivos
Se generan las excepciones necesarias
Se abstraen las clases que se pueden considerar dependencias del servicio de archivos como la ibrería para procesar los archivos o el servidor
Se mueven las excepciones de validación del controlador a el servicoo específico

PASO 13: Tests
Test y stub sobre value objects, verificando las excepciones
Test sobre use case, verificando que se llama a colaboradores
Test sobre servicoo de gestión de archivos, verificanso las excepciones
