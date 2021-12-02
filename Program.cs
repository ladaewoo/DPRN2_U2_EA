using System;

namespace DPRN2_U2_EA_JOMV
{
    class Expediente
    {
        public Estudiante[] estudiantes = new Estudiante[10];
        public PadresFamilia[] padres = new PadresFamilia[10];
        public Profesor[] profesores = new Profesor[10];

        public Expediente()
        {

        }
    }

    abstract class Escuela
    {
        protected string nombreCompleto;
        protected int edad;
        protected string domicilio;
        protected string telefono;

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public Escuela(string nombreCompleto, int edad, string domicilio, string telefono) 
        {
            this.nombreCompleto = nombreCompleto;
            this.edad = edad;
            this.domicilio = domicilio;
            this.telefono = telefono;
        }
    }

    class Estudiante : Escuela
    {
        protected double promedio;
        protected int grado;
        protected string grupo;

        private int padreIndex;

        public double Promedio
        {
            get { return promedio; }
            set { promedio = value; }
        }

        public int Grado
        {
            get { return grado; }
            set { grado = value; }
        }

        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        public int getPadreIndex()
        {
            return padreIndex;
        }

        public Estudiante(string nombreCompleto, int edad, string domicilio, string telefono, double promedio, int grado, string grupo, int padreIndex) 
            : base (nombreCompleto, edad, domicilio, telefono)
        {
            this.promedio = promedio;
            this.grado = grado;
            this.grupo = grupo;
            this.padreIndex = padreIndex;
        }
    }

    class Profesor : Escuela
    {
        protected string grupo;
        protected string noNomina;
        protected double sueldoxhora;
        protected int antiguedad;
        protected int horasTrabajadas;

        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        public string NoNomina
        {
            get { return noNomina; }
            set { noNomina = value; }
        }

        public double SueldoXHora
        {
            get { return sueldoxhora; }
            set { sueldoxhora = value; }
        }

        public int Antiguedad
        {
            get { return antiguedad; }
            set { antiguedad = value; }
        }

        public int HorasTrabajadas
        {
            get { return horasTrabajadas; }
            set { horasTrabajadas = value; }
        }
        public Profesor(string nombreCompleto, int edad, string domicilio, string telefono, string grupo, string noNomina, double sueldoxhora, int antiguedad, int horasTrabajadas) 
            : base (nombreCompleto, edad, domicilio, telefono)
        {
            this.grupo = grupo;
            this.noNomina = noNomina;
            this.sueldoxhora = sueldoxhora;
            this.antiguedad = antiguedad;
            this.horasTrabajadas = horasTrabajadas;
        }

        public void identificacion()
        {
            Console.WriteLine("El nombre del profesor es <<{0}>>", nombreCompleto);
        }

    }

    class PadresFamilia : Escuela
    {
        protected int numeroHijos;
        protected string celular;
        protected string email;
        
        public int NumeroHijos
        {
            get { return numeroHijos; }
            set { numeroHijos = value; }
        }

        public void ConsultarCalificaciones(Estudiante estudiante, Profesor profesor)
        {
            string mensaje = "";

            if(estudiante.Promedio >= 9.5)
            {
                mensaje = "Su hijo ha obtenido una beca";
            } else if(estudiante.Promedio > 6 && estudiante.Promedio < 9.5)
            {
                mensaje = "Sin comentarios";
            } else {
                mensaje = "Su hijo está reprobado";
            }

            Console.WriteLine("Promedio: {0}", estudiante.Promedio);
            Console.WriteLine("Mensaje: {0}", mensaje);
            Console.WriteLine();
            Console.WriteLine("Nombre del estudiante: {0}", estudiante.NombreCompleto);
            Console.WriteLine("Edad: {0}", estudiante.Edad);
            Console.WriteLine("Domicilio: {0}", estudiante.Domicilio);
            Console.WriteLine("Telefono: {0}", estudiante.Telefono);
            Console.WriteLine("Grado: {0}", estudiante.Grado);
            Console.WriteLine("Grupo: {0}", estudiante.Grupo);
            Console.WriteLine();
            Console.WriteLine("Nombre del padre: {0}", nombreCompleto);
            Console.WriteLine("Edad: {0}", edad);
            Console.WriteLine("Domicilio: {0}", domicilio);
            Console.WriteLine("Telefono: {0}", telefono);
            Console.WriteLine("Celular: {0}", celular);
            Console.WriteLine("e-mail: {0}", email);
            profesor.identificacion();
        }

        public PadresFamilia(string nombreCompleto, int edad, string domicilio, string telefono, int numeroHijos) 
            : base (nombreCompleto, edad, domicilio, telefono)
        {
            this.numeroHijos = numeroHijos;
        }

        public PadresFamilia(string nombreCompleto, int edad, string domicilio, string telefono, int numeroHijos, string celular, string email) 
            : base (nombreCompleto, edad, domicilio, telefono)
        {
            this.numeroHijos = numeroHijos;
            this.celular = celular;
            this.email = email;
        }
    }

    class Program
    {
        private static Expediente expediente = new Expediente();
        private static int opcion;
        
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Hola, por favor selecciona un estudiante de la lista.");
            
            for (int i = 0; i < expediente.estudiantes.Length; i++)
            {
                if (expediente.estudiantes[i] != null)
                {
                    Console.WriteLine("{0}. {1}", i+1, expediente.estudiantes[i].NombreCompleto);
                }
            }

            opcion = Convert.ToInt32(Console.ReadLine());
        }

        public static  void CargarDatos()
        {
            expediente.estudiantes[0] = new Estudiante("Juan Pérez", 20, "Colina del abedul 1364", "55-55-5515", 5, 3, "A", 0);
            expediente.estudiantes[1] = new Estudiante("Maria López", 20, "Calle de mes #123", "55-56-6565", 10, 2, "B", 1);
            expediente.estudiantes[2] = new Estudiante("Pedro Pérez", 20, "Calz. ejercito 200", "55-33-3315", 8, 1, "C", 2);

            expediente.padres[0] = new PadresFamilia("Hugo Pérez", 35, "Avenida ocho de marzo #3012", "55-111-22", 2, "2222-1313", "hugo.perez@gmail.com");
            expediente.padres[1] = new PadresFamilia("Martha Carrillo", 35, "Claro de luna #30", "55-333-44", 2, "3443-1313", "martha.carrillo@gmail.com");
            expediente.padres[2] = new PadresFamilia("Jorge González", 35, "Av. principal #10", "55-777-22", 2, "9999-1313", "jorge.gonzalez@gmail.com");

            expediente.profesores[0] = new Profesor("Álvaro Pérez", 35, "Claro de luna #30", "55-777-22", "A", "12344", 400, 10, 20);
            expediente.profesores[1] = new Profesor("Sofía Perez", 35, "Av. principal #10", "55-444-22", "A", "12345", 600, 2, 45);               
        }
        static void Main(string[] args)
        {
            
            Console.Title = "Unidad 2. Evidencia de Aprendizaje";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            CargarDatos();
            Menu();

            while (opcion > 0 || opcion < 3)
            {
                Console.Clear();
                expediente.padres[0].ConsultarCalificaciones(expediente.estudiantes[opcion - 1], expediente.profesores[0]);
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }     
        
        }
    }
}
