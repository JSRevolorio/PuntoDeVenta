namespace SPV.util
{
    /*
     Clase que funcionara como manejador de respuesta
     que se enviaran al cliente o a la vista por medio
     de archivos json.
    */

    public class Respuesta
    {        
        public string Mensaje {get; set;}
        public bool Estado {get; set;}
        public dynamic Resultado {get; set;}
    }
}
