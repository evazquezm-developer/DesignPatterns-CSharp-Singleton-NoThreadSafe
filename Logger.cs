using System;
using System.IO;

namespace DesignPatterns
{
    /// <summary>
    /// 1.- Al definir el constructor como privado,
    ///     previene que cualquier clase externa cree instancias de Logger.
    /// 2.- El metodo estatico GetInstance() devolvera siempre la misma instancia.    
    /// 3.- Y finalmente, la utilidad de este patron, sera insertar mensajes en un archivo;
    ///     mediante el metodo publico Log.
    /// 
    /// Para hacer simple este ejemplo, el nombre de archivo 'log.txt' esta fijo, pero deberia ser leido
    /// desde la configuracion.
    /// </summary>

    public class Logger {
        private static Logger? instance;

        private Logger() {
        }

        public static Logger GetInstance() {
            if ( instance == null ) {
                instance = new Logger();                
            }

            return instance;
        }

        public void Log(string textMessage)
        {
            using(var stream = File.AppendText("log.txt")) {
                stream.WriteLine( $"{DateTime.Now}: {textMessage }");
            }
        }
    }
}