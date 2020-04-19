using protoCorreo;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ApliProtoCorreo
{
    class Program
    {
        static void Main(string[] args)
        {

            //easilyMail mymail = new easilyMail();
            //try
            //{
            //    mymail.sned();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(mymail.Exceptions);
            //    Console.WriteLine(ex.Message);
            //}



            Attachment[] attachment = new Attachment[0];

            MessageService correo = new MessageService();

            string fromDisplayName = "Envio Prototipo Correo";
            string fromEmailAddress = "fmontoya@transer.com.co";
            string toName = "Interesados en el Correo";
            string toEmailAddress = "francisco.montoya.l@gmail.com";
            string subject = "Sujeto del Correo";
            string message = "Mensaje del Correo";


            string perrro = string.Empty;
            try
            {
                var tsk = correo.SendEmailAsync(fromDisplayName, fromEmailAddress, toName, toEmailAddress, subject, message, attachment);
                Console.WriteLine(correo.Exceptions);
                Console.WriteLine("id: " + tsk.Id);
                Console.WriteLine("status: " + tsk.Status);
                Console.WriteLine("Exception: " + tsk.Exception);
                perrro = correo.Exceptions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(correo.Exceptions);
                Console.WriteLine(ex.Message);
                perrro = correo.Exceptions;

            }
            Console.WriteLine(perrro);
            Console.WriteLine("Fin de la ejecucion.");
            Console.ReadKey();
        }
        [global::System.Serializable]
        public class MyException : Exception
        {
            public MyException() { }
            public MyException(string message, string metodo) { }
            public MyException(string message) : base(message) { }
            public MyException(string message, Exception inner) : base(message, inner) { }
            protected MyException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
